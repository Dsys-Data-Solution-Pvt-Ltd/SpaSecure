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
using System.Text.RegularExpressions;

using log4net;
using log4net.Config;
using System.Drawing;

using SMS.BusinessEntities;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using MKB.TimePicker;
using MKB.Exceptions;
using SMS.Services.DataService;
using System.Data.SqlClient;

namespace SMS.SuperVisor
{
    public partial class AddNewEmergencyContact : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
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
            if (dsLocationName.Rows.Count > 0)
            {
                ddllocation.Items.Add(dsLocationName.Rows[0][0].ToString().Trim());
            }
        }
        private void fillLocation()
        {
            ddllocation.Items.Clear();
            ddllocation.Items.Add(" ");

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
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (txtmobileno.Text.Trim() != "")
                {
                    if (txtName.Text.Trim() != "")
                    {
                        getLocationIDByName(ddllocation.Text.Trim());
                        SqlParameter[] para = new SqlParameter[8];
                        para[0] = new SqlParameter("@name",txtName.Text.Trim());
                        para[1] = new SqlParameter("@Position",txtPosition.Text.Trim());
                        para[2] = new SqlParameter("@Mobile_No",txtmobileno.Text.Trim());
                        para[3] = new SqlParameter("@Office_No",txtofficeno.Text.Trim());
                        para[4] = new SqlParameter("@Home_No",txthomeno.Text.Trim());
                        para[5] = new SqlParameter("@Extension", txtGrade.Text.Trim());
                        para[6] = new SqlParameter("@DateFrom", DateTime.Now);
                        para[7] = new SqlParameter("@Location_id",searchid.Text.Trim());

                        dal.executeprocedure("SP_AddEmergencyContact", para);

                        HttpContext.Current.Items.Add("COMPLETE", "INSERT");
                        Server.Transfer("CompleteForm.aspx");
                    }
                    else
                    {
                        lblerror.Visible = true;
                        lblerror.Text = "Please Fill Name...!";
                    }
                }
                else
                {
                    lblerror.Visible = true;
                    lblerror.Text = "Please Fill Contact Name...!";
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnClearPassAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                txtGrade.Text = "";
                txthomeno.Text = "";
                txtName.Text = "";
                txtmobileno.Text = "";
                txtPosition.Text = "";
                txtofficeno.Text = "";
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
   }
}
