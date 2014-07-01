using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.BusinessEntities;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SMS.Services.DALUtilities;
using Telerik.Web.UI;
using SMS.SMSCommons;
using SMS.Services.DataService;
using SMS.SuperVisor;
using System.Drawing;
using SMS.SuperVisor;
using SMS.Services.DALUtilities;
using SMS.SMSCommons;
using SMS.Web;
using Telerik.Web.UI;

namespace SMS.Controller
{
    public partial class DescriptionDashBoard : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        int LocID = 0;
        DataTable dt = null;
        public static int countGR = 0;
        public static int countTC = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //====================message display code============================================

            DBConnectionHandler1 db = new DBConnectionHandler1();
            SqlConnection cn = db.getconnection();
            cn.Open();
            String currenthour = string.Empty;
            String currentminute = string.Empty;
            string date = System.DateTime.Now.ToShortDateString();
            SqlCommand cmd = new SqlCommand("SELECT top 1 dbo.Shift_Master.ShiftTimeFrom,dbo.Shift_Master.ShiftTimeTo FROM  dbo.location INNER JOIN  dbo.LocationShiftMap ON dbo.location.Location_id = dbo.LocationShiftMap.LocationID INNER JOIN dbo.Shift_Master ON dbo.LocationShiftMap.ShiftID = dbo.Shift_Master.shift_ID WHERE location.Location_id='" + Request.Params["t1"].ToString() + "' and '" + DateTime.Now.ToShortTimeString() + "' between ShiftTimeFrom and ShiftTimeTo Order By dbo.Shift_Master.shift_ID ASC", cn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr.GetString(0).Length > 9)
                {
                    string curtime = dr.GetString(0).Substring(0, 2);
                    string curtime1 = dr.GetString(0).Substring(2, 2);
                    //Session["currenthour"] = curtime;
                    //Session["currentminute"] = curtime1;
                    //cn.Close();
                    currenthour = curtime;
                    currentminute = curtime1;
                    dr.Close();
                    dr.Dispose();
                    cmd.Dispose();
                }
                else
                {
                    string curtime = dr.GetString(0).Substring(0, 1);
                    string curtime1 = dr.GetString(0).Substring(2, 2);
                    //Session["currenthour"] = curtime;
                    //Session["currentminute"] = curtime1;
                    //cn.Close();
                    currenthour = curtime;
                    currentminute = curtime1;
                    dr.Close();
                    dr.Dispose();
                    cmd.Dispose();
                }
            }
            dr.Close();
            if (currenthour.ToString() != "")
            {

                //cn.Open();
                DataSet ds1 = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter("select Checkin_DateTime,user_name from checkin_manager where LocationID=" + Request.Params["t1"].ToString(), cn);
                adp.Fill(ds1, "temp");
                DataTable dt = ds1.Tables[0];

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string completedate = Convert.ToString(dt.Rows[i]["Checkin_DateTime"]);
                    string[] y = completedate.Split(' ');
                    Session["chkhour"] = y[1].Substring(0, 1);
                    string x = Session["chkhour"].ToString();
                    Session["chkminute"] = y[1].Substring(2, 2);
                    string xx = Session["chkminute"].ToString();
                    if (Convert.ToInt32(Session["chkhour"].ToString()) >= Convert.ToInt32(currenthour.ToString()))
                    {
                        //if (Convert.ToInt32(Session["chkminute"].ToString()) >= Convert.ToInt32(currentminute.ToString()))
                        //{
                        //    dispmessage.Text += dt.Rows[i]["user_name"].ToString() + " is Late By  " + (Convert.ToInt32(Session["chkhour"].ToString()) - Convert.ToInt32(currenthour.ToString())) + ":" + (Convert.ToInt32(Session["chkminute"].ToString()) - Convert.ToInt32(currentminute.ToString())) + ",     ";
                        //}
                    }


                }
                if (dispmessage.Text.ToString() != "")
                {
                    lblLocation.Text = "Message: " + dispmessage.Text;
                    cn.Close();
                }
            }




            //================================================================
            //==============Changes Sandeep Date:10/7/2012======================//
            //System.Threading.Thread.Sleep(2000);
            //==================End Changes================//
            Response.AppendHeader("Refresh", "200");
            if (!IsPostBack)
            {
                string locationID = Request.Params["t1"].ToString();
                LocID = Convert.ToInt32(locationID);
                SqlDataSource ds = (SqlDataSource)TblGrid.FindControl("dsLocation");
                ds.SelectCommand = "SELECT Location_id, Location_name FROM location where Current_Status='Present' and Location_id=" + LocID;
                ds.DataBind();
                //=====================================================//
                if (locationID != null)
                {
                    Session["LCID"] = locationID.ToString();
                    mvGuards.ActiveViewIndex = 0;
                    BindGuardSchedule();

                }

                //BindGuardSchedule(txtdatefrom.Text);

                //=====================================================//
                //grdLeft.DataSource=ds;
                //grdRightMain.DataSource = ds;
                log4net.ILog logger = log4net.LogManager.GetLogger("File");
                try
                {
                    // grdShiftStaff.DataBind();
                    //tmrUpdateSchedule.Enabled = false;

                }
                catch (Exception ex)
                {
                    logger.Info(ex.Message);
                    cn.Close();
                }
                finally
                {
                    cn.Close();
                }
                //Response.AppendHeader("Refresh",20); for auto refreshing the page
            }
        }
        protected void btnContinue_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Server.Transfer("../SMSUsers/AddLocation.aspx");//page not found
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

            if (btnContinue.Text.StartsWith("Start"))
            {
                btnContinue.Text = "Stop Continuous Refreshing";
                //tmrUpdateSchedule.Enabled = true;
            }
            else
            {
                btnContinue.Text = "Start Continuous Refreshing";
                //tmrUpdateSchedule.Enabled = false;
            }
        }
        protected void grdMain_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            //Response.AppendHeader("Refresh", "10");
            //string sql ="SELECT dbo.checkin_manager.user_name, dbo.location.Location_name, dbo.checkout_manager.checkin_time, dbo.checkout_manager.checkout_time,dbo.checkout_manager.checkout_id, dbo.checkin_manager.checkin_id, dbo.Shift_Master.shift_ID, dbo.checkin_manager.Checkin_DateTime,dbo.Shift_Master.ShiftTimeFrom, dbo.Shift_Master.ShiftTimeTo, dbo.checkout_manager.username FROM dbo.LocationShiftMap INNER JOIN dbo.checkin_manager INNER JOIN dbo.checkout_manager ON dbo.checkin_manager.checkin_id = dbo.checkout_manager.checkin_id AND dbo.checkin_manager.checkin_id = dbo.checkout_manager.checkout_id INNER JOIN dbo.location ON dbo.checkin_manager.LocationID = dbo.location.Location_id AND dbo.checkout_manager.LocationID = dbo.location.Location_id ON dbo.LocationShiftMap.LocationID = dbo.location.Location_id INNER JOIN dbo.Shift_Master ON dbo.LocationShiftMap.ShiftID = dbo.Shift_Master.shift_ID"; 
            //string sql = "select Location_name,ShiftTimeFrom,ShiftTimeTo from location,LocationShiftMap,Shift_Master where location.Location_id=LocationShiftMap.LocationID and Shift_Master.shift_ID=LocationShiftMap.ShiftID";
            string sql = "SELECT Location_id, Location_name FROM location where Current_Status='Present' and Location_id=" + LocID;
            DataSet ds = GetDataTable(sql);
            grdMain.DataSource = GetDataTable(sql);
        }

        public DataSet GetDataTable(string query)
        {

            String ConnString = ConfigurationManager.ConnectionStrings["SpaSecureConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(ConnString);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand(query, conn);

            DataSet myDataTable = new DataSet();
            //string x = RadGrid1.Columns[1].Display.ToString();
            conn.Open();
            try
            {
                adapter.Fill(myDataTable, "DashBoard");
            }
            finally
            {
                conn.Close();
            }

            return myDataTable;
        }


        protected void grdMain_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem gr = (GridDataItem)e.Item;
                DataRowView dr = (DataRowView)gr.DataItem;


                GridTableCell Linkcell = (GridTableCell)gr["Location_name"];
                Label link = (Label)Linkcell.FindControl("locationName");
                GridTableCell gpCell = (GridTableCell)gr["checkInUser"];
                RadGrid gpc = (RadGrid)gpCell.FindControl("grdCurrCheckIn1");

                //GridTableCell gpInnerCell = (GridTableCell)gpc.Columns[0];
                //HyperLink Status = (HyperLink)gpInnerCell.FindControl("lblGuardCIStatus");
                //grdCurrCheckIn_ItemDataBound(object sender, GridItemEventArgs e)

                BindSchedule(gpc, dr, "GetCheckedInGuardsNew", false, true, false);
                //RadGrid gv = ((RadGrid)gr.Cells[1].FindControl("grdCurrCheckOuts"));
                GridTableCell gvCell = (GridTableCell)gr["checkOutUser"];
                RadGrid gv = (RadGrid)gpCell.FindControl("grdCurrCheckOuts1");

                BindSchedule(gv, dr, "GetCheckedOutGuardsNew", true, true, true);
                GridTableCell gpCellShift = (GridTableCell)gr["CurrentShift"];
                RadGrid gpcShift = (RadGrid)gpCellShift.FindControl("grdCurrentShift1");

                //string shiftCurrId=BindScheduleShift(gpcShift, dr, "CurrentShiftID", false, true, false);
                //BindScheduleShift1(gpcShift, dr, "CurrentShiftID", false, true, false);
                BindScheduleShift(gpcShift, dr, "CurrentShiftTest", false, true, false);
                //BindCurrShiftData(gpcShift,shiftCurrId,"CurrShiftData",false, true, false);

                GridTableCell gvCellShift = (GridTableCell)gr["NextShift"];
                RadGrid gvShift = (RadGrid)gvCellShift.FindControl("grdNextShift1");

                //string shiftNextId=BindScheduleShift(gvShift, dr, "NextShiftID", false, true, false);
                BindScheduleShift(gvShift, dr, "NextShift", false, true, false);
                //BindNextShiftData(gvShift,shiftNextId,"NextShiftData", false, true, false);
            }


        }
        /*private void BindScheduleShift1(RadGrid gv, DataRowView dr, string spname, bool IsCheckinStatusNeeded, bool IsCheckOutStatusNeeded, bool IsRemovalNeeded)
        {
            DBConnectionHandler1 db = new DBConnectionHandler1();
            SqlConnection cn = db.getconnection();
            cn.Open();
            DataSet ds1 = new DataSet();
            string loc = dr[0].ToString();
            string date = DateTime.Now.ToShortTimeString();
            SqlDataAdapter adp = new SqlDataAdapter("SELECT top 1 dbo.Shift_Master.ShiftTimeFrom,dbo.Shift_Master.ShiftTimeTo FROM  dbo.location INNER JOIN  dbo.LocationShiftMap ON dbo.location.Location_id = dbo.LocationShiftMap.LocationID INNER JOIN dbo.Shift_Master ON dbo.LocationShiftMap.ShiftID = dbo.Shift_Master.shift_ID WHERE location.Location_id='" + loc + "' and '" + date + "' between ShiftTimeFrom and ShiftTimeTo Order By dbo.Shift_Master.shift_ID ASC", cn);
            adp.Fill(ds1, "TEMP");
            gv.ShowHeader = false;
            gv.DataSource = ds1;
            gv.DataBind();
            //======================Date:16/6 Changes:Sandeep==============================//
            cn.Close();
            //=====================================================//

        }*/



        private void BindSchedule(RadGrid gv, DataRowView dr, string spname, bool IsCheckinStatusNeeded, bool IsCheckOutStatusNeeded, bool IsRemovalNeeded)
        {
            string shiftid = "";
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@LocationID", int.Parse(dr[0].ToString()));
            //para[0] = new SqlParameter("@LocationID",LocId);
            // para[1] = new SqlParameter("@CurrDate", DateTime.Now);
            //DataTable dt = dal.executeprocedure(spname, para, false);
            gv.ShowHeader = false;
            //int i = dt.Rows.Count;
            /*while (i > 0)
            {
                gv.DataSource = dt;
                i--;
            }*/
            //gv.DataSource = dt;
            //gv.DataBind();
            //gv.ShowHeader = false;
            ////gv.Text = dt.Rows[0]["Name"].ToString();
            //gv.DataBind();
            //=================Changes By Sandeep Date:28/6/2012=====================//
            if (spname == "GetCheckedInGuardsNew")
            {
                DataTable dt = dal.executeprocedure(spname, para, false);
                gv.DataSource = dt;
                gv.DataBind();
            }
            else if (spname == "GetCheckedOutGuardsNew")
            {
                //===============================Code for dynamic Table Creation===================================================//
                try { dal.executesql("drop table temp_001"); }
                catch (Exception ex) { }
                string temp = "create table temp_001(UserName varchar(50),checkout_time varchar(50))";
                dal.executesql(temp);
                DataTable dt = dal.executeprocedure(spname, para, false);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string FName = dt.Rows[i]["UserName"].ToString();
                    DataTable dtc = dal.getdata("select * from temp_001 where UserName='" + FName + "'");
                    if (dtc.Rows.Count == 0)
                    {
                        string tempInsert = "insert into temp_001(UserName,checkout_time) values('" + dt.Rows[i]["UserName"].ToString() + "','" + dt.Rows[i]["checkout_time"].ToString() + "')";
                        dal.executesql(tempInsert);
                    }


                }
                DataTable dtfetch = dal.getdata("select distinct UserName,checkout_time from temp_001 order by checkout_time desc");
                if (dtfetch.Rows.Count > 0)
                {
                    gv.DataSource = dtfetch;
                    gv.DataBind();
                }
                else
                {
                    gv.DataSource = null;
                    gv.DataBind();
                }
                dal.executesql("drop table temp_001");
                //=====================End Changes===================================//
            }
        }
        //private void BindScheduleShift(RadGrid gv, DataRowView dr, string spname, bool IsCheckinStatusNeeded, bool IsCheckOutStatusNeeded, bool IsRemovalNeeded)
        //{
        //    /*string shiftid = "";
        //    SqlParameter[] para = new SqlParameter[2];
        //    para[0] = new SqlParameter("@LocationID", int.Parse(dr[0].ToString()));
        //    para[1] = new SqlParameter("@CurrentDate", DateTime.Now.ToShortTimeString());
        //    DataTable dt = dal.executeprocedure(spname, para, false);
        //    gv.ShowHeader = false;
        //    int i = dt.Rows.Count;
        //    /*while (i > 0)
        //    {
        //        gv.DataSource = dt;
        //        i--;
        //    }*/
        //    /*gv.DataSource = dt;
        //    gv.DataBind();*/
        //    gv.ShowHeader = false;
        //    DBConnectionHandler1 db = new DBConnectionHandler1();
        //    SqlConnection cn = db.getconnection();
        //    cn.Open();
        //    DataSet ds1 = new DataSet();
        //    string loc = dr[0].ToString();
        //    string date = DateTime.Now.ToShortTimeString();
        //    SqlDataAdapter adp = new SqlDataAdapter("SELECT top 1 dbo.Shift_Master.ShiftTimeFrom,dbo.Shift_Master.ShiftTimeTo FROM  dbo.location INNER JOIN  dbo.LocationShiftMap ON dbo.location.Location_id = dbo.LocationShiftMap.LocationID INNER JOIN dbo.Shift_Master ON dbo.LocationShiftMap.ShiftID = dbo.Shift_Master.shift_ID WHERE location.Location_id='" + loc + "' and '" + date + "' Not between ShiftTimeFrom and ShiftTimeTo Order By dbo.Shift_Master.shift_ID ASC", cn);
        //    adp.Fill(ds1, "TEMP");
        //    gv.DataSource = ds1;
        //    gv.DataBind();
        //    //========================Date:16/6 Changes:Sandeep======//
        //    cn.Close();
        //    //=======================================================//
        //}
        //==========================Changes By Sandeep Date:29/6/2012=======================================//
        private void BindScheduleShift(RadGrid gv, DataRowView dr, string spname, bool IsCheckinStatusNeeded, bool IsCheckOutStatusNeeded, bool IsRemovalNeeded)
        {
            string shiftid = "";
            string shiftTimeFrom = "";
            string shiftTimeTo = "";
            int i = 0;

            DataTable dtCurrShift = null;
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@LocationID", int.Parse(dr[0].ToString()));
            //para[1] = new SqlParameter("@CurrentDate", DateTime.Now.ToShortTimeString());

            if (spname == "CurrentShiftTest")
            {
                DataTable dtShift = dal.executeprocedure("CurrentShiftsMultiple", para, false);
                int l = dtShift.Rows.Count;
                while (l > 0)
                {
                    string cshiftTTF = dtShift.Rows[l - 1]["ShiftTimeFrom"].ToString();
                    string cshiftTTT = dtShift.Rows[l - 1]["ShiftTimeTo"].ToString();
                    string cshiftTF = cshiftTTF.Replace(".", "");
                    string cshiftTT = cshiftTTT.Replace(".", "");
                    string[] cshiftTFArr = cshiftTF.Split(':');
                    int cshiftTFHour = Convert.ToInt32(cshiftTFArr[0].ToString());
                    string[] cshiftTTArr = cshiftTT.Split(':');
                    int cshiftTTHour = Convert.ToInt32(cshiftTTArr[0].ToString());

                    SqlParameter[] shiftPara = new SqlParameter[4];
                    shiftPara[0] = new SqlParameter("@LocationID", int.Parse(dr[0].ToString()));
                    shiftPara[1] = new SqlParameter("@CurrentDate", DateTime.Now.ToShortTimeString());
                    shiftPara[2] = new SqlParameter("@shifttimeFrom", cshiftTF.ToString());
                    shiftPara[3] = new SqlParameter("@shifttimeTo", cshiftTT.ToString());

                    dtCurrShift = dal.executeprocedure(spname, shiftPara, false);
                    if (dtCurrShift.Rows.Count > 0)
                        break;
                    l--;
                }
            }
            else if (spname == "NextShift")
            {
                SqlParameter[] Npara = new SqlParameter[2];
                Npara[0] = new SqlParameter("@LocationID", int.Parse(dr[0].ToString()));
                Npara[1] = new SqlParameter("@CurrentDate", DateTime.Now.ToShortTimeString());
                dtCurrShift = dal.executeprocedure(spname, Npara, false);
            }
            DataTable dtt = null;
            DataTable dttMy = null;
            DataTable dttMe = null;
            gv.ShowHeader = false;
            if (dtCurrShift != null)
            {
                i = dtCurrShift.Rows.Count;
            }
            if (i == 1)
            {
                //gv.DataSource = dtCurrShift;
                //string recentShiftTF = dtCurrShift.Rows[0]["ShiftTimeFrom"].ToString();
                //string recentShiftTT = dtCurrShift.Rows[0]["ShiftTimeTo"].ToString();

                //string[] substrF = recentShiftTF.Split(':');
                //string[] substrT = recentShiftTT.Split(':');

                //int rshiftH = Convert.ToInt32(substrF[0].ToString());
                //int rshiftT = Convert.ToInt32(substrT[0].ToString());

                //string[] sbstrF = substrF[1].Split(' ');
                //string[] sbstrT = substrT[1].Split(' ');

                //string sbstrFType = sbstrF[1].Replace(".", "").ToString();
                //string sbstrTType = sbstrT[1].Replace(".", "").ToString();

                //string currDate = DateTime.Now.ToShortTimeString();
                //string[] substr = currDate.Split(':');
                //int currhour = Convert.ToInt32(substr[0].ToString());
                //string restPart = substr[1].ToString();
                //string[] subRest = restPart.Split(' ');
                //string currtype = subRest[1].ToString();


                //if (sbstrFType == "PM")
                //    rshiftH += 12;
                //if (sbstrTType == "PM")
                //    rshiftT += 12;
                //if (currtype == "PM")
                //    currhour += 12;

                //if ((currhour >= rshiftH) && (currhour <= rshiftT))
                //{
                //    int k = dal.executesql("insert into temp_DashBoard(Location_ID,ShiftTimeFrom,ShiftTimeTo) values (" + int.Parse(dr[0].ToString()) + ",'" + recentShiftTF + "','" + recentShiftTT + "')");
                //    dtt = dal.getdata("select ShiftTimeFrom,ShiftTimeTo from temp_DashBoard where Location_ID='" + int.Parse(dr[0].ToString()) + "'");
                //    int del = dal.executesql("delete from temp_DashBoard where Location_ID='" + int.Parse(dr[0].ToString()) + "'");
                //    gv.DataSource = dtt;
                //    gv.DataBind();

                //}
                //else if ((sbstrFType == "PM") && (sbstrTType == "AM"))
                //{
                //    int k = dal.executesql("insert into temp_DashBoard(Location_ID,ShiftTimeFrom,ShiftTimeTo) values (" + int.Parse(dr[0].ToString()) + ",'" + recentShiftTF + "','" + recentShiftTT + "')");
                //    dtt = dal.getdata("select ShiftTimeFrom,ShiftTimeTo from temp_DashBoard where Location_ID='" + int.Parse(dr[0].ToString()) + "'");
                //    int del = dal.executesql("delete from temp_DashBoard where Location_ID='" + int.Parse(dr[0].ToString()) + "'");
                //    gv.DataSource = dtt;
                //    gv.DataBind(); 
                //}
                //else
                //{
                gv.DataSource = dtCurrShift;
                gv.DataBind();
                //}
            }
            else if (i > 1)
            {
                string currDate = DateTime.Now.ToShortTimeString();
                string[] substr = currDate.Split(':');
                int currhour = Convert.ToInt32(substr[0].ToString());
                string restPart = substr[1].ToString();
                string[] subRest = restPart.Split(' ');
                string currtype = subRest[1].ToString();

                if (currtype == "PM")
                    currhour = currhour + 12;
                while (i > 0)
                {
                    SqlParameter[] mypara = new SqlParameter[2];
                    mypara[0] = new SqlParameter("@LocationID", int.Parse(dr[0].ToString()));
                    mypara[1] = new SqlParameter("@CurrentDate", DateTime.Now.ToShortTimeString());
                    dtt = dal.executeprocedure("NextShiftTime", mypara, false);
                    string shiftTF = dtt.Rows[i - 1]["ShiftTimeFrom"].ToString();
                    string shiftTT = dtt.Rows[i - 1]["ShiftTimeTo"].ToString();
                    string[] shiftTFArr = shiftTF.Split(':');
                    int shiftTFHour = Convert.ToInt32(shiftTFArr[0].ToString());
                    string[] shiftTTArr = shiftTT.Split(':');
                    int shiftTTHour = Convert.ToInt32(shiftTTArr[0].ToString());
                    if (Convert.ToInt32(currhour) <= Convert.ToInt32(shiftTFHour))
                    {
                        shiftTimeFrom = Convert.ToDateTime(shiftTF).ToShortTimeString();
                        //shiftTimeTFrom = shiftTimeFrom.Replace("",".");
                        shiftTimeTo = Convert.ToDateTime(shiftTT).ToShortTimeString();
                        //shiftTimeTTo=shiftTimeTo.Replace("",".");
                        int k = dal.executesql("insert into temp_DashBoard(Location_ID,ShiftTimeFrom,ShiftTimeTo) values (" + int.Parse(dr[0].ToString()) + ",'" + shiftTimeFrom + "','" + shiftTimeTo + "')");
                        dttMy = dal.getdata("select ShiftTimeFrom,ShiftTimeTo from temp_DashBoard where Location_ID='" + int.Parse(dr[0].ToString()) + "'");
                        int del = dal.executesql("delete from temp_DashBoard where Location_ID='" + int.Parse(dr[0].ToString()) + "'");
                    }
                    else
                    {
                        SqlParameter[] myLpara = new SqlParameter[4];
                        myLpara[0] = new SqlParameter("@LocationID", int.Parse(dr[0].ToString()));
                        myLpara[1] = new SqlParameter("@CurrentDate", DateTime.Now.ToShortTimeString());
                        myLpara[2] = new SqlParameter("@shiftTo", shiftTimeTo.ToString());
                        myLpara[3] = new SqlParameter("@shiftFrom", shiftTimeFrom.ToString());
                        //dttMe = dal.executeprocedure("NextShiftSpecial", myLpara, false);
                        dttMe = dal.executeprocedure("TestShift", myLpara, false);
                        if (dttMe != null)
                        {
                            string shifttf = dttMe.Rows[0]["ShiftTimeFrom"].ToString();
                            string shiftto = dttMe.Rows[0]["ShiftTimeTo"].ToString();
                            int k = dal.executesql("insert into temp_DashBoard(Location_ID,ShiftTimeFrom,ShiftTimeTo) values (" + int.Parse(dr[0].ToString()) + ",'" + shifttf + "','" + shiftto + "')");
                            dttMy = dal.getdata("select ShiftTimeFrom,ShiftTimeTo from temp_DashBoard where Location_ID='" + int.Parse(dr[0].ToString()) + "'");
                            int del = dal.executesql("delete from temp_DashBoard where Location_ID='" + int.Parse(dr[0].ToString()) + "'");
                        }
                        else
                        {
                            int k = dal.executesql("insert into temp_DashBoard(Location_ID,ShiftTimeFrom,ShiftTimeTo) values (" + int.Parse(dr[0].ToString()) + ",'00:00 AM','00:00 PM')");
                            dttMy = dal.getdata("select ShiftTimeFrom,ShiftTimeTo from temp_DashBoard where Location_ID='" + int.Parse(dr[0].ToString()) + "'");
                            int del = dal.executesql("delete from temp_DashBoard where Location_ID='" + int.Parse(dr[0].ToString()) + "'");
                        }


                    }

                    i--;
                }
                gv.DataSource = dttMy;
                gv.DataBind();
            }
            else
            {
                gv.MasterTableView.NoRecordsTemplate = new MyNoRecordsTemplate();
            }
        }


        //====================End Changes=================================//
        //========================Changes Sandeep Date:7/7/2012=========================================//

        /*protected void grdLeft_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            
            if (e.Item is GridDataItem)
            {
                GridDataItem gr = (GridDataItem)e.Item;
                DataRowView dr = (DataRowView)gr.DataItem;

                GridTableCell gTblCUser = (GridTableCell)gr["checkInSecurity"];
                RadGrid grdCUser = (RadGrid)gTblCUser.FindControl("grdCurrCheckInSecurity");
                BindSchedule(grdCUser, dr, "GetCheckedInGuardsNew", false, true, false);

            }
        }*/

        /*protected void grdRightMain_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem gr = (GridDataItem)e.Item;
                DataRowView dr = (DataRowView)gr.DataItem;

                GridTableCell gTblCUser = (GridTableCell)gr["checkOutSecurity"];
                RadGrid grdCUser = (RadGrid)gTblCUser.FindControl("grdCurrCheckOutSecurity");
                BindSchedule(grdCUser, dr, "GetCheckedOutGuardsNew", false, true, false);

            }
        }*/
        //===========================End Changes=================================//
        private void BindGuardSchedule()
        {
            DateTime temp;
            //if (DateTime.TryParse(date, out temp))
            if (Session["LCID"] != null)
            {

                SqlParameter[] para = new SqlParameter[1];
                para[0] = new SqlParameter("@LocationID", Session["LCID"].ToString());
                //para[1] = new SqlParameter("@CurrentTime", DateTime.Now.ToShortTimeString());
                //para[1] = new SqlParameter("@MDate", date);
                //DataTable dt = dal.executeprocedure1("usp_GetDailySchedule1", para, false);
                //==========================Working Code Date:11/7/2012=====================//
                //=================Purpose:Show Grid which Shows Current User With Current Time======//
                /*
                DataTable dt = dal.executeprocedure("SP_DescriptionDashBoard",para, false);
                if (dt.Rows.Count > 0)
                {
                    grdSchedule.DataSource = dt;
                    grdSchedule.DataBind();
                }
                else
                {
                    grdSchedule.DataSource = null;
                    grdSchedule.DataBind();
                }*/
                //=======================================================================//



                //=========================Changes By:Sandeep Date:16/6/2012========================//
                dt = dal.executeprocedure("usp_GetDailyScheduleLatestForDistinctGaurds", para, false);
                //==================================================================================//
                DataTable dt1 = SMSCommons.SMSCommon.ConvertRowsToColumns(dt, "Shift", "StaffName");
                //DataTable dt1 = SMSCommons.smscom.ConvertRowsToColumns(dt, "Shift", "StaffName");



                grdSchedule.AutoGenerateColumns = false;
                for (int i = 0; i < grdSchedule.Columns.Count; i++)
                {
                    try
                    {
                        grdSchedule.Columns.RemoveAt(0);
                    }
                    catch (Exception ex)
                    {

                    }
                }

                foreach (DataColumn dc in dt1.Columns)
                {
                    TemplateField makeliveCol = new TemplateField();
                    makeliveCol.ItemTemplate = new CreateItemTemplateLinkBtn(System.Guid.NewGuid().ToString().Split('-')[System.Guid.NewGuid().ToString().Split('-').Length - 1], dc.ColumnName, "MakeLive", "return confirm('Are you sure you want to publish this version?')");
                    makeliveCol.HeaderText = dc.ColumnName;
                    makeliveCol.HeaderStyle.Width = Unit.Pixel(180);
                    makeliveCol.ItemStyle.Height = Unit.Pixel(30);
                    makeliveCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
                    makeliveCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                    grdSchedule.Columns.Add(makeliveCol);
                    //grdMy.Columns.Add(makeliveCol);
                }
                grdSchedule.DataSource = dt1;
                grdSchedule.DataBind();


                string script = "";

                //=========================Changes By:Date:11/7/2012============================================//
                //==========Purpose:To show the same grid as in Login.aspx page for current assigned users=====//
                int grdcount = grdSchedule.Rows.Count;
                foreach (GridViewRow gvrSecurity in grdSchedule.Rows)
                {
                    int gvrgrid = gvrSecurity.Cells.Count;
                    foreach (TableCell tcSecurity in gvrSecurity.Cells)
                    {


                        LinkButton lnkUser = new LinkButton();
                        lnkUser = ((LinkButton)tcSecurity.Controls[0]);
                        //string xx = dt1.Rows[countTC][countGR].ToString();
                        string xx = dt1.Rows[grdSchedule.Rows.Count - grdcount][gvrSecurity.Cells.Count - gvrgrid].ToString();
                        gvrgrid = gvrgrid - 1;

                        if (gvrgrid == 0) { grdcount = grdcount - 1; }

                        if (xx != "")
                        {
                            string[] yy = xx.Split('|');
                            lnkUser.Text = yy[0].ToString();
                            lnkUser.ToolTip = yy[4].ToString();
                            lnkUser.ForeColor = Color.Black;
                            lnkUser.Font.Bold = true;
                            lnkUser.Font.Underline = false;

                        }




                        //=======Changes By:Sandeep Date:22/6/2012========//
                        string StaffID = lnkUser.ToolTip.ToString();
                        //=========================================================//

                        lnkUser.PostBackUrl = "~/ADMIN/ProfileUser.aspx?t1=" + StaffID.ToString();

                    }

                }
                //============================End Changes==============================//

            }





        }
    }
}