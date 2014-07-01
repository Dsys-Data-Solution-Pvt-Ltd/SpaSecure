using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using log4net;
using log4net.Config;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.Services.DataService;
using SMS.SMSAppUtilities;
using SMS.BusinessEntities.Main;
using SMS.BusinessEntities.Authorization;
using Telerik.Web.UI;
using SMS.master;

namespace SMS.SMSAdmin
{
    public partial class MonthlyRoster : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();

        int btnyescount = 0;
       
        public static int count = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Panel1.Visible = false;
                lblremark.Visible = false;
                txtremark.Visible = false;
                //Session["Mrid"] = null;    
            }
        }
        protected void txtdatefrom_TextChanged(object sender, EventArgs e)
        {
            BindNewData();
        }
        private void BindNewData()
        {
            //DataAccessLayer dal = new DataAccessLayer();
            DateTime temp;
            if (DateTime.TryParse(txtdatefrom.Text, out temp))
            {
                lblErr.Visible = false;
                DateTime dt = DateTime.ParseExact(txtdatefrom.Text, "MM/dd/yyyy", null);
                hdnMonthID.Value = dt.Month.ToString() + dt.Year.ToString();

                //gvAvailable.DataBind();

                Session["damontID"] = hdnMonthID.Value;
                Session["damontNo"] = dt.Month;
                DataTable dtt = CheckMrs();

                if (dtt.Rows.Count == 0)
                {
                    //var dates = Enumerable.Range(1, DateTime.DaysInMonth(dt.Year, dt.Month)).Select(n => new DateTime(dt.Year, dt.Month, n));
                    //// then filter the only the start of weeks
                    //var weekends = from d in dates
                    //               where d.DayOfWeek == DayOfWeek.Monday
                    //               select d;
                    SqlParameter[] para1 = new SqlParameter[3];
                    para1[0] = new SqlParameter("@LocationID", ddlSite.SelectedValue);
                    para1[1] = new SqlParameter("@MonthID", hdnMonthID.Value);
                    para1[2] = new SqlParameter("@MonthNo", dt.Month);
                    int rows = dal.executeprocedure("usp_AddMonthlyRoster", para1);
                }
                ddlShift.DataBind();
                dlShiftAssignment.DataBind();
                dlShiftAssignment1.DataBind();
            }
            else
            {
                lblErr.Visible = true;
            }
        }

        private DataTable CheckMrs()
        {
            //DataAccessLayer dal = new DataAccessLayer();
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@LocationID", ddlSite.SelectedValue);
            para[1] = new SqlParameter("@MonthID", hdnMonthID.Value);
            Session["MRID"] = para[1].ToString();
            return dal.executeprocedure("usp_CheckMonthlyRoster", para, true);
        }
        protected void ddlShift_SelectedIndexChanged(object sender, EventArgs e)
        {
            staffcount.Text = "";
            dllshift.Text = ddlShift.SelectedValue;
            DBConnectionHandler1 db = new DBConnectionHandler1();
            SqlConnection cn = db.getconnection();
            cn.Open();
            SqlCommand cmd = new SqlCommand("Select ShiftID from LocationShiftMap where LSID in(Select LocationShiftID from MonthlyRoster where MRID=@mrid)", cn);
            cmd.Parameters.AddWithValue("@mrid", ddlShift.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                int x = dr.GetInt32(0);
                Session["mridtest"] = x;
                //cn.Close();
            }
            cmd.Dispose();
            dr.Close();
            dr.Dispose();
            //Session["shiftid"] = ddlShift.SelectedValue;
            DataAccessLayer dal = new DataAccessLayer();
            if (ddlShift.SelectedValue != "0")
            {
                #region Security Officer
                foreach (GridItem gr in gvAvailableGuards.Items)
                {
                    if (((CheckBox)gr.Cells[0].FindControl("chkGuard")).Checked)
                    {
                        string staffid = ((CheckBox)gr.Cells[0].FindControl("chkGuard")).ToolTip;
                        DataSet dschkguard = dal.getdataset("Select MGAID from MonthlyGuardAssignment where StaffID='" + staffid + "'");

                        if (dschkguard.Tables[0].Rows.Count > 0)
                        {
                            //cn.Open();
                            //SqlCommand cmd3 = new SqlCommand("select MRID from  MonthlyGuardAssignment where StaffID='" + staffid + "'",cn);
                            //SqlDataReader dr3 = cmd3.ExecuteReader();
                            //if (dr3.Read())
                            //{
                            //    long aa = dr3.GetInt64(0);
                            //    Session["MRID"] = aa;
                            //}
                            //dr3.Close();
                            //cmd3.Dispose();
                            SqlCommand cmd1 = new SqlCommand("Select MGAID from MonthlyGuardAssignment where StaffID='" + staffid + "'", cn);
                            //cmd1.Parameters.AddWithValue("@staffid", "09FB9431E2FF");
                            // cmd1.Parameters.AddWithValue("@mgaid", long.Parse(mgaid));
                            SqlDataReader dr2 = cmd1.ExecuteReader();
                            if (dr2.Read())
                            {
                                long z = dr2.GetInt64(0);
                                Session["mgaid"] = z;
                            }
                            dr2.Close();
                            dr2.Dispose();
                            cmd1.Dispose();
                            //=================================================
                            //DBConnectionHandler1 db = new DBConnectionHandler1();
                            //SqlConnection cn = db.getconnection();
                            //cn.Open();
                            SqlCommand cmd2 = new SqlCommand("Select ShiftID from LocationShiftMap where LSID in(Select LocationShiftID from MonthlyRoster where MRID in(select MRID from MonthlyGuardAssignment where MGAID=@mgaid))", cn);
                            //cmd1.Parameters.AddWithValue("@staffid","09FB9431E2FF");
                            cmd2.Parameters.AddWithValue("@mgaid", Session["mgaid"].ToString());
                            SqlDataReader dr1 = cmd2.ExecuteReader();
                            if (dr1.Read())
                            {
                                int y = dr1.GetInt32(0);
                                Session["mridtest2"] = y;
                                //cn.Close();
                            }
                            dr1.Close();
                            dr1.Dispose();
                            if (Session["mridtest"].ToString() == Session["mridtest2"].ToString())
                            {
                                staffcount.Text += staffid + " ";
                                Panel1.Visible = true;
                            }
                            else
                            {
                                Panel1.Visible = false;
                                //staffcount.Text = "";
                                long mrid = long.Parse(ddlShift.SelectedValue);
                                SqlParameter[] para = new SqlParameter[3];
                                para[0] = new SqlParameter("@StaffID", staffid);
                                para[1] = new SqlParameter("@MRID", mrid);
                                para[2] = new SqlParameter("@Remark", txtremark.Text);
                                dal.executeprocedure("usp_DeployMonthlyStaff", para);
                            }
                        }
                        else
                        {
                            Panel1.Visible = false;
                            //staffcount.Text = "";
                            long mrid = long.Parse(ddlShift.SelectedValue);
                            SqlParameter[] para = new SqlParameter[3];
                            para[0] = new SqlParameter("@StaffID", staffid);
                            para[1] = new SqlParameter("@MRID", mrid);
                            para[2] = new SqlParameter("@Remark", txtremark.Text);
                            int i = dal.executeprocedure("usp_DeployMonthlyStaff", para);
                            //staffcount.Text = "";
                            //gvAvailableGuards.DataBind();
                            //dlShiftAssignment.DataBind();
                            //ddlShift.SelectedValue = "0";
                        }
                        gvAvailableGuards.DataBind();

                        dlShiftAssignment.DataBind();
                        // ddlShift.SelectedValue = "0";
                    }
                }
                #endregion

                #region Supervisor
                foreach (GridItem gr1 in gvAvailableSupervisor.Items)
                {
                    if (((CheckBox)gr1.Cells[0].FindControl("chkGuard1")).Checked)
                    {
                        string staffid = ((CheckBox)gr1.Cells[0].FindControl("chkGuard1")).ToolTip;
                        DataSet dschkguard = dal.getdataset("Select MGAID from MonthlyGuardAssignment where StaffID='" + staffid + "'");

                        if (dschkguard.Tables[0].Rows.Count > 0)
                        {
                            //cn.Open();
                            SqlCommand cmd1 = new SqlCommand("Select MGAID from MonthlyGuardAssignment where StaffID='" + staffid + "'", cn);
                            //cmd1.Parameters.AddWithValue("@staffid", "09FB9431E2FF");
                            // cmd1.Parameters.AddWithValue("@mgaid", long.Parse(mgaid));
                            SqlDataReader dr2 = cmd1.ExecuteReader();
                            if (dr2.Read())
                            {
                                long z = dr2.GetInt64(0);
                                Session["mgaid"] = z;
                            }
                            dr2.Close();
                            cmd1.Dispose();
                            //=================================================
                            //DBConnectionHandler1 db = new DBConnectionHandler1();
                            //SqlConnection cn = db.getconnection();
                            //cn.Open();
                            SqlCommand cmd2 = new SqlCommand("Select ShiftID from LocationShiftMap where LSID in(Select LocationShiftID from MonthlyRoster where MRID in(select MRID from MonthlyGuardAssignment where MGAID=@mgaid))", cn);
                            //cmd1.Parameters.AddWithValue("@staffid","09FB9431E2FF");
                            cmd2.Parameters.AddWithValue("@mgaid", Session["mgaid"].ToString());
                            SqlDataReader dr1 = cmd2.ExecuteReader();
                            if (dr1.Read())
                            {
                                int y = dr1.GetInt32(0);
                                Session["mridtest2"] = y;
                                cn.Close();
                            }
                            dr1.Close();
                            dr1.Dispose();
                            if (Session["mridtest"].ToString() == Session["mridtest2"].ToString())
                            {
                                staffcount.Text += staffid + " ";
                                Panel1.Visible = true;
                            }
                            else
                            {
                                Panel1.Visible = false;
                                long mrid = long.Parse(ddlShift.SelectedValue);
                                SqlParameter[] para = new SqlParameter[3];
                                para[0] = new SqlParameter("@StaffID", staffid);
                                para[1] = new SqlParameter("@MRID", mrid);
                                para[2] = new SqlParameter("@Remark", txtremark.Text);
                                dal.executeprocedure("usp_DeployMonthlyStaff", para);
                            }
                        }
                        else
                        {
                            Panel1.Visible = false;
                            //staffcount.Text = "";
                            long mrid = long.Parse(ddlShift.SelectedValue);
                            SqlParameter[] para = new SqlParameter[3];
                            para[0] = new SqlParameter("@StaffID", staffid);
                            para[1] = new SqlParameter("@MRID", mrid);
                            para[2] = new SqlParameter("@Remark", txtremark.Text);
                            dal.executeprocedure("usp_DeployMonthlyStaff", para);
                        }
                        gvAvailableSupervisor.DataBind();

                        // gvAvailableSupervisor.Rebind();
                    }
                }

                #endregion

            }



        }
        private void fillavaible()
        {
            //DataAccessLayer dal = new DataAccessLayer();
            DBConnectionHandler1 db = new DBConnectionHandler1();
            SqlConnection cn = db.getconnection();

            try
            {

                //---------first delete from monthly,weekly,dailyguardassign------------------
                string[] staffcount1 = staffcount.Text.Split(' ');
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                for (int i = 0; i < staffcount1.Length - 1; i++)
                {

                    SqlCommand cmd = new SqlCommand("select MGAID from MonthlyGuardAssignment where StaffID=@StaffID", cn);
                    cmd.Parameters.AddWithValue("@StaffID", staffcount1[i]);
                    SqlDataReader dr = cmd.ExecuteReader();
                    long mgaid1 = 0;
                    if (dr.Read())
                    {
                        mgaid1 = dr.GetInt64(0);
                        dr.Close();
                        dr.Dispose();
                        //cn.Close();
                    }
                    string mgaid = Convert.ToString(mgaid1);
                    SqlParameter[] para = new SqlParameter[1];
                    para[0] = new SqlParameter("@MGAID", long.Parse(mgaid));
                    dal.executeprocedure("usp_UnDeployMonthlyStaff", para);
                }
                cn.Close();
                //----------------------------------------------------------------------------
                if (dllshift.Text.ToString() != "0")
                {
                    for (int i = 0; i < staffcount1.Length - 1; i++)
                    {
                        Panel1.Visible = false;
                        long mrid = long.Parse(dllshift.Text.ToString());
                        SqlParameter[] para = new SqlParameter[3];
                        para[0] = new SqlParameter("@StaffID", staffcount1[i]);
                        para[1] = new SqlParameter("@MRID", mrid);
                        para[2] = new SqlParameter("@Remark", txtremark.Text);
                        dal.executeprocedure("usp_DeployMonthlyStaff", para);
                    }

                }
                gvAvailableGuards.DataBind();
                gvAvailableSupervisor.DataBind();
                dlShiftAssignment1.DataBind();
                dlShiftAssignment.DataBind();
                ddlShift.SelectedValue = "0";
            }
            catch (Exception exc)
            {
                //dr.Close();
                //dr.Dispose();
                cn.Close();
            }
        }


        private void BindGrid(RadGrid grdStaff, string MRID)
        {
            DataAccessLayer dal = new DataAccessLayer();
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@MRID", long.Parse(MRID));
            //Session["Mrid"] = para[0].Value; changes by Sandeep Date:5/7/2012
            //Session["MridSO"] = para[0].Value;
            Session["Mrid"] = para[0].Value;
            DataTable dt = dal.executeprocedure("usp_GetMonthlyAssignedStaff", para, true);
            grdStaff.DataSource = dt;
            grdStaff.DataBind();
        }

        private void BindGrid1(RadGrid grdStaff, string MRID)
        {
            DataAccessLayer dal = new DataAccessLayer();
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@MRID", long.Parse(MRID));
            //Session["Mrid"] = para[0].Value; changes by Sandeep Date:5/7/2012
            //Session["MridSV"] = para[0].Value;
            Session["Mrid"] = para[0].Value;
            DataTable dt = dal.executeprocedure("usp_GetMonthlyAssignedStaff1", para, true);
            grdStaff.DataSource = dt;
            grdStaff.DataBind();
        }

        protected void dlShiftAssignment_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            RadGrid grdStaff = (RadGrid)e.Item.FindControl("grdShiftStaff");
            string MRID = ((HiddenField)e.Item.FindControl("hdnLocID")).Value;
            //=====================================//
            //Session["MRIDSO"] = MRID.ToString();
            //====================================//
            BindGrid(grdStaff, MRID);
            DataRowView dr = (DataRowView)e.Item.DataItem;
            string count = dr.Row[4].ToString();
            if (count == "0")
            {
                ((LinkButton)e.Item.FindControl("lnkUnAssign")).Visible = true;
                ddlShift.Enabled = true;
            }
            else
            {
                //((LinkButton)e.Item.FindControl("lnkUnAssign")).Visible = false;
                //ddlShift.Enabled = false;
            }
        }
        protected void dlShiftAssignment1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            RadGrid grdStaff = (RadGrid)e.Item.FindControl("grdShiftStaff1");
            string MRID = ((HiddenField)e.Item.FindControl("hdnLocID1")).Value;
            //================================================//
            //Session["MRIDSV"] = MRID.ToString();
            //=================================================//
            BindGrid1(grdStaff, MRID);
            DataRowView dr = (DataRowView)e.Item.DataItem;
            string count = dr.Row[4].ToString();
            if (count == "0")
            {
                ((LinkButton)e.Item.FindControl("lnkUnAssign1")).Visible = true;
                ddlShift.Enabled = true;
            }
            else
            {
                //((LinkButton)e.Item.FindControl("lnkUnAssign")).Visible = false;
                //ddlShift.Enabled = false;
            }
        }

        protected void btnGetData_Click(object sender, EventArgs e)
        {
            BindNewData();
        }

        protected void grdShiftStaff_RowDataBound(object sender, GridItemEventArgs e)
        {
            DataListItem dlItem = (DataListItem)((RadGrid)sender).Parent;
            DataRowView dr = (DataRowView)dlItem.DataItem;
            //string MRID = Session["Mrid"].ToString(); changes by me Date:5/7/2012
            string MRID = Session["Mrid"].ToString();
            //string MRID = dr.Row[3].ToString();
            //Session["Mrid"] = dr.Row[3].ToString();
            if (e.Item.ItemType == GridItemType.Header)
            {
                CheckBox chkSelectAll = (CheckBox)e.Item.FindControl("chkAll");
                chkSelectAll.Attributes.Add("onclick",
                "jqCheckAll(this,'assigned" + MRID + "');");
                chkSelectAll.CssClass = "assigned" + MRID;
            }
        }
        protected void grdShiftStaff1_RowDataBound(object sender, GridItemEventArgs e)
        {
            DataListItem dlItem = (DataListItem)((RadGrid)sender).Parent;
            DataRowView dr = (DataRowView)dlItem.DataItem;
            //string MRID = dr.Row[3].ToString();
            //string MRID = Session["Mrid"].ToString(); changes by me Date:5/7/2012
            string MRID = Session["Mrid"].ToString();
            if (e.Item.ItemType == GridItemType.Header)
            {
                CheckBox chkSelectAll = (CheckBox)e.Item.FindControl("chkAll");
                chkSelectAll.Attributes.Add("onclick",
                "jqCheckAll(this,'assigned" + MRID + "');");
                chkSelectAll.CssClass = "assigned" + MRID;
            }
        }

        protected void lnkUnAssign_Click(object sender, EventArgs e)
        {
            DataAccessLayer dal = new DataAccessLayer();
            DataListItem dlItem = (DataListItem)((LinkButton)sender).Parent;
            RadGrid grv = (RadGrid)dlItem.FindControl("grdShiftStaff");


            foreach (GridItem gr in grv.Items)
            {
                if (((CheckBox)gr.Cells[0].FindControl("chkGuard")).Checked)
                {
                    string mgaid = ((CheckBox)gr.Cells[0].FindControl("chkGuard")).ToolTip;
                    SqlParameter[] para = new SqlParameter[1];
                    para[0] = new SqlParameter("@MGAID", long.Parse(mgaid));
                    dal.executeprocedure("usp_UnDeployMonthlyStaff", para);
                }
            }
            gvAvailableGuards.DataBind();
            dlShiftAssignment.DataBind();
        }

        protected void lnkUnAssign1_Click(object sender, EventArgs e)
        {
            DataAccessLayer dal = new DataAccessLayer();
            DataListItem dlItem = (DataListItem)((LinkButton)sender).Parent;
            RadGrid grv = (RadGrid)dlItem.FindControl("grdShiftStaff1");


            foreach (GridItem gr in grv.Items)
            {
                if (((CheckBox)gr.Cells[0].FindControl("chkGuard")).Checked)
                {
                    string mgaid = ((CheckBox)gr.Cells[0].FindControl("chkGuard")).ToolTip;
                    SqlParameter[] para = new SqlParameter[1];
                    para[0] = new SqlParameter("@MGAID", long.Parse(mgaid));
                    dal.executeprocedure("usp_UnDeployMonthlyStaff", para);
                }
            }
            //gvAvailableGuards.DataBind();
            //dlShiftAssignment.DataBind();
            gvAvailableSupervisor.DataBind();
            dlShiftAssignment1.DataBind();
        }
        protected void lnkReplacement_Click(object sender, EventArgs e)
        {
            SpaMaster MyMasterPage = (SpaMaster)Page.Master;
            DataAccessLayer dal = new DataAccessLayer();
            try
            {
                DataListItem dlItem = (DataListItem)((LinkButton)sender).Parent;
                RadGrid grv = (RadGrid)dlItem.FindControl("grdShiftStaff");
                foreach (GridItem gr in grv.Items)
                {
                    if (((CheckBox)gr.Cells[0].FindControl("chkGuard")).Checked)
                    {
                        string mgaid = ((CheckBox)gr.Cells[0].FindControl("chkGuard")).ToolTip;

                        SqlParameter[] para = new SqlParameter[1];
                        DataSet dsMIRD = dal.getdataset("Select MRID from MonthlyGuardAssignment where MGAID ='" + mgaid + "'");
                        if (dsMIRD.Tables[0].Rows.Count > 0)
                        {
                            Session["newMIRD"] = dsMIRD.Tables[0].Rows[0][0].ToString();
                        }


                    }
                    else
                    {
                        if (Session["newMIRD"] == null)
                        {

                            //MyMasterPage.ShowErrorMessage("Please Select Security Officer..!");   

                            hdnMessage.Value = "Please Select Security Officer!...";
                        }
                    }
                }
                int count = 0;




















                foreach (GridItem gr in gvAvailableGuards.Items)
                {
                    if (((CheckBox)gr.Cells[0].FindControl("chkGuard")).Checked)
                    {
                        string staffid = ((CheckBox)gr.Cells[0].FindControl("chkGuard")).ToolTip;

                        Session["MStaffID"] = staffid;

                        if (Session["newMIRD"] != null)
                        {
                            count = 1;
                            long mrid = long.Parse(Session["newMIRD"].ToString());
                            SqlParameter[] para = new SqlParameter[3];
                            para[0] = new SqlParameter("@StaffID", staffid);
                            para[1] = new SqlParameter("@MRID", mrid);
                            para[2] = new SqlParameter("@Remark", txtremark.Text);
                            dal.executeprocedure("usp_DeployMonthlyStaff", para);
                            lblerror1.Text = "";
                            //MyMasterPage.ShowErrorMessage("Replaced Successfully"); 
                            hdnMessage.Value = "Replaced Successfully";
                        }
                        else
                        {
                            // MyMasterPage.ShowErrorMessage("Please Select Security Officer..!");   

                            hdnMessage.Value = "Please Select Security Officer!...";
                        }

                    }
                    else
                    {
                        if (count == 0)
                        {
                            Session["MStaffID"] = null;
                            // MyMasterPage.ShowErrorMessage("Please Select Security Officer..!");   

                            hdnMessage.Value = "Please Select Security Officer!...";
                        }

                    }
                }
                gvAvailableGuards.DataBind();
                gvAvailableSupervisor.DataBind();
                dlShiftAssignment.DataBind();

                //============================================================================

                //foreach (GridViewRow gr in gvAvailableSupervisor.Rows)
                //{
                //    if (((CheckBox)gr.Cells[0].FindControl("chkGuard")).Checked)
                //    {
                //        string staffid = ((CheckBox)gr.Cells[0].FindControl("chkGuard")).ToolTip;
                //        Session["MStaffID"] = staffid;
                //        long mrid = long.Parse(Session["newMIRD"].ToString());
                //        SqlParameter[] para = new SqlParameter[3];
                //        para[0] = new SqlParameter("@StaffID", staffid);
                //        para[1] = new SqlParameter("@MRID", mrid);
                //        para[2] = new SqlParameter("@Remark", txtremark.Text);
                //        dal.executeprocedure("usp_DeployMonthlyStaff", para);
                //    }
                //    else
                //    {

                //    }
                //}
                //gvAvailableSupervisor.DataBind();
                //dlShiftAssignment.DataBind();
                //gvAvailableGuards.DataBind();

                //===========================================================================

                DataListItem dlItem1 = (DataListItem)((LinkButton)sender).Parent;
                RadGrid grv1 = (RadGrid)dlItem.FindControl("grdShiftStaff");
                foreach (GridItem gr in grv1.Items)
                {
                    if (((CheckBox)gr.Cells[0].FindControl("chkGuard")).Checked)
                    {
                        if (Session["MStaffID"] != null)
                        {
                            string mgaid = ((CheckBox)gr.Cells[0].FindControl("chkGuard")).ToolTip;
                            SqlParameter[] para = new SqlParameter[1];
                            para[0] = new SqlParameter("@MGAID", long.Parse(mgaid));
                            dal.executeprocedure("usp_UnDeployMonthlyStaff", para);
                            lblerror1.Text = "";
                        }
                        else
                        {
                            //lblerror1.Text = "Please Select Security Officer!...";
                        }
                    }
                    else
                    {

                    }
                }
                Session["newMIRD"] = null; Session["MStaffID"] = null; lblerror1.Text = "";
                gvAvailableGuards.DataBind();
                dlShiftAssignment.DataBind();
                gvAvailableSupervisor.DataBind();





                //foreach (GridViewRow gr1 in grv1.Rows)
                //{
                //    if (((CheckBox)gr1.Cells[0].FindControl("chkGuard1")).Checked)
                //    {
                //        string mgaid = ((CheckBox)gr1.Cells[0].FindControl("chkGuard1")).ToolTip;
                //        SqlParameter[] para = new SqlParameter[1];
                //        para[0] = new SqlParameter("@MGAID", long.Parse(mgaid));
                //        dal.executeprocedure("usp_UnDeployMonthlyStaff", para);
                //    }
                //    else
                //    {

                //    }
                //}
                //gvAvailableGuards.DataBind();
                //dlShiftAssignment.DataBind();
                //gvAvailableSupervisor.DataBind();

                lblremark.Visible = false;
                txtremark.Visible = false;
                MyMasterPage.ShowErrorMessage(hdnMessage.Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //=======================Changes By:Sandeep Date:3/7/2012============================//
        //=======================Purpose:For Supervisor Replacement==========================//

        protected void lnkReplacementForSV_Click(object sender, EventArgs e)
        {
            SpaMaster MyMasterPage = (SpaMaster)Page.Master;
            DataAccessLayer dal = new DataAccessLayer();
            try
            {
                DataListItem dlItem = (DataListItem)((LinkButton)sender).Parent;
                RadGrid grv = (RadGrid)dlItem.FindControl("grdShiftStaff1");
                foreach (GridItem gr in grv.Items)
                {
                    if (((CheckBox)gr.Cells[0].FindControl("chkGuard")).Checked)
                    {
                        string mgaid = ((CheckBox)gr.Cells[0].FindControl("chkGuard")).ToolTip;
                        SqlParameter[] para = new SqlParameter[1];
                        DataSet dsMIRD = dal.getdataset("Select MRID from MonthlyGuardAssignment where MGAID ='" + mgaid + "'");
                        if (dsMIRD.Tables[0].Rows.Count > 0)
                        {
                            Session["newMIRD"] = dsMIRD.Tables[0].Rows[0][0].ToString();
                        }
                    }
                    else
                    {
                        if (Session["newMIRD"] == null)
                        {
                            MyMasterPage.ShowErrorMessage("Please Select Security Officer..!");

                            //lblerror1.Text = "Please Select Security Officer!...";
                        }
                    }
                }
                int count = 0;
                foreach (GridItem gr in gvAvailableSupervisor.Items)
                {
                    if (((CheckBox)gr.Cells[0].FindControl("chkGuard1")).Checked)
                    {
                        string staffid = ((CheckBox)gr.Cells[0].FindControl("chkGuard1")).ToolTip;
                        Session["MStaffID"] = staffid;
                        if (Session["newMIRD"] != null)
                        {
                            long mrid = long.Parse(Session["newMIRD"].ToString());
                            SqlParameter[] para = new SqlParameter[3];
                            para[0] = new SqlParameter("@StaffID", staffid);
                            para[1] = new SqlParameter("@MRID", mrid);
                            para[2] = new SqlParameter("@Remark", txtremark.Text);
                            dal.executeprocedure("usp_DeployMonthlyStaff", para);
                        }
                        else
                        {
                            MyMasterPage.ShowErrorMessage("Please Select Security Officer..!");

                            // lblerror1.Text = "Please Select Security Officer!...";
                        }
                    }
                    else
                    {
                        if (count == 0)
                        {
                            Session["MStaffID"] = null;
                            MyMasterPage.ShowErrorMessage("Please Select Security Officer..!");

                            // lblerror1.Text = "Please Select Security Officer!...";
                        }
                    }
                }
                gvAvailableGuards.DataBind();
                gvAvailableSupervisor.DataBind();
                dlShiftAssignment1.DataBind();

                //============================================================================

                //foreach (GridViewRow gr in gvAvailableSupervisor.Rows)
                //{
                //    if (((CheckBox)gr.Cells[0].FindControl("chkGuard")).Checked)
                //    {
                //        string staffid = ((CheckBox)gr.Cells[0].FindControl("chkGuard")).ToolTip;
                //        Session["MStaffID"] = staffid;
                //        long mrid = long.Parse(Session["newMIRD"].ToString());
                //        SqlParameter[] para = new SqlParameter[3];
                //        para[0] = new SqlParameter("@StaffID", staffid);
                //        para[1] = new SqlParameter("@MRID", mrid);
                //        para[2] = new SqlParameter("@Remark", txtremark.Text);
                //        dal.executeprocedure("usp_DeployMonthlyStaff", para);
                //    }
                //    else
                //    {

                //    }
                //}
                //gvAvailableSupervisor.DataBind();
                //dlShiftAssignment.DataBind();
                //gvAvailableGuards.DataBind();

                //===========================================================================

                //DataListItem dlItem1 = (DataListItem)((LinkButton)sender).Parent;
                RadGrid grv1 = (RadGrid)dlItem.FindControl("grdShiftStaff1");
                foreach (GridItem gr in grv1.Items)
                {
                    if (((CheckBox)gr.Cells[0].FindControl("chkGuard")).Checked)
                    {
                        if (Session["MStaffID"] != null)
                        {
                            string mgaid = ((CheckBox)gr.Cells[0].FindControl("chkGuard")).ToolTip;
                            SqlParameter[] para = new SqlParameter[1];
                            para[0] = new SqlParameter("@MGAID", long.Parse(mgaid));
                            dal.executeprocedure("usp_UnDeployMonthlyStaff", para);
                        }
                        else
                        {

                        }
                    }
                    else
                    {

                    }
                }
                Session["newMIRD"] = null; Session["MStaffID"] = null;
                lblerror1.Text = "";
                gvAvailableGuards.DataBind();
                dlShiftAssignment1.DataBind();
                gvAvailableSupervisor.DataBind();

                //foreach (GridViewRow gr1 in grv1.Rows)
                //{
                //    if (((CheckBox)gr1.Cells[0].FindControl("chkGuard1")).Checked)
                //    {
                //        string mgaid = ((CheckBox)gr1.Cells[0].FindControl("chkGuard1")).ToolTip;
                //        SqlParameter[] para = new SqlParameter[1];
                //        para[0] = new SqlParameter("@MGAID", long.Parse(mgaid));
                //        dal.executeprocedure("usp_UnDeployMonthlyStaff", para);
                //    }
                //    else
                //    {

                //    }
                //}
                //gvAvailableGuards.DataBind();
                //dlShiftAssignment.DataBind();
                //gvAvailableSupervisor.DataBind();

                lblremark.Visible = false;
                txtremark.Visible = false;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //====================================End Changes========================================//

        protected void btnremark_Click(object sender, EventArgs e)
        {
            lblremark.Visible = true;
            txtremark.Visible = true;
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

        protected void btnyes_Click(object sender, EventArgs e)
        {
            try
            {

                fillavaible();
                Panel1.Visible = false;
            }
            catch (Exception ex)
            {
                //cn.Close();
            }
        }
        protected void btnNo_Click(object sender, EventArgs e)
        {
            try
            {
                Panel1.Visible = false;
            }
            catch (Exception ex)
            {
            }
        }



        protected void ddlSite_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtdatefrom.Text = "";

        }

        //protected void gvAvailableGaurds_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        GridViewRow gr = e.Row;
        //        DataRowView dr = (DataRowView)gr.DataItem;

        //        //GridView gpc = ((GridView)gr.Cells[1].FindControl("gvAvailableSupervisor"));
        //        //gpc.ShowHeader = false;

        //        //GridView gpc1 = ((GridView)gr.Cells[1].FindControl("gvAvailableGuards"));
        //        //gpc1.ShowHeader = false;
        //        //foreach (GridViewRow gvr1 in gpc1.Rows)
        //        //{
        //         //   mytest();
        //        //}

        //       // gpc.DataBind();
        //        //gpc1.DataBind();


        //    }


        //}

        public string GetSupervisor()
        {
            string x = string.Empty;
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@MonthID", hdnMonthID.Value);
            para[1] = new SqlParameter("@StartMatch", drpcharactor.SelectedValue.ToString());
            DataTable dsLocationID = dal.executeprocedure("usp_GetMonthlyAvailableSupervisor", para, false);
            //       int i = gvAvailableGuards.Rows.Count;
            //for (int k = 0; k < dsLocationID.Rows.Count;k++)
            //{

            //GridView gpc = (GridView)Master.FindControl("grdAvailableGuards");

            //Label lb = (Label)gvAvailableGuards.FindControl("lblSupervisor");
            // string abc = dsLocationID.Rows[i]["SupervisorName"].ToString();

            // lb.Text = abc;
            // x = abc;
            //}
            return x;
            //gvAvailableGuards.DataBind();
        }

        protected void gvAvailableGuards_RowDataBound(object sender, Telerik.Web.UI.GridItemEventHandler e)
        {

            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //          //GridViewRow gr = e.Row;
            //          //DataRowView dr = (DataRowView)gr.DataItem;
            //   // GetSupervisor();
            //            //gvAvailableGuards.DataBind();
            //}

        }
        //===============================Changes By:Sandeep Date:3/7/2012============================================//
        protected void grdShiftStaff_PageIndexChanging(object sender, GridPageChangedEventArgs e)
        {
            DataListItem dlItem = (DataListItem)((GridView)sender).Parent;
            //DataRowView dr = (DataRowView)dlItem.DataItem;
            //============Changes By:Sandeep Date:6/7/2012=============//
            string MRID = ((HiddenField)dlItem.FindControl("hdnLocID")).Value;
            //==========================================================//

            RadGrid grdStaff = (RadGrid)dlItem.FindControl("grdShiftStaff");
            //string MRID = Session["Mrid"].ToString();
            //string MRID = dr.Row[3].ToString();
            //string MRID = hdnMRID.Value.ToString();
            //DataTable dtt = CheckMrs();

            //Session["MridSecurity"] = dtt.Rows[0]["MRID"].ToString();
            //string MRID = Session["MridSecurity"].ToString();

            if (e.NewPageIndex >= 0)
            {
                // grdStaff.PageIndexChanged = e.NewPageIndex;
                BindGrid(grdStaff, MRID);
            }


            //count++;
        }
        protected void grdShiftStaff1_PageIndexChanging(object sender, GridPageChangedEventArgs e)
        {
            DataListItem dlItem = (DataListItem)((RadGrid)sender).Parent;
            //DataRowView dr = (DataRowView)dlItem.DataItem;
            //==========Changes By:Sandeep Date:6/7/2012==============//
            string MRID = ((HiddenField)dlItem.FindControl("hdnLocID1")).Value;
            //==========================================================//
            RadGrid grdStaff = (RadGrid)dlItem.FindControl("grdShiftStaff1");
            //string MRID = Session["Mrid"].ToString();
            //string MRID = dr.Row[3].ToString();
            //string MRID = hdnMRID.Value.ToString();
            //DataTable dtt = CheckMrs();
            //Session["MridSecurity"] = dtt.Rows[1]["MRID"].ToString();
            //string MRID = Session["MridSecurity"].ToString();

            if (e.NewPageIndex >= 0)
            {
                // grdStaff.PageIndex = e.NewPageIndex;
                BindGrid1(grdStaff, MRID);
            }
            //count++;
        }
        //=====================================End Changes==============================================//
        protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {

            //((sender as CheckBox).NamingContainer as GridItem).Selected = (sender as CheckBox).Checked;
            //bool checkHeader = true;
            //int ro = ((sender as CheckBox).NamingContainer as GridItem).ItemIndex;
            //GridDataItem item = gvAvailableGuards.MasterTableView.Items[ro];

            // CheckBox chkAll =
            //(CheckBox)item.FindControl("chkAll");


            CheckBox chkAll = sender as CheckBox;


            //CheckBox chkAll =
            //   (CheckBox)gvAvailableGuards.FindControl("chkAll");
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
        protected void chkSelectAll_CheckedChanged1(object sender, EventArgs e)
        {
            //CheckBox chkAll =
            //   (CheckBox)gvAvailableSupervisor.HeaderRow.FindControl("chkAll");

            CheckBox chkAll = sender as CheckBox;

            if (chkAll.Checked == true)
            {
                foreach (GridItem gvRow in gvAvailableSupervisor.Items)
                {
                    CheckBox chkSel =
                         (CheckBox)gvRow.FindControl("chkGuard1");
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
                foreach (GridItem gvRow in gvAvailableSupervisor.Items)
                {
                    CheckBox chkSel = (CheckBox)gvRow.FindControl("chkGuard1");
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
        protected void chkSelectAll_CheckedChanged2(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            RadGrid grid = (RadGrid)chk.Parent.Parent.Parent.Parent.Parent.Parent;


            // CheckBox chkAll = (CheckBox)grid.HeaderRow.FindControl("chkAll");

            CheckBox chkAll = sender as CheckBox;

            if (chkAll.Checked == true)
            {
                foreach (GridItem gvRow in grid.Items)
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
                foreach (GridItem gvRow in grid.Items)
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
        protected void chkSelectAll_CheckedChanged3(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            RadGrid grid = (RadGrid)chk.Parent.Parent.Parent.Parent.Parent.Parent;
            // CheckBox chkAll = (CheckBox)grid.HeaderRow.FindControl("chkAll");

            CheckBox chkAll = sender as CheckBox;

            if (chkAll.Checked == true)
            {
                foreach (GridItem gvRow in grid.Items)
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
                foreach (GridItem gvRow in grid.Items)
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
    }

}
