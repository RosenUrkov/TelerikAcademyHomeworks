using SchoolSystem.Framework.Core.Contracts;
using System;
using System.Diagnostics;

namespace SchoolSystem.Framework.Core.Providers
{
    public class TimeMeasurementProvider : ITimeMeasurementProvider
    {
        private Stopwatch stopwatch;

        public TimeMeasurementProvider()
        {
            this.stopwatch = new Stopwatch();
        }

        public void Start()
        {
            this.stopwatch.Start();
        }        

        public void Stop()
        {
            this.stopwatch.Stop();
        }

        public long GetMeasuredTime()
        {
            return this.stopwatch.ElapsedMilliseconds;
        }
    }
}
