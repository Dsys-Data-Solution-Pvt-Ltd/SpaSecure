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
using log4net;
using log4net.Config;
using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.Services.DataService;
using SMS.SMSAppUtilities;
using SMS.BusinessEntities;

namespace SMS.ADMIN
{
    public partial class UpdateInventory : System.Web.UI.Page
    {
        DataAccessLayer Dal = new DataAccessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            String iBTID = String.Empty;
            lblErrMsg.Visible = false;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
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
                    FillItemType();
                    PopulatePageCntrls(iBTID);
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private void FillItemType()
        {
            ddItemType.Items.Clear();
            SqlParameter[] para1 = new SqlParameter[0];
            DataTable dsItemtype = Dal.executeprocedure("SP_GetInventorydata", para1, true);
            if (dsItemtype.Rows.Count > 0)
            {
                ddItemType.DataSource = dsItemtype;
                ddItemType.DataTextField = "Item_type";
                ddItemType.DataValueField = "Item_type";
                ddItemType.DataBind();
                ddItemType.Items.Insert(0, new ListItem("Select", "Select", true));
            }
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                AddNewInventory objInventory_Data = new AddNewInventory();
                AdminBLL ws = new AdminBLL();
                if (txtItemName.Text.Trim() != "")
                {
                    objInventory_Data.Item_id = txtItemID.Text.Trim();
                    objInventory_Data.Item_Name = txtItemName.Text.Trim();
                    objInventory_Data.Item_qty = txtqunatity.Text.Trim();
                    objInventory_Data.CreatedBy = txtCreatedBy.Text.Trim();
                    objInventory_Data.Item_Type = ddItemType.Text.Trim();
                    objInventory_Data.CreatedTime = Convert.ToDateTime(txtCreatedTime.Text.Trim());
                    objInventory_Data.EditBy = txtEditBy.Text.Trim();

                    if (txtCreatedBy.Text.Trim() != "")
                    {
                        objInventory_Data.EditTime = DateTime.Now;
                    }                    

                    ws.UpdateInventoryData(objInventory_Data);
                    HttpContext.Current.Items.Add(ContextKeys.CTX_COMPLETE, "UPDATE");
                    Server.Transfer("CompleteForm.aspx");
                }
                else
                {
                    lblErrMsg.Visible = true;
                    lblErrMsg.Text = "Invalid Item Name ..!";
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        private void PopulatePageCntrls(String argsBGID)
        {
            Int32 iCount = 0;
            GetInventoryResponce ret = null;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                AdminBLL objAdminBLL = new AdminBLL();
                GetInventoryData objGetInventoryTableRequest = new GetInventoryData();
                objGetInventoryTableRequest.Itemid = argsBGID.ToString();
                objGetInventoryTableRequest.WhereClause = " where Item_id='"+ argsBGID +"' " ;
                ret = objAdminBLL.GetInventoryData(objGetInventoryTableRequest);

                hdnBTID.Value = ret.Itemid[iCount].Item_id.ToString();
                hdnBTID.Value = ret.Itemid[iCount].Item_Name.ToString();
                
                txtItemID.Text = ret.Itemid[iCount].Item_id.ToString();
                txtItemName.Text = ret.Itemid[iCount].Item_Name.ToString();
                txtqunatity.Text = ret.Itemid[iCount].Item_qty.ToString();
                txtCreatedBy.Text = ret.Itemid[iCount].CreatedBy.ToString();
                ddItemType.Text = ret.Itemid[iCount].Item_Type.ToString();
                txtCreatedTime.Text = ret.Itemid[iCount].CreatedTime.ToString();
                txtEditBy.Text = ret.Itemid[iCount].EditBy.ToString();
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
                Server.Transfer("AdminInvetory.aspx");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

    }
}
