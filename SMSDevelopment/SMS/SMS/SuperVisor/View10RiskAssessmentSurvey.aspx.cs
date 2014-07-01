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
    public partial class View10RiskAssessmentSurvey : System.Web.UI.Page
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
            DataTable dt = dal.executeprocedure("SP_GetRiskSurvey10", para, false);

            if (dt.Rows.Count > 0)
            {
               P14.Text = dt.Rows[0][0].ToString().Trim();
               P15.Text = dt.Rows[0][1].ToString().Trim();
               P16.Text = dt.Rows[0][2].ToString().Trim();
               P17.Text = dt.Rows[0][3].ToString().Trim();
               P18.Text = dt.Rows[0][4].ToString().Trim();
               P19.Text = dt.Rows[0][5].ToString().Trim();

               P20.Text = dt.Rows[0][6].ToString().Trim();
               P21.Text = dt.Rows[0][7].ToString().Trim();
               P22.Text = dt.Rows[0][8].ToString().Trim();
               P23.Text = dt.Rows[0][9].ToString().Trim();
               P24.Text = dt.Rows[0][10].ToString().Trim();

               P25.Text = dt.Rows[0][11].ToString().Trim();
               P26.Text = dt.Rows[0][12].ToString().Trim();
               P27.Text = dt.Rows[0][13].ToString().Trim();
               P28.Text = dt.Rows[0][14].ToString().Trim();
               P29.Text = dt.Rows[0][15].ToString().Trim();
               P30.Text = dt.Rows[0][16].ToString().Trim();

               Q1.Text = dt.Rows[0][17].ToString().Trim();
               Q2.Text = dt.Rows[0][18].ToString().Trim();
               Q3.Text = dt.Rows[0][19].ToString().Trim();

               Q4.Text = dt.Rows[0][20].ToString().Trim();
               Q5.Text = dt.Rows[0][21].ToString().Trim();
               Q6.Text = dt.Rows[0][22].ToString().Trim();
               Q7.Text = dt.Rows[0][23].ToString().Trim();
               Q8.Text = dt.Rows[0][24].ToString().Trim();

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
                Response.Redirect("View11RiskAssessmentSurvey.aspx?id=" + lblid.Text);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

    }
}
