using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Model;

namespace Storage
{
    public class DataBaseAccess : IDataBaseAccess
    {
        private readonly string connectionStr = "Data source = DESKTOP-O4KVC7B\\SQLEXPRESS; initial Catalog=ProjO1; integrated security = true";
        private readonly SqlConnection connection;
        private readonly IMapper mapper;

        public DataBaseAccess(IMapper mapper)
        {
            this.connection = new SqlConnection(connectionStr);
            this.connection.Open();
            this.mapper = mapper;
        }

      
        // Searches database for customer to match
        // UserName and Password
       
        public Customer GetCustomer(string userName, string password)
        {
            string queryString = ($"SELECT * FROM Customers WHERE UserName = '{userName}' AND UserPassword = '{password}';");

            Customer customer;
            using (SqlCommand cmd = new SqlCommand(queryString, this.connection))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                customer = this.mapper.EntityToCustomer(dr);
                dr.Close();
            }
            return customer;
        }

       
        // Gets List of stores from database
        
        public List<Store> GetStores()
        {
            string queryString = "SELECT * FROM Stores;";
            List<Store> stores = new ();
            using (SqlCommand cmd = new (queryString, this.connection))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                stores = this.mapper.EntityToStoreList(dr);
                dr.Close();
            }
            return stores;
        }

       
        // Gets products from store
       
        public List<Product> GetStoreProducts(int storeId)
        {
            string queryString = "SELECT ProductId, ProductName, ProductAmount, ProductDesc FROM Products WHERE StoreId = " + storeId;
            List<Product> products = new List<Product>();
            using (SqlCommand cmd = new SqlCommand(queryString, this.connection))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                products = this.mapper.EntityToProductList(dr);
                dr.Close();
            }
            return products;
        }

        
        // Gets customers orders from database
       
        public List<Order> GetOrders(int customerId, int storeId)
        {
            string queryString = "SELECT o.OrderId, p.StoreId, p.ProductId, p.ProductName, p.ProductDesc, p.ProductAmount,     o.TotalAmount " + 
                "FROM Products p " +

                "LEFT JOIN OrderProduct op " +

                "ON op.ProductId = p.ProductId " +

                "LEFT JOIN Orders o " +

                "ON op.OrderId = o.OrderId " +

                "WHERE o.CustomerId = " + customerId + " AND p.StoreId = " + storeId;

            List<Order> orders = new List<Order>();
            using (SqlCommand cmd = new SqlCommand(queryString, this.connection))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                orders = this.mapper.EntityToOrderList(dr);
                dr.Close();
            }
            return orders;
        }

       
        // Adds a customer to the database
       
        public int AddCustomer(string fName, string lName, string uName, string password)
        {
            int newId;
            string queryString = ($"INSERT INTO Customers (FirstName, LastName, UserName, UserPassword) OUTPUT INSERTED.CustomerId VALUES ('{fName}', '{lName}', '{uName}', '{password}');");

            using (SqlCommand cmd = new SqlCommand(queryString, this.connection))
            {
                newId = (int)cmd.ExecuteScalar();
                return newId;
            }
        }

      
        // Adds new order to the database
      
        public int AddOrder(int customerId, decimal totalAmount)
        {
            int newId;
            string queryString = ($"INSERT INTO Orders (CustomerId, TotalAmount) OUTPUT INSERTED.OrderId VALUES ({customerId}, {(decimal)totalAmount});");

            using SqlCommand cmd = new SqlCommand(queryString, this.connection);
            newId = (int)cmd.ExecuteScalar();
            return newId;
        }

      
        // Adds order and product id to junction table in database
       
        public void AddOrderProduct(int orderId, int productId)
        {
            string queryString = ($"INSERT INTO OrderProduct (OrderId, ProductId) VALUES ({orderId}, {productId});");

            using (SqlCommand cmd = new SqlCommand(queryString, this.connection))
            {
                cmd.ExecuteScalar();
            }
        }

       
        // Closes database connection
        
        public void CloseDataBaseConnection()
        {
            this.connection.Close();
        }
    }
}