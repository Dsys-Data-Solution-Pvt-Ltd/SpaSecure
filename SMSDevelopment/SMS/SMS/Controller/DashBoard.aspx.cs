using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using SMS.SMSCommons;
using SMS.Services.DataService;
using SMS.SuperVisor;
using System.Drawing;
using SMS.Web;

namespace SMS.Controller
{
    public partial class DashBoard : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                grdShiftStaff.DataBind();
                if (!IsPostBack)
                {
                    tmrUpdateSchedule.Enabled = false;
                }
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

                GridView gpc = ((GridView)gr.Cells[1].FindControl("grdCurrCheckIn"));
                BindSchedule(gpc, dr, "GetCheckedInGuards", false, true, false);

                GridView gv = ((GridView)gr.Cells[1].FindControl("grdCurrCheckOuts"));
                BindSchedule(gv, dr, "GetCheckedOutGuards", true, true, true);
            }
        }

        public void GetRemarks(GridViewRow gr, DataRowView dr, string tbid, string lnkid, string buttonid, string shiftid, string columnname)
        {
            try
            {
                TextBox tb = ((TextBox)gr.Cells[1].FindControl(tbid));
                LinkButton lnk = ((LinkButton)gr.Cells[1].FindControl(lnkid));
                Button btn = ((Button)gr.Cells[1].FindControl(buttonid));
                string MDate = "";
                if (columnname != "")
                {
                    MDate = columnname.Split('-')[0].Trim().Split(' ')[0];
                }
                DataTable dt = dal.getdata("Select Remarks,WDRID from vwRosterGeneral where MDate='" + MDate + "' and LocationID=" + dr[0].ToString() + " and shift_ID=" + shiftid);
                tb.Text = dt.Rows[0][0].ToString();
                lnk.OnClientClick = "return UpdateRemarks('" + tb.ClientID + "','" + dt.Rows[0][1].ToString() + "','" + tbid + "');";
                btn.OnClientClick = "return SendReport('" + dr[0].ToString() + "','" + dr[1].ToString() + "','" + columnname + "','" + shiftid + "','" + buttonid + "','" + dt.Rows[0][1].ToString() + "','" + MDate + "','" + tb.ClientID + "');";
            }
            catch (Exception ex)
            {

            }
        }

        private void BindSchedule(GridView gv, DataRowView dr, string spname, bool IsCheckinStatusNeeded, bool IsCheckOutStatusNeeded, bool IsRemovalNeeded)
        {
            string shiftid = "";
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@LocationID", int.Parse(dr[0].ToString()));
          // para[1] = new SqlParameter("@CurrDate", DateTime.Now);
            DataTable dt = dal.executeprocedure(spname, para, false);
            gv.ShowHeader = false;
            gv.DataSource = dt;
            gv.DataBind();
            gv.ShowHeader = false;
        }

        private void GetGuardCheckoutStatus(LinkButton lnk, DateTime[] dtarr, string StaffID, string LocationID)
        {
            DataTable dtchkin = CheckUserCheckedInStatus(StaffID, dtarr[0], dtarr[1], LocationID);
            if (!dtchkin.Rows[0][1].ToString().ToLower().Contains("not checked in yet"))
            {
                DataTable dtr = CheckUserCheckedOutStatus(StaffID, dtarr[0], dtarr[1], LocationID);
                if (dtr.Rows[0][0].ToString() == "Green")
                {
                    lnk.ForeColor = Color.LimeGreen;
                    lnk.ToolTip = "Checked Out At " + DateTime.Parse(dtr.Rows[0][1].ToString()).ToString("MM/dd/yyyy H:n");
                }
                else if (dtr.Rows[0][0].ToString() == "Orange")
                {
                    lnk.ForeColor = Color.Orange;
                    lnk.ToolTip = "Checked Out Late By : " + DateTime.Now.Subtract(dtarr[0]).TotalMinutes.ToString() + "minutes. Checked In At : " + DateTime.Parse(dtr.Rows[0][1].ToString()).ToString("MM/dd/yyyy HH:mm");
                }
                else
                {
                    TimeSpan ts = DateTime.Now.Subtract(dtarr[0]);
                    if (ts.TotalMinutes > 30)
                    {
                        lnk.ForeColor = Color.Maroon;
                        lnk.ToolTip = dtr.Rows[0][1].ToString();
                    }
                    else
                    {
                        lnk.ForeColor = Color.Black;
                        lnk.ToolTip = "Expected To Checkout";
                    }
                }
            }
        }

        public static DataTable CheckUserCheckedOutStatus(string StaffID, DateTime fromTime, DateTime toTime, string LocationID)
        {
            DataAccessLayer dal = new DataAccessLayer();
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("StaffID", StaffID);
            para[1] = new SqlParameter("FromTime", fromTime);
            para[2] = new SqlParameter("ToTime", toTime);
            para[3] = new SqlParameter("LocationID", int.Parse(LocationID));
            return dal.executeprocedure("usp_CheckUserCheckedOutStatus", para, true);
        }

        public void GetGuardCheckInStatus(LinkButton lnk, DateTime[] dtarr, string StaffID, string MDate, string LocationID)
        {
            DataTable dtr = CheckUserCheckedInStatus(StaffID, dtarr[0], dtarr[1], LocationID);
            if (dtr.Rows[0][0].ToString() == "Green")
            {
                lnk.ForeColor = Color.LimeGreen;
                lnk.ToolTip = "Checked In At " + DateTime.Parse(dtr.Rows[0][1].ToString()).ToString("MM/dd/yyyy HH:mm:ss tt");
            }
            else if (dtr.Rows[0][0].ToString() == "Orange")
            {
                lnk.ForeColor = Color.Orange;
                lnk.ToolTip = "Late By : " + decimal.Ceiling(decimal.Parse(DateTime.Parse(dtr.Rows[0][1].ToString()).Subtract(dtarr[0]).TotalMinutes.ToString())).ToString() + " minutes. Checked In At : " + DateTime.Parse(dtr.Rows[0][1].ToString()).ToString("MM/dd/yyyy HH:mm:ss tt");
            }
            else
            {
                TimeSpan ts = DateTime.Now.Subtract(dtarr[0]);
                if (ts.TotalMinutes > 30)
                {
                    lnk.ForeColor = Color.Maroon;
                    lnk.ToolTip = dtr.Rows[0][1].ToString();
                }
                else
                {
                    lnk.ForeColor = Color.Black;
                    lnk.ToolTip = "Expected To Come";
                }
            }
        }

        public static DateTime[] GetFromToFromColumnName(string FromTime, string ToTime)
        {
            DateTime FromDateTime;
            DateTime ToDateTime;
            //  FromDateTime = DateTime.ParseExact(FromTime, "MM/dd/yyyy h:mm tt", null);
            //ToDateTime = DateTime.ParseExact(ToTime, "MM/dd/yyyy h:mm tt", null);
            FromDateTime = Convert.ToDateTime(FromTime);
            ToDateTime = Convert.ToDateTime(ToTime);
            DateTime[] dtarr = new DateTime[2];
            dtarr[0] = FromDateTime;
            dtarr[1] = ToDateTime;
            return dtarr;
        }

        public static DataTable CheckUserCheckedInStatus(string StaffID, DateTime fromTime, DateTime toTime, string LocationID)
        {
            DataAccessLayer dal = new DataAccessLayer();
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("StaffID", StaffID);
            para[1] = new SqlParameter("FromTime", fromTime);
            para[2] = new SqlParameter("ToTime", toTime);
            para[3] = new SqlParameter("LocationID", int.Parse(LocationID));
            return dal.executeprocedure("usp_CheckUserCheckedInStatus", para, true);
        }

        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public static string RemoveStaffFromDuty(string StaffID, string LocationID)
        {
            try
            {
                SqlParameter[] para = new SqlParameter[4];
                para[0] = new SqlParameter("LocationID", int.Parse(LocationID));
                para[1] = new SqlParameter("StaffID", StaffID);
                para[2] = new SqlParameter("MDate", DateTime.Now.ToString("MM/dd/yyyy"));
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

        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public static string UpdateShiftRemarks(string Remark, string WDRID, string ColumnName)
        {
            try
            {
                DataAccessLayer dal = new DataAccessLayer();
                if (ColumnName.ToLower().Contains("past"))
                {
                    dal.executesql("UPDATE WeekDayRoster set Remarks='" + Remark + "' where WDRID=" + WDRID + "");
                }
                if (ColumnName.ToLower().Contains("current"))
                {
                    dal.executesql("UPDATE WeekDayRoster set Remarks='" + Remark + "' where WDRID=" + WDRID + "");
                }
                if (ColumnName.ToLower().Contains("next"))
                {
                    dal.executesql("UPDATE WeekDayRoster set Remarks='" + Remark + "' where WDRID=" + WDRID + "");
                }
                return "Success";
            }
            catch (Exception ex)
            {
                return "Failure";
            }
        }

        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public static string SendReportMails(string LocationID, string LocationName, string ShiftName, string ShiftID, string Identifier, string WDRID, string MDate, string Remark)
        {
            try
            {
                string spname = "";
                DataAccessLayer dal = new DataAccessLayer();
                if (Identifier.ToLower().Contains("past"))
                {
                    spname = "GetPastShift";
                    //dal.executesql("UPDATE WeekDayRoster set Remarks='" + Remark + "' where WDRID=" + WDRID + "");
                }
                if (Identifier.ToLower().Contains("current"))
                {
                    spname = "GetCurrentShift";
                    //dal.executesql("UPDATE WeekDayRoster set Remarks='" + Remark + "' where WDRID=" + WDRID + "");
                }
                if (Identifier.ToLower().Contains("next"))
                {
                    spname = "GetCurrentShift";
                    //dal.executesql("UPDATE WeekDayRoster set Remarks='" + Remark + "' where WDRID=" + WDRID + "");
                }
                string shiftid = "";
                SqlParameter[] para = new SqlParameter[2];
                para[0] = new SqlParameter("@LocationID", int.Parse(LocationID));
                para[1] = new SqlParameter("@CurrDate", DateTime.Now);
                DataTable dt = dal.executeprocedure(spname, para, false);
                string MailTitle = "<table width='100%'><tr><td align='left'>Shift Report for Shift " + ShiftName + " on " + LocationName;
                string MailContent = "<b>Shift Timings : </b>" + ShiftName + "<br />";
                MailContent += "<b>Final Shift Deployment</b><br />";
                MailContent += "<table border='1' style='width:100%;border-width:1px;border-collapse:collapse;'>";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    MailContent += "<tr><td>" + dt.Rows[i][0].ToString().Split(new String[] { "||" }, StringSplitOptions.None)[0] + "</td></tr>";
                }
                MailContent += "</table><br/><br/>";
                MailContent += "<b>Checkin Status<b><br/>";
                MailContent += "<table border='1' style='width:100%;border-width:1px;border-collapse:collapse;'>";
                string FromTime, ToTime = "";
                FromTime = ShiftName.Split('-')[0].Trim();
                ToTime = ShiftName.Split('-')[1].Trim();
                DateTime[] dtarr = GetFromToFromColumnName(FromTime, ToTime);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    MailContent += "<tr><td width='20%'>" + dt.Rows[i][0].ToString().Split(new String[] { "||" }, StringSplitOptions.None)[0] + "</td><td>";
                    DataTable dtr = CheckUserCheckedInStatus(dt.Rows[i][0].ToString().Split(new String[] { "||" }, StringSplitOptions.None)[2], dtarr[0], dtarr[1], LocationID);
                    if (dtr.Rows[0][0].ToString() == "Green")
                    {
                        MailContent += "<font style='font-color:green'>On Time : </font>Checked In At " + DateTime.Parse(dtr.Rows[0][1].ToString()).ToString("MM/dd/yyyy HH:mm:ss tt");
                    }
                    else if (dtr.Rows[0][0].ToString() == "Orange")
                    {

                        MailContent += "<font style='font-color:orange'>Late By : </font>" + decimal.Ceiling(decimal.Parse(DateTime.Parse(dtr.Rows[0][1].ToString()).Subtract(dtarr[0]).TotalMinutes.ToString())).ToString() + " minutes. Checked In At : " + DateTime.Parse(dtr.Rows[0][1].ToString()).ToString("MM/dd/yyyy HH:mm:ss tt");
                    }
                    else
                    {
                        TimeSpan ts = DateTime.Now.Subtract(dtarr[0]);
                        if (ts.TotalMinutes > 30)
                        {
                            MailContent += "<font style='font-color:maroon'>Not Checked In Yet</font>";
                        }
                        else
                        {
                            MailContent += "<font style='font-color:black'>Expected To Come</font>";
                        }
                    }
                    MailContent += "</td></tr>";
                }
                MailContent += "</table><br/><br/>";

                MailContent += "<b>Check-Out Status<b><br/>";
                MailContent += "<table border='1' style='width:100%;border-width:1px;border-collapse:collapse;'>";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    MailContent += "<tr><td width='20%'>" + dt.Rows[i][0].ToString().Split(new String[] { "||" }, StringSplitOptions.None)[0] + "</td><td>";
                    DataTable dtr = CheckUserCheckedOutStatus(dt.Rows[i][0].ToString().Split(new String[] { "||" }, StringSplitOptions.None)[2], dtarr[0], dtarr[1], LocationID);
                    if (dtr.Rows[0][0].ToString() == "Green")
                    {
                        MailContent += "<font style='font-color:green'>On Time : </font>Checked Out At " + DateTime.Parse(dtr.Rows[0][1].ToString()).ToString("MM/dd/yyyy HH:mm:ss tt");
                    }
                    else if (dtr.Rows[0][0].ToString() == "Orange")
                    {

                        MailContent += "<font style='font-color:orange'>Checked Out Late By : </font>" + decimal.Ceiling(decimal.Parse(DateTime.Parse(dtr.Rows[0][1].ToString()).Subtract(dtarr[0]).TotalMinutes.ToString())).ToString() + " minutes. Checked In At : " + DateTime.Parse(dtr.Rows[0][1].ToString()).ToString("MM/dd/yyyy HH:mm:ss tt");
                    }
                    else
                    {
                        TimeSpan ts = DateTime.Now.Subtract(dtarr[1]);
                        if (ts.TotalMinutes > 30)
                        {
                            MailContent += "<font style='font-color:maroon'>Not Checked Out Yet</font>";
                        }
                        else
                        {
                            MailContent += "<font style='font-color:black'>Expected To Checkout</font>";
                        }
                    }
                    MailContent += "</td></tr>";
                }
                MailContent += "</table><br/><br/>";

                MailContent += "<b>Remarks For This Shift<b><br/>";
                MailContent += "<table border='1' style='width:100%;border-width:1px;border-collapse:collapse;'><tr><td>";
                MailContent += Remark + "</td></tr></table></td></tr></table>";
                //List<string> emailids = new List<string>();
                //DataTable dte = dal.getdata("select EmailID from UserInformation where Role like '%director%' or Role like '%superuser%'");
                //foreach (DataRow dr in dte.Rows)
                //{
                //    emailids.Add(dr[0].ToString());
                //}
                //MailHelper.SendEmail(emailids, "info@tspsecure.com", "", "Shift Report for Shift " + ShiftName + " on " + LocationName, MailContent, true);
                MailHelper.SendEmail("deepak.dubey@gmail.com", "info@tspsecure.com", "", "Shift Report for Shift " + ShiftName + " on " + LocationName, MailContent, true);
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

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Server.Transfer("../SMSUsers/AddLocation.aspx");//page not found
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

            if (btnContinue.Text.StartsWith("Start"))
            {
                btnContinue.Text = "Stop Continuous Refreshing";
                tmrUpdateSchedule.Enabled = true;
            }
            else
            {
                btnContinue.Text = "Start Continuous Refreshing";
                tmrUpdateSchedule.Enabled = false;
            }
        }
        protected void tmrUpdateSchedule_Tick(object sender, EventArgs e)
        {
        }
        public string GetURL(string locid)
        {
            //log4net.ILog logger = log4net.LogManager.GetLogger("File");
            //try
            //{
            return "~/SMSAdmin/DailyRoster.aspx?LID=" + locid + "&dte=" + DateTime.Now.ToString("MM.dd.yyyy");
            //}
            //catch (Exception ex)
            //{
            //    logger.Info(ex.Message);
            //}


        }

        protected void grdShiftStaff_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //try
            //{

            //    grdShiftStaff.CurrentPageIndex = e.NewPageSize;
            //    LoadGrid();
            //}
            //catch (Exception ex)
            //{

            //}
        }
    }
}
