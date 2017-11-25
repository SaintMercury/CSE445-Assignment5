using System;
using Assignment_5.Managers;

namespace Assignment_5
{
    public partial class Register : System.Web.UI.Page
    {
        private CredentialsManager m_CredsManager;

        protected void Page_Load(object sender, EventArgs e)
        {
            m_CredsManager = new CredentialsManager();
        }

        protected void btnRegisterMember_Click(object sender, EventArgs e)
        {
            string uname, pw1, pw2;
            if (Utility.TryParseText(txtUserName, out uname)
                && Utility.TryParseText(txtPW1, out pw1)
                && Utility.TryParseText(txtPW2, out pw2))
            {

                if (pw1 == pw2)
                {
                    if (m_CredsManager.RegisterMember(uname, pw1))
                    {
                        lblError.Text = "Successfully created member. Proceed to login page.";
                        txtUserName.Text = null;
                    }
                    else
                    {
                        lblError.Text = "Username already exists";
                    }
                    
                    txtPW1.Text = null;
                    txtPW2.Text = null;
                    
                }
                else
                {
                    lblError.Text = "Password mismatch";
                }
            }
            else
            {
                lblError.Text = "Please ensure all fields have been values";
            }
        }

        protected void btnRegisterStaff_Click(object sender, EventArgs e)
        {
            string uname, pw1, pw2;
            if (Utility.TryParseText(txtUserName, out uname)
                && Utility.TryParseText(txtPW1, out pw1)
                && Utility.TryParseText(txtPW2, out pw2))
            {
                if (pw1 == pw2)
                {
                    if (m_CredsManager.RegisterMember(uname, pw1))
                    {
                        lblError.Text = "Successfully created Staff. See instructions below and proceed to login page.";

                        txtUserName.Text = null;
                    }
                    else
                    {
                        lblError.Text = "Successfully created Staff. See instructions below and proceed to login page.";
                    }

                    txtPW1.Text = null;
                    txtPW2.Text = null;
                    
                }
                else
                {
                    lblError.Text = "Password mismatch";
                }
            }
            else
            {
                lblError.Text = "Please ensure all fields have values";
            }
        }
    }
}