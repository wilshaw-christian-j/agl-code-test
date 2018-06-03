
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AGL_People_Service_Consumer.model;

namespace AGL_People_Service_Consumer.view{
    public class ConsoleView : IView
    {
        public void DisplayGroupedAndSortedPeopleData(Task<List<Person>> peopleData)
        {
            foreach (var petOwner in GroupPetOwnersByGender(peopleData))
            {
                Console.WriteLine("");
                Console.WriteLine(" "+petOwner.Key);
                Console.WriteLine("");

                foreach (var pet in SortCatsByName(petOwner))
                {
                    Console.WriteLine(" *"+pet.Name);
                }
            }
            Console.Read();
        }
        protected List<IGrouping<string, Person>> GroupPetOwnersByGender(Task<List<Person>> personData)
        {
            var peopleData = personData.Result.ToList();
            return peopleData
                .OrderBy(p => p.Gender)
                .Where(p => p.Pets != null)
                .GroupBy(p => p.Gender)
                .ToList();
        }
        protected List<Pet> SortCatsByName(IGrouping<string, Person> group)
        {
            return group.SelectMany(p => p.Pets).Where(c => c.Type.Equals("Cat")).OrderBy(p => p.Name).ToList();
        }
    }
}
