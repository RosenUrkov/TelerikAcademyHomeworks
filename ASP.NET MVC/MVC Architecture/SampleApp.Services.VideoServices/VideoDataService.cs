using SampleApp.Data.Models;
using SampleApp.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.Services.VideoServices
{
    public class VideoDataService
    {
        private readonly IEfRepostory<Video> repo;

        public VideoDataService(IEfRepostory<Video> repo)
        {
            this.repo = repo;
        }

        public IEnumerable<Video> GetAllVideos()
        {
            return this.repo.All.AsEnumerable();
        }

        public void AddVideo(Video video)
        {
            this.repo.Add(video);
        }
    }
}
