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

using Microsoft.SqlServer.Management;
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
    public partial class View5RiskAssessmentSurvey : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (!IsPostBack)
                {
                    DBConnectionHandler1 bd = new DBConnectionHandler1();
                    SqlConnection cn = bd.getconnection();
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("select * from UploadLogo", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        if (dr.GetString(0) != "")
                        {
                            image1.ImageUrl = dr.GetString(0);
                            cn.Close();
                            dr.Close();
                        }
                    }
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
            lblid.Text = Convert.ToString(argsBGID);

            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Risk_id", argsBGID);
            DataTable dt = dal.executeprocedure("SP_GetRiskSurvey5", para, false);

            if (dt.Rows.Count > 0)
            {
               J1.Text = dt.Rows[0][0].ToString().Trim();
               J2.Text = dt.Rows[0][1].ToString().Trim();
               J3.Text = dt.Rows[0][2].ToString().Trim();
               J4.Text = dt.Rows[0][3].ToString().Trim();
               J5.Text = dt.Rows[0][4].ToString().Trim();
               J6.Text = dt.Rows[0][5].ToString().Trim();
               J7.Text = dt.Rows[0][6].ToString().Trim();
               J8.Text = dt.Rows[0][7].ToString().Trim();
               J9.Text = dt.Rows[0][8].ToString().Trim();
               J10.Text = dt.Rows[0][9].ToString().Trim();
               J11.Text = dt.Rows[0][10].ToString().Trim();
               J12.Text = dt.Rows[0][11].ToString().Trim();
               J13.Text = dt.Rows[0][12].ToString().Trim();

               K1.Text = dt.Rows[0][13].ToString().Trim();
               K2.Text = dt.Rows[0][14].ToString().Trim();
               K3.Text = dt.Rows[0][15].ToString().Trim();
               K4.Text = dt.Rows[0][16].ToString().Trim();
               K5.Text = dt.Rows[0][17].ToString().Trim();
               K6.Text = dt.Rows[0][18].ToString().Trim();
               K7.Text = dt.Rows[0][19].ToString().Trim();
               K8.Text = dt.Rows[0][20].ToString().Trim();
               K9.Text = dt.Rows[0][21].ToString().Trim();
               K10.Text = dt.Rows[0][22].ToString().Trim();
               K11.Text = dt.Rows[0][23].ToString().Trim();
               K12.Text = dt.Rows[0][24].ToString().Trim();

               K13.Text = dt.Rows[0][25].ToString().Trim();
               K14.Text = dt.Rows[0][26].ToString().Trim();
               K15.Text = dt.Rows[0][27].ToString().Trim();
               K16.Text = dt.Rows[0][28].ToString().Trim();
               K17.Text = dt.Rows[0][29].ToString().Trim();
               K18.Text = dt.Rows[0][30].ToString().Trim();
               K19.Text = dt.Rows[0][31].ToString().Trim();
               K20.Text = dt.Rows[0][32].ToString().Trim();

               K21.Text = dt.Rows[0][33].ToString().Trim();
               K22.Text = dt.Rows[0][34].ToString().Trim();
               K23.Text = dt.Rows[0][35].ToString().Trim();

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
                Response.Redirect("View6RiskAssessmentSurvey.aspx?id=" + lblid.Text);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }




    }
}
