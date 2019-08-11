namespace TestSoundControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnPlaySound = new System.Windows.Forms.Button();
            this.btnStopSound = new System.Windows.Forms.Button();
            this.cbEnable3 = new System.Windows.Forms.CheckBox();
            this.soundPlayer3 = new Strangetimez.SoundPlayer();
            this.soundPlayer2 = new Strangetimez.SoundPlayer();
            this.soundPlayer1 = new Strangetimez.SoundPlayer();
            this.soundPlayer4 = new Strangetimez.SoundPlayer();
            this.soundPlayer5 = new Strangetimez.SoundPlayer();
            this.SuspendLayout();
            // 
            // btnPlaySound
            // 
            this.btnPlaySound.Location = new System.Drawing.Point(268, 186);
            this.btnPlaySound.Name = "btnPlaySound";
            this.btnPlaySound.Size = new System.Drawing.Size(203, 23);
            this.btnPlaySound.TabIndex = 3;
            this.btnPlaySound.Text = "Play Sound";
            this.btnPlaySound.UseVisualStyleBackColor = true;
            this.btnPlaySound.Click += new System.EventHandler(this.btnPlaySound_Click);
            // 
            // btnStopSound
            // 
            this.btnStopSound.Enabled = false;
            this.btnStopSound.Location = new System.Drawing.Point(477, 186);
            this.btnStopSound.Name = "btnStopSound";
            this.btnStopSound.Size = new System.Drawing.Size(75, 23);
            this.btnStopSound.TabIndex = 8;
            this.btnStopSound.Text = "Stop Sound";
            this.btnStopSound.UseVisualStyleBackColor = true;
            this.btnStopSound.Click += new System.EventHandler(this.btnStopSound_Click);
            // 
            // cbEnable3
            // 
            this.cbEnable3.AutoSize = true;
            this.cbEnable3.Checked = true;
            this.cbEnable3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbEnable3.Location = new System.Drawing.Point(218, 142);
            this.cbEnable3.Name = "cbEnable3";
            this.cbEnable3.Size = new System.Drawing.Size(65, 17);
            this.cbEnable3.TabIndex = 17;
            this.cbEnable3.Text = "Enabled";
            this.cbEnable3.UseVisualStyleBackColor = true;
            this.cbEnable3.CheckedChanged += new System.EventHandler(this.cbEnable3_CheckedChanged);
            // 
            // soundPlayer3
            // 
            this.soundPlayer3.BackColor = System.Drawing.SystemColors.Control;
            this.soundPlayer3.DeviceListWidth = 108;
            this.soundPlayer3.DisabledColour = System.Drawing.SystemColors.Control;
            this.soundPlayer3.Filename = "";
            this.soundPlayer3.FilenameWidth = 203;
            this.soundPlayer3.Location = new System.Drawing.Point(214, 61);
            this.soundPlayer3.Margin = new System.Windows.Forms.Padding(0);
            this.soundPlayer3.Name = "soundPlayer3";
            this.soundPlayer3.RecordingDeviceID = 0;
            this.soundPlayer3.RecordingFilename = "";
            this.soundPlayer3.ShowClearButton = false;
            this.soundPlayer3.ShowDeviceList = false;
            this.soundPlayer3.ShowFilename = false;
            this.soundPlayer3.ShowRecord = true;
            this.soundPlayer3.ShowTitle = true;
            this.soundPlayer3.ShowVolume = false;
            this.soundPlayer3.Size = new System.Drawing.Size(349, 26);
            this.soundPlayer3.SoundDeviceName = "Speakers (Conexant 20585 SmartA";
            this.soundPlayer3.State = Strangetimez.SoundPlayer.SoundControlState.None;
            this.soundPlayer3.TabIndex = 20;
            this.soundPlayer3.Title = "Sound Player";
            this.soundPlayer3.TitleWidth = 200;
            this.soundPlayer3.Volume = 50;
            // 
            // soundPlayer2
            // 
            this.soundPlayer2.BackColor = System.Drawing.SystemColors.Control;
            this.soundPlayer2.DeviceListWidth = 108;
            this.soundPlayer2.DisabledColour = System.Drawing.SystemColors.Control;
            this.soundPlayer2.Filename = "";
            this.soundPlayer2.FilenameWidth = 203;
            this.soundPlayer2.Location = new System.Drawing.Point(9, 35);
            this.soundPlayer2.Margin = new System.Windows.Forms.Padding(0);
            this.soundPlayer2.Name = "soundPlayer2";
            this.soundPlayer2.RecordingDeviceID = 0;
            this.soundPlayer2.RecordingFilename = "";
            this.soundPlayer2.ShowClearButton = true;
            this.soundPlayer2.ShowDeviceList = true;
            this.soundPlayer2.ShowFilename = true;
            this.soundPlayer2.ShowRecord = true;
            this.soundPlayer2.ShowTitle = true;
            this.soundPlayer2.ShowVolume = true;
            this.soundPlayer2.Size = new System.Drawing.Size(740, 26);
            this.soundPlayer2.SoundDeviceName = "Speakers (Conexant 20585 SmartA";
            this.soundPlayer2.State = Strangetimez.SoundPlayer.SoundControlState.None;
            this.soundPlayer2.TabIndex = 19;
            this.soundPlayer2.Title = "Sound Player";
            this.soundPlayer2.TitleWidth = 200;
            this.soundPlayer2.Volume = 50;
            // 
            // soundPlayer1
            // 
            this.soundPlayer1.BackColor = System.Drawing.SystemColors.Control;
            this.soundPlayer1.DeviceListWidth = 108;
            this.soundPlayer1.DisabledColour = System.Drawing.SystemColors.Control;
            this.soundPlayer1.Filename = "";
            this.soundPlayer1.FilenameWidth = 203;
            this.soundPlayer1.Location = new System.Drawing.Point(9, 9);
            this.soundPlayer1.Margin = new System.Windows.Forms.Padding(0);
            this.soundPlayer1.Name = "soundPlayer1";
            this.soundPlayer1.RecordingDeviceID = 0;
            this.soundPlayer1.RecordingFilename = "";
            this.soundPlayer1.ShowClearButton = true;
            this.soundPlayer1.ShowDeviceList = true;
            this.soundPlayer1.ShowFilename = true;
            this.soundPlayer1.ShowRecord = true;
            this.soundPlayer1.ShowTitle = true;
            this.soundPlayer1.ShowVolume = true;
            this.soundPlayer1.Size = new System.Drawing.Size(740, 26);
            this.soundPlayer1.SoundDeviceName = "Speakers (Conexant 20585 SmartA";
            this.soundPlayer1.State = Strangetimez.SoundPlayer.SoundControlState.None;
            this.soundPlayer1.TabIndex = 18;
            this.soundPlayer1.Title = "Sound Player";
            this.soundPlayer1.TitleWidth = 200;
            this.soundPlayer1.Volume = 50;
            // 
            // soundPlayer4
            // 
            this.soundPlayer4.BackColor = System.Drawing.SystemColors.Control;
            this.soundPlayer4.DeviceListWidth = 108;
            this.soundPlayer4.DisabledColour = System.Drawing.SystemColors.Control;
            this.soundPlayer4.Filename = "";
            this.soundPlayer4.FilenameWidth = 203;
            this.soundPlayer4.Location = new System.Drawing.Point(9, 87);
            this.soundPlayer4.Margin = new System.Windows.Forms.Padding(0);
            this.soundPlayer4.Name = "soundPlayer4";
            this.soundPlayer4.RecordingDeviceID = 0;
            this.soundPlayer4.RecordingFilename = "";
            this.soundPlayer4.ShowClearButton = true;
            this.soundPlayer4.ShowDeviceList = true;
            this.soundPlayer4.ShowFilename = true;
            this.soundPlayer4.ShowRecord = true;
            this.soundPlayer4.ShowTitle = true;
            this.soundPlayer4.ShowVolume = true;
            this.soundPlayer4.Size = new System.Drawing.Size(740, 26);
            this.soundPlayer4.SoundDeviceName = "Speakers (Conexant 20585 SmartA";
            this.soundPlayer4.State = Strangetimez.SoundPlayer.SoundControlState.None;
            this.soundPlayer4.TabIndex = 21;
            this.soundPlayer4.Title = "Sound Player";
            this.soundPlayer4.TitleWidth = 200;
            this.soundPlayer4.Volume = 50;
            // 
            // soundPlayer5
            // 
            this.soundPlayer5.BackColor = System.Drawing.SystemColors.Control;
            this.soundPlayer5.DeviceListWidth = 108;
            this.soundPlayer5.DisabledColour = System.Drawing.SystemColors.Control;
            this.soundPlayer5.Filename = "";
            this.soundPlayer5.FilenameWidth = 203;
            this.soundPlayer5.Location = new System.Drawing.Point(9, 113);
            this.soundPlayer5.Margin = new System.Windows.Forms.Padding(0);
            this.soundPlayer5.Name = "soundPlayer5";
            this.soundPlayer5.RecordingDeviceID = 0;
            this.soundPlayer5.RecordingFilename = "";
            this.soundPlayer5.ShowClearButton = true;
            this.soundPlayer5.ShowDeviceList = true;
            this.soundPlayer5.ShowFilename = true;
            this.soundPlayer5.ShowRecord = true;
            this.soundPlayer5.ShowTitle = true;
            this.soundPlayer5.ShowVolume = true;
            this.soundPlayer5.Size = new System.Drawing.Size(740, 26);
            this.soundPlayer5.SoundDeviceName = "Speakers (Conexant 20585 SmartA";
            this.soundPlayer5.State = Strangetimez.SoundPlayer.SoundControlState.None;
            this.soundPlayer5.TabIndex = 22;
            this.soundPlayer5.Title = "Sound Player";
            this.soundPlayer5.TitleWidth = 200;
            this.soundPlayer5.Volume = 50;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 221);
            this.Controls.Add(this.soundPlayer5);
            this.Controls.Add(this.soundPlayer4);
            this.Controls.Add(this.soundPlayer3);
            this.Controls.Add(this.soundPlayer2);
            this.Controls.Add(this.soundPlayer1);
            this.Controls.Add(this.cbEnable3);
            this.Controls.Add(this.btnStopSound);
            this.Controls.Add(this.btnPlaySound);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnPlaySound;
        private System.Windows.Forms.Button btnStopSound;
        private System.Windows.Forms.CheckBox cbEnable3;
        private Strangetimez.SoundPlayer soundPlayer1;
        private Strangetimez.SoundPlayer soundPlayer2;
        private Strangetimez.SoundPlayer soundPlayer3;
        private Strangetimez.SoundPlayer soundPlayer4;
        private Strangetimez.SoundPlayer soundPlayer5;
    }
}

