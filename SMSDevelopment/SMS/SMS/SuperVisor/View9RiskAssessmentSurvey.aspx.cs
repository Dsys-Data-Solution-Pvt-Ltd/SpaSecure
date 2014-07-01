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
    public partial class View9RiskAssessmentSurvey : System.Web.UI.Page
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
            DataTable dt = dal.executeprocedure("SP_GetRiskSurvey9", para, false);

            if (dt.Rows.Count > 0)
            {
               O24.Text = dt.Rows[0][0].ToString().Trim();
               O25.Text = dt.Rows[0][1].ToString().Trim();
               O25How.Text = dt.Rows[0][2].ToString().Trim();
               O26.Text = dt.Rows[0][3].ToString().Trim();
               O27.Text = dt.Rows[0][4].ToString().Trim();
               O28.Text = dt.Rows[0][5].ToString().Trim();

               O29.Text = dt.Rows[0][6].ToString().Trim();
               O30.Text = dt.Rows[0][7].ToString().Trim();
               O31.Text = dt.Rows[0][8].ToString().Trim();
               O32.Text = dt.Rows[0][9].ToString().Trim();
               O33.Text = dt.Rows[0][10].ToString().Trim();

               O34.Text = dt.Rows[0][11].ToString().Trim();
               O35.Text = dt.Rows[0][12].ToString().Trim();
               O36.Text = dt.Rows[0][13].ToString().Trim();
               O37.Text = dt.Rows[0][14].ToString().Trim();
               O38.Text = dt.Rows[0][15].ToString().Trim();
               O39.Text = dt.Rows[0][16].ToString().Trim();

               O40.Text = dt.Rows[0][17].ToString().Trim();
               O40txt.Text = dt.Rows[0][18].ToString().Trim();
               O41.Text = dt.Rows[0][19].ToString().Trim();

               O42.Text = dt.Rows[0][20].ToString().Trim();
               O43.Text = dt.Rows[0][21].ToString().Trim();
               O44.Text = dt.Rows[0][22].ToString().Trim();
               O45.Text = dt.Rows[0][23].ToString().Trim();

               P1.Text = dt.Rows[0][24].ToString().Trim();
               P2.Text = dt.Rows[0][25].ToString().Trim();
               P3.Text = dt.Rows[0][26].ToString().Trim();
               P4.Text = dt.Rows[0][27].ToString().Trim();
               P4txt.Text = dt.Rows[0][28].ToString().Trim();
               P5.Text = dt.Rows[0][29].ToString().Trim();

               P6.Text = dt.Rows[0][30].ToString().Trim();
               P7.Text = dt.Rows[0][31].ToString().Trim();
               P8.Text = dt.Rows[0][32].ToString().Trim();
               P9.Text = dt.Rows[0][33].ToString().Trim();
               P10.Text = dt.Rows[0][34].ToString().Trim();
               P10txt.Text = dt.Rows[0][35].ToString().Trim();
               P11.Text = dt.Rows[0][36].ToString().Trim();
               P12.Text = dt.Rows[0][37].ToString().Trim();
               P13.Text = dt.Rows[0][38].ToString().Trim();

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
                Response.Redirect("View10RiskAssessmentSurvey.aspx?id=" + lblid.Text);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }




    }
}
