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
    public partial class View6RiskAssessmentSurvey : System.Web.UI.Page
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
            DataTable dt = dal.executeprocedure("SP_GetRiskSurvey6", para, false);

            if (dt.Rows.Count > 0)
            {
               K24.Text = dt.Rows[0][0].ToString().Trim();
               K25.Text = dt.Rows[0][1].ToString().Trim();
               K26.Text = dt.Rows[0][2].ToString().Trim();
               K27.Text = dt.Rows[0][3].ToString().Trim();
               K28.Text = dt.Rows[0][4].ToString().Trim();
               K29.Text = dt.Rows[0][5].ToString().Trim();
               K30.Text = dt.Rows[0][6].ToString().Trim();
               K31.Text = dt.Rows[0][7].ToString().Trim();
               K31A.Text = dt.Rows[0][8].ToString().Trim();
               K31B.Text = dt.Rows[0][9].ToString().Trim();
               K31C.Text = dt.Rows[0][10].ToString().Trim();
               K32.Text = dt.Rows[0][11].ToString().Trim();
               K32A.Text = dt.Rows[0][12].ToString().Trim();
               K32B.Text = dt.Rows[0][13].ToString().Trim();
               K32C.Text = dt.Rows[0][14].ToString().Trim();
               K32D.Text = dt.Rows[0][15].ToString().Trim();
               K33.Text = dt.Rows[0][16].ToString().Trim();
               K34.Text = dt.Rows[0][17].ToString().Trim();
               K35.Text = dt.Rows[0][18].ToString().Trim();
               K36.Text = dt.Rows[0][19].ToString().Trim();

               ChkKeys.Text = dt.Rows[0][20].ToString().Trim();
               ChkAccessCard.Text = dt.Rows[0][21].ToString().Trim();
               ChkIDBadges.Text = dt.Rows[0][22].ToString().Trim();
               ChkSecurityOfficer.Text = dt.Rows[0][23].ToString().Trim();
               ChkOpenEntry.Text = dt.Rows[0][24].ToString().Trim();

               ChkAfterKeys.Text = dt.Rows[0][25].ToString().Trim();
               ChkAfterAccessCard.Text = dt.Rows[0][26].ToString().Trim();
               ChkAfterIDBadges.Text = dt.Rows[0][27].ToString().Trim();
               ChkAfterSecurityOfficer.Text = dt.Rows[0][28].ToString().Trim();
               ChkAfterOpenEntry.Text = dt.Rows[0][29].ToString().Trim();

               L3.Text = dt.Rows[0][30].ToString().Trim();
               L4.Text = dt.Rows[0][31].ToString().Trim();
               L5.Text = dt.Rows[0][32].ToString().Trim();
               L6.Text = dt.Rows[0][33].ToString().Trim();
               L7.Text = dt.Rows[0][34].ToString().Trim();
               L8.Text = dt.Rows[0][35].ToString().Trim();

               L9.Text = dt.Rows[0][36].ToString().Trim();
               L10.Text = dt.Rows[0][37].ToString().Trim();
               L11.Text = dt.Rows[0][38].ToString().Trim();
               L12.Text = dt.Rows[0][39].ToString().Trim();
               L13.Text = dt.Rows[0][40].ToString().Trim();
               L14.Text = dt.Rows[0][41].ToString().Trim();


               L15.Text = dt.Rows[0][42].ToString().Trim();
               L16.Text = dt.Rows[0][43].ToString().Trim();
               L17.Text = dt.Rows[0][44].ToString().Trim();
               L18.Text = dt.Rows[0][45].ToString().Trim();
               L19.Text = dt.Rows[0][46].ToString().Trim();
               L20.Text = dt.Rows[0][47].ToString().Trim();

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
                Response.Redirect("View7RiskAssessmentSurvey.aspx?id=" + lblid.Text);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }




    }
}
