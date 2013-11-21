using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace TaxiOrNot.RestApi.Controllers
{
    public class InitController:BaseApiController
    {
        public string Get()
        {
            return this.ExecuteOperationAndHandleException(() =>
            {
                return "Server is up and running!";
            });
        }
    }
}