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

using System.Collections.Generic;

using SMS.BusinessEntities.Main;

namespace SMS.BusinessEntities
{
    [Serializable]
    public class GetIncidentData
    {
        String _Date_of_Incident = string.Empty;
        String _Time_of_Incident = string.Empty;

        String _Assignment = string.Empty;
        String _Place_of_Incident = string.Empty;
        String _Type_of_Incident = string.Empty;
        String _Report_No = string.Empty;
        String _ReportDetail = string.Empty;

        String _Reported_By = string.Empty;
        String _Name = string.Empty;
        String _Verified_By = string.Empty;
        String _whereClause = string.Empty;

        String _follownric = string.Empty;
        String _followinvesti = string.Empty;
        String _followverify = string.Empty;
        String _followstatus = string.Empty;
        String _followtime = string.Empty;
        String _followdate = string.Empty;
        String _followsremark = string.Empty;
        String _Location_id = string.Empty;
        String _AlertStatus = string.Empty;



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
        public String AlertStatus
        {
            get
            {
                return _AlertStatus;
            }
            set
            {
                _AlertStatus = value;
            }
        }
        public String Date_of_Incident
        {
            get
            {
                return _Date_of_Incident;
            }
            set
            {
                _Date_of_Incident = value;
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

        public String Time_of_Incident
        {
            get
            {
                return _Time_of_Incident;
            }
            set
            {
                _Time_of_Incident = value;
            }
        }
        public String Assignment
        {
            get
            {
                return _Assignment;
            }
            set
            {
                _Assignment = value;
            }
        }
        public String Place_of_Incident
        {
            get
            {
                return _Place_of_Incident;
            }
            set
            {
                _Place_of_Incident = value;
            }


        }
        public String Type_of_Incident
        {
            get
            {
                return _Type_of_Incident;
            }
            set
            {
                _Type_of_Incident = value;
            }


        }
        public String Report_No
        {
            get
            {
                return _Report_No;
            }
            set
            {
                _Report_No= value;
            }


        }
        public String Reported_By
        {
            get
            {
                return _Reported_By;
            }
            set
            {
                _Reported_By = value;
            }


        }
        public String ReportDetail
        {
            get
            {
                return _ReportDetail;
            }
            set
            {
                _ReportDetail = value;
            }


        }
        public String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }


        }
        public String Verified_By
        {
            get
            {
                return _Verified_By;
            }
            set
            {
                _Verified_By = value;
            }


        }

        public String follownric
        {
            get
            {
                return _follownric;
            }
            set
            {
                _follownric = value;
            }


        }
        public String followinvesti
        {
            get
            {
                return _followinvesti;
            }
            set
            {
                _followinvesti = value;
            }


        }
        public String followverify
        {
            get
            {
                return _followverify;
            }
            set
            {
                _followverify = value;
            }


        }
        public String followstatus
        {
            get
            {
                return _followstatus;
            }
            set
            {
                _followstatus = value;
            }


        }
        public String followtime
        {
            get
            {
                return _followtime;
            }
            set
            {
                _followtime = value;
            }


        }
        public String followdate
        {
            get
            {
                return _followdate;
            }
            set
            {
                _followdate = value;
            }


        }
        public String followsremark
        {
            get
            {
                return _followsremark;
            }
            set
            {
                _followsremark = value;
            }


        }
    


    }
}
