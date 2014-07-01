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
using System.Collections.Generic;
using log4net;
using log4net.Config;
using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.Services.DataService;
using SMS.SMSAppUtilities;
using SMS.BusinessEntities;

namespace SMS.SMSCommons
{
    public partial class VerifyLogin : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            lblerror1.Visible = false;
            try
            {
                if (!IsPostBack)
                {
                    //Session["StaffID"]="01D5880CE712";
                    DataSet userAssignLocation = dal.getdataset("Select Distinct LocationID from StaffLocationMap Where StaffID = '" + Session["StaffID"].ToString() + "' ");
                    if (userAssignLocation.Tables[0].Rows.Count > 0)
                    {
                        DataTable dt = new DataTable();
                        DataTable Temp = new DataTable();
                        dal.executesql("delete from templocation");

                        for (int k = 0; k < userAssignLocation.Tables[0].Rows.Count; k++)
                        {
                            int locid = Convert.ToInt32(userAssignLocation.Tables[0].Rows[k][0].ToString());
                            dt = dal.getdata("Select Location_name,Location_id from location Where Location_id = '" + locid + "' ");
                            dal.executesql("Insert into templocation(Location_name,Location_id) values('" + dt.Rows[0][0].ToString() + "','" + dt.Rows[0][1].ToString() + "')");
                            Temp.Merge(dt);
                        }
                        // Temp.DefaultView.Sort = "Location_name";
                        DataSet dsnew = dal.getdataset("Select Distinct Location_name,Location_id from templocation order by Location_name Asc");
                        if (dsnew.Tables[0].Rows.Count > 0)
                        {
                            grdLocations.DataSource = dsnew;
                            grdLocations.DataBind();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //throw ex;
            }
        }

        //----------previous code----------------------------------------
        //private void getLocationNameById(string Name)
        //{
        //    SqlParameter[] para = new SqlParameter[1];
        //    para[0] = new SqlParameter("@Location_id", Name);
        //    DataTable dsLocationName = dal.executeprocedure("sp_getLocationNameByID", para, false);
        //    if (dsLocationName.Rows.Count > 0)
        //    {
        //        ddllocation.Items.Add(dsLocationName.Rows[0][0].ToString().Trim());
        //    }
        //}

        private void fillLocation()
        {
            //-----------previous code------------------------
        //    ddllocation.Items.Clear();
             
        //    DataSet dsleave = dal.getdataset("Select Location_name,Location_id from location Order by Location_name Asc");
        //    if (dsleave.Tables[0].Rows.Count > 0)
        //    {
        //        ddllocation.DataSource = dsleave.Tables[0];
        //        ddllocation.DataTextField = "Location_name";
        //        ddllocation.DataValueField = "Location_id";
        //        ddllocation.DataBind();
        //        ddllocation.Items.Insert(0, new ListItem(" ", " ", true));
        //    }
        }
        protected void grdLocations_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToLower() == "select")
            {
                Session["LCID"] = e.CommandArgument;
                //Response.Redirect("Default.aspx");
                Response.Redirect("../master/login.aspx");
            }
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //---------previous code------------------
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                //if (ddllocation.Text.Trim() != "")
                //{
                //    Session["LCID"] = int.Parse(ddllocation.SelectedValue);
                //    Response.Redirect("Default.aspx");
                //}
                //else
                //{
                //    lblerror1.Visible = true;
                //    lblerror1.Text = "Please Select Location...!";
                //}

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }






    }
}
