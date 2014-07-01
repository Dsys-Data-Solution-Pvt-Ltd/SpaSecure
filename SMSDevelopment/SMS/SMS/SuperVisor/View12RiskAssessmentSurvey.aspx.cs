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
    public partial class View12RiskAssessmentSurvey : System.Web.UI.Page
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
            DataTable dt = dal.executeprocedure("SP_GetRiskSurvey12", para, false);

            if (dt.Rows.Count > 0)
            {
                  R6.Text = dt.Rows[0][0].ToString().Trim();
                  R7.Text = dt.Rows[0][1].ToString().Trim();
                  R8.Text = dt.Rows[0][2].ToString().Trim();
                  R9.Text = dt.Rows[0][3].ToString().Trim();
                  R10.Text = dt.Rows[0][4].ToString().Trim();
                  R11.Text = dt.Rows[0][5].ToString().Trim();
                  R12.Text = dt.Rows[0][6].ToString().Trim();
                  R13.Text = dt.Rows[0][7].ToString().Trim();
                  R14.Text = dt.Rows[0][8].ToString().Trim();

                  S1.Text = dt.Rows[0][9].ToString().Trim();
                  S2.Text = dt.Rows[0][10].ToString().Trim();
                  S3.Text = dt.Rows[0][11].ToString().Trim();
                  S3Comment.Text = dt.Rows[0][12].ToString().Trim();

                  T1.Text = dt.Rows[0][13].ToString().Trim();
                  T1txt.Text = dt.Rows[0][14].ToString().Trim();
                  T2.Text = dt.Rows[0][15].ToString().Trim();
                  T2txt.Text = dt.Rows[0][16].ToString().Trim();
                  T3.Text = dt.Rows[0][17].ToString().Trim();
                  T3txt.Text = dt.Rows[0][18].ToString().Trim();
                  T4.Text = dt.Rows[0][19].ToString().Trim();

                  T4txt.Text = dt.Rows[0][20].ToString().Trim();
                  T5.Text = dt.Rows[0][21].ToString().Trim();
                  T6txt.Text = dt.Rows[0][22].ToString().Trim();
                  T7.Text = dt.Rows[0][23].ToString().Trim();
                  T7txt.Text = dt.Rows[0][24].ToString().Trim();
                  T8.Text = dt.Rows[0][25].ToString().Trim();
                  T8txt.Text = dt.Rows[0][26].ToString().Trim();

                  T9.Text = dt.Rows[0][27].ToString().Trim();
                  T10.Text = dt.Rows[0][28].ToString().Trim();
                  T11.Text = dt.Rows[0][29].ToString().Trim();
                  T12.Text = dt.Rows[0][30].ToString().Trim();
                  T13.Text = dt.Rows[0][31].ToString().Trim();

                 T13Name1.Text = dt.Rows[0][32].ToString().Trim();
                 T13Aut1.Text = dt.Rows[0][33].ToString().Trim();
                 T13Name2.Text = dt.Rows[0][34].ToString().Trim();
                 T13Aut2.Text = dt.Rows[0][35].ToString().Trim();
                 T13Name3.Text = dt.Rows[0][36].ToString().Trim();

                    T13Name4.Text = dt.Rows[0][37].ToString().Trim();
                    T13Aut4.Text = dt.Rows[0][38].ToString().Trim();
                    T14.Text = dt.Rows[0][39].ToString().Trim();
                    T15.Text = dt.Rows[0][40].ToString().Trim();
                    T16.Text = dt.Rows[0][41].ToString().Trim();

                    T17.Text = dt.Rows[0][41].ToString().Trim();
                    T18.Text = dt.Rows[0][42].ToString().Trim();
                    T19.Text = dt.Rows[0][43].ToString().Trim();
                    T20.Text = dt.Rows[0][44].ToString().Trim();
                    T21.Text = dt.Rows[0][45].ToString().Trim();
                    T22.Text = dt.Rows[0][46].ToString().Trim();
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
                Response.Redirect("View13RiskAssessmentSurvey.aspx?id=" + lblid.Text);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }




    }
}
