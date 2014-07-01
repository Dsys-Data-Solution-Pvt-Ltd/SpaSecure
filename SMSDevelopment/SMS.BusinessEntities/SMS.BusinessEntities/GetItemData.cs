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

namespace SMS.BusinessEntities
{
    [Serializable]
    public class GetItemData
    {
        String _Model_No = string.Empty;
        String _Item_Name = string.Empty;
        String _Item_Description = string.Empty;
        String _Item_quantity = string.Empty;

        String _IssuedBy_Nric = string.Empty;
        String _IssuedBy_Name = string.Empty;
        String _IssuedBy_Position = string.Empty;
        String _IssuedBy_Time = string.Empty;

        String _IssuedTo_Nric = string.Empty;
        String _IssuedTo_Name = string.Empty;
        String _IssuedTo_Position = string.Empty;

        String _Status = string.Empty;
        String _Remarks = string.Empty;

        String _Foundremark = string.Empty;
        String _loged_Time = string.Empty;
        String _Signed_Time = string.Empty;
        String _Found_Time = string.Empty;

        String _whereClause = string.Empty;
        String _Location_id = string.Empty;
        String _status = string.Empty;

        public String WhereClause
        {
            get
            {
                return _whereClause;
            }
            set
            {
                _whereClause = value;
            }
        }

        public String Model_No
        {
            get
            {
                return _Model_No;
            }
            set
            {
                _Model_No = value;
            }
        }
        public String Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }
        public String Item_Name
        {
            get
            {
                return _Item_Name;
            }
            set
            {
                _Item_Name = value;
            }
        }
        public String Item_Description
        {
            get
            {
                return _Item_Description;
            }
            set
            {
                _Item_Description = value;
            }
        }
        public String Item_quantity
        {
            get
            {
                return _Item_quantity;
            }
            set
            {
                _Item_quantity = value;
            }
        }

        public String IssuedBy_Nric
        {
            get
            {
                return _IssuedBy_Nric;
            }
            set
            {
                _IssuedBy_Nric = value;
            }
        }
        public String IssuedBy_Name
        {
            get
            {
                return _IssuedBy_Name;
            }
            set
            {
                _IssuedBy_Name = value;
            }
        }
        public String IssuedBy_Position
        {
            get
            {
                return IssuedBy_Position;
            }
            set
            {
                _IssuedBy_Position = value;
            }
        }
        public String IssuedBy_Time
        {
            get
            {
                return _IssuedBy_Time;
            }
            set
            {
                _IssuedBy_Time = value;
            }
        }

        public String IssuedTo_Nric
        {
            get
            {
                return _IssuedTo_Nric;
            }
            set
            {
                _IssuedTo_Nric = value;
            }
        }
        public String IssuedTo_Name
        {
            get
            {
                return _IssuedTo_Name;
            }
            set
            {
                _IssuedTo_Name = value;
            }
        }
        public String IssuedTo_Position
        {
            get
            {
                return _IssuedTo_Position;
            }
            set
            {
                _IssuedTo_Position = value;
            }
        }

        public String Remarks
        {
            get
            {
                return _Remarks;
            }
            set
            {
                _Remarks = value;
            }
        }      
       

        public String Foundremark
        {
            get
            {
                return _Foundremark;
            }
            set
            {
                _Foundremark = value;
            }
        }        
        public String loged_Time
        {
            get
            {
                return _loged_Time;
            }
            set
            {
                _loged_Time = value;
            }
        }
        public String Signed_Time
        {
            get
            {
                return _Signed_Time;
            }
            set
            {
                _Signed_Time = value;
            }
        }
        public String Found_Time
        {
            get
            {
                return _Found_Time;
            }
            set
            {
                _Found_Time = value;
            }
        }

        public String Location_id
        {
            get
            {
                return _Location_id;
            }
            set
            {
                _Location_id = value;
            }

        }
    }
}
