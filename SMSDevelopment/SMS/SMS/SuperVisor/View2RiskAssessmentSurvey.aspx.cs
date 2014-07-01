using System;
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
    public partial class View2RiskAssessmentSurvey : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
           log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (!IsPostBack)
                {
                    if (Request.QueryString["id"] != null)
                    {
                        int id = Convert.ToInt32(Request.QueryString["id"].ToString());
                        PopulateFuntion(id);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private void PopulateFuntion(int argsBGID)
        {
            lblid.Text =Convert.ToString(argsBGID);

            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Risk_id", argsBGID);            
            DataTable dt = dal.executeprocedure("SP_GetRiskSurvey2", para, false);

            if (dt.Rows.Count > 0)
            {
                B21.Text = dt.Rows[0][0].ToString().Trim();
                B22.Text = dt.Rows[0][1].ToString().Trim();
                B23.Text = dt.Rows[0][2].ToString().Trim();
                B24.Text = dt.Rows[0][3].ToString().Trim();
                B25.Text = dt.Rows[0][4].ToString().Trim();

                B26.Text = dt.Rows[0][5].ToString().Trim();
                B27.Text = dt.Rows[0][6].ToString().Trim();
                B28.Text = dt.Rows[0][7].ToString().Trim();
                B29.Text = dt.Rows[0][8].ToString().Trim();

                B30.Text = dt.Rows[0][9].ToString().Trim();
                B31.Text = dt.Rows[0][10].ToString().Trim();
                B32.Text = dt.Rows[0][11].ToString().Trim();
                B33.Text = dt.Rows[0][12].ToString().Trim();
                B34.Text = dt.Rows[0][13].ToString().Trim();
                B35.Text = dt.Rows[0][14].ToString().Trim();
                B36.Text = dt.Rows[0][15].ToString().Trim();
                B37.Text = dt.Rows[0][16].ToString().Trim();
                B38.Text = dt.Rows[0][17].ToString().Trim();
                B39.Text = dt.Rows[0][18].ToString().Trim();
                B40.Text = dt.Rows[0][19].ToString().Trim();

               B41.Text = dt.Rows[0][20].ToString().Trim();
               B42.Text = dt.Rows[0][21].ToString().Trim();
               B43.Text = dt.Rows[0][22].ToString().Trim();
               B44.Text = dt.Rows[0][23].ToString().Trim();
               B45.Text = dt.Rows[0][24].ToString().Trim();

               B46.Text = dt.Rows[0][25].ToString().Trim();
               B47.Text = dt.Rows[0][26].ToString().Trim();
               C1.Text = dt.Rows[0][27].ToString().Trim();
               C2.Text = dt.Rows[0][28].ToString().Trim();

               C3.Text = dt.Rows[0][29].ToString().Trim();
               C4.Text = dt.Rows[0][30].ToString().Trim();
               C5.Text = dt.Rows[0][31].ToString().Trim();
               C6.Text = dt.Rows[0][32].ToString().Trim();
               C7.Text = dt.Rows[0][33].ToString().Trim();
               C8.Text = dt.Rows[0][34].ToString().Trim();

               
            }

        }



        protected void btnprint_Click(object sender, EventArgs e)
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

        protected void bntnext_Click(object sender, EventArgs e)
        {

            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Response.Redirect("View3RiskAssessmentSurvey.aspx?id=" + lblid.Text);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }







    }
}
