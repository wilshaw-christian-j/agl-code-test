using System;
using AGL_People_Service_Consumer.controller;
using AGL_People_Service_Consumer.view;

namespace AGL_People_Service_Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            const string peopleEndPoint = "http://agl-developer-test.azurewebsites.net/people.json";
            IDataRetreiver dataRetreiver = new DataRetreiver();
            IServiceConsumer service = new PeopleServiceConsumer(peopleEndPoint, dataRetreiver);
            var peopleList = service.GetAllPeople();

            IView view = new ConsoleView();
            view.DisplayGroupedAndSortedPeopleData(peopleList);
        }
    }
}
