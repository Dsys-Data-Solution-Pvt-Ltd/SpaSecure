using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMS.SMSAppUtilities;
using SMS.Services.DataService;
using System.Data.SqlClient;
using System.Data;
using Telerik.Web.UI;
using SMS.master;

namespace SMS.Client
{
    public partial class ViewPreRegisteredVisotors : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ManagementRole"].ToString().ToLower() == "superuser" || Session["ManagementRole"].ToString().ToLower() == "super security")
                {
                    getLocationName();
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
                    if (controlname.ToUpper().Contains("gvPreRegisteredVisits".ToUpper()))
                    {
                        if (ctrlname1 != null)
                        {
                            if (ctrlname1.Contains("RowClick"))
                            { }
                            else if (ctrlname1.ToUpper().Contains("FIRECOMMAND") || ctrlname1 == "")
                            {
                                BindGridWithFilter();
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
                BindGridWithFilter();
            }
           
        }

        #region 
       
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

        private void getLocationName()
        {
            SqlParameter[] para = new SqlParameter[0];
            DataTable dsLocation = dal.executeprocedure("sp_FillLocationName", para, false);
            if (dsLocation.Rows.Count > 0)
            {
                ddllocation.DataSource = dsLocation;
                ddllocation.DataTextField = "Location_name";
                ddllocation.DataValueField = "Location_id";
                ddllocation.DataBind();
                ddllocation.Items.Insert(0, "");

                ddllocationUpdate.DataSource = dsLocation;
                ddllocationUpdate.DataTextField = "Location_name";
                ddllocationUpdate.DataValueField = "Location_id";
                ddllocationUpdate.DataBind();
                ddllocationUpdate.Items.Insert(0, "");

                ddllocationView.DataSource = dsLocation;
                ddllocationView.DataTextField = "Location_name";
                ddllocationView.DataValueField = "Location_id";
                ddllocationView.DataBind();
                ddllocationView.Items.Insert(0, "");
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
        //private String getLocationNameByIdDrop(string Name)
        //{
        //    string Location="";
        //    SqlParameter[] para = new SqlParameter[1];
        //    para[0] = new SqlParameter("@Location_id", Name);
        //    DataTable dsLocationName = dal.executeprocedure("sp_getLocationNameByID", para, false);
        //    if (dsLocationName.Rows.Count > 0)
        //    {
        //          Location=dsLocationName.Rows[0][0].ToString().Trim();
        //    }
        //    return Location;
        //}

        #endregion



        #region BindGrid
        private string ReturnWhere()
        {
            string str = string.Empty;
            string makeWhereClause = string.Empty;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                List<String> arr = new List<String>();
                arr.Add("test");
                if (arr.Count == 1)
                {
                    str += " where AlertStatus ='ON' ";
                    arr.Add("9");
                }
                else
                {
                    str += " and AlertStatus ='ON' ";
                }

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
            return (str);
        }

        private void BindGridWithFilter()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                string where = ReturnWhere();
                //string where = "";
                DataSet dsitem = dal.getdataset("Select PRVID,convert(varchar, FromDate, 101) as FromDate1,convert(varchar, ToDate, 101) as ToDate1,ExpectedTime,Name,Invited_By,Company,Position from PreRegisteredVisits " + where + " order by FromDate desc");
                if (dsitem.Tables[0].Rows.Count > 0)
                {

                    // gvPreRegisteredVisits.PageSize = 20;
                    gvPreRegisteredVisits.DataSource = dsitem.Tables[0];
                    gvPreRegisteredVisits.DataBind();
                }
                else
                {

                    gvPreRegisteredVisits.DataSource = string.Empty;
                    gvPreRegisteredVisits.DataBind();
                }
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
            GridDataItem item = gvPreRegisteredVisits.MasterTableView.Items[ro];

            foreach (GridDataItem item1 in gvPreRegisteredVisits.MasterTableView.Items)
            {

                if (item == item1)
                {
                    if ((item.FindControl("CheckBox1") as CheckBox).Checked)
                    {

                        gvPreRegisteredVisits.Items[ro].Selected = true;


                        ViewState["PRVID"] = item.OwnerTableView.DataKeyValues[ro]["PRVID"];


                    }
                }
                else
                {
                    (item1.FindControl("CheckBox1") as CheckBox).Checked = false;
                }


            }
         
        }
        #endregion
       

        //protected void btnClearKeyAdd_Click(object sender, EventArgs e)
        //{
        //    log4net.ILog logger = log4net.LogManager.GetLogger("File");
        //    try
        //    {
        //        txtdatefrom.Text = "";
        //        txtdateto.Text = "";
        //        txtInvitedby.Text = "";
        //        txtVisitors.Text = "";
        //        //ddllocation.Text = "";
        //        if (Session["ManagementRole"].ToString().ToLower() == "superuser")
        //        {
        //            getLocationName();
        //        }
        //        else
        //        {
        //            getLocationNameById(Session["LCID"].ToString());
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Info(ex.Message);
        //    }
        //}

     
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
        protected void btnCancelCStaff_Click(object sender, EventArgs e)
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
            txtFromDate.Text = "";
            txtCompany.Text = "";
            txtInvitedBy.Text = "";
            txtName.Text = "";
            txtPosition.Text = "";
            txtpurpose.Text = "";
            txttelephone.Text = "";
            txtToDate.Text = "";
            txtVechicle.Text = "";
            ddllocation.SelectedIndex = 0;
           // this.ModalPopupAdd.Hide();
        }

        protected void btnAddVisitor_Click(object sender, EventArgs e)
        {

            SpaMaster MyMasterPage = (SpaMaster)Page.Master;
            getLocationIDByName(ddllocation.SelectedItem.Text.Trim());
            if (txtFromDate.Text.Trim() != "" && txtName.Text.Trim() != "" && txtPosition.Text.Trim() != "" && txtCompany.Text.Trim() != "" && txtInvitedBy.Text.Trim() != "")
            {
                DateTime fromdate = Convert.ToDateTime(txtFromDate.Text.Trim());
                DateTime Todate = Convert.ToDateTime(txtToDate.Text.Trim());
                string time = tsExpectedTime.Date.TimeOfDay.ToString();
                string newtime = time.Substring(0, 5);
                string name = txtName.Text.Trim();
                string company = txtCompany.Text.Trim();
                string position = txtPosition.Text.Trim();
                string invitedby = txtInvitedBy.Text.Trim();
                string vechileno = txtVechicle.Text.Trim();
                string telepohne = txttelephone.Text.Trim();
                string purpose = txtpurpose.Text.Trim();

                if (txtToDate.Text.Trim() == "")
                {
                    txtToDate.Text = "";
                }
                    // dal.executesql("Insert into PreRegisteredVisits(FromDate,ToDate,ExpectedTime,Name,Company,Position,Invited_By,LocationID,VechicleNo,Purpose,Telephoe,AlertStatus) values('" + txtFromDate.Text.Trim() + "','" + txtToDate.Text.Trim() + "','" + newtime + "','" + txtName.Text.Trim() + "','" + txtCompany.Text.Trim() + "','" + txtPosition.Text + "','" + txtInvitedBy.Text.Trim() + "','" + Searchid.Text + "','" + txtVechicle.Text + "','" + txtpurpose.Text + "','" + txttelephone.Text + "','ON') ");
                    SqlParameter[] para1 = new SqlParameter[11];
                    para1[0] = new SqlParameter("@FromDate", fromdate);
                    para1[1] = new SqlParameter("@ToDate", Todate);
                    para1[2] = new SqlParameter("@ExpectedTime", time);
                    para1[3] = new SqlParameter("@LocationID", Searchid.Text);
                    //para1[3] = new SqlParameter("@LocationID", Searchid.Text);
                    para1[4] = new SqlParameter("@Invited_By", invitedby);
                    para1[5] = new SqlParameter("@Name", name);
                    para1[6] = new SqlParameter("@Company", company);
                    para1[7] = new SqlParameter("@Position", position);
                    para1[8] = new SqlParameter("@Telephoe", telepohne);
                    para1[9] = new SqlParameter("@Purpose", purpose);
                    para1[10] = new SqlParameter("@VechicleNo", vechileno);
                     int re=dal.executeprocedure("SP_AddPrevisitors", para1);

                    if (re > 0)
                     {
                         MyMasterPage.ShowErrorMessage("Record Insert SuccessFully"); 
                         //dal.executesql("Update PreRegisteredVisits set FromDate='" + txtFromDate.Text.Trim() + "',ToDate='" + txtToDate.Text.Trim() + "',ExpectedTime='" + newtime + "',Name='" + txtName.Text.Trim() + "',Company='" + txtCompany.Text.Trim() + "',Position='" + txtPosition.Text.Trim() + "',Invited_By='" + txtInvitedBy.Text.Trim() + "',LocationID='" + Searchid.Text + "',VechicleNo='" + txtVechicle.Text + "',Purpose='" + txtpurpose.Text + "',Telephoe='"+txttelephone.Text+"' where PRVID ='" + hdnCSID.Value + "' ");
                         //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AlertMessage", " alert('Record Insert SuccessFully');", true);
                         BindGridWithFilter();
                         ClearAdd();
                         //this.ModalPopupAdd.Hide();
                     }
                     else
                     {
                         MyMasterPage.ShowErrorMessage("Failed To Insert Record"); 
                        // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AlertMessage", " alert('Failed To Insert Record');", true);
                     }
                }
                else
               {
                   MyMasterPage.ShowErrorMessage("Please Fill All Field"); 
                    //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AlertMessage", " alert('Please Fill All Field');", true);
                }


        }

        protected void ddllocation_SelectedIndexChanged1(object sender, EventArgs e)
        {
            Searchid.Text = ddllocation.Text;
        }
        #endregion


        #region Update

        public void Fill()
        {
            if (ViewState["PRVID"] != null)
            {
                string location = string.Empty;
                SqlParameter[] para = new SqlParameter[1];
                para[0] = new SqlParameter("@PRVID", ViewState["PRVID"].ToString());
                DataTable dt = dal.executeprocedure("usp_GetPreRegisteredVisit", para, true);
                txtFromDateUpdate.Text = DateTime.Parse(dt.Rows[0]["FromDate"].ToString()).ToString("MM/dd/yyyy");
                txtToDateUpdate.Text = DateTime.Parse(dt.Rows[0]["ToDate"].ToString()).ToString("MM/dd/yyyy");
                string expected = dt.Rows[0]["ExpectedTime"].ToString();
                tsExpectedTimeUpdate.Hour = int.Parse(expected.Split(':')[0]);
                tsExpectedTimeUpdate.Minute = int.Parse(expected.Split(':')[1]);
                txtNameUpdate.Text = dt.Rows[0]["Name"].ToString();
                txtCompanyUpdate.Text = dt.Rows[0]["Company"].ToString();
                txtPositionUpdate.Text = dt.Rows[0]["Position"].ToString();
                txtInvitedByUpdate.Text = dt.Rows[0]["Invited_By"].ToString();
                txttelephoneUpdate.Text = dt.Rows[0]["Telephoe"].ToString();
                txtVechicleUpdate.Text = dt.Rows[0]["VechicleNo"].ToString();
                txtpurposeUpdate.Text = dt.Rows[0]["Purpose"].ToString();
                location = dt.Rows[0]["LocationID"].ToString();
                //location=  getLocationNameByIdDrop(location);
                ddllocationUpdate.SelectedValue = location;
            }
        }
        protected void ImgUpdate_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (ViewState["PRVID"] != null)
                {
                    Fill();
                    this.ModalPopupUpdate.Show();
                }
            }
            catch (Exception ex)
            {
                logger.Info("AdminCappAsset(AssertImgUpdate_Click):" + ex.Message);
            }
        }
        protected void BtnCancelUpdate_Click(object sender, EventArgs e)
        { 
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                this.ModalPopupUpdate.Hide();
            ClearUpdate();
            }
            catch (Exception ex)
            {
                logger.Info("AdminCappAsset(AssertImgUpdate_Click):" + ex.Message);
            }
        }

        public void ClearUpdate()
        {
            txtFromDateUpdate.Text = "";
            txtCompanyUpdate.Text = "";
            txtInvitedByUpdate.Text = "";
            txtNameUpdate.Text = "";
            txtPositionUpdate.Text = "";
            txtpurposeUpdate.Text = "";
            txttelephoneUpdate.Text = "";
            txtToDateUpdate.Text = "";
            txtVechicleUpdate.Text = "";
            ddllocationUpdate.SelectedIndex = 0;
            this.ModalPopupUpdate.Hide();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            SpaMaster MyMasterPage = (SpaMaster)Page.Master;
            if (ViewState["PRVID"] != null)
            {
                getLocationIDByName(ddllocationUpdate.SelectedItem.Text.Trim());
                if (txtFromDateUpdate.Text.Trim() != "" && txtNameUpdate.Text.Trim() != "" && txtPositionUpdate.Text.Trim() != "" && txtCompanyUpdate.Text.Trim() != "" && txtInvitedByUpdate.Text.Trim() != "")
                {
                    DateTime fromdate = Convert.ToDateTime(txtFromDateUpdate.Text.Trim());
                    DateTime Todate = Convert.ToDateTime(txtToDateUpdate.Text.Trim());
                    string time = tsExpectedTimeUpdate.Date.TimeOfDay.ToString();
                    string newtime = time.Substring(0, 5);
                    string name = txtNameUpdate.Text.Trim();
                    string company = txtCompanyUpdate.Text.Trim();
                    string position = txtPositionUpdate.Text.Trim();
                    string invitedby = txtInvitedByUpdate.Text.Trim();
                    string vechileno = txtVechicleUpdate.Text.Trim();
                    string telepohne = txttelephoneUpdate.Text.Trim();
                    string purpose = txtpurposeUpdate.Text.Trim();

                    if (txtToDateUpdate.Text.Trim() == "")
                    {
                        txtToDateUpdate.Text = "";
                    }
                    SqlParameter[] para = new SqlParameter[12];
                    para[0] = new SqlParameter("@FromDate", fromdate);
                    para[1] = new SqlParameter("@ToDate", Todate);
                    para[2] = new SqlParameter("@ExpectedTime", time);
                    para[3] = new SqlParameter("@LocationID", ddllocationUpdate.SelectedValue);

                    para[4] = new SqlParameter("@Invited_By", invitedby);
                    para[5] = new SqlParameter("@Name", name);
                    para[6] = new SqlParameter("@Company", company);
                    para[7] = new SqlParameter("@Position", position);
                    para[8] = new SqlParameter("@Telephoe", telepohne);
                    para[9] = new SqlParameter("@Purpose", purpose);
                    para[10] = new SqlParameter("@VechicleNo", vechileno);
                    para[11] = new SqlParameter("@PRVID", ViewState["PRVID"].ToString());
                     int re= dal.executeprocedure("SP_UpdatePrevisitors", para);
                     if (re > 0)
                     {
                         MyMasterPage.ShowErrorMessage("Record Updated SuccessFully");   
                         //dal.executesql("Update PreRegisteredVisits set FromDate='" + txtFromDate.Text.Trim() + "',ToDate='" + txtToDate.Text.Trim() + "',ExpectedTime='" + newtime + "',Name='" + txtName.Text.Trim() + "',Company='" + txtCompany.Text.Trim() + "',Position='" + txtPosition.Text.Trim() + "',Invited_By='" + txtInvitedBy.Text.Trim() + "',LocationID='" + Searchid.Text + "',VechicleNo='" + txtVechicle.Text + "',Purpose='" + txtpurpose.Text + "',Telephoe='"+txttelephone.Text+"' where PRVID ='" + hdnCSID.Value + "' ");
                       //  ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AlertMessage", " alert('Record Updated SuccessFully');", true);
                         BindGridWithFilter();
                         ClearUpdate();
                         this.ModalPopupUpdate.Hide();
                     }
                     else
                     {
                         MyMasterPage.ShowErrorMessage("Failed To Update Record");   
                         //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AlertMessage", " alert('Failed To Update Record');", true);
                     }
                }
                else
                {
                    MyMasterPage.ShowErrorMessage("Please Fill All Field");   
                    //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AlertMessage", " alert('Please Fill All Field');", true);
                }
            }

        }

        #endregion update

        # region Delete
        private void DeleteItem(string argPRVID)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (!string.IsNullOrEmpty(argPRVID))
                {
                    dal.executesql("Update PreRegisteredVisits set AlertStatus='OFF' where PRVID=" + argPRVID);
                    HttpContext.Current.Items.Add(ContextKeys.CTX_COMPLETE, "DELETE");
                    this.ModalPopupDelete.Hide();
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
                if (ViewState["PRVID"] != null)
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
                if (ViewState["PRVID"] != null)
                {
                    DeleteItem(ViewState["PRVID"].ToString());
                    BindGridWithFilter();
                    MyMasterPage.ShowErrorMessage("Record Deleted Successfully");
                  //  ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AlertMessage", " alert('Record Deleted Successfully');", true);
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
            if (ViewState["PRVID"] != null)
            {
                string location = string.Empty;
                SqlParameter[] para = new SqlParameter[1];
                para[0] = new SqlParameter("@PRVID", ViewState["PRVID"].ToString());
                DataTable dt = dal.executeprocedure("usp_GetPreRegisteredVisit", para, true);
                txtFromDateView.Text = DateTime.Parse(dt.Rows[0]["FromDate"].ToString()).ToString("MM/dd/yyyy");
                txtToDateView.Text = DateTime.Parse(dt.Rows[0]["ToDate"].ToString()).ToString("MM/dd/yyyy");
                string expected = dt.Rows[0]["ExpectedTime"].ToString();
                tsExpectedTimeView.Hour = int.Parse(expected.Split(':')[0]);
                tsExpectedTimeView.Minute = int.Parse(expected.Split(':')[1]);
                txtNameView.Text = dt.Rows[0]["Name"].ToString();
                txtCompanyView.Text = dt.Rows[0]["Company"].ToString();
                txtPositionView.Text = dt.Rows[0]["Position"].ToString();
                txtInvitedByView.Text = dt.Rows[0]["Invited_By"].ToString();
                txttelephoneView.Text = dt.Rows[0]["Telephoe"].ToString();
                txtVechicleView.Text = dt.Rows[0]["VechicleNo"].ToString();
                txtpurposeView.Text = dt.Rows[0]["Purpose"].ToString();
                ddllocationView.SelectedValue = dt.Rows[0]["LocationID"].ToString();
            }
        }
        protected void ImageView(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (ViewState["PRVID"] != null)
                {
                    FillView();
                    ModalPopupView.Show();
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
    }
}
