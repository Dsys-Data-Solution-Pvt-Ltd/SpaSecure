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
using SMS.master;

namespace SMS.SuperVisor
{
    public partial class AdminAssignment_Vist : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();

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
                    string staffid = Session["StaffID"].ToString();
                    fillNameandNRIC(staffid);
                    if (Session["ManagementRole"].ToString().ToLower() == "superuser")
                    {
                        fillLocation();
                    }
                    else
                    {
                        getLocationNameById(Session["LCID"].ToString());
                    }
                    
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
        private void fillNameandNRIC(string id)
        {
            DataSet dsuserinfo = dal.getdataset("Select FirstName,MiddleName,LastName,NRICno from Userinformation where Staff_ID='" + id + "' ");
            if (dsuserinfo.Tables[0].Rows.Count > 0)
            {
                txtsubmittedby.Text = dsuserinfo.Tables[0].Rows[0]["FirstName"].ToString();
                txtsubmittedby.Text += "";
                txtsubmittedby.Text += dsuserinfo.Tables[0].Rows[0]["MiddleName"].ToString();
                txtsubmittedby.Text += "";
                txtsubmittedby.Text += dsuserinfo.Tables[0].Rows[0]["LastName"].ToString();
                txtnric.Text = dsuserinfo.Tables[0].Rows[0]["NRICno"].ToString();
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
        private void fillLocation()
        {
            ddllocation.Items.Clear();
            ddllocation.Items.Add(" ");

            SqlParameter[] para = new SqlParameter[0];
            DataTable dsLocation = dal.executeprocedure("sp_FillLocationName", para, false);
            if (dsLocation.Rows.Count > 0)
            {
                for (int j = 0; j < dsLocation.Rows.Count; j++)
                {
                    ddllocation.Items.Add(dsLocation.Rows[j][0].ToString().Trim());
                }
            }
        }
        private void getLocationIDByName(string Name)
        {
            searchid.Text = ddllocation.Text;
            //SqlParameter[] para = new SqlParameter[1];
            //para[0] = new SqlParameter("@Location_name", Name);
            //DataTable dsLocationID = dal.executeprocedure("sp_GetLocationIDbyName", para, false);
            //if (dsLocationID.Rows.Count > 0)
            //{
            //   searchid.Text = dsLocationID.Rows[0][0].ToString().Trim();
            //}
        }

        private void BindGrid()
        {
            getLocationIDByName(ddllocation.Text.Trim());
            string where = ReturnWhere();
            //DataSet ds = dal.getdataset("Select * from tblAssignmentVisit "+where+" ");
            DataSet ds = dal.getdataset("Select * from tblAssignmentVisit");
            //if (ds.Tables[0].Rows.Count > 0)
            //{
                gvPassTable.DataSource = ds.Tables[0];
                gvPassTable.DataBind();
            //}
        }

        protected void btnNewPass_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Response.Redirect("../SuperVisor/Assignment_Visit.aspx");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
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

                if (e.CommandName == "EditRow")
                {
                    HttpContext.Current.Items.Add(ContextKeys.CTX_UPDATE_URL, Request.Url.ToString());
                    HttpContext.Current.Items.Add(ContextKeys.CTX_BT_ID, _BTId);
                    Server.Transfer("AssignmentVisitReport.aspx");
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
                        str += " where strNameOfAssignment='" + searchid.Text.Trim() + "'";
                        arr.Add("1");
                    }
                    else
                    {
                        str += " and strNameOfAssignment='" + searchid.Text.Trim() + "'";
                    }
                }
                if (txtsubmitedBy.Text.Trim() != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where strSubmittedBy = '" + txtsubmitedBy.Text + "'";
                        arr.Add("2");
                    }
                    else
                    {
                        str += " and strSubmittedBy = '" + txtsubmitedBy.Text + "'";
                    }
                }


                if (txtdateto.Text != "" && txtdatefrom.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where dtmDateVisit BETWEEN '" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                        arr.Add("3");
                    }
                    else
                    {
                        str += " and dtmDateVisit BETWEEN '" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                    }
                }
                if (txtdatefrom.Text != "" && txtdateto.Text == "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where dtmDateVisit ='" + txtdatefrom.Text + "'";
                        arr.Add("4");
                    }
                    else
                    {
                        str += " and dtmDateVisit ='" + txtdatefrom.Text + "'";
                    }
                }


            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
            return (str);
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

        protected void btnClearPassAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
               // ddllocation.Text = "";
                fillLocation();
                txtdatefrom.Text = "";
                txtsubmitedBy.Text = "";
                //txtsubmitedBy.Text = "";
                txtdateto.Text = "";

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        # region Icon menu

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
        protected void btnClear_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                ClearAdd();
                this.ModalPopupAdd.Hide();
            }
            catch (Exception ex)
            {
                logger.Info("AdminCappAsset(AssertImgUpdate_Click):" + ex.Message);
            }

        }

        public void ClearAdd()
        {
            txtTo.Text = "";
           // txtsubmittedby.Text = "";
           // ddllocation.Text = "";
            txtIC.Text = "";
            txtdressing.Text = "";
            txtappearance.Text = "";
            txthaircut.Text = "";
            ddrAlertness.Text = "";
            ddrDeployment.Text = "";
            ddrgeneralPerformance.Text = "";
            txtotherMatters.Text = "";
            txtconclustion.Text = "";
            txtrecommendation.Text = "";

            txtGuard1.Text = "";
            txtGuard2.Text = "";
            txtGuard3.Text = "";
            txtGuard4.Text = "";
            txtGuard5.Text = "";
            txtGuard6.Text = "";
            txtGuard7.Text = "";
            txtGuard8.Text = "";
            txtGuard9.Text = "";
            txtGuard10.Text = "";
        }
        protected void btnAssignmentAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                string time = TimeSelector1.Date.TimeOfDay.ToString();
                string dtime = txtdatefrom.Text + " " + time;
                SqlParameter[] para = new SqlParameter[24];
                para[0] = new SqlParameter("@strTo", txtTo.Text.Trim());
                para[1] = new SqlParameter("@strSubmittedBy", txtsubmittedby.Text.Trim());
                para[2] = new SqlParameter("@strNameOfAssignment", ddllocation.Text.Trim());
                para[3] = new SqlParameter("@dtmDateVisit", dtime);
                para[4] = new SqlParameter("@strInCharge", txtIC.Text.Trim());
                para[5] = new SqlParameter("@strGuards1", txtGuard1.Text.Trim());

                para[6] = new SqlParameter("@strDressing", txtdressing.Text.Trim());
                para[7] = new SqlParameter("@strAppearance", txtappearance.Text.Trim());
                para[8] = new SqlParameter("@strHaircut", txthaircut.Text.Trim());
                para[9] = new SqlParameter("@strAlertness", ddrAlertness.SelectedValue);
                para[10] = new SqlParameter("@strDeployment", ddrDeployment.SelectedValue);
                para[11] = new SqlParameter("@strGeneralPerformance", ddrgeneralPerformance.SelectedValue);
                para[12] = new SqlParameter("@strOtherMatters", txtotherMatters.Text.Trim());
                para[13] = new SqlParameter("@strConclussion", txtconclustion.Text.Trim());
                para[14] = new SqlParameter("@strRecommendation", txtrecommendation.Text.Trim());

                para[15] = new SqlParameter("@strGuards2", txtGuard2.Text.Trim());
                para[16] = new SqlParameter("@strGuards3", txtGuard3.Text.Trim());
                para[17] = new SqlParameter("@strGuards4", txtGuard4.Text.Trim());
                para[18] = new SqlParameter("@strGuards5", txtGuard5.Text.Trim());
                para[19] = new SqlParameter("@strGuards6", txtGuard6.Text.Trim());
                para[20] = new SqlParameter("@strGuards7", txtGuard7.Text.Trim());
                para[21] = new SqlParameter("@strGuards8", txtGuard8.Text.Trim());
                para[22] = new SqlParameter("@strGuards9", txtGuard9.Text.Trim());
                para[23] = new SqlParameter("@strGuards10", txtGuard10.Text.Trim());

                int re=dal.executeprocedure("sp_InsertAssignmentVisit", para);
                //if (re > 0)
                //{

                //    //dal.executesql("Update PreRegisteredVisits set FromDate='" + txtFromDate.Text.Trim() + "',ToDate='" + txtToDate.Text.Trim() + "',ExpectedTime='" + newtime + "',Name='" + txtName.Text.Trim() + "',Company='" + txtCompany.Text.Trim() + "',Position='" + txtPosition.Text.Trim() + "',Invited_By='" + txtInvitedBy.Text.Trim() + "',LocationID='" + Searchid.Text + "',VechicleNo='" + txtVechicle.Text + "',Purpose='" + txtpurpose.Text + "',Telephoe='"+txttelephone.Text+"' where PRVID ='" + hdnCSID.Value + "' ");
                   // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AlertMessage", " alert('Record Insert SuccessFully');", true);
                MyMasterPage.ShowErrorMessage("Record Insert SuccessFully");  
                
                BindGrid();
                    ClearAdd();
                    ModalPopupAdd.Hide();
                   // this.ModalPopupAdd.Hide();
                //}
                //else
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AlertMessage", " alert('Failed To Insert Record');", true);
                //}
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        #endregion

        # region Delete
        private void DeleteItem(string argPassID)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (!string.IsNullOrEmpty(argPassID))
                {
                    dal.executesql("Delete from tblAssignmentVisit where intID = '" + argPassID + "' ");
                    HttpContext.Current.Items.Add(ContextKeys.CTX_COMPLETE, "DELETE");
                    //Server.Transfer("AlertUpdateComplete.aspx");
                  //  Response.Redirect("CompleteForm.aspx");
                }
            }

            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void ImgDelete_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (ViewState["intID"] != null)
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
                if (ViewState["intID"] != null)
                {
                    DeleteItem(ViewState["intID"].ToString());
                    BindGrid();
                    MyMasterPage.ShowErrorMessage("Record Deleted SuccessFully");  
                   // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AlertMessage", " alert('Record Deleted SuccessFully');", true);
                    this.ModalPopupDelete.Hide();
                }
            }
            catch (Exception ex)
            {
                logger.Info("AdminCappAsset(AssertImgUpdate_Click):" + ex.Message);
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
                logger.Info("AdminCappAsset(AssertImgUpdate_Click):" + ex.Message);
            }
        }

        #endregion

        #region View

        public void FillView()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
                try
                {
                    if (ViewState["intID"] != null)
                    {
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
                        if (HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL] != null)
                        {
                            string strURL = HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL].ToString();
                            //((SMSmaster)this.Master).FilterContent(strURL, btnsave.ID, SMSAppUtilities.SMSAppEnums.ContentType.Update);
                        }


                        Int32 iCount = 0;


                        DataSet dsgetvalue = dal.getdataset("Select strTo,strSubmittedBy,strNameOfAssignment,strInCharge,strDressing,strAppearance,strHaircut,strAlertness,strDeployment,strGeneralPerformance,strOtherMatters,strConclussion,strRecommendation,strGuards1,strGuards2,strGuards3,strGuards4,strGuards5,strGuards6,strGuards7,strGuards8,strGuards9,strGuards10,dtmDateVisit from tblAssignmentVisit where intID='" + ViewState["intID"].ToString() + "'");
                        if (dsgetvalue.Tables[0].Rows.Count > 0)
                        {

                            txtToView.Text = dsgetvalue.Tables[0].Rows[0][0].ToString().Trim();
                            txtToView.Visible = false;
                            txtsubmittedbyView.Text = dsgetvalue.Tables[0].Rows[0][1].ToString().Trim();
                            txtNameofAssignmentView.Text = dsgetvalue.Tables[0].Rows[0][2].ToString().Trim();
                            txtICView.Text = dsgetvalue.Tables[0].Rows[0][3].ToString().Trim();
                            txtdressingView.Text = dsgetvalue.Tables[0].Rows[0][4].ToString().Trim();
                            txtappearanceView.Text = dsgetvalue.Tables[0].Rows[0][5].ToString().Trim();
                            txthaircutView.Text = dsgetvalue.Tables[0].Rows[0][6].ToString().Trim();
                            txtAlertnessView.Text = dsgetvalue.Tables[0].Rows[0][7].ToString().Trim();

                            txtDeploymentView.Text = dsgetvalue.Tables[0].Rows[0][8].ToString().Trim();
                            txtgeneralPerformanceView.Text = dsgetvalue.Tables[0].Rows[0][9].ToString().Trim();
                            txtotherMattersView.Text = dsgetvalue.Tables[0].Rows[0][10].ToString().Trim();
                            txtconclustionView.Text = dsgetvalue.Tables[0].Rows[0][11].ToString().Trim();
                            txtrecommendationView.Text = dsgetvalue.Tables[0].Rows[0][12].ToString().Trim();

                            txtGuard1View.Text = dsgetvalue.Tables[0].Rows[0][13].ToString().Trim();
                            txtGuard2View.Text = dsgetvalue.Tables[0].Rows[0][14].ToString().Trim();
                            txtGuard3View.Text = dsgetvalue.Tables[0].Rows[0][15].ToString().Trim();
                            txtGuard4View.Text = dsgetvalue.Tables[0].Rows[0][16].ToString().Trim();
                            txtGuard5View.Text = dsgetvalue.Tables[0].Rows[0][17].ToString().Trim();

                            txtGuard6View.Text = dsgetvalue.Tables[0].Rows[0][18].ToString().Trim();
                            txtGuard7View.Text = dsgetvalue.Tables[0].Rows[0][19].ToString().Trim();
                            txtGuard8View.Text = dsgetvalue.Tables[0].Rows[0][20].ToString().Trim();
                            txtGuard9View.Text = dsgetvalue.Tables[0].Rows[0][21].ToString().Trim();
                            txtGuard10View.Text = dsgetvalue.Tables[0].Rows[0][22].ToString().Trim();

                            txtdateofvisitView.Text = dsgetvalue.Tables[0].Rows[0][23].ToString().Trim();

                        }
                    }

                }
                catch (Exception ex)
                {
                    logger.Info(ex.Message);
                }
            
        }
        protected void ImageView(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (ViewState["intID"] != null)
                {
                    FillView();
                    ModalPopupView.Show();
                    Session["ctrl"] = tblview;
                }
            }
            catch (Exception ex)
            {
                logger.Info("AdminCappAsset(AssertImgUpdate_Click):" + ex.Message);
            }
        }
        protected void btnCancelView_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                ModalPopupView.Hide();
            }
            catch (Exception ex)
            {
                logger.Info("AdminCappAsset(AssertImgUpdate_Click):" + ex.Message);
            }
        }
        #endregion


        #endregion


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


                        ViewState["intID"] = item.OwnerTableView.DataKeyValues[ro]["intID"];


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
