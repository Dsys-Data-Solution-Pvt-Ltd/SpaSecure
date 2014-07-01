using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;

namespace SMS.PDFCreator
{
    
    public class ReportSender
    {
        public string smtp;
        MailMessage message;
        SmtpClient smtpclient;

        public ReportSender(string smtp)
        {
            smtpclient = new SmtpClient(smtp);
        }

        public bool SendReport(string file,string sender,string receiver,string subject)
        {
            message = new MailMessage(sender,receiver,subject,"report");
            Attachment report = new Attachment(file);
            message.Attachments.Add(report);

            smtpclient.Send(message); 
            return false;
        }
    }
}
