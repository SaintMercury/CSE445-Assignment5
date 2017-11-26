using System;
using System.Web;
using Assignment_5.Assign3ServicesMax;

namespace Assignment_5
{
    public partial class DefaultCpy : System.Web.UI.Page
    {
        private ServiceClient m_svcClient;
        protected void Page_Load(object sender, EventArgs e)
        {
            m_svcClient = new ServiceClient();
            string[] arr = new[] {"Trump", "Twitter"};
            var resp = m_svcClient.newsFocus(arr);
            Console.WriteLine(resp);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            // Login as a member
            // Verify stuff

            // Cookie storage
            HttpCookie cookies = new HttpCookie("CSE445-Assignment5-Group16");
            cookies["mName"] = mUsername.Text;
            cookies.Expires = DateTime.Now.AddMonths(1);
            Response.Cookies.Add(cookies);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            // Login as an Admin
            // Verify Stuff

            // Cookie storage
            HttpCookie cookies = new HttpCookie("CSE445-Assignment5-Group16");
            cookies["aName"] = mUsername.Text;
            cookies.Expires = DateTime.Now.AddMonths(1);
            Response.Cookies.Add(cookies);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            // Register Account Button
            Response.Redirect("Register.aspx");
        }
    }
}