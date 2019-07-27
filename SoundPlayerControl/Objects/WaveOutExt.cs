using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strangetimez.Objects
{
    public class WaveOutExt
    {

        private WaveOut waveOutput;
        public WaveOut WaveOutput
        {
            get { return waveOutput; }
            set { waveOutput = value; }
        }

        
        public WaveOutExt()
        {
            WaveOutput = new WaveOut();
        }


        public void Add(WaveOut vWav)
        {
            WaveOutput = vWav;
        }

        public void Dispose()
        {
            waveOutput.Dispose();
        }


    }
}
