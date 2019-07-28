using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strangetimez.Objects
{
    public class FileDetectEventArgs : EventArgs
    {
        public String Filename { get; set; }

        public FileDetectEventArgs(String vFilename)
        {
            this.Filename = vFilename;
        }


    }
}
