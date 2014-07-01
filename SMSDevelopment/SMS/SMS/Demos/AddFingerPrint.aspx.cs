using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SMS.Services.DataService;
using System.Globalization;
using System.Data.SqlClient;

namespace SMS.Demos
{
    public partial class AddFingerPrint : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (hdnFP.Value != "")
            {
                DataAccessLayer dal = new DataAccessLayer();
                byte[] finger = HexsToArray(hdnFP.Value);
                SqlParameter[] para = new SqlParameter[2];
                para[0] = new SqlParameter("@Finger", finger);
                para[1] = new SqlParameter("@NRIC", txtNRIC.Text);
                dal.executeprocedure("usp_UpdateFingerPrint", para);
            }
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
