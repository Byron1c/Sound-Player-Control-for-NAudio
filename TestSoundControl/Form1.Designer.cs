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
            this.btnPlaySound = new System.Windows.Forms.Button();
            this.btnStopSound = new System.Windows.Forms.Button();
            this.cbEnable3 = new System.Windows.Forms.CheckBox();
            this.soundPlayer1 = new Strangetimez.SoundPlayer();
            this.soundPlayer2 = new Strangetimez.SoundPlayer();
            this.soundPlayer3 = new Strangetimez.SoundPlayer();
            this.SuspendLayout();
            // 
            // btnPlaySound
            // 
            this.btnPlaySound.Location = new System.Drawing.Point(178, 119);
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
            this.btnStopSound.Location = new System.Drawing.Point(387, 119);
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
            this.cbEnable3.Location = new System.Drawing.Point(104, 84);
            this.cbEnable3.Name = "cbEnable3";
            this.cbEnable3.Size = new System.Drawing.Size(65, 17);
            this.cbEnable3.TabIndex = 17;
            this.cbEnable3.Text = "Enabled";
            this.cbEnable3.UseVisualStyleBackColor = true;
            this.cbEnable3.CheckedChanged += new System.EventHandler(this.cbEnable3_CheckedChanged);
            // 
            // soundPlayer1
            // 
            this.soundPlayer1.BackColor = System.Drawing.SystemColors.Control;
            this.soundPlayer1.DisabledColour = System.Drawing.SystemColors.Control;
            this.soundPlayer1.Filename = "";
            this.soundPlayer1.Location = new System.Drawing.Point(9, 9);
            this.soundPlayer1.Margin = new System.Windows.Forms.Padding(0);
            this.soundPlayer1.Name = "soundPlayer1";
            this.soundPlayer1.ShowClearButton = true;
            this.soundPlayer1.ShowDeviceList = true;
            this.soundPlayer1.ShowFilename = true;
            this.soundPlayer1.ShowTitle = true;
            this.soundPlayer1.ShowVolume = true;
            this.soundPlayer1.Size = new System.Drawing.Size(599, 24);
            this.soundPlayer1.SoundDeviceName = "Speakers (Conexant 20585 SmartA";
            this.soundPlayer1.TabIndex = 18;
            this.soundPlayer1.Title = "Sound Player";
            this.soundPlayer1.Volume = 50;
            // 
            // soundPlayer2
            // 
            this.soundPlayer2.BackColor = System.Drawing.SystemColors.Control;
            this.soundPlayer2.DisabledColour = System.Drawing.SystemColors.Control;
            this.soundPlayer2.Filename = "";
            this.soundPlayer2.Location = new System.Drawing.Point(9, 33);
            this.soundPlayer2.Margin = new System.Windows.Forms.Padding(0);
            this.soundPlayer2.Name = "soundPlayer2";
            this.soundPlayer2.ShowClearButton = true;
            this.soundPlayer2.ShowDeviceList = true;
            this.soundPlayer2.ShowFilename = true;
            this.soundPlayer2.ShowTitle = true;
            this.soundPlayer2.ShowVolume = true;
            this.soundPlayer2.Size = new System.Drawing.Size(599, 24);
            this.soundPlayer2.SoundDeviceName = "Speakers (Conexant 20585 SmartA";
            this.soundPlayer2.TabIndex = 19;
            this.soundPlayer2.Title = "Sound Player";
            this.soundPlayer2.Volume = 50;
            // 
            // soundPlayer3
            // 
            this.soundPlayer3.BackColor = System.Drawing.SystemColors.Control;
            this.soundPlayer3.DisabledColour = System.Drawing.SystemColors.Control;
            this.soundPlayer3.Filename = "";
            this.soundPlayer3.Location = new System.Drawing.Point(9, 57);
            this.soundPlayer3.Margin = new System.Windows.Forms.Padding(0);
            this.soundPlayer3.Name = "soundPlayer3";
            this.soundPlayer3.ShowClearButton = true;
            this.soundPlayer3.ShowDeviceList = true;
            this.soundPlayer3.ShowFilename = true;
            this.soundPlayer3.ShowTitle = true;
            this.soundPlayer3.ShowVolume = true;
            this.soundPlayer3.Size = new System.Drawing.Size(599, 24);
            this.soundPlayer3.SoundDeviceName = "Speakers (Conexant 20585 SmartA";
            this.soundPlayer3.TabIndex = 20;
            this.soundPlayer3.Title = "Sound Player";
            this.soundPlayer3.Volume = 50;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 171);
            this.Controls.Add(this.soundPlayer3);
            this.Controls.Add(this.soundPlayer2);
            this.Controls.Add(this.soundPlayer1);
            this.Controls.Add(this.cbEnable3);
            this.Controls.Add(this.btnStopSound);
            this.Controls.Add(this.btnPlaySound);
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
    }
}

