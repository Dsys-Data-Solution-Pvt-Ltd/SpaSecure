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

using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.Services.DataService;
using SMS.SMSAppUtilities;
using SMS.BusinessEntities;

namespace SMS.SMSAdmin
{
    public partial class ShiftDeployment : System.Web.UI.Page
    {

        SqlConnection conn = new SqlConnection();
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                txtStaffNo.Focus();
                if (!IsPostBack)
                {
                    BindGrid();
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

        protected void Button3_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Response.Redirect("AddNewShift.aspx");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnSearch1_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {    
                BindGridWithFilter();
            }
            catch (System.Threading.ThreadAbortException)
            {
             }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
            
        }
       
        protected void gvShift_RowDataBound(object sender, GridViewRowEventArgs e)
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
                    gvShiftTable.Columns[0].FooterText = "Total Records: 20";
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
       
        protected void gvShift_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {    
                string _BTId = Convert.ToString(e.CommandArgument);

                if (e.CommandName == "EditRow")
                {
                    HttpContext.Current.Items.Add(ContextKeys.CTX_UPDATE_URL, Request.Url.ToString());
                    HttpContext.Current.Items.Add(ContextKeys.CTX_BT_ID, _BTId);
                    Server.Transfer("ShiftUpdate.aspx");
                }
                if (e.CommandName == "DeleteRow")
                {
                    DeleteItem(_BTId);
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


        private void DeleteItem(string argShiftId)
        {log4net.ILog logger = log4net.LogManager.GetLogger("File");
              
            try
            {
                if (!string.IsNullOrEmpty(argShiftId))
                {
                    AdminBLL ws = new AdminBLL();
                    DeleteShiftRequest _req = new DeleteShiftRequest();

                    _req.ShiftNo = argShiftId.ToString();

                    ws.DeleteShift(_req);
                    HttpContext.Current.Items.Add(ContextKeys.CTX_COMPLETE, "DELETE");
                    Server.Transfer("PassUpDateComplete.aspx");
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

        protected void gvShift_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {    
                if (e.NewPageIndex >= 0)
                {
                    gvShiftTable.PageIndex = e.NewPageIndex;
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

        private void BindGridWithFilter()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {    
                AdminBLL ws = new AdminBLL();
                GetShiftData objReq = new GetShiftData();
                string WhereClause = ReturnWhere();
                if (!string.IsNullOrEmpty(txtStaffNo.Text))
                {
                    objReq.Shift_ID = txtStaffNo.Text;
                }
                if (!string.IsNullOrEmpty(txtShiftName1.Text))
                {
                    objReq.shiftdep = txtShiftName1.Text;
                }
                if (!string.IsNullOrEmpty(WhereClause))
                {
                    objReq.WhereClause = WhereClause;
                }

                GetShiftDataResponse ret = ws.GetShift(objReq);
                int pageSize = ContextKeys.GRID_PAGE_SIZE;
                gvShiftTable.PageSize = pageSize;
                gvShiftTable.DataSource = ret.Shift_ID;
                gvShiftTable.DataBind();
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

            if (txtStaffNo.Text != "")
            {
                if (arr.Count == 1)
                {
                    makeWhereClause = " where ";
                    str += " where Shift_ID='" + txtStaffNo.Text + "'";
                    arr.Add("1");
                }
                else
                {
                    str += " and Shift_ID ='" + txtStaffNo.Text + "'";
                }
            }
            if (txtShiftName1.Text != "")
            {
                if (arr.Count == 1)
                {
                    str += " where shiftdep='" + txtShiftName1.Text + "'";
                    arr.Add("2");
                }
                else
                {
                    str += " and shiftdep ='" + txtShiftName1.Text + "'";
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
                GetShiftData _req = new GetShiftData();
                GetShiftDataResponse _resp = ws.GetShift(_req);

                int pageSize = ContextKeys.GRID_PAGE_SIZE;
                gvShiftTable.PageSize = pageSize;
                gvShiftTable.DataSource = _resp.Shift_ID;
                gvShiftTable.DataBind();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        
        
        void initgrid()
        {
             log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {    
            SqlConnection conn = new SqlConnection();
            AdminDAL c = new AdminDAL();
            conn = c.getconnection();

            string sa;
            sa = "select * from Shift_Master";

            SqlCommand cmd = new SqlCommand(sa, conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            adp.Fill(ds);
            gvShiftTable.DataSource = ds;
            gvShiftTable.DataBind();
             }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void gvShiftTable_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnClearItemAdd_Click(object sender, EventArgs e)
        {
            txtdatefrom.Text = "";
            txtdateto.Text = "";
            txtShiftName1.Text = "";
            txtStaffNo.Text = "";
        }

        protected void txtdateto_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtdatefrom_TextChanged(object sender, EventArgs e)
        {

        }

        protected void imgBtnFromDate3_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void imgBtnFromDate2_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}
