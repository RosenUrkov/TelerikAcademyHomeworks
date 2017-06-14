using Academy.Framework.Models.Contracts;
using Academy.Models.Contracts;
using System.Collections.Generic;
using System;
using System.Linq;
using Academy.Models;

namespace Academy.Framework.Models
{
    public class Academy : IAcademyModel
    {
        private readonly IList<ISeason> seasons;
        private readonly IList<IStudent> students;
        private readonly IList<ITrainer> trainers;
        
        public Academy()
        {
            this.seasons = new List<ISeason>();
            this.students = new List<IStudent>();
            this.trainers = new List<ITrainer>();
        }

        public int AddSeason(ISeason season)
        {
            this.seasons.Add(season);
            return this.seasons.Count - 1;
        }

        public int AddStudent(IStudent student)
        {
            this.students.Add(student);
            return this.students.Count - 1;
        }

        public int AddTrainer(ITrainer trainer)
        {
            this.trainers.Add(trainer);
            return this.trainers.Count - 1;
        }

        public ISeason GetSeason(int seasonId)
        {
            return this.seasons[seasonId];
        }

        public IStudent GetStudent(string username)
        {
            return this.students.FirstOrDefault(x => x.Username.ToLower() == username.ToLower());
        }

        public ITrainer GetTrainer(string username)
        {
            return this.trainers.FirstOrDefault(x => x.Username.ToLower() == username.ToLower());
        }

        public IList<IUser> GetUsers()
        {
            var result = new List<IUser>();
            result.AddRange(this.trainers);
            result.AddRange(this.students);

            return result;
        }
    }
}
