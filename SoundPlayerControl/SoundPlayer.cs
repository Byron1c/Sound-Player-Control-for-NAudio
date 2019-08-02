using Microsoft.Win32;
using NAudio.CoreAudioApi.Interfaces;
using NAudio.Wave;
using Strangetimez.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;



namespace Strangetimez
{

    public partial class SoundPlayer: UserControl
    {

        public enum SoundControlState
        {
            None,
            Playing,
            Recording,
            
        }


        /// <summary>
        /// Registers a call back for Device Events
        /// </summary>
        /// <param name="client">Object implementing IMMNotificationClient type casted as IMMNotificationClient interface</param>
        /// <returns></returns>
        public int RegisterEndpointNotificationCallback([In] [MarshalAs(UnmanagedType.Interface)] IMMNotificationClient client)
        {
            //DeviceEnum declared below
            return deviceEnum.RegisterEndpointNotificationCallback(client);
        }

        /// <summary>
        /// UnRegisters a call back for Device Events
        /// </summary>
        /// <param name="client">Object implementing IMMNotificationClient type casted as IMMNotificationClient interface </param>
        /// <returns></returns>
        public int UnRegisterEndpointNotificationCallback([In] [MarshalAs(UnmanagedType.Interface)] IMMNotificationClient client)
        {
            //DeviceEnum declared below
            return deviceEnum.UnregisterEndpointNotificationCallback(client);
        }
        

        /// <summary>
        /// The sound filename and path
        /// </summary>
        private String filename;
        public String Filename
        {
            get { return filename; }
            set { filename = value; txtSoundFilename.Text = value; setSoundButtons(); setToolTips(); }
        }


        /// <summary>
        /// The volume to play the sound at. 0 to 100
        /// </summary>
        private int volume;
        public int Volume
        {
            get { return volume; }
            set { volume = value;
                numVolume.Value = value;
            }
        }


        /// <summary>
        /// The name of the selected / default sound device
        /// </summary>
        private String soundDeviceName;
        public String SoundDeviceName
        {
            get { return soundDeviceName; }
            set { soundDeviceName = value; cbOutputDevice.SelectedItem = value; }
        }


        private Boolean showDeviceList;
        public Boolean ShowDeviceList
        {
            get { return showDeviceList; }
            set {
                showDeviceList = value;
                cbOutputDevice.Visible = value;
                SetControlWidth(); 
            }
        }


        private Boolean showClearButton;
        public Boolean ShowClearButton
        {
            get { return showClearButton; }
            set
            {
                showClearButton = value;
                btnClearSound.Visible = value;
                SetControlWidth(); 
            }
        }


        private Boolean showVolume;
        public Boolean ShowVolume
        {
            get { return showVolume; }
            set
            {
                showVolume = value;
                numVolume.Visible = value;
                SetControlWidth();
            }
        }


        private Boolean showFilename;
        public Boolean ShowFilename
        {
            get { return showFilename; }
            set
            {
                showFilename = value;
                txtSoundFilename.Visible = value;
                SetControlWidth();
            }
        }


        private String title;
        public String Title
        {
            get { return title; }
            set
            {
                title = value;
                txtTitle.Text  = value;
            }
        }


        private Boolean showTitle;
        public Boolean ShowTitle
        {
            get { return showTitle; }
            set
            {
                showTitle = value;
                txtTitle.Visible = value;
                SetControlWidth();
            }
        }


        private Boolean showRecord;
        public Boolean ShowRecord
        {
            get { return showTitle; }
            set
            {
                showRecord = value;
                btnRecord.Visible = value;
                SetControlWidth();
            }
        }


        private Color disabledColour;
        public Color DisabledColour
        {
            get { return disabledColour; }
            set
            {
                disabledColour = value;
                panelDisable.BackColor = value;
            }
        }


        private SoundControlState state;
        public SoundControlState State
        {
            get { return state; }
            set
            {
                state = value;
            }
        }


        private String recordingFilename;
        public String RecordingFilename
        {
            get { return recordingFilename; }
            set
            {
                recordingFilename = value;
                if (!String.IsNullOrEmpty(recordingFilename))
                {
                    // enable recording?
                }
                else
                {
                    // disable recording?
                }
            }
        }


        private int recordingDeviceID;
        public int RecordingDeviceID
        {
            get { return recordingDeviceID; }
            set
            {
                recordingDeviceID = value;
                SetRecordingDevice(value);
            }
        }


        public int DeviceListWidth
        {
            get { return cbOutputDevice.Width; }
            set
            {
                cbOutputDevice.Width = value;
                SetControlWidth();
            }
        }


        public int FilenameWidth
        {
            get { return txtSoundFilename.Width; }
            set
            {
                txtSoundFilename.Width = value;
                SetControlWidth();
            }
        }


        public int TitleWidth
        {
            get { return txtTitle.Width; }
            set
            {
                txtTitle.Width = value;
                SetControlWidth();
            }
        }




        // Playback Stopped event handling
        internal List<EventHandler<StoppedEventArgs>> PlaybackStoppedEventHandlers;
        public event EventHandler<StoppedEventArgs> PlaybackStopped
        {
            add
            {
                soundPlaying.WaveOutput.PlaybackStopped += value;
                PlaybackStoppedEventHandlers.Add(value);
            }
            remove
            {
                soundPlaying.WaveOutput.PlaybackStopped -= value;
                PlaybackStoppedEventHandlers.Remove(value);
            }
        }


