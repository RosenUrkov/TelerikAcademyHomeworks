using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using Academy.Framework.Models.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Academy.Commands.Listing
{
    public class ListUsersInSeasonCommand : ICommand
    {
        private readonly IAcademyModel academy;

        public ListUsersInSeasonCommand(IAcademyModel academy)
        {
            this.academy = academy;
        }

        public string Execute(IList<string> parameters)
        {
            var seasonId = int.Parse(parameters[0]);
            var season = this.academy.GetSeason(seasonId);

            return season.ListUsers();
        }
    }
}
