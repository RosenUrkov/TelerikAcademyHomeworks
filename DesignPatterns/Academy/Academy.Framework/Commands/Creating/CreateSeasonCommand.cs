using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using Academy.Framework.Models.Contracts;
using System.Collections.Generic;

namespace Academy.Commands.Creating
{
    public class CreateSeasonCommand : ICommand
    {
        private readonly IAcademyFactory factory;
        private readonly IAcademyModel academy;

        public CreateSeasonCommand(IAcademyFactory factory, IAcademyModel academy)
        {
            this.factory = factory;
            this.academy = academy;
        }

        public string Execute(IList<string> parameters)
        {
            var startingYear = parameters[0];
            var endingYear = parameters[1];
            var initiative = parameters[2];

            var season = this.factory.CreateSeason(startingYear, endingYear, initiative);

            var seasonId = this.academy.AddSeason(season);

            return $"Season with ID {seasonId} was created.";
        }
    }
}
