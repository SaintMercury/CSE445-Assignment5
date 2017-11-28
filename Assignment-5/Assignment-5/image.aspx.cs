using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Assignment_5.ImageVerifierService;
using System.Drawing;
using System.Drawing.Imaging;

namespace Assignment_5
{
    public partial class image : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Clear();
            IService svc = new ServiceClient();
            string str, length;
            if(Session["generatedString"] == null)
            {
                if (Session["userLength"] == null)
                    length = "3";
                else
                    length = Session["userLength"].ToString();
                str = svc.GetVerifierString(length);
                Session["generatedString"] = str;
            }
            else
            {
                str = Session["generatedString"].ToString();
            }
            var stream = svc.GetImage(str);
            var image = System.Drawing.Image.FromStream(stream);
            Response.ContentType = "image/jpeg";
            image.Save(Response.OutputStream, ImageFormat.Jpeg);
        }
    }
}