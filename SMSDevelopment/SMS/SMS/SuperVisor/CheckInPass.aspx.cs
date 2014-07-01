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

//using Microsoft.SqlServer.Management.Trace;
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
    public partial class CheckInPass : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (!IsPostBack)
                {                   
                    BindGrid();
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }


        private void BindGrid()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                AdminBLL ws = new AdminBLL();
                GetPassData _req = new GetPassData();
                GetPassDataResponse _resp = ws.GetPassData(_req);

                int pageSize = ContextKeys.GRID_PAGE_SIZE;
                gvKeySearch.PageSize = pageSize;
                gvKeySearch.DataSource = _resp.Pass;
                gvKeySearch.DataBind();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void gvNewKey_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvNewKey_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (e.NewPageIndex >= 0)
                {
                    gvKeySearch.PageIndex = e.NewPageIndex;
                    AdminBLL ws = new AdminBLL();
                    GetPassData _req = new GetPassData();
                    GetPassDataResponse _resp = ws.GetPassData(_req);

                    int pageSize = ContextKeys.GRID_PAGE_SIZE;
                    gvKeySearch.PageSize = pageSize;
                    gvKeySearch.DataSource = _resp.Pass;
                    gvKeySearch.DataBind();
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        protected void gvNewKey_RowDataBound(object sender, GridViewRowEventArgs e)
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
                    gvKeySearch.Columns[0].FooterText = "Total Records: 20";
                }

                if (e.Row.Cells[2].Text == "Free")
                {
                    e.Row.Cells[2].ForeColor = Color.Red;

                }

            }

            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }




    }
}
