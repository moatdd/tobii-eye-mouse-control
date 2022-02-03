using System.Windows.Forms;

namespace TobiiFormApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.rightEyeLabel = new System.Windows.Forms.Label();
			this.leftEyeLabel = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.winkRightEnabled = new System.Windows.Forms.CheckBox();
			this.winkRightHotkeyCombo = new System.Windows.Forms.ComboBox();
			this.gazeLeftEnabled = new System.Windows.Forms.CheckBox();
			this.gazeLeftHotkeyCombo = new System.Windows.Forms.ComboBox();
			this.gazeLeftShift = new System.Windows.Forms.CheckBox();
			this.gazeLeftAlt = new System.Windows.Forms.CheckBox();
			this.gazeLeftCtrl = new System.Windows.Forms.CheckBox();
			this.gazeDownCtrl = new System.Windows.Forms.CheckBox();
			this.gazeDownAlt = new System.Windows.Forms.CheckBox();
			this.gazeDownShift = new System.Windows.Forms.CheckBox();
			this.gazeDownHotkeyCombo = new System.Windows.Forms.ComboBox();
			this.gazeDownEnabled = new System.Windows.Forms.CheckBox();
			this.gazeCenterCtrl = new System.Windows.Forms.CheckBox();
			this.gazeCenterAlt = new System.Windows.Forms.CheckBox();
			this.gazeCenterShift = new System.Windows.Forms.CheckBox();
			this.gazeCenterHotkeyCombo = new System.Windows.Forms.ComboBox();
			this.gazeCenterEnabled = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radioButton3);
			this.groupBox1.Controls.Add(this.radioButton2);
			this.groupBox1.Controls.Add(this.radioButton1);
			this.groupBox1.Location = new System.Drawing.Point(15, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(288, 70);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Gaze Smooth Filter";
			// 
			// radioButton3
			// 
			this.radioButton3.AutoSize = true;
			this.radioButton3.Location = new System.Drawing.Point(209, 31);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(70, 17);
			this.radioButton3.TabIndex = 2;
			this.radioButton3.TabStop = true;
			this.radioButton3.Text = "Unfiltered";
			this.radioButton3.UseVisualStyleBackColor = true;
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Location = new System.Drawing.Point(78, 31);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(114, 17);
			this.radioButton2.TabIndex = 1;
			this.radioButton2.TabStop = true;
			this.radioButton2.Text = "Weighted Average";
			this.radioButton2.UseVisualStyleBackColor = true;
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Checked = true;
			this.radioButton1.Location = new System.Drawing.Point(6, 31);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(52, 17);
			this.radioButton1.TabIndex = 0;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "Alpha";
			this.radioButton1.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 99);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(89, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Gaze Point X: ";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(12, 125);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(89, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Gaze Point Y: ";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(107, 99);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(13, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "0";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(107, 125);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(13, 13);
			this.label4.TabIndex = 5;
			this.label4.Text = "0";
			// 
			// rightEyeLabel
			// 
			this.rightEyeLabel.AutoSize = true;
			this.rightEyeLabel.Location = new System.Drawing.Point(253, 125);
			this.rightEyeLabel.Name = "rightEyeLabel";
			this.rightEyeLabel.Size = new System.Drawing.Size(29, 13);
			this.rightEyeLabel.TabIndex = 10;
			this.rightEyeLabel.Text = "false";
			// 
			// leftEyeLabel
			// 
			this.leftEyeLabel.AutoSize = true;
			this.leftEyeLabel.Location = new System.Drawing.Point(253, 99);
			this.leftEyeLabel.Name = "leftEyeLabel";
			this.leftEyeLabel.Size = new System.Drawing.Size(29, 13);
			this.leftEyeLabel.TabIndex = 9;
			this.leftEyeLabel.Text = "false";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(158, 125);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(70, 13);
			this.label7.TabIndex = 8;
			this.label7.Text = "Right Eye: ";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(158, 99);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(62, 13);
			this.label8.TabIndex = 7;
			this.label8.Text = "Left Eye: ";
			// 
			// winkRightEnabled
			// 
			this.winkRightEnabled.AutoSize = true;
			this.winkRightEnabled.Location = new System.Drawing.Point(15, 358);
			this.winkRightEnabled.Name = "winkRightEnabled";
			this.winkRightEnabled.Size = new System.Drawing.Size(79, 17);
			this.winkRightEnabled.TabIndex = 12;
			this.winkRightEnabled.Text = "Wink Right";
			this.winkRightEnabled.UseVisualStyleBackColor = true;
			// 
			// winkRightHotkeyCombo
			// 
			this.winkRightHotkeyCombo.FormattingEnabled = true;
			this.winkRightHotkeyCombo.Location = new System.Drawing.Point(15, 381);
			this.winkRightHotkeyCombo.Name = "winkRightHotkeyCombo";
			this.winkRightHotkeyCombo.Size = new System.Drawing.Size(279, 21);
			this.winkRightHotkeyCombo.TabIndex = 13;
			// 
			// gazeLeftEnabled
			// 
			this.gazeLeftEnabled.AutoSize = true;
			this.gazeLeftEnabled.Location = new System.Drawing.Point(15, 175);
			this.gazeLeftEnabled.Name = "gazeLeftEnabled";
			this.gazeLeftEnabled.Size = new System.Drawing.Size(72, 17);
			this.gazeLeftEnabled.TabIndex = 16;
			this.gazeLeftEnabled.Text = "Gaze Left";
			this.gazeLeftEnabled.UseVisualStyleBackColor = true;
			// 
			// gazeLeftHotkeyCombo
			// 
			this.gazeLeftHotkeyCombo.FormattingEnabled = true;
			this.gazeLeftHotkeyCombo.Location = new System.Drawing.Point(15, 198);
			this.gazeLeftHotkeyCombo.Name = "gazeLeftHotkeyCombo";
			this.gazeLeftHotkeyCombo.Size = new System.Drawing.Size(279, 21);
			this.gazeLeftHotkeyCombo.TabIndex = 17;
			// 
			// gazeLeftShift
			// 
			this.gazeLeftShift.AutoSize = true;
			this.gazeLeftShift.Location = new System.Drawing.Point(93, 175);
			this.gazeLeftShift.Name = "gazeLeftShift";
			this.gazeLeftShift.Size = new System.Drawing.Size(47, 17);
			this.gazeLeftShift.TabIndex = 18;
			this.gazeLeftShift.Text = "Shift";
			this.gazeLeftShift.UseVisualStyleBackColor = true;
			// 
			// gazeLeftAlt
			// 
			this.gazeLeftAlt.AutoSize = true;
			this.gazeLeftAlt.Location = new System.Drawing.Point(146, 175);
			this.gazeLeftAlt.Name = "gazeLeftAlt";
			this.gazeLeftAlt.Size = new System.Drawing.Size(38, 17);
			this.gazeLeftAlt.TabIndex = 19;
			this.gazeLeftAlt.Text = "Alt";
			this.gazeLeftAlt.UseVisualStyleBackColor = true;
			// 
			// gazeLeftCtrl
			// 
			this.gazeLeftCtrl.AutoSize = true;
			this.gazeLeftCtrl.Location = new System.Drawing.Point(190, 175);
			this.gazeLeftCtrl.Name = "gazeLeftCtrl";
			this.gazeLeftCtrl.Size = new System.Drawing.Size(59, 17);
			this.gazeLeftCtrl.TabIndex = 20;
			this.gazeLeftCtrl.Text = "Control";
			this.gazeLeftCtrl.UseVisualStyleBackColor = true;
			// 
			// gazeDownCtrl
			// 
			this.gazeDownCtrl.AutoSize = true;
			this.gazeDownCtrl.Location = new System.Drawing.Point(188, 225);
			this.gazeDownCtrl.Name = "gazeDownCtrl";
			this.gazeDownCtrl.Size = new System.Drawing.Size(59, 17);
			this.gazeDownCtrl.TabIndex = 25;
			this.gazeDownCtrl.Text = "Control";
			this.gazeDownCtrl.UseVisualStyleBackColor = true;
			// 
			// gazeDownAlt
			// 
			this.gazeDownAlt.AutoSize = true;
			this.gazeDownAlt.Location = new System.Drawing.Point(148, 225);
			this.gazeDownAlt.Name = "gazeDownAlt";
			this.gazeDownAlt.Size = new System.Drawing.Size(38, 17);
			this.gazeDownAlt.TabIndex = 24;
			this.gazeDownAlt.Text = "Alt";
			this.gazeDownAlt.UseVisualStyleBackColor = true;
			// 
			// gazeDownShift
			// 
			this.gazeDownShift.AutoSize = true;
			this.gazeDownShift.Location = new System.Drawing.Point(99, 225);
			this.gazeDownShift.Name = "gazeDownShift";
			this.gazeDownShift.Size = new System.Drawing.Size(47, 17);
			this.gazeDownShift.TabIndex = 23;
			this.gazeDownShift.Text = "Shift";
			this.gazeDownShift.UseVisualStyleBackColor = true;
			// 
			// gazeDownHotkeyCombo
			// 
			this.gazeDownHotkeyCombo.FormattingEnabled = true;
			this.gazeDownHotkeyCombo.Location = new System.Drawing.Point(15, 248);
			this.gazeDownHotkeyCombo.Name = "gazeDownHotkeyCombo";
			this.gazeDownHotkeyCombo.Size = new System.Drawing.Size(279, 21);
			this.gazeDownHotkeyCombo.TabIndex = 22;
			// 
			// gazeDownEnabled
			// 
			this.gazeDownEnabled.AutoSize = true;
			this.gazeDownEnabled.Location = new System.Drawing.Point(15, 225);
			this.gazeDownEnabled.Name = "gazeDownEnabled";
			this.gazeDownEnabled.Size = new System.Drawing.Size(82, 17);
			this.gazeDownEnabled.TabIndex = 21;
			this.gazeDownEnabled.Text = "Gaze Down";
			this.gazeDownEnabled.UseVisualStyleBackColor = true;
			// 
			// gazeCenterCtrl
			// 
			this.gazeCenterCtrl.AutoSize = true;
			this.gazeCenterCtrl.Location = new System.Drawing.Point(188, 275);
			this.gazeCenterCtrl.Name = "gazeCenterCtrl";
			this.gazeCenterCtrl.Size = new System.Drawing.Size(59, 17);
			this.gazeCenterCtrl.TabIndex = 30;
			this.gazeCenterCtrl.Text = "Control";
			this.gazeCenterCtrl.UseVisualStyleBackColor = true;
			// 
			// gazeCenterAlt
			// 
			this.gazeCenterAlt.AutoSize = true;
			this.gazeCenterAlt.Location = new System.Drawing.Point(149, 275);
			this.gazeCenterAlt.Name = "gazeCenterAlt";
			this.gazeCenterAlt.Size = new System.Drawing.Size(38, 17);
			this.gazeCenterAlt.TabIndex = 29;
			this.gazeCenterAlt.Text = "Alt";
			this.gazeCenterAlt.UseVisualStyleBackColor = true;
			// 
			// gazeCenterShift
			// 
			this.gazeCenterShift.AutoSize = true;
			this.gazeCenterShift.Location = new System.Drawing.Point(101, 275);
			this.gazeCenterShift.Name = "gazeCenterShift";
			this.gazeCenterShift.Size = new System.Drawing.Size(47, 17);
			this.gazeCenterShift.TabIndex = 28;
			this.gazeCenterShift.Text = "Shift";
			this.gazeCenterShift.UseVisualStyleBackColor = true;
			// 
			// gazeCenterHotkeyCombo
			// 
			this.gazeCenterHotkeyCombo.FormattingEnabled = true;
			this.gazeCenterHotkeyCombo.Location = new System.Drawing.Point(15, 298);
			this.gazeCenterHotkeyCombo.Name = "gazeCenterHotkeyCombo";
			this.gazeCenterHotkeyCombo.Size = new System.Drawing.Size(279, 21);
			this.gazeCenterHotkeyCombo.TabIndex = 27;
			// 
			// gazeCenterEnabled
			// 
			this.gazeCenterEnabled.AutoSize = true;
			this.gazeCenterEnabled.Location = new System.Drawing.Point(15, 275);
			this.gazeCenterEnabled.Name = "gazeCenterEnabled";
			this.gazeCenterEnabled.Size = new System.Drawing.Size(85, 17);
			this.gazeCenterEnabled.TabIndex = 26;
			this.gazeCenterEnabled.Text = "Gaze Center";
			this.gazeCenterEnabled.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(315, 411);
			this.Controls.Add(this.gazeCenterCtrl);
			this.Controls.Add(this.gazeCenterAlt);
			this.Controls.Add(this.gazeCenterShift);
			this.Controls.Add(this.gazeCenterHotkeyCombo);
			this.Controls.Add(this.gazeCenterEnabled);
			this.Controls.Add(this.gazeDownCtrl);
			this.Controls.Add(this.gazeDownAlt);
			this.Controls.Add(this.gazeDownShift);
			this.Controls.Add(this.gazeDownHotkeyCombo);
			this.Controls.Add(this.gazeDownEnabled);
			this.Controls.Add(this.gazeLeftCtrl);
			this.Controls.Add(this.gazeLeftAlt);
			this.Controls.Add(this.gazeLeftShift);
			this.Controls.Add(this.gazeLeftHotkeyCombo);
			this.Controls.Add(this.gazeLeftEnabled);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.leftEyeLabel);
			this.Controls.Add(this.rightEyeLabel);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.winkRightEnabled);
			this.Controls.Add(this.winkRightHotkeyCombo);
			this.Controls.Add(this.groupBox1);
			this.Name = "Form1";
			this.Text = "GazeKey";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox    groupBox1;
        public  System.Windows.Forms.RadioButton radioButton3;
        public  System.Windows.Forms.RadioButton radioButton2;
        public  System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label       label1;
        private System.Windows.Forms.Label       label2;
        public  System.Windows.Forms.Label       label3;
        public  System.Windows.Forms.Label       label4;
        public  System.Windows.Forms.Label       leftEyeLabel;
        public  System.Windows.Forms.Label       rightEyeLabel;
		private System.Windows.Forms.Label       label7;
		private System.Windows.Forms.Label       label8;
		public  CheckBox                         winkRightEnabled;
		public  ComboBox                         winkRightHotkeyCombo;
		public CheckBox gazeLeftEnabled;
		public ComboBox gazeLeftHotkeyCombo;
		public CheckBox gazeLeftShift;
		public CheckBox gazeLeftAlt;
		public CheckBox gazeLeftCtrl;
		public CheckBox gazeDownCtrl;
		public CheckBox gazeDownAlt;
		public CheckBox gazeDownShift;
		public ComboBox gazeDownHotkeyCombo;
		public CheckBox gazeDownEnabled;
		public CheckBox gazeCenterCtrl;
		public CheckBox gazeCenterAlt;
		public CheckBox gazeCenterShift;
		public ComboBox gazeCenterHotkeyCombo;
		public CheckBox gazeCenterEnabled;
	}
}

