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
using SMS.Services.DataService;
using SMS.Services.BusinessServices;
using SMS.SMSAppUtilities;
using System.Data.SqlClient;

namespace SMS.Controller
{
    public partial class IPCameraMaster : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        AdminDAL a = new AdminDAL();
        string whereclouse = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    fillLocation();
                    fillgridwithFilter();
                }
            }
            catch (Exception ex)
            {
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
                ddllocation.Items.Insert(0, " ");
            }
        }

        protected void gvPass_RowDataBound(object sender, GridViewRowEventArgs e)
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
                    gvPassTable.Columns[0].FooterText = "Total Records: 20";
                }               
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void gvPass_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                string _BTId = Convert.ToString(e.CommandArgument);
                if (e.CommandName == "EditRow")
                {                      
                    Response.Redirect("viewIPcamera.aspx?id=" + _BTId);
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

        private void DeleteItem(string argPassID)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                SqlParameter[] para = new SqlParameter[1];
                para[0] = new SqlParameter("@IP_id", argPassID);
                dal.exeprocedure("SP_deleteIPCemra", para);
                fillgridwithFilter();               
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void gvPass_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (e.NewPageIndex >= 0)
                {
                    dal.gridpageindex = e.NewPageIndex;
                    fillgridwithFilter();                   
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        
        private void BindGrid(string where)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {               
                int pageSize = ContextKeys.GRID_PAGE_SIZE;
                DataTable dt = dal.getdata("select * from LocationIPCameraMap with(nolock)" + where);
                gvPassTable.PageIndex = dal.gridpageindex;
                gvPassTable.PageSize = pageSize;
                gvPassTable.DataSource = dt;
                gvPassTable.DataBind();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void gvPassTable_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void btnNewPass_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Response.Redirect("AddNewCamera.aspx");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnSearchPassAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                fillgridwithFilter();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private void fillgridwithFilter()
        {
            string s = string.Empty;
            if (ddllocation.Text.Trim() != "")
            {
                s = " where Location_ID = " + ddllocation.SelectedValue.ToString() + " ";
                BindGrid(s);
            }
            else
            {
                BindGrid(whereclouse);
            }
        }

        
    }
}
