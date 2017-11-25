using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Assignment_5.Managers;
using EncryptionLibrary;

namespace Assignment_5
{
    public partial class TryItEncryption : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEncrypt_Click(object sender, EventArgs e)
        {
            string text;
            if (Utility.TryParseText(txtEncrpytIn, out text))
            {
                lblEncrypted.Text = EncDec.Encrypt(text);
            }
            else
            {
                lblEncrypted.Text = "Please enter a value to encrypt";
            }
            
        }

        protected void btnDecrpyt_Click(object sender, EventArgs e)
        {
            string text;
            if (Utility.TryParseText(txtDecryptIn, out text))
            {
                lblDecrypted.Text = EncDec.Decrypt(text);
            }
            else
            {
                lblDecrypted.Text = "Please enter a value to decrypt";
            }
        }
    }
}