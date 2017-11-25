using System;
using System.Web.Security;
using Assignment_5.Managers;

// Ta credentials
//string uname = "TA";
//string password = "Cse445ta!";

namespace Assignment_5
{
    public partial class Login : System.Web.UI.Page
    {
        private CredentialsManager m_CredsManager;
        protected void Page_Load(object sender, EventArgs e)
        {
            m_CredsManager = new CredentialsManager();
            
        }

        // Member login
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string userName, password;

            // make sure username, password fields have values
            if (Utility.TryParseText(txtUserName, out userName) 
                && Utility.TryParseText(txtPassword, out password))
            {
                // If we successfully authenticate, we get back a unique id, else id will be null
                string id = m_CredsManager.TryLoginMember(userName, password);
                if (!string.IsNullOrEmpty(id))
                {
                    // Use our retrieved ID to set auth cookie
                    FormsAuthentication.SetAuthCookie(id, true);
                    
                    // Any page loads from the "ProtectedMember" directory 
                    // will look for an auth cookie, but id is arbitrary
                    Response.Redirect("ProtectedMember/Member.aspx");
                }
            }

            lblOutput.Text = "Invalid login";
        }

        // Staff login
        // Logic similar to member login except here the username is important
        // Member pages look for authenticated users with no particular id on auth cookie
        // Staff pages look for auth cookies that have ad id that matches one
        // been specified in ProtectedStaff/Web.config
        protected void btnLoginAsStaff_Click(object sender, EventArgs e)
        {
            string userName, password;
            if (Utility.TryParseText(txtUserName, out userName)
                && Utility.TryParseText(txtPassword, out password))
            {
                string id = m_CredsManager.TryLoginStaff(userName, password);
                if (!string.IsNullOrEmpty(id))
                {
                    // Only users who have their usernames specified in plain text
                    // at "~/ProtectedStaff/Web.config
                    // will be able to access any pages in the "ProtectedStaff" directory
                    FormsAuthentication.SetAuthCookie(txtUserName.Text, true);
                    Response.Redirect("ProtectedStaff/Staff.aspx");
                }
            }
            lblOutput.Text = "Invalid login";
        }


        // Destroy our auth cookie and redirect
        protected void btnLogout_Click1(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();

            Response.Redirect("Login.aspx");
        }

        
    }
}