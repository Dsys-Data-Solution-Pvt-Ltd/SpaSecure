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
    public class GetLostFoundData
    {
      
        String _Name = string.Empty;
        String _Description = string.Empty;
        String _Location = string.Empty;

        String _NRICno = string.Empty;
        String _ContNo = string.Empty;
        String _Date = string.Empty;
        String _LostStatus = string.Empty;

        String _Time = string.Empty;
       

        String _whereClause = string.Empty;
       

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

        public String Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
            }
        }
        public String ContNo
        {
            get
            {
                return _ContNo;
            }
            set
            {
                _ContNo = value;
            }
        }
        public String NRICno
        {
            get
            {
                return _NRICno;
            }
            set
            {
                _NRICno = value;
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
        public String LostStatus
        {
            get
            {
                return _LostStatus;
            }
            set
            {
                _LostStatus = value;
            }
        }
        public String Location
        {
            get
            {
                return _Location;
            }
            set
            {
                _Location = value;
            }
        }
        public String Time
        {
            get
            {
                return _Time;
            }
            set
            {
                _Time = value;
            }
        }
        public String Date
        {
            get
            {
                return _Date;
            }
            set
            {
                _Date = value;
            }
        }
    }
}