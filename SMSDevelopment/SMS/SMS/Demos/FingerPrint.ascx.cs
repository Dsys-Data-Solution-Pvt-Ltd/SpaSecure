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
using DPFP;
using DPFP.Verification;
using System.Globalization;

namespace SMS.Demos
{
    public partial class FingerPrint1 : System.Web.UI.UserControl
    {
        protected string _buttonValue;
        public string ButtonValue
        {
            get { return _buttonValue; }
            set { _buttonValue = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            DataView DataView = null;
            string savedPassword = null;
            string enteredPassword = null;
            Template template1 = new Template();
            Template template2 = new Template();
            FeatureSet featureSet = new FeatureSet();

            try
            {
                RequiredFieldValidator1.ErrorMessage = "Name is required.";

                // Handle only when fingerprints have been passed in on a postback and the page is valid.

                if (Page.IsPostBack && TextBox1.Text != string.Empty && HiddenField1.Value != string.Empty)
                {
                    // Registration handler.

                    if (Request.Url.AbsolutePath.Contains("Register.aspx"))
                    {
                        // Attempt to insert the information into the database.
                        SqlDataSource1.Insert();

                        // Handle a successful registration.
                        Response.Redirect("Success.aspx");

                        // Login handler.

                    }
                    else if (Request.Url.AbsolutePath.Contains("Login.aspx"))
                    {
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

                            template2 = new DPFP.Template();
                            template2.DeSerialize((byte[])DataView.Table.Rows[0]["Template2"]);

                            featureSet = new DPFP.FeatureSet();
                            featureSet.DeSerialize(HexsToArray(this.HiddenField1.Value));

                            // Verify data and return a message.
                            if (VerifyFingerprints(template1, template2, featureSet))
                            {

                                if (VerifyPassword(savedPassword, enteredPassword) || enteredPassword.Equals(string.Empty))
                                {
                                    // Handle a successful login.
                                    Response.Redirect("./Success.aspx");

                                    return;
                                }
                            }
                        }

                        this.Label3.Text = "Login Failed.  Either your password is invalid, or your fingerprints to not match.  Please try again.";

                        RequiredFieldValidator1.ErrorMessage = string.Empty;
                    }
                }
                else
                {
                    this.Label3.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Violation of PRIMARY KEY constraint"))
                {
                    this.Label3.Text = "Name is already registered.  Please choose another name.";
                }
                else
                {
                    this.Label3.Text = "Handled System Error :::: " + ex.Message + " :::: " + ex.StackTrace;
                }
            }
            finally
            {
                // Clear the form.
                Clear();
            }
        }

        private void SqlDataSource1_Inserting1(object sender, System.Web.UI.WebControls.SqlDataSourceCommandEventArgs e)
        {
            e.Command.Parameters["@Template1"].Value = HexsToArray(this.HiddenField1.Value);
            e.Command.Parameters["@Template2"].Value = HexsToArray(this.HiddenField2.Value);
        }

        private bool VerifyPassword(string actualPassword, string checkPassword)
        {
            return (actualPassword.Equals(checkPassword) ? true : false);
        }

        private bool VerifyFingerprints(DPFP.Template TemplateLeftIndex, DPFP.Template TemplateRightIndex, DPFP.FeatureSet FeatureSet)
        {
            Verification.Result Result = new Verification.Result();
            Verification Verification = new Verification();

            // Verify the left index finger.
            Verification.Verify(FeatureSet, TemplateLeftIndex,ref Result);
            if (Result.Verified)
            {
                return true;
            }

            // Verify the right index finger.
            Verification.Verify(FeatureSet, TemplateRightIndex,ref Result);
            if (Result.Verified)
            {
                return true;
            }

            // No match occurred.
            return false;
        }

        /// <summary>
        /// Format a hex string into a byte array.
        /// </summary>
        public byte[] HexsToArray(string sHexString)
        {
            byte[] ra = new byte[sHexString.Length / 2];
            for (Int32 i = 0; i <= sHexString.Length - 1; i += 2)
            {
                ra[i / 2] = byte.Parse(sHexString.Substring(i, 2), NumberStyles.HexNumber);
            }
            return ra;
        }

        public void Clear()
        {
            this.TextBox1.Text = string.Empty;
            this.TextBox2.Text = string.Empty;
            this.HiddenField1.Value = string.Empty;
            this.HiddenField2.Value = string.Empty;
        }
    }
}