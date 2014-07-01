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
using System.Data.SqlClient;
using System.Collections.Generic;

using log4net;
using log4net.Config;

using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.Services.DataService;
using SMS.SMSAppUtilities;
using SMS.BusinessEntities;
using Telerik.Web.UI;
using System.Globalization;
using SMS.master;
namespace SMS.SMSAdmin
{
    public partial class eventplanneraspx : System.Web.UI.Page
    {
        int p = 0;
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd;
        DataAccessLayer dal = new DataAccessLayer();
        SpaMaster SM = new SpaMaster();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ManagementRole"].ToString().ToLower().Contains("superuser"))//change by rakesh
            {
                pnn.Visible = false;
            }
            else
            {
               pnn.Visible = true;
            }
         
         log4net.ILog logger = log4net.LogManager.GetLogger("File");
         try
         {                     
                if (!IsPostBack)
                {
                    fillevent();
                    fillEventType();
                    if (Session["ManagementRole"].ToString().ToLower() == "superuser")
                    {
                        fillLocation();
                        getLocationName();
                    }
                    else
                    {
                        getLocationNameById(Session["LCID"].ToString());
                    }
                    fillsupervisor();
                 //   BindGridWithFilter();
                }
                string ctrlname = Page.Request.Params.Get("__EVENTTARGET");
                string ctrlname1 = Page.Request.Params.Get("__eventargument");
                if (ctrlname != null)
                {
                    string controlname = ctrlname;//.Split('$')[ctrlname.Split('$').Length - 1].ToString();
                    if (!controlname.Contains("imdAdd") && !controlname.Contains("imgUpdate") && !controlname.Contains("imgDelete") && !controlname.Contains("CheckBox1"))
                    {
                        if (controlname.ToUpper().Contains("gvNewEventSearch1".ToUpper()))
                        {
                            if (ctrlname1 != null)
                            {
                                if (ctrlname1.Contains("RowClick"))
                                { }
                                else if (ctrlname1.ToUpper().Contains("FIRECOMMAND") || ctrlname1 == "")
                                {
                                    BindGridWithFilter();
                                }
                                else
                                {

                                }

                            }
                        }
                    }
                }
                else
                {
                    BindGridWithFilter();
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
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
            SqlParameter[] para = new SqlParameter[0];
            DataTable dsLocation = dal.executeprocedure("sp_FillLocationName", para, false);
            if (dsLocation.Rows.Count > 0)
            {
                drlLocation.DataSource = dsLocation;
                drlLocation.DataTextField = "Location_name";
                drlLocation.DataValueField = "Location_name";
                drlLocation.DataBind();
                drlLocation.Items.Insert(0, " ");
            } 
        }

        private void getLocationNameById(string Name)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Location_id", Name);
            DataTable dsLocationName = dal.executeprocedure("sp_getLocationNameByID", para, false);
            if (dsLocationName.Rows.Count > 0)
            {
                drlLocation.Items.Add(dsLocationName.Rows[0][0].ToString().Trim());
            }
        }

      
        private void fillevent()
        {
            string ID = "eventtype";
            SqlParameter[] para1 = new SqlParameter[1];
            para1[0] = new SqlParameter("@ID", ID);
            DataTable dt = dal.executeprocedure("sp_getLogvaluebyID", para1, true);
            if (dt.Rows.Count > 0)
            {

                ddlEventType.DataSource = dt;
                ddlEventType.DataTextField = "Description";
                ddlEventType.DataValueField = "Description";
                ddlEventType.DataBind();
                ddlEventType.Items.Insert(0, new ListItem("-Select-", " "));
            }

            //string ID = "eventtype";
            //SqlParameter[] para1 = new SqlParameter[1];
            //para1[0] = new SqlParameter("@ID", ID);

            //DataTable dt1 = dal.executeprocedure("sp_getLogvaluebyID", para1, true);          
            //if (dt1.Rows.Count > 0)
            //{
            //    for (int k = 0; k < dt1.Rows.Count; k++)
            //    {
            //       ddlEventType.Items.Add(dt1.Rows[k][0].ToString().Trim());
            //    }
            //}
        }


