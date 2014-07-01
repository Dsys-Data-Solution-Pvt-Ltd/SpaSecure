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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
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

namespace SMS.SuperVisor
{
    public partial class AdminIncident : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        AdminDAL a = new AdminDAL();
        AdminBLL b = new AdminBLL();
        int i = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                txtincidentno.Focus();
                if (!IsPostBack)
                {
                    if (Session["ManagementRole"].ToString().ToLower() == "superuser" || Session["ManagementRole"].ToString().ToLower() == "super security officer")
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
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Location_id", Name);
            DataTable dsLocationName = dal.executeprocedure("sp_getLocationNameByID", para, false);
            if (dsLocationName.Rows.Count > 0)
            {
                ddllocation.Items.Add(dsLocationName.Rows[0][0].ToString().Trim());
            }
        }

        private void BindGridWithFilter()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                AdminBLL ws = new AdminBLL();
                GetIncidentData objReq = new GetIncidentData();
                getLocationIDByName(ddllocation.Text.Trim());
                string WhereClause = ReturnWhere();

                if (!string.IsNullOrEmpty(txtdateto.Text))
                {
                    if (!string.IsNullOrEmpty(txtdatefrom.Text))
                    {
                        objReq.Date_of_Incident = txtdatefrom.Text;
                        objReq.Date_of_Incident = txtdatefrom.Text;
                    }
                }
                if (!string.IsNullOrEmpty(txtdatefrom.Text))
                {
                    if (string.IsNullOrEmpty(txtdateto.Text))
                    {
                        objReq.Date_of_Incident = txtdatefrom.Text;
                    }
                }
                if (!string.IsNullOrEmpty(txtplaceofincident.Text))
                {
                    objReq.Place_of_Incident = txtplaceofincident.Text;
                }
                if (!string.IsNullOrEmpty(txtreport.Text))
                {
                    objReq.Reported_By = txtreport.Text;
                }
                if (!string.IsNullOrEmpty(txtverifiedby.Text))
                {
                    objReq.Verified_By = txtverifiedby.Text;
                }
                if (!string.IsNullOrEmpty(txtincidentno.Text))
                {
                    objReq.Report_No = txtincidentno.Text;
                }
                if (!string.IsNullOrEmpty(WhereClause))
                {
                    objReq.WhereClause = WhereClause;
                }
                GetIncidentDataResponse ret = ws.GetIncidentData(objReq);

                int pageSize = ContextKeys.GRID_PAGE_SIZE;
                gvItemTable.PageSize = pageSize;
                gvItemTable.DataSource = ret.Incident;
                if (ret.Incident.Count == 0)
                {
                    // incident2.Visible = false;
                }
                gvItemTable.DataBind();
                //incident2.Text = ret.Incident.Count.ToString();
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
                if (txtdateto.Text != "" && txtdatefrom.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where Date_of_Incident BETWEEN '" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                        arr.Add("1");
                    }
                    else
                    {
                        str += " and Date_of_Incident BETWEEN '" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                    }

                }
                if (txtdatefrom.Text != "" && txtdateto.Text == "")
                {
                    if (arr.Count == 1)
                    {
                        makeWhereClause = " where ";
                        str += " where Date_of_Incident='" + txtdatefrom.Text + "'";
                        arr.Add("2");
                    }
                    else
                    {
                        str += " and Date_of_Incident='" + txtdatefrom.Text + "'";
                    }
                }
                if (txtincidentno.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where Report_No='" + txtincidentno.Text + "'";
                        arr.Add("3");
                    }
                    else
                    {
                        str += " and Report_No='" + txtincidentno.Text + "'";
                    }
                }
                if (txtplaceofincident.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where Place_of_Incident='" + txtplaceofincident.Text + "'";
                        arr.Add("4");

                    }
                    else
                    {
                        str += " and Place_of_Incident='" + txtplaceofincident.Text + "'";
                    }
                }
                if (ddllocation.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where location_ID ='" + searchid.Text + "'";
                        arr.Add("5");
                    }
                    else
                    {
                        str += " and location_ID ='" + searchid.Text + "'";
                    }
                }

                if (txtreport.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where Reported_By ='" + txtreport.Text + "'";
                        arr.Add("6");
                    }
                    else
                    {
                        str += " and Reported_By ='" + txtreport.Text + "'";
                    }
                }

                if (txtverifiedby.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where Verified_By='" + txtverifiedby.Text + "'";
                        arr.Add("7");
                    }
                    else
                    {
                        str += " and Verified_By='" + txtverifiedby.Text + "'";
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

            return (str);
        }

        private void BindGrid()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                AdminBLL ws = new AdminBLL();

                GetIncidentData _req = new GetIncidentData();
                GetIncidentDataResponse _resp = ws.GetIncidentData(_req);


                int pageSize = ContextKeys.GRID_PAGE_SIZE;
                gvItemTable.PageSize = pageSize;
                gvItemTable.DataSource = _resp.Incident;
                if (_resp.Incident.Count == 0)
                {
                    //incident1.Visible = false;
                    //incident2.Visible = false;
                }
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
                    //JS for delete btn
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

                if (e.CommandName == "View")
                {
                    HttpContext.Current.Items.Add(ContextKeys.CTX_UPDATE_URL, Request.Url.ToString());
                    HttpContext.Current.Items.Add(ContextKeys.CTX_BT_ID, _BTId);
                    Server.Transfer("..//SuperVisor//IncidentAdminReport.aspx");
                }

                if (e.CommandName == "EditRow")
                {
                    HttpContext.Current.Items.Add(ContextKeys.CTX_UPDATE_URL, Request.Url.ToString());
                    HttpContext.Current.Items.Add(ContextKeys.CTX_BT_ID, _BTId);
                    Server.Transfer("..//SuperVisor//IncidentFollowUp.aspx");
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
        private void DeleteItem(string argincidentId)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {

                if (!string.IsNullOrEmpty(argincidentId))
                {
                    AdminBLL ws = new AdminBLL();
                    DeleteIncidentRequest _req = new DeleteIncidentRequest();

                    //_req.ReportNo = argincidentId.ToString();
                    _req.IncidentNo = argincidentId.ToString();
                    ws.DeleteIncident(_req);
                    HttpContext.Current.Items.Add(ContextKeys.CTX_COMPLETE, "DELETE");
                    Server.Transfer("../SMSAdmin/AlertUpdateComplete.aspx");
                }

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        protected void gvItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (e.NewPageIndex >= 0)
                {
                    gvItemTable.PageIndex = e.NewPageIndex;

                    AdminBLL ws = new AdminBLL();

                    GetIncidentData _req = new GetIncidentData();
                    GetIncidentDataResponse _resp = ws.GetIncidentData(_req);

                    int pageSize = ContextKeys.GRID_PAGE_SIZE;
                    gvItemTable.PageSize = pageSize;
                    gvItemTable.DataSource = _resp.Incident;
                    gvItemTable.DataBind();
                }
            }

            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void gvItemTable_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void btnAddnewIncident_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Response.Redirect("../SuperVisor/IncidentReport.aspx");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void IncidentFollowUp_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Response.Redirect("../SuperVisor/IncidentFollowUp.aspx");
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
                BindGridWithFilter();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnclear_Click(object sender, EventArgs e)
        {
            txtdatefrom.Text = "";
            txtdateto.Text = "";
            txtincidentno.Text = "";
            txtplaceofincident.Text = "";
            txtreport.Text = "";
            txtverifiedby.Text = "";
            getLocationName();
        }
    }
}
