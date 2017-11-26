using System;
using System.Collections.Generic;
using Assignment_5.DTOs;
using Assignment_5.MyService;

namespace Assignment_5.ProtectedMember
{
    public partial class TripPlanner : System.Web.UI.Page
    {
        private MyServiceClient m_GeoService;
        private List<Trip> m_Trips;

        protected void Page_Load(object sender, EventArgs e)
        {
            // check to see if we've got trips in the session state
            if (Session["trips"] != null)
            {
                m_Trips = (List<Trip>)Session["trips"];
            }
        }

        protected void btnGet_Distance_By_Address_Click1(object sender, EventArgs e)
        {
            // use the form fields to generate a trip obj
            // if it goes successfully, we have something we can save to the session state
            Trip trip = CreateTrip();
            if (trip != null)
            {
                AppendTripToSessionState(trip);
            }
        }

        // get our text fields
        // calculate a distance using a service call
        // put it all in the trip and return it
        private Trip CreateTrip()
        {
            Trip retTrip = null;
            string startAddr, destAddr;
            if (Utility.TryParseText(txtStartAddress, out startAddr) && Utility.TryParseText(txtDestAddress, out destAddr))
            {
                retTrip = new Trip(startAddr, destAddr);
                string serializedDistance = CalculateDistance(retTrip);
                if ( !string.IsNullOrEmpty(serializedDistance) ) 
                {
                    retTrip.SetDistance(serializedDistance);
                }
            }

            return retTrip;
        }

        private string CalculateDistance(Trip trip)
        {
            // lazy load our service client
            if (m_GeoService == null)
            {
                m_GeoService = new MyServiceClient();
            }

            return m_GeoService.GetDistanceByAddress(trip.FromAddress, trip.DestAddress);
        }

        // Existing list is deserialized to member variable on page load
        // if no trips at save time, create a new one 
        private void AppendTripToSessionState(Trip trip)
        {
            if (m_Trips == null)
            {
                m_Trips = new List<Trip>();
            }

            m_Trips.Add(trip);

            // rewrite with new list
            Session["trips"] = m_Trips;
        }
    }
}
