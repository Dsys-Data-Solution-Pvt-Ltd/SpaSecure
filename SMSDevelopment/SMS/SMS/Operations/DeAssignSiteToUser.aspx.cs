using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using SMS.Services.DataService;
using SMS.Services.DALUtilities;
using System.Data;

namespace SMS.Operations
{
    public partial class DeAssignSiteToUser : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (!IsPostBack)
                {
                    if (Request.QueryString["curr"] != null)
                    {
                        if (Session["ManagementRole"].ToString().ToLower() == "superuser")
                        {
                            getLocationName();
                        }

                    }
                    else
                    {
                        if (Session["ManagementRole"].ToString().ToLower() == "superuser")
                        {
                            getLocationName();
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }


        }
        private void getLocationName()
        {
            ddlLocation.Items.Clear();
            ddlLocation.Items.Add(" ");
            SqlParameter[] para = new SqlParameter[0];

            DataTable dsLocation = dal.executeprocedure("sp_FillLocationName", para, false);
            if (dsLocation.Rows.Count > 0)
            {
                for (int k = 0; k < dsLocation.Rows.Count; k++)
                {
                    ddlLocation.Items.Add(dsLocation.Rows[k][0].ToString().Trim());
                }
            }
        }

        protected void grdUser_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dsgrole = dal.getdata("SELECT distinct dbo.UserInformation.FirstName,dbo.StaffLocationMap.StaffID FROM dbo.StaffLocationMap INNER JOIN dbo.location ON dbo.StaffLocationMap.LocationID = dbo.location.Location_id INNER JOIN dbo.UserInformation ON dbo.StaffLocationMap.StaffID = dbo.UserInformation.Staff_ID where location.Location_name='" + ddlLocation.SelectedValue + "'");
            if (dsgrole.Rows.Count > 0)
            {
                grdUser.DataSource = dsgrole;
                grdUser.DataBind();
            }
        }

        protected void btnAssignSites_Click(object sender, EventArgs e)
        {
            if (ddlLocation.SelectedValue != "0")
            {
                foreach (GridViewRow gr in grdUser.Rows)
                {

                    if (((CheckBox)gr.Cells[0].FindControl("chkUser")).Checked)
                    {
                        string StaffId = ((CheckBox)gr.Cells[0].FindControl("chkUser")).ToolTip;
                        int dsDel = dal.executesql("delete from StaffLocationMap where StaffLocationMap.StaffID ='" + StaffId + "'");

                        if (dsDel > 0)
                        {
                            Server.Transfer("~/ADMIN/CompleteForm.aspx");
                        }
                       
                    }
                }
            }
        }
        protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkAll =
               (CheckBox)grdUser.HeaderRow.FindControl("chkAll");
            if (chkAll.Checked == true)
            {
                foreach (GridViewRow gvRow in grdUser.Rows)
                {
                    CheckBox chkSel =
                         (CheckBox)gvRow.FindControl("chkUser");
                    chkSel.Checked = true;
                }
            }
            else
            {
                foreach (GridViewRow gvRow in grdUser.Rows)
                {
                    CheckBox chkSel = (CheckBox)gvRow.FindControl("chkUser");
                    chkSel.Checked = false;

                }
            }
        }
    }
}