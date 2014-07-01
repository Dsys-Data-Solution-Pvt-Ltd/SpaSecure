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

//using Microsoft.SqlServer.Management.Trace;
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
    public partial class OffLeaveApplication : System.Web.UI.Page
    {

        DataAccessLayer dal = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                lblerror.Visible = true;
                if (!IsPostBack)
                {
                    string staffid = Session["StaffID"].ToString();                    
                    fillNameandNRIC(staffid);
                    fillLeaveType();
                    getLocationNameById(Session["LCID"].ToString());
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
              txtAssignment.Text = dsLocationName.Rows[0][0].ToString().Trim();
            }
        }


        private void fillNameandNRIC(string id)
        {
            DataSet dsuserinfo = dal.getdataset("Select FirstName,MiddleName,LastName,NRICno from Userinformation where Staff_ID='" + id + "' ");
            if (dsuserinfo.Tables[0].Rows.Count > 0)
            {
                txtname.Text = dsuserinfo.Tables[0].Rows[0]["FirstName"].ToString();
                txtname.Text += " ";
                txtname.Text += dsuserinfo.Tables[0].Rows[0]["MiddleName"].ToString();
                txtname.Text += " ";
                txtname.Text += dsuserinfo.Tables[0].Rows[0]["LastName"].ToString();
                txtNRICno.Text = dsuserinfo.Tables[0].Rows[0]["NRICno"].ToString();
            }
        }
        protected void btnNewItemAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (ddlTypeOfLeave.Text.Trim() != "")
                {
                    if (txtname.Text.Trim() != "")
                    {
                      if(ddlleaveDayCount.Text.Trim() != "")
                      {

                        string Status = "Pending";
                        SqlParameter[] para = new SqlParameter[12];
                        para[0] = new SqlParameter("@Name", txtname.Text.Trim());
                        para[1] = new SqlParameter("@NRIC", txtNRICno.Text.Trim());
                        para[2] = new SqlParameter("@Assignment", txtAssignment.Text.Trim());

                        para[3] = new SqlParameter("@DateOfApplication", txtDateofApplication.Text.Trim());
                        para[4] = new SqlParameter("@LeaveFromDate", txtdatefrom.Text.Trim());
                        para[5] = new SqlParameter("@LeaveToDate", txtdateto.Text.Trim());
                        para[6] = new SqlParameter("@Approved_Status", Status);
                        para[7] = new SqlParameter("@Leave_Reason", txtLeaveReason.Text.Trim());

                        para[8] = new SqlParameter("@LeaveType", ddlTypeOfLeave.Text.Trim());
                        para[9] = new SqlParameter("@LeaveDayCount", ddlleaveDayCount.Text.Trim());
                        para[10] = new SqlParameter("@SuperiorName", txtsuperiorOfficer.Text.Trim());
                        para[11] = new SqlParameter("@RemainingDays",txtramainingday.Text.Trim());

                        dal.executeprocedure("AddOffLeaveApplication", para);

                        lblerror.Visible = true;
                        lblerror.Text = "Insert Successfully ..!";

                        HttpContext.Current.Items.Add("COMPLETE", "INSERT");
                        Server.Transfer("..//SMSAdmin//AlertUpdateComplete.aspx");
                      }
                      else
                      {
                          lblerror.Visible = true;
                          lblerror.Text = "Please Select No.Days Applied..!";
                      }
                    }
                    else
                     {
                        lblerror.Visible = true;
                        lblerror.Text = "Please Fill The Name..!";
                     }
                }
                else
                {
                   lblerror.Visible = true;
                   lblerror.Text = "Please Select Leave Type..!";
                }

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
                DataTable dt1 = dal.executeprocedure("sp_getLogvaluebyID", para1, true);
              
                int count = dt1.Rows.Count;
                for (i = 0; i < count; i++)
                {
                    string f = dt1.Rows[i].ItemArray[0].ToString();

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
                    }
                }
                else
                {
                    // txtAddVechicleType.Text = "";
                    lblerror.Visible = true;
                    lblerror.Text = "This Type already exist ..!";
                    lblerror.Visible = true;
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        private void fillLeaveType()
        {
            ddlTypeOfLeave.Items.Clear();
            string ID = "LeaveType";
            SqlParameter[] para1 = new SqlParameter[1];
            para1[0] = new SqlParameter("@ID", ID);
            DataTable dt = dal.executeprocedure("sp_getLogvaluebyID", para1, true);           
            if (dt.Rows.Count > 0)
            {
                ddlTypeOfLeave.DataSource = dt;
                ddlTypeOfLeave.DataTextField = "Description";
                ddlTypeOfLeave.DataValueField = "Description";
                ddlTypeOfLeave.DataBind();
                ddlTypeOfLeave.Items.Insert(0, new ListItem("-Select-", "-Select-", true));
            }
        }

        protected void ddlleaveDayCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                int remainday = 0;
                int day = 0;
                int Appliedday = Convert.ToInt32(ddlleaveDayCount.Text);

                DataSet dspreissuedday = dal.getdataset("Select RemainingDays from OffLeaveApplication where LeaveType='" + ddlTypeOfLeave.Text.Trim() + "' and Approved_Status = 'Yes' and Name = '" + txtname.Text.Trim() + "' and NRIC = '" + txtNRICno.Text.Trim() + "' ");
                if (dspreissuedday.Tables[0].Rows.Count > 0)
                {
                    day = Convert.ToInt32(dspreissuedday.Tables[0].Rows[0][0].ToString());
                    remainday = day - Appliedday;
                    txtramainingday.Text = remainday.ToString();
                }
                else
                {

                    DataSet dscount = dal.getdataset("Select NoOfDay from OffleaveSetting where LeaveType='" + ddlTypeOfLeave.Text.Trim() + "' and StaffName = '" + txtname.Text.Trim() + "' ");
                    if (dscount.Tables[0].Rows.Count > 0)
                    {
                        day = Convert.ToInt32(dscount.Tables[0].Rows[0][0].ToString());
                        remainday = day - Appliedday;
                        txtramainingday.Text = remainday.ToString();
                    }
                    else
                    {
                        txtramainingday.Text = "";
                    }
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
                txtNRICno.Text = "";
                txtname.Text = "";
                txtramainingday.Text = "";
                txtsuperiorOfficer.Text = "";
                txtLeaveReason.Text = "";
                txtdateto.Text = "";
                txtDateofApplication.Text = "";
                txtdatefrom.Text = "";
                txtAssignment.Text = "";
                txtaddTypeOfLeave.Text = "";
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void ddlTypeOfLeave_SelectedIndexChanged(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                DataSet dsinfo = dal.getdataset("Select RemaingDay from OffleaveSetting where StaffName = '" + txtname.Text + "' and LeaveType ='" + ddlTypeOfLeave.Text.Trim() + "' ");
                if (dsinfo.Tables[0].Rows.Count > 0)
                {                  
                    txtramainingday.Text = dsinfo.Tables[0].Rows[0][0].ToString();                  
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

  }
}
