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
using System.Drawing;

using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.Services.DataService;
using SMS.SMSAppUtilities;
using SMS.BusinessEntities;

namespace SMS.SuperVisor
{
    public partial class ChangeNotification : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                lblerror.Visible = false;               
                if (!IsPostBack)
                {
                    if (Session["ManagementRole"].ToString().ToLower() == "superuser")
                    {
                        fillLocation();
                    }
                    else
                    {
                        getLocationNameById(Session["LCID"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        private void getLocationNameById(string Name)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Location_id", Name);
            DataTable dsLocationName = dal.executeprocedure("sp_getLocationNameByID", para, false);
            ddllocation.Items.Add("");
            if (dsLocationName.Rows.Count > 0)
            {
                ddllocation.Items.Add(dsLocationName.Rows[0][0].ToString().Trim());
            }
        }

        private void fillLocation()
        {
            ddllocation.Items.Clear();
            ddllocation.Items.Add("");

            SqlParameter[] para = new SqlParameter[0];
            DataTable dsLocation = dal.executeprocedure("sp_FillLocationName", para, false);
            if (dsLocation.Rows.Count > 0)
            {
                for (int j = 0; j < dsLocation.Rows.Count; j++)
                {
                    ddllocation.Items.Add(dsLocation.Rows[j][0].ToString().Trim());
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
                searchid.Text = dsLocationID.Rows[0][0].ToString().Trim();
            }
        }
        protected void btnSearchPassAdd_Click(object sender, EventArgs e)
        {
            string refno = txtRefNo.Text.ToString();
            string NotiDate = txtdate.Text.ToString();
            string Attn = txtAttn.Text.ToString();
            string replaced = txtreplaced.Text.ToString();
            string fromGuardName = txtguardfrom.Text.ToString();
            string fromGyardNameNRIC = txtguardfromNric.Text.ToString();
            string ToGuard = txtToguard.Text.ToString();
            string ToGuardNRIC = txtToguardnric.Text.ToString();
            int locationid = Convert.ToInt32(getLocationIDByName1(searchid.Text));
            dal.executesql("insert into ChangeNotification(RefNumber,NotifyDate,Attn,replacedon,SecurityGuardFromName,SecurityGuardFromNRIC,SecurityGuardToName,SecurityGuardToNRIC,Location_id,DateFrom) values('" + refno + "','" + NotiDate + "','" + Attn + "','" + replaced + "','" + fromGuardName + "','" + fromGyardNameNRIC + "','" + ToGuard + "','" + ToGuardNRIC + "','"+locationid+"','"+DateTime.Now+"')");

            lblerror.Visible = true;
            lblerror.Text = "Inserted Successfully";
            
        }

        protected void btnClearPassAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Session["ctrl"] = printview;
                ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('printpage.aspx','PrintMe','height=700px,width=800px,scrollbars=1');</script>");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void ddllocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchid.Text = ddllocation.SelectedValue.ToString();
        }
        private string getLocationIDByName1(string Name)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Location_name", Name);
            DataTable dsLocationID = dal.executeprocedure("sp_GetLocationIDbyName", para, false);
            string result = "";
            if (dsLocationID.Rows.Count > 0)
            {
                result= dsLocationID.Rows[0][0].ToString().Trim();
            }
            return result;
        }


    }
}
