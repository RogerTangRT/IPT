using System;

namespace AgenteMonitorRecurso
{
    class Class_Timer
    {
        public TimeSpan Timeout
        {
            get
            {
                return TimeSpan.FromMilliseconds(i_TimeoutMilliseconds - (i_TempoFinal - i_TempoInicial));
            }
        }

        int i_TempoInicial = Environment.TickCount;
        int i_TempoFinal = Environment.TickCount;
        int i_TimeoutMilliseconds = 0;
        public Class_Timer(int TimeoutMilliseconds)
        {
            i_TimeoutMilliseconds = TimeoutMilliseconds;
        }
        public void RegisterTime()
        {
            i_TempoFinal = Environment.TickCount;
        }
    }
}
