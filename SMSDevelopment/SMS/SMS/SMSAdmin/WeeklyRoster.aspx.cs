using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMS.Services.DataService;
using System.Data;
using System.Data.SqlClient;
using SMS.SMSCommons;
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
    public partial class WeeklyRoster : System.Web.UI.Page
    {
      
           
       // DataAccessLayer dal = new DataAccessLayer();
        String iBTID = string.Empty;
        DataAccessLayer dal = new DataAccessLayer();
        private DataControlRowType templateType;
        private string columnName;

        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (!IsPostBack)
                {
                    Panel1.Visible = false;
                    BindShiftGrid();
                }
                if (ddlWeek.SelectedValue != "0" && ddlWeek.SelectedValue != "")
                {
                    if (hdnHash.Value != "")
                    {
                        SqlParameter[] para = new SqlParameter[1];
                        para[0] = new SqlParameter("@WGAID", long.Parse(hdnHash.Value));
                        dal.executeprocedure("usp_UnDeployWeeklyStaff", para);
                        gvAvailableGuards.DataBind();
                        hdnHash.Value = "";
                    }
                    //BindShiftGrid();
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
            if (!IsPostBack)
            {
               Session["script"] = "";
                
            }
        }

        protected void lnkReplacement_Click(object sender, EventArgs e)
        {
            try
            {
                foreach ( GridItem  gr in gvAvailableGuards.Items)
                {
                    if (((CheckBox)gr.Cells[0].FindControl("chkGuard")).Checked)
                    {
                        //string value = hdnReplacements.Value;
                        string value = Label4.Text;
                        string[] wgaid = value.Split(' ');

                        string staffid = wgaid[0].ToString();
                        string locationid = wgaid[1].ToString();
                        string date = wgaid[2].ToString();
                        string mdaid = ((CheckBox)gr.Cells[0].FindControl("chkGuard")).ToolTip;

                        SqlParameter[] para = new SqlParameter[4];
                        para[0] = new SqlParameter("@StaffID", staffid);
                        para[1] = new SqlParameter("@MDate", date);
                        para[2] = new SqlParameter("@LocationID", locationid);
                        para[3] = new SqlParameter("@NewStaffID", mdaid);
                        // para[4] = new SqlParameter("AvailabilityFlag", staffid.Contains("===") ? true : false);

                        DataAccessLayer dal = new DataAccessLayer();
                        dal.executeprocedure("usp_ReplaceGuardFromWeeklyDuty", para);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BindShiftGrid()
        {
            grdShiftStaff.DataSourceID = "";
            grdShiftStaff.DataSourceID = "dsShiftStaff";
            grdShiftStaff.DataBind();
        }

        protected void txtdatefrom_TextChanged(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                BindNewData();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private void BindNewData()
        {
            DateTime temp;
            if (DateTime.TryParse(txtdatefrom.Text, out temp))
            {
                lblErr.Visible = false;
                DateTime dt = DateTime.ParseExact(txtdatefrom.Text, "MM/dd/yyyy", null);
                hdnMonthID.Value = dt.Month.ToString() + dt.Year.ToString();
                gvAvailableGuards.DataBind();
                ddlWeek.DataBind();
                ddlShift.DataBind();
                BindWeek(hdnMonthID.Value,Convert.ToInt32(ddlSite.SelectedValue));
            }
            else
            {
                lblErr.Visible = true;
            }
        }

        public void BindWeek(string monthid,int locid)
        {
            DataTable dt = dal.getdata("SELECT '- Select -' AS WeekName, 0 AS WeekID UNION SELECT distinct WeekMaster.WeekName, vwWeeklyDeployment.WeekID FROM vwWeeklyDeployment INNER JOIN WeekMaster ON vwWeeklyDeployment.WeekID = WeekMaster.WeekID WHERE (vwWeeklyDeployment.MonthID = '"+monthid+"') AND (vwWeeklyDeployment.LocationID = '"+locid+"')");
            if (dt.Rows.Count > 0)
            {
                ddlWeek.DataTextField = "WeekName";
                ddlWeek.DataValueField = "WeekID";
                ddlWeek.DataSource = dt;
                ddlWeek.DataBind();
            }
        
        }

        private DataTable CheckMrs()
        {
            //log4net.ILog logger = log4net.LogManager.GetLogger("File");
            //try
            //{
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@LocationID", ddlSite.SelectedValue);
            para[1] = new SqlParameter("@MonthID", hdnMonthID.Value);
            return dal.executeprocedure("usp_CheckMonthlyRoster", para, true);
            //}
            //catch (Exception ex)
            //{
            //    logger.Info(ex.Message);
            //}
        }

        protected void ddlShift_SelectedIndexChanged(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            //Changes By:Sandeep Date:18/8/2011
            try
            {
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
                    //else
                    //{


                    //    //lblWarning.Text = "You Have Not Selected Security Officer.Please Select!";
                    }

                    if (s > 0)
                    {
                        int ShiftID = int.Parse(ddlShift.SelectedValue);
                        //DateTime dt = DateTime.ParseExact(txtDeployDate.Text, "MM/dd/yyyy", null);
                        DateTime dt = Convert.ToDateTime(txtDeployDate.Text);//change by rakesh
                        DeployShiftAndRebindAll(ShiftID, dt);
                    }
                    else
                    {
                        MyMasterPage.ShowErrorMessage("You Have Not Selected Security Officer.Please Select..!");
                    }
               // }

              // ddlShift.DataBind();
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

                    DataSet dschkguard = dal.getdataset("Select WGAID,WDRID from WeeklyGuardAssign where StaffID='" + StaffID + "'");
                    if (dschkguard.Tables[0].Rows.Count > 0)
                    {
                        checkguard.Text += StaffID + " ";
                        wdrid.Text += dschkguard.Tables[0].Rows[0][1] + " ";
                        Panel1.Visible = true;
                        //fillavaible(ShiftID, date);
                    }
                    else
                    {
                        Panel1.Visible = false;
                        int LocationID = int.Parse(ddlSite.SelectedValue);
                        int WeekID = int.Parse(ddlWeek.SelectedValue);
                        int MonthID = int.Parse(hdnMonthID.Value);
                        SqlParameter[] para = new SqlParameter[6];
                        para[0] = new SqlParameter("@StaffID", StaffID);
                        para[1] = new SqlParameter("@Date", date);
                        para[2] = new SqlParameter("@LocationID", LocationID);
                        para[3] = new SqlParameter("@WeekID", WeekID);
                        para[4] = new SqlParameter("@MonthID", MonthID);
                        para[5] = new SqlParameter("@ShiftID", ShiftID);
                        dal.executeprocedure("usp_DeployWeeklyStaff", para);
                        //gvAvailableGuards.DataBind();
                        //BindShiftGrid();
                    }
                }
            }
            gvAvailableGuards.DataBind();
            BindShiftGrid();
        }


        private void fillavaible(int ShiftID, string date)
        {
            SMS.Services.DALUtilities.DBConnectionHandler1 db = new Services.DALUtilities.DBConnectionHandler1();
            SqlConnection cn = db.getconnection();
            try
            {
                /*foreach (GridViewRow gr in gvAvailableGuards.Rows)
                {
                    if (((CheckBox)gr.Cells[0].FindControl("chkGuard")).Checked)
                    {
                        string StaffID = ((CheckBox)gr.Cells[0].FindControl("chkGuard")).ToolTip;

                        int LocationID = int.Parse(ddlSite.SelectedValue);
                        int WeekID = int.Parse(ddlWeek.SelectedValue);
                        int MonthID = int.Parse(hdnMonthID.Value);
                        SqlParameter[] para = new SqlParameter[6];
                        para[0] = new SqlParameter("@StaffID", StaffID);
                        para[1] = new SqlParameter("@Date", date);
                        para[2] = new SqlParameter("@LocationID", LocationID);
                        para[3] = new SqlParameter("@WeekID", WeekID);
                        para[4] = new SqlParameter("@MonthID", MonthID);
                        para[5] = new SqlParameter("@ShiftID", ShiftID);
                        dal.executeprocedure("usp_DeployWeeklyStaff", para);

                    }
                }
                gvAvailableGuards.DataBind();
                BindShiftGrid();*/

                if (cn.State == ConnectionState.Closed) { cn.Open(); }
                else { cn.Close(); }
                string[] arr = checkguard.Text.Split(' ');
                string[] arr1 = wdrid.Text.Split(' ');
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    SqlCommand _cmd = new SqlCommand("select LocationID,WDRID from vwWeeklyDeployment where StaffID=@staffid and MDate=@mdate", cn);
                    //_cmd.Parameters.Add("@wdrid", arr1[i].ToString());
                    _cmd.Parameters.Add("@staffid", arr[i].ToString());
                    _cmd.Parameters.Add("@mdate", date);
                    SqlDataReader dr = _cmd.ExecuteReader();
                    int loc = 0; string loc1 = "";
                    long wdrid2 = 0; string wdrid3 = "";
                    if (dr.Read())
                    {
                        loc = dr.GetInt32(0);
                        wdrid2 = dr.GetInt64(1);
                        loc1 = Convert.ToString(loc);
                        wdrid3 = Convert.ToString(wdrid2);
                        dr.Close();
                        dr.Dispose();
                    }
                    dr.Close();
                    dr.Dispose();
                    if (loc1 != "") { Delete(date, arr[i].ToString(), loc1.ToString(), wdrid3); }


                }
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    int WeekID = int.Parse(ddlWeek.SelectedValue);
                    int MonthID = int.Parse(hdnMonthID.Value);
                    SqlParameter[] para = new SqlParameter[6];
                    para[0] = new SqlParameter("@StaffID", arr[i].ToString());
                    para[1] = new SqlParameter("@Date", date);
                    para[2] = new SqlParameter("@LocationID", ddlSite.SelectedValue.Trim());
                    para[3] = new SqlParameter("@WeekID", WeekID);
                    para[4] = new SqlParameter("@MonthID", MonthID);
                    para[5] = new SqlParameter("@ShiftID", ShiftID);
                    dal.executeprocedure("usp_DeployWeeklyStaff", para);
                }
                gvAvailableGuards.DataBind();
                BindShiftGrid();
                cn.Close();
                checkguard.Text = "";
                wdrid.Text = "";
            }
            catch (Exception ex)
            {
                cn.Close();
            }
        }

        protected void btnyes_Click(object sender, EventArgs e)
        {
            try
            {
                int ShiftID = int.Parse(ddlShift.SelectedValue);
                string dt = txtDeployDate.Text.Trim();
                //DateTime dt = DateTime.ParseExact(txtDeployDate.Text, "MM/dd/yyyy", null);
                fillavaible(ShiftID, dt);
                Panel1.Visible = false;
            }
            catch (Exception ex)
            {
            }
        }
        protected void chkSelectAll_CheckedChanged
                               (object sender, EventArgs e)
        {
            //   CheckBox chkAll =
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
        protected void btnNo_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
        }


        public void BindGrid(GridView grdStaff, string MRID)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                SqlParameter[] para = new SqlParameter[1];
                para[0] = new SqlParameter("@MRID", long.Parse(MRID));

                Session["Mrid"] = para[0].Value;
                DataTable dt = dal.executeprocedure("usp_GetMonthlyAssignedStaff", para, true);
                grdStaff.DataSource = dt;
                grdStaff.DataBind();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void dlShiftAssignment_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            GridView grdStaff = (GridView)e.Item.FindControl("grdShiftStaff");
            string MRID = ((HiddenField)e.Item.FindControl("hdnLocID")).Value;
            BindGrid(grdStaff, MRID);
        }

        protected void btnGetData_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                BindNewData();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void grdShiftStaff_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow gr = e.Row;
                DataRowView dr = (DataRowView)gr.DataItem;
                if (dr != null)
                {
                    if (dr[2].ToString() == "0")
                    {
                        ddlShift.Enabled = true;
                        txtDeployDate.Enabled = true;
                    }
                    else
                    {

                    }
                    string MDate = dr[0].ToString();
                    GridView gv = ((GridView)gr.Cells[1].FindControl("grdSchedule"));
                    SqlParameter[] para = new SqlParameter[4];
                    para[0] = new SqlParameter("@LocationID", ddlSite.SelectedValue);
                    para[1] = new SqlParameter("@WeekID", ddlWeek.SelectedValue);
                    para[2] = new SqlParameter("@MonthID", hdnMonthID.Value);
                    para[3] = new SqlParameter("@MDate", MDate);
                    DataTable dt = dal.executeprocedure("usp_GetWeeklySchedule", para, false);
                    gv.DataSource = dt;
                    gv.DataBind();
                    /*DataTable dt1 = SMSCommon.ConvertRowsToColumns(dt,"Shift","StaffName");
                    gv.AutoGenerateColumns = false;
                    for (int i = 0; i <= gv.Columns.Count; i++)
                    {
                        try
                        {
                            gv.Columns.RemoveAt(0);
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    try
                    {
                        gv.Columns.RemoveAt(0);
                    }
                    catch (Exception ex)
                    { }

                    foreach (DataColumn dc in dt1.Columns)
                    {
                        //TemplateField makeliveCol = new TemplateField();
                        //makeliveCol.ItemTemplate = new CreateItemTemplateLinkBtn(System.Guid.NewGuid().ToString().Split('-')[System.Guid.NewGuid().ToString().Split('-').Length - 1], dc.ColumnName, "Select", "return confirm('Are you sure you want to publish this version?')");
                        //makeliveCol.HeaderText = dc.ColumnName;
                        //makeliveCol.HeaderStyle.Width = Unit.Pixel(180);
                        //makeliveCol.ItemStyle.Height = Unit.Pixel(30);
                        //gv.Columns.Add(makeliveCol);
                        gv.DataSource = dt1;
                        gv.DataBind();
                        
                    }
                    gv.DataSource = dt1;
                    gv.DataBind();
                    foreach (GridViewRow gvr in gv.Rows)
                    {
                        foreach (TableCell tc in gvr.Cells)
                        {
                            try
                            {
                                LinkButton lnk = ((LinkButton)tc.Controls[0]);
                                Label4.Text = lnk.ToolTip + " " + ddlSite.SelectedValue.ToString() + " " + lnk.CommandArgument;
                                //script += "AttachContextMenu('"+lnk.ClientID+"','" + lnk.ToolTip + "','" + ddlSite.SelectedValue.ToString() + "','" + lnk.CommandArgument + "');";
                            }
                            catch (Exception ex)
                            { }
                        }
                    }*/
                }
            }
        }

        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public static string RemoveStaffFromDuty(string StaffID, string LocationID, string MDate)
        {
            try
            {
                SqlParameter[] para = new SqlParameter[3];
                para[0] = new SqlParameter("LocationID", int.Parse(LocationID));
                para[1] = new SqlParameter("StaffID", StaffID.Replace("===", ""));
                para[2] = new SqlParameter("MDate", MDate);
                DataAccessLayer dal = new DataAccessLayer();
                dal.executeprocedure("usp_RemoveGuardFromWeeklyDuty", para);
                return "Success";
            }
            catch (Exception ex)
            {
                return "Failure";
            }
        }

        protected void btnRef_Click(object sender, EventArgs e)
        {

        }

        protected void drpcharactor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
            }
        }

        protected void ddlShift0_SelectedIndexChanged(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                //int ShiftID = int.Parse(ddlShift0.SelectedValue);
                //DateTime dt = DateTime.ParseExact(txtDeployDate1.Text, "MM/dd/yyyy", null);
                //DeployShiftAndRebindAll(ShiftID, dt);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

        }

        //protected void grdShiftStaff_RowCreated(object sender, GridViewRowEventArgs e)
        //{

        //}
        protected void grdShiftStaff_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string commandname = e.CommandName;
        }
        protected void grdSchedule_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string staffid = e.CommandArgument.ToString();
            string[] staffid1 = staffid.Split(' ');
            string mdate = staffid1[0].ToString();
            string wdrid = staffid1[1].ToString();
            string staffidentification = staffid1[2].ToString();
            if (e.CommandName == "replace")
            {

                replace(mdate, staffidentification, ddlSite.SelectedValue.ToString(), wdrid);
            }
            if (e.CommandName == "DeleteRow")
            {
                Delete(mdate, staffidentification, ddlSite.SelectedValue.ToString(), wdrid);
            }
            if (e.CommandName == "profile")
            {
                ModalPopupAdd.Show();
                PopulatePageCntrls(staffidentification);
              //  Response.Redirect("../ADMIN/Staff_ViewReport.aspx?StaffID=" + staffidentification);
            }
        }
        public void replace(string str1, string str2, string str3, string str4)
        {
            try
            {
                foreach (GridItem gr in gvAvailableGuards.Items)
                {
                    if (((CheckBox)gr.Cells[0].FindControl("chkGuard")).Checked)
                    {
                        string mdaid = ((CheckBox)gr.Cells[0].FindControl("chkGuard")).ToolTip;

                        SqlParameter[] para = new SqlParameter[5];
                        para[0] = new SqlParameter("@StaffID", str2);
                        para[1] = new SqlParameter("@MDate", str1);
                        para[2] = new SqlParameter("@LocationID", str3);
                        para[3] = new SqlParameter("@NewStaffID", mdaid);
                        para[4] = new SqlParameter("@wdrid", str4);
                        DataAccessLayer dal = new DataAccessLayer();
                        dal.executeprocedure("usp_ReplaceGuardFromWeeklyDuty", para);

                    }
                }
                BindShiftGrid();
                gvAvailableGuards.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(string str1, string str2, string str3, string str4)
        {
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@StaffID", str2);
            para[1] = new SqlParameter("@MDate", str1);
            para[2] = new SqlParameter("@LocationID", str3);
            para[3] = new SqlParameter("@wdrid", str4);
            DataAccessLayer dal = new DataAccessLayer();
            dal.executeprocedure("usp_RemoveGuardFromWeeklyDuty", para);
            BindShiftGrid();
            gvAvailableGuards.DataBind();
        }
        protected void grdSchedule_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //DeleteItem();
        }
        protected void ddlWeek_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdShiftStaff_DataBound(object sender, EventArgs e)
        {
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "CMenu", "$(document).ready( function() {" + Session["script"].ToString() + "});", true);//error raise on this line
            Session["script"] = "";
        }

        protected void grdShiftStaff_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
           

           

           if (e.NewPageIndex >= 0)
           {

               grdShiftStaff.PageIndex = e.NewPageIndex;
               BindShiftGrid();
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

    public class CreateItemTemplateLinkBtn : ITemplate
    {
        string strColumnText;
        string strLinkButtonName;
        string strCommandName;
        string strClientClick;
        DataAccessLayer dal = new DataAccessLayer();

        public CreateItemTemplateLinkBtn(string LinkButtonName, string ColText, string CommandName, string ClientClick)
        {
            this.strColumnText = ColText;
            this.strLinkButtonName = LinkButtonName;
            this.strCommandName = CommandName;
            this.strClientClick = ClientClick;
        }

        public void InstantiateIn(Control objContainer)
        {
            LinkButton lnkbtn = new LinkButton();
            lnkbtn.CommandName = strCommandName;
            lnkbtn.DataBinding += new EventHandler(lnkbtn_DataBinding);
            objContainer.Controls.Add(lnkbtn);
        }

        private void lnkbtn_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                HttpContext.Current.Response.Write("sdfsdf");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private void lnkbtn_DataBinding(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkbtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkbtn.NamingContainer;
                lnkbtn.ID = strLinkButtonName;
                string text = DataBinder.Eval(row.DataItem, strColumnText).ToString();
                string originaltext = text;
                string WGAID = "";
                string StaffID = "";
                if (text != "")
                {
                    string[] values = originaltext.Split(new string[] { "||" }, StringSplitOptions.None);
                    text = values[0];
                    WGAID = values[1];
                    StaffID = values[2];
                }
                GridViewRow gr;
                DataRowView dr;
                string date = "";
                try
                {
                    gr = (GridViewRow)row.Parent.Parent.Parent.Parent;
                    dr = (DataRowView)gr.DataItem;
                    date = dr[0].ToString();
                    lnkbtn.PostBackUrl = "WeeklyRoster.aspx";
                    lnkbtn.CommandArgument = date;
                }
                catch (Exception ex)
                {
                    gr = (GridViewRow)row;
                    dr = (DataRowView)gr.DataItem;
                    date = ((TextBox)gr.Parent.Parent.Parent.FindControl("txtdatefrom")).Text;
                    if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("dailyroster"))
                        lnkbtn.PostBackUrl = "DailyRoster.aspx";
                }
                try
                {
                    lnkbtn.Enabled = true;
                    if (lnkbtn.CommandArgument == "")
                        lnkbtn.CommandArgument = StaffID;
                    if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("dashboard.aspx"))
                    {
                        date = DateTime.Now.ToString("MM/dd/yyyy");
                        lnkbtn.PostBackUrl = HttpContext.Current.Request.Url.Segments[HttpContext.Current.Request.Url.Segments.Length - 1];
                    }
                    DateTime dte = DateTime.ParseExact(date, "MM/dd/yyyy", null);
                    SqlParameter[] para = new SqlParameter[2];
                    para[0] = new SqlParameter("@StaffID", StaffID);
                    para[1] = new SqlParameter("@Date", dte);
                    DataTable dt = dal.executeprocedure("usp_IsStaffOnLeave", para, false);
                    lnkbtn.ToolTip = StaffID;
                    lnkbtn.CommandName = strCommandName;
                    if (dt.Rows.Count > 0)
                    {
                        if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("roster.aspx"))
                        {
                            if (dr[2].ToString() != "0")
                            {
                                lnkbtn.Enabled = false;
                            }
                            else
                            {
                                lnkbtn.Enabled = true;
                            }
                        }
                        lnkbtn.Font.Bold = true;
                        lnkbtn.ForeColor = System.Drawing.Color.Red;
                        lnkbtn.ToolTip = "On Leave for " + date;
                        lnkbtn.CommandName = "Delete";
                        lnkbtn.OnClientClick = "$('[id$=hdnHash]').val(" + WGAID + "); return confirm('This person is on leave on " + date + ".Do you want to remove " + text + " from Schedule ?')";
                    }
                    lnkbtn.Click += new EventHandler(lnkbtn_Click);
                    lnkbtn.Text = text;
                    lnkbtn.CausesValidation = false;
                }
                catch (Exception ex)
                {

                }
            }
            catch (Exception ex)
            {
            }
            
        }







      
     
    }
}
