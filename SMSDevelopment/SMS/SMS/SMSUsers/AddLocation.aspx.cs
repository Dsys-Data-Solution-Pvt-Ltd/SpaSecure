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
using System.Text.RegularExpressions;

using Microsoft.SqlServer.Management.Trace;
using log4net;
using log4net.Config;
using SMS.Services.DataService;
using System.Data.SqlClient;

using SMS.BusinessEntities;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;

namespace SMS
{
    public partial class AddLocation : System.Web.UI.Page
    {
        SqlConnection cn;
        AdminDAL a = new AdminDAL();
        AdminBLL b = new AdminBLL();
        String column = string.Empty;
        String table = string.Empty;
        String where = string.Empty;
        int i = 0;

        DataAccessLayer dal = new DataAccessLayer();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                txtAddLocationName1.Focus();
                fillno();
                lblerror.Visible = false;
                lblerr.Visible = false;
                lblerr2.Visible = false;

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private void fillno()
        {
            if (IsPostBack == false)
            {

                string pre = string.Empty;
                string sep = "L";
                int rcode = 0;
                int length = 0;
                string final = string.Empty;
                DataSet ds = new DataSet();
                ds = dal.getdataset("Select id from AutogenCode where descript='Location' ");

                pre = ds.Tables[0].Rows[0][0].ToString();
                length = Convert.ToInt32(pre.Length);

                rcode = Convert.ToInt32(pre.Substring(1, length - 1));
                rcode++;

                final = sep + Convert.ToString(rcode);

                txtAddLocationName.Text = final;
            }

        }





        protected void Add_Location(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                AddNewLocationRequest objAddLocationRequest = new AddNewLocationRequest();
                LocationData objlocation = new LocationData();
                String zipreg = "^[a-z A-Z]+$";
                String ZipRegex = "^[0-9]+$";
                String ZipRegexboth = "^[a-z A-Z 0-9]+$";

                // if (Regex.IsMatch(txtAddLocationName.Text, ZipRegexboth))
               // {
                    if (Regex.IsMatch(txtAddLocationName1.Text, zipreg))
                    {


                        column = "locid";
                        table = "location";
                        where = "where locid='" + txtAddLocationName.Text + "'";
                        if (b.isexistBLL(column, table, where))
                        {
                            lblerror.Visible = true;
                            lblerror.Text = "Location Code Already Exist ..!";
                            lblerr.Visible = true;
                            throw new Exception();
                        }

                        column = "loc";
                        table = "location";
                        where = "where loc='" + txtAddLocationName1.Text + "'";
                        if (b.isexistBLL(column, table, where))
                        {
                            lblerror.Visible = true;
                            lblerror.Text = "Location Name Already Exist ..!";
                            lblerr2.Visible = true;
                            throw new Exception();
                        }



                        objlocation.locid = txtAddLocationName.Text;
                        objlocation.loc = txtAddLocationName1.Text;
                        objlocation.Date_From = Convert.ToDateTime(DateTime.Now);

                        AdminBLL ws = new AdminBLL();
                        ws.AddLocation(objlocation);
                        UpdateAutogenCode();
                        HttpContext.Current.Items.Add("COMPLETE", "INSERT");
                        Server.Transfer("..//SMSADMIN//AlertUpdateComplete.aspx");

                    }
                    else
                    {
                        lblerror.Visible = true;
                        lblerror.Text = "Invalid Location Name ..!";
                        lblerr2.Visible = true;
                    }
                //}
                //else
                //{
                //    lblerror.Visible = true;
                //    lblerror.Text = "Invalid Location Code ..!";
                //    lblerr.Visible = true;
                //}
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

        }


        private void UpdateAutogenCode()
        {
            DataSet dsupage = dal.getdataset("Update AutogenCode set id ='" + txtAddLocationName.Text.Trim() + "' where Descript='Location' ");
        }



        protected void btnClearLocationAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                txtAddLocationName.Text = "";
                txtAddLocationName1.Text = "";

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }



    }
}
