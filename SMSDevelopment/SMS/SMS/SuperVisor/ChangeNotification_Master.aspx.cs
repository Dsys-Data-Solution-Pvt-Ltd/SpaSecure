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
using System.Drawing;

using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.Services.DataService;
using SMS.SMSAppUtilities;
using SMS.BusinessEntities;

namespace SMS.SuperVisor
{
    public partial class ChangeNotification_Master : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (HttpContext.Current.Session["SESSION_LOGIN_USER"] == null)
                {
                    Response.Redirect("~/master/login3.aspx");
                }
                if (!IsPostBack)             //change by rakesh 11jl
                {
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
                searchid.Text = dsLocationID.Rows[0][0].ToString().Trim();
            }
        }

        private void getLocationName()
        {
            ddllocation.Items.Clear(); 
            ddllocation.Items.Add("");
            SqlParameter[] para = new SqlParameter[0];
            
            DataTable dsLocation = dal.executeprocedure("sp_FillLocationName", para, false);
            if (dsLocation.Rows.Count > 0)
            {
                for (int k = 0; k < dsLocation.Rows.Count; k++)
                {
                    ddllocation.Items.Add(dsLocation.Rows[k][0].ToString().Trim());
                }
            }
        }

        private void getLocationNameById(string Name)
        {
            ddllocation.Items.Clear();                //change by rakesh 11jl
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Location_id", Name);
            DataTable dsLocationName = dal.executeprocedure("sp_getLocationNameByID", para, false);
            if (dsLocationName.Rows.Count > 0)
            {
                ddllocation.Items.Add(dsLocationName.Rows[0][0].ToString().Trim());
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

                if (txtdateto.Text != "" && txtdatefrom.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where DateFrom BETWEEN '" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                        arr.Add("1");
                    }
                    else
                    {
                        str += " and DateFrom BETWEEN '" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                    }
                }
                if (txtdatefrom.Text != "" && txtdateto.Text == "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where DateFrom ='" + txtdatefrom.Text + "'";
                        arr.Add("2");
                    }
                    else
                    {
                        str += " and DateFrom ='" + txtdatefrom.Text + "'";
                    }
                }
                if (txtref.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where RefNumber ='" + txtref.Text.Trim() + "'";
                        arr.Add("3");
                    }
                    else
                    {
                        str += " and RefNumber ='" + txtref.Text.Trim() + "'";
                    }
                }
                if (ddllocation.Text.Trim() != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where Location_id ='" + searchid.Text + "'";
                        arr.Add("4");
                    }
                    else
                    {
                        str += " and Location_id ='" + searchid.Text + "'";
                    }
                }

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
            return (str);
        }
        private void BindGridWithFilter()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                string where = ReturnWhere();
                AdminBLL ws = new AdminBLL();
                int pageSize = ContextKeys.GRID_PAGE_SIZE;
                DataSet ds = dal.getdataset("select * from ChangeNotification with(nolock)" + where + " ");
                gvLoctionTable.PageSize = pageSize;
                gvLoctionTable.DataSource = ds.Tables[0];
                gvLoctionTable.DataBind();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnNewLocation_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangeNotification.aspx");
        }
        protected void gvLocation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    ImageButton Delete = (ImageButton)e.Row.FindControl("btnDelete");
                    Delete.Attributes.Add("onclick", "javascript:return " +
                        "confirm('Are you sure to delete this record?')");
                }

                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    gvLoctionTable.Columns[0].FooterText = "Total Records: 20";
                }
            }

            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void gvLocation_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                string _BTId = Convert.ToString(e.CommandArgument);

                if (e.CommandName == "EditRow")
                {
                    HttpContext.Current.Items.Add(ContextKeys.CTX_UPDATE_URL, Request.Url.ToString());
                    HttpContext.Current.Items.Add(ContextKeys.CTX_BT_ID, _BTId);
                    //Response.Redirect("../SMSAdmin/LocationUpdate.aspx");
                    Server.Transfer("ChangeNotification_View.aspx?id=" + _BTId.ToString());
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
        private void DeleteItem(string arglocationid)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {

                dal.executesql("delete from ChangeNotification Where Notification_id = '" + arglocationid + "' ");
                HttpContext.Current.Items.Add(ContextKeys.CTX_COMPLETE, "DELETE");
                Server.Transfer("CompleteForm.aspx");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void gvLocation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (e.NewPageIndex >= 0)
                {
                    DataSet ds = dal.getdataset("select * from ChangeNotification with(nolock)");
                    int pageSize = ContextKeys.GRID_PAGE_SIZE;
                    gvLoctionTable.PageSize = pageSize;
                    gvLoctionTable.DataSource = ds.Tables[0];
                    gvLoctionTable.DataBind();
                }
            }
          
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnSearchAdminAlert_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                getLocationIDByName(ddllocation.Text.Trim());
                BindGridWithFilter();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnClearAdminAlert_Click(object sender, EventArgs e)    //change by rakesh 11jl
        {
            if (Session["ManagementRole"].ToString().ToLower() == "superuser")
            {
                getLocationName();
            }
            else
            {
                getLocationNameById(Session["LCID"].ToString());
            }
            txtdatefrom.Text = "";
            txtdateto.Text = "";
            txtref.Text = "";
        }
    }
}
