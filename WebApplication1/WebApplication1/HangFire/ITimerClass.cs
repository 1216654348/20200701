using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace WebApplication1.HangFire
{
    public interface ITimerClass
    {
        void TryNewTasks(object source = null, ElapsedEventArgs e = null);
    }
}
