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
    public partial class GPS_locSearch : System.Web.UI.Page
    {
        DataALayer dal = new DataALayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridWithFilter();
                getLocationName();
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
                HyperLink hy7 = (HyperLink)Master.FindControl("HyperLink1");
                hy7.Visible = true;
                //LinkButton hy5 = (LinkButton)Master.FindControl("lnknewclient");
                //hy5.Visible = false;
            }

        }
        private void getLocationName()
        {
            ddllocation.Items.Clear();
            ddllocation.Items.Add("");
            SqlParameter[] para = new SqlParameter[0];
            // para[0] = new SqlParameter("@Location_id", Name);
            DataTable dsLocation = dal.executeprocedure("sp_FillLocationName", para, false);
            if (dsLocation.Rows.Count > 0)
            {
                for (int k = 0; k < dsLocation.Rows.Count; k++)
                {
                    ddllocation.Items.Add(dsLocation.Rows[k][0].ToString().Trim());
                }
            }
        }
        private void getLocationIDByName(string Name)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Location_name", Name);
            DataTable dsLocationID = dal.executeprocedure("sp_GetLocationIDbyName", para, false);
            if (dsLocationID.Rows.Count > 0)
            {
                SearchLocID.Text = dsLocationID.Rows[0][0].ToString().Trim();
            }
        }
        private void BindGridWithFilter()
        {
            getLocationIDByName(ddllocation.SelectedValue.ToString());
            try
            {

                DataSet dsitem = new DataSet();
                DBConnectionHandler1 db = new DBConnectionHandler1();
                SqlConnection cn = db.getconnection();
                if (ddllocation.SelectedValue.ToString() == "")
                {

                    dsitem = dal.getdataset("select convert(varchar,LocationID)+' '+convert(varchar,GTSID) as Location,location.Location_name as LocationID,FileName,CurrentDate from GaurdTourSystem2,location where GaurdTourSystem2.LocationID=location.Location_id");
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
                else
                {
                    string date1 = txtpatrotime.Text.Substring(0,1);
                    string  date2 = txtpatrotime.Text.Substring(1,txtpatrotime.Text.Length-1);
                    string query="";
                    //int date3 = Convert.ToInt32(date2);
                    if (date1[0].ToString() == "0")
                    {
                         //string  str = "  and CurrentDate>='" + date2+ "'";
                        //query="select location.Location_name as LocationID,FileName,CurrentDate from GaurdTourSystem2,location where GaurdTourSystem2.LocationID=location.Location_id and location.Location_id=" + SearchLocID.Text+str;
                        SqlParameter[] para=new SqlParameter[2];
                        para[0] = new SqlParameter("@LocationId", SqlDbType.VarChar, 50);
                        para[0].Value=SearchLocID.Text;
                        para[1] = new SqlParameter("@CurrentDate", SqlDbType.VarChar, 100);
                        para[1].Value=date2;
                        DataTable dt=new DataTable();
                        dt = dal.executeprocedure("GpsSearch",para,false);
                        if (dt.Rows.Count > 0)
                        {
                            gvItemTable.PageSize = 20;
                            gvItemTable.DataSource = dt;
                            gvItemTable.DataBind();
                        }
                        else
                        {
                            gvItemTable.DataSource = null;
                            gvItemTable.DataBind();
                        }
                    }
                    else
                    {
                        //query="select location.Location_name as LocationID,FileName,CurrentDate from GaurdTourSystem2,location where GaurdTourSystem2.LocationID=location.Location_id and location.Location_id=" + SearchLocID.Text + " and CurrentDate>=" + Convert.ToString(txtpatrotime.Text);
                        //dsitem = dal.getdataset("select location.Location_name as LocationID,FileName,CurrentDate from GaurdTourSystem2,location where GaurdTourSystem2.LocationID=location.Location_id and location.Location_id=" + SearchLocID.Text + " and CurrentDate>=" + Convert.ToString(txtpatrotime.Text));
                        SqlParameter[] para = new SqlParameter[2];
                        para[0] = new SqlParameter("@LocationId", SqlDbType.VarChar, 50);
                        para[0].Value = SearchLocID.Text;
                        para[1] = new SqlParameter("@CurrentDate", SqlDbType.VarChar, 100);
                        para[1].Value = txtpatrotime.Text;
                        DataTable dt = new DataTable();
                        dt = dal.executeprocedure("GpsSearch",para,false);
                        if (dt.Rows.Count > 0)
                        {
                            gvItemTable.PageSize = 20;
                            gvItemTable.DataSource = dt;
                            gvItemTable.DataBind();
                        }
                        else
                        {
                            gvItemTable.DataSource = null;
                            gvItemTable.DataBind();
                        }
                    }
                    
                   
                }
                   
                
            }
            catch (Exception ex)
            {
                // logger.Info(ex.Message);
            }
        }

        protected void txtpatrotime_TextChanged(object sender, EventArgs e)
        {
            BindGridWithFilter();
        }

        protected void gvItemTable_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            if (e.CommandName == "View")
            {
                string BTid = e.CommandArgument.ToString();
                Server.Transfer("PatroTimeSystem.aspx?BTID="+BTid);
            }
            if (e.CommandName == "DeleteRow")
            {
                string BTid1 = e.CommandArgument.ToString();
                string[] BTid2 = BTid1.Split(' ');
                string BTid4 = BTid2[0];
                string BTid3 = BTid2[1];
                DeleteItem(BTid4,BTid3);
            }
        }
        private void DeleteItem(string argContractorId,string BTid3)
        {
            getLocationIDByName(argContractorId);
            if (!string.IsNullOrEmpty(argContractorId))
            {
                DBConnectionHandler1 db = new DBConnectionHandler1();
                SqlConnection cn = db.getconnection();
                cn.Open();
                SqlCommand cmd = new SqlCommand("delete from GaurdTourSystem where GTSID IN(select GTSID from GaurdTourSystem2 where LocationID=@location and GTSID=@gtsid)", cn);
                cmd.Parameters.AddWithValue("@location", argContractorId);
                cmd.Parameters.AddWithValue("@gtsid",BTid3);
                SqlCommand cmd1 = new SqlCommand("delete from GaurdTourSystem2 where LocationID=@location and GTSID=@gtsid", cn);
                cmd1.Parameters.AddWithValue("@location", argContractorId);
                cmd1.Parameters.AddWithValue("@gtsid", BTid3);
                int result1 = cmd.ExecuteNonQuery();
                int result2 = cmd1.ExecuteNonQuery();
                BindGridWithFilter();
                // HttpContext.Current.Items.Add(ContextKeys.CTX_COMPLETE, "DELETE");
                // Server.Transfer("../SMSAdmin/AlertUpdateComplete.aspx");
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

        protected void ddllocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGridWithFilter();
        }
    }
} 