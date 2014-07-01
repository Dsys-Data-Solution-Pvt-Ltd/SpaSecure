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

using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.Services.DataService;
using SMS.SMSAppUtilities;
using SMS.BusinessEntities;

namespace SMS.SuperVisor
{
    public partial class OffLeaveReport : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            String iBTID = string.Empty;

            if (!IsPostBack)
            {
                if (HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL] != null)
                {
                    string strURL = HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL].ToString();                    
                }
                if (HttpContext.Current.Items[ContextKeys.CTX_BT_ID] != null)
                {
                    iBTID = iBTID = HttpContext.Current.Items[ContextKeys.CTX_BT_ID].ToString();
                }

                PopulatePageCntrls(iBTID);
            }
        }

        private void PopulatePageCntrls(String argsBGID)
        {
            
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                DataSet dsget = dal.getdataset("Select Name,NRIC,Assignment,DateOfApplication,LeaveFromDate,LeaveToDate,Approved_Status From OffLeaveApplication Where Leave_id='"+argsBGID+"' ");
                if (dsget.Tables[0].Rows.Count > 0)
                {
                    txtname.Text = dsget.Tables[0].Rows[0][0].ToString().Trim();
                    txtNRIC.Text = dsget.Tables[0].Rows[0][1].ToString().Trim();
                    txtAssignment.Text = dsget.Tables[0].Rows[0][2].ToString().Trim();
                    txtDateofApplication.Text = dsget.Tables[0].Rows[0][3].ToString().Trim();
                    txtLeaveFrom.Text = dsget.Tables[0].Rows[0][4].ToString().Trim();
                    txtLeaveTo.Text = dsget.Tables[0].Rows[0][5].ToString().Trim();
                    txtApproved.Text = dsget.Tables[0].Rows[0][6].ToString().Trim();
                  //txtname.Text = dsget.Tables[0].Rows[0][0].ToString().Trim();

                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }



        protected void btnprint_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Session["ctrl"] = printview;
                ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('printpage.aspx','PrintMe','height=700px,width=800px,scrollbars=1');</script>");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }



    }
}
