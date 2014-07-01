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
    public class GetShiftData
    {
        String _Shift_ID = string.Empty;
        String _shiftdep = string.Empty;
        DateTime? _ShiftDateFrom =DateTime.Now;
        DateTime? _ShiftDateTo=DateTime.Now;
        DateTime? _ShiftTimeFrom=DateTime.Now;
        DateTime? _ShiftTimeTo = DateTime.Now;
        String _Location= string.Empty;
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

        public String Shift_ID
        {
            get
            {
                return _Shift_ID;
            }
            set
            {
                _Shift_ID = value;
            }
        }
        public String shiftdep
        {
            get
            {
                return _shiftdep;
            }
            set
            {
                _shiftdep = value;
            }
        }
        public DateTime? ShiftDateFrom
        {
            get
            {
                return _ShiftDateFrom;
            }
            set
            {
                _ShiftDateFrom = value;
            }
        }
        public DateTime? ShiftDateTo
        {
            get
            {
                return _ShiftDateTo;
            }
            set
            {
                _ShiftDateTo = value;
            }
        }
        public DateTime? ShiftTimeFrom
        {
            get
            {
                return _ShiftTimeFrom;
            }
            set
            {
                _ShiftTimeFrom = value;
            }
        }
        public DateTime? ShiftTimeTo
        {
            get
            {
                return _ShiftTimeTo;
            }
            set
            {
                _ShiftTimeTo = value;
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
       
     }
}
