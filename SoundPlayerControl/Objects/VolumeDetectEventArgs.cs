using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strangetimez.Objects
{
    public class VolumeDetectEventArgs : EventArgs
    {
        public int Volume { get; set; }

        public VolumeDetectEventArgs(int vVolume)
        {
            this.Volume = vVolume;
        }


    }
}
