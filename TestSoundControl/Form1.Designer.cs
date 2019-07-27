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
            this.soundPlayer4 = new Strangetimez.SoundPlayer();
            this.soundPlayer3 = new Strangetimez.SoundPlayer();
            this.soundPlayer2 = new Strangetimez.SoundPlayer();
            this.soundPlayer1 = new Strangetimez.SoundPlayer();
            this.button1 = new System.Windows.Forms.Button();
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
            // soundPlayer4
            // 
            this.soundPlayer4.BackColor = System.Drawing.SystemColors.Control;
            this.soundPlayer4.Filename = "";
            this.soundPlayer4.Location = new System.Drawing.Point(9, 81);
            this.soundPlayer4.Margin = new System.Windows.Forms.Padding(0);
            this.soundPlayer4.Name = "soundPlayer4";
            this.soundPlayer4.ShowClearButton = true;
            this.soundPlayer4.ShowDeviceList = true;
            this.soundPlayer4.ShowFilename = true;
            this.soundPlayer4.ShowVolume = true;
            this.soundPlayer4.Size = new System.Drawing.Size(604, 24);
            this.soundPlayer4.SoundDeviceName = "Speakers (Conexant 20585 SmartA";
            this.soundPlayer4.TabIndex = 12;
            this.soundPlayer4.Volume = 50;
            // 
            // soundPlayer3
            // 
            this.soundPlayer3.BackColor = System.Drawing.SystemColors.Control;
            this.soundPlayer3.Filename = "";
            this.soundPlayer3.Location = new System.Drawing.Point(9, 57);
            this.soundPlayer3.Margin = new System.Windows.Forms.Padding(0);
            this.soundPlayer3.Name = "soundPlayer3";
            this.soundPlayer3.ShowClearButton = true;
            this.soundPlayer3.ShowDeviceList = true;
            this.soundPlayer3.ShowFilename = true;
            this.soundPlayer3.ShowVolume = true;
            this.soundPlayer3.Size = new System.Drawing.Size(604, 24);
            this.soundPlayer3.SoundDeviceName = "Speakers (Conexant 20585 SmartA";
            this.soundPlayer3.TabIndex = 11;
            this.soundPlayer3.Volume = 50;
            // 
            // soundPlayer2
            // 
            this.soundPlayer2.BackColor = System.Drawing.SystemColors.Control;
            this.soundPlayer2.Filename = "";
            this.soundPlayer2.Location = new System.Drawing.Point(9, 33);
            this.soundPlayer2.Margin = new System.Windows.Forms.Padding(0);
            this.soundPlayer2.Name = "soundPlayer2";
            this.soundPlayer2.ShowClearButton = true;
            this.soundPlayer2.ShowDeviceList = true;
            this.soundPlayer2.ShowFilename = true;
            this.soundPlayer2.ShowVolume = true;
            this.soundPlayer2.Size = new System.Drawing.Size(604, 24);
            this.soundPlayer2.SoundDeviceName = "Speakers (Conexant 20585 SmartA";
            this.soundPlayer2.TabIndex = 10;
            this.soundPlayer2.Volume = 50;
            // 
            // soundPlayer1
            // 
            this.soundPlayer1.BackColor = System.Drawing.SystemColors.Control;
            this.soundPlayer1.Filename = "";
            this.soundPlayer1.Location = new System.Drawing.Point(9, 9);
            this.soundPlayer1.Margin = new System.Windows.Forms.Padding(0);
            this.soundPlayer1.Name = "soundPlayer1";
            this.soundPlayer1.ShowClearButton = true;
            this.soundPlayer1.ShowDeviceList = true;
            this.soundPlayer1.ShowFilename = true;
            this.soundPlayer1.ShowVolume = true;
            this.soundPlayer1.Size = new System.Drawing.Size(604, 24);
            this.soundPlayer1.SoundDeviceName = "Speakers (Conexant 20585 SmartA";
            this.soundPlayer1.TabIndex = 9;
            this.soundPlayer1.Volume = 50;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(537, 136);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 171);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.soundPlayer4);
            this.Controls.Add(this.soundPlayer3);
            this.Controls.Add(this.soundPlayer2);
            this.Controls.Add(this.soundPlayer1);
            this.Controls.Add(this.btnStopSound);
            this.Controls.Add(this.btnPlaySound);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnPlaySound;
        private System.Windows.Forms.Button btnStopSound;
        private Strangetimez.SoundPlayer soundPlayer1;
        private Strangetimez.SoundPlayer soundPlayer2;
        private Strangetimez.SoundPlayer soundPlayer3;
        private Strangetimez.SoundPlayer soundPlayer4;
        private System.Windows.Forms.Button button1;
    }
}

