using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._Chronometer
{
    public interface IChronometer
    {
        string GetTime { get; }
        List<string> Laps { get; }
        void Start();
        void End();
        void Lap();
        void Reset();
    }
}
