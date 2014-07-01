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
using System.Data.SqlClient;
using log4net;
using log4net.Config;
using System.Text.RegularExpressions;
using SMS.BusinessEntities;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using System.Globalization;


namespace SMS.ADMIN
{
    public partial class Add_New_Inventory : System.Web.UI.Page
    {

        DataAccessLayer Dal = new DataAccessLayer();
        AdminDAL adal = new AdminDAL();
        AdminBLL bll = new AdminBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
               // txtItemName.Focus();
                lblerror.Visible = false;   
             
                if(!IsPostBack)
                {
                    FillItemType();
                }

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }


        private void FillItemType()
        {

            string ID = "Item_Type";
            SqlParameter[] para1 = new SqlParameter[1];
            para1[0] = new SqlParameter("@ID", ID);
            DataTable dsInventory = Dal.executeprocedure("sp_getLogvaluebyID", para1, true);
            if (dsInventory.Rows.Count > 0)
            {
                ddItemType.DataSource = dsInventory;
                ddItemType.DataTextField = "Description";
                ddItemType.DataValueField = "Description";
                ddItemType.DataBind();
                ddItemType.Items.Insert(0, new System.Web.UI.WebControls.ListItem(" ", " ", true));
            }
        }


        protected void btnaddNewItem_Click(object sender, EventArgs e)
        {
           log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (ddItemType.Text.Trim() != "" && txtItemName.Text.Trim() != "" && txtCreatedBy.Text.Trim() != "" && ddItemType.Text.Trim() != "")
                {
                    AddNewInventoryRequest objAddNewInventoryRequest = new AddNewInventoryRequest();
                    AddNewInventory objaddInventory = new AddNewInventory();

                    int newItemquantity = Convert.ToInt32(txtqunatity.Text.Trim());
                    objaddInventory.Item_Name = txtItemName.Text.Trim();
                    objaddInventory.CreatedBy = txtCreatedBy.Text.Trim();
                    objaddInventory.Item_Type = ddItemType.Text.Trim();
                    objaddInventory.CreatedTime = Convert.ToDateTime(DateTime.Now);
                    objaddInventory.Item_qty = Convert.ToString(Itemqty(ddItemType.Text.Trim(), txtItemName.Text.Trim(), newItemquantity));
                    objaddInventory.SerialNo = txtSerialNo.Text;
                    objaddInventory.ModelNo = txtModelno.Text;
                    AdminBLL ws = new AdminBLL();
                    ws.AddNewInventory(objaddInventory);
                    HttpContext.Current.Items.Add("COMPLETE", "INSERT");
                    Server.Transfer("CompleteForm.aspx");
                }
                else
                {
                    lblerror.Visible = true;
                    lblerror.Text = "Please Fill All Entries ..!";
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }


        private int Itemqty(string type, string name, int Newqty)
        {

            int ItemID = 0;
            int Oldqty = 0;
            int bothqty = 0;            
            int nwqty = Newqty;

            DataSet dsItemdqty = Dal.getdataset("Select Item_id,Item_qty from AddNewInvetory where Item_Type='" + type + "' and Item_Name ='" + name + "' ");
            if (dsItemdqty.Tables[0].Rows.Count > 0)
            {
                ItemID = Convert.ToInt32(dsItemdqty.Tables[0].Rows[0][0].ToString().Trim());
                Oldqty = Convert.ToInt32(dsItemdqty.Tables[0].Rows[0][1].ToString().Trim());

                bothqty = Oldqty + nwqty;

                Dal.executesql("Update AddNewInvetory Set Item_qty ='" + bothqty + "' where Item_id ='" + ItemID + "' ");

                HttpContext.Current.Items.Add("COMPLETE", "INSERT");
                Server.Transfer("CompleteForm.aspx");
            }           
                return nwqty;           
        }

        protected void btnClearNewItem_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                ClearAll();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private void ClearAll()
        {
            txtItemName.Text = "";
            txtqunatity.Text = "";
            txtCreatedBy.Text = "";
            ddItemType.Text = "";
            txtModelno.Text = "";
            txtSerialNo.Text = "";
        }

        protected void btnAddNewType_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                string g = txtItemType.Text.Trim();
                int i = 0;
                string ID = "Item_Type";
                SqlParameter[] para = new SqlParameter[1];
                para[0] = new SqlParameter("@ID",ID);

                DataTable dt = Dal.executeprocedure("sp_getLogvaluebyID", para, true);
                int count = dt.Rows.Count; 
                for (i = 0; i <count; i++)
                {
                    string f = dt.Rows[i].ItemArray[0].ToString();

                    if (string.Equals(f, g, StringComparison.CurrentCultureIgnoreCase))
                    {
                        break;
                    }
                }
                i++;
                count++;
                if (i == count)
                {
                    if (txtItemType.Text.Trim() != "")
                    {                       
                        SqlParameter[] para2 = new SqlParameter[3];
                        para2[0] = new SqlParameter("@ID", SqlDbType.VarChar);
                        para2[0].Value = "Item_Type";

                        para2[1] = new SqlParameter("@code", SqlDbType.BigInt);
                        para2[1].Value = count;

                        para2[2] = new SqlParameter("@Description", SqlDbType.VarChar);
                        para2[2].Value = txtItemType.Text.Trim();

                        Dal.executeprocedure("SP_InsertLogData", para2);

                       // Dal.executesql("insert into log(ID,code,Description) values('Item_Type'," + count + ",'" + txtItemType.Text.Trim() + "')");
                        txtItemType.Text = "";
                        FillItemType();
                    }
                }
                else
                {
                    txtItemType.Text = "";
                    lblerror.Visible = true;
                    lblerror.Text = "This Type Already Exist ..!";                    
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void ddItemType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
    }
}
