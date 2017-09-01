using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace UnitsOfWork
{
    class Unit : IComparable<Unit>
    {
        public Unit(string name, string type, int attack)
        {
            this.Name = name;
            this.Type = type;
            this.Attack = attack;
        }

        public string Name { get; set; }

        public string Type { get; set; }

        public int Attack { get; set; }

        public override string ToString()
        {
            return this.Name + "[" + this.Type + "](" + this.Attack + ")";
        }

        public override bool Equals(object obj)
        {
            var other = obj as Unit;
            return this.Name == other.Name;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        public int CompareTo(Unit other)
        {
            var comparer = other.Attack.CompareTo(this.Attack);
            if (comparer == 0)
            {
                return this.Name.CompareTo(other.Name);
            }

            return comparer;
        }
    }

    class Program
    {
        static SortedSet<Unit> units = new SortedSet<Unit>();
        static Dictionary<string, Unit> nameType = new Dictionary<string, Unit>();
        static Dictionary<string, SortedSet<Unit>> dict = new Dictionary<string, SortedSet<Unit>>();

        static void Main(string[] args)
        {
            var builder = new StringBuilder();
            while (true)
            {
                var command = Console.ReadLine().Split(' ');
                switch (command[0][0])
                {
                    case 'a': builder.AppendLine(Add(command[1], command[2], int.Parse(command[3]))); break;
                    case 'r': builder.AppendLine(Remove(command[1])); break;
                    case 'f': builder.AppendLine(Find(command[1])); break;
                    case 'p': builder.AppendLine(Power(int.Parse(command[1]))); break;
                    case 'e': Console.WriteLine(builder.ToString().TrimEnd()); return;
                }
            }
        }

        static string Add(string name, string type, int attack)
        {
            var unit = new Unit(name, type, attack);
            if (units.Add(unit))
            {
                if (!dict.ContainsKey(type))
                {
                    dict[type] = new SortedSet<Unit>();
                }

                dict[type].Add(unit);
                nameType[name] = unit;

                return "SUCCESS: " + name + " added!";
            }

            return "FAIL: " + name + " already exists!";
        }

        static string Remove(string name)
        {
            if (!nameType.ContainsKey(name))
            {
                return "FAIL: " + name + " could not be found!";
            }

            var unit = nameType[name];
            if (units.Remove(unit))
            {
                dict[unit.Type].Remove(unit);
                nameType[name] = null;
                return "SUCCESS: " + name + " removed!";
            }

            return "FAIL: " + name + " could not be found!";
        }

        static string Find(string type)
        {
            var result = "RESULT: ";
            if (!dict.ContainsKey(type))
            {
                return result;
            }

            return result + string.Join(", ", dict[type].Take(10));
        }

        static string Power(int count)
        {
            var result = "RESULT: ";
            var curr = string.Join(", ", units.Take(count));

            return result + curr;
        }
    }
}
