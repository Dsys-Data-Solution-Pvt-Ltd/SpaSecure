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

namespace SMS.SMSAdmin
{
    public partial class AddNewKey : System.Web.UI.Page
    {
        AdminDAL a = new AdminDAL();
        DataAccessLayer dal = new DataAccessLayer();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {

                

                txtKeyNo.Focus();
                lblerror.Visible = false;

                if (!IsPostBack)
                {
                   
                    ColorTab();
                    lnkViewKey.BackColor = System.Drawing.Color.Maroon;
                    lnkViewKey.ForeColor = System.Drawing.Color.White;
                    
                    // getLocationName();
              
                
                    //add start
                    if (Session["ManagementRole"].ToString().ToLower() == "superuser")
                    {
                        getLocationName();
                    }
                    else
                    {
                        getLocationNameById(Session["LCID"].ToString());
                    }

                    //add end



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

        
        //private void getLocationIDByName(string Name)
        //{

        //    SqlParameter[] para = new SqlParameter[1];
        //    para[0] = new SqlParameter("@Location_name", Name);
        //    DataTable dsLocationID = dal.executeprocedure("sp_GetLocationIDbyName", para, false);
        //    if (dsLocationID.Rows.Count > 0)
        //    {
        //        SearchLocID.Text = dsLocationID.Rows[0][0].ToString().Trim();
        //    }
        //}

        //private void getLocationName()
        //{
        //    ddllocation.Items.Clear();
        //    ddllocation.Items.Add(" ");
        //    SqlParameter[] para = new SqlParameter[0];

        //    DataTable dsLocation = dal.executeprocedure("sp_FillLocationName", para, false);
        //    if (dsLocation.Rows.Count > 0)
        //    {
        //        for (int k = 0; k < dsLocation.Rows.Count; k++)
        //        {
        //            ddllocation.Items.Add(dsLocation.Rows[k][0].ToString().Trim());
        //        }
        //    }
        //}


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

                if (e.Row.Cells[2].Text == "Free")
                {
                    e.Row.Cells[2].ForeColor = Color.Red;
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
                string state = string.Empty;

                SqlDataReader rd = dal.getDataReader("select status from addnewkey where Key_ID ='" + _BTId + "'");//change by rakesh
                if (rd.Read())
                {
                    state = (rd.GetValue(0).ToString().Trim());
                }

                if (e.CommandName == "EditRow")
                {
                    if (state == "Free")
                    {
                        HttpContext.Current.Items.Add(ContextKeys.CTX_UPDATE_URL, Request.Url.ToString());
                        HttpContext.Current.Items.Add(ContextKeys.CTX_BT_ID, _BTId);
                        Server.Transfer("KeyDataUpdate.aspx");
                    }
                    else
                    {
                        lblerror.Visible = true;
                        lblerror.Text = "Can't be Edit It's Reserved ..!";
                    }

                }
                if (e.CommandName == "DeleteRow")
                {
                    if (state == "Free")
                    {
                        DeleteItem(_BTId);
                    }
                    else
                    {
                        lblerror.Visible = true;
                        lblerror.Text = "Can't be Delete It's Reserved ..!";
                    }
                }
                //=======================================================//
                rd.Close();
                rd.Dispose();
                //=========================================================//
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
      
        
      

        protected void gvNewKey_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //log4net.ILog logger = log4net.LogManager.GetLogger("File");
            //try
            //{
            //    if (e.NewPageIndex >= 0)
            //    {
            //        gvKeySearch.PageIndex = e.NewPageIndex;
            //        AdminBLL ws = new AdminBLL();
            //        GetNewKey _req = new GetNewKey();
            //        GetNewKeyRequest _resp = ws.GetNewKey(_req);

            //        int pageSize = ContextKeys.GRID_PAGE_SIZE;
            //        gvKeySearch.PageSize = pageSize;
            //        gvKeySearch.DataSource = _resp.Key;
            //        gvKeySearch.DataBind();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    logger.Info(ex.Message);
            //}
        }

        protected void btnNewBTable_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Response.Redirect("NewKeyAdd.aspx");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnClearKeyAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                txtdatefrom.Text = "";
                txtdateto.Text = "";
                ddlstatus.Text = "";
                txtKeyName.Text = "";
                txtKeyNo.Text = "";
                txtKeyNRIC.Text = "";
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnSearchKeyAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                BindGridWithFilter();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
       
        
        protected void gvNewKey_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void BindGridWithFilter()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                AdminBLL ws = new AdminBLL();
                GetNewKey objReq = new GetNewKey();
                string WhereClause = ReturnWhere();

                if (!string.IsNullOrEmpty(txtKeyNo.Text))
                {
                    objReq.key_no = txtKeyNo.Text;
                }
                if (!string.IsNullOrEmpty(ddlstatus.Text))
                {
                    objReq.status = ddlstatus.Text;
                }
                if (!string.IsNullOrEmpty(txtKeyName.Text))
                {
                    objReq.name = txtKeyName.Text;
                }
                if (!string.IsNullOrEmpty(txtKeyNRIC.Text))
                {
                    objReq.nricno = txtKeyNRIC.Text;
                }
                if (!string.IsNullOrEmpty(WhereClause))
                {
                    objReq.WhereClause = WhereClause;
                }

                if (!string.IsNullOrEmpty(txtdateto.Text))
                {
                    if (!string.IsNullOrEmpty(txtdatefrom.Text))
                    {
                        objReq.Date_From = txtdatefrom.Text;
                        objReq.Date_From = txtdatefrom.Text;
                    }
                }

                if (!string.IsNullOrEmpty(txtdatefrom.Text))
                {
                    if (string.IsNullOrEmpty(txtdateto.Text))
                    {
                        objReq.Date_From = txtdatefrom.Text;
                    }
                }
                if (!string.IsNullOrEmpty(ddllocation.SelectedValue.ToString()))
                {
                    getLocationIDByName(ddllocation.SelectedValue.ToString());

                    objReq.Location_Id = SearchLocID.Text;
                    
                }

                GetNewKeyRequest ret = ws.GetNewKey(objReq);
                int pageSize = ContextKeys.GRID_PAGE_SIZE;
                gvKeySearch.PageSize = pageSize;
                gvKeySearch.DataSource = ret.Key;
                gvKeySearch.DataBind();
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

                if (txtKeyNo.Text.Trim() != "")
                {
                    //if (arr.Count == 1)
                    //{
                    //    makeWhereClause = " where ";
                    //    str += " where Key_ID='" + txtKeyNo.Text + "'";
                    //    arr.Add("1");
                    //}
                    //else
                    //{
                     str += " and Key_ID='" + txtKeyNo.Text + "'";
                    //}
                }
                if (ddlstatus.Text.Trim() != "")
                {
                    //if (arr.Count == 1)
                    //{
                    //    str += " where status='" + ddlstatus.Text + "'";
                    //    arr.Add("2");
                    //}
                    //else
                    //{
                       str += " and status='" + ddlstatus.Text + "'";
                    //}
                }
                if (txtKeyName.Text.Trim() != "")
                {
                    //if (arr.Count == 1)
                    //{
                    //    str += " where name='" + txtKeyName.Text + "'";
                    //    arr.Add("3");

                    //}
                    //else
                    //{
                       str += " and name='" + txtKeyName.Text + "'";
                    //}
                }
                if (txtKeyNRIC.Text.Trim() != "")
                {
                    //if (arr.Count == 1)
                    //{
                    //    str += " where Staff_ID='" + txtKeyNRIC.Text + "'";
                    //    arr.Add("4");
                    //}
                    //else
                    //{
                      str += " and Staff_ID='" + txtKeyNRIC.Text + "'";
                    //}
                }

                if (txtdatefrom.Text.Trim() != "" && txtdateto.Text.Trim() != "")
                {
                    //if (arr.Count == 1)
                    //{
                    //    str += " where Date_From BETWEEN '" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                    //    arr.Add("5");
                    //}
                    //else
                    //{
                    str += " and addnewkey.Date_From BETWEEN'" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                    //}
                }

                if (txtdatefrom.Text.Trim() != "" && txtdateto.Text.Trim() == "")
                {
                    //if (arr.Count == 1)
                    //{
                    //    str += " where Date_From='" + txtdatefrom.Text + "'";
                    //    arr.Add("6");
                    //}
                    //else
                    //{
                    str += " and addnewkey.Date_From='" + txtdatefrom.Text + "'";
                    //}
                }
                if (ddllocation.SelectedValue.ToString()!="")
                {
                    getLocationIDByName(ddllocation.SelectedValue.ToString());
                    //if (arr.Count == 1)
                    //{
                    //    str += " where Date_From='" + txtdatefrom.Text + "'";
                    //    arr.Add("6");
                    //}
                    //else
                    //{
                    str += " and addnewkey.Location_ID='" + SearchLocID.Text + "'";
                    //}
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
                AdminBLL ws = new AdminBLL();
                GetNewKey _req = new GetNewKey();
                GetNewKeyRequest _resp = ws.GetNewKey(_req);

                int pageSize = ContextKeys.GRID_PAGE_SIZE;
                gvKeySearch.PageSize = pageSize;
                gvKeySearch.DataSource = _resp.Key;
                gvKeySearch.DataBind();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }


        protected void txtdatefrom_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtdateto_TextChanged(object sender, EventArgs e)
        {

        }

        protected void imgBtnFromDate3_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void imgBtnFromDate2_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnChkinkey_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Response.Redirect("../SuperVisor/CheckInkey.aspx");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnChkoutkey_Click(object sender, EventArgs e)
        {

        }

        protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
        {

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


                        ViewState["KeyID"] = item.OwnerTableView.DataKeyValues[ro]["Key_ID"];


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
            lnkViewKey.BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6");
            lnkCheckInKey.BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6");

        }
        private void DeleteItem(string argKeyID)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (!string.IsNullOrEmpty(argKeyID))
                {
                    AdminBLL ws = new AdminBLL();
                    DeleteKeyRequest _req = new DeleteKeyRequest();

                    _req.KeyNo = argKeyID.ToString();

                    ws.DeleteKey(_req);
                    BindGrid();
                    ////HttpContext.Current.Items.Add(ContextKeys.CTX_COMPLETE, "DELETE");
                    ////Server.Transfer("AlertUpdateComplete.aspx");
                }

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }


        protected void imdAdd_Click(object sender, EventArgs e)
        {
            SpaMaster MyMasterPage = (SpaMaster)Page.Master;
            
            DataTable dtAddNewPass = AdminDAL.Checkmenu(Session["RoleID"].ToString(), "89");

        if (dtAddNewPass.Rows.Count > 0)
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
            {
                SpaMaster MyMasterPage = (SpaMaster)Page.Master;
          // SpaMaster MyMasterPage = (SpaMaster)Page.Master;
            
            DataTable dtAddNewPass = AdminDAL.Checkmenu(Session["RoleID"].ToString(), "90");

        if (dtAddNewPass.Rows.Count > 0)
        {
                if (ViewState["KeyID"] != null)
                {

                    string _BTId = ViewState["KeyID"].ToString();
                    string state = string.Empty;

                    SqlDataReader rd = dal.getDataReader("select status from addnewkey where Key_ID ='" + _BTId + "'");//change by rakesh
                    if (rd.Read())
                    {
                        state = (rd.GetValue(0).ToString().Trim());
                    }
                    rd.Close();
                    rd.Dispose();
                    if (state == "Free")
                    {
                        ModalPopupUpdate.Show();
                        PopulatePageCntrls(_BTId);
                        //HttpContext.Current.Items.Add(ContextKeys.CTX_UPDATE_URL, Request.Url.ToString());
                        //HttpContext.Current.Items.Add(ContextKeys.CTX_BT_ID, _BTId);
                        //Server.Transfer("KeyDataUpdate.aspx");

                    }
                    else
                    {
                       
                        MyMasterPage.ShowErrorMessage("Cannot be Edit It is Reserved ..!");     
          
                        //lblerror.Visible = true;
                        //lblerror.Text = "Can't be Edit It's Reserved ..!";
                    }

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
            {  SpaMaster MyMasterPage = (SpaMaster)Page.Master;
          // SpaMaster MyMasterPage = (SpaMaster)Page.Master;
            
            DataTable dtAddNewPass = AdminDAL.Checkmenu(Session["RoleID"].ToString(), "90");

        if (dtAddNewPass.Rows.Count > 0)
        {
                if (ViewState["KeyID"] != null)
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

        protected void lnkViewKey_Click(object sender, EventArgs e)
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
        protected void lnkCheckInKey_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                 DataTable dtCheckInKey = AdminDAL.Checkmenu(Session["RoleID"].ToString(), "91");

                 if (dtCheckInKey.Rows.Count > 0)
                 {
                     Response.Redirect("../SuperVisor/CheckInkey.aspx");
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
        protected void txtStaffiD_TextChangedUpd(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                filluserinfoUpd();
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
                if (ViewState["KeyID"] != null)
                {

                    string _BTId = ViewState["KeyID"].ToString();
                    string state = string.Empty;

                    SqlDataReader rd = dal.getDataReader("select status from addnewkey where Key_ID ='" + _BTId + "'");//change by rakesh
                    if (rd.Read())
                    {
                        state = (rd.GetValue(0).ToString().Trim());
                    }
                    rd.Close();
                    rd.Dispose();

                    if (state == "Free")
                    {
                        DeleteItem(_BTId);
                        MyMasterPage.ShowErrorMessage("Record Deleted Successfully..!");
                        ModalPopupDeleteimage.Hide();
                    }
                    else
                    {
                       
                        MyMasterPage.ShowErrorMessage("Cannot be Delete It is Reserved ..!");     
          
                        //lblerror.Visible = true;
                        //lblerror.Text = "Can't be Delete It's Reserved ..!";
                    }

                  
                       
          


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

        #region add

        private void getLocationIDByName(string Name)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Location_name", Name);
            DataTable dsLocationID = dal.executeprocedure("sp_GetLocationIDbyName", para, false);
            if (dsLocationID.Rows.Count > 0)
            {
                SearchLocID.Text = dsLocationID.Rows[0][0].ToString().Trim();
            }
        }

        private void getLocationName()
        {
            DropDownList1.Items.Clear();
            DropDownList1.Items.Add(" ");
            SqlParameter[] para = new SqlParameter[0];
            DataTable dsLocation = dal.executeprocedure("sp_FillLocationName", para, false);
            if (dsLocation.Rows.Count > 0)
            {
                for (int k = 0; k < dsLocation.Rows.Count; k++)
                {
                    DropDownList1.Items.Add(dsLocation.Rows[k][0].ToString().Trim());
                }
            }
        }

        private void getLocationNameById(string Name)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Location_id", Name);
            DataTable dsLocationName = dal.executeprocedure("sp_getLocationNameByID", para, false);
            if (dsLocationName.Rows.Count > 0)
            {
                ddllocation.Items.Add(dsLocationName.Rows[0][0].ToString().Trim());
            }
        }


        private void AllClear()
        {
            txtbunchNo.Text = "";
            txtKeyDesc.Text = "";
            txtKeyName.Text = "";
            txtKeyNo.Text = "";
            txtKeyPosition.Text = "";
            ddllocation.Text = "";
            txtStaffiD.ClearSelection();
            txtStaffiD.Text = "";

           

        }



        protected void btnpopupADDClear_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
               
                //ModalPopupDeleteimage.Hide();
                ModalPopupAdd.Hide();
                AllClear();
               // ModalPopupUpdate.Hide();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnpopupADD_Click(object sender, EventArgs e)
        {
            SpaMaster MyMasterPage = (SpaMaster)Page.Master;
          
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                String ZipRegex = "^[0-9]+$";
                AddNewKeyRequest objAddNewKeyRequest = new AddNewKeyRequest();
                AdminAddNewKey objaddkey = new AdminAddNewKey();
                getLocationIDByName(DropDownList1.SelectedValue.ToString());
                String q = txtbunchNo.Text;
                if (txtbunchNo.Text != "")
                {
                    DataSet ds = dal.getdataset("select BunchNo from addnewkey where Location_ID='" + SearchLocID.Text + "' and BunchNo='" + txtbunchNo.Text + "'");

                    int count = ds.Tables[0].Rows.Count;
                    if (count > 0)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            String z = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                            if (string.Equals(q, z, StringComparison.CurrentCultureIgnoreCase))
                            {


                                MyMasterPage.ShowErrorMessage("Bunch No. already exist ..!");
                                return;
                                //LabePopupAddError.Visible = true;
                                //LabePopupAddError.Text = "Bunch No. already exist ..!";
                                //lblerr1.Visible = true;
                                //throw new Exception();
                            }
                        }
                    }
                    else
                    {

                        if (txtStaffiD.Text != "")
                        {
                            String q1 = txtStaffiD.Text;
                            //DataSet ds1 = dal.getdataset("select NRICno from UserInformation");
                            //for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                            //{
                            //    String z = ds1.Tables[0].Rows[i].ItemArray[0].ToString();
                            //    if (string.Equals(q1, z, StringComparison.CurrentCultureIgnoreCase))
                            //    {
                                    getLocationIDByName(DropDownList1.Text.Trim());
                                    objaddkey.BunchNo = txtbunchNo.Text;
                                    objaddkey.Description = txtKeyDesc.Text;
                                    objaddkey.status = txtKeyStatus.Text;
                                    objaddkey.name = txtKeyName.Text;
                                    objaddkey.position = txtKeyPosition.Text;
                                    objaddkey.NoOfKey = txtKeyNo.Text;
                                    objaddkey.Staff_ID = txtStaffiD.Text;
                                    // objaddkey.Location_ID = Convert.ToInt32(SearchLocID.Text);
                                    objaddkey.Location_ID = SearchLocID.Text;
                                    objaddkey.Date_From = Convert.ToDateTime(DateTime.Now);

                                    AdminBLL ws = new AdminBLL();
                                    ws.Add_NewKey(objaddkey);
                                    AllClear();

                                    //LabePopupAddError.Visible = true;
                                    //LabePopupAddError.Text = "Insert Succesfully ..!";
                                    MyMasterPage.ShowErrorMessage("Record Inserted Succesfully ..!");


                                    //HttpContext.Current.Items.Add("COMPLETE", "INSERT");
                                    //Server.Transfer("AlertUpdateComplete.aspx");
                                    BindGrid();
                            //    }
                            //}
                        }
                        else
                        {
                            MyMasterPage.ShowErrorMessage("Please Fill NRICno ..!");
                        }
                      //  MyMasterPage.ShowErrorMessage("Invalid NRICno  ..!");

                        //LabePopupAddError.Visible = true;
                        //LabePopupAddError.Text = "Invalid NRICno ID ....!";
                        //lblerr2.Visible = true;

                    }
                }
                else
                {
                    MyMasterPage.ShowErrorMessage("Please Fill Bunch No.!");
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private void filluserinfo()
        {
            DataSet ds = dal.getdataset("Select FirstName,Role from UserInformation where NRICno = '" + txtStaffiD.Text.Trim() + "' ");
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtKeyName.Text = ds.Tables[0].Rows[0][0].ToString().Trim();
                txtKeyPosition.Text = ds.Tables[0].Rows[0][1].ToString().Trim();
            }
            else
            {
                txtKeyName.Text = "";
                txtKeyPosition.Text = "";
            }
        }

        private void filluserinfoUpd()
        {
            DataSet ds = dal.getdataset("Select FirstName,Role from UserInformation where NRICno = '" + txtKeyNRICUpdate.Text.Trim() + "' ");
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtKeyNameUpdate.Text = ds.Tables[0].Rows[0][0].ToString().Trim();
                txtKeyPositionUpdate.Text = ds.Tables[0].Rows[0][1].ToString().Trim();
            }
            else
            {
                txtKeyNameUpdate.Text = "";
                txtKeyPositionUpdate.Text = "";
            }
        }

        protected void txtStaffiD_TextChanged(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                filluserinfo();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        #endregion

        # region Update

        protected void btnBackPassAdmin_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                //   Response.Redirect("~\addnewkey.aspx");
                // Server.Transfer("AddNewKey.aspx");
                ModalPopupUpdate.Hide();
                ClearUpdate();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SpaMaster MyMasterPage = (SpaMaster)Page.Master;
          
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                AdminAddNewKey objKey_Data = new AdminAddNewKey();
                AdminBLL ws = new AdminBLL();

                objKey_Data.key_no = txtKeyNoUpdate.Text;
                objKey_Data.Description = txtKeyDescUpdate.Text;
                objKey_Data.name = txtKeyNameUpdate.Text;
                objKey_Data.position = txtKeyPositionUpdate.Text;
                objKey_Data.count = txtKeyConntUpdate.Text;
                objKey_Data.nricno = txtKeyNRICUpdate.Text;

                ws.UpdateKeyData(objKey_Data);
                //HttpContext.Current.Items.Add(ContextKeys.CTX_COMPLETE, "UPDATE");
                //Server.Transfer("AlertUpdateComplete.aspx");
                BindGrid();
                MyMasterPage.ShowErrorMessage("Record Updated Successfully..!");
                ModalPopupUpdate.Hide();
                ClearUpdate();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        public void ClearUpdate()
        {
            txtKeyNoUpdate.Text = "";
            txtKeyNRICUpdate.Text = "";
            txtKeyConntUpdate.Text = "";
            txtKeyPositionUpdate.Text = "";
            txtKeyDescUpdate.Text = "";
            txtKeyNameUpdate.Text = "";

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

                objGetBillingTableRequest.WhereClause = " and Key_ID= '" + argsBGID + "' ";

                ret = objAdminBLL.GetNewKey(objGetBillingTableRequest);

                hdnBTID.Value = ret.Key[iCount].key_ID.ToString();
                //hdnBTID.Value = ret.Key[iCount].Description.ToString();

                txtKeyNoUpdate.Text = ret.Key[iCount].key_ID.ToString();
                txtKeyDescUpdate.Text = ret.Key[iCount].Description.ToString();

                txtKeyNameUpdate.Text = ret.Key[iCount].name.ToString();
                txtKeyPositionUpdate.Text = ret.Key[iCount].position.ToString();
                txtKeyNRICUpdate.Text = ret.Key[iCount].Staff_ID.ToString();
                txtKeyConntUpdate.Text = ret.Key[iCount].NoOfKey.ToString();

                //-------------------------------------------------------------------
                //DBConnectionHandler1 db = new DBConnectionHandler1();
                //SqlConnection cn = db.getconnection();
                //cn.Open();
                //SqlCommand cmd = new SqlCommand("select NRICno from UserInformation where NRICno=@staffid", cn);
                //cmd.Parameters.AddWithValue("@staffid", txtKeyNRICUpdate.Text);
                //SqlDataReader dr = cmd.ExecuteReader();
                //if (dr.Read())
                //{

                //    txtKeyNRICUpdate.SelectedItem.Text = dr.GetString(0);
                //    //txtKeyConnt.Text = "";
                //    //========================//
                //    dr.Close();
                //    dr.Dispose();
                //    //========================//
                //    cn.Close();
                //}
                //-------------------------------------------------------------------

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

        }

        #endregion


    }
}

