using System;
using System.Data.SqlClient;
using System.Data.Common;
using System.Threading.Tasks;

namespace SweetnSaltyDbAccess
{
    public class SweetnSaltyDbAccessClass : ISweetnSaltyDbAccessClass
    {
        private readonly string str = "Data source = DESKTOP-O4KVC7B\\SQLEXPRESS; initial Catalog = sweetNsaltyAPI; integrated security = true";
        private readonly SqlConnection _con;

        //constructor
        public SweetnSaltyDbAccessClass()
        {
            this._con = new SqlConnection(this.str);
            _con.Open();
        }

        public async Task<SqlDataReader> PostFlavor(string flavor)
        {
            string query = "insert into Flavors values(@flavor)";
            using (SqlCommand cmd = new SqlCommand(query, _con))
            {
                cmd.Parameters.AddWithValue("@flavor", flavor);
                try
                {
                    await cmd.ExecuteNonQueryAsync();
                    query = "SELECT TOP 1 * FROM Flavors ORDER BY FlavorID DESC;";
                    using (SqlCommand sqlCommand = new SqlCommand(query, _con))
                    {
                        SqlDataReader dr = await sqlCommand.ExecuteReaderAsync();
                        return dr;
                    }

                }
                catch (DbException)
                {
                    Console.WriteLine("error");
                    return null;
                }
            }

            }
            public async Task<SqlDataReader> PostPerson(string fname, string lname)
            {
                string query = "insert into Users values (@fname, @lname);";
            using (SqlCommand cmd = new SqlCommand(query, _con))
            {
                cmd.Parameters.AddWithValue("@fname", fname);
                cmd.Parameters.AddWithValue("@lname", lname);
                try
                {
                    await cmd.ExecuteNonQueryAsync();
                    query = "select top 1 * FROM Users ORDER BY UserID DESC;";
                    using (SqlCommand sqlCommand = new SqlCommand(query, _con))
                    {
                        SqlDataReader dr = await sqlCommand.ExecuteReaderAsync();
                        return dr;
                    }

                }
                catch (DbException)
                {
                    Console.WriteLine("error");
                    return null;
                }
            }
            }
                public async Task<SqlDataReader> GetPerson(string fname, string lname)
                {
                    string query = "select * from Users WHERE FirstName = @fname AND LastName = @lname;";
                   
                        using (SqlCommand cmd = new SqlCommand(query, _con))
                        {
                            cmd.Parameters.AddWithValue("@fname", fname);
                            cmd.Parameters.AddWithValue("@lname", lname);
                            SqlDataReader dr = await cmd.ExecuteReaderAsync();
                            return dr;
                        }
                   
                }

                public async Task<SqlDataReader> GetPersonAndFlavors(int id)
                {
                    string query = "select Flavors.FlavorID, FLavors.FlavorName from Flavors" +                                   
                                       "left join UserTastes ON Flavors.FlavorID = UserTastes.FlavorID" +
                                       "where Users.UserID = @id;";
                  
                        using (SqlCommand cmd = new SqlCommand(query, _con))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            SqlDataReader dr = await cmd.ExecuteReaderAsync();
                            return dr;
                        }                  

                }

               public  async Task<SqlDataReader> GetAllFlavors()
                {
                    string query = "select * FROM Flavors;";
            
            
                using (SqlCommand cmd = new SqlCommand(query, _con))
                {
                    SqlDataReader dr = await cmd.ExecuteReaderAsync();
                    return dr;
                }
                }
               }
            }
        
    


