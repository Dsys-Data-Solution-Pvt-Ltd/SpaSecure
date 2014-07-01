using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using SMS.BusinessEntities.Main;


namespace SMS.Exporter
{
    public class PDFCreator
    {
        Document document = null;
        HeaderFooter companyHeader = null;
        Font headerfont = FontFactory.GetFont("Arial", 15, Font.BOLD);

        public PDFCreator()
        {
            Chunk headertext = new Chunk("TRIPLE 'S' PROTECTION PTE.,LTD");
            headertext.Font = headerfont;
            companyHeader = new HeaderFooter(new Phrase(headertext), false);
            companyHeader.Border = Rectangle.NO_BORDER;
            companyHeader.Alignment = HeaderFooter.ALIGN_CENTER;
        }

        public bool CreateClientVisit(string path,List<ClientVisitMinutes> lst)
        {
            try
            {
                Font textunderline = FontFactory.GetFont(FontFactory.TIMES, 12, Font.UNDERLINE);

                document = new Document();
                string filename = path + ".pdf";
                PdfWriter.GetInstance(document, new FileStream(filename, FileMode.Create));

                document.Header = companyHeader; //COMPANY HEADER
                
                HeaderFooter footer = new HeaderFooter(new Phrase("BEFORE"), new Phrase("AFTER"));
                footer.Border = Rectangle.NO_BORDER;
                document.Footer = footer;

                
                
                document.Open();

                //DOCUMENT HEADER
                Chunk documentheader = new Chunk("CLIENT VISIT MINUTES", headerfont);
                Paragraph p_header = new Paragraph(documentheader);
                p_header.Alignment = Element.ALIGN_CENTER;

                document.Add(p_header);

                //BODY OF DOCUMENT
                Paragraph body = new Paragraph();
                Table table = new Table(5);
                table.Border = Rectangle.NO_BORDER;
                table.Width = 100;
                table.Alignment = Element.ALIGN_LEFT;

                Cell assignment = new Cell("ASSIGNMENT : ");
                assignment.Border = Rectangle.NO_BORDER;
                table.AddCell(assignment);
                Cell assingment_data = new Cell(lst[0].strAssignment);
                assingment_data.Border = Rectangle.NO_BORDER;
                table.AddCell(assingment_data);
                Cell completedby = new Cell("COMPLETED BY : ");
                completedby.Border = Rectangle.NO_BORDER;
                table.AddCell(completedby);
                Cell completedby_data = new Cell(lst[0].strCompletedBy);
                completedby_data.Border = Rectangle.NO_BORDER;
                table.AddCell(completedby_data);

                Cell datemet = new Cell("DATE MET : ");
                datemet.Border = Rectangle.NO_BORDER;
                table.AddCell(datemet);
                Cell datemet_data = new Cell(lst[0].dtmDateMet.ToShortDateString());
                datemet_data.Colspan = 3;
                datemet_data.Border = Rectangle.NO_BORDER;
                table.AddCell(datemet_data);

                Cell metwith = new Cell("MET WITH : ");
                metwith.Border = Rectangle.NO_BORDER;
                table.AddCell(metwith);
                Cell metwitht_data = new Cell(lst[0].strMetWith);
                metwitht_data.Colspan = 3;
                metwitht_data.Border = Rectangle.NO_BORDER;
                table.AddCell(metwitht_data);

                
                document.Add(table);


                Phrase complaints = new Phrase("1) COMPLAINTS/ABSENTEEISM");
                document.Add(complaints);
                Paragraph complaints_data = new Paragraph(lst[0].strComplaints);
                complaints_data.SpacingBefore = 5;
                complaints_data.SpacingAfter = 5;
                document.Add(complaints_data);

                Phrase comments = new Phrase("2) POSITIVE COMMENTS");
                document.Add(comments);
                Paragraph comments_data = new Paragraph(lst[0].strPositiveComments);
                comments_data.SpacingBefore = 5;
                comments_data.SpacingAfter = 5;
                document.Add(comments_data);

                Phrase deployment = new Phrase("3) DEPLOYMENT/OTHER CHANGES");
                document.Add(deployment);
                Paragraph deployment_data = new Paragraph(lst[0].strDeployment);
                deployment_data.SpacingBefore = 5;
                deployment_data.SpacingAfter = 5;
                document.Add(deployment_data);

                Phrase events = new Phrase("5) UPCOMING EVENTS");
                document.Add(events);
                Paragraph events_data = new Paragraph(lst[0].strEvents);
                events_data.SpacingBefore = 5;
                events_data.SpacingAfter = 5;
                document.Add(events_data);

                Phrase remarks = new Phrase("5) REMARKS");
                document.Add(remarks);
                Paragraph remarks_data = new Paragraph(lst[0].strRemarks);
                remarks_data.SpacingBefore = 5;
                remarks_data.SpacingAfter = 5;
                document.Add(remarks_data);

                Table hardcopy = new Table(4);

                hardcopy.Border = Rectangle.NO_BORDER;
                hardcopy.Width = 100;
                hardcopy.Alignment = Element.ALIGN_LEFT;
                

                Cell acknowledgement = new Cell("Acknowledgement : ");
                acknowledgement.Border = Rectangle.NO_BORDER;
                hardcopy.AddCell(acknowledgement);
                Cell acknowledgement_line = new Cell(new Chunk("                           ",textunderline));
                acknowledgement_line.Border = Rectangle.NO_BORDER;
                hardcopy.AddCell(acknowledgement_line);
                Cell signature = new Cell("Signature : ");
                signature.Border = Rectangle.NO_BORDER;
                hardcopy.AddCell(signature);
                Cell signature_line = new Cell(new Chunk("                           ",textunderline));
                signature_line.Border = Rectangle.NO_BORDER;
                hardcopy.AddCell(signature_line);

                

                document.Add(hardcopy);

                

                document.Close();

                return true;
            }

            catch
            {
                return false;
            }
            
            
        }
    }
}
