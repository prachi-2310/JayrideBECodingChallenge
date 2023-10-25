using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JayrideBECodingChallenge.Models
{
    public class ListingsClass
    {
        public string from { get; set; }
        public string to { get; set; }
        public List<listings> listings { get; set; }
    }

    public class listings
    {
        public string name { get; set; }
        public decimal pricePerPassenger { get; set; }
        public int totalPassengers { get; set; }
        public decimal totalPrice { get; set; }
        public vehicleType vehicleType { get; set; }
    }

    public class vehicleType
    {
        public string name { get; set; }
        public int maxPassengers { get; set; }
    }
}