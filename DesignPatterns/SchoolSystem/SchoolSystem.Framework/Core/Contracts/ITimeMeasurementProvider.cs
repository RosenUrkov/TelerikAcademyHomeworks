using System;

namespace SchoolSystem.Framework.Core.Contracts
{
    public interface ITimeMeasurementProvider
    {
        void Start();

        void Stop();

        long GetMeasuredTime();
    }
}
