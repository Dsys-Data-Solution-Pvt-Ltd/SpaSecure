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

namespace SMS.SMSAdmin
{
    public partial class eventplanneraspx : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd;
        DataAccessLayer dal = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
         
         log4net.ILog logger = log4net.LogManager.GetLogger("File");
         try
         {                     
                if (!IsPostBack)
                {                   
                    fillevent();
                    if (Session["ManagementRole"].ToString().ToLower() == "superuser")
                    {
                        getLocationName();
                    }
                    else
                    {
                        getLocationNameById(Session["LCID"].ToString());
                    }
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
                    Server.Transfer("AlertUpdateComplete.aspx");
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

    }
}