        // Other event handlers
        public event EventHandler<FileDetectEventArgs> FileChanged;
        public event EventHandler<VolumeDetectEventArgs> VolumeChanged;
        public event EventHandler<DeviceDetectEventArgs> DeviceChanged;
        public event EventHandler<RecordDetectEventArgs> RecordingStopped;



        public const String recordingTempFilename = "SoundPlayerRecording";
        private const int padding = 2;

        private System.Timers.Timer tmrDeviceUpdate;
        private System.Timers.Timer tmrRecording;
        private int recordingTimeSeconds = 0;

        /// <summary>
        /// Used to indicate when the form is working on itsself
        /// </summary>
        private Boolean ApplyingSettings = false;

        /// <summary>
        ///  Sound event handler stuff
        /// </summary>
        private NAudio.CoreAudioApi.MMDeviceEnumerator deviceEnum = new NAudio.CoreAudioApi.MMDeviceEnumerator();
        private NotificationClientImplementation notificationClient;
        private NAudio.CoreAudioApi.Interfaces.IMMNotificationClient notifyClient;


        public WaveOutExt soundPlaying;
        private Mp3FileReader mp3FileReader;
        private WaveFileReader wavFileReader;

        // recording
        private WaveIn waveSource = null;
        private WaveFileWriter waveFile = null;



        public SoundPlayer()
        {
            InitializeComponent();

            Initialise();
        }


        public SoundPlayer(String vFilename, int vVolume, Boolean vShowDeviceList = true, Boolean vShowVolume = true, Boolean vShowClearButton = true, Boolean vShowFilename = true, Boolean vShowTitle = true)
        {
            InitializeComponent();

            Initialise();

            Filename = vFilename;
            Volume = vVolume;
            ShowDeviceList = vShowDeviceList;
            ShowVolume = vShowVolume;
            ShowClearButton = vShowClearButton;
            ShowFilename = vShowFilename;
            ShowTitle = vShowTitle;

            SetControlWidth();
        }



        private void Initialise()
        {
            ApplyingSettings = true;

            Volume = 50;
            Filename = string.Empty;
            SoundDeviceName = string.Empty;
            ShowDeviceList = true;
            ShowClearButton = true;
            ShowVolume = true;
            ShowFilename = true;
            ShowTitle = true;
            ShowRecord = true;
            DisabledColour = SystemColors.Control;
            State = SoundControlState.None;
            RecordingFilename = string.Empty;
            RecordingDeviceID = 0; // 0 = default

            Title = "Sound Player";

            PlaybackStoppedEventHandlers = new List<EventHandler<StoppedEventArgs>>();

            soundPlaying = new WaveOutExt();
            waveSource = new WaveIn();

            numVolume.KeyUp += NumVolume_KeyUp;
            this.Disposed += OnDispose;
            this.EnabledChanged += SoundPlayer_EnabledChanged;

            //Sound Event stuff
            notificationClient = new NotificationClientImplementation(this);
            notifyClient = (NAudio.CoreAudioApi.Interfaces.IMMNotificationClient)notificationClient;
            deviceEnum.RegisterEndpointNotificationCallback(notifyClient);

            //Timer that fires when devices change
            tmrDeviceUpdate = new System.Timers.Timer();
            tmrDeviceUpdate.Interval = 2000;
            tmrDeviceUpdate.Elapsed += TmrDeviceUpdate_Tick;

            tmrRecording = new System.Timers.Timer();
            tmrRecording.Interval = 1000;
            tmrRecording.Elapsed += TmrDeviceUpdate_Elapsed;
            recordingTimeSeconds = 0;

            SetSoundDeviceList();
            setSoundButtons();
            SetEnabled();

            // set the device to be the first listed device, if its not already set
            if (cbOutputDevice.Items.Count > 0 && String.IsNullOrEmpty(SoundDeviceName)) SoundDeviceName = cbOutputDevice.SelectedItem.ToString();

            ApplyingSettings = false;

        }

        private void TmrDeviceUpdate_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            recordingTimeSeconds++;
            setRecordingText();
        }

        private void SoundPlayer_EnabledChanged(object sender, EventArgs e)
        {
            SetEnabled();
        }

        private void SetEnabled()
        {
            panelDisable.Location = new Point(0, 0);
            panelDisable.BringToFront();
            flowLayoutPanel1.SendToBack();

            //flowLayoutPanel1.Enabled = this.Enabled;
            setSoundControlsAllEnabled(this.Enabled);
            panelDisable.Visible = !this.Enabled;            

            setSoundButtons();

            //stupid controls - cant get the clear button (or any button as last in the flow layout) to go BEHIND the panel, so Ill hide it
            //if (showClearButton) btnClearSound.Visible = this.Enabled;
        }

