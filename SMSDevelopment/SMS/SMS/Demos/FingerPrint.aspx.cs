using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using DPFP;
using DPFP.Verification;
using System.Globalization;

namespace SMS.Demos
{
    public partial class FingerPrint : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataView DataView = null;
            string savedPassword = null;
            string enteredPassword = null;
            Template template1 = new Template();
            FeatureSet featureSet = new FeatureSet();

            // Attempt to select information from the database using name as a parameter (via asp.net).
            DataView = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);

            // Check if a record exists.

            if (DataView != null && !DataView.Table.Rows.Count.Equals(0))
            {
                // Get data from the form and the returned recordset.
                savedPassword = (object.ReferenceEquals(DataView.Table.Rows[0]["Password"].GetType(), typeof(DBNull)) ? string.Empty : DataView.Table.Rows[0]["Password"].ToString().Trim());
                enteredPassword = TextBox2.Text;

                template1 = new DPFP.Template();
                template1.DeSerialize((byte[])DataView.Table.Rows[0]["Template1"]);

                featureSet = new DPFP.FeatureSet();
                featureSet.DeSerialize(HexsToArray(hdnFP.Value));

                // Verify data and return a message.
                if (VerifyFingerprints(template1, featureSet))
                {

                    if (VerifyPassword(savedPassword, enteredPassword) || enteredPassword.Equals(string.Empty))
                    {
                        // Handle a successful login.
                        Response.Redirect("./Success.aspx");

                        return;
                    }
                }
            }
        }

        private bool VerifyPassword(string actualPassword, string checkPassword)
        {
            return (actualPassword.Equals(checkPassword) ? true : false);
        }

        private bool VerifyFingerprints(DPFP.Template TemplateLeftIndex, DPFP.FeatureSet FeatureSet)
        {
            Verification.Result Result = new Verification.Result();
            Verification Verification = new Verification();

            // Verify the left index finger.
            Verification.Verify(FeatureSet, TemplateLeftIndex, ref Result);
            if (Result.Verified)
            {
                return true;
            }

            // No match occurred.
            return false;
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
