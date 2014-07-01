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
using System.Data.SqlClient;
using SMS.Services.DataService;
using SMS.SuperVisor;
using System.Drawing;
using SMS.SMSAdmin;
using SMS.SMSAppUtilities;
using SMS.Services.BusinessServices;
using Telerik.Web.UI;

namespace SMS.SMSCommons
{
    public partial class default2 : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["ManagementRole"] = "superuser";
            if (!IsPostBack)
            {
                //FillSettingValue();

                if (Session["ManagementRole"] != null)
                {
                    txtdatefrom.Text = DateTime.Now.ToString("MM/dd/yyyy");
                    mvAttendence.ActiveViewIndex = 0;
                    if (Session["ManagementRole"].ToString().ToLower().Contains("Superuser") || Session["ManagementRole"].ToString().ToLower().Contains("director"))
                    {
                        grdLocations.DataSource = dal.getdata("select Location_id,Location_name from location where Current_Status='Present' order by Location_name Asc");
                        grdLocations.DataBind();
                        if (Session["LCID"] != null)
                        {
                            mvAttendence.ActiveViewIndex = 1;
                        }
                    }
                    else if (Session["managementRole"].ToString().ToLower().StartsWith("security") || Session["managementRole"].ToString().ToLower().Contains("visor"))
                    {
                        if (Session["LCID"] != null)
                        {
                            Session["LCID"] = Session["LCID"].ToString();
                        }
                        lnkBack.Visible = false;
                        mvAttendence.ActiveViewIndex = 1;
                        BindGuardSchedule(txtdatefrom.Text);
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
            }
            if (Session["ManagementRole"].ToString().ToLower() == "Superuser")
            {
                divSuperUser.Style.Add(HtmlTextWriterStyle.Display, "");
            }
            else
            {
                divSuperUser.Style.Add(HtmlTextWriterStyle.Display, "none");
            }
        }

        private void FillSettingValue()
        {
            AdminBLL BLL = new AdminBLL();
            BLL.FilldefaultValues();


            if (HttpContext.Current.Items["Welcome_heading"] != null)
            {
                lblWelcom_Heading.Text = HttpContext.Current.Items["Welcome_heading"].ToString();
            }
            // lblWelcom_Heading.Text = HttpContext.Current.Items[ContextKeys.Welcome_heading].ToString();
            // lblWelcom_title.Text = HttpContext.Current.Items[ContextKeys.Welcome_title].ToString();
            // lblWelcom_title1.Text = HttpContext.Current.Items[ContextKeys.Welcome_title2].ToString();

            //lblWelcom_title.Text = HttpContext.Current.Items[ContextKeys.Welcome_title].ToString();
            //lblWelcom_title1.Text = HttpContext.Current.Items[ContextKeys.Welcome_title2].ToString();

        }

        private void BindGuardSchedule(string date)
        {
            DateTime temp;
            if (DateTime.TryParse(date, out temp))
            {
                SqlParameter[] para = new SqlParameter[2];
                para[0] = new SqlParameter("@LocationID", Session["LCID"].ToString());
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

                foreach (DataColumn dc in dt1.Columns)
                {
                  
                    TemplateField makeliveCol = new TemplateField();
                    makeliveCol.ItemTemplate = new CreateItemTemplateLinkBtn(System.Guid.NewGuid().ToString().Split('-')[System.Guid.NewGuid().ToString().Split('-').Length - 1], dc.ColumnName, "MakeLive", "return confirm('Are you sure you want to publish this version?')");
                    makeliveCol.HeaderText = dc.ColumnName;
                    makeliveCol.HeaderStyle.Width = Unit.Pixel(180);
                    makeliveCol.ItemStyle.Height = Unit.Pixel(30);
                    makeliveCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
                    makeliveCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                    grdSchedule.Columns.Add(makeliveCol);
                }
                grdSchedule.DataSource = dt1;
                grdSchedule.DataBind();
                string script = "";
                foreach (GridViewRow gvr in grdSchedule.Rows)
                {
                    foreach (TableCell tc in gvr.Cells)
                    {
                        LinkButton lnk = ((LinkButton)tc.Controls[0]);
                        lnk.ForeColor = Color.Black;
                        lnk.Font.Bold = true;
                        lnk.Font.Underline = false;
                        script += "AttachContextMenu('" + lnk.ClientID + "','" + lnk.CommandArgument + "');";
                    }
                }
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CMenu", "$(document).ready( function() {" + script + "});", true);
            }
        }

        protected void lnkAdmin_Click(object sender, ImageClickEventArgs e)
        {
            Session["SubRole"] = "Admin Executive";
            BindMenu("Admin Executive");
        }

        private void BindMenu(string role)
        {
            Menu mn = (Menu)Master.FindControl("Menu");
            DataAccessLayer dal = new DataAccessLayer();
            DataSet ds = dal.getdataset("select * from vwRoleMenu where RoleName='" + role + "'");
            mn.DataSource = new HierarchicalDataSet(ds, "ID", "ParentID");
            mn.DataBind();
        }

        protected void lnkOperations_Click(object sender, ImageClickEventArgs e)
        {
            Session["SubRole"] = "Operations Manager";
            //BindMenu("Operations Manager");
        }

        protected void lnkController_Click(object sender, ImageClickEventArgs e)
        {
            Session["SubRole"] = "Controller";
            //BindMenu("Controller");
        }

        protected void grdLocations_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToLower() == "select")
            {
                Session["LCID"] = e.CommandArgument;
                mvAttendence.ActiveViewIndex = 1;
                BindGuardSchedule(txtdatefrom.Text);
            }
        }

        protected void lnkBack_Click(object sender, EventArgs e)
        {
            mvAttendence.ActiveViewIndex = 0;
        }

        protected void lnkSuperUser_Click(object sender, ImageClickEventArgs e)
        {
            Session["SubRole"] = "superuser";
            BindMenu("superuser");
            //BindMenu1("Superuser");
        }
    

    }
}