        protected void gvNewEvent_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //JS for delete btn
                    ImageButton Delete = (ImageButton)e.Row.FindControl("btnDelete");
                    Delete.Attributes.Add("onclick", "javascript:return " +
                        "confirm('Are you sure to delete this record?')");
                }
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    gvNewEventSearch.Columns[0].FooterText = "Total Records: 20";
                }
            }
           
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void gvNewEvent_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                string _BTId = Convert.ToString(e.CommandArgument);

                if (e.CommandName == "EditRow")
                {
                    HttpContext.Current.Items.Add(ContextKeys.CTX_UPDATE_URL, Request.Url.ToString());
                    HttpContext.Current.Items.Add(ContextKeys.CTX_BT_ID, _BTId);
                    Server.Transfer("EventUpdate.aspx");
                }
                if (e.CommandName == "DeleteRow")
                {
                    DeleteItem(_BTId);
                }
            }
           
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private void DeleteItem(string argEventId)
        { 
        log4net.ILog logger = log4net.LogManager.GetLogger("File");
        try
        {
           
                if (!string.IsNullOrEmpty(argEventId))
                {
                    AdminBLL ws = new AdminBLL();
                    DeleteEventPlannerRequest _req = new DeleteEventPlannerRequest();

                    _req.EventID = argEventId.ToString();

                    ws.DeleteEvent(_req);
                    HttpContext.Current.Items.Add(ContextKeys.CTX_COMPLETE, "DELETE");
                   //  Server.Transfer("AlertUpdateComplete.aspx");
                }
           
        }
        catch (Exception ex)
        {
            logger.Info(ex.Message);
        }
        }

        protected void gvNewEvent_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (e.NewPageIndex >= 0)
                {
                    if (e.NewPageIndex >= 0)
                    {
                        gvNewEventSearch.PageIndex = e.NewPageIndex;
                        AdminBLL ws = new AdminBLL();
                        GetDataEvent _req = new GetDataEvent();
                        GetDataEventResponse _resp = ws.GetEventData(_req);

                        int pageSize = ContextKeys.GRID_PAGE_SIZE;
                        gvNewEventSearch.PageSize = pageSize;
                        gvNewEventSearch.DataSource = _resp.Eventid;
                        gvNewEventSearch.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnAddNewEvent_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Response.Redirect("../SMSUsers/EventHandling.aspx");
            }
           
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

        }

        protected void btnSearch1_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                BindGridWithFilter();
            }
           
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
         
        }

        private void BindGridWithFilter()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                AdminBLL ws = new AdminBLL();
                GetDataEvent objReq = new GetDataEvent();
                getLocationIDByName(drlLocation.Text.Trim());
                string WhereClause = ReturnWhere();

                if (!string.IsNullOrEmpty(txtpersonincharg.Text))
                {
                    objReq.Event_ID = txtpersonincharg.Text;
                }
                if (!string.IsNullOrEmpty(txtdatefrom.Text))
                {
                    if (string.IsNullOrEmpty(txtdateto.Text))
                    {
                        objReq.Date_From = txtdatefrom.Text;
                    }
                }
                if (!string.IsNullOrEmpty(txtdateto.Text))
                {
                    if (!string.IsNullOrEmpty(txtdatefrom.Text))
                    {
                        objReq.Date_From = txtdatefrom.Text;
                        objReq.Date_From = txtdateto.Text;
                    }
                }
                if (!string.IsNullOrEmpty(drlLocation.SelectedValue))
                {
                    objReq.Location_id = drlLocation.Text;
                }
                if (!string.IsNullOrEmpty(ddlEventType.Text))
                {
                    objReq.Event_Type = ddlEventType.Text;
                }
                if (!string.IsNullOrEmpty(WhereClause))
                {
                    objReq.WhereClause = WhereClause;
                }

                GetDataEventResponse ret = ws.GetEventData(objReq);
                int pageSize = ContextKeys.GRID_PAGE_SIZE;
               // gvNewEventSearch.PageSize = pageSize;
                gvNewEventSearch1.DataSource = ret.Eventid;
                gvNewEventSearch1.DataBind();

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private string ReturnWhere()
        {
            string str = string.Empty;
            string makeWhereClause = string.Empty;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                List<String> arr = new List<String>();
                arr.Add("test");

                if (txtpersonincharg.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        makeWhereClause = " where ";
                        str += " where Incharg_Name ='" + txtpersonincharg.Text + "'";
                        arr.Add("1");
                    }
                    else
                    {
                        str += " and Incharg_Name ='" + txtpersonincharg.Text + "'";
                    }
                }
              
                if (drlLocation.Text.Trim() != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where Location_id='" + SearchLocID.Text + "' ";
                        arr.Add("2");
                    }
                    else
                    {
                        str += " and Location_id='" + SearchLocID.Text + "' ";
                    }
                }
                if (ddlEventType.Text.Trim() != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where Event_Type='" + ddlEventType.Text + "'";
                        arr.Add("3");
                    }
                    else
                    {
                        str += " and Event_Type='" + ddlEventType.Text + "'";
                    }
                }

                if (txtdateto.Text.Trim() != "" && txtdatefrom.Text.Trim() != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where Date_From BETWEEN '" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                        arr.Add("4");
                    }
                    else
                    {
                        str += " and Date_From BETWEEN '" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                    }
                }
                if (txtdatefrom.Text.Trim() != "" && txtdateto.Text.Trim() == "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where Date_From='" + txtdatefrom.Text + "'";
                        arr.Add("5");
                    }
                    else
                    {
                        str += " and Date_From='" + txtdatefrom.Text + "'";
                    }
                }

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
            return (str);
        }



        private int GetLocationIDbyName(string Name)
        {
            int id = 0;
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Location_name", Name);
            DataTable dsLocationid = dal.executeprocedure("sp_GetLocationIDbyName", para, false);
            if (dsLocationid.Rows.Count > 0)
            {
                id = Convert.ToInt32(dsLocationid.Rows[0][0].ToString().Trim());
                return id;
            }
            return id;
        }

        private void BindGrid()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                AdminBLL ws = new AdminBLL();
                GetDataEvent _req = new GetDataEvent();
                GetDataEventResponse _resp = ws.GetEventData(_req);

                int pageSize = ContextKeys.GRID_PAGE_SIZE;
                gvNewEventSearch.PageSize = pageSize;
                gvNewEventSearch.DataSource = _resp.Eventid;
                gvNewEventSearch.DataBind();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        
        protected void btnCanel_Click(object sender, EventArgs e)
        {
           log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                txtpersonincharg.Text = "";
                //drlLocation.Items.Add("");
                getLocationName();
                //ddlEventType.Items.Add("");
                txtdatefrom.Text = "";
                txtdateto.Text = "";
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

       
        
        
        
        #region Add
        protected void ImgAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                           SpaMaster MyMasterPage = (SpaMaster)Page.Master;

                                            DataTable dtAddEvents = AdminDAL.Checkmenu(Session["RoleID"].ToString(), "24");

                                            if (dtAddEvents.Rows.Count > 0)
                                            {

                                                this.ModalPopupAdd.Show();
                                            }
                                            else
                                            {
                                                
                                                MyMasterPage.ShowErrorMessage("You Do Not Have permission..!");   
          

                                            }



            }
            catch (Exception ex)
            {
                logger.Info("AdminCappAsset(AssertImgUpdate_Click):" + ex.Message);
            }

        }
        protected void cmdbuttonadd_Click(object sender, EventArgs e)
        {
            SpaMaster MyMasterPage = (SpaMaster)Page.Master;

           log4net.ILog logger = log4net.LogManager.GetLogger("File");
           try
           {
               AddNewEventmanRequest objAddEventmanRequest = new AddNewEventmanRequest();
               eventAdmin objeventman = new eventAdmin();
               DateTime datetime;
               if (txtNricNo.Text.Trim() != "" && txtname.Text.Trim() != "")
               {
                  // objeventman.Date_From = DateTime.TryParse(txtFromDate.Text, out datetime) ? (DateTime?)datetime : null; 
                  // objeventman.Date_to = DateTime.TryParse(txttoDate.Text, out datetime) ? (DateTime?)datetime : null;
                   if (txtFromDate.Text.Length == 0)
                   {
                       objeventman.Date_From = null;
                   }
                   else
                   {
                       DateTimeFormatInfo dtfi = new DateTimeFormatInfo();
                       dtfi.ShortDatePattern = "MM/dd/yyyy";
                       dtfi.DateSeparator = "/";
                       DateTime objDate = Convert.ToDateTime(txtFromDate.Text, dtfi);
                       objeventman.Date_From = objDate;
                   }

                   if (txttoDate.Text.Length == 0)
                   {
                       objeventman.Date_to = null;
                   }
                   else
                   {
                       DateTimeFormatInfo dtfi = new DateTimeFormatInfo();
                       dtfi.ShortDatePattern = "MM/dd/yyyy";
                       dtfi.DateSeparator = "/";
                       DateTime objDate = Convert.ToDateTime(txttoDate.Text, dtfi);
                       objeventman.Date_to = objDate;                                        
                   }
                   
                   
                   

                   objeventman.Event_Type = drlEventType.Text.Trim();

                   objeventman.Start_time = TimeSelector1.Date.TimeOfDay.ToString();
                   objeventman.End_time = TimeSelector2.Date.TimeOfDay.ToString();


                   objeventman.Special_Requirment = txtspecialreq.Text;
                   objeventman.Guard_Requirment = txtgaurdreq.Text;
                   objeventman.Special_Duty = txtdutygaurd.Text;
                   objeventman.Incharg_Name = txtname.Text.Trim();
                   objeventman.Incharg_NricNo = txtNricNo.Text.Trim();
                   objeventman.Incharg_position = txtPosition.Text;
                   objeventman.Incharg_ContactNo = txtContact.Text;
                   objeventman.Superior_Name = txtSupireorName.Text;
                   string location_id = getLocationIDByName1(drlLocationAdd.SelectedItem.Text.ToString());
                   objeventman.Location_id = location_id;

                   AdminBLL ws = new AdminBLL();
                    ws.AddEvent(objeventman);
                    BindGridWithFilter();
                //    this.ModalPopupAdd.Hide();
                   ClearAdd();
                       //dal.executesql("Update PreRegisteredVisits set FromDate='" + txtFromDate.Text.Trim() + "',ToDate='" + txtToDate.Text.Trim() + "',ExpectedTime='" + newtime + "',Name='" + txtName.Text.Trim() + "',Company='" + txtCompany.Text.Trim() + "',Position='" + txtPosition.Text.Trim() + "',Invited_By='" + txtInvitedBy.Text.Trim() + "',LocationID='" + Searchid.Text + "',VechicleNo='" + txtVechicle.Text + "',Purpose='" + txtpurpose.Text + "',Telephoe='"+txttelephone.Text+"' where PRVID ='" + hdnCSID.Value + "' ");
                      // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AlertMessage", " alert('Record Insert SuccessFully');", true);


                   MyMasterPage.ShowErrorMessage("Record Inserted SuccessFully..!");   
           
                       
                   
                  // HttpContext.Current.Items.Add("COMPLETE", "INSERT");
                   //Server.Transfer("..//SMSADMIN//AlertUpdateComplete.aspx");
               }
               else
               {
                   SM.ShowErrorMessage("Please Fill NRICno. & Name.....!");
                 //  lblerror.Visible = true;
                 //  lblerror.Text = "Please Fill NRICno. & Name.....!";
               }
           }
           catch (Exception ex)
           {
               logger.Info(ex.Message);
           }
        }
        private string getLocationIDByName1(string Name)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Location_name", Name);
            string result = string.Empty;
            DataTable dsLocationID = dal.executeprocedure("sp_GetLocationIDbyName", para, false);
            if (dsLocationID.Rows.Count > 0)
            {
                //SearchLocID.Text = dsLocationID.Rows[0][0].ToString().Trim();
                result = dsLocationID.Rows[0][0].ToString().Trim();
            }
            return result;
        }


        protected void cmdbuttonClear_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                ClearAdd();
                this.ModalPopupAdd.Hide();
            }
            catch (Exception ex)
            {
                logger.Info("EventPlanner(AssertImgUpdate_Click):" + ex.Message);
            }           
        }
        public void ClearAdd()
        {
            txtaddeventtype.Text = "";
            txtContact.Text = "";
            txtdutygaurd.Text = "";
            txtFromDate.Text = "";
            txtgaurdreq.Text = "";
            txtname.Text = "";
            txtNricNo.Text = "";
            txtPosition.Text = "";
            txtspecialreq.Text = "";            
            txttoDate.Text = "";
            if (txtSupireorName.Items.Count > 0)
            {
                txtSupireorName.SelectedIndex = 0;
            }
            if (drlEventType.Items.Count > 0)
            {
                drlEventType.SelectedIndex = 0;
            }             
            if (drlLocationAdd.Items.Count > 0)
            {
                drlLocationAdd.SelectedIndex=0;
            }
        }

        protected void cmdadd2_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                string g = txtaddeventtype.Text.Trim();
                string ID = "eventtype";
                SqlParameter[] para1 = new SqlParameter[1];
                para1[0] = new SqlParameter("@ID", ID);
                DataTable dt1 = dal.executeprocedure("sp_getLogvaluebyID", para1, true);

                int count = dt1.Rows.Count;
                for (p = 0; p < count; p++)
                {
                    string f = dt1.Rows[p].ItemArray[0].ToString();

                    if (string.Equals(f, g, StringComparison.CurrentCultureIgnoreCase))
                    {
                        break;
                    }
                }
                p++;
                count++;
                if (p == count)
                {
                    if (txtaddeventtype.Text.Trim() != "")
                    {
                        SqlParameter[] para2 = new SqlParameter[3];
                        para2[0] = new SqlParameter("@ID", SqlDbType.VarChar);
                        para2[0].Value = "eventtype";

                        para2[1] = new SqlParameter("@code", SqlDbType.BigInt);
                        para2[1].Value = count;

                        para2[2] = new SqlParameter("@Description", SqlDbType.VarChar);
                        para2[2].Value = txtaddeventtype.Text.Trim();

                        dal.executeprocedure("SP_InsertLogData", para2);


                        // dal.executesql("insert into log(ID,Code,Description) values('eventtype'," + count + ",'" + txtaddeventtype.Text + "')");
                        txtaddeventtype.Text = "";
                        fillEventType();
                    }
                }
                else
                {
                    txtaddeventtype.Text = "";
                    SM.ShowErrorMessage("This Type Already Exist....!");
                   // lblerror.Visible = true;
                   // lblerror.Text = "This Type Already Exist....!";
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private void fillEventType()
        {
            string ID = "eventtype";
            SqlParameter[] para1 = new SqlParameter[1];
            para1[0] = new SqlParameter("@ID", ID);
            DataTable dt = dal.executeprocedure("sp_getLogvaluebyID", para1, true);
            if (dt.Rows.Count > 0)
            {
                drlEventType.DataSource = dt;
                drlEventType.DataTextField = "Description";
                drlEventType.DataValueField = "Description";
                drlEventType.DataBind();
                drlEventType.Items.Insert(0, new ListItem("-Select-", " "));


                //ddlEventTypeUpdate.DataSource = dt;
                //ddlEventTypeUpdate.DataTextField = "Description";
                //ddlEventTypeUpdate.DataValueField = "Description";
                //ddlEventTypeUpdate.DataBind();
                //ddlEventTypeUpdate.Items.Insert(0, new ListItem("-Select-", " "));

                
            }
        }
        private void fillLocation()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {

                SqlParameter[] para = new SqlParameter[0];
                DataTable dsLocation = dal.executeprocedure("sp_FillLocationName", para, false);
                if (dsLocation.Rows.Count > 0)
                {
                    drlLocationAdd.DataSource = dsLocation;
                    drlLocationAdd.DataTextField = "Location_name";
                    drlLocationAdd.DataValueField = "Location_id";
                    drlLocationAdd.DataBind();                   

                    drlLocationUpdate.DataSource = dsLocation;
                    drlLocationUpdate.DataTextField = "Location_name";
                    drlLocationUpdate.DataValueField = "Location_id";
                    drlLocationUpdate.DataBind();                  

                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        protected void txtStaffiD_TextChanged(object sender, EventArgs e)
        {
            if (txtNricNo.Text.Trim() != "")
            {
                DataSet ds = dal.getdataset("select FirstName+' '+LastName as Name,Staff_Telphone as Phone,Role as Position From UserInformation where NRICno='" + txtNricNo.Text + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtname.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    txtContact.Text = ds.Tables[0].Rows[0]["Phone"].ToString();
                    txtPosition.Text = ds.Tables[0].Rows[0]["Position"].ToString();
                }
                else
                {
                    txtname.Text = "";
                    txtContact.Text = "";
                    txtPosition.Text = "";
                }
            }
            else
            {
                txtname.Text = "";
                txtContact.Text = "";
                txtPosition.Text = "";
            }
        }
        protected void txtNricNo_TextChanged(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (txtNricNo.Text.Trim() != "")
                {
                    DataSet ds = dal.getdataset("select FirstName+' '+LastName as Name,Staff_Telphone as Phone,Role as Position From UserInformation where NRICno='" + txtNricNo.Text + "'");
                    txtname.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    txtContact.Text = ds.Tables[0].Rows[0]["Phone"].ToString();
                    txtPosition.Text = ds.Tables[0].Rows[0]["Position"].ToString();
                }

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        
        #endregion
       
        
        #region Update

        public void Fill()
        {
            if (ViewState["Event_ID"] != null)
            {
                PopulatePageCntrls(ViewState["Event_ID"].ToString());
            }
        }
        private void PopulatePageCntrls(String argsBGID)
        {
            Int32 iCount = 0;
            GetDataEventResponse ret = null;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {

                DateTime dt;
                AdminBLL objAdminBLL = new AdminBLL();
                GetDataEvent objGetBillingTableRequest = new GetDataEvent();

                objGetBillingTableRequest.Event_ID = argsBGID.ToString();

                objGetBillingTableRequest.WhereClause = " where Event_ID='" + argsBGID.ToString() + "'";
                ret = objAdminBLL.GetEventData(objGetBillingTableRequest);

                hdnBTID.Value = ret.Eventid[iCount].Event_ID.ToString();
                txtEventID.Text = ret.Eventid[iCount].Event_ID.ToString();
                
                if (ret.Eventid[iCount].Date_From != null)
                {                    
                    txtFromDateUpdate.Text = ret.Eventid[iCount].Date_From.Value.ToString("MM/dd/yyyy");//"ToString().ToString(dtfi);
                }

                if (ret.Eventid[iCount].Date_to != null)
                {                    
                    ToDateUpdate.Text = ret.Eventid[iCount].Date_to.Value.ToString("MM/dd/yyyy");                       
                }

                ddlEventTypeUpdate.Text = ret.Eventid[iCount].Event_Type.ToString();

                dt = Convert.ToDateTime(ret.Eventid[iCount].Start_time);
                TimeSelector3.Date = dt;

                dt = Convert.ToDateTime(ret.Eventid[iCount].End_time);
                TimeSelector4.Date = dt;

                //RadTimePicker4.SelectedDate = dt;
                
                // txtpersonincharge.Text = ret.Eventid[iCount].Person_incharg.ToString();
                txtspecialreqUpdate.Text = ret.Eventid[iCount].Special_Requirment.ToString();
                txtgaurdreqUpdate.Text = ret.Eventid[iCount].Guard_Requirment.ToString();
                txtdutygaurdUpdate.Text = ret.Eventid[iCount].Special_Duty.ToString();
                txtNameUpdate.Text = ret.Eventid[iCount].Incharg_Name.ToString();
                txtNricNoUpdate.Text = ret.Eventid[iCount].Incharg_NricNo.ToString();
                txtPositionUpdate.Text = ret.Eventid[iCount].Incharg_position.ToString();
                txtContactUpdate.Text = ret.Eventid[iCount].Incharg_ContactNo.ToString();
                txtSupireorNameUpdate.Text = ret.Eventid[iCount].Superior_Name.ToString();

                //string location = GetLocationNameById(ret.Eventid[iCount].Location_id.ToString());
               // drlLocationUpdate = location;
                drlLocationUpdate.SelectedValue = ret.Eventid[iCount].Location_id.ToString();
            }   
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        private String GetLocationNameById(string id)
        {
            string name = string.Empty;
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Location_id", id);
            DataTable dsLocationid = dal.executeprocedure("sp_getLocationNameByID", para, false);
            if (dsLocationid.Rows.Count > 0)
            {
                name = dsLocationid.Rows[0][0].ToString().Trim();
                return name;
            }
            return name;
        }
        protected void ImgUpdate_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {

                  SpaMaster MyMasterPage = (SpaMaster)Page.Master;

                  DataTable dtViewEvents = AdminDAL.Checkmenu(Session["RoleID"].ToString(), "23");

                  if (dtViewEvents.Rows.Count > 0)
                                            {


                if (ViewState["Event_ID"] != null)
                {






                    Fill();
                    this.ModalPopupUpdate.Show();
                }


                                            }
                                            else
                                            {

                                                MyMasterPage.ShowErrorMessage("You Do Not Have permission..!");


                                            }


            }
            catch (Exception ex)
            {
                logger.Info("AdminCappAsset(AssertImgUpdate_Click):" + ex.Message);
            }
        }
        protected void BtnCancelUpdate_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                this.ModalPopupUpdate.Hide();
                ClearUpdate();
            }
            catch (Exception ex)
            {
                logger.Info("AdminCappAsset(AssertImgUpdate_Click):" + ex.Message);
            }
        }

        public void ClearUpdate()
        {
            txtEventID.Text = "";
            txtFromDateUpdate.Text = "";
            ToDateUpdate.Text = "";
            if (drlLocationUpdate.Items.Count > 0)
            {
                drlLocationUpdate.SelectedIndex = 0;
            }
            //if (ddlEventTypeUpdate.Items.Count > 0)
            //{
            //    ddlEventTypeUpdate.SelectedIndex = 0;
            //}
            
            txtspecialreqUpdate.Text = "" ;
            txtgaurdreqUpdate.Text="";
            txtdutygaurdUpdate.Text="";
            txtNameUpdate.Text="";
            txtNricNoUpdate.Text="";
            txtPositionUpdate.Text="";
            txtContactUpdate.Text="";
           // txtSupireorNameUpdate.Text="";
           // this.ModalPopupUpdate.Hide();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
            if (ViewState["Event_ID"] != null)
            {               
               
                    eventAdmin objevent = new eventAdmin();
                    AdminBLL ws = new AdminBLL();
                    DateTime datetime;

                    objevent.Event_ID = txtEventID.Text;
                   // objevent.Date_From = DateTime.TryParse(txtFromDateUpdate.Text, out datetime) ? (DateTime?)datetime : null; ;
                   // objevent.Date_to = DateTime.TryParse(ToDateUpdate.Text, out datetime) ? (DateTime?)datetime : null; ;
                    if (txtFromDateUpdate.Text.Length == 0)
                    {
                        objevent.Date_From = null;
                    }
                    else
                    {
                        DateTimeFormatInfo dtfi = new DateTimeFormatInfo();
                        dtfi.ShortDatePattern = "MM/dd/yyyy";
                        dtfi.DateSeparator = "/";
                        DateTime objDate = Convert.ToDateTime(txtFromDateUpdate.Text, dtfi);
                        objevent.Date_From = objDate;
                    }

                    if (ToDateUpdate.Text.Length == 0)
                    {
                        objevent.Date_to = null;
                    }
                    else
                    {
                        DateTimeFormatInfo dtfi = new DateTimeFormatInfo();
                        dtfi.ShortDatePattern = "MM/dd/yyyy";
                        dtfi.DateSeparator = "/";
                        DateTime objDate = Convert.ToDateTime(ToDateUpdate.Text, dtfi);
                        objevent.Date_to = objDate;
                    }
                    objevent.Location_id = Convert.ToString(GetLocationIDbyName(drlLocationUpdate.Text));
                    objevent.Event_Type = ddlEventTypeUpdate.Text;

                    string time = TimeSelector3.Date.TimeOfDay.ToString();
                    objevent.Start_time = time;

                    string time1 = TimeSelector4.Date.TimeOfDay.ToString();
                    objevent.End_time = time1;

                    objevent.Special_Requirment = txtspecialreqUpdate.Text;
                    objevent.Guard_Requirment = txtgaurdreqUpdate.Text;
                    objevent.Special_Duty = txtdutygaurdUpdate.Text;
                    objevent.Incharg_Name = txtNameUpdate.Text;
                    objevent.Incharg_NricNo = txtNricNoUpdate.Text;
                    objevent.Incharg_position = txtPositionUpdate.Text;
                    objevent.Incharg_ContactNo = txtContactUpdate.Text;
                    objevent.Superior_Name = txtSupireorNameUpdate.Text;


                    ws.Updatevent(objevent);
                   // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AlertMessage", " alert('Record Update SuccessFully');", true);
                    SpaMaster MyMasterPage = (SpaMaster)Page.Master;

                    MyMasterPage.ShowErrorMessage("Record Updated SuccessFully..!");   
          
                    this.ModalPopupUpdate.Hide();
                    ClearUpdate();
                    BindGridWithFilter();
                    //dal.executesql("Update PreRegisteredVisits set FromDate='" + txtFromDate.Text.Trim() + "',ToDate='" + txtToDate.Text.Trim() + "',ExpectedTime='" + newtime + "',Name='" + txtName.Text.Trim() + "',Company='" + txtCompany.Text.Trim() + "',Position='" + txtPosition.Text.Trim() + "',Invited_By='" + txtInvitedBy.Text.Trim() + "',LocationID='" + Searchid.Text + "',VechicleNo='" + txtVechicle.Text + "',Purpose='" + txtpurpose.Text + "',Telephoe='"+txttelephone.Text+"' where PRVID ='" + hdnCSID.Value + "' ");
                      
                  //  HttpContext.Current.Items.Add(ContextKeys.CTX_COMPLETE, "UPDATE");
                   // Server.Transfer("AlertUpdateComplete.aspx");
            }
                }
                catch (Exception ex)
                {
                    logger.Info(ex.Message);
                }
            

        }
        private void fillsupervisor()
        {
            txtSupireorNameUpdate.Items.Clear();
            txtSupireorNameUpdate.Items.Add(" ");
            txtSupireorName.Items.Clear();
            txtSupireorName.Items.Add(" ");

            DataSet dssup = dal.getdataset("Select Firstname from UserInformation where Role = 'SuperVisor'");
            if (dssup.Tables[0].Rows.Count > 0)
            {
                for (int j = 0; j < dssup.Tables[0].Rows.Count; j++)
                {
                    txtSupireorNameUpdate.Items.Add(dssup.Tables[0].Rows[j][0].ToString().Trim());
                    txtSupireorName.Items.Add(dssup.Tables[0].Rows[j][0].ToString().Trim());
                }
            }
        }
        #endregion update

      
        #region delete
        protected void ImgDelete_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {


                 SpaMaster MyMasterPage = (SpaMaster)Page.Master;

                  DataTable dtViewEvents = AdminDAL.Checkmenu(Session["RoleID"].ToString(), "23");

                  if (dtViewEvents.Rows.Count > 0)
                                            {


                if (ViewState["Event_ID"] != null)
                {
                    this.ModalPopupDelete.Show();
                }

                                            }
                  else
                  {

                      MyMasterPage.ShowErrorMessage("You Do Not Have permission..!");


                  }


            }
            catch (Exception ex)
            {
                logger.Info("AdminCappAsset(AssertImgUpdate_Click):" + ex.Message);
            }
        }
        protected void Deletepopup_Yes_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (ViewState["Event_ID"] != null)
                {
                    DeleteItem(ViewState["Event_ID"].ToString());
                  //  ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AlertMessage", " alert('Record Delete SuccessFully');", true);

                    SpaMaster MyMasterPage = (SpaMaster)Page.Master;

                    MyMasterPage.ShowErrorMessage("Record Deleted SuccessFully..!");   
          
                    
                    
                    BindGridWithFilter();
                    ViewState["Event_ID"] = null;
                    ModalPopupDelete.Hide();
                }
            }
            catch (Exception ex)
            {
                logger.Info("AdminCappAsset(AssertImgUpdate_Click):" + ex.Message);
            }
        }
        protected void btnCancelDelete_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                this.ModalPopupDelete.Hide();
            }
            catch (Exception ex)
            {
                logger.Info("AdminCappAsset(AssertImgUpdate_Click):" + ex.Message);
            }
        }


        #endregion

        protected void ToggleRowSelection(object sender, EventArgs e)
        {
            ((sender as CheckBox).NamingContainer as GridItem).Selected = (sender as CheckBox).Checked;
            bool checkHeader = true;
            List<string> lstreportsession = new List<string>();
            int ro = ((sender as CheckBox).NamingContainer as GridItem).ItemIndex;
            GridDataItem item = gvNewEventSearch1.MasterTableView.Items[ro];

            foreach (GridDataItem item1 in gvNewEventSearch1.MasterTableView.Items)
            {

                if (item == item1)
                {
                    if ((item.FindControl("CheckBox1") as CheckBox).Checked)
                    {

                        gvNewEventSearch1.Items[ro].Selected = true;


                        ViewState["Event_ID"] = item.OwnerTableView.DataKeyValues[ro]["Event_ID"];


                    }
                }
                else
                {
                    (item1.FindControl("CheckBox1") as CheckBox).Checked = false;
                }


            }

        }

    }
}
