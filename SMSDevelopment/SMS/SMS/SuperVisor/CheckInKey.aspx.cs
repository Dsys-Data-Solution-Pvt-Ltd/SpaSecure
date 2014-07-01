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

//using Microsoft.SqlServer.Management.Trace;
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
    public partial class CheckInKey : System.Web.UI.Page
    {
        
        DataAccessLayer dal = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
          log4net.ILog logger = log4net.LogManager.GetLogger("File");
          try
            {
                if (!IsPostBack)
                {
                   getkeybunch("Free");

                   
                   ColorTab();
                   lnkCheckInKey.BackColor = System.Drawing.Color.Maroon;
                   lnkCheckInKey.ForeColor = System.Drawing.Color.White;
                }
                string ctrlname = Page.Request.Params.Get("__EVENTTARGET");
                string ctrlname1 = Page.Request.Params.Get("__eventargument");
                if (ctrlname != null)
                {
                    string controlname = ctrlname;//.Split('$')[ctrlname.Split('$').Length - 1].ToString();
                    if (!controlname.Contains("imdAdd") && !controlname.Contains("imgUpdate") && !controlname.Contains("imgDelete") && !controlname.Contains("imgCopy") && !controlname.Contains("CheckBox1"))
                    {
                        if (controlname.ToUpper().Contains("gvPreRegisteredVisits".ToUpper()))
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


        private void filluserinfo()
        {
            DataSet ds = dal.getdataset("Select Staff_Telphone from UserInformation where NRICno = '" + txtKeyNRIC.Text.Trim() + "' ");
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtphone.Text = ds.Tables[0].Rows[0][0].ToString().Trim();
               
            }
            else
            {
                txtphone.Text = "";
                
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

      
        private int getkeyid(string name)
        {
            int i = 0;
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@BunchNo", ddlbunchno.Text.Trim());               
            DataTable dt = dal.executeprocedure("sp_getkey_id", para, false);

            if (dt.Rows.Count > 0)
            {
                i = Convert.ToInt32(dt.Rows[0][0].ToString());
                return i;
            }
            return i;
        }
        private void getkeybunch(string sta)
        {
            ddlbunchno.Items.Clear();
            ddlbunchno.Items.Add(" ");

            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@status", sta);
            DataTable dtbunch = dal.executeprocedure("sp_getkey_BunchNo", para, false);

            if (dtbunch.Rows.Count > 0)
            {
                for (int k = 0; k < dtbunch.Rows.Count; k++)
                {
                  ddlbunchno.Items.Add(dtbunch.Rows[k][0].ToString());                   
                }
            }           
        }

        private void UpdateStatus(int keyid)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Key_ID", keyid);
            dal.executeprocedure("sp_UpdateKeyStatus", para, false);
        }

       

        private void BindGrid()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                AdminBLL ws = new AdminBLL();
                GetCheckInKey _req = new GetCheckInKey();
                GetCheckInkeyResponse _resp = ws.GetCheckInkey(_req);

                int pageSize = ContextKeys.GRID_PAGE_SIZE;
                gvKeySearch.PageSize = pageSize;
                gvKeySearch.DataSource = _resp.CheckIn_id;
                gvKeySearch.DataBind();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        protected void gvNewKey_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvNewKey_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                //if (e.NewPageIndex >= 0)
                //{
                //    gvKeySearch.PageIndex = e.NewPageIndex;
                //    AdminBLL ws = new AdminBLL();
                //    GetNewKey _req = new GetNewKey();
                //    GetNewKeyRequest _resp = ws.GetNewKey(_req);

                //    int pageSize = ContextKeys.GRID_PAGE_SIZE;
                //    gvKeySearch.PageSize = pageSize;
                //    gvKeySearch.DataSource = _resp.Key;
                //    gvKeySearch.DataBind();
                //}
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
                        "confirm('Are you Sure To Check Out This Key ?')");
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

              
                if (e.CommandName == "DeleteRow")
                {
                    string KeyID = string.Empty;
                    DataSet dsbunchno = dal.getdataset("Select Key_ID from Checkin_key where Chkinkey_id= '" + _BTId + "' ");
                    if (dsbunchno.Tables[0].Rows.Count > 0)
                    {
                        KeyID = dsbunchno.Tables[0].Rows[0][0].ToString().Trim();
                        dal.executesql("Update addnewkey set status ='Free' Where Key_ID = '" + KeyID + "' ");
                    }

                    dal.executesql("Delete from Checkin_key where Chkinkey_id= '" + _BTId + "' ");
                    BindGrid();

                    //DeleteItem(_BTId);
                }
            }

            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }


        protected void btnChkOut_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < gvKeySearch.Rows.Count; i++)
            //{
            //    GridViewRow _gRow = gvKeySearch.Rows[i];
            //    CheckBox _tempCheckBox = ((CheckBox)_gRow.FindControl("chkSelect"));


            //    if (_tempCheckBox.Checked)
            //    {
                    
            //    }

            //}

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


                        ViewState["Chkinkeyid"] = item.OwnerTableView.DataKeyValues[ro]["Chkinkey_id"];


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
        protected void imdAdd_Click(object sender, EventArgs e)
        {
            ModalPopupAdd.Show();
        }

        protected void imgUpdate_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                //if (ViewState["KeyID"] != null)
                //{

                //    string _BTId = ViewState["KeyID"].ToString();
                //    string state = string.Empty;

                //    SqlDataReader rd = dal.getDataReader("select status from addnewkey where Key_ID ='" + _BTId + "'");//change by rakesh
                //    if (rd.Read())
                //    {
                //        state = (rd.GetValue(0).ToString().Trim());
                //    }

                //    if (state == "Free")
                //    {
                //        ModalPopupUpdate.Show();
                //        PopulatePageCntrls(_BTId);
                //        //HttpContext.Current.Items.Add(ContextKeys.CTX_UPDATE_URL, Request.Url.ToString());
                //        //HttpContext.Current.Items.Add(ContextKeys.CTX_BT_ID, _BTId);
                //        //Server.Transfer("KeyDataUpdate.aspx");

                //    }
                //    else
                //    {
                //        lblerror.Visible = true;
                //        lblerror.Text = "Can't be Edit It's Reserved ..!";
                //    }

                //}


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
                if (ViewState["Chkinkeyid"] != null)
                {

                    ModalPopupDeleteimage.Show();
                    



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
                SpaMaster MyMasterPage = (SpaMaster)Page.Master;

                DataTable dtAddNewKey = AdminDAL.Checkmenu(Session["RoleID"].ToString(), "89");
                DataTable dtViewKey = AdminDAL.Checkmenu(Session["RoleID"].ToString(), "90");
                if (dtAddNewKey.Rows.Count > 0)
                {

                    Response.Redirect("../SMSAdmin/AddNewKey.aspx");
                }
                else if (dtViewKey.Rows.Count > 0)
                {
                    Response.Redirect("../SMSAdmin/AddNewKey.aspx");
                }
                else
                {
                    MyMasterPage.ShowErrorMessage("You Don not Have Permission..!");


                }

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
                BindGrid();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            } 
        }

        private void AllClear()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                //ddlbunchno.Text = "";
                txtname.Text = "";
                txtdesignation.Text = "";
                txtKeyNRIC.ClearSelection();
                txtKeyNRIC.Text = "";
                txtphone.Text = "";
                // ddlbunchno.Text = "";

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
                SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                if (ddlbunchno.Text != " ")
                {
                    SqlParameter[] para = new SqlParameter[6];
                    para[0] = new SqlParameter("@Key_ID", getkeyid(ddlbunchno.Text.Trim()));
                    para[1] = new SqlParameter("@Name", txtname.Text.Trim());
                    para[2] = new SqlParameter("@Designation", txtdesignation.Text.Trim());
                    para[3] = new SqlParameter("@Nricno", txtKeyNRIC.Text.Trim());
                    para[4] = new SqlParameter("@ContNo", txtphone.Text.Trim());
                    para[5] = new SqlParameter("@Fromdate", DateTime.Now);
                    //para[7] = new SqlParameter("@LocationID", int.Parse(Session["LCID"].ToString()));

                   int result=  dal.executeprocedure("sp_CheckInKey", para);
                   if (result > 0)
                   {
                       UpdateStatus(getkeyid(ddlbunchno.Text.Trim()));


                       AllClear();
                       BindGrid();
                       getkeybunch("Free");
                       //  ModalPopupAdd.Hide();


                       //HttpContext.Current.Items.Add("COMPLETE", "INSERT");
                       //Server.Transfer("../SMSAdmin/AlertUpdateComplete.aspx");
                       MyMasterPage.ShowErrorMessage("Record Inserted Successfully..!");
                   }
                   else
                   {
                       MyMasterPage.ShowErrorMessage("Faild To Insert Record..!");
                   }
                }
                else
                {
                    MyMasterPage.ShowErrorMessage("Please Add New Key Firstly.");
                }
          
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
                //ddlbunchno.Text = "";
                txtname.Text = "";
                txtdesignation.Text = "";
                txtKeyNRIC.ClearSelection();
                txtKeyNRIC.Text = "";
                txtphone.Text = "";
                // ddlbunchno.Text = "";
                ModalPopupAdd.Hide();
               
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
                if (ViewState["Chkinkeyid"] != null)
                {

                    string _BTId = ViewState["Chkinkeyid"].ToString();



                    string KeyID = string.Empty;
                    DataSet dsbunchno = dal.getdataset("Select Key_ID from Checkin_key where Chkinkey_id= '" + _BTId + "' ");
                    if (dsbunchno.Tables[0].Rows.Count > 0)
                    {
                        KeyID = dsbunchno.Tables[0].Rows[0][0].ToString().Trim();
                        dal.executesql("Update addnewkey set status ='Free' Where Key_ID = '" + KeyID + "' ");
                    }

                    dal.executesql("Delete from Checkin_key where Chkinkey_id= '" + _BTId + "' ");
                    BindGrid();
                    ModalPopupDeleteimage.Hide();
                    MyMasterPage.ShowErrorMessage("Record Deleted Successfully..!");     
          
           
                    //DeleteItem(_BTId);




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



    }
}
