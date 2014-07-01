using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using SMS.Services.DataService;
using SMS.Services.DALUtilities;
using SMS.Services.BusinessServices;



namespace SMS.Services.DALUtilities
{
    public class DBConnectionHandler1
    {
        public SqlConnection _cn;
        SqlCommand _cmd;
        int output, editmenumast, countmenumast, searchparentid1, result;
        public SqlConnection getconnection()
        {
            _cn = new SqlConnection();
            _cn.ConnectionString = ConfigurationManager.ConnectionStrings["tspsecur_SMSConnectionString"].ConnectionString;
            return _cn;

        }
        public SqlConnection con
        {
            get
            {
                return _cn;

            }
            set
            {
                _cn = value;

            }
        }
        public void closeconnection()
        {
            if (_cn.State == ConnectionState.Closed)
            {
                _cn.Close();
                _cn = null;

            }
        }
        public SqlCommand cmd
        {
            get
            {
                return _cmd;

            }
            set
            {
                _cmd = value;

            }
        }
        public void closecommand()
        {
            if (_cn.State == ConnectionState.Closed)
            {
                _cn.Close();
                _cn = null;

            }
        }
        public int insertprocedure(string SpName, SqlParameter[] sqlParams)
        {
            SqlConnection cn = getconnection();
            cn.Open();
            _cmd = new SqlCommand(SpName, cn);
            _cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < sqlParams.Length; i++)
            {
                _cmd.Parameters.Add(sqlParams[i]);
            }
            output = _cmd.ExecuteNonQuery();
            closeconnection();
            return output;

        }
        public int editmenumastmap(string SpName, SqlParameter[] sqlParams)
        {
            SqlConnection cn = getconnection();
            cn.Open();
            _cmd = new SqlCommand(SpName, cn);
            _cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < sqlParams.Length; i++)
            {
                _cmd.Parameters.Add(sqlParams[i]);
            }
            editmenumast = cmd.ExecuteNonQuery();
            closeconnection();
            return editmenumast;

        }
        public int countmenumastmap(string spname, SqlParameter[] param)
        {
            SqlConnection cn = getconnection();
            cn.Open();
            _cmd = new SqlCommand(spname, cn);
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.Add(param[0]);
            _cmd.Parameters.Add(param[1]);
            _cmd.Parameters.Add(param[2]);
            int countmenumast = (int)_cmd.ExecuteScalar();
            closeconnection();
            return countmenumast;
        }
        public DataTable getData(SqlCommand cmd)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            _cmd = new SqlCommand();
            //cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandType = CommandType.Text;
            _cmd.Connection = _cn;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                da.Fill(ds);
                dt = ds.Tables[0];
            }
            catch (Exception ex)
            {
            }
            return dt;
        }
        public int Runsql(SqlParameter[] param, string sp)//method to run by stored procedure
        {

            SqlConnection cn;
            cn = getconnection();
            cn.Open();
            _cmd = new SqlCommand(sp, cn);
            _cmd.CommandType = CommandType.StoredProcedure;
            // _cmd.CommandText = "sp_Addtraining";

            if (param != null)
            {
                _cmd.Parameters.Clear();
                for (int i = 0; i < param.Length; i++)
                {
                    _cmd.Parameters.Add(param[i]);
                }
            }
            result = _cmd.ExecuteNonQuery();
            return result;
        }
    }
}