using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;


using System.Text.RegularExpressions;
using SMS.BusinessEntities.Main;

using Microsoft.Practices.EnterpriseLibrary;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System.Collections.Generic;

namespace SMS.BusinessEntities.Main
{
    [Serializable]
    [HasSelfValidation]
    public class ItemData
    {
        public String AddItem_ID { get; set; }
        public String Model_No { get; set; }
        public String Item_Name { get; set; }
        public String Item_Description { get; set; }
        public String Item_quantity { get; set; }

        public String IssuedBy_Nric { get; set; }
        public String IssuedBy_Name { get; set; }
        public String IssuedBy_Position { get; set; }
        public String IssuedBy_Time { get; set; }

        public String IssuedTo_Nric { get; set; }
        public String IssuedTo_Name { get; set; }
        public String IssuedTo_Position { get; set; }

        public String Status { get; set; }
        public String Remark { get; set; }

        public String Foundremark { get; set; }
        public DateTime? loged_Time { get; set; }
        public DateTime? Signed_Time { get; set; }
        public DateTime? Found_Time { get; set; }

        public String Location_id { get; set; }
       
    

     [SelfValidation]
        public void Validate(ValidationResults results)
        {
            //if (String.IsNullOrEmpty(Item_no))
            //{
            //    results.AddResult(new ValidationResult("Please enter a Item No.", this, "Item_No", null, null));
            //}


        }  
    } 

}




















