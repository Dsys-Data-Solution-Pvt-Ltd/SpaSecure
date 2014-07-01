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
using SMS.master;

namespace SMS.SMSAdmin
{
    public partial class EventPlan : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                #region image display
                //--------------image display---------------------------
                DBConnectionHandler1 bd = new DBConnectionHandler1();
                SqlConnection cn = bd.getconnection();
                cn.Open();
                SqlCommand cmd = new SqlCommand("select * from UploadLogo", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (dr.GetString(0) != "")
                    {
                        image1.ImageUrl = dr.GetString(0);
                        //========================//
                        dr.Close();
                        dr.Dispose();
                        //========================//
                        cn.Close();
                    }
                }
                //---------------------------=---------------------------
                #endregion
               

                if (!IsPostBack)
                {
                    if (HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL] != null)
                    {
                        string strURL = HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL].ToString();
                    }
                    fillevent();
                    if (Session["ManagementRole"].ToString().ToLower() == "superuser" || Session["ManagementRole"].ToString().ToLower() == "super security")
                    {
                        fillLocation();
                    }
                    else
                    {
                        getLocationNameById(Session["LCID"].ToString());
                    }
                    
                }

                string ctrlname = Page.Request.Params.Get("__EVENTTARGET");
                string ctrlname1 = Page.Request.Params.Get("__eventargument");
                if (ctrlname != null)
                {
                    string controlname = ctrlname;//.Split('$')[ctrlname.Split('$').Length - 1].ToString();
                    if (!controlname.Contains("imdAdd") && !controlname.Contains("imgUpdate") && !controlname.Contains("imgDelete") && !controlname.Contains("imgCopy") && !controlname.Contains("CheckBox1"))
                    {
                        if (controlname.ToUpper().Contains("gvNewEventSearch".ToUpper()))
                        {
                            if (ctrlname1 != null)
                            {
                                if (ctrlname1.Contains("RowClick"))
                                { }
                                else if (ctrlname1.ToUpper().Contains("FIRECOMMAND") || ctrlname1 == "")
                                {
                                    BindGrid();
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
                    BindGrid();
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        #region Bind Grid
        private void BindGrid()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                AdminBLL ws = new AdminBLL();
                GetDataEvent _req = new GetDataEvent();
                GetDataEventResponse _resp = ws.GetEventData(_req);

                gvNewEventSearch.DataSource = _resp.Eventid;
                gvNewEventSearch.DataBind();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void ToggleRowSelection(object sender, EventArgs e)
        {
            ((sender as CheckBox).NamingContainer as GridItem).Selected = (sender as CheckBox).Checked;
            bool checkHeader = true;
            List<string> lstreportsession = new List<string>();
            int ro = ((sender as CheckBox).NamingContainer as GridItem).ItemIndex;
            GridDataItem item = gvNewEventSearch.MasterTableView.Items[ro];

            foreach (GridDataItem item1 in gvNewEventSearch.MasterTableView.Items)
            {

                if (item == item1)
                {
                    if ((item.FindControl("CheckBox1") as CheckBox).Checked)
                    {

                        gvNewEventSearch.Items[ro].Selected = true;


                        ViewState["Event_ID"] = item.OwnerTableView.DataKeyValues[ro]["Event_ID"];


                    }
                }
                else
                {
                    (item1.FindControl("CheckBox1") as CheckBox).Checked = false;
                }


            }

        }
        #endregion

        #region Location
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

        private void getLocationIDByName(string Name)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Location_name", Name);
            DataTable dsLocationID = dal.executeprocedure("sp_GetLocationIDbyName", para, false);
            if (dsLocationID.Rows.Count > 0)
            {
                searchid.Text = dsLocationID.Rows[0][0].ToString().Trim();
            }
        }

        private string getLocationNameById1(string Name)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Location_id", Name);
            DataTable dsLocationName = dal.executeprocedure("sp_getLocationNameByID", para, false);
            if (dsLocationName.Rows.Count > 0)
            {
                return dsLocationName.Rows[0][0].ToString().Trim();
            }
            return null;
        }
        #endregion

        #region Fill Dropdown
        private void fillevent()
        {
            string ID = "eventtype";
            SqlParameter[] para1 = new SqlParameter[1];
            para1[0] = new SqlParameter("@ID", ID);
            DataTable dt = dal.executeprocedure("sp_getLogvaluebyID", para1, true);
            if (dt.Rows.Count > 0)
            {
                DropDownList2.DataSource = dt;
                DropDownList2.DataTextField = "Description";
                DropDownList2.DataValueField = "Description";
                DropDownList2.DataBind();
                DropDownList2.Items.Insert(0, new ListItem("-Select-", ""));
            }
        }
        private void fillLocation()
        {
            SqlParameter[] para = new SqlParameter[0];
            DataTable dsLocation = dal.executeprocedure("sp_FillLocationName", para, false);
            if (dsLocation.Rows.Count > 0)
            {
                ddllocation.DataSource = dsLocation;
                ddllocation.DataTextField = "Location_name";
                ddllocation.DataValueField = "Location_id";
                ddllocation.DataBind();
                ddllocation.Items.Insert(0, "");
            }
            
        }

        #endregion

        # region Icon menu
       
        # region Delete

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
                    this.ModalPopupDelete.Hide();
                }

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
       
        protected void ImgDelete_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (ViewState["Event_ID"] != null)
                {
                    this.ModalPopupDelete.Show();
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
                SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                if (ViewState["Event_ID"] != null)
                {
                    DeleteItem(ViewState["Event_ID"].ToString());
                    MyMasterPage.ShowErrorMessage("Record Deleted Successfully");
                    BindGridWithFilter();
                    this.ModalPopupDelete.Hide();
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

        #region View

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

                objGetBillingTableRequest.WhereClause = " where Event_ID ='" + argsBGID.ToString() + "'";
                ret = objAdminBLL.GetEventData(objGetBillingTableRequest);

                // hdnBTID.Value = ret.Eventid[iCount].Event_ID.ToString();

                txtEventID1.Text = ret.Eventid[iCount].Event_ID.ToString();
                txtEventdate.Text = ret.Eventid[iCount].Date_From.ToString();
                txtEventDateTo.Text = ret.Eventid[iCount].Date_to.ToString();

                txtLocation.Text = getLocationNameById1(ret.Eventid[iCount].Location_id.ToString());
                txteventtype.Text = ret.Eventid[iCount].Event_Type.ToString();

                txtpersonNRIC.Text = ret.Eventid[iCount].Incharg_NricNo.ToString();
                txtEnterName.Text = ret.Eventid[iCount].Incharg_Name.ToString();
                txtContactNo.Text = ret.Eventid[iCount].Incharg_ContactNo.ToString();
                txtCreatedBy.Text = ret.Eventid[iCount].Superior_Name.ToString();

                txtdutygaurd.Text = ret.Eventid[iCount].Special_Requirment.ToString();
                txtEnterName.Text = ret.Eventid[iCount].Incharg_Name.ToString();
                txtpersonNRIC.Text = ret.Eventid[iCount].Incharg_NricNo.ToString();

                txtEventstartTime.Text = ret.Eventid[iCount].Start_time.ToString();
                txtEventEndTime.Text = ret.Eventid[iCount].End_time.ToString();
                txtPosition.Text = ret.Eventid[iCount].Incharg_position.ToString();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

        }
        protected void ImageView(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (ViewState["Event_ID"] != null)
                {
                    PopulatePageCntrls(ViewState["Event_ID"].ToString());
                    ModalPopupView.Show();
                    Session["ctrl"] = printview;
                }
            }
            catch (Exception ex)
            {
                logger.Info("AdminCappAsset(AssertImgUpdate_Click):" + ex.Message);
            }
        }
        protected void btnCancelView_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                ModalPopupView.Hide();
            }
            catch (Exception ex)
            {
                logger.Info("AdminCappAsset(AssertImgUpdate_Click):" + ex.Message);
            }
        }

        protected void btnprint_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
               
                ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('NewPrintpage.aspx','PrintMe','height=700px,width=800px,scrollbars=1');</script>");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        #endregion


        #endregion

        #region Old Code


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

                if (e.CommandName == "View")
                {
                    HttpContext.Current.Items.Add(ContextKeys.CTX_UPDATE_URL, Request.Url.ToString());
                    HttpContext.Current.Items.Add(ContextKeys.CTX_BT_ID, _BTId);
                    Server.Transfer("EventPlanView.aspx");
                }
                if (e.CommandName == "DeleteRow")
                {
                    // DeleteItem(_BTId);
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
                        AdminBLL ws = new AdminBLL();
                        GetDataEvent _req = new GetDataEvent();
                        GetDataEventResponse _resp = ws.GetEventData(_req);
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
                getLocationIDByName(ddllocation.Text.Trim());
                string WhereClause = ReturnWhere();
                if (!string.IsNullOrEmpty(txteventid.Text))
                {
                    objReq.Event_ID = txteventid.Text;
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
                if (!string.IsNullOrEmpty(ddllocation.Text))
                {
                    objReq.Location_id = Session["LCID"].ToString();
                }
                if (!string.IsNullOrEmpty(DropDownList2.Text))
                {
                    objReq.Event_Type = DropDownList2.Text;
                }
                if (!string.IsNullOrEmpty(WhereClause))
                {
                    objReq.WhereClause = WhereClause;
                }

                GetDataEventResponse ret = ws.GetEventData(objReq);
                int pageSize = ContextKeys.GRID_PAGE_SIZE;
                gvNewEventSearch.PageSize = pageSize;
                gvNewEventSearch.DataSource = ret.Eventid;
                gvNewEventSearch.DataBind();
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

                if (txteventid.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        makeWhereClause = " where ";
                        str += " where Event_ID='" + txteventid.Text + "'";
                        arr.Add("1");
                    }
                    else
                    {
                        str += " and Event_ID='" + txteventid.Text + "'";
                    }
                }

                if (ddllocation.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        //str += " where Location_id ='" + searchid.Text + "'";
                        str += " where Location_id ='" + ddllocation.Text + "'";
                        arr.Add("2");

                    }
                    else
                    {
                        str += " and Location_id ='" + ddllocation.Text + "'";
                    }
                }
                if (DropDownList2.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where Event_Type='" + DropDownList2.Text + "'";
                        arr.Add("3");
                    }
                    else
                    {
                        str += " and Event_Type='" + DropDownList2.Text + "'";
                    }
                }

                if (txtdateto.Text != "" && txtdatefrom.Text != "")
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
                if (txtdatefrom.Text != "" && txtdateto.Text == "")
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





        protected void gvNewEvent_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnNewBTable_Click(object sender, EventArgs e)
        {

        }

        protected void imgBtnFromDate3_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void txtdateto_TextChanged(object sender, EventArgs e)
        {

        }

        protected void imgBtnFromDate2_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void txtdatefrom_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnCanel_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                txteventid.Text = "";
                fillevent();
                if (Session["ManagementRole"].ToString().ToLower() == "superuser" || Session["ManagementRole"].ToString().ToLower() == "super security")
                {
                    fillLocation();
                }
                else
                {
                    getLocationNameById(Session["LCID"].ToString());
                }
                txtdatefrom.Text = "";
                txtdateto.Text = "";
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void ddllocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchid.Text = ddllocation.Text;
        }




        #endregion 

    }
}