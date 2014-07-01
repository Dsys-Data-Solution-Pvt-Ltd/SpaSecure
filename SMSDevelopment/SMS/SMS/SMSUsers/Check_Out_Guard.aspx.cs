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
using System.Globalization;
using DPFP.Verification;
using SMS.master;
namespace SMS.SMSUsers
{
    public partial class Check_Out_Guard : System.Web.UI.Page
    {        
        AdminDAL w = new AdminDAL();
        DataAccessLayer dal = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                lblerror.Visible = false;
                lblerror.Text = "";
                lblerr1.Visible = false;               
                txtID1.Focus();
                if (!IsPostBack)
                {                   
                    //string role = Session["role"].ToString();
                    string role = Session["user_role"].ToString();
                    txtrole.Text = role;
                    if (role == "Operations Manager" || role == "Supervisor" || role == "Controller" || role == "Security Officer")
                    {
                        tblThumbInfo.Style.Add(HtmlTextWriterStyle.Display, "block");
                        //manually.Visible = false;
                        manually.Visible = true;
                    }
                    else
                    {
                        tblThumbInfo.Style.Add(HtmlTextWriterStyle.Display, "block");
                        manually.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnClear1_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                txtID1.Text = "";                
                txtName1.Text = "";                
                txtTeleNo1.Text = "";
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void AddCheckOutGuard(object sender, EventArgs e)
        {
            SpaMaster SM = (SpaMaster)Page.Master;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Boolean ok = false;                
                checkout objchickout = new checkout();  
                String ZipRegex = "^[a-z A-Z 0-9]+$";
                if (Regex.IsMatch(txtID1.Text, ZipRegex))
                {
                    if (Session["user_role"].ToString() == "Supervisor" || Session["user_role"].ToString() == "Security Officer" || Session["user_role"].ToString() == "Operations Manager")
                    {
                        if (Session["user_role"].ToString() == "Operations Manager")
                        {
                            txtrole.Text = "Security Officer";
                        }
                        DataTable dt = dal.getdata("Select Staff_ID from UserInformation where NRICno='" + txtID1.Text.Trim() + "' and Role = '" + txtrole.Text.Trim() + "'");
                        DataSet rd = new DataSet();
                        if (dt.Rows.Count > 0)
                        {
                            rd = dal.getdataset("select * from checkin_manager where UserID='" + dt.Rows[0][0].ToString() + "' and Role='" + txtrole.Text + "' order by Checkin_DateTime desc ");

                            if (rd.Tables[0].Rows.Count > 0)
                            {
                                objchickout.user_id = rd.Tables[0].Rows[0]["UserID"].ToString();
                                objchickout.user_name = rd.Tables[0].Rows[0]["user_name"].ToString();
                                objchickout.telephone = rd.Tables[0].Rows[0]["telephone"].ToString();

                                objchickout.key_no = rd.Tables[0].Rows[0]["Key_no"].ToString();
                                objchickout.pass_no = rd.Tables[0].Rows[0]["Pass_No"].ToString();
                                objchickout.Role = rd.Tables[0].Rows[0]["Role"].ToString();

                                objchickout.Checkin_DateTime = Convert.ToDateTime(rd.Tables[0].Rows[0]["Checkin_DateTime"].ToString());
                                objchickout.checkin_id = rd.Tables[0].Rows[0]["checkin_id"].ToString();
                                objchickout.NRICno = rd.Tables[0].Rows[0]["NRICno"].ToString();
                                objchickout.Location_id = rd.Tables[0].Rows[0]["LocationID"].ToString();
                            }
                            else
                            {
                                SM.ShowErrorMessage("No security officer with this NRIC/FIN No. checked In ..!");
                                return;
                            }
                        }
                        else
                        {
                            //lblerror.Visible = true;
                            //lblerror.Text = "No Security Officer with this NRIC/FIN No. exists in database !";
                            //lblerr1.Visible = true;
                            //throw new Exception();
                            SM.ShowErrorMessage("No Security Officer with this NRIC/FIN No. exists in database !");
                            return;
                        }
                        /*string time = string.Empty;
                        time = ConfigurationManager.AppSettings.Get("SPATime");
                        double newtime = Convert.ToDouble(time);
                        objchickout.Checkout_DateTime = DateTime.Now.AddHours(newtime);*/
                        objchickout.Checkout_DateTime = DateTime.Now;
                        AdminBLL ws = new AdminBLL();
                        ws.AddCheckOutGaurd(objchickout);
                        ok = true;
                        if (ok == true)
                        {
                            removedata();
                        }
                        HttpContext.Current.Items.Add("COMPLETE", "INSERT");
                        SM.ShowErrorMessage("Check Out Successfully..!");
                        //Server.Transfer("..//SMSADMIN//AlertUpdateComplete.aspx");
                    }
                    else
                    {
                        //lblerror.Visible = true;
                        //lblerror.Text = "No security officer with this NRIC/FIN No. checked In ..!";
                        //lblerr1.Visible = true;
                        //throw new Exception();
                        SM.ShowErrorMessage("No security officer with this NRIC/FIN No. checked In ..!");
                    }
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

        }
        void removedata()
        {
            //dal.executesql("delete from checkin_manager where NRICno='" + txtID1.Text.Trim() + "' and Role='" + txtrole.Text.Trim() + "'");
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@NRICno", SqlDbType.VarChar, 100);
            para[0].Value = txtID1.Text.Trim();
            para[1] = new SqlParameter("@Role", SqlDbType.VarChar, 100);
            para[1].Value = txtrole.Text.Trim();
            dal.exeprocedure("SP_deleteCheckInDetailByNRICrole", para);           
        }       

        private void BindGridContractor()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                AdminBLL ws = new AdminBLL();
                GetContractorData _req = new GetContractorData();
                //GetContractorDataResponse _resp = ws.GetContractorData(_req);
                DataTable _resp = ws.GetContractorData(_req);

                int pageSize = ContextKeys.GRID_PAGE_SIZE;
                gvContractorTable.PageSize = pageSize;
               // gvContractorTable.DataSource = _resp.Contractor;
                gvContractorTable.DataSource = _resp;
                gvContractorTable.DataBind();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

        }
        private void BindGridWithFilterContractor()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                AdminBLL ws = new AdminBLL();
                GetContractorData objReq = new GetContractorData();
                string WhereClause = ReturnWhereContractor();              
                if (!string.IsNullOrEmpty(txtID1.Text))
                {
                    objReq.NRICno = txtID1.Text;
                }
                if (!string.IsNullOrEmpty(txtName1.Text))
                {
                    objReq.NRICno = txtName1.Text;
                } 
                if (!string.IsNullOrEmpty(WhereClause))
                {
                    objReq.WhereClause = WhereClause;
                }

                GetContractorDataResponse ret = ws.GetContractorData1(objReq);
                int pageSize = ContextKeys.GRID_PAGE_SIZE;
                gvContractorTable.PageSize = pageSize;
                gvContractorTable.DataSource = ret.Contractor;
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
                    ////JS for delete btn
                    //ImageButton Delete = (ImageButton)e.Row.FindControl("btnDelete");
                    //Delete.Attributes.Add("onclick", "javascript:return " +
                    //    "confirm('Are you sure to delete this record?')");
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
                    BindGridWithFilterContractor();
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

                if (txtID1.Text.Trim() != "")
                {
                    if (arr.Count == 1)
                    {
                        makeWhereClause = " where ";
                        str += " where NRICno='" + txtID1.Text.Trim() + "' and Role='" + txtrole.Text + "' and user_name='"+txtName1.Text.Trim()+"'";
                        arr.Add("1");
                    }
                    else
                    {
                        str += " and NRICno='" + txtID1.Text.Trim() + "' and Role='" + txtrole.Text + "' and user_name='" + txtName1.Text.Trim() + "'";
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
            return (str);

        }

        protected void txtID1_TextChanged(object sender, EventArgs e)
        {
            SpaMaster SM = (SpaMaster)Page.Master;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                DBConnectionHandler1 db = new DBConnectionHandler1();
                SqlConnection cn = db.getconnection();
                cn.Open();
                SqlCommand cmd = new SqlCommand("select Role from UserInformation where NRICno='" + txtID1.Text+"'",cn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Session["user_role"] = dr.GetString(0);
                    cmd.Dispose();
                    dr.Close();
                    cn.Close();
                }
                if (Session["user_role"].ToString() != "Operations Manager")
                {
                   // txtrole.Text = "Security Officer";
                    String ZipRegex = "^[a-z A-Z 0-9]+$";
                    if (Regex.IsMatch(txtID1.Text.Trim(), ZipRegex))
                    {
                        DataTable dt = dal.getdata("Select Staff_ID,ImagePathName from UserInformation where NRICno='" + txtID1.Text + "' and Role = '" + txtrole.Text + "'");
                        SqlParameter[] para = new SqlParameter[2];
                        para[0] = new SqlParameter("@NRICno", SqlDbType.VarChar, 100);
                        para[0].Value = txtID1.Text.Trim();
                        para[1] = new SqlParameter("@Role", SqlDbType.VarChar, 100);
                        para[1].Value = txtrole.Text.Trim();
                        DataTable dt1 = dal.executeprocedure("SP_GetCheckInDetailByNRICrole", para, false);
                        if (dt1.Rows.Count > 0)
                        {
                            txtID1.Text = dt1.Rows[0]["NRICno"].ToString();
                            txtTeleNo1.Text = dt1.Rows[0]["telephone"].ToString();
                            txtName1.Text = dt1.Rows[0]["user_name"].ToString();
                            txtcheckinTime.Text = dt1.Rows[0]["Checkin_DateTime"].ToString();
                            Image3.ImageUrl = dt.Rows[0]["ImagePathName"].ToString();
                            gvContractorTable.Visible = true;
                            BindGridWithFilterContractor();
                        }
                        else
                        {
                            //lblerror.Visible = true;
                            //lblerror.Text = "Invalid NRIC/FIN No/Alerady Checked Out...!";
                            //lblerr1.Visible = true;
                            SM.ShowErrorMessage("Invalid NRIC/FIN No/Alerady Checked Out...!");
                            return;
                        }
                    }
                    else
                    {
                        //lblerror.Visible = true;
                        //lblerror.Text = "Invalid NRIC/FIN No. ..!";
                        //lblerr1.Visible = true;
                        SM.ShowErrorMessage("Invalid NRIC/FIN No. ..!");
                        return;
                    }
                }
                else
                {
                    //lblerror.Visible = true;
                    //lblerror.Text = "Invalid NRIC/FIN No. ..!";
                    //lblerr1.Visible = true;
                    SM.ShowErrorMessage("Invalid NRIC/FIN No. ..!");
                    return;
                }
               
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
            Page.ClientScript.RegisterStartupScript(this.GetType(), "MenuShow", "ShowManualPortion();", true);
        }

        private bool VerifyFingerprints(DPFP.Template TemplateLeftIndex, DPFP.FeatureSet FeatureSet)
        {
            try
            {
                Verification.Result Result = new Verification.Result();
                Verification Verification = new Verification();

                // Verify the left index finger.
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
            SpaMaster SM = (SpaMaster)Page.Master;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            bool success = false;
            try
            {
                Template template1 = new Template();
                FeatureSet featureSet = new FeatureSet();

                SqlParameter[] para = new SqlParameter[1];
                //para[0] = new SqlParameter("@Role", txtrole.Text);
                para[0] = new SqlParameter("Staff_ID", Session["StaffID1"].ToString());
                DataTable dt = dal.executeprocedure("usp_GetRoleThumbPrints", para, false);

                foreach (DataRow dr in dt.Rows)
                {
                    template1 = new DPFP.Template();
                    template1.DeSerialize((byte[])dr["ThumbImage"]);

                    featureSet = new DPFP.FeatureSet();
                    featureSet.DeSerialize(HexsToArray(hdnFP.Value));
                    if (VerifyFingerprints(template1, featureSet))
                    {
                        txtID1.Text = dr["NRICno"].ToString();
                        txtName1.Text = dr["FirstName"].ToString();
                        txtTeleNo1.Text = dr["Phone"].ToString();
                        //SqlDataReader rd;
                        DataTable dtcheckin = dal.getdata("select Checkin_DateTime from checkin_manager where checkin_id = (select max(checkin_id)as checkin_id from checkin_manager where Userid='" + dr["Staff_ID"].ToString() + "')");
                            if (dtcheckin.Rows.Count > 0)
                            {
                                txtcheckinTime.Text = dtcheckin.Rows[0][0].ToString();
                                lblcheckinTime.Text = dtcheckin.Rows[0][0].ToString();
                                AddCheckOutGuard(sender, e);
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
                               // dal.executesql("Insert into checkout_manager(Checkout_time) values('" + DateTime.Now + "')");

                                tblThumbInfo.Style.Add(HtmlTextWriterStyle.Display, "block");
                            }
                            else
                            {
                                //lblerror.Text = "You Have Already Checked-Out";
                                //lblerror.Visible = true;
                                SM.ShowErrorMessage("You Have Already Checked-Out");
                                return;
                            }
                        break;
                    }
                }
                if (!success)
                {
                    if (!(lblerror.Text.ToLower().Contains("checked")))
                    {
                        //lblerror.Text = "Invalid Thumbprint. Please Put Correct Finger.";
                        //lblerror.Visible = true;
                        SM.ShowErrorMessage("Invalid Thumbprint. Please Put Correct Finger.");
                        return;
                    }
                }
                else
                {
                    //lblerror.Text = "You Have Successfully Checked Out.";
                    //lblerror.Visible = true;
                    SM.ShowErrorMessage("You Have Successfully Checked Out.");
                    return;
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
                if (!(lblerror.Text.ToLower().Contains("already")))
                {
                  //  lblerror.Text = "Error Has Occured. Please Thumbprint Again.";
                    SM.ShowErrorMessage("Error Has Occured. Please Thumbprint Again.");
                    return;
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
