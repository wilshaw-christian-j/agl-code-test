using AGL_People_Service_Consumer.model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AGL_People_Service_Consumer.controller
{
    public interface IServiceConsumer
    {
        Task<List<Person>> GetAllPeople();
    }
}
