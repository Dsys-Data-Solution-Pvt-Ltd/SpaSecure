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
using System.Collections.Generic;

using log4net;
using log4net.Config;
using System.Drawing;

using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.SMSAppUtilities;
using SMS.BusinessEntities;
using Telerik.Web.UI;
using System.Text.RegularExpressions;
using SMS.master;

namespace SMS.SuperVisor
{
    public partial class AdminPass : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
       
          
        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                txtPassNUmber.Focus();
                lblerror.Visible = false;
                LblErrorAdd.Visible = false;
                lblerr1.Visible = false;
                lblerr2.Visible = false;
                lblerr3.Visible = false;
                lblerr5.Visible = false;
              if(!IsPostBack)
              {
                  fillpassno();
                  getPassType("passtype");
                 


                  //Add start
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
                      if (controlname.ToUpper().Contains("gvPassTable".ToUpper()))
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

        private void fillpassno()
        {
            txtPassNUmber.Items.Clear();
            txtPassNUmber.Items.Add("");
            DataSet ds = dal.getdataset("Select Pass_No from Pass_Master");
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                {
                    txtPassNUmber.Items.Add(ds.Tables[0].Rows[k][0].ToString().Trim());
                }                
            }
        }

        private void getPassType(string ID)
        {
            ddlAddPassType.Items.Clear();
            //ddlAddPassType.Items.Add(" ");
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@pass_Type", ID);
            DataTable dtpasstype = dal.executeprocedure("sp_FillValueBylog", para, false);

            if (dtpasstype.Rows.Count > 0)
            {
                for (int k = 0; k < dtpasstype.Rows.Count; k++)
                {
                    ddlAddPassType.Items.Add(dtpasstype.Rows[k][0].ToString());
                }
            }
        }

        protected void gvPass_RowDataBound(object sender, GridViewRowEventArgs e)
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
                    gvPassTable.Columns[0].FooterText = "Total Records: 20";
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

        protected void gvPass_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                string state = string.Empty; 
                string _BTId = Convert.ToString(e.CommandArgument);
                //----------change by rakesh
                SqlDataReader rd = dal.getDataReader("select Pass_Status from Pass_Master where Pass_id ='" + _BTId + "'");//change by rakesh
                if (rd.Read())
                {
                    state = rd.GetString(0);
                    rd.Close();
                }
                //------------------------------------------              

                if (e.CommandName == "EditRow")
                {

                    if (state == "Free")
                    {
                        HttpContext.Current.Items.Add(ContextKeys.CTX_UPDATE_URL, Request.Url.ToString());
                        HttpContext.Current.Items.Add(ContextKeys.CTX_BT_ID, _BTId);
                        Server.Transfer("../SMSAdmin/PassUpDate.aspx");
                        //Response.Redirect("PassUpDate.aspx");

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
            }

            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

       

        protected void gvPass_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                //if (e.NewPageIndex >= 0)
                //{
                //    gvPassTable.PageIndex = e.NewPageIndex;

                //    AdminBLL ws = new AdminBLL();
                //    GetPassData _req = new GetPassData();
                //    GetPassDataResponse _resp = ws.GetPassData(_req);

                //    int pageSize = ContextKeys.GRID_PAGE_SIZE;
                //    gvPassTable.PageSize = pageSize;
                //    gvPassTable.DataSource = _resp.Pass;
                //    gvPassTable.DataBind();
                //}
            }

            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private void BindGridWithFilter()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                AdminBLL ws = new AdminBLL();
                GetPassData objReq = new GetPassData();
                string WhereClause = ReturnWhere();

                if (!string.IsNullOrEmpty(txtPassNUmber.Text))
                {
                    objReq.Pass_No = txtPassNUmber.Text;
                }
                if (!string.IsNullOrEmpty(ddlstatus.Text))
                {
                    objReq.Status = ddlstatus.Text;
                }

                if (!string.IsNullOrEmpty(ddlAddPassType.Text))
                {
                    objReq.pass_Type = ddlAddPassType.Text;
                }
                if (!string.IsNullOrEmpty(WhereClause))
                {
                    objReq.WhereClause = WhereClause;
                }
                if (!string.IsNullOrEmpty(txtdatefrom.Text))
                {
                    if (string.IsNullOrEmpty(txtdateto.Text))
                    {
                        objReq.Date_From = txtdatefrom.Text;
                    }
                }
                if (!string.IsNullOrEmpty(txtdateto.Text))
                {
                    if (!string.IsNullOrEmpty(txtdatefrom.Text))
                    {
                        objReq.Date_From = txtdatefrom.Text;
                        objReq.Date_From = txtdateto.Text;
                    }
                }


