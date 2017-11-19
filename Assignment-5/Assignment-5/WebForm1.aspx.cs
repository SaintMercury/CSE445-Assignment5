using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Assignment_5.Models;
using EncryptionLibrary;

namespace Assignment_5
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var credManager = new CredentialsManager();
            string userName = "TA";
            string password = "Cse445ta!";
            HttpCookie authCookie = credManager.LoginStaff(userName, password);
            string id = EncDec.Encrypt(userName + password);

            bool isLoggedIn = credManager.IsLoggedIn(authCookie, id);
            Console.WriteLine("is logged in: " + isLoggedIn);
        }
    }
}