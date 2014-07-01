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

namespace SMS.SuperVisor
{
    public partial class MonthlyRoster : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        int btnyescount=0;
        protected void Page_Load(object sender, EventArgs e)
        {           
          if (!IsPostBack)
          {
              Panel1.Visible = false;
              lblremark.Visible = false;
              txtremark.Visible = false;                   
          }                         
        }      
        protected void txtdatefrom_TextChanged(object sender, EventArgs e)
        {
            BindNewData();
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
            }
            else
            {
                lblErr.Visible = true;
            }
        }

        private DataTable CheckMrs()
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@LocationID", ddlSite.SelectedValue);
            para[1] = new SqlParameter("@MonthID", hdnMonthID.Value);
            Session["MRID"] = para[1].ToString();
            return dal.executeprocedure("usp_CheckMonthlyRoster", para, true);
        }
        protected void ddlShift_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlShift.SelectedValue != "0")
            {
                foreach (GridViewRow gr in gvAvailableGuards.Rows)
                {
                    if (((CheckBox)gr.Cells[0].FindControl("chkGuard")).Checked)
                    {
                        string staffid = ((CheckBox)gr.Cells[0].FindControl("chkGuard")).ToolTip;
                        
                        DataSet dschkguard = dal.getdataset("Select MGAID from MonthlyGuardAssignment where StaffID='"+ staffid + "'");
                        
                            if (dschkguard.Tables[0].Rows.Count > 0)
                            {
                                //Panel1.Visible = true;

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
                                //gvAvailableGuards.DataBind();
                                //dlShiftAssignment.DataBind();
                                //ddlShift.SelectedValue = "0";
                            }
                            
                        
                        
                    }
                }
                gvAvailableGuards.DataBind();
                dlShiftAssignment.DataBind();
                ddlShift.SelectedValue = "0";
            }
        }

        private void fillavaible()
        {
            if (ddlShift.SelectedValue != "0")
            {
                /*foreach (GridViewRow gr in gvAvailableGuards.Rows)
                {
                    if (((CheckBox)gr.Cells[0].FindControl("chkGuard")).Checked)
                    {
                        string staffid = ((CheckBox)gr.Cells[0].FindControl("chkGuard")).ToolTip;

                        long mrid = long.Parse(ddlShift.SelectedValue);
                        SqlParameter[] para = new SqlParameter[3];
                        para[0] = new SqlParameter("@StaffID", staffid);
                        para[1] = new SqlParameter("@MRID", mrid);
                        para[2] = new SqlParameter("@Remark", txtremark.Text);
                        dal.executeprocedure("usp_DeployMonthlyStaff", para);                        
                    }
                }*/
                
            }
            gvAvailableGuards.DataBind();
            dlShiftAssignment.DataBind();
            ddlShift.SelectedValue = "0";
        }


        private void BindGrid(GridView grdStaff, string MRID)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@MRID", long.Parse(MRID));
            Session["Mrid"] = para[0].Value;
            DataTable dt = dal.executeprocedure("usp_GetMonthlyAssignedStaff", para, true);
            grdStaff.DataSource = dt;
            grdStaff.DataBind();
        }

        protected void dlShiftAssignment_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            GridView grdStaff = (GridView)e.Item.FindControl("grdShiftStaff");
            string MRID = ((HiddenField)e.Item.FindControl("hdnLocID")).Value;
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

        protected void btnGetData_Click(object sender, EventArgs e)
        {
            BindNewData();
        }

        protected void grdShiftStaff_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataListItem dlItem = (DataListItem)((GridView)sender).Parent;
            DataRowView dr = (DataRowView)dlItem.DataItem;
            string MRID = dr.Row[3].ToString();
            if (e.Row.RowType == DataControlRowType.Header)
            {
                CheckBox chkSelectAll = (CheckBox)e.Row.FindControl("chkAll");
                chkSelectAll.Attributes.Add("onclick",
                "jqCheckAll(this,'assigned" + MRID + "');");
                chkSelectAll.CssClass = "assigned" + MRID;
            }
        }

        protected void lnkUnAssign_Click(object sender, EventArgs e)
        {
            DataListItem dlItem = (DataListItem)((LinkButton)sender).Parent;
            GridView grv = (GridView)dlItem.FindControl("grdShiftStaff");
            foreach (GridViewRow gr in grv.Rows)
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
        protected void lnkReplacement_Click(object sender, EventArgs e)
        {
            try
            {                
                DataListItem dlItem = (DataListItem)((LinkButton)sender).Parent;
                GridView grv = (GridView)dlItem.FindControl("grdShiftStaff");
                foreach (GridViewRow gr in grv.Rows)
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
                }

                foreach (GridViewRow gr in gvAvailableGuards.Rows)
                {
                    if (((CheckBox)gr.Cells[0].FindControl("chkGuard")).Checked)
                    {
                        string staffid = ((CheckBox)gr.Cells[0].FindControl("chkGuard")).ToolTip;
                        Session["MStaffID"] = staffid;
                        long mrid = long.Parse(Session["newMIRD"].ToString());
                        SqlParameter[] para = new SqlParameter[3];
                        para[0] = new SqlParameter("@StaffID", staffid);
                        para[1] = new SqlParameter("@MRID", mrid);
                        para[2] = new SqlParameter("@Remark", txtremark.Text);
                       dal.executeprocedure("usp_DeployMonthlyStaff", para);
                    }
                }               
                 gvAvailableGuards.DataBind();
                 dlShiftAssignment.DataBind();

                 DataListItem dlItem1 = (DataListItem)((LinkButton)sender).Parent;
                 GridView grv1 = (GridView)dlItem.FindControl("grdShiftStaff");
                 foreach (GridViewRow gr in grv1.Rows)
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

                lblremark.Visible = false;
                txtremark.Visible = false;              
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void dlShiftAssignment_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
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
    }

}
