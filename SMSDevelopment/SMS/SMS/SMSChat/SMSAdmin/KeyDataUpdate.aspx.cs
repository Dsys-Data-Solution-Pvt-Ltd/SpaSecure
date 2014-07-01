using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.Services.DataService;
using SMS.SMSAppUtilities;
using SMS.BusinessEntities;

namespace SMS.SMSAdmin
{
    public partial class KeyDataUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             
            String iBTID = string.Empty;
             log4net.ILog logger = log4net.LogManager.GetLogger("File");
             try
             {
                 txtKeyDesc.Focus();
                 if (!IsPostBack)
                 {
                     if (HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL] != null)
                     {
                         string strURL = HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL].ToString();
                         //((SMSmaster)this.Master).FilterContent(strURL, btnSave.ID, SMSAppUtilities.SMSAppEnums.ContentType.Update);
                         ((master.login)this.Master).FilterContent(strURL, btnSave.ID, SMSAppUtilities.SMSAppEnums.ContentType.Update);
                     
                     }
                     if (HttpContext.Current.Items[ContextKeys.CTX_BT_ID] != null)
                     {
                         iBTID = Convert.ToString(HttpContext.Current.Items[ContextKeys.CTX_BT_ID]);
                     }

                     PopulatePageCntrls(iBTID);
                 }
             }
             catch (Exception ex)
             {
                 logger.Info(ex.Message);
             }
        }

        protected void btnBackPassAdmin_Click(object sender, EventArgs e)
        { 
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
             //   Response.Redirect("~\addnewkey.aspx");
                Server.Transfer("AddNewKey.aspx");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
          log4net.ILog logger = log4net.LogManager.GetLogger("File");
          try
             {
                AdminAddNewKey objKey_Data = new AdminAddNewKey();
                AdminBLL ws = new AdminBLL();

                objKey_Data.key_no = txtKeyNo.Text;
                objKey_Data.Description = txtKeyDesc.Text;               
                objKey_Data.name = txtKeyName.Text;
                objKey_Data.position = txtKeyPosition.Text;
                objKey_Data.count = txtKeyConnt.Text;
                objKey_Data.nricno = txtKeyNRIC.Text;

                ws.UpdateKeyData(objKey_Data);
                HttpContext.Current.Items.Add(ContextKeys.CTX_COMPLETE, "UPDATE");
                Server.Transfer("AlertUpdateComplete.aspx");
           
        }
        catch (Exception ex)
        {
            logger.Info(ex.Message);
        }
     }

        private void PopulatePageCntrls(string argsBGID)
        {
            Int32 iCount = 0;
            GetNewKeyRequest ret = null;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
               
                    AdminBLL objAdminBLL = new AdminBLL();
                    GetNewKey objGetBillingTableRequest = new GetNewKey();
                    objGetBillingTableRequest.key_no = argsBGID.ToString();

                    objGetBillingTableRequest.WhereClause = " where Key_ID= '" + argsBGID + "' ";

                    ret = objAdminBLL.GetNewKey(objGetBillingTableRequest);

                      hdnBTID.Value = ret.Key[iCount].key_ID.ToString();
                     //hdnBTID.Value = ret.Key[iCount].Description.ToString();

                    txtKeyNo.Text = ret.Key[iCount].key_ID.ToString();
                    txtKeyDesc.Text = ret.Key[iCount].Description.ToString();
                   
                    txtKeyName.Text = ret.Key[iCount].name.ToString();
                    txtKeyPosition.Text = ret.Key[iCount].position.ToString();
                    txtKeyNRIC.Text = ret.Key[iCount].Staff_ID.ToString();
                    //txtKeyConnt.Text = ret.Key[iCount].Staff_ID.ToString();
                    
                //-------------------------------------------------------------------
                    DBConnectionHandler1 db = new DBConnectionHandler1();
                    SqlConnection cn = db.getconnection();
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("select NRICno from UserInformation where NRICno=@staffid", cn);
                    cmd.Parameters.AddWithValue("@staffid", txtKeyNRIC.Text);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {

                        txtKeyNRIC.Text = dr.GetString(0);
                        //txtKeyConnt.Text = "";
                        cn.Close();
                    }
                //-------------------------------------------------------------------
                
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

        }
    }
}
