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
using SMS.master;

namespace SMS.SMSUsers
{
    public partial class Check_In_Guard : System.Web.UI.Page
    {
        
        DataAccessLayer dal = new DataAccessLayer();
        AdminDAL a = new AdminDAL();
        AdminBLL b = new AdminBLL();
        String column = string.Empty;
        String table = string.Empty;
        String where = string.Empty;
        String where1 = string.Empty;
        string[] Month = new string[12]
        {
            "January","February","March","April","May","June","July","August","September","October","November","December"
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            lblerror.Text = "";
            txtNricID3.Focus();
            lblerror.Visible = false;
            lblerr1.Visible = false;
            lblerr2.Visible = false;
            

            //string role = Session["role"].ToString();

            if (Session["user_role"] != null)
            {
                string role = Session["user_role"].ToString();
                txtrole.Text = role;

                if (role == "Operations Manager" || role == "Supervisor" || role == "Controller" || role == "Security Officer")
                {
                    tblThumbInfo.Style.Add(HtmlTextWriterStyle.Display, "block");
                    manually.Visible = true;

                }
                else
                {
                    tblThumbInfo.Style.Add(HtmlTextWriterStyle.Display, "block");
                    manually.Visible = false;
                }
            }
        }

        private void BindGridStaff()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                AdminBLL ws = new AdminBLL();
                GetCheckinData _req = new GetCheckinData();
                GetChiekinDataResponse _resp = ws.Getcheckin(_req);

                int pageSize = ContextKeys.GRID_PAGE_SIZE;
                gvContractorTable.PageSize = pageSize;
                gvContractorTable.DataSource = _resp.checkinid;
                gvContractorTable.DataBind();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

        }
        private void BindGridWithFilterStaff()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                AdminBLL ws = new AdminBLL();
                GetCheckinData objReq = new GetCheckinData();
                string WhereClause = ReturnWhereContractor();

                if (!string.IsNullOrEmpty(txtNricID3.Text))
                {
                    objReq.NRICno = txtNricID3.Text;
                }
                if (!string.IsNullOrEmpty(txtName3.Text))
                {
                    objReq.user_name = txtName3.Text;
                }

                if (!string.IsNullOrEmpty(WhereClause))
                {
                    objReq.WhereClause = WhereClause;
                }

