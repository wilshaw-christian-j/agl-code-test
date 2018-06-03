using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AGL_People_Service_Consumer.controller
{
    public interface IDataRetreiver
    {
      Task<string> GetData(string endpoint);
    }
}
