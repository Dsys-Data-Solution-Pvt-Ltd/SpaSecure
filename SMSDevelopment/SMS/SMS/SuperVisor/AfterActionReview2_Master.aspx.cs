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
using SMS.SMSAppUtilities;
using SMS.Services.BusinessServices;
using Telerik.Web.UI;

namespace SMS.SuperVisor
{
    public partial class AfterActionReview2 : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {

                //if (!IsPostBack)
                //{
                //    BindGridWithFilter();
                //}

                string ctrlname = Page.Request.Params.Get("__EVENTTARGET");
                string ctrlname1 = Page.Request.Params.Get("__eventargument");
                if (ctrlname != null)
                {
                    string controlname = ctrlname;//.Split('$')[ctrlname.Split('$').Length - 1].ToString();
                    if (!controlname.Contains("imdAdd") && !controlname.Contains("imgUpdate") && !controlname.Contains("imgDelete") && !controlname.Contains("imgCopy") && !controlname.Contains("CheckBox1"))
                    {
                        if (controlname.ToUpper().Contains("gvLoctionTable".ToUpper()))
                        {
                            if (ctrlname1 != null)
                            {
                                if (ctrlname1.Contains("RowClick"))
                                { }
                                else if (ctrlname1.ToUpper().Contains("FIRECOMMAND") || ctrlname1 == "")
                                {
                                    BindGridWithFilter();
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
                int pageSize = ContextKeys.GRID_PAGE_SIZE;
                DataSet ds = dal.getdataset("select * from tblCustomerComplaint with(nolock)");
                gvLoctionTable.PageSize = pageSize;
                gvLoctionTable.DataSource = ds.Tables[0];
                gvLoctionTable.DataBind();
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
                    Server.Transfer("ChangeActionReviewStage2.aspx?id=" + _BTId.ToString());
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
                    DataSet ds = dal.getdataset("select * from tblCustomerComplaint with(nolock)");
                    int pageSize = ContextKeys.GRID_PAGE_SIZE;
                    gvLoctionTable.PageSize = pageSize;
                    gvLoctionTable.DataSource = ds.Tables[0];
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

        protected void ToggleRowSelection(object sender, EventArgs e)
        {
            ((sender as CheckBox).NamingContainer as GridItem).Selected = (sender as CheckBox).Checked;
            bool checkHeader = true;
           // List<string> lstreportsession = new List<string>();
            int ro = ((sender as CheckBox).NamingContainer as GridItem).ItemIndex;
            GridDataItem item = gvLoctionTable.MasterTableView.Items[ro];

            foreach (GridDataItem item1 in gvLoctionTable.MasterTableView.Items)
            {

                if (item == item1)
                {
                    if ((item.FindControl("CheckBox1") as CheckBox).Checked)
                    {

                        gvLoctionTable.Items[ro].Selected = true;


                        ViewState["PRVID"] = item.OwnerTableView.DataKeyValues[ro]["intID"];


                    }
                }
                else
                {
                    (item1.FindControl("CheckBox1") as CheckBox).Checked = false;
                }


            }

        }

        # region Icon menu

        #region View

        public void FillView()
        {
            if (ViewState["PRVID"] != null)
            {
                int id =Convert.ToInt32(ViewState["PRVID"].ToString());
                DataSet ds = dal.getdataset("select * from tblCustomerComplaint with(nolock) where intID=" + id);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    txtIssueRaised.Text = ds.Tables[0].Rows[0]["IssueRaised"].ToString();
                    txtdescProb.Text = ds.Tables[0].Rows[0]["strDescription"].ToString();
                    txtBy.Text = ds.Tables[0].Rows[0]["strRaisedBy"].ToString();
                    calDate.Text = ds.Tables[0].Rows[0]["dtmDate"].ToString();
                }
            }
        }
        protected void ImageView(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (ViewState["PRVID"] != null)
                {
                    FillView();
                    ModalPopupView.Show();
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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {

                string root = txtRootCause.Text.ToString().Trim();
                string AOC = txtAOC.Text.ToString().Trim();
                string AO = txtAO.Text.ToString().Trim();
                string GO = txtGO.Text.ToString().Trim();
                string AR = txtAR.Text.ToString().Trim();
                string ART = txtART.Text.ToString().Trim();
                string expdate = txtexpected.Text.ToString().Trim();
                int id = Convert.ToInt32(Request.QueryString["id"].ToString());

                string update = "update tblCustomerComplaint set strCause='" + root + "',Analysis='" + AOC + "',AOU='" + AO + "',Goals='" + GO + "',strActionFix='" + AR + "',strActionPrevent='" + ART + "',dtmExpectedCompletion='" + expdate + "',status='Operations Replied' where intID=" + id;
                dal.executesql(update);
               // lblerror.Text = "Submitted to MD";
               // lblerror.Visible = true;
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
