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


using log4net;
using log4net.Config;

using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.Services.DataService;
using SMS.SMSAppUtilities;
using SMS.BusinessEntities;
using MKB.TimePicker;
using MKB.Exceptions;

namespace SMS.SMSAdmin
{ 
    public partial class ShiftUpdate : System.Web.UI.Page
    {

        SqlConnection conn = new SqlConnection();
        
        SqlCommand cmd;
        private int numOfRows;       
        static int myCount=0;

        private TextBox[] dynamicTextBoxes;

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Control myControl = GetPostBackControl(this.Page);
            if ((myControl != null))
            {
                myCount = Convert.ToInt32(txtaddNumberofStaff.Text.ToString());
            }
        }
        protected override void OnInit(EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {

                base.OnInit(e);
                if (!string.IsNullOrEmpty(txtaddNumberofStaff.Text))
                {
                    myCount = (Convert.ToInt32(txtaddNumberofStaff.Text.ToString()));
                }

                dynamicTextBoxes = new TextBox[myCount];
                int i;
                int j;
                int count1 = 0;
                for (i = 0; i < myCount; i += 1)
                {
                    for (j = 0; j <= 2; j += 1)
                    {
                        if (count1 != myCount)
                        {
                            TextBox textBox = new TextBox();
                            textBox.ID = "myTextBox" + i.ToString() + j.ToString();
                            myPlaceHolder.Controls.Add(textBox);
                            dynamicTextBoxes[count1] = textBox;
                            count1++;
                        }
                    }
                    LiteralControl literalBreak = new LiteralControl("<br />");
                    myPlaceHolder.Controls.Add(literalBreak);
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }


        protected void MyButton_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {

                MyLabel.Text = "";
                foreach (TextBox tb in dynamicTextBoxes)
                {
                    MyLabel.Text += tb.Text + " :: ";
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        public static Control GetPostBackControl(Page thePage)
        {
            Control myControl = null;
            string ctrlName = thePage.Request.Params.Get("__EVENTTARGET");
            if (((ctrlName != null) & (ctrlName != string.Empty)))
            {
                myControl = thePage.FindControl(ctrlName);
            }
            else
            {
                foreach (string Item in thePage.Request.Form)
                {
                    Control c = thePage.FindControl(Item);
                    if (((c) is System.Web.UI.WebControls.Button))
                    {
                        myControl = c;
                    }
                }

            }
            return myControl;


        }


        protected void Page_Load(object sender, EventArgs e)
        {
            Int32 iBTID = 0;
          log4net.ILog logger = log4net.LogManager.GetLogger("File");
          try
           {

               lblStaffNumber.Visible = false;

            if (!IsPostBack)
            {
                
                if (HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL] != null)
                {
                    string strURL = HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL].ToString();
                    //((SMSmaster)this.Master).FilterContent(strURL, btnSave.ID, SMSAppUtilities.SMSAppEnums.ContentType.Update);
                }
                if (HttpContext.Current.Items[ContextKeys.CTX_BT_ID] != null)
                {
                    iBTID = Convert.ToInt32(HttpContext.Current.Items[ContextKeys.CTX_BT_ID]);
                }

                
                PopulatePageCntrls(iBTID);
                BindGrid(iBTID);
                GenerateTable(numOfRows);

            }
           }
          catch (Exception ex)
          {
              logger.Info(ex.Message);
          }
        }
        
        private void PopulatePageCntrls(int argsBGID)
        {

            Int32 iCount = 0;
            GetShiftDataResponse ret = null;
           log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            { 
                DateTime dt;
                AdminBLL objAdminBLL = new AdminBLL();
                GetShiftData objGetBillingTableRequest = new GetShiftData();
                objGetBillingTableRequest.Shift_ID = argsBGID.ToString();

                objGetBillingTableRequest.WhereClause = " where Shift_ID=" + argsBGID.ToString();


                ret = objAdminBLL.GetShift(objGetBillingTableRequest);

                hdnBTID.Value = ret.Shift_ID[iCount].Shift_ID.ToString();

                txtaddshiftID.Text = ret.Shift_ID[iCount].Shift_ID.ToString();
                txtaddshiftName.Text = ret.Shift_ID[iCount].shiftdep.ToString();
                txtaddLocationName.Text = ret.Shift_ID[iCount].Location.ToString();

                dt = Convert.ToDateTime(ret.Shift_ID[iCount].ShiftDateFrom);
                txtaddDateFrom.Text = Convert.ToString(dt);

                dt = Convert.ToDateTime(ret.Shift_ID[iCount].ShiftDateTo);
                txtaddDateTo.Text = Convert.ToString(dt);


                dt = Convert.ToDateTime(ret.Shift_ID[iCount].ShiftTimeFrom);
                TimeSelector1.Date = dt;

                dt = Convert.ToDateTime(ret.Shift_ID[iCount].ShiftTimeTo);
                TimeSelector2.Date = dt;
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void Add_ShiftUpdate(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            { 
                Shift objShift_Data = new Shift();
                AdminBLL ws = new AdminBLL();
                AdminDAL aa=new AdminDAL();
                SqlConnection conn = new SqlConnection();
                conn=aa.getconnection();
                DateTime datetime;

                objShift_Data.Shift_ID = txtaddshiftID.Text;
                objShift_Data.shiftdep = txtaddshiftName.Text;
                objShift_Data.ShiftDateFrom = DateTime.TryParse(txtaddDateFrom.Text, out datetime) ? (DateTime?)datetime : null; ;
                objShift_Data.ShiftDateTo = DateTime.TryParse(txtaddDateTo.Text, out datetime) ? (DateTime?)datetime : null; ;
                objShift_Data.ShiftTimeFrom =TimeSelector1.Date.TimeOfDay.ToString();
                objShift_Data.ShiftTimeTo = TimeSelector2.Date.TimeOfDay.ToString();
                objShift_Data.Location = txtaddLocationName.Text;


                AddNewStaffShiftRequest objstaffshift = new AddNewStaffShiftRequest();
                Staff_Shift objStaff = new Staff_Shift();

             
               User_Info objuser=new User_Info();
               
                foreach (TextBox tb in dynamicTextBoxes)
                {
                    string ss = Convert.ToString(objuser.Staff_ID);                   
                    SqlCommand cmd = new SqlCommand("select Staff_ID from userinformation", conn);                    
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                      ss=  rd.GetValue(0).ToString();

                      if (ss == tb.Text)
                        {

                            objStaff.Shift_ID = objShift_Data.Shift_ID;
                            objStaff.Staff_ID = tb.Text;
                            ws.AddStaffShift(objStaff);
                        }

                    }
                    rd.Close();
                }


                ws.UpdateShiftData(objShift_Data);

                HttpContext.Current.Items.Add(ContextKeys.CTX_COMPLETE, "UPDATE");
                Server.Transfer("AlertUpdateComplete.aspx"); 

               
            }
            catch (System.Threading.ThreadAbortException)
            {
           }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void BtnBack(object sender, EventArgs e)
        {
             log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            { 
                Response.Redirect(SMSAppUtilities.SMSAppUtilities.RetrieveMainURL("ShiftDeployment.aspx"));
            }
            catch (System.Threading.ThreadAbortException)
            {
           }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }


        protected void gvShiftUpdate_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //JS for delete btn
                    ImageButton Delete = (ImageButton)e.Row.FindControl("btnDelete");
                    Delete.Attributes.Add("onclick", "javascript:return " +
                        "confirm('Are you sure to delete this record?')");
                }
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    gvKeySearch.Columns[0].FooterText = "Total Records: 20";
                }
            }
            catch (System.Threading.ThreadAbortException)
            {
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void gvShiftUpdate_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            { 
                string _BTId = Convert.ToString(e.CommandArgument);
                if (e.CommandName == "DeleteRow")
                {
                    DeleteItem(_BTId);
                }
            }
            catch (System.Threading.ThreadAbortException)
            {
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
       }

        private void DeleteItem(string argStaffID)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            { 
                if (!string.IsNullOrEmpty(argStaffID))
                {
                    AdminBLL ws = new AdminBLL();
                    GetStaffShift _req = new GetStaffShift();

                    _req.StaffID = argStaffID.ToString();

                    ws.DeleteShiftStaff(_req);
                    HttpContext.Current.Items.Add(ContextKeys.CTX_COMPLETE, "DELETE");
                    Server.Transfer("AlertUpdateComplete.aspx");
                }
            }
            catch (System.Threading.ThreadAbortException)
            {
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }     

        protected void gvShiftUpdate_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            { 
                if (e.NewPageIndex >= 0)
                {
                    gvKeySearch.PageIndex = e.NewPageIndex;
                }
            }
            catch (System.Threading.ThreadAbortException)
            {
           }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private void BindGrid(int iBTID)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            { 
                AdminBLL ws = new AdminBLL();
                
                GetStaffShift _req = new GetStaffShift();            
                _req.ShiftID = iBTID.ToString();

              

                GetUserDataResponse _resp1 = ws.GetShiftKey(_req);

                int pageSize = ContextKeys.GRID_PAGE_SIZE;
                gvKeySearch.PageSize = pageSize;
                gvKeySearch.DataSource = _resp1.UserID;             
                gvKeySearch.DataBind();
               }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

        }

        protected void btnTotalStaffNo_Click(object sender, EventArgs e)
        {

        }


        private void GenerateTable(int rowsCount)
        {
        }

        protected void txtaddNumberofStaff_TextChanged(object sender, EventArgs e)
        {
            myCount = Convert.ToInt32(txtaddNumberofStaff.Text.ToString());
            lblStaffNumber.Visible = true;
        }

        protected void gvShiftUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
