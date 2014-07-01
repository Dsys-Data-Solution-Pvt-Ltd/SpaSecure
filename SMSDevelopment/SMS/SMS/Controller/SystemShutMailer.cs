using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using SMS.Services.DataService;
using System.Data;

namespace SMS.Controller
{
    public class SystemShutMailer
    {
        DataAccessLayer dal = new DataAccessLayer();
        public string SendAutoShutEmail(DataTable dt, string ShiftName,string LocationID)
        {
            string MailContent = "<td>";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                MailContent += dt.Rows[i][0].ToString().Split(new String[] { "||" }, StringSplitOptions.None)[0] + "<br />";
            }
            MailContent += "</td>";
            MailContent += "<td>";
            string FromTime, ToTime = "";
            FromTime = ShiftName.Split('-')[0].Trim();
            ToTime = ShiftName.Split('-')[1].Trim();
            DateTime[] dtarr = CDashBoard.GetFromToFromColumnName(FromTime, ToTime);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                MailContent += dt.Rows[i][0].ToString().Split(new String[] { "||" }, StringSplitOptions.None)[0] + " ";
                DataTable dtr = CDashBoard.CheckUserCheckedInStatus(dt.Rows[i][0].ToString().Split(new String[] { "||" }, StringSplitOptions.None)[2], dtarr[0], dtarr[1], LocationID);
                if (dtr.Rows[0][0].ToString() == "Green")
                {
                    MailContent += "<font style='font-color:green'>On Time : </font>Checked In At " + DateTime.Parse(dtr.Rows[0][1].ToString()).ToString("MM/dd/yyyy HH:mm:ss tt");
                }
                else if (dtr.Rows[0][0].ToString() == "Orange")
                {

                    MailContent += "<font style='font-color:orange'>Late By : </font>" + decimal.Ceiling(decimal.Parse(DateTime.Parse(dtr.Rows[0][1].ToString()).Subtract(dtarr[0]).TotalMinutes.ToString())).ToString() + " minutes. Checked In At : " + DateTime.Parse(dtr.Rows[0][1].ToString()).ToString("MM/dd/yyyy HH:mm:ss tt");
                }
                else
                {
                    TimeSpan ts = DateTime.Now.Subtract(dtarr[0]);
                    if (ts.TotalMinutes > 30)
                    {
                        MailContent += "<font style='font-color:maroon'>Not Checked In Yet</font>";
                    }
                    else
                    {
                        MailContent += "<font style='font-color:black'>Expected To Come</font>";
                    }
                }
                MailContent += "<br />";
            }
            MailContent += "</td>";

            MailContent += "<td>";
            DeploymentDataContext db = new DeploymentDataContext();
            long DGAID = 0;
            DGAID += long.Parse(dt.Rows[0][0].ToString().Split(new String[] { "||" }, StringSplitOptions.None)[1]);
            string Remark = (from vw in db.vwDailyDeployments
                             join wdr in db.WeekDayRosters on vw.WDRID equals wdr.WDRID
                             where vw.DGAID == DGAID
                             select wdr.Remarks).SingleOrDefault();

            MailContent += Remark + "</td>";
            //List<string> emailids = new List<string>();
            //DataTable dte = dal.getdata("select EmailID from UserInformation where Role like '%director%' or Role like '%superuser%'");
            //foreach (DataRow dr in dte.Rows)
            //{
            //    emailids.Add(dr[0].ToString());
            //}
            //MailHelper.SendEmail(emailids, "info@tspsecure.com", "", "Shift Report for Shift " + ShiftName + " on " + LocationName, MailContent, true);

            return MailContent;
        }
    }
}
