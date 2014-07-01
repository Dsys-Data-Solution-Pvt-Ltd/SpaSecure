using System;
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
using SMS.Services.DataService;

using log4net;
using log4net.Config;

using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;

using SMS.SMSAppUtilities;
using SMS.BusinessEntities;

namespace SMS.SuperVisor
{
    public partial class UpdateEmergencyContact : System.Web.UI.Page
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
                    if (HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL] != null)
                    {
                        string strURL = HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL].ToString();
                        //((SMSmaster)this.Master).FilterContent(strURL, btnSave.ID, SMSAppUtilities.SMSAppEnums.ContentType.Update);
                    }
                    if (HttpContext.Current.Items[ContextKeys.CTX_BT_ID] != null)
                    {
                        iBTID = iBTID = HttpContext.Current.Items[ContextKeys.CTX_BT_ID].ToString();
                    }
                    getLocationName();
                    PopulatePageCntrls(iBTID);
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private string getLocationIDByName(string Name)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Location_name", Name);
            DataTable dsLocationID = dal.executeprocedure("sp_GetLocationIDbyName", para, false);
            if (dsLocationID.Rows.Count > 0)
            {
                return dsLocationID.Rows[0][0].ToString().Trim();
            }
            return null;
        }

        private void getLocationName()
        {
            ddllocation.Items.Clear();
            ddllocation.Items.Add("");
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
                ddllocation.Items.Insert(0,(dsLocationName.Rows[0][0].ToString().Trim()));
            }
        }


        private void PopulatePageCntrls(String argsBGID)
        {
            DataSet dspan = dal.getdataset("Select name,Position,Mobile_No,Office_No,Home_No,Extension,Location_id from EmergencyContact where Emg_id = '" + argsBGID + "' ");
            if (dspan.Tables[0].Rows.Count > 0)
            {
               searchid.Text = argsBGID;
               txtName.Text = dspan.Tables[0].Rows[0]["name"].ToString().Trim();
               txtPosition.Text = dspan.Tables[0].Rows[0]["Position"].ToString().Trim();
               txtmobileno.Text = dspan.Tables[0].Rows[0]["Mobile_No"].ToString().Trim();

               txtofficeno.Text = dspan.Tables[0].Rows[0]["Office_No"].ToString().Trim();
               txthomeno.Text = dspan.Tables[0].Rows[0]["Home_No"].ToString().Trim();
               txtGrade.Text = dspan.Tables[0].Rows[0]["Extension"].ToString().Trim();
               getLocationNameById(dspan.Tables[0].Rows[0]["Location_id"].ToString().Trim());
               
            }
        }     

        protected void btnSave_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (ddllocation.Text.Trim() != "")
                {
                    int locationid = Convert.ToInt32(getLocationIDByName(ddllocation.Text.Trim()));
                    dal.executesql("Update EmergencyContact Set name ='" + txtName.Text.Trim() + "',Position ='" + txtPosition.Text.Trim() + "',Mobile_No='" + txtmobileno.Text.Trim() + "',Office_No='" + txtofficeno.Text.Trim() + "',Home_No='" + txthomeno.Text.Trim() + "',Extension='" + txtGrade.Text.Trim() + "',Location_id=" + locationid + " where Emg_id = '" + searchid.Text.Trim() + "' ");
                    Server.Transfer("AdminListEmergencyContact.aspx");
                }
                else
                {
                    lblerror.Visible = true;
                    lblerror.Text = "Please Fill Location...";
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Server.Transfer("AdminListEmergencyContact.aspx");
        }


    }
}
