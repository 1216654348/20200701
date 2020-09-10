using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace Asp.NetCoreApi.HangFire
{
    public interface ITimerClass
    {
        void TryNewTasks(object source = null, ElapsedEventArgs e = null);
    }
}
