using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjO1Test
{
    class MockDBTest
    {

        public List<Customer> GetCustomer()
        {
            List<Customer> customers = new List<Customer>();
            Customer c1 = new Customer()
            {
                customerId = 1,
                firstName = "Dan",
                lastName = "Spill",
                username = "Dan.S",
                eMail = "dantheman@co.co",
                password = "1111",
            };
            Customer c2 = new Customer()
            {
                customerId = 2,
                firstName = "D",
                lastName = "Sp",
                username = "D.S",
                eMail = "dant@co.co",
                password = "111",
            };
            Customer c3 = new Customer()
            {
                customerId = 3,
                firstName = "ant",
                lastName = "ill",
                username = "n.S",
                eMail = "theman@co.co",
                password = "1441",
            };
            customers.Add(c1);
            customers.Add(c2);
            customers.Add(c3);
            return customers;
        }




        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            Product p1 = new Product()
            {
                productId = 1,
                productName = "New Thing",
                description = "a thing thats new",
                price = 23.00
            };
            Product p2 = new Product()
            {
                productId = 10,
                productName = "Thing",
                description = "a thing",
                price = 2344.00
            };
            Product p3 = new Product()
            {
                productId = 100,
                productName = "big thing",
                description = "large object",
                price = 1.00
            };
            products.Add(p1);
            products.Add(p2);
            products.Add(p3);
            return products;
        }

        public List<Order> GetOrders()
        {
            List<Order> orders = new List<Order>();
            Order o1 = new Order()
            {
                productId = 1,
                productName = "New Thing",
                description = "a thing thats new",
                price = 23.00
            };
            Order o2 = new Order()
            {
                productId = 10,
                productName = "Thing",
                description = "a thing",
                price = 2344.00
            };
            Order o3 = new Order()
            {
                productId = 100,
                productName = "big thing",
                description = "large object",
                price = 1.00
            };
            orders.Add(o1);
            orders.Add(o2);
            orders.Add(o3);
            return orders;
        }


    }
}