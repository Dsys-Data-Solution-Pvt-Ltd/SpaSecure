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
using System.Data.SqlClient;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Drawing;
using System.IO;
using SMS.Services.DataService;
using log4net;
using log4net.Config;
using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.BusinessEntities;
using SMS.Services.DALUtilities;
using SMS.Services.BusinessServices;
using SMS.Services;


namespace SMS.Services.DataService
{
    public class AdminDAL
    {
        int output, sermenuid, searchtreeval, editmenumast, countmenumast, searchparentid1, output2;
        int searchzeroparentid1, serstatusmenuid, parent, parent2;

        #region privatemethod
        public SqlConnection _cn;
        public SqlCommand _cmd = new SqlCommand();
        public SqlConnection getconnection()
        {
            _cn = new SqlConnection();
            _cn.ConnectionString = ConfigurationManager.ConnectionStrings["tspsecur_SMSConnectionString"].ConnectionString;
            _cn.Open();
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
        public void closecon()
        {
            if (_cn.State == ConnectionState.Open)
            {
                _cmd.Dispose();
                _cn.Close();

            }
        }
        public void disposeconnection()
        {
            if (_cn.State == ConnectionState.Closed)
            {
                _cn.Dispose();
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

        public int executesql(string strsql)
        {
            AdminDAL a = new AdminDAL();
            a.getconnection();
            _cmd.CommandType = CommandType.Text;
            _cmd.CommandTimeout = 2;
            _cmd.CommandText = strsql;
            int result = _cmd.ExecuteNonQuery();
            closecon();
            disposeconnection();
            return result;

        }
        public DataSet getdatasetDAL(string strsql)
        {
            Database db = DBConnectionHandler.GetDBConnection().DBConnection;
            DbCommand dbCommand = db.GetSqlStringCommand(strsql);
            DataSet ds = new DataSet();
            // IDataAdapter adp = new IDataAdapter(dbCommand);

            //  adp = db.ExecuteScalar(dbCommand);
            //adp.SelectCommand = dbCommand;
            //  adp.Fill(ds);
            return ds;

            //_cmd.CommandType = CommandType.Text;
            //_cmd.CommandTimeout = 2;
            //_cmd.CommandText = strsql;
            //DataSet ds = new DataSet();
            //SqlDataAdapter adp = new SqlDataAdapter();
            //adp.SelectCommand = _cmd;
            //adp.Fill(ds);
            //closecon();
            //disposeconnection();
            //return ds;

        }
        public bool isexistDAL(string strsql)
        {
            Database db = DBConnectionHandler.GetDBConnection().DBConnection;
            DbCommand dbCommand = db.GetSqlStringCommand(strsql);
            IDataReader rd = null;
            rd = db.ExecuteReader(dbCommand);

            rd.Read();
            string test = rd[0].ToString();

            if (test == "1")
                return true;
            else
            {
                return false;
            }

        }
        #endregion

        #region MenuItem

        public DataSet GetMenuItems(GetAuthRequest argObj)
        {
            string userrole = string.Empty;
            string getuserRole = string.Empty;
            DataSet ds = null;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                //DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.SPNames.GET_MENU_ITEMS);
                DbCommand dbCommand = db.GetStoredProcCommand("usp_GetMenuItems");


                getuserRole = GetAuthenticateUserRole(argObj);

                if (getuserRole == "Security Officer")
                {
                    userrole = "1";
                }
                if (getuserRole == "Middle Administrator")
                {
                    userrole = "2";
                }
                if (getuserRole == "Senior Administrator")
                {
                    userrole = "5";
                }
                if (getuserRole == "Client")
                {
                    userrole = "0";
                }
                db.AddInParameter(dbCommand, "@ManagementRole", DbType.String, userrole);
                ds = db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
            return ds;
        }

        public List<User_Info>GetUserStaffInfo(GetUserData argObj)
        {
            List<User_Info> lstStaffID = null;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetSqlStringCommand("select * from UserInformation with(nolock)" + argObj.WhereClause);
                IDataReader dataReader = null;
                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    dataReader = db.ExecuteReader(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
                lstStaffID = CBO.FillCollection<User_Info>(dataReader);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

            return lstStaffID;
        }


        public List<User_Info> GetUserStaffInfo1(GetUserData argObj)
        {
            List<User_Info> lstStaffID = null;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetSqlStringCommand("select * from UserInformation with(nolock)" + argObj.WhereClause);
                IDataReader dataReader = null;
                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    dataReader = db.ExecuteReader(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
                lstStaffID = CBO.FillCollection<User_Info>(dataReader);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

            return lstStaffID;
        }




        public void DeleteStaff_Present(DeleteUserRequest argObj)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.SPNames.DELETE_STAFF_PRESENT);

                db.AddInParameter(dbCommand, "@Staff_ID", DbType.String, argObj.UserNo);
                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }


        #endregion

        #region chickin insert

        public void AddCheckinGaurd(checkin objcheckin)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.CheckInInfoConst.SPNames.Checkin_Guard);

                db.AddInParameter(dbCommand, "@NRICno", DbType.String, objcheckin.NRICno);
                db.AddInParameter(dbCommand, "@UserID", DbType.String, objcheckin.UserID);
                db.AddInParameter(dbCommand, "@user_name", DbType.String, objcheckin.user_name);
                db.AddInParameter(dbCommand, "@telephone", DbType.String, objcheckin.telephone);
                db.AddInParameter(dbCommand, "@ImagePath", DbType.String, objcheckin.ImagePath);
                db.AddInParameter(dbCommand, "@Role", DbType.String, objcheckin.Role);
                db.AddInParameter(dbCommand, "@Checkin_DateTime", DbType.DateTime, objcheckin.Checkin_DateTime);
                db.AddInParameter(dbCommand, "@LocationID", DbType.Int32, objcheckin.LocationID);

                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    db.ExecuteNonQuery(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }


        public void AddCheckinVisitor(checkin objcheckin)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.CheckInInfoConst.SPNames.Checkin_Visitor);

                // db.AddInParameter(dbCommand, "@checkin_id", DbType.String, objcheckin.checkin_id);
                db.AddInParameter(dbCommand, "@NRICno", DbType.String, objcheckin.NRICno);
                db.AddInParameter(dbCommand, "@user_name", DbType.String, objcheckin.user_name);
                db.AddInParameter(dbCommand, "@user_address", DbType.String, objcheckin.user_address);
                db.AddInParameter(dbCommand, "@company_from", DbType.String, objcheckin.company_from);
                db.AddInParameter(dbCommand, "@telephone", DbType.String, objcheckin.telephone);
                db.AddInParameter(dbCommand, "@remarks", DbType.String, objcheckin.remarks);
                db.AddInParameter(dbCommand, "@key_no ", DbType.String, objcheckin.Key_no);
                db.AddInParameter(dbCommand, "@ImagePath", DbType.String, objcheckin.ImagePath);
                db.AddInParameter(dbCommand, "@Pass_No", DbType.String, objcheckin.Pass_No);
                db.AddInParameter(dbCommand, "@pass_type", DbType.String, objcheckin.pass_type);
                db.AddInParameter(dbCommand, "@Vehicle_No", DbType.String, objcheckin.Vehicle_No);
                db.AddInParameter(dbCommand, "@to_visit", DbType.String, objcheckin.to_visit);
                db.AddInParameter(dbCommand, "@purpose", DbType.String, objcheckin.purpose);
                db.AddInParameter(dbCommand, "@Item_Declear", DbType.String, objcheckin.Item_Declear);
                db.AddInParameter(dbCommand, "@Checkin_DateTime", DbType.DateTime, objcheckin.Checkin_DateTime);
                db.AddInParameter(dbCommand, "@Role", DbType.String, objcheckin.Role);
                db.AddInParameter(dbCommand, "@LocationID", DbType.Int32, objcheckin.LocationID);

                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    db.ExecuteNonQuery(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

        }

        public void AddCheckinContractor(checkin objcheckin)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.CheckInInfoConst.SPNames.Checkin_Contractor);

                //db.AddInParameter(dbCommand, "@checkin_id", DbType.String, objcheckin.checkin_id);
                //db.AddInParameter(dbCommand, "@UserID", DbType.String, objcheckin.UserID);
                db.AddInParameter(dbCommand, "@user_name", DbType.String, objcheckin.user_name);
                db.AddInParameter(dbCommand, "@user_address", DbType.String, objcheckin.user_address);
                db.AddInParameter(dbCommand, "@company_from", DbType.String, objcheckin.company_from);
                db.AddInParameter(dbCommand, "@telephone", DbType.String, objcheckin.telephone);
                db.AddInParameter(dbCommand, "@remarks", DbType.String, objcheckin.remarks);
                db.AddInParameter(dbCommand, "@key_no ", DbType.String, objcheckin.Key_no);
                db.AddInParameter(dbCommand, "@user_image", DbType.String, objcheckin.user_image);
                db.AddInParameter(dbCommand, "@Pass_No", DbType.String, objcheckin.Pass_No);
                db.AddInParameter(dbCommand, "@pass_type", DbType.String, objcheckin.pass_type);
                db.AddInParameter(dbCommand, "@Vehicle_No", DbType.String, objcheckin.Vehicle_No);
                db.AddInParameter(dbCommand, "@to_visit", DbType.String, objcheckin.to_visit);
                db.AddInParameter(dbCommand, "@Item_Declear", DbType.String, objcheckin.Item_Declear);
                db.AddInParameter(dbCommand, "@Checkin_DateTime", DbType.DateTime, objcheckin.Checkin_DateTime);
                db.AddInParameter(dbCommand, "@Status", DbType.String, objcheckin.Status);
                db.AddInParameter(dbCommand, "@ImagePath", DbType.String, objcheckin.ImagePath);
                db.AddInParameter(dbCommand, "@purpose", DbType.String, objcheckin.purpose);
                db.AddInParameter(dbCommand, "@Role", DbType.String, objcheckin.Role);
                db.AddInParameter(dbCommand, "@LocationID", DbType.Int32, objcheckin.LocationID);
                db.AddInParameter(dbCommand, "@NRICno", DbType.String, objcheckin.NRICno);

                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    db.ExecuteNonQuery(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        public void AddCheckinStaff(checkin objcheckin)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.CheckInInfoConst.SPNames.Checkin_Staff);

                //  db.AddInParameter(dbCommand, "@checkin_id", DbType.String, objcheckin.checkin_id);
                db.AddInParameter(dbCommand, "@UserID", DbType.String, objcheckin.UserID);
                db.AddInParameter(dbCommand, "@user_name", DbType.String, objcheckin.user_name);
                db.AddInParameter(dbCommand, "@telephone", DbType.String, objcheckin.telephone);
                // db.AddInParameter(dbCommand, "@user_image", DbType.String, objcheckin.user_image);
                db.AddInParameter(dbCommand, "@Checkin_DateTime", DbType.DateTime, objcheckin.Checkin_DateTime);
                db.AddInParameter(dbCommand, "@Department", DbType.String, objcheckin.Department);
                db.AddInParameter(dbCommand, "@Role", DbType.String, objcheckin.Role);
                db.AddInParameter(dbCommand, "@Pass_No", DbType.String, objcheckin.Pass_No);
                db.AddInParameter(dbCommand, "@Key_no", DbType.String, objcheckin.Key_no);
                db.AddInParameter(dbCommand, "@remarks", DbType.String, objcheckin.remarks);
                db.AddInParameter(dbCommand, "@LocationID", DbType.Int32, objcheckin.LocationID);

                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    db.ExecuteNonQuery(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        
        }

        #endregion

        #region Checkout insert

        public void AddCheckOutGaurd(checkout objcheckout)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.CheckOutInfoConst.SPNames.Checkout_Guard);

                db.AddInParameter(dbCommand, "@checkinid", DbType.String, objcheckout.checkin_id);
                db.AddInParameter(dbCommand, "@NRICno", DbType.String, objcheckout.NRICno);
                db.AddInParameter(dbCommand, "@user_id", DbType.String, objcheckout.user_id);
                db.AddInParameter(dbCommand, "@user_name", DbType.String, objcheckout.user_name);
                db.AddInParameter(dbCommand, "@telephone", DbType.String, objcheckout.telephone);

                db.AddInParameter(dbCommand, "@key_no ", DbType.String, objcheckout.key_no);
                db.AddInParameter(dbCommand, "@user_image", DbType.String, objcheckout.user_image);
                db.AddInParameter(dbCommand, "@pass_no", DbType.String, objcheckout.pass_no);
                db.AddInParameter(dbCommand, "@Role", DbType.String, objcheckout.Role);
                db.AddInParameter(dbCommand, "@checkin_time", DbType.DateTime, objcheckout.Checkin_DateTime);
                db.AddInParameter(dbCommand, "@checkout_time", DbType.DateTime, objcheckout.Checkout_DateTime);
                db.AddInParameter(dbCommand, "@LocationID", DbType.String, objcheckout.Location_id);


                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    db.ExecuteNonQuery(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        public void AddCheckOutVisitor(checkout objcheckout)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.CheckOutInfoConst.SPNames.Checkout_Visitor);


                db.AddInParameter(dbCommand, "@checkin_id", DbType.String, objcheckout.checkin_id);
                db.AddInParameter(dbCommand, "@NRICno", DbType.String, objcheckout.NRICno);
                db.AddInParameter(dbCommand, "@user_name", DbType.String, objcheckout.user_name);
                db.AddInParameter(dbCommand, "@user_address", DbType.String, objcheckout.user_address);
                db.AddInParameter(dbCommand, "@company_from", DbType.String, objcheckout.company_from);
                db.AddInParameter(dbCommand, "@telephone", DbType.String, objcheckout.telephone);
                db.AddInParameter(dbCommand, "@remarks", DbType.String, objcheckout.remarks);
                db.AddInParameter(dbCommand, "@key_no ", DbType.String, objcheckout.key_no);
                db.AddInParameter(dbCommand, "@user_image", DbType.String, objcheckout.user_image);
                db.AddInParameter(dbCommand, "@pass_no", DbType.String, objcheckout.pass_no);
                db.AddInParameter(dbCommand, "@Vehicle_no", DbType.String, objcheckout.vehicle_no);
                db.AddInParameter(dbCommand, "@to_visit", DbType.String, objcheckout.to_visit);
                db.AddInParameter(dbCommand, "@checkin_time", DbType.DateTime, objcheckout.Checkin_DateTime);
                db.AddInParameter(dbCommand, "@checkout_time", DbType.DateTime, objcheckout.Checkout_DateTime);
                db.AddInParameter(dbCommand, "@PassType", DbType.String, objcheckout.PassType);
                db.AddInParameter(dbCommand, "@purpose", DbType.String, objcheckout.purpose);
                db.AddInParameter(dbCommand, "@Item_Declear", DbType.String, objcheckout.Item_Declear);
                db.AddInParameter(dbCommand, "@Role", DbType.String, objcheckout.Role);
                db.AddInParameter(dbCommand, "@LocationID", DbType.String, objcheckout.Location_id);


                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    db.ExecuteNonQuery(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        public void AddCheckOutSaleman(checkout objcheckout)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.CheckOutInfoConst.SPNames.Checkout_Salesman);

