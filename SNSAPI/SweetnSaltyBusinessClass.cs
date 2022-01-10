using SweetnSaltyDbAccess;
using SweetnSaltyModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SweetnSaltyBusiness
{
    public class SweetnSaltyBusinessClass : ISweetnSaltyBusinessClass
    {
        private readonly ISweetnSaltyDbAccessClass __dB;
        private readonly IMapper _map;

        public SweetnSaltyBusinessClass(ISweetnSaltyDbAccessClass Dbaccess, IMapper mapper)//you need a reference to the DbAccess Layer 
        {
           this. _map = mapper;
           this. __dB = Dbaccess;
        }
    
        public async Task<Flavor> PostFlavor(string flavor)
        {
            SqlDataReader dr = await __dB.PostFlavor(flavor);
            if (dr.Read())
            {
                Flavor f = _map.EntityToFlavor(dr);
                return f;
            }
            else { return null; }
        }

     public async Task<Person> PostPerson(string fname, string lname)
        {
            SqlDataReader dr = await __dB.PostPerson(fname, lname);
            if (dr.Read())
            {
                Person p = _map.EntityToPerson(dr);
                return p;
            }
            else { return null; }
        }

     public async Task<Person> GetPerson(string fname, string lname)
        {
            SqlDataReader dr = await __dB.GetPerson(fname, lname);
            if (dr.Read())
            {
                Person p = _map.EntityToPerson(dr);
                return p;
            }
            else { return null; }
        }
      public async Task<Person> GetPersonAndFlavors(int id)
        {
             SqlDataReader dr = await __dB.GetPersonAndFlavors(id);
            if (dr.Read())
            {
                Person p = _map.EntityToPersonFlavors(dr);
                return p;
            }
            else { return null; }
        }

    public async Task<List<Flavor>> GetAllFlavors()
        {
           SqlDataReader dr = await __dB.GetAllFlavors();
            List<Flavor> f=  _map.EntityToFlavorList(dr);
            return f;
        }

    }
}
