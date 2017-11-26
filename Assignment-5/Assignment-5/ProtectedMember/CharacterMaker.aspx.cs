using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Assignment_5.Assign3ServicesMax;

namespace Assignment_5.ProtectedMember
{
    public partial class CharacterMaker : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void makeCharacter(object sender, EventArgs e)
        {
            IService service = new ServiceClient();
            string str = service.getChar(this.inputName.Text);
            str = str.Replace("\\n", "\n");
            str = str.Replace("\\t", "\t");
            this.outputBox.Text = str;
        }
    }
}