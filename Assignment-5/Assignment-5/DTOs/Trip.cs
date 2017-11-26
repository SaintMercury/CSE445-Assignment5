using System;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Assignment_5.DTOs
{
    public class Trip
    {
        public string FromAddress { get; set; }
        public string DestAddress { get; set; }
        public double DistanceInMiles { get; set; }
        public double DistanceInKm { get; set; }

        public Trip(string fromAddress, string destAddress)
        {
            FromAddress = fromAddress.Trim();
            DestAddress = destAddress.Trim();
        }

        public Trip(string fromAddress, string destAddress, double distanceInMiles)
        {
            FromAddress = fromAddress;
            DestAddress = destAddress;
            DistanceInMiles = distanceInMiles;
        }

        public bool SetDistance(string serializedDistance)
        {
            bool setSuccessfully = false;
            if (serializedDistance != null)
            {
                JObject jObj = JObject.Parse(serializedDistance);
                DistanceInMiles = Double.Parse(jObj["Miles"].ToString());
                DistanceInKm = Double.Parse(jObj["Kilometers"].ToString());
                setSuccessfully = true;
            }

            return setSuccessfully;
        }
    }
}