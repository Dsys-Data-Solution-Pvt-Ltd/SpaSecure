using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using SMS.Services;
using SMS.BusinessEntities;
using SMS.Services.DataService;


namespace SMS.Services.DALUtilities
{
    public class DALConstants
    {
        DataAccessLayer dal = new DataAccessLayer();

        public class Misc
        {
            public const string CONNECTION_STRING = "tspsecur_SMSConnectionString";
        }

        public static class SPNames
        {
            public const string USER_FIRSTNAME = "usp_User_FirstName";
            public const string DELETE_USER_STAFF = "sp_DeleteuserStaff";
            public const string DELETE_STAFF_PRESENT = "sp_DeleteStaffToPresent";
            public const string GET_MENU_ITEMS = "usp_GetMenuItems";
            public const string FORGOT_PASSWORD = "usp_ForgotPassword";
            public const string AUTHENTICATE_USER = "usp_GetUserInfo";
            public const string User_AddIncident = "sp_User_AddIncident";
            public const string User_AddPass = "sp_User_Addpass";
            public const string User_AddVehicle = "sp_User_AddVehicle";
            public const string User_AddShift = "sp_User_AddShift";
            public const string User_AddSOP = "sp_AddSOP";
            public const string AddNew_Key = "sp_AddNewKey";
            public const string location = "sp_location";
            public const string eventman = "sp_eventman";
            public const string AppointmentAdd = "sp_AddAppontment";
            public const string AddTutorial = "sp_AddTutorial";
            public const string AddnewItem = "sp_AddNewItem";
            public const string AlertHandling = "sp_AlertHandling";
            public const string AddStaffShift = "sp_AddShiftStaff";

            public const string AddInventory = "sp_AddNewInventory";
            public const string AddTraining = "SP_AddTrainingMgt";
            public const string AddClientVisitMinutes = "sp_InsertClientVisitMinutes";
            public const string AddAssignmentVisit = "sp_InsertAssignmentVisit";
            public const string AddPenaltyClause = "sp_InsertPenaltyClause";
            public const string AddCustomerComplaint = "sp_InsertCustomerComplaint";
            public const string AddSOAppraisal = "sp_InsertSOAppraisal";
            public const string AddCustomerFeedback = "sp_InsertCustomerFeedback";
            public const string AddSOBriefing = "sp_InsertSOBriefing";



            public const string DELETE_Inventory = "sp_DeleteInventory";
            public const string DELETE_EMBOSSING = "sp_DeleteItem";
            public const string DELETE_Location = "sp_DeleteLocation";
            public const string DELETE_Pass = "sp_DeletePass";
            public const string DELETE_Key = "sp_DeleteKey";
            public const string DELETE_SOP = "sp_DeleteSOP";
            public const string DELETE_Shift = "sp_DeleteShift";
            public const string DELETE_Event = "sp_DeleteEvent";
            public const string DELETE_Alert = "sp_DeleteAlert";
            public const string DELETE_Contractor = "sp_DeleteContractor";
            public const string DELETE_User = "sp_DeleteUser";
            public const string DELETE_Vehicle = "sp_DeleteVehicle";
            public const string DELETE_Incident = "sp_DeleteIncident";
            public const string DELETE_ShiftStaff = "sp_DeleteShiftStaff";
            public const string DELETE_Training = "SP_Delete_TrainingMgt";
            public const string DELETE_AssignmentVisit = "sp_DeleteAssignmentVisit";
            public const string DELETE_ClientContacts = "sp_DeleteClientContacts";
            public const string DELETE_ClientVisitMinutes = "sp_DeleteClientVisitMinutes";
            public const string DELETE_CourseEvaluation = "sp_DeleteCourseEvaluation";
            public const string DELETE_CustomerComplaint = "sp_DeleteCustomerComplaint";
            public const string DELETE_EmergencyContacts = "sp_DeleteEmergencyContacts";
            public const string DELETE_EssentialContacts = "sp_DeleteEssentialContacts";
            public const string DELETE_PenaltyClause = "sp_DeletePenaltyClause";
            public const string DELETE_SOAppraisal = "sp_DeleteSOAppraisal";
            public const string DELETE_SOBriefing = "sp_DeleteSOBriefing";
            

            public const string GET_ItemData = "sp_GET_ItemData";
            public const string GET_PassData = "sp_GET_PassData";
            public const string GET_SOPData = "sp_GET_SOPData";
            public const string GET_NewKey = "sp_GET_NewKey";
            public const string GET_LocationData = "sp_GET_LocationData";
            public const string GET_AssignToData = "sp_GET_AssignData";
            public const string GET_AlertData = "sp_GET_AlertData"; 
        }

        public static class ClientVisitMinutes
        {
            public static class SPNames
            {
                public const string UPDATE_ClientVisitMinutes = "sp_UpdateClientVisitMinutes";
            }
        }

        public static class AssignmentVisit
        {
            public static class SPNames
            {
                public const string UPDATE_AssignmentVisit = "sp_UpdateAssignmentVisit";
            }
        }

        public static class ClientContacts
        {
            public static class SPNames
            {
                public const string UPDATE_ClientContacts = "sp_UpdateClientContacts";
            }
        }

        public static class CourseEvaluation
        {
            public static class SPNames
            {
                public const string UPDATE_CourseEvaluation = "sp_UpdateCourseEvaluation";
            }
        }

