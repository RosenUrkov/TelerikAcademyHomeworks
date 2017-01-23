using Cosmetics.Common;
using Cosmetics.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Products
{
    public class Shampoo :Product, IShampoo, IProduct
    {     

        public Shampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage) 
            :base(name,brand,price,gender)
        {            
            this.Milliliters = milliliters;
            this.Usage = usage;
            this.Price = price * milliliters;

        }
                                      
        public uint Milliliters { get;private set; }

        public UsageType Usage { get; private set; }        

        public override string Print()
        {
            var builder = new StringBuilder();
            builder.AppendLine(base.Print());
            builder.AppendLine($"  * Quantity: {this.Milliliters} ml");
            builder.AppendLine($"  * Usage: {this.Usage}");

            return builder.ToString().Trim();
        }

    }
}
