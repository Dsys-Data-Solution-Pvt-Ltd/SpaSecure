using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.Services.DataService;
using SMS.BusinessEntities.Main;

namespace SMS.Services.BusinessServices
{
    public class add_user_info
    {
        int insert, editmenumast, countmenumast;
        int output;

        SMS.Services.DataService.AdminDAL ad = new SMS.Services.DataService.AdminDAL();
        //AddNewTrainee ae = new AddNewTrainee();
        public int insertmenu(roleMasterMap obj, string spname)
        {
            AdminDAL ad = new AdminDAL();
            insert = ad.addmenu(obj, spname);
            return insert;
        }
        public int editmenumastmap(roleMasterMap obj, string spname)
        {
            AdminDAL ad = new AdminDAL();
            editmenumast = ad.editmenumastmap(obj, spname);
            return editmenumast;
        }
        public int countmenumastmap(roleMasterMap obj, string spname)
        {
            AdminDAL ad = new AdminDAL();
            countmenumast = ad.countmenumastmap(obj, spname);
            return countmenumast;
        }
        /*public int insertTrainee(AddNewTrainee ae, string sp)
        {
            output = ad.insertTrainee(ae, sp);
            return output;
        }*/
        /*public int insertTrainee1(AddNewTrainee ae, string sp)
        {
            output = ad.insertTrainee1(ae, sp);
            return output;
        }*/

    }
}