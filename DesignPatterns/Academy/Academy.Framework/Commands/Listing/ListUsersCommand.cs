using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using Academy.Framework.Models.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Academy.Commands.Listing
{
    public class ListUsersCommand : ICommand
    {
        private readonly IAcademyModel academy;

        public ListUsersCommand(IAcademyModel academy)
        { 
            this.academy = academy;
        }

        public string Execute(IList<string> parameters)
        {
            var users = this.academy.GetUsers();
            var builder = new StringBuilder();

            foreach (var user in users)
            {
                builder.AppendLine(user.ToString());
            }

            if (builder.ToString().Equals(""))
            {
                return "There are no registered users!";
            }

            return builder.ToString().TrimEnd();
        }
    }
}
