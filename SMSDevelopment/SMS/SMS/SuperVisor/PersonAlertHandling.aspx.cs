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
//using Microsoft.SqlServer.Management.Trace;

using log4net;
using log4net.Config;
using System.Text.RegularExpressions;

using SMS.BusinessEntities;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;

namespace SMS.SuperVisor
{
    public partial class PersonAlertHandling : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        AdminDAL a = new AdminDAL();
        int i = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                txtP_NricNo.Focus();
                lblerror.Visible = false;
                lblerr.Visible = false;
                lblerr1.Visible = false;

                if (!IsPostBack)
                {
                    fillDepartment();

                    if (Session["ManagementRole"].ToString().ToLower() == "superuser" || Session["ManagementRole"].ToString().ToLower() == "super security officer")
                    {
                        fillLocation();
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

        #region PrivateMethod

        private void fillAlert()
        {
            ddlAlertreason.Items.Clear();
            ddlAlertreason.Items.Add(" ");
            DataSet dsAlert = dal.getdataset("select Description from log where ID='alerttype'");
            if (dsAlert.Tables[0].Rows.Count > 0)
            {
                for (int k = 0; k < dsAlert.Tables[0].Rows.Count; k++)
                {
                    ddlAlertreason.Items.Add(dsAlert.Tables[0].Rows[k][0].ToString());
                }
            }
        }
        private void fillDepartment()
        {
            ddlRole0.Items.Clear();
            ddlRole0.Items.Add(" ");
            DataSet dsdepartment = dal.getdataset("select Description from log where ID='departmentname'");
            if (dsdepartment.Tables[0].Rows.Count > 0)
            {
                for (int k = 0; k < dsdepartment.Tables[0].Rows.Count; k++)
                {
                    ddlRole0.Items.Add(dsdepartment.Tables[0].Rows[k][0].ToString());
                }
            }
        }
        private void fillLocation()
        {
            ddllocation.Items.Clear();
            ddllocation.Items.Add(" ");
            DataSet dsdepartment = dal.getdataset("select Location_name from location order by Location_name Asc");
            if (dsdepartment.Tables[0].Rows.Count > 0)
            {
                for (int k = 0; k < dsdepartment.Tables[0].Rows.Count; k++)
                {
                    ddllocation.Items.Add(dsdepartment.Tables[0].Rows[k][0].ToString());
                }
            }
        }

        private string locationId(string locName)
        {
            string h = string.Empty;
            DataSet dsid = dal.getdataset("select Location_id from location where Location_name ='" + locName + "'");
            if (dsid.Tables[0].Rows.Count > 0)
            {
                for (int k = 0; k < dsid.Tables[0].Rows.Count; k++)
                {
                    h = dsid.Tables[0].Rows[k][0].ToString();
                    return h;
                }
            }
            return h;
        }

        #endregion


        protected void btnNewItemAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (txtP_NricNo.Text != "" && txtbynric.Text != "")
                {
                    lblerror.Visible = false;
                    AddAlertHandling objAddAlertHandling = new AddAlertHandling();
                    AlertHandlingUser objAH = new AlertHandlingUser();
                    objAH.Location_id = locationId(ddllocation.Text.Trim());
                    objAH.P_NRIC_no = txtP_NricNo.Text;
                    objAH.P_Name = txtP_name.Text;
                    objAH.P_Nationality = txtnationality.Text;
                    objAH.P_Passport = txtP_Passport.Text;

                    objAH.Alert_Type = ddlAlertreason.Text.Trim();
                    objAH.Comment = txtmessage.Text;

                    objAH.AlertBy_Name = txtname.Text;
                    objAH.AlertBy_NRICNo = txtbynric.Text;
                    objAH.AlertDepartment = ddlRole0.Text;
                    objAH.AlertDesignation = txtdesignation.Text;
                    objAH.AlertContNo = txtphone.Text;

                    objAH.V_Color = "";
                    objAH.V_OwnerName = "";
                    objAH.V_OwnerNricNo = "";
                    objAH.V_ResgistNo = "";
                    objAH.V_Type = "";
                    objAH.Date_From = Convert.ToDateTime(DateTime.Now);

                    AdminBLL ws = new AdminBLL();
                    ws.AddAlertHandling(objAH);
                    HttpContext.Current.Items.Add("COMPLETE", "INSERT");
                    Server.Transfer("..//SMSAdmin//AlertUpdateComplete.aspx");
                }
                else
                {
                    lblerror.Visible = true;
                    lblerr.Visible = true;
                    lblerr1.Visible = true;
                    lblerror.Text = "please fill all the fields!!!";
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnClearNewItemAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                AllClear();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private void AllClear()
        {
            txtP_NricNo.Text = "";
            txtP_name.Text = "";
            txtnationality.Text = "";
            txtP_Passport.Text = "";
            ddlAlertreason.Text = "";
            txtmessage.Text = "";
            txtdesignation.Text = "";
            txtname.Text = "";
            txtphone.Text = "";
            ddlRole0.Text = "";
            txtbynric.Text = "";
        }

        protected void cmdAddReason_Click(object sender, EventArgs e)
        {

        }

        protected void txtbynric_TextChanged(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (txtbynric.Text.Trim() != "")
                {
                    DataSet ds = dal.getdataset("Select FirstName,Role,Staff_Telphone from UserInformation where NRICno='" + txtbynric.Text.Trim() + "' ");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtname.Text = ds.Tables[0].Rows[0][0].ToString().Trim();
                        txtdesignation.Text = ds.Tables[0].Rows[0][1].ToString().Trim();
                        txtphone.Text = ds.Tables[0].Rows[0][2].ToString().Trim();
                    }

                }
                else
                {
                    txtname.Text = "";
                    txtphone.Text = "";
                    txtdesignation.Text = "";
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }


    }
}
