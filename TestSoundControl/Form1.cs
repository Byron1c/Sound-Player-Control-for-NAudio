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

        SoundPlayer sp;

        private void Form1_Load(object sender, EventArgs e)
        {
            soundPlayer1.Title = "Test Sound 1";
            soundPlayer2.Title = "Test Sound 2";
            soundPlayer3.Title = "Test Sound 3";

            soundPlayer1.BackColor  = Color.PaleGoldenrod;
            soundPlayer1.ShowDeviceList = false;
            soundPlayer1.ShowClearButton = false;
            soundPlayer1.ShowVolume = false;
            soundPlayer1.ShowFilename = false;
            soundPlayer1.PlaybackStopped += SoundPlayer1_PlaybackStopped;
            soundPlayer1.Filename = @"C:\Windows\Media\Alarm02.wav";
            soundPlayer1.BorderStyle = BorderStyle.FixedSingle;
            soundPlayer1.FileChangeDetected += SoundPlayer1_FileChangeDetected;

            //soundPlayer3.Enabled = false;
            soundPlayer3.Filename = @"C:\Windows\Media\Alarm03.wav";
            soundPlayer3.DisabledColour = Color.Aquamarine;

            sp = new SoundPlayer(@"C:\Windows\Media\Alarm01.wav", 95); 
            sp.PlaybackStopped += WaveOutput_PlaybackStopped;
            btnPlaySound.Text += " " + sp.GetPlayTimeFormatted();

            this.Disposed += Form1_Disposed;
        }

        private void SoundPlayer1_FileChangeDetected(object sender, Strangetimez.Objects.FileDetectEventArgs e)
        {
            MessageBox.Show("SP1 Filename changed to " + e.Filename);
        }

        private void Form1_Disposed(object sender, EventArgs e)
        {
            sp.Dispose();
        }

        private void SoundPlayer1_PlaybackStopped(object sender, NAudio.Wave.StoppedEventArgs e)
        {
            MessageBox.Show("Sound Player #1 has finished playing");
        }

        private void WaveOutput_PlaybackStopped(object sender, NAudio.Wave.StoppedEventArgs e)
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
            sp.PlaySound();
        }

        private void btnStopSound_Click(object sender, EventArgs e)
        {
            btnStopSound.Enabled = false;
            btnPlaySound.Enabled = true;
            sp.StopSound();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //sp.RawDeviceInfo();
        }

        private void cbEnable3_CheckedChanged(object sender, EventArgs e)
        {
            soundPlayer1.Enabled = cbEnable3.Checked;
            soundPlayer3.Enabled = cbEnable3.Checked;
        }
    }
}
