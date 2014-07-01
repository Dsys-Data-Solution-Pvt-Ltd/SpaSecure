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
using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.Services.DataService;
using SMS.SMSAppUtilities;
using SMS.BusinessEntities;
using System.Data.SqlClient;
using log4net;
using log4net.Config;
using MKB.TimePicker;
using MKB.Exceptions;

namespace SMS.SMSAdmin
{
    public partial class EventUpdate : System.Web.UI.Page
    {       
        AdminDAL a = new AdminDAL();      
        DataAccessLayer dal = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {   
                String iBTID = string.Empty;
                if (!IsPostBack)
                {
                    if (HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL] != null)
                    {
                        string strURL = HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL].ToString();
                        //((SMSmaster)this.Master).FilterContent(strURL, cmdbuttonadd.ID, SMSAppUtilities.SMSAppEnums.ContentType.Update);
                        ((master.login)this.Master).FilterContent(strURL, cmdbuttonadd.ID, SMSAppUtilities.SMSAppEnums.ContentType.Update);

                    
                    }
                    if (HttpContext.Current.Items[ContextKeys.CTX_BT_ID] != null)
                    {
                        iBTID = HttpContext.Current.Items[ContextKeys.CTX_BT_ID].ToString();
                    }
                    fillsupervisor();
                    fillEventType();
                    fillLocation();
                    PopulatePageCntrls(iBTID);
                    
                }
                
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

        }
        private void fillsupervisor()
        {
            txtSupireorName.Items.Clear();
            txtSupireorName.Items.Add(" ");
            DataSet dssup = dal.getdataset("Select Firstname from UserInformation where Role = 'SuperVisor'");
            if (dssup.Tables[0].Rows.Count > 0)
            {
                for (int j = 0; j < dssup.Tables[0].Rows.Count; j++)
                {
                    txtSupireorName.Items.Add(dssup.Tables[0].Rows[j][0].ToString().Trim());
                }
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
                //drlEventType.Items.Insert(0, new ListItem("-Select-", " "));
            }
        }

        private void fillLocation()
        {
            SqlParameter[] para = new SqlParameter[0];
            DataTable dsLocation = dal.executeprocedure("sp_FillLocationName", para, false);
            if (dsLocation.Rows.Count > 0)
            {
                drlLocation.DataSource = dsLocation;
                drlLocation.DataTextField = "Location_name";
                drlLocation.DataValueField = "Location_id";
                drlLocation.DataBind();
                //drlLocation.Items.Insert(0, " ");
            } 
        }


        private void PopulatePageCntrls(String argsBGID)
        {
            Int32 iCount = 0;
            GetDataEventResponse ret = null;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {

                    DateTime dt;
                    AdminBLL objAdminBLL = new AdminBLL();
                    GetDataEvent objGetBillingTableRequest = new GetDataEvent();

                    objGetBillingTableRequest.Event_ID = argsBGID.ToString();

                    objGetBillingTableRequest.WhereClause = " where Event_ID='" + argsBGID.ToString() + "'";
                    ret = objAdminBLL.GetEventData(objGetBillingTableRequest);

                    hdnBTID.Value = ret.Eventid[iCount].Event_ID.ToString();
                    txtEventID.Text = ret.Eventid[iCount].Event_ID.ToString();
                    txtFromDate.Text = ret.Eventid[iCount].Date_From.ToString();
                    txttoDate.Text = ret.Eventid[iCount].Date_to.ToString();

                    string location = GetLocationNameById(ret.Eventid[iCount].Location_id.ToString());
                    drlLocation.Text = location;
                    drlEventType.Text = ret.Eventid[iCount].Event_Type.ToString();

                    dt = Convert.ToDateTime(ret.Eventid[iCount].Start_time);
                    TimeSelector1.Date = dt;

                    dt = Convert.ToDateTime(ret.Eventid[iCount].End_time);
                    TimeSelector2.Date = dt;

                   // txtpersonincharge.Text = ret.Eventid[iCount].Person_incharg.ToString();
                    txtspecialreq.Text = ret.Eventid[iCount].Special_Requirment.ToString();
                    txtgaurdreq.Text = ret.Eventid[iCount].Guard_Requirment.ToString();
                    txtdutygaurd.Text = ret.Eventid[iCount].Special_Duty.ToString();
                    txtname.Text = ret.Eventid[iCount].Incharg_Name.ToString();
                    txtNricNo.Text = ret.Eventid[iCount].Incharg_NricNo.ToString();
                    txtPosition.Text = ret.Eventid[iCount].Incharg_position.ToString();
                    txtContact.Text = ret.Eventid[iCount].Incharg_ContactNo.ToString();
                    txtSupireorName.Text = ret.Eventid[iCount].Superior_Name.ToString();
                
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        private String GetLocationNameById(string id)
        {
            string name = string.Empty;
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Location_id", id);
            DataTable dsLocationid = dal.executeprocedure("sp_getLocationNameByID", para, false);
            if (dsLocationid.Rows.Count > 0)
            {
                name = dsLocationid.Rows[0][0].ToString().Trim();
                return name;
            }
            return name;
        }
         private int GetLocationIDbyName(string Name)
        {
            int id = 0;
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Location_name", Name);
            DataTable dsLocationid = dal.executeprocedure("sp_GetLocationIDbyName", para, false);
            if (dsLocationid.Rows.Count > 0)
            {
                id=Convert.ToInt32(dsLocationid.Rows[0][0].ToString().Trim());
                return id;
            }
            return id;
        }


        protected void txtEventstarttype_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtFromDate_TextChanged(object sender, EventArgs e)
        {

        }

        protected void drlLocation_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void drlEventType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void imgBtnFromDate_Click(object sender, ImageClickEventArgs e)
        {

        }
        protected void txttoDate_TextChanged(object sender, EventArgs e)
        {

        }
        protected void imgBtnFromDate1_Click(object sender, ImageClickEventArgs e)
        {
        }      

        protected void cmdbuttonadd_Click(object sender, EventArgs e)
        {
          log4net.ILog logger = log4net.LogManager.GetLogger("File");
          try
          {
              eventAdmin objevent = new eventAdmin();
              AdminBLL ws = new AdminBLL();
              DateTime datetime;

              objevent.Event_ID = txtEventID.Text;
              objevent.Date_From = DateTime.TryParse(txtFromDate.Text, out datetime) ? (DateTime?)datetime : null; ;
              objevent.Date_to = DateTime.TryParse(txttoDate.Text, out datetime) ? (DateTime?)datetime : null; ;

              objevent.Location_id = Convert.ToString(GetLocationIDbyName(drlLocation.Text));
              objevent.Event_Type = drlEventType.Text;
              string time = TimeSelector1.Date.TimeOfDay.ToString();
              objevent.Start_time = time;
              string time1 = TimeSelector2.Date.TimeOfDay.ToString();
              objevent.End_time = time1;

              objevent.Special_Requirment = txtspecialreq.Text;
              objevent.Guard_Requirment = txtgaurdreq.Text;
              objevent.Special_Duty = txtdutygaurd.Text;
              objevent.Incharg_Name = txtname.Text;
              objevent.Incharg_NricNo = txtNricNo.Text;
              objevent.Incharg_position = txtPosition.Text;
              objevent.Incharg_ContactNo = txtContact.Text;
              objevent.Superior_Name = txtSupireorName.Text;


              ws.Updatevent(objevent);
              HttpContext.Current.Items.Add(ContextKeys.CTX_COMPLETE, "UPDATE");
              Server.Transfer("AlertUpdateComplete.aspx");

          }
          catch (Exception ex)
          {
              logger.Info(ex.Message);
          }       
        }

        protected void cmdbuttonclear_Click1(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Server.Transfer("../SMSAdmin/eventplanner.aspx");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }


    }
}
