using NAudio.CoreAudioApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strangetimez.Objects
{
    class NotificationClientImplementation : NAudio.CoreAudioApi.Interfaces.IMMNotificationClient           
    {
        private SoundPlayer soundPlayer;

        public void OnPropertyValueChanged(string deviceId, PropertyKey propertyKey)
        {
            //Do some Work
            soundPlayer.StartDeviceUpdateTimer();
            //fmtid & pid are changed to formatId and propertyId in the latest version NAudio
            Console.WriteLine("OnPropertyValueChanged: formatId --> {0}  propertyId --> {1}", propertyKey.formatId.ToString(), propertyKey.propertyId.ToString());
        }

        public void OnDefaultDeviceChanged(DataFlow dataFlow, Role deviceRole, string defaultDeviceId)
        {
            //Do some Work
            soundPlayer.StartDeviceUpdateTimer();
            Console.WriteLine("OnDefaultDeviceChanged --> {0}", dataFlow.ToString());
        }

        public void OnDeviceAdded(string deviceId)
        {
            //Do some Work
            soundPlayer.StartDeviceUpdateTimer();
            Console.WriteLine("OnDeviceAdded -->");
        }

        public void OnDeviceRemoved(string deviceId)
        {
            soundPlayer.StartDeviceUpdateTimer();
            Console.WriteLine("OnDeviceRemoved -->");
            //Do some Work
        }

        public void OnDeviceStateChanged(string deviceId, DeviceState newState)
        {
            soundPlayer.StartDeviceUpdateTimer();
            Console.WriteLine("OnDeviceStateChanged\n Device Id -->{0} : Device State {1}", deviceId, newState);
            //Do some Work
        }

        public NotificationClientImplementation(SoundPlayer vSoundPlayer)
        {
            soundPlayer = vSoundPlayer;

            //_realEnumerator.RegisterEndpointNotificationCallback();
            if (System.Environment.OSVersion.Version.Major < 6)
            {
                throw new NotSupportedException("This functionality is only supported on Windows Vista or newer.");
            }
        }


        

    }
}
