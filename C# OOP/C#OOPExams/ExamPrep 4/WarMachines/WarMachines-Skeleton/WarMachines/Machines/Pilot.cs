using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public class Pilot : IPilot
    {
        private string name;
        private ICollection<IMachine> machines;

        public Pilot(string name)
        {
            this.Name = name;
            this.machines = new List<IMachine>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public ICollection<IMachine> Machines
        {
            get
            {
                return this.machines.OrderBy(x => x.HealthPoints).ThenBy(x => x.Name).ToList();
            }
            
        }

        public void AddMachine(IMachine machine)
        {
            if(machine == null)
            {
                throw new ArgumentNullException("Machine cannot be null.");
            }
            this.machines.Add(machine);
        }

        public string Report()
        {
            var builder = new StringBuilder();

            builder.AppendLine($"{this.Name} - {(machines.Count > 0 ? machines.Count.ToString() : "no")} {(machines.Count != 1 ? "machines" : "machine")}");
            foreach (var machine in Machines)
            {
                builder.AppendLine(machine.ToString());
            }

            return builder.ToString().TrimEnd();
        }
    }
}
