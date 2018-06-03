using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using AGL_People_Service_Consumer.controller;
using System.Threading.Tasks;
using AGL_People_Service_Consumer.model;

namespace AGL_People_Service_Consumer.Test
{
    [TestClass]
    public class ControllerTests: PeopleServiceConsumer
    {
        public ControllerTests() : base("invalid_endpoint", new DataRetreiver())
        {
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestEmptyEndpointUrl()
        {
            IDataRetreiver dataRetreiver = new DataRetreiver();
            IServiceConsumer testService = new PeopleServiceConsumer(String.Empty, dataRetreiver);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestNullDataRetreiver()
        {
            IDataRetreiver dataRetreiver = new DataRetreiver();
            IServiceConsumer testService = new PeopleServiceConsumer("invalid", null);
        }

        [TestMethod]
        public void TestParseSinglePersonNoPets()
        {
            List<Person> people = this.ParseData("[{\"name\":\"Bob\",\"gender\":\"Male\",\"age\":23}]");
            Assert.AreEqual(1, people.Count);
            Assert.AreEqual("Bob", people[0].Name);
            Assert.AreEqual("Male", people[0].Gender);
            Assert.AreEqual(23, people[0].Age);
            Assert.IsNull(people[0].Pets);
        }

        [TestMethod]
        public void TestParseSinglePersonSinglePet()
        {
            List<Person> people = this.ParseData("[{\"name\":\"Bob\",\"gender\":\"Male\",\"age\":23,\"pets\":[{\"name\":\"Garfield\",\"type\":\"Cat\"}]}]");
            Assert.AreEqual(1, people.Count);
            Assert.AreEqual("Bob", people[0].Name);
            Assert.AreEqual("Male", people[0].Gender);
            Assert.AreEqual(23, people[0].Age);
            Assert.AreEqual(1, people[0].Pets.Count);
            Assert.AreEqual("Garfield", people[0].Pets[0].Name);
            Assert.AreEqual("Cat", people[0].Pets[0].Type);
        }

        [TestMethod]
        public void TestParseMultiplePeopleWithPets()
        {
            List<Person> people = this.ParseData("[{\"name\":\"Bob\",\"gender\":\"Male\",\"age\":23,\"pets\":[{\"name\":\"Garfield\",\"type\":\"Cat\"},{\"name\":\"Fido\",\"type\":\"Dog\"}]},{\"name\":\"Jennifer\",\"gender\":\"Female\",\"age\":18,\"pets\":[{\"name\":\"Garfield\",\"type\":\"Cat\"}]},{\"name\":\"Steve\",\"gender\":\"Male\",\"age\":45,\"pets\":null},{\"name\":\"Fred\",\"gender\":\"Male\",\"age\":40,\"pets\":[{\"name\":\"Tom\",\"type\":\"Cat\"},{\"name\":\"Max\",\"type\":\"Cat\"},{\"name\":\"Sam\",\"type\":\"Dog\"},{\"name\":\"Jim\",\"type\":\"Cat\"}]},{\"name\":\"Samantha\",\"gender\":\"Female\",\"age\":40,\"pets\":[{\"name\":\"Tabby\",\"type\":\"Cat\"}]},{\"name\":\"Alice\",\"gender\":\"Female\",\"age\":64,\"pets\":[{\"name\":\"Simba\",\"type\":\"Cat\"},{\"name\":\"Nemo\",\"type\":\"Fish\"}]}]");
            Assert.AreEqual(6, people.Count);
            Assert.AreEqual(2, people[0].Pets.Count);
            Assert.AreEqual(1, people[1].Pets.Count);
            Assert.IsNull(people[2].Pets);
            Assert.AreEqual(4, people[3].Pets.Count);
            Assert.AreEqual(1, people[4].Pets.Count);
            Assert.AreEqual(2, people[5].Pets.Count);
        }

    }
}
