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

namespace SMS.ADMIN
{
    public partial class FacilityBooking : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (!IsPostBack)
                {
                    fillFacilityType();
                    if (Session["ManagementRole"].ToString().ToLower() == "superuser")
                    {
                        getLocationName();
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
        private void getLocationIDByName(string Name)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Location_name", Name);
            DataTable dsLocationID = dal.executeprocedure("sp_GetLocationIDbyName", para, false);
            if (dsLocationID.Rows.Count > 0)
            {
                SearchLocID.Text = dsLocationID.Rows[0][0].ToString().Trim();
            }
        }

        private void getLocationName()
        {
            SqlParameter[] para = new SqlParameter[0];
            DataTable dsLocation = dal.executeprocedure("sp_FillLocationName", para, false);
            if (dsLocation.Rows.Count > 0)
            {
                for (int k = 0; k < dsLocation.Rows.Count; k++)
                {
                    ddllocation.Items.Add(dsLocation.Rows[k][0].ToString().Trim());
                }
            }
        }

        private void getLocationNameById(string Name)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Location_id", Name);
            DataTable dsLocationName = dal.executeprocedure("sp_getLocationNameByID", para, false);
            if (dsLocationName.Rows.Count > 0)
            {
                ddllocation.Items.Add(dsLocationName.Rows[0][0].ToString().Trim());
            }
        }
        protected void btnNewItemAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                getLocationIDByName(ddllocation.Text.Trim());
                Boolean booktime = false;

                DataSet dsverify = dal.getdataset("Select bookingdateFrom,bookingdateto,SUBSTRING(bookingtimeFrom,1,2)As bookingtimeFrom,SUBSTRING(bookingtimeTo,1,2)As bookingtimeTo from FacilityBooking where location_id ='" + SearchLocID.Text + "' and FacilityType ='" + ddlTypeOfFacility.Text + "' ");
                if (dsverify.Tables[0].Rows.Count > 0)
                {
                    DateTime BFromDate;
                    DateTime BToDate;
                    int BFromTime = 0;
                    int BToTime = 0;

                    for (int k = 0; k < dsverify.Tables[0].Rows.Count; k++)
                    {
                        BFromDate = Convert.ToDateTime(dsverify.Tables[0].Rows[k][0].ToString());
                        BToDate = Convert.ToDateTime(dsverify.Tables[0].Rows[k][1].ToString());
                        BFromTime = Convert.ToInt32(dsverify.Tables[0].Rows[k][2].ToString());
                        BToTime = Convert.ToInt32(dsverify.Tables[0].Rows[k][3].ToString());

                        //Check for Current Day
                        if (Convert.ToDateTime(txtbookingdate.Text) == BFromDate && Convert.ToDateTime(txtbookingdate.Text) == BToDate)
                        {
                            int hour = 0;
                            if (TimeSelector1.AmPm.ToString().Contains("PM"))
                            {
                                TimeSelector1.Hour += 10;
                                hour = TimeSelector1.Hour + 10;
                            }
                            else
                            {
                                hour = TimeSelector1.Hour;
                            }

                            if (BFromTime < hour || BToTime > hour)
                            {
                                booktime = true;
                                break;
                            }
                            if (BFromTime < hour || BToTime > hour)
                            {
                                booktime = true;
                                break;
                            }

                        }
                        //Booking Date Falls in Middle of From Date and To Date
                        if (Convert.ToDateTime(txtbookingdate.Text) > BFromDate && Convert.ToDateTime(txtbookingdate.Text) < BToDate)
                        {                            
                            booktime = true;
                            break;
                        }
                        else if (Convert.ToDateTime(txtbookingdate.Text) == BFromDate)
                        {
                            int hour = 0;
                            if (TimeSelector1.AmPm.ToString().Contains("PM"))
                            {
                                TimeSelector1.Hour += 10;
                                hour = TimeSelector1.Hour + 10;
                            }
                            else
                            {
                                hour = TimeSelector1.Hour;
                            }

                            if (BFromTime > hour)
                            {
                                booktime = true;
                              //  bookdate = true;
                                break;
                            }
                        }
                        else if (Convert.ToDateTime(txtbookingdate.Text) == BToDate)
                        {                          
                            int hour = 0;
                            if (TimeSelector1.AmPm.ToString().Contains("PM"))
                            {
                                TimeSelector1.Hour += 10;
                                hour = TimeSelector1.Hour + 10;
                            }
                            else
                            {
                                hour = TimeSelector1.Hour;
                            }

                            if (BToTime > hour)
                            {
                                booktime = true;
                                //bookdate = true;
                                break;
                            }
                        }

                    }

                }
                else
                {
                    booktime = false;
                }

