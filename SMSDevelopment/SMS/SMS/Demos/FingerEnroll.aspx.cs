using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

namespace SMS.Demos
{
    public partial class FingerEnroll : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (hdnFP.Value != "")
            {
                // Attempt to insert the information into the database.
                //SqlDataSource1.Insert();

                // Handle a successful registration.
                Response.Redirect("Success.aspx");
            }
        }

        protected void SqlDataSource1_Inserting(object sender, SqlDataSourceCommandEventArgs e)
        {
            e.Command.Parameters["@Template1"].Value = HexsToArray(hdnFP.Value);
        }

        public byte[] HexsToArray(string sHexString)
        {
            byte[] ra = new byte[sHexString.Length / 2];
            for (Int32 i = 0; i <= sHexString.Length - 1; i += 2)
            {
                ra[i / 2] = byte.Parse(sHexString.Substring(i, 2), NumberStyles.HexNumber);
            }
            return ra;
        }
    }
}
