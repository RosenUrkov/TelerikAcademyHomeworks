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
            return this.Name.CompareTo(other.Name);
        }

        public override string ToString()
        {
            return "{" + string.Format("{0};{1};{2:F2}", this.Name, this.Consumer, this.Price) + "}";
        }
    }

    class Program
    {
        static MultiDictionary<string, Order> dict = new MultiDictionary<string, Order>(true);
        static OrderedMultiDictionary<double, Order> dict2 = new OrderedMultiDictionary<double, Order>(true);

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var fullCommand = Console.ReadLine();

                var spaceIndex = fullCommand.IndexOf(' ');
                var command = fullCommand.Substring(0, spaceIndex);
                var parameters = fullCommand.Substring(spaceIndex + 1).Split(';');

                switch (command[0])
                {
                    case 'A': Console.WriteLine(Add(parameters[0], double.Parse(parameters[1]), parameters[2])); break;
                    case 'D': Console.WriteLine(Delete(parameters[0])); break;
                    case 'F':
                        Console.WriteLine(parameters.Length == 1 ?
                            Find(parameters[0]) :
                            Find(double.Parse(parameters[0]), double.Parse(parameters[1])));
                        break;
                }
            }
        }

        static string Add(string name, double price, string consumer)
        {
            var order = new Order(name, price, consumer);

            dict[consumer].Add(order);
            dict2[price].Add(order);

            return "Order added";
        }

        static string Delete(string consumer)
        {
            if (!dict.ContainsKey(consumer) || dict[consumer].Count == 0)
            {
                return "No orders found";
            }

            foreach (var item in dict[consumer])
            {
                dict2.Remove(item.Price, item);
            }

            var result = dict[consumer].Count + " orders deleted";
            dict.Remove(consumer);

            return result;
        }

        static string Find(double from, double to)
        {
            var range = dict2.Range(from, true, to, true);
            if (range.Count == 0)
            {
                return "No orders found";
            }

            var result = new OrderedBag<string>();
            foreach (var pair in range)
            {
                foreach (var item in pair.Value)
                {
                    result.Add(item.ToString());
                }
            }
            
            return string.Join("\n", result);
        }

        static string Find(string consumer)
        {
            if (!dict.ContainsKey(consumer) || dict[consumer].Count == 0)
            {
                return "No orders found";
            }

            var result = new OrderedBag<string>();
            foreach (var order in dict[consumer])
            {
                result.Add(order.ToString());
            }
            
            return string.Join("\n", result);
        }
    }
}
