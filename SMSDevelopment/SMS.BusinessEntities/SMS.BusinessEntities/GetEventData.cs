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
    public class GetEventData
    {
        String _eventid = String.Empty;
        String _date = string.Empty;
        String _time = string.Empty;
        String _location = string.Empty;
        String _eventbreaf = string.Empty;


        public String eventid
        {
            get
            {
                return _eventid;
            }
            set
            {
                _eventid = value;
            }
        }

        public String date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
            }
        }

        public String time
        {
            get
            {
                return _time;
            }
            set
            {
                _time = value;
            }
        }

        public String location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
            }
        }

        public String eventbreaf
        {
            get
            {
                return _eventbreaf;
            }
            set
            {
                _eventbreaf = value;
            }
        }





    }
}



