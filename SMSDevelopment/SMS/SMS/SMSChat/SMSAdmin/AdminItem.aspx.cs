using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
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
    public partial class AdminItem : System.Web.UI.Page
    {
        
        DataAccessLayer dal = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                txtItemNo.Focus();
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

        protected void btnNewItem_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Response.Redirect("NewItemAdd.aspx");
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

                if (e.CommandName == "ViewRow")
                {
                    HttpContext.Current.Items.Add(ContextKeys.CTX_UPDATE_URL, Request.Url.ToString());
                    HttpContext.Current.Items.Add(ContextKeys.CTX_BT_ID, _BTId);
                    Server.Transfer("FollowUpReport.aspx");
                   //  Response.Redirect("../SMSAdmin/IncidentFollowUpReport1.aspx");
                }

                if (e.CommandName == "EditRow")
                {
                    HttpContext.Current.Items.Add(ContextKeys.CTX_UPDATE_URL, Request.Url.ToString());
                    HttpContext.Current.Items.Add(ContextKeys.CTX_BT_ID, _BTId);
                    Server.Transfer("ItemUpdate.aspx");
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

        private void DeleteItem(string argEmbossId)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (!string.IsNullOrEmpty(argEmbossId))
                {
                    AdminBLL ws = new AdminBLL();
                    DeleteItemRequest _req = new DeleteItemRequest();

                    _req.ItemNo = argEmbossId.ToString();

                    ws.DeleteItem(_req);
                    HttpContext.Current.Items.Add(ContextKeys.CTX_COMPLETE, "DELETE");
                    Server.Transfer("AlertUpdateComplete.aspx");
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
                    BindGridWithFilter();
                    AdminBLL ws = new AdminBLL();
                    GetItemData _req = new GetItemData();
                    GetItemDataResponse _resp = ws.GetItemData(_req);

                    int pageSize = ContextKeys.GRID_PAGE_SIZE;
                    gvItemTable.PageSize = pageSize;
                    gvItemTable.DataSource = _resp.Item;
                    gvItemTable.DataBind();
                }
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

        private void BindGridWithFilter()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                AdminBLL ws = new AdminBLL();
                GetItemData objReq = new GetItemData();
                string WhereClause = ReturnWhere();
                if (!string.IsNullOrEmpty(txtItemNo.Text))
                {
                    objReq.Model_No = txtItemNo.Text;
                }
                if (!string.IsNullOrEmpty(txtItemDes.Text))
                {
                    objReq.Item_Description = txtItemDes.Text;
                }
                if (!string.IsNullOrEmpty(txtItemLoggedByName.Text))
                {
                    //objReq.loged_Nric = txtItemLoggedByName.Text;
                }

                if (!string.IsNullOrEmpty(txtItemSignedOutBy.Text))
                {
                   // objReq.Signed_Nric = txtItemSignedOutBy.Text;
                }

                if (!string.IsNullOrEmpty(WhereClause))
                {
                    objReq.WhereClause = WhereClause;
                }

                GetItemDataResponse ret = ws.GetItemData(objReq);
                int pageSize = ContextKeys.GRID_PAGE_SIZE;
                gvItemTable.PageSize = pageSize;
                gvItemTable.DataSource = ret.Item;
                gvItemTable.DataBind();
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

                if (txtItemNo.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        makeWhereClause = " where ";
                        str += " where Item_no='" + txtItemNo.Text + "'";
                        arr.Add("1");
                    }
                    else
                    {
                        str += " and Item_no='" + txtItemNo.Text + "'";
                    }
                }
                if (txtItemDes.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where Item_Description='" + txtItemDes.Text + "'";
                        arr.Add("2");
                    }
                    else
                    {
                        str += " and Item_Description='" + txtItemDes.Text + "'";
                    }
                }

                if (txtItemLoggedByName.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where loged_Nric='" + txtItemLoggedByName.Text + "'";
                        arr.Add("3");
                    }
                    else
                    {
                        str += " and loged_Nric='" + txtItemLoggedByName.Text + "'";
                    }
                }


                if (txtItemSignedOutBy.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where Signed_Nric='" + txtItemSignedOutBy.Text + "'";
                        arr.Add("4");
                    }
                    else
                    {
                        str += " and Signed_Nric='" + txtItemSignedOutBy.Text + "'";
                    }
                }
                if (txtdatefrom.Text != "" && txtdateto.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where loged_Time BETWEEN '" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                        arr.Add("5");
                    }
                    else
                    {
                        str += " and loged_Time BETWEEN'" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                    }

                }

                if (txtdatefrom.Text != "" && txtdateto.Text == "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where loged_Time='" + txtdatefrom.Text + "'";
                        arr.Add("6");
                    }
                    else
                    {
                        str += " and loged_Time='" + txtdatefrom.Text + "'";
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
                GetItemData _req = new GetItemData();
                GetItemDataResponse _resp = ws.GetItemData(_req);

                int pageSize = ContextKeys.GRID_PAGE_SIZE;
                gvItemTable.PageSize = pageSize;
                gvItemTable.DataSource = _resp.Item;
                if (_resp.Item.Count == 0)
                {
                    //item1.Visible = false;
                    //item2.Visible = false;
                }
                gvItemTable.DataBind();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnClearItemAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                txtItemDes.Text = "";
                txtItemLoggedByName.Text = "";
                txtItemNo.Text = "";
                txtItemSignedOutBy.Text = "";
                txtdatefrom.Text = "";
                txtdateto.Text = "";
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void gvItemTable_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnNewItem_Click1(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Response.Redirect("../SMSUsers/AddItem.aspx");
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

        protected void imgBtnFromDate2_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void imgBtnFromDate3_Click(object sender, ImageClickEventArgs e)
        {

        }

    }
}

