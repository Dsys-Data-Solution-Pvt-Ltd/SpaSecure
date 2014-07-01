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

namespace SMS.SuperVisor
{
    public partial class AfterActionReview_Master : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {

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
                    //HttpContext.Current.Items.Add(ContextKeys.CTX_UPDATE_URL, Request.Url.ToString());
                    //HttpContext.Current.Items.Add(ContextKeys.CTX_BT_ID, _BTId);
                    //Response.Redirect("../SMSAdmin/LocationUpdate.aspx");
                    //Server.Transfer("ChangeActionReviewStage2.aspx?id=" + _BTId.ToString());
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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Server.Transfer("AfterActionReview.aspx");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }



    }
}
