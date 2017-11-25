using System;
using System.Web.Security;

namespace Assignment_5.ProtectedStaff
{
    public partial class StaffCpy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();

            Response.Redirect("../Login.aspx");
        }
    }
}