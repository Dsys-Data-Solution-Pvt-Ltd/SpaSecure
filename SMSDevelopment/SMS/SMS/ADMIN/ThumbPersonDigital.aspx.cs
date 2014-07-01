using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

using log4net;
using log4net.Config;
using System.Data.SqlClient;
using System.Collections.Generic;
using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.Services.DataService;
using SMS.SMSAppUtilities;
using SMS.BusinessEntities;
using System.Text.RegularExpressions;
using DPFP;
using DPFP.Verification;
using System.Globalization;


namespace SMS.ADMIN
{
    public partial class ThumbPersonDigital : System.Web.UI.Page
    {

        DataAccessLayer dal = new DataAccessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["ManagementRole"] = "Controller";
            if (!IsPostBack)
            {
                if (HttpContext.Current.Session["SESSION_LOGIN_USER"] == null)
                {
                    Response.Redirect("~/master/login3.aspx");
                }

                if (Session["ManagementRole"].ToString().ToLower() == "superuser")
                {
                    getLocationName();
                }
                else
                {
                    getLocationNameById(Session["LCID"].ToString());
                }
            }
        }

        private void getLocationIDByName(string Name)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Location_name", Name);
            DataTable dsLocationID = dal.executeprocedure("sp_GetLocationIDbyName", para, false);
            if (dsLocationID.Rows.Count > 0)
            {
                SearchLocID.Text = dsLocationID.Rows[0][0].ToString().Trim();
            }
        }

        private void getLocationName()
        {
            ddllocation.Items.Clear();
            ddllocation.Items.Add("");
            SqlParameter[] para = new SqlParameter[0];
            DataTable dsLocation = dal.executeprocedure("sp_FillLocationName", para, false);
            if (dsLocation.Rows.Count > 0)
            {
                for (int k = 0; k < dsLocation.Rows.Count; k++)
                {
                    ddllocation.Items.Add(dsLocation.Rows[k][0].ToString().Trim());
                }
            }
        }

        private void getLocationNameById(string Name)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Location_id", Name);
            DataTable dsLocationName = dal.executeprocedure("sp_getLocationNameByID", para, false);
            if (dsLocationName.Rows.Count > 0)
            {
                ddllocation.Items.Add(dsLocationName.Rows[0][0].ToString().Trim());
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
            try
            {
                Verification.Verify(FeatureSet, TemplateLeftIndex, ref Result);
                if (Result.Verified)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
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
        protected void btnThumbCheckIn_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            bool success = false;
            //try
            //{
                Template template1 = new Template();
                FeatureSet featureSet = new FeatureSet();
                SqlParameter[] para = new SqlParameter[1];

                if (ddllocation.Text.Trim() != "")
                {
                    //para[0] = new SqlParameter("@Role", Session["user_role"].ToString());
                    para[0] = new SqlParameter("Staff_ID", Session["StaffID"].ToString());
                    DataTable dt = dal.executeprocedure("usp_GetRoleThumbPrints", para, false);

                    foreach (DataRow dr in dt.Rows)
                    {
                        template1 = new DPFP.Template();
                        template1.DeSerialize((byte[])dr["ThumbImage"]);

                        featureSet = new DPFP.FeatureSet();
                        featureSet.DeSerialize(HexsToArray(hdnFP.Value));
                        if (VerifyFingerprints(template1, featureSet))
                        {
                            string ipaddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
                            string staffid = dt.Rows[0]["Staff_ID"].ToString();
                            getLocationIDByName(ddllocation.Text.Trim());
                            int locid = Convert.ToInt32(SearchLocID.Text);


                            SqlParameter[] para1 = new SqlParameter[5];
                            para1[0] = new SqlParameter("@UserID", staffid);
                            para1[1] = new SqlParameter("@IPAddress", ipaddress);
                            para1[2] = new SqlParameter("@Location_ID", locid);
                            para1[3] = new SqlParameter("@Logintime", DateTime.Now);
                            para1[4] = new SqlParameter("@Fromdate", DateTime.Now);
                            dal.executeprocedure("SP_AddThumbStoreInfo", para1);

                            Response.Redirect("~/ADMIN/ThumbAfter.aspx");

                        }
                        success = true;
                    }
                }
                else
                {
                    lblerror.Visible = true;
                    lblerror.Text = "Please Select The Location";
                }
                if (!success)
                {
                    if (!(lblerror.Text.ToLower().Contains("already")))
                    {
                        lblerror.Text = "Invalid Thumbprint. Please Put Correct Finger.";
                        lblerror.Visible = true;
                    }
                }
         
        }


    }
}
