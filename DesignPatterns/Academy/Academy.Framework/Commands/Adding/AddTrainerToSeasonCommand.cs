using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using Academy.Framework.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Academy.Commands.Adding
{
    public class AddTrainerToSeasonCommand : ICommand
    {
        private readonly IAcademyModel academy;

        public AddTrainerToSeasonCommand(IAcademyModel academy)
        {
            this.academy = academy;
        }

        public string Execute(IList<string> parameters)
        {
            var trainerUsername = parameters[0];
            var seasonId = int.Parse(parameters[1]);

            var trainer = this.academy.GetTrainer(trainerUsername);
            var season = this.academy.GetSeason(seasonId);

            if (season.Trainers.Any(x => x.Username.ToLower() == trainerUsername.ToLower()))
            {
                throw new ArgumentException($"The Trainer {trainerUsername} is already a part of Season {seasonId}!");
            }

            season.Trainers.Add(trainer);
            return $"Trainer {trainerUsername} was assigned to Season {seasonId}.";
        }
    }
}
