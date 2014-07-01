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
using System.Globalization;
using SMS.master;
namespace SMS.SuperVisor
{
    public partial class AdminClientVisitMinutes : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        String iBTID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {

                if (HttpContext.Current.Session["SESSION_LOGIN_USER"] == null)
                {
                    Response.Redirect("~/master/login3.aspx");
                }


                if (!IsPostBack)
                {

                    if (Session["ManagementRole"].ToString().ToLower() == "superuser")
                    {
                        getLocationName();
                    }
                    else
                    {
                        getLocationNameById(Session["LCID"].ToString());
                    }

                    getLocationIDByName(ddllocation.Text.Trim());
                   // BindGrid();
                    
                    //getLocationNameById(Session["LCID"].ToString());

                }
                string ctrlname = Page.Request.Params.Get("__EVENTTARGET");
                string ctrlname1 = Page.Request.Params.Get("__eventargument");
                if (ctrlname != null)
                {
                    string controlname = ctrlname;//.Split('$')[ctrlname.Split('$').Length - 1].ToString();
                    if (!controlname.Contains("imdAdd") && !controlname.Contains("imgCopy") && !controlname.Contains("imgDelete") && !controlname.Contains("CheckBox1"))
                    {
                        if (controlname.ToUpper().Contains("gvPassTable1".ToUpper()))
                        {
                            if (ctrlname1 != null)
                            {
                                if (ctrlname1.Contains("RowClick"))
                                { 
                                
                                }
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


        private void getLocationName()
        {
            ddllocation.Items.Clear();
           // ddllocation.Items.Add(" ");
            SqlParameter[] para = new SqlParameter[0];            
            DataTable dsLocation = dal.executeprocedure("sp_FillLocationName", para, false);
            if (dsLocation.Rows.Count > 0)
            {
                for (int k = 0; k < dsLocation.Rows.Count; k++)
                {
                    ddllocation.Items.Add(dsLocation.Rows[k][0].ToString().Trim());
                    ddlLocationAdd.Items.Add(dsLocation.Rows[k][0].ToString().Trim());
                }
            }
        }
        private void getLocationNameById(string Name)       
        {
            ddllocation.Items.Clear();                      //change by rakesh 11jl
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Location_id", Name);
            DataTable dsLocationName = dal.executeprocedure("sp_getLocationNameByID", para, false);
            if (dsLocationName.Rows.Count > 0)
            {
                ddllocation.Items.Add(dsLocationName.Rows[0][0].ToString().Trim());
            }
        }
        private void getLocationIDByName(string Name)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Location_name", Name);
            DataTable dsLocationID = dal.executeprocedure("sp_GetLocationIDbyName", para, false);
            if (dsLocationID.Rows.Count > 0)
            {
                Searchid.Text = dsLocationID.Rows[0][0].ToString().Trim();
            }
        }


        
        private void BindGrid()
        {
          //  string where = ReturnWhere();

            DataSet ds = dal.getdataset("Select * from tblClientVisitMinutes");
            //if (ds.Tables[0].Rows.Count > 0)
            // {
                gvPassTable1.DataSource = ds;
                gvPassTable1.DataBind();
             //}
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

                if (ddllocation.Text.Trim() != "")
                {
                    if (arr.Count == 1)
                    {
                        makeWhereClause = " where ";
                        str += " where Location='" + ddllocation.Text.Trim() + "'";
                        arr.Add("1");
                    }
                    else
                    {
                        str += " and Location='" + ddllocation.Text.Trim() + "'";
                    }
                }
                if (txtcompletedby.Text.Trim() != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where CompletedBy = '" + txtcompletedby.Text + "'";
                        arr.Add("2");
                    }
                    else
                    {
                        str += " and CompletedBy = '" + txtcompletedby.Text + "'";
                    }
                }


                if (txtdateto.Text != "" && txtdatefrom.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where Date BETWEEN '" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                        arr.Add("3");
                    }
                    else
                    {
                        str += " and Date BETWEEN '" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                    }
                }
                if (txtdatefrom.Text != "" && txtdateto.Text == "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where Date ='" + txtdatefrom.Text + "'";
                        arr.Add("4");
                    }
                    else
                    {
                        str += " and Date ='" + txtdatefrom.Text + "'";
                    }
                }


            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
            return (str);
        }

        //private void fillLocation()
        //{
        //    //ddllocation.Items.Clear();
        //    //ddllocation.Items.Add(" ");