                if (booktime == false)
                {
                    getLocationIDByName(ddllocation.Text.Trim());
                    SqlParameter[] para = new SqlParameter[12];
                    para[0] = new SqlParameter("@FacilityType", ddlTypeOfFacility.Text.Trim());
                    para[1] = new SqlParameter("@Name", txtname.Text.Trim());
                    para[2] = new SqlParameter("@Position", txtposition.Text.Trim());
                    para[3] = new SqlParameter("@UnitNumber", txtunitno.Text.Trim());
                    para[4] = new SqlParameter("@bookingdateFrom", txtbookingdate.Text.Trim());
                    para[5] = new SqlParameter("@bookingtimeFrom", TimeSelector1.Date.TimeOfDay.ToString());
                    para[6] = new SqlParameter("@Status", txtStatus.Text.Trim());

                    para[7] = new SqlParameter("@Comment", txtcomment.Text.Trim());
                    para[8] = new SqlParameter("@DateFrom", DateTime.Now);
                    para[9] = new SqlParameter("@bookingdateTo", txtbookingto.Text.Trim());
                    para[10] = new SqlParameter("@bookingtimeTo", TimeSelector12.Date.TimeOfDay.ToString());
                    para[11] = new SqlParameter("@Location_id",Convert.ToInt32(SearchLocID.Text));
                    dal.executeprocedure("SP_AddFacilityBook", para);

                    HttpContext.Current.Items.Add("COMPLETE", "INSERT");
                    Server.Transfer("..//SMSAdmin//AlertUpdateComplete.aspx");
                }
                else
                {
                    lblerror.Visible = true;
                    lblerror.Text = "Facility is Already Occupied";
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private void fillLocation()
        {
            ddllocation.Items.Clear();           
            SqlParameter[] para1 = new SqlParameter[0];
            DataTable dtloc = dal.executeprocedure("SP_GetLocationdata", para1, true);
            if (dtloc.Rows.Count > 0)
            {
                ddllocation.DataSource = dtloc;
                ddllocation.DataTextField = "Location_name";
                ddllocation.DataValueField = "Location_id";
                ddllocation.DataBind();
                ddllocation.Items.Insert(0, new ListItem(" ", " ", true));
            }
        }

        private void fillFacilityType()
        {
            ddlTypeOfFacility.Items.Clear();
            string ID = "FacilityType";
            SqlParameter[] para1 = new SqlParameter[1];
            para1[0] = new SqlParameter("@ID", ID);
            DataTable dt1 = dal.executeprocedure("sp_getLogvaluebyID", para1, true);           
            if (dt1.Rows.Count > 0)
            {
                ddlTypeOfFacility.DataSource = dt1;
                ddlTypeOfFacility.DataTextField = "Description";
                ddlTypeOfFacility.DataValueField = "Description";
                ddlTypeOfFacility.DataBind();
                ddlTypeOfFacility.Items.Insert(0, new ListItem("", "", true));
            }
        }
        protected void btnAddNewType_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                string g = txtaddTypeOfFacility.Text.Trim();
                int i = 0;
                string ID = "FacilityType";
                SqlParameter[] para = new SqlParameter[1];
                para[0] = new SqlParameter("@ID", ID);
                DataTable dt = dal.executeprocedure("sp_getLogvaluebyID", para, true);
                
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
                    if (txtaddTypeOfFacility.Text.Trim() != "")
                    {
                        SqlParameter[] para2 = new SqlParameter[3];
                        para2[0] = new SqlParameter("@ID", SqlDbType.VarChar);
                        para2[0].Value = "FacilityType";

                        para2[1] = new SqlParameter("@code", SqlDbType.BigInt);
                        para2[1].Value = count;

                        para2[2] = new SqlParameter("@Description", SqlDbType.VarChar);
                        para2[2].Value = txtaddTypeOfFacility.Text.Trim();

                        dal.executeprocedure("SP_InsertLogData", para2);                       
                        fillFacilityType();
                        txtaddTypeOfFacility.Text = "";
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
    }
}
