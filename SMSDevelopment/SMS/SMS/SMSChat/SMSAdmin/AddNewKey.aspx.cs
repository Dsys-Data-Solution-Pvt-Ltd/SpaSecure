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

namespace SMS.SMSAdmin
{
    public partial class AddNewKey : System.Web.UI.Page
    {
        AdminDAL a = new AdminDAL();
        DataAccessLayer dal = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                txtKeyNo.Focus();
                lblerror.Visible = false;

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

        protected void gvNewKey_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                string _BTId = Convert.ToString(e.CommandArgument);
                string state = string.Empty;

                SqlDataReader rd = dal.getDataReader("select status from addnewkey where Key_ID ='" + _BTId + "'");//change by rakesh
                if (rd.Read())
                {
                    state = (rd.GetValue(0).ToString().Trim());
                }

                if (e.CommandName == "EditRow")
                {
                    if (state == "Free")
                    {
                        HttpContext.Current.Items.Add(ContextKeys.CTX_UPDATE_URL, Request.Url.ToString());
                        HttpContext.Current.Items.Add(ContextKeys.CTX_BT_ID, _BTId);
                        Server.Transfer("KeyDataUpdate.aspx");
                    }
                    else
                    {
                        lblerror.Visible = true;
                        lblerror.Text = "Can't be Edit It's Reserved ..!";
                    }

                }
                if (e.CommandName == "DeleteRow")
                {
                    if (state == "Free")
                    {
                        DeleteItem(_BTId);
                    }
                    else
                    {
                        lblerror.Visible = true;
                        lblerror.Text = "Can't be Delete It's Reserved ..!";
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        private void DeleteItem(string argKeyID)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (!string.IsNullOrEmpty(argKeyID))
                {
                    AdminBLL ws = new AdminBLL();
                    DeleteKeyRequest _req = new DeleteKeyRequest();

                    _req.KeyNo = argKeyID.ToString();

                    ws.DeleteKey(_req);
                    HttpContext.Current.Items.Add(ContextKeys.CTX_COMPLETE, "DELETE");
                    Server.Transfer("AlertUpdateComplete.aspx");
                }

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
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
                    GetNewKey _req = new GetNewKey();
                    GetNewKeyRequest _resp = ws.GetNewKey(_req);

                    int pageSize = ContextKeys.GRID_PAGE_SIZE;
                    gvKeySearch.PageSize = pageSize;
                    gvKeySearch.DataSource = _resp.Key;
                    gvKeySearch.DataBind();
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnNewBTable_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Response.Redirect("NewKeyAdd.aspx");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnClearKeyAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                txtdatefrom.Text = "";
                txtdateto.Text = "";
                ddlstatus.Text = "";
                txtKeyName.Text = "";
                txtKeyNo.Text = "";
                txtKeyNRIC.Text = "";
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnSearchKeyAdd_Click(object sender, EventArgs e)
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
        protected void gvNewKey_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void BindGridWithFilter()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                AdminBLL ws = new AdminBLL();
                GetNewKey objReq = new GetNewKey();
                string WhereClause = ReturnWhere();

                if (!string.IsNullOrEmpty(txtKeyNo.Text))
                {
                    objReq.key_no = txtKeyNo.Text;
                }
                if (!string.IsNullOrEmpty(ddlstatus.Text))
                {
                    objReq.status = ddlstatus.Text;
                }
                if (!string.IsNullOrEmpty(txtKeyName.Text))
                {
                    objReq.name = txtKeyName.Text;
                }
                if (!string.IsNullOrEmpty(txtKeyNRIC.Text))
                {
                    objReq.nricno = txtKeyNRIC.Text;
                }
                if (!string.IsNullOrEmpty(WhereClause))
                {
                    objReq.WhereClause = WhereClause;
                }

                if (!string.IsNullOrEmpty(txtdateto.Text))
                {
                    if (!string.IsNullOrEmpty(txtdatefrom.Text))
                    {
                        objReq.Date_From = txtdatefrom.Text;
                        objReq.Date_From = txtdatefrom.Text;
                    }
                }

                if (!string.IsNullOrEmpty(txtdatefrom.Text))
                {
                    if (string.IsNullOrEmpty(txtdateto.Text))
                    {
                        objReq.Date_From = txtdatefrom.Text;
                    }
                }


                GetNewKeyRequest ret = ws.GetNewKey(objReq);
                int pageSize = ContextKeys.GRID_PAGE_SIZE;
                gvKeySearch.PageSize = pageSize;
                gvKeySearch.DataSource = ret.Key;
                gvKeySearch.DataBind();
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

                if (txtKeyNo.Text.Trim() != "")
                {
                    if (arr.Count == 1)
                    {
                        makeWhereClause = " where ";
                        str += " where Key_ID='" + txtKeyNo.Text + "'";
                        arr.Add("1");
                    }
                    else
                    {
                        str += " and Key_ID='" + txtKeyNo.Text + "'";
                    }
                }
                if (ddlstatus.Text.Trim() != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where status='" + ddlstatus.Text + "'";
                        arr.Add("2");
                    }
                    else
                    {
                        str += " and status='" + ddlstatus.Text + "'";
                    }
                }
                if (txtKeyName.Text.Trim() != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where name='" + txtKeyName.Text + "'";
                        arr.Add("3");

                    }
                    else
                    {
                        str += " and name='" + txtKeyName.Text + "'";
                    }
                }
                if (txtKeyNRIC.Text.Trim() != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where Staff_ID='" + txtKeyNRIC.Text + "'";
                        arr.Add("4");
                    }
                    else
                    {
                        str += " and Staff_ID='" + txtKeyNRIC.Text + "'";
                    }
                }

                if (txtdatefrom.Text.Trim() != "" && txtdateto.Text.Trim() != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where Date_From BETWEEN '" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                        arr.Add("5");
                    }
                    else
                    {
                        str += " and Date_From BETWEEN'" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                    }
                }

                if (txtdatefrom.Text.Trim() != "" && txtdateto.Text.Trim() == "")
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
                GetNewKey _req = new GetNewKey();
                GetNewKeyRequest _resp = ws.GetNewKey(_req);

                int pageSize = ContextKeys.GRID_PAGE_SIZE;
                gvKeySearch.PageSize = pageSize;
                gvKeySearch.DataSource = _resp.Key;
                gvKeySearch.DataBind();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }


        protected void txtdatefrom_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtdateto_TextChanged(object sender, EventArgs e)
        {

        }

        protected void imgBtnFromDate3_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void imgBtnFromDate2_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnChkinkey_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Response.Redirect("../SuperVisor/CheckInkey.aspx");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnChkoutkey_Click(object sender, EventArgs e)
        {

        }

    }
}

