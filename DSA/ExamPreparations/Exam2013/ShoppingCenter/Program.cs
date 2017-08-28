using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace ShoppingCenter
{
    class Product : IComparable<Product>
    {
        public Product(string name, double price, string producer)
        {
            this.Name = name;
            this.Price = price;
            this.Producer = producer;
        }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Producer { get; set; }

        public int CompareTo(Product other)
        {
            var compar = this.Name.CompareTo(other.Name);
            if (compar != 0)
            {
                return compar;
            }

            compar = this.Producer.CompareTo(other.Producer);
            if (compar != 0)
            {
                return compar;
            }

            return this.Price.CompareTo(other.Price);
        }

        public override bool Equals(object obj)
        {
            var other = obj as Product;
            return this.Name == other.Name && this.Price == other.Price && this.Producer == other.Producer;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() ^ this.Price.GetHashCode() ^ this.Producer.GetHashCode();
        }

        public override string ToString()
        {
            return "{" + string.Format("{0};{1};{2:F2}", this.Name, this.Producer, this.Price) + "}";
        }
    }

    public class Program
    {
        static Dictionary<string, OrderedBag<Product>> dict = new Dictionary<string, OrderedBag<Product>>();

        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var builder = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                var fullCommand = Console.ReadLine();
                var commandEndIndex = fullCommand.IndexOf(' ');

                var command = fullCommand.Substring(0, commandEndIndex);
                var parameters = fullCommand.Substring(commandEndIndex + 1).Split(';');

                switch (command)
                {
                    case "AddProduct": builder.AppendLine(AddProduct(parameters[0], double.Parse(parameters[1]), parameters[2])); break;
                    case "DeleteProducts": builder.AppendLine(parameters.Length == 1 ? DeleteProducts(parameters[0]) : DeleteProducts(parameters[0], parameters[1])); break;
                    case "FindProductsByName": FindProductsByName(parameters[0], builder); break;
                    case "FindProductsByPriceRange": FindProductsByPriceRange(double.Parse(parameters[0]), double.Parse(parameters[1]), builder); break;
                    case "FindProductsByProducer": FindProductsByProducer(parameters[0], builder); break;
                }
            }

            Console.WriteLine(builder.ToString().TrimEnd());
        }

        static string AddProduct(string name, double price, string producer)
        {
            var prod = new Product(name, price, producer);
            var priceStr = price.ToString();

            if (!dict.ContainsKey(name))
            {
                dict[name] = new OrderedBag<Product>();
            }
            if (!dict.ContainsKey(producer))
            {
                dict[producer] = new OrderedBag<Product>();
            }
            if (!dict.ContainsKey(priceStr))
            {
                dict[priceStr] = new OrderedBag<Product>();
            }

            dict[name].Add(prod);
            dict[producer].Add(prod);
            dict[priceStr].Add(prod);

            return "Product added";
        }

        static string DeleteProducts(string name, string producer)
        {
            if ((!dict.ContainsKey(producer) || dict[producer].Count == 0) &&
                (!dict.ContainsKey(name) || dict[name].Count == 0))
            {
                return "No products found";
            }

            var prods = dict[name];

            var count = 0;
            foreach (var item in prods)
            {
                if (item.Producer == producer)
                {
                    count++;
                    dict[name].Remove(item);
                    dict[producer].Remove(item);
                    dict[item.Price.ToString()].Remove(item);
                }
            }

            var prods2 = dict[producer];
            foreach (var item in prods2)
            {
                if (item.Name == name)
                {
                    count++;
                    dict[producer].Remove(item);
                    dict[item.Price.ToString()].Remove(item);
                }
            }


            return count + " products deleted";
        }

        static string DeleteProducts(string producer)
        {
            if (!dict.ContainsKey(producer) || dict[producer].Count == 0)
            {
                return "No products found";
            }

            var prods = dict[producer];
            dict[producer] = null;

            foreach (var item in prods)
            {
                dict[item.Name].Remove(item);
                dict[item.Price.ToString()].Remove(item);
            }

            return prods.Count + " products deleted";
        }

        static void FindProductsByName(string name, StringBuilder builder)
        {
            if (!dict.ContainsKey(name) || dict[name].Count == 0)
            {
                builder.AppendLine("No products found");
                return;
            }

            var prods = dict[name];
            foreach (var item in prods)
            {
                builder.AppendLine(item.ToString());
            }
        }

        static void FindProductsByProducer(string producer, StringBuilder builder)
        {
            if (!dict.ContainsKey(producer) || dict[producer].Count == 0)
            {
                builder.AppendLine("No products found");
                return;
            }

            var prods = dict[producer];
            foreach (var item in prods)
            {
                builder.AppendLine(item.ToString());
            }
        }

        static void FindProductsByPriceRange(double fromPrice, double toPrice, StringBuilder builder)
        {
            var prods = new OrderedBag<string>();
            foreach (var item in dict.Keys)
            {
                double res;
                if (double.TryParse(item, out res))
                {
                    if (fromPrice <= res && res <= toPrice)
                    {
                        foreach (var prod in dict[item])
                        {
                            prods.Add(prod.ToString());
                        }
                    }
                }
            }

            if (prods.Count == 0)
            {
                builder.AppendLine("No products found");
                return;
            }

            foreach (var item in prods)
            {
                builder.AppendLine(item);
            }
        }
    }
}
