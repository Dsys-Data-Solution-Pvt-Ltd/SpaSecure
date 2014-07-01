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

namespace SMS.BusinessEntities
{
    [Serializable]
    public class GetVehicleData
    {
        String _Vehicle_No = string.Empty;
        String _Vehicle_Type = string.Empty;
        String _Vehicle_Remark = string.Empty;
        String _Vehicle_Color = string.Empty;
        String _Vehicle_Model = string.Empty;
        String _whereClause = string.Empty;

        String _Date_From = string.Empty;
        String _Date_to = string.Empty;
        String _Owned_By = string.Empty;





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
        public String Vehicle_No
        {
            get
            {
                return _Vehicle_No;
            }
            set
            {
                _Vehicle_No = value;
            }
        }

        public String Vehicle_Type
        {
            get
            {
                return _Vehicle_Type;
            }
            set
            {
                _Vehicle_Type = value;
            }
        }

        public String Vehicle_Remark
        {
            get
            {
                return _Vehicle_Remark;
            }
            set
            {
                _Vehicle_Remark = value;
            }
        }

        public String Vehicle_Color
        {
            get
            {
                return _Vehicle_Color;
            }
            set
            {
                _Vehicle_Color = value;
            }
        }
        public String Vehicle_Model
        {
            get
            {
                return _Vehicle_Model;
            }
            set
            {
                _Vehicle_Model = value;
            }
        }


        public String DateFrom
        {
            get
            {
                return _Date_From;
            }
            set
            {
                _Date_From = value;
            }
        }
        public String _Dateto
        {
            get
            {
                return _Date_to;
            }
            set
            {
                _Date_to = value;
            }
        }
        public String Owned_By
        {
            get
            {
                return _Owned_By;
            }
            set
            {
                _Owned_By = value;
            }
        }




    }
}
