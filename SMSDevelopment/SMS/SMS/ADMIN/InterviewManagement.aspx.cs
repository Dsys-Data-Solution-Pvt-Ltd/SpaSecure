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

namespace SMS.ADMIN
{
    public partial class InterviewManagement : System.Web.UI.Page
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
                    ddlInterviewStatus.SelectedIndex = 0;
                    txtdatefrom.Text = DateTime.Now.ToString();
                    txtdateto.Text = DateTime.Now.ToString();
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
                DataSet ds = dal.getdataset("select * from InterviewManager with(nolock)");
                gvItemTable.PageSize = 20;
                gvItemTable.DataSource = ds.Tables[0];
                gvItemTable.DataBind();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        private void BindGridwithFilter()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                AdminBLL ws = new AdminBLL();
                DataSet ds = dal.getdataset("select * from InterviewManager with(nolock)");
                gvItemTable.PageSize = 20;
                gvItemTable.DataSource = ds.Tables[0];
                gvItemTable.DataBind();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnAddnewIncident_Click(object sender, EventArgs e)
        {
           log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                 Response.Redirect("NewPrescreen.aspx");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                string status = ddlInterviewStatus.SelectedValue.ToString().Trim();
                DateTime dtfrom = Convert.ToDateTime(txtdatefrom.Text.ToString());
                DateTime dtto = Convert.ToDateTime(txtdateto.Text.ToString());
                string searchQuery = "select * from InterviewManager where status='" + status + "' and Prescreen_date between '"+dtfrom +"' and '"+dtto+"'";

                DataSet ds = dal.getdataset(searchQuery);
                gvItemTable.PageSize = 20;
                gvItemTable.DataSource = ds.Tables[0];
                gvItemTable.DataBind();
             }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        protected void gvItem_RowDataBound(object sender, GridViewRowEventArgs e)
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
                    gvItemTable.Columns[0].FooterText = "Total Records: 20";
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void gvItem_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                string _BTId = Convert.ToString(e.CommandArgument);
                string state = string.Empty;

                if (e.CommandName == "EditRow")
                {
                    Response.Redirect("UpdateInterview.aspx?id=" + _BTId);
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

        private void DeleteItem(string _BTId)
        {
            dal.executesql("delete from InterviewManager Where Interview_id = '" + _BTId + "' ");
        }
    }
}
