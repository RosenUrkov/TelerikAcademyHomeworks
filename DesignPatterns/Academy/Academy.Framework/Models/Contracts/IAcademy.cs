using Academy.Models;
using Academy.Models.Contracts;
using System.Collections.Generic;

namespace Academy.Framework.Models.Contracts
{
    public interface IAcademyModel
    {
        IStudent GetStudent(string username);

        int AddStudent(IStudent student);

        ITrainer GetTrainer(string username);

        int AddTrainer(ITrainer trainer);

        IList<IUser> GetUsers();

        int AddSeason(ISeason season);

        ISeason GetSeason(int seasonId);
    }
}
