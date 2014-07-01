using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Timers;
using System.Configuration;
using iTextSharp.text.pdf;
using System.Web;
using System.Web.Services;
//using System.Drawing;
using System.Net;
using System.Net.Mail;
using iTextSharp.text;
using System.Diagnostics;
using exWindowMailService.DAL;
using exWindowMailService.BE;
using System.Linq;
using System.ServiceProcess;
using System.IO;
using System.Text;
using iTextSharp.text.html.simpleparser;
using System.Windows.Forms.DataVisualization.Charting;
using VehicleTrackingSystem.VTS;
namespace exWindowMailService
{
    public partial class MailService : ServiceBase
    {
        DAL_ManageVehicle dal = new DAL_ManageVehicle();
        BE_ManageVehicle BeObj = new BE_ManageVehicle();
        BE_ManageBranch MBObj = new BE_ManageBranch();
        DAL_ManageBranch dalObj = new DAL_ManageBranch();
        DAL_Shedular DSObj = new DAL_Shedular();
        BE_Shedular BSObj = new BE_Shedular();
        DataAccessLayer dAccess = new DataAccessLayer();
      
        #region Variables Declaration For Schedular
        public int ZID = 0;
        public int VID = 0;
        public int IGI = 0;
        public int StopMoreThan = 0;
        public DateTime startDate,endDate;
        public string Frequency, MailToAddress, ReportFormat, Subject, msgBody;
        #endregion
        #region Declaration of Web Service
        SchedularService.IntegratedService serviceRef = new SchedularService.IntegratedService();
        #endregion

        //Initialize the DateTime Object
        DateTime todaysDate = DateTime.Now;

        string ReportDate=String.Empty,reportTime = String.Empty;

        double diff = 0;
        int intDiff = 0;

        private string igValue = String.Empty;
        public int result = 0;

        //Initialize the timer
        Timer timer = new Timer();
        System.Threading.Timer nTimer;
        public static System.Timers.Timer aTimer;

        Double _timeinterval = 300 * 1000;

        public MailService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            #region Earlier Code
            //add this line to text file during start of service
            TraceService("start service");
            
            //handle Elapsed event
            timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);

            //This statement is used to set interval to 1 minute (= 60,000 milliseconds)

            timer.Interval = 60000;

            //enabling the timer
            timer.Enabled = true;
            #endregion
            #region Second Method
            //aTimer = new System.Timers.Timer();
            //string starttime = "09:56";
            ////start time is 01.25 means 01:15 AM

            //double mins = Convert.ToDouble(starttime);
            //DateTime t = DateTime.Now.Date.AddHours(mins);
            //TimeSpan ts = new TimeSpan();
            //// ts = t - System.DateTime.Now;
            //ts = t.AddDays(1) - System.DateTime.Now;
            //if (ts.TotalMilliseconds < 0)
            //{
            //    ts = t.AddDays(1) - System.DateTime.Now;
            //    // ts = t - System.DateTime.Now;
            //}
            //_timeinterval = ts.TotalMilliseconds;
            //// _timeinterval now set to 1:15 am (time from now to 1:15AM)
            //aTimer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            //aTimer.Interval = _timeinterval;
            //aTimer.Enabled = true;
            #endregion
            #region Third Method
            //string startTimeString = "09:20";

            //DateTime startTime;
            //int millisecondsToStart = 0;

            //if (DateTime.TryParseExact(startTimeString, "HHmm", CultureInfo.InvariantCulture, DateTimeStyles.None, out startTime))
            //{
            //    if (DateTime.Now > startTime)
            //        startTime = startTime.AddDays(1);
            //    millisecondsToStart = (int)startTime.Subtract(DateTime.Now).TotalMilliseconds;

            //}

