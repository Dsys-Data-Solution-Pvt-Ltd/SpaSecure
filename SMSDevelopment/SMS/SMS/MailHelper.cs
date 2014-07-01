using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;

namespace SMS.Web
{
    public class MailHelper
    {
        public static bool SendEmail(string toEmail, string fromEmail, string bcc, string subject, string body, bool isHtml)
        {
            bool emailResult = false;
            MailMessage message = new MailMessage();
          
            message.From = new MailAddress(fromEmail);
            if (toEmail != "" && toEmail != null)
                message.To.Add(new MailAddress(toEmail));
            if (bcc != "" && bcc != null)
                message.Bcc.Add(new MailAddress(bcc));
          
            string fullBody = "";
            string startBody = "";
            startBody += " <style type='text/css'>#wrapper{background: none repeat scroll 0 0 #1A4B7A;border: 0 solid silver;font-size: 1.4em;margin: 10px auto;text-align: left;width: 65em;}";
            startBody += "div.container{background-color: #133E67;}#LogoHeader{background: url('http://tspsecure.com/Images/head_bg.gif') repeat-x scroll 0 0 transparent;height: 107px;width: 65em;}";
            startBody += "#content-wrapper{background: scroll left center #FFFFFF;float: right;height: auto;width: 65em;}#content-inner{padding: 5px 15px 0;}.divContainer{background-color: #EAF6FB;border: 1px solid #D0E2F0;height: auto;margin-top: 2em;width: 62.6em;}";
            startBody += ".pageTitle{color: #1F5588;font-family: Verdana;font-size: 12px;font-weight: bold;letter-spacing: 1.5px;}.divHeader{background-color: #D0E2F0;border: 0 solid #4596DD;height: 1.5em;vertical-align: top;width: 62.6em;}";
            startBody += "b.r1{margin: 0 5px;}b.r2{margin: 0 3px;}b.r3{margin: 0 2px;}b.rtop b.r4, b.rbottom b.r4{height: 2px;margin: 0 1px;}b.rtop, b.rbottom{background: none repeat scroll 0 0 #FFFFFF;display: block;}</style>";
            startBody += "<table width='600px'><tr><td><div id='wrapper'><div class='container'><b class='rtop'><b class='r1'></b><b class='r2'></b><b class='r3'></b><b class='r4'></b></b></div>";
            startBody += "<div class='seprator1'></div><div id='content-wrapper'><div id='content-inner'>";
            startBody += "<div class='divContainer'><div class='divHeader'><span class='pageTitle'>"+subject+"</span></div><table width='100%' border='0'><tbody><tr valign='top' align='left'><td>";

            string startEnd = "";
            startEnd += "</td></tr></tbody></table></div><br /></div></div><div class='container'><span class='footertext'>Copyright &copy; 2009-2010 SPA Solutions. All rights reserved.</span></div><b class='rbottom'><b class='r4'></b><b class='r3'></b><b class='r2'></b><b class='r1'></b></b></div></td></tr></table>";
            
            fullBody = startBody + body + startEnd;

            message.Subject = "SpaSecure - " + subject;
            message.Body = fullBody + "\r\n";
            message.IsBodyHtml = isHtml;

            try
            {
                emailResult = true;
                
                SmtpClient client = new SmtpClient();
                client.Send(message);
            }
            catch (Exception ex)
            {
                emailResult = false;
            }
            return emailResult;
        }
        public static bool SendEmail(List<string> tomails,  string fromEmail, string bcc, string subject, string body, bool isHtml)
        {
            bool emailResult = false;
            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromEmail);
            foreach (string to in tomails)
            {
                message.To.Add(new MailAddress(to));
            }
            if (bcc != "" && bcc != null)
                message.Bcc.Add(new MailAddress(bcc));

            string fullBody = "";
            string startBody = "";
            startBody += " <style type='text/css'>#wrapper{background: none repeat scroll 0 0 #1A4B7A;border: 0 solid silver;font-size: 1.4em;margin: 10px auto;text-align: left;width: 65em;}";
            startBody += "div.container{background-color: #133E67;}#LogoHeader{background: url('http://tspsecure.com/Images/head_bg.gif') repeat-x scroll 0 0 transparent;height: 107px;width: 65em;}";
            startBody += "#content-wrapper{background: scroll left center #FFFFFF;float: right;height: auto;width: 65em;}#content-inner{padding: 5px 15px 0;}.divContainer{background-color: #EAF6FB;border: 1px solid #D0E2F0;height: auto;margin-top: 2em;width: 62.6em;}";
            startBody += ".pageTitle{color: #1F5588;font-family: Verdana;font-size: 12px;font-weight: bold;letter-spacing: 1.5px;}.divHeader{background-color: #D0E2F0;border: 0 solid #4596DD;height: 1.5em;vertical-align: top;width: 62.6em;}";
            startBody += "b.r1{margin: 0 5px;}b.r2{margin: 0 3px;}b.r3{margin: 0 2px;}b.rtop b.r4, b.rbottom b.r4{height: 2px;margin: 0 1px;}b.rtop, b.rbottom{background: none repeat scroll 0 0 #FFFFFF;display: block;}</style>";
            startBody += "<div id='wrapper'><div class='container'><b class='rtop'><b class='r1'></b><b class='r2'></b><b class='r3'></b><b class='r4'></b></b></div><div id='LogoHeader'>";
            startBody += "<div class='seprator'></div><div class='seprator1'></div><div id='content-wrapper'><div id='content-inner'>";
            startBody += "<div class='divContainer'><div class='divHeader'><span class='pageTitle'>" + subject + "</span></div><table width='100%' border='0'><tbody><tr valign='top' align='left'><td>";

            string startEnd = "";
            startEnd += "</td></tr></tbody></table></div><br /></div></div><div class='container'><span class='footertext'>Copyright &copy; 2009-2010 SPA Solutions. All rights reserved.</span></div><b class='rbottom'><b class='r4'></b><b class='r3'></b><b class='r2'></b><b class='r1'></b></b></div>";

            fullBody = startBody + body + startEnd;

            message.Subject = "tspSecure.com - " + subject;
            message.Body = fullBody + "\r\n";
            message.IsBodyHtml = isHtml;

            try
            {
                emailResult = true;
                SmtpClient client = new SmtpClient();
                client.Send(message);
            }
            catch(Exception ex)
            {
                emailResult = false;
            }
            return emailResult;
        }
    }
}
