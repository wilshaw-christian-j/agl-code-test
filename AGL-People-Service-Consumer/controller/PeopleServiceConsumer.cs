
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using AGL_People_Service_Consumer.model;

namespace AGL_People_Service_Consumer.controller
{
    public class PeopleServiceConsumer : IServiceConsumer
    {
        private String _endpoint;
        private IDataRetreiver _dataRetreiver;
        public PeopleServiceConsumer(String endpoint,IDataRetreiver dataRetreiver)
        {
            if (String.IsNullOrEmpty(endpoint))
            {
                throw new Exception("Enpoint Address must not be empty.");
            }

            this._endpoint = endpoint;
            this._dataRetreiver = dataRetreiver ?? throw new Exception("DataRetreiver must be provided.");
        }

        public async Task<List<Person>> GetAllPeople()
        {
            String peopleData = await GetPeopleData(_endpoint);
            return ParseData(peopleData);
        }
        protected async Task<String> GetPeopleData(String url)
        {
            var peopleApiResponse = await _dataRetreiver.GetData(url);
            return peopleApiResponse;
        }
        protected List<Person> ParseData(String jsonData)
        {
            List<Person> people = JsonConvert.DeserializeObject<List<Person>>(jsonData);
            return people;
        }
    }
}
