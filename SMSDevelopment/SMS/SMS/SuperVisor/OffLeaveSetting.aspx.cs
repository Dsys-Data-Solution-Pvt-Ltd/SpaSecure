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
using Telerik.Web.UI;
using SMS.master;

namespace SMS.SuperVisor
{
    public partial class OffLeaveSetting : System.Web.UI.Page
    {
       DataAccessLayer dal = new DataAccessLayer();
       String iBTID = string.Empty;
       protected void Page_Load(object sender, EventArgs e)
       {
           log4net.ILog logger = log4net.LogManager.GetLogger("File");
           try
           {
              
               if (!IsPostBack)
               {
                  
                  
                   //if (HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL] != null)
                   //{
                   //    string strURL = HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL].ToString();
                   //    ((master.login)this.Master).FilterContent(strURL, btnNewItemAdd.ID, SMSAppUtilities.SMSAppEnums.ContentType.Update);
                   //}
                   //if (HttpContext.Current.Items[ContextKeys.CTX_BT_ID] != null)
                   //{
                   //    iBTID = iBTID = HttpContext.Current.Items[ContextKeys.CTX_BT_ID].ToString();
                   //}
               }
               string ctrlname = Page.Request.Params.Get("__EVENTTARGET");
               string ctrlname1 = Page.Request.Params.Get("__eventargument");
               if (ctrlname != null)
               {
                   string controlname = ctrlname;//.Split('$')[ctrlname.Split('$').Length - 1].ToString();
                   if (!controlname.Contains("imdAdd") && !controlname.Contains("imgEdit") && !controlname.Contains("imgDelete") && !controlname.Contains("imglock256") && !controlname.Contains("CheckBox1"))
                   {
                       if (controlname.ToUpper().Contains("OffleaveTable".ToUpper()))
                       {
                           if (ctrlname1 != null)
                           {
                               if (ctrlname1.Contains("RowClick"))
                               { }
                               else if (ctrlname1.ToUpper().Contains("FIRECOMMAND") || ctrlname1 == "")
                               {
                                   BindGrid();


                               }
                               else
                               {

                               }

                           }
                       }
                   }
               }
               else
               {
                   BindGrid();

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

           DataSet dsdepartment = dal.getdataset("select (FirstName + ' ' + MiddleName + ' ' + LastName)as name from userinformation where role !='client' order by FirstName Asc");
           if (dsdepartment.Tables[0].Rows.Count > 0)
           {
               ddlStaffname.DataSource = dsdepartment.Tables[0];
              ddlStaffname.DataTextField = "name";
              ddlStaffname.DataValueField = "name";
               ddlStaffname.DataBind();

              
           }
       }
       private void fillLeaveType()
       {
           ddlTypeOfLeave.Items.Clear();
           string ID = "LeaveType";
           SqlParameter[] para1 = new SqlParameter[1];
           para1[0] = new SqlParameter("@ID", ID);
           DataTable dt1 = dal.executeprocedure("sp_getLogvaluebyID", para1, true);

           //DataSet dsleave = dal.getdataset("Select Description from log where ID='LeaveType'");
           if (dt1.Rows.Count > 0)
           {
               ddlTypeOfLeave.DataSource = dt1;
               ddlTypeOfLeave.DataTextField = "Description";
               ddlTypeOfLeave.DataValueField = "Description";
               ddlTypeOfLeave.DataBind();
               ddlTypeOfLeave.Items.Insert(0, new ListItem("", "", true));
           }
       }

       protected void gvPass_RowDataBound(object sender, GridViewRowEventArgs e)
       {
           log4net.ILog logger = log4net.LogManager.GetLogger("File");
           try
           {
               if (e.Row.RowType == DataControlRowType.DataRow)
               {

                   ImageButton Delete = (ImageButton)e.Row.FindControl("btnDelete");
                   Delete.Attributes.Add("onclick", "javascript:return " +
                       "confirm('Are you sure to delete this record?')");
               }
               if (e.Row.RowType == DataControlRowType.Footer)
               {
                 //  gvPassTable.Columns[0].FooterText = "Total Records: 20";
               }
           }

           catch (Exception ex)
           {
               logger.Info(ex.Message);
           }
       }

       protected void gvPass_RowCommand(object sender, GridViewCommandEventArgs e)
       {
           log4net.ILog logger = log4net.LogManager.GetLogger("File");
           try
           {
               string _BTId = Convert.ToString(e.CommandArgument);

               if (e.CommandName == "Edit")
               {
                   HttpContext.Current.Items.Add(ContextKeys.CTX_UPDATE_URL, Request.Url.ToString());
                   HttpContext.Current.Items.Add(ContextKeys.CTX_BT_ID, _BTId);
                   Server.Transfer("UpdateOffLeaveSetting.aspx");
               }
               if (e.CommandName == "DeleteRow")
               {
                  // DeleteItem(_BTId);
               }
           }

           catch (Exception ex)
           {
               logger.Info(ex.Message);
           }
       }

       private void DeleteItem()
       {
           log4net.ILog logger = log4net.LogManager.GetLogger("File");
           try
           {
               
               string argPassID = ViewState["OLid"].ToString().Trim(); 
               dal.executesql("Delete from OffleaveSetting where OLid = '" + argPassID + "' ");
              // Server.Transfer("OffLeaveSetting.aspx");
               SpaMaster MyMasterPage = (SpaMaster)Page.Master;

               MyMasterPage.ShowErrorMessage("Record Delete Sucessfully ..!");  
               BindGrid();
               ModalPopupDelete.Hide();
           }

           catch (Exception ex)
           {
               logger.Info(ex.Message);
           }
       }

       protected void gvPass_PageIndexChanging(object sender, GridViewPageEventArgs e)
       {
           log4net.ILog logger = log4net.LogManager.GetLogger("File");
           try
           {
               if (e.NewPageIndex >= 0)
               {
                  // OffleaveTable.PageIndex = e.NewPageIndex;

                   DataSet dspenalty = dal.getdataset("Select * from OffleaveSetting");
                   if (dspenalty.Tables[0].Rows.Count > 0)
                   {
                       int pageSize = ContextKeys.GRID_PAGE_SIZE;
                       OffleaveTable.PageSize = 25;
                       OffleaveTable.DataSource = dspenalty.Tables[0];
                       OffleaveTable.DataBind();
                   }
               }
           }

           catch (Exception ex)
           {
               logger.Info(ex.Message);
           }
       }

       protected void gvPassTable_SelectedIndexChanged(object sender, EventArgs e)
       {
       }
       //private string ReturnWhere()
       //{
       ////    string str = string.Empty;
       ////    string makeWhereClause = string.Empty;
       ////    log4net.ILog logger = log4net.LogManager.GetLogger("File");
       ////    try
       ////    {
       ////        List<String> arr = new List<String>();
       ////        arr.Add("test");

       ////        if (txtdateto.Text != "" && txtdatefrom.Text != "")
       ////        {
       ////            if (arr.Count == 1)
       ////            {
       ////                str += " where DateFrom BETWEEN '" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
       ////                arr.Add("1");
       ////            }
       ////            else
       ////            {
       ////                str += " and DateFrom BETWEEN '" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
       ////            }
       ////        }
       ////        if (txtdatefrom.Text != "" && txtdateto.Text == "")
       ////        {
       ////            if (arr.Count == 1)
       ////            {
       ////                str += " where DateFrom ='" + txtdatefrom.Text + "'";
       ////                arr.Add("2");
       ////            }
       ////            else
       ////            {
       ////                str += " and DateFrom ='" + txtdatefrom.Text + "'";
       ////            }
       ////        }
       ////        if (ddlTypeOfLeave.Text != "")
       ////        {
       ////            if (arr.Count == 1)
       ////            {
       ////                str += " where LeaveType ='" + ddlTypeOfLeave.Text.Trim() + "'";
       ////                arr.Add("3");
       ////            }
       ////            else
       ////            {
       ////                str += " and LeaveType ='" + ddlTypeOfLeave.Text.Trim() + "'";
       ////            }
       ////        }
       ////        if (ddlStaffname.Text != "")
       ////        {
       ////            if (arr.Count == 1)
       ////            {
       ////                str += " where StaffName ='" + ddlStaffname.Text.Trim() + "'";
       ////                arr.Add("4");
       ////            }
       ////            else
       ////            {
       ////                str += " and StaffName ='" + ddlStaffname.Text.Trim() + "'";
       ////            }
       ////        }
              
       ////    }
       ////    catch (Exception ex)
       ////    {
       ////        logger.Info(ex.Message);
       ////    }
       ////    return (str);
       //}
       private void BindGrid()
       {
           log4net.ILog logger = log4net.LogManager.GetLogger("File");
           try
           {
              // string where = ReturnWhere();
               DataSet ds = dal.getdataset("Select * from OffleaveSetting with(nolock) ");
               //if (ds.Tables[0].Rows.Count > 0)
               //{
                   int pageSize = ContextKeys.GRID_PAGE_SIZE;
                   OffleaveTable.PageSize = 25;
                   OffleaveTable.DataSource = ds.Tables[0];
                   OffleaveTable.DataBind();
               //}
           }
           catch (Exception ex)
           {
               logger.Info(ex.Message);
           }
       }

       protected void gvPass_SelectedIndexChanged(object sender, EventArgs e)
       {

       }

       protected void btnNewPass_Click(object sender, EventArgs e)
       {
           log4net.ILog logger = log4net.LogManager.GetLogger("File");
           try
           {
               Response.Redirect("../SuperVisor/AddNewOffLeave.aspx");
           }

           catch (Exception ex)
           {
               logger.Info(ex.Message);
           }
       }

       protected void btnSearchPassAdd_Click(object sender, EventArgs e)
       {
           log4net.ILog logger = log4net.LogManager.GetLogger("File");
           try
           {
               BindGrid();
           }
           catch (Exception ex)
           {
               logger.Info(ex.Message);
           }
       }

       protected void btnClearPassAdd_Click(object sender, EventArgs e)
       {
           log4net.ILog logger = log4net.LogManager.GetLogger("File");
           try
           {
               //txtdatefrom.Text = "";
               //txtdateto.Text = "";
            
               fillStaffName();
               fillLeaveType();
               
           }
           catch (Exception ex)
           {
               logger.Info(ex.Message);
           }
       }

        #region Add new leave

       protected void imgAdd_Click(object sender, EventArgs e)
       {

           ModalPopupAdd.Show();
           fillStaffName();
           fillLeaveType();
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
                      
                   }
               }

               else
               {
                   lblerror.Visible = true;
                   SpaMaster MyMasterPage = (SpaMaster)Page.Master;

                   MyMasterPage.ShowErrorMessage("This Type Already Exist ..!");  
                  // lblerror.Text = "This Type Already Exist...!";
                   lblerror.Visible = true;
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
               if (ddlTypeOfLeave.Text == "")
               {
                   SpaMaster MyMasterPage = (SpaMaster)Page.Master;

                   MyMasterPage.ShowErrorMessage("Please select LeaveType..!");
               }
               else if (txtNoOfday.Text == "")
               {
                   SpaMaster MyMasterPage = (SpaMaster)Page.Master;

                   MyMasterPage.ShowErrorMessage("Fill  No. of Leavedays..!");
               }
               else
               {
                   SqlParameter[] para = new SqlParameter[7];
                   para[0] = new SqlParameter("@LeaveType", ddlTypeOfLeave.Text.Trim());
                   para[1] = new SqlParameter("@SuperiorName", txtsuperiorOfficer.Text.Trim());
                   para[2] = new SqlParameter("@NoOfDay", txtNoOfday.Text.Trim());
                   para[3] = new SqlParameter("@StaffName", ddlStaffname.Text.Trim());
                   para[4] = new SqlParameter("@DateFrom", DateTime.Now);
                   para[5] = new SqlParameter("@RemaingStatus", "False");
                   para[6] = new SqlParameter("@RemaingDay", txtNoOfday.Text.Trim());

                   dal.executeprocedure("SP_addOffleaveSetting", para);
                   SpaMaster MyMasterPage = (SpaMaster)Page.Master;

                   MyMasterPage.ShowErrorMessage("Record Insert sucessfully ..!");

                   // lblErrMsg.Text = "Record Insert sucessfully";
                   BindGrid();
                   ClearAdd();
                   HttpContext.Current.Items.Add("COMPLETE", "INSERT");
                   // Server.Transfer("..//SMSAdmin//AlertUpdateComplete.aspx");
               }
           }
           catch (Exception ex)
           {
               logger.Info(ex.Message);
           }
       }
       public void ClearAdd()
       { 
            ddlTypeOfLeave.Text="";
            txtsuperiorOfficer.Text="";
            txtNoOfday.Text = "";
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
        #endregion


        #region update Leave 

       protected void imgUpdate_Click(object sender, EventArgs e)
       {
           if (ViewState["OLid"] != null)
           {
               fillLeaveTypeUda();
               fillStaffNameUda();
               ModalPopupEdit.Show();
               PopulatePageCntrls();
           }

       }
       private void PopulatePageCntrls()
       {
           string argsBGID = ViewState["OLid"].ToString().Trim(); 
           DataSet dspan = dal.getdataset("Select * from OffleaveSetting where OLid = '" + argsBGID + "' ");
           if (dspan.Tables[0].Rows.Count > 0)
           {
               lblidUda.Text = argsBGID;
               ddlTypeOfLeaveUda.SelectedValue=dspan.Tables[0].Rows[0]["LeaveType"].ToString().Trim();
               txtsuperiorOfficerUda.Text = dspan.Tables[0].Rows[0]["SuperiorName"].ToString().Trim();
               txtNoOfdayUda.Text = dspan.Tables[0].Rows[0]["NoOfDay"].ToString().Trim();
               ddlStaffnameUda.SelectedItem.Text = (dspan.Tables[0].Rows[0]["StaffName"].ToString().Trim());
           }
       }
       private void fillStaffNameUda()
       {
           ddlStaffname.Items.Clear();

           DataSet dsdepartment = dal.getdataset("select (FirstName + ' ' + MiddleName + ' ' + LastName)as name from userinformation where role !='client' order by FirstName Asc");
           if (dsdepartment.Tables[0].Rows.Count > 0)
           {
               ddlStaffnameUda.DataSource = dsdepartment.Tables[0];
               ddlStaffnameUda.DataTextField = "name";
               ddlStaffnameUda.DataValueField = "name";
               ddlStaffnameUda.DataBind();


           }
       }

       protected void btnsaveUda_Click(object sender, EventArgs e)
       {
           log4net.ILog logger = log4net.LogManager.GetLogger("File");
           try
           {
               //dal.executesql("Update OffLeaveApplication Set Name ='" + txtnameUda.Text.Trim() + "',NRIC='" + txtNRICnoUpda.Text.Trim() + "',Assignment='" + txtAssignmentUda.Text.Trim() + "',DateOfApplication='" + txtDateofApplicationUda.Text.Trim() + "',LeaveFromDate='" + txtdatefromUda.Text.Trim() + "',LeaveToDate='" + txtdatetoUda.Text.Trim() + "',Approved_Status='" + ddlApprovedUda.Text.Trim() + "',LeaveDayCount='" + ddlleaveDayCountUda.Text.Trim() + "' where Leave_id = '" + txtIDUda.Text.Trim() + "' ");

               //dal.executesql("Update OffleaveSetting set RemaingDay='" + txtramainingdayUda.Text + "' where StaffName ='" + txtnameUda.Text.Trim() + "'");
               //Server.Transfer("AdminSuperOffLeave.aspx");
           }
           catch (Exception ex)
           {
               logger.Info(ex.Message);
           }
       }

     
       protected void btnCancel_Click(object sender, EventArgs e)
       {
           ModalPopupEdit.Hide();
           ModalPopupAdd.Hide();
           ModalPopupDelete.Hide();
           ClearAdd();
       }

       protected void btnNewItemAddUda_Click(object sender, EventArgs e)
       {
           log4net.ILog logger = log4net.LogManager.GetLogger("File");
           try
           {
               dal.executesql("Update OffleaveSetting Set LeaveType ='" + ddlTypeOfLeaveUda.SelectedItem.Text.Trim() + "',SuperiorName='" + txtsuperiorOfficerUda.Text.Trim() + "',StaffName='" + ddlStaffnameUda.SelectedItem.Text.Trim() + "',NoOfDay='" + txtNoOfdayUda.Text.Trim() + "' where OLid = '" + lblidUda.Text.Trim() + "' ");
              // Response.Redirect("~/Supervisor/OffLeaveSetting.aspx");
               SpaMaster MyMasterPage = (SpaMaster)Page.Master;

               MyMasterPage.ShowErrorMessage("Record Update sucessfully ..!");  
               ModalPopupEdit.Hide();
               BindGrid();
           }
           catch (Exception ex)
           {
               logger.Info(ex.Message);
           }
       }

       protected void btnClearNewItemAddUda_Click(object sender, EventArgs e)
       {
           log4net.ILog logger = log4net.LogManager.GetLogger("File");
           try
           {
               Response.Redirect("~/Supervisor/OffLeaveSetting.aspx");
           }
           catch (Exception ex)
           {
               logger.Info(ex.Message);
           }
       }
       protected void imgDelete_Click(object sender, EventArgs e)
       {
           if (ViewState["OLid"] != null)
           {
               ModalPopupDelete.Show();
           }

       }
       protected void btnDeleCancel_Click(object sender, EventArgs e)
       {
           DeleteItem();
       }
        #endregion
        #region grid seleted row
       private void fillLeaveTypeUda()
       {

           ddlTypeOfLeaveUda.Items.Clear();
           ddlTypeOfLeaveUda.Items.Add(" ");
           string ID = "LeaveType";
           SqlParameter[] para1 = new SqlParameter[1];
           para1[0] = new SqlParameter("@ID", ID);
           DataTable dt1 = dal.executeprocedure("sp_getLogvaluebyID", para1, true);


           // DataSet dsleave = dal.getdataset("Select Description from log where ID='LeaveType' ");
           if (dt1.Rows.Count > 0)
           {
               for (int k = 0; k < dt1.Rows.Count; k++)
               {
                   ddlTypeOfLeaveUda.Items.Add(dt1.Rows[k][0].ToString().Trim());
               }
           }
       }
       protected void ToggleRowSelection(object sender, EventArgs e)
       {
           ((sender as CheckBox).NamingContainer as GridItem).Selected = (sender as CheckBox).Checked;
           bool checkHeader = true;
           List<string> lstreportsession = new List<string>();
           int ro = ((sender as CheckBox).NamingContainer as GridItem).ItemIndex;
           GridDataItem item = OffleaveTable.MasterTableView.Items[ro];

           foreach (GridDataItem item1 in OffleaveTable.MasterTableView.Items)
           {

               if (item == item1)
               {
                   if ((item.FindControl("CheckBox1") as CheckBox).Checked)
                   {

                       OffleaveTable.Items[ro].Selected = true;


                       ViewState["OLid"] = item.OwnerTableView.DataKeyValues[ro]["OLid"];


                   }
               }
               else
               {
                   (item1.FindControl("CheckBox1") as CheckBox).Checked = false;
               }


           }

       }
        #endregion
    }
}
