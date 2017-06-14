using Academy.Core.Contracts;
using Academy.Core.Providers;
using Academy.Framework.Core.Factories;
using Academy.Models;
using Academy.Models.Contracts;
using Academy.Models.Enums;
using Academy.Models.Utils;
using Academy.Models.Utils.Contracts;
using Academy.Models.Utils.LectureResources;
using System;

namespace Academy.Core.Factories
{
    public class AcademyFactory : IAcademyFactory
    {
        private readonly ILectureResourceFactory resourceFactory;

        public AcademyFactory(ILectureResourceFactory resourceFactory)
        {
            this.resourceFactory = resourceFactory;
        }

        public ISeason CreateSeason(string startingYear, string endingYear, string initiative)
        {
            var parsedStartingYear = int.Parse(startingYear);
            var parsedEngingYear = int.Parse(endingYear);

            Initiative parsedInitiativeAsEnum;
            Enum.TryParse<Initiative>(initiative, out parsedInitiativeAsEnum);

            return new Season(parsedStartingYear, parsedEngingYear, parsedInitiativeAsEnum);
        }

        public IStudent CreateStudent(string username, string track)
        {
            Track parsedTrackAsEnum;
            Enum.TryParse<Track>(track, out parsedTrackAsEnum);

            return new Student(username, parsedTrackAsEnum);
        }

        public ITrainer CreateTrainer(string username, string technologies)
        {            
            return new Trainer(username, technologies.Split(','));
        }

        public ICourse CreateCourse(string name, string lecturesPerWeek, string startingDate)
        {
            var lectures = int.Parse(lecturesPerWeek);
            var starting = DateTime.Parse(startingDate);
            var ending = starting.AddDays(30);

            return new Course(name, lectures, starting, ending);
        }

        public ILecture CreateLecture(string name, string date, ITrainer trainer)
        {
            var parsedDate = DateTime.Parse(date);

            return new Lecture(name, parsedDate, trainer);
        }

        public ILectureResource CreateLectureResource(string type, string name, string url)
        {
            return this.resourceFactory.GetLectureResource(type, name, url);            
        }

        public ICourseResult CreateCourseResult(ICourse course, string examPoints, string coursePoints)
        {
            return new CourseResult(course, float.Parse(examPoints), float.Parse(coursePoints));
        }
    }
}
