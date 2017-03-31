using WarMachines.Machines;

namespace WarMachines.Tests.Machines.Mocks
{
    public class MachineMock : Machine
    {
        public MachineMock(string name, double healthPoints, double attackPoints, double defensePoints) : 
            base(name, healthPoints, attackPoints, defensePoints)
        {
        }

        public void SetAttackPoints(double attPoints)
        {
            this.AttackPoints = attPoints;
        }
    }
}
