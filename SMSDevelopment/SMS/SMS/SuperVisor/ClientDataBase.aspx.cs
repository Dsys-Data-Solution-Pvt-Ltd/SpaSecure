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

using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.Services.DataService;
using SMS.SMSAppUtilities;
using SMS.BusinessEntities;
using Telerik.Web.UI;

namespace SMS.SuperVisor
{
    public partial class ClientDataBase : System.Web.UI.Page
    {
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
                    dr.Close();
                    cn.Close();
                }
            }
            //---------------------------=---------------------------
            #endregion
                if (!IsPostBack)
                {
                    //BindGrid();
                    if (HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL] != null)
                    {
                        string strURL = HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL].ToString();
                    }
                }

                string ctrlname = Page.Request.Params.Get("__EVENTTARGET");
                string ctrlname1 = Page.Request.Params.Get("__eventargument");
                if (ctrlname != null)
                {
                    string controlname = ctrlname;//.Split('$')[ctrlname.Split('$').Length - 1].ToString();
                    if (!controlname.Contains("imdAdd") && !controlname.Contains("imgUpdate") && !controlname.Contains("imgDelete") && !controlname.Contains("imgCopy") && !controlname.Contains("CheckBox1"))
                    {
                        if (controlname.ToUpper().Contains("gvItemTable".ToUpper()))
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

        #region BindGrid
        protected void ToggleRowSelection(object sender, EventArgs e)
        {
            ((sender as CheckBox).NamingContainer as GridItem).Selected = (sender as CheckBox).Checked;
            bool checkHeader = true;
            List<string> lstreportsession = new List<string>();
            int ro = ((sender as CheckBox).NamingContainer as GridItem).ItemIndex;
            GridDataItem item = gvItemTable.MasterTableView.Items[ro];

            foreach (GridDataItem item1 in gvItemTable.MasterTableView.Items)
            {

                if (item == item1)
                {
                    if ((item.FindControl("CheckBox1") as CheckBox).Checked)
                    {

                        gvItemTable.Items[ro].Selected = true;


                        ViewState["Location_id"] = item.OwnerTableView.DataKeyValues[ro]["Location_id"];


                    }
                }
                else
                {
                    (item1.FindControl("CheckBox1") as CheckBox).Checked = false;
                }


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
                gvItemTable.PageSize = pageSize;
                gvItemTable.DataSource = _resp.Location;
                gvItemTable.DataBind();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

        }
        #endregion

        #region Old Code
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

                if (e.CommandName == "View")
                {
                    //HttpContext.Current.Items.Add(ContextKeys.CTX_UPDATE_URL, Request.Url.ToString());
                    //HttpContext.Current.Items.Add(ContextKeys.CTX_BT_ID, _BTId);
                    //Server.Transfer("ClientDatabaseReport.aspx");
                    Response.Redirect("ClientDatabaseReport.aspx?id=" + _BTId);//change by rakesh 

                }
                if (e.CommandName == "DeleteRow")
                {
                    //DeleteItem(_BTId);
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

        protected void gvItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (e.NewPageIndex >= 0)
                {
                   
                   
                    AdminBLL ws = new AdminBLL();
                    GetLocationData _req = new GetLocationData();
                    GetLocationDataResponse _resp = ws.GetLocationData(_req);

                   
                    gvItemTable.DataSource = _resp.Location;
                    gvItemTable.DataBind();
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

        #endregion





      

        # region Icon menu

        #region View

        private void PopulatePageCntrls(String argsBGID)
        {

            Int32 iCount = 0;
            GetLocationDataResponse ret = null;


            AdminBLL objAdminBLL = new AdminBLL();
            GetLocationData objGetBillingTableRequest = new GetLocationData();
            objGetBillingTableRequest.locid = argsBGID.ToString();
            objGetBillingTableRequest.WhereClause = " where Location_id= '" + argsBGID + "'";
            ret = objAdminBLL.GetLocationData(objGetBillingTableRequest);

            txtOperationName.Text = ret.Location[iCount].Operation_Name.ToString();
            txtOperationsContactTele.Text = ret.Location[iCount].O_cont.ToString();
            txtOperationsContactMobile.Text = ret.Location[iCount].O_Mob.ToString();
            txtOperationsContactEmail.Text = ret.Location[iCount].O_Email.ToString();
            txtOperationsContactFax.Text = ret.Location[iCount].O_Fax.ToString();


            txtManageName.Text = ret.Location[iCount].Management_Name.ToString();
            txtManageTele.Text = ret.Location[iCount].M_cont.ToString();
            txtManageMobile.Text = ret.Location[iCount].M_Mob.ToString();
            txtManageEmail.Text = ret.Location[iCount].M_Email.ToString();
            txtManageFax.Text = ret.Location[iCount].M_Fax.ToString();

           
        }
        protected void ImageView(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (ViewState["Location_id"] != null)
                {
                    PopulatePageCntrls(ViewState["Location_id"].ToString());
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
                Session["ctrl"] = printview;
                ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('NewPrintpage.aspx','PrintMe','height=700px,width=800px,scrollbars=1');</script>");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        #endregion

        #endregion

    }
}
