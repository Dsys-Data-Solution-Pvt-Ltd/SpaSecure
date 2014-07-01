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
    public partial class ClientVisitMinutes : System.Web.UI.Page
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


        protected void btnAssignmentAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {               
                    SqlParameter[] para = new SqlParameter[9];
                    para[0] = new SqlParameter("@Location",ddllocation.Text.Trim());
                    para[1] = new SqlParameter("@CompletedBy", txtcompletedby.Text.Trim());
                    para[2] = new SqlParameter("@Date", txtdatefrom.Text.Trim());
                    para[3] = new SqlParameter("@ClientName",txtClientName.Text.Trim());
                    para[4] = new SqlParameter("@Complaints", txtcomplaints.Text.Trim());
                    para[5] = new SqlParameter("@PositiveComment", txtpositivecomments.Text.Trim());
                    para[6] = new SqlParameter("@Deployment", txtdeployment.Text.Trim());
                    para[7] = new SqlParameter("@UpcomingEvent", txtupcomingevent.Text.Trim());
                    para[8] = new SqlParameter("@Remarks", txtremarks.Text.Trim());

                    dal.executeprocedure("SP_AddClientVisitMinutes", para);

                    HttpContext.Current.Items.Add("COMPLETE", "INSERT");
                    Server.Transfer("CompleteForm.aspx");

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {                
               // ddllocation.Text = "";
                txtcompletedby.Text = "";
                txtdatefrom.Text = "";
                txtClientName.Text = "";
                txtcomplaints.Text = "";
                txtpositivecomments.Text = "";
                txtdeployment.Text = "";
                txtupcomingevent.Text = "";
                txtremarks.Text = "";
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }


    }
}
