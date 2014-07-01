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
    public partial class updateviewclient : System.Web.UI.Page
    {
        DataALayer Dal = new DataALayer();
        string Staff_ID = string.Empty;
        string Location_ID = string.Empty;
        DataALayer dal = new DataALayer();
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
                    getLocationName();
                    if (Request.QueryString["BTID"] != null)
                    {
                        PopulateFuntion(Request.QueryString["BTID"].ToString());
                    }
                   
                }

            }
            catch (Exception ex)
            {

            }
        }
        private void PopulateFuntion(string  argid)
        {
            string quer = "select Userinformation.UserID,UserInformation.UserPassword,location.Location_name as Location_ID from Userinformation,StaffLocationMap,location where UserInformation.Staff_ID='" + argid +"'"+" and NRICno=2222 and StaffLocationMap.StaffID=UserInformation.staff_ID and StaffLocationMap.LocationID=location.Location_id order by location.Location_name  Asc ";
            DataSet dsedit = dal.getdataset(quer);
            if (dsedit.Tables[0].Rows.Count > 0)
            {
                staffid.Text = argid.ToString();

                txtclientName.Text = dsedit.Tables[0].Rows[0]["UserID"].ToString();
                txtpassword.Text = dsedit.Tables[0].Rows[0]["UserPassword"].ToString();
                //lbllocationid.Visible = true;
                lbllocationid.Text = dsedit.Tables[0].Rows[0]["Location_ID"].ToString();
                
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
        protected void btnAdd_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (ddllocation.SelectedValue.ToString()!="")
                {
                    getLocationIDByName(ddllocation.SelectedValue.ToString());
                    
                    DBConnectionHandler1 db = new DBConnectionHandler1();
                    SqlConnection cn = db.getconnection();
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("update UserInformation set UserID=@UserID,UserPassword=@UserPassword where Staff_ID=@Staff_ID", cn);
                    SqlCommand cmd1 = new SqlCommand("update StaffLocationMap set LocationID=@LocationID where StaffID=@StaffID", cn);
                    cmd.Parameters.AddWithValue("@UserID", txtclientName.Text);
                    cmd.Parameters.AddWithValue("@UserPassword", txtpassword.Text);
                    cmd.Parameters.AddWithValue("@Staff_ID", staffid.Text);
                    cmd1.Parameters.AddWithValue("@LocationID", SearchLocID.Text);
                    cmd1.Parameters.AddWithValue("@StaffID", staffid.Text);
                    int result1 = cmd.ExecuteNonQuery();
                    result1 = cmd1.ExecuteNonQuery();
                    cmd.Dispose();
                    cmd1.Dispose();
                    cn.Close();
                    txtclientName.Text = "";
                    txtpassword.Text = "";
                    lblmsg.Visible = true;
                    lblmsg.Text = "Update Successfully...!";
                }
                else
                {
                    getLocationIDByName(lbllocationid.Text);
                    DBConnectionHandler1 db = new DBConnectionHandler1();
                    SqlConnection cn = db.getconnection();
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("update UserInformation set UserID=@UserID,UserPassword=@UserPassword where Staff_ID=@Staff_ID", cn);
                    SqlCommand cmd1 = new SqlCommand("update StaffLocationMap set LocationID=@LocationID where StaffID=@StaffID", cn);
                    cmd.Parameters.AddWithValue("@UserID", txtclientName.Text);
                    cmd.Parameters.AddWithValue("@UserPassword", txtpassword.Text);
                    cmd.Parameters.AddWithValue("@Staff_ID", staffid.Text);
                    cmd1.Parameters.AddWithValue("@LocationID", SearchLocID.Text);
                    cmd1.Parameters.AddWithValue("@StaffID", staffid.Text);
                    int result1 = cmd.ExecuteNonQuery();
                     result1 = cmd1.ExecuteNonQuery();
                    cmd.Dispose();
                    cmd1.Dispose();
                    cn.Close();
                    //Dal.executesql("update UserInformation set UserID=" + txtclientName.Text + " and UserPassword=" + txtpassword.Text + " where Staff_ID=" + staffid.Text);
                    //Dal.executesql("update StaffLocationMap set LocationID=" + SearchLocID.Text + " where StaffID=" + staffid.Text);
                    //txtpassword.Text = "";
                    txtclientName.Text = "";
                    txtpassword.Text = "";
                    lblmsg.Visible = true;
                    lblmsg.Text = "Update Successfully...!";
                }
                
            }
            catch (Exception ex)
            {

            }
        }
       
    }
}