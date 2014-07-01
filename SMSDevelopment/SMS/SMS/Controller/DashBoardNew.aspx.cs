using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using SMS.Services.DALUtilities;
using Telerik.Web.UI;
using SMS.SMSCommons;
using SMS.Services.DataService;
using SMS.SuperVisor;
using System.Drawing;
using SMS.Web;
using SMS.master;

namespace SMS.Controller
{
    public partial class DashBoardNew : System.Web.UI.Page
    {
        int LocID = 0;
        DataTable dt = null;
        public static int countGR = 0;
        public static int countTC = 0;
        DBConnectionHandler1 cn = new DBConnectionHandler1();
        DataAccessLayer dal = new DataAccessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime dt = new DateTime();
            string str = DateTime.Now.ToShortTimeString();
            int LocationID = 0;

            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                // grdShiftStaff.DataBind();
                if (!IsPostBack)
                {
                    //tmrUpdateSchedule.Enabled = false;
                }
                BindgrdSchedule();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

            //string sql = "SELECT dbo.checkin_manager.user_name, dbo.location.Location_name, dbo.checkout_manager.checkin_time, dbo.checkout_manager.checkout_time,dbo.checkout_manager.checkout_id, dbo.checkin_manager.checkin_id, dbo.Shift_Master.shift_ID, dbo.checkin_manager.Checkin_DateTime,dbo.Shift_Master.ShiftTimeFrom, dbo.Shift_Master.ShiftTimeTo, dbo.checkout_manager.username FROM dbo.LocationShiftMap INNER JOIN dbo.checkin_manager INNER JOIN dbo.checkout_manager ON dbo.checkin_manager.checkin_id = dbo.checkout_manager.checkin_id AND dbo.checkin_manager.checkin_id = dbo.checkout_manager.checkout_id INNER JOIN dbo.location ON dbo.checkin_manager.LocationID = dbo.location.Location_id AND dbo.checkout_manager.LocationID = dbo.location.Location_id ON dbo.LocationShiftMap.LocationID = dbo.location.Location_id INNER JOIN dbo.Shift_Master ON dbo.LocationShiftMap.ShiftID = dbo.Shift_Master.shift_ID";
            //string sql = "select Location_name,ShiftTimeFrom,ShiftTimeTo from location,LocationShiftMap,Shift_Master where location.Location_id=LocationShiftMap.LocationID and Shift_Master.shift_ID=LocationShiftMap.ShiftID";
            //Response.AppendHeader("Refresh", "2");  how to autoRefresh page on page Load 
            //Response.Write("<script>alert('"+str+"')</script>");


