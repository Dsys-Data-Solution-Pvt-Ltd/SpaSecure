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

using Microsoft.SqlServer.Management.Trace;
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
    public partial class PastSite : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                txtLocationID.Focus();
                if (!IsPostBack)
                {
                    BindGridWithFilter();
                }
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
                GetLocationData objReq = new GetLocationData();
                string WhereClause = ReturnWhere();

                if (!string.IsNullOrEmpty(txtLocationID.Text))
                {
                    objReq.locid = txtLocationID.Text;
                }
                if (!string.IsNullOrEmpty(txtAddLocation.Text))
                {
                    objReq.loc = txtAddLocation.Text;
                }
                if (!string.IsNullOrEmpty(WhereClause))
                {
                    objReq.WhereClause = WhereClause;
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


                GetLocationDataResponse ret = ws.GetLocationData(objReq);
                int pageSize = ContextKeys.GRID_PAGE_SIZE;
                gvLoctionTable.PageSize = pageSize;
                gvLoctionTable.DataSource = ret.Location;
                gvLoctionTable.DataBind();
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

                if (txtLocationID.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        makeWhereClause = " where ";
                        str += " where Location_id='" + txtLocationID.Text + "'";
                        arr.Add("1");
                    }
                    else
                    {
                        str += " and Location_id='" + txtLocationID.Text + "'";
                    }
                }
                if (txtAddLocation.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where Location_name='" + txtAddLocation.Text + "'";
                        arr.Add("2");
                    }
                    else
                    {
                        str += " and Location_name ='" + txtAddLocation.Text + "'";
                    }
                }


                if (txtdateto.Text != "" && txtdatefrom.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where Date_From BETWEEN '" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                        arr.Add("5");
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
                        arr.Add("6");
                    }
                    else
                    {
                        str += " and Date_From='" + txtdatefrom.Text + "'";
                    }
                }
                if (str == "")
                {
                    str += " where Current_Status = 'Past'";
                }

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
            return (str);
        }



        protected void btnNewLocation_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Response.Redirect("../ADMIN/AddNewSite.aspx");
            }

            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
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
                    Server.Transfer("LocationUpdate.aspx");
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

                if (!string.IsNullOrEmpty(arglocationid))
                {
                    AdminBLL ws = new AdminBLL();
                    DeleteLocationRequest _req = new DeleteLocationRequest();

                    _req.locid = arglocationid.ToString();

                    ws.Deletelocation(_req);
                    HttpContext.Current.Items.Add(ContextKeys.CTX_COMPLETE, "DELETE");
                    Server.Transfer("AlertUpdateComplete.aspx");
                }

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
                    gvLoctionTable.PageIndex = e.NewPageIndex;
                    BindGridWithFilter();
                    AdminBLL ws = new AdminBLL();
                    GetLocationData _req = new GetLocationData();
                    GetLocationDataResponse _resp = ws.GetLocationData(_req);

                    int pageSize = ContextKeys.GRID_PAGE_SIZE;
                    gvLoctionTable.PageSize = pageSize;
                    gvLoctionTable.DataSource = _resp.Location;
                    gvLoctionTable.DataBind();
                }
            }
            catch (System.Threading.ThreadAbortException)
            {
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnClearLocationAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                txtLocationID.Text = "";
                txtAddLocation.Text = "";
                txtdatefrom.Text = "";
                txtdateto.Text = "";

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnSearchLocationAdd_Click(object sender, EventArgs e)
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


        private void BindGrid()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                AdminBLL ws = new AdminBLL();
                GetLocationData _req = new GetLocationData();
                GetLocationDataResponse _resp = ws.GetLocationData(_req);

                int pageSize = ContextKeys.GRID_PAGE_SIZE;
                gvLoctionTable.PageSize = pageSize;
                gvLoctionTable.DataSource = _resp.Location;
                gvLoctionTable.DataBind();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

        }

        protected void gvLoctionTable_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void txtdatefrom_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtdateto_TextChanged(object sender, EventArgs e)
        {

        }

        protected void imgBtnFromDate2_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void imgBtnFromDate3_Click(object sender, ImageClickEventArgs e)
        {

        }





    }
}
