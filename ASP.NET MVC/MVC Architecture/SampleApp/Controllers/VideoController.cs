using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using SampleApp.Services.VideoServices;
using SampleApp.Data.UnitOfWork;
using AutoMapper;
using SampleApp.Models;

namespace SampleApp.Controllers
{
    public class VideoController : Controller
    {
        private readonly VideoDataService service;
        private readonly IEfUnitOfWork unitOfWork;

        public VideoController(VideoDataService service, IEfUnitOfWork unitOfWork)
        {
            this.service = service;
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadVideo(HttpPostedFileBase video)
        {
            if (video != null)
            {
                // Validate the uploaded file if you want like content length(optional)

                // Get the complete file path
                var uploadFilesDir = System.Web.HttpContext.Current.Server.MapPath("~/Videos");
                if (!Directory.Exists(uploadFilesDir))
                {
                    Directory.CreateDirectory(uploadFilesDir);
                }
                var fileSavePath = Path.Combine(uploadFilesDir, video.FileName);

                this.service.AddVideo(new Data.Models.Video() { FilePath = "~/Videos/" + video.FileName });
                this.unitOfWork.Commit();

                // Save the uploaded file to "UploadedFiles" folder
                video.SaveAs(fileSavePath);
            }

            return RedirectToAction("ShowVideos");
        }

        public ActionResult ShowVideos()
        {
            var videoPaths = this.service.GetAllVideos().Select(x => Mapper.Map<Video>(x));
            return this.View("Video", videoPaths);
        }
    }
}