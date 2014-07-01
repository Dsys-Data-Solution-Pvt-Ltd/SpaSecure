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
using Telerik.Web.UI;
using SMS.master;
using System.Drawing;
namespace SMS.Operations
{
    public partial class AssignSitesToUsers : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {               
                if (Session["ManagementRole"] != null)
                {
                    if (!IsPostBack)
                    {
                        fillrole();
                        BindLocations();
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
                        //BindUser();
                        //DataTable dt = dal.getdata("select ID,RoleName from RoleMaster where ParentID=(select top 1 ID from RoleMaster where RoleName='" + Session["ManagementRole"].ToString() + "')");
                        //ddlRole.DataSource = dt;
                        //ddlRole.DataTextField = "RoleName";
                        //ddlRole.DataValueField = "RoleName";
                        //ddlRole.DataBind();
                        //ddlRole.Items.Insert(0, new ListItem("- Select -", "0"));                       
                    }
                }
                else
                {
                    Server.Transfer("~/master/login3.aspx");
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private void BindLocations()
        {
            string role = Session["ManagementRole"].ToString().ToLower();

            SqlParameter[] para = new SqlParameter[0];
            DataTable dsLocation = dal.executeprocedure("sp_FillLocationName", para, false);
            if (dsLocation.Rows.Count > 0)
            {
                grdLocations.DataSource = dsLocation;
                grdLocations.DataBind();
            }
            //if (!role.Contains("super") && !role.Contains("director"))
            //{
            //    grdLocations.DataSource = dal.getdata("select Location_id,Location_name from location where Location_id in (select LocationID from StaffLocationMap where StaffID='" + Session["StaffID"] + "')");
            //    grdLocations.DataBind();
            //}
            //else
            //{
               // grdLocations.DataSource = dal.getdata("select Location_id,Location_name from location where Current_Status='Present' order by Location_name Asc");
                //grdLocations.DataBind();
            //}
        }

        protected void btnAssignSites_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                if (ddlUser.SelectedValue != "0")
                {
                    string LocationIDs = "";
                    foreach (GridViewRow gr in grdLocations.Rows)
                    {
                        if (((CheckBox)gr.Cells[0].FindControl("chkSite")).Checked)
                        {
                            LocationIDs += ((CheckBox)gr.Cells[0].FindControl("chkSite")).ToolTip + ",";
                        }
                    }
                    string StaffID = ddlUser.SelectedValue;
                    if (StaffID.ToString() != "")
                    {
                        LocationIDs = LocationIDs.Substring(0, LocationIDs.Length - 1);

                        SqlParameter[] para = new SqlParameter[2];
                        dal.executesql("Delete from StaffLocationMap where StaffID = '" + StaffID + "'");

                        para[0] = new SqlParameter("@StaffID", StaffID);
                        para[1] = new SqlParameter("@LocationIDs", LocationIDs);
                        dal.executeprocedure("usp_AssignLocatiosToStaffs", para);
                        MyMasterPage.ShowErrorMessage("Locations Have Been Assigned Successfully !");  
                       // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AlertMessage", " alert('Locations Have Been Assigned Successfully !');", true);
                       // lblerror.Text = "Locations Have Been Assigned Successfully !";
                    }
                    else
                    {
                        MyMasterPage.ShowErrorMessage("Please Select User!");  
                        //lblerror.Text = "Please Select User!";
                      //  ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AlertMessage", " alert('Please Select User!');", true);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void ddlRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                ddlUser.DataSource = dal.getdata("select isnull(FirstName,'')+' '+isnull(MiddleName,'')+' '+isnull(LastName,'') as StaffName,Staff_ID as StaffID from UserInformation where Role='" + ddlRole.SelectedValue + "' and Staff_Status='Present' order by FirstName Asc");
                ddlUser.DataTextField = "StaffName";
                ddlUser.DataValueField = "StaffID";
                ddlUser.DataBind();
                ddlUser.Items.Insert(0, new ListItem("- Select -", "0"));                
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private void fillrole()
        {
            string rol = Session["user_role"].ToString();
            int subrole = 0;

            if ("superuser" == rol.ToLower())
            {
                SqlParameter[] para = new SqlParameter[0];
                DataTable dtrole = dal.executeprocedure("SP_getRoleNameFromRoleMaster", para, false);
                if (dtrole.Rows.Count > 0)
                {
                    ddlRole.DataSource = dtrole;
                    ddlRole.DataTextField = "UserRole";
                    ddlRole.DataValueField = "UserRole";
                    ddlRole.DataBind();
                    ddlRole.Items.Insert(0, new ListItem("- Select -", "0"));  
                }
                //DataSet dsgrole = dal.getdataset("Select RoleName from RoleMaster order by RoleName Asc");
                //if (dsgrole.Tables[0].Rows.Count > 0)
                //{
                //    for (int h = 0; h < dsgrole.Tables[0].Rows.Count; h++)
                //    {
                //        ddlRole.Items.Add(dsgrole.Tables[0].Rows[h][0].ToString());
                //    }
                //}
            }
            else
            {
                //DataTable subroleid = dal.getdata("Select submenuid from Submenu where SubRole='" + rol + "'");
                DataTable subroleid = dal.getdata("Select ID from UserRoleMaster where UserRole='" + rol + "'");
                if (subroleid.Rows.Count > 0)
                {
                    subrole = Convert.ToInt32(subroleid.Rows[0][0].ToString());
                }
                //DataTable dsgrole = dal.getdata("Select SubRole from Submenu Where submenuid > " + subrole + " ");
                DataTable dsgrole = dal.getdata("Select UserRole from UserRoleMaster where ID> " + subrole + " ");
                if (dsgrole.Rows.Count > 0)
                {
                    ddlRole.DataSource = dsgrole;
                    ddlRole.DataTextField = "UserRole";
                    ddlRole.DataValueField = "UserRole";
                    ddlRole.DataBind();
                    ddlRole.Items.Insert(0, new ListItem("- Select -", "0"));  
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //dal.executesql("Delete from StaffLocationMap");
            //DataSet dsstaffid = dal.getdataset("select Staff_id,role from userinformation where role='SuperVisor' OR role='Security Officer'");
            //if (dsstaffid.Tables[0].Rows.Count > 0)
            //{
            //    for(int k = 0; k < dsstaffid.Tables[0].Rows.Count; k++)
            //    {
            //        string staffid = dsstaffid.Tables[0].Rows[k][0].ToString();
            //        DataSet dslocation = dal.getdataset("select location_id from location where current_status='Present'");
            //        if (dslocation.Tables[0].Rows.Count > 0)
            //        {
            //            for (int j = 0; j < dslocation.Tables[0].Rows.Count; j++)
            //            {
            //                string locid = dslocation.Tables[0].Rows[j][0].ToString();
            //                dal.executesql("Insert into StaffLocationMap(StaffID,LocationID)values('" +staffid +"','" + locid + "')");
            //            }
            //        }
            //    }
            //}
            //Response.Redirect("DeAssignSiteToUser.aspx");
            ModalPopupDelete.Show();
        }

        protected void drpcharactor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dsgrole = dal.getdata("Select Location_name,Location_id from location where Location_name like'"+drpcharactor.SelectedValue+"%' ");
            if (dsgrole.Rows.Count > 0)
            {
                grdLocations.DataSource = dsgrole;
                grdLocations.DataBind();
            }

        }
        protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkAll =
                   (CheckBox)grdLocations.FindControl("chkAll");
                if (chkAll.Checked == true)
                {
                    foreach (GridViewRow gvRow in grdLocations.Rows)
                    {
                        CheckBox chkSel =
                             (CheckBox)gvRow.FindControl("chkSite");
                        chkSel.Checked = true;
                    }
                }
                else
                {
                    foreach (GridViewRow gvRow in grdLocations.Rows)
                    {
                        CheckBox chkSel = (CheckBox)gvRow.FindControl("chkSite");
                        chkSel.Checked = false;

                    }
               
            }
        }


        #region DeassianLocation
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


        public void BindDeGrid()
        {
            DataTable dsgrole = dal.getdata("SELECT distinct dbo.UserInformation.FirstName,dbo.StaffLocationMap.StaffID FROM dbo.StaffLocationMap INNER JOIN dbo.location ON dbo.StaffLocationMap.LocationID = dbo.location.Location_id INNER JOIN dbo.UserInformation ON dbo.StaffLocationMap.StaffID = dbo.UserInformation.Staff_ID where location.Location_name='" + ddlLocation.SelectedValue + "'");
            if (dsgrole.Rows.Count > 0)
            {
                grdUser.DataSource = dsgrole;
                grdUser.DataBind();
            }
        }
        protected void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDeGrid();
        }

        protected void btnAssignSites_Click1(object sender, EventArgs e)
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
                            BindDeGrid();
                            //Server.Transfer("~/ADMIN/CompleteForm.aspx");
                        }

                    }
                }
            }
        }
        protected void chkSelectAll_CheckedChanged1(object sender, EventArgs e)
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

        protected void btnbtnCancel_Click(object sender, EventArgs e)
        {
            ModalPopupDelete.Hide();
        }
        #endregion
       

    }
}
