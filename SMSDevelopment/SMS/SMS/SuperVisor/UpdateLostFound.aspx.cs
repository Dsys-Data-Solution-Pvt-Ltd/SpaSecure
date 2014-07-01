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
using SMS.Services.DataService;

using log4net;
using log4net.Config;

using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;

using SMS.SMSAppUtilities;
using SMS.BusinessEntities;

namespace SMS.SuperVisor
{
    public partial class UpdateLostFound : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                String iBTID = string.Empty;
                if (!IsPostBack)
                {
                    if (HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL] != null)
                    {
                        string strURL = HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL].ToString();
                        //((SMSmaster)this.Master).FilterContent(strURL, btnsave.ID, SMSAppUtilities.SMSAppEnums.ContentType.Update);
                        ((master.login)this.Master).FilterContent(strURL, btnsave.ID, SMSAppUtilities.SMSAppEnums.ContentType.Update);
                    }
                    if (HttpContext.Current.Items[ContextKeys.CTX_BT_ID] != null)
                    {
                        iBTID = iBTID = HttpContext.Current.Items[ContextKeys.CTX_BT_ID].ToString();
                    }
                    PopulatePageCntrls(iBTID);
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private void PopulatePageCntrls(String argsBGID)
        {

            DataSet dspan = dal.getdataset("Select Name,NRICno,ContNo,Date,Time,Description,Location from LostFoundItem where Lost_ID = '" + argsBGID + "' ");
            if (dspan.Tables[0].Rows.Count > 0)
            {
                txtLostID.Text = argsBGID;
                txtName.Text = dspan.Tables[0].Rows[0][0].ToString().Trim();
                txtNRIC.Text = dspan.Tables[0].Rows[0][1].ToString().Trim();
                txtTelephone.Text = dspan.Tables[0].Rows[0][2].ToString().Trim();
                calDate.Text = dspan.Tables[0].Rows[0][3].ToString().Trim();

                TimeSelector1.Date = Convert.ToDateTime(dspan.Tables[0].Rows[0][4].ToString().Trim());                
                txtdescription.Text = dspan.Tables[0].Rows[0][5].ToString().Trim();
                txtLocation.Text = dspan.Tables[0].Rows[0][6].ToString().Trim();               
            }

        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
               
                    string Status = ddlStatus.Text.Trim();
                    dal.executesql("Update LostFoundItem Set Name ='" + txtName.Text.Trim() + "',NRICno='" + txtNRIC.Text.Trim() + "',Location='" + txtLocation.Text.Trim() + "',ContNo='" + txtTelephone.Text.Trim() + "',Date='" + calDate.Text.Trim() + "',Description='" + txtdescription.Text.Trim() + "',Action='" + txtAckAction.Text.Trim() + "',AckClaimant='" + txtAckClaimant.Text.Trim() + "',AckNRICno='" + txtAckNRIC.Text.Trim() + "',AckTelephone='" + txtAckContact.Text.Trim() + "',AckAddress='" + txtAckAddress.Text.Trim() + "',LostStatus='" + Status + "' where Lost_ID = '" + txtLostID.Text.Trim() + "' ");
                    Server.Transfer("AdminLostFound.aspx");
                
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {               
              Server.Transfer("AdminLostFound.aspx");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

       

       
    }
}
