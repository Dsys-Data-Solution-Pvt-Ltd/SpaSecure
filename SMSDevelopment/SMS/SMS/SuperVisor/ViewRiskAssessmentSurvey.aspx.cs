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
    public partial class ViewRiskAssessmentSurvey : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
             log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
            String iBTID = string.Empty;

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
                if (HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL] != null)
                {
                    string strURL = HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL].ToString();
                }
                if (HttpContext.Current.Items[ContextKeys.CTX_BT_ID] != null)
                {
                    iBTID = iBTID = HttpContext.Current.Items[ContextKeys.CTX_BT_ID].ToString();
                }

                PopulatePageCntrls(iBTID);
             }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private void PopulatePageCntrls(String argsBGID)
        {
            lblid.Text = argsBGID;

            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Risk_id", argsBGID);            
            DataTable dt = dal.executeprocedure("SP_GetRiskSurvey1", para, false);

            if (dt.Rows.Count > 0)
            {
                txtCompletedBy.Text = dt.Rows[0][0].ToString().Trim();
                txtDate.Text = dt.Rows[0][1].ToString().Trim();
                txtClientName.Text = dt.Rows[0][2].ToString().Trim();
                txtContactPerson.Text = dt.Rows[0][3].ToString().Trim();
                txtAddress.Text = dt.Rows[0][4].ToString().Trim();

                txtCity.Text = dt.Rows[0][5].ToString().Trim();
                txtState.Text = dt.Rows[0][6].ToString().Trim();
                txtZip.Text = dt.Rows[0][7].ToString().Trim();
                txtPhone.Text = dt.Rows[0][8].ToString().Trim();

                ChkConstruction.Text = dt.Rows[0][9].ToString().Trim();
                ChkOfficePark.Text = dt.Rows[0][10].ToString().Trim();
                ChkHighRise.Text = dt.Rows[0][11].ToString().Trim();
                ChkOfficeBldg.Text = dt.Rows[0][12].ToString().Trim();
                ChkHospital.Text = dt.Rows[0][13].ToString().Trim();
                ChkRetail.Text = dt.Rows[0][14].ToString().Trim();
                ChkBank.Text = dt.Rows[0][15].ToString().Trim();
                ChkGovernementLeased.Text = dt.Rows[0][16].ToString().Trim();
                ChkHotelMotel.Text = dt.Rows[0][17].ToString().Trim();
                ChkResidential.Text = dt.Rows[0][18].ToString().Trim();
                txtFacultyOther.Text = dt.Rows[0][19].ToString().Trim();

                B1.Text = dt.Rows[0][20].ToString().Trim();
                B2.Text = dt.Rows[0][21].ToString().Trim();
                B3.Text = dt.Rows[0][22].ToString().Trim();
                B4.Text = dt.Rows[0][23].ToString().Trim();
                B4List.Text = dt.Rows[0][24].ToString().Trim();

               B5.Text = dt.Rows[0][25].ToString().Trim();
               B6.Text = dt.Rows[0][26].ToString().Trim();
               B7.Text = dt.Rows[0][27].ToString().Trim();
               B8.Text = dt.Rows[0][28].ToString().Trim();

               B9.Text = dt.Rows[0][29].ToString().Trim();
               B10.Text = dt.Rows[0][30].ToString().Trim();
               B11.Text = dt.Rows[0][31].ToString().Trim();
               B12.Text = dt.Rows[0][32].ToString().Trim();
               B13.Text = dt.Rows[0][33].ToString().Trim();
               B14.Text = dt.Rows[0][34].ToString().Trim();               

               B15.Text = dt.Rows[0][35].ToString().Trim();
               B16.Text = dt.Rows[0][36].ToString().Trim();
               B17.Text = dt.Rows[0][37].ToString().Trim();
               B18.Text = dt.Rows[0][38].ToString().Trim();
               B19.Text = dt.Rows[0][39].ToString().Trim();
               B20.Text = dt.Rows[0][40].ToString().Trim();

               txtManufacuturing.Text = dt.Rows[0][41].ToString().Trim();
               txtManufacturProduct.Text = dt.Rows[0][42].ToString().Trim();

               txtFacultyDistribution.Text = dt.Rows[0][43].ToString().Trim();
               txtDistributionProduct.Text = dt.Rows[0][44].ToString().Trim();
               txtOtherDiscribe.Text = dt.Rows[0][45].ToString().Trim();

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
                Response.Redirect("View2RiskAssessmentSurvey.aspx?id=" + lblid.Text); 
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
    
    
    
    }
}
