using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Data;
using System.Data.SqlClient;
using SMS.Services.DataService;
using SMS.SMSCommons;
using System.Drawing;
using SMS.Services.DALUtilities;
using Telerik.Web.UI;

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
using log4net;
using log4net.Config;
using System.Data.SqlClient;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.Services.DataService;
using SMS.SMSAppUtilities;
using SMS.BusinessEntities;
using MKB.TimePicker;
using MKB.Exceptions;
using System.Text.RegularExpressions;
using SMS.master;

namespace SMS.SuperVisor
{
    public partial class DailyRoster : System.Web.UI.Page
    {
       
          
        DataAccessLayer dal = new DataAccessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                GridView1.Columns[2].Visible = false;
                string url = Request.ServerVariables["URL"];
                if (hdnHash.Value != "")
                {
                    dal.executesql("delete from DailyGuardAssign where DGAID =" + hdnHash.Value);
                    hdnHash.Value = "";
                }
                if (!IsPostBack)
                {
                    Panel1.Visible = false;
                    if (Request["LID"] != null)
                    {
                        txtdatefrom.Text = Request["dte"].Replace('.', '/');
                        ddlSite.DataBind();
                        ddlSite.SelectedValue = Request["LID"];
                        txtdatefrom_TextChanged1(sender, e);
                    }

                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
            
           //BindGuardSchedule(txtdatefrom.Text);
        }

        public static int GetWeekOfMonth(DateTime date)
        {
            DateTime beginningOfMonth = new DateTime(date.Year, date.Month, 1);

            while (date.Date.AddDays(1).DayOfWeek != CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek)
                date = date.AddDays(1);

            return (int)Math.Truncate((double)date.Subtract(beginningOfMonth).TotalDays / 7f) + 1;
        } 

        //public static int GetWeekOfMonth(DateTime dt)
        //{
        //    return Iso8601WeekNumber(dt) - Iso8601WeekNumber(dt.AddDays(1 - dt.Day)) + 1;
        //}

