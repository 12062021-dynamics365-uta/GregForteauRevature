using SweetnSaltyModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SweetnSaltyBusiness
{
    public class Mapper : IMapper
    {
        public Flavor EntityToFlavor(SqlDataReader dr)
        {
            return new Flavor()
            {
                FlavorId = dr.GetInt32(0),
                FlavorName = dr.GetString(1),
            };
        }
        public Person EntityToPerson(SqlDataReader dr)
        {
            return new Person()
            {
                PersonId = dr.GetInt32(0),
                FirstName = dr.GetString(1),
                LastName = dr.GetString(2),
            };
        }
        public Person EntityToPersonFlavors(SqlDataReader dr)
        {
            Person p = new Person();
            List<Flavor> f = new List<Flavor>();
            do
            {
                Flavor flavor = new Flavor()
                {
                    FlavorId = dr.GetInt32(3),
                    FlavorName = dr.GetString(4),
                };
                f.Add(flavor);
                p = new Person()
                {
                    PersonId = dr.GetInt32(0),
                    FirstName = dr.GetString(1),
                    LastName = dr.GetString(2),
                    personalFlav = f
                };
            } while (dr.Read());
            return p;
        }
        public List<Flavor> EntityToFlavorList(SqlDataReader dr)
        {
            List<Flavor> flavors = new List<Flavor>();
            while (dr.Read())
            {
                Flavor flavor = new Flavor()
                {
                    FlavorId = dr.GetInt32(0),
                    FlavorName = dr.GetString(1),
                };
                flavors.Add(flavor);
            }
            return flavors;
        }

    }
    }