                // db.AddInParameter(dbCommand, "@checkin_id", DbType.String, objcheckout.checkin_id);
                db.AddInParameter(dbCommand, "@checkout_id", DbType.String, objcheckout.checkout_id);
                db.AddInParameter(dbCommand, "@user_id", DbType.String, objcheckout.user_id);
                db.AddInParameter(dbCommand, "@telephone", DbType.String, objcheckout.telephone);

                db.AddInParameter(dbCommand, "@user_name", DbType.String, objcheckout.user_name);
                db.AddInParameter(dbCommand, "@key_no ", DbType.String, objcheckout.key_no);
                db.AddInParameter(dbCommand, "@checkin_time", DbType.DateTime, objcheckout.Checkin_DateTime);
                db.AddInParameter(dbCommand, "@checkout_time", DbType.DateTime, objcheckout.Checkout_DateTime);

                db.AddInParameter(dbCommand, "@pass_no", DbType.String, objcheckout.pass_no);
                db.AddInParameter(dbCommand, "@Role", DbType.String, objcheckout.Role);
                db.AddInParameter(dbCommand, "@Department", DbType.String, objcheckout.Department);
                db.AddInParameter(dbCommand, "@remarks", DbType.String, objcheckout.remarks);

                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    db.ExecuteNonQuery(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        public void AddCheckOutContractor(checkout objcheckout)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.CheckOutInfoConst.SPNames.Checkout_Contractor);

                db.AddInParameter(dbCommand, "@checkin_id", DbType.String, objcheckout.checkin_id);
                //db.AddInParameter(dbCommand, "@checkout_id", DbType.String, objcheckout.checkout_id);
                db.AddInParameter(dbCommand, "@NRICno", DbType.String, objcheckout.NRICno);
                db.AddInParameter(dbCommand, "@user_name", DbType.String, objcheckout.user_name);
                db.AddInParameter(dbCommand, "@user_address", DbType.String, objcheckout.user_address);
                db.AddInParameter(dbCommand, "@company_from", DbType.String, objcheckout.company_from);
                db.AddInParameter(dbCommand, "@telephone", DbType.String, objcheckout.telephone);
                db.AddInParameter(dbCommand, "@remarks", DbType.String, objcheckout.remarks);
                db.AddInParameter(dbCommand, "@key_no ", DbType.String, objcheckout.key_no);
                db.AddInParameter(dbCommand, "@user_image", DbType.String, objcheckout.user_image);
                db.AddInParameter(dbCommand, "@pass_no", DbType.String, objcheckout.pass_no);
                db.AddInParameter(dbCommand, "@Vehicle_no", DbType.String, objcheckout.vehicle_no);
                db.AddInParameter(dbCommand, "@to_visit", DbType.String, objcheckout.to_visit);
                db.AddInParameter(dbCommand, "@checkin_time", DbType.DateTime, objcheckout.Checkin_DateTime);
                db.AddInParameter(dbCommand, "@checkout_time", DbType.DateTime, objcheckout.Checkout_DateTime);
                db.AddInParameter(dbCommand, "@PassType", DbType.String, objcheckout.PassType);
                db.AddInParameter(dbCommand, "@purpose", DbType.String, objcheckout.purpose);
                db.AddInParameter(dbCommand, "@Item_Declear", DbType.String, objcheckout.Item_Declear);
                db.AddInParameter(dbCommand, "@Role", DbType.String, objcheckout.Role);

                db.AddInParameter(dbCommand, "@LocationID", DbType.String, objcheckout.Location_id);

                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    db.ExecuteNonQuery(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        #endregion

        #region InsertData

        public void AddUserIncident(UserIncident objUserIncident)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.SPNames.User_AddIncident);

                db.AddInParameter(dbCommand, "@Location_id", DbType.String, objUserIncident.Location_id);
                db.AddInParameter(dbCommand, "@Date_of_Incident", DbType.Date, objUserIncident.Date_of_Incident);
                db.AddInParameter(dbCommand, "@Time_of_Incident", DbType.String, objUserIncident.Time_of_Incident);
                db.AddInParameter(dbCommand, "@Place_of_Incident", DbType.String, objUserIncident.Place_of_Incident);

                db.AddInParameter(dbCommand, "@Report_No", DbType.String, objUserIncident.Report_No);
                db.AddInParameter(dbCommand, "@Received_By", DbType.String, objUserIncident.Received_By);
                db.AddInParameter(dbCommand, "@ReceivedVerified_By", DbType.String, objUserIncident.ReceivedVerified_By);

                db.AddInParameter(dbCommand, "@ReportDetail", DbType.String, objUserIncident.ReportDetail);
                db.AddInParameter(dbCommand, "@Reported_By", DbType.String, objUserIncident.Reported_By);
                
                db.AddInParameter(dbCommand, "@Verified_By", DbType.String, objUserIncident.Verified_By);
                db.AddInParameter(dbCommand, "@followstatus", DbType.String, objUserIncident.followstatus);

                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    db.ExecuteNonQuery(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        public void AddUserPass(Pass objUserPass)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.SPNames.User_AddPass);

                db.AddInParameter(dbCommand, "@Staff_ID", DbType.String, objUserPass.Staff_ID);
                db.AddInParameter(dbCommand, "@Location_id", DbType.String, objUserPass.Location_id);
                db.AddInParameter(dbCommand, "@Pass_No", DbType.String, objUserPass.Pass_No);
                db.AddInParameter(dbCommand, "@Date_From", DbType.DateTime, objUserPass.Date_From);
                db.AddInParameter(dbCommand, "@pass_Type", DbType.String, objUserPass.pass_Type);
                db.AddInParameter(dbCommand, "@Pass_Desciption", DbType.String, objUserPass.Pass_Desciption);
                db.AddInParameter(dbCommand, "@Pass_Status", DbType.String, objUserPass.Pass_Status);

                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    db.ExecuteNonQuery(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        public void AddUserVehicle(Vehicle objUserVehicle)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.SPNames.User_AddVehicle);

                db.AddInParameter(dbCommand, "@Vehicle_No", DbType.String, objUserVehicle.Vehicle_No);
                db.AddInParameter(dbCommand, "@Vehicle_Type", DbType.String, objUserVehicle.Vehicle_Type);
                db.AddInParameter(dbCommand, "@Vehicle_Remark", DbType.String, objUserVehicle.Vehicle_Remark);
                db.AddInParameter(dbCommand, "@Vehicle_Color", DbType.String, objUserVehicle.Vehicle_Color);
                db.AddInParameter(dbCommand, "@Vehicle_Model", DbType.String, objUserVehicle.Vehicle_Model);

                db.AddInParameter(dbCommand, "@Owned_By", DbType.String, objUserVehicle.Ownew_By);
                db.AddInParameter(dbCommand, "@Date_From", DbType.DateTime, objUserVehicle.Date_From);
                // db.AddInParameter(dbCommand, "@Date_to", DbType.DateTime, objUserVehicle.Date_to);



                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    db.ExecuteNonQuery(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        //public void AddItem(ItemData objItem)
        //{
        //    log4net.ILog logger = log4net.LogManager.GetLogger("File");
        //    try
        //    {
        //        Database db = DBConnectionHandler.GetDBConnection().DBConnection;
        //        DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.SPNames.AddnewItem);

        //        db.AddInParameter(dbCommand, "@Item_no", DbType.String, objItem.Item_no);
        //        db.AddInParameter(dbCommand, "@Item_Description", DbType.String, objItem.Item_Description);
        //        db.AddInParameter(dbCommand, "@Item_quantity", DbType.String, objItem.Item_quantity);

        //        db.AddInParameter(dbCommand, "@loged_Nric", DbType.String, objItem.loged_Nric);
        //        db.AddInParameter(dbCommand, "@loged_Name", DbType.String, objItem.loged_Name);
        //        db.AddInParameter(dbCommand, "@loged_CompName", DbType.String, objItem.loged_CompName);
        //        db.AddInParameter(dbCommand, "@loged_Time", DbType.DateTime, objItem.loged_Time);

        //        db.AddInParameter(dbCommand, "@Found_Nric", DbType.String, objItem.Found_Nric);
        //        db.AddInParameter(dbCommand, "@Status", DbType.String, objItem.Status);
        //        db.AddInParameter(dbCommand, "@Found_Time", DbType.DateTime, objItem.Found_Time);

        //        log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
        //        try
        //        {
        //            db.ExecuteNonQuery(dbCommand);
        //        }
        //        catch (Exception ex)
        //        {
        //            logger1.Info(ex.Message);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Info(ex.Message);
        //    }
        //}

        public void AddUserShift(Shift objUserShift)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.SPNames.User_AddShift);

                db.AddInParameter(dbCommand, "@Shift_ID", DbType.String, objUserShift.Shift_ID);
                db.AddInParameter(dbCommand, "@shiftdep", DbType.String, objUserShift.shiftdep);
                db.AddInParameter(dbCommand, "@ShiftDateFrom", DbType.DateTime, objUserShift.ShiftDateFrom);
                db.AddInParameter(dbCommand, "@ShiftDateTo", DbType.DateTime, objUserShift.ShiftDateTo);
                db.AddInParameter(dbCommand, "@ShiftTimeFrom", DbType.String, objUserShift.ShiftTimeFrom);
                db.AddInParameter(dbCommand, "@ShiftTimeTo", DbType.String, objUserShift.ShiftTimeTo);
                db.AddInParameter(dbCommand, "@Location", DbType.String, objUserShift.Location);

                db.AddInParameter(dbCommand, "@superid", DbType.String, objUserShift.superid);
                db.AddInParameter(dbCommand, "@supername", DbType.String, objUserShift.supername);
                db.AddInParameter(dbCommand, "@supercontno", DbType.String, objUserShift.supercontno);

                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    db.ExecuteNonQuery(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        public void AddAppointment(AppointmentSheduling objAppointment)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.SPNames.AppointmentAdd);

