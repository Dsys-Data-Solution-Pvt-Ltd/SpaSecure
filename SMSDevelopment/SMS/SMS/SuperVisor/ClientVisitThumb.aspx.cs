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

namespace SMS.SuperVisor
{
    public partial class ClientVisitThumb : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {

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
            try
            {
                Template template1 = new Template();
                FeatureSet featureSet = new FeatureSet();

                SqlParameter[] para = new SqlParameter[1];

               // para[0] = new SqlParameter("@Role", txtrole.Text);
                DataTable dt = dal.executeprocedure("usp_GetRoleThumbPrints", para, false);

                foreach (DataRow dr in dt.Rows)
                {
                    template1 = new DPFP.Template();
                    template1.DeSerialize((byte[])dr["ThumbImage"]);

                    featureSet = new DPFP.FeatureSet();
                    featureSet.DeSerialize(HexsToArray(hdnFP.Value));
                    if (VerifyFingerprints(template1, featureSet))
                    {
                        DataTable dtcheckin = dal.getdata("select checkin_id from checkin_manager where UserID = '" + dr["Staff_ID"].ToString() + "' ");
                        if (dtcheckin.Rows.Count > 0)
                        {
                            DataTable dtcheckout = dal.getdata("select checkout_id from checkout_manager where checkin_id = '" + dtcheckin.Rows[0][0].ToString() + "' ");
                            if (dtcheckout.Rows.Count == 0)
                            {
                                lblerror.Visible = true;
                                lblerror.Text = "Security Officer is Already Checked in.Please Contact Your SuperVisor..!";
                               // lblerr1.Visible = true;
                                throw new Exception();
                            }
                        }
                        AddNewCheckInRequest objAddCheckinRequest = new AddNewCheckInRequest();
                        checkin objchickin = new checkin();
                        objchickin.telephone = dr["Phone"].ToString();
                        objchickin.UserID = dr["Staff_ID"].ToString();
                       // objchickin.Role = txtrole.Text;
                        objchickin.user_name = dr["FirstName"].ToString();
                        objchickin.Checkin_DateTime = DateTime.Now;
                        objchickin.NRICno = dr["NRICno"].ToString();
                        if (Session["LCID"] != null && Session["LCID"].ToString() != "0")
                        {
                            objchickin.LocationID = int.Parse(Session["LCID"].ToString());
                        }
                        AdminBLL ws = new AdminBLL();
                        ws.AddCheckinGaurd(objchickin);
                        tblThumbInfo.Style.Add(HtmlTextWriterStyle.Display, "");
                        lblFin.Text = dr["NRICno"].ToString();
                        lblName.Text = dr["FirstName"].ToString();
                        lblPhone.Text = dr["Phone"].ToString();
                        if (dr["ImagePathName"] != null && dr["ImagePathName"].ToString() != "")
                        {
                            UserImage.ImageUrl = dr["ImagePathName"].ToString();
                            UserImage.Visible = true;
                        }
                        else
                        {
                            UserImage.Visible = false;
                        }
                        success = true;
                        tblThumbInfo.Style.Add(HtmlTextWriterStyle.Display, "block");
                        break;
                        HttpContext.Current.Items.Add("COMPLETE", "INSERT");
                    }
                }
                if (!success)
                {
                    if (!(lblerror.Text.ToLower().Contains("already")))
                    {
                        lblerror.Text = "Invalid Thumbprint. Please Put Correct Finger.";
                        lblerror.Visible = true;
                    }
                }
                else
                {
                    lblerror.Text = "You Have Successfully Checked In";
                    lblerror.Visible = true;
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
                if (!(lblerror.Text.ToLower().Contains("already")))
                {
                    lblerror.Text = "Error Has Occured. Please Thumbprint Again.";
                }
                lblerror.Visible = true;
            }
        }
        protected void btnContinue_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SMSAdmin/AlertUpdateComplete.aspx");
        }

    }
}
