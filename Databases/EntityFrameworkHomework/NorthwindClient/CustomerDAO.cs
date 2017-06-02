using NorthwindDatabase;
using System.Data.Entity;
using System.Linq;

namespace NorthwindClient
{
    public class CustomerDAO
    {
        public static void AddCustomer(Customer customer)
        {
            using (var context = new NorthwindContext())
            {
                context.Customers.Add(customer);

                context.SaveChanges();
            }
        }

        public static void UpdateCustomer(Customer customer)
        {
            using (var context = new NorthwindContext())
            {
                context.Entry(customer).State = EntityState.Modified;

                context.SaveChanges();
            }
        }

        public static Customer FindCustomerById(string customerId)
        {
            using (var context = new NorthwindContext())
            {
                return context.Customers.Find(customerId);
            }
        }

        public static void DeleteCustomer(Customer customer)
        {
            using (var context = new NorthwindContext())
            {
                var deletingCustomer = context.Customers.Find(customer.CustomerID);
                context.Customers.Remove(deletingCustomer);
                
                context.SaveChanges();
            }
        }
    }
}
