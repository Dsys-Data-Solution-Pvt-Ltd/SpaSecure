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
    public partial class CheckOutKey : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (!IsPostBack)
                {
                    getkeybunch("Reserve");
                    //BindGrid();
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private void getkeybunch(string sta)
        {
            ddlbunchno.Items.Clear();
            ddlbunchno.Items.Add(" ");
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@status", sta);
            DataTable dtbunch = dal.executeprocedure("sp_getkey_BunchNo", para, false);

            if (dtbunch.Rows.Count > 0)
            {
                for (int k = 0; k < dtbunch.Rows.Count; k++)
                {
                    ddlbunchno.Items.Add(dtbunch.Rows[0][0].ToString());
                }
            }
        }


        protected void btnSearchKeyAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnClearKeyAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                ddlbunchno.Text = "";
                txtname.Text = "";
                txtdesignation.Text = "";
                txtKeyNRIC.Text = "";
                txtphone.Text = "";
                // ddlbunchno.Text = "";

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }




    }
}
