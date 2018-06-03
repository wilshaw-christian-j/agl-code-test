using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AGL_People_Service_Consumer.controller;
using System.Threading.Tasks;

namespace AGL_People_Service_Consumer.Test
{
    [TestClass]
    public class DataRetreiverTests
    {
        [TestMethod]
        public void TestValidServiceUrlAsync()
        {
            string url = "http://agl-developer-test.azurewebsites.net/people.json";
            IDataRetreiver dataRetreiver = new DataRetreiver();
            var actual = Task.Run(async () => await dataRetreiver.GetData(url));
            actual.Wait();
            String expected = "[{\"name\":\"Bob\",\"gender\":\"Male\",\"age\":23,\"pets\":[{\"name\":\"Garfield\",\"type\":\"Cat\"},{\"name\":\"Fido\",\"type\":\"Dog\"}]},{\"name\":\"Jennifer\",\"gender\":\"Female\",\"age\":18,\"pets\":[{\"name\":\"Garfield\",\"type\":\"Cat\"}]},{\"name\":\"Steve\",\"gender\":\"Male\",\"age\":45,\"pets\":null},{\"name\":\"Fred\",\"gender\":\"Male\",\"age\":40,\"pets\":[{\"name\":\"Tom\",\"type\":\"Cat\"},{\"name\":\"Max\",\"type\":\"Cat\"},{\"name\":\"Sam\",\"type\":\"Dog\"},{\"name\":\"Jim\",\"type\":\"Cat\"}]},{\"name\":\"Samantha\",\"gender\":\"Female\",\"age\":40,\"pets\":[{\"name\":\"Tabby\",\"type\":\"Cat\"}]},{\"name\":\"Alice\",\"gender\":\"Female\",\"age\":64,\"pets\":[{\"name\":\"Simba\",\"type\":\"Cat\"},{\"name\":\"Nemo\",\"type\":\"Fish\"}]}]";
            Assert.AreEqual(expected, actual.Result);
        }
    }
}
