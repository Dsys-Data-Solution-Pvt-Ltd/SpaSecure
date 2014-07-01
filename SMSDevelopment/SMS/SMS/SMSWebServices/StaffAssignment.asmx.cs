using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;
using System.Linq;
using System.Linq.Expressions;
using System.Globalization;
using System.Linq.Dynamic;

namespace SMS.SMSWebServices
{
    /// <summary>
    /// Summary description for StaffAssignment
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class StaffAssignment : System.Web.Services.WebService
    {

        [WebMethod]
        public string GetAllStaff()
        {
            SMSDataContext dc = new SMSDataContext();
            var staffs = (from d in dc.UserInformations
                          where d.Role.Contains("Guard") || d.Role.Contains("Staff")
                          orderby d.Role
                          select d);

            string persons = "";
            foreach (var staff in staffs)
            {
                persons += "<li title=\"" + staff.UserID+","+staff.Role + "\"><a href='#" + staff.Staff_ID + "'>" + staff.UserID+" ("+staff.Role+")" + "</a><br /></li>";
            }
            return persons;
        }
    }
}
