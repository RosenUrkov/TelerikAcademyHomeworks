namespace NorthwindClient
{
    using NorthwindDatabase;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            GetAllCustomers().ForEach(Console.WriteLine);

            Console.WriteLine();

            GetAllCustomersSQL().ForEach(Console.WriteLine);

            Console.WriteLine();

            GetAllOrdersByRegionAndPeriod("SP", new DateTime(1996, 07, 17)).ForEach(x=> Console.WriteLine(x.ShipName));
        }

        private static List<Customer> GetAllCustomers()
        {
            using (var context = new NorthwindContext())
            {
                return context.Customers
                    .Where(x => x.Orders.Any(y =>
                            y.OrderDate.Value.Year == 1997 &&
                            y.City.Country.Name == "Canada"))
                    .ToList();
            }
        }

        private static List<Customer> GetAllCustomersSQL()
        {
            string query = @"SELECT * FROM Customers c
	                            JOIN Orders o
	                            ON c.CustomerID = o.CustomerID
	                            JOIN Cities ct
	                            ON o.ShipCityId = ct.CityId
	                            JOIN Countries co
	                            ON ct.CountryId = co.CountryId
                            WHERE DATEPART(YEAR, o.OrderDate) = 1997
	                            AND co.Name = 'Canada'";

            using (var context = new NorthwindContext())
            {
                return context.Customers.SqlQuery(query).ToList();
            }
        }

        private static List<Order> GetAllOrdersByRegionAndPeriod(string region, DateTime timePeriod)
        {
            using (var context = new NorthwindContext())
            {
                return context.Orders
                    .Where(x => x.ShipRegion == region && (x.OrderDate == timePeriod || x.ShippedDate == timePeriod))
                .ToList();
            }
        }
    }
}