            //string[] substr = ct.Split(' ');
            //for (int i=0;i<substr.Length;i++)
            //{
            //    Response.Write("Elements:"+substr[i]);
            //    Response.Write("\n");
            //}
            //Label1.Text = substr[0].ToString();
            //Label2.Text = substr[1].ToString();
            //Label3.Text = substr[2].ToString();
            //RadGrid1.DataSource = GetDataTable(sql);
        }
        protected void btnContinue_Click(object sender, EventArgs e)
        {
            SpaMaster MyMasterPage = (SpaMaster)Page.Master;
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
                MyMasterPage.ShowErrorMessage("Stop Continuous Refreshing");

                //btnContinue.Text = "Stop Continuous Refreshing";
                //tmrUpdateSchedule.Enabled = true;
            }
            else
            {
                MyMasterPage.ShowErrorMessage("Start Continuous Refreshing");


                btnContinue.Text = "Start Continuous Refreshing";
                //tmrUpdateSchedule.Enabled = false;
            }
        }
        protected void btnRef_Click(object sender, EventArgs e)
        {

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
        protected void RadGrid1_NeedDataSource1(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            //Response.AppendHeader("Refresh", "10");
            //string sql ="SELECT dbo.checkin_manager.user_name, dbo.location.Location_name, dbo.checkout_manager.checkin_time, dbo.checkout_manager.checkout_time,dbo.checkout_manager.checkout_id, dbo.checkin_manager.checkin_id, dbo.Shift_Master.shift_ID, dbo.checkin_manager.Checkin_DateTime,dbo.Shift_Master.ShiftTimeFrom, dbo.Shift_Master.ShiftTimeTo, dbo.checkout_manager.username FROM dbo.LocationShiftMap INNER JOIN dbo.checkin_manager INNER JOIN dbo.checkout_manager ON dbo.checkin_manager.checkin_id = dbo.checkout_manager.checkin_id AND dbo.checkin_manager.checkin_id = dbo.checkout_manager.checkout_id INNER JOIN dbo.location ON dbo.checkin_manager.LocationID = dbo.location.Location_id AND dbo.checkout_manager.LocationID = dbo.location.Location_id ON dbo.LocationShiftMap.LocationID = dbo.location.Location_id INNER JOIN dbo.Shift_Master ON dbo.LocationShiftMap.ShiftID = dbo.Shift_Master.shift_ID"; 
            //string sql = "select Location_name,ShiftTimeFrom,ShiftTimeTo from location,LocationShiftMap,Shift_Master where location.Location_id=LocationShiftMap.LocationID and Shift_Master.shift_ID=LocationShiftMap.ShiftID";
            string sql = "SELECT Location_id, Location_name FROM location where Current_Status='Present' order by Location_name Asc";
            DataSet ds = GetDataTable(sql);
            RadGrid1.DataSource = GetDataTable(sql);
        }

        ///////////////////////*********code to show popup on hyperlinks in grid*************/////////////////////////////

        protected void RadGrid1_ItemCreated(object sender, GridItemEventArgs e)
        {
            //if ((e.Item is GridHeaderItem))
            //{
            //    GridHeaderItem header = (GridHeaderItem)e.Item;
            //    //GridDataItem parentItem = (GridDataItem)e.Item.OwnerTableView.ParentItem;
            //    //GridTableView Detailtable = (GridTableView)e.Item.OwnerTableView;

            //    //header["Location_name"].Text ="LocationName";
            //    //header["Checkin_DateTime"].Text ="Chekin/Checkout Duration";
            //    //header["Current_Status"].Text ="Checkin/Checkout Status";
            //    //header["user_name"].Text ="UserName";

            //} 
        }
        protected void grdCurrentShift_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                //GridDataItem gr = (GridDataItem)e.Item;
                //DataRowView dr = (DataRowView)gr.DataItem;
            }
        }
        protected void grdCurrentNext_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {


            }
        }
        protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
        {
            //string sql = "SELECT dbo.checkin_manager.user_name, dbo.location.Location_name, dbo.checkout_manager.checkin_time, dbo.checkout_manager.checkout_time,dbo.checkout_manager.checkout_id, dbo.checkin_manager.checkin_id, dbo.Shift_Master.shift_ID, dbo.checkin_manager.Checkin_DateTime,dbo.Shift_Master.ShiftTimeFrom, dbo.Shift_Master.ShiftTimeTo, dbo.checkout_manager.username FROM dbo.LocationShiftMap INNER JOIN dbo.checkin_manager INNER JOIN dbo.checkout_manager ON dbo.checkin_manager.checkin_id = dbo.checkout_manager.checkin_id AND dbo.checkin_manager.checkin_id = dbo.checkout_manager.checkout_id INNER JOIN dbo.location ON dbo.checkin_manager.LocationID = dbo.location.Location_id AND dbo.checkout_manager.LocationID = dbo.location.Location_id ON dbo.LocationShiftMap.LocationID = dbo.location.Location_id INNER JOIN dbo.Shift_Master ON dbo.LocationShiftMap.ShiftID = dbo.Shift_Master.shift_ID";
            //string sql = "select Location_name,ShiftTimeFrom,ShiftTimeTo from location,LocationShiftMap,Shift_Master where location.Location_id=LocationShiftMap.LocationID and Shift_Master.shift_ID=LocationShiftMap.ShiftID";
            //string[] x = new string[20];
            //DataTable dtt = new DataTable();
            //SqlConnection _cn = cn.getconnection();

            //SqlCommand cmd = new SqlCommand(sql, _cn);
            //dtt = cn.getData(cmd);
            if (e.Item is GridDataItem)
            {
                GridDataItem gr = (GridDataItem)e.Item;

                DataRowView dr = (DataRowView)gr.DataItem;

                //RadGrid gpc = ((RadGrid)gr.Cells[1].FindControl("grdCurrCheckIn"));
                //RadGrid gpc=((RadGrid))gr.Cells[1].FindControl("grdCurrCheckIn"));
                GridTableCell Linkcell = (GridTableCell)gr["Location_name"];

                //=========================Ruchi 2/6/14====================================//
                //HyperLink link = (HyperLink)Linkcell.FindControl("locationName");
                LinkButton link = (LinkButton)Linkcell.FindControl("locationName");

                //========================================================================//

                GridTableCell NavigateID = (GridTableCell)gr["NavigateID"];
                Label loc_ID = (Label)NavigateID.FindControl("lblLocid");
                // link.NavigateUrl ="DescriptionDashBoard.aspx?t1="+loc_ID.Text.ToString();
                link.CommandArgument = loc_ID.Text.ToString();
                link.CommandName = "Location";
                GridTableCell gpCell = (GridTableCell)gr["checkInUser"];
                RadGrid gpc = (RadGrid)gpCell.FindControl("grdCurrCheckIn");

                //GridTableCell gpInnerCell = (GridTableCell)gpc.Columns[0];
                //HyperLink Status = (HyperLink)gpInnerCell.FindControl("lblGuardCIStatus");
                //grdCurrCheckIn_ItemDataBound(object sender, GridItemEventArgs e);

                //GridDataItem gpGridInner = (GridDataItem)e.Item;
                //GridTableCell gpInnerCell = (GridTableCell)gpGridInner("checkInUserInner");
                //Label gpc = (Label)gpInnerCell.FindControl("lblGuardName");

                BindSchedule(gpc, dr, "GetCheckedInGuardsNew", false, true, false);

                //RadGrid gv = ((RadGrid)gr.Cells[1].FindControl("grdCurrCheckOuts"));
                GridTableCell gvCell = (GridTableCell)gr["checkOutUser"];
                RadGrid gv = (RadGrid)gpCell.FindControl("grdCurrCheckOuts");

                BindSchedule(gv, dr, "GetCheckedOutGuardsNew", false, true, false);

                GridTableCell gpCellShift = (GridTableCell)gr["CurrentShift"];
                RadGrid gpcShift = (RadGrid)gpCellShift.FindControl("grdCurrentShift");

                //string shiftCurrId=BindScheduleShift(gpcShift, dr, "CurrentShiftID", false, true, false);
                BindScheduleShift(gpcShift, dr, "CurrentShiftTest", false, true, false);
                //BindScheduleCurrShift(gpcShift, dr, "CurrentShiftTest", false, true, false);
                //BindScheduleCurrentShift(gpcShift, dr, " ", false, true, false);
                //BindCurrShiftData(gpcShift,shiftCurrId,"CurrShiftData",false, true, false);

                GridTableCell gvCellShift = (GridTableCell)gr["NextShift"];
                RadGrid gvShift = (RadGrid)gvCellShift.FindControl("grdNextShift");

                //string shiftNextId=BindScheduleShift(gvShift, dr, "NextShiftID", false, true, false);
                //BindScheduleNexShift(gvShift, dr, "NextShift", false, true, false);
                BindScheduleShift(gvShift, dr, "NextShift", false, true, false);
                //BindScheduleNextShift(gvShift, dr, " ", false, true, false);
                //BindNextShiftData(gvShift,shiftNextId,"NextShiftData", false, true, false);
            }


        }
        protected void grdCurrCheckIn_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                /*changes not needed*/
                //GridDataItem grr = (GridDataItem)e.Item;
                //DataRowView drr = (DataRowView)grr.DataItem;

                //GridTableCell Linkcell = (GridTableCell)grr["checkInUserInner"];
                //HyperLink link = (HyperLink)Linkcell.FindControl("lblGuardCIStatus");
                //link.ForeColor = System.Drawing.Color.Green;
                /*End Changes*/
            }
        }

        private void BindSchedule(RadGrid gv, DataRowView dr, string spname, bool IsCheckinStatusNeeded, bool IsCheckOutStatusNeeded, bool IsRemovalNeeded)
        {
            string shiftid = "";
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@LocationID", int.Parse(dr[0].ToString()));
            //para[1] = new SqlParameter("@CurrDate", DateTime.Now);
            //DataTable dt = dal.executeprocedure(spname, para, false);
            gv.ShowHeader = false;
            //int i = dt.Rows.Count;
            /*while (i> 0)
            {
                gv.DataSource = dt;
                i--;
            }*/
            //gv.DataBind();
            //gv.ShowHeader = false;
            //gv.Text = dt.Rows[0]["Name"].ToString();
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
                string temp = "create table temp_001(UserName varchar(50),checkout_time varchar(50),userid varchar(50))";
                dal.executesql(temp);
                DataTable dt = dal.executeprocedure(spname, para, false);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string FName = dt.Rows[i]["UserName"].ToString();
                    DataTable dtc = dal.getdata("select * from temp_001 where UserName='" + FName + "'");
                    if (dtc.Rows.Count == 0)
                    {
                        string tempInsert = "insert into temp_001(UserName,checkout_time,userid) values('" + dt.Rows[i]["UserName"].ToString() + "','" + dt.Rows[i]["checkout_time"].ToString() + "','" + dt.Rows[i]["userid"].ToString() + "')";
                        dal.executesql(tempInsert);
                    }


                }
                DataTable dtfetch = dal.getdata("select distinct checkout_time,UserName,userid from temp_001 order by checkout_time desc");
                if (dtfetch.Rows.Count > 0)
                {
                    gv.DataSource = dtfetch;
                    gv.DataBind();
                }
                else
                {
                    //Changes By Sandeep Date:22/8/2012 Purpose:To Display No Record Template
                    gv.DataSource = String.Empty;
                    gv.DataBind();
                    //End Changes
                }
                dal.executesql("drop table temp_001");
                //=====================End Changes===================================//
            }
        }
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
                //gv.MasterTableView.NoRecordsTemplate = new MyNoRecordsTemplate();
                //changes By Sandeep Date:22/8/2012 Purpose:To Display No Record Template
                gv.DataSource = String.Empty;
                gv.DataBind();
                //End Changes
            }
        }
        #region Not Used Code
        /*private void BindScheduleCurrentShift(RadGrid gv, DataRowView dr, string strSql, bool IsCheckinStatusNeeded, bool IsCheckOutStatusNeeded, bool IsRemovalNeeded)
        {
            string shiftid = "";
            SqlParameter[] para = new SqlParameter[2];
            //para[0] = new SqlParameter("@LocationID", int.Parse(dr[0].ToString()));
            //para[1] = new SqlParameter("@CurrentDate", DateTime.Now.ToShortTimeString());
            
            int x=int.Parse(dr[0].ToString());

            string currDate=DateTime.Now.ToShortTimeString();
            string[] substr = currDate.Split(':');
            string currhour = substr[0].ToString();
            string restPart = substr[1].ToString();
            string[] subRest = restPart.Split(' ');
            string currtype = subRest[1].ToString();
            //DataTable dt = dal.executeprocedure(spname, para, false);
            DataTable dtt=null;
            DataTable dt = dal.getdata("SELECT Shift_Master.ShiftTimeFrom,Shift_Master.ShiftTimeTo FROM location INNER JOIN LocationShiftMap ON location.Location_id = LocationShiftMap.LocationID INNER JOIN Shift_Master ON LocationShiftMap.ShiftID = Shift_Master.shift_ID WHERE location.Location_id='"+x+"' ");
            int i=dt.Rows.Count;
            while ( i > 0)
            {
                string shiftTimeFrom = dt.Rows[i-1]["ShiftTimeFrom"].ToString();
                string[] shiftSub = shiftTimeFrom.Split(':');
                string shiftHour = shiftSub[0].ToString();
                string shiftRest = shiftSub[1].ToString();
                string[] shiftTF = shiftRest.Split(' ');
                string shifttype = shiftTF[1].ToString();
                string shiftTFtype = shifttype.Replace(".","");
                string shiftTimeTo = dt.Rows[i-1]["ShiftTimeTo"].ToString();
                string[] shifttoSub = shiftTimeTo.Split(':');
                string shifttoHour = shifttoSub[0].ToString();
                string shifttoRest = shifttoSub[1].ToString();
                string[] shiftTT = shifttoRest.Split(' ');
                string shiftTtype = shiftTT[1].ToString();
                string shiftTotype = shiftTtype.Replace(".", "");
                if (Convert.ToInt32(currhour) >= Convert.ToInt32(shiftHour) && Convert.ToInt32(currhour) <= Convert.ToInt32(shifttoHour))
                {
                    if (currtype == shiftTFtype && currtype == shiftTotype)
                    {
                        int k = dal.executesql("insert into temp_DashBoard(Location_ID,ShiftTimeFrom,ShiftTimeTo) values (" + int.Parse(dr[0].ToString()) + ",'" + shiftTimeFrom + "','" + shiftTimeTo + "')");
                        //dtt = dal.getdata("SELECT Shift_Master.ShiftTimeFrom,Shift_Master.ShiftTimeTo FROM location INNER JOIN LocationShiftMap ON location.Location_id = LocationShiftMap.LocationID INNER JOIN Shift_Master ON LocationShiftMap.ShiftID = Shift_Master.shift_ID WHERE location.Location_id='" + x + "' and '" + currhour + "' Between '"+shiftHour+"' and '"+shifttoHour+"' ");
                        //dtt = shiftTimeFrom + "             " + shiftTimeTo;
                        dtt = dal.getdata("select ShiftTimeFrom,ShiftTimeTo from temp_DashBoard where Location_ID='" + int.Parse(dr[0].ToString()) + "'");
                        int del = dal.executesql("delete from temp_DashBoard where Location_ID='" + int.Parse(dr[0].ToString()) + "'");
                    }
                }
                else 
                {
                    //gv.MasterTableView.NoRecordsTemplate = new MyNoRecordsTemplate();
                }
                
                i--;
            }
            gv.ShowHeader = false;
            
            gv.DataSource = dtt;
            gv.DataBind();
            //if (dt.Rows.Count > 0)
            //{
            //    shiftid = dt.Rows[0][0].ToString().Split(new string[] { "||" }, StringSplitOptions.None)[dt.Rows[0][0].ToString().Split(new string[] { "||" }, StringSplitOptions.None).Length - 1];
            //}
            //RadGrid grdSchedule = gv;
            //grdSchedule.AutoGenerateColumns = false;
            //return shiftid;
        }
        private void BindScheduleNextShift(RadGrid gv, DataRowView dr, string strSql, bool IsCheckinStatusNeeded, bool IsCheckOutStatusNeeded, bool IsRemovalNeeded)
        {
            string shiftid = "";
            SqlParameter[] para = new SqlParameter[2];
            //para[0] = new SqlParameter("@LocationID", int.Parse(dr[0].ToString()));
            //para[1] = new SqlParameter("@CurrentDate", DateTime.Now.ToShortTimeString());

            int x = int.Parse(dr[0].ToString());

            string currDateNext = DateTime.Now.ToShortTimeString();
            string[] substrNext = currDateNext.Split(':');
            string currhourNext = substrNext[0].ToString();
            string restPartNext = substrNext[1].ToString();
            string[] subRestNext = restPartNext.Split(' ');
            string currtypeNext = subRestNext[1].ToString();
            string currexactNext = currtypeNext.Replace("",".");
            //DataTable dt = dal.executeprocedure(spname, para, false);
            DataTable dttNext = null;
            //DataTable dttGlobal = null;
            DataTable dt = dal.getdata("SELECT dbo.Shift_Master.ShiftTimeFrom,dbo.Shift_Master.ShiftTimeTo FROM dbo.location INNER JOIN dbo.LocationShiftMap ON dbo.location.Location_id = dbo.LocationShiftMap.LocationID INNER JOIN dbo.Shift_Master ON dbo.LocationShiftMap.ShiftID = dbo.Shift_Master.shift_ID WHERE location.Location_id='" +int.Parse(dr[0].ToString())+ "' and '" +currDateNext+ "' not between ShiftTimeFrom and ShiftTimeTo Order By dbo.Shift_Master.shift_ID ASC ");
            //DataTable dt = dal.getdata("SELECT Shift_Master.ShiftTimeFrom,Shift_Master.ShiftTimeTo FROM location INNER JOIN LocationShiftMap ON location.Location_id = LocationShiftMap.LocationID INNER JOIN Shift_Master ON LocationShiftMap.ShiftID = Shift_Master.shift_ID WHERE location.Location_id='" + x + "' ");
            int i = dt.Rows.Count;
            while (i > 0)
            {
                string shiftTimeFromNext = dt.Rows[i - 1]["ShiftTimeFrom"].ToString();
                string[] shiftSubNext = shiftTimeFromNext.Split(':');
                string shiftHourNext = shiftSubNext[0].ToString();
                string shiftRestNext = shiftSubNext[1].ToString();
                string[] shiftTFNext = shiftRestNext.Split(' ');
                string shifttypeNext = shiftTFNext[1].ToString();
                string shiftTFtypeNext = shifttypeNext.Replace(".", "");
                string shiftTimeToNext = dt.Rows[i - 1]["ShiftTimeTo"].ToString();
                string[] shifttoSubNext = shiftTimeToNext.Split(':');
                string shifttoHourNext = shifttoSubNext[0].ToString();
                string shifttoRestNext = shifttoSubNext[1].ToString();
                string[] shiftTTNext = shifttoRestNext.Split(' ');
                string shiftTtypeNext = shiftTTNext[1].ToString();
                string shiftTotypeNext = shiftTtypeNext.Replace(".", "");
                //if (Convert.ToInt32(currhourNext) <= Convert.ToInt32(shiftHourNext) && Convert.ToInt32(currhourNext) <= Convert.ToInt32(shifttoHourNext))
                //{
                    if (currtypeNext == shiftTFtypeNext && currtypeNext == shiftTotypeNext)
                    {
                        string currTime = currhourNext + ' ' + currexactNext;
                        //dttGlobal = dal.getdata("SELECT dbo.Shift_Master.ShiftTimeFrom,dbo.Shift_Master.ShiftTimeTo FROM dbo.location INNER JOIN dbo.LocationShiftMap ON dbo.location.Location_id = dbo.LocationShiftMap.LocationID INNER JOIN dbo.Shift_Master ON dbo.LocationShiftMap.ShiftID = dbo.Shift_Master.shift_ID WHERE location.Location_id='" + int.Parse(dr[0].ToString()) + "' and '" + currTime + "' not between ShiftTimeFrom and ShiftTimeTo Order By dbo.Shift_Master.shift_ID ASC ");
                        int k = dal.executesql("insert into temp_DashBoard(Location_ID,ShiftTimeFrom,ShiftTimeTo) values (" + int.Parse(dr[0].ToString()) + ",'" + shiftTimeFromNext + "','" + shiftTimeToNext + "')");
                        //dtt = dal.getdata("SELECT Shift_Master.ShiftTimeFrom,Shift_Master.ShiftTimeTo FROM location INNER JOIN LocationShiftMap ON location.Location_id = LocationShiftMap.LocationID INNER JOIN Shift_Master ON LocationShiftMap.ShiftID = Shift_Master.shift_ID WHERE location.Location_id='" + x + "' and '" + currhour + "' Between '"+shiftHour+"' and '"+shifttoHour+"' ");
                        //dtt = shiftTimeFrom + "             " + shiftTimeTo;
                        dttNext = dal.getdata("select ShiftTimeFrom,ShiftTimeTo from temp_DashBoard where Location_ID='" + int.Parse(dr[0].ToString()) + "'");
                        int del = dal.executesql("delete from temp_DashBoard where Location_ID='" + int.Parse(dr[0].ToString()) + "'");
                    }
                //}
                else
                {
                    //gv.MasterTableView.NoRecordsTemplate = new MyNoRecordsTemplate();
                }

                i--;
            }
            gv.ShowHeader = false;

            gv.DataSource = dttNext;
            gv.DataBind();
            //if (dt.Rows.Count > 0)
            //{
            //    shiftid = dt.Rows[0][0].ToString().Split(new string[] { "||" }, StringSplitOptions.None)[dt.Rows[0][0].ToString().Split(new string[] { "||" }, StringSplitOptions.None).Length - 1];
            //}
            //RadGrid grdSchedule = gv;
            //grdSchedule.AutoGenerateColumns = false;
            //return shiftid;
        }*/
        #endregion
        private void BindCurrShiftData(RadGrid gv, string dr, string spname, bool IsCheckinStatusNeeded, bool IsCheckOutStatusNeeded, bool IsRemovalNeeded)
        {
            string shiftid = "";
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@ShiftID", dr.ToString());
            gv.ShowHeader = false;
            DataTable dt = dal.executeprocedure(spname, para, false);
            gv.ShowHeader = false;
            gv.DataSource = dt;
            gv.DataBind();

        }
        private void BindNextShiftData(RadGrid gv, string dr, string spname, bool IsCheckinStatusNeeded, bool IsCheckOutStatusNeeded, bool IsRemovalNeeded)
        {
            string shiftid = "";
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@ShiftId", dr.ToString());
            gv.ShowHeader = false;
            DataTable dt = dal.executeprocedure(spname, para, false);
            gv.ShowHeader = false;
            gv.DataSource = dt;
            gv.DataBind();

        }
        protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Location")
            {
                string LocationName = e.CommandArgument.ToString();
                ShowPopup(LocationName);
                this.ModalPopupUpdate.Show();
            }
        }
        protected void grdCurrCheckIn_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "CheckIN")
            {
                string CheckIN = e.CommandArgument.ToString();
                PopulatePageCntrls(CheckIN);
                this.ModalPopupAdd.Show();
            }
        }
        protected void grdCurrCheckOuts_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "CheckOut")
            {
                string CheckOut = e.CommandArgument.ToString();
                PopulatePageCntrls(CheckOut);
                this.ModalPopupAdd.Show();
            }
        }


        #region Popup
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.ModalPopupUpdate.Hide();
        }
        public void ShowPopup(string locationName)
        {
            DBConnectionHandler1 db = new DBConnectionHandler1();
            SqlConnection cn = db.getconnection();
            cn.Open();
            String currenthour = string.Empty;
            String currentminute = string.Empty;
            string date = System.DateTime.Now.ToShortDateString();
            //SqlCommand cmd = new SqlCommand("SELECT top 1 dbo.Shift_Master.ShiftTimeFrom,dbo.Shift_Master.ShiftTimeTo FROM  dbo.location INNER JOIN  dbo.LocationShiftMap ON dbo.location.Location_id = dbo.LocationShiftMap.LocationID INNER JOIN dbo.Shift_Master ON dbo.LocationShiftMap.ShiftID = dbo.Shift_Master.shift_ID WHERE location.Location_id='" + Request.Params["t1"].ToString() + "' and '" + DateTime.Now.ToShortTimeString() + "' between ShiftTimeFrom and ShiftTimeTo Order By dbo.Shift_Master.shift_ID ASC", cn);
            SqlCommand cmd = new SqlCommand("SELECT top 1 dbo.Shift_Master.ShiftTimeFrom,dbo.Shift_Master.ShiftTimeTo FROM  dbo.location INNER JOIN  dbo.LocationShiftMap ON dbo.location.Location_id = dbo.LocationShiftMap.LocationID INNER JOIN dbo.Shift_Master ON dbo.LocationShiftMap.ShiftID = dbo.Shift_Master.shift_ID WHERE location.Location_id='" + locationName + "' and '" + DateTime.Now.ToShortTimeString() + "' between ShiftTimeFrom and ShiftTimeTo Order By dbo.Shift_Master.shift_ID ASC", cn);
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
                SqlDataAdapter adp = new SqlDataAdapter("select Checkin_DateTime,user_name from checkin_manager where LocationID=" + locationName, cn);
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
            string locationID = locationName;
            LocID = Convert.ToInt32(locationID);
            SqlDataSource ds = (SqlDataSource)TblGrid.FindControl("SqlDataSourcegridmain");
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
        protected void grdMain_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            //Response.AppendHeader("Refresh", "10");
            //string sql ="SELECT dbo.checkin_manager.user_name, dbo.location.Location_name, dbo.checkout_manager.checkin_time, dbo.checkout_manager.checkout_time,dbo.checkout_manager.checkout_id, dbo.checkin_manager.checkin_id, dbo.Shift_Master.shift_ID, dbo.checkin_manager.Checkin_DateTime,dbo.Shift_Master.ShiftTimeFrom, dbo.Shift_Master.ShiftTimeTo, dbo.checkout_manager.username FROM dbo.LocationShiftMap INNER JOIN dbo.checkin_manager INNER JOIN dbo.checkout_manager ON dbo.checkin_manager.checkin_id = dbo.checkout_manager.checkin_id AND dbo.checkin_manager.checkin_id = dbo.checkout_manager.checkout_id INNER JOIN dbo.location ON dbo.checkin_manager.LocationID = dbo.location.Location_id AND dbo.checkout_manager.LocationID = dbo.location.Location_id ON dbo.LocationShiftMap.LocationID = dbo.location.Location_id INNER JOIN dbo.Shift_Master ON dbo.LocationShiftMap.ShiftID = dbo.Shift_Master.shift_ID"; 
            //string sql = "select Location_name,ShiftTimeFrom,ShiftTimeTo from location,LocationShiftMap,Shift_Master where location.Location_id=LocationShiftMap.LocationID and Shift_Master.shift_ID=LocationShiftMap.ShiftID";
            string sql = "SELECT Location_id, Location_name FROM location where Current_Status='Present' and Location_id=" + LocID;
            DataSet ds = GetDataTable1(sql);
            grdMain.DataSource = GetDataTable1(sql);
        }
        public DataSet GetDataTable1(string query)
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

                BindSchedule1(gpc, dr, "GetCheckedInGuardsNew", false, true, false);
                //RadGrid gv = ((RadGrid)gr.Cells[1].FindControl("grdCurrCheckOuts"));
                GridTableCell gvCell = (GridTableCell)gr["checkOutUser"];
                RadGrid gv = (RadGrid)gpCell.FindControl("grdCurrCheckOuts1");

                BindSchedule1(gv, dr, "GetCheckedOutGuardsNew", true, true, true);
                GridTableCell gpCellShift = (GridTableCell)gr["CurrentShift"];
                RadGrid gpcShift = (RadGrid)gpCellShift.FindControl("grdCurrentShift1");

                //string shiftCurrId=BindScheduleShift(gpcShift, dr, "CurrentShiftID", false, true, false);
                //BindScheduleShift1(gpcShift, dr, "CurrentShiftID", false, true, false);
                BindScheduleShift1(gpcShift, dr, "CurrentShiftTest", false, true, false);
                //BindCurrShiftData(gpcShift,shiftCurrId,"CurrShiftData",false, true, false);

                GridTableCell gvCellShift = (GridTableCell)gr["NextShift"];
                RadGrid gvShift = (RadGrid)gvCellShift.FindControl("grdNextShift1");

                //string shiftNextId=BindScheduleShift(gvShift, dr, "NextShiftID", false, true, false);
                BindScheduleShift1(gvShift, dr, "NextShift", false, true, false);
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



        private void BindSchedule1(RadGrid gv, DataRowView dr, string spname, bool IsCheckinStatusNeeded, bool IsCheckOutStatusNeeded, bool IsRemovalNeeded)
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
                    gv.DataSource = String.Empty;
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
        private void BindScheduleShift1(RadGrid gv, DataRowView dr, string spname, bool IsCheckinStatusNeeded, bool IsCheckOutStatusNeeded, bool IsRemovalNeeded)
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

                gv.DataSource = dtCurrShift;
                gv.DataBind();

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
                //gv.MasterTableView.NoRecordsTemplate = new MyNoRecordsTemplate();
                gv.DataSource = String.Empty;//Changes to Display No Record Template
                gv.DataBind();
            }
        }

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
                        i--;
                    }
                    catch (Exception ex)
                    {

                    }
                }

                foreach (DataColumn dc in dt1.Columns)
                {
                    TemplateField makeliveCol = new TemplateField();
                    //  makeliveCol.ItemTemplate = new CreateItemTemplateLinkBtn(System.Guid.NewGuid().ToString().Split('-')[System.Guid.NewGuid().ToString().Split('-').Length - 1], dc.ColumnName, "MakeLive", "return confirm('Are you sure you want to publish this version?')");

                    //  makeliveCol.ItemTemplate = new 
                    makeliveCol.HeaderStyle.ForeColor = System.Drawing.Color.White;
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
                // ==========Purpose:To show the same grid as in Login.aspx page for current assigned users=====//

                //try
                //{


                //    int grdcount = grdSchedule.Rows.Count;
                //    foreach (GridViewRow gvrSecurity in grdSchedule.Rows)
                //    {
                //        int gvrgrid = gvrSecurity.Cells.Count;
                //        foreach (TableCell tcSecurity in gvrSecurity.Cells)
                //        {


                //            LinkButton lnkUser = new LinkButton();
                //            lnkUser = ((LinkButton)tcSecurity.Controls[0]);
                //            //string xx = dt1.Rows[countTC][countGR].ToString();
                //            string xx = dt1.Rows[grdSchedule.Rows.Count - grdcount][gvrSecurity.Cells.Count - gvrgrid].ToString();
                //            gvrgrid = gvrgrid - 1;

                //            if (gvrgrid == 0) { grdcount = grdcount - 1; }

                //            if (xx != "")
                //            {
                //                string[] yy = xx.Split('|');
                //                lnkUser.Text = yy[0].ToString();
                //                lnkUser.ToolTip = yy[4].ToString();
                //                lnkUser.ForeColor = Color.Black;
                //                lnkUser.Font.Bold = true;
                //                lnkUser.Font.Underline = false;
                //                lnkUser.Click += ViewDetails;
                //                lnkUser.CommandArgument = lnkUser.ToolTip.ToString();
                //            }




                //            //=======Changes By:Sandeep Date:22/6/2012========//
                //            string StaffID = lnkUser.ToolTip.ToString();
                //            //=========================================================//

                //            // lnkUser.PostBackUrl = "~/ADMIN/ProfileUser.aspx?t1=" + StaffID.ToString();

                //        }

                //    }
                //}
                //catch(Exception ex)
                //{
                //}
                //============================End Changes==============================//

            }
        }

        protected void BindgrdSchedule()
        {
            if (Session["LCID"] != null)
            {

                SqlParameter[] para = new SqlParameter[1];
                para[0] = new SqlParameter("@LocationID", Session["LCID"].ToString());
                dt = dal.executeprocedure("usp_GetDailyScheduleLatestForDistinctGaurds", para, false);
                //==================================================================================//
                DataTable dt1 = SMSCommons.SMSCommon.ConvertRowsToColumns(dt, "Shift", "StaffName");
                grdSchedule.DataSource = dt1;
                grdSchedule.DataBind();


            }
        }

        protected void OnRowDataBoundgrdSchedule(object sender, GridViewRowEventArgs e)
        {

            if (Session["LCID"] != null)
            {

                SqlParameter[] para = new SqlParameter[1];
                para[0] = new SqlParameter("@LocationID", Session["LCID"].ToString());



                //=========================Changes By:Sandeep Date:16/6/2012========================//
                dt = dal.executeprocedure("usp_GetDailyScheduleLatestForDistinctGaurds", para, false);
                //==================================================================================//
                DataTable dt1 = SMSCommons.SMSCommon.ConvertRowsToColumns(dt, "Shift", "StaffName");




                try
                {


                    //int grdcount = grdSchedule.Rows.Count;
                    //foreach (GridViewRow gvrSecurity in grdSchedule.Rows)
                    //{
                    //    int gvrgrid = gvrSecurity.Cells.Count;
                    //    foreach (TableCell tcSecurity in gvrSecurity.Cells)
                    //    {


                    //        LinkButton lnkUser = new LinkButton();
                    //        lnkUser = ((LinkButton)tcSecurity.Controls[0]);
                    //        //string xx = dt1.Rows[countTC][countGR].ToString();
                    //        string xx = dt1.Rows[grdSchedule.Rows.Count - grdcount][gvrSecurity.Cells.Count - gvrgrid].ToString();
                    //        gvrgrid = gvrgrid - 1;

                    //        if (gvrgrid == 0) { grdcount = grdcount - 1; }

                    //        if (xx != "")
                    //        {
                    //            string[] yy = xx.Split('|');
                    //            lnkUser.Text = yy[0].ToString();
                    //            lnkUser.ToolTip = yy[4].ToString();
                    //            lnkUser.ForeColor = Color.Black;
                    //            lnkUser.Font.Bold = true;
                    //            lnkUser.Font.Underline = false;
                    //            lnkUser.Click += ViewDetails;
                    //            lnkUser.CommandArgument = lnkUser.ToolTip.ToString();
                    //        }




                    //        //=======Changes By:Sandeep Date:22/6/2012========//
                    //        string StaffID = lnkUser.ToolTip.ToString();
                    //        //=========================================================//

                    //        // lnkUser.PostBackUrl = "~/ADMIN/ProfileUser.aspx?t1=" + StaffID.ToString();

                    //    }

                    //}
                }
                catch (Exception ex)
                {
                }
                //============================End Changes==============================//










                int g = e.Row.Cells.Count;


                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    for (int i = 0; i < dt1.Columns.Count; i++)
                    {
                        LinkButton lnkView = new LinkButton();
                        lnkView.ID = "lnkView" + i;
                        //lnkView.Text = e.Row.Cells[i].ToString(); ;
                        lnkView.Click += ViewDetails;
                        // lnkView.CommandArgument = (e.Row.DataItem as DataRowView).Row..ToString();



                        string xx = dt1.Rows[e.Row.RowIndex][i].ToString();




                        if (xx != "")
                        {
                            string[] yy = xx.Split('|');
                            lnkView.Text = yy[0].ToString();
                            lnkView.ToolTip = yy[4].ToString();
                            lnkView.ForeColor = Color.Black;
                            lnkView.Font.Bold = true;
                            lnkView.Font.Underline = false;

                            lnkView.CommandArgument = lnkView.ToolTip.ToString();
                        }

                        e.Row.Cells[i].Controls.Add(lnkView);




                    }
                }
            }
        }

        protected void ViewDetails(object sender, EventArgs e)
        {
            LinkButton lnkView = (sender as LinkButton);
            GridViewRow row = (lnkView.NamingContainer as GridViewRow);
            string id = lnkView.CommandArgument;
            ModalPopupAdd.Show();
            PopulatePageCntrls(id);

        }

        private void PopulatePageCntrls(String argsBGID)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Session["ctrl"] = printview;
                string fullname = string.Empty;
                SqlParameter[] para = new SqlParameter[1];
                para[0] = new SqlParameter("@StaffID", argsBGID);
                DataTable dsStaff = dal.executeprocedure("usp_GetEnrollStaff", para, true);
                if (dsStaff.Rows.Count > 0)
                {

                    fullname = dsStaff.Rows[0]["Staff_PreName"].ToString().Trim();
                    fullname += " ";
                    fullname += dsStaff.Rows[0]["FirstName"].ToString().Trim();
                    fullname += " ";
                    fullname += dsStaff.Rows[0]["MiddleName"].ToString().Trim();
                    fullname += " ";
                    fullname += dsStaff.Rows[0]["LastName"].ToString().Trim();
                    txtfullname.Text = fullname;

                    txtNRIC.Text = dsStaff.Rows[0]["NRICno"].ToString().Trim();
                    txtDOB.Text = dsStaff.Rows[0]["Staff_DOB"].ToString().Trim();
                    txtSex.Text = dsStaff.Rows[0]["Staff_Sex"].ToString().Trim();
                    txtReligion.Text = dsStaff.Rows[0]["Staff_Religion"].ToString().Trim();
                    txtRace.Text = dsStaff.Rows[0]["Staff_Race"].ToString().Trim();
                    txtAge.Text = dsStaff.Rows[0]["Staff_Age"].ToString().Trim();

                    txtMaritalStatus.Text = dsStaff.Rows[0]["Staff_MaritalStatus"].ToString().Trim();
                    txtRole.Text = dsStaff.Rows[0]["Role"].ToString().Trim();
                    ImgageStaff.ImageUrl = dsStaff.Rows[0]["ImagePathName"].ToString().Trim();
                    //ImgageStaff.ImageUrl = "~/admin/Images/f45d6f3d4f32.jpg";
                    txtContNo.Text = dsStaff.Rows[0]["Staff_Telphone"].ToString().Trim();

                    HypNRICWorkPermit.ToolTip = dsStaff.Rows[0]["Staff_NRICWorkPermitCertificate"].ToString().Trim();
                    NSRSWSQModules.ToolTip = dsStaff.Rows[0]["Staff_NSRSWSQModulesCertificate"].ToString().Trim();
                    OtherRecognisedCertificate.ToolTip = dsStaff.Rows[0]["Staff_OtherRecognisedCertificate"].ToString().Trim();
                    ExemptionCertificate.ToolTip = dsStaff.Rows[0]["Staff_ExemptionCertificate"].ToString().Trim();
                    SecurityOfficerLicense.ToolTip = dsStaff.Rows[0]["Staff_SecurityOfficerLicenseCertificate"].ToString().Trim();
                    SIRDScreen.ToolTip = dsStaff.Rows[0]["Staff_SIRDScreenCertificate"].ToString().Trim();
                }

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnprint_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Session["ctrl"] = printview;
                ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('PrintViewPage.aspx','PrintMe','height=700px,width=800px,scrollbars=1');</script>");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnCancelPop_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                ModalPopupAdd.Hide();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }




        #endregion popup

        # region Google viewer
        protected void ButtonCancelViewer_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                ModalPopupViewer.Hide();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void Nricworkpermit_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                var domainname = Request.ServerVariables["HTTP_HOST"];



                if (HypNRICWorkPermit.ToolTip != "")
                {
                    string[] name = HypNRICWorkPermit.ToolTip.Split('/');

                    string s = " https://docs.google.com/viewer?url=http://" + domainname + "/FileUpload/" + name[2] + "&embedded=true";
                    ViewerDoc.Attributes.Add("src", s);
                    ModalPopupViewer.Show();
                }
                else
                {

                    SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                    MyMasterPage.ShowErrorMessage("No Document Attached..!");
                }


            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        protected void NSRSWSQModules_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                var domainname = Request.ServerVariables["HTTP_HOST"];
                if (NSRSWSQModules.ToolTip != "")
                {

                    string[] name = NSRSWSQModules.ToolTip.Split('/');

                    string s = " https://docs.google.com/viewer?url=http://" + domainname + "/FileUpload/" + name[2] + "&embedded=true";
                    ViewerDoc.Attributes.Add("src", s);
                    ModalPopupViewer.Show();


                    ModalPopupViewer.Show();
                }
                else
                {

                    SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                    MyMasterPage.ShowErrorMessage("No Document Attached..!");
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        protected void OtherRecognisedCertificate_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                var domainname = Request.ServerVariables["HTTP_HOST"];
                if (OtherRecognisedCertificate.ToolTip != "")
                {
                    string[] name = OtherRecognisedCertificate.ToolTip.Split('/');

                    string s = " https://docs.google.com/viewer?url=http://" + domainname + "/FileUpload/" + name[2] + "&embedded=true";
                    ViewerDoc.Attributes.Add("src", s);
                    ModalPopupViewer.Show();
                    ModalPopupViewer.Show();
                }
                else
                {

                    SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                    MyMasterPage.ShowErrorMessage("No Document Attached..!");
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void ExemptionCertificate_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                var domainname = Request.ServerVariables["HTTP_HOST"];
                if (ExemptionCertificate.ToolTip != "")
                {
                    string[] name = ExemptionCertificate.ToolTip.Split('/');

                    string s = " https://docs.google.com/viewer?url=http://" + domainname + "/FileUpload/" + name[2] + "&embedded=true";
                    ViewerDoc.Attributes.Add("src", s);
                    ModalPopupViewer.Show();
                    ModalPopupViewer.Show();
                }
                else
                {

                    SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                    MyMasterPage.ShowErrorMessage("No Document Attached..!");
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        protected void SecurityOfficerLicense_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                var domainname = Request.ServerVariables["HTTP_HOST"];
                if (SecurityOfficerLicense.ToolTip != "")
                {
                    string[] name = SecurityOfficerLicense.ToolTip.Split('/');

                    string s = " https://docs.google.com/viewer?url=http://" + domainname + "/FileUpload/" + name[2] + "&embedded=true";
                    ViewerDoc.Attributes.Add("src", s);
                    ModalPopupViewer.Show();
                    ModalPopupViewer.Show();
                }
                else
                {

                    SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                    MyMasterPage.ShowErrorMessage("No Document Attached..!");
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        protected void SIRDScreen_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                var domainname = Request.ServerVariables["HTTP_HOST"];
                if (SIRDScreen.ToolTip != "")
                {
                    string[] name = SIRDScreen.ToolTip.Split('/');

                    string s = " https://docs.google.com/viewer?url=http://" + domainname + "/FileUpload/" + name[2] + "&embedded=true";
                    ViewerDoc.Attributes.Add("src", s);
                    ModalPopupViewer.Show();
                    ModalPopupViewer.Show();
                }
                else
                {

                    SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                    MyMasterPage.ShowErrorMessage("No Document Attached..!");
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }


        #endregion

    }

    public class MyNoRecordsTemplate : ITemplate
    {
        Label NoRecordsLabel;
        void System.Web.UI.ITemplate.InstantiateIn(System.Web.UI.Control container)
        {
            NoRecordsLabel = new Label();
            NoRecordsLabel.ID = "NoRecordsLabel";
            NoRecordsLabel.BackColor = System.Drawing.Color.Orange;
            NoRecordsLabel.BorderWidth = Unit.Pixel(1);
            NoRecordsLabel.BorderColor = System.Drawing.Color.Brown;
            NoRecordsLabel.Text = "No data to display";
            container.Controls.Add(NoRecordsLabel);
        }
    }

}
