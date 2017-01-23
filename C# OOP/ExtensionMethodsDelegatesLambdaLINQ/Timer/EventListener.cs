using System;

namespace Timer
{
    public class EventListener
    {
        private EventTimer myTimer;

        public EventListener(EventTimer timer, int number , string text,int seconds)
        {
            myTimer = timer;
            myTimer.Changed += new ChangedEventHandler(TimerChanged);
                        
        }

        private void TimerChanged(object sender,EventArgs e)
        {
            Timer.PrintOnTime(5,"text",5);
        }


    }
}