                db.AddInParameter(dbCommand, "@Date", DbType.DateTime, objAppointment.Date);
                db.AddInParameter(dbCommand, "@Timein", DbType.DateTime, objAppointment.Timein);
                db.AddInParameter(dbCommand, "@Timeout", DbType.DateTime, objAppointment.Timeout);
                db.AddInParameter(dbCommand, "@Department", DbType.String, objAppointment.Department);
                db.AddInParameter(dbCommand, "@Username", DbType.String, objAppointment.Username);
                db.AddInParameter(dbCommand, "@UserID", DbType.String, objAppointment.UserID);

                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    db.ExecuteNonQuery(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        public void Add_NewKey(AdminAddNewKey objAddNewKey)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {

                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.SPNames.AddNew_Key);

                db.AddInParameter(dbCommand, "@BunchNo", DbType.String, objAddNewKey.BunchNo);
                db.AddInParameter(dbCommand, "@Description", DbType.String, objAddNewKey.Description);
                db.AddInParameter(dbCommand, "@status", DbType.String, objAddNewKey.status);
                db.AddInParameter(dbCommand, "@name", DbType.String, objAddNewKey.name);
                db.AddInParameter(dbCommand, "@position", DbType.String, objAddNewKey.position);
                db.AddInParameter(dbCommand, "@NoOfKey", DbType.String, objAddNewKey.NoOfKey);
                db.AddInParameter(dbCommand, "@Location_ID", DbType.String, objAddNewKey.Location_ID);
                db.AddInParameter(dbCommand, "@Staff_ID", DbType.String, objAddNewKey.Staff_ID);

                db.AddInParameter(dbCommand, "@Date_From", DbType.Date, objAddNewKey.Date_From);


                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    db.ExecuteNonQuery(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        public void AddLocation(LocationData objlocation)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.SPNames.location);

                db.AddInParameter(dbCommand, "@Location_name", DbType.String, objlocation.Location_name);
                db.AddInParameter(dbCommand, "@code", DbType.String, objlocation.code);
                db.AddInParameter(dbCommand, "@Loc_Address", DbType.String, objlocation.Loc_Address);


                db.AddInParameter(dbCommand, "@F_cont", DbType.String, objlocation.F_cont);
                db.AddInParameter(dbCommand, "@F_Mob", DbType.String, objlocation.F_Mob);
                db.AddInParameter(dbCommand, "@F_Email", DbType.String, objlocation.F_Email);
                db.AddInParameter(dbCommand, "@F_Fax", DbType.String, objlocation.F_Fax);

                db.AddInParameter(dbCommand, "@O_cont", DbType.String, objlocation.O_cont);
                db.AddInParameter(dbCommand, "@O_Mob", DbType.String, objlocation.O_Mob);
                db.AddInParameter(dbCommand, "@O_Email", DbType.String, objlocation.O_Email);
                db.AddInParameter(dbCommand, "@O_Fax", DbType.String, objlocation.O_Fax);

                db.AddInParameter(dbCommand, "@M_cont", DbType.String, objlocation.M_cont);
                db.AddInParameter(dbCommand, "@M_Mob", DbType.String, objlocation.M_Mob);
                db.AddInParameter(dbCommand, "@M_Email", DbType.String, objlocation.M_Email);
                db.AddInParameter(dbCommand, "@M_Fax", DbType.String, objlocation.M_Fax);

                db.AddInParameter(dbCommand, "@Emergency_email", DbType.String, objlocation.Emergency_email);
                db.AddInParameter(dbCommand, "@Chift_Security_day", DbType.String, objlocation.Chift_Security_day);
                db.AddInParameter(dbCommand, "@Supervisor_day", DbType.String, objlocation.Supervisor_day);
                db.AddInParameter(dbCommand, "@Senior_Secu_Off_day", DbType.String, objlocation.Senior_Secu_Off_day);
                db.AddInParameter(dbCommand, "@Security_Off_day", DbType.String, objlocation.Security_Off_day);

                db.AddInParameter(dbCommand, "@Chift_Security_nig", DbType.String, objlocation.Chift_Security_nig);
                db.AddInParameter(dbCommand, "@Supervisor_nig", DbType.String, objlocation.Supervisor_nig);
                db.AddInParameter(dbCommand, "@Senior_Secu_Off_nig", DbType.String, objlocation.Senior_Secu_Off_nig);
                db.AddInParameter(dbCommand, "@Security_Off_nig", DbType.String, objlocation.Security_Off_nig);


                db.AddInParameter(dbCommand, "@Contract_value", DbType.String, objlocation.Contract_value);
                db.AddInParameter(dbCommand, "@Current_Status", DbType.String, objlocation.Current_Status);

                db.AddInParameter(dbCommand, "@Finance_Name", DbType.String, objlocation.Finance_Name);
                db.AddInParameter(dbCommand, "@Operation_Name", DbType.String, objlocation.Operation_Name);
                db.AddInParameter(dbCommand, "@Management_Name", DbType.String, objlocation.Management_Name);


                db.AddInParameter(dbCommand, "@Contract_start_date", DbType.DateTime, objlocation.Contract_start_date);
                db.AddInParameter(dbCommand, "@Contract_expire_date", DbType.DateTime, objlocation.Contract_expire_date);
                db.AddInParameter(dbCommand, "@Date_From", DbType.DateTime, objlocation.Date_From);

                db.AddInParameter(dbCommand, "@OtherPerson1", DbType.String, objlocation.OtherPerson1);
                db.AddInParameter(dbCommand, "@OtherPerson1_day", DbType.String, objlocation.OtherPerson1_day);
                db.AddInParameter(dbCommand, "@OtherPerson1_nig", DbType.String, objlocation.OtherPerson1_nig);

                db.AddInParameter(dbCommand, "@OtherPerson2", DbType.String, objlocation.OtherPerson2);
                db.AddInParameter(dbCommand, "@OtherPerson2_day", DbType.String, objlocation.OtherPerson2_day);
                db.AddInParameter(dbCommand, "@OtherPerson2_nig", DbType.String, objlocation.OtherPerson2_nig);

                db.AddInParameter(dbCommand, "@OtherPerson3", DbType.String, objlocation.OtherPerson3);
                db.AddInParameter(dbCommand, "@OtherPerson3_day", DbType.String, objlocation.OtherPerson3_day);
                db.AddInParameter(dbCommand, "@OtherPerson3_nig", DbType.String, objlocation.OtherPerson3_nig);

                db.AddInParameter(dbCommand, "@ClientUserID", DbType.String, objlocation.ClientUserID);
                db.AddInParameter(dbCommand, "@ClientPassword", DbType.String, objlocation.ClientPassword);
                


                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    db.ExecuteNonQuery(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        public void AddStaffShift(Staff_Shift objStaffShift)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.SPNames.AddStaffShift);
                db.AddInParameter(dbCommand, "@Shift_ID", DbType.String, objStaffShift.Shift_ID);
                db.AddInParameter(dbCommand, "@Staff_ID", DbType.String, objStaffShift.Staff_ID);

                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    db.ExecuteNonQuery(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        public void AddUserInfo(AddNewUserRequest objAddUserInfoRequest)
        {

            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.UserInfoConst.SPNames.ADD_USERINFO);

                db.AddInParameter(dbCommand, "@UserID", DbType.String, objAddUserInfoRequest.User_Info.UserID);
                db.AddInParameter(dbCommand, "@UserPassword", DbType.String, objAddUserInfoRequest.User_Info.UserPassword);
                db.AddInParameter(dbCommand, "@FirstName", DbType.String, objAddUserInfoRequest.User_Info.FirstName);
                db.AddInParameter(dbCommand, "@MiddleName", DbType.String, objAddUserInfoRequest.User_Info.MiddleName);
                db.AddInParameter(dbCommand, "@LastName", DbType.String, objAddUserInfoRequest.User_Info.LastName);
                db.AddInParameter(dbCommand, "@KinName", DbType.String, objAddUserInfoRequest.User_Info.KinName);

                db.AddInParameter(dbCommand, "@HomeAddress", DbType.String, objAddUserInfoRequest.User_Info.HomeAddress);
                db.AddInParameter(dbCommand, "@City", DbType.String, objAddUserInfoRequest.User_Info.City);
                db.AddInParameter(dbCommand, "@State", DbType.String, objAddUserInfoRequest.User_Info.State);

                db.AddInParameter(dbCommand, "@Country", DbType.String, objAddUserInfoRequest.User_Info.Country);
                db.AddInParameter(dbCommand, "@Mobile", DbType.String, objAddUserInfoRequest.User_Info.Mobile);
                db.AddInParameter(dbCommand, "@Phone", DbType.String, objAddUserInfoRequest.User_Info.Phone);
                db.AddInParameter(dbCommand, "@Fax", DbType.String, objAddUserInfoRequest.User_Info.Fax);
                db.AddInParameter(dbCommand, "@EMail", DbType.String, objAddUserInfoRequest.User_Info.EmailId);
                db.AddInParameter(dbCommand, "@PostalCode", DbType.String, objAddUserInfoRequest.User_Info.PostalCode);

                db.AddInParameter(dbCommand, "@KinContactNo", DbType.String, objAddUserInfoRequest.User_Info.KinContactNo);
                db.AddInParameter(dbCommand, "@NRICno", DbType.String, objAddUserInfoRequest.User_Info.NRICno);
                db.AddInParameter(dbCommand, "@DOB", DbType.String, objAddUserInfoRequest.User_Info.DOB);
                db.AddInParameter(dbCommand, "@Role", DbType.String, objAddUserInfoRequest.User_Info.Role);
                db.AddInParameter(dbCommand, "@Staff_ID", DbType.String, objAddUserInfoRequest.User_Info.Staff_ID);

                db.AddInParameter(dbCommand, "@SecQues", DbType.String, objAddUserInfoRequest.User_Info.UserSecretQues);
                db.AddInParameter(dbCommand, "@SecAns", DbType.String, objAddUserInfoRequest.User_Info.UserSecretAns);
                db.AddInParameter(dbCommand, "@Status", DbType.String, objAddUserInfoRequest.User_Info.UserStatus);
                db.AddInParameter(dbCommand, "@ImagePathName", DbType.String, objAddUserInfoRequest.User_Info.ImagePathName);
                db.AddInParameter(dbCommand, "@ManagementRole", DbType.String, objAddUserInfoRequest.User_Info.ManagementRole);

                db.AddInParameter(dbCommand, "@LastLoginTime", DbType.String, objAddUserInfoRequest.User_Info.LastLoginTime);
                db.AddInParameter(dbCommand, "@LastActivityTime", DbType.String, objAddUserInfoRequest.User_Info.LastActivityTime);


                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    db.ExecuteNonQuery(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        public void AddEvent(eventAdmin objeventman)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.SPNames.eventman);

                //db.AddInParameter(dbCommand, "@Event_ID", DbType.String, objeventman.Event_ID);
                db.AddInParameter(dbCommand, "@Date_From", DbType.DateTime, objeventman.Date_From);
                db.AddInParameter(dbCommand, "@Date_to", DbType.DateTime, objeventman.Date_to);

                db.AddInParameter(dbCommand, "@Location_id", DbType.String, objeventman.Location_id);
                db.AddInParameter(dbCommand, "@Event_Type", DbType.String, objeventman.Event_Type);
                db.AddInParameter(dbCommand, "@Start_time", DbType.String, objeventman.Start_time);
                db.AddInParameter(dbCommand, "@End_time", DbType.String, objeventman.End_time);

                db.AddInParameter(dbCommand, "@Special_Requirment", DbType.String, objeventman.Special_Requirment);
                db.AddInParameter(dbCommand, "@Guard_Requirment", DbType.String, objeventman.Guard_Requirment);
                db.AddInParameter(dbCommand, "@Special_Duty", DbType.String, objeventman.Special_Duty);
                db.AddInParameter(dbCommand, "@Incharg_Name", DbType.String, objeventman.Incharg_Name);
                db.AddInParameter(dbCommand, "@Incharg_NricNo", DbType.String, objeventman.Incharg_NricNo);
                db.AddInParameter(dbCommand, "@Incharg_position", DbType.String, objeventman.Incharg_position);
                db.AddInParameter(dbCommand, "@Incharg_ContactNo", DbType.String, objeventman.Incharg_ContactNo);
                db.AddInParameter(dbCommand, "@Superior_Name", DbType.String, objeventman.Superior_Name);

                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    db.ExecuteNonQuery(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        #endregion

        #region UpdateData

        //public void UpdateItemData(ItemData objBillingCode)
        //{
        //    log4net.ILog logger = log4net.LogManager.GetLogger("File");
        //    try
        //    {
        //        Database db = DBConnectionHandler.GetDBConnection().DBConnection;
        //        DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.ItemDataConst.SPNames.UPDATE_ItemData);


        //        db.AddInParameter(dbCommand, "@Item_no", DbType.String, objBillingCode.Item_no);
        //        db.AddInParameter(dbCommand, "@Item_Description", DbType.String, objBillingCode.Item_Description);
        //        db.AddInParameter(dbCommand, "@Item_quantity", DbType.String, objBillingCode.Item_quantity);
        //        db.AddInParameter(dbCommand, "@loged_Nric", DbType.String, objBillingCode.loged_Nric);
        //        db.AddInParameter(dbCommand, "@loged_Name", DbType.String, objBillingCode.loged_Name);
        //        db.AddInParameter(dbCommand, "@loged_CompName", DbType.String, objBillingCode.loged_CompName);
        //        db.AddInParameter(dbCommand, "@Signed_Nric", DbType.String, objBillingCode.Signed_Nric);
        //        db.AddInParameter(dbCommand, "@Signed_Name", DbType.String, objBillingCode.Signed_Name);
        //        db.AddInParameter(dbCommand, "@Signed_CompName", DbType.String, objBillingCode.Signed_CompName);
        //        db.AddInParameter(dbCommand, "@Remarks", DbType.String, objBillingCode.Remarks);

        //        db.AddInParameter(dbCommand, "@Found_Nric", DbType.String, objBillingCode.Found_Nric);
        //        db.AddInParameter(dbCommand, "@Status", DbType.String, objBillingCode.Status);
        //        db.AddInParameter(dbCommand, "@Foundremark", DbType.String, objBillingCode.Foundremark);

        //        db.AddInParameter(dbCommand, "@loged_Time", DbType.DateTime, objBillingCode.loged_Time);
        //        db.AddInParameter(dbCommand, "@Signed_Time", DbType.DateTime, objBillingCode.Signed_Time);
        //        //db.AddInParameter(dbCommand, "@Found_Time", DbType.String, objBillingCode.Found_Time);


        //        log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
        //        try
        //        {
        //            db.ExecuteNonQuery(dbCommand);
        //        }
        //        catch (Exception ex)
        //        {
        //            logger1.Info(ex.Message);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Info(ex.Message);
        //    }
        //}

        public void UpdateLocationData(LocationData objBillingCode)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.LocationDataConst.SPNames.UPDATE_LocationData);
                
                db.AddInParameter(dbCommand, "@Location_id", DbType.String, objBillingCode.Location_id);
                db.AddInParameter(dbCommand, "@Location_name", DbType.String, objBillingCode.Location_name);
                db.AddInParameter(dbCommand, "@Loc_Address", DbType.String, objBillingCode.Loc_Address);
               
                db.AddInParameter(dbCommand, "@F_cont", DbType.String, objBillingCode.F_cont);
                db.AddInParameter(dbCommand, "@F_Mob", DbType.String, objBillingCode.F_Mob);
                db.AddInParameter(dbCommand, "@F_Email", DbType.String, objBillingCode.F_Email);
                db.AddInParameter(dbCommand, "@F_Fax", DbType.String, objBillingCode.F_Fax);
                
                db.AddInParameter(dbCommand, "@O_cont", DbType.String, objBillingCode.O_cont);
                db.AddInParameter(dbCommand, "@O_Mob", DbType.String, objBillingCode.O_Mob);
                db.AddInParameter(dbCommand, "@O_Email", DbType.String, objBillingCode.O_Email);
                db.AddInParameter(dbCommand, "@O_Fax", DbType.String, objBillingCode.O_Fax);

                db.AddInParameter(dbCommand, "@M_cont", DbType.String, objBillingCode.M_cont);
                db.AddInParameter(dbCommand, "@M_Mob", DbType.String, objBillingCode.M_Mob);
                db.AddInParameter(dbCommand, "@M_Email", DbType.String, objBillingCode.M_Email);
                db.AddInParameter(dbCommand, "@M_Fax", DbType.String, objBillingCode.M_Fax);

                db.AddInParameter(dbCommand, "@Emergency_email", DbType.String, objBillingCode.Emergency_email);
                db.AddInParameter(dbCommand, "@Chift_Security_day", DbType.String, objBillingCode.Chift_Security_day);
                db.AddInParameter(dbCommand, "@Supervisor_day", DbType.String, objBillingCode.Supervisor_day);
                db.AddInParameter(dbCommand, "@Senior_Secu_Off_day", DbType.String, objBillingCode.Senior_Secu_Off_day);
                db.AddInParameter(dbCommand, "@Security_Off_day", DbType.String, objBillingCode.Security_Off_day);

                db.AddInParameter(dbCommand, "@Chift_Security_nig", DbType.String, objBillingCode.Chift_Security_nig);
                db.AddInParameter(dbCommand, "@Supervisor_nig", DbType.String, objBillingCode.Supervisor_nig);
                db.AddInParameter(dbCommand, "@Senior_Secu_Off_nig", DbType.String, objBillingCode.Senior_Secu_Off_nig);
                db.AddInParameter(dbCommand, "@Security_Off_nig", DbType.String, objBillingCode.Security_Off_nig);

                db.AddInParameter(dbCommand, "@Contract_value", DbType.String, objBillingCode.Contract_value);
                db.AddInParameter(dbCommand, "@Contract_start_date", DbType.DateTime, objBillingCode.Contract_start_date);
                db.AddInParameter(dbCommand, "@Contract_expire_date", DbType.DateTime, objBillingCode.Contract_expire_date);

                db.AddInParameter(dbCommand, "@Finance_Name", DbType.String, objBillingCode.Finance_Name);
                db.AddInParameter(dbCommand, "@Operation_Name", DbType.String, objBillingCode.Operation_Name);
                db.AddInParameter(dbCommand, "@Management_Name", DbType.String, objBillingCode.Management_Name);

                db.AddInParameter(dbCommand, "@OtherPerson1", DbType.String, objBillingCode.OtherPerson1);
                db.AddInParameter(dbCommand, "@OtherPerson1_day", DbType.String, objBillingCode.OtherPerson1_day);
                db.AddInParameter(dbCommand, "@OtherPerson1_nig", DbType.String, objBillingCode.OtherPerson1_nig);

                db.AddInParameter(dbCommand, "@OtherPerson2", DbType.String, objBillingCode.OtherPerson2);
                db.AddInParameter(dbCommand, "@OtherPerson2_day", DbType.String, objBillingCode.OtherPerson2_day);
                db.AddInParameter(dbCommand, "@OtherPerson2_nig", DbType.String, objBillingCode.OtherPerson2_nig);

                db.AddInParameter(dbCommand, "@OtherPerson3", DbType.String, objBillingCode.OtherPerson3);
                db.AddInParameter(dbCommand, "@OtherPerson3_day", DbType.String, objBillingCode.OtherPerson3_day);
                db.AddInParameter(dbCommand, "@OtherPerson3_nig", DbType.String, objBillingCode.OtherPerson3_nig);

                db.AddInParameter(dbCommand, "@ClientUserID", DbType.String, objBillingCode.ClientUserID);

                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    db.ExecuteNonQuery(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        public void UpdatePassData(Pass objBillingCode)
        {

            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.PassDataConst.SPNames.UPDATE_PassData);
                db.AddInParameter(dbCommand, "@Pass_id", DbType.String, objBillingCode.Pass_id);
                db.AddInParameter(dbCommand, "@Pass_No", DbType.String, objBillingCode.Pass_No);
                db.AddInParameter(dbCommand, "@pass_Type", DbType.String, objBillingCode.pass_Type);
                db.AddInParameter(dbCommand, "@Pass_Desciption", DbType.String, objBillingCode.Pass_Desciption);
                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    db.ExecuteNonQuery(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        public void AddUserSOP(SOP objUserSOP)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {

                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.SPNames.User_AddSOP);

                //db.AddInParameter(dbCommand, "@SOP_ID", DbType.String, objUserSOP.SOP_ID);
                db.AddInParameter(dbCommand, "@SOP_Title", DbType.String, objUserSOP.SOP_Title);
                db.AddInParameter(dbCommand, "@SOP_Subject", DbType.String, objUserSOP.SOP_Subject);
                db.AddInParameter(dbCommand, "@ImagePathName", DbType.String, objUserSOP.ImagePathName);
                db.AddInParameter(dbCommand, "@Date_From", DbType.String, objUserSOP.Date_From);
                db.AddInParameter(dbCommand, "@Created_By", DbType.String, objUserSOP.Created_By);

                db.AddInParameter(dbCommand, "@Location", DbType.String, objUserSOP.Location);

                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    db.ExecuteNonQuery(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }




        public void UpdateSOPData(SOP objBillingCode)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.SOPDataConst.SPNames.UPDATE_SOPData);

                db.AddInParameter(dbCommand, "@SOP_ID", DbType.String, objBillingCode.SOP_ID);
                db.AddInParameter(dbCommand, "@SOP_Title", DbType.String, objBillingCode.SOP_Title);
                db.AddInParameter(dbCommand, "@SOP_Subject", DbType.String, objBillingCode.SOP_Subject);
                db.AddInParameter(dbCommand, "@ImagePathName", DbType.String, objBillingCode.ImagePathName);
                db.AddInParameter(dbCommand, "@Location", DbType.String, objBillingCode.Location);

                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    db.ExecuteNonQuery(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        public void UpdateKeyData(AdminAddNewKey objBillingCode)
        {

            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.KeyDataConst.SPNames.UPDATE_KeyData);

                db.AddInParameter(dbCommand, "@Key_ID", DbType.String, objBillingCode.key_no);
                db.AddInParameter(dbCommand, "@Description", DbType.String, objBillingCode.Description);
                //db.AddInParameter(dbCommand, "@status", DbType.String, objBillingCode.status);
                db.AddInParameter(dbCommand, "@name", DbType.String, objBillingCode.name);
                db.AddInParameter(dbCommand, "@position", DbType.String, objBillingCode.position);
                db.AddInParameter(dbCommand, "@NoOfKey ", DbType.String, objBillingCode.count);
                db.AddInParameter(dbCommand, "@nricno", DbType.String, objBillingCode.nricno);


                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    db.ExecuteNonQuery(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        public void UpdateShiftData(Shift objShiftData)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.ShiftDataConst.SPNames.UPDATE_ShiftData);

                db.AddInParameter(dbCommand, "@Shift_ID", DbType.String, objShiftData.Shift_ID);
                db.AddInParameter(dbCommand, "@shiftdep", DbType.String, objShiftData.shiftdep);
                db.AddInParameter(dbCommand, "@ShiftDateFrom", DbType.DateTime, objShiftData.ShiftDateFrom);
                db.AddInParameter(dbCommand, "@ShiftDateTo", DbType.DateTime, objShiftData.ShiftDateTo);
                db.AddInParameter(dbCommand, "@ShiftTimeFrom", DbType.DateTime, objShiftData.ShiftTimeFrom);
                db.AddInParameter(dbCommand, "@ShiftTimeTo", DbType.DateTime, objShiftData.ShiftTimeTo);
                db.AddInParameter(dbCommand, "@Location", DbType.String, objShiftData.Location);

                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    db.ExecuteNonQuery(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        public void Updatevehicle(Vehicle objBillingCode)
        {

            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.VehicleConst.SPNames.UPDATE_Vehicle);


                db.AddInParameter(dbCommand, "@Vehicle_No", DbType.String, objBillingCode.Vehicle_No);
                db.AddInParameter(dbCommand, "@Vehicle_Type", DbType.String, objBillingCode.Vehicle_Type);
                db.AddInParameter(dbCommand, "@Vehicle_Remark", DbType.String, objBillingCode.Vehicle_Remark);
                db.AddInParameter(dbCommand, "@Vehicle_Color", DbType.String, objBillingCode.Vehicle_Color);
                db.AddInParameter(dbCommand, "@Vehicle_Model", DbType.String, objBillingCode.Vehicle_Model);

                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    db.ExecuteNonQuery(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        public void Updateuser(User_Info objBillingCode)
        {

            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;

                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.UserConst.SPNames.UPDATE_User);



                db.AddInParameter(dbCommand, "@UserID", DbType.String, objBillingCode.UserID);
                db.AddInParameter(dbCommand, "@UserPassword", DbType.String, objBillingCode.UserPassword);
                db.AddInParameter(dbCommand, "@FirstName", DbType.String, objBillingCode.FirstName);
                db.AddInParameter(dbCommand, "@MiddleName", DbType.String, objBillingCode.MiddleName);
                db.AddInParameter(dbCommand, "@LastName", DbType.String, objBillingCode.LastName);
                db.AddInParameter(dbCommand, "@KinName", DbType.String, objBillingCode.KinName);

                db.AddInParameter(dbCommand, "@HomeAddress", DbType.String, objBillingCode.HomeAddress);
                db.AddInParameter(dbCommand, "@City", DbType.String, objBillingCode.City);
                db.AddInParameter(dbCommand, "@State", DbType.String, objBillingCode.State);

                db.AddInParameter(dbCommand, "@Country", DbType.String, objBillingCode.Country);
                db.AddInParameter(dbCommand, "@Mobile", DbType.String, objBillingCode.Mobile);
                db.AddInParameter(dbCommand, "@Phone", DbType.String, objBillingCode.Phone);
                db.AddInParameter(dbCommand, "@Fax", DbType.String, objBillingCode.Fax);
                db.AddInParameter(dbCommand, "@EmailId", DbType.String, objBillingCode.EmailId);
                db.AddInParameter(dbCommand, "@PostalCode", DbType.String, objBillingCode.PostalCode);

                db.AddInParameter(dbCommand, "@KinContactNo", DbType.String, objBillingCode.KinContactNo);
                db.AddInParameter(dbCommand, "@NRICno", DbType.String, objBillingCode.NRICno);
                db.AddInParameter(dbCommand, "@DOB", DbType.String, objBillingCode.DOB);
                db.AddInParameter(dbCommand, "@Role", DbType.String, objBillingCode.Role);
                db.AddInParameter(dbCommand, "Staff_ID ", DbType.String, objBillingCode.Staff_ID);
                db.AddInParameter(dbCommand, "UserSecretQues", DbType.String, objBillingCode.UserSecretQues);

                db.AddInParameter(dbCommand, "@UserSecretAns", DbType.String, objBillingCode.UserSecretAns);
                db.AddInParameter(dbCommand, "@UserStatus", DbType.String, objBillingCode.UserStatus);
                db.AddInParameter(dbCommand, "@ImagePathName", DbType.String, objBillingCode.ImagePathName);
                db.AddInParameter(dbCommand, "@ManagementRole", DbType.String, objBillingCode.ManagementRole);

                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    db.ExecuteNonQuery(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        public void Updateevent(eventAdmin objBillingCode)
        {

            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.EventConst.SPNames.UPDATE_Event);


                db.AddInParameter(dbCommand, "@Event_ID", DbType.String, objBillingCode.Event_ID);
                db.AddInParameter(dbCommand, "@Date_From", DbType.String, objBillingCode.Date_From);
                db.AddInParameter(dbCommand, "@Date_to", DbType.String, objBillingCode.Date_to);

                db.AddInParameter(dbCommand, "@Location_id", DbType.String, objBillingCode.Location_id);
                db.AddInParameter(dbCommand, "@Event_Type", DbType.String, objBillingCode.Event_Type);
                db.AddInParameter(dbCommand, "@Start_time", DbType.String, objBillingCode.Start_time);
                db.AddInParameter(dbCommand, "@End_time", DbType.String, objBillingCode.End_time);

                // db.AddInParameter(dbCommand, "@Person_incharg", DbType.String, objBillingCode.Person_incharg);
                db.AddInParameter(dbCommand, "@Special_Requirment", DbType.String, objBillingCode.Special_Requirment);
                db.AddInParameter(dbCommand, "@Guard_Requirment", DbType.String, objBillingCode.Guard_Requirment);

                db.AddInParameter(dbCommand, "@Special_Duty", DbType.String, objBillingCode.Special_Duty);
                db.AddInParameter(dbCommand, "@Incharg_Name", DbType.String, objBillingCode.Incharg_Name);
                db.AddInParameter(dbCommand, "@Incharg_NricNo", DbType.String, objBillingCode.Incharg_NricNo);
                db.AddInParameter(dbCommand, "@Incharg_position", DbType.String, objBillingCode.Incharg_position);
                db.AddInParameter(dbCommand, "@Incharg_ContactNo", DbType.String, objBillingCode.Incharg_ContactNo);
                db.AddInParameter(dbCommand, "@Superior_Name", DbType.String, objBillingCode.Superior_Name);



                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    db.ExecuteNonQuery(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        public void Updatincident(UserIncident objBillingCode)
        {

            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.IncidentConst.SPNames.UPDATE_Incident);
                db.AddInParameter(dbCommand, "@Report_No", DbType.String, objBillingCode.Report_No);
                db.AddInParameter(dbCommand, "@Incident_id", DbType.String, objBillingCode.Incident_id);
                db.AddInParameter(dbCommand, "@followinvesti", DbType.String, objBillingCode.followinvesti);
                db.AddInParameter(dbCommand, "@Verified_By", DbType.String, objBillingCode.Verified_By);
                db.AddInParameter(dbCommand, "@followstatus", DbType.String, objBillingCode.followstatus);
                db.AddInParameter(dbCommand, "@Date_of_Incident", DbType.String, objBillingCode.Date_of_Incident);
                db.AddInParameter(dbCommand, "@Assignment", DbType.String, objBillingCode.followsremark);
                db.AddInParameter(dbCommand, "@ReportDetail", DbType.Date, objBillingCode.ReportDetail);
                db.AddInParameter(dbCommand, "@Time_of_Incident", DbType.String, objBillingCode.Time_of_Incident);
                db.AddInParameter(dbCommand, "@Place_of_Incident", DbType.Date, objBillingCode.Place_of_Incident);


                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    db.ExecuteNonQuery(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        public void Updatecontractor(Contractor objBillingCode)
        {

            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.Contractor.SPNames.UPDATE_Contractor);


                db.AddInParameter(dbCommand, "@checkout_id", DbType.String, objBillingCode.checkout_id);
                db.AddInParameter(dbCommand, "@user_id", DbType.String, objBillingCode.user_id);
                db.AddInParameter(dbCommand, "@user_name", DbType.String, objBillingCode.user_name);
                db.AddInParameter(dbCommand, "@user_address", DbType.String, objBillingCode.user_address);
                db.AddInParameter(dbCommand, "@company_from", DbType.String, objBillingCode.company_from);
                db.AddInParameter(dbCommand, "@to_visit", DbType.String, objBillingCode.to_visit);


                db.AddInParameter(dbCommand, "@Item_Declear", DbType.String, objBillingCode.Item_Declear);
                db.AddInParameter(dbCommand, "@telephone", DbType.String, objBillingCode.telephone);
                db.AddInParameter(dbCommand, "@remarks", DbType.String, objBillingCode.remarks);
                db.AddInParameter(dbCommand, "@vehicle_no", DbType.String, objBillingCode.vehicle_no);
                db.AddInParameter(dbCommand, "@key_no", DbType.String, objBillingCode.key_no);
                db.AddInParameter(dbCommand, "@pass_no", DbType.String, objBillingCode.pass_no);
                db.AddInParameter(dbCommand, "@PassType", DbType.String, objBillingCode.PassType);
                db.AddInParameter(dbCommand, "@purpose", DbType.String, objBillingCode.purpose);
                db.AddInParameter(dbCommand, "@user_image", DbType.String, objBillingCode.user_image);

                db.AddInParameter(dbCommand, "@checkin_time", DbType.Date, objBillingCode.checkin_time);
                db.AddInParameter(dbCommand, "@checkout_time", DbType.Date, objBillingCode.checkout_time);





                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    db.ExecuteNonQuery(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        public void Updatevisitor(Visitor objBillingCode)
        {

            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.Visitor.SPNames.UPDATE_Visitor);


                db.AddInParameter(dbCommand, "@checkout_id", DbType.String, objBillingCode.checkout_id);
                db.AddInParameter(dbCommand, "@user_id", DbType.String, objBillingCode.user_id);
                db.AddInParameter(dbCommand, "@user_name", DbType.String, objBillingCode.user_name);
                db.AddInParameter(dbCommand, "@user_address", DbType.String, objBillingCode.user_address);
                db.AddInParameter(dbCommand, "@company_from", DbType.String, objBillingCode.company_from);
                db.AddInParameter(dbCommand, "@to_visit", DbType.String, objBillingCode.to_visit);


                db.AddInParameter(dbCommand, "@Item_Declear", DbType.String, objBillingCode.Item_Declear);
                db.AddInParameter(dbCommand, "@telephone", DbType.String, objBillingCode.telephone);
                db.AddInParameter(dbCommand, "@remarks", DbType.String, objBillingCode.remarks);
                db.AddInParameter(dbCommand, "@vehicle_no", DbType.String, objBillingCode.vehicle_no);
                db.AddInParameter(dbCommand, "@key_no", DbType.String, objBillingCode.key_no);
                db.AddInParameter(dbCommand, "@pass_no", DbType.String, objBillingCode.pass_no);
                db.AddInParameter(dbCommand, "@PassType", DbType.String, objBillingCode.PassType);
                db.AddInParameter(dbCommand, "@purpose", DbType.String, objBillingCode.purpose);
                db.AddInParameter(dbCommand, "@user_image", DbType.String, objBillingCode.user_image);

                db.AddInParameter(dbCommand, "@checkin_time", DbType.Date, objBillingCode.checkin_time);
                db.AddInParameter(dbCommand, "@checkout_time", DbType.Date, objBillingCode.checkout_time);
                //db.AddInParameter(dbCommand, "@Role", DbType.String, objBillingCode.Role);


                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    db.ExecuteNonQuery(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        public void UpdateAttendance(Contractor objBillingCode)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.Attendance.SPNames.UPDATE_Attendance);


                db.AddInParameter(dbCommand, "@checkout_id", DbType.String, objBillingCode.checkout_id);
                db.AddInParameter(dbCommand, "@user_id", DbType.String, objBillingCode.user_id);
                db.AddInParameter(dbCommand, "@user_name", DbType.String, objBillingCode.user_name);

                db.AddInParameter(dbCommand, "@key_no", DbType.String, objBillingCode.key_no);
                db.AddInParameter(dbCommand, "@pass_no", DbType.String, objBillingCode.pass_no);
                db.AddInParameter(dbCommand, "@PassType", DbType.String, objBillingCode.PassType);

                db.AddInParameter(dbCommand, "@checkin_time", DbType.Date, objBillingCode.checkin_time);
                db.AddInParameter(dbCommand, "@checkout_time", DbType.Date, objBillingCode.checkout_time);


                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    db.ExecuteNonQuery(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        #endregion

        #region GetData


        #region Needs to Be Tested 20 Jun 2014
        public static DataTable Checkmenu(string userroles, string menuID)
        {
            string userrole = userroles;
            DBConnectionHandler1 d = new DBConnectionHandler1();
            SqlConnection cn = d.getconnection();
            cn.Open();
            string Query = "";
            if (userrole == "1")
            {
                Query = "select MenuId from MenuMasterMap";
            }
            else
            {
                Query = "select MenuId from RoleMenuMap where RoleId='" + userrole + "' and MenuId='" + menuID + "' ";
            }
            SqlCommand cmd = new SqlCommand(Query, cn);


            DataTable dt = new DataTable();
            SqlDataAdapter ds = new SqlDataAdapter();
            ds.SelectCommand = cmd;
            ds.Fill(dt);
            cn.Close();
            return dt;
        }
        #endregion
        

        public string GetAuthenticateUserRole(GetAuthRequest argObj)
        {
            string lstInstitution = string.Empty;

            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetSqlStringCommand("Select top 1 Role from UserInformation with(nolock) where userID='" + argObj.UserInfo.UserID + "'");

                IDataReader dataReader = db.ExecuteReader(dbCommand);
                while (dataReader.Read())
                {
                    lstInstitution = dataReader["Role"].ToString();
                    break;
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
            return lstInstitution;
        }

        public string GetAuthenticateUserRoleAndID(GetAuthRequest argObj)
        {
            string lstInstitution = string.Empty;

            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetSqlStringCommand("Select top 1 Role,Staff_ID from UserInformation with(nolock) where userID='" + argObj.UserInfo.UserID + "'");

                IDataReader dataReader = db.ExecuteReader(dbCommand);
                while (dataReader.Read())
                {
                    lstInstitution = dataReader["Role"].ToString() + "||" + dataReader["Staff_ID"].ToString();
                    break;
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
            return lstInstitution;
        }

        public List<GetAuthResponse> AuthenticateUser(GetAuthRequest argObj)
        {
            List<GetAuthResponse> lstInstitution = null;

            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.SPNames.AUTHENTICATE_USER);
                db.AddInParameter(dbCommand, "@UserID", DbType.String, argObj.UserInfo.UserID);
                db.AddInParameter(dbCommand, "@Password", DbType.String, argObj.UserInfo.UserPassword);
                IDataReader dataReader = db.ExecuteReader(dbCommand);
                lstInstitution = DALUtilities.CBO.FillCollection<GetAuthResponse>(dataReader);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
            return lstInstitution;
        }
        public List<PassNo> GetPassDataDAL(GetPassDataNo argObj)
        {
            List<PassNo> lstPassno = null;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetSqlStringCommand("select Pass_No from  Pass_Master with(nolock)");
                IDataReader dataReader = null;

                dataReader = db.ExecuteReader(dbCommand);
                lstPassno = CBO.FillCollection<PassNo>(dataReader);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
            return lstPassno;
        }
        public List<Pass> GetPassData(GetPassData argObj)
        {
            List<Pass> lstPassno = null;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;

                DbCommand dbCommand = db.GetSqlStringCommand("select Pass_id,Pass_No,Pass_Status,Staff_ID,location.Location_name as Location_ID from Pass_Master,location where location.Location_id=Pass_Master.Location_id" + argObj.WhereClause + " order by Pass_Master.Date_From desc");
                IDataReader dataReader = null;

                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    dataReader = db.ExecuteReader(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
                lstPassno = CBO.FillCollection<Pass>(dataReader);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
            return lstPassno;
        }
        public List<Pass> GetPassData2(GetPassData argObj)
        {
            List<Pass> lstPassno = null;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;

                DbCommand dbCommand = db.GetSqlStringCommand("select Pass_id,Pass_No,pass_Type,Pass_Desciption from  Pass_Master with(nolock)" + argObj.WhereClause + "order by Date_From desc");
                IDataReader dataReader = null;

                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    dataReader = db.ExecuteReader(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
                lstPassno = CBO.FillCollection<Pass>(dataReader);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
            return lstPassno;
        }
        public List<SOP> GetSOPData(GetSOPData argObj)
        {
            List<SOP> lstSOPno = null;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetSqlStringCommand("select * from SOP_Master with(nolock)" + argObj.WhereClause);
                IDataReader dataReader = null;

                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    dataReader = db.ExecuteReader(dbCommand);
                }

                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
                lstSOPno = CBO.FillCollection<SOP>(dataReader);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
            return lstSOPno;
        }
        public List<SOP> GetAllSOPData(GetSOPData argObj)
        {
            List<SOP> lstSOPno = null;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetSqlStringCommand("select * from SOP_Master with(nolock)");
                IDataReader dataReader = null;

                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    dataReader = db.ExecuteReader(dbCommand);
                }

                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
                lstSOPno = CBO.FillCollection<SOP>(dataReader);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
            return lstSOPno;
        }


        public List<LocationData> GetLocationData(GetLocationData argObj)
        {
            List<LocationData> lstlocid = null;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetSqlStringCommand("select * from location with(nolock)" + argObj.WhereClause);
                IDataReader dataReader = null;

                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    dataReader = db.ExecuteReader(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
                lstlocid = CBO.FillCollection<LocationData>(dataReader);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

            return lstlocid;
        }

        public List<checkin> Getcheckin(GetCheckinData argObj)
        {
            List<checkin> lstlocid = null;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetSqlStringCommand("select Top 8 * from checkin_manager with(nolock)" + argObj.WhereClause + " order by Checkin_DateTime desc");
                IDataReader dataReader = null;

                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    dataReader = db.ExecuteReader(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
                lstlocid = CBO.FillCollection<checkin>(dataReader);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

            return lstlocid;
        }

        public List<eventAdmin> GetEventData(GetDataEvent argObj)
        {
            List<eventAdmin> lsteventno = null;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetSqlStringCommand("select * from event with(nolock)" + argObj.WhereClause + " order by Date_From desc");
                IDataReader dataReader = null;
                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    dataReader = db.ExecuteReader(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
                lsteventno = CBO.FillCollection<eventAdmin>(dataReader);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

            return lsteventno;
        }

        public List<Shift> GetShift(GetShiftData argObj)
        {
            List<Shift> lsteventno = null;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetSqlStringCommand("select * from Shift_Master with(nolock)" + argObj.WhereClause);
                IDataReader dataReader = null;
                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    dataReader = db.ExecuteReader(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
                lsteventno = CBO.FillCollection<Shift>(dataReader);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

            return lsteventno;
        }

        public List<AdminAddNewKey> GetNewKey(GetNewKey argObj)
        {
            List<AdminAddNewKey> lstKeyno = null;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetSqlStringCommand("select Key_ID,Description,BunchNo,Staff_ID,NoOfKey,position,status,name,location.Location_name as Location_ID from addnewkey,location where location.Location_id=addnewkey.Location_ID" + argObj.WhereClause + " order by addnewkey.Date_From desc");
                IDataReader dataReader = null;
                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    dataReader = db.ExecuteReader(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
                lstKeyno = CBO.FillCollection<AdminAddNewKey>(dataReader);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

            return lstKeyno;
        }


        public List<User_Info> GetStaffShiftKey(GetStaffShift argObj)
        {
            List<User_Info> lstKeyno = null;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetSqlStringCommand("select staff_ID,FirstName from userinformation with(nolock) where staff_Id in (select staff_ID from shift_staff with(nolock) where Shift_ID='" + argObj.ShiftID + "')");
                IDataReader dataReader = null;
                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    dataReader = db.ExecuteReader(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
                lstKeyno = CBO.FillCollection<User_Info>(dataReader);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

            return lstKeyno;
        }

        public List<AlertHandlingUser> GetAlertData(GetAlertData argObj)
        {
            List<AlertHandlingUser> lstAlerttype = null;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetSqlStringCommand("select * from Alert_Handling with(nolock)" + argObj.WhereClause + " order by Date_From desc ");
                IDataReader dataReader = null;
                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    dataReader = db.ExecuteReader(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
                lstAlerttype = CBO.FillCollection<AlertHandlingUser>(dataReader);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
            return lstAlerttype;
        }

        public List<UserIncident> GetIncidentData(GetIncidentData argObj)
        {
            List<UserIncident> lstDateofincident = null;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetSqlStringCommand("select * from Incident_Master with(nolock) where AlertStatus!='Over'" + argObj.WhereClause + "   order by Date_of_Incident desc");
                IDataReader dataReader = null;
                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    dataReader = db.ExecuteReader(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
                lstDateofincident = CBO.FillCollection<UserIncident>(dataReader);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

            return lstDateofincident;
        }

        public List<ItemData> GetItemData(GetItemData argObj)
        {
            List<ItemData> lstItemno = null;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetSqlStringCommand("select * from AddNewItem with(nolock)" + argObj.WhereClause + " ");
                IDataReader dataReader = null;
                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    dataReader = db.ExecuteReader(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }

                lstItemno = CBO.FillCollection<ItemData>(dataReader);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

            return lstItemno;
        }
        public List<LostFoundItem> GetLostFoundData(GetLostFoundData argObj)
        {
            List<LostFoundItem> lstLostId = null;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetSqlStringCommand("select Lost_ID,Name,NRICno,Location,ContNo,convert(varchar(20),Date,101) as Date,Time,convert(varchar(20),Description,101) as Description,Action,NameOfReporting,AckClaimant,AckNRICno,AckTelephone,AckAddress,LostStatus from LostFoundItem with(nolock)" + argObj.WhereClause + " ");
                IDataReader dataReader = null;
                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    dataReader = db.ExecuteReader(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }

                lstLostId = CBO.FillCollection<LostFoundItem>(dataReader);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

            return lstLostId;
        }

        public List<Contractor> GetStaffData(GetContractorData argObj)
        {
            List<Contractor> lstContractorNo = null;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetSqlStringCommand("select * from checkout_manager with(nolock) where Role='Staff'" + argObj.WhereClause);
                IDataReader dataReader = null;
                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    dataReader = db.ExecuteReader(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
                lstContractorNo = CBO.FillCollection<Contractor>(dataReader);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

            return lstContractorNo;
        }

        public List<Contractor> GetStaffData1(GetContractorData argObj)
        {
            List<Contractor> lstContractorNo = null;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetSqlStringCommand("select * from checkout_manager with(nolock)" + argObj.WhereClause);
                IDataReader dataReader = null;
                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    dataReader = db.ExecuteReader(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
                lstContractorNo = CBO.FillCollection<Contractor>(dataReader);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

            return lstContractorNo;
        }
        public List<Contractor> GetGuardData(GetContractorData argObj)
        {
            List<Contractor> lstContractorNo = null;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetSqlStringCommand("select * from checkout_manager with(nolock) where Role='Guard'" + argObj.WhereClause);
                IDataReader dataReader = null;
                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    dataReader = db.ExecuteReader(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
                lstContractorNo = CBO.FillCollection<Contractor>(dataReader);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

            return lstContractorNo;
        }



        public List<Contractor> GetContractorDataForCurrentTime(GetContractorData argObj)
        {
            List<Contractor> lstContractorNo = null;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetSqlStringCommand("select checkin_id as checkout_id,Checkin_DateTime As Checkin_time,user_name,NRICno,Pass_No,telephone,company_from,to_visit from checkin_manager with(nolock)" + argObj.WhereClause + "order by checkin_DateTime Desc");
                IDataReader dataReader = null;
                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    dataReader = db.ExecuteReader(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
                lstContractorNo = CBO.FillCollection<Contractor>(dataReader);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

            return lstContractorNo;
        }

        public DataTable GetCheckInData(GetContractorData objReq)
        {
            DataTable dt = null;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;

                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    DataAccessLayer dal = new DataAccessLayer();
                    // dt = dal.getdata("select * from checkin_manager with(nolock)" + objReq.WhereClause + " order by checkin_datetime desc");
                    dt = dal.getdata("select * from checkin_manager inner join location  on checkin_manager.locationID=location.Location_id" + objReq.WhereClause + " order by checkin_datetime desc");
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
            return dt;
        }

        public DataTable GetContractorData(GetContractorData argObj)
        {
            DataTable dt = null;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;

                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    DataAccessLayer dal = new DataAccessLayer();
                    // dt = dal.getdata("select * from checkin_manager with(nolock)" + objReq.WhereClause + " order by checkin_datetime desc");
                    dt = dal.getdata("select location.Location_name as ln,* from checkout_manager inner join location  on checkout_manager.locationID=location.Location_id" + argObj.WhereClause + " order by checkin_time Desc");
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
            return dt;
        }

        //public List<Contractor> GetContractorData(GetContractorData argObj)
        //{
        //    List<Contractor> lstContractorNo = null;
        //    log4net.ILog logger = log4net.LogManager.GetLogger("File");
        //    try
        //    {
        //        Database db = DBConnectionHandler.GetDBConnection().DBConnection;
        //        //DbCommand dbCommand = db.GetSqlStringCommand("select * from checkout_manager  with(nolock)" + argObj.WhereClause + " order by checkin_time Desc");
        //        DbCommand dbCommand = db.GetSqlStringCommand("select location.Location_name as ln* from checkout_manager inner join location  on checkout_manager.locationID=location.Location_id" + argObj.WhereClause + " order by checkin_time Desc");
        //        IDataReader dataReader = null;
        //        log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
        //        try
        //        {
        //            dataReader = db.ExecuteReader(dbCommand);
        //        }
        //        catch (Exception ex)
        //        {
        //            logger1.Info(ex.Message);
        //        }
        //        lstContractorNo = CBO.FillCollection<Contractor>(dataReader);
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Info(ex.Message);
        //    }
        //    return lstContractorNo;
        //}

        public List<Contractor> GetContractorData1(GetContractorData argObj)
        {
            List<Contractor> lstContractorNo = null;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetSqlStringCommand("select Top 7 * from checkout_manager with(nolock)" + argObj.WhereClause + " order by checkin_time desc");
                IDataReader dataReader = null;
                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    dataReader = db.ExecuteReader(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
                lstContractorNo = CBO.FillCollection<Contractor>(dataReader);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

            return lstContractorNo;
        }

        public List<Contractor> GetContractorData2(GetContractorData argObj)
        {
            List<Contractor> lstContractorNo = null;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetSqlStringCommand("select Top 10 * from checkout_manager with(nolock) where Role='Contractor'" + argObj.WhereClause + " order by checkin_time Desc ");
                IDataReader dataReader = null;
                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    dataReader = db.ExecuteReader(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
                lstContractorNo = CBO.FillCollection<Contractor>(dataReader);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

            return lstContractorNo;
        }

        public List<Visitor> GetVisitorData(GetVisitorData argObj)
        {
            List<Visitor> lstVisitorNo = null;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetSqlStringCommand("select * from checkout_manager with(nolock) where Role='Visitor'" + argObj.WhereClause);
                IDataReader dataReader = null;
                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    dataReader = db.ExecuteReader(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
                lstVisitorNo = CBO.FillCollection<Visitor>(dataReader);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

            return lstVisitorNo;
        }

        public List<Visitor> GetVisitorDataCurrentReport(GetVisitorData argObj)
        {
            List<Visitor> lstVisitorNo = null;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetSqlStringCommand("select checkin_id as checkout_id,Checkin_DateTime As Checkin_time,user_name,NRICno,Pass_No,telephone,company_from,to_visit from checkin_manager with(nolock)" + argObj.WhereClause + "order by checkin_DateTime Desc");
                IDataReader dataReader = null;
                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    dataReader = db.ExecuteReader(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
                lstVisitorNo = CBO.FillCollection<Visitor>(dataReader);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

            return lstVisitorNo;
        }
        public List<Visitor> GetVisitorData1(GetVisitorData argObj)
        {
            List<Visitor> lstVisitorNo = null;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetSqlStringCommand("select * from checkout_manager with(nolock)" + argObj.WhereClause + "order by checkout_time Desc");
                IDataReader dataReader = null;
                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    dataReader = db.ExecuteReader(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
                lstVisitorNo = CBO.FillCollection<Visitor>(dataReader);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

            return lstVisitorNo;
        }

        public List<User_Info> GetUserInfoData(GetUserData argObj)
        {
            List<User_Info> lstUserID = null;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetSqlStringCommand("select * from UserInformation with(nolock)" + argObj.WhereClause + "order by LastLoginTime desc");
                IDataReader dataReader = null;
                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    dataReader = db.ExecuteReader(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
                lstUserID = CBO.FillCollection<User_Info>(dataReader);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

            return lstUserID;
        }

        public List<Vehicle> GetVehicleData(GetVehicleData argObj)
        {
            List<Vehicle> lstvehicleNo = null;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetSqlStringCommand("select * from Vehicle_Master with(nolock)" + argObj.WhereClause + "order by Date_From desc");
                IDataReader dataReader = null;
                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    dataReader = db.ExecuteReader(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
                lstvehicleNo = CBO.FillCollection<Vehicle>(dataReader);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

            return lstvehicleNo;
        }

        #endregion

        #region DeleteData

        public void DeleteKeyData(AdminAddNewKey objBillingCode)
        {

            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.Key1DataConst.SPNames.DELETE_KeyData);

                db.AddInParameter(dbCommand, "@key_no", DbType.String, objBillingCode.key_no);


                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    db.ExecuteNonQuery(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        public void DeleteItem(DeleteItemRequest argObj)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.SPNames.DELETE_EMBOSSING);

                db.AddInParameter(dbCommand, "@ItemNo", DbType.String, argObj.ItemNo);

                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        public void DeleteLocationUser(DeleteLocationRequest argObj)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.SPNames.DELETE_Location);

                db.AddInParameter(dbCommand, "@loc_ID", DbType.String, argObj.locid);

                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        public void DeletePassUser(DeletePassRequest argObj)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.SPNames.DELETE_Pass);

                db.AddInParameter(dbCommand, "@Pass_id", DbType.String, argObj.Pass_Id);

                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        public void DeleteKeyUser(DeleteKeyRequest argObj)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.SPNames.DELETE_Key);

                db.AddInParameter(dbCommand, "@Key_ID", DbType.String, argObj.KeyNo);

                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        public void DeleteSOPUser(DeleteSOPRequest argObj)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.SPNames.DELETE_SOP);

                db.AddInParameter(dbCommand, "@SOP_ID", DbType.String, argObj.SOP_ID);

                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        public void DeleteShiftUser(DeleteShiftRequest argObj)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.SPNames.DELETE_Shift);

                db.AddInParameter(dbCommand, "@ShiftID", DbType.String, argObj.ShiftNo);

                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        public void DeleteShiftStaff(GetStaffShift argObj)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.SPNames.DELETE_ShiftStaff);

                db.AddInParameter(dbCommand, "@StaffID", DbType.String, argObj.StaffID);

                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        public void DeleteEventUser(DeleteEventPlannerRequest argObj)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.SPNames.DELETE_Event);

                db.AddInParameter(dbCommand, "@EventID", DbType.String, argObj.EventID);

                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        public void DeleteContractorUser(DeleteContractorRequest argObj)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.SPNames.DELETE_Contractor);

                db.AddInParameter(dbCommand, "@checkout_id", DbType.String, argObj.ContratorNo);

                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        public void DeleteUser(DeleteUserRequest argObj)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.SPNames.DELETE_User);



                db.AddInParameter(dbCommand, "@User_ID", DbType.String, argObj.UserNo);


                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        public void DeleteVehicle(DeleteVehicleRequest argObj)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.SPNames.DELETE_Vehicle);

                db.AddInParameter(dbCommand, "@VehicleNo", DbType.String, argObj.VehicleNo);

                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        public void DeleteIncident(DeleteIncidentRequest argObj)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.SPNames.DELETE_Incident);

                db.AddInParameter(dbCommand, "@Incident_id", DbType.String, argObj.IncidentNo);
                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }



        #endregion

        public void DeleteUserStaff(DeleteUserRequest argObj)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.SPNames.DELETE_USER_STAFF);

                db.AddInParameter(dbCommand, "@Staff_ID", DbType.String, argObj.UserNo);
                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        public void DeleteInventoryUser(DeleteInventoryRequest argObj)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.SPNames.DELETE_Inventory);

                db.AddInParameter(dbCommand, "@Item_id", DbType.String, argObj.InventoryItemId);
                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        public List<AddNewInventory> GetIenvenData(GetInventoryData argObj)
        {
            List<AddNewInventory> lstItemid = null;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetSqlStringCommand("select * from AddNewInvetory with(nolock)" + argObj.WhereClause);
                IDataReader dataReader = null;

                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    dataReader = db.ExecuteReader(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
                lstItemid = CBO.FillCollection<AddNewInventory>(dataReader);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

            return lstItemid;
        }

        public void UpdateInventoryData(AddNewInventory objinventory)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.Invetory.SPNames.UPDATE_Inventory);

                db.AddInParameter(dbCommand, "@Item_id", DbType.String, objinventory.Item_id);
                db.AddInParameter(dbCommand, "@Item_Type", DbType.String, objinventory.Item_Type);
                db.AddInParameter(dbCommand, "@Item_Name", DbType.String, objinventory.Item_Name);
                db.AddInParameter(dbCommand, "@Item_qty", DbType.String, objinventory.Item_qty);
                db.AddInParameter(dbCommand, "@CreatedBy", DbType.String, objinventory.CreatedBy);

                db.AddInParameter(dbCommand, "@CreatedTime", DbType.DateTime, objinventory.CreatedTime);
                db.AddInParameter(dbCommand, "@EditBy", DbType.String, objinventory.EditBy);
                db.AddInParameter(dbCommand, "@EditTime", DbType.DateTime, objinventory.EditTime);

                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    db.ExecuteNonQuery(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        public void Add_NewInventory(AddNewInventory objAddNewInventoryRequest)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.SPNames.AddInventory);

                db.AddInParameter(dbCommand, "@Item_Type", DbType.String, objAddNewInventoryRequest.Item_Type);
                db.AddInParameter(dbCommand, "@Item_Name", DbType.String, objAddNewInventoryRequest.Item_Name);
                db.AddInParameter(dbCommand, "@Item_qty", DbType.String, objAddNewInventoryRequest.Item_qty);
                db.AddInParameter(dbCommand, "@CreatedBy", DbType.String, objAddNewInventoryRequest.CreatedBy);
                db.AddInParameter(dbCommand, "@CreatedTime", DbType.DateTime, objAddNewInventoryRequest.CreatedTime);
                db.AddInParameter(dbCommand, "@SerialNo", DbType.String, objAddNewInventoryRequest.SerialNo);
                db.AddInParameter(dbCommand, "@ModelNo", DbType.String, objAddNewInventoryRequest.ModelNo);

                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    db.ExecuteNonQuery(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        public void DeleteTrainingUser(DeleteTrainingRequest argObj)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.SPNames.DELETE_Training);

                db.AddInParameter(dbCommand, "@training_id", DbType.String, argObj.TrainingId);

                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        public List<AddTraining> GetTrainingData(GetTrainingData argObj)
        {
            List<AddTraining> lsttrainingid = null;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetSqlStringCommand("select * from TrainingMgt with(nolock)" + argObj.WhereClause);
                IDataReader dataReader = null;

                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    dataReader = db.ExecuteReader(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
                lsttrainingid = CBO.FillCollection<AddTraining>(dataReader);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

            return lsttrainingid;
        }

        public void UpdateTrainingData(AddTraining objTraining)
        {

            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.Taining.SPNames.UPDATE_Training);

                db.AddInParameter(dbCommand, "@training_id", DbType.String, objTraining.training_id);
                db.AddInParameter(dbCommand, "@training_type", DbType.String, objTraining.training_type);
                db.AddInParameter(dbCommand, "@T_startdate", DbType.DateTime, objTraining.T_startdate);
                db.AddInParameter(dbCommand, "@T_enddate", DbType.DateTime, objTraining.T_enddate);
                db.AddInParameter(dbCommand, "@Venue", DbType.String, objTraining.Venue);

                db.AddInParameter(dbCommand, "@Facilitation", DbType.String, objTraining.Facilitation);
                db.AddInParameter(dbCommand, "@Trainee", DbType.String, objTraining.Trainee);
                db.AddInParameter(dbCommand, "@TraineeDetail", DbType.String, objTraining.TraineeDetail);


                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    db.ExecuteNonQuery(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        public void Add_NewTraining(AddTraining objAddNewTrainingRequest)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.SPNames.AddTraining);

                db.AddInParameter(dbCommand, "@training_type", DbType.String, objAddNewTrainingRequest.training_type);
                db.AddInParameter(dbCommand, "@T_startdate", DbType.DateTime, objAddNewTrainingRequest.T_startdate);
                db.AddInParameter(dbCommand, "@T_enddate", DbType.DateTime, objAddNewTrainingRequest.T_enddate);
                db.AddInParameter(dbCommand, "@Venue", DbType.String, objAddNewTrainingRequest.Venue);
                db.AddInParameter(dbCommand, "@Trainee", DbType.String, objAddNewTrainingRequest.Trainee);
                db.AddInParameter(dbCommand, "@Facilitation", DbType.String, objAddNewTrainingRequest.Facilitation);
                db.AddInParameter(dbCommand, "@TraineeDetail", DbType.String, objAddNewTrainingRequest.TraineeDetail);


                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    db.ExecuteNonQuery(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        public void AddAlertHandling(AlertHandlingUser objAlertHandling)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.SPNames.AlertHandling);

                db.AddInParameter(dbCommand, "@Location_id", DbType.String, objAlertHandling.Location_id);
                db.AddInParameter(dbCommand, "@P_Name", DbType.String, objAlertHandling.P_Name);
                db.AddInParameter(dbCommand, "@P_NRIC_no", DbType.String, objAlertHandling.P_NRIC_no);
                db.AddInParameter(dbCommand, "@P_Passport", DbType.String, objAlertHandling.P_Passport);
                db.AddInParameter(dbCommand, "@P_Nationality", DbType.String, objAlertHandling.P_Nationality);

                db.AddInParameter(dbCommand, "@V_Type", DbType.String, objAlertHandling.V_Type);
                db.AddInParameter(dbCommand, "@V_Color", DbType.String, objAlertHandling.V_Color);
                db.AddInParameter(dbCommand, "@V_ResgistNo", DbType.String, objAlertHandling.V_ResgistNo);
                db.AddInParameter(dbCommand, "@V_OwnerName", DbType.String, objAlertHandling.V_OwnerName);
                db.AddInParameter(dbCommand, "@V_OwnerNricNo", DbType.String, objAlertHandling.V_OwnerNricNo);
                db.AddInParameter(dbCommand, "@Reason", DbType.String, objAlertHandling.Reason);
                db.AddInParameter(dbCommand, "@Alert_Type", DbType.String, objAlertHandling.Alert_Type);

                db.AddInParameter(dbCommand, "@Comment", DbType.String, objAlertHandling.Comment);
                db.AddInParameter(dbCommand, "@AlertBy_NRICNo", DbType.String, objAlertHandling.AlertBy_NRICNo);
                db.AddInParameter(dbCommand, "@AlertBy_Name", DbType.String, objAlertHandling.AlertBy_Name);
                db.AddInParameter(dbCommand, "@AlertDepartment", DbType.String, objAlertHandling.AlertDepartment);
                db.AddInParameter(dbCommand, "@AlertDesignation", DbType.String, objAlertHandling.AlertDesignation);
                db.AddInParameter(dbCommand, "@AlertContNo", DbType.String, objAlertHandling.AlertContNo);

                db.AddInParameter(dbCommand, "@Date_From", DbType.DateTime, objAlertHandling.Date_From);


                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    db.ExecuteNonQuery(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        public void Updatalert(AlertHandlingUser objBillingCode)
        {

            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.AlertConst.SPNames.UPDATE_Alert);


                db.AddInParameter(dbCommand, "@Alert_ID", DbType.String, objBillingCode.Alert_ID);
                db.AddInParameter(dbCommand, "@P_Name", DbType.String, objBillingCode.P_Name);
                db.AddInParameter(dbCommand, "@P_NRIC_no", DbType.String, objBillingCode.P_NRIC_no);
                db.AddInParameter(dbCommand, "@P_Passport", DbType.String, objBillingCode.P_Passport);
                db.AddInParameter(dbCommand, "@P_Nationality", DbType.String, objBillingCode.P_Nationality);

                db.AddInParameter(dbCommand, "@V_Type", DbType.String, objBillingCode.V_Type);
                db.AddInParameter(dbCommand, "@V_Color", DbType.String, objBillingCode.V_Color);
                db.AddInParameter(dbCommand, "@V_ResgistNo", DbType.String, objBillingCode.V_ResgistNo);
                db.AddInParameter(dbCommand, "@V_OwnerName", DbType.String, objBillingCode.V_OwnerName);
                db.AddInParameter(dbCommand, "@V_OwnerNricNo", DbType.String, objBillingCode.V_OwnerNricNo);

                db.AddInParameter(dbCommand, "@Alert_Type", DbType.String, objBillingCode.Alert_Type);
                db.AddInParameter(dbCommand, "@Comment", DbType.String, objBillingCode.Comment);
                db.AddInParameter(dbCommand, "@AlertBy_NRICNo", DbType.String, objBillingCode.AlertBy_NRICNo);
                db.AddInParameter(dbCommand, "@AlertBy_Name", DbType.String, objBillingCode.AlertBy_Name);
                db.AddInParameter(dbCommand, "@AlertDepartment", DbType.String, objBillingCode.AlertDepartment);
                db.AddInParameter(dbCommand, "@AlertDesignation", DbType.String, objBillingCode.AlertDesignation);
                db.AddInParameter(dbCommand, "@AlertContNo", DbType.String, objBillingCode.AlertContNo);

                db.AddInParameter(dbCommand, "@Date_From", DbType.DateTime, objBillingCode.Date_From);



                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    db.ExecuteNonQuery(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        public void DeleteAlertUser(DeleteAlertRequest argObj)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.SPNames.DELETE_Alert);

                db.AddInParameter(dbCommand, "@Alert_ID", DbType.String, argObj.Alert_ID);

                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        public List<CheckInKeyData> GetCheckInkeyData(GetCheckInKey argObj)
        {
            List<CheckInKeyData> lstKey = null;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetSqlStringCommand("select * from vwCheckInKey with(nolock)" + argObj.WhereClause + " order by Fromdate desc");
                IDataReader dataReader = null;
                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    dataReader = db.ExecuteReader(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
                lstKey = CBO.FillCollection<CheckInKeyData>(dataReader);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

            return lstKey;
        }

        public List<CourseEvaluation> GetCourseEvaluationData(GetCourseEvaluationData argObj)
        {
            List<CourseEvaluation> lstlocid = null;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetSqlStringCommand("select * from location with(nolock)" + argObj.WhereClause);
                IDataReader dataReader = null;

                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    dataReader = db.ExecuteReader(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
                lstlocid = CBO.FillCollection<CourseEvaluation>(dataReader);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

            return lstlocid;
        }
        //========================Changes by Shakil================================================

        public List<Visitor> GetOMVisitorData(GetOMVisitorData argObj)
        {
            List<Visitor> lstVisitorNo = null;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                //select checkin_time,checkout_time,NRICno,user_name,Location_name as LocationID from checkout_manager,location where Role='Operations Manager' and checkout_manager.LocationID=location.Location_id
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetSqlStringCommand("select checkin_time,checkout_id,checkout_time,NRICno,user_name,Location_name as LocationID from checkout_manager,location  " + argObj.WhereClause + " and checkout_manager.LocationID=location.Location_id");
                //DbCommand dbCommand = db.GetSqlStringCommand("select * from checkout_manager with(nolock)" + argObj.WhereClause);                
                IDataReader dataReader = null;
                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    dataReader = db.ExecuteReader(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
                lstVisitorNo = CBO.FillCollection<Visitor>(dataReader);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

            return lstVisitorNo;
        }





        public List<Visitor> GetOMVisitorDataCurrentReport(GetOMVisitorData argObj)
        {
            List<Visitor> lstVisitorNo = null;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                //select checkin_id as checkout_id,Checkin_DateTime As Checkin_time,user_name,LocationID,NRICno,Pass_No,telephone,company_from,to_visit from checkin_manager with(nolock)
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetSqlStringCommand("select checkin_id as checkout_id,Checkin_DateTime As Checkin_time,user_name,location.Location_name as LocationID,NRICno,Pass_No,telephone,company_from,to_visit from checkin_manager,location " + argObj.WhereClause + " and location.Location_id=checkin_manager.LocationID order by checkin_DateTime Desc");
                IDataReader dataReader = null;
                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    dataReader = db.ExecuteReader(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
                lstVisitorNo = CBO.FillCollection<Visitor>(dataReader);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

            return lstVisitorNo;
        }

        //===============================Changes end By Shakil=======================================

        public List<ClientVisitMinutes> GetClientVisitMinutesData(GetClientVisitMinutesData argObj)
        {
            List<ClientVisitMinutes> lstlocid = null;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetSqlStringCommand("select * from tblClientVisitMinutes with(nolock)" + argObj.WhereClause);
                IDataReader dataReader = null;

                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    dataReader = db.ExecuteReader(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
                lstlocid = CBO.FillCollection<ClientVisitMinutes>(dataReader);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

            return lstlocid;
        }

        #region Kan
        public List<PenaltyClause> GetPenaltyClauseData(GetPenaltyClauseData argObj)
        {
            List<PenaltyClause> lstlocid = null;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetSqlStringCommand("select * from tblPenaltyClause with(nolock)" + argObj.WhereClause);
                IDataReader dataReader = null;

                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");
                try
                {
                    dataReader = db.ExecuteReader(dbCommand);
                }
                catch (Exception ex)
                {
                    logger1.Info(ex.Message);
                }
                lstlocid = CBO.FillCollection<PenaltyClause>(dataReader);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

            return lstlocid;
        }
        
        public void AddClientVisitMinutes(ClientVisitMinutes cvm)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.SPNames.AddClientVisitMinutes);

                db.AddInParameter(dbCommand, "@strAssignment", DbType.String, cvm.strAssignment);
                db.AddInParameter(dbCommand, "@dtmDateMet", DbType.String, cvm.dtmDateMet);
                db.AddInParameter(dbCommand, "@strMetWith", DbType.String, cvm.strMetWith);
                db.AddInParameter(dbCommand, "@strCompletedBy", DbType.String, cvm.strCompletedBy);
                db.AddInParameter(dbCommand, "@strComplaints", DbType.String, cvm.strComplaints);
                db.AddInParameter(dbCommand, "@strPositiveComments", DbType.String, cvm.strPositiveComments);
                db.AddInParameter(dbCommand, "@strDeployment", DbType.String, cvm.strDeployment);
                db.AddInParameter(dbCommand, "@strEvents", DbType.String, cvm.strEvents);
                db.AddInParameter(dbCommand, "@strRemarks", DbType.String, cvm.strRemarks);
 
                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");

                try
                {
                    db.ExecuteNonQuery(dbCommand);
                } catch (Exception execException) { logger1.Info(execException.Message); }
            }
            catch (Exception cvmex)
            {
                logger.Info(cvmex.Message);
            }
        }

        public void AddAssignmentVisit(AssignmentVisit av)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.SPNames.AddAssignmentVisit);

                db.AddInParameter(dbCommand, "@strTo", DbType.String, av.strTo);
                db.AddInParameter(dbCommand, "@dtmDateVisit", DbType.String, av.dtmDateVisit);
                db.AddInParameter(dbCommand, "@strSubmittedBy", DbType.String, av.strSubmittedBy);
                db.AddInParameter(dbCommand, "@strNameOfAssignment", DbType.String, av.strNameOfAssignment);
                db.AddInParameter(dbCommand, "@strInCharge", DbType.String, av.strInCharge);
                db.AddInParameter(dbCommand, "@strGuards", DbType.String, av.strGuards);
                db.AddInParameter(dbCommand, "@strDressing", DbType.String, av.strDressing);
                db.AddInParameter(dbCommand, "@strAppearance", DbType.String, av.strAppearance);
                db.AddInParameter(dbCommand, "@strHaircut", DbType.String, av.strHaircut);
                db.AddInParameter(dbCommand, "@strAlertness", DbType.String, av.strAlertness);
                db.AddInParameter(dbCommand, "@strDeployment", DbType.String, av.strDeployment);
                db.AddInParameter(dbCommand, "@strGeneralPerformance", DbType.String, av.strGeneralPerformance);
                db.AddInParameter(dbCommand, "@strOtherMatters", DbType.String, av.strOtherMatters);
                db.AddInParameter(dbCommand, "@strConclussion", DbType.String, av.strConclussion);
                db.AddInParameter(dbCommand, "@strRecommendation", DbType.String, av.strRecommendation);


                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");

                try
                {
                    db.ExecuteNonQuery(dbCommand);
                }
                catch (Exception execException) { logger1.Info(execException.Message); }
            }
            catch (Exception avex)
            {
                logger.Info(avex.Message);
            }
        }

        public void AddClientFeedback(CustomerFeedback cf)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.SPNames.AddCustomerFeedback);

                db.AddInParameter(dbCommand, "@strNameOfTrainee", DbType.String, cf.strNameOfTrainee);
                db.AddInParameter(dbCommand, "@dtmDateOfEvaluation", DbType.String, cf.dtmDateOfEvaluation);
                db.AddInParameter(dbCommand, "@strNric", DbType.String, cf.strNric);
                db.AddInParameter(dbCommand, "@strResponseTime", DbType.String, cf.strResponseTime);
                db.AddInParameter(dbCommand, "@strSupportServices", DbType.String, cf.strSupportServices);
                db.AddInParameter(dbCommand, "@strPerformance", DbType.String, cf.strPerformance);
                db.AddInParameter(dbCommand, "@strResponsiveness", DbType.String, cf.strResponsiveness);
                db.AddInParameter(dbCommand, "@strTakingInstructions", DbType.String, cf.strTakingInstructions);
                db.AddInParameter(dbCommand, "@strResponseToComplaints", DbType.String, cf.strResponseToComplaints);
                db.AddInParameter(dbCommand, "@strComments", DbType.String, cf.strComments);
    
                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");

                try
                {
                    db.ExecuteNonQuery(dbCommand);
                }
                catch (Exception execException) { logger1.Info(execException.Message); }
            }
            catch (Exception cfex)
            {
                logger.Info(cfex.Message);
            }
        }

        public void AddCourseEvaluation(CourseEvaluation ce)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                //Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                //DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.SPNames.AddAssignmentVisit);

                //db.AddInParameter(dbCommand, "@strNameOfTrainee", DbType.String, ce.strNameOfTrainee);
                //db.AddInParameter(dbCommand, "@dtmDateOfEvaluation", DbType.String, ce.dtmDateOfEvaluation);
                //db.AddInParameter(dbCommand, "@dtmDateCreated", DbType.String, ce.dtmDateOfEvaluation);
                //db.AddInParameter(dbCommand, "@strNric", DbType.String, cf.strNric);
                //db.AddInParameter(dbCommand, "@strComments", DbType.String, cf.strResponseTime);
                //db.AddInParameter(dbCommand, "@strSupportServices", DbType.String, cf.strSupportServices);
                //db.AddInParameter(dbCommand, "@strPerformance", DbType.String, cf.strPerformance);
                //db.AddInParameter(dbCommand, "@strResponsiveness", DbType.String, cf.strResponsiveness);
                //db.AddInParameter(dbCommand, "@strTakingInstructions", DbType.String, cf.strTakingInstructions);
                //db.AddInParameter(dbCommand, "@strResponseToComplaints", DbType.String, cf.strResponseToComplaints);
                //db.AddInParameter(dbCommand, "@strComments", DbType.String, cf.strComments);
    
                //log4net.ILog logger1 = log4net.LogManager.GetLogger("File");

                //try
                //{
                //    db.ExecuteNonQuery(dbCommand);
                //}
                //catch (Exception execException) { logger1.Info(execException.Message); }
            }
            catch (Exception cfex)
            {
                logger.Info(cfex.Message);
            }
        }

        public void AddPenaltyClause(PenaltyClause pc)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.SPNames.AddAssignmentVisit);

                db.AddInParameter(dbCommand, "@strHeading", DbType.String, pc.strHeading);
                db.AddInParameter(dbCommand, "@dblFine", DbType.Decimal, pc.dblFine);
                db.AddInParameter(dbCommand, "@strClause", DbType.String, pc.strClause);
                    
                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");

                try
                {
                    db.ExecuteNonQuery(dbCommand);
                }
                catch (Exception execException) { logger1.Info(execException.Message); }
            }
            catch (Exception pcex)
            {
                logger.Info(pcex.Message);
            }
        }

        public void AddCustomerComplaint(CustomerComplaint cc)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.SPNames.AddCustomerComplaint);

                db.AddInParameter(dbCommand, "@strLogNo", DbType.String, cc.strLogNo);
                db.AddInParameter(dbCommand, "@strDocument", DbType.String, cc.strDocument);
                db.AddInParameter(dbCommand, "@strAuditNo", DbType.String, cc.strAuditNo);
                db.AddInParameter(dbCommand, "@strDescription", DbType.String, cc.strDescription);
                db.AddInParameter(dbCommand, "@strRaisedBy", DbType.String, cc.strRaisedBy);
                db.AddInParameter(dbCommand, "@strCause", DbType.String, cc.strCause);
                db.AddInParameter(dbCommand, "@strActionFix", DbType.String, cc.strActionFix);
                db.AddInParameter(dbCommand, "@strActionPrevent", DbType.String, cc.strActionPrevent);
                db.AddInParameter(dbCommand, "@dtmDate", DbType.DateTime, cc.dtmDate);
                db.AddInParameter(dbCommand, "@dtmExpectedCompletion", DbType.DateTime, cc.dtmExpectedCompletion);
                db.AddInParameter(dbCommand, "@dtmActionApproved", DbType.DateTime, cc.dtmActionApproved);

                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");

                try
                {
                    db.ExecuteNonQuery(dbCommand);
                }
                catch (Exception execException) { logger1.Info(execException.Message); }
            }
            catch (Exception ccex)
            {
                logger.Info(ccex.Message);
            }
        }

        public void AddSOAppraisal(SOAppraisal soa)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.SPNames.AddSOAppraisal);

                db.AddInParameter(dbCommand, "@strName", DbType.String, soa.strName);
                db.AddInParameter(dbCommand, "@dtmDate", DbType.DateTime, soa.dtmDate);
                db.AddInParameter(dbCommand, "@strCategory", DbType.String, soa.strCategory);

                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");

                try
                {
                    db.ExecuteNonQuery(dbCommand);
                }
                catch (Exception execException) { logger1.Info(execException.Message); }
            }
            catch (Exception soaex)
            {
                logger.Info(soaex.Message);
            }
        }

        public void AddSOBriefing(SOBriefing sob)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.SPNames.AddSOBriefing);

                db.AddInParameter(dbCommand, "@dtmTime", DbType.DateTime, sob.dtmTime);
                db.AddInParameter(dbCommand, "@dtmDate", DbType.DateTime, sob.dtmDate);
                db.AddInParameter(dbCommand, "@strLocation", DbType.String, sob.strLocation);
                db.AddInParameter(dbCommand, "@strAttendees", DbType.String, sob.strAttendees);
                db.AddInParameter(dbCommand, "@strDetails", DbType.String, sob.strDetails);

                log4net.ILog logger1 = log4net.LogManager.GetLogger("File");

                try
                {
                    db.ExecuteNonQuery(dbCommand);
                }
                catch (Exception execException) { logger1.Info(execException.Message); }
            }
            catch (Exception sobex)
            {
                logger.Info(sobex.Message);
            }
        }

       
        public int addmenu(roleMasterMap obj, string spname)
        {

            SqlParameter[] param = new SqlParameter[6];
            //param[0] = new SqlParameter("@ID", obj.rMastMp_Id);
            param[0] = new SqlParameter("@RoleId", obj.rMastMp_RoleId);
            param[1] = new SqlParameter("@MenuId", obj.rMastMp_MenuId);
            param[2] = new SqlParameter("@addright", obj.rMastMp_Addright);
            param[3] = new SqlParameter("@readpermission", obj.rMastMp_readonly);
            param[4] = new SqlParameter("@writeonly ", obj.rMastMp_writeonly);
            param[5] = new SqlParameter("@parentid ", obj.rmastMp_ParentId);
            DBConnectionHandler1 d = new DBConnectionHandler1();
            output = d.insertprocedure(spname, param);
            return output;
        }
        public int searchmenuid(string menuname, int parentid)
        {
            DBConnectionHandler1 d = new DBConnectionHandler1();
            SqlConnection cn = d.getconnection();
            cn.Open();
            SqlCommand cmd = new SqlCommand("select ID from MenuMaster where DisplayText=@displayText and ParentId=@parentid", cn);
            cmd.Parameters.AddWithValue("@DisplayText", menuname);
            cmd.Parameters.AddWithValue("@parentid", parentid);
            //cmd.Parameters.AddWithValue("@parentid",Convert.ToInt32(x));
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read()) { sermenuid = dr.GetInt32(0); }
            dr.Close();
            dr.Dispose();
            cn.Close();
            return sermenuid;
        }
        public int searchstatusmenuid(string menuname, int parentStatus)
        {
            DBConnectionHandler1 d = new DBConnectionHandler1();
            SqlConnection cn = d.getconnection();
            cn.Open();
            SqlCommand cmd = new SqlCommand("select ID from MenuMaster where DisplayText=@displayText and ParentStatus=@parentStatus", cn);
            cmd.Parameters.AddWithValue("@DisplayText", menuname);
            cmd.Parameters.AddWithValue("@parentStatus", parentStatus);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read()) { serstatusmenuid = dr.GetInt32(0); }
            dr.Close();
            dr.Dispose();
            cn.Close();
            return serstatusmenuid;
        }
        public int searchtreevalue(string tree)
        {
            DBConnectionHandler1 d = new DBConnectionHandler1();
            SqlConnection cn = d.getconnection();
            cn.Open();
            SqlCommand cmd = new SqlCommand("select ID from UserRoleMaster where UserRole=@UserRole", cn);
            cmd.Parameters.AddWithValue("@UserRole", tree);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read()) { searchtreeval = dr.GetInt32(0); }
            dr.Close();
            dr.Dispose();
            cn.Close();
            return searchtreeval;
        }
        public DataTable userrole(int tree)
        {
            DBConnectionHandler1 d = new DBConnectionHandler1();
            SqlConnection cn = d.getconnection();
            cn.Open();
            SqlCommand cmd = new SqlCommand("sermenumastermap", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@RoleId", tree);
            cmd.Parameters.Add(param[0]);
            DataTable dt = new DataTable();
            SqlDataAdapter ds = new SqlDataAdapter();
            ds.SelectCommand = cmd;
            ds.Fill(dt);
            cn.Close();
            return dt;
        }
        public int editmenumastmap(roleMasterMap obj, string spname)
        {
            DBConnectionHandler1 d = new DBConnectionHandler1();
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@RoleId", obj.rMastMp_RoleId);
            param[1] = new SqlParameter("@MenuId", obj.rMastMp_MenuId);
            param[2] = new SqlParameter("@addright", obj.rMastMp_Addright);
            param[3] = new SqlParameter("@readpermission", obj.rMastMp_readonly);
            param[4] = new SqlParameter("@writeonly ", obj.rMastMp_writeonly);
            param[5] = new SqlParameter("@parentid ", obj.rmastMp_ParentId);
            param[6] = new SqlParameter("@ID", obj.rMastMp_Id);
            editmenumast = d.editmenumastmap(spname, param);
            return editmenumast;
        }
        public int countmenumastmap(roleMasterMap obj, string spname)
        {
            DBConnectionHandler1 d = new DBConnectionHandler1();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@RoleId", obj.rMastMp_RoleId);
            param[1] = new SqlParameter("@MenuId", obj.rMastMp_MenuId);
            param[2] = new SqlParameter("@Parentid", obj.rmastMp_ParentId);
            countmenumast = d.countmenumastmap(spname, param);
            return countmenumast;
        }
        public DataTable menuname()
        {
            DBConnectionHandler1 d = new DBConnectionHandler1();
            SqlConnection cn = d.getconnection();
            cn.Open();
            SqlCommand cmd = new SqlCommand("dynamicparentmenu", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter ds = new SqlDataAdapter();
            ds.SelectCommand = cmd;
            ds.Fill(dt);
            cn.Close();
            return dt;
        }
        public DataTable menuhildname()
        {
            DBConnectionHandler1 d = new DBConnectionHandler1();
            SqlConnection cn = d.getconnection();
            cn.Open();
            SqlCommand cmd = new SqlCommand("dynamichildmenu", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter ds = new SqlDataAdapter();
            ds.SelectCommand = cmd;
            ds.Fill(dt);
            return dt;
        }
        public DataTable menuhild2name()
        {
            DBConnectionHandler1 d = new DBConnectionHandler1();
            SqlConnection cn = d.getconnection();
            cn.Open();
            SqlCommand cmd = new SqlCommand("dynamichil2dmenu", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter ds = new SqlDataAdapter();
            ds.SelectCommand = cmd;
            ds.Fill(dt);
            return dt;
        }
        public DataTable menuhild3name()
        {
            DBConnectionHandler1 d = new DBConnectionHandler1();
            SqlConnection cn = d.getconnection();
            cn.Open();
            SqlCommand cmd = new SqlCommand("dynamichil3dmenu", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter ds = new SqlDataAdapter();
            ds.SelectCommand = cmd;
            ds.Fill(dt);
            return dt;
        }
        public DataTable shiftdeployment()
        {
            DBConnectionHandler1 d = new DBConnectionHandler1();
            SqlConnection cn = d.getconnection();
            cn.Open();
            SqlCommand cmd = new SqlCommand("shiftdeployment", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter ds = new SqlDataAdapter();
            ds.SelectCommand = cmd;
            ds.Fill(dt);
            return dt;
        }
        public DataTable shiftmgmt()
        {
            DBConnectionHandler1 d = new DBConnectionHandler1();
            SqlConnection cn = d.getconnection();
            cn.Open();
            SqlCommand cmd = new SqlCommand("shiftmgmt", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter ds = new SqlDataAdapter();
            ds.SelectCommand = cmd;
            ds.Fill(dt);
            return dt;
        }
        public DataTable dynamicchild4menu()
        {
            DBConnectionHandler1 d = new DBConnectionHandler1();
            SqlConnection cn = d.getconnection();
            cn.Open();
            SqlCommand cmd = new SqlCommand("dynamicchild4menu", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter ds = new SqlDataAdapter();
            ds.SelectCommand = cmd;
            ds.Fill(dt);
            return dt;
        }
        public DataTable locationyment()
        {
            DBConnectionHandler1 d = new DBConnectionHandler1();
            SqlConnection cn = d.getconnection();
            cn.Open();
            SqlCommand cmd = new SqlCommand("locationyment", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter ds = new SqlDataAdapter();
            ds.SelectCommand = cmd;
            ds.Fill(dt);
            return dt;
        }
        public DataTable inventry()
        {
            DBConnectionHandler1 d = new DBConnectionHandler1();
            SqlConnection cn = d.getconnection();
            cn.Open();
            SqlCommand cmd = new SqlCommand("inventry", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter ds = new SqlDataAdapter();
            ds.SelectCommand = cmd;
            ds.Fill(dt);
            return dt;
        }
        public DataTable tranning()
        {
            DBConnectionHandler1 d = new DBConnectionHandler1();
            SqlConnection cn = d.getconnection();
            cn.Open();
            SqlCommand cmd = new SqlCommand("tranning", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter ds = new SqlDataAdapter();
            ds.SelectCommand = cmd;
            ds.Fill(dt);
            return dt;
        }
        public DataTable previsitors()
        {
            DBConnectionHandler1 d = new DBConnectionHandler1();
            SqlConnection cn = d.getconnection();
            cn.Open();
            SqlCommand cmd = new SqlCommand("previsitors", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter ds = new SqlDataAdapter();
            ds.SelectCommand = cmd;
            ds.Fill(dt);
            return dt;
        }
        public DataTable checkinout()
        {
            DBConnectionHandler1 d = new DBConnectionHandler1();
            SqlConnection cn = d.getconnection();
            cn.Open();
            SqlCommand cmd = new SqlCommand("checkinout", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter ds = new SqlDataAdapter();
            ds.SelectCommand = cmd;
            ds.Fill(dt);
            return dt;
        }
        public DataTable feedbackform()
        {
            DBConnectionHandler1 d = new DBConnectionHandler1();
            SqlConnection cn = d.getconnection();
            cn.Open();
            SqlCommand cmd = new SqlCommand("feedbackform", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter ds = new SqlDataAdapter();
            ds.SelectCommand = cmd;
            ds.Fill(dt);
            return dt;
        }
        public DataTable viewreports()
        {
            DBConnectionHandler1 d = new DBConnectionHandler1();
            SqlConnection cn = d.getconnection();
            cn.Open();
            SqlCommand cmd = new SqlCommand("viewreports", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter ds = new SqlDataAdapter();
            ds.SelectCommand = cmd;
            ds.Fill(dt);
            return dt;
        }
        public DataTable alertmgmt()
        {
            DBConnectionHandler1 d = new DBConnectionHandler1();
            SqlConnection cn = d.getconnection();
            cn.Open();
            SqlCommand cmd = new SqlCommand("alertmgmt", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter ds = new SqlDataAdapter();
            ds.SelectCommand = cmd;
            ds.Fill(dt);
            return dt;
        }
        public DataTable followup()
        {
            DBConnectionHandler1 d = new DBConnectionHandler1();
            SqlConnection cn = d.getconnection();
            cn.Open();
            SqlCommand cmd = new SqlCommand("followup", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter ds = new SqlDataAdapter();
            ds.SelectCommand = cmd;
            ds.Fill(dt);
            return dt;
        }
        public DataTable Maintenance()
        {
            DBConnectionHandler1 d = new DBConnectionHandler1();
            SqlConnection cn = d.getconnection();
            cn.Open();
            SqlCommand cmd = new SqlCommand("Maintenance", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter ds = new SqlDataAdapter();
            ds.SelectCommand = cmd;
            ds.Fill(dt);
            return dt;
        }
        public DataTable sopmanagement()
        {
            DBConnectionHandler1 d = new DBConnectionHandler1();
            SqlConnection cn = d.getconnection();
            cn.Open();
            SqlCommand cmd = new SqlCommand("sopmanagement", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter ds = new SqlDataAdapter();
            ds.SelectCommand = cmd;
            ds.Fill(dt);
            return dt;
        }
        public DataTable staffmgmt()
        {
            DBConnectionHandler1 d = new DBConnectionHandler1();
            SqlConnection cn = d.getconnection();
            cn.Open();
            SqlCommand cmd = new SqlCommand("staffmgmt", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter ds = new SqlDataAdapter();
            ds.SelectCommand = cmd;
            ds.Fill(dt);
            return dt;
        }
        public DataTable creportsmgmt()
        {
            DBConnectionHandler1 d = new DBConnectionHandler1();
            SqlConnection cn = d.getconnection();
            cn.Open();
            SqlCommand cmd = new SqlCommand("creportsmgmt", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter ds = new SqlDataAdapter();
            ds.SelectCommand = cmd;
            ds.Fill(dt);
            return dt;
        }
        //public DataTable reportmgmt()
        //{
        //    DBConnectionHandler1 d = new DBConnectionHandler1();
        //    SqlConnection cn = d.getconnection();
        //    cn.Open();
        //    SqlCommand cmd = new SqlCommand("reportmgmt", cn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    DataTable dt = new DataTable();
        //    SqlDataAdapter ds = new SqlDataAdapter();
        //    ds.SelectCommand = cmd;
        //    ds.Fill(dt);
        //    return dt;
        //}
        public DataTable masterppd()
        {
            DBConnectionHandler1 d = new DBConnectionHandler1();
            SqlConnection cn = d.getconnection();
            cn.Open();
            SqlCommand cmd = new SqlCommand("masterppd", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter ds = new SqlDataAdapter();
            ds.SelectCommand = cmd;
            ds.Fill(dt);
            return dt;
        }
        public int searchparentid(string displaytext)
        {
            DBConnectionHandler1 d = new DBConnectionHandler1();
            SqlConnection cn = d.getconnection();
            cn.Open();
            SqlCommand cmd = new SqlCommand("select ID from MenuMaster where DisplayText=@displayText", cn);
            cmd.Parameters.AddWithValue("@DisplayText", displaytext);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read()) { searchparentid1 = dr.GetInt32(0); }
            dr.Close();
            dr.Dispose();
            cn.Close();
            return searchparentid1;
        }
        public int searchzeroparentid(string displaytext)
        {
            DBConnectionHandler1 d = new DBConnectionHandler1();
            SqlConnection cn = d.getconnection();
            cn.Open();
            SqlCommand cmd = new SqlCommand("select ParentId,ParentStatus from MenuMaster where DisplayText=@displayText", cn);
            cmd.Parameters.AddWithValue("@DisplayText", displaytext);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr.GetInt32(1) == 0)
                {
                    searchzeroparentid1 = 0;
                }
                else if (dr.GetInt32(1) == 1)
                {
                    searchzeroparentid1 = Convert.ToInt32(0);
                }

            }
            dr.Close();
            dr.Dispose();
            cn.Close();
            return searchzeroparentid1;
        }
        public int serachParent(int parent1)
        {
            DBConnectionHandler1 d = new DBConnectionHandler1();
            SqlConnection cn = d.getconnection();
            cn.Open();
            //if (parent1 != 0)
            //{
            SqlCommand cmd = new SqlCommand("select ParentId,ParentStatus from MenuMaster where ID=@id", cn);
            cmd.Parameters.AddWithValue("@id", parent1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr.GetInt32(1) == 0)
                {
                    parent = 0;
                }
                else if (dr.GetInt32(1) == 1)
                {
                    parent = dr.GetInt32(0);
                }
            }
            dr.Close();
            dr.Dispose();
            cn.Close();
            return parent;
            //}
            //else { return -1; }

        }
        public int searchparentid2(int var)
        {
            DBConnectionHandler1 d = new DBConnectionHandler1();
            SqlConnection cn = d.getconnection();
            cn.Open();
            SqlCommand cmd = new SqlCommand("select ParentId,Parentstatus from MenuMaster where ID=@id", cn);
            cmd.Parameters.AddWithValue("@Id", var);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr.GetInt32(1) == 1)
                {
                    parent2 = dr.GetInt32(0);
                }
                else { parent2 = 0; }
            }
            return parent2;
        }
        

        #endregion
    }
}
