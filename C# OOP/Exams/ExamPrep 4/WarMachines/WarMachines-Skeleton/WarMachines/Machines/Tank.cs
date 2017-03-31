using System;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public class Tank : Machine, ITank, IMachine
    {
        public Tank(string name, double attackPoints, double defensePoints) : base(name, attackPoints, defensePoints)
        {
            this.ToggleDefenseMode();
            this.HealthPoints = 100;  
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            this.DefenseMode = !this.DefenseMode;
            if (this.DefenseMode)
            {
                this.AttackPoints -= 40;
                this.DefensePoints += 30;
            }
            else
            {
                this.AttackPoints += 40;
                this.DefensePoints -= 30;
            }
            
        }

        protected override string AdditionalInfo()
        {
            return $" *Defense: {(this.DefenseMode ? "ON" : "OFF")}";
        }
    }
}
