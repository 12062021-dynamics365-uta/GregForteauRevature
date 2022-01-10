using System;
using System.Collections.Generic;

namespace SweetnSaltyModels
{
    public class Person
    {
        public int PersonId {  get; set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Flavor> personalFlav {  get; set;}
    }
}
