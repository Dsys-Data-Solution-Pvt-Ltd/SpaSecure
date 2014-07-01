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
    public partial class UpdateOffLeaveSetting : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (!IsPostBack)
                {
                    String iBTID = string.Empty;
                    if (!IsPostBack)
                    {
                        if (HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL] != null)
                        {
                            string strURL = HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL].ToString();
                            ((master.login)this.Master).FilterContent(strURL, btnNewItemAdd.ID, SMSAppUtilities.SMSAppEnums.ContentType.Update);
                        }
                        if (HttpContext.Current.Items[ContextKeys.CTX_BT_ID] != null)
                        {
                            iBTID = iBTID = HttpContext.Current.Items[ContextKeys.CTX_BT_ID].ToString();
                        }
                        PopulatePageCntrls(iBTID);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            } 
        }
        private void PopulatePageCntrls(String argsBGID)
        {
            DataSet dspan = dal.getdataset("Select * from OffleaveSetting where OLid = '" + argsBGID + "' ");
            if (dspan.Tables[0].Rows.Count > 0)
            {
                lblid.Text = argsBGID;
                ddlTypeOfLeave.Items.Add(dspan.Tables[0].Rows[0]["LeaveType"].ToString().Trim());
                txtsuperiorOfficer.Text = dspan.Tables[0].Rows[0]["SuperiorName"].ToString().Trim();
                txtNoOfday.Text = dspan.Tables[0].Rows[0]["NoOfDay"].ToString().Trim();
                ddlStaffname.Items.Add(dspan.Tables[0].Rows[0]["StaffName"].ToString().Trim());
            }
        }

        protected void btnNewItemAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                dal.executesql("Update OffleaveSetting Set LeaveType ='" + ddlTypeOfLeave.Text.Trim() + "',SuperiorName='" + txtsuperiorOfficer.Text.Trim() + "',NoOfDay='" + txtNoOfday.Text.Trim() + "' where OLid = '" + lblid.Text.Trim() + "' ");
                Response.Redirect("~/Supervisor/OffLeaveSetting.aspx");                
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnClearNewItemAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Response.Redirect("~/Supervisor/OffLeaveSetting.aspx");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }


    }
}
