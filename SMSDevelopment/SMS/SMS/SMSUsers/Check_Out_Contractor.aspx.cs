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
using SMS.master;

namespace SMS.SMSUsers
{
    public partial class Check_Out_Contractor : System.Web.UI.Page
    {       
        checkout objchickout = new checkout();
        AdminDAL w = new AdminDAL();
        DataAccessLayer dal = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            SpaMaster SM = (SpaMaster)Page.Master;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
              //  lblerror.Visible = false;
               // lblerr1.Visible = false;
               // gvContractorTable.Visible = false;
               // txtNricID3.Focus();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
            if (Session["LCID"] != null)
            {
                // objchickin.LocationID = int.Parse(Session["LCID"].ToString());

                // Location = Session["LCID"].ToString();
            }
            else
            {
                SM.ShowErrorMessage("Please select Location first!!!");
                //lblerror.Visible = true;
                //lblerror.Text = "Please select Location first!!!";
            }
        }

        protected void AddCheckOutSaleman(object sender, EventArgs e)
        {
            SpaMaster SM = (SpaMaster)Page.Master;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Boolean ok = false;
                String ZipRegex = "^[a-z A-Z 0-9]+$";
                if (Regex.IsMatch(txtNricID3.Text, ZipRegex))
                {
                    SqlParameter[] para = new SqlParameter[2];
                    para[0] = new SqlParameter("@NRICno", SqlDbType.VarChar, 100);
                    para[0].Value = txtNricID3.Text.Trim();
                    para[1] = new SqlParameter("@Role", SqlDbType.VarChar, 100);
                    para[1].Value = txtrole.Text.Trim();
                    DataTable dt1 = dal.executeprocedure("SP_GetCheckInDetailByNRICrole", para, false);
                    if (dt1.Rows.Count > 0)
                    {
                        objchickout.NRICno = dt1.Rows[0]["NRICno"].ToString();
                        objchickout.user_name = dt1.Rows[0]["user_name"].ToString();
                        objchickout.user_address = dt1.Rows[0]["user_address"].ToString();

                        objchickout.company_from = dt1.Rows[0]["company_from"].ToString();
                        objchickout.telephone = dt1.Rows[0]["telephone"].ToString();
                        objchickout.remarks = dt1.Rows[0]["remarks"].ToString();
                        objchickout.vehicle_no = dt1.Rows[0]["Vehicle_No"].ToString();

                        objchickout.key_no = dt1.Rows[0]["Key_no"].ToString();
                        objchickout.pass_no = dt1.Rows[0]["Pass_No"].ToString();
                        objchickout.PassType = dt1.Rows[0]["pass_type"].ToString();
                        objchickout.to_visit = dt1.Rows[0]["to_visit"].ToString();
                        objchickout.purpose = dt1.Rows[0]["purpose"].ToString();
                        objchickout.Item_Declear = dt1.Rows[0]["Item_Declear"].ToString();

                        objchickout.Checkin_DateTime = Convert.ToDateTime(dt1.Rows[0]["Checkin_DateTime"].ToString());
                        objchickout.user_image = dt1.Rows[0]["ImagePath"].ToString();
                        objchickout.Role = dt1.Rows[0]["Role"].ToString();
                        objchickout.checkin_id = dt1.Rows[0]["checkin_id"].ToString();
                        objchickout.Location_id = Session["LCID"].ToString();

                        /*string time = string.Empty;
                        time = ConfigurationManager.AppSettings.Get("SPATime");
                        double newtime = Convert.ToDouble(time);
                        objchickout.Checkout_DateTime = DateTime.Now.AddHours(newtime);*/
                        objchickout.Checkout_DateTime = DateTime.Now;
                        AdminBLL ws = new AdminBLL();
                        ws.AddCheckOutContractor(objchickout);
                        ok = true;
                        if (ok == true)
                        {
                            removedata();
                            UpdateKeyStatus();
                            UpdatePassStatus();
                        }
                        HttpContext.Current.Items.Add("COMPLETE", "INSERT");
                        SM.ShowErrorMessage("Check Out Successfully");

                        // Server.Transfer("..//SMSADMIN//AlertUpdateComplete.aspx");
                    }
                    else
                    {
                        SM.ShowErrorMessage("NRIC/FIN No. Already Checked Out ..!");
                    
                    }
                
                
                }
                else if (txtPassno.Text != "")
                {
                    SqlParameter[] para = new SqlParameter[1];
                    para[0] = new SqlParameter("@PassNo", SqlDbType.VarChar, 100);
                    para[0].Value = txtPassno.Text.Trim();
                    DataTable dt1 = dal.executeprocedure("SP_GetCheckInDetailByPassNo", para, false);
                    if (dt1.Rows.Count > 0)
                    {
                        objchickout.NRICno = dt1.Rows[0]["NRICno"].ToString();
                        objchickout.user_name = dt1.Rows[0]["user_name"].ToString();
                        objchickout.user_address = dt1.Rows[0]["user_address"].ToString();

                        objchickout.company_from = dt1.Rows[0]["company_from"].ToString();
                        objchickout.telephone = dt1.Rows[0]["telephone"].ToString();
                        objchickout.remarks = dt1.Rows[0]["remarks"].ToString();
                        objchickout.vehicle_no = dt1.Rows[0]["Vehicle_No"].ToString();

                        objchickout.key_no = dt1.Rows[0]["Key_no"].ToString();
                        objchickout.pass_no = dt1.Rows[0]["Pass_No"].ToString();
                        objchickout.PassType = dt1.Rows[0]["pass_type"].ToString();
                        objchickout.to_visit = dt1.Rows[0]["to_visit"].ToString();
                        objchickout.purpose = dt1.Rows[0]["purpose"].ToString();
                        objchickout.Item_Declear = dt1.Rows[0]["Item_Declear"].ToString();

                        objchickout.Checkin_DateTime = Convert.ToDateTime(dt1.Rows[0]["Checkin_DateTime"].ToString());
                        objchickout.user_image = dt1.Rows[0]["ImagePath"].ToString();
                        objchickout.Role = dt1.Rows[0]["Role"].ToString();
                        objchickout.checkin_id = dt1.Rows[0]["checkin_id"].ToString();
                        objchickout.Location_id = Session["LCID"].ToString();

                        /*string time = string.Empty;
                        time = ConfigurationManager.AppSettings.Get("SPATime");
                        double newtime = Convert.ToDouble(time);
                        objchickout.Checkout_DateTime = DateTime.Now.AddHours(newtime);*/
                        objchickout.Checkout_DateTime = DateTime.Now;
                        AdminBLL ws = new AdminBLL();
                        ws.AddCheckOutContractor(objchickout);
                        ok = true;
                        if (ok == true)
                        {
                            removedataByPassNo();
                            UpdateKeyStatus();
                            UpdatePassStatus();
                        }
                        HttpContext.Current.Items.Add("COMPLETE", "INSERT");
                    //    Server.Transfer("..//SMSADMIN//AlertUpdateComplete.aspx");
                        SM.ShowErrorMessage("Check Out Successfully");
                    }
                }
                else
                {
                    
                    //lblerror.Visible = true;
                    //lblerror.Text = "Invalid passNo. ..!";
                    SM.ShowErrorMessage("Invalid passNo. ..!");
                   // lblerr1.Visible = true;
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private void UpdateKeyStatus()
        {
            dal.executesql("Update addnewkey set status='Free' where BunchNo='" + objchickout.key_no + "'");
            //SqlParameter[] para = new SqlParameter[2];
            //para[0] = new SqlParameter("@Key_ID", SqlDbType.Int, 30);
            //para[0].Value = txtKeyNo3.SelectedValue.ToString();
            //para[0] = new SqlParameter("@Status", SqlDbType.VarChar, 30);
            //para[0].Value = "Reserve";
            //dal.exeprocedure("SP_getCheckinIDbyNRICNo", para);   

        }
        private void UpdatePassStatus()
        {
            dal.executesql("Update Pass_Master set Pass_Status='Free' where Pass_id='" + objchickout.pass_no + "'");

            //SqlParameter[] para1 = new SqlParameter[2];
            //para1[0] = new SqlParameter("@Pass_id", SqlDbType.Int, 30);
            //para1[0].Value = txtPassNo3.SelectedValue.ToString();
            //para1[1] = new SqlParameter("@Status", SqlDbType.VarChar, 30);
            //para1[1].Value = "Reserve";
            //dal.exeprocedure("SP_UpdatePassStatusbyPassID", para1);    
        }
        void removedata()
        {
            //dal.executesql("delete from checkin_manager where NRICno='" + txtNricID3.Text + "' and Role='" + txtrole.Text + "' ");

            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@NRICno", SqlDbType.VarChar, 100);
            para[0].Value = txtNricID3.Text.Trim();
            para[1] = new SqlParameter("@Role", SqlDbType.VarChar, 100);
            para[1].Value = txtrole.Text.Trim();
            dal.exeprocedure("SP_deleteCheckInDetailByNRICrole", para);
        }

        void removedataByPassNo()
        {
            //dal.executesql("delete from checkin_manager where NRICno='" + txtNricID3.Text + "' and Role='" + txtrole.Text + "' ");

            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@PassNo", SqlDbType.VarChar, 100);
            para[0].Value = txtPassno.Text.Trim();

            dal.exeprocedure("SP_deleteCheckInDetailByPassNo", para);
        }

        protected void btnClear3_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                clearAll();
                Panel1.Visible = false;
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private void clearAll()
        {
            txtKeyNo3.Text = "";
            txtName3.Text = "";
            txtNricID3.Text = "";
            txtPassno.Text = "";
            txtTeleNo3.Text = "";
            txtAddress3.Text = "";
            txtPassType.Text = "";
            txtVehicleNo3.Text = "";
            txtCompanyfrom3.Text = "";
            txtpurpose.Text = "";
            txtServingAt1.Text = "";
            txtItemDeclear3.Text = "";
            txtcheckinTime.Text = "";
            txtRemarks3.Text = "";
            Image3.ImageUrl = Convert.ToString("~/ImageUpload/i m.jpg");
            txtName3.Enabled = true;
            //Response.Redirect("Check_Out_Contractor.aspx");
        }


        protected void txtNricID3_TextChanged(object sender, EventArgs e)
        {
            SpaMaster MyMasterPage = (SpaMaster)Page.Master;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (txtNricID3.Text.Trim() != "")
                {
                    String ZipRegex = "^[a-z A-Z 0-9]+$";
                    if (Regex.IsMatch(txtNricID3.Text, ZipRegex))
                    {
                        SqlParameter[] para = new SqlParameter[2];
                        para[0] = new SqlParameter("@NRICno", SqlDbType.VarChar, 100);
                        para[0].Value = txtNricID3.Text.Trim();
                        para[1] = new SqlParameter("@Role", SqlDbType.VarChar, 100);
                        para[1].Value = txtrole.Text.Trim();
                        DataTable dt = dal.executeprocedure("SP_GetCheckInDetailByNRICrole", para, false);
                            if (dt.Rows.Count > 0)
                            {
                                txtNricID3.Text = dt.Rows[0]["NRICno"].ToString();
                                txtTeleNo3.Text = dt.Rows[0]["telephone"].ToString();
                                txtName3.Text = dt.Rows[0]["user_name"].ToString();
                                txtName3.Enabled = false;
                                txtKeyNo3.Text = dt.Rows[0]["key_no"].ToString();
                                txtPassno.Text = dt.Rows[0]["pass_no"].ToString();
                                Image3.ImageUrl = dt.Rows[0]["ImagePath"].ToString();
                                txtAddress3.Text = dt.Rows[0]["user_address"].ToString();
                                txtCompanyfrom3.Text = dt.Rows[0]["company_from"].ToString();
                                txtRemarks3.Text = dt.Rows[0]["remarks"].ToString();
                                txtVehicleNo3.Text = dt.Rows[0]["Vehicle_No"].ToString();
                                txtPassType.Text = dt.Rows[0]["pass_type"].ToString();
                                txtServingAt1.Text = dt.Rows[0]["to_visit"].ToString();
                                txtpurpose.Text = dt.Rows[0]["purpose"].ToString();
                                txtItemDeclear3.Text = dt.Rows[0]["Item_Declear"].ToString();
                                txtcheckinTime.Text = dt.Rows[0]["Checkin_DateTime"].ToString();
                                Panel1.Visible = true;
                            }
                            else
                            {
                                MyMasterPage.ShowErrorMessage("NRIC/FIN No. Already Checked Out ..!");
                                // lblerror.Visible = true;
                                // lblerror.Text = "Invalid NRIC/FIN No. ..!";
                                // lblerr1.Visible = true;
                            }
                       
                    }
                    else
                    {
                        MyMasterPage.ShowErrorMessage("Invalid NRIC/FIN No. ..!");
                    }
                }
                else
                {
                        MyMasterPage.ShowErrorMessage("Fill NRIC/FIN No. ..!");
                    // lblerror.Visible = true;
                    //  lblerror.Text = "Invalid NRIC/FIN No. ..!";
                    //  lblerr1.Visible = true;
                }
                    

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

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
                //gvContractorTable.DataSource = _resp.Contractor;
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

                if (!string.IsNullOrEmpty(WhereClause))
                {
                    objReq.WhereClause = WhereClause;
                }

                GetContractorDataResponse ret1 = ws.GetContractorData1(objReq);
                int pageSize1 = ContextKeys.GRID_PAGE_SIZE;
                gvContractorTable.PageSize = pageSize1;
                gvContractorTable.DataSource = ret1.Contractor;
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

                if (txtNricID3.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        makeWhereClause = " where ";
                        str += " where NRICno='" + txtNricID3.Text + "'";
                        arr.Add("1");
                    }
                    else
                    {
                        str += " and NRICno='" + txtNricID3.Text + "'";
                    }
                }

                if (txtrole.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        makeWhereClause = " where ";
                        str += " where  Role='" + txtrole.Text + "'";
                        arr.Add("2");
                    }
                    else
                    {
                        str += " and  Role='" + txtrole.Text + "'";
                    }
                }

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
            return (str);

        }
        protected void imgBtnFromDate3_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnHistory3_Click(object sender, EventArgs e)
        {

        }

