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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.Services.DataService;
using System.Data.SqlClient;
namespace GaurdPatroSystem
{
    public partial class viewclient : System.Web.UI.Page
    { DataALayer dal = new DataALayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    HyperLink hy7 = (HyperLink)Master.FindControl("HyperLink1");
                    hy7.Visible = true;
                    HyperLink hy = (HyperLink)Master.FindControl("LoginHome");
                    hy.Visible = true;
                    HyperLink hy1 = (HyperLink)Master.FindControl("Home1");
                    hy1.Visible = false;
                    HyperLink hy2 = (HyperLink)Master.FindControl("Home2");
                    hy2.Visible = true;
                    HyperLink hy3 = (HyperLink)Master.FindControl("fileby");
                    hy3.Visible = true;
                    HyperLink hy4 = (HyperLink)Master.FindControl("recordby");
                    hy4.Visible = true;
                    LinkButton hy6 = (LinkButton)Master.FindControl("LinkButton1");
                    hy6.Visible = true;
                    BindGridWithFilter();
                }
            }
            catch(Exception exc)
            {
            }
        }
        private void BindGridWithFilter()
        {
           
            try
            {

                DataSet dsitem = new DataSet();
                DBConnectionHandler1 db = new DBConnectionHandler1();
                SqlConnection cn = db.getconnection();
               

                    //dsitem = dal.getdataset("select convert(varchar,LocationID)+' '+convert(varchar,GTSID) as Location,location.Location_name as LocationID,FileName,CurrentDate from GaurdTourSystem2,location where GaurdTourSystem2.LocationID=location.Location_id");
                    dsitem = dal.getdataset("select Userinformation.Staff_ID,Userinformation.Role,location.Location_name as Location_ID from Userinformation,StaffLocationMap,location where NRICno='2222' and StaffLocationMap.StaffID=UserInformation.staff_ID and StaffLocationMap.LocationID=location.Location_id order by location.Location_name  Asc ");
                    if (dsitem.Tables[0].Rows.Count > 0)
                    {
                        gvItemTable.PageSize = 20;
                        gvItemTable.DataSource = dsitem.Tables[0];
                        gvItemTable.DataBind();
                    }
                    else
                    {
                        gvItemTable.DataSource = null;
                        gvItemTable.DataBind();
                    }
               
                        

              


            }
            catch (Exception ex)
            {
                // logger.Info(ex.Message);
            }
        }
        protected void gvItemTable_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string BTid = e.CommandArgument.ToString();
            if (e.CommandName == "Edit")
            {
                
                Server.Transfer("updateviewclient.aspx?BTID=" + BTid);
            }
            if (e.CommandName == "DeleteRow")
            {

                DeleteItem(BTid);
            }
        }
        private void DeleteItem(string argContractorId)
        {
           
            if (!string.IsNullOrEmpty(argContractorId))
            {
                DBConnectionHandler1 db = new DBConnectionHandler1();
                SqlConnection cn = db.getconnection();
                cn.Open();
                SqlCommand cmd = new SqlCommand("delete from UserInformation where Staff_ID=@staffid", cn);
                cmd.Parameters.AddWithValue("@staffid", argContractorId);
                SqlCommand cmd1 = new SqlCommand("delete from StaffLocationMap where StaffID=@staffid", cn);
                cmd1.Parameters.AddWithValue("@staffid", argContractorId);
                int result1 = cmd.ExecuteNonQuery();
                int result2 = cmd1.ExecuteNonQuery();
                cmd.Dispose();
                cmd1.Dispose();
                cn.Close();
                BindGridWithFilter();
                
            }
        }
        protected void gvItemTable_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton Delete = (ImageButton)e.Row.FindControl("btnDelete");
                Delete.Attributes.Add("onclick", "javascript:return " +
                    "confirm('Are you sure to delete this record?')");
            }



        }
    }
}