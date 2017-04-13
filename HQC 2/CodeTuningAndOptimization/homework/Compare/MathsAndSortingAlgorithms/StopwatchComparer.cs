namespace MathsAndSortingAlgorithms
{
    using System;
    using System.Diagnostics;

    public class StopwatchComparer
    {
        private Stopwatch timer;

        public StopwatchComparer()
        {
            timer = new Stopwatch();
        }

        public TimeSpan MesureTime(Action act)
        {
            this.timer.Start();
            act();
            this.timer.Stop();

            var time = this.timer.Elapsed;

            timer.Reset();
            return time;
        }
    }
}
