namespace Strangetimez
{
    partial class SoundPlayer
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtTitle = new System.Windows.Forms.Label();
            this.txtSoundFilename = new System.Windows.Forms.TextBox();
            this.btnLoadSound = new System.Windows.Forms.Button();
            this.btnPlaySound = new System.Windows.Forms.Button();
            this.btnStopSound = new System.Windows.Forms.Button();
            this.cbOutputDevice = new System.Windows.Forms.ComboBox();
            this.numVolume = new System.Windows.Forms.NumericUpDown();
            this.btnClearSound = new System.Windows.Forms.Button();
            this.btnRecord = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panelDisable = new Strangetimez.Objects.ExtendedPanel();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numVolume)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.txtTitle);
            this.flowLayoutPanel1.Controls.Add(this.txtSoundFilename);
            this.flowLayoutPanel1.Controls.Add(this.btnLoadSound);
            this.flowLayoutPanel1.Controls.Add(this.btnPlaySound);
            this.flowLayoutPanel1.Controls.Add(this.btnStopSound);
            this.flowLayoutPanel1.Controls.Add(this.cbOutputDevice);
            this.flowLayoutPanel1.Controls.Add(this.numVolume);
            this.flowLayoutPanel1.Controls.Add(this.btnClearSound);
            this.flowLayoutPanel1.Controls.Add(this.btnRecord);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(631, 25);
            this.flowLayoutPanel1.TabIndex = 42;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(3, 2);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(91, 21);
            this.txtTitle.TabIndex = 34;
            this.txtTitle.Text = "Title";
            this.txtTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSoundFilename
            // 
            this.txtSoundFilename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSoundFilename.Location = new System.Drawing.Point(96, 2);
            this.txtSoundFilename.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.txtSoundFilename.Name = "txtSoundFilename";
            this.txtSoundFilename.ReadOnly = true;
            this.txtSoundFilename.Size = new System.Drawing.Size(203, 20);
            this.txtSoundFilename.TabIndex = 36;
            // 
            // btnLoadSound
            // 
            this.btnLoadSound.BackColor = System.Drawing.Color.White;
            this.btnLoadSound.BackgroundImage = global::Strangetimez.Properties.Resources.browse_icon_small;
            this.btnLoadSound.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLoadSound.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadSound.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnLoadSound.Location = new System.Drawing.Point(301, 2);
            this.btnLoadSound.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.btnLoadSound.Name = "btnLoadSound";
            this.btnLoadSound.Size = new System.Drawing.Size(35, 20);
            this.btnLoadSound.TabIndex = 35;
            this.btnLoadSound.Text = "...";
            this.btnLoadSound.UseVisualStyleBackColor = true;
            this.btnLoadSound.Click += new System.EventHandler(this.btnLoadSound_Click);
            // 
            // btnPlaySound
            // 
            this.btnPlaySound.BackColor = System.Drawing.Color.White;
            this.btnPlaySound.BackgroundImage = global::Strangetimez.Properties.Resources.Play_1_Hot_icon_small;
            this.btnPlaySound.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPlaySound.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlaySound.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlaySound.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlaySound.Location = new System.Drawing.Point(338, 2);
            this.btnPlaySound.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.btnPlaySound.Name = "btnPlaySound";
            this.btnPlaySound.Size = new System.Drawing.Size(35, 20);
            this.btnPlaySound.TabIndex = 37;
            this.btnPlaySound.UseVisualStyleBackColor = true;
            this.btnPlaySound.Click += new System.EventHandler(this.btnPlaySound_Click);
            // 
            // btnStopSound
            // 
            this.btnStopSound.BackColor = System.Drawing.Color.White;
            this.btnStopSound.BackgroundImage = global::Strangetimez.Properties.Resources.Stop_red_icon_small_Disabled;
            this.btnStopSound.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStopSound.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStopSound.Enabled = false;
            this.btnStopSound.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStopSound.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStopSound.Location = new System.Drawing.Point(375, 2);
            this.btnStopSound.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.btnStopSound.Name = "btnStopSound";
            this.btnStopSound.Size = new System.Drawing.Size(35, 20);
            this.btnStopSound.TabIndex = 38;
            this.btnStopSound.UseVisualStyleBackColor = true;
            this.btnStopSound.Click += new System.EventHandler(this.btnStopSound_Click);
            // 
            // cbOutputDevice
            // 
            this.cbOutputDevice.FormattingEnabled = true;
            this.cbOutputDevice.Location = new System.Drawing.Point(412, 2);
            this.cbOutputDevice.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.cbOutputDevice.Name = "cbOutputDevice";
            this.cbOutputDevice.Size = new System.Drawing.Size(108, 21);
            this.cbOutputDevice.TabIndex = 39;
            this.cbOutputDevice.SelectedIndexChanged += new System.EventHandler(this.cbOutputDevice_SelectedIndexChanged);
            // 
            // numVolume
            // 
            this.numVolume.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numVolume.Location = new System.Drawing.Point(522, 2);
            this.numVolume.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.numVolume.Name = "numVolume";
            this.numVolume.Size = new System.Drawing.Size(42, 20);
            this.numVolume.TabIndex = 40;
            this.numVolume.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numVolume.ValueChanged += new System.EventHandler(this.numVolume_ValueChanged);
            // 
            // btnClearSound
            // 
            this.btnClearSound.BackColor = System.Drawing.Color.White;
            this.btnClearSound.BackgroundImage = global::Strangetimez.Properties.Resources.delete_small;
            this.btnClearSound.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClearSound.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearSound.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearSound.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearSound.Location = new System.Drawing.Point(566, 2);
            this.btnClearSound.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.btnClearSound.Name = "btnClearSound";
            this.btnClearSound.Size = new System.Drawing.Size(30, 20);
            this.btnClearSound.TabIndex = 41;
            this.btnClearSound.UseVisualStyleBackColor = true;
            this.btnClearSound.Click += new System.EventHandler(this.btnClearSound_Click);
            // 
            // btnRecord
            // 
            this.btnRecord.BackColor = System.Drawing.Color.White;
            this.btnRecord.BackgroundImage = global::Strangetimez.Properties.Resources.record_small;
            this.btnRecord.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRecord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecord.Location = new System.Drawing.Point(598, 2);
            this.btnRecord.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(30, 20);
            this.btnRecord.TabIndex = 42;
            this.btnRecord.UseVisualStyleBackColor = true;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // panelDisable
            // 
            this.panelDisable.BackColor = System.Drawing.SystemColors.Control;
            this.panelDisable.Location = new System.Drawing.Point(4, 4);
            this.panelDisable.Name = "panelDisable";
            this.panelDisable.Size = new System.Drawing.Size(640, 24);
            this.panelDisable.TabIndex = 46;
            this.panelDisable.Visible = false;
            // 
            // SoundPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panelDisable);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "SoundPlayer";
            this.Size = new System.Drawing.Size(640, 26);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numVolume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtSoundFilename;
        private System.Windows.Forms.Button btnStopSound;
        private System.Windows.Forms.ComboBox cbOutputDevice;
        private System.Windows.Forms.NumericUpDown numVolume;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnLoadSound;
        private System.Windows.Forms.Button btnPlaySound;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label txtTitle;
        private Objects.ExtendedPanel panelDisable;
        private System.Windows.Forms.Button btnClearSound;
        private System.Windows.Forms.Button btnRecord;
    }
}
