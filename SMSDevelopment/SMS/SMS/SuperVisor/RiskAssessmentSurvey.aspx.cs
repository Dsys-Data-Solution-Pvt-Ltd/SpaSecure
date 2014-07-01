using System;
using System.Collections;
using System.Configuration;
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
using log4net;
using log4net.Config;
using System.Drawing;
using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.Services.DataService;
using SMS.SMSAppUtilities;
using SMS.BusinessEntities;

namespace SMS.SuperVisor
{
    public partial class RiskAssessmentSurvey : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (!IsPostBack)
                {
                    DALConstants dl = new DALConstants();
                    dl.DeleteRecord("RiskSurvey1");
                    newriskid();                 
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }


        //private void DeleteRecord()
        //{
        //    DataSet dsRisk1 = dal.getdataset("Select Risk_id From RiskSurvey1");
        //    {
        //        if (dsRisk1.Tables[0].Rows.Count > 0)
        //        {
        //            for (int j = 0; j < dsRisk1.Tables[0].Rows.Count; j++)
        //            {
        //                string RKid = dsRisk1.Tables[0].Rows[j][0].ToString();
        //                DataSet dsRiskId = dal.getdataset("Select Risk_id from RiskSurvey16 Where Risk_id = '" + RKid + "'");
        //                if (dsRiskId.Tables[0].Rows.Count > 0)
        //                {
        //                }
        //                else
        //                {
        //                    dal.executesql("Delete from RiskSurvey1 where Risk_id ='" + RKid + "' ");
        //                }
        //            }
        //        }
        //    }
        //}

        
        private void newriskid()
        {
            int id = 0;
            //SqlParameter[] para1 = new SqlParameter[0];
            //DataTable dtid = dal.executeprocedure("SP_getMaxRiskID", para1,false);
            DBConnectionHandler1 db = new DBConnectionHandler1();
            SqlConnection cn = db.getconnection();
            cn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter("select isnull(MAX(Risk_id),'') from RiskSurvey1",cn);
            DataTable dtid = new DataTable();
            adp.Fill(ds,"dtid");
            if (dtid.Rows.Count > 0)
            {
                id = Convert.ToInt32(dtid.Rows[0][0].ToString());
                id++;
                GlobalVar.Risk_ID = id;
            }
            else
            {
                GlobalVar.Risk_ID = 1;
            }
        }

