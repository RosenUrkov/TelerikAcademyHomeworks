using Academy.Commands.Contracts;
using Academy.Models;
using System.Collections.Generic;
using System;
using Academy.Core.Contracts;
using System.Text;

namespace Academy.Commands.Listing
{
    public class ListUsersCommand : ICommand
    {
        private readonly IAcademyFactory factory;
        private readonly IEngine engine;

        public ListUsersCommand(IAcademyFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }

        public string Execute(IList<string> parameters)
        {
            var builder = new StringBuilder();
            List<IUser> users = new List<IUser>();
            users.AddRange(this.engine.Trainers);
            users.AddRange(this.engine.Students);

            foreach (var user in users)
            {
                builder.AppendLine(user.ToString());
            }

            return builder.ToString().TrimEnd();
            
        }
    }
}