            //nTimer = new System.Threading.Timer(OnTimedEvent, null, millisecondsToStart, Convert.ToInt32(86400000));  
            //////System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite); 
            #endregion
            
        }
        protected override void OnStop()
        {
            timer.Enabled = false;
            TraceService("stopping service");
        }
        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            TraceService("Another entry at:" + DateTime.Now);
            // operation to perform
            try
            {
            DataTable dtresult = FetchFromShedular();

            for (int i = 0; i < dtresult.Rows.Count; i++)
            {
                int count = dtresult.Rows.Count;
                reportTime = dtresult.Rows[i]["ReportTime"].ToString();
                int RID = Convert.ToInt32(dtresult.Rows[i]["RID"].ToString());
                if (RID == 2)
                    ZID = Convert.ToInt32(dtresult.Rows[i]["zoneID"].ToString());
                else
                    ZID = 0;
                if ((RID == 2) || (RID == 3) || (RID == 4) || (RID == 5))
                {
                    startDate = Convert.ToDateTime(dtresult.Rows[i]["StartDateFrom"].ToString());
                    endDate = Convert.ToDateTime(dtresult.Rows[i]["StartDateTo"].ToString());
                    if (RID != 2)
                        VID = Convert.ToInt32(dtresult.Rows[i]["VID"].ToString());
                }
                else
                {
                    //startDate = Convert.ToDateTime(SqlDateTime.Null);
                    //endDate = Convert.ToDateTime(SqlDateTime.Null);
                }
                if (RID == 4)
                {
                    StopMoreThan = Convert.ToInt32(dtresult.Rows[i]["StopMoreThan"].ToString());
                    IGI = Convert.ToInt32(dtresult.Rows[i]["Iginition"].ToString());
                }

                Frequency = dtresult.Rows[i]["Frequency"].ToString();
                ReportDate = dtresult.Rows[i]["ReportDate"].ToString();
                MailToAddress = dtresult.Rows[i]["Email"].ToString();
                ReportFormat = dtresult.Rows[i]["ExportFormat"].ToString();
                Subject = dtresult.Rows[i]["Subject"].ToString();
                msgBody = dtresult.Rows[i]["Message"].ToString();

                if (RID != 0)
                {
                    FindMethodsForReports(RID, ReportFormat, MailToAddress, Subject, msgBody, VID, ZID, IGI, StopMoreThan, startDate, endDate,Frequency,reportTime,ReportDate);
                    //UpdateSchedular(Frequency, reportTime, RID);
                }
                else { TraceService("OnElapsedTime RID not Found:" + DateTime.Now); }
                
               
            }
            //aTimer.Interval = 86400000; // now interval sets to 24 hrs
            }
            catch (Exception ex)
            {
                TraceService("Process " + ex.Message);
            }
        }
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            // operation to perform
            CreateReport();
            //DownloadPDFFormat();
            aTimer.Interval = 86400000; // now interval sets to 24 hrs

        }
        private void TraceService(string content)
        {
            //set up a filestream
            FileStream fs = new FileStream(@"C:\Logs\ScheduledWindowService.txt", FileMode.OpenOrCreate, FileAccess.Write);

            //set up a streamwriter for adding text
            StreamWriter sw = new StreamWriter(fs);

            //find the end of the underlying filestream
            sw.BaseStream.Seek(0, SeekOrigin.End);

            //add the text
            sw.WriteLine(content);
            //add the text to the underlying filestream

            sw.Flush();
            //close the writer
            sw.Close();
        }

        
        #region Reports For Work
        private void CreateReport()
        {
            //log4net.ILog logger = log4net.LogManager.GetLogger("File");
            TraceService("CreateReport " + DateTime.Now);
            try
            {
                BeObj.BranchID = 10;

                DataTable dt = dal.GetVehicleReportFromDateFromTo(BeObj);
                DateTime from = Convert.ToDateTime("02/08/2013").Date;
                DateTime to = Convert.ToDateTime("02/11/2013").Date;
                TimeSpan diffMy = (from - to);

                diff = diffMy.Days;

                if (diff < 0)
                {
                    diff = diff * (-1);
                    intDiff = Convert.ToInt32(diff);
                    //lblMessage.Text = String.Empty;

                    try
                    {
                        string HTML = "";
                        HTML += "<table border=2 class=manage_table width=85% style='border-width:2px;border-color:black'>";
                        HTML += "<tr><td colspan=9><center><b><h3>Trip Report</h3></b></center></td></tr>";
                        HTML += "<tr><td align=left>Branch: </td><td align=left colspan=8> Indore </td></tr>";
                        HTML += "<tr><td align=left>Vehicle: </td><td align=left colspan=8> Steve_Test_Tracker </td></tr>";
                        HTML += "<tr><td align=left>Report Date From: </td><td colspan=3 align=left>" + String.Format("{0:DD/mm/yyyy}", from) + "</td><td align=left>To: </td><td align=left colspan=4>" + String.Format("{0:DD/mm/yyyy}", to) + "</td></tr>";
                        HTML += "<tr><td><b>Time</b></td><td><b>Longitude</b></td><td><b>Latitude</b></td><td><b>Speed(km/h)</b></td><td><b>Stop Duration(min)</b></td><td><b>Ignition</b></td><td><b>Cog</b></td><td><b>Distance(meter)</b></td><td><b>Address</b></td></tr>";
                        for (int i = 0; i < intDiff; i++)
                        {

                            HTML += "<tr><td colspan=9 align=left><b>Date: </b><b>" + String.Format("{0:DD/mm/yyyy}", from.AddDays(i).ToShortDateString()) + "</b></td></tr>";
                            BeObj.vehicleID = Convert.ToInt32(6520);
                            BeObj.DateFrom = Convert.ToDateTime(from.AddDays(i));
                            DataTable dtNew = dal.GetVehicleReportFromDateFromTo(BeObj);

                            for (int j = 0; j < dtNew.Rows.Count; j++)
                            {
                                //string LogDateTime = dtNew.Rows[j]["LOG_DATETIME"].ToString();
                                //string[] LogTime = LogDateTime.Split(' ');
                                //string time = LogTime[1].ToString().Substring(0, 4);
                                string time = Convert.ToDateTime(dtNew.Rows[j]["LOG_DATETIME"].ToString()).ToString("hh:mm");

                                if (Convert.ToInt32(dtNew.Rows[j]["IGNITION"].ToString()) == 1)
                                    igValue = "on";
                                else
                                    igValue = "off";

                                HTML += "<tr>";
                                HTML += "<td>" + time + "</td><td>" + dtNew.Rows[j]["LONGITUDE"].ToString() + "</td><td>" + dtNew.Rows[j]["LATITUDE"].ToString() + "</td><td>" + dtNew.Rows[j]["SPEED"].ToString() + "</td><td>" + dtNew.Rows[j]["StopDuration"].ToString() + "</td><td>" + igValue + "</td><td>" + dtNew.Rows[j]["COG"].ToString() + "</td><td>" + dtNew.Rows[j]["DISTANCE"].ToString() + "</td><td></td>";
                                HTML += "</tr>";
                            }

                        }
                        HTML += "</table>";
                        //divReport.InnerHtml = HTML;
                    }
                    catch (Exception ex)
                    {
                        //logger.Info(ex.Message);
                        TraceService("CreateReport " + ex.Message);
                        Console.WriteLine(ex.Message);
                    }
                }


            }
            catch (Exception ex)
            {
                //logger.Info(ex.Message);
                TraceService("CreateReport " + ex.Message);
                Console.WriteLine(ex.Message);
            }

        }
        public void DownloadPDFFormat(string x,string y,string z)
        {
            //log4net.ILog logger = log4net.LogManager.GetLogger("File");
            TraceService("DownloadPDFFormat " + DateTime.Now);
            try
            {
                Document pdfReport = new Document(PageSize.A4, 100, 91, 100, 93);
                System.IO.MemoryStream msReport = new System.IO.MemoryStream();
                PdfWriter writer = PdfWriter.GetInstance(pdfReport, msReport);
                pdfReport.Open();
                SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["VehicleTracking"].ConnectionString);
                cn.Open();

                string datetime = string.Empty;
                datetime = Convert.ToString(System.DateTime.Now);

                //Create Heading
                Phrase headerPhrase = new Phrase("                                     Trip Detail Report                                                       ", FontFactory.GetFont("Garamond", 14));

                #region Drawing Horizontal Line
                PdfContentByte cb = writer.DirectContent;
                cb.SetLineWidth(1.0f);   // Make a bit thicker than 1.0 default
                cb.SetGrayStroke(0.25f); // 1 = black, 0 = white
                cb.MoveTo(100, pdfReport.Top - 5f);
                cb.LineTo(500, pdfReport.Top - 5f);
                cb.Stroke();
                #endregion

                headerPhrase.Add("      Generated On : ");
                headerPhrase.Add(datetime);
                headerPhrase.Add("\n");
                headerPhrase.Add("            Branch:  Indore ");
                headerPhrase.Add("\n");
                headerPhrase.Add("            Vehicle: Steve_Test_Tracker");
                headerPhrase.Add("\n");
                headerPhrase.Add("            Report Date From: " + String.Format("{0:DD/mm/yyyy}", "02/08/2013") + " To: " + String.Format("{0:DD/mm/yyyy}", "02/11/2013") + "");

                //headerPhrase.Add(str);

                //Create Heading
                // Phrase headerPhrase = new Phrase("Contractor Report", FontFactory.GetFont("TIMES_ROMAN", 16));
                HeaderFooter header = new HeaderFooter(headerPhrase, false);
                header.Border =    iTextSharp.text.Rectangle.NO_BORDER;
                header.Alignment = Element.ALIGN_CENTER;
                header.Alignment = Element.ALIGN_BOTTOM;
                pdfReport.Header = header;
                pdfReport.Add(headerPhrase);



                // Creates the Table
                PdfPTable ptData = new PdfPTable(9);
                ptData.SpacingBefore = 8;
                ptData.DefaultCell.Padding = 1;

                float[] headerwidths = new float[9]; // percentage


                headerwidths[0] = 4.2F;
                headerwidths[1] = 4.2F;
                headerwidths[2] = 4.2F;
                headerwidths[3] = 5.2F;
                headerwidths[4] = 5.2F;
                headerwidths[5] = 4.2F;
                headerwidths[6] = 4.2F;
                headerwidths[7] = 5.5F;
                headerwidths[8] = 4.2F;


                ptData.SetWidths(headerwidths);
                ptData.WidthPercentage = 100;
                ptData.DefaultCell.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                ptData.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;

                //Insert the Table Headers
                for (int i = 0; i < 1; i++)
                {
                    PdfPCell cell = new PdfPCell();
                    cell.BorderWidth = 0.001f;
                    cell.BackgroundColor = new Color(200, 200, 200);
                    cell.BorderColor = new Color(100, 100, 100);
                    cell.Phrase = new Phrase("Time", FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 7, Font.BOLD));
                    ptData.AddCell(cell);

                    cell.BorderWidth = 0.001f;
                    cell.BackgroundColor = new Color(200, 200, 200);
                    cell.BorderColor = new Color(100, 100, 100);
                    cell.Phrase = new Phrase("Longitude", FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 7, Font.BOLD));
                    ptData.AddCell(cell);

                    cell.BorderWidth = 0.001f;
                    cell.BackgroundColor = new Color(200, 200, 200);
                    cell.BorderColor = new Color(100, 100, 100);
                    cell.Phrase = new Phrase("Latitude", FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 7, Font.BOLD));
                    ptData.AddCell(cell);

                    cell.BorderWidth = 0.001f;
                    cell.BackgroundColor = new Color(200, 200, 200);
                    cell.BorderColor = new Color(100, 100, 100);
                    cell.Phrase = new Phrase("Speed(KM/H)", FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 7, Font.BOLD));
                    ptData.AddCell(cell);

                    cell.BorderWidth = 0.001f;
                    cell.BackgroundColor = new Color(200, 200, 200);
                    cell.BorderColor = new Color(100, 100, 100);
                    cell.Phrase = new Phrase("Stop Duration(Min)", FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 7, Font.BOLD));
                    ptData.AddCell(cell);

                    cell.BorderWidth = 0.001f;
                    cell.BackgroundColor = new Color(200, 200, 200);
                    cell.BorderColor = new Color(100, 100, 100);
                    cell.Phrase = new Phrase("Iginition", FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 7, Font.BOLD));
                    ptData.AddCell(cell);

                    cell.BorderWidth = 0.001f;
                    cell.BackgroundColor = new Color(200, 200, 200);
                    cell.BorderColor = new Color(100, 100, 100);
                    cell.Phrase = new Phrase("COG", FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 7, Font.BOLD));
                    ptData.AddCell(cell);

                    cell.BorderWidth = 0.001f;
                    cell.BackgroundColor = new Color(200, 200, 200);
                    cell.BorderColor = new Color(100, 100, 100);
                    cell.Phrase = new Phrase("Distance(Meters)", FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 7, Font.BOLD));
                    ptData.AddCell(cell);

                    cell.BorderWidth = 0.001f;
                    cell.BackgroundColor = new Color(200, 200, 200);
                    cell.BorderColor = new Color(100, 100, 100);
                    cell.Phrase = new Phrase("Address", FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 7, Font.BOLD));
                    ptData.AddCell(cell);
                }
                ptData.HeaderRows = 1;  // this is the end of the table header

                //Insert the Table Data
                #region For Calculating Dynamic table Colunms
                BeObj.BranchID = Convert.ToInt32(10);

                DataTable dt = dal.GetVehicleReportFromDateFromTo(BeObj);
                DateTime from = Convert.ToDateTime("02/08/2013").Date;
                DateTime to = Convert.ToDateTime("02/11/2013").Date;
                TimeSpan diffMy = (from - to);

                diff = diffMy.Days;

                if (diff < 0)
                {
                    diff = diff * (-1);
                    intDiff = Convert.ToInt32(diff);
                    //lblMessage.Text = String.Empty;

                    try
                    {
                        for (int i = 0; i < intDiff; i++)
                        {
                            PdfPCell cell = new PdfPCell();
                            cell.BorderWidth = 0.001f;
                            cell.BackgroundColor = new Color(200, 200, 200);
                            cell.Colspan = 9;
                            cell.BorderColor = new Color(100, 100, 100);
                            cell.Phrase = new Phrase("Date : " + String.Format("{0:DD/mm/yyyy}", from.AddDays(i).ToShortDateString()), FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 7, Font.BOLD));
                            ptData.AddCell(cell);
                            ptData.HeaderRows = 1;// this is the end of the table header

                            BeObj.vehicleID = Convert.ToInt32(6520);
                            BeObj.DateFrom = Convert.ToDateTime(from.AddDays(i));
                            DataTable dtNew = dal.GetVehicleReportFromDateFromTo(BeObj);

                            for (int intJ = 0; intJ < dtNew.Rows.Count; intJ++)
                            {
                                for (int intK = 0; intK < 9; intK++)
                                {
                                    string time = Convert.ToDateTime(dtNew.Rows[intJ]["LOG_DATETIME"].ToString()).ToString("hh:mm");

                                    if (Convert.ToInt32(dtNew.Rows[intJ]["IGNITION"].ToString()) == 1)
                                        igValue = "on";
                                    else
                                        igValue = "off";

                                    ptData.HeaderRows = 0;
                                    PdfPCell cellNew = new PdfPCell();
                                    cellNew.BorderWidth = 0.001f;
                                    cellNew.BorderColor = new Color(100, 100, 100);
                                    cellNew.BackgroundColor = new Color(250, 250, 250);


                                    if (dtNew.Rows[intJ][intK].ToString() != "&nbsp;")
                                    {
                                        if (intK == 0)
                                            cellNew.Phrase = new Phrase(time, FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 6));
                                        else if (intK == 1)
                                            cellNew.Phrase = new Phrase(dtNew.Rows[intJ]["LONGITUDE"].ToString(), FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 6));
                                        else if (intK == 2)
                                            cellNew.Phrase = new Phrase(dtNew.Rows[intJ]["LATITUDE"].ToString(), FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 6));
                                        else if (intK == 3)
                                            cellNew.Phrase = new Phrase(dtNew.Rows[intJ]["SPEED"].ToString(), FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 6));
                                        else if (intK == 4)
                                            cellNew.Phrase = new Phrase(dtNew.Rows[intJ]["StopDuration"].ToString(), FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 6));
                                        else if (intK == 5)
                                            cellNew.Phrase = new Phrase(igValue, FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 6));
                                        else if (intK == 6)
                                            cellNew.Phrase = new Phrase(dtNew.Rows[intJ]["COG"].ToString(), FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 6));
                                        else if (intK == 7)
                                            cellNew.Phrase = new Phrase(dtNew.Rows[intJ]["DISTANCE"].ToString(), FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 6));
                                        else if (intK == 8)
                                            cellNew.Phrase = new Phrase("", FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 6));
                                    }
                                    else
                                    {
                                        cellNew.Phrase = new Phrase("", FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 6));
                                    }
                                    ptData.AddCell(cellNew);
                                }
                            }
                        }

                        //Insert the Table

                        pdfReport.Add(ptData);

                        //Closes the Report and writes to Memory Stream

                        pdfReport.Close();

                        //Writes the Memory Stream Data to Response Object
                        //Response.Clear();
                        //// Response.AddHeader("content-disposition", string.Format("attachment;filename=" + ConfigurationManager.AppSettings["TxnInfoPdfFile"]));
                        //Response.AddHeader("content-disposition", string.Format("attachment;filename=TripDetailReport.pdf"));
                        //Response.Charset = "";
                        //Response.ContentType = "application/pdf";
                        //Response.BinaryWrite(msReport.ToArray());
                        //Response.End();

                        MemoryStream pdfstream = new MemoryStream(msReport.ToArray());
                        ////create attachment
                        Attachment attachment = new Attachment(pdfstream, "TripDetailReport.pdf");
                        DoSomeEmailSendStuff(pdfstream,x,y,z);
                        //return attachment;
                    }
                    catch (Exception ex)
                    {
                        //logger.Info(ex.Message);
                        TraceService("DownloadPDFFormat " + ex.Message);
                        Console.WriteLine(ex.Message);
                    }
                }
                #endregion

            }
            catch (Exception ex)
            {
                //logger.Info(ex.Message);
                TraceService("DownloadPDFFormat " + ex.Message);
                Console.WriteLine(ex.Message);

            }
            //return null;
        }
        private void DoSomeEmailSendStuff(MemoryStream _ms,string toAdd,string subJect,string msgBody)
        {
            TraceService("DoSomeEmailSendStuff " + DateTime.Now);
            try
            {
                var fromAddress = new MailAddress("mail.dms.101@gmail.com", "Flether Pty. Ltd.");
                var toAddress = new MailAddress(toAdd, "Sandy Vaio");
                const string fromPassword = "dmsmailisfun";
                //const string subject = "Test Message";
                string subject = subJect;
                //const string body = "This is Server Generated Messsage";
                string body = msgBody;

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    //UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    message.Attachments.Add(new Attachment(_ms, "Report.Pdf", "application/pdf"));
                    smtp.Send(message);
                }
            }
            catch (Exception x)
            {
                Debug.WriteLine(x);
                TraceService("DoSomeEmailSendStuff " + x.Message);
            }
        }
        #endregion
        #region Method Calling
        public void Process()
        {
            TraceService("Process " + DateTime.Now);
            //VehicleDailySummaryReport vd1 = new VehicleDailySummaryReport();
            //vd1.GenerateReportHTML();xcel se related hai 

            try
            {
                DataTable dtresult = FetchFromShedular();

                for (int i = 0; i < dtresult.Rows.Count; i++)
                {
                    int count = dtresult.Rows.Count;
                    reportTime = dtresult.Rows[i]["ReportTime"].ToString();
                    int RID = Convert.ToInt32(dtresult.Rows[i]["RID"].ToString());
                    if (RID == 2)
                        ZID = Convert.ToInt32(dtresult.Rows[i]["zoneID"].ToString());
                    else
                        ZID = 0;
                    if ((RID == 2) || (RID == 3) || (RID == 4) || (RID == 5))
                    {
                        startDate = Convert.ToDateTime(dtresult.Rows[i]["StartDateFrom"].ToString());
                        endDate = Convert.ToDateTime(dtresult.Rows[i]["StartDateTo"].ToString());
                        if (RID != 2)
                            VID = Convert.ToInt32(dtresult.Rows[i]["VID"].ToString());

                    }
                    else
                    {
                        //startDate = SqlDateTime.Null;
                        //endDate = SqlDateTime.Null;
                    }
                    if (RID == 4)
                    {
                        StopMoreThan = Convert.ToInt32(dtresult.Rows[i]["StopMoreThan"].ToString());
                        IGI = Convert.ToInt32(dtresult.Rows[i]["Iginition"].ToString());
                    }

                    Frequency = dtresult.Rows[i]["Frequency"].ToString();
                    ReportDate = dtresult.Rows[i]["ReportDate"].ToString();
                    MailToAddress = dtresult.Rows[i]["Email"].ToString();
                    ReportFormat = dtresult.Rows[i]["ExportFormat"].ToString();
                    Subject = dtresult.Rows[i]["Subject"].ToString();
                    msgBody = dtresult.Rows[i]["Message"].ToString();

                    if (RID != 0)
                    {
                        FindMethodsForReports(RID, ReportFormat, MailToAddress, Subject, msgBody, VID, ZID, IGI, StopMoreThan, startDate, endDate, Frequency, reportTime, ReportDate);
                        //UpdateSchedular(Frequency, reportTime, RID);
                    }
                    else { TraceService("OnElapsedTime RID not Found:" + DateTime.Now); }


                }
            }
            catch (Exception ex)
            {
                TraceService("Process " + ex.Message);
            }
        }
        #endregion
        #region FetchShedular
        private DataTable FetchFromShedular()
        {
            TraceService("FetchForShedular " + DateTime.Now);
            DataTable dtResult = null;
            try
            {
                BSObj.ReportDate = DateTime.Now.ToShortDateString();
                dtResult = DSObj.FetchSchedularData(BSObj);
            }
            catch (Exception ex)
            {
                TraceService("FetchForShedular " + ex.Message);
            }
            return dtResult;
        }
        #endregion
        #region Method of Daily Operation Report
       
        #endregion
    }
}
