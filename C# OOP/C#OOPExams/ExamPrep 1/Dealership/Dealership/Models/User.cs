namespace Dealership.Models
{
    using System;
    using System.Collections.Generic;
    using Dealership.Common.Enums;
    using Dealership.Contracts;
    using Common;
    using System.Text;

    public class User : IUser
    {
        private string firstName;
        private string lastName;
        private string password;
        private string username;
        private IList<IVehicle> vehicles;

        public User(string username, string firstName, string lastName, string password, string role)
        {
            this.Username = username;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Password = password;
            this.vehicles = new List<IVehicle>();
            if(role == null)
            {
                throw new ArgumentException("Role can not be null");
            }
            this.Role = (Role)Enum.Parse(typeof(Role),role);
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {

                Validator.ValidateNull(value, "First name of the user can not be null.");
                Validator.ValidateIntRange(value.Length, Constants.MinNameLength, Constants.MaxNameLength,
                   string.Format(Constants.StringMustBeBetweenMinAndMax, "Firstname", Constants.MinNameLength, Constants.MaxNameLength));
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            private set
            {
                Validator.ValidateNull(value, "Last name of the user can not be null.");
                Validator.ValidateIntRange(value.Length, Constants.MinNameLength, Constants.MaxNameLength,
                   string.Format(Constants.StringMustBeBetweenMinAndMax, "Lastname", Constants.MinNameLength, Constants.MaxNameLength));
                this.lastName = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }
            private set
            {
                Validator.ValidateNull(value, "Password of the user can not be null.");
                Validator.ValidateSymbols(value, Constants.PasswordPattern, string.Format(Constants.InvalidSymbols, "Password"));
                Validator.ValidateIntRange(value.Length, Constants.MinPasswordLength, Constants.MaxPasswordLength,
                    string.Format(Constants.StringMustBeBetweenMinAndMax, "Password", Constants.MinPasswordLength, Constants.MaxPasswordLength));
                this.password = value;
            }
        }

        public Role Role { get; private set; }

        public string Username
        {
            get
            {
                return this.username;
            }
            private set
            {
                Validator.ValidateNull(value, "Username can not be null.");
                Validator.ValidateSymbols(value, Constants.UsernamePattern, string.Format(Constants.InvalidSymbols, "Username"));
                Validator.ValidateIntRange(value.Length, Constants.MinNameLength, Constants.MaxNameLength,
                    string.Format(Constants.StringMustBeBetweenMinAndMax, "Username", Constants.MinNameLength, Constants.MaxNameLength));
                this.username = value;
            }
        }

        public IList<IVehicle> Vehicles
        {
            get
            {
                return this.vehicles;
            }
            private set
            {
                this.vehicles = value;
            }
        }

    public void AddComment(IComment commentToAdd, IVehicle vehicleToAddComment)
        {
            Validator.ValidateNull(commentToAdd, Constants.CommentCannotBeNull);         
            Validator.ValidateNull(vehicleToAddComment, Constants.VehicleCannotBeNull);
            vehicleToAddComment.Comments.Add(commentToAdd);
        }

        public void AddVehicle(IVehicle vehicle)
        {
            Validator.ValidateNull(vehicle, Constants.VehicleCannotBeNull);
            if (this.Role == Role.Admin)
            {
                throw new ArgumentException(Constants.AdminCannotAddVehicles);
            }
            else if ((this.Role != Role.VIP) && (this.Vehicles.Count >= Constants.MaxVehiclesToAdd))
            {
                throw new ArgumentException(string.Format(Constants.NotAnVipUserVehiclesAdd,Constants.MaxVehiclesToAdd));

            }

            this.Vehicles.Add(vehicle);
        }

        public string PrintVehicles()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"--USER {Username}--");

            if (Vehicles.Count == 0)
            {
                builder.AppendLine("--NO VEHICLES--");
                return builder.ToString().TrimEnd();
            }

            for (int i = 0; i < Vehicles.Count; i++)
            {
                builder.AppendLine($@"{i+1}. {Vehicles[i].Type}:");
                builder.AppendLine(Vehicles[i].ToString());
            }
            return builder.ToString().TrimEnd(); ; 
        }

        public void RemoveComment(IComment commentToRemove, IVehicle vehicleToRemoveComment)
        {
            Validator.ValidateNull(commentToRemove, Constants.CommentCannotBeNull);
            Validator.ValidateNull(vehicleToRemoveComment, Constants.VehicleCannotBeNull);
            if(commentToRemove.Author != this.Username)
            {
                throw new ArgumentException(Constants.YouAreNotTheAuthor);
            }
            vehicleToRemoveComment.Comments.Remove(commentToRemove);
        }

        public void RemoveVehicle(IVehicle vehicle)
        {
            Validator.ValidateNull(vehicle, Constants.VehicleCannotBeNull);
            this.Vehicles.Remove(vehicle);
        }

        public override string ToString()
        {            
            return $"Username: {Username}, FullName: {FirstName} {LastName}, Role: {Role}";
           
        }

    }
}
