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
    public partial class View7RiskAssessmentSurvey : System.Web.UI.Page
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
            DataTable dt = dal.executeprocedure("SP_GetRiskSurvey7", para, false);

            if (dt.Rows.Count > 0)
            {
               M1.Text = dt.Rows[0][0].ToString().Trim();
               txtSectionMType.Text = dt.Rows[0][1].ToString().Trim();
               txtSectionMManufacturer.Text = dt.Rows[0][2].ToString().Trim();
               ChkDoorContact.Text = dt.Rows[0][3].ToString().Trim();
               ChkWindowContact.Text = dt.Rows[0][4].ToString().Trim();
               ChkGlassbreak.Text = dt.Rows[0][5].ToString().Trim();
               ChkMotionSensors.Text = dt.Rows[0][6].ToString().Trim();
               ChkProprietary.Text = dt.Rows[0][7].ToString().Trim();
               ChkCentralStation.Text = dt.Rows[0][8].ToString().Trim();
               ChkPolice.Text = dt.Rows[0][9].ToString().Trim();
               M3Other.Text = dt.Rows[0][10].ToString().Trim();
               
               M4.Text = dt.Rows[0][11].ToString().Trim();
               M5.Text = dt.Rows[0][12].ToString().Trim();
               M6.Text = dt.Rows[0][13].ToString().Trim();
               M7.Text = dt.Rows[0][14].ToString().Trim();
               M8.Text = dt.Rows[0][15].ToString().Trim();
               M9.Text = dt.Rows[0][16].ToString().Trim();

               M10.Text = dt.Rows[0][17].ToString().Trim();
               M10List.Text = dt.Rows[0][18].ToString().Trim();
               M11.Text = dt.Rows[0][19].ToString().Trim();

               M12.Text = dt.Rows[0][20].ToString().Trim();
               M13.Text = dt.Rows[0][21].ToString().Trim();
               M14.Text = dt.Rows[0][22].ToString().Trim();
               M15.Text = dt.Rows[0][23].ToString().Trim();
               M16.Text = dt.Rows[0][24].ToString().Trim();

               ChkVHSTape.Text = dt.Rows[0][25].ToString().Trim();
               ChkDVR.Text = dt.Rows[0][26].ToString().Trim();
               ChkHardDisc.Text = dt.Rows[0][27].ToString().Trim();
               ChkOtherHarddisc.Text = dt.Rows[0][28].ToString().Trim();
               ChkOtherHarddisc.Text = dt.Rows[0][29].ToString().Trim();

               M18.Text = dt.Rows[0][30].ToString().Trim();
               ChBW.Text = dt.Rows[0][31].ToString().Trim();
               Chkcolor.Text = dt.Rows[0][32].ToString().Trim();
               ChkInfrared.Text = dt.Rows[0][33].ToString().Trim();
               ChkPTZ.Text = dt.Rows[0][34].ToString().Trim();
               ChkWirlessRF.Text = dt.Rows[0][35].ToString().Trim();
               ChkIP.Text = dt.Rows[0][36].ToString().Trim();

               M20.Text = dt.Rows[0][37].ToString().Trim();
               M21.Text = dt.Rows[0][38].ToString().Trim();
               M22.Text = dt.Rows[0][39].ToString().Trim();
               M23.Text = dt.Rows[0][40].ToString().Trim();
               M24.Text = dt.Rows[0][41].ToString().Trim();

               M25.Text = dt.Rows[0][42].ToString().Trim();
               M26.Text = dt.Rows[0][43].ToString().Trim();
               M27.Text = dt.Rows[0][44].ToString().Trim();
               M28.Text = dt.Rows[0][45].ToString().Trim();
               M29.Text = dt.Rows[0][46].ToString().Trim();
               M30.Text = dt.Rows[0][47].ToString().Trim();
               M31.Text = dt.Rows[0][42].ToString().Trim();
               M32.Text = dt.Rows[0][43].ToString().Trim();

              N1.Text = dt.Rows[0][44].ToString().Trim();
              N2.Text = dt.Rows[0][45].ToString().Trim();
              N2Why.Text = dt.Rows[0][46].ToString().Trim();
              N3.Text = dt.Rows[0][47].ToString().Trim();

              N4.Text = dt.Rows[0][44].ToString().Trim();
              N5.Text = dt.Rows[0][45].ToString().Trim();
              
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
                Response.Redirect("View8RiskAssessmentSurvey.aspx?id=" + lblid.Text);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }





    }
}
