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

using log4net;
using log4net.Config;
using SMS.Services.DataService;
using System.Data.SqlClient;

using SMS.BusinessEntities;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using MKB.TimePicker;
using MKB.Exceptions;
using System.Text.RegularExpressions;

namespace SMS.SuperVisor
{
    public partial class SecurityOfficerAppraisal : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                lblerror.Visible = false;
                if (!IsPostBack)
                {
                    string staffid = Session["StaffID"].ToString();                    
                    fillNameandNRIC(staffid);
                    if (Session["ManagementRole"].ToString().ToLower() == "superuser")
                    {
                        getLocationName();
                    }
                    else
                    {
                        getLocationNameById(Session["LCID"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        private void getLocationIDByName(string Name)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Location_name", Name);
            DataTable dsLocationID = dal.executeprocedure("sp_GetLocationIDbyName", para, false);
            if (dsLocationID.Rows.Count > 0)
            {
                searchid.Text = dsLocationID.Rows[0][0].ToString().Trim();
            }
        }

        private void getLocationName()
        {
            ddllocation.Items.Clear();
            ddllocation.Items.Add(" ");
            SqlParameter[] para = new SqlParameter[0];            
            DataTable dsLocation = dal.executeprocedure("sp_FillLocationName", para, false);
            if (dsLocation.Rows.Count > 0)
            {
                for (int k = 0; k < dsLocation.Rows.Count; k++)
                {
                    ddllocation.Items.Add(dsLocation.Rows[k][0].ToString().Trim());
                }
            }
        }

        private void getLocationNameById(string Name)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Location_id", Name);
            DataTable dsLocationName = dal.executeprocedure("sp_getLocationNameByID", para, false);
            if (dsLocationName.Rows.Count > 0)
            {
                ddllocation.Items.Add(dsLocationName.Rows[0][0].ToString().Trim());
            }
        }
        private void fillNameandNRIC(string id)
        {
            DataSet dsuserinfo = dal.getdataset("Select FirstName,MiddleName,LastName,NRICno from Userinformation where Staff_ID='" + id + "' ");
            if (dsuserinfo.Tables[0].Rows.Count > 0)
            {
                txtStaffName.Text = dsuserinfo.Tables[0].Rows[0]["FirstName"].ToString();
                txtStaffName.Text += "";
                txtStaffName.Text += dsuserinfo.Tables[0].Rows[0]["MiddleName"].ToString();
                txtStaffName.Text += "";
                txtStaffName.Text += dsuserinfo.Tables[0].Rows[0]["LastName"].ToString();
                txtNric.Text = dsuserinfo.Tables[0].Rows[0]["NRICno"].ToString();              
            }

        }


        protected void ddlSufficientMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
               if(ddlSufficientMaterial.Text == "No")
               {
                   pnlSufficientMaterial.Visible = true;
               }
                else
               {
                   pnlSufficientMaterial.Visible = false;
               }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (txtStaffName.Text.Trim() != "")
                {
                    if (txtNric.Text.Trim() != "")
                    {
                        getLocationIDByName(ddllocation.Text.Trim());
                        SqlParameter[] para = new SqlParameter[21];
                        para[0] = new SqlParameter("@Name", txtStaffName.Text.Trim());
                        para[1] = new SqlParameter("@Date",DateTime.Now);
                        para[2] = new SqlParameter("@Self_Adequate", ddlAdequateTraining.Text.Trim());
                        para[3] = new SqlParameter("@Self_Adequate_No", txtAdequateNo.Text.Trim());
                        para[4] = new SqlParameter("@Self_JobDescription", ddljobDescription.Text.Trim());
                        para[5] = new SqlParameter("@Self_Material", ddlSufficientMaterial.Text.Trim());

                        para[6] = new SqlParameter("@Self_Material_No", txtNoSufficientMaterial.Text.Trim());
                        para[7] = new SqlParameter("@Self_Area", ddlotherArea.Text.Trim());
                        para[8] = new SqlParameter("@Self_Area_yes", txtyesotherArea.Text.Trim());
                        para[9] = new SqlParameter("@Self_OtherPosition", ddlotherposition.Text.Trim());
                        para[10] = new SqlParameter("@Self_OtherPosition_yes", txtyesotherposition.Text.Trim());

                        para[11] = new SqlParameter("@Company_Direction", ddCompanyCurrent.Text.Trim());
                        para[12] = new SqlParameter("@Company_Direction_No", txtNocurrentCompany.Text.Trim());
                        para[13] = new SqlParameter("@Company_Area", ddlCompanyArea.Text.Trim());
                        para[14] = new SqlParameter("@Company_Area_yes", txtyescompanyArea.Text.Trim());
                        para[15] = new SqlParameter("@Company_Identify", ddlcompanyidentify.Text.Trim());
                        para[16] = new SqlParameter("@Company_Identify_yes", txtyescompanyidentify.Text.Trim());

                        para[17] = new SqlParameter("@Management_Area", ddlmanagementneed.Text.Trim());
                        para[18] = new SqlParameter("@Management_Area_yes", txtyesmanagementneed.Text.Trim());
                        para[19] = new SqlParameter("@NRICno", txtNric.Text.Trim());
                        para[20] = new SqlParameter("@Location_id", searchid.Text.Trim());

                        dal.executeprocedure("SP_AddApprisal", para);


                        HttpContext.Current.Items.Add("COMPLETE", "INSERT");
                        Server.Transfer("CompleteForm.aspx");
                    }
                    else
                    {
                        lblerror.Visible = true;
                        lblerror.Text = "Invalid NRIC No....";
                    }
                }
                else
                {
                    lblerror.Visible = true;
                    lblerror.Text = "Invalid Name....";
                }

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {                
               // calDate.Text = "";
                ddlAdequateTraining.Text = "";
                txtAdequateNo.Text = "";
                ddljobDescription.Text = "";
                ddlSufficientMaterial.Text = "";

                txtNoSufficientMaterial.Text = "";
                ddlotherArea.Text = "";
                txtyesotherArea.Text = "";
                ddlotherposition.Text = "";
                txtyesotherposition.Text = "";

                ddCompanyCurrent.Text = "";
                txtNocurrentCompany.Text = "";
                ddlCompanyArea.Text = "";
                txtyescompanyArea.Text = "";
                ddlcompanyidentify.Text = "";
                txtyescompanyidentify.Text = "";

                ddlmanagementneed.Text = "";
                txtyesmanagementneed.Text = "";
             }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

       



    }
}
