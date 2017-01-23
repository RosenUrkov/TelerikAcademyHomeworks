using System;

namespace Academy.Models
{
    public class User : IUser
    {
        private string username;

        public User(string username)
        {
            this.Username = username;
        }

        public string Username
        {
            get
            {
                return this.username;   
            }

            set
            {
                Validator.ValidateString(value, Validator.UsernameMinLength, Validator.UsernameMaxLength, Validator.UsernameMessage);
                this.username = value;
            }
        }
    }
}
