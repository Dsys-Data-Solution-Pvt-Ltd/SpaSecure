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
using System.Text.RegularExpressions;

using SMS.BusinessEntities;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;


namespace SMS.SMSUsers
{
    public partial class AlertHandling : System.Web.UI.Page
    {
        SqlConnection cn;
        AdminDAL a = new AdminDAL();
        int i = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
        log4net.ILog logger = log4net.LogManager.GetLogger("File");
        try
        {
            txtAddNRIC.Focus();
            lblerror.Visible = false;
            lblerr.Visible = false;
            lblerr1.Visible = false;
           
           
            cn = a.getconnection();

            if (ddlRole.Text == "")
            {
                String q;
                q = "select Description from log where ID='alerttype'";
                SqlCommand cmd = new SqlCommand(q, cn);
                SqlDataReader rec = cmd.ExecuteReader();
                while (rec.Read())
                {
                    if (!IsPostBack)
                    ddlRole.Items.Add(rec.GetValue(0).ToString());
                }
                rec.Close();
            }

            if (ddlRole0.Text == "")
            {
                String q1;
                q1 = "select Description from log where ID='departmentname'";
                SqlCommand cmd1 = new SqlCommand(q1, cn);
                SqlDataReader rec1 = cmd1.ExecuteReader();
                while (rec1.Read())
                {
                    if (!IsPostBack)
                        ddlRole0.Items.Add(rec1.GetValue(0).ToString());
                }
                rec1.Close();
            }
          
        }
        catch (Exception ex)
        {
            logger.Info(ex.Message);
        }

        }

        protected void btnNewItemAdd_Click(object sender, EventArgs e)
        {
           log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
             String ZipRegex = "^[0-9]+$";
             //if (Regex.IsMatch(txtAddNRIC.Text, ZipRegex))
             // {
                   AddAlertHandling objAddAlertHandling = new AddAlertHandling();
                   AlertHandlingUser objAH = new AlertHandlingUser();


                       String d = txtbynric.Text;
                       String x = "select NRICno from UserInformation";
                       SqlCommand cmd4 = new SqlCommand(x, cn);
                       SqlDataAdapter adp4 = new SqlDataAdapter(cmd4);
                       DataSet ds4 = new DataSet();
                       adp4.Fill(ds4);
                       int count1 = ds4.Tables[0].Rows.Count;
                       for (i = 0; i < count1; i++)
                       {
                           String z = ds4.Tables[0].Rows[i].ItemArray[0].ToString();
                           if (string.Equals(d, z, StringComparison.CurrentCultureIgnoreCase))
                           {


                               String d1 = txtAddNRIC.Text;
                               String x1 = "select NRIC_no from Alert_Handling";
                               SqlCommand cmd3 = new SqlCommand(x1, cn);
                               SqlDataAdapter adp = new SqlDataAdapter(cmd3);
                               DataSet ds = new DataSet();
                               adp.Fill(ds);
                               int count = ds.Tables[0].Rows.Count;
                               for (i = 0; i < count; i++)
                               {
                                   String z1 = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                                   if (string.Equals(d1, z1, StringComparison.CurrentCultureIgnoreCase))
                                   {
                                       lblerror.Visible = true;
                                       lblerror.Text = "NRIC/FIN No. already exist ..!";
                                       lblerr.Visible = true;
                                       throw new Exception();
                                   }

                               }

                               objAH.Alert_Type = ddlRole.Text;
                               objAH.Name = txtAddItemDesc.Text;
                               objAH.NRIC_no = txtAddNRIC.Text;
                               objAH.Company = txtAddCompany.Text;
                               objAH.Vehicle_no = txtAddVehicle.Text;
                               objAH.Message = txtmessage.Text;

                               objAH.Name1 = txtname.Text;
                               objAH.Designation = txtdesignation.Text;
                               //objAH.Department = txtdepartment.Text;
                               objAH.phone = txtphone.Text;
                               objAH.Bynricno = txtbynric.Text;
                               objAH.Date_From = Convert.ToDateTime(DateTime.Now);


                               AdminBLL ws = new AdminBLL();
                               ws.AddAlertHandling(objAH);
                               HttpContext.Current.Items.Add("COMPLETE", "INSERT");
                               Server.Transfer("..//SMSADMIN//AlertUpdateComplete.aspx");


                             }
                         }
                             lblerror.Visible = true;
                             lblerror.Text = "No Exist NRIC/FIN No. ..!";
                             lblerr1.Visible = true; 
                //       }
                //else
                //{
                //    lblerror.Visible = true;
                //    lblerror.Text = "Invalid NRIC/FIN No. ..!";
                //    lblerr.Visible = true;
                //}
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
                txtAddCompany.Text = "";
                txtAddItemDesc.Text = "";
                txtAddNRIC.Text = "";
                txtAddVehicle.Text = "";
                //txtdepartment.Text = "";
                txtdesignation.Text = "";
                txtmessage.Text = "";
                txtname.Text = "";
                txtphone.Text = "";
                ddlRole.Text = "";
                ddlRole0.Text = "";

             }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
    }
}
