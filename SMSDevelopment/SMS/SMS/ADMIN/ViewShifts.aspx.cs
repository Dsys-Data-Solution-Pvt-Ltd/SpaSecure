using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMS.SMSAppUtilities;
using SMS.Services.DataService;
using Telerik.Web.UI;
using MKB.TimePicker;
using System.Data;
using SMS.master;

namespace SMS.ADMIN
{
    public partial class ViewShifts : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {                
                if (!IsPostBack)
                {
                    BindGridTelerik();
                }
                string ctrlname = Page.Request.Params.Get("__EVENTTARGET");
                string ctrlname1 = Page.Request.Params.Get("__eventargument");
                if (ctrlname != null)
                {
                    string controlname = ctrlname;//.Split('$')[ctrlname.Split('$').Length - 1].ToString();
                    if (!controlname.Contains("imdAdd") && !controlname.Contains("imgUpdate") && !controlname.Contains("imgDelete") && !controlname.Contains("imgGlobe") && !controlname.Contains("imglock256") && !controlname.Contains("CheckBox1"))
                    {
                        if (controlname.ToUpper().Contains("RadGridCatalog".ToUpper()))
                        {
                            if (ctrlname1 != null)
                            {
                                if (ctrlname1.Contains("RowClick"))
                                { }
                                else if (ctrlname1.ToUpper().Contains("FIRECOMMAND") || ctrlname1 == "")
                                {
                                    BindGridTelerik();
                                }
                                else
                                {
                                }
                            }
                        }
                        else if (controlname.ToUpper().Contains("lnkEdLocal".ToUpper()))
                        {
                            BindGridTelerik();
                        }
                    }
                }
                else
                {
                    BindGridTelerik();
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        #region New Code
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ModalPopupAdd.Hide();
            ModalPopupUpdate.Hide();
            ModalPopupDelete.Hide();
        }
      
        
        protected void imgAdd_Click(object sender, EventArgs e)
        {
            SpaMaster MyMasterPage = (SpaMaster)Page.Master;

                                            DataTable dtAddShift = AdminDAL.Checkmenu(Session["RoleID"].ToString(), "109");

                                            if (dtAddShift.Rows.Count > 0)
                                            {
                                                ModalPopupAdd.Show();
                                            }
                                            else
                                            {
                                               
                                                MyMasterPage.ShowErrorMessage("You Do Not Have Permission..!");   
          

                                            }
        }
        protected void imgUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                SpaMaster MyMasterPage = (SpaMaster)Page.Master;

                DataTable dtViewShift = AdminDAL.Checkmenu(Session["RoleID"].ToString(), "108");
              
                if (dtViewShift.Rows.Count > 0)
                {
                    if (ViewState["SID"] != null)
                    {
                        ModalPopupUpdate.Show();
                        FillUpdate(ViewState["SID"].ToString());
                    }
                }
                else
                {

                    MyMasterPage.ShowErrorMessage("You Do Not Have Permission..!");


                }

               
               

            }
            catch (Exception ex) { }
        }
        protected void imgDelete_Click(object sender, EventArgs e)
        {


            SpaMaster MyMasterPage = (SpaMaster)Page.Master;

            DataTable dtViewShift = AdminDAL.Checkmenu(Session["RoleID"].ToString(), "108");

            if (dtViewShift.Rows.Count > 0)
            {
                if (ViewState["SID"] != null)
                {
                    ModalPopupDelete.Show();

                }
            }
            else
            {

                MyMasterPage.ShowErrorMessage("You Do Not Have Permission..!");


            }

           

           

        }
      
        
        
        
        protected void btnSearchLocationAdd_Click(object sender, EventArgs e)
        {
            SpaMaster MyMasterPage = (SpaMaster)Page.Master;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            string minute = "";
            if (tsFromTime.Minute == 0)
                minute = tsFromTime.Minute.ToString() + "0";
            else
                minute = tsFromTime.Minute.ToString();

            string FromTime = tsFromTime.Hour + ":" + minute + " ";

            //int.Parse(FromTime.Split(' ')[0].Split(':')[1]);

            if (tsFromTime.AmPm == TimeSelector.AmPmSpec.AM)
            {
                FromTime += "A.M.";
            }
            else
            {
                FromTime += "P.M.";
            }
            string tominute = "";
            if (tsToTime.Minute == 0)
                tominute = tsToTime.Minute.ToString() + "0";
            else
                tominute = tsToTime.Minute.ToString();

            string ToTime = tsToTime.Hour + ":" + tominute + " ";
            if (tsToTime.AmPm == TimeSelector.AmPmSpec.AM)
            {
                ToTime += "A.M.";
            }
            else
            {
                ToTime += "P.M.";
            }
            try
            {
                DataTable dt = new DataTable();
                dt = dal.getdata("select * from Shift_Master where ShiftTimeFrom='" + FromTime + "' and ShiftTimeTo='" + ToTime + "'");
                if (dt.Rows.Count == 0)
                {
                    dal.executesql("insert into Shift_Master (ShiftTimeFrom,ShiftTimeTo) values ('" + FromTime + "','" + ToTime + "')");
                    ModalPopupAdd.Hide();
                    BindGridTelerik();
                    MyMasterPage.ShowErrorMessage("Record Inserted Successfully");
                    // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AlertMessage", " alert('Record Submitted..!');", true);
                }
                else
                {
                    MyMasterPage.ShowErrorMessage("This Shift Already exist....");
                }
            }
            catch (Exception ex)
            {
                MyMasterPage.ShowErrorMessage("Error Occured..!");
                // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AlertMessage", " alert('Error Occured..!');", true);
                logger.Info(ex.Message);
            }
        }
        protected void btnSearchLocationUpdate_Click(object sender, EventArgs e)
        {
            SpaMaster MyMasterPage = (SpaMaster)Page.Master;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            string minute = "";
            if (tsFromTimeupd.Minute == 0)
                minute = tsFromTimeupd.Minute.ToString() + "0";
            else
                minute = tsFromTimeupd.Minute.ToString();

            string FromTime = tsFromTimeupd.Hour + ":" + minute + " ";

            //int.Parse(FromTime.Split(' ')[0].Split(':')[1]);

            if (tsFromTimeupd.AmPm == TimeSelector.AmPmSpec.AM)
            {
                FromTime += "A.M.";
            }
            else
            {
                FromTime += "P.M.";
            }
            string tominute = "";
            if (tsToTimeupd.Minute == 0)
                tominute = tsToTimeupd.Minute.ToString() + "0";
            else
                tominute = tsToTimeupd.Minute.ToString();

            string ToTime = tsToTimeupd.Hour + ":" + tominute + " ";
            if (tsToTimeupd.AmPm == TimeSelector.AmPmSpec.AM)
            {
                ToTime += "A.M.";
            }
            else
            {
                ToTime += "P.M.";
            }
            try
            {
                
                    dal.executesql("Update Shift_Master set ShiftTimeFrom='" + FromTime + "',ShiftTimeTo='" + ToTime + "' where shift_ID=" + hdnitmID.Value.ToString());
                    ViewState["SID"] = "";
                    BindGridTelerik();
                    ModalPopupUpdate.Hide();
                    MyMasterPage.ShowErrorMessage("Record Updated Successfully"); 
                    //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AlertMessage", " alert('Record Submitted..!');", true);
            }
            catch (Exception ex)
            {
                MyMasterPage.ShowErrorMessage("Error Occurred..!"); 
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AlertMessage", " alert('Error Occurred..!');", true);
                logger.Info(ex.Message);
            }
        }
        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            GridDataItem itm = (GridDataItem)chk.NamingContainer;
            int crrntindex = itm.ItemIndex;
            if (chk.Checked == true)
            {
               
                ((sender as CheckBox).NamingContainer as GridItem).Selected = (sender as CheckBox).Checked;
                bool checkHeader = true;
                List<string> lstreportsession = new List<string>();
                int ro = ((sender as CheckBox).NamingContainer as GridItem).ItemIndex;
                GridDataItem item = RadGridCatalog.MasterTableView.Items[ro];

                foreach (GridDataItem item1 in RadGridCatalog.MasterTableView.Items)
                {
                    if (item == item1)
                    {
                        if ((item.FindControl("CheckBox1") as CheckBox).Checked)
                        {
                            RadGridCatalog.Items[ro].Selected = true;
                            string iss = itm.OwnerTableView.DataKeyValues[crrntindex]["shift_ID"].ToString();
                            hdnitmID.Value = iss;
                            ViewState["SID"] = iss;
                            
                        }
                    }
                    else
                    {
                        (item1.FindControl("CheckBox1") as CheckBox).Checked = false;
                    }
                }
            }
        }
        private void FillUpdate(string sid)
        {
            try {
                DataTable dt = dal.getdata("select * from Shift_Master where shift_ID=" + sid);
                string FromTime = dt.Rows[0][1].ToString();
                tsFromTimeupd.Hour = int.Parse(FromTime.Split(' ')[0].Split(':')[0]);
                tsFromTimeupd.Minute = int.Parse(FromTime.Split(' ')[0].Split(':')[1]);
                string AMPM = FromTime.Split(' ')[1].Replace(".", "");
                if (AMPM.ToLower() == "am")
                {
                    tsFromTimeupd.AmPm = TimeSelector.AmPmSpec.AM;
                }
                else
                {
                    tsFromTimeupd.AmPm = TimeSelector.AmPmSpec.PM;
                }
                string ToTime = dt.Rows[0][2].ToString();
                tsToTimeupd.Hour = int.Parse(ToTime.Split(' ')[0].Split(':')[0]);
                tsToTimeupd.Minute = int.Parse(ToTime.Split(' ')[0].Split(':')[1]);
                AMPM = ToTime.Split(' ')[1].Replace(".", "");
                if (AMPM.ToLower() == "am")
                {
                    tsToTimeupd.AmPm = TimeSelector.AmPmSpec.AM;
                }
                else
                {
                    tsToTimeupd.AmPm = TimeSelector.AmPmSpec.PM;
                }
                ViewState["SID"] = Request["SID"];
            }
            catch(Exception ex)
            {
            
            }
        }
        private void BindGridTelerik()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                RadGridCatalog.DataSource = dal.getdata("select * from Shift_Master");
                RadGridCatalog.DataBind();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string argitemid = hdnitmID.Value.ToString();
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                if (!string.IsNullOrEmpty(argitemid))
                {
                    DataAccessLayer dal = new DataAccessLayer();
                    dal.executesql("delete from Shift_Master where shift_ID=" + argitemid);
                    BindGridTelerik();
                    ModalPopupDelete.Hide();
                    MyMasterPage.ShowErrorMessage("Record Deleted Successfully");  
                  //  ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AlertMessage", " alert('Record Deletd Submitted..!');", true);
                    //HttpContext.Current.Items.Add(ContextKeys.CTX_COMPLETE, "DELETE");
                    //Server.Transfer("CompleteForm.aspx");
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        #endregion


    }
}
