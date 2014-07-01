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
    public partial class View13RiskAssessmentSurvey : System.Web.UI.Page
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
            DataTable dt = dal.executeprocedure("SP_GetRiskSurvey13", para, false);

            if (dt.Rows.Count > 0)
            {
               T23.Text = dt.Rows[0][0].ToString().Trim();
               T24.Text = dt.Rows[0][1].ToString().Trim();
               T25.Text = dt.Rows[0][2].ToString().Trim();
               T26.Text = dt.Rows[0][3].ToString().Trim();
               T27a.Text = dt.Rows[0][4].ToString().Trim();
               T27b.Text = dt.Rows[0][5].ToString().Trim();
               T27c.Text = dt.Rows[0][6].ToString().Trim();
               T27d.Text = dt.Rows[0][7].ToString().Trim();
               T27e.Text = dt.Rows[0][8].ToString().Trim();

               T27f.Text = dt.Rows[0][9].ToString().Trim();
               T27g.Text = dt.Rows[0][10].ToString().Trim();
               T27h.Text = dt.Rows[0][11].ToString().Trim();
               T27i.Text = dt.Rows[0][12].ToString().Trim();

               T27j.Text = dt.Rows[0][13].ToString().Trim();
               T27k.Text = dt.Rows[0][14].ToString().Trim();
               T27l.Text = dt.Rows[0][15].ToString().Trim();
               T27m.Text = dt.Rows[0][16].ToString().Trim();
               T27n.Text = dt.Rows[0][17].ToString().Trim();
               T27o.Text = dt.Rows[0][18].ToString().Trim();
               T27p.Text = dt.Rows[0][19].ToString().Trim();

               T27q.Text = dt.Rows[0][20].ToString().Trim();
               T27r.Text = dt.Rows[0][21].ToString().Trim();
               T28.Text = dt.Rows[0][22].ToString().Trim();
               T29.Text = dt.Rows[0][23].ToString().Trim();
               T30.Text = dt.Rows[0][24].ToString().Trim();
               T31.Text = dt.Rows[0][25].ToString().Trim();
               T32.Text = dt.Rows[0][26].ToString().Trim();

               T33.Text = dt.Rows[0][27].ToString().Trim();
               T34a.Text = dt.Rows[0][28].ToString().Trim();
               T34b.Text = dt.Rows[0][29].ToString().Trim();
               T35.Text = dt.Rows[0][30].ToString().Trim();
               T36.Text = dt.Rows[0][31].ToString().Trim();

               T37.Text = dt.Rows[0][32].ToString().Trim();
               T38.Text = dt.Rows[0][33].ToString().Trim();
               T39a.Text = dt.Rows[0][34].ToString().Trim();
               T39b.Text = dt.Rows[0][35].ToString().Trim();
               T39c.Text = dt.Rows[0][36].ToString().Trim();
               T39d.Text = dt.Rows[0][37].ToString().Trim();
               T40.Text = dt.Rows[0][38].ToString().Trim();
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
                Response.Redirect("View14RiskAssessmentSurvey.aspx?id=" + lblid.Text);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }




    }
}
