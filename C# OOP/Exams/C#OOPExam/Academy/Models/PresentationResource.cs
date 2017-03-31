using Academy.Models.Contracts;

namespace Academy.Models
{
    public class PresentationResource : LectureResource, ILectureResouce
    {
        public PresentationResource(string name, string url) : base(name, url)
        {
            this.Type = "Presentation";
        }

        protected override string AdditionalInfo()
        {
            return "";
        }
    }
}
