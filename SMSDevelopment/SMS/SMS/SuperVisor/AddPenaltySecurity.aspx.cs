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

using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.Services.DataService;
using SMS.SMSAppUtilities;
using SMS.BusinessEntities;

namespace SMS.SuperVisor
{
    public partial class AddPenaltySecurity : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                lblerr1.Visible = false;
                lblerror.Visible = false;

                if (!IsPostBack)
                {
                     
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnSearchPassAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                SqlParameter[] para = new SqlParameter[3];
                para[0] = new SqlParameter("@Heading", txtHeading.Text.Trim());
                para[1] = new SqlParameter("@Clause", txtClause.Text.Trim());
                para[2] = new SqlParameter("@Fine", txtFine.Text.Trim());

                dal.executeprocedure("SP_AddPenalitySecurity", para);

                lblerror.Visible = true;
                lblerror.Text = "Insert Successfully ..!";

                HttpContext.Current.Items.Add("COMPLETE", "INSERT");
                Server.Transfer("..//SMSAdmin//AlertUpdateComplete.aspx");
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
                txtHeading.Text = "";
                txtClause.Text = "";
                txtFine.Text = "";
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }




    }
}
