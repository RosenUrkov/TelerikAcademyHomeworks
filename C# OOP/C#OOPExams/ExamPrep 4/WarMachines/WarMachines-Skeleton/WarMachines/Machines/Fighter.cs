using System;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    class Fighter : Machine, IFighter, IMachine
    {
        
        public Fighter(string name, double attackPoints, double defensePoints, bool stealthMode) : base(name, attackPoints, defensePoints)
        {
            this.StealthMode = stealthMode;          
            this.HealthPoints = 200;
        }

        public bool StealthMode { get; private set; }


        public void ToggleStealthMode()
        {
            this.StealthMode = !this.StealthMode;
                                  
        }

        protected override string AdditionalInfo()
        {
            return $" *Stealth: {(this.StealthMode ? "ON" : "OFF")}";
        }
    }
}

