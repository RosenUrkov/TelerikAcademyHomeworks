namespace HighQualityCode
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Event : IComparable
    {
        private DateTime date;
        private string title;
        private string location;

        public Event(DateTime date, string title, string location)
        {
            this.date = date;
            this.title = title;
            this.location = location;
        }

        public int CompareTo(object obj)
        {
            Event other = obj as Event;
            int date = this.date.CompareTo(other.date);
            int title = this.title.CompareTo(other.title);

            int location = this.location.CompareTo(other.location);
            if (date == 0)
            {
                if (title == 0)
                {
                    return location;
                }
                else
                {
                    return title;
                }
            }
            else
            {
                return date;
            }
        }

        public override string ToString()
        {
            StringBuilder toString = new StringBuilder();
            toString.Append(this.date.ToString("yyyy-MM-ddTHH:mm:ss"));

            toString.Append(" | " + this.title);
            if (this.location != null && this.location != string.Empty)
            {
                toString.Append(" | " + this.location);
            }

            return toString.ToString();
        }
    }
}