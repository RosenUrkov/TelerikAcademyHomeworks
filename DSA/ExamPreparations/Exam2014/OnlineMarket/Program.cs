using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace OrdersSystem
{
    class Order : IComparable<Order>
    {
        public Order(string name, double price, string consumer)
        {
            this.Name = name;
            this.Price = price;
            this.Consumer = consumer;
        }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Consumer { get; set; }

        public int CompareTo(Order other)
        {
            var comparer = this.Price.CompareTo(other.Price);
            if (comparer == 0)
            {
                comparer = this.Name.CompareTo(other.Name);
            }
            if (comparer == 0)
            {
                comparer = this.Consumer.CompareTo(other.Consumer);
            }

            return comparer;
        }

        public override string ToString()
        {
            return string.Format("{0}({1})", this.Name, this.Price);
        }

        public override bool Equals(object obj)
        {
            var other = obj as Order;
            return this.Name == other.Name;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
    }

    class Program
    {
        static Dictionary<string, HashSet<Order>> dict = new Dictionary<string, HashSet<Order>>();
        static OrderedMultiDictionary<double, Order> dict2 = new OrderedMultiDictionary<double, Order>(true);

        static void Main(string[] args)
        {
            var builder = new StringBuilder();
            while (true)
            {
                var command = Console.ReadLine().Split(' ');

                switch (command[0][0])
                {
                    case 'a': builder.AppendLine(Add(command[1], double.Parse(command[2]), command[3])); break;
                    case 'f':
                        if (command.Length == 4)
                        {
                            builder.AppendLine(Find(command[3]));
                        }
                        else if (command.Length == 7)
                        {
                            builder.AppendLine(Find(double.Parse(command[4]), double.Parse(command[6])));
                        }
                        else if (command[3][0] == 'f')
                        {
                            builder.AppendLine(Find(double.Parse(command[4]), double.MaxValue));
                        }
                        else if (command[3][0] == 't')
                        {
                            builder.AppendLine(Find(double.MinValue, double.Parse(command[4])));
                        }
                        break;
                    case 'e': Console.WriteLine(builder.ToString().TrimEnd()); return;
                }
            }
        }

        static string Add(string name, double price, string consumer)
        {
            var order = new Order(name, price, consumer);
            if (!dict.ContainsKey(consumer))
            {
                dict[consumer] = new HashSet<Order>();
            }

            if (!dict[consumer].Add(order))
            {
                return "Error: Product " + name + " already exists";
            }

            dict2[price].Add(order);
            return "Ok: Product " + name + " added successfully";
        }

        static string Find(double from, double to)
        {
            var range = dict2.Range(from, true, to, true);

            var result = new List<Order>();
            foreach (var pair in range)
            {
                foreach (var item in pair.Value)
                {
                    result.Add(item);
                }
            }

            result.Sort();
            var res = result.Take(10).Select(x => x.ToString());
            return "Ok: " + string.Join(", ", res);
        }

        static string Find(string consumer)
        {
            if (!dict.ContainsKey(consumer) || dict[consumer].Count == 0)
            {
                return "Error: Type " + consumer + " does not exists";
            }

            var result = new List<Order>();
            foreach (var order in dict[consumer])
            {
                result.Add(order);
            }

            result.Sort();
            var res = result.Take(10).Select(x => x.ToString());
            return "Ok: " + string.Join(", ", res);
        }
    }
}