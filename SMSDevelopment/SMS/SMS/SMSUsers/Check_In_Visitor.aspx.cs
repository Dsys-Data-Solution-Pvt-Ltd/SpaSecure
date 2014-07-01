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
    public partial class Check_In_Visitor : System.Web.UI.Page
    {        
        DataAccessLayer dal = new DataAccessLayer();
        AdminDAL a = new AdminDAL();
        AdminBLL b = new AdminBLL();
        String column = string.Empty;
        String table = string.Empty;
        String where = string.Empty;
        String where1 = string.Empty;

        int totalSeconds = 0;
        int seconds = 0;
        int minutes = 0;
        string time = "";
        string Location = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                if (!IsPostBack)
                {   //check checkin Time
                    AddNewCheckInRequest objAddCheckinRequest = new AddNewCheckInRequest();
                    checkin objcheckin = new checkin();
                    objcheckin.Checkin_DateTime = DateTime.Now;
                    DateTime dt = (DateTime)objcheckin.Checkin_DateTime;
                 //   Session["dt"] = 3600;



                    txtNricID2.Focus();
                    fillKeyNo();
                    fillPassNo();
                }

                Label1.Visible = false;
                lblerror.Visible = false;
                lblerr1.Visible = false;
                lblerr2.Visible = false;
                lblerr3.Visible = false;
                lblerr4.Visible = false;
                lblerr5.Visible = false;
                lblerr6.Visible = false;
               // Label2.Visible = false;
                if (Session["LCID"] != null)
                {
                    // objchickin.LocationID = int.Parse(Session["LCID"].ToString());

                    Location = Session["LCID"].ToString();
                }
                else
                {
                    MyMasterPage.ShowErrorMessage("Please select Location first!!!");
                    //lblerror.Visible = true;
                    //lblerror.Text = "Please select Location first!!!";
                }
               
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        private void fillPassNo()
        {
            txtPassNo2.Items.Clear();
            SqlParameter[] para = new SqlParameter[0];
            DataTable dt1 = dal.executeprocedure("SP_GetPassFree", para, false);
            if (dt1.Rows.Count > 0)
            {
                txtPassNo2.DataSource = dt1;
                txtPassNo2.DataTextField = "Pass_No";
                txtPassNo2.DataValueField = "Pass_id";
                txtPassNo2.DataBind();
                txtPassNo2.Items.Insert(0, new ListItem(" ", " ", true));
            }
        }
        private void fillKeyNo()
        {
            txtKeyNo2.Items.Clear();
            SqlParameter[] para1 = new SqlParameter[0];
            DataTable dt = dal.executeprocedure("SP_GetKeyFree", para1, false);
            if (dt.Rows.Count > 0)
            {
                txtKeyNo2.DataSource = dt;
                txtKeyNo2.DataTextField = "BunchNo";
                txtKeyNo2.DataValueField = "Key_ID";
                txtKeyNo2.DataBind();
                txtKeyNo2.Items.Insert(0, new ListItem(" ", " ", true));
            }
        }
        #region Timer
        private void checkTime()
        {
            SpaMaster MyMasterPage = (SpaMaster)Page.Master;
            DBConnectionHandler1 db = new DBConnectionHandler1();
            SqlConnection cn = db.getconnection();
            cn.Open();
            SqlCommand cmd = new SqlCommand("select checkin_DateTime,user_name from checkin_manager where NRICno=@NRICno", cn);
            cmd.Parameters.AddWithValue("@NRICno", txtNricID2.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DateTime currentTime = DateTime.Now;
                DateTime DbTime = dr.GetDateTime(0);
                double diff = (currentTime - DbTime).TotalHours;

                if (diff > 6)
                {
                    Label1.Visible = true;
                    MyMasterPage.ShowErrorMessage("Your Time is Over...");
                    ////Label1.Text = "Your Time is Over...";
                    //string Msg = "<script>confirm('Time Over');</script>";
                    //ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "confirm", Msg, false);

                }
            }
            //========================//
            dr.Close();
            dr.Dispose();
            cn.Close();
            //========================//
        }

        private void checktime1()
        {
            SpaMaster MyMasterPage = (SpaMaster)Page.Master;
            Session["dt"] = Convert.ToInt16(Session["dt"]) - 1;
            if (Convert.ToInt16(Session["dt"]) <= 0)
            {
                //Label1.Text = "TimeOut!";
                //Response.Write("<script> alert(\"Time Out\")</script>");
                MyMasterPage.ShowErrorMessage("Your Time is Over...");
                //ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "confirm", Msg, false);
                Session["dt"] = 3600;
            }
            else
            {

                totalSeconds = Convert.ToInt16(Session["dt"]);
                seconds = totalSeconds % 60;
                minutes = totalSeconds / 60;
                time = minutes + ":" + seconds;
                Label1.Text = time;

            }

        }
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            SpaMaster MyMasterPage = (SpaMaster)Page.Master;
            Session["dt"] = Convert.ToInt16(Session["dt"]) - 1;
            if (Convert.ToInt16(Session["dt"]) <= 0)
            {
                MyMasterPage.ShowErrorMessage("Your Time is Over...");
                //Label1.Text = "TimeOut!";
                //Response.Write("<script> alert(\"Time Out\")</script>");
                //string Msg = "<script>confirm('Time Over');</script>";
                //ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "confirm", Msg, false);
                Session["dt"] = 3600;
            }
            else
            {

                totalSeconds = Convert.ToInt16(Session["dt"]);
                seconds = totalSeconds % 60;
                minutes = totalSeconds / 60;
                time = minutes + ":" + seconds;
                Label1.Text = time;

            }

        }
        #endregion

        #region Visitor
        protected void gvVisitorTable_RowDataBound(object sender, GridViewRowEventArgs e)
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
                    gvVisitorTable.Columns[0].FooterText = "Total Records: 20";
                }
            }

            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        protected void gvVisitorTable_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (e.NewPageIndex >= 0)
                {
                    gvVisitorTable.PageIndex = e.NewPageIndex;
                    BindGridWithFilterVisitor();
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        protected void gvVisitorTable_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void BindGridWithFilterVisitor()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                AdminBLL ws = new AdminBLL();
                GetVisitorData objReq = new GetVisitorData();
                string WhereClause = ReturnWhereVisitor();

                if (!string.IsNullOrEmpty(txtNricID2.Text))
                {
                    objReq.NRICno = txtNricID2.Text;
                }
                if (!string.IsNullOrEmpty(WhereClause))
                {
                    objReq.WhereClause = WhereClause;
                }

                GetVisitorDataResponse ret = ws.GetVisitorData(objReq);
                int pageSize = ContextKeys.GRID_PAGE_SIZE;
                gvVisitorTable.PageSize = pageSize;
                gvVisitorTable.DataSource = ret.Visitor;
                gvVisitorTable.DataBind();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        private void BindGridVisitor()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                AdminBLL ws = new AdminBLL();
                GetCheckinData _req = new GetCheckinData();
                GetChiekinDataResponse _resp = ws.Getcheckin(_req);

                int pageSize = ContextKeys.GRID_PAGE_SIZE;
                gvVisitorTable.PageSize = pageSize;
                gvVisitorTable.DataSource = _resp.checkinid;
                gvVisitorTable.DataBind();

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

        }
        private string ReturnWhereVisitor()
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
                        makeWhereClause = " and ";
                        str += " and NRICno='" + txtNricID2.Text + "'";
                        arr.Add("1");
                    }
                    else
                    {
                        str += " and NRICno='" + txtNricID2.Text + "'";
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

            return (str);
        }
        protected void VisitorDisplay_Click(object sender, EventArgs e)
        {
            gvVisitorTable.Visible = true;

            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                BindGridWithFilterVisitor();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        #endregion

        protected void AddCheckInVisitor(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                AddNewCheckInRequest objAddCheckinRequest = new AddNewCheckInRequest();
                checkin objchickin = new checkin();

                
                    SqlParameter[] para = new SqlParameter[1];
                    para[0] = new SqlParameter("@NRICno", SqlDbType.VarChar, 100);
                    para[0].Value = txtNricID2.Text.Trim();
                    DataTable dt1 = dal.executeprocedure("SP_getCheckinIDbyNRICNo", para, false);
                    if (dt1.Rows.Count > 0)
                    {
                        long CHECKIN_ID = Convert.ToInt64(dt1.Rows[0]["checkin_id"].ToString());
                        SqlParameter[] para2 = new SqlParameter[1];
                        para2[0] = new SqlParameter("@checkin_id", SqlDbType.BigInt, 50);
                        para2[0].Value = CHECKIN_ID;
                        DataTable dt3 = dal.executeprocedure("SP_GetCheckoutIDbyCheckInID", para2, false);
                        if (dt3.Rows.Count == 0)
                        {
                            MyMasterPage.ShowErrorMessage("NRIC/FIN No. Already Checked In ..!");
                            //lblerror.Visible = true;
                            //lblerror.Text = "NRIC/FIN No. Already Checked In ..!";
                            //lblerr1.Visible = true;
                            return;
                        }
                    }
               

                 

                 if (Session["CaptureImagePath"] != null)
                 {
                     objchickin.ImagePath = Session["CaptureImagePath"].ToString();
                 }
                 else if (Session["CaptureImage"] != null)
                 {
                     objchickin.ImagePath = Session["CaptureImage"].ToString();
                     //Session["CaptureImage"] = null;
                    // return;
                 }
                
                 if (txtKeyNo2.SelectedValue.Trim() != "")
                 {
                     objchickin.Key_no = txtKeyNo2.Text;
                     UpdateKeyStatus();
                 }
                
                 if (txtTeleNo2.Text.Trim() != "")
                 {

                     objchickin.telephone = txtTeleNo2.Text.Trim();
                     //UpdatePassStatus();
                 }
                 
                 if (txtToVisit2.Text.Trim() != "")
                 {

                     objchickin.to_visit = txtToVisit2.Text.Trim();
                     ////UpdatePassStatus();
                 }
                 
                 if (txtPassNo2.SelectedValue.Trim() != "")
                 {
                     objchickin.Pass_No = txtPassNo2.Text.Trim();
                  UpdatePassStatus();
                 }
                

               if (txtNricID2.Text.Trim() != "")
                {
                    objchickin.NRICno = txtNricID2.Text.Trim();
                   // UpdatePassStatus();
                }
               else
               {
                   objchickin.NRICno = "";
                   MyMasterPage.ShowErrorMessage("please Fill NRICno. first !!");
                   return;
                   //lblerr1.Visible = true;
                   //lblerror.Visible = true;
                   //lblerror.Text = "please Fill NRICno. first !!";
               }

               if (txtNricID2.Text.Trim() != "")
               {

                   objchickin.to_visit = txtToVisit2.Text.Trim();
                   objchickin.Vehicle_No = txtVehicleNo2.Text.Trim();
                   objchickin.telephone = txtTeleNo2.Text.Trim();
                   objchickin.NRICno = txtNricID2.Text.Trim();
                   objchickin.user_name = txtName2.Text.Trim();
                   objchickin.user_address = txtAddress2.Text.Trim();
                   objchickin.company_from = txtCompanyFrom2.Text.Trim();
                   objchickin.remarks = txtRemarks2.Text.Trim();
                   objchickin.pass_type = cmbvisitorPass.Text.Trim();
                   objchickin.purpose = txtVisitorPurpose2.Text.Trim();
                   objchickin.Item_Declear = txtItemDeclear2.Text.Trim();

                   objchickin.Checkin_DateTime = DateTime.Now;
                   //objchickin.Checkin_DateTime = DateTime.Now;
                   objchickin.Role = txtrole.Text;

                   if (Location != null)
                   {
                       objchickin.LocationID = int.Parse(Location);
                   }
                   else
                   {
                       MyMasterPage.ShowErrorMessage("Please select Location first!!!");
                       return;
                       //lblerror.Visible = true;
                       //lblerror.Text = "Please select Location first!!!";
                   }

                   AdminBLL ws = new AdminBLL();
                  ws.AddCheckinVisitor(objchickin);
                   checktime1();
                   UpdatePre_visitors(txtName2.Text, Convert.ToDateTime(DateTime.Now.ToShortDateString()), DateTime.Now.ToShortTimeString().ToString());
                   HttpContext.Current.Items.Add("COMPLETE", "INSERT");
                   MyMasterPage.ShowErrorMessage("Check In Successfully");
               }
               else
               {
                   MyMasterPage.ShowErrorMessage("Please Fill all the fields!!!");
                   //lblerror.Visible = true;
                   //lblerror.Text = "Please Fill all the fields!!!";
               }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        private void UpdateKeyStatus()
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@Key_ID", SqlDbType.Int, 30);
            para[0].Value = txtKeyNo2.SelectedValue.ToString();
            para[1] = new SqlParameter("@Status", SqlDbType.VarChar, 30);
            para[1].Value = "Reserve";
            dal.exeprocedure("SP_UpdateKeyStatusbyKeyID", para);      
        }
        private void UpdatePassStatus()
        { 
            SqlParameter[] para1 = new SqlParameter[2];
            para1[0] = new SqlParameter("@Pass_id", SqlDbType.Int, 30);
            para1[0].Value = txtPassNo2.SelectedValue.ToString();
            para1[1] = new SqlParameter("@Status", SqlDbType.VarChar, 30);
            para1[1].Value = "Reserve";
            dal.exeprocedure("SP_UpdatePassStatusbyPassID", para1);      
        }

        private void UpdatePre_visitors(string name,DateTime fromdate,string time)
        {
            dal.executesql("Update PreRegisteredVisits set AlertStatus = 'OFF' where Name ='" + name + "' and FromDate ='" + fromdate + "' and ExpectedTime ='" + time + "' ");
        }

        #region AddMethod

        String PassOccupied()
        {
            SpaMaster MyMasterPage = (SpaMaster)Page.Master;
            Boolean trueval = false;
            string passvalue = txtPassNo2.Text.Trim();

            if (txtPassNo2.Text.Trim() != "")
            {

                column = "Pass_No";
                table = "checkin_manager";
                where = "Where Pass_No = '" + passvalue + "' ";
                trueval = b.isexistBLL(column, table, where);
                if (trueval)
                {
                    MyMasterPage.ShowErrorMessage("Pass No. is Occupied ..!");
                   
                    //lblerror.Visible = true;
                    //lblerror.Text = "Pass No. is Occupied ..!";
                    //lblerr2.Visible = true;
                    
                }
                return passvalue;
            }
            return passvalue;
        }
        String Addpass()
        {
            SpaMaster MyMasterPage = (SpaMaster)Page.Master;
            Boolean bal = false;
            String ZipRegex = "^[a-z A-Z 0-9]+$";
            if (Regex.IsMatch(txtPassNo2.Text, ZipRegex))
            {
                column = "pass_Type";
                table = "Pass_Master";
                where = "Where Pass_No = '" + txtPassNo2.Text + "' and pass_Type='Visitor'";
                where1 = "where Pass_No = '" + txtPassNo2.Text + "' and pass_Type= 'VIP'";
                bal = b.isexistBLL(column, table, where);
                if (bal)
                {
                    return txtPassNo2.Text;
                }
                bal = b.isexistBLL(column, table, where1);
                if (bal)
                {
                    return txtPassNo2.Text;
                }
                else
                {
                    MyMasterPage.ShowErrorMessage("Invalid Pass No. ..!");
                    //lblerror.Visible = true;
                    //lblerror.Text = "Invalid Pass No. ..!";
                    //lblerr2.Visible = true;
                   // throw new Exception();
                    return "";
                }
            }
            else
            {
                MyMasterPage.ShowErrorMessage("Please Fill Only Numeric Values ..!");
                //lblerror.Visible = true;
                //lblerror.Text = "Please Fill Only Numeric Values ..!";
                //lblerr2.Visible = true;
                return "";
            }
            return "";
        }
        String addkey()
        {
            SpaMaster MyMasterPage = (SpaMaster)Page.Master;
            Boolean bal = false;
            String ZipRegex = "^[a-z A-Z 0-9]+$";
            if (txtKeyNo2.Text != "")
            {
                if (Regex.IsMatch(txtKeyNo2.Text, ZipRegex))
                {

                    column = "Key_no";
                    table = "addnewKey";
                    where = "Where Key_no = '" + txtKeyNo2.Text + "' ";
                    bal = b.isexistBLL(column, table, where);
                    if (bal)
                    {

                        where1 = "where Key_no = '" + txtKeyNo2.Text + "' and Status='Free'";
                        bal = b.isexistBLL(column, table, where1);
                        if (bal)
                        {
                            return txtKeyNo2.Text;
                        }
                        else
                        {
                            MyMasterPage.ShowErrorMessage("Key No. is Occupied ..!");  
                            //lblerror.Visible = true;
                            //lblerror.Text = "Key No. is Occupied ..!";
                            //lblerr4.Visible = true;
                            return "";
                        }

                    }
                    else
                    {
                        MyMasterPage.ShowErrorMessage("Key No. Not Found ..!");  
                        //lblerror.Visible = true;
                        //lblerror.Text = "Key No. Not Found ..!";
                        //lblerr4.Visible = true;
                        return "";
                    }
                }
                else
                {
                    MyMasterPage.ShowErrorMessage("Please Fill Only Numeric Values  ..!");  
                    //lblerror.Visible = true;
                    //lblerror.Text = "Please Fill Only Numeric Values  ..!";
                    //lblerr4.Visible = true;
                    return "";
                }

            }
            return "";
        }
        String AddTelephone()
        {
            SpaMaster MyMasterPage = (SpaMaster)Page.Master;
            if (txtTeleNo2.Text != "")
            {
                String ZipRegex = "^[0-9]+$";
                if (Regex.IsMatch(txtTeleNo2.Text, ZipRegex))
                {
                    return txtTeleNo2.Text;
                }
                else
                {
                    MyMasterPage.ShowErrorMessage("Please Fill Only Numeric Values  ..!");  
                    //lblerror.Visible = true;
                    //lblerror.Text = "Please Fill Only Numeric Values ..!";
                    //lblerr3.Visible = true;
                    return "";
                }
            }
            return "";
        }
        String tovisit()
        {
            SpaMaster MyMasterPage = (SpaMaster)Page.Master;
            String zipRegex = "^[a-z A-Z]+$";

            if (txtToVisit2.Text != "")
            {

                if (Regex.IsMatch(txtToVisit2.Text, zipRegex))
                {
                    return txtToVisit2.Text;
                }
                else
                {
                    MyMasterPage.ShowErrorMessage("Please Fill String Values ..!");  
                    //lblerror.Visible = true;
                    //lblerror.Text = "Please Fill String Values ..!";
                    //lblerr6.Visible = true;
                    //throw new Exception();
                    return "";
                }
            }
            else
            {
                MyMasterPage.ShowErrorMessage("Please Fill To Visit Values ..!");  
                //lblerror.Visible = true;
                //lblerror.Text = "Please Fill To Visit Values ..!";
                //lblerr6.Visible = true;
                //throw new Exception();
                return "";

            }
            return "";

        }
        String addVehicle()
        {
            SpaMaster MyMasterPage = (SpaMaster)Page.Master;
            String ZipRegex = "^[0-9 a-z A-Z]+$";
            if (txtVehicleNo2.Text != "")
            {
                if (Regex.IsMatch(txtVehicleNo2.Text, ZipRegex))
                {
                    column = "Vehicle_No";
                    table = "checkin_manager";
                    where = "Where Vehicle_No = '" + txtVehicleNo2.Text + "' ";
                    if (b.isexistBLL(column, table, where))
                    {
                        MyMasterPage.ShowErrorMessage("Vehicle No. Already Used ..!");  
                        //lblerror.Visible = true;
                        //lblerror.Text = "Vehicle No. Already Used ..!";
                        //lblerr5.Visible = true;
                        return "";
                    }
                    else
                    {
                        return txtVehicleNo2.Text;
                    }
                }
                else
                {
                    MyMasterPage.ShowErrorMessage("Invalid Vehicle No. ..!");  
                    //lblerror.Visible = true;
                    //lblerror.Text = "Invalid Vehicle No. ..!";
                    //lblerr5.Visible = true;
                    return "";
                }
            }
            return "";
        }
        String addimage()
        {
            Boolean ok = false;
            string imageloc = string.Empty;
            string ext = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
            string[] ar = { ".jpg", ".gif", ".jpeg", ".png" };
            for (int i = 0; i < ar.Length; i++)
            {
                if (ext == ar[i])
                {
                    ok = true;
                    break;
                }
            }

            if (ok)
            {
                string path = Server.MapPath("~/ImageUpload/");
                FileUpload1.PostedFile.SaveAs(path + FileUpload1.FileName);
                imageloc = Convert.ToString(path + FileUpload1.FileName);
            }

            return "";

        }


        #endregion

        private void clearAll()
        {
            txtNricID2.Text = "";
            txtName2.Text = "";
            txtAddress2.Text = "";
            txtCompanyFrom2.Text = "";
            txtToVisit2.Text = "";
            txtVisitorPurpose2.Text = "";
            txtVehicleNo2.Text = "";
            txtRemarks2.Text = "";
            txtPassNo2.Text = "";
            txtKeyNo2.Text = "";
            txtTeleNo2.Text = "";
            txtItemDeclear2.Text = "";
            cmbvisitorPass.Text = "";
            txtName2.Enabled = true;
        }

        protected void btnClear2_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                clearAll();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void txtNricID2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                if (txtNricID2.Text.Trim() != "")
                {
                    SqlParameter[] para = new SqlParameter[1];
                    para[0] = new SqlParameter("@NRICno", SqlDbType.VarChar, 100);
                    para[0].Value = txtNricID2.Text.Trim();

                    DataTable dt = dal.executeprocedure("SP_getCheckinIDbyNRICNo", para, false);
                    if (dt.Rows.Count > 0)
                    {
                        lblerror.Visible = true;
                        MyMasterPage.ShowErrorMessage("Already Checked In ..!");     
                        //lblerror.Text = "Already Checked In ..!";
                        checkTime();
                    }
                    else
                    {
                        lblerror.Visible = false;
                        SqlParameter[] para1 = new SqlParameter[1];
                        para1[0] = new SqlParameter("@NRICno", SqlDbType.VarChar, 100);
                        para1[0].Value = txtNricID2.Text.Trim();
                        DataTable dt1 = dal.executeprocedure("SP_getCheckOtbyNRICNo", para1, false);
                        if (dt1.Rows.Count > 0)
                        {
                            txtNricID2.Text = dt1.Rows[0]["NRICno"].ToString();
                            txtName2.Text = dt1.Rows[0]["user_name"].ToString();
                            txtPassNo2.Items.Insert(0,dt1.Rows[0]["pass_no"].ToString());
                            txtKeyNo2.Items.Insert(0, dt1.Rows[0]["key_no"].ToString());
                            txtName2.Enabled = false;
                            txtAddress2.Text = dt1.Rows[0]["user_address"].ToString();
                            txtTeleNo2.Text = dt1.Rows[0]["telephone"].ToString();
                            txtCompanyFrom2.Text = dt1.Rows[0]["company_from"].ToString();
                            Image3.ImageUrl = dt1.Rows[0]["user_image"].ToString();
                            Session["CaptureImagePath"] = dt1.Rows[0]["user_image"].ToString();
                            txtToVisit2.Text = dt1.Rows[0]["to_visit"].ToString();
                            BindGridWithFilterVisitor();
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }


    }
}
