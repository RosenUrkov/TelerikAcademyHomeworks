using System;
using Academy.Models.Contracts;
using System.Text;

namespace Academy.Models
{
    public class DemoResorce : LectureResource, ILectureResouce
    {
        public DemoResorce(string name, string url) : base(name, url)
        {
            this.Type = "Demo";
        }

        protected override string AdditionalInfo()
        {
            return "";
        }
    }
}
