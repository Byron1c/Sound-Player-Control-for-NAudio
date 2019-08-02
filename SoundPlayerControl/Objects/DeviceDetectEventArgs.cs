using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strangetimez.Objects
{
    public class DeviceDetectEventArgs : EventArgs
    {
        public String SoundDeviceName { get; set; }

        public DeviceDetectEventArgs(String vSoundDeviceName)
        {
            this.SoundDeviceName = vSoundDeviceName;
        }


    }
}
