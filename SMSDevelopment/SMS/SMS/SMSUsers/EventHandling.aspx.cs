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
using MKB.TimePicker;
using MKB.Exceptions;
using SMS.BusinessEntities;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;

namespace SMS.SMSUsers
{
    public partial class EventHandaler : System.Web.UI.Page
    {       
        AdminDAL a = new AdminDAL();
        DataAccessLayer dal = new DataAccessLayer();
        int p = 0;     

        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {                
                  lblerror.Visible = false;
                  lblerr1.Visible = false;                  
                  if (IsPostBack == false)
                  {                    
                      fillEventType();                     
                      if (Session["ManagementRole"].ToString().ToLower() == "superuser")
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
                drlLocation.Items.Add(dsLocationName.Rows[0][0].ToString().Trim());
            }
        }
        private void fillEventType()
        { 
           string ID = "eventtype";
           SqlParameter[] para1 = new SqlParameter[1];
           para1[0] = new SqlParameter("@ID", ID);
           DataTable dt = dal.executeprocedure("sp_getLogvaluebyID", para1, true);
           if (dt.Rows.Count > 0)
           {
               drlEventType.DataSource = dt;
               drlEventType.DataTextField = "Description";
               drlEventType.DataValueField = "Description";
               drlEventType.DataBind();
               drlEventType.Items.Insert(0, new ListItem("-Select-", " "));
           }
        }
        private void fillLocation()
        {log4net.ILog logger = log4net.LogManager.GetLogger("File");
        try
        {

            SqlParameter[] para = new SqlParameter[0];
            DataTable dsLocation = dal.executeprocedure("sp_FillLocationName", para, false);
            if (dsLocation.Rows.Count > 0)
            {
                drlLocation.DataSource = dsLocation;
                drlLocation.DataTextField = "Location_name";
                drlLocation.DataValueField = "Location_id";
                drlLocation.DataBind();
                drlLocation.Items.Insert(0, " ");
            }
        }
        catch (Exception ex)
        {
            logger.Info(ex.Message);
        } 
        }

        protected void imgBtnFromDate1_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void imgBtnFromDate_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void txtFromDate_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtEventstarttype_TextChanged(object sender, EventArgs e)
        {

        }

        protected void cmdbuttonadd_Click(object sender, EventArgs e)
        {
           log4net.ILog logger = log4net.LogManager.GetLogger("File");
           try
           {
               AddNewEventmanRequest objAddEventmanRequest = new AddNewEventmanRequest();
               eventAdmin objeventman = new eventAdmin();
               DateTime datetime;
               if (txtNricNo.Text.Trim() != "" && txtname.Text.Trim() != "")
               {
                   objeventman.Date_From = DateTime.TryParse(txtFromDate.Text, out datetime) ? (DateTime?)datetime : null; 
                   objeventman.Date_to = DateTime.TryParse(txttoDate.Text, out datetime) ? (DateTime?)datetime : null;
                  
                   objeventman.Event_Type = drlEventType.Text.Trim();
                   objeventman.Start_time = TimeSelector1.Date.TimeOfDay.ToString();
                   objeventman.End_time = TimeSelector2.Date.TimeOfDay.ToString();

                   objeventman.Special_Requirment = txtspecialreq.Text;
                   objeventman.Guard_Requirment = txtgaurdreq.Text;
                   objeventman.Special_Duty = txtdutygaurd.Text;
                   objeventman.Incharg_Name = txtname.Text.Trim();
                   objeventman.Incharg_NricNo = txtNricNo.Text.Trim();
                   objeventman.Incharg_position = txtPosition.Text;
                   objeventman.Incharg_ContactNo = txtContact.Text;
                   objeventman.Superior_Name = txtSupireorName.Text;
                   string location_id = getLocationIDByName1(drlLocation.SelectedValue.ToString());
                   objeventman.Location_id = location_id;

                   AdminBLL ws = new AdminBLL();
                   ws.AddEvent(objeventman);

                   HttpContext.Current.Items.Add("COMPLETE", "INSERT");
                   Server.Transfer("..//SMSADMIN//AlertUpdateComplete.aspx");
               }
               else
               {
                   lblerror.Visible = true;
                   lblerror.Text = "Please Fill NRICno. & Name.....!";
               }
           }
           catch (Exception ex)
           {
               logger.Info(ex.Message);
           }
        }



