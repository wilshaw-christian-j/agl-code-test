using AGL_People_Service_Consumer.model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AGL_People_Service_Consumer.Test
{
    public static class TestData
    {
        public static List<Person> PersonTestData()
        {
            return new List<Person>{
                new Person
                {
                    Name = "Abel",
                    Gender = "Male",
                    Pets = new List<Pet>
                    {
                        new Pet { Name = "Charlie", Type = "Dog" },
                        new Pet { Name = "Deeno", Type = "Cat" }
                    }
                },
                    new Person
                    {
                        Name = "Elsa",
                        Gender = "Female",
                        Pets = new List<Pet>
                    {
                        new Pet { Name = "Frank", Type = "Cat" },
                        new Pet { Name = "Gary", Type = "Dog" }
                    }
                    },
                    new Person
                    {
                        Name = "Harry",
                        Gender = "Male",
                        Pets = new List<Pet>
                    {
                        new Pet { Name = "Indigo", Type = "Cat" }
                    }
                    },
                    new Person
                    {
                        Name = "Jason",
                        Gender = "Male",
                        Pets = new List<Pet>
                    {
                        new Pet { Name = "Kathy", Type = "Dog" },
                        new Pet { Name = "Lira", Type = "Dog" },
                        new Pet { Name = "Meow", Type = "Cat" }
                    }
                    },
                    new Person
                    {
                        Name = "Neena",
                        Gender = "Female",
                        Pets = new List<Pet>
                    {
                        new Pet { Name = "October", Type = "Cat" }
                    }
                    },
                    new Person
                    {
                        Name = "Pete",
                        Gender = "Male",
                        Pets = new List<Pet>
                    {
                        new Pet { Name = "Quintus", Type = "Dog" }
                    }
                    }


        };

        }
    }
}
