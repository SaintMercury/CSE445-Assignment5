using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            HttpCookie cookies = Request.Cookies["CSE445-Assignment5-Group16"];
            if( !(cookies == null || cookies["Name"] == ""))
            {
                mUsername.Text = cookies["mName"];
                aUsername.Text = cookies["aName"];
            }

            // Redirect if already logged in
            if(cookies["Logged-In"] == "true")
            {
                Response.Redirect("Member.aspx");
            }
        }
        catch(Exception ex)
        {
            //
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        // Login as a member
        // Verify stuff
        bool verifiedMember = true;

        // Cookie storage
        if(verifiedMember)
        {
            HttpCookie cookies = new HttpCookie("CSE445-Assignment5-Group16");
            cookies["mName"] = mUsername.Text;
            cookies.Expires = DateTime.Now.AddMonths(1);
            Response.Cookies.Add(cookies);
            Response.Redirect("Member.aspx");
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        // Login as an Admin
        // Verify Stuff
        bool verifiedStaff = true;

        // Cookie storage
        if (verifiedStaff)
        {
            HttpCookie cookies = new HttpCookie("CSE445-Assignment5-Group16");
            cookies["aName"] = mUsername.Text;
            cookies.Expires = DateTime.Now.AddMonths(1);
            Response.Cookies.Add(cookies);
            Response.Redirect("Staff.aspx");
        }
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        // Register Account Button
        Response.Redirect("Register.aspx");
    }
}