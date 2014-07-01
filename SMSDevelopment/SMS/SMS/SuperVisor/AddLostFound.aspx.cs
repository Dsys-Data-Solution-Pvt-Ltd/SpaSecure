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
    public partial class AddLostFound : System.Web.UI.Page
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
                    if (Session["ManagementRole"].ToString().ToLower() == "superuser" || Session["ManagementRole"].ToString().ToLower() == "super security officer")
                    {
                        getLocationName();
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

        private void getLocationName()
        {
            SqlParameter[] para = new SqlParameter[0];
            DataTable dsLocation = dal.executeprocedure("sp_FillLocationName", para, false);
            if (dsLocation.Rows.Count > 0)
            {
                for (int k = 0; k < dsLocation.Rows.Count; k++)
                {
                    ddllocation.Items.Add(dsLocation.Rows[k][0].ToString().Trim());
                }
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


        protected void btnItemAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                string Status = ddlStatus.Text.Trim();
                if (ddllocation.Text != "" && txtName.Text != "" && txtNRIC.Text != "")
                {
                    SqlParameter[] para = new SqlParameter[8];
                    para[0] = new SqlParameter("@Name", txtName.Text.Trim());
                    para[1] = new SqlParameter("@NRICno", txtNRIC.Text.Trim());
                    para[2] = new SqlParameter("@Location", ddllocation.Text.Trim());
                    para[3] = new SqlParameter("@ContNo", txtTelephone.Text.Trim());
                    para[4] = new SqlParameter("@Description", txtdescription.Text.Trim());
                    para[5] = new SqlParameter("@Date", calDate.Text.Trim());
                    //para[6] = new SqlParameter("@Time", TimeSelector1.Date.ToShortTimeString().ToString());
                    para[6] = new SqlParameter("@Time", TimeSelector1.Date.ToShortTimeString().ToString());
                    para[7] = new SqlParameter("@LostStatus", Status);
                    dal.executeprocedure("SP_AddLostFound", para);

                    HttpContext.Current.Items.Add("COMPLETE", "INSERT");
                    Server.Transfer("CompleteForm.aspx");
                }
                else
                {
                    lblerror.Visible = true;
                    lblerror.Text = "Please Fill All Entries....";
                }

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnClearItemAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                txtName.Text = "";
                txtNRIC.Text = "";
                // txtLocation.Text = "";
                txtTelephone.Text = "";
                txtdescription.Text = "";
                calDate.Text = "";

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }




    }
}
