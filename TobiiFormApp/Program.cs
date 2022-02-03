using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tobii.Interaction;
using WindowsInput;
using WindowsInput.Native;

namespace TobiiFormApp
{
    static class Program
    {
        private static Point prevPos;
        private static bool  hasPrevPos;
        private static float alpha = 0.3f;

        private enum filters
        {
            Smooth,
            Averaged,
            Unfiltered
        };

        private static bool _gazeLeftEnabled   = false;
        private static bool _gazeDownEnabled   = false;
        private static bool _gazeCenterEnabled = false;
        private static bool _winkRightEnabled  = false;
        private static int  _currentFilter;

        private static Form1                form;
        private static IKeyboardMouseEvents m_GlobalHook;

        private static void GlobalHookKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                InputSimulator inputSimulator = new InputSimulator(); //!!!!!
                inputSimulator.Mouse.LeftButtonDown();
            }
        }

        private static void GlobalHookKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                InputSimulator inputSimulator = new InputSimulator(); //!!!!!
                inputSimulator.Mouse.LeftButtonUp();
            }
        }

        private static bool leftWinkStatus      = false;
        private static bool rightWinkStatus     = false;
        private static bool _isWinkRightKeyDown = false;

        private enum GazeDirection
        {
            Center,
            Left,
            Right,
            Up,
            Down,
            UpLeft,
            UpRight,
            DownLeft,
            DownRight
        }

        private static GazeDirection _gazeDirection        = GazeDirection.Center;
        private static int           _gazeDirectionRepeats = 0;

        private static int            _winkStatusRepeats = 0;
        private const  int            numRepeatsNeeded   = 12;
        private static VirtualKeyCode _winkRightKeyCode  = VirtualKeyCode.LCONTROL;

        private static VirtualKeyCode              _gazeLeftKeyCode   = VirtualKeyCode.NUMPAD3;
        private static List<VirtualKeyCode> _gazeLeftModifiers = new List<VirtualKeyCode>() { VirtualKeyCode.CONTROL, VirtualKeyCode.MENU };

        private static VirtualKeyCode       _gazeDownKeyCode   = VirtualKeyCode.NUMPAD2;
        private static List<VirtualKeyCode> _gazeDownModifiers = new List<VirtualKeyCode>() { VirtualKeyCode.CONTROL, VirtualKeyCode.MENU };

        private static VirtualKeyCode       _gazeCenterKeyCode   = VirtualKeyCode.NUMPAD2;
        private static List<VirtualKeyCode> _gazeCenterModifiers = new List<VirtualKeyCode>() { VirtualKeyCode.CONTROL, VirtualKeyCode.MENU };

        private const int _screenLeft   = 0;
        private const int _screenRight  = 2560;
        private const int _screenTop    = 0;
        private const int _screenBottom = 1080;

        private static void WinkRightKey(bool leftEyeOpen, bool rightEyeOpen, double timestamp)
        {
            if (leftEyeOpen != leftWinkStatus || rightEyeOpen != rightWinkStatus)
            {
                leftWinkStatus     = leftEyeOpen;
                rightWinkStatus    = rightEyeOpen;
                _winkStatusRepeats = 0;
                return;
            }

            if (_winkStatusRepeats < numRepeatsNeeded)
            {
                _winkStatusRepeats++;
                return;
            }

            var gazeOnScreen = _gazeX >= 0 && _gazeY >= 0 && _gazeX <= _screenRight && _gazeY <= _screenBottom;
            var isWinking    = leftEyeOpen   && !rightEyeOpen   && gazeOnScreen;

            if (isWinking) _nextWinkRightTimestamp = timestamp + 1000;
            if (isWinking == _isWinkRightKeyDown)
                return;

            if (_inputSimulator == null)
                _inputSimulator = new InputSimulator(); //!!!!!

            if (isWinking)
            {
                _inputSimulator.Keyboard.KeyDown(_winkRightKeyCode);
                _isWinkRightKeyDown = true;
            }
            else if (timestamp > _nextWinkRightTimestamp)
            {
                _inputSimulator.Keyboard.KeyUp(_winkRightKeyCode);
                _isWinkRightKeyDown = false;
            }
        }

        private static GazeDirection _lastGazeDirection      = GazeDirection.Center;
        private static double        _gazeTimeoutTimestamp   = 0;
        private static double        _nextWinkRightTimestamp = 0;

        private static double _gazeX = 0;
        private static double _gazeY = 0;


        private static void GazeDirectionKey(GazeDirection gazeDirection, double timestamp)
        {
            if (gazeDirection != _lastGazeDirection)
            {
                _lastGazeDirection    = gazeDirection;
                _gazeDirectionRepeats = 0;
                return;
            }

            if (_gazeDirectionRepeats < numRepeatsNeeded)
            {
                _gazeDirectionRepeats++;
                return;
            }

            if (gazeDirection != GazeDirection.Center) _gazeTimeoutTimestamp = timestamp + 1000;


            if (_inputSimulator == null)
                _inputSimulator = new InputSimulator(); //!!!!!

            switch (gazeDirection)
            {
                case GazeDirection.Center:
                    if (timestamp > _gazeTimeoutTimestamp)
                    {
                        if (_gazeCenterEnabled)
                            _inputSimulator.Keyboard.ModifiedKeyStroke(_gazeCenterModifiers, _gazeCenterKeyCode);
                        _gazeDirection = gazeDirection;
                    }

                    break;
                case GazeDirection.Left:
                    if (_gazeLeftEnabled)
                        _inputSimulator.Keyboard.ModifiedKeyStroke(_gazeLeftModifiers, _gazeLeftKeyCode);
                    _gazeDirection = gazeDirection;
                    break;
                case GazeDirection.Right:
                    _gazeDirection = gazeDirection;
                    break;
                case GazeDirection.Up:
                    _gazeDirection = gazeDirection;
                    break;
                case GazeDirection.Down:
                    _gazeDirection = gazeDirection;
                    break;
                default:
                    _gazeDirection = gazeDirection;
                // throw new ArgumentOutOfRangeException(nameof(gazeDirection), gazeDirection, null);
                    break;
            }
        }


        private static InputSimulator _inputSimulator = null;

        //Moves the mouse cursor and applies filter based on the currently selected setting
        private static void moveCursor(int x, int y)
        {
            Cursor.Position = SmoothFilter(new Point(x, y));
        }

        private static void subscribeGlobalKeyHook()
        {
            m_GlobalHook         =  Hook.GlobalEvents();
            m_GlobalHook.KeyDown += GlobalHookKeyDown;
            m_GlobalHook.KeyUp   += GlobalHookKeyUp;
        }

        private static void unsubscribeGlobalKeyHook()
        {
            m_GlobalHook.KeyDown -= GlobalHookKeyDown;
            m_GlobalHook.KeyUp   -= GlobalHookKeyUp;
            m_GlobalHook.Dispose();
        }

        //Applies a filter to the point based on currently selected setting
        private static Point SmoothFilter(Point point)
        {
            //checks which filter is selected
            checkFilterSettings();

            Point filteredPoint = point;

            if (!hasPrevPos)
            {
                prevPos    = point;
                hasPrevPos = true;
            }

            if (_currentFilter == (int)filters.Smooth)
            {
                filteredPoint = new Point((int)((point.X * alpha) + (prevPos.X * (1.0f - alpha))),
                    (int)((point.Y                       * alpha) + (prevPos.Y * (1.0f - alpha))));
            }
            else if (_currentFilter == (int)filters.Averaged) //takes the average of the current point and the previous point
            {
                filteredPoint = new Point((point.X + prevPos.X) / 2, (point.Y + prevPos.Y) / 2);
            }

            prevPos = filteredPoint; //set the previous point to current point

            return filteredPoint;
        }

        private static void toggleGazeCenter(object       sender, EventArgs e) { _gazeCenterEnabled = ((CheckBox)sender).CheckState == CheckState.Checked; }
        private static void GazeCenterChangeHotkey(object sender, EventArgs e) { _gazeCenterKeyCode = (VirtualKeyCode)((ComboBox)sender).SelectedItem; }
        private static void toggleGazeCenterShift(object  sender, EventArgs e) { SetShift(ref _gazeCenterModifiers, ((CheckBox)sender).CheckState == CheckState.Checked); }
        private static void toggleGazeCenterCtrl(object   sender, EventArgs e) { SetCtrl(ref  _gazeCenterModifiers, ((CheckBox)sender).CheckState == CheckState.Checked); }
        private static void toggleGazeCenterAlt(object    sender, EventArgs e) { SetAlt(ref   _gazeCenterModifiers, ((CheckBox)sender).CheckState == CheckState.Checked); }
        
        private static void toggleGazeDown(object        sender, EventArgs e) { _gazeDownEnabled = ((CheckBox)sender).CheckState == CheckState.Checked; }
        private static void GazeDownChangeHotkey(object  sender, EventArgs e) { _gazeDownKeyCode = (VirtualKeyCode)((ComboBox)sender).SelectedItem; }
        private static void toggleGazeDownShift(object sender, EventArgs e) { SetShift(ref _gazeDownModifiers, ((CheckBox)sender).CheckState == CheckState.Checked); }
        private static void toggleGazeDownCtrl(object  sender, EventArgs e) { SetCtrl(ref  _gazeDownModifiers, ((CheckBox)sender).CheckState == CheckState.Checked); }
        private static void toggleGazeDownAlt(object   sender, EventArgs e) { SetAlt(ref   _gazeDownModifiers, ((CheckBox)sender).CheckState == CheckState.Checked); }

        private static void toggleGazeLeft(object       sender, EventArgs e) { _gazeLeftEnabled = ((CheckBox)sender).CheckState == CheckState.Checked; }
        private static void GazeLeftChangeHotkey(object sender, EventArgs e) { _gazeLeftKeyCode = (VirtualKeyCode)((ComboBox)sender).SelectedItem; }
        private static void toggleGazeLeftShift(object  sender, EventArgs e) { SetShift(ref _gazeLeftModifiers, ((CheckBox)sender).CheckState == CheckState.Checked); }
        private static void toggleGazeLeftCtrl(object   sender, EventArgs e) { SetCtrl(ref _gazeLeftModifiers, ((CheckBox)sender).CheckState  == CheckState.Checked); }
        private static void toggleGazeLeftAlt(object    sender, EventArgs e) { SetAlt(ref _gazeLeftModifiers, ((CheckBox)sender).CheckState   == CheckState.Checked); }

        [Flags]
        private enum HotkeyModifier
        {
            None = 0,
            Shift = 1 << 0,
            Alt = 1 << 1,
            Ctrl = 1 << 2
        }

        private static HotkeyModifier GetHotkeyModifier(ref IEnumerable<VirtualKeyCode> keycodes)
        {
            var virtualKeyCodes = keycodes as VirtualKeyCode[] ?? keycodes.ToArray();
            var result =
                (virtualKeyCodes.Contains(VirtualKeyCode.SHIFT) ? HotkeyModifier.Shift : HotkeyModifier.None) |
                (virtualKeyCodes.Contains(VirtualKeyCode.MENU) ? HotkeyModifier.Alt : HotkeyModifier.None) |
                (virtualKeyCodes.Contains(VirtualKeyCode.CONTROL) ? HotkeyModifier.Ctrl : HotkeyModifier.None);

            return result;
        }
        
        private static void SetShift(ref List<VirtualKeyCode> keyCodes, bool value)
        {
            if (value) { if (!keyCodes.Contains(VirtualKeyCode.SHIFT)) keyCodes.Add(VirtualKeyCode.SHIFT); }
            else { if (keyCodes.Contains(VirtualKeyCode.SHIFT)) keyCodes.Remove(VirtualKeyCode.SHIFT); }
        }
        
        private static void SetCtrl(ref List<VirtualKeyCode> keyCodes, bool value)
        {
            if (value) { if (!keyCodes.Contains(VirtualKeyCode.CONTROL)) keyCodes.Add(VirtualKeyCode.CONTROL); }
            else { if (keyCodes.Contains(VirtualKeyCode.CONTROL)) keyCodes.Remove(VirtualKeyCode.CONTROL); }
        }
        
        private static void SetAlt(ref List<VirtualKeyCode> keyCodes, bool value)
        {
            if (value) { if (!keyCodes.Contains(VirtualKeyCode.MENU)) keyCodes.Add(VirtualKeyCode.MENU); }
            else { if (keyCodes.Contains(VirtualKeyCode.MENU)) keyCodes.Remove(VirtualKeyCode.MENU); }
        }
        
        private static void toggleWinkRight(object        sender, EventArgs e) { _winkRightEnabled  = ((CheckBox)sender).CheckState == CheckState.Checked; }
        private static void WinkRightChangeHotkey(object  sender, EventArgs e) { _winkRightKeyCode  = (VirtualKeyCode)((ComboBox)sender).SelectedItem; }
        
        
        private static void checkFilterSettings()
        {
            if (form.radioButton1.Checked) //Smooth alpha filter
            {
                _currentFilter = (int)filters.Smooth;
            }
            else if (form.radioButton2.Checked) //Averaged filter
            {
                _currentFilter = (int)filters.Averaged;
            }
            else //unfiltered
            {
                _currentFilter = (int)filters.Unfiltered;
            }
        }

        [STAThread]
        static void Main()
        {
            var host = new Host();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            form = new Form1();

            // subscribeGlobalKeyHook();

            //handle the 'toggle gaze control' button event
            form.gazeLeftEnabled.CheckedChanged += new System.EventHandler(toggleGazeLeft);
            form.gazeLeftShift.CheckedChanged   += new System.EventHandler(toggleGazeLeftShift);
            form.gazeLeftAlt.CheckedChanged     += new System.EventHandler(toggleGazeLeftAlt);
            form.gazeLeftCtrl.CheckedChanged    += new System.EventHandler(toggleGazeLeftCtrl);
            form.gazeLeftCtrl.Checked           =  _gazeLeftModifiers.Contains(VirtualKeyCode.CONTROL);
            form.gazeLeftAlt.Checked           =  _gazeLeftModifiers.Contains(VirtualKeyCode.MENU);
            form.gazeLeftShift.Checked           =  _gazeLeftModifiers.Contains(VirtualKeyCode.SHIFT);
            
            form.gazeDownEnabled.CheckedChanged += new System.EventHandler(toggleGazeDown);
            form.gazeDownShift.CheckedChanged   += new System.EventHandler(toggleGazeDownShift);
            form.gazeDownAlt.CheckedChanged     += new System.EventHandler(toggleGazeDownAlt);
            form.gazeDownCtrl.CheckedChanged    += new System.EventHandler(toggleGazeDownCtrl);
            form.gazeDownCtrl.Checked           =  _gazeDownModifiers.Contains(VirtualKeyCode.CONTROL);
            form.gazeDownAlt.Checked            =  _gazeDownModifiers.Contains(VirtualKeyCode.MENU);
            form.gazeDownShift.Checked          =  _gazeDownModifiers.Contains(VirtualKeyCode.SHIFT);
            
            form.gazeCenterEnabled.CheckedChanged += new System.EventHandler(toggleGazeCenter);
            form.gazeCenterShift.CheckedChanged   += new System.EventHandler(toggleGazeCenterShift);
            form.gazeCenterAlt.CheckedChanged     += new System.EventHandler(toggleGazeCenterAlt);
            form.gazeCenterCtrl.CheckedChanged    += new System.EventHandler(toggleGazeCenterCtrl);
            form.gazeCenterCtrl.Checked             =  _gazeCenterModifiers.Contains(VirtualKeyCode.CONTROL);
            form.gazeCenterAlt.Checked              =  _gazeCenterModifiers.Contains(VirtualKeyCode.MENU);
            form.gazeCenterShift.Checked            =  _gazeCenterModifiers.Contains(VirtualKeyCode.SHIFT);
            
            form.winkRightEnabled.CheckedChanged  += new System.EventHandler(toggleWinkRight);

            var enumValues = Enum.GetValues(typeof(VirtualKeyCode));
            foreach (var enumValue in enumValues)
            {
                form.winkRightHotkeyCombo.Items.Add(enumValue);
                form.gazeLeftHotkeyCombo.Items.Add(enumValue);
                form.gazeDownHotkeyCombo.Items.Add(enumValue);
                form.gazeCenterHotkeyCombo.Items.Add(enumValue);
            }
            form.winkRightHotkeyCombo.SelectedItem = _winkRightKeyCode;
            form.gazeLeftHotkeyCombo.SelectedItem = _gazeLeftKeyCode;
            form.gazeDownHotkeyCombo.SelectedItem = _gazeDownKeyCode;
            form.gazeCenterHotkeyCombo.SelectedItem = _gazeCenterKeyCode;
            
            form.winkRightHotkeyCombo.SelectedValueChanged  += new System.EventHandler(WinkRightChangeHotkey);
            form.gazeLeftHotkeyCombo.SelectedValueChanged   += new System.EventHandler(GazeLeftChangeHotkey);
            form.gazeDownHotkeyCombo.SelectedValueChanged   += new System.EventHandler(GazeDownChangeHotkey);
            form.gazeCenterHotkeyCombo.SelectedValueChanged += new System.EventHandler(GazeCenterChangeHotkey);
            
            //create the data stream
            var gazePointDataStream = host.Streams.CreateGazePointDataStream(Tobii.Interaction.Framework.GazePointDataMode.LightlyFiltered);

            gazePointDataStream.GazePoint((x, y, timestamp) =>
            {
                
                // moveCursor((int)x, (int)y);
                //update the form labels with gaze coordinate
                GazeDirectionKey(GetGazeDirection(x, y), timestamp);
                _gazeX = x;
                _gazeY = y;

                form.label3.Invoke((MethodInvoker)(() => form.label3.Text = ((int)x).ToString()));
                form.label4.Invoke((MethodInvoker)(() => form.label4.Text = ((int)y).ToString()));
            });

            // var headPoseDataStream = host.Streams.CreateHeadPoseStream();
            // headPoseDataStream.HeadPose((timestamp, position, rotation) =>
            // {
            //     form.headRotationIndicator.Invoke((MethodInvoker)(() => form.headRotationIndicator.Text = rotation.ToString()));
            // });

            var eyePositionDataStream = host.Streams.CreateEyePositionStream(true);

            eyePositionDataStream.EyePosition((eyePosData) =>
            {
                if (!_winkRightEnabled) return;

                var leftEyeOpen  = eyePosData.HasLeftEyePosition;
                var rightEyeOpen = eyePosData.HasRightEyePosition;

                WinkRightKey(leftEyeOpen, rightEyeOpen, eyePosData.Timestamp);

                form.leftEyeLabel.Invoke((MethodInvoker)(() => form.leftEyeLabel.Text   = leftEyeOpen.ToString()));
                form.rightEyeLabel.Invoke((MethodInvoker)(() => form.rightEyeLabel.Text = rightEyeOpen.ToString()));
            });

            Application.Run(form);
        }

        private static GazeDirection GetGazeDirection(double x, double y)
        {
            if (x      >= _screenLeft && x <= _screenRight && y >= _screenTop && y <= _screenBottom) return GazeDirection.Center;
            else if (x >= _screenLeft && x <= _screenRight && y < _screenTop) return GazeDirection.Up;
            else if (x >= _screenLeft && x <= _screenRight && y > _screenBottom) return GazeDirection.Down;
            else if (x < _screenLeft  && y >= _screenTop   && y <= _screenBottom) return GazeDirection.Left;
            else if (x > _screenRight && y >= _screenTop   && y <= _screenBottom) return GazeDirection.Right;
            else if (x < _screenLeft  && y < _screenTop) return GazeDirection.UpLeft;
            else if (x > _screenRight && y < _screenTop) return GazeDirection.UpRight;
            else if (x < _screenLeft  && y > _screenBottom) return GazeDirection.DownLeft;
            else if (x > _screenRight && y > _screenBottom) return GazeDirection.DownRight;
            else return GazeDirection.Center;
        }
    }
}