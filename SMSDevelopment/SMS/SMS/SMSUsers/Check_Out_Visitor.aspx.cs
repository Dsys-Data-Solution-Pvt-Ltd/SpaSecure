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
using System.Text.RegularExpressions;
using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.Services.DataService;
using SMS.SMSAppUtilities;
using SMS.BusinessEntities;
using SMS.master;

namespace SMS.SMSUsers
{
    public partial class Check_Out_Visitor : System.Web.UI.Page
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
                lblerror.Visible = false;
                lblerr1.Visible = false;
                txtNricID2.Focus();
                gvContractorTable.Visible = false;
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

        protected void AddCheckOutVisitor(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                Boolean ok = false;
                String ZipRegex = "^[a-z A-Z 0-9]+$";

                if (Regex.IsMatch(txtNricID2.Text, ZipRegex) && (txtNricID2.Text.Trim() != ""))
                {
                    SqlParameter[] para = new SqlParameter[2];
                    para[0] = new SqlParameter("@NRICno", SqlDbType.VarChar, 100);
                    para[0].Value = txtNricID2.Text.Trim();
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
                        //objchickout.Location_id = Session["LCID"].ToString();

                        /*string time = string.Empty;
                        time = ConfigurationManager.AppSettings.Get("SPATime");
                        double newtime = Convert.ToDouble(time);
                        objchickout.Checkout_DateTime = DateTime.Now.AddHours(newtime);*/
                        objchickout.Checkout_DateTime = DateTime.Now;
                        ok = true;
                        if (ok == true)
                        {
                            removedata();
                            UpdateKeyStatus();
                            UpdatePassStatus();
                        }
                        AdminBLL ws = new AdminBLL();
                        ws.AddCheckOutVisiter(objchickout);
                        MyMasterPage.ShowErrorMessage("Check Out Successfully");
                        //HttpContext.Current.Items.Add("COMPLETE", "INSERT");
                        //Server.Transfer("..//SMSADMIN//AlertUpdateComplete.aspx");
                    }
                    else
                    {
                        MyMasterPage.ShowErrorMessage("NRIC/FIN No. Already Checked Out ..!");
                    }
                }
                else
                {
                    MyMasterPage.ShowErrorMessage("Invalid NRIC/FIN No. ..!");     
                    //lblerror.Visible = true;
                    //lblerror.Text = "Invalid NRIC/FIN No. ..!";
                    //lblerr1.Visible = true;
                }

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
            //txtPassNo2.Text = "hello";
        }
        private void UpdateKeyStatus()
        {
            dal.executesql("Update addnewkey set status='Free' where BunchNo='" + objchickout.key_no + "'");
        }
        private void UpdatePassStatus()
        {
            dal.executesql("Update Pass_Master set Pass_Status='Free' where Pass_No='" + objchickout.pass_no + "'");
        }
        void removedata()
        {
            // dal.executesql("delete from checkin_manager where NRICno='" + txtNricID2.Text + "' and Role='" + txtrole.Text + "'");            
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@NRICno", SqlDbType.VarChar, 100);
            para[0].Value = txtNricID2.Text.Trim();
            para[1] = new SqlParameter("@Role", SqlDbType.VarChar, 100);
            para[1].Value = txtrole.Text.Trim();
            dal.exeprocedure("SP_deleteCheckInDetailByNRICrole", para);
        }
        protected void btnClear2_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                txtKeyNo2.Text = "";
                txtName2.Text = "";
                txtNricID2.Text = "";
                txtPassNo2.Text = "";
                txtAddress2.Text = "";
                txtTeleNo2.Text = "";
                txtpasstype.Text = "";
                txtVehicleNo2.Text = "";
                txtToVisit2.Text = "";
                txtVisitorPurpose2.Text = "";
                txtCompanyFrom2.Text = "";
                txtItemDeclear2.Text = "";
                txtcheckinTime.Text = "";
                txtRemarks2.Text = "";
                txtName2.Enabled = true;
                image3.ImageUrl = Convert.ToString("~/ImageUpload/im.jpg");
                //Response.Redirect("Check_Out_Visitor.aspx");
                Panel1.Visible = false;
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        protected void clear()
        {
            txtKeyNo2.Text = "";
            txtName2.Text = "";
            txtPassNo2.Text = "";
            txtAddress2.Text = "";
            txtTeleNo2.Text = "";
            txtpasstype.Text = "";
            txtVehicleNo2.Text = "";
            txtToVisit2.Text = "";
            txtVisitorPurpose2.Text = "";
            txtCompanyFrom2.Text = "";
            txtItemDeclear2.Text = "";
            txtcheckinTime.Text = "";
            txtRemarks2.Text = "";
            txtName2.Enabled = true;
        }


        protected void txtaddNumberofStaff_Changed(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                if (txtNricID2.Text.Trim() != "")
                {
                    SqlParameter[] para = new SqlParameter[2];
                    para[0] = new SqlParameter("@NRICno", SqlDbType.VarChar, 100);
                    para[0].Value = txtNricID2.Text.Trim();
                    para[1] = new SqlParameter("@Role", SqlDbType.VarChar, 100);
                    para[1].Value = txtrole.Text.Trim();
                      DataTable dt = dal.executeprocedure("SP_GetCheckInDetailByNRICrole", para, false);
                        if (dt.Rows.Count > 0)
                        {
                            txtNricID2.Text = dt.Rows[0]["NRICno"].ToString();
                            txtTeleNo2.Text = dt.Rows[0]["telephone"].ToString();
                            txtName2.Text = dt.Rows[0]["user_name"].ToString();
                            txtName2.Enabled = false;
                            txtKeyNo2.Text = dt.Rows[0]["key_no"].ToString();
                            txtPassNo2.Text = dt.Rows[0]["pass_no"].ToString();
                            image3.ImageUrl = dt.Rows[0]["ImagePath"].ToString();
                            txtAddress2.Text = dt.Rows[0]["user_address"].ToString();
                            txtCompanyFrom2.Text = dt.Rows[0]["company_from"].ToString();
                            txtRemarks2.Text = dt.Rows[0]["remarks"].ToString();
                            txtVehicleNo2.Text = dt.Rows[0]["Vehicle_No"].ToString();
                            txtpasstype.Text = dt.Rows[0]["pass_type"].ToString();
                            txtToVisit2.Text = dt.Rows[0]["to_visit"].ToString();
                            txtVisitorPurpose2.Text = dt.Rows[0]["purpose"].ToString();
                            txtItemDeclear2.Text = dt.Rows[0]["Item_Declear"].ToString();
                            txtcheckinTime.Text = dt.Rows[0]["Checkin_DateTime"].ToString();
                            Panel1.Visible = true;
                        }
                        else
                        {
                             MyMasterPage.ShowErrorMessage("NRIC/FIN No. Already Checked Out ..!");
                         //   MyMasterPage.ShowErrorMessage("Invalid NRIC/FIN No. ..!");
                            //lblerror.Visible = true;
                            //lblerror.Text = "Invalid NRIC/FIN No. ..!";
                            clear();
                            //lblerr1.Visible = true;
                        }
                   
                }
                else
                {
                    MyMasterPage.ShowErrorMessage("Fill NRIC/FIN No. ..!");
                    //lblerror.Visible = true;
                    //lblerror.Text = "Invalid NRIC/FIN No. ..!";
                    //lblerr1.Visible = true;
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

                if (!string.IsNullOrEmpty(txtNricID2.Text))
                {
                    objReq.user_id = txtNricID2.Text;
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

                if (txtNricID2.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        makeWhereClause = " where ";
                        str += " where user_id='" + txtNricID2.Text.Trim() + "'and Role='" + txtrole.Text.Trim() + "'";
                        arr.Add("1");
                    }
                    else
                    {
                        str += " and user_id='" + txtNricID2.Text.Trim() + "'and Role='" + txtrole.Text.Trim() + "'";
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
            return (str);

        }

        protected void btnItemToDiclare2_Click(object sender, EventArgs e)
        {

        }

        protected void btnHistory2_Click(object sender, EventArgs e)
        {

        }

        protected void txtPassNo2_TextChanged(object sender, EventArgs e)
        {

            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                if (txtPassNo2.Text != "")
                {
                    DBConnectionHandler1 db = new DBConnectionHandler1();
                    SqlConnection cn = db.getconnection();
                    cn.Open();
                    SqlCommand _cmd = new SqlCommand("Select * from checkin_manager where Pass_No=@Pass_No and Role=@Role", cn);
                    _cmd.Parameters.AddWithValue("@Pass_No", txtPassNo2.Text.Trim());
                    _cmd.Parameters.AddWithValue("@Role", txtrole.Text.Trim());
                    SqlDataReader dr = _cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        txtNricID2.Text = dr.GetString(20);
                        txtTeleNo2.Text = dr.GetString(5);
                        txtName2.Text = dr.GetString(2);
                        txtName2.Enabled = false;
                        txtKeyNo2.Text = dr.GetString(8);
                        txtPassNo2.Text = dr.GetString(9);
                        if (dr.GetString(17).ToString() != "")
                        {
                            image3.ImageUrl = dr.GetString(17);
                        }
                        txtAddress2.Text = dr.GetString(3);
                        txtCompanyFrom2.Text = dr.GetString(4);
                        txtRemarks2.Text = dr.GetString(6);
                        txtVehicleNo2.Text = dr.GetString(7);
                        txtpasstype.Text = dr.GetString(10);
                        txtToVisit2.Text = dr.GetString(11);
                        txtVisitorPurpose2.Text = dr.GetString(12);
                        txtItemDeclear2.Text = dr.GetString(13);
                        txtcheckinTime.Text = dr.GetString(14);
                        Panel1.Visible = true;
                        btnCheckOut2.Style.Add("margin-left", "-24em");
                        //========================//
                        dr.Close();
                        dr.Dispose();
                        //========================//
                        cn.Close();
                    }
                    else
                    {
                        MyMasterPage.ShowErrorMessage("Invalid Pass No. ..!");     
                        //lblerror.Visible = true;
                        //lblerror.Text = "Invalid Pass No. ..!";
                        clear();
                        //lblerr1.Visible = true;
                    }
                }
                else
                {
                    MyMasterPage.ShowErrorMessage("Invalid Pass No. ..!");     
                    //lblerror.Visible = true;
                    //lblerror.Text = "Invalid Pass No. ..!";
                    //lblerr1.Visible = true;
                }
                
            }
            catch (Exception exc)
            {
                logger.Info(exc.Message);
            }
        }
    }
}
