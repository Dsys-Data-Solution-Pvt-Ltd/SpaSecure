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
    public partial class View11RiskAssessmentSurvey : System.Web.UI.Page
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
            DataTable dt = dal.executeprocedure("SP_GetRiskSurvey11", para, false);

            if (dt.Rows.Count > 0)
            {
               Q9.Text = dt.Rows[0][0].ToString().Trim();
               Q10a.Text = dt.Rows[0][1].ToString().Trim();
               Q10b.Text = dt.Rows[0][2].ToString().Trim();
               Q10c.Text = dt.Rows[0][3].ToString().Trim();
               Q10d.Text = dt.Rows[0][4].ToString().Trim();
               Q11.Text = dt.Rows[0][5].ToString().Trim();

               Q12.Text = dt.Rows[0][6].ToString().Trim();
               Q13.Text = dt.Rows[0][7].ToString().Trim();
               Q14.Text = dt.Rows[0][8].ToString().Trim();
               Q15.Text = dt.Rows[0][9].ToString().Trim();
               Q16.Text = dt.Rows[0][10].ToString().Trim();

               Q17.Text = dt.Rows[0][11].ToString().Trim();
               Q18.Text = dt.Rows[0][12].ToString().Trim();
               Q19.Text = dt.Rows[0][13].ToString().Trim();
               Q20.Text = dt.Rows[0][14].ToString().Trim();
               Q21.Text = dt.Rows[0][15].ToString().Trim();
               Q22.Text = dt.Rows[0][16].ToString().Trim();
               Q23.Text = dt.Rows[0][17].ToString().Trim();
               Q24.Text = dt.Rows[0][18].ToString().Trim();
               Q25.Text = dt.Rows[0][19].ToString().Trim();

               Q26.Text = dt.Rows[0][20].ToString().Trim();
               Q27.Text = dt.Rows[0][21].ToString().Trim();
               Q28.Text = dt.Rows[0][22].ToString().Trim();
               Q29.Text = dt.Rows[0][23].ToString().Trim();
               Q30.Text = dt.Rows[0][24].ToString().Trim();
               Q31.Text = dt.Rows[0][25].ToString().Trim();
               Q32.Text = dt.Rows[0][26].ToString().Trim();

               R1.Text = dt.Rows[0][27].ToString().Trim();
               R2.Text = dt.Rows[0][28].ToString().Trim();
               R3.Text = dt.Rows[0][29].ToString().Trim();
               R4.Text = dt.Rows[0][30].ToString().Trim();
               R5.Text = dt.Rows[0][31].ToString().Trim();
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
                Response.Redirect("View12RiskAssessmentSurvey.aspx?id=" + lblid.Text);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }



    }
}
