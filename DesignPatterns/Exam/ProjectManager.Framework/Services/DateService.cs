using System;

namespace ProjectManager.Framework.Services
{
    public class DateService : IDateService
    {
        public DateTime Now
        {
            get
            {
                return DateTime.Now;
            }
        }
    }
}