        // Note the naming
        public void OnNewFileDetect(FileDetectEventArgs e)
        {
            // Note this pattern for thread safety...
            EventHandler<FileDetectEventArgs> handler = this.FileChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        // Note the naming
        public void OnVolumeChangeDetect(VolumeDetectEventArgs e)
        {
            // Note this pattern for thread safety...
            EventHandler<VolumeDetectEventArgs> handler = this.VolumeChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        // Note the naming
        public void OnDeviceChangeDetect(DeviceDetectEventArgs e)
        {
            // Note this pattern for thread safety...
            EventHandler<DeviceDetectEventArgs> handler = this.DeviceChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void OnRecordingStoppedDetect(RecordDetectEventArgs e)
        {
            // Note this pattern for thread safety...
            EventHandler<RecordDetectEventArgs> handler = this.RecordingStopped;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        

        private void SetControlWidth()
        {
            int width = 0;
            if (txtTitle.Visible) width += txtTitle.Width + padding;
            if (txtSoundFilename.Visible) width += txtSoundFilename.Width + padding;
            if (btnLoadSound.Visible) width += btnLoadSound.Width + padding;
            if (btnPlaySound.Visible) width += btnPlaySound.Width + padding;
            if (btnStopSound.Visible) width += btnStopSound.Width + padding;
            if (numVolume.Visible) width += numVolume.Width + padding;
            if (cbOutputDevice.Visible) width += cbOutputDevice.Width + padding;
            if (btnClearSound.Visible) width += btnClearSound.Width + padding;
            if (btnRecord.Visible) width += btnRecord.Width + padding;
            this.Width = width + (padding * 2); // extra padding for the flowlayout
        }

        private void NumVolume_KeyUp(object sender, KeyEventArgs e)
        {
            Volume = (int)numVolume.Value;
        }

        private void btnLoadSound_Click(object sender, EventArgs e)
        {
            //clear any used resources
            CloseWaveOut(false);

            string filePath = OpenSoundFile();
            if (filePath != string.Empty) Filename = filePath;

            if (String.IsNullOrEmpty(Filename))
            {
                Volume = 50;
                numVolume.Value = (decimal)50f;
                numVolume.Enabled = true;
            } else
            {
                // raise event for filename change
                OnNewFileDetect(new FileDetectEventArgs(Filename));
                setToolTips();
            }

            setSoundButtons();
        }


        private void setToolTips()
        {
            string formattedTime = GetTimeFormatted(GetPlayTimeSeconds());

            if (!string.IsNullOrEmpty(formattedTime))
            {
                toolTip1.SetToolTip(btnPlaySound, String.Format(Filename + "\nPlay Time: " + formattedTime));
                toolTip1.SetToolTip(txtSoundFilename, String.Format(Filename + "\nPlay Time: " + formattedTime));
                toolTip1.SetToolTip(btnStopSound, String.Format(Filename + "\nPlay Time: " + formattedTime));
            }
            else
            {
                toolTip1.SetToolTip(btnPlaySound, String.Empty);
                toolTip1.SetToolTip(txtSoundFilename, String.Empty);
                toolTip1.SetToolTip(btnStopSound, String.Empty);
            }

            toolTip1.SetToolTip(btnRecord, RecordingFilename);
        }


        public string GetPlayTimeFormatted()
        {
            return GetTimeFormatted(GetPlayTimeSeconds());
        }


        private string GetTimeFormatted(int vSeconds)
        {
            int seconds = vSeconds; 
            if (seconds > -1)
            {
                TimeSpan t = TimeSpan.FromSeconds(seconds);

                string formattedTime = string.Format("{0:D2}h:{1:D2}m:{2:D2}s", //:{3:D3}ms",
                                t.Hours,
                                t.Minutes,
                                t.Seconds);

                return formattedTime;
            }

            return string.Empty;
            
        }


        /// <summary>
        /// Returns the number of seconds that the sound file plays for
        /// </summary>
        /// <returns>returns a positive value for the number of seconds. 
        /// returns -1 when no file found or specified</returns>
        public int GetPlayTimeSeconds()
        {
            return getPlayTimeSeconds(Filename);
        }


        /// <summary>
        /// Select a sound file
        /// </summary>
        /// <returns></returns>
        private static string OpenSoundFile()
        {
            String output = string.Empty;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            string allExtensions = "*.wav;*.aiff;*.mp3;*.aac";
            openFileDialog.Filter = String.Format("All Supported Files|{0}|All Files (*.*)|*.*", allExtensions);
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                output = openFileDialog.FileName;
            }
            
            openFileDialog.Dispose();

            return output;

        }

        private void btnPlaySound_Click(object sender, EventArgs e)
        {
            Play();
        }

        public void Play()
        {
            //disableButtonsOnPlay();
            State = SoundControlState.Playing;
            setButtonsOnPlay(ref btnPlaySound, ref btnStopSound, ref btnLoadSound, ref btnRecord);
            playSound(Filename, getSoundDeviceIDByName(SoundDeviceName), Volume);
            
        }

        private void setButtonsOnPlay(ref Button vPlayButton, ref Button vStopButton, ref Button vBrowseButton, ref Button vRecordButton)
        {
            vStopButton.Enabled = true;
            vStopButton.BackgroundImage = (Image)new Bitmap(Properties.Resources.Stop_red_icon_small);

            vPlayButton.Enabled = false;
            vPlayButton.BackgroundImage = (Image)new Bitmap(Properties.Resources.Play_1_Hot_icon_small_Disabled);

            vBrowseButton.Enabled = false;
            vBrowseButton.BackgroundImage = (Image)new Bitmap(Properties.Resources.browse_icon_Disabled);

            vRecordButton.Enabled = false;
            vRecordButton.BackgroundImage = (Image)new Bitmap(Properties.Resources.record_small_Disabled);

        }



        //private void disableButtonsOnPlay()
        //{
        //    btnPlaySound.Enabled = false;
        //    btnPlaySound.BackgroundImage = (Image)new Bitmap(Properties.Resources.Play_1_Hot_icon_small_Disabled);
        //}


        /// <summary>
        /// Get the sound device ID from the name
        /// </summary>
        /// <param name="vName"></param>
        /// <returns></returns>
        private int getSoundDeviceIDByName(String vName)
        {
            int output = 0; // default to the first item

            if (String.IsNullOrEmpty(vName)) return 0; // 0 or -1 is "default" 

            int waveOutDevices = WaveOut.DeviceCount;
            for (int waveOutDevice = 0; waveOutDevice < waveOutDevices; waveOutDevice++)
            {
                WaveOutCapabilities deviceInfo = WaveOut.GetCapabilities(waveOutDevice);

                //if (RemoveTextToRight(deviceInfo.ProductName, "(") == vName)
                if (deviceInfo.ProductName == vName)
                {
                    output = waveOutDevice;
                    break;
                }

            }

            return output;
        }

        public void SetSoundDeviceByName(String vName)
        {
            SoundDeviceName = vName;
    
        }
        public void SetSoundDeviceByID(int vDeviceID)
        {
            int waveOutDevices = WaveOut.DeviceCount;
            for (int waveOutDevice = 0; waveOutDevice < waveOutDevices; waveOutDevice++)
            {
                WaveOutCapabilities deviceInfo = WaveOut.GetCapabilities(waveOutDevice);

                if (waveOutDevice == vDeviceID)
                {
                    SetSoundDeviceByName(deviceInfo.ProductName);
                    break;
                }

            }
        }



        private void playSound(String vFile, int vDeviceID, int vVolume) //File: settings.CurrentSettings.SoundBreakWarning
        {

            try
            {
                string ext = System.IO.Path.GetExtension(vFile);

                // if no sound in this slot, then exit
                if (soundPlaying == null) return;

                // if no file specified, then exit
                if (vFile == string.Empty)
                {
                    return;
                }

                if (ext.ToUpper().Trim().Replace(".", "") == "MP3")
                {
                    mp3FileReader = new Mp3FileReader(vFile);
                }
                else if ((ext.ToUpper().Trim().Replace(".", "") == "WAV"))
                {
                    wavFileReader = new WaveFileReader(vFile);
                }
                else
                {
                    //TODO: log this as an error?
                    return; // no suitable file selected
                }

                soundPlaying.WaveOutput.DeviceNumber = vDeviceID; //settings.CurrentSettings.SoundBreakWarningDeviceID;
                soundPlaying.WaveOutput.PlaybackStopped += WaveOut_PlaybackStopped;
                soundPlaying.WaveOutput.Volume = (float)(vVolume / 100.0f);



                if (ext.ToUpper().Trim().Replace(".", "") == "MP3")
                {
                    soundPlaying.WaveOutput.Init(mp3FileReader);
                }
                else if ((ext.ToUpper().Trim().Replace(".", "") == "WAV"))
                {
                    soundPlaying.WaveOutput.Init(wavFileReader);
                }
                else
                {
                    //TODO: log this as an error?
                    return; // no suitable file selected
                }


                soundPlaying.WaveOutput.Play();

            }
            catch (Exception ex)
            {
                //ProcessError(ex, ErrorMessageType.SoundPlaying, ShowError.NoShow, ThrowError.NoThrow, String.Format(CultureInfo.InvariantCulture, ""), FileFunctions.GetErrorLogFullPath());
            }


        }



        private void WaveOut_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            CloseWaveOut(false);
            resetSoundButtonsDefault();

        }



        private void resetSoundButtonsDefault()
        {
            btnPlaySound.Enabled = true;
            btnStopSound.Enabled = false;

            btnPlaySound.BackgroundImage = (Image)new Bitmap(Properties.Resources.Play_1_Hot_icon_small);
            btnStopSound.BackgroundImage = (Image)new Bitmap(Properties.Resources.Stop_red_icon_small_Disabled);

            btnLoadSound.Enabled = true;
            btnLoadSound.BackgroundImage = (Image)new Bitmap(Properties.Resources.browse_icon_small);

            btnRecord.Enabled = true;
            btnRecord.BackgroundImage = (Image)new Bitmap(Properties.Resources.record_small);

            setAllControls(this.Enabled);

        }


        private void setAllControls(Boolean vEnabled)
        {
            setSoundControlsAllEnabled(vEnabled);
            //setSoundDeviceList();
            setSoundFilenames();
            setSoundButtons();
        }


        /// <summary>
        /// Set the enabled state of the sound controls
        /// </summary>
        private void setSoundControlsAllEnabled(Boolean vEnabled)
        {
            txtSoundFilename.Enabled = vEnabled;
            btnLoadSound.Enabled = vEnabled;
            btnPlaySound.Enabled = vEnabled;
            btnStopSound.Enabled = vEnabled;
            cbOutputDevice.Enabled = vEnabled;
            numVolume.Enabled = vEnabled;
            btnRecord.Enabled = vEnabled;
            btnClearSound.Enabled = vEnabled;

        }


        /// <summary>
        /// Set the state of all of the sound buttons
        /// </summary>
        private void setSoundButtons()
        {
            if (this.Enabled)
            {

                btnPlaySound.Enabled = true;
                btnRecord.Enabled = true;

                if (String.IsNullOrEmpty(Filename))
                {
                    btnPlaySound.Enabled = false;
                    btnStopSound.Enabled = false;
                    btnLoadSound.Select();
                }
                else
                {
                    btnPlaySound.Enabled = true;
                    btnStopSound.Enabled = false;
                    btnPlaySound.Select();
                }
                
            }
            else
            {
                btnPlaySound.Enabled = false;
                btnStopSound.Enabled = false;
                btnLoadSound.Enabled = false;
                btnRecord.Enabled = false;
                btnClearSound.Enabled = false;
            }

            setButtonsImages(ref btnPlaySound, ref btnStopSound, ref btnLoadSound, ref btnRecord);

        }


        /// <summary>
        /// Set the images for each of the buttons based on their enabled state
        /// </summary>
        /// <param name="vPlayButton"></param>
        /// <param name="vStopButton"></param>
        private void setButtonsImages(ref Button vPlayButton, ref Button vStopButton, ref Button vLoadButton, ref Button vRecordButton)
        {
            if (vStopButton.Enabled == false || !this.Enabled)
            {
                vStopButton.BackgroundImage = (Image)new Bitmap(Properties.Resources.Stop_red_icon_small_Disabled);
            }
            else
            {
                vStopButton.BackgroundImage = (Image)new Bitmap(Properties.Resources.Stop_red_icon_small);
            }

            //vPlayButton.Enabled = false;
            if (vPlayButton.Enabled == false || !this.Enabled)
            {
                vPlayButton.BackgroundImage = (Image)new Bitmap(Properties.Resources.Play_1_Hot_icon_small_Disabled);
            }
            else
            {
                vPlayButton.BackgroundImage = (Image)new Bitmap(Properties.Resources.Play_1_Hot_icon_small);
            }



            if (vLoadButton.Enabled == false || !this.Enabled)
            {
                vLoadButton.BackgroundImage = (Image)new Bitmap(Properties.Resources.browse_icon_Disabled);
            }
            else
            {
                vLoadButton.BackgroundImage = (Image)new Bitmap(Properties.Resources.browse_icon_small);
            }



            if (vRecordButton.Enabled == false || !this.Enabled)
            {
                vRecordButton.BackgroundImage = (Image)new Bitmap(Properties.Resources.record_small_Disabled);
            }
            else
            {
                vRecordButton.BackgroundImage = (Image)new Bitmap(Properties.Resources.record_small);
            }

        }


        /// <summary>
        /// Set the file text for the sounds
        /// </summary>
        private void setSoundFilenames()
        {
            txtSoundFilename.Text = Filename;
            txtSoundFilename.Enabled = this.Enabled;
        }


        public List<WaveOutCapabilities> PlaybackDeviceList()
        {
            List<WaveOutCapabilities> output = new List<WaveOutCapabilities>();

            int waveOutDevices = WaveOut.DeviceCount;
            for (int waveOutDevice = 0; waveOutDevice < waveOutDevices; waveOutDevice++)
            {
                //WaveOutCapabilities deviceInfo = WaveOut.GetCapabilities(waveOutDevice);
                output.Add(WaveOut.GetCapabilities(waveOutDevice));
            }

            return output;
        }


        public List<WaveInCapabilities> RecordingDeviceList()
        {
            List<WaveInCapabilities> output = new List<WaveInCapabilities>();

            int waveOutDevices = WaveIn.DeviceCount;
            for (int waveInDevice = 0; waveInDevice < waveOutDevices; waveInDevice++)
            {
                //WaveOutCapabilities deviceInfo = WaveOut.GetCapabilities(waveOutDevice);
                output.Add(WaveIn.GetCapabilities(waveInDevice));
            }

            return output;
        }


        internal void SetSoundDeviceList()
        {

            //try
            {
                // from: https://stackoverflow.com/questions/1449136/enumerate-recording-devices-in-naudio
                cbOutputDevice.Items.Clear();

                int waveOutDevices = WaveOut.DeviceCount; 
                for (int waveOutDevice = 0; waveOutDevice < waveOutDevices; waveOutDevice++)
                {
                    WaveOutCapabilities deviceInfo = WaveOut.GetCapabilities(waveOutDevice);

                    //Console.WriteLine("Device {0}: {1}, {2} channels", waveOutDevice, deviceInfo.ProductName, deviceInfo.Channels);
                    //cbOutputDevice.Items.Add(RemoveTextToRight(deviceInfo.ProductName, "("));
                    cbOutputDevice.Items.Add(deviceInfo.ProductName);
                }

                cbOutputDevice.SelectedItem = SoundDeviceName;


                if (cbOutputDevice.SelectedItem == null && waveOutDevices > 0) cbOutputDevice.SelectedIndex = 0;
            }
            //catch (Exception ex)
            //{

            //}
            
        }


        /// <summary>
        /// for testing, not useful atm
        /// </summary>
        private void RawDeviceInfo()
        {
            //https://stackoverflow.com/questions/6438628/get-default-audio-video-device
            string RequestedDeviceStatus = "Active"; // Initialize string variable for storing audio device status of interest. Valid input = "Active" or "Enabled"
            string RequestedDeviceType = "Playback"; // Initialize string variable for storing audio device type of interest. Valid input = "Playback" or "Recording"

            if (!String.Equals(RequestedDeviceStatus, "Active", StringComparison.OrdinalIgnoreCase) && !String.Equals(RequestedDeviceStatus, "Enabled", StringComparison.OrdinalIgnoreCase)) // Check RequestedDeviceStatus to ensure valid input was provided
            {
                Console.WriteLine("Invalid AudioDeviceStatus specified. Info request canceled"); // Output info to event log
                Console.ReadLine(); // Wait for user input
                return; // Immediately stop processing the inline function
            }
            string DeviceRegistryName; // Declare string variable for storing the registry name for the device type of interest

            if (String.Equals(RequestedDeviceType, "Playback", StringComparison.OrdinalIgnoreCase)) // Check if info request is for playback devices
                DeviceRegistryName = "Render"; // Set the DeviceRegistryName
            else if (String.Equals(RequestedDeviceType, "Recording", StringComparison.OrdinalIgnoreCase)) // Check if info request is for recording devices
                DeviceRegistryName = "Capture"; // Set the DeviceRegistryName
            else
            {
                Console.WriteLine("Invalid AudioDeviceType specified. Info request canceled"); // Output info to event log
                Console.ReadLine(); // Wait for user input
                return; // Immediately stop processing the inline function
            }
            RegistryKey RootKey; // Initialize RegistryKey for containing the root (base) key to evaluate

            if (Environment.Is64BitOperatingSystem) // Check if operating system is 64-bit
                RootKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64); // Opens registry's LocalMachine key with a 64-bit view
            else
                RootKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32); // Opens registry's LocalMachine key with a 32-bit view
            string AudioKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\MMDevices\Audio"; // Parent registry key for audio devices
            string DeviceName, DeviceType; // Declare string variables for storing audio device information
            string[] ActiveDeviceRoles = null; // Initialize string array for storing information about the active devices for each audio role

            using (RegistryKey ChildKey = RootKey.OpenSubKey(AudioKey)) // Open subkey of AudioKey and store in ChildKey. "using" implemented for proper disposal.
            {
                foreach (string ChildKeyName in ChildKey.GetSubKeyNames()) // Loop through each SubKeyName in ChildKey
                {
                    if (ChildKeyName == DeviceRegistryName) // Check if ChildKeyName is "Render" (signifies registry folder for audio playback devices)
                    {
                        using (RegistryKey RenderKey = ChildKey.OpenSubKey(ChildKeyName)) // Open subkey of ChildKey and store in RenderKey. "using" implemented for proper disposal.
                        {
                            DateTime[] ActiveDeviceRoleTimes = null; // Initialize DateTime array for storing times when audio devices last held a particular audio role
                            int j = 1; // Initialize integer variable for tracking audio playback device count
                            foreach (string DeviceKeyName in RenderKey.GetSubKeyNames()) // Loop through each SubKeyName in RenderKey
                            {
                                using (RegistryKey DeviceKey = RenderKey.OpenSubKey(DeviceKeyName)) // Open subkey of RenderKey and store in DeviceKey. "using" implemented for proper disposal.
                                {
                                    if (Convert.ToInt32(DeviceKey.GetValue("DeviceState")) == 1) // Check if current audio device is enabled
                                    {
                                        string CurrentDeviceInfo; // Declare string variable for storing information about the current audio device
                                        using (RegistryKey DeviceKeyProperties = DeviceKey.OpenSubKey("Properties")) // Open "Properties" subkey of DeviceKey and store in DeviceKeyProperties. "using" implemented for proper disposal.
                                        {
                                            DeviceName = DeviceKeyProperties.GetValue("{b3f8fa53-0004-438e-9003-51a46e139bfc},6").ToString(); // Retrieve the current device's name from the registry
                                            DeviceType = DeviceKeyProperties.GetValue("{a45c254e-df1c-4efd-8020-67d146a850e0},2").ToString(); // Retrieve the current device's type from the registry
                                            CurrentDeviceInfo = DeviceType + " (" + DeviceName + ")"; // Combine the DeviceName and DeviceType info similar to how VoiceAttack displays this data in the Options menu
                                            if (String.Equals(RequestedDeviceStatus, "Enabled", StringComparison.OrdinalIgnoreCase)) // Check if user wants to show which audio devices are enabled
                                            {
                                                Console.WriteLine("Audio " + RequestedDeviceType + " Device " + j++ + " = " + CurrentDeviceInfo); // Output the CurrentDeviceInfo to the event log
                                                continue; // Continue with next index in parent for loop
                                            }
                                        }

                                        string[] roles = { "Role:0", "Role:1", "Role:2" }; // Initialize string array for storing the names of the different audio roles
                                        DateTime[] CurrentDeviceRoleTimes = new DateTime[roles.Length]; // Initialize DateTime array for storing times when the current audio devices last held a particular audio role
                                        //Console.WriteLine("Audio " + RequestedDeviceType + " Device " + j++ + " = " + CurrentDeviceInfo); // Output the CurrentDeviceInfo to the event log. Useful for debuging
                                        for (int i = 0; i < roles.Length; i++) // Loop based on the size of the roles string array
                                        {
                                            byte[] RegistryData = (byte[])DeviceKey.GetValue(roles[i]); // Extract audio device role data from the registry
                                            if (RegistryData == null) // Check if the extracted data is null
                                                continue; // Continue to next index in parent for loop
                                            CurrentDeviceRoleTimes[i] = GetRoleDateTime(RegistryData); // Retrieve role information from registry, convert this data to a DateTime, and store it
                                            //Console.WriteLine(roles[i] + " = " + CurrentDeviceRoleTimes[i].ToString()); // Output info to event log. Useful for debuging
                                        }
                                        if (ActiveDeviceRoles == null || ActiveDeviceRoles.Length == 0) // Check if ActiveDeviceRoles is null or empty
                                        {
                                            ActiveDeviceRoles = new string[roles.Length]; // Initialize ActiveDeviceRoles string array
                                            ActiveDeviceRoleTimes = new DateTime[roles.Length]; // Initialize ActiveDeviceRoleTImes DateTime array
                                        }
                                        for (int i = 0; i < roles.Length; i++) // Loop based on the size of the roles string array 
                                        {
                                            if (ActiveDeviceRoleTimes[i] < CurrentDeviceRoleTimes[i]) // Check if the ActiveDeviceRoleTime at the current index is less than the CurrentDeviceRoleTime at this index
                                            {
                                                ActiveDeviceRoles[i] = CurrentDeviceInfo; // Set ActiveDeviceRoles at current index to CurrentDeviceInfo
                                                ActiveDeviceRoleTimes[i] = CurrentDeviceRoleTimes[i]; // Set ActiveDeviceRoleTime at current index to corresponding CurrentDeviceRoleTime at this index
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (!String.Equals(RequestedDeviceStatus, "Enabled", StringComparison.OrdinalIgnoreCase)) // Check if user does NOT want to see the enabled devices
            {
                if (ActiveDeviceRoles != null) // Check if ActiveDeviceRoles is not null (i.e., enabled device data has been found and stored)
                {
                    for (int i = 0; i < ActiveDeviceRoles.Length; i++) // Loop based on the size of the ActiveDeviceRoles string array
                    {
                        string RoleName = null; // Initialize string variable for storing role description
                        switch (i) // Create switch statement based on integer i
                        {
                            case 0: // For case where i = 0
                                RoleName = "Default"; // Set RoleName
                                break; // Break out of switch statement
                            case 1: // For case where i = 1
                                    // There is the "Multimedia" role, but I don't believe this is currently used by Windows. 
                                    // The code for this role will remain for possible future use.
                                    //RoleName = "Multimedia"; // Set RoleName
                                    //break; // Break out of switch statement
                                continue; // Immediately continue with next index in parent for loop
                            case 2: // For case where i = 2
                                RoleName = "Communications"; // Set RoleName
                                break; // Break out of switch statement
                        }

                        if (ActiveDeviceRoles[i] == null) // Check if ActiveDeviceRole at current index is null
                            Console.WriteLine("{0} {1} Device = {2}", RoleName, RequestedDeviceType, "Not Set"); // Output info to event log
                        else
                            Console.WriteLine("{0} {1} Device = {2}", RoleName, RequestedDeviceType, ActiveDeviceRoles[i]); // Output info to event log
                    }
                }
                else
                    Console.WriteLine("No audio playback devices enabled"); // Output info to event log
            }
            Console.ReadLine();
        }

        // Function for converting registry data for an audio device into corresponding DateTime information
        static DateTime GetRoleDateTime(byte[] binary)
        {
            if (binary == null || binary.Length != 16) // Check if binary is null or the length is not 16
                throw new ArgumentException("Error converting registry data to DateTime"); // Throw an exception

            int year = Convert.ToInt32(binary[0] + binary[1] * 256); // Extract year from registy data
            int month = Convert.ToInt32(binary[2]); // Extract month from registy data
            int day = Convert.ToInt32(binary[6]); // Extract day from registy data
            int hour = Convert.ToInt32(binary[8]); // Extract hour from registy data
            int minute = Convert.ToInt32(binary[10]); // Extract minute from registy data
            int seconds = Convert.ToInt32(binary[12]); // Extract seconds from registy data
            int milliseconds = Convert.ToInt32(binary[14] + binary[15] * 256); // Extract milliseconds from registy data
            return new DateTime(year, month, day, hour, minute, seconds, milliseconds).ToLocalTime(); // Return the converted DateTime data


        }



        private int getPlayTimeSeconds(String vPath)
        {
            int output = 0;

            if (string.IsNullOrEmpty(vPath)) return -1;
            if (!System.IO.File.Exists(vPath)) return -1;

            try
            {
                string ext = System.IO.Path.GetExtension(vPath).ToUpper().Trim().Replace(".", "");

                if (ext == "MP3")
                {
                    using (Mp3FileReader fileReader = new Mp3FileReader(vPath))
                    {
                        output = (int)fileReader.TotalTime.TotalSeconds;
                        fileReader.Close();
                    }
                }
                else if (ext == "WAV")
                {
                    using (WaveFileReader fileReader = new WaveFileReader(vPath))
                    {
                        output = (int)fileReader.TotalTime.TotalSeconds;
                        fileReader.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                //ProcessError(ex, ErrorMessageType.UnknownDataRead, ShowError.NoShow, ThrowError.NoThrow, String.Format(CultureInfo.InvariantCulture, ""), FileFunctions.GetErrorLogFullPath());
            }

            return output;

        }


        private void btnStopSound_Click(object sender, EventArgs e)
        {
            Stop();
        }

        /// <summary>
        /// Will stop playing or recording, depending on what action was previously performed (pressing play, or record)
        /// </summary>
        public void Stop()
        {
            if (State == SoundControlState.Playing)
            {                
                CloseWaveOut(false);
                State = SoundControlState.None;
            }
            else if (State == SoundControlState.Recording) 
            {
                //waveSource.StopRecording();
                stopRecording();
            }
            else
            {
                // None
                // no activity happened most likely
            }

            resetSoundButtonsDefault();


        }


        /// <summary>
        /// stop playing specific sound
        /// </summary>
        /// <param name="vType"></param>
        /// <param name="vQuitting"> wether we are cleaning up to quit, or resetting for the next use</param>
        private void CloseWaveOut(Boolean vQuitting)
        {
            if (soundPlaying != null)
            {
                if (soundPlaying != null)
                {
                    soundPlaying.WaveOutput.Stop();
                }
                //if (mainOutputStream != null)
                if (mp3FileReader != null)
                {
                    mp3FileReader.Close();
                    mp3FileReader.Dispose();
                    mp3FileReader = null;
                }
                if (wavFileReader != null)
                {
                    wavFileReader.Close();
                    wavFileReader.Dispose();
                    wavFileReader = null;
                }
                if (soundPlaying != null)
                {
                    soundPlaying.WaveOutput.Dispose();
                    soundPlaying.Dispose();
                    soundPlaying = null;
                }

                if (!vQuitting)
                {
                    soundPlaying = new WaveOutExt();

                    // re-set the handlers
                    foreach (EventHandler<StoppedEventArgs> ev in PlaybackStoppedEventHandlers)
                    {
                        soundPlaying.WaveOutput.PlaybackStopped += ev;
                    }       
                }
            }
        }


        private void btnClearSound_Click(object sender, EventArgs e)
        {
            Filename = string.Empty;
            Volume = 50;
            //numVolume.Enabled = false;

            CloseWaveOut(false);

            setAllControls(this.Enabled);
        }


        private void cbOutputDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ApplyingSettings)
            {
                SoundDeviceName = cbOutputDevice.SelectedItem.ToString();
                // raise event for device change
                OnDeviceChangeDetect(new DeviceDetectEventArgs(SoundDeviceName));
            } 
            
        }


        private void numVolume_ValueChanged(object sender, EventArgs e)
        {
            volume = (int)numVolume.Value;
            if (!ApplyingSettings)
            {
                // raise event for volume change
                OnVolumeChangeDetect(new VolumeDetectEventArgs(Volume));
            }
            
        }


        private void TmrDeviceUpdate_Tick(object sender, EventArgs e)
        {
            tmrDeviceUpdate.Stop();

            try
            {
                this.Invoke((Action)delegate
                {
                    SetSoundDeviceList();
                });
            }
            catch (Exception)
            {

            }                      
        }


        public void StartDeviceUpdateTimer()
        {
            if (!tmrDeviceUpdate.Enabled)
                tmrDeviceUpdate.Start();
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            StartRecording();
        }

        public void StartRecording()
        {
            String fileToRecord = System.IO.Path.GetTempPath() + recordingTempFilename; // + ".wav";

            // if the recording filename is not specified
            if (String.IsNullOrEmpty(this.RecordingFilename))
            {
                int filenum = 0;
                while (System.IO.File.Exists(fileToRecord + filenum + ".wav"))
                {
                    filenum++;
                }
                fileToRecord = fileToRecord + filenum + ".wav";
                RecordingFilename = fileToRecord;
            }           

            // check if the filename has .WAV in it
            if (!RecordingFilename.ToUpper().Contains(".WAV"))
            {
                RecordingFilename += ".wav";
            }

            State = SoundControlState.Recording;
            setButtonsOnRecord(ref btnPlaySound, ref btnStopSound, ref btnLoadSound, ref btnRecord);

            waveSource = new WaveIn();
            waveSource.WaveFormat = new WaveFormat(44100, 1);
            waveSource.DeviceNumber = RecordingDeviceID;
            waveSource.DataAvailable += WaveSource_DataAvailable;
            waveSource.RecordingStopped += WaveSource_RecordingStopped;

            try
            {
                //waveFile = new WaveFileWriter(@"C:\Temp\Test0001.wav", waveSource.WaveFormat);
                waveFile = new WaveFileWriter(RecordingFilename, waveSource.WaveFormat);
                waveSource.StartRecording();
                tmrRecording.Start();
                setRecordingText();
            }
            catch (Exception)
            {

            }

        }

        private void setRecordingText()
        {
            string formattedTime = GetTimeFormatted(recordingTimeSeconds);
            this.Invoke((Action)delegate
            {
                this.txtSoundFilename.Text = "Recordning ... " + formattedTime;
            });
            
        }

        public void SetRecordingDevice(int vDeviceID)
        {
            recordingDeviceID = vDeviceID;
            if (waveSource != null) waveSource.DeviceNumber = vDeviceID;
        }

        private void WaveSource_RecordingStopped(object sender, StoppedEventArgs e)
        {
            stopRecording();
            setToolTips();
        }

        private void stopRecording()
        {
            // only run the event if its recording currently
            if (State == SoundControlState.None) return;

            tmrRecording.Stop();
            recordingTimeSeconds = 0;
            this.txtSoundFilename.Text = Filename;
                        
            ResetRecording();
            State = SoundControlState.None;

            // raise event for device change
            OnRecordingStoppedDetect(new RecordDetectEventArgs(RecordingFilename));
        }


        private void ResetRecording()
        {
            if (waveSource != null)
            {
                waveSource.Dispose();
                waveSource = null;
            }

            if (waveFile != null)
            {
                waveFile.Dispose();
                waveFile = null;
            }

            //waveSource = new WaveIn();

            resetSoundButtonsDefault();
        }

        private void WaveSource_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (waveFile != null)
            {
                waveFile.Write(e.Buffer, 0, e.BytesRecorded);
                waveFile.Flush();
            }
        }

        private void setButtonsOnRecord(ref Button vPlayButton, ref Button vStopButton, ref Button vBrowseButton, ref Button vRecordButton)
        {
            vStopButton.Enabled = true;
            vStopButton.BackgroundImage = (Image)new Bitmap(Properties.Resources.Stop_red_icon_small);

            vPlayButton.Enabled = false;
            vPlayButton.BackgroundImage = (Image)new Bitmap(Properties.Resources.Play_1_Hot_icon_small_Disabled);

            vBrowseButton.Enabled = false;
            vBrowseButton.BackgroundImage = (Image)new Bitmap(Properties.Resources.browse_icon_Disabled);

            vRecordButton.Enabled = false;
            vRecordButton.BackgroundImage = (Image)new Bitmap(Properties.Resources.record_small_Disabled);

        }











        private void OnDispose(object sender, EventArgs e)
        {
            Stop(); // stop recording/playback

            if (tmrRecording != null)
            {
                tmrRecording.Stop();
                tmrRecording.Dispose();
            }

            if (tmrDeviceUpdate != null)
            {
                tmrDeviceUpdate.Stop();
                tmrDeviceUpdate.Dispose();
            }

            CloseWaveOut(true);

            if (waveFile != null)
            {
                waveFile.Close();
                waveFile.Dispose();
            }

            if (waveSource != null) waveSource.Dispose();
                        
        }


    }
          
}
