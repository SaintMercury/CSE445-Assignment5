using System;
using Assignment_5.MyService;

namespace Assignment_5
{
    public partial class TryItGoogleServices : System.Web.UI.Page
    {
        private MyServiceClient m_ServiceClient;

        protected void Page_Load(object sender, EventArgs e)
        {
            m_ServiceClient = new MyServiceClient();
        }

        protected void btnGet_Coordinates_Click(object sender, EventArgs e)
        {
            string address = txtAddress.Text.Trim();
            if (!string.IsNullOrEmpty(address))
            {
                string location = m_ServiceClient.GetCoordinates(address);
                lblLocation.Text += location + "\n";
            }
            else
            {
                lblLocation.Text = "Please enter an address.";
            }
        }

        protected void btnGet_Distance_Click(object sender, EventArgs e)
        {
            double lat1, lng1, lat2, lng2;
            bool parsed;

            string lat1Str = txtLat1.Text.Trim();
            parsed = double.TryParse(lat1Str, out lat1);

            lblDistance.Text = "Please enter valid, decimal coordinates.";

            // Continue to parse values until failure
            if (parsed)
            {
                string lng1Str = txtLng1.Text.Trim();
                parsed = double.TryParse(lng1Str, out lng1);

                if (parsed)
                {
                    string lat2Str = txtLat2.Text.Trim();
                    parsed = double.TryParse(lat2Str, out lat2);

                    if (parsed)
                    {
                        string lng2Str = txtLng2.Text.Trim();
                        parsed = double.TryParse(lng2Str, out lng2);
                        if (parsed)
                        {
                            string distance = m_ServiceClient.GetDistanceByCoordinates(lat1, lng1, lat2, lng2);

                            lblDistance.Text = distance;
                        }
                    }
                }
            }
        }

        protected void btnGet_Distance_By_Address_Click(object sender, EventArgs e)
        {
            string address1 = txtAddress1.Text.Trim();
            string address2 = txtAddress2.Text.Trim();

            if (!string.IsNullOrEmpty(address1) && !string.IsNullOrEmpty(address2))
            {
                string distance = m_ServiceClient.GetDistanceByAddress(address1, address2);
                lblDistBetweenAddr.Text += distance + "\n";
            }
            else
            {
                lblDistBetweenAddr.Text = "Please enter 2 valid addresses.";
            }
        }
    }
}
