using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Xml.Linq;
using System.Threading;
using System.Web.Caching;
using SMS.Controller;
using SMS.Web;
using System.Data.SqlClient;
using SMS.Services.DataService;
using System.Diagnostics;
using System.Collections.Generic;

namespace SMS
{
    public class Global : System.Web.HttpApplication
    {
        DataAccessLayer dal = new DataAccessLayer();
        private const string CACHE_ENTRY_KEY = "ServiceMimicCacheEntry";
        private const string CACHE_KEY = "ServiceMimicCache";
        public Thread thrd;
        protected void Application_Start(object sender, EventArgs e)
        {
            log4net.Config.XmlConfigurator.Configure();
            Application[CACHE_KEY] = HttpContext.Current.Cache;
            //DoServiceActions();
           // RegisterCacheEntry();
        }

        private void RegisterCacheEntry()
        {
            Cache cache = (Cache)Application[CACHE_KEY];
            if (cache[CACHE_ENTRY_KEY] != null) return;
            cache.Add(CACHE_ENTRY_KEY, CACHE_ENTRY_KEY, null,
                      DateTime.MaxValue, TimeSpan.FromMinutes(15), CacheItemPriority.Normal,
                      new CacheItemRemovedCallback(CacheItemRemoved));
        }

        private void CacheItemRemoved(string key, object value, CacheItemRemovedReason reason)
        {
            SpawnServiceActions();
            RegisterCacheEntry();
        }

        private void SpawnServiceActions()
        {
            ThreadStart threadStart = new ThreadStart(DoServiceActions);
            Thread thread = new Thread(threadStart);
            thread.Start();
        }

        private void DoServiceActions()
        {
            DataAccessLayer dal = new DataAccessLayer();
            SystemShutMailer ssm = new SystemShutMailer();
            DeploymentDataContext db = new DeploymentDataContext();
            bool IsMailSendingNeeded = false;
            var locs = (from l in db.locations select new { l.Location_id, l.Location_name });
            string MailTitle = "<table border='1' style='width:100%;border-width:1px;font-family: Verdana;font-size: 12px;letter-spacing: 1.5px;'><tr><th align='left' colspan='4' scope='col'>System Generated Report After Auto Shut Time</th></tr>";
            string MailContent = "<tr><th width='20%' align='left'> Location Name </th><th width='28%' align='left'> Projected Deployment </th><th width='28%' align='left'> Actual Scenario </th><th width='24%' align='left'> Remarks </th></tr>";
            string ShftName = "";
            foreach (var loc in locs)
            {
                string shiftid = "";
                SqlParameter[] para = new SqlParameter[2];
                para[0] = new SqlParameter("@LocationID", loc.Location_id);
                para[1] = new SqlParameter("@CurrDate", DateTime.Now);
                DataTable dt = dal.executeprocedure("GetCurrentShift", para, false);
                if (dt.Rows.Count > 0)
                {
                    string Shiftname = dt.Columns[0].ColumnName;
                    ShftName = Shiftname;
                    string FromTime, ToTime = "";
                    FromTime = Shiftname.Split('-')[0].Trim();
                    ToTime = Shiftname.Split('-')[1].Trim();
                    DateTime[] dtarr = CDashBoard.GetFromToFromColumnName(FromTime, ToTime);
                    long DGAID = 0;
                    DGAID += long.Parse(dt.Rows[0][0].ToString().Split(new String[] { "||" }, StringSplitOptions.None)[1]);
                    bool IsMailSent = (from vw in db.vwDailyDeployments
                                     join wdr in db.WeekDayRosters on vw.WDRID equals wdr.WDRID
                                     where vw.DGAID == DGAID
                                     select wdr.IsMailSent.Value).SingleOrDefault();

                    if (dtarr[0].AddHours(3) < DateTime.Now && (!IsMailSent))
                    {
                        IsMailSendingNeeded = true;
                        MailContent += "<tr><td>" + loc.Location_name + "</td>";
                        MailContent += ssm.SendAutoShutEmail(dt, Shiftname,loc.Location_id.ToString());
                        MailContent += "</tr>";
                        WeekDayRoster wd = (from vw in db.vwDailyDeployments
                                           join wdr in db.WeekDayRosters on vw.WDRID equals wdr.WDRID
                                           where vw.DGAID == DGAID
                                           select wdr).SingleOrDefault();

                        wd.IsMailSent = true;
                        db.SubmitChanges();
                    }
                }
            }
            MailContent += "</table>";
            if (IsMailSendingNeeded)
            {
                //List<string> toemails = new List<string>();
                //DataTable dt = new DataTable();
                //foreach
                MailHelper.SendEmail("vinod_ryze@yahoo.com", "deepak@dsds.co.in", "", "Shift Report for Shift " + ShftName, MailTitle + MailContent, true);
            }
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            DoServiceActions();
            RegisterCacheEntry();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                //get reference to the source of the exception chain
                Exception ex = Server.GetLastError().GetBaseException();

                ////log the details of the exception and page state to the
                ////Windows 2000 Event Log
                Console.WriteLine("Test Web",
                  "MESSAGE: " + ex.Message +
                  "\nSOURCE: " + ex.Source +
                  "\nFORM: " + Request.Form.ToString() +
                  "\nQUERYSTRING: " + Request.QueryString.ToString() +
                  "\nTARGETSITE: " + ex.TargetSite +
                  "\nSTACKTRACE: " + ex.StackTrace);

                //Insert optional email notification here...
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void Session_End(object sender, EventArgs e)
        {
            if (Session["StaffID"] != null)
            {
                SqlParameter[] para1 = new SqlParameter[2];
                para1[0] = new SqlParameter("@Staff_ID", SqlDbType.VarChar);
                para1[0].Value = Session["StaffID"].ToString();
                para1[1] = new SqlParameter("@ActiveStatus", SqlDbType.VarChar);
                para1[1].Value = "0";


                dal.exeprocedure("SP_UpdateuserinformationActiveStatus", para1);
            }
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}