        public static class CustomerComplaint
        {
            public static class SPNames
            {
                public const string UPDATE_CustomerComplaint = "sp_UpdateCustomerComplaint";
            }
        }

        public static class PenaltyClause
        {
            public static class SPNames
            {
                public const string UPDATE_PenaltyClause = "sp_UpdatePenaltyClause";
            }
        }

        public static class SOAppraisal
        {
            public static class SPNames
            {
                public const string UPDATE_SOAppraisal = "sp_UpdateSOAppraisal";
            }
        }

        public static class SOBriefing
        {
            public static class SPNames
            {
                public const string UPDATE_SOBriefing = "sp_UpdateSOBriefing";
            }
        }

        public static class CheckInInfoConst
        {
            public static class SPNames
            {
                public const string Checkin_Guard = "sp_CheckIn_Guard";
                public const string Checkin_Contractor = "sp_CheckIn_Contractor";
                public const string Checkin_Staff = "sp_CheckIn_Staff";
                public const string Checkin_Visitor = "sp_CheckIn_Visitor";
            }
        }
        public static class CheckOutInfoConst
        {
            public static class SPNames
            {
                public const string Checkout_Guard = "sp_Checkout_Guard";
                public const string Checkout_Contractor = "sp_CheckOut_Contractor";
                public const string Checkout_Salesman = "sp_CheckOut_Salesman";
                public const string Checkout_Visitor = "sp_CheckOut_Visitor";
            }
        }
        #region User Information
        public static class UserInfoConst
        {
            public static class SPNames
            {
                public const string ADD_USERINFO = "usp_AddUserInfo";
                public const string GET_USERINFO = "usp_GetUserInfo";
                public const string DELETE_USERINFO = "usp_DeleteUserInfo";
                public const string UPDATE_USERINFO = "usp_UpdateUserInfo";
                public const string CHANGE_PASSWORD = "usp_ChangePassword";
            }
        }
        #endregion
        public static class ItemDataConst
        {
            public static class SPNames
            {
                public const string UPDATE_ItemData = "usp_UpdateItemData";
            }
        }

        public static class Taining
        {
            public static class SPNames
            {
                public const string UPDATE_Training = "SP_Update_TrainingMgt";
            }
        }

         public static class LocationDataConst
        {
            public static class SPNames
            {
                public const string UPDATE_LocationData = "usp_UpdateLocationData";
            }
        }
         public static class PassDataConst
         {
             public static class SPNames
             {
                 public const string UPDATE_PassData = "usp_UpdatePassData";
             }
         }
         public static class SOPDataConst
         {
             public static class SPNames
             {
                 public const string UPDATE_SOPData = "usp_UpdateSOPData";
             }
         }
         public static class KeyDataConst
         {
             public static class SPNames
             {
                 public const string UPDATE_KeyData = "usp_UpdateKeyData";
             }
         }
         public static class ShiftDataConst
         {
             public static class SPNames
             {
                 public const string UPDATE_ShiftData = "usp_UpdateShiftData";
             }
         }
         public static class Key1DataConst
         {
             public static class SPNames
             {
                 public const string DELETE_KeyData = "sp_DeleteKeyData";
             }
         }

         public static class Invetory
         {
             public static class SPNames
             {
                 public const string UPDATE_Inventory = "sp_UpdateInventoryAdmin";
             }
         }
   
         public static class VehicleConst
         {
             public static class SPNames
             {
                 public const string UPDATE_Vehicle = "sp_UpdateVehicleData";
             }
         }

         public static class UserConst
         {
             public static class SPNames
             {
                 public const string UPDATE_User = "sp_UpdateUser";
             }
         }


         public static class EventConst
         {
             public static class SPNames
             {
                 public const string UPDATE_Event = "sp_UpdateEvent";
             }
         }


         public static class IncidentConst
         {
             public static class SPNames
             {
                 public const string UPDATE_Incident = "sp_UpdateIncident";
             }
         }


         public static class AlertConst
         {
             public static class SPNames
             {
                 public const string UPDATE_Alert = "sp_UpdateAlert";
             }
         }


         public static class Visitor
         {
             public static class SPNames
             {
                 public const string UPDATE_Visitor = "sp_UpdateVisitor";
             }
         }
         public static class Contractor
         {
             public static class SPNames
             {
                 public const string UPDATE_Contractor = "sp_UpdateContractor";
             }
         }

         public static class Attendance
         {
             public static class SPNames
             {
                 public const string UPDATE_Attendance = "sp_UpdateAttendance";
             }
         }

         public void DeleteRecord(string RiskSurvey)
         {             
             DataSet dsRisk1 = dal.getdataset("Select Risk_id From "+RiskSurvey+" ");
             {
                 if (dsRisk1.Tables[0].Rows.Count > 0)
                 {
                     for (int j = 0; j < dsRisk1.Tables[0].Rows.Count; j++)
                     {
                         string RKid = dsRisk1.Tables[0].Rows[j][0].ToString();
                         DataSet dsRiskId = dal.getdataset("Select Risk_id from RiskSurvey16 Where Risk_id = '" + RKid + "'");
                         if (dsRiskId.Tables[0].Rows.Count > 0)
                         {
                         }
                         else
                         {
                             dal.executesql("Delete from " + RiskSurvey + " where Risk_id ='" + RKid + "' ");
                         }
                     }
                 }
             }
         }



    }
}