        protected void btnItemAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (txtClientName.Text.Trim() != "")
                {
                    lblid.Text = GlobalVar.Risk_ID.ToString();

                    SqlParameter[] para = new SqlParameter[49];
                    para[0] = new SqlParameter("@Risk_id", lblid.Text.Trim());
                    para[1] = new SqlParameter("@DateFrom", DateTime.Now);

                    para[2] = new SqlParameter("@CompletedBy", txtChklistCompletedBy.Text.Trim());
                    para[3] = new SqlParameter("@CompletedDate", calDate.Text.Trim());
                    para[4] = new SqlParameter("@ClientName", txtClientName.Text.Trim());
                    para[5] = new SqlParameter("@ContactPerson", txtContactPerson.Text.Trim());
                    para[6] = new SqlParameter("@Address", txtlocationAddress.Text.Trim());

                    para[7] = new SqlParameter("@State", txtState.Text.Trim());
                    para[8] = new SqlParameter("@Zip", txtZip.Text.Trim());
                    para[9] = new SqlParameter("@Phone", txtPhoneNo.Text.Trim());

                    // string Const =  (ChkConstruction.Checked == true ? ChkConstruction.Checked.ToString(): " ");

                    para[10] = new SqlParameter("@TOF_Construction", (ChkConstruction.Checked == true ? ChkConstruction.Text.Trim() : " "));
                    para[11] = new SqlParameter("@TOF_OfficePark", (ChkOfficePark.Checked == true ? ChkOfficePark.Text.Trim() : " "));
                    para[12] = new SqlParameter("@TOF_HighRise", (ChkHighRise.Checked == true ? ChkHighRise.Text.Trim() : " "));
                    para[13] = new SqlParameter("@TOF_OfficeBldg", (ChkOfficeBldg.Checked == true ? ChkOfficeBldg.Text.Trim() : " "));
                    para[14] = new SqlParameter("@TOF_Hospital", (ChkHospital.Checked == true ? ChkHospital.Text.Trim() : " "));
                    para[15] = new SqlParameter("@TOF_Retail", (ChkRetail.Checked == true ? ChkRetail.Text.Trim() : " "));
                    para[16] = new SqlParameter("@TOF_Bank", (ChkBank.Checked == true ? ChkBank.Text.Trim() : " "));
                    para[17] = new SqlParameter("@TOF_GovFacility", (ChkGovernmentOwnedFacility.Checked == true ? ChkGovernmentOwnedFacility.Text.Trim() : " "));
                    para[18] = new SqlParameter("@TOF_Govleased", (ChkGovernementLeased.Checked == true ? ChkGovernementLeased.Text.Trim() : " "));
                    para[19] = new SqlParameter("@TOF_Hotel", (ChkHotelMotel.Checked == true ? ChkHotelMotel.Text.Trim() : " "));
                    para[20] = new SqlParameter("@TOF_Residential", (ChkResidential.Checked == true ? ChkResidential.Text.Trim() : " "));
                    para[21] = new SqlParameter("@TOF_Other", txtFacultyOther.Text.Trim());

                    para[22] = new SqlParameter("@B1", B1.Text.Trim());
                    para[23] = new SqlParameter("@B2", B2.Text.Trim());
                    para[24] = new SqlParameter("@B3", B3.Text.Trim());

                    para[25] = new SqlParameter("@B4", B4.Text.Trim());
                    para[26] = new SqlParameter("@B4Percentage", txtSectionBpercentage.Text.Trim());
                    para[27] = new SqlParameter("@B5", B5.Text.Trim());
                    para[28] = new SqlParameter("@B6", B6.Text.Trim());
                    para[29] = new SqlParameter("@B7", B7.Text.Trim());
                    para[30] = new SqlParameter("@B8", B8.Text.Trim());
                    para[31] = new SqlParameter("@B9", B9.Text.Trim());
                    para[32] = new SqlParameter("@B10", B10.Text.Trim());
                    para[33] = new SqlParameter("@B11", B11.Text.Trim());
                    para[34] = new SqlParameter("@B12", B12.Text.Trim());
                    para[35] = new SqlParameter("@B13", B13.Text.Trim());
                    para[36] = new SqlParameter("@B14", B14.Text.Trim());
                    para[37] = new SqlParameter("@B15", B15.Text.Trim());
                    para[38] = new SqlParameter("@B16", B16.Text.Trim());
                    para[39] = new SqlParameter("@B17", B17.Text.Trim());
                    para[40] = new SqlParameter("@B18", B18.Text.Trim());
                    para[41] = new SqlParameter("@B19", B19.Text.Trim());
                    para[42] = new SqlParameter("@B20", B20.Text.Trim());

                    para[43] = new SqlParameter("@Manufacturing_HighTect", ddlManufacturing.Text.Trim());
                    para[44] = new SqlParameter("@Manufacturing_Product", txtManufacturProduct.Text.Trim());
                    para[45] = new SqlParameter("@Distribution_HighTect", ddlfaultyDistribution.Text.Trim());
                    para[46] = new SqlParameter("@Distribution_Product", txtDistributionProduct.Text.Trim());
                    para[47] = new SqlParameter("@Please_Describe", txtotherDiscribe.Text.Trim());
                    para[48] = new SqlParameter("@City", txtCity.Text.Trim());

                    dal.executeprocedure("SP_RiskSurvey1", para);

                    // Updateid();
                    //Server.Transfer("RiskAssessmentSurvey2.aspx");
                    Response.Redirect("RiskAssessmentSurvey2.aspx");

                }
                else
                {
                    lblerror.Visible = true;
                    lblerror.Text = "Please Fill the Client Name..!";
                }               
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }


        private String RiskSurveyid()
        {
            String id = string.Empty;

            SqlDataReader drid = dal.getDataReader("Select Code from Log where ID='RiskSurvey'");
            if (drid.Read())
            {
                id = drid.GetValue(0).ToString().Trim();
                drid.Close();
                return id;
                
            }
            drid.Close();
            return id;
           
        }
        private void Updateid()
        {
            string UpdateCode = string.Empty;
            int Code = Convert.ToInt32(lblid.Text);
            UpdateCode=Convert.ToString(++Code);
            dal.executesql("Update Log set Code='" + UpdateCode + "' Where ID='RiskSurvey' ");

        }



    }
}
