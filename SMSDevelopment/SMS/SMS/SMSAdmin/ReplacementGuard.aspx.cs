using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMS.Services.DataService;
using System.Data;
using System.Data.SqlClient;

namespace SMS.SMSAdmin
{
    public partial class ReplacementGuard : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        string loc = string.Empty;
        string mon = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Request.QueryString["id"] != null)
                    {
                        string id = Request.QueryString["id"].ToString();
                        BindNewData(id);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void BindNewData(string date)
        {  
            hdnMonthID.Value = date;
            gvAvailableGuards.DataBind();
            gvAvailableGuards.Visible = true;           
        }

        protected void btnAssign_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtt = CheckMrs();
                fillguard();
                if (dtt.Rows.Count == 0)
                {
                      loc = Session["monthlocation"].ToString();
                      mon = Session["damontID"].ToString();
                      string montid = Session["damontNo"].ToString();

                    SqlParameter[] para1 = new SqlParameter[3];
                    para1[0] = new SqlParameter("@LocationID", loc);
                    para1[1] = new SqlParameter("@MonthID", mon);
                    para1[2] = new SqlParameter("@MonthNo", montid);
                    int rows = dal.executeprocedure("usp_AddMonthlyRoster", para1);
                }
                //ddlShift.DataBind();
                //dlShiftAssignment.DataBind();

            }
            catch (Exception ex)
            {
            }
        }
        private DataTable CheckMrs()
        {
            loc = Session["monthlocation"].ToString();
            mon = Session["damontID"].ToString();
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@LocationID", loc);
            para[1] = new SqlParameter("@MonthID", mon);
            return dal.executeprocedure("usp_CheckMonthlyRoster", para, true);
        }
        private void fillguard()
        {
            foreach (GridViewRow gr in gvAvailableGuards.Rows)
            {
                if (((CheckBox)gr.Cells[0].FindControl("chkGuard")).Checked)
                {
                    string staffid = ((CheckBox)gr.Cells[0].FindControl("chkGuard")).ToolTip;
                    int mrid = Convert.ToInt32(Session["Mrid"].ToString());
                    SqlParameter[] para = new SqlParameter[2];
                    para[0] = new SqlParameter("@StaffID", staffid);
                    para[1] = new SqlParameter("@MRID", mrid);
                    dal.executeprocedure("usp_DeployMonthlyStaff", para);
                }
            }
            gvAvailableGuards.DataBind();
            Session["verify"] = 0;
            ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.close();</script>");
           // Server.Transfer("MonthlyRoster.aspx");
        }
    }
}