        //    //SqlParameter[] para = new SqlParameter[0];
        //    //DataTable dsLocation = dal.executeprocedure("sp_FillLocationName", para, false);
        //    //if (dsLocation.Rows.Count > 0)
        //    //{
        //    //    for (int j = 0; j < dsLocation.Rows.Count; j++)
        //    //    {
        //    //        ddllocation.Items.Add(dsLocation.Rows[j][0].ToString().Trim());
        //    //    }
        //    //}
        //    string location = Session["LCID"].ToString();
        //    ddllocation.Items.Add(location);
        //}

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
                string _BTId = Convert.ToString(e.CommandArgument);
                string state = string.Empty;

                if (e.CommandName == "View")
                {
                    HttpContext.Current.Items.Add(ContextKeys.CTX_UPDATE_URL, Request.Url.ToString());
                    HttpContext.Current.Items.Add(ContextKeys.CTX_BT_ID, _BTId);
                    Server.Transfer("ClientVisitMinuteReport.aspx");
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

        private void DeleteItem(string argPassID)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (!string.IsNullOrEmpty(argPassID))
                {

                    dal.executesql("Delete from tblClientVisitMinutes where strCVID = '" + argPassID + "' ");
                    HttpContext.Current.Items.Add(ContextKeys.CTX_COMPLETE, "DELETE");
                    //Server.Transfer("CompleteForm.aspx");
                    BindGrid();
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

        protected void btnNewPass_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Response.Redirect("../SuperVisor/ClientVisitMinutes.aspx");
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
                BindGrid();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
            
        }

        protected void btnClearPassAdd_Click(object sender, EventArgs e)         //change by rakesh 11jl
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (Session["ManagementRole"].ToString().ToLower() == "superuser")
                {
                    getLocationName();
                }
                else
                {
                    getLocationNameById(Session["LCID"].ToString());
                }

                txtcompletedby.Text = "";
                txtdatefrom.Text = "";
                txtdateto.Text = "";
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
            
        }

        #region Add
        
        protected void ImgAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                this.ModalPopupAdd.Show();
            }
            catch (Exception ex)
            {
                logger.Info("AdminCappAsset(AssertImgUpdate_Click):" + ex.Message);
            }

        }
        protected void btnAssignmentAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                SqlParameter[] para = new SqlParameter[9];
                para[0] = new SqlParameter("@Location", ddlLocationAdd.Text.Trim());
                para[1] = new SqlParameter("@CompletedBy", txtCompletedByAdd.Text.Trim());
                para[2] = new SqlParameter("@Date", txtdatefromAdd.Text.Trim());
                para[3] = new SqlParameter("@ClientName", txtClientName.Text.Trim());
                para[4] = new SqlParameter("@Complaints", txtcomplaints.Text.Trim());
                para[5] = new SqlParameter("@PositiveComment", txtpositivecomments.Text.Trim());
                para[6] = new SqlParameter("@Deployment", txtdeployment.Text.Trim());
                para[7] = new SqlParameter("@UpcomingEvent", txtupcomingevent.Text.Trim());
                para[8] = new SqlParameter("@Remarks", txtremarks.Text.Trim());

                dal.executeprocedure("SP_AddClientVisitMinutes", para);

                HttpContext.Current.Items.Add("COMPLETE", "INSERT");
               // Server.Transfer("CompleteForm.aspx");
                MyMasterPage.ShowErrorMessage("Record Insert SuccessFully"); 
               
                //dal.executesql("Update PreRegisteredVisits set FromDate='" + txtFromDate.Text.Trim() + "',ToDate='" + txtToDate.Text.Trim() + "',ExpectedTime='" + newtime + "',Name='" + txtName.Text.Trim() + "',Company='" + txtCompany.Text.Trim() + "',Position='" + txtPosition.Text.Trim() + "',Invited_By='" + txtInvitedBy.Text.Trim() + "',LocationID='" + Searchid.Text + "',VechicleNo='" + txtVechicle.Text + "',Purpose='" + txtpurpose.Text + "',Telephoe='"+txttelephone.Text+"' where PRVID ='" + hdnCSID.Value + "' ");
              //  ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AlertMessage", " alert('Record Insert SuccessFully');", true);
                BindGrid();
                ClearAdd();       
                       
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearAdd();            
        }
        void ClearAdd()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                // ddllocation.Text = "";
                txtcompletedby.Text = "";
                txtdatefrom.Text = "";
                txtClientName.Text = "";
                txtcomplaints.Text = "";
                txtpositivecomments.Text = "";
                txtdeployment.Text = "";
                txtupcomingevent.Text = "";
                txtremarks.Text = "";
                ModalPopupAdd.Hide();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        #endregion
        #region View
        protected void ImgView_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (ViewState["strCVID"] != null)
                {
                    //view
                    DBConnectionHandler1 bd = new DBConnectionHandler1();
                    SqlConnection cn = bd.getconnection();
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("select * from UploadLogo", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        if (dr.GetString(0) != "")
                        {
                            image1.ImageUrl = dr.GetString(0);
                            cn.Close();
                            dr.Close();
                        }
                    }
                    cn.Close();
                    dr.Close();
                    if (HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL] != null)
                    {
                        string strURL = HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL].ToString();
                    }
                    PopulatePageCntrls(ViewState["strCVID"].ToString());
                   // Fill();
                    this.ModalPopupUpdate.Show();
                    Session["ctrl"] = printview;
                }
            }
            catch (Exception ex)
            {
                logger.Info("AdminCappAsset(AssertImgUpdate_Click):" + ex.Message);
            }
        }
        private void PopulatePageCntrls(String argsBGID)
        {

            DataSet dspan = dal.getdataset("Select Location,CompletedBy,Date,ClientName,Complaints,PositiveComment,Deployment,UpcomingEvent,Remarks from tblClientVisitMinutes where strCVID = '" + argsBGID + "' ");
            if (dspan.Tables[0].Rows.Count > 0)
            {

                ddlocationView.Text = dspan.Tables[0].Rows[0][0].ToString().Trim();
                txtcompletedbyView.Text = dspan.Tables[0].Rows[0][1].ToString().Trim();
                txtdatefromView.Text = dspan.Tables[0].Rows[0][2].ToString().Trim();
                txtClientNameView.Text = dspan.Tables[0].Rows[0][3].ToString().Trim();

                txtcomplaintsView.Text = dspan.Tables[0].Rows[0][4].ToString().Trim();
                txtpositivecommentsView.Text = dspan.Tables[0].Rows[0][5].ToString().Trim();
                txtdeploymentView.Text = dspan.Tables[0].Rows[0][6].ToString().Trim();
                txtupcomingeventView.Text = dspan.Tables[0].Rows[0][7].ToString().Trim();
                txtremarksView.Text = dspan.Tables[0].Rows[0][8].ToString().Trim();

            }

        }

        protected void btnprint_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Session["ctrl"] = printview;
                ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('printpage.aspx','PrintMe','height=700px,width=800px,scrollbars=1');</script>");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        protected void BtnCancelPrint_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                this.ModalPopupUpdate.Hide();
               // ClearUpdate();
            }
            catch (Exception ex)
            {
                logger.Info("ClientVisitMinuteReport(BtnCancelPrint_Click):" + ex.Message);
            }
        }

