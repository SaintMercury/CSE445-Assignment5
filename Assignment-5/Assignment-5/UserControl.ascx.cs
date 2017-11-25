using System;

namespace Assignment_5
{
    public partial class UserControlCpy : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Date.Text = DateTime.Today.ToLongDateString();
        }
    }
}