        public static int Iso8601WeekNumber(DateTime dt)
        {
            return CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(dt, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        private void BindGuardSchedule(string date)
        {
            DateTime temp;
            if(txtdatefrom.Text!=null)
            {
                if (DateTime.TryParse(date, out temp))
                {
                    //----------change by rakesh---------------
                    DBConnectionHandler1 db = new DBConnectionHandler1();
                    SqlConnection cn = db.getconnection();
                    DataSet ds = new DataSet();
                    SqlDataAdapter adp = new SqlDataAdapter("SELECT Shift, StaffName,StaffID FROM vwDailyDeployment where LocationID='" + ddlSite.SelectedValue + "' and MDate='" + date + "'", cn);
                    adp.Fill(ds, "temp");
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
                    //-----------------------------------------
                    /*lblErr.Visible = false;
                    SqlParameter[] para = new SqlParameter[2];
                    para[0] = new SqlParameter("@LocationID", ddlSite.SelectedValue);
                    para[1] = new SqlParameter("@MDate", date);
                    DataTable dt = dal.executeprocedure("usp_GetDailySchedule", para, false);                
                    DataTable dt1 = SMSCommon.ConvertRowsToColumns(dt, "Shift", "StaffName");               
                    grdSchedule.AutoGenerateColumns = false;

                    for (int i = 0; i <= grdSchedule.Columns.Count; i++)
                    {
                        try
                        {
                            grdSchedule.Columns.RemoveAt(0);
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    try
                    {
                        //grdSchedule.Columns.RemoveAt(0);
                    }
                    catch (Exception ex)
                    {  }

                    foreach (DataColumn dc in dt1.Columns)
                    {


                        TemplateField makeliveCol = new TemplateField();
                        makeliveCol.ItemTemplate = new CreateItemTemplateLinkBtn(System.Guid.NewGuid().ToString().Split('-')[System.Guid.NewGuid().ToString().Split('-').Length - 1], dc.ColumnName, "MakeLive", "return confirm('Are you sure you want to publish this version?')");
                        makeliveCol.HeaderText = dc.ColumnName;
                        makeliveCol.HeaderStyle.Width = Unit.Pixel(180);
                        makeliveCol.ItemStyle.Height = Unit.Pixel(30);
                        grdSchedule.Columns.Add(makeliveCol);
                    }
                    grdSchedule.DataSource = dt1;
                    grdSchedule.DataBind();
                    string script="";
                    foreach (GridViewRow gvr in grdSchedule.Rows)
                    {
                    
                        foreach (TableCell tc in gvr.Cells)
                        {
                            try
                            {
                            
                                LinkButton lnk = ((LinkButton)tc.Controls[0]);
                                lnk.ForeColor = Color.Black;
                                lnk.PostBackUrl = "../ADMIN/Staff_ViewReport.aspx?StaffID=" + lnk.CommandArgument;
                                lnk.Font.Bold = true;
                                lnk.Font.Underline = true;
                                lnk.CssClass = "temp";
                                script += "AttachContextMenu('" + lnk.ClientID + "','" + lnk.CommandArgument + "','" + ddlSite.SelectedValue.ToString() + "')";
                            


                             }
                            catch (Exception ex)
                            { }
                        }
                    }*/
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "CMenu", "$(document).ready( function() {" + script + "});", true);//error find out
                }
            }
        }

        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public static string RemoveStaffFromDuty(string StaffID, string LocationID,string MDate)
        {
            try
            {
                SqlParameter[] para = new SqlParameter[4];
                para[0] = new SqlParameter("LocationID", int.Parse(LocationID));
                para[1] = new SqlParameter("StaffID", StaffID.Replace("===",""));
                para[2] = new SqlParameter("MDate", MDate);
                para[3] = new SqlParameter("AvailabilityFlag", StaffID.Contains("===") ? true : false);
                DataAccessLayer dal = new DataAccessLayer();
                dal.executeprocedure("usp_RemoveGuardFromDailyDuty", para);
                return "Success";
            }
            catch (Exception ex)
            {
                return "Failure";
            }
        }

        protected void ddlSite_SelectedIndexChanged(object sender, EventArgs e)
        {
            //hdnReplacements.Value = ddlSite.SelectedValue;
                if (txtdatefrom.Text != "")
                {
                    //DateTime dt = DateTime.ParseExact(txtdatefrom.Text, "MM/dd/yyyy", null);
                    DateTime dt = Convert.ToDateTime(txtdatefrom.Text);//change by rakesh
                    dsAvailableGuard.SelectParameters["Dt"].DefaultValue = dt.ToString();
                    gvAvailableGuards.DataBind();
                    BindGuardSchedule(txtdatefrom.Text);
                }
                else
                {
                    dsAvailableGuard.SelectParameters["Dt"].DefaultValue = DateTime.Now.ToString();
                    gvAvailableGuards.DataBind();
                    //BindGuardSchedule(DateTime.Now.ToString("MM/dd/yyyy"));
                }
           
            
        }

        protected void ddlShift_SelectedIndexChanged(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            //Changes By:Sandeep Date:18/8/2011
            try
            {
               // ViewState["Shift"] = int.Parse(ddlShift.SelectedValue);
                SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                int s = 0;
                foreach (GridItem gr in gvAvailableGuards.Items)
                {
                    if (((CheckBox)gr.Cells[0].FindControl("chkGuard")).Checked)
                    {
                        lblWarning.Text = String.Empty;
                         s++;
                        break;
                    }
               
                
                }
                if (s > 0)
                {
                    int ShiftID = Convert.ToInt32(ddlShift.SelectedValue);
                   // int ShiftID =Convert.ToInt32(ViewState["Shift"].ToString());
                    
                    DateTime dt = DateTime.ParseExact(txtdatefrom.Text, "MM/dd/yyyy", null);
                    DeployShiftAndRebindAll(ShiftID, dt);

                }
                else
                {
                    MyMasterPage.ShowErrorMessage("You Have Not Selected Security Officer.Please Select..!");

                }
                //  ddlShift.DataBind();

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
            //End Changes
        }




     
        private void DeployShiftAndRebindAll(int ShiftID, DateTime date)
        {
            foreach (GridItem gr in gvAvailableGuards.Items)
            {
                if (((CheckBox)gr.Cells[0].FindControl("chkGuard")).Checked)
                {
                    string StaffID = ((CheckBox)gr.Cells[0].FindControl("chkGuard")).ToolTip;

                    DataSet dschkguard = dal.getdataset("Select WGAID from WeeklyGuardAssign where StaffID='" + StaffID + "'");
                    if (dschkguard.Tables[0].Rows.Count > 0)
                    {
                        //Panel1.Visible = true;
                        fillavaible(ShiftID, date);
                    }
                    else
                    {
                        Panel1.Visible = false;
                        int LocationID = int.Parse(ddlSite.SelectedValue);
                        int WeekID = int.Parse(hdnWeekID.Value);
                        int MonthID = int.Parse(hdnMonthID.Value);
                        SqlParameter[] para = new SqlParameter[6];
                        para[0] = new SqlParameter("@StaffID", StaffID);
                        para[1] = new SqlParameter("@Date", date);
                        para[2] = new SqlParameter("@LocationID", LocationID);
                        para[3] = new SqlParameter("@WeekID", WeekID);
                        para[4] = new SqlParameter("@MonthID", MonthID);
                        para[5] = new SqlParameter("@ShiftID", ShiftID);
                        dal.executeprocedure("usp_DeployDailyStaff", para);
                        gvAvailableGuards.DataBind();
                        if (txtdatefrom.Text != "")
                        {
                            BindGuardSchedule(txtdatefrom.Text);
                        }
                    }
                }
            }
            gvAvailableGuards.DataBind();
            BindGuardSchedule(txtdatefrom.Text);
        }
        private void fillavaible(int ShiftID, DateTime date)
        {
            foreach (GridItem gr in gvAvailableGuards.Items)
            {
                if (((CheckBox)gr.Cells[0].FindControl("chkGuard")).Checked)
                {
                    string StaffID = ((CheckBox)gr.Cells[0].FindControl("chkGuard")).ToolTip;

                    int LocationID = int.Parse(ddlSite.SelectedValue);
                    int WeekID = int.Parse(hdnWeekID.Value);
                    int MonthID = int.Parse(hdnMonthID.Value);
                    SqlParameter[] para = new SqlParameter[6];
                    para[0] = new SqlParameter("@StaffID", StaffID);
                    para[1] = new SqlParameter("@Date", date);
                    para[2] = new SqlParameter("@LocationID", LocationID);
                    para[3] = new SqlParameter("@WeekID", WeekID);
                    para[4] = new SqlParameter("@MonthID", MonthID);
                    para[5] = new SqlParameter("@ShiftID", ShiftID);
                    dal.executeprocedure("usp_DeployDailyStaff", para);
                   
                }
            }
            gvAvailableGuards.DataBind();
            //BindGuardSchedule(txtdatefrom.Text);
        }




        protected void ddlShift0_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //protected void grdSchedule_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    try
        //    {
                
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}

        /*protected void lnkReplacement_Click(object sender, EventArgs e)
        {
            //Label3.Text = "rep";
            try
            {
                foreach (GridViewRow gr in gvAvailableGuards.Rows)
                {                   
                    if (((CheckBox)gr.Cells[0].FindControl("chkGuard")).Checked)
                    {
                        string value = hdnReplacements.Value;

                        string[] wgaid = value.Split(new char[] { ',' });

                        string staffid = wgaid[0].ToString();
                        //string locationid = wgaid[1].ToString();
                        //string date =  wgaid[2].ToString();                       
                        string mdaid = ((CheckBox)gr.Cells[0].FindControl("chkGuard")).ToolTip;

                        SqlParameter[] para = new SqlParameter[5];
                        para[0] = new SqlParameter("@StaffID", staffid);
                        //para[1] = new SqlParameter("@MDate", date);
                        //para[2] = new SqlParameter("@LocationID", locationid);                       
                        para[3] = new SqlParameter("@NewStaffID", mdaid);
                        para[4] = new SqlParameter("AvailabilityFlag", staffid.Contains("===") ? true : false);
                        
                        DataAccessLayer dal = new DataAccessLayer();
                        dal.executeprocedure("usp_ReplaceGuardFromDailyDuty", para);
                    }
                }  
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }*/



        protected void txtdatefrom_TextChanged1(object sender, EventArgs e)
        {
            DateTime temp;
            if (DateTime.TryParse(txtdatefrom.Text, out temp))
            {
                lblErr.Visible = false;
                DateTime dat = DateTime.ParseExact(txtdatefrom.Text, "MM/dd/yyyy", null);
                hdnMonthID.Value = dat.Month.ToString() + dat.Year.ToString();
                hdnWeekID.Value = GetWeekOfMonth(dat).ToString();
                dsAvailableGuard.SelectParameters["Dt"].DefaultValue = dat.ToString();
                gvAvailableGuards.DataBind();
                BindGuardSchedule(txtdatefrom.Text);
            }
            else
            {
                lblErr.Visible = true;
            }
        }

        protected void btnRef_Click(object sender, EventArgs e)
        {

        }

        protected void drpcharactor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnyes_Click(object sender, EventArgs e)
        {
            try
            {
                int ShiftID = int.Parse(ddlShift.SelectedValue);
                DateTime dt = DateTime.ParseExact(txtdatefrom.Text, "MM/dd/yyyy", null);
                fillavaible(ShiftID, dt);
                Panel1.Visible = false;
            }
            catch (Exception ex)
            {
            }
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           
            try
            {
                if (e.CommandName == "replace")
                {
                    //Response.Write(e.CommandName);
                    string staffid = e.CommandArgument.ToString();
                    replace(staffid);
                }
                if (e.CommandName == "profile")
                {
                    string staffid = e.CommandArgument.ToString();
                    ModalPopupAdd.Show();
                    PopulatePageCntrls(staffid);
                   // Response.Redirect("../ADMIN/Staff_ViewReport.aspx?StaffID=" + e.CommandArgument);
                }
                if (e.CommandName == "DeleteRow")
                {
                    
                    
                    string staffid = e.CommandArgument.ToString();
                    DeleteItem(staffid);
                }

            }
            catch (Exception exc)
            {

            }
        }
        public void replace(string id)
        {

            foreach (GridItem gr in gvAvailableGuards.Items)
            {
                if (((CheckBox)gr.Cells[0].FindControl("chkGuard")).Checked)
                {
                   string mdaid = ((CheckBox)gr.Cells[0].FindControl("chkGuard")).ToolTip;
                   Label3.Text = mdaid;
                   string staffid = id;
                   string locationid = ddlSite.SelectedValue;
                   string date = txtdatefrom.Text;
                   DBConnectionHandler1 db = new DBConnectionHandler1();
                   SqlConnection cn = db.getconnection();
                   cn.Open();
                   SqlCommand cmd = new SqlCommand("SELECT Shift FROM vwDailyDeployment where StaffID=@staffid", cn);
                   cmd.Parameters.AddWithValue("@staffid",staffid);
                   SqlDataReader dr = cmd.ExecuteReader();
                   string shift = "";

                   //  if(dr.Read())  change by gsp
                    
                    while(dr.Read())
                   {

                       shift = dr.GetString(0);
                   }
                       //=========================================//
                       dr.Close();
                       dr.Dispose();
                       //=========================================//
                       cn.Close();
                   
                   SqlParameter[] para = new SqlParameter[5];
                   para[0] = new SqlParameter("@StaffID", staffid);
                   para[1] = new SqlParameter("@MDate", date);
                   para[2] = new SqlParameter("@LocationID", locationid);
                   para[3] = new SqlParameter("@NewStaffID", Label3.Text);
                   para[4] = new SqlParameter("@shift",shift);
                   DataAccessLayer dal = new DataAccessLayer();
                   dal.executeprocedure("usp_ReplaceGuardFromDailyDuty1", para);
                   Label3.Text = "";
                   break; 
                }
                
            }
            BindGuardSchedule(txtdatefrom.Text);
            

        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //DeleteItem();
        }
        private void DeleteItem(string argStaffid)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                DBConnectionHandler1 db = new DBConnectionHandler1();
                SqlConnection cn = db.getconnection();
                cn.Open();
                SqlCommand cmd = new SqlCommand("select DGAID FROM vwDailyDeployment where MDate=@date and LocationID=@location and StaffID=@staffid",cn);
                cmd.Parameters.AddWithValue("@date",txtdatefrom.Text);
                cmd.Parameters.AddWithValue("@location",ddlSite.SelectedValue);
                cmd.Parameters.AddWithValue("@staffid", argStaffid);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    long wgaid = dr.GetInt64(0);
                    dal.executesql("delete from DailyGuardAssign where DGAID ="+wgaid);
                    
                }
                //========================//
                dr.Close();
                dr.Dispose();
                //========================//
                cn.Close();
                //Server.Transfer("../ADMIN/CompleteForm.aspx");
                BindGuardSchedule(txtdatefrom.Text);
                
                    
                
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (e.NewPageIndex >= 0)
            {
                GridView1.PageIndex = e.NewPageIndex;
                BindGuardSchedule(txtdatefrom.Text);
            }
        }
        protected void chkSelectAll_CheckedChanged
                               (object sender, EventArgs e)
        {
            //CheckBox chkAll =
            //   (CheckBox)gvAvailableGuards.HeaderRow.FindControl("chkAll");

            CheckBox chkAll = sender as CheckBox;
           
            if (chkAll.Checked == true)
            {
                foreach (GridItem gvRow in gvAvailableGuards.Items)
                {
                    CheckBox chkSel =
                         (CheckBox)gvRow.FindControl("chkGuard");
                    chkSel.Checked = true;
                    //TextBox txtname = (TextBox)gvRow.FindControl("txtName");
                    //TextBox txtlocation = (TextBox)gvRow.FindControl("txtLocation");
                    //txtname.ReadOnly = false;
                    //txtlocation.ReadOnly = false;
                    //txtname.ForeColor = System.Drawing.Color.Black;
                    //txtlocation.ForeColor = System.Drawing.Color.Black;
                }
            }
            else
            {
                foreach (GridItem gvRow in gvAvailableGuards.Items)
                {
                    CheckBox chkSel = (CheckBox)gvRow.FindControl("chkGuard");
                    chkSel.Checked = false;
                    //TextBox txtname = (TextBox)gvRow.FindControl("txtName");
                    //TextBox txtlocation = (TextBox)gvRow.FindControl("txtLocation");
                   // txtname.ReadOnly = true;
                    //txtlocation.ReadOnly = true;
                    //txtname.ForeColor = System.Drawing.Color.Blue;
                    //txtlocation.ForeColor = System.Drawing.Color.Blue;
                }
            }
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



    }
}