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

namespace SMS.SuperVisor
{
    public partial class WeeklyRoster : System.Web.UI.Page
    {
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
                    BindShiftGrid();
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
                foreach (GridViewRow gr in gvAvailableGuards.Rows)
                {
                    if (((CheckBox)gr.Cells[0].FindControl("chkGuard")).Checked)
                    {
                        string value = hdnReplacements.Value;
                        string[] wgaid = value.Split(new char[] { ',' });

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

        private void BindShiftGrid()
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
            }
            else
            {
                lblErr.Visible = true;
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
            try
            {
                int ShiftID = int.Parse(ddlShift.SelectedValue);
                //DateTime dt = DateTime.ParseExact(txtDeployDate.Text, "MM/dd/yyyy", null);
                DateTime dt = Convert.ToDateTime(txtDeployDate.Text);//change by rakesh
                DeployShiftAndRebindAll(ShiftID, dt);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

        }

        private void DeployShiftAndRebindAll(int ShiftID, DateTime date)
        {
            foreach (GridViewRow gr in gvAvailableGuards.Rows)
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


        private void fillavaible(int ShiftID, DateTime date)
        {
           foreach (GridViewRow gr in gvAvailableGuards.Rows)
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
              BindShiftGrid();
            }
    
        protected void btnyes_Click(object sender, EventArgs e)
        {
            try
            {
                int ShiftID = int.Parse(ddlShift.SelectedValue);
                DateTime dt = DateTime.ParseExact(txtDeployDate.Text, "MM/dd/yyyy", null);
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


        private void BindGrid(GridView grdStaff, string MRID)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                SqlParameter[] para = new SqlParameter[1];
                para[0] = new SqlParameter("@MRID", long.Parse(MRID));
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
            string script = "";
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow gr = e.Row;
                DataRowView dr = (DataRowView)gr.DataItem;
                if (dr != null)
                {
                    if (dr[2].ToString() == "0")
                    {
                        ddlShift.Enabled = true;
                        //ddlShift0.Enabled = true;
                        txtDeployDate.Enabled = true;
                        //txtDeployDate1.Enabled = true;
                    }
                    else
                    {
                        // ddlShift.Enabled = false;                        
                       // txtDeployDate.Enabled = false;
                        
                    }
                    string MDate = dr[0].ToString();
                    GridView gv = ((GridView)gr.Cells[1].FindControl("grdSchedule"));
                    SqlParameter[] para = new SqlParameter[4];
                    para[0] = new SqlParameter("@LocationID", ddlSite.SelectedValue);
                    para[1] = new SqlParameter("@WeekID", ddlWeek.SelectedValue);
                    para[2] = new SqlParameter("@MonthID", hdnMonthID.Value);
                    para[3] = new SqlParameter("@MDate", MDate);
                    DataTable dt = dal.executeprocedure("usp_GetWeeklySchedule", para, false);
                    DataTable dt1 = SMSCommon.ConvertRowsToColumns(dt, "Shift", "StaffName");
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
                        TemplateField makeliveCol = new TemplateField();
                        makeliveCol.ItemTemplate = new CreateItemTemplateLinkBtn(System.Guid.NewGuid().ToString().Split('-')[System.Guid.NewGuid().ToString().Split('-').Length - 1], dc.ColumnName, "Select", "return confirm('Are you sure you want to publish this version?')");
                        makeliveCol.HeaderText = dc.ColumnName;
                        makeliveCol.HeaderStyle.Width = Unit.Pixel(180);
                        makeliveCol.ItemStyle.Height = Unit.Pixel(30);
                        gv.Columns.Add(makeliveCol);
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
                                script += "AttachContextMenu('"+lnk.ClientID+"','" + lnk.ToolTip + "','" + ddlSite.SelectedValue.ToString() + "','" + lnk.CommandArgument + "');";
                            }
                            catch (Exception ex)
                            { }
                        }
                    }
                }
                Session["script"] += script;
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

        protected void grdShiftStaff_RowCreated(object sender, GridViewRowEventArgs e)
        {
        }
        protected void grdShiftStaff_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string commandname = e.CommandName;
        }

        protected void ddlWeek_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdShiftStaff_DataBound(object sender, EventArgs e)
        {
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "CMenu", "$(document).ready( function() {" + Session["script"].ToString() + "});", true);//error raise on this line
            Session["script"] = "";
        }

       
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
            try{
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
                if(lnkbtn.CommandArgument == "")
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
