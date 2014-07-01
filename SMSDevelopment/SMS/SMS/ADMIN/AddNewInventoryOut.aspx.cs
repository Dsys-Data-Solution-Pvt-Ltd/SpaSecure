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

namespace SMS.ADMIN
{
    public partial class AddNewInventoryOut : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                txtnric.Focus();
                if (!IsPostBack)
                {
                    fillItemType();
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private void fillItemType()
        {
             ddlItemType.Items.Clear();
             SqlParameter[] para1 = new SqlParameter[0];
             DataTable dsItemtype = dal.executeprocedure("SP_GetInventorydata", para1, true);           
            if (dsItemtype.Rows.Count > 0)
            {
                ddlItemType.DataSource = dsItemtype;
                ddlItemType.DataTextField = "Item_type";
                ddlItemType.DataValueField = "Item_type";
                ddlItemType.DataBind();               
                ddlItemType.Items.Insert(0, new ListItem("Select", "Select", true));
            }
        }
        private void fillItemName(string Item_type)
        {
            ddlItemName.Items.Clear();
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Item_type", Item_type);
            DataTable dsInventory = dal.executeprocedure("SP_GetInventorydataBYItemtype", para, true);          
            if (dsInventory.Rows.Count > 0)
            {
                ddlItemName.DataSource = dsInventory;
                ddlItemName.DataTextField = "Item_Name";
                ddlItemName.DataValueField = "Item_Name";
                ddlItemName.DataBind();
                txttotalqty.Text = dsInventory.Rows[0]["Item_qty"].ToString();
            }
        }
        private int itemId(string type, string name)
        {
            int item_id = 0;
            SqlParameter[] para3 = new SqlParameter[2];
            para3[0] = new SqlParameter("@Item_type", type);
            para3[1] = new SqlParameter("@Item_Name", name);
            DataTable ds = dal.executeprocedure("SP_GetItemIDInventorybytypeName", para3, true);           
            if (ds.Rows.Count > 0)
            {
                item_id = Convert.ToInt32(ds.Rows[0]["Item_id"].ToString().Trim());
                return item_id;
            }
            return item_id;
        }        

        protected void txtnric_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtnric.Text.Trim() != "")
                {
                    SqlParameter[] para2 = new SqlParameter[1];
                    para2[0] = new SqlParameter("@NRICno", txtnric.Text.Trim());
                    DataTable dsuserinfo = dal.executeprocedure("sp_FillNameByStaffId", para2, true);
                    if (dsuserinfo.Rows.Count > 0)
                    {
                        txtname.Text = dsuserinfo.Rows[0]["FirstName"].ToString();
                        txtname.Text += " ";
                        txtname.Text += dsuserinfo.Rows[0]["MiddleName"].ToString();
                        txtname.Text += " ";
                        txtname.Text += dsuserinfo.Rows[0]["LastName"].ToString();
                        txtposition.Text = dsuserinfo.Rows[0]["Role"].ToString();
                        //txtstffid.Text = dsuserinfo.Rows[0]["Staff_ID"].ToString();
                    }
                    else
                    {
                        txtnric.Text = "";
                        lblerror.Visible = true;
                        lblerror.Text = "Invalid NRICno....!";
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnNewInventoryOut_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (ddlItemName.Text.Trim() != "" && ddlItemType.Text.Trim() != "" && txtquantity.Text.Trim() != "" && txtnric.Text.Trim()!="" && txtname.Text.Trim() != "")
                {
                    string type = ddlItemType.SelectedItem.Text.ToString().Trim();
                    string name = ddlItemName.SelectedValue.ToString().Trim();
                   
                    int currqty = 0;
                    int oldqty = 0;                  
                    currqty = Convert.ToInt32(txtquantity.Text.Trim());
                    int insertItemid = itemId(type, name);                   

                    DataSet dsoldqty = dal.getdataset("Select Item_qty from AddNewInvetory where Item_id = '" + insertItemid + "'");
                    if (dsoldqty.Tables[0].Rows.Count > 0)
                    {
                        int newqty = 0;
                        oldqty = Convert.ToInt32(dsoldqty.Tables[0].Rows[0]["Item_qty"].ToString().Trim());

                        dal.executesql("insert into NewInventory_Temp(item_Id,Item_Type,Item_Name,Item_QTY,Staff_ID,Status,Comment,Position,FromDate) values(" + insertItemid + ",'" + type + "','" + name + "','" + currqty + "','" + txtstffid.Text + "','New','" + txtComment.Text + "','" + txtposition.Text + "','" + DateTime.Now + "')");

                        if (oldqty > currqty)
                        {
                            newqty = oldqty - currqty;
                            dal.executesql("Update AddNewInvetory set Item_qty = " + newqty + " where Item_id = '" + insertItemid + "'");
                            lblerror.Visible = true;
                            lblerror.Text = "Inventory Out Successfully....!";
                            CearlAll();
                        }
                    }
                }
                else
                {
                    lblerror.Visible = true;
                    lblerror.Text = "Please Fill All Entries....!";
                }

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private void CearlAll()
        {
            txtstffid.Text = "";
            txtquantity.Text = "";
            txtposition.Text = "";
            txtnric.Text = "";
            txtname.Text = "";
            txtComment.Text = "";
            txttotalqty.Text = "";
        }

        protected void ddlItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                fillItemName(ddlItemType.SelectedItem.Text.ToString().Trim());
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }



    }
}