                GetChiekinDataResponse ret = ws.Getcheckin(objReq);
                int pageSize = ContextKeys.GRID_PAGE_SIZE;
                gvContractorTable.PageSize = pageSize;
                gvContractorTable.DataSource = ret.checkinid;
                gvContractorTable.DataBind();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        protected void gvContractorTable_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                }
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    gvContractorTable.Columns[0].FooterText = "Total Records: 20";
                }
            }

            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        protected void gvContractorTable_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (e.NewPageIndex >= 0)
                {
                    gvContractorTable.PageIndex = e.NewPageIndex;
                    BindGridWithFilterStaff();
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        protected void gvContractorTable_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private string ReturnWhereContractor()
        {
            string str = string.Empty;
            string makeWhereClause = string.Empty;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                List<String> arr = new List<String>();
                arr.Add("test");

                if (txtNricID3.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        makeWhereClause = " where ";
                        str += " where NRICno='" + txtNricID3.Text.Trim() + "' and Role='" + txtrole.Text.Trim() + "' and user_name='" + txtName3.Text.Trim() + "'";
                        arr.Add("1");
                    }
                    else
                    {
                        str += " and NRICno='" + txtNricID3.Text.Trim() + "' and Role='" + txtrole.Text.Trim() + "' and user_name='" + txtName3.Text.Trim() + "'";
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
            return (str);

        }

        
        protected void txtNricID3_TextChanged(object sender, EventArgs e)
        {
            SpaMaster SM = (SpaMaster)Page.Master;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (Session["user_role"].ToString() == "Operations Manager")
                {
                    txtrole.Text = "Security Officer";
                }
                SqlDataReader rd = dal.getDataReader("select Top 1 NRICno,FirstName,Staff_TelPhone,ImagePathName from UserInformation where NRICno='" + txtNricID3.Text + "' and Role='" + txtrole.Text + "'");
                if (rd.HasRows)
                {
                    if (rd.Read())
                    {
                        txtNricID3.Text = rd.GetValue(0).ToString();
                        txtName3.Text = rd.GetValue(1).ToString();
                        txtTeleNo3.Text = rd.GetValue(2).ToString();
                        Image3.ImageUrl = rd.GetValue(3).ToString();
                        //TextsecOff.Text = rd.GetValue(4).ToString();
                    }
                    rd.Close();
                    gvContractorTable.Visible = true;
                    BindGridWithFilterStaff();
                }
                else
                {
                    
                    //lblerror.Visible = true;
                    //lblerror.Text = "Invalid NRIC/FIN No. ..!";
                    //lblerr1.Visible = true;
                    SM.ShowErrorMessage("Invalid NRIC/FIN No. ..!");
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
            Page.ClientScript.RegisterStartupScript(this.GetType(), "MenuShow", "ShowManualPortion();", true);
        }


        #region other

        protected void btnscan_Click(object sender, EventArgs e)
        {
            Response.Redirect("CheckInScan.aspx");
        }


        protected void txtName3_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtTeleNo3_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtPassNo3_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtKeyNo3_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnprintthumb_Click(object sender, EventArgs e)
        {

        }

        #endregion

        protected void btncheckin_Click(object sender, EventArgs e)
        {
            SpaMaster SM = (SpaMaster)Page.Master;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (Session["user_role"].ToString() == "Supervisor" || Session["user_role"].ToString() == "Security Officer" || Session["user_role"].ToString() == "Operations Manager")
                {
                    AddNewCheckInRequest objAddCheckinRequest = new AddNewCheckInRequest();
                    checkin objchickin = new checkin();
                    string NRICNO = txtNricID3.Text.Trim();
                    //string ROLE = txtrole.Text.Trim();
                    string STAFFID = string.Empty;
                    if (Session["user_role"].ToString() == "Operations Manager")
                    {
                        txtrole.Text = "Security Officer";
                    }
                    SqlParameter[] para1 = new SqlParameter[2];
                    para1[0] = new SqlParameter("@NRICNO", SqlDbType.VarChar, 100);
                    para1[0].Value = NRICNO;
                    para1[1] = new SqlParameter("@ROLE", SqlDbType.VarChar, 100);
                    para1[1].Value = txtrole.Text;
                    DataTable dt = new DataTable();

                    
                    
                    dt = dal.executeprocedure("SP_GetStaffidbyNRICRole", para1, false);
                    objchickin.Role = txtrole.Text;
                  
                    if (dt.Rows.Count > 0)
                    {
                        STAFFID = dt.Rows[0]["Staff_ID"].ToString();
                        SqlParameter[] para = new SqlParameter[1];
                        para[0] = new SqlParameter("@UserID", SqlDbType.VarChar, 100);
                        para[0].Value = STAFFID;
                        DataTable dt1 = dal.executeprocedure("SP_GetCheckInIDbyUserid", para, false);
                        if (dt1.Rows.Count > 0)
                        {
                            long CHECKIN_ID = Convert.ToInt64(dt1.Rows[0]["checkin_id"].ToString());
                            SqlParameter[] para2 = new SqlParameter[1];
                            para2[0] = new SqlParameter("@checkin_id", SqlDbType.BigInt, 100);
                            para2[0].Value = CHECKIN_ID;
                            DataTable dt3 = dal.executeprocedure("SP_GetCheckoutIDbyCheckInID", para2, false);
                            if (dt3.Rows.Count == 0)
                            {
                                //lblerror.Visible = true;
                                //lblerror.Text = "NRIC/FIN No. Already Checked In ..!";
                                //lblerr1.Visible = true;
                                SM.ShowErrorMessage("NRIC/FIN No. Already Checked In ..!");
                                return;
                               // throw new Exception();
                            }
                        }
                    }
                    else
                    {
                        //lblerror.Visible = true;
                        //lblerror.Text = "No security officer with this NRIC/FIN No. exists in database !";
                        //lblerr1.Visible = true;
                        SM.ShowErrorMessage("No security officer with this NRIC/FIN No. exists in database !");
                        return;
                    }
                    //=========================================//
                    DBConnectionHandler1 db = new DBConnectionHandler1();
                    SqlConnection cn = db.getconnection();
                    cn.Open();
                    if (cn.State == ConnectionState.Open) { }
                    else { cn.Open(); }
                    SqlCommand cmd = new SqlCommand("select code from location where Location_id=@location", cn);
                    cmd.Parameters.AddWithValue("@location",int.Parse(Session["LCID"].ToString()));
                    SqlDataReader dr = cmd.ExecuteReader();
                    string AssignmentCode = string.Empty;
                    if (dr.Read())
                    {
                         AssignmentCode = dr.GetString(0);
                    }
                    string CurrDate=DateTime.Now.ToShortDateString();
                    string[] Splitter=CurrDate.Split('/');
                    int Date=Convert.ToInt32(Splitter[1].ToString());
                    SqlParameter[] para3 = new SqlParameter[5];
                    para3[0] = new SqlParameter("@Nric", SqlDbType.VarChar, 100);
                    para3[0].Value = NRICNO;
                    para3[1] = new SqlParameter("@AssignmentCode", SqlDbType.VarChar, 200);
                    para3[1].Value = AssignmentCode;
                    para3[2] = new SqlParameter("@Day", SqlDbType.Int, 100);
                    para3[2].Value = Date;
                    para3[3] = new SqlParameter("@Month", SqlDbType.Int, 100);
                    para3[3].Value = DateTime.Now.Month;
                    para3[4] = new SqlParameter("@WorkMonth", SqlDbType.VarChar, 100);
                    para3[4].Value =Month[DateTime.Now.Month-1]+" "+DateTime.Now.Year;
                    DataTable dt2 = new DataTable();



                    dt2 = dal.executeprocedure("SP_AddSalaryInterface", para3, false);
                    objchickin.Role = txtrole.Text;
                    //==========================================//

                    objchickin.telephone = txtTeleNo3.Text;
                    objchickin.UserID = STAFFID;
                    //objchickin.Role =TextsecOff.Text;
                    objchickin.user_name = txtName3.Text.Trim();
                    objchickin.NRICno = NRICNO;

                    /*string time = string.Empty;
                    time = ConfigurationManager.AppSettings.Get("SPATime");
                    double newtime = Convert.ToDouble(time);
                    objchickin.Checkin_DateTime = DateTime.Now.AddHours(newtime);*/
                    objchickin.Checkin_DateTime = DateTime.Now;
                    if (Session["LCID"] != null && Session["LCID"].ToString() != "0")
                    {
                        objchickin.LocationID = int.Parse(Session["LCID"].ToString());
                    }
                    else
                    {
                        //lblerror.Visible = true;
                        //lblerror.Text = "You must login as either supervisor or security officer or Operation Manager..!";
                        //lblerr1.Visible = true;
                        SM.ShowErrorMessage("You must login as either supervisor or security officer or Operation Manager..!");
                        return;
                        //throw new Exception();
                    }


                    AdminBLL ws = new AdminBLL();
                    ws.AddCheckinGaurd(objchickin);

                    HttpContext.Current.Items.Add("COMPLETE", "INSERT");
                    SM.ShowErrorMessage("Check In Successfully..!");
                    return;
                   // Server.Transfer("..//SMSADMIN//AlertUpdateComplete.aspx");
                }
                else
                {
                    //lblerror.Visible = true;
                    //lblerror.Text = "You must login as either supervisor or security officer or Operation Manager..!";
                    //lblerr1.Visible = true;
                    SM.ShowErrorMessage("You must login as either supervisor or security officer or Operation Manager..!");
                    
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        #region AddMethod

        String AddTelephone()
        {
            SpaMaster SM = (SpaMaster)Page.Master;
            if (txtTeleNo3.Text != "")
            {
                String ZipRegex = "^[0-9]+$";
                if (Regex.IsMatch(txtTeleNo3.Text, ZipRegex))
                {
                    return txtTeleNo3.Text;
                }
                else
                {
                    //lblerror.Visible = true;
                    //lblerror.Text = "Please Fill Only Numeric Values ..!";
                    SM.ShowErrorMessage("Please Fill Only Numeric Values ..!");
                    throw new Exception();
                }
            }
            return "";
        }

        #endregion

        protected void btnclear_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                txtNricID3.Text = "";
                txtName3.Text = "";
                txtTeleNo3.Text = "";
            }
            catch (Exception ex)
            {
                 logger.Info(ex.Message);
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
               // return true;
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
            SpaMaster SM = (SpaMaster)Page.Master;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            bool success = false;
            try
            {              
                
                Template template1 = new Template();
                FeatureSet featureSet = new FeatureSet();
                SqlParameter[] para = new SqlParameter[1];

               // para[0] = new SqlParameter("Staff_ID", "4D1614C3A02F");
                para[0] = new SqlParameter("Staff_ID", Session["StaffID1"].ToString());
                DataTable dt = dal.executeprocedure("usp_GetRoleThumbPrints", para, false);
                foreach (DataRow dr in dt.Rows)
                {
                    featureSet = new DPFP.FeatureSet();
                    featureSet.DeSerialize(HexsToArray(hdnFP.Value));
                        template1 = new DPFP.Template();
                        template1.DeSerialize((byte[])dr["ThumbImage"]);
                        if (VerifyFingerprints(template1, featureSet))
                        {
                            DataTable dtcheckin = dal.getdata("select checkin_id from checkin_manager where UserID = '" + dr["Staff_ID"].ToString() + "' ");
                            if (dtcheckin.Rows.Count > 0)
                            {
                                DataTable dtcheckout = dal.getdata("select checkout_id from checkout_manager where checkin_id = '" + dtcheckin.Rows[0][0].ToString() + "' ");
                                if (dtcheckout.Rows.Count == 0)
                                {
                                    //lblerror.Visible = true;
                                    //lblerror.Text = "Security Officer is Already Checked in.Please Contact Your SuperVisor..!";
                                    //lblerr1.Visible = true;
                                    SM.ShowErrorMessage("Security Officer is Already Checked in.Please Contact Your SuperVisor..!");
                                    return;
                                   // throw new Exception();
                                }
                            }

                        AddNewCheckInRequest objAddCheckinRequest = new AddNewCheckInRequest();
                        checkin objchickin = new checkin();
                        objchickin.telephone = dr["Phone"].ToString();
                        objchickin.UserID = dr["Staff_ID"].ToString();
                        objchickin.Role = txtrole.Text;
                        objchickin.user_name = dr["FirstName"].ToString();
                        objchickin.Checkin_DateTime = DateTime.Now;
                        objchickin.NRICno = dr["NRICno"].ToString();
                        if (Session["LCID"] != null && Session["LCID"].ToString() != "0")
                        {
                            objchickin.LocationID = int.Parse(Session["LCID"].ToString());
                        }
                        //=========================================//
                        DBConnectionHandler1 db = new DBConnectionHandler1();
                        SqlConnection cn = db.getconnection();
                        cn.Open();
                        if (cn.State == ConnectionState.Open) { }
                        else { cn.Open(); }
                        SqlCommand cmd = new SqlCommand("select code from location where Location_id=@location", cn);
                        cmd.Parameters.AddWithValue("@location", int.Parse(Session["LCID"].ToString()));
                        SqlDataReader dr1 = cmd.ExecuteReader();
                        string AssignmentCode = string.Empty;
                        if (dr1.Read())
                        {
                            AssignmentCode = dr1.GetString(0);
                        }
                        string CurrDate = DateTime.Now.ToShortDateString();
                        string[] Splitter = CurrDate.Split('/');
                        int Date = Convert.ToInt32(Splitter[1].ToString());
                        SqlParameter[] para3 = new SqlParameter[5];
                        para3[0] = new SqlParameter("@Nric", SqlDbType.VarChar, 100);
                        para3[0].Value = dr["NRICno"].ToString();
                        para3[1] = new SqlParameter("@AssignmentCode", SqlDbType.VarChar, 200);
                        para3[1].Value = AssignmentCode;
                        para3[2] = new SqlParameter("@Day", SqlDbType.Int, 100);
                        para3[2].Value = Date;
                        para3[3] = new SqlParameter("@Month", SqlDbType.Int, 100);
                        para3[3].Value = DateTime.Now.Month;
                        para3[4] = new SqlParameter("@WorkMonth", SqlDbType.VarChar, 100);
                        para3[4].Value = Month[DateTime.Now.Month - 1] + " " + DateTime.Now.Year;
                        DataTable dt2 = new DataTable();



                        dt2 = dal.executeprocedure("SP_AddSalaryInterface", para3, false);
                        //objchickin.Role = txtrole.Text;
                        //==========================================//
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
                        //lblerror.Text = "Invalid Thumbprint. Please Put Correct Finger.";
                        //lblerror.Visible = true;
                        SM.ShowErrorMessage("Invalid Thumbprint. Please Put Correct Finger.");
                    }
                }
                else
                {
                    //lblerror.Text = "You Have Successfully Checked In";
                    //lblerror.Visible = true;
                    SM.ShowErrorMessage("You Have Successfully Checked In");
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
                if (!(lblerror.Text.ToLower().Contains("already")))
                {
                    //lblerror.Text = "Error Has Occured. Please Thumbprint Again.";
                    SM.ShowErrorMessage("Error Has Occured. Please Thumbprint Again.");
                }
               // lblerror.Visible = true;
            }
        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SMSAdmin/AlertUpdateComplete.aspx");
        }
    }
}
