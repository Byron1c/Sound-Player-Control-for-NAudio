using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strangetimez.Objects
{
    public class RecordDetectEventArgs : EventArgs
    {
        public String Filename { get; set; }

        public RecordDetectEventArgs(String vFilename)
        {
            this.Filename = vFilename;
        }


    }
}
