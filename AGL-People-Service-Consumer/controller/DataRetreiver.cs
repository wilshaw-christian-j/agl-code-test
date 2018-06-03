using System.Net.Http;
using System.Threading.Tasks;

namespace AGL_People_Service_Consumer.controller
{
    public class DataRetreiver : IDataRetreiver
    {
        private HttpClient client = new HttpClient();
        async public Task<string> GetData(string url)
        {
            Task<string> getPeopleData = client.GetStringAsync(url);
            string peopleData = await getPeopleData;
            return peopleData;
        }
    }
}
