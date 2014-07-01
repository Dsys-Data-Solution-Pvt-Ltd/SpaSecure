using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace SMS.Services.DataService
{
    public static class GlobalVar
    {
        public static int RiskID = 0;
        public static int verify = 0;
        public static string MISCid = "";
        public static string PublicID = "";


        public static int Risk_ID
        {
            get
            {
                return RiskID;
            }
            set
            {
                RiskID = value;
            }
        }

        public static int veri_fy
        {
            get
            {
                return verify;
            }
            set
            {
                verify = value;
            }
        }


        public static String MISC_id
        {
            get
            {
                return MISCid;
            }
            set
            {
                MISCid = value;
            }
        }
        public static String Public_ID
        {
            get
            {
                return PublicID;
            }
            set
            {
                PublicID = value;
            }
        }
    }
}
