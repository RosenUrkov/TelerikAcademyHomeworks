namespace Timer
{
    using System;
    using System.Threading;

    public delegate void ChangedEventHandler(object sender, EventArgs e);

    public class EventTimer : Timer
    {
        public event ChangedEventHandler Changed;

        protected virtual void OnChanged(EventArgs e)
        {
            if (Changed != null)
            {
                Changed(this, e);
            }
            
        }

        public void EventPrintOnTime(int number,string text,int seconds)
        {
            while (true)
            {
                OnChanged(EventArgs.Empty);
                Thread.Sleep(seconds * 1000);
            }
        }      
    }
}
