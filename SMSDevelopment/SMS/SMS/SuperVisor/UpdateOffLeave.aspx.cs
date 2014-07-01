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
    public partial class UpdateOffLeave : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                fillLeaveType();

                String iBTID = string.Empty;
                if (!IsPostBack)
                {
                    if (HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL] != null)
                    {
                        string strURL = HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL].ToString();
                        //((SMSmaster)this.Master).FilterContent(strURL, btnsave.ID, SMSAppUtilities.SMSAppEnums.ContentType.Update);
                    }
                    if (HttpContext.Current.Items[ContextKeys.CTX_BT_ID] != null)
                    {
                        iBTID = iBTID = HttpContext.Current.Items[ContextKeys.CTX_BT_ID].ToString();
                    }

                    PopulatePageCntrls(iBTID);
                    
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private void PopulatePageCntrls(String argsBGID)
        {
            DataSet dspan = dal.getdataset("Select * from OffLeaveApplication where Leave_id = '" + argsBGID + "' ");
            if (dspan.Tables[0].Rows.Count > 0)
            {
                  txtID.Text = argsBGID;
                  txtname.Text = dspan.Tables[0].Rows[0]["Name"].ToString().Trim();
                  txtNRICno.Text = dspan.Tables[0].Rows[0]["NRIC"].ToString().Trim();
                  txtAssignment.Text = dspan.Tables[0].Rows[0]["Assignment"].ToString().Trim();
                  txtDateofApplication.Text = dspan.Tables[0].Rows[0]["DateOfApplication"].ToString().Trim();

                  txtdatefrom.Text = dspan.Tables[0].Rows[0]["LeaveFromDate"].ToString().Trim();
                  txtdateto.Text = dspan.Tables[0].Rows[0]["LeaveToDate"].ToString().Trim();
                  ddlApproved.Text = dspan.Tables[0].Rows[0]["Approved_Status"].ToString().Trim();
                  txtLeaveReason.Text = dspan.Tables[0].Rows[0]["Leave_Reason"].ToString().Trim();

                  ddlTypeOfLeave.Text = dspan.Tables[0].Rows[0]["LeaveType"].ToString().Trim();
                  ddlleaveDayCount.Text = dspan.Tables[0].Rows[0]["LeaveDayCount"].ToString().Trim();
                  txtramainingday.Text = dspan.Tables[0].Rows[0]["RemainingDays"].ToString().Trim();
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                dal.executesql("Update OffLeaveApplication Set Name ='" + txtname.Text.Trim() + "',NRIC='" + txtNRICno.Text.Trim() + "',Assignment='" + txtAssignment.Text.Trim() + "',DateOfApplication='" + txtDateofApplication.Text.Trim() + "',LeaveFromDate='" + txtdatefrom.Text.Trim() + "',LeaveToDate='" + txtdateto.Text.Trim() + "',Approved_Status='" + ddlApproved.Text.Trim() + "',LeaveDayCount='"+ddlleaveDayCount.Text.Trim()+"' where Leave_id = '" + txtID.Text.Trim() + "' ");

                dal.executesql("Update OffleaveSetting set RemaingDay='" + txtramainingday.Text + "' where StaffName ='" + txtname.Text.Trim() + "'");
                Server.Transfer("AdminSuperOffLeave.aspx"); 
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Server.Transfer("AdminSuperOffLeave.aspx"); 
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


                //DataSet ds = dal.getdataset("select Description from log where ID='LeaveType'");               
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
                    }
                }

                else
                {
                   // txtAddVechicleType.Text = "";
                    lblErrMsg.Visible = true;
                    lblErrMsg.Text = "This Type already exist ..!";
                    lblErrMsg.Visible = true;
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
            ddlTypeOfLeave.Items.Add(" ");
            string ID = "LeaveType";
            SqlParameter[] para1 = new SqlParameter[1];
            para1[0] = new SqlParameter("@ID", ID);
            DataTable dt1 = dal.executeprocedure("sp_getLogvaluebyID", para1, true);


           // DataSet dsleave = dal.getdataset("Select Description from log where ID='LeaveType' ");
            if (dt1.Rows.Count > 0)
            {
                for (int k = 0; k < dt1.Rows.Count; k++)
                {
                    ddlTypeOfLeave.Items.Add(dt1.Rows[k][0].ToString().Trim());
                }
            }
        }



    }
}
