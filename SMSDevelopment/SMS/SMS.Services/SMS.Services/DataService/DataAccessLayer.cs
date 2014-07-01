using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using log4net;
using log4net.Config;
using SMS.Services.DataService;
using System.Data.SqlClient;

using SMS.BusinessEntities;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;

namespace SMS.Services.DataService
{

    public class DataAccessLayer
    {
        SqlConnection cn;
        public int gridpageindex = 0;


        public SqlConnection getconnection()
        {
            //LKOI12705310

            cn = new SqlConnection();
            cn.ConnectionString = ConfigurationManager.ConnectionStrings["tspsecur_SMSConnectionString"].ConnectionString;
            cn.Open();
            return cn;
        }
      
        
        #region Connection and Command Object
        public SqlConnection _con;
        public SqlCommand _com;
        #endregion

        #region properties
        public SqlConnection con
        {
            get
            {
                return _con;
            }
            set
            {
                _con = value;
            }
        }
        public SqlCommand com
        {
            get
            {
                return _com;
            }
            set
            {
                _com = value;
            }
        }

        #endregion

        #region PrivateMethods
        private void openconnection()
        {
            if (_con == null)
            {
                _con = new SqlConnection(ConfigurationManager.ConnectionStrings["tspsecur_SMSConnectionString"].ConnectionString);
                _com = new SqlCommand();
                _com.Connection = _con;
            }
            if (_con.State == ConnectionState.Closed)
            {
                _con.Open();

            }

        }
        private void closeconnection()
        {
            if (_con.State == ConnectionState.Open)
            {
                _com.Dispose();
                _con.Close();
            }
        }

        private void disposeconnection()
        {
            if (_con.State == ConnectionState.Closed)
            {
                _con.Dispose();
                _con = null;
            }
        }
        #endregion

        #region PublicMethods
        public int executesql(string strsql)
        {
            openconnection();
            _com.CommandType = CommandType.Text;
            _com.CommandTimeout = 2;
            _com.CommandText = strsql;
            int result = _com.ExecuteNonQuery();
            closeconnection();
            disposeconnection();
            return result;
        }

        public DataTable getdata(string strsql)
        {
            openconnection();
            _com.CommandType = CommandType.Text;
            _com.CommandTimeout = 2;
            _com.CommandText = strsql;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = _com;
            da.Fill(dt);
            closeconnection();
            disposeconnection();
            return dt;
        }

        public DataSet getdataset(string strsql)
        {
            openconnection();
            _com.CommandType = CommandType.Text;
            _com.CommandTimeout = 20;
            _com.CommandText = strsql;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = _com;
            da.Fill(ds);
            closeconnection();
            disposeconnection();
            return ds;
        }

        public int executeprocedure(string spname, SqlParameter[] arrparam)
        {
            openconnection();
            _com.CommandType = CommandType.StoredProcedure;
            _com.CommandTimeout = 2;
            _com.CommandText = spname;

            if (arrparam != null)
            {
                _com.Parameters.Clear();

                for (int i = 0; i < arrparam.Length; i++)
                {
                    _com.Parameters.Add(arrparam[i]);
                }
            }
            int result = _com.ExecuteNonQuery();
            closeconnection();
            disposeconnection();
            return result;

        }


        public void exeprocedure(string spname, SqlParameter[] arrparam)
        {
            openconnection();
            _com.CommandType = CommandType.StoredProcedure;
            _com.CommandTimeout = 2;
            _com.CommandText = spname;

            if (arrparam != null)
            {
                _com.Parameters.Clear();

                for (int i = 0; i < arrparam.Length; i++)
                {
                    _com.Parameters.Add(arrparam[i]);
                }
            }
            int result = _com.ExecuteNonQuery();
            closeconnection();
            disposeconnection();
          //  return result;

        }


        public DataTable executeprocedure(string spname, SqlParameter[] arrparam, bool var)
        {
            openconnection();
            _com.CommandType = CommandType.StoredProcedure;
            _com.CommandTimeout = 2;
            _com.CommandText = spname;

            if (arrparam != null)
            {
                _com.Parameters.Clear();

                for (int i = 0; i < arrparam.Length; i++)
                {
                    _com.Parameters.Add(arrparam[i]);
                }
            }
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = _com;
            da.Fill(dt);
            closeconnection();
            disposeconnection();
            return dt;

        }

        public SqlDataReader getDataReader(string strsql)
        {
             openconnection();
            _com.CommandType = CommandType.Text;
            _com.CommandTimeout = 2;
            _com.CommandText = strsql;
            // _com(strsql, _con);
            SqlDataReader rd = _com.ExecuteReader();
            // closeconnection();
            // disposeconnection();
            return rd;
        }

       
        #endregion

        public string orderby(string where, string field)
        {
            string returnorderby = string.Empty;
            if (where == "A-Z")
            {
                return returnorderby = " Order by " + field + " Asc ";
            }
            if (where == "Z-A")
            {
                return returnorderby = " Order by " + field + " Desc ";
            }
            if (where == "Date")
            {
                return returnorderby = " Order by " + field + " Desc ";
            }
            return returnorderby; 
            
           
        }
        public DataTable executeprocedure1(string spname, SqlParameter[] arrparam, bool var)
        {
            openconnection();
            _com.CommandType = CommandType.StoredProcedure;
            _com.CommandTimeout = 2;
            _com.CommandText = spname;

            if (arrparam != null)
            {
                _com.Parameters.Clear();

                //for (int i = 0; i < arrparam.Length; i++)
                //{
                    _com.Parameters.Add(arrparam[0]);
                //}
            }
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = _com;
            da.Fill(dt);
            closeconnection();
            disposeconnection();
            return dt;

        }






    }
}
        
    