#endregion
        #region delete
        protected void ImgDelete_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (ViewState["strCVID"] != null)
                {
                    this.ModalPopupDelete.Show();
                }
            }
            catch (Exception ex)
            {
                logger.Info("AdminCappAsset(AssertImgUpdate_Click):" + ex.Message);
            }
        }
        protected void Deletepopup_Yes_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                if (ViewState["strCVID"] != null)
                {
                    DeleteItem(ViewState["strCVID"].ToString());
                    MyMasterPage.ShowErrorMessage("Record Delete SuccessFully"); 
                   // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AlertMessage", " alert('Record Delete SuccessFully');", true);
                    BindGrid();
                    ViewState["strCVID"] = null;
                    ModalPopupDelete.Hide();
                }
            }
            catch (Exception ex)
            {
                logger.Info("AdminClientVisitMinutes(Deletepopup_Yes_Click):" + ex.Message);
            }
        }
        protected void btnCancelDelete_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                this.ModalPopupDelete.Hide();
            }
            catch (Exception ex)
            {
                logger.Info("AdminClientVisitMinutes(btnCancelDelete_Click):" + ex.Message);
            }
        }


        #endregion

        protected void ToggleRowSelection(object sender, EventArgs e)
        {
            ((sender as CheckBox).NamingContainer as GridItem).Selected = (sender as CheckBox).Checked;
            bool checkHeader = true;
            List<string> lstreportsession = new List<string>();
            int ro = ((sender as CheckBox).NamingContainer as GridItem).ItemIndex;
            GridDataItem item = gvPassTable1.MasterTableView.Items[ro];

            foreach (GridDataItem item1 in gvPassTable1.MasterTableView.Items)
            {
                if (item == item1)
                {
                    if ((item.FindControl("CheckBox1") as CheckBox).Checked)
                    {
                        gvPassTable1.Items[ro].Selected = true;
                        ViewState["strCVID"] = item.OwnerTableView.DataKeyValues[ro]["strCVID"];
                    }
                }
                else
                {
                    (item1.FindControl("CheckBox1") as CheckBox).Checked = false;
                }
            }
        }
    }
}
