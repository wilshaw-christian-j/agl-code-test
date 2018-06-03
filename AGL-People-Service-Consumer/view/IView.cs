
using AGL_People_Service_Consumer.model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AGL_People_Service_Consumer.view
{
    public interface IView
    {
        void DisplayGroupedAndSortedPeopleData(Task<List<Person>> peopleList);
    }
}