                GetPassDataResponse ret = ws.GetPassData(objReq);
                int pageSize = ContextKeys.GRID_PAGE_SIZE;
                gvPassTable.PageSize = pageSize;
                gvPassTable.DataSource = ret.Pass;
                gvPassTable.DataBind();
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

                if (ddlAddPassType.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        makeWhereClause = " where ";
                        str += " and pass_Type='" + ddlAddPassType.Text + "'";
                        arr.Add("1");
                        //str += " and pass_Type='" + ddlAddPassType.Text + "'";
                    }
                    else
                    {
                        str += " and pass_Type='" + ddlAddPassType.Text + "'";
                        //makeWhereClause = " where ";
                        //str += " where pass_Type='" + ddlAddPassType.Text + "'";
                        //arr.Add("1");
                    }
                }


                if (ddlstatus.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        makeWhereClause = " where ";
                        str += " and Pass_Status='" + ddlstatus.Text + "'";
                        arr.Add("3");
                        //str += " and Pass_Status='" + ddlstatus.Text + "'";
                    }
                    else
                    {
                        str += " and Pass_Status='" + ddlstatus.Text + "'";
                        //makeWhereClause = " where ";
                        //str += " where Pass_Status='" + ddlstatus.Text + "'";
                        //arr.Add("3");
                    }
                }

                if (txtPassNUmber.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " and Pass_No='" + txtPassNUmber.Text + "'";
                        arr.Add("2");
                        //str += " and Pass_No='" + txtPassNUmber.Text + "'";
                    }
                    else
                    {
                        str += " and Pass_No='" + txtPassNUmber.Text + "'";
                        //str += " where Pass_No='" + txtPassNUmber.Text + "'";
                        //arr.Add("2");
                    }
                }

                if (txtdateto.Text != "" && txtdatefrom.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " and Pass_Master.Date_From BETWEEN '" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                        arr.Add("5");
                        //str += " and Date_From BETWEEN '" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                    }
                    else
                    {
                        str += " and Pass_Master.Date_From BETWEEN '" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                        //str += " where Date_From BETWEEN '" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                        //arr.Add("5");
                    }
                }
                if (txtdatefrom.Text != "" && txtdateto.Text == "")
                {
                    if (arr.Count == 1)
                    {
                        str += " and Pass_Master.Date_From='" + txtdatefrom.Text + "'";
                        arr.Add("6");
                        //str += " and Date_From='" + txtdatefrom.Text + "'";
                    }
                    else
                    {
                        str += " and Pass_Master.Date_From='" + txtdatefrom.Text + "'";
                        //str += " where Date_From='" + txtdatefrom.Text + "'";
                        //arr.Add("6");
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
                AdminBLL ws = new AdminBLL();
                GetPassData _req = new GetPassData();
                GetPassDataResponse _resp = ws.GetPassData(_req);

                int pageSize = ContextKeys.GRID_PAGE_SIZE;
                gvPassTable.PageSize = pageSize;
                gvPassTable.DataSource = _resp.Pass;
                gvPassTable.DataBind();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

        }

        protected void gvPassTable_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnNewPass_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Response.Redirect("../SuperVisor/AddNewPass.aspx");
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
                BindGridWithFilter();
            }

            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnClearPassAdd_Click(object sender, EventArgs e)
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
            fillpassno();
            txtdatefrom.Text = "";
            txtdateto.Text = "";
            txtPassNUmber.Text = "";
            //ddlAddPassType.Text = "";
            //ddlstatus.Text = "";            
        }

        protected void btnChkInPass_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Response.Redirect("~/SuperVisor/CheckInPass.aspx");
               // Server.Transfer("..//SuperVisor//CheckInPass.aspx");
             
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
            GridDataItem item = gvPassTable.MasterTableView.Items[ro];

            foreach (GridDataItem item1 in gvPassTable.MasterTableView.Items)
            {

                if (item == item1)
                {
                    if ((item.FindControl("CheckBox1") as CheckBox).Checked)
                    {

                        gvPassTable.Items[ro].Selected = true;


                        ViewState["Passid"] = item.OwnerTableView.DataKeyValues[ro]["Pass_id"];


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
        private void DeleteItem(string argPassID)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (!string.IsNullOrEmpty(argPassID))
                {
                    AdminBLL ws = new AdminBLL();
                    DeletePassRequest _req = new DeletePassRequest();

                    //_req.Pass_No = argPassID.ToString();
                    _req.Pass_Id = argPassID.ToString();
                    ws.DeletePass(_req);
                   // HttpContext.Current.Items.Add(ContextKeys.CTX_COMPLETE, "DELETE");
                    //Server.Transfer("AlertUpdateComplete.aspx");
                  //  Response.Redirect("CompleteForm.aspx");


                    BindGrid();
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
          
            DataTable dtAddNewPass = AdminDAL.Checkmenu(Session["RoleID"].ToString(), "93");

            if (dtAddNewPass.Rows.Count > 0)
            {

                getPassTypeAdd("passtype");

                if (Session["ManagementRole"].ToString().ToLower() == "superuser")
                {
                    getLocationName();
                }
                else
                {
                    getLocationNameById(Session["LCID"].ToString());
                }


                ModalPopupAdd.Show();
            }
            else
            {
                MyMasterPage.ShowErrorMessage("You Don not Have Permission ..!");     
          
            }

        }

        protected void imgUpdate_Click(object sender, EventArgs e)
        {
            SpaMaster MyMasterPage = (SpaMaster)Page.Master;
          
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {


                
          
            DataTable dtAddNewPass = AdminDAL.Checkmenu(Session["RoleID"].ToString(), "94");

            if (dtAddNewPass.Rows.Count > 0)
            {




                if (ViewState["Passid"] != null)
                {

                    string _BTId = ViewState["Passid"].ToString();
                    string state = string.Empty;

                    SqlDataReader rd = dal.getDataReader("select Pass_Status from Pass_Master where Pass_id ='" + _BTId + "'");//change by rakesh
                    if (rd.Read())
                    {
                        state = (rd.GetValue(0).ToString().Trim());
                    }
                    rd.Close();
                    rd.Dispose();
                    if (state == "Free")
                    {
                        ModalPopupUpdate.Show();

                        fillpasstype();
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
                MyMasterPage.ShowErrorMessage("You Do not Have Permission ..!");

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
          
               DataTable dtAddNewPass = AdminDAL.Checkmenu(Session["RoleID"].ToString(), "94");

            if (dtAddNewPass.Rows.Count > 0)
            {



                if (ViewState["Passid"] != null)
                {

                    ModalPopupDeleteimage.Show();



                }
            }
            else
            {
                MyMasterPage.ShowErrorMessage("You Do not Have Permission ..!");

            }
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
                if (ViewState["Passid"] != null)
                {

                    string state = string.Empty;
                    string _BTId = ViewState["Passid"].ToString();
                    //----------change by rakesh
                    SqlDataReader rd = dal.getDataReader("select Pass_Status from Pass_Master where Pass_id ='" + _BTId + "'");//change by rakesh
                    if (rd.Read())
                    {
                        state = rd.GetString(0);
                        rd.Close();
                    }


                    if (state == "Free")
                    {
                        DeleteItem(_BTId);
                    }
                    else
                    {
                        MyMasterPage.ShowErrorMessage("Cannot be Delete It is Reserved ..!");     
          
                        //lblerror.Visible = true;
                        //lblerror.Text = "Can't be Delete It's Reserved ..!";
                    }

                    MyMasterPage.ShowErrorMessage("Record Deleted Successfully ..!");
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
        
        # region update

        private void fillpasstype()
        {
            
                DataSet ds1 = dal.getdataset("select Description from log where ID='passtype' order by Description Asc");
                for (int t = 0; t < ds1.Tables[0].Rows.Count; t++)
                {
                    ddlpasstypeupdate.Items.Add(ds1.Tables[0].Rows[t][0].ToString().Trim());
                }
           
        }
        public void ClearUpdate()
        {
            txtpass_id.Text = "";
            txtUpdatePassNo.Text = "";
           // ddlAddPassType.Text = "";
            txtUpdatePassDescription.Text = "";

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            SpaMaster MyMasterPage = (SpaMaster)Page.Master;
          
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Pass objPass_Data = new Pass();
                AdminBLL ws = new AdminBLL();

                objPass_Data.Pass_id = ViewState["Passid"].ToString();
                objPass_Data.Pass_No = txtUpdatePassNo.Text;
                objPass_Data.pass_Type = ddlAddPassType.Text;
                objPass_Data.Pass_Desciption = txtUpdatePassDescription.Text;

                ws.UpdatePassData(objPass_Data);
                BindGrid();
                ModalPopupUpdate.Hide();
                ClearUpdate();
                MyMasterPage.ShowErrorMessage("Record Updated Successfully ..!");     
          
                //HttpContext.Current.Items.Add(ContextKeys.CTX_COMPLETE, "UPDATE");
                //Server.Transfer("AlertUpdateComplete.aspx");
            }

            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private void PopulatePageCntrls(String argsBGID)
        {
            Int32 iCount = 0;
            GetPassDataResponse ret = null;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                //DBConnectionHandler1 db = new DBConnectionHandler1();
                //SqlConnection cn = db.getconnection();
                //cn.Open();
                //SqlCommand cmd = new SqlCommand("select Pass_No,pass_Type,Pass_Desciption from Pass_Master where Pass_id=@passid", cn);
                //cmd.Parameters.AddWithValue("@passid", argsBGID);
                //SqlDataReader dr = cmd.ExecuteReader();
                //if (dr.Read())
                //{

                //    txtUpdatePassNo.Text = dr.GetString(0);
                //    ddlAddPassType.Text = dr.GetString(1);
                //    txtUpdatePassDescription.Text = dr.GetString(2);
                //    cn.Close();
                //}
                //hdnBTID.Value = txtUpdatePassNo.Text;
                AdminBLL objAdminBLL = new AdminBLL();
                GetPassData objGetBillingTableRequest = new GetPassData();
                objGetBillingTableRequest.Pass_No = argsBGID.ToString();

                objGetBillingTableRequest.WhereClause = " where Pass_id= '" + argsBGID + "' ";

                ret = objAdminBLL.GetPassData2(objGetBillingTableRequest);

                //hdnBTID.Value = ret.Pass[iCount].Pass_No.ToString();

                txtpass_id.Text = ret.Pass[iCount].Pass_id.ToString();
                txtUpdatePassNo.Text = ret.Pass[iCount].Pass_No.ToString();
                ddlAddPassType.Text = ret.Pass[iCount].pass_Type.ToString();
                txtUpdatePassDescription.Text = ret.Pass[iCount].Pass_Desciption.ToString();
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
                // Response.Redirect("../SMSAdmin/AdminPass.aspx");
               // Server.Transfer("../SuperVisor/AdminPass.aspx");

                ModalPopupUpdate.Hide();
                ClearUpdate();

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        #endregion


        #region Add

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
            ddllocation.Items.Clear();
            ddllocation.Items.Add("");
            SqlParameter[] para = new SqlParameter[0];
            // para[0] = new SqlParameter("@Location_id", Name);
            DataTable dsLocation = dal.executeprocedure("sp_FillLocationName", para, false);
            if (dsLocation.Rows.Count > 0)
            {
                for (int k = 0; k < dsLocation.Rows.Count; k++)
                {
                    ddllocation.Items.Add(dsLocation.Rows[k][0].ToString().Trim());
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

        private void getPassTypeAdd(string ID)
        {
            ddlpasstypeAdd.Items.Clear();
            ddlpasstypeAdd.Items.Add(" ");
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@pass_Type", ID);
            DataTable dtpasstype = dal.executeprocedure("sp_FillValueBylog", para, false);

            if (dtpasstype.Rows.Count > 0)
            {
                for (int k = 0; k < dtpasstype.Rows.Count; k++)
                {
                    ddlpasstypeAdd.Items.Add(dtpasstype.Rows[k][0].ToString());
                }
            }
        }
        private void GetStaffInfo(string ID)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@NRICno", ID);

            DataTable dtStaffInfo = dal.executeprocedure("sp_FillNameByStaffId", para, false);
            if (dtStaffInfo.Rows.Count > 0)
            {
                txtKeyName.Text = dtStaffInfo.Rows[0][0].ToString().Trim();
                txtposition.Text = dtStaffInfo.Rows[0][1].ToString().Trim();
            }
            else
            {
                txtKeyName.Text = "";
                txtposition.Text = "";
            }

        }

        private int GetLocationIdbyName(string name)
        {
            int locid = 0;
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Location_name", name);

            DataTable dtLocationid = dal.executeprocedure("sp_GetLocationIDbyName", para, false);
            if (dtLocationid.Rows.Count > 0)
            {
                locid = Convert.ToInt32(dtLocationid.Rows[0][0].ToString().Trim());
                return locid;
            }
            return locid;
        }





        protected void btnSearchPassAddpop_Click(object sender, EventArgs e)
        {
            SpaMaster MyMasterPage = (SpaMaster)Page.Master;
          
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                AddNewPassRequest objAddPass = new AddNewPassRequest();
                Pass ObjPass = new Pass();

                if (ddlpasstypeAdd.Text.Trim() != "")
                {
                    String q1 = txtKeyNRIC.Text.Trim();
                    //DataSet ds1 = dal.getdataset("select NRICno from UserInformation");

                    //for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                    //{
                    //    String z = ds1.Tables[0].Rows[i].ItemArray[0].ToString();
                    //    if (string.Equals(q1, z, StringComparison.CurrentCultureIgnoreCase))
                    //    {
                            getLocationIDByName(ddllocation.Text.Trim());
                            ObjPass.pass_Type = ddlpasstypeAdd.Text;
                            ObjPass.Pass_No = txtAddNoType.Text;
                            ObjPass.Pass_Desciption = txtPassDecription.Text;
                            ObjPass.Date_From = Convert.ToDateTime(DateTime.Now);
                            ObjPass.Pass_Status = txtstatus.Text;
                            ObjPass.Staff_ID = txtKeyNRIC.Text;

                            ObjPass.Location_id = SearchLocID.Text;

                            AdminBLL ws = new AdminBLL();
                            ws.AddUserPass(ObjPass);
                            //LblErrorAdd.Visible = true;
                            //LblErrorAdd.Text = "Add Successfully....!";

                            MyMasterPage.ShowErrorMessage("Record Inserted Successfully ..!");
                            BindGrid();
                            ClearAlladd();
                           // break;

                            // HttpContext.Current.Items.Add("COMPLETE", "INSERT");
                            // Server.Transfer("..//SMSADMIN//AlertUpdateComplete.aspx");

                        //}
                        //else
                        //{
                        //    MyMasterPage.ShowErrorMessage("Invalid NRICNo..!");     
          
                        //    //LblErrorAdd.Visible = true;
                        //    //LblErrorAdd.Text = "Invalid NRICNo....!";
                        //    //lblerr2.Visible = true;
                        //}
                   // }


                    //throw new Exception();

                }
                else
                {
                    MyMasterPage.ShowErrorMessage("Please Select Pass Detail ..!");     
          
                           
                    //LblErrorAdd.Visible = true;
                    //LblErrorAdd.Text = "Please Select Pass Detail ..!";
                    //lblerr5.Visible = true;

                }
               
             //   ModalPopupAdd.Hide();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void txtKeyNRIC_TextChanged(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                GetStaffInfo(txtKeyNRIC.Text.Trim());
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnClearPassAddpop_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
               
                ModalPopupAdd.Hide();
                ClearAlladd();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private void ClearAlladd()
        {
            //ddlAddPassType.Text = "";
            txtAddPassType.Text = "";
            txtPassDecription.Text = "";
            txtAddNoType.Text = "";
            txtKeyNRIC.Text = "";
            txtposition.Text = "";
            txtKeyName.Text = "";
        }

        protected void btnAdd1_Click(object sender, EventArgs e)
        {
            SpaMaster MyMasterPage = (SpaMaster)Page.Master;
          
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                String ZipRegex = "^[0-9 a-z A-Z]+$";
                if (txtAddPassType.Text.Trim() != "")
                {
                    if (Regex.IsMatch(txtAddPassType.Text.Trim(), ZipRegex))
                    {
                        DataSet ds = dal.getdataset("select Description from log where ID='passtype' and Description='" + txtAddPassType.Text.Trim() + "'");
                        int count = ds.Tables[0].Rows.Count;
                        if (count == 0)
                        {
                            if (txtAddPassType.Text.Trim() != "")
                            {
                                dal.executesql("insert into log values('passtype'," + count + ",'" + txtAddPassType.Text.Trim() + "')");
                                getPassTypeAdd("passtype");
                                txtAddPassType.Text = "";
                                MyMasterPage.ShowErrorMessage("PassType Added Successfully ..!");     
          
                            }
                        }
                        else
                        {
                            MyMasterPage.ShowErrorMessage("This Value Already Exist ..!");     
          
                            //LblErrorAdd.Visible = true;
                            //LblErrorAdd.Text = "This Value Already Exist ..!";
                            //lblerr3.Visible = true;
                        }
                    }
                    else
                    {
                        MyMasterPage.ShowErrorMessage("Please Fill Only String Values ..!");     
          
                        //LblErrorAdd.Visible = true;
                        //LblErrorAdd.Text = "Please Fill Only String Values ..!";
                        //lblerr3.Visible = true;

                    }
                }
                
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }





        #endregion

    }
}
