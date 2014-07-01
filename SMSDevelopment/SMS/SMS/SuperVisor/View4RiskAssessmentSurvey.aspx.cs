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
    public partial class View4RiskAssessmentSurvey : System.Web.UI.Page
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
            DataTable dt = dal.executeprocedure("SP_GetRiskSurvey4", para, false);

            if (dt.Rows.Count > 0)
            {
               G13.Text = dt.Rows[0][0].ToString().Trim();
               G14.Text = dt.Rows[0][1].ToString().Trim();
               G15.Text = dt.Rows[0][2].ToString().Trim();
               G16.Text = dt.Rows[0][3].ToString().Trim();
               G17.Text = dt.Rows[0][4].ToString().Trim();
               G18.Text = dt.Rows[0][5].ToString().Trim();
               G19.Text = dt.Rows[0][6].ToString().Trim();
               G20.Text = dt.Rows[0][7].ToString().Trim();
               G21.Text = dt.Rows[0][8].ToString().Trim();
               G22.Text = dt.Rows[0][9].ToString().Trim();

               H1.Text = dt.Rows[0][10].ToString().Trim();
               H2.Text = dt.Rows[0][11].ToString().Trim();
               H3.Text = dt.Rows[0][12].ToString().Trim();
               H4.Text = dt.Rows[0][13].ToString().Trim();
               H5.Text = dt.Rows[0][14].ToString().Trim();
               H6.Text = dt.Rows[0][15].ToString().Trim();
               H7.Text = dt.Rows[0][16].ToString().Trim();
               H8.Text = dt.Rows[0][17].ToString().Trim();
               H9.Text = dt.Rows[0][18].ToString().Trim();
               H10.Text = dt.Rows[0][19].ToString().Trim();
               H11.Text = dt.Rows[0][20].ToString().Trim();
               H12.Text = dt.Rows[0][21].ToString().Trim();
               H13.Text = dt.Rows[0][22].ToString().Trim();
               H14.Text = dt.Rows[0][23].ToString().Trim();
               H15.Text = dt.Rows[0][24].ToString().Trim();

               I1.Text = dt.Rows[0][25].ToString().Trim();
               I2.Text = dt.Rows[0][26].ToString().Trim();
               I3.Text = dt.Rows[0][27].ToString().Trim();
               I4.Text = dt.Rows[0][28].ToString().Trim();
               I5.Text = dt.Rows[0][29].ToString().Trim();
               I6.Text = dt.Rows[0][30].ToString().Trim();
               I7.Text = dt.Rows[0][31].ToString().Trim();
               I8.Text = dt.Rows[0][32].ToString().Trim();

               I9.Text = dt.Rows[0][33].ToString().Trim();
               I10.Text = dt.Rows[0][34].ToString().Trim();
               I11.Text = dt.Rows[0][35].ToString().Trim();
               I12.Text = dt.Rows[0][36].ToString().Trim();
               I13.Text = dt.Rows[0][37].ToString().Trim();
               I14.Text = dt.Rows[0][38].ToString().Trim();
               I15.Text = dt.Rows[0][39].ToString().Trim();

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
                Response.Redirect("View5RiskAssessmentSurvey.aspx?id=" + lblid.Text);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }




    }
}
