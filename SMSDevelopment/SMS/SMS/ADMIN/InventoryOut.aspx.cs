using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SMS.Services.BusinessServices;
using SMS.Services.DataService;
using SMS.SMSAppUtilities;

namespace SMS.ADMIN
{
    public partial class InventoryOut : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        string Staff_ID = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillItemType();
                if (Request.QueryString["id"].ToString() == "1")
                {
                    if (Session["Staff_ID"] != null)
                    {
                        BindGridFilter();
                    }
                    else
                    {
                        if (Session["Staff_ID_LOCAL"] != null)
                        {
                            BindGridFilter();
                        }
                    }
                }
            }
        }
        private void BindGridFilter()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                AdminBLL ws = new AdminBLL();
                int pageSize = 20;
                DataSet ds = dal.getdataset("select * from NewInventory_Temp with(nolock)where Staff_ID='" + Session["Staff_ID"].ToString() + "'");
                GridView1.PageSize = pageSize;
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
                cmdIssueItem.Visible = true;
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        protected void btnSearchPassAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {

                if (Session["Staff_ID"] != null)
                {
                    Staff_ID = Session["Staff_ID"].ToString().Trim();
                }
                else
                {
                    if (Session["Staff_ID_LOCAL"] != null)
                    {
                        Staff_ID = Session["Staff_ID_LOCAL"].ToString().Trim();
                    }
                }
                string type = ddlItemType.SelectedItem.Text.ToString().Trim();
                string name = ddlItemName.SelectedValue.ToString().Trim();
                int qty = Convert.ToInt32(txtquantity.Text.ToString().Trim());


                int insertItemid = itemId(type, name);
                dal.executesql("insert into NewInventory_Temp (item_Id,Item_Type,Item_Name,Item_QTY,Staff_ID,Status) values(" + insertItemid + ",'" + type + "','" + name + "','" + qty + "','" + Staff_ID + "','New')");
                BindGridFilter();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private int itemId(string type, string name)
        {
            int item_id = 0;
            DataSet ds = dal.getdataset("Select Item_id from AddNewInvetory where Item_Type = '" + type + "' and Item_Name = '" + name + "' ");
            if (ds.Tables[0].Rows.Count > 0)
            {
                item_id = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString().Trim());
                return item_id;
            }
            return item_id;
        }


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                int item_ID = Convert.ToInt32(e.CommandArgument.ToString());

                if (e.CommandName == "DeleteRow")
                {
                    dal.executesql("delete from NewInventory_Temp where Item_id=" + item_ID);
                    BindGridFilter();
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        private void BindGrid()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                AdminBLL ws = new AdminBLL();
                int pageSize = 20;
                DataSet ds = dal.getdataset("select * from NewInventory_Temp with(nolock)");
                GridView1.PageSize = pageSize;
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
                cmdIssueItem.Visible = true;
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        private void fillItemType()
        {
            ddlItemType.Items.Clear();

            DataSet dsdepartment = dal.getdataset("select Item_type from AddNewInvetory order by Item_ID Asc");
            if (dsdepartment.Tables[0].Rows.Count > 0)
            {
                ddlItemType.DataSource = dsdepartment.Tables[0];
                ddlItemType.DataTextField = "Item_type";
                ddlItemType.DataValueField = "Item_type";
                ddlItemType.DataBind();
                cmdIssueItem.Visible = true;
                ddlItemType.Items.Insert(0, new ListItem("Select", "Select", true));
            }
        }
        private void fillItemName(string Item_type)
        {
            ddlItemName.Items.Clear();
            DataSet dsdepartment = dal.getdataset("select Item_Name from AddNewInvetory where item_Type='" + Item_type + "'");
            if (dsdepartment.Tables[0].Rows.Count > 0)
            {
                ddlItemName.DataSource = dsdepartment.Tables[0];
                ddlItemName.DataTextField = "Item_Name";
                ddlItemName.DataValueField = "Item_Name";
                ddlItemName.DataBind();
                cmdIssueItem.Visible = true;
            }

        }
        protected void cmdIssueItem_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (Session["Staff_ID"] != null)
                {
                    Staff_ID = Session["Staff_ID"].ToString().Trim();

                    DataSet dsinventory = dal.getdataset("Select item_id,Item_Qty from NewInventory_Temp where Staff_ID = '" + Staff_ID + "'");
                    if (dsinventory.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dsinventory.Tables[0].Rows.Count; i++)
                        {
                            string item_id = string.Empty;
                            int currqty = 0;
                            int oldqty = 0;
                            item_id = dsinventory.Tables[0].Rows[i][0].ToString().Trim();
                            currqty = Convert.ToInt32(dsinventory.Tables[0].Rows[i][1].ToString().Trim());

                            DataSet dsoldqty = dal.getdataset("Select Item_qty from AddNewInvetory where Item_id = '" + item_id + "'");
                            if (dsoldqty.Tables[0].Rows.Count > 0)
                            {
                                int newqty = 0;

                                oldqty = Convert.ToInt32(dsoldqty.Tables[0].Rows[0][0].ToString().Trim());
                                if (oldqty > currqty)
                                {
                                    newqty = oldqty - currqty;
                                    dal.executesql("Update AddNewInvetory set Item_qty = " + newqty + " where Item_id = '" + item_id + "'");
                                }
                            }
                        }
                    }
                }

                ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.close();</script>");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
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
