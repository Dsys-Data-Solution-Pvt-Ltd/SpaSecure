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
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.SqlClient;

namespace SMS.Services.DALUtilities
{
    public class DBConnectionHandler
    {

        public static DBConnectionHandler pDBConnectionHandler;
        private static Database pDatabase;

        // Making the default constructor private
        private DBConnectionHandler()
        {

        }

        // single point of access for database connection
        public static DBConnectionHandler GetDBConnection()
        {
            if (pDBConnectionHandler == null)
            {
                pDBConnectionHandler = new DBConnectionHandler();
                Connect();
            }
            return pDBConnectionHandler;
        }

        public Database DBConnection
        {
            get
            {
                return pDatabase;
            }
        }



        private static Database Connect()
        {
            try
            {
                pDatabase = DatabaseFactory.CreateDatabase(DALConstants.Misc.CONNECTION_STRING);
                return pDatabase;
            }
            catch (Exception cex)
            {
                throw cex;
            }
        }

    }
}
