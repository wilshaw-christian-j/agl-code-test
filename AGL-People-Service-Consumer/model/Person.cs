using System;
using System.Collections.Generic;
using System.Text;

namespace AGL_People_Service_Consumer.model
{
    public class Person
    {
        public String Name { get; set; }
        public String Gender { get; set; }
        public Int32 Age { get; set; }

        public List<Pet> Pets;
    }
}
