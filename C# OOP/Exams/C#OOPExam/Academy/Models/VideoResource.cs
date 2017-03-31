using System;
using Academy.Models.Contracts;

namespace Academy.Models
{
    public class VideoResource : LectureResource, ILectureResouce
    {
        public VideoResource(string name, string url, DateTime uploadedOn) : base(name, url)
        {
            this.Type = "Video";
            this.UploadedOn = uploadedOn;
        }

        public DateTime UploadedOn { get; private set; }

        protected override string AdditionalInfo()
        {
            return $"     - Uploaded on: {this.UploadedOn}";
        }
    }
}
