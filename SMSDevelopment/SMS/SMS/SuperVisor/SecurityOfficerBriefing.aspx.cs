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

//using Microsoft.SqlServer.Management.Trace;
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
    public partial class SecurityOfficerBriefing : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                lblerror.Visible = false;
                lblerr.Visible = false;
                if (!IsPostBack)
                {                   
                    fillEventType();
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

        protected void btnAddTraining_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                SqlParameter[] para = new SqlParameter[10];
                para[0] = new SqlParameter("@TypeofBriefing", txttypeofBriefing.Text.Trim());
                para[1] = new SqlParameter("@DateofBrief", txtdatefrom.Text.Trim());
                para[2] = new SqlParameter("@Location",ddllocation.Text.Trim());
                para[3] = new SqlParameter("@Attendees",txtAttendees.Text.Trim());
                para[4] = new SqlParameter("@BreifDetail",txtDetail.Text.Trim());
                para[5] = new SqlParameter("@Conducted_By",txtConductedBy.Text.Trim());
                para[6] = new SqlParameter("@BreiActionDate",txtActionDate.Text.Trim());
                para[7] = new SqlParameter("@Comments",txtActionComment.Text.Trim());

                para[8] = new SqlParameter("@ReportedTo", txtReportedName.Text.Trim());
                para[9] = new SqlParameter("@Position",txtposition.Text.Trim());


                dal.executeprocedure("SP_AddSoBriefing", para);

                HttpContext.Current.Items.Add("COMPLETE", "INSERT");
                Server.Transfer("CompleteForm.aspx");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnClearTraining_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                txttypeofBriefing.Text = "";
                txtdatefrom.Text = "";
                ddllocation.Text = "";
                txtAttendees.Text = "";
                txtDetail.Text = "";
                txtConductedBy.Text = "";
                txtActionDate.Text = "";
                txtActionComment.Text = "";

                txtReportedName.Text = "";
                txtposition.Text = "";
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void cmdadd2_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                string g = txtaddbrieortype.Text;
                int p = 0;
                string ID = "BrieorType";
                SqlParameter[] para1 = new SqlParameter[1];
                para1[0] = new SqlParameter("@ID", ID);
                DataTable dt = dal.executeprocedure("sp_getLogvaluebyID", para1, true);
                
                int count = dt.Rows.Count;
                for (p = 0; p < count; p++)
                {
                    string f = dt.Rows[p].ItemArray[0].ToString();

                    if (string.Equals(f, g, StringComparison.CurrentCultureIgnoreCase))
                    {
                        break;
                    }
                }
                p++;
                count++;
                if (p == count)
                {
                    if (txtaddbrieortype.Text.Trim() != "")
                    {
                        dal.executesql("insert into log(ID,Code,Description) values('BrieorType'," + count + ",'" + txtaddbrieortype.Text + "')");
                        txtaddbrieortype.Text = "";
                        fillEventType();
                    }
                }
                else
                {
                    txtaddbrieortype.Text = "";
                    lblerror.Visible = true;
                    lblerror.Text = "This Value Already Exist ..!";
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        private void fillEventType()
        {
            txttypeofBriefing.Items.Clear();
            txttypeofBriefing.Items.Add(" ");

            string ID = "BrieorType";
            SqlParameter[] para1 = new SqlParameter[1];
            para1[0] = new SqlParameter("@ID", ID);
            DataTable dt1 = dal.executeprocedure("sp_getLogvaluebyID", para1, true);
           
            if (dt1.Rows.Count > 0)
            {
                for (int j = 0; j < dt1.Rows.Count; j++)
                {
                    txttypeofBriefing.Items.Add(dt1.Rows[j][0].ToString().Trim());
                }
            }
        }






    }
}