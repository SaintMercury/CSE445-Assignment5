using System.Runtime.Serialization.Json;
using Newtonsoft.Json;

namespace Assignment_5.DTOs
{
    public class Distance
    {
        public double Kilometers { get; set; }
        public double Miles { get; set; }

        public Distance(double meters)
        {
            Kilometers = meters / 1000;
            Miles = Kilometers * 0.6214;
        }

        public Distance(string serializedDist)
        {
            JsonConvert.DeserializeObject<Distance>(serializedDist);
        }
    }
}