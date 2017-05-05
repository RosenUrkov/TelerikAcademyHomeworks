namespace ProjectManager.Models
{
    using Contracts;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class User : IUser
    {
        private const string RequiredUsernameMessage = "User Username is required!";
        private const string RequiredEmailMessage = "User Email is required!";
        private const string InvalidEmailMessage = "User Email is not valid!";

        public User(string username, string email)
        {
            this.Username = username;
            this.Email = email;
        }

        [Required(ErrorMessage = RequiredUsernameMessage)]
        public string Username { get; private set; }
        [Required(ErrorMessage = RequiredEmailMessage)]
        [EmailAddress(ErrorMessage = InvalidEmailMessage)]
        public string Email { get; private set; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine("    Username: " + this.Username);
            builder.AppendLine("    Email: " + this.Email);
            return builder.ToString();
        }
    }
}
