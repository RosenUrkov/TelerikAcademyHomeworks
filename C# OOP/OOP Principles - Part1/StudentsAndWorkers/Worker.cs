using System;

namespace StudentsAndWorkers
{
    public class Worker:Human
    {
        private decimal weekSalary;
        private int workHoursPerDay;

        public Worker(string firstName, string lastName, decimal weekSalary, int workHoursPerDay)
            :base(firstName,lastName)
        {
            this.WorkHoursPerDay = workHoursPerDay;
            this.WeekSalary = weekSalary;
        }

        public decimal WeekSalary
        {
            get
            {
                return this.weekSalary;
            }
            set
            {
                InvalidNumberCheck(value);
                this.weekSalary = value;
            }
        }

        public int WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }
            set
            {
                InvalidNumberCheck(value);
                this.workHoursPerDay = value;
            }
        }

        private void InvalidNumberCheck(decimal value)
        {
            if (value<1)
            {
                throw new ArgumentException("Number must be bigger then zero.");
            }
        }

        public decimal MoneyPerHour()
        {
            return Math.Round(WeekSalary / 5*WorkHoursPerDay, 2);
        }
    }
}
