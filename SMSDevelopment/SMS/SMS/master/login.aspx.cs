using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Drawing;
using System.IO;
using SMS.Services.DataService;
using log4net;
using log4net.Config;
using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.BusinessEntities;
using SMS.Services.DALUtilities;
using SMS.Services.BusinessServices;
using SMS.Services;
using SMS.SuperVisor;
using Telerik.Web.UI;

namespace SMS.master
{
    public partial class login1 : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        string StaffID = "";
        int iDT = 0;
        int grdRows = 0;
        DataTable dt = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Convert.ToInt32(User_Role_Id()) == 1)
                {
                    lnkAdmin.Visible = true;
                    lnkOperations.Visible = true;
                    lnkController.Visible = true;
                    lnkSuperUser.Visible = true;
                }
                else
                {
                    lnkAdmin.Visible = false;
                    lnkOperations.Visible = false;
                    lnkController.Visible = false;
                    lnkSuperUser.Visible = false;
                }
                GetAlert();
            }
            //Session["ManagementRole"] = "Superuser";
            //if (!IsPostBack)
            //{
            //FillSettingValue();

            if (Session["ManagementRole"] != null)
            {
                txtdatefrom.Text = DateTime.Now.ToString("MM/dd/yyyy");
                mvAttendence.ActiveViewIndex = 0;
                //if (Session["ManagementRole"].ToString().ToLower().Contains("Superuser") || Session["ManagementRole"].ToString().ToLower().Contains("director"))
                if (Session["ManagementRole"].ToString().ToLower().Contains("superuser") || Session["ManagementRole"].ToString().ToLower().Contains("super security officer"))//change by rakesh
                {
                    grdLocations.DataSource = dal.getdata("select Location_id,Location_name from location where Current_Status='Present' order by Location_name Asc");
                    grdLocations.DataBind();
                    if (Session["LCID"] != null)
                    {
                        mvAttendence.ActiveViewIndex = 1;
                        lnkBack.Visible = true;
                    }
                }
                else if (Session["managementRole"].ToString().ToLower().StartsWith("security") || Session["managementRole"].ToString().ToLower().Contains("supervisor"))
                {
                    if (Session["LCID"] != null)
                    {
                        Session["LCID"] = Session["LCID"].ToString();
                    }
                    lnkBack.Visible = false;
                    mvAttendence.ActiveViewIndex = 1;
                    //BindGuardSchedule(txtdatefrom.Text);
                    BindGuardSchedule();
                }
                else
                {
                    grdLocations.DataSource = dal.getdata("select Location_id,Location_name from location where Location_id in (select LocationID from StaffLocationMap where StaffID='" + Session["StaffID"] + "')");
                    grdLocations.DataBind();
                    if (Session["LCID"] != null)
                    {
                        mvAttendence.ActiveViewIndex = 1;
                    }
                }
            }
            //}
            if (Session["ManagementRole"].ToString().ToLower() == "superuser".ToString() || Session["ManagementRole"].ToString().ToLower() == "super security".ToString())
            {
                divSuperUser.Style.Add(HtmlTextWriterStyle.Display, "");
            }
            else
            {
                divSuperUser.Style.Add(HtmlTextWriterStyle.Display, "none");
                int roleid = User_Role_Id(Session["user_role"].ToString());
                Session["RoleID"] = roleid;

            }

            try
            {
                BindgrdSchedule();
            }
            catch (Exception ex)
            {
            }



        }

        //private void FillSettingValue()
        //{
        //    AdminBLL BLL = new AdminBLL();
        //    BLL.FilldefaultValues();


        //    if (HttpContext.Current.Items["Welcome_heading"] != null)
        //    {
        //        lblWelcom_Heading.Text = HttpContext.Current.Items["Welcome_heading"].ToString();
        //    }
        //}

        private void BindGuardSchedule()
        {
            DateTime temp;
            //if (DateTime.TryParse(date, out temp))
            if (Session["LCID"] != null)
            {

                SqlParameter[] para = new SqlParameter[1];
                para[0] = new SqlParameter("@LocationID", Session["LCID"].ToString());
                //para[1] = new SqlParameter("@CurrentTime", DateTime.Now.ToShortTimeString());
                //para[1] = new SqlParameter("@MDate", date);
                //DataTable dt = dal.executeprocedure1("usp_GetDailySchedule1", para, false);
                //==========================Working Code Date:11/7/2012=====================//
                //=================Purpose:Show Grid which Shows Current User With Current Time======//
                /*
                DataTable dt = dal.executeprocedure("SP_DescriptionDashBoard",para, false);
                if (dt.Rows.Count > 0)
                {
                    grdSchedule.DataSource = dt;
                    grdSchedule.DataBind();
                }
                else
                {
                    grdSchedule.DataSource = null;
                    grdSchedule.DataBind();
                }*/
                //=======================================================================//



                //=========================Changes By:Sandeep Date:16/6/2012========================//
                dt = dal.executeprocedure("usp_GetDailyScheduleLatestForDistinctGaurds", para, false);
                //==================================================================================//
                DataTable dt1 = SMSCommons.SMSCommon.ConvertRowsToColumns(dt, "Shift", "StaffName");
                //DataTable dt1 = SMSCommons.smscom.ConvertRowsToColumns(dt, "Shift", "StaffName");



                grdSchedule.AutoGenerateColumns = false;
                for (int i = 0; i < grdSchedule.Columns.Count; i++)
                {
                    try
                    {
                        grdSchedule.Columns.RemoveAt(0);
                        i--;
                    }
                    catch (Exception ex)
                    {

                    }
                }

                foreach (DataColumn dc in dt1.Columns)
                {
                    TemplateField makeliveCol = new TemplateField();
                    //  makeliveCol.ItemTemplate = new CreateItemTemplateLinkBtn(System.Guid.NewGuid().ToString().Split('-')[System.Guid.NewGuid().ToString().Split('-').Length - 1], dc.ColumnName, "MakeLive", "return confirm('Are you sure you want to publish this version?')");

                    //  makeliveCol.ItemTemplate = new 

                    makeliveCol.HeaderText = dc.ColumnName;
                    makeliveCol.HeaderStyle.Width = Unit.Pixel(180);
                    makeliveCol.ItemStyle.Height = Unit.Pixel(30);
                    makeliveCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
                    makeliveCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                    makeliveCol.HeaderStyle.ForeColor = System.Drawing.Color.White;
                    grdSchedule.Columns.Add(makeliveCol);
                    //grdMy.Columns.Add(makeliveCol);
                }

                grdSchedule.DataSource = dt1;
                grdSchedule.DataBind();


                string script = "";

                //=========================Changes By:Date:11/7/2012============================================//
                // ==========Purpose:To show the same grid as in Login.aspx page for current assigned users=====//

                //try
                //{


                //    int grdcount = grdSchedule.Rows.Count;
                //    foreach (GridViewRow gvrSecurity in grdSchedule.Rows)
                //    {
                //        int gvrgrid = gvrSecurity.Cells.Count;
                //        foreach (TableCell tcSecurity in gvrSecurity.Cells)
                //        {


                //            LinkButton lnkUser = new LinkButton();
                //            lnkUser = ((LinkButton)tcSecurity.Controls[0]);
                //            //string xx = dt1.Rows[countTC][countGR].ToString();
                //            string xx = dt1.Rows[grdSchedule.Rows.Count - grdcount][gvrSecurity.Cells.Count - gvrgrid].ToString();
                //            gvrgrid = gvrgrid - 1;

                //            if (gvrgrid == 0) { grdcount = grdcount - 1; }

                //            if (xx != "")
                //            {
                //                string[] yy = xx.Split('|');
                //                lnkUser.Text = yy[0].ToString();
                //                lnkUser.ToolTip = yy[4].ToString();
                //                lnkUser.ForeColor = Color.Black;
                //                lnkUser.Font.Bold = true;
                //                lnkUser.Font.Underline = false;
                //                lnkUser.Click += ViewDetails;
                //                lnkUser.CommandArgument = lnkUser.ToolTip.ToString();
                //            }




                //            //=======Changes By:Sandeep Date:22/6/2012========//
                //            string StaffID = lnkUser.ToolTip.ToString();
                //            //=========================================================//

                //            // lnkUser.PostBackUrl = "~/ADMIN/ProfileUser.aspx?t1=" + StaffID.ToString();

                //        }

                //    }
                //}
                //catch(Exception ex)
                //{
                //}
                //============================End Changes==============================//

            }





        }
        public int User_Role_Id(string User_Role)
        {
            Session["user_role2"] = User_Role;
            //string x = User_Role;
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConfigurationManager.ConnectionStrings["tspsecur_SMSConnectionString"].ConnectionString;
            cn.Open();
            int result = 0;
            SqlCommand cmd1 = new SqlCommand("select ID from UserRoleMaster where UserRole=@userrole", cn);
            cmd1.Parameters.AddWithValue("@userrole", Session["user_role2"].ToString());
            SqlDataReader dr1 = cmd1.ExecuteReader();
            if (dr1.Read())
            {
                result = dr1.GetInt32(0);
                dr1.Close();
                dr1.Dispose();
                cn.Close();
            }
            return result;
        }
        protected void lnkSuperUser_Click(object sender, ImageClickEventArgs e)
        {
            int roleid = User_Role_Id("Superuser");
            Session["RoleID"] = roleid;
            Session["SubRole"] = "Superuser";
            int id = 1;
            Session["count"] = id;
           // Response.Redirect("login.aspx");

        }

        protected void lnkController_Click(object sender, ImageClickEventArgs e)
        {
            int roleid = User_Role_Id("Controller");
            Session["RoleID"] = roleid;

            Session["SubRole"] = "Controller";
            int id = 1;
            Session["count1"] = id;
            Response.Redirect("login.aspx");
        }

        protected void lnkOperations_Click(object sender, ImageClickEventArgs e)
        {
            int roleid = User_Role_Id("Operations Manager");
            Session["RoleID"] = roleid;

            Session["SubRole"] = "Operations Manager";
            int id = 1;
            Session["count2"] = id;
            Response.Redirect("login.aspx");
        }

        protected void lnkAdmin_Click(object sender, ImageClickEventArgs e)
        {
            int roleid = User_Role_Id("Admin");
            Session["RoleID"] = roleid;

            //Session["SubRole"] = "Admin Executive";
            Session["SubRole"] = "Admin";
            int id = 1;
            Session["count3"] = id;
            Response.Redirect("login.aspx");
        }

        protected void grdLocations_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToLower() == "select")
            {
                Session["LCID"] = e.CommandArgument;
                mvAttendence.ActiveViewIndex = 1;
                //BindGuardSchedule(txtdatefrom.Text);
                BindGuardSchedule();
                lnkBack.Visible = true;
            }
        }
        public object User_Role_Id()
        {
            string User_Id = Session[SMSAppUtilities.SessionKeys.SESSION_LOGIN_USER_ID].ToString();
            Database db = DBConnectionHandler.GetDBConnection().DBConnection;
            DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.SPNames.USER_FIRSTNAME);
            db.AddInParameter(dbCommand, "@UserID", DbType.String, User_Id);
            IDataReader dr = db.ExecuteReader(dbCommand);
            if (dr.Read())
            {
                Session["user_role"] = dr.GetString(2);

            }
            return User_Role_Id1(Session["user_role"].ToString());


        }
        public object User_Role_Id1(string User_Role)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConfigurationManager.ConnectionStrings["tspsecur_SMSConnectionString"].ConnectionString;
            cn.Open();
            SqlCommand cmd1 = new SqlCommand("select ID from UserRoleMaster where UserRole=@userrole", cn);
            cmd1.Parameters.AddWithValue("@userrole", User_Role);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            if (dr1.Read())
            {
                Session["user_id"] = dr1.GetInt32(0);
                dr1.Close();
                dr1.Dispose();
                cn.Close();
            }
            return Session["user_id"];
        }
        protected void lnkBack_Click(object sender, EventArgs e)
        {
            if (Session["ManagementRole"].ToString().ToLower().Contains("superuser") || Session["ManagementRole"].ToString().ToLower().Contains("super security officer"))//change by rakesh
            {

                Session["LCID"] = null;
                grdLocations.DataSource = dal.getdata("select Location_id,Location_name from location where Current_Status='Present' order by Location_name Asc");
                grdLocations.DataBind();
                mvAttendence.ActiveViewIndex = 0;
                lnkBack.Visible = false;
            }
            else
            {
                Session["LCID"] = null;
                grdLocations.DataSource = dal.getdata("select Location_id,Location_name from location,StaffLocationMap where Current_Status='Present' and StaffLocationMap.StaffID='" + Session["StaffID"].ToString() + "' and StaffLocationMap.LocationID=location.Location_id order by Location_name Asc");
                grdLocations.DataBind();
                mvAttendence.ActiveViewIndex = 0;
                lnkBack.Visible = false;
            }
        }


        #region Popup
        protected void BindgrdSchedule()
        {
            if (Session["LCID"] != null)
            {

                SqlParameter[] para = new SqlParameter[1];
                para[0] = new SqlParameter("@LocationID", Session["LCID"].ToString());
                dt = dal.executeprocedure("usp_GetDailyScheduleLatestForDistinctGaurds", para, false);
                //==================================================================================//
                DataTable dt1 = SMSCommons.SMSCommon.ConvertRowsToColumns(dt, "Shift", "StaffName");
                grdSchedule.DataSource = dt1;
                grdSchedule.DataBind();


            }
        }


        protected void OnRowDataBoundgrdSchedule(object sender, GridViewRowEventArgs e)
        {

            if (Session["LCID"] != null)
            {

                SqlParameter[] para = new SqlParameter[1];
                para[0] = new SqlParameter("@LocationID", Session["LCID"].ToString());



                //=========================Changes By:Sandeep Date:16/6/2012========================//
                dt = dal.executeprocedure("usp_GetDailyScheduleLatestForDistinctGaurds", para, false);
                //==================================================================================//
                DataTable dt1 = SMSCommons.SMSCommon.ConvertRowsToColumns(dt, "Shift", "StaffName");




                try
                {


                    //int grdcount = grdSchedule.Rows.Count;
                    //foreach (GridViewRow gvrSecurity in grdSchedule.Rows)
                    //{
                    //    int gvrgrid = gvrSecurity.Cells.Count;
                    //    foreach (TableCell tcSecurity in gvrSecurity.Cells)
                    //    {


                    //        LinkButton lnkUser = new LinkButton();
                    //        lnkUser = ((LinkButton)tcSecurity.Controls[0]);
                    //        //string xx = dt1.Rows[countTC][countGR].ToString();
                    //        string xx = dt1.Rows[grdSchedule.Rows.Count - grdcount][gvrSecurity.Cells.Count - gvrgrid].ToString();
                    //        gvrgrid = gvrgrid - 1;

                    //        if (gvrgrid == 0) { grdcount = grdcount - 1; }

                    //        if (xx != "")
                    //        {
                    //            string[] yy = xx.Split('|');
                    //            lnkUser.Text = yy[0].ToString();
                    //            lnkUser.ToolTip = yy[4].ToString();
                    //            lnkUser.ForeColor = Color.Black;
                    //            lnkUser.Font.Bold = true;
                    //            lnkUser.Font.Underline = false;
                    //            lnkUser.Click += ViewDetails;
                    //            lnkUser.CommandArgument = lnkUser.ToolTip.ToString();
                    //        }




                    //        //=======Changes By:Sandeep Date:22/6/2012========//
                    //        string StaffID = lnkUser.ToolTip.ToString();
                    //        //=========================================================//

                    //        // lnkUser.PostBackUrl = "~/ADMIN/ProfileUser.aspx?t1=" + StaffID.ToString();

                    //    }

                    //}
                }
                catch (Exception ex)
                {
                }
                //============================End Changes==============================//










                int g = e.Row.Cells.Count;


                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    for (int i = 0; i < dt1.Columns.Count; i++)
                    {
                        LinkButton lnkView = new LinkButton();
                        lnkView.ID = "lnkView" + i;
                        //lnkView.Text = e.Row.Cells[i].ToString(); ;
                        lnkView.Click += ViewDetails;
                        // lnkView.CommandArgument = (e.Row.DataItem as DataRowView).Row..ToString();



                        string xx = dt1.Rows[e.Row.RowIndex][i].ToString();




                        if (xx != "")
                        {
                            string[] yy = xx.Split('|');
                            lnkView.Text = yy[0].ToString();
                            lnkView.ToolTip = yy[4].ToString();
                            lnkView.ForeColor = Color.Black;
                            lnkView.Font.Bold = true;
                            lnkView.Font.Underline = true;

                            lnkView.CommandArgument = lnkView.ToolTip.ToString();
                        }

                        e.Row.Cells[i].Controls.Add(lnkView);




                    }
                }
            }
        }

        protected void ViewDetails(object sender, EventArgs e)
        {
            LinkButton lnkView = (sender as LinkButton);
            GridViewRow row = (lnkView.NamingContainer as GridViewRow);
            string id = lnkView.CommandArgument;
            ModalPopupAdd.Show();
            PopulatePageCntrls(id);

        }

        private void PopulatePageCntrls(String argsBGID)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Session["ctrl"] = printview;
                string fullname = string.Empty;
                SqlParameter[] para = new SqlParameter[1];
                para[0] = new SqlParameter("@StaffID", argsBGID);
                DataTable dsStaff = dal.executeprocedure("usp_GetEnrollStaff", para, true);
                if (dsStaff.Rows.Count > 0)
                {

                    fullname = dsStaff.Rows[0]["Staff_PreName"].ToString().Trim();
                    fullname += " ";
                    fullname += dsStaff.Rows[0]["FirstName"].ToString().Trim();
                    fullname += " ";
                    fullname += dsStaff.Rows[0]["MiddleName"].ToString().Trim();
                    fullname += " ";
                    fullname += dsStaff.Rows[0]["LastName"].ToString().Trim();
                    txtfullname.Text = fullname;

                    txtNRIC.Text = dsStaff.Rows[0]["NRICno"].ToString().Trim();
                    txtDOB.Text = dsStaff.Rows[0]["Staff_DOB"].ToString().Trim();
                    txtSex.Text = dsStaff.Rows[0]["Staff_Sex"].ToString().Trim();
                    txtReligion.Text = dsStaff.Rows[0]["Staff_Religion"].ToString().Trim();
                    txtRace.Text = dsStaff.Rows[0]["Staff_Race"].ToString().Trim();
                    txtAge.Text = dsStaff.Rows[0]["Staff_Age"].ToString().Trim();

                    txtMaritalStatus.Text = dsStaff.Rows[0]["Staff_MaritalStatus"].ToString().Trim();
                    txtRole.Text = dsStaff.Rows[0]["Role"].ToString().Trim();
                    ImgageStaff.ImageUrl = dsStaff.Rows[0]["ImagePathName"].ToString().Trim();
                    //ImgageStaff.ImageUrl = "~/admin/Images/f45d6f3d4f32.jpg";
                    txtContNo.Text = dsStaff.Rows[0]["Staff_Telphone"].ToString().Trim();

                    HypNRICWorkPermit.ToolTip = dsStaff.Rows[0]["Staff_NRICWorkPermitCertificate"].ToString().Trim();
                    NSRSWSQModules.ToolTip = dsStaff.Rows[0]["Staff_NSRSWSQModulesCertificate"].ToString().Trim();
                    OtherRecognisedCertificate.ToolTip = dsStaff.Rows[0]["Staff_OtherRecognisedCertificate"].ToString().Trim();
                    ExemptionCertificate.ToolTip = dsStaff.Rows[0]["Staff_ExemptionCertificate"].ToString().Trim();
                    SecurityOfficerLicense.ToolTip = dsStaff.Rows[0]["Staff_SecurityOfficerLicenseCertificate"].ToString().Trim();
                    SIRDScreen.ToolTip = dsStaff.Rows[0]["Staff_SIRDScreenCertificate"].ToString().Trim();
                }

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnprint_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Session["ctrl"] = printview;
                ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('PrintViewPage.aspx','PrintMe','height=700px,width=800px,scrollbars=1');</script>");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnCancelPop_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                ModalPopupAdd.Hide();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }



        #endregion

        # region Google viewer
        protected void ButtonCancelViewer_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                ModalPopupViewer.Hide();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void Nricworkpermit_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                var domainname = Request.ServerVariables["HTTP_HOST"];



                if (HypNRICWorkPermit.ToolTip != "")
                {
                    string[] name = HypNRICWorkPermit.ToolTip.Split('/');

                    string s = " https://docs.google.com/viewer?url=http://" + domainname + "/FileUpload/" + name[2] + "&embedded=true";
                    ViewerDoc.Attributes.Add("src", s);
                    ModalPopupViewer.Show();
                }
                else
                {

                    SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                    MyMasterPage.ShowErrorMessage("No Document Attached..!");
                }


            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        protected void NSRSWSQModules_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                var domainname = Request.ServerVariables["HTTP_HOST"];
                if (NSRSWSQModules.ToolTip != "")
                {

                    string[] name = NSRSWSQModules.ToolTip.Split('/');

                    string s = " https://docs.google.com/viewer?url=http://" + domainname + "/FileUpload/" + name[2] + "&embedded=true";
                    ViewerDoc.Attributes.Add("src", s);
                    ModalPopupViewer.Show();


                    ModalPopupViewer.Show();
                }
                else
                {

                    SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                    MyMasterPage.ShowErrorMessage("No Document Attached..!");
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        protected void OtherRecognisedCertificate_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                var domainname = Request.ServerVariables["HTTP_HOST"];
                if (OtherRecognisedCertificate.ToolTip != "")
                {
                    string[] name = OtherRecognisedCertificate.ToolTip.Split('/');

                    string s = " https://docs.google.com/viewer?url=http://" + domainname + "/FileUpload/" + name[2] + "&embedded=true";
                    ViewerDoc.Attributes.Add("src", s);
                    ModalPopupViewer.Show();
                    ModalPopupViewer.Show();
                }
                else
                {

                    SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                    MyMasterPage.ShowErrorMessage("No Document Attached..!");
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void ExemptionCertificate_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                var domainname = Request.ServerVariables["HTTP_HOST"];
                if (ExemptionCertificate.ToolTip != "")
                {
                    string[] name = ExemptionCertificate.ToolTip.Split('/');

                    string s = " https://docs.google.com/viewer?url=http://" + domainname + "/FileUpload/" + name[2] + "&embedded=true";
                    ViewerDoc.Attributes.Add("src", s);
                    ModalPopupViewer.Show();
                    ModalPopupViewer.Show();
                }
                else
                {

                    SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                    MyMasterPage.ShowErrorMessage("No Document Attached..!");
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        protected void SecurityOfficerLicense_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                var domainname = Request.ServerVariables["HTTP_HOST"];
                if (SecurityOfficerLicense.ToolTip != "")
                {
                    string[] name = SecurityOfficerLicense.ToolTip.Split('/');

                    string s = " https://docs.google.com/viewer?url=http://" + domainname + "/FileUpload/" + name[2] + "&embedded=true";
                    ViewerDoc.Attributes.Add("src", s);
                    ModalPopupViewer.Show();
                    ModalPopupViewer.Show();
                }
                else
                {

                    SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                    MyMasterPage.ShowErrorMessage("No Document Attached..!");
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        protected void SIRDScreen_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                var domainname = Request.ServerVariables["HTTP_HOST"];
                if (SIRDScreen.ToolTip != "")
                {
                    string[] name = SIRDScreen.ToolTip.Split('/');

                    string s = " https://docs.google.com/viewer?url=http://" + domainname + "/FileUpload/" + name[2] + "&embedded=true";
                    ViewerDoc.Attributes.Add("src", s);
                    ModalPopupViewer.Show();
                    ModalPopupViewer.Show();
                }
                else
                {

                    SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                    MyMasterPage.ShowErrorMessage("No Document Attached..!");
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        #endregion




        #region Alert Popup
        public void GetAlert()
        {
            DataTable dt = dal.getdata("select * from Alert_Handling where Status='ON' and P_NRIC_no='" + Session["NricNoOfStaff"].ToString() + "'");
            if (dt.Rows.Count > 0)
            {
                ModalPopupAlert.Show();
                if (dt.Rows[0]["Alert_Type"].ToString() == "Person Alert")
                {
                    PnlPersonAlert.Visible = true;

                    gvPersonAlert.DataSource = dt;
                    gvPersonAlert.DataBind();

                }
                else
                {
                    PnlPersonAlert.Visible = false;
                }
            }


            DataTable dt1 = dal.getdata("select * from Alert_Handling where Status='ON' and V_OwnerNricNo='" + Session["NricNoOfStaff"].ToString() + "'");

            if (dt1.Rows.Count > 0)
            {
                ModalPopupAlert.Show();
                if (dt1.Rows[0]["Alert_Type"].ToString() == "Vehicle Alert")
                {
                    PnlVehicleAlert.Visible = true;
                    gvVehicleAlert.DataSource = dt1;
                    gvVehicleAlert.DataBind();
                }
                else
                {

                    PnlVehicleAlert.Visible = false;
                }
            }

        }
        protected void btnCancelOK_Click(object sender, EventArgs e)
        {
            int i = 0;
            //int ro = ((sender as HiddenField).NamingContainer as GridItem).ItemIndex;
            foreach (GridDataItem item in gvPersonAlert.MasterTableView.Items)
            {
                string iss = item.OwnerTableView.DataKeyValues[i]["Alert_ID"].ToString();
                dal.executesql("update Alert_Handling set Status='Over' where Alert_ID=" + iss);
                i++;
            }
            int j = 0;
            foreach (GridDataItem item in gvVehicleAlert.MasterTableView.Items)
            {
                string iss = item.OwnerTableView.DataKeyValues[j]["Alert_ID"].ToString();
                dal.executesql("update Alert_Handling set Status='Over' where Alert_ID=" + iss);
               j++;
            }

            ModalPopupAlert.Hide();
            //dal.executesql("");
        }

        #endregion




    }
}