        protected void txtRemarks3_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtPassno_TextChanged(object sender, EventArgs e)
        {
            SpaMaster SM = (SpaMaster)Page.Master;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (txtPassno.Text.Trim() != "")
                {
                    String ZipRegex = "^[a-z A-Z 0-9]+$";
                    if (Regex.IsMatch(txtNricID3.Text, ZipRegex))
                    {
                        DBConnectionHandler1 db = new DBConnectionHandler1();
                        SqlConnection cn = db.getconnection();
                        cn.Open();
                        SqlCommand _cmd = new SqlCommand("Select * from checkin_manager where Pass_No=@Pass_No and Role=@Role", cn);
                        _cmd.Parameters.AddWithValue("@Pass_No", txtPassno.Text.Trim());
                        _cmd.Parameters.AddWithValue("@Role", txtrole.Text.Trim());
                        SqlDataReader dr = _cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            txtNricID3.Text = dr.GetString(20);
                            txtTeleNo3.Text = dr.GetString(5);
                            txtName3.Text = dr.GetString(2);
                            txtName3.Enabled = false;
                            txtKeyNo3.Text = dr.GetString(8);
                            txtPassno.Text = dr.GetString(9);
                            if (dr.GetString(17).ToString() != "")
                            {
                                Image3.ImageUrl = dr.GetString(17);
                            }

                            txtAddress3.Text = dr.GetString(3);
                            txtCompanyfrom3.Text = dr.GetString(4);
                            txtRemarks3.Text = dr.GetString(6);
                            txtVehicleNo3.Text = dr.GetString(7);
                            txtPassType.Text = dr.GetString(10);
                            txtServingAt1.Text = dr.GetString(11);
                            txtpurpose.Text = dr.GetString(12);
                            txtItemDeclear3.Text = dr.GetString(13);
                            txtcheckinTime.Text = dr.GetString(14);
                            Panel1.Visible = true;
                        }
                        else
                        {
                            
                            //lblerror.Visible = true;
                            //lblerror.Text = "Invalid Pass No. ..!";
                            SM.ShowErrorMessage("Invalid Pass No. ..!");
                            //lblerr1.Visible = true;
                        }
                        //========================//
                        dr.Close();
                        dr.Dispose();
                        cn.Close();
                        //========================//
                    }
                    else
                    {
                        //lblerror.Visible = true;
                        //lblerror.Text = "Invalid Pass No. ..!";
                        SM.ShowErrorMessage("Invalid Pass No. ..!");
                       // lblerr1.Visible = true;
                    }
                    
                }
                
            }
            catch (Exception exc)
            {
                logger.Info(exc.Message);
            }
        }
    }
}
