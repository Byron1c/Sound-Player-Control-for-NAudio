using NAudio.Wave;
using Strangetimez;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestSoundControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private SoundPlayer sp;

        private void Form1_Load(object sender, EventArgs e)
        {
            // Visual controls
            soundPlayer1.Title = "Sound 1 - Default No Rec";
            soundPlayer1.TitleWidth = 200;
            soundPlayer2.Title = "Sound 2 - Default No Rec";
            soundPlayer2.TitleWidth = 200;
            soundPlayer3.Title = "Sound 3 - Mini Layout Formatted";
            soundPlayer3.TitleWidth = 200;
            soundPlayer4.Title = "Sound 4 - Custom Sizes";
            soundPlayer4.TitleWidth = 200;
            soundPlayer5.Title = "Sound 5 - Only Filename Set";
            soundPlayer5.TitleWidth = 200;

            soundPlayer1.ShowRecord = false;

            soundPlayer2.ShowRecord = false;

            soundPlayer3.BackColor  = Color.PaleGoldenrod;
            soundPlayer3.ShowDeviceList = false;
            soundPlayer3.ShowClearButton = false;
            soundPlayer3.ShowVolume = false;
            soundPlayer3.ShowFilename = false;
            soundPlayer3.ShowRecord = false;
            soundPlayer3.PlaybackStopped += SoundPlayer3_PlaybackStopped;
            soundPlayer3.RecordingStopped += SoundPlayer3_RecordingStopped;
            soundPlayer3.Filename = @"C:\Windows\Media\Alarm02.wav";
            soundPlayer3.BorderStyle = BorderStyle.FixedSingle;
            soundPlayer3.FileChanged += SoundPlayer1_FileChanged;
            soundPlayer3.DisabledColour = Color.Aquamarine;
            soundPlayer3.Volume = 90;


            soundPlayer4.VolumeChanged += SoundPlayer2_VolumeChanged;
            soundPlayer4.DeviceChanged += SoundPlayer2_DeviceChanged;
            soundPlayer4.RecordingFilename = @"C:\temp\sp";
            soundPlayer4.RecordingStopped += SoundPlayer4_RecordingStopped;
            soundPlayer4.DeviceListWidth = 200;
            soundPlayer4.FilenameWidth = 150;
            soundPlayer4.TitleWidth = 200;

            soundPlayer5.Filename = @"C:\Windows\Media\Alarm03.wav";
            soundPlayer5.RecordingStopped += SoundPlayer5_RecordingStopped;


            //Programattic 
            sp = new SoundPlayer(@"C:\Windows\Media\Alarm01.wav", 95); 
            sp.PlaybackStopped += sp_PlaybackStopped;
            btnPlaySound.Text += " " + sp.GetPlayTimeFormatted();

            // Misc 
            List<WaveInCapabilities> recordingDevices = soundPlayer2.RecordingDeviceList();
            List<WaveOutCapabilities> playbackDevices = soundPlayer2.PlaybackDeviceList();



            this.Disposed += Form1_Disposed;

        }






        #region Programattic
        private void sp_PlaybackStopped(object sender, NAudio.Wave.StoppedEventArgs e)
        {
            btnStopSound.Enabled = false;
            btnPlaySound.Enabled = true;
            MessageBox.Show("Programmatic sound has finished playing");
            sp.Dispose();
        }
        private void btnPlaySound_Click(object sender, EventArgs e)
        {
            btnStopSound.Enabled = true;
            btnPlaySound.Enabled = false;
            sp.Play();
        }
        private void btnStopSound_Click(object sender, EventArgs e)
        {
            btnStopSound.Enabled = false;
            btnPlaySound.Enabled = true;
            sp.Stop();
        }

        #endregion



        #region Visual Controls

        private void SoundPlayer5_RecordingStopped(object sender, Strangetimez.Objects.RecordDetectEventArgs e)
        {
            //set the recorded sound to be the playback sound on the same control
            soundPlayer5.Filename = soundPlayer5.RecordingFilename;

            MessageBox.Show("SP5 Recording finished. \n\nPress Play on the sound control to hear what you recorded:\n\n" + e.Filename);
        }

        private void SoundPlayer4_RecordingStopped(object sender, Strangetimez.Objects.RecordDetectEventArgs e)
        {
            //set the recorded sound to be the playback sound on the same control
            soundPlayer2.Filename = soundPlayer2.RecordingFilename;

            MessageBox.Show("SP4 Recording finished. \n\nPress Play on the sound control to hear what you recorded:\n\n" + e.Filename);
           
        }

        private void SoundPlayer3_RecordingStopped(object sender, Strangetimez.Objects.RecordDetectEventArgs e)
        {
            //set the recorded sound to be the playback sound on the same control
            soundPlayer2.Filename = soundPlayer2.RecordingFilename;

            MessageBox.Show("SP4 Recording finished. \n\nPress Play on the sound control to hear what you recorded:\n\n" + e.Filename);
        }

        private void SoundPlayer2_DeviceChanged(object sender, Strangetimez.Objects.DeviceDetectEventArgs e)
        {
            MessageBox.Show("SP2 Device changed to " + e.SoundDeviceName);
        }

        private void SoundPlayer2_VolumeChanged(object sender, Strangetimez.Objects.VolumeDetectEventArgs e)
        {
            MessageBox.Show("SP2 Volume changed to " + e.Volume);
        }

        private void SoundPlayer1_FileChanged(object sender, Strangetimez.Objects.FileDetectEventArgs e)
        {
            MessageBox.Show("SP1 Filename changed to " + e.Filename);
        }

        private void SoundPlayer3_PlaybackStopped(object sender, NAudio.Wave.StoppedEventArgs e)
        {
            MessageBox.Show("Sound Player #3 has finished playing");
        }


        private void cbEnable3_CheckedChanged(object sender, EventArgs e)
        {
            soundPlayer1.Enabled = cbEnable3.Checked;
            soundPlayer2.Enabled = cbEnable3.Checked;
            soundPlayer3.Enabled = cbEnable3.Checked;
            soundPlayer4.Enabled = cbEnable3.Checked;
            soundPlayer5.Enabled = cbEnable3.Checked;
        }
        
        #endregion



        // Cleanup
        private void Form1_Disposed(object sender, EventArgs e)
        {
            sp.Dispose();

            soundPlayer1.Dispose();
            soundPlayer2.Dispose();
            soundPlayer3.Dispose();
            soundPlayer4.Dispose();
            soundPlayer5.Dispose();
        }


    }
}
