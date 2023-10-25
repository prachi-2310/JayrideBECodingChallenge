using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JayrideBECodingChallenge.Models;

namespace JayrideBECodingChallenge.Controllers
{
    public class ListingsController : ApiController
    {
        public object Get(int passengers)
        {
            string base_url = "https://jayridechallengeapi.azurewebsites.net/api/QuoteRequest";

            RestClient client = new RestClient(base_url);
            var request = new RestRequest("", Method.Get);
            var response = client.Execute(request);

            ListingsClass listingsClass = JsonConvert.DeserializeObject<ListingsClass>(response.Content);

            //Check condition for number of passengers
            listingsClass.listings = listingsClass.listings.Where(a => passengers == a.vehicleType.maxPassengers).ToList();

            if (listingsClass.listings.Count != 0)
            {
                //Calculate Total Price
                foreach (listings list in listingsClass.listings)
                {
                    list.totalPassengers = passengers;
                    list.totalPrice = Math.Round(passengers * list.pricePerPassenger, 2);
                }

                //Sort by Total Price
                listingsClass.listings = listingsClass.listings.OrderBy(a => a.totalPrice).ToList();

                return listingsClass;
            }
            else
            {
                return "Sorry!! No vehicle found for " + passengers + " passengers";
            }
        }
    }
}
