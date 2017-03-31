using System;
using System.Collections.Generic;
using System.Text;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public abstract class Machine : IMachine
    {
        private string name;
        private IList<string> targets;
        private IPilot pilot;

        protected Machine(string name, double attackPoints, double defensePoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.targets = new List<string>();

        }

        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

        public double HealthPoints { get; set; }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public IList<string> Targets
        {
            get
            {
                return this.targets;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("List of strings cannot be null.");
                }

                this.targets = value;
            }
        }

        public IPilot Pilot
        {
            get
            {
                return this.pilot;
            }

            set
            {
                if (value==null)
                {
                    throw new ArgumentNullException("Pilot cannot be null.");
                }

                this.pilot = value;
            }
        }

        

        public void Attack(string target)
        {
            if (string.IsNullOrEmpty(target))
            {
                throw new ArgumentNullException("Target cannot be null or empty.");
            }
            this.targets.Add(target);
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine($"- {this.name}");
            builder.AppendLine($" *Type: {this.GetType().Name}");
            builder.AppendLine($" *Health: {this.HealthPoints}");
            builder.AppendLine($" *Attack: {this.AttackPoints}");
            builder.AppendLine($" *Defense: {this.DefensePoints}");
            builder.AppendLine($" *Targets: {(this.targets.Count>0 ? string.Join(", ",this.targets) : "None")}");
            builder.AppendLine(AdditionalInfo());

            return builder.ToString().TrimEnd();
        }

        protected abstract string AdditionalInfo();
    }
}
