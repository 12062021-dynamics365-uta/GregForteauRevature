using System.Collections.Generic;
using System.Data.SqlClient;
using Model;

namespace Storage
{
    public class Mapper : IMapper
    {
        
        // Maps database entity to Customer Object
        
        public Customer EntityToCustomer(SqlDataReader dr)
        {
            Customer customer = null;

            while (dr.Read())
            {
                customer = new Customer()
                {
                    CustomerId = dr.GetInt32(0),
                    Fname = dr.GetString(1),
                    Lname = dr.GetString(2)
                };
            }
            return customer;
        }

       
        // Maps database entity to list of store objects
       
        public List<Store> EntityToStoreList(SqlDataReader dr)
        {
            List<Store> stores = new();// new syntax

            while (dr.Read())
            {
                Store s = new()// new syntax
                {
                    StoreId = dr.GetInt32(0),
                    Name = dr.GetString(1)
                };
                stores.Add(s);
            }
            return stores;
        }

    
        // Maps database entity to list of product objects
        
       
        public List<Product> EntityToProductList(SqlDataReader dr)
        {
            List<Product> products = new ();

            while (dr.Read())
            {
                Product p = new ()
                {
                    ProductId = dr.GetInt32(0),
                    Name = dr.GetString(1),
                    Description = dr.GetString(3),
                    Price = dr.GetDecimal(2)
                };
                products.Add(p);
            }
            return products;
        }

        
        // Maps database entity to list of orders
        
        public List<Order> EntityToOrderList(SqlDataReader dr)
        {
            List<Order> orders = new ();

            while (dr.Read())
            {
                Order order = new ()
                {
                    OrderId = dr.GetInt32(0),
                    TotalCost = dr.GetDecimal(6),
                    Products = new List<Product>()
                };

                if (!orders.Exists(x => x.OrderId == dr.GetInt32(0)))
                    orders.Add(order);
                foreach (Order o in orders)
                {
                    if (o.OrderId == dr.GetInt32(0))
                    {
                        Product p = new ()
                        {
                            ProductId = dr.GetInt32(2),
                            Name = dr.GetString(3),
                            Description = dr.GetString(4),
                            Price = dr.GetDecimal(5)
                        };
                        o.Products.Add(p);
                    }
                }
            }
            return orders;
        }
    }
}