using System;
using Assignment_5.Managers;

namespace Assignment_5.TryItPages
{
    public partial class TryItXml : System.Web.UI.Page
    {
        private CredentialsManager m_CredsManager;
        private XmlAccessObject m_XmlAccess;
        protected void Page_Load(object sender, EventArgs e)
        {
            m_CredsManager = new CredentialsManager();
            m_XmlAccess = new XmlAccessObject();
            
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
                    m_CredsManager.RegisterMember(uname, pw1);
                    txtUserName.Text = null;
                    txtPW1.Text = null;
                    txtPW2.Text = null;
                    lblError.Text = "Successfully created member with encrpyted credentials.";
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
                    m_CredsManager.RegisterStaff(uname, pw1);
                    txtUserName.Text = null;
                    txtPW1.Text = null;
                    txtPW2.Text = null;
                    lblError.Text = "Successfully created Staff with encrypted credentials";
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

        protected void btnWriteMember_Click(object sender, EventArgs e)
        {
            string uname, pw1, pw2;
            if (Utility.TryParseText(txtUserName, out uname)
                && Utility.TryParseText(txtPW1, out pw1)
                && Utility.TryParseText(txtPW2, out pw2))
            {

                if (pw1 == pw2)
                {
                    m_XmlAccess.RegisterMember(uname,pw1);
                    txtUserName.Text = null;
                    txtPW1.Text = null;
                    txtPW2.Text = null;
                    lblError.Text = "Successfully wrote to Member.xml";
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

        protected void btnWriteStaff_Click(object sender, EventArgs e)
        {
            string uname, pw1, pw2;
            if (Utility.TryParseText(txtUserName, out uname)
                && Utility.TryParseText(txtPW1, out pw1)
                && Utility.TryParseText(txtPW2, out pw2))
            {
                if (pw1 == pw2)
                {
                    m_XmlAccess.RegisterStaff(uname, pw1);
                    txtUserName.Text = null;
                    txtPW1.Text = null;
                    txtPW2.Text = null;
                    lblError.Text = "Successfully wrote to Staff.xml";
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

        protected void btnAuthStaff_Click(object sender, EventArgs e)
        {
            string uname, pw1;
            if (Utility.TryParseText(txtUserName, out uname)
                && Utility.TryParseText(txtPW1, out pw1))
            {
                if(m_CredsManager.AuthenticateStaff(uname, pw1))
                {
                    lblAuthSucc.Text = "Successful Authentication";
                }
                else
                {
                    lblAuthSucc.Text = "Failed to authenticate";
                }
            }
            else
            {
                lblAuthSucc.Text = "Please ensure all fields have values";
            }
        }

        protected void btnAuthMember_Click(object sender, EventArgs e)
        {
            string uname, pw1;
            if (Utility.TryParseText(txtUserName, out uname)
                && Utility.TryParseText(txtPW1, out pw1))
            {
                if (m_CredsManager.AuthenticateMember(uname, pw1))
                {
                    lblAuthSucc.Text = "Successful Authentication";
                }
                else
                {
                    lblAuthSucc.Text = "Failed to authenticate";
                }
            }
            else
            {
                lblAuthSucc.Text = "Please ensure all fields have values";
            }
        }
    }
}