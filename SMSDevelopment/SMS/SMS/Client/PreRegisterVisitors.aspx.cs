using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using SMS.Services.DataService;
using System.Data;
using SMS.SMSAppUtilities;
using System.Drawing;
using System.Web.UI.MobileControls;

namespace SMS.Client
{
    public partial class PreRegisterVisitors : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
          log4net.ILog logger = log4net.LogManager.GetLogger("File");
          try
          {
             lblerror.Visible = false;
             if (!IsPostBack)
             {
                 if (Session["ManagementRole"].ToString().ToLower() == "superuser")
                 {
                     getLocationName();
                 }
                 else
                 {
                     getLocationNameById(Session["LCID"].ToString());                     
                 }
                 getLocationIDByName(ddllocation.Text.Trim());
                 BindVisitors();
             }
            if (Request["mode"] != null)
            {
                if (Request["mode"] == "edit")
                {
                    if (!IsPostBack)
                    {
                        string location = string.Empty;
                        SqlParameter[] para = new SqlParameter[1];
                        para[0] = new SqlParameter("@PRVID", long.Parse(Request["id"]));
                        DataTable dt = dal.executeprocedure("usp_GetPreRegisteredVisit", para, true);
                        txtFromDate.Text = DateTime.Parse(dt.Rows[0]["FromDate"].ToString()).ToString("MM/dd/yyyy");
                        txtToDate.Text = DateTime.Parse(dt.Rows[0]["ToDate"].ToString()).ToString("MM/dd/yyyy");
                        string expected = dt.Rows[0]["ExpectedTime"].ToString();
                        tsExpectedTime.Hour = int.Parse(expected.Split(':')[0]);
                        tsExpectedTime.Minute = int.Parse(expected.Split(':')[1]);
                        hdnCSID.Value = dt.Rows[0]["PRVID"].ToString();
                        txtName.Text = dt.Rows[0]["Name"].ToString();
                        txtCompany.Text = dt.Rows[0]["Company"].ToString();
                        txtPosition.Text = dt.Rows[0]["Position"].ToString();
                        txtInvitedBy.Text = dt.Rows[0]["Invited_By"].ToString();
                        txttelephone.Text = dt.Rows[0]["Telephoe"].ToString();
                        txtVechicle.Text = dt.Rows[0]["VechicleNo"].ToString();
                        txtpurpose.Text = dt.Rows[0]["Purpose"].ToString();


                        location = dt.Rows[0]["LocationID"].ToString();
                        //getLocationNameById(location);

                        lblHead.Text = "Update Pre-Registered Visitors";
                        btnAddVisitor.Text = "Update";                      
                    }
                }
            }
            //getLocationIDByName(ddllocation.Text.Trim());
            //BindVisitors();
          }
          catch (Exception ex)
          {
              logger.Info(ex.Message);
          }
        }
        private void getLocationIDByName(string Name)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Location_name", Name);
            DataTable dsLocationID = dal.executeprocedure("sp_GetLocationIDbyName", para, false);
            if (dsLocationID.Rows.Count > 0)
            {
              Searchid.Text = dsLocationID.Rows[0][0].ToString().Trim();
            }
        }

        private void getLocationName()
        {
            ddllocation.Items.Clear();
            SqlParameter[] para = new SqlParameter[0];           
            DataTable dsLocation = dal.executeprocedure("sp_FillLocationName", para, false);
            if (dsLocation.Rows.Count > 0)
            {
                ddllocation.DataSource = dsLocation;
                ddllocation.DataTextField = "Location_name";
                ddllocation.DataValueField = "Location_id";
                ddllocation.DataBind();
                ddllocation.Items.Insert(0, "");               
            }
        }

        private void getLocationNameById(string id)
        {           
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Location_id", id);
            DataTable dsLocationName = dal.executeprocedure("sp_getLocationNameByID", para, false);
            
            if (dsLocationName.Rows.Count > 0)
            {
               // ddllocation.Items.Add(dsLocationName.Rows[0][0].ToString().Trim());
                ddllocation.Items.Insert(0, dsLocationName.Rows[0][0].ToString().Trim());
            }
        }

        protected void btnCancelCStaff_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.UrlReferrer.ToString());
            txtFromDate.Text = "";
            txtCompany.Text = "";
            txtInvitedBy.Text = "";
            txtName.Text = "";
            txtPosition.Text = "";
            txtpurpose.Text = "";
            txttelephone.Text = "";
            txtToDate.Text = "";
            txtVechicle.Text = "";
        }

        protected void btnAddVisitor_Click(object sender, EventArgs e)
        {
        
          
                getLocationIDByName(ddllocation.Text.Trim());
                if (txtFromDate.Text.Trim() != "" && txtName.Text.Trim() != "" && txtPosition.Text.Trim() != "" && txtCompany.Text.Trim() != "" && txtInvitedBy.Text.Trim() != "")
                {
                    DateTime fromdate = Convert.ToDateTime(txtFromDate.Text.Trim());
                    DateTime Todate = Convert.ToDateTime(txtToDate.Text.Trim());
                    string time = tsExpectedTime.Date.TimeOfDay.ToString();
                    string newtime = time.Substring(0, 5);
                    string name = txtName.Text.Trim();
                    string company = txtCompany.Text.Trim();
                    string position = txtPosition.Text.Trim();
                    string invitedby = txtInvitedBy.Text.Trim();
                    string vechileno = txtVechicle.Text.Trim();
                    string telepohne = txttelephone.Text.Trim();
                    string purpose = txtpurpose.Text.Trim();

                    if (txtToDate.Text.Trim() == "")
                    {
                        txtToDate.Text = "";
                    }

                   
                    if (btnAddVisitor.Text.Contains("Add"))
                    {
                       // dal.executesql("Insert into PreRegisteredVisits(FromDate,ToDate,ExpectedTime,Name,Company,Position,Invited_By,LocationID,VechicleNo,Purpose,Telephoe,AlertStatus) values('" + txtFromDate.Text.Trim() + "','" + txtToDate.Text.Trim() + "','" + newtime + "','" + txtName.Text.Trim() + "','" + txtCompany.Text.Trim() + "','" + txtPosition.Text + "','" + txtInvitedBy.Text.Trim() + "','" + Searchid.Text + "','" + txtVechicle.Text + "','" + txtpurpose.Text + "','" + txttelephone.Text + "','ON') ");
                        SqlParameter[] para1 = new SqlParameter[11];
                        para1[0] = new SqlParameter("@FromDate", fromdate);
                        para1[1] = new SqlParameter("@ToDate", Todate);
                        para1[2] = new SqlParameter("@ExpectedTime", time);
                        para1[3] = new SqlParameter("@LocationID", Searchid.Text);
                        //para1[3] = new SqlParameter("@LocationID", Searchid.Text);
                        para1[4] = new SqlParameter("@Invited_By", invitedby);
                        para1[5] = new SqlParameter("@Name", company);
                        para1[6] = new SqlParameter("@Company", company);
                        para1[7] = new SqlParameter("@Position", position);
                        para1[8] = new SqlParameter("@Telephoe", telepohne);
                        para1[9] = new SqlParameter("@Purpose", purpose);
                        para1[10] = new SqlParameter("@VechicleNo", vechileno);
                        dal.executeprocedure("SP_AddPrevisitors", para1);

                        lblerror.Visible = true;
                        lblerror.Text = "Insert Successfully ...!";
                        BindVisitors();
                    }
                    else
                    {
                        SqlParameter[] para = new SqlParameter[12];
                        para[0] = new SqlParameter("@FromDate", fromdate);
                        para[1] = new SqlParameter("@ToDate", Todate);
                        para[2] = new SqlParameter("@ExpectedTime", time);
                        para[3] = new SqlParameter("@LocationID", Searchid.Text);

                        para[4] = new SqlParameter("@Invited_By", invitedby);
                        para[5] = new SqlParameter("@Name", company);
                        para[6] = new SqlParameter("@Company", company);
                        para[7] = new SqlParameter("@Position", position);
                        para[8] = new SqlParameter("@Telephoe", telepohne);
                        para[9] = new SqlParameter("@Purpose", purpose);
                        para[10] = new SqlParameter("@VechicleNo", vechileno);
                        para[11] = new SqlParameter("@PRVID", hdnCSID.Value);
                        dal.executeprocedure("SP_UpdatePrevisitors", para);

                       //dal.executesql("Update PreRegisteredVisits set FromDate='" + txtFromDate.Text.Trim() + "',ToDate='" + txtToDate.Text.Trim() + "',ExpectedTime='" + newtime + "',Name='" + txtName.Text.Trim() + "',Company='" + txtCompany.Text.Trim() + "',Position='" + txtPosition.Text.Trim() + "',Invited_By='" + txtInvitedBy.Text.Trim() + "',LocationID='" + Searchid.Text + "',VechicleNo='" + txtVechicle.Text + "',Purpose='" + txtpurpose.Text + "',Telephoe='"+txttelephone.Text+"' where PRVID ='" + hdnCSID.Value + "' ");
                       lblerror.Visible = true;
                       lblerror.Text = "Update Successfully ...!";
                    }
                }
                else
                {
                   lblerror.Visible = true;
                   lblerror.Text = "Please Fill All Entries....!";
                }
            
        }

        private void BindVisitors()
        {
            if (Request["mode"] != null)
            {
                //getLocationIDByName(ddllocation.Text.Trim());
                DataTable dt = dal.getdata("Select PRVID,convert(varchar, FromDate, 101) as FromDate1,convert(varchar, ToDate, 101) as ToDate1,ExpectedTime,Name,Invited_By,Company,Position from PreRegisteredVisits where AlertStatus='ON' and PRVID = '" + Request["id"] + "' order by FromDate desc");
                //if (dt.Rows.Count > 0)
                //{
                gvPreRegisteredVisits.DataSource = dt;
                gvPreRegisteredVisits.DataBind();
                //}
                //else
                //{
                //    gvPreRegisteredVisits.DataSource = null;
                //    gvPreRegisteredVisits.DataBind();
                //}
            }
            else
            {
                getLocationIDByName(ddllocation.Text.Trim());
                DataTable dt = dal.getdata("Select PRVID,convert(varchar, FromDate, 101) as FromDate1,convert(varchar, ToDate, 101) as ToDate1,ExpectedTime,Name,Invited_By,Company,Position from PreRegisteredVisits where AlertStatus='ON' and LocationID = '" + Searchid.Text + "' order by FromDate desc");
                //if (dt.Rows.Count > 0)
                //{
                gvPreRegisteredVisits.DataSource = dt;
                gvPreRegisteredVisits.DataBind();   
            }


                
                
                
        }

        protected void gvPreRegisteredVisits_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvPreRegisteredVisits_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                string PRVSID = Convert.ToString(e.CommandArgument);
                if (e.CommandName == "EditRow")
                {
                    SqlParameter[] para = new SqlParameter[1];
                    para[0] = new SqlParameter("@PRVSID", PRVSID);
                    DataTable dsprevisitdata = dal.executeprocedure("SP_GetPreRegisterVisitdata", para, false);
                    if (dsprevisitdata.Rows.Count > 0)
                    {
                        txtName.Text = dsprevisitdata.Rows[0]["Name"].ToString();
                        txtCompany.Text = dsprevisitdata.Rows[0]["Company"].ToString();
                        txtPosition.Text = dsprevisitdata.Rows[0]["Position"].ToString();
                        btnAddVisitor.Text = "Update Visitor";
                        hdnPRVSID.Value = PRVSID;
                    }
                    //DataTable dt = dal.getdata("select Name,Company,Position from PreRegisteredVisitors where PRVSID=" + PRVSID);
                }
                if (e.CommandName == "DeleteRow")
                {
                    DeleteItem(PRVSID);
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        private void DeleteItem(string argPRVSID)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (!string.IsNullOrEmpty(argPRVSID))
                {
                    SqlParameter[] para1 = new SqlParameter[11];
                    para1[0] = new SqlParameter("@PRVSID", argPRVSID);
                    dal.executeprocedure("SP_DeletePreRegisterVisit", para1);  
                   // dal.executesql("delete from PreRegisteredVisitors where PRVSID="+argPRVSID);
                    BindVisitors();
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void gvPreRegisteredVisits_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ImageButton Delete = (ImageButton)e.Row.FindControl("btnDelete");
                    Delete.Attributes.Add("onclick", "javascript:return " + "confirm('Are you sure to delete this record?')");
                }
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    gvPreRegisteredVisits.Columns[0].FooterText = "Total Records: 20";
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void ddllocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            Searchid.Text = ddllocation.Text;
        }

        protected void ddllocation_SelectedIndexChanged1(object sender, EventArgs e)
        {
            //getLocationIDByName(ddllocation.Text.Trim());
            Searchid.Text = ddllocation.Text;
        }


    }
}
