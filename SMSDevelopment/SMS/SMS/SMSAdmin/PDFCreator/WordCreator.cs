using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.Office.Interop.Word;
using SMS.BusinessEntities.Main;

namespace SMS.Exporter
{
    public class WordCreator
    {
        Application word = new Application();
        Document wordDocument = new Document();
        Table wordTable;
        Paragraph para1;
        Paragraph para2;
        Paragraph para3;
        Paragraph para4;
        Range range;
        InlineShape shpe;
        Chart chart;
        Double pos;

        public WordCreator()
        {

        }

        public bool CreateWord(List<ClientVisitMinutes> lst)
        {
            word = (Application)Activator.CreateInstance(Type.GetTypeFromProgID("Word.Application"));
            word.Visible = true;

            object missing = System.Reflection.Missing.Value;
            object ref_range = null;

            wordDocument = word.Documents.Add(ref missing, ref missing, ref missing, ref missing);

            para1 = wordDocument.Content.Paragraphs.Add(ref missing);
            para1.Range.Text = "TRIPLE 'S' PROTECTION PTE.,LTD";
            para1.Range.Font.Bold = 1;
            para1.Range.Font.Size = 14;
            para1.Format.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            //para1.Format.SpaceAfter = 24;
            para1.Range.InsertParagraphAfter();

            object index = "\\endofdoc";
            object bookmark = wordDocument.Bookmarks.get_Item(ref index).Range;
            para2 = wordDocument.Content.Paragraphs.Add(ref bookmark);
            para2.Range.Text = "CLIENT VISIT MINUTES";
            para2.Range.Font.Size = 14;
            para2.Format.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            para2.Format.SpaceAfter = 6;
            para2.Range.InsertParagraphAfter();


           return true;
        }
    }
}
