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
    public partial class AddNewOffLeave : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (!IsPostBack)
                {
                    fillLeaveType();
                    fillStaffName();
                }
            }

            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private void fillStaffName()
        {
           ddlStaffname.Items.Clear();

           DataSet dsdepartment = dal.getdataset("select (FirstName + ' ' + MiddleName + ' '+ LastName)as name from userinformation where role !='client' order by FirstName Asc");
            if (dsdepartment.Tables[0].Rows.Count > 0)
            {              
                ddlStaffname.DataSource = dsdepartment.Tables[0];
                ddlStaffname.DataTextField = "name";
                ddlStaffname.DataValueField = "name";
                ddlStaffname.DataBind();
                
                ddlStaffname.Items.Insert(0, new ListItem("-Select-", "-Select-", true));
            }
        }

        private void fillLeaveType()
        {
            ddlTypeOfLeave.Items.Clear();
            string ID = "LeaveType";
            SqlParameter[] para1 = new SqlParameter[1];
            para1[0] = new SqlParameter("@ID", ID);
            DataTable dt1 = dal.executeprocedure("sp_getLogvaluebyID", para1, true);           
          
            if (dt1.Rows.Count > 0)
            {
                ddlTypeOfLeave.DataSource = dt1;
                ddlTypeOfLeave.DataTextField = "Description";
                ddlTypeOfLeave.DataValueField = "Description";
                ddlTypeOfLeave.DataBind();           
                ddlTypeOfLeave.Items.Insert(0, new ListItem("-Select-", "-Select-", true));
            }
        }


        protected void btnNewItemAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {                
                SqlParameter[] para = new SqlParameter[7];
                para[0] = new SqlParameter("@LeaveType",ddlTypeOfLeave.Text.Trim());
                para[1] = new SqlParameter("@SuperiorName",txtsuperiorOfficer.Text.Trim());
                para[2] = new SqlParameter("@NoOfDay",txtNoOfday.Text.Trim());
                para[3] = new SqlParameter("@StaffName",ddlStaffname.Text.Trim());
                para[4] = new SqlParameter("@DateFrom", DateTime.Now);
                para[5] = new SqlParameter("@RemaingStatus","False");
                para[6] = new SqlParameter("@RemaingDay", txtNoOfday.Text.Trim());

                dal.executeprocedure("SP_addOffleaveSetting", para);               

                HttpContext.Current.Items.Add("COMPLETE", "INSERT");
                Server.Transfer("..//SMSAdmin//AlertUpdateComplete.aspx");

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnAddNewType_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                string g = txtaddTypeOfLeave.Text.Trim();
                int i = 0;
                string ID = "LeaveType";
                SqlParameter[] para1 = new SqlParameter[1];
                para1[0] = new SqlParameter("@ID", ID);
                DataTable dt = dal.executeprocedure("sp_getLogvaluebyID", para1, true);
                
                int count = dt.Rows.Count;
                for (i = 0; i < count; i++)
                {
                    string f = dt.Rows[i].ItemArray[0].ToString();

                    if (string.Equals(f, g, StringComparison.CurrentCultureIgnoreCase))
                    {
                        break;
                    }
                }
                i++;
                count++;
                if (i == count)
                {
                    if (txtaddTypeOfLeave.Text.Trim() != "")
                    {
                        dal.executesql("insert into log(ID,Code,Description) values('LeaveType'," + count + ",'" + txtaddTypeOfLeave.Text.Trim() + "') ");
                        fillLeaveType();
                        txtaddTypeOfLeave.Text = "";
                    }
                }

                else
                {                    
                    lblerror.Visible = true;
                    lblerror.Text = "This Type Already Exist...!";
                    lblerror.Visible = true;
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
                txtsuperiorOfficer.Text = "";
                txtNoOfday.Text = "";
                txtaddTypeOfLeave.Text = "";
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }


    }
}
