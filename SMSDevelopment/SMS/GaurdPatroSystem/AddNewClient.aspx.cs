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
    public partial class AddNewClient : System.Web.UI.Page
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
                    HyperLink hy = (HyperLink)Master.FindControl("LoginHome");
                    hy.Visible = true;
                    HyperLink hy7 = (HyperLink)Master.FindControl("HyperLink1");
                    hy7.Visible = true;
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
                }
                
            }
            catch (Exception ex)
            {

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
            getLocationIDByName(ddllocation.SelectedValue.ToString());
            try
            {
                //Dal.executesql("Insert into location(Location_name,ClientUserID,ClientPassword,Current_Status) values('" + txtlocation.Text + "','" + txtclientName.Text + "','" + txtpassword.Text + "','Present')");
                getStaffID();
                //getLocationID();
                
                Dal.executesql("Insert into UserInformation(UserID,UserPassword,NRICno,Role,Staff_ID) values('" + txtclientName.Text + "','" + txtpassword.Text + "','2222','Client','" + Staff_ID + "')");
                Dal.executesql("Insert into StaffLocationMap(StaffID,LocationID) values('" + Staff_ID + "','" + SearchLocID.Text + "')");
                txtpassword.Text = "";
                //txtlocation.Text = "";
                txtclientName.Text = "";
                lblmsg.Visible = true;
                lblmsg.Text = "Add Successfully...!";
            }
            catch (Exception ex)
            {

            }
        }
        private void getStaffID()
        {
            DataSet dsStaff = Dal.getdataset("SELECT part from SplitString(convert(varchar(100),newid()),'-') where id = (select max(id) from SplitString(convert(varchar(100),newid()),'-'))");
            if (dsStaff.Tables[0].Rows.Count > 0)
            {
                Staff_ID = dsStaff.Tables[0].Rows[0][0].ToString().Trim();
            }
        }
        //private void getLocationID()
        //{
        //    DataSet dslocation = Dal.getdataset(" SELECT Top(1) Location_id From location order by Location_id desc");
        //    if (dslocation.Tables[0].Rows.Count > 0)
        //    {
        //        Location_ID = dslocation.Tables[0].Rows[0][0].ToString().Trim();
        //    }
        //}


    }
}