        protected void cmdbuttonClear_Click(object sender, EventArgs e)
        {
           log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                    txtaddeventtype.Text = "";                  
                    txtContact.Text = "";
                    txtdutygaurd.Text = "";   
                    txtFromDate.Text = "";
                    txtgaurdreq.Text = "";
                    txtname.Text = "";
                    txtNricNo.Text = "";                    
                    txtPosition.Text = "";
                    txtspecialreq.Text = "";
                    txtSupireorName.Text = "";
                    txttoDate.Text = "";
                    drlEventType.Text = "";
                    drlLocation.Text = "";
             }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

       
        protected void cmdadd2_Click(object sender, EventArgs e)
        {
          log4net.ILog logger = log4net.LogManager.GetLogger("File");
          try
          {  
            string g = txtaddeventtype.Text.Trim();
            string ID = "eventtype";
            SqlParameter[] para1 = new SqlParameter[1];
            para1[0] = new SqlParameter("@ID", ID);
            DataTable dt1 = dal.executeprocedure("sp_getLogvaluebyID", para1, true);
           
            int count = dt1.Rows.Count;
            for (p = 0; p < count; p++)
            {
                string f = dt1.Rows[p].ItemArray[0].ToString();

                if (string.Equals(f, g, StringComparison.CurrentCultureIgnoreCase))              
                {
                    break;
                }
            }
            p++;
            count++;
            if (p == count)
            {
                if (txtaddeventtype.Text.Trim() != "")
                {
                    SqlParameter[] para2 = new SqlParameter[3];
                    para2[0] = new SqlParameter("@ID", SqlDbType.VarChar);
                    para2[0].Value = "eventtype";

                    para2[1] = new SqlParameter("@code", SqlDbType.BigInt);
                    para2[1].Value = count;

                    para2[2] = new SqlParameter("@Description", SqlDbType.VarChar);
                    para2[2].Value = txtaddeventtype.Text.Trim();

                    dal.executeprocedure("SP_InsertLogData", para2);


                   // dal.executesql("insert into log(ID,Code,Description) values('eventtype'," + count + ",'" + txtaddeventtype.Text + "')");
                    txtaddeventtype.Text = "";
                    fillEventType();
                }
            }
            else
              {
                txtaddeventtype.Text = "";
                lblerror.Visible = true;
                lblerror.Text = "This Type Already Exist....!";
              }
           }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void imgBtnFromDate1_Click1(object sender, ImageClickEventArgs e)
        {

        }

        protected void txttoDate_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnGetData_Click(object sender, EventArgs e)
        {
            
        }

        protected void txtNricNo_TextChanged(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (txtNricNo.Text.Trim() != "")
                {
                    DataSet ds = dal.getdataset("select FirstName+' '+LastName as Name,Staff_Telphone as Phone,Role as Position From UserInformation where NRICno='" + txtNricNo.Text + "'");
                    txtname.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    txtContact.Text = ds.Tables[0].Rows[0]["Phone"].ToString();
                    txtPosition.Text = ds.Tables[0].Rows[0]["Position"].ToString();
                }

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        private string  getLocationIDByName1(string Name)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Location_name", Name);
            string  result = string.Empty;
            DataTable dsLocationID = dal.executeprocedure("sp_GetLocationIDbyName", para, false);
            if (dsLocationID.Rows.Count > 0)
            {
                //SearchLocID.Text = dsLocationID.Rows[0][0].ToString().Trim();
                result = dsLocationID.Rows[0][0].ToString().Trim();
            }
            return result;
        }



   } 
 }

