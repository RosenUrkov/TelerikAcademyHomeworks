using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace PlayerRanking
{
    class Player : IComparable<Player>
    {
        public Player(string name, string type, int age)
        {
            this.Name = name;
            this.Type = type;
            this.Age = age;
        }

        public string Name { get; set; }

        public string Type { get; set; }

        public int Age { get; set; }

        public string View()
        {
            return this.Name + "(" + this.Age + ")";
        }

        public override string ToString()
        {
            return this.View();
        }

        public override bool Equals(object obj)
        {
            var other = obj as Player;
            return this.Age == other.Age && this.Name == other.Name && this.Type == other.Type;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() ^ this.Type.GetHashCode() ^ this.Age.GetHashCode();
        }

        public int CompareTo(Player other)
        {
            var comparer = this.Name.CompareTo(other.Name);
            if (comparer != 0)
            {
                return comparer;
            }

            return other.Age.CompareTo(this.Age);
        }
    }

    public class Program
    {
        static Dictionary<string, SortedSet<Player>> find = new Dictionary<string, SortedSet<Player>>();
        static BigList<Player> ranking = new BigList<Player>();

        public static void Main(string[] args)
        {
            var builder = new StringBuilder();

            while (true)
            {
                var commandArgs = Console.ReadLine().Split(' ');

                switch (commandArgs[0][0])
                {
                    case 'a': Add(commandArgs[1], commandArgs[2], int.Parse(commandArgs[3]), int.Parse(commandArgs[4]), builder); break;
                    case 'f': Find(commandArgs[1], builder); break;
                    case 'r': Ranklist(int.Parse(commandArgs[1]), int.Parse(commandArgs[2]), builder); break;
                    case 'e': Console.WriteLine(builder.ToString().TrimEnd('\n', '\r')); return;
                }
            }
        }

        static void Add(string name, string type, int age, int position, StringBuilder builder)
        {
            var player = new Player(name, type, age);
            ranking.Insert(position - 1, player);

            if (!find.ContainsKey(type))
            {
                find[type] = new SortedSet<Player>();
            }
            find[type].Add(player);

            builder.AppendLine("Added player " + name + " to position " + position);
        }

        static void Find(string type, StringBuilder builder)
        {
            builder.Append("Type " + type + ": ");

            if (!find.ContainsKey(type))
            {
                builder.AppendLine();
                return;
            }

            builder.AppendLine(string.Join("; ", find[type].Take(5)));
        }

        static void Ranklist(int start, int end, StringBuilder builder)
        {
            var range = ranking.GetRange(start - 1, end - (start - 1));
            builder.AppendLine(string.Join("; ", range.Select((x, i) => i + 1 + ". " + x.View())));
        }
    }
}
