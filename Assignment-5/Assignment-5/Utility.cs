using System.Web.UI.WebControls;

namespace Assignment_5
{
    public static class Utility
    {

        public static bool TryParseText(TextBox txtBox, out string extracted)
        {
            bool isNotEmpty = false;
            extracted = txtBox.Text;

            if (!string.IsNullOrEmpty(extracted))
            {
                extracted = extracted.Trim();
                isNotEmpty = true;
            }

            return isNotEmpty;
        }
    }
}