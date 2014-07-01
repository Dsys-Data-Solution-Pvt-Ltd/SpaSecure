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
using GaurdPatroSystem.Services.DataService;
using System.Collections.Generic;

using System.IO;

namespace GaurdPatroSystem
{
    public partial class VerifyLogin : System.Web.UI.Page
    {
        DataALayer dal = new DataALayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblerror1.Visible = false;
            if (!IsPostBack)
            {
                HyperLink hy7 = (HyperLink)Master.FindControl("HyperLink1");
                hy7.Visible = false;
                HyperLink hy = (HyperLink)Master.FindControl("LoginHome");
                hy.Visible = true;
                HyperLink hy1 = (HyperLink)Master.FindControl("Home1");
                hy1.Visible = false;
                //hy1.NavigateUrl = "VerifyLogin.aspx";
                HyperLink hy2 = (HyperLink)Master.FindControl("Home2");
                hy2.Visible = false;
                HyperLink hy3 = (HyperLink)Master.FindControl("fileby");
                hy3.Visible = false;
                HyperLink hy4 = (HyperLink)Master.FindControl("recordby");
                hy4.Visible = false;
                LinkButton hy5 = (LinkButton)Master.FindControl("lnknewclient");
                hy5.Visible = false;
                LinkButton hy6 = (LinkButton)Master.FindControl("LinkButton1");
                hy6.Visible = false;
                DataSet userAssignLocation = dal.getdataset("select LocationID from StaffLocationMap Where StaffID = '" + Session["staff_id"].ToString() + "' ");
                if (userAssignLocation.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = new DataTable();
                    DataTable Temp = new DataTable();
                    for (int k = 0; k < userAssignLocation.Tables[0].Rows.Count; k++)
                    {
                        int locid = Convert.ToInt32(userAssignLocation.Tables[0].Rows[k][0].ToString());
                        dt = dal.getdata("select Location_name,Location_id from location Where Location_id = " + locid + " ");
                        Temp.Merge(dt);
                    }
                    grdLocations.DataSource = Temp;
                    grdLocations.DataBind();
                }
                else
                {
                    grdLocations.DataSource = null;
                    grdLocations.DataBind();
                }
            }
        }

        protected void grdLocations_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToLower() == "select")
            {
              string location=  e.CommandArgument.ToString();
                Session["LCID"] =location;
                Response.Redirect("ClientPatroTime.aspx");
            }
        }

    }
}
