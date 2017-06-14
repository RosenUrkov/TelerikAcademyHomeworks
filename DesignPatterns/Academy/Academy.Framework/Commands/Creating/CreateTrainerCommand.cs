using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using Academy.Framework.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Academy.Commands.Creating
{
    public class CreateTrainerCommand : ICommand
    {
        private readonly IAcademyFactory factory;
        private readonly IAcademyModel academy;

        public CreateTrainerCommand(IAcademyFactory factory, IAcademyModel academy)
        {
            this.factory = factory;
            this.academy = academy;
        }

        public string Execute(IList<string> parameters)
        {
            var username = parameters[0];
            var technologies = parameters[1];

            if (this.academy.GetStudent(username) != null || this.academy.GetTrainer(username) != null)
            {
                throw new ArgumentException($"A user with the username {username} already exists!");
            }

            var trainer = this.factory.CreateTrainer(username, technologies);
            var trainerId = this.academy.AddTrainer(trainer);

            return $"Trainer with ID {trainerId} was created.";
        }
    }
}
