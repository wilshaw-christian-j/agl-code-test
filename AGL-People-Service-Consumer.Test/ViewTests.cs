using AGL_People_Service_Consumer.model;
using AGL_People_Service_Consumer.view;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AGL_People_Service_Consumer.Test
{
    [TestClass]
    public class ViewTests: ConsoleView
    {

        [TestMethod]
        public void TestSortingAndFiltering()
        {
            List<Person> people = TestData.PersonTestData();
            var data = people.OrderBy(p => p.Gender)
                .Where(p => p.Pets != null)
                .GroupBy(p => p.Gender)
                .ToList();
            foreach (var group in data)
            {
                var sortedPets = this.SortCatsByName(group);
                if (group.Key.Equals("Female"))
                {
                    Assert.AreEqual(2, sortedPets.Count);
                    Assert.AreEqual("Frank", sortedPets[0].Name);
                    Assert.AreEqual("October", sortedPets[1].Name);
                }
                else
                {
                    Assert.AreEqual(3, sortedPets.Count);
                    Assert.AreEqual("Deeno", sortedPets[0].Name);
                    Assert.AreEqual("Indigo", sortedPets[1].Name);
                    Assert.AreEqual("Meow", sortedPets[2].Name);
                }
            }

        }
    }
}
