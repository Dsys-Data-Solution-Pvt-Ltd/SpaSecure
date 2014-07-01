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
using Telerik.Web.UI;
using SMS.master;

namespace SMS.ADMIN
{
    public partial class AdminInvetory : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {             
                if (!IsPostBack)
                {
                    FillItemType();
                    FillItemTypeUpdate();
                    fillItemTypeIout();
                }
                string ctrlname = Page.Request.Params.Get("__EVENTTARGET");
                string ctrlname1 = Page.Request.Params.Get("__eventargument");
                if (ctrlname != null)
                {
                    string controlname = ctrlname;//.Split('$')[ctrlname.Split('$').Length - 1].ToString();
                    if (!controlname.Contains("imdAdd") && !controlname.Contains("imgUpdate") && !controlname.Contains("imgDelete") && !controlname.Contains("imgGlobe") && !controlname.Contains("imglock256") && !controlname.Contains("CheckBox1"))
                    {
                        if (controlname.ToUpper().Contains("RadGridCatalog".ToUpper()))
                        {
                            if (ctrlname1 != null)
                            {
                                if (ctrlname1.Contains("RowClick"))
                                { }
                                else if (ctrlname1.ToUpper().Contains("FIRECOMMAND") || ctrlname1 == "")
                                {
                                    BindGridTelerik();
                                }
                                else
                                {
                                }
                            }
                        }
                        else if (controlname.ToUpper().Contains("lnkEdLocal".ToUpper()))
                        {
                            BindGridTelerik();
                        }
                    }
                }
                else
                {
                    BindGridTelerik();
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ModalPopupAdd.Hide();
            ModalPopupUpdate.Hide();
            ModalPopupDelete.Hide();
            ModalPopupout.Hide();
            CearlAll();
        }
      
        
        protected void imgAdd_Click(object sender, EventArgs e)
        {
            SpaMaster MyMasterPage = (SpaMaster)Page.Master;

            
                                        DataTable dtInventoryAdd = AdminDAL.Checkmenu(Session["RoleID"].ToString(), "64");

                                        if (dtInventoryAdd.Rows.Count > 0)
                                        {

                                            ModalPopupAdd.Show();
                                        }
                                        else
                                        {
                                          
                                            MyMasterPage.ShowErrorMessage("You Do Not Have Permission..!");   
          

                                        }



        }
        protected void imgUpdate_Click(object sender, EventArgs e)
        {
            try
            {


                 SpaMaster MyMasterPage = (SpaMaster)Page.Master;

              DataTable dtViewInventory = AdminDAL.Checkmenu(Session["RoleID"].ToString(), "63");
                                     
                                        if (dtViewInventory.Rows.Count > 0)
                                        {

                                            
                                            if(ViewState["Item_Id"]!=null)
                                            {
                                            PopulatePageCntrls(ViewState["Item_Id"].ToString());
                                             ModalPopupUpdate.Show();
                                            }










                //int flag = 0;
                //foreach (GridDataItem row in RadGridCatalog.MasterTableView.Items)
                //{
                //    CheckBox chk1 = (CheckBox)row.FindControl("CheckBox1");
                //    int index = row.ItemIndex;
                //    if (chk1.Checked == true)
                //    {
                //        flag = 1;
                //        break;
                //    }
                //}
                //if (flag == 1)
                //{
                //    PopulatePageCntrls(ViewState["Item_Id"].ToString());
                //    ModalPopupUpdate.Show();
                //}
                //else {
                //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AlertMessage", " alert('Please select item in the check box.');", true);
                //}
                                        }
                                        else
                                        {

                                            MyMasterPage.ShowErrorMessage("You Do Not Have Permission..!");


                                        }
            }
            catch (Exception ex) { }
        }
        protected void imgDelete_Click(object sender, EventArgs e)
        {
            SpaMaster MyMasterPage = (SpaMaster)Page.Master;

              DataTable dtViewInventory = AdminDAL.Checkmenu(Session["RoleID"].ToString(), "63");
                                     
                                        if (dtViewInventory.Rows.Count > 0)
                                        {
                                            if (ViewState["Item_Id"] != null)
                                            {
                                                ModalPopupDelete.Show();
                                            }
            //int flag = 0;
            //foreach (GridDataItem row in RadGridCatalog.MasterTableView.Items)
            //{
            //    CheckBox chk1 = (CheckBox)row.FindControl("CheckBox1");
            //    int index = row.ItemIndex;
            //    if (chk1.Checked == true)
            //    {
            //        flag = 1;
            //        break;
            //    }
            //}
            //if (flag == 1)
            //{
            //    ModalPopupDelete.Show();
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AlertMessage", " alert('Please select  item in the check box.');", true);
            //}
                                        }
                                        else
                                        {

                                            MyMasterPage.ShowErrorMessage("You Do Not Have Permission..!");


                                        }
        }
        protected void imgout_Click(object sender, EventArgs e)
        {
            SpaMaster MyMasterPage = (SpaMaster)Page.Master;

                                        DataTable dtInventoryOut = AdminDAL.Checkmenu(Session["RoleID"].ToString(), "130");
                                      
                                        if (dtInventoryOut.Rows.Count > 0)
                                        {
                                       ModalPopupout.Show();
                                        }
                                        else
                                        {

                                            MyMasterPage.ShowErrorMessage("You Do Not Have Permission..!");


                                        }
        }
       
        
        
        private void BindGridTelerik()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                AdminBLL ws = new AdminBLL();
                GetInventoryData objReq = new GetInventoryData();
                GetInventoryResponce ret = ws.GetInventoryData(objReq);
                RadGridCatalog.DataSource = ret.Itemid;
                RadGridCatalog.DataBind();   
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
       
        
        #region Add Record

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
        private void FillItemTypeUpdate()
        {
            ddItemTypeupdate.Items.Clear();
            SqlParameter[] para1 = new SqlParameter[0];
            DataTable dsItemtype = Dal.executeprocedure("SP_GetInventorydata", para1, true);
            if (dsItemtype.Rows.Count > 0)
            {
                ddItemTypeupdate.DataSource = dsItemtype;
                ddItemTypeupdate.DataTextField = "Item_type";
                ddItemTypeupdate.DataValueField = "Item_type";
                ddItemTypeupdate.DataBind();
                ddItemTypeupdate.Items.Insert(0, new ListItem("Select", "Select", true));
            }
        }
        protected void btnAddNewType_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                string g = txtItemType.Text.Trim();
                int i = 0;
                string ID = "Item_Type";
                SqlParameter[] para = new SqlParameter[1];
                para[0] = new SqlParameter("@ID", ID);

                DataTable dt = Dal.executeprocedure("sp_getLogvaluebyID", para, true);
                int count = dt.Rows.Count;
                for (i = 0; i < count; i++)
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
                        MyMasterPage.ShowErrorMessage("Item Added Successfully..!");  
                      //  ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AlertMessage", " alert('Item Added Successfully..!');", true);
                        // Dal.executesql("insert into log(ID,code,Description) values('Item_Type'," + count + ",'" + txtItemType.Text.Trim() + "')");
                        txtItemType.Text = "";
                        FillItemType();
                        ClearAll();
                    }
                }
                else
                {
                    txtItemType.Text = "";
                    MyMasterPage.ShowErrorMessage("This Type Already Exist ..!");  
                    //lblerror.Visible = true;
                    //lblerror.Text = "This Type Already Exist ..!";
                   // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AlertMessage", " alert('This Type Already Exist ..!');", true);
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnaddNewItem_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                SpaMaster MyMasterPage = (SpaMaster)Page.Master;
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

                    BindGridTelerik();
                    MyMasterPage.ShowErrorMessage("Record Inserted SuccessFully");  
                  //  ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AlertMessage", " alert('Record Inserted SuccessFully');", true);
                    ClearAll();
                    BindGridTelerik();
                    //HttpContext.Current.Items.Add("COMPLETE", "INSERT");
                    //Server.Transfer("CompleteForm.aspx");
                }
                else
                {
                    MyMasterPage.ShowErrorMessage("Please Fill All Entries ..!");  
                    //lblerror.Visible = true;
                    //lblerror.Text = "Please Fill All Entries ..!";
                   // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AlertMessage", " alert('Please Fill All Entries ..!');", true);

                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        DataAccessLayer Dal = new DataAccessLayer();
        private int Itemqty(string type, string name, int Newqty)
        {
            SpaMaster MyMasterPage = (SpaMaster)Page.Master;
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
                ClearAll();
                MyMasterPage.ShowErrorMessage("Record Inserted SuccessFully");  
               // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AlertMessage", " alert('Record Inserted SuccessFully');", true);
                BindGridTelerik();
                //HttpContext.Current.Items.Add("COMPLETE", "INSERT");
                //Server.Transfer("CompleteForm.aspx");
            }
            return nwqty;
        }
        private void ClearAll()
        {
            txtItemName.Text = "";
            txtqunatity.Text = "";
            txtCreatedBy.Text = "";
            txtItemType.Text = "";
            //ddItemType.SelectedIndex = 0;
            txtModelno.Text = "";
            txtSerialNo.Text = "";

            txtItemID.Text = "";
            //ddItemTypeupdate.SelectedIndex = 0;
            txtItemNameupd.Text = "";
            txtqunatityupd.Text = "";
            txtCreatedByupd.Text = "";
            txtCreatedTime.Text = "";
            txtEditBy.Text = "";
            hdnitmID.Value = "";
        }
        #endregion

        #region Update
        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            ClearAll();

            ((sender as CheckBox).NamingContainer as GridItem).Selected = (sender as CheckBox).Checked;
            bool checkHeader = true;
            List<string> lstreportsession = new List<string>();
            int ro = ((sender as CheckBox).NamingContainer as GridItem).ItemIndex;
            GridDataItem item = RadGridCatalog.MasterTableView.Items[ro];

            foreach (GridDataItem item1 in RadGridCatalog.MasterTableView.Items)
            {
                if (item == item1)
                {
                    if ((item.FindControl("CheckBox1") as CheckBox).Checked)
                    {
                        RadGridCatalog.Items[ro].Selected = true;
                        string iss = item.OwnerTableView.DataKeyValues[ro]["Item_Id"].ToString();
                        ViewState["Item_Id"] = iss;
                        hdnitmID.Value = iss;
                    }
                }
                else
                {
                    (item1.FindControl("CheckBox1") as CheckBox).Checked = false;
                }
            }
            //CheckBox chk = (CheckBox)sender;
            //GridDataItem itm = (GridDataItem)chk.NamingContainer;
            //int crrntindex = itm.ItemIndex;
            //if (chk.Checked == true)
            //{
            //    string iss = itm.OwnerTableView.DataKeyValues[crrntindex]["Item_Id"].ToString();
            //    hdnitmID.Value = iss;
            //    PopulatePageCntrls(iss);
            //    //foreach (GridDataItem row in RadGridCatalog.MasterTableView.Items)
            //    //{
            //    //    CheckBox chk1 = (CheckBox)row.FindControl("CheckBox1");
            //    //    int index = row.ItemIndex;
            //    //    if (crrntindex == index)
            //    //        continue;
            //    //    if (chk1.Checked == true)
            //    //    {
            //    //        chk1.Checked = false;
            //    //    }
            //    //}
            //}
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
                objGetInventoryTableRequest.WhereClause = " where Item_id='" + argsBGID + "' ";
                ret = objAdminBLL.GetInventoryData(objGetInventoryTableRequest);

                hdnBTID.Value = ret.Itemid[iCount].Item_id.ToString();
                hdnBTID.Value = ret.Itemid[iCount].Item_Name.ToString();
                txtCreatedTime.Text = System.DateTime.Now.ToShortTimeString();
                txtItemID.Text = ret.Itemid[iCount].Item_id.ToString();
                txtItemNameupd.Text = ret.Itemid[iCount].Item_Name.ToString();
                txtqunatityupd.Text = ret.Itemid[iCount].Item_qty.ToString();
                txtCreatedByupd.Text = ret.Itemid[iCount].CreatedBy.ToString();
                ddItemTypeupdate.SelectedValue = ret.Itemid[iCount].Item_Type.ToString();
                txtCreatedTime.Text = ret.Itemid[iCount].CreatedTime.ToString();
                txtEditBy.Text = Session["User_Id"].ToString();
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
                SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                AddNewInventory objInventory_Data = new AddNewInventory();
                AdminBLL ws = new AdminBLL();
                if (txtItemNameupd.Text.Trim() != "")
                {
                    objInventory_Data.Item_id = txtItemID.Text.Trim();
                    objInventory_Data.Item_Name = txtItemNameupd.Text.Trim();
                    objInventory_Data.Item_qty = txtqunatityupd.Text.Trim();
                    objInventory_Data.CreatedBy = txtCreatedByupd.Text.Trim();
                    objInventory_Data.Item_Type = ddItemTypeupdate.Text.Trim();
                    objInventory_Data.CreatedTime = Convert.ToDateTime(txtCreatedTime.Text.Trim());
                    objInventory_Data.EditBy = txtEditBy.Text.Trim();

                    if (txtCreatedBy.Text.Trim() != "")
                    {
                        objInventory_Data.EditTime = DateTime.Now;
                    }

                    ws.UpdateInventoryData(objInventory_Data);
                    BindGridTelerik();
                    MyMasterPage.ShowErrorMessage("Record Updated Successfully..!");  
                   // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AlertMessage", " alert('Record Updated Successfully..!');", true);
                    ModalPopupUpdate.Hide();
                    //HttpContext.Current.Items.Add(ContextKeys.CTX_COMPLETE, "UPDATE");
                    //Server.Transfer("CompleteForm.aspx");
                }
                else
                {
                    MyMasterPage.ShowErrorMessage("Invalid Item Name ..!");  
                    //lblErrMsg.Visible = true;
                    //lblErrMsg.Text = "Invalid Item Name ..!";
                    //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AlertMessage", " alert('Invalid Item Name ..!');", true);
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                if (!string.IsNullOrEmpty(hdnitmID.Value.ToString()))
                {
                    AdminBLL ws = new AdminBLL();
                    DeleteInventoryRequest _req = new DeleteInventoryRequest();

                    _req.InventoryItemId = hdnitmID.Value.ToString();
                    ws.DeleteInventory(_req);
                    ModalPopupDelete.Hide();
                    BindGridTelerik();
                    MyMasterPage.ShowErrorMessage("Record Deleted Successfully..!");  
                   // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AlertMessage", " alert('Record Deleted Successfully..!');", true);
                    
                    //HttpContext.Current.Items.Add(ContextKeys.CTX_COMPLETE, "DELETE");
                    //Server.Transfer("CompleteForm.aspx");
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        //protected void ToggleRowSelection(object sender, EventArgs e)
        //{
        //    ((sender as CheckBox).NamingContainer as GridItem).Selected = (sender as CheckBox).Checked;
        //    bool checkHeader = true;

        //    int ro = ((sender as CheckBox).NamingContainer as GridItem).ItemIndex;
        //    GridDataItem item = RadGridCatalog.MasterTableView.Items[ro];
        //    if ((item.FindControl("CheckBox1") as CheckBox).Checked)
        //    {
        //        RadGridCatalog.Items[ro].Selected = true;
        //       string iss = item.OwnerTableView.DataKeyValues[ro]["Item_Id"].ToString();
        //        checkHeader = false;
        //    }
        //    else
        //    {
                
        //    }
        //}
        #endregion

        #region InventoryOut 

        private void fillItemTypeIout()
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
                SpaMaster MyMasterPage = (SpaMaster)Page.Master;
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
                        MyMasterPage.ShowErrorMessage("Invalid NRICno....!");
                        //lblerror.Visible = true;
                        //lblerror.Text = "Invalid NRICno....!";
                        //  ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AlertMessage", " alert('Invalid NRICno....!');", true);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        //protected void txtnric_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        SpaMaster MyMasterPage = (SpaMaster)Page.Master;
        //        if (txtnric.Text.Trim() != "")
        //        {
        //            SqlParameter[] para2 = new SqlParameter[1];
        //            para2[0] = new SqlParameter("@NRICno", txtnric.Text.Trim());
        //            DataTable dsuserinfo = dal.executeprocedure("sp_FillNameByStaffId", para2, true);
        //            if (dsuserinfo.Rows.Count > 0)
        //            {
        //                txtname.Text = dsuserinfo.Rows[0]["FirstName"].ToString();
        //                txtname.Text += " ";
        //                txtname.Text += dsuserinfo.Rows[0]["MiddleName"].ToString();
        //                txtname.Text += " ";
        //                txtname.Text += dsuserinfo.Rows[0]["LastName"].ToString();
        //                txtposition.Text = dsuserinfo.Rows[0]["Role"].ToString();
        //                //txtstffid.Text = dsuserinfo.Rows[0]["Staff_ID"].ToString();
        //            }
        //            else
        //            {
        //                txtnric.Text = "";
        //                MyMasterPage.ShowErrorMessage("Invalid NRICno....!");
        //                //lblerror.Visible = true;
        //                //lblerror.Text = "Invalid NRICno....!";
        //                //  ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AlertMessage", " alert('Invalid NRICno....!');", true);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        protected void btnNewInventoryOut_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                if (ddlItemName.Text.Trim() != "" && ddlItemType.Text.Trim() != "" && txtquantity.Text.Trim() != "" && txtnric.Text.Trim() != "" && txtname.Text.Trim() != "")
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
                            //lblerror.Visible = true;
                            //lblerror.Text = "Inventory Out Successfully....!";
                            CearlAll();
                            MyMasterPage.ShowErrorMessage("Inventory Out Successfully....!");
                            BindGridTelerik();

                          //  ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AlertMessage", " alert('Inventory Out Successfully....!');", true);
                        }
                    }
                }
                else
                {
                    MyMasterPage.ShowErrorMessage("Please Fill All Entries....!");  
                    //lblerror.Visible = true;
                    //lblerror.Text = "Please Fill All Entries....!";
                    //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AlertMessage", " alert('Please Fill All Entries....!');", true);
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
            //ddlItemName.SelectedItem.Text = "";
           // ddlItemType.SelectedIndex = 0;
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

        protected void txtIssuedToNRIC_TextChanged(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                GetStaffInfo(txtnric.Text.Trim());
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private void GetStaffInfo(string ID)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@NRICno", ID);

            DataTable dtStaffInfo = dal.executeprocedure("sp_FillNameByStaffId", para, false);
            if (dtStaffInfo.Rows.Count > 0)
            {
                txtname.Text = dtStaffInfo.Rows[0][0].ToString().Trim();
                txtposition.Text = dtStaffInfo.Rows[0][1].ToString().Trim();
            }
            else
            {
                txtname.Text = "";
                txtposition.Text = "";
            }
        }
        #endregion

    }
}
