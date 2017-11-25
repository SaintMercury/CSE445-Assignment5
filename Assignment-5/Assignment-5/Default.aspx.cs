using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_5
{
    public partial class DefaultCpy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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