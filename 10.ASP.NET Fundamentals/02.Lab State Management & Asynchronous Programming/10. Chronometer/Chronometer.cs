using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._Chronometer
{
    public class Chronometer : IChronometer
    {
        private Stopwatch stopwatch;
        private List<string> laps;
        public Chronometer()
        {
            stopwatch = new Stopwatch();
            laps = new List<string>();
        }
        public string GetTime => stopwatch.Elapsed.ToString(@"mm\:ss\.ffff");

        public List<string> Laps => laps;

        public void End()
        {
            stopwatch.Stop();
        }

        public void Lap()
        {
            laps.Add(stopwatch.Elapsed.ToString(@"mm\:ss\.ffff"));
        }

        public void Reset()
        {
           stopwatch.Reset();
            laps.Clear();
        }

        public void Start()
        {
            stopwatch.Start();
        }
    }
}
