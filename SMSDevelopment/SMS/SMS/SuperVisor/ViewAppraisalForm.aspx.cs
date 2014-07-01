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
using System;

namespace SMS.SuperVisor
{
    public partial class ViewAppraisalForm : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            String iBTID = string.Empty;

            if (!IsPostBack)
            {
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

        private void PopulatePageCntrls(String argsBGID)
        {

            DataSet dspan = dal.getdataset("Select Name,Date,Self_Adequate,Self_Adequate_No,Self_JobDescription,Self_Material,Self_Material_No,Self_Area,Self_Area_yes,Self_OtherPosition,Self_OtherPosition_yes,Company_Direction,Company_Direction_No,Company_Area,Company_Area_yes,Company_Identify,Company_Identify_yes,Management_Area,Management_Area_yes,NRICno,Location_id  from tblSOAppraisal where SOAppra_ID = '" + argsBGID + "' ");
            if (dspan.Tables[0].Rows.Count > 0)
            {

               txtName.Text = dspan.Tables[0].Rows[0][0].ToString().Trim();
               txtDate.Text = dspan.Tables[0].Rows[0][1].ToString().Trim();
               txtAdequateTraining.Text = dspan.Tables[0].Rows[0][2].ToString().Trim();
               txtAdequateNo.Text = dspan.Tables[0].Rows[0][3].ToString().Trim();

               txtjobDescription.Text = dspan.Tables[0].Rows[0][4].ToString().Trim();
               txtSufficientMaterials.Text = dspan.Tables[0].Rows[0][5].ToString().Trim();
               txtNoSufficientMaterial.Text = dspan.Tables[0].Rows[0][6].ToString().Trim();
               txtotherArea.Text = dspan.Tables[0].Rows[0][7].ToString().Trim();

               txtyesotherArea.Text = dspan.Tables[0].Rows[0][8].ToString().Trim();
               txtotherposition.Text = dspan.Tables[0].Rows[0][9].ToString().Trim();


               txtyesotherposition.Text = dspan.Tables[0].Rows[0][10].ToString().Trim();
               txtcurrentCompany.Text = dspan.Tables[0].Rows[0][11].ToString().Trim();
               txtNocurrentCompany.Text = dspan.Tables[0].Rows[0][12].ToString().Trim();
               txtcompanyArea.Text = dspan.Tables[0].Rows[0][13].ToString().Trim();
               txtyescompanyArea.Text = dspan.Tables[0].Rows[0][14].ToString().Trim();
               txtcompanyidentify.Text = dspan.Tables[0].Rows[0][15].ToString().Trim();


               txtyescompanyidentify.Text = dspan.Tables[0].Rows[0][16].ToString().Trim();
               txtmanagementneeds.Text = dspan.Tables[0].Rows[0][17].ToString().Trim();
               txtyesmanagementneed.Text = dspan.Tables[0].Rows[0][18].ToString().Trim();

               txtNric.Text = dspan.Tables[0].Rows[0][19].ToString().Trim();
               txtlocation.Text = getLocationNameById(dspan.Tables[0].Rows[0][20].ToString().Trim());

            }

        }
        private string getLocationNameById(string Name)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Location_id", Name);
            DataTable dsLocationName = dal.executeprocedure("sp_getLocationNameByID", para, false);
            if (dsLocationName.Rows.Count > 0)
            {
               return dsLocationName.Rows[0][0].ToString().Trim();
            }
            return null;
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





    }
}
