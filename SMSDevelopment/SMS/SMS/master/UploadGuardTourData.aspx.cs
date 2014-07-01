using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using SMS.Services.DataService;
using SMS.Services.DALUtilities;

namespace SMS.master
{
    public partial class UploadGuardTourData : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getLocationName();
            }

        }
        private void getLocationName()
        {
            ddllocation.Items.Clear();
            ddllocation.Items.Add("");
            SqlParameter[] para = new SqlParameter[0];
            // para[0] = new SqlParameter("@Location_id", Name);
            DataTable dsLocation = dal.executeprocedure("sp_FillLocationName", para, false);
            if (dsLocation.Rows.Count > 0)
            {
                for (int k = 0; k < dsLocation.Rows.Count; k++)
                {
                    ddllocation.Items.Add(dsLocation.Rows[k][0].ToString().Trim());
                }
            }
        }
        private void getLocationIDByName(string Name)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Location_name", Name);
            DataTable dsLocationID = dal.executeprocedure("sp_GetLocationIDbyName", para, false);
            if (dsLocationID.Rows.Count > 0)
            {
                SearchLocID.Text = dsLocationID.Rows[0][0].ToString().Trim();
            }
        }
        protected void BtnUpload_Click1(object sender, EventArgs e)
        {
            string name = FileUpload1.FileName;
            string filepath = Server.MapPath(@"GuardTour/") + name;
            FileUpload1.PostedFile.SaveAs(filepath);
            OleDbConnection excelConnection = new OleDbConnection("provider=Microsoft.jet.oledb.4.0;data source=" + filepath + ";extended properties='Excel 8.0;HDR=YES;'");
            excelConnection.Open();
            OleDbCommand ocmd = new OleDbCommand("select * from [Sheet1$]", excelConnection);
                //excelConnection.Open();
                OleDbDataReader odr = ocmd.ExecuteReader();
                string f1 = "";
                string f2 = "";
                string f3 = "";
                string f4 = "";
                string f5 = "";
                string f6 = "";
                string f7 = "";
                string f8 = "";
                string f9 = "";
                string f10= "";
                getLocationIDByName(ddllocation.SelectedValue.ToString());
                DBConnectionHandler1 db = new DBConnectionHandler1();
                SqlConnection cn = db.getconnection();
                cn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter("select MAX(temp) from GaurdTourSystem2", cn);
                DataTable dtid = new DataTable();
                
                adp.Fill(ds);
                dtid = ds.Tables[0];
                int id = 0;
                if (dtid.Rows.Count > 0)
                {
                    if (dtid.Rows[0][0].ToString() == "")
                    {
                        id = 1;
                        //cn.Close();
                    }
                    else
                    {
                        id = Convert.ToInt32(dtid.Rows[0][0].ToString());
                        id++;
                    }
                    
                    cn.Close();
                    //GlobalVar.Risk_ID = id;
                }
                else
                {
                    id = 1;
                    cn.Close();
                }
                insertdataintosql2(SearchLocID.Text, name.ToString(), Convert.ToString(DateTime.Now.ToShortDateString()),id);
                cn.Open();
                SqlCommand _cmd = new SqlCommand("select GTSID from GaurdTourSystem2 where LocationID=@location and temp=@currentdate",cn);
                _cmd.Parameters.AddWithValue("@location", SearchLocID.Text);
                _cmd.Parameters.AddWithValue("@currentdate",id);
                SqlDataReader dr = _cmd.ExecuteReader();
                if (dr.Read()) { int GTSID = dr.GetInt32(0); f10 = GTSID.ToString(); dr.Close(); cn.Close(); }
                while (odr.Read())
                {
                    //string elementHead = valid(odr, 0);
                    //Session["ElementHead"] = elementHead.ToString();
                    f1 = valid(odr, 1);
                    f2 = valid(odr, 2);
                    f3 = valid(odr, 3);
                    f4 = valid(odr, 4);
                    f5 = valid(odr, 5);
                    f6 = valid(odr, 6);
                    f7 = valid(odr, 7);
                    f8 = valid(odr, 8);
                    f9 = valid(odr, 9);
                    //f10=valid(odr,9);
                    if (f1.ToString().ToUpper() == "number" || f2.ToString().ToUpper() == "Personnel#")
                    {


                    }
                    else
                    {

                        insertdataintosql(f1, f2, f3, f4, f5, f6, f7, f8, f9,f10);

                    }
                        
                }
                lblerror1.Text = "Uploaded Successfully!!!";
            excelConnection.Close();
        }
        protected string valid(OleDbDataReader myreader, int stval)
        {
            //if any columns are found null then they are replaced by zero
            object val = myreader[stval];
            if (object.ReferenceEquals(val, DBNull.Value))
            {
                return Convert.ToString(0);
                //return Convert.ToString("First");
            }
            else
            {
                return val.ToString();
            }
        }
        public void insertdataintosql(string f1, string f2, string f3, string f4, string f5, string f6, string f7, string f8, string f9, string f10)
        {

            DBConnectionHandler1 db = new DBConnectionHandler1();
            SqlConnection cn = db.getconnection();
            cn.Open();
            f2 = f2.Replace("'", "''");
            f3 = f3.Replace("'", "''");
            f4 = f4.Replace("'", "''");
            f1 = f1.Replace("'", "''");
            //string query = "insert into ALG_Exceldetails (F1,F2,F3,F4,F5,F6,F7,F8) values('" + f1 + "','" + f2 + "','" + f3 + "','" + f4 + "','" + f5 + "','" + f6 + "','" + f7 + "','" + f8 + "')";
            string query = "insert into GaurdTourSystem (Personnel,Check_Point,PatrolTime,Remark,Rout,Reader,GEvent,Personnel#,Check_Point#,GTSID) values('" + f2 + "','" + f5 + "','" + f3 + "','" + f6 + "','" + f9 + "','" + f8 + "','" + f7 + "','" + f1 + "','" + f4 + "','" + f10 + "')";
            SqlCommand cmd = new SqlCommand(query,cn);
            cmd.ExecuteNonQuery();
            
            cn.Close();
        }
        public void insertdataintosql2(string f1, string f2,string  f3, int f4)
        {

            DBConnectionHandler1 db = new DBConnectionHandler1();
            SqlConnection cn = db.getconnection();
            cn.Open();
            string query = "insert into GaurdTourSystem2 (LocationID,FileName,CurrentDate,temp) values('" + f1 + "','" + f2 + "','" + f3 + "','" + f4 + "')";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.ExecuteNonQuery();
            cn.Close();
        }
       
    }
}