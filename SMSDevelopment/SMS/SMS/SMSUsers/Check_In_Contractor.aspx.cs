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
    public partial class Check_In_Contractor : System.Web.UI.Page
    {
        
        DataAccessLayer dal = new DataAccessLayer();
        AdminDAL a = new AdminDAL();
        AdminBLL b = new AdminBLL();
        String column = string.Empty;
        String table = string.Empty;
        String where = string.Empty;
        String where1 = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            SpaMaster SM = (SpaMaster)Page.Master;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                txtNricID3.Focus();
                lblerror.Visible = false;
            
                lblerr1.Visible = false;
                lblerr2.Visible = false;
               // lblerr3.Visible = false;
                lblerr4.Visible = false;
                lblerr5.Visible = false;
                lblerr6.Visible = false;

                if (!IsPostBack)
                {
                    fillKeyNo();
                    fillPassNo();
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
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private void fillPassNo()
        {
            txtPassNo3.Items.Clear();           
            SqlParameter[] para = new SqlParameter[0];
            DataTable dt1 = dal.executeprocedure("SP_GetPassFree", para, false);
            if (dt1.Rows.Count > 0)
            {
                txtPassNo3.DataSource = dt1;
                txtPassNo3.DataTextField = "Pass_No";
                txtPassNo3.DataValueField = "Pass_id";
                txtPassNo3.DataBind();
                txtPassNo3.Items.Insert(0, new ListItem(" ", " ", true));
            }
        }
        private void fillKeyNo()
        {
            txtKeyNo3.Items.Clear();           
            SqlParameter[] para1 = new SqlParameter[0];
            DataTable dt = dal.executeprocedure("SP_GetKeyFree", para1, false);
            if (dt.Rows.Count > 0)
            {
                txtKeyNo3.DataSource = dt;
                txtKeyNo3.DataTextField = "BunchNo";
                txtKeyNo3.DataValueField = "Key_ID";
                txtKeyNo3.DataBind();
                txtKeyNo3.Items.Insert(0, new ListItem(" ", " ", true));
            }
        }

        #region Contractor
        protected void ContractorDisplay_Click(object sender, EventArgs e)
        {
            gvContractorTable.Visible = true;

            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                BindGridWithFilterContractor();

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
        private void BindGridWithFilterContractor()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                AdminBLL ws = new AdminBLL();
                GetContractorData objReq = new GetContractorData();
                string WhereClause = ReturnWhereContractor();

                if (!string.IsNullOrEmpty(txtNricID3.Text))
                {
                    objReq.user_id = txtNricID3.Text;
                }
                if (!string.IsNullOrEmpty(WhereClause))
                {
                    objReq.WhereClause = WhereClause;
                }


                GetContractorDataResponse ret = ws.GetContractorData2(objReq);
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

                if (txtNricID3.Text.Trim() != "")
                {
                    if (arr.Count == 1)
                    {
                        makeWhereClause = " and ";
                        str += " and NRICno='" + txtNricID3.Text.Trim() + "'";
                        arr.Add("1");
                    }
                    else
                    {
                        str += " and NRICno='" + txtNricID3.Text.Trim() + "'";
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
            return (str);

        }
        #endregion

        protected void AddCheckInContractor(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                SpaMaster SM = (SpaMaster)Page.Master;
                AddNewCheckInRequest objAddCheckinRequest = new AddNewCheckInRequest();
                checkin objchickin = new checkin();
                String ZipRegex = "^[a-z A-Z 0-9]+$";
                if (txtNricID3.Text.Trim() != "")
                {
                    SqlParameter[] para = new SqlParameter[1];
                    para[0] = new SqlParameter("@NRICno", SqlDbType.VarChar, 100);
                    para[0].Value = txtNricID3.Text.Trim();
                    DataTable dt1 = dal.executeprocedure("SP_getCheckinIDbyNRICNo", para, false);
                    if (dt1.Rows.Count > 0)
                    {
                        long CHECKIN_ID = Convert.ToInt64(dt1.Rows[0]["checkin_id"].ToString());
                        SqlParameter[] para2 = new SqlParameter[1];
                        para2[0] = new SqlParameter("@checkin_id", SqlDbType.BigInt, 100);
                        para2[0].Value = CHECKIN_ID;
                        DataTable dt3 = dal.executeprocedure("SP_GetCheckoutIDbyCheckInID", para2, false);
                        if (dt3.Rows.Count == 0)
                        {
                          //  lblerror.Visible = true;
                          //  lblerror.Text = "NRIC/FIN No. Already Checked In ..!";
                          //  lblerr1.Visible = true;
                            SM.ShowErrorMessage("NRIC/FIN No. Already Checked In ..!");
                            return;
                            // throw new Exception();
                        }
                    }
                }
                else
                {
                    objchickin.NRICno = "";
                   // lblerr2.Visible = true;
                   // lblerror.Visible = true;
                  //  lblerror.Text = "Please Fill NRIC no.!!";
                    SM.ShowErrorMessage("Please Fill NRIC no.!!");
                    return;
                }
                    if (Session["CaptureImagePath"] != null)
                    {
                        objchickin.ImagePath = Session["CaptureImagePath"].ToString();
                    }
                    else if (Session["CaptureImage"] != null)
                    {

                        objchickin.ImagePath = Session["CaptureImage"].ToString();
                        //Session["CaptureImage"] = null;
                    }
                   
                    if (Session["LCID"] != null)
                    {
                        objchickin.LocationID = int.Parse(Session["LCID"].ToString());
                       // Session["LCID"] = null;
                    }
                    
                    if (txtKeyNo3.Text.Trim() != "")
                    {
                        objchickin.Key_no = txtKeyNo3.Text;
                        UpdateKeyStatus();
                    }
                    else
                    {
                        objchickin.Key_no = "";
                        
                    }
                    if (txtPassNo3.Text.Trim() != "")
                    {

                        objchickin.Pass_No = txtPassNo3.Text.Trim();
                        UpdatePassStatus();
                    }
                   
                    if (txtTeleNo3.Text.Trim() != "")
                    {
                        
                        objchickin.telephone = txtTeleNo3.Text.Trim();
                        //UpdatePassStatus();
                    }
                    else
                    {
                        objchickin.telephone = "";
                        
                    }
                    if (txtName3.Text.Trim() != "")
                    {

                        objchickin.user_name = txtName3.Text.Trim();
                        //UpdatePassStatus();
                    }
                   
                    if (txtServingAt1.Text.Trim() != "")
                    {

                        objchickin.to_visit = txtServingAt1.Text.Trim();
                        //UpdatePassStatus();
                    }
                    else
                    {
                        objchickin.to_visit = "";
                       
                    }
                    if (txtNricID3.Text.Trim() != "")
                    {
                        //objchickin.Pass_No = txtPassNo3.Text;//PassOccupied();
                        objchickin.to_visit = txtServingAt1.Text;// tovisit();
                        objchickin.Vehicle_No = txtVehicleNo3.Text;//addVehicle();
                        objchickin.telephone = txtTeleNo3.Text;//AddTelephone();

                        objchickin.NRICno = txtNricID3.Text;
                        objchickin.user_name = txtName3.Text;
                        objchickin.user_address = txtAddress3.Text;
                        objchickin.company_from = txtCompanyfrom3.Text;
                        objchickin.remarks = txtRemarks3.Text;
                        objchickin.pass_type = cmbContractorPass.Text;
                        objchickin.purpose = txtpurpose.Text;
                        objchickin.Item_Declear = txtItemDeclear3.Text;
                        /*string time = string.Empty;
                        time = ConfigurationManager.AppSettings.Get("SPATime");
                        double newtime = Convert.ToDouble(time);
                        objchickin.Checkin_DateTime = DateTime.Now.AddHours(newtime);*/
                        objchickin.Checkin_DateTime = DateTime.Now;
                        objchickin.Role = txtrole.Text;

                        AdminBLL ws = new AdminBLL();
                        // ws.AddCheckinVisitor(objchickin);
                        ws.AddCheckinContractor(objchickin);

                        HttpContext.Current.Items.Add("COMPLETE", "INSERT");
                        SM.ShowErrorMessage("Contractor Check In successfully");
                        return;
                       // Server.Transfer("..//SMSADMIN//AlertUpdateComplete.aspx");
                    }
                    else
                    {
                       // lblerr3.Visible = true;
                        //lblerror.Visible = true;
                        //lblname.Visible = true;
                        //lblerror.Text = "Please Fill All the (*) fields!!";
                        SM.ShowErrorMessage("Please Fill All the (*) fields!!");
                        return;
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
            para[0].Value = txtKeyNo3.SelectedValue.ToString();
            para[1] = new SqlParameter("@Status", SqlDbType.VarChar, 30);
            para[1].Value = "Reserve";
            dal.exeprocedure("SP_UpdateKeyStatusbyKeyID", para);          
        }
        private void UpdatePassStatus()
        {
            SqlParameter[] para1 = new SqlParameter[2];
            para1[0] = new SqlParameter("@Pass_id", SqlDbType.Int, 30);
            para1[0].Value = txtPassNo3.SelectedValue.ToString();
            para1[1] = new SqlParameter("@Status", SqlDbType.VarChar, 30);
            para1[1].Value = "Reserve";
            dal.exeprocedure("SP_UpdatePassStatusbyPassID", para1);           
        }
            


        #region AddMethod

        String PassOccupied()
        {
            SpaMaster SM = (SpaMaster)Page.Master;
            string passvalue = txtPassNo3.Text.Trim();
            if (txtPassNo3.Text.Trim() != "")
            {
                //string passvalue = Addpass();

                column = "Pass_No";
                table = "checkin_manager";
                where = "Where Pass_No = '" + passvalue + "' ";

                if (b.isexistBLL(column, table, where))
                {
                    //lblerror.Visible = true;
                    //lblerror.Text = "Pass No. is Occupied ..!";
                    //lblerr2.Visible = true;
                    SM.ShowErrorMessage("Pass No. is Occupied ..!");
                    throw new Exception();
                }
                return passvalue;
            }
            return passvalue;
        }
        String Addpass()
        {
            SpaMaster SM = (SpaMaster)Page.Master;
            Boolean bal = false;
            String ZipRegex = "^[a-z A-Z 0-9]+$";
            if (Regex.IsMatch(txtPassNo3.Text, ZipRegex))
            {
                column = "pass_Type";
                table = "Pass_Master";
                where = "Where Pass_No = '" + txtPassNo3.Text + "' and pass_Type='Contractor'";

                bal = b.isexistBLL(column, table, where);
                if (bal)
                {
                    return txtPassNo3.Text;
                }

                else
                {
                    //lblerror.Visible = true;
                    //lblerror.Text = "Invalid Pass No. ..!";
                    //lblerr2.Visible = true;
                    SM.ShowErrorMessage("Invalid Pass No. ..!");
                    throw new Exception();
                }
            }
            else
            {
                //lblerror.Visible = true;
                //lblerror.Text = "Please Fill Only Numeric Values ..!";
                //lblerr2.Visible = true;
                SM.ShowErrorMessage("Please Fill Only Numeric Values ..!");
                throw new Exception();
            }
            return "";
        }
        //void autogen()
        //{
        //    keyvalue++;
        //    SqlConnection cn;
        //    AdminDAL a = new AdminDAL();
        //    cn = a.getconnection();
        //    String k;
        //    String m;
        //    k = "update Autogen set KeyValue=" + keyvalue + " where Number = 1";
        //    SqlCommand cmd = new SqlCommand(k, cn);
        //    cmd.ExecuteNonQuery();

        //}
        String addVehicle()
        {
            SpaMaster SM = (SpaMaster)Page.Master;
            String ZipRegex = "^[0-9 a-z A-Z]+$";

            if (txtVehicleNo3.Text != "")
            {
                if (Regex.IsMatch(txtVehicleNo3.Text, ZipRegex))
                {
                    column = "Vehicle_No";
                    table = "checkin_manager";
                    where = "Where Vehicle_No = '" + txtVehicleNo3.Text + "' ";
                    if (b.isexistBLL(column, table, where))
                    {
                        //lblerror.Visible = true;
                        //lblerror.Text = "Vehicle No. Already Used ..!";
                        //lblerr5.Visible = true;
                        SM.ShowErrorMessage("Vehicle No. Already Used ..!");
                        throw new Exception();
                    }
                    else
                    {
                        return txtVehicleNo3.Text;
                    }
                }
                else
                {
                    //lblerror.Visible = true;
                    //lblerror.Text = "Invalid Vehicle No. ..!";
                    //lblerr5.Visible = true;
                    SM.ShowErrorMessage("Invalid Vehicle No. ..!");
                    throw new Exception();
                }
            }
            return "";
        }
        String addkey()
        {
            SpaMaster SM = (SpaMaster)Page.Master;
            Boolean bal = false;
            String ZipRegex = "^[a-z A-Z 0-9]+$";
            if (txtKeyNo3.Text.Trim() != "")
            {
                if (Regex.IsMatch(txtKeyNo3.Text, ZipRegex))
                {

                    column = "Key_no";
                    table = "addnewKey";
                    where = "Where Key_no = '" + txtKeyNo3.Text + "' ";
                    bal = b.isexistBLL(column, table, where);
                    if (bal)
                    {

                        where1 = "where Key_no = '" + txtKeyNo3.Text + "' and Status='Free'";
                        bal = b.isexistBLL(column, table, where1);
                        if (bal)
                        {
                            return txtKeyNo3.Text;
                        }
                        else
                        {
                            //lblerror.Visible = true;
                            //lblerror.Text = "Key No. is Occupied ..!";
                            //lblerr4.Visible = true;
                            SM.ShowErrorMessage("Key No. is Occupied ..!");
                            throw new Exception();
                        }

                    }
                    else
                    {
                        //lblerror.Visible = true;
                        //lblerror.Text = "Key No. Not Found ..!";
                        //lblerr4.Visible = true;
                        SM.ShowErrorMessage("Key No. Not Found ..!");
                        throw new Exception();
                    }
                }
                else
                {
                    //lblerror.Visible = true;
                    //lblerror.Text = "Please Fill Only Numeric Values  ..!";
                    //lblerr4.Visible = true;
                    SM.ShowErrorMessage("Please Fill Only Numeric Values  ..!");
                    throw new Exception();
                }

            }
            return "";
        }
        String addimage()
        {
            SpaMaster SM = (SpaMaster)Page.Master;
            Boolean ok = false;
            String imageloc = string.Empty;
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
                return imageloc;
            }
            else
            {
            }

            return "";
        }
        String tovisit()
        {
            SpaMaster SM = (SpaMaster)Page.Master;
            String zipRegex = "^[a-z A-Z]+$";

            if (txtServingAt1.Text != "")
            {

                if (Regex.IsMatch(txtServingAt1.Text, zipRegex))
                {
                    return txtServingAt1.Text;
                }
                else
                {
                    //lblerror.Visible = true;
                    //lblerror.Text = "Please Fill Alphabets Values ..!";
                    //lblerr6.Visible = true;
                    SM.ShowErrorMessage("Please Fill Alphabets Values ..!");
                    throw new Exception();
                }
            }
            else
            {
                //lblerror.Visible = true;
                //lblerror.Text = "Please Fill To Visit Values ..!";
                //lblerr6.Visible = true;
                SM.ShowErrorMessage("Please Fill To Visit Values ..!");
                throw new Exception();

            }
            return "";

        }
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
                    //lblerr3.Visible = true;
                    throw new Exception();
                }
            }
            return "";
        }

        #endregion

        protected void btnClear3_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                txtNricID3.Text = "";
                txtCompanyfrom3.Text = "";
                txtTeleNo3.Text = "";
                txtServingAt1.Text = "";
                txtVehicleNo3.Text = "";
                txtRemarks3.Text = "";               
                txtAddress3.Text = "";
                txtItemDeclear3.Text = "";

                txtpurpose.Text = "";
                cmbContractorPass.Text = "";
                txtName3.Text = "";
                txtPassNo3.Text = "";
                txtKeyNo3.Text = "";
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void txtNricID3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SpaMaster SM = (SpaMaster)Page.Master;
                if (txtNricID3.Text.Trim() != "")
                {
                    SqlParameter[] para = new SqlParameter[1];
                    para[0] = new SqlParameter("@NRICno", SqlDbType.VarChar, 100);
                    para[0].Value = txtNricID3.Text.Trim();
                    DataTable dt = dal.executeprocedure("SP_getCheckinIDbyNRICNo", para, false);
                    if (dt.Rows.Count > 0)
                    {
                        //lblerror.Visible = true;
                        //lblerror.Text = "Already Checked In ..!";
                        SM.ShowErrorMessage("Already Checked In ..!");
                    }
                    else
                    {
                        SqlParameter[] para1 = new SqlParameter[1];
                        para1[0] = new SqlParameter("@NRICno", SqlDbType.VarChar, 100);
                        para1[0].Value = txtNricID3.Text.Trim();
                        DataTable dt1 = dal.executeprocedure("SP_getCheckOtbyNRICNo", para1, false);
                        if (dt1.Rows.Count > 0)
                        {
                            txtNricID3.Text = dt1.Rows[0]["NRICno"].ToString();
                            txtName3.Text = dt1.Rows[0]["user_name"].ToString();
                            txtName3.Enabled = false;
                            txtAddress3.Text = dt1.Rows[0]["user_address"].ToString();
                            txtTeleNo3.Text = dt1.Rows[0]["telephone"].ToString();
                            txtCompanyfrom3.Text = dt1.Rows[0]["company_from"].ToString();
                            Image3.ImageUrl = dt1.Rows[0]["user_image"].ToString();
                            Session["CaptureImagePath"] = dt1.Rows[0]["user_image"].ToString();
                            txtServingAt1.Text = dt1.Rows[0]["to_visit"].ToString();                            
                            BindGridWithFilterContractor();
                        }
                       
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void btnCheckIn3_Click(object sender, EventArgs e)
        {

        }

    }
 }