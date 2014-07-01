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
    public partial class UpdateAdminAddItem : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                               
                lblerr1.Visible = false;
                errorIssuedByNRIC.Visible = false;
                txtItemName.Focus();
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

            DataSet dspan = dal.getdataset("Select Model_No,Item_Name,Item_quantity,IssuedBy_Name,IssuedBy_Nric,IssuedBy_Position,IssuedTo_Name,IssuedTo_Nric,IssuedTo_Position,Remark from AddNewItem where AddItem_ID = '" + argsBGID + "' ");
            if (dspan.Tables[0].Rows.Count > 0)
            {
                txtItemID.Text = argsBGID;
                txtModelNo.Text = dspan.Tables[0].Rows[0][0].ToString().Trim();
                txtItemName.Text = dspan.Tables[0].Rows[0][1].ToString().Trim();
                txtItemquantity.Text = dspan.Tables[0].Rows[0][2].ToString().Trim();

                txtIssuedByName.Text = dspan.Tables[0].Rows[0][3].ToString().Trim();
                txtIssuedByNRIC.Text = dspan.Tables[0].Rows[0][4].ToString().Trim();
                txtIssuedByPosition.Text = dspan.Tables[0].Rows[0][5].ToString().Trim();

                txtIssuedToName.Text = dspan.Tables[0].Rows[0][6].ToString().Trim();
                txtIssuedToNRIC.Text = dspan.Tables[0].Rows[0][7].ToString().Trim();
                txtIssuedToPosition.Text = dspan.Tables[0].Rows[0][8].ToString().Trim();

                txtComment.Text = dspan.Tables[0].Rows[0][9].ToString().Trim();
            }

        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                dal.executesql("Update AddNewItem Set Model_No ='" + txtModelNo.Text.Trim() + "',Item_Name='" + txtItemName.Text.Trim() + "',Item_quantity='" + txtItemquantity.Text.Trim() + "',IssuedBy_Name='" + txtIssuedByName.Text.Trim() + "',IssuedBy_Nric='" + txtIssuedByNRIC.Text.Trim() + "',IssuedBy_Position='" + txtIssuedByPosition.Text.Trim() + "',IssuedTo_Name='" + txtIssuedToName.Text.Trim() + "',IssuedTo_Nric='" + txtIssuedToNRIC.Text.Trim() + "',IssuedTo_Position='" + txtIssuedToPosition.Text.Trim() + "',Remark='" + txtComment.Text.Trim() + "',Status='"+ddlStatus.Text.Trim()+"' where AddItem_ID = '" + txtItemID.Text.Trim() + "' ");
                Server.Transfer("AdminAddItem.aspx");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
               Server.Transfer("AdminAddItem.aspx");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }





    }
}
