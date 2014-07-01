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
    public partial class UpdatePenaltySecurity : System.Web.UI.Page
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

            DataSet dspan = dal.getdataset("Select Heading,Clause,Fine,Penality_id from PenalitySecurityPersonnel where Penality_id = '" + argsBGID + "' ");
            if (dspan.Tables[0].Rows.Count > 0)
            {
                
                txtHeading.Text = dspan.Tables[0].Rows[0][0].ToString().Trim();
                txtClause.Text = dspan.Tables[0].Rows[0][1].ToString().Trim();
                txtFine.Text = dspan.Tables[0].Rows[0][2].ToString().Trim();
                txtID.Text = dspan.Tables[0].Rows[0][3].ToString().Trim();
            }
          
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                dal.executesql("Update PenalitySecurityPersonnel set Heading  = '" + txtHeading.Text.Trim() + "',Clause = '" + txtClause.Text.Trim() + "',Fine ='" + txtFine.Text.Trim() + "' Where Penality_id = '" + txtID.Text.Trim() + "' ");
                Server.Transfer("PenaltySecurityPersnnel.aspx");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Response.Redirect("PenaltySecurityPersnnel.aspx");
        }




    }
}
