using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using JayrideBECodingChallenge.Models;
using Newtonsoft.Json;
using RestSharp;
using Swashbuckle.Swagger;

namespace JayrideBECodingChallenge.Controllers
{
    public class LocationController : ApiController
    {
        public string Get()
        {
            string IPStackAPIKey = ConfigurationManager.AppSettings["IPStackAPIKey"].ToString();
            string IP_Address = HttpContext.Current.Request.UserHostAddress;
            string base_url = "http://api.ipstack.com/";

            RestClient client = new RestClient(base_url);
            var request = new RestRequest(IP_Address, Method.Get).AddParameter("access_key", IPStackAPIKey);
            var response = client.Execute(request);

            var obj = JsonConvert.DeserializeObject<dynamic>(response.Content);
            string city = obj.city;

            return "Current City: " + city;
        }
    }
}
