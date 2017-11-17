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
                mUsername.Text = cookies["Name"];
                aUsername.Text = cookies["Name"];
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
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        // Login as an Admin
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        // Register Account Button

    }
}