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
using System.Drawing;

using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.Services.DataService;
using SMS.SMSAppUtilities;
using SMS.BusinessEntities;
using Telerik.Web.UI;
using SMS.master;

namespace SMS.SuperVisor
{
    public partial class AdminAddItem : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        
           
        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                //txtModel.Focus();
                //lblerror.Visible = false;
                if (!IsPostBack)
                {
                    
                    ColorTab();
                    lnkViewItem.BackColor = System.Drawing.Color.Maroon;
                    lnkViewItem.ForeColor = System.Drawing.Color.White;
                   


                }
                string ctrlname = Page.Request.Params.Get("__EVENTTARGET");
                string ctrlname1 = Page.Request.Params.Get("__eventargument");
                if (ctrlname != null)
                {
                    string controlname = ctrlname;//.Split('$')[ctrlname.Split('$').Length - 1].ToString();
                    if (!controlname.Contains("imdAdd") && !controlname.Contains("imgUpdate") && !controlname.Contains("imgDelete") && !controlname.Contains("imgCopy") && !controlname.Contains("CheckBox1"))
                    {
                        if (controlname.ToUpper().Contains("gvKeySearch".ToUpper()))
                        {
                            if (ctrlname1 != null)
                            {
                                if (ctrlname1.Contains("RowClick"))
                                { }
                                else if (ctrlname1.ToUpper().Contains("FIRECOMMAND") || ctrlname1 == "")
                                {
                                    BindGrid();
                                }
                                else
                                {

                                }

                            }
                        }
                    }
                }
                else
                {
                    BindGrid();
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        private string ReturnWhere()
        {
            string str = string.Empty;
            string makeWhereClause = string.Empty;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                List<String> arr = new List<String>();
                arr.Add("test");

                if (txtItemName.Text.Trim() != "")
                {
                    if (arr.Count == 1)
                    {
                        makeWhereClause = " where ";
                        str += " and Item_Name='" + txtItemName.Text + "'";
                        //str += " where Item_Name='" + txtItemName.Text + "'";
                        //arr.Add("1");
                    }
                    else
                    {
                        //str += " and Item_Name='" + txtItemName.Text + "'";
                        str += " where Item_Name='" + txtItemName.Text + "'";
                        arr.Add("1");
                    }
                }
                if (txtModel.Text.Trim() != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " and Model_No = '" + txtModel.Text + "'";
                        //str += " where Model_No = '" + txtModel.Text + "'";
                        //arr.Add("2");
                    }
                    else
                    {
                        //str += " and Model_No = '" + txtModel.Text + "'";
                        str += " where Model_No = '" + txtModel.Text + "'";
                        arr.Add("2");
                    }
                }


                if (txtIssuedTo.Text.Trim() != "")
                {
                    if (arr.Count == 1)
                    {
                        makeWhereClause = " where ";
                        str += " and IssuedTo_Name='" + txtIssuedTo.Text + "'";
                        //str += " where IssuedTo_Name='" + txtIssuedTo.Text + "'";
                        //arr.Add("3");
                    }
                    else
                    {
                        str += " where IssuedTo_Name='" + txtIssuedTo.Text + "'";
                        arr.Add("3");
                        //str += " and IssuedTo_Name='" + txtIssuedTo.Text + "'";
                    }
                }
                if (txtIssuedBy.Text.Trim() != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " and IssuedBy_Name = '" + txtIssuedBy.Text + "'";
                        //str += " where IssuedBy_Name = '" + txtIssuedBy.Text + "'";
                        //arr.Add("4");
                    }
                    else
                    {
                        str += " where IssuedBy_Name = '" + txtIssuedBy.Text + "'";
                        arr.Add("4");
                        //str += " and IssuedBy_Name = '" + txtIssuedBy.Text + "'";
                    }
                }


                if (txtdateto.Text != "" && txtdatefrom.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " and IssuedBy_Time BETWEEN '" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                       // str += " where IssuedBy_Time BETWEEN '" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                        //arr.Add("5");
                    }
                    else
                    {
                        str += " where IssuedBy_Time BETWEEN '" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                        arr.Add("5");
                        //str += " and IssuedBy_Time BETWEEN '" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                    }
                }
                if (txtdatefrom.Text != "" && txtdateto.Text == "")
                {
                    if (arr.Count == 1)
                    {
                        str += " and IssuedBy_Time ='" + txtdatefrom.Text + "'";
                        //str += " where IssuedBy_Time ='" + txtdatefrom.Text + "'";
                        //arr.Add("6");
                    }
                    else
                    {
                        str += " where IssuedBy_Time ='" + txtdatefrom.Text + "'";
                        arr.Add("6");
                        //str += " and IssuedBy_Time ='" + txtdatefrom.Text + "'";
                    }
                }


            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
            return (str);
        }

        private void BindGrid()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                DataSet dsitem = dal.getdataset("Select AddItem_ID,Model_No,Item_Name,Item_quantity,IssuedBy_Name,IssuedBy_Time,IssuedTo_Name from AddNewItem Where Status ='Issued' " + ReturnWhere() + "");
                //DataSet dsitem = dal.getdataset("Select AddItem_ID,Model_No,Item_Name,Item_quantity,IssuedBy_Name,IssuedBy_Time,IssuedTo_Name from AddNewItem "+ ReturnWhere() + " and Status ='Issued'");

                //int pageSize = ContextKeys.GRID_PAGE_SIZE;
                gvKeySearch.PageSize = 20;
                gvKeySearch.DataSource = dsitem.Tables[0];
                gvKeySearch.DataBind();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void gvNewKey_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    ImageButton Delete = (ImageButton)e.Row.FindControl("btnDelete");
                    Delete.Attributes.Add("onclick", "javascript:return " +
                        "confirm('Are you sure to delete this record?')");
                }

                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    gvKeySearch.Columns[0].FooterText = "Total Records: 20";
                }

               
            }

            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void gvNewKey_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                string _BTId = Convert.ToString(e.CommandArgument);               

                if (e.CommandName == "EditRow")
                {                   
                     HttpContext.Current.Items.Add(ContextKeys.CTX_UPDATE_URL, Request.Url.ToString());
                     HttpContext.Current.Items.Add(ContextKeys.CTX_BT_ID, _BTId);
                     Server.Transfer("UpdateAdminAddItem.aspx");                   
                }
                if (e.CommandName == "DeleteRow")
                { 
                    DeleteItem(_BTId);
                }

            }

            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
       
        protected void gvNewKey_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (e.NewPageIndex >= 0)
                {
                    //gvKeySearch.PageIndex = e.NewPageIndex;
                    //AdminBLL ws = new AdminBLL();
                    //GetNewKey _req = new GetNewKey();
                    //GetNewKeyRequest _resp = ws.GetNewKey(_req);

                    //int pageSize = ContextKeys.GRID_PAGE_SIZE;
                    //gvKeySearch.PageSize = pageSize;
                    //gvKeySearch.DataSource = _resp.Key;
                    //gvKeySearch.DataBind();
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        protected void gvNewKey_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnNewBTable_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Response.Redirect("../SuperVisor/AddNewItem.aspx");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
      
        protected void btnSearchKeyAdd_Click1(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                BindGrid();
            }

            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnClearKeyAdd_Click1(object sender, EventArgs e)
        {
            txtModel.Text = "";
            txtItemName.Text = "";
            txtIssuedTo.Text = "";
            txtIssuedBy.Text = "";
            txtdateto.Text = "";
            txtdatefrom.Text = "";
        }






        private void DeleteItem(string argKeyID)
        {

            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {

                dal.executesql("Delete from AddNewItem Where AddItem_ID ='" + argKeyID + "' ");

                BindGrid();
               // Server.Transfer("~/SMSAdmin/AlertUpdateComplete.aspx");
                //if (!string.IsNullOrEmpty(argKeyID))
                //{
                //    AdminBLL ws = new AdminBLL();
                //    DeleteKeyRequest _req = new DeleteKeyRequest();

                //    _req.KeyNo = argKeyID.ToString();

                //    ws.DeleteKey(_req);
                //HttpContext.Current.Items.Add(ContextKeys.CTX_COMPLETE, "DELETE");

                //}

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void ToggleRowSelection(object sender, EventArgs e)
        {
            ((sender as CheckBox).NamingContainer as GridItem).Selected = (sender as CheckBox).Checked;
            bool checkHeader = true;
            List<string> lstreportsession = new List<string>();
            int ro = ((sender as CheckBox).NamingContainer as GridItem).ItemIndex;
            GridDataItem item = gvKeySearch.MasterTableView.Items[ro];

            foreach (GridDataItem item1 in gvKeySearch.MasterTableView.Items)
            {

                if (item == item1)
                {
                    if ((item.FindControl("CheckBox1") as CheckBox).Checked)
                    {

                        gvKeySearch.Items[ro].Selected = true;


                        ViewState["AddItem_ID"] = item.OwnerTableView.DataKeyValues[ro]["AddItem_ID"];


                    }
                }
                else
                {
                    (item1.FindControl("CheckBox1") as CheckBox).Checked = false;
                }


            }
            //else
            //{
            //    if (Session["AOpID"].ToString() == item.OwnerTableView.DataKeyValues[ro]["ID"].ToString())
            //    {
            //        foreach (GridDataItem item1 in gvKeySearch.MasterTableView.Items)
            //        {
            //            if ((item1.FindControl("CheckBox1") as CheckBox).Checked)
            //            {
            //                int ro1 = item1.ItemIndex;
            //                gvKeySearch.Items[ro1].Selected = true;

            //                string partno = item1["Part_Number"].Text;
            //                string seqno = item1["Sequence_no"].Text;
            //                string Assetno = item1["Asset_Number"].Text;
            //                Session["ARowOperation"] = ro1;
            //                Session["ASequenceNumber"] = seqno;
            //                Session["AAssetNumber"] = Assetno;
            //                Session["AOpID"] = item1.OwnerTableView.DataKeyValues[ro1]["ID"];
            //                break;

            //            }
            //            else
            //            {
            //                Session["ARowOperation"] = null;
            //                Session["ASequenceNumber"] = null;
            //                Session["AAssetNumber"] = null;
            //                Session["AOpID"] = null;
            //            }

            //        }


            //    }



            //}







            //GridHeaderItem headerItem = RadGridCatalog.MasterTableView.GetItems(GridItemType.Header)[0] as GridHeaderItem;
            //(headerItem.FindControl("headerChkbox") as CheckBox).Checked = checkHeader;
        }
        public void ColorTab()
        {
            lnkViewItem.BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6");
            lnkCheckOutItem.BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6");

        }
        protected void imdAdd_Click(object sender, EventArgs e)
        {
            SpaMaster MyMasterPage = (SpaMaster)Page.Master;
          
            
            DataTable dtViewItems = AdminDAL.Checkmenu(Session["RoleID"].ToString(), "96");

            if (dtViewItems.Rows.Count > 0)
            {
           ModalPopupAdd.Show();
            }
            else
            {
                MyMasterPage.ShowErrorMessage("You Do not Have Permission..!");


            }
        }

        protected void imgUpdate_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {  SpaMaster MyMasterPage = (SpaMaster)Page.Master;
          
                DataTable dtViewItems = AdminDAL.Checkmenu(Session["RoleID"].ToString(), "97");

            if (dtViewItems.Rows.Count > 0)
            {
                if (ViewState["AddItem_ID"] != null)
                {

                    string _BTId = ViewState["AddItem_ID"].ToString();
                    PopulatePageCntrls(_BTId);
                    ModalPopupupdate.Show();
                }

            }
            else
            {
                MyMasterPage.ShowErrorMessage("You Do not Have Permission..!");


            }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void imgDelete_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                SpaMaster MyMasterPage = (SpaMaster)Page.Master;
          
                DataTable dtViewItems = AdminDAL.Checkmenu(Session["RoleID"].ToString(), "97");

            if (dtViewItems.Rows.Count > 0)
            {
                if (ViewState["AddItem_ID"] != null)
                {

                    ModalPopupDeleteimage.Show();






                }
            }
            else
            {
                MyMasterPage.ShowErrorMessage("You Do not Have Permission..!");     
          

            }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

        }

        protected void lnkViewItem_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                BindGrid(); 
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

        }
        protected void lnkCheckOutItem_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Response.Redirect("../SuperVisor/AddNewItem.aspx");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }


        # region delete

        protected void Deletepopup_Yes_Click(object sender, EventArgs e)
        {
            SpaMaster MyMasterPage = (SpaMaster)Page.Master;
          
            try
            {
                if (ViewState["AddItem_ID"] != null)
                {

                    string _BTId = ViewState["AddItem_ID"].ToString();



                    DeleteItem(_BTId);


                    MyMasterPage.ShowErrorMessage("Record Deleted Successfully..!");
                    ModalPopupDeleteimage.Hide();




                }
            }
            catch (Exception ex)
            {
                Response.Write("Some Error ");
            }

        }

        protected void btnCancelDelete_Click(object sender, EventArgs e)
        {
            ModalPopupDeleteimage.Hide();
        }


        #endregion


        # region Update

        private void PopulatePageCntrls(String argsBGID)
        {

            DataSet dspan = dal.getdataset("Select Model_No,Item_Name,Item_quantity,IssuedBy_Name,IssuedBy_Nric,IssuedBy_Position,IssuedTo_Name,IssuedTo_Nric,IssuedTo_Position,Remark from AddNewItem where AddItem_ID = '" + argsBGID + "' ");
            if (dspan.Tables[0].Rows.Count > 0)
            {
                txtItemID.Text = argsBGID;
                txtModelNo.Text = dspan.Tables[0].Rows[0][0].ToString().Trim();
                txtItemNameUpdate.Text = dspan.Tables[0].Rows[0][1].ToString().Trim();
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
            SpaMaster MyMasterPage = (SpaMaster)Page.Master;
          
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                dal.executesql("Update AddNewItem Set Model_No ='" + txtModelNo.Text.Trim() + "',Item_Name='" + txtItemNameUpdate.Text.Trim() + "',Item_quantity='" + txtItemquantity.Text.Trim() + "',IssuedBy_Name='" + txtIssuedByName.Text.Trim() + "',IssuedBy_Nric='" + txtIssuedByNRIC.Text.Trim() + "',IssuedBy_Position='" + txtIssuedByPosition.Text.Trim() + "',IssuedTo_Name='" + txtIssuedToName.Text.Trim() + "',IssuedTo_Nric='" + txtIssuedToNRIC.Text.Trim() + "',IssuedTo_Position='" + txtIssuedToPosition.Text.Trim() + "',Remark='" + txtComment.Text.Trim() + "',Status='" + ddlStatus.Text.Trim() + "' where AddItem_ID = '" + txtItemID.Text.Trim() + "' ");
                //Server.Transfer("AdminAddItem.aspx");
                BindGrid();
                ModalPopupupdate.Hide();
                ClearUpdate();
                MyMasterPage.ShowErrorMessage("Record Updated Successfully..!");     
          
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        public void ClearUpdate()
        {
            txtModelNo.Text = "";
            txtItemNameUpdate.Text = "";
            txtItemquantity.Text = "";
            txtIssuedByName.Text = "";
            txtIssuedByNRIC.Text = "";
            txtIssuedByPosition.Text = "";
            txtIssuedToName.Text = "";
            txtIssuedToNRIC.Text = "";
            txtIssuedToPosition.Text = "";
            txtComment.Text = "";
            txtItemID.Text = "";
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                ClearUpdate();
                ModalPopupupdate.Hide();
               // Server.Transfer("AdminAddItem.aspx");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void txtIssuedToNRICUp_TextChanged(object sender, EventArgs e)
        {

            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                GetStaffInfoUp(txtIssuedToNRIC.Text.Trim());
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        private void GetStaffInfoUp(string ID)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@NRICno", ID);

            DataTable dtStaffInfo = dal.executeprocedure("sp_FillNameByStaffId", para, false);
            if (dtStaffInfo.Rows.Count > 0)
            {
                txtIssuedToName.Text = dtStaffInfo.Rows[0][0].ToString().Trim();
                txtIssuedToPosition.Text = dtStaffInfo.Rows[0][1].ToString().Trim();
            }
            else
            {
                txtIssuedToName.Text = "";
                txtIssuedToPosition.Text = "";
            }
        }

        protected void txtIssuedByNRICUp_TextChanged(object sender, EventArgs e)
        {

            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                GetStaffInfoBYUp(txtIssuedByNRIC.Text.Trim());
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private void GetStaffInfoBYUp(string ID)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@NRICno", ID);

            DataTable dtStaffInfo = dal.executeprocedure("sp_FillNameByStaffId", para, false);
            if (dtStaffInfo.Rows.Count > 0)
            {
                txtIssuedToName.Text = dtStaffInfo.Rows[0][0].ToString().Trim();
                txtIssuedToPosition.Text = dtStaffInfo.Rows[0][1].ToString().Trim();
            }
            else
            {
                txtIssuedToName.Text = "";
                txtIssuedToPosition.Text = "";
            }
        }
        //private void GetStaffInfoToUpd(string ID)
        //{
        //    SqlParameter[] para = new SqlParameter[1];
        //    para[0] = new SqlParameter("@NRICno", ID);

        //    DataTable dtStaffInfo = dal.executeprocedure("sp_FillNameByStaffId", para, false);
        //    if (dtStaffInfo.Rows.Count > 0)
        //    {
        //        txtIssuedToName.Text = dtStaffInfo.Rows[0][0].ToString().Trim();
        //        txtIssuedToPosition.Text = dtStaffInfo.Rows[0][1].ToString().Trim();
        //    }
        //    else
        //    {
        //        txtIssuedToName.Text = "";
        //        txtIssuedToPosition.Text = "";
        //    }
        //}
        #endregion

        # region Add
        protected void btnItemAdd_Click(object sender, EventArgs e)
        {
            SpaMaster MyMasterPage = (SpaMaster)Page.Master;
          
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                string Status = "Issued";

                SqlParameter[] para = new SqlParameter[14];

                para[0] = new SqlParameter("@Model_No", txtmodelnoadd.Text.Trim());
                para[1] = new SqlParameter("@Item_Name", txtitemnameadd.Text.Trim());
                para[2] = new SqlParameter("@Item_Description", txtitemdescadd.Text.Trim());
                para[3] = new SqlParameter("@Item_quantity", txtitemqtyadd.Text.Trim());

                para[4] = new SqlParameter("@IssuedBy_Nric", txtnricaddby.Text.Trim());
                para[5] = new SqlParameter("@IssuedBy_Name", txtnameaddby.Text.Trim());
                para[6] = new SqlParameter("@IssuedBy_Position", txtpositionaddby.Text.Trim());
                para[7] = new SqlParameter("@IssuedBy_Time", DateTime.Now);

                para[8] = new SqlParameter("@IssuedTo_Nric", txtnricaddto.Text.Trim());
                para[9] = new SqlParameter("@IssuedTo_Name", txtnameaddto.Text.Trim());
                para[10] = new SqlParameter("@IssuedTo_Position", txtpositionaddto.Text.Trim());
                para[11] = new SqlParameter("@Status", Status);
                para[12] = new SqlParameter("@Remark", txtcommentaddby.Text.Trim());
                para[13] = new SqlParameter("@Location_id", Session["LCID"].ToString());


                dal.executeprocedure("SP_AddItem", para);

                //HttpContext.Current.Items.Add("COMPLETE", "INSERT");
                //Server.Transfer("CompleteForm.aspx");

                BindGrid();
                ClearAdd();
               // ModalPopupAdd.Hide();
                MyMasterPage.ShowErrorMessage("Record Inserted Successfully..!");     
          
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        protected void btnItemCancel_Click(object sender, EventArgs e)
        {
            ModalPopupAdd.Hide();
            ClearAdd(); 
        }
        public void ClearAdd()
        {
            txtpositionaddby.Text = "";
            txtcommentaddby.Text = "";
            txtpositionaddto.Text = "";
            txtmodelnoadd.Text = "";
            txtitemnameadd.Text = "";
            txtitemdescadd.Text = "";
            txtitemqtyadd.Text = "";
            txtnricaddby.Text = "";
            txtnameaddby.Text = "";
            txtnricaddto.Text = "";
            txtnameaddto.Text = "";
        }


        private void GetStaffInfo(string ID)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@NRICno", ID);

            DataTable dtStaffInfo = dal.executeprocedure("sp_FillNameByStaffId", para, false);
            if (dtStaffInfo.Rows.Count > 0)
            {
                txtnameaddto.Text = dtStaffInfo.Rows[0][0].ToString().Trim();
                txtpositionaddto.Text = dtStaffInfo.Rows[0][1].ToString().Trim();
            }
            else
            {
                txtnameaddto.Text = "";
                txtpositionaddto.Text = "";
            }
        }

        private void GetStaffInfoByNRIC(string ID)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@NRICno", ID);

            DataTable dtStaffInfo = dal.executeprocedure("sp_FillNameByStaffId", para, false);
            if (dtStaffInfo.Rows.Count > 0)
            {
                txtnameaddby.Text = dtStaffInfo.Rows[0][0].ToString().Trim();
                txtpositionaddby.Text = dtStaffInfo.Rows[0][1].ToString().Trim();
            }
            else
            {
                txtnameaddby.Text = "";
                txtpositionaddby.Text = "";
            }
        }



        protected void txtIssuedToNRIC_TextChanged(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                GetStaffInfo(txtnricaddto.Text.Trim());
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }


      
        protected void txtIssuedByNRIC_TextChanged(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                GetStaffInfoByNRIC(txtnricaddby.Text.Trim());
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }


        #endregion



    }
}
