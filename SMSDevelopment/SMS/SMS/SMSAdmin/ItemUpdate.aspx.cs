using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;


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
    public partial class ItemUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           String iBTID = String.Empty;
           log4net.ILog logger = log4net.LogManager.GetLogger("File");
           try
           {
            txtItemdescription.Focus();
            if (!IsPostBack)
            {
                if (HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL] != null)
                {
                    string strURL = HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL].ToString();
                    //((SMSmaster)this.Master).FilterContent(strURL, btnSave.ID, SMSAppUtilities.SMSAppEnums.ContentType.Update);
                }
                
                if (HttpContext.Current.Items[ContextKeys.CTX_BT_ID] != null)
                {
                    iBTID = Convert.ToString(HttpContext.Current.Items[ContextKeys.CTX_BT_ID]);
                }
                //PopulatePageCntrls(iBTID);
             }
            }
            catch (Exception ex)
              {
                logger.Info(ex.Message);
              }


        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
           log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
               // Response.Redirect(SMSAppUtilities.SMSAppUtilities.RetrieveMainURL("AdminItem.aspx"));
                Server.Transfer("AdminItem.aspx");
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
                //ItemData objItem_Data = new ItemData();
                //AdminBLL ws = new AdminBLL();
                //DateTime datetime;

                //objItem_Data.Item_no = txtItemNo.Text;
                //objItem_Data.Item_Description =txtItemdescription.Text;
                //objItem_Data.Item_quantity =txtitemquantity.Text;

                //objItem_Data.loged_Nric =txtlogednric.Text;
                //objItem_Data.loged_Name =txtlogedname.Text;
                //objItem_Data.loged_CompName =txtlogedcompname.Text;

                //objItem_Data.Signed_Nric =txtsignednric.Text;
                //objItem_Data.Signed_Name =txtsignedname.Text;
                //objItem_Data.Signed_CompName = txtsignedcompname.Text;
                //objItem_Data.Remarks = txtremarks.Text;

                //objItem_Data.Found_Nric =txtfoundnric.Text;
                //objItem_Data.Status = cmbstatus.Text;
                //objItem_Data.Foundremark =txtfoundremark.Text;

                //objItem_Data.loged_Time = TimeSelector1.Date;
                //objItem_Data.Signed_Time = TimeSelector2.Date;

                //ws.UpdateItemData(objItem_Data);
                //HttpContext.Current.Items.Add(ContextKeys.CTX_COMPLETE, "UPDATE");
                //Server.Transfer("AlertUpdateComplete.aspx");
            }
            
              catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        
        //private void PopulatePageCntrls(string argsBGID)
        //{
        //    Int32 iCount = 0;
        //    GetItemDataResponse ret = null;

        //   log4net.ILog logger = log4net.LogManager.GetLogger("File");
        //    try
        //    {
        //        DateTime dt;
        //        AdminBLL objAdminBLL = new AdminBLL();
        //        GetItemData objGetBillingTableRequest = new GetItemData();
        //        objGetBillingTableRequest.Model_No = argsBGID.ToString();

        //        objGetBillingTableRequest.WhereClause = " where Model_No= '" + argsBGID + "' ";

        //        ret = objAdminBLL.GetItemData(objGetBillingTableRequest);

        //        hdnBTID.Value = ret.Item[iCount].Model_No.ToString();
               
                
        //       txtItemNo.Text = ret.Item[iCount].Model_No.ToString();
        //       txtItemdescription.Text = ret.Item[iCount].Item_Description.ToString();
        //       txtitemquantity.Text = ret.Item[iCount].Item_quantity.ToString();

        //       txtlogednric.Text = ret.Item[iCount].loged_Nric.ToString();
        //       txtlogedname.Text = ret.Item[iCount].loged_Name.ToString();
        //       txtlogedcompname.Text = ret.Item[iCount].loged_CompName.ToString();

        //       txtsignednric.Text = ret.Item[iCount].Signed_Nric.ToString();
        //       txtsignedname.Text = ret.Item[iCount].Signed_Name.ToString();
        //       txtsignedcompname.Text = ret.Item[iCount].Signed_CompName.ToString();
        //       txtremarks.Text = ret.Item[iCount].Remarks.ToString();

        //       txtfoundnric.Text = ret.Item[iCount].Found_Nric.ToString();
        //       cmbstatus.Text = ret.Item[iCount].Status.ToString();
        //       txtfoundremark.Text = ret.Item[iCount].Foundremark.ToString();

        //        dt = Convert.ToDateTime(ret.Item[iCount].loged_Time);
        //        TimeSelector1.Date = dt;
        //        dt = Convert.ToDateTime(ret.Item[iCount].Signed_Time);
        //        TimeSelector2.Date = dt;
               
                    
        //    }
        //      catch (Exception ex)
        //    {
        //        logger.Info(ex.Message);
        //    }
        //}

    }
}
