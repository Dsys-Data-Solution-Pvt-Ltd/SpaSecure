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
using SMS.BusinessEntities.Main;
using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities;
using SMS.Services.DALUtilities;
using SMS.Services.DataService;
using System.Data.SqlClient;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Drawing;
using System.IO;

using log4net;
using log4net.Config;


namespace SMS.Services.BusinessServices
{
    public class AdminBLL
    {
        public DataSet GetMenuItems(GetAuthRequest argObj)
        {
            DataSet ds = null;
            AdminDAL objAdminDAL = null;
            try
            {
                objAdminDAL = new AdminDAL();
                ds = objAdminDAL.GetMenuItems(argObj);
                //Creating relation between menu parent and child.
                ds.DataSetName = "Menus";
            }

            catch (Exception ex)
            {
                throw ex;
            }
            return ds;

        }
        #region checkin

        public void AddCheckinGaurd(checkin objcheckin)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                objAdminDAL.AddCheckinGaurd(objcheckin);

            }
            catch (Exception es)
            {
                throw es;
            }
        }
        public void AddCheckinVisitor(checkin objcheckin)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                objAdminDAL.AddCheckinVisitor(objcheckin);
            }
            catch (Exception es)
            {
                throw es;
            }
        }
        public void AddCheckinContractor(checkin objcheckin)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                objAdminDAL.AddCheckinContractor(objcheckin);

            }
            catch (Exception es)
            {
                throw es;
            }
        }
        public void AddCheckinStaff(checkin objcheckin)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                objAdminDAL.AddCheckinStaff(objcheckin);

            }
            catch (Exception es)
            {
                throw es;
            }
        }

        #endregion

        #region checkout insert
        public void AddCheckOutGaurd(checkout objcheckout)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                objAdminDAL.AddCheckOutGaurd(objcheckout);

            }
            catch (Exception es)
            {
                throw es;
            }

        }
        public void AddCheckOutVisiter(checkout objcheckout)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                objAdminDAL.AddCheckOutVisitor(objcheckout);

            }
            catch (Exception es)
            {
                throw es;
            }

        }
        public void AddCheckOutSaleman(checkout objcheckout)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                objAdminDAL.AddCheckOutSaleman(objcheckout);
            }
            catch (Exception es)
            {
                throw es;
            }
        }
        public void AddCheckOutContractor(checkout objcheckout)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                objAdminDAL.AddCheckOutContractor(objcheckout);
            }
            catch (Exception es)
            {
                throw es;
            }
        }
        #endregion

        #region AddData

        public void AddUserIncident(UserIncident objUserIncident)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                objAdminDAL.AddUserIncident(objUserIncident);
            }
            catch (Exception es)
            {
                throw es;
            }
        }

        public void AddEvent(eventAdmin objeventman)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                objAdminDAL.AddEvent(objeventman);
            }
            catch (Exception es)
            {
                throw es;
            }
        }

        public void AddItem(ItemData objItem)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                //objAdminDAL.AddItem(objItem);
            }
            catch (Exception es)
            {
                throw es;
            }
        }

        public void AddUserPass(Pass objUserPass)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                objAdminDAL.AddUserPass(objUserPass);
            }
            catch (Exception es)
            {
                throw es;
            }
        }

        public void AddUserVehicle(Vehicle objUserVehicle)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                objAdminDAL.AddUserVehicle(objUserVehicle);
            }
            catch (Exception es)
            {
                throw es;
            }
        }

        public void AddUserShift(Shift objUserShift)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                objAdminDAL.AddUserShift(objUserShift);
            }
            catch (Exception es)
            {
                throw es;
            }
        }

        public void AddUserSOP(SOP objUserSOP)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                objAdminDAL.AddUserSOP(objUserSOP);
            }
            catch (Exception es)
            {
                throw es;
            }
        }

        public void Add_NewKey(AdminAddNewKey objAddNewKey)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                objAdminDAL.Add_NewKey(objAddNewKey);
            }
            catch (Exception cmsEx) { throw cmsEx; }

        }

        public void AddLocation(LocationData objlocation)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                objAdminDAL.AddLocation(objlocation);
            }
            catch (Exception es)
            {
                throw es;
            }
        }

        public void AddStaffShift(Staff_Shift objStaffShift)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                objAdminDAL.AddStaffShift(objStaffShift);
            }
            catch (Exception es)
            {
                throw es;
            }
        }

        public void AddAppointment(AppointmentSheduling objAppointment)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                objAdminDAL.AddAppointment(objAppointment);
            }
            catch (Exception es)
            {
                throw es;
            }
        }

        public void AddUserInfo(AddNewUserRequest objAddUserInfoRequest)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                objAdminDAL.AddUserInfo(objAddUserInfoRequest);
            }
            catch (Exception cmsEx) { throw cmsEx; }

        }

        public bool AuthenticateUser(GetAuthRequest argObj)
        {
            bool bAuth = false;

            try
            {
                AdminDAL objAdminDAL = new AdminDAL();

                List<GetAuthResponse> arr = objAdminDAL.AuthenticateUser(argObj);
                if (arr.Count > 0)
                {
                    bAuth = true;
                }


            }
            catch (Exception ex)
            {

            }
            return bAuth;
        }

        #endregion

        #region GetData

        public GetItemDataResponse GetItemData(GetItemData objGetItemDataRequest)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                GetItemDataResponse ret = new GetItemDataResponse();
                List<ItemData> lst = objAdminDAL.GetItemData(objGetItemDataRequest);
                ret.Item = lst;
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public LostFoundData GetLostFoundData(GetLostFoundData objGetLostFound)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                LostFoundData ret = new LostFoundData();
                List<LostFoundItem> lst = objAdminDAL.GetLostFoundData(objGetLostFound);
                ret.LostId= lst;
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public GetPassDataResponse GetPassDataBLL(GetPassDataNo objGetPassDataRequest)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                GetPassDataResponse ret = new GetPassDataResponse();
                List<PassNo> lst = objAdminDAL.GetPassDataDAL(objGetPassDataRequest);
                ret.Passcount = lst;
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GetUserDataResponse GetUserStaffInfo(GetUserData objGetUserInfoDataRequest)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                GetUserDataResponse ret = new GetUserDataResponse();

                List<User_Info> lst = objAdminDAL.GetUserStaffInfo(objGetUserInfoDataRequest);
                ret.Staff_ID = lst;
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public GetUserDataResponse GetUserStaffInfo1(GetUserData objGetUserInfoDataRequest)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                GetUserDataResponse ret = new GetUserDataResponse();

                List<User_Info> lst = objAdminDAL.GetUserStaffInfo1(objGetUserInfoDataRequest);
                ret.Staff_ID = lst;
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void DeleteStaffToPresent(DeleteUserRequest argObj)
        {
            try
            {
                AdminDAL ws = new AdminDAL();
                ws.DeleteStaff_Present(argObj);
            }
            catch (Exception ex)
            {

            }
        }

        public GetPassDataResponse GetPassData(GetPassData objGetPassDataRequest)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                GetPassDataResponse ret = new GetPassDataResponse();
                List<Pass> lst = objAdminDAL.GetPassData(objGetPassDataRequest);
                ret.Pass = lst;
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public GetPassDataResponse GetPassData2(GetPassData objGetPassDataRequest)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                GetPassDataResponse ret = new GetPassDataResponse();
                List<Pass> lst = objAdminDAL.GetPassData2(objGetPassDataRequest);
                ret.Pass = lst;
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GetSOPDataResponse GetSOPData(GetSOPData objGetSOPDataRequest)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                GetSOPDataResponse ret = new GetSOPDataResponse();
                List<SOP> lst = objAdminDAL.GetSOPData(objGetSOPDataRequest);
                ret.SOPNo = lst;
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GetSOPDataResponse GetAllSOPData(GetSOPData objGetSOPDataRequest)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                GetSOPDataResponse ret = new GetSOPDataResponse();
                List<SOP> lst = objAdminDAL.GetAllSOPData(objGetSOPDataRequest);
                ret.SOPNo = lst;
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public GetNewKeyRequest GetNewKey(GetNewKey objGetNewKeyRequest)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                GetNewKeyRequest ret = new GetNewKeyRequest();
                List<AdminAddNewKey> lst = objAdminDAL.GetNewKey(objGetNewKeyRequest);
                ret.Key = lst;
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GetUserDataResponse GetShiftKey(GetStaffShift objGetShiftRequest)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                GetUserDataResponse ret = new GetUserDataResponse();
                List<User_Info> lst = objAdminDAL.GetStaffShiftKey(objGetShiftRequest);
                ret.UserID = lst;
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GetLocationDataResponse GetLocationData(GetLocationData objGetLocationDataRequest)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                GetLocationDataResponse ret = new GetLocationDataResponse();
                List<LocationData> lst = objAdminDAL.GetLocationData(objGetLocationDataRequest);
                ret.Location = lst;

                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GetDataEventResponse GetEventData(GetDataEvent objGetNewEventRequest)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                GetDataEventResponse ret = new GetDataEventResponse();
                List<eventAdmin> lst = objAdminDAL.GetEventData(objGetNewEventRequest);
                ret.Eventid = lst;
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GetShiftDataResponse GetShift(GetShiftData objGetNewShiftRequest)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                GetShiftDataResponse ret = new GetShiftDataResponse();
                List<Shift> lst = objAdminDAL.GetShift(objGetNewShiftRequest);
                ret.Shift_ID = lst;
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetAuthenticateUserRoleAndID(GetAuthRequest argObj)
        {
            string userRole = string.Empty;

            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                string arr = objAdminDAL.GetAuthenticateUserRoleAndID(argObj);
                userRole = arr;

            }
            catch (Exception ex)
            {

            }
            return (userRole);
        }

        public GetIncidentDataResponse GetIncidentData(GetIncidentData objGetIncidentDataRequest)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                GetIncidentDataResponse ret = new GetIncidentDataResponse();

                List<UserIncident> lst = objAdminDAL.GetIncidentData(objGetIncidentDataRequest);
                ret.Incident = lst;
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GetContractorDataResponse GetStaffData(GetContractorData objGetContractorDataRequest)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                GetContractorDataResponse ret = new GetContractorDataResponse();

                List<Contractor> lst = objAdminDAL.GetStaffData(objGetContractorDataRequest);
                ret.Contractor = lst;
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GetContractorDataResponse GetStaffData1(GetContractorData objGetContractorDataRequest)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                GetContractorDataResponse ret = new GetContractorDataResponse();

                List<Contractor> lst = objAdminDAL.GetStaffData1(objGetContractorDataRequest);
                ret.Contractor = lst;
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GetContractorDataResponse GetGuardData(GetContractorData objGetContractorDataRequest)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                GetContractorDataResponse ret = new GetContractorDataResponse();

                List<Contractor> lst = objAdminDAL.GetGuardData(objGetContractorDataRequest);
                ret.Contractor = lst;
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public GetContractorDataResponse GetContractorDataForCurrentTime(GetContractorData objGetContractorDataRequest)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                GetContractorDataResponse ret = new GetContractorDataResponse();

                List<Contractor> lst = objAdminDAL.GetContractorDataForCurrentTime(objGetContractorDataRequest);
                ret.Contractor = lst;
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetCheckInData(GetContractorData objReq)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                GetContractorDataResponse ret = new GetContractorDataResponse();

                DataTable lst = objAdminDAL.GetCheckInData(objReq);
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetContractorData(GetContractorData objGetContractorDataRequest)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                GetContractorDataResponse ret = new GetContractorDataResponse();

                DataTable lst = objAdminDAL.GetContractorData(objGetContractorDataRequest);
               // ret.Contractor = lst;
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public GetContractorDataResponse GetContractorData(GetContractorData objGetContractorDataRequest)
        //{
        //    try
        //    {
        //        AdminDAL objAdminDAL = new AdminDAL();
        //        GetContractorDataResponse ret = new GetContractorDataResponse();

        //        List<Contractor> lst = objAdminDAL.GetContractorData(objGetContractorDataRequest);
        //        ret.Contractor = lst;
        //        return ret;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public GetContractorDataResponse GetContractorData1(GetContractorData objGetContractorDataRequest)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                GetContractorDataResponse ret = new GetContractorDataResponse();

                List<Contractor> lst = objAdminDAL.GetContractorData1(objGetContractorDataRequest);
                ret.Contractor = lst;
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public GetContractorDataResponse GetContractorData2(GetContractorData objGetContractorDataRequest)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                GetContractorDataResponse ret = new GetContractorDataResponse();

                List<Contractor> lst = objAdminDAL.GetContractorData2(objGetContractorDataRequest);
                ret.Contractor = lst;
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //====================Changes by Shakil=========================================


        public GetOMVisitorDataResponse GetOMVisitorDataCurrentReport(GetOMVisitorData objGetVisitorDataRequest)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                GetOMVisitorDataResponse ret = new GetOMVisitorDataResponse();

                List<Visitor> lst = objAdminDAL.GetOMVisitorDataCurrentReport(objGetVisitorDataRequest);
                ret.OMVisitor = lst;
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        public GetOMVisitorDataResponse GetOMVisitorData(GetOMVisitorData objGetVisitorDataRequest)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                GetOMVisitorDataResponse ret = new GetOMVisitorDataResponse();

                List<Visitor> lst = objAdminDAL.GetOMVisitorData(objGetVisitorDataRequest);
                ret.OMVisitor = lst;
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //============================Changes end by Shakil=======================================


        public GetVisitorDataResponse GetVisitorData(GetVisitorData objGetVisitorDataRequest)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                GetVisitorDataResponse ret = new GetVisitorDataResponse();

                List<Visitor> lst = objAdminDAL.GetVisitorData(objGetVisitorDataRequest);
                ret.Visitor = lst;
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GetVisitorDataResponse GetVisitorDataCurrentReport(GetVisitorData objGetVisitorDataRequest)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                GetVisitorDataResponse ret = new GetVisitorDataResponse();

                List<Visitor> lst = objAdminDAL.GetVisitorDataCurrentReport(objGetVisitorDataRequest);
                ret.Visitor = lst;
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public GetVisitorDataResponse GetVisitorData1(GetVisitorData objGetVisitorDataRequest)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                GetVisitorDataResponse ret = new GetVisitorDataResponse();

                List<Visitor> lst = objAdminDAL.GetVisitorData1(objGetVisitorDataRequest);
                ret.Visitor = lst;
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GetUserDataResponse GetUserInfoData(GetUserData objGetUserInfoDataRequest)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                GetUserDataResponse ret = new GetUserDataResponse();

                List<User_Info> lst = objAdminDAL.GetUserInfoData(objGetUserInfoDataRequest);
                ret.UserID = lst;
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GetVehicleDataResponse GetVehicleData(GetVehicleData objGetVehicleDataRequest)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                GetVehicleDataResponse ret = new GetVehicleDataResponse();

                List<Vehicle> lst = objAdminDAL.GetVehicleData(objGetVehicleDataRequest);
                ret.Vehicle = lst;
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GetChiekinDataResponse Getcheckin(GetCheckinData objGetVehicleDataRequest)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                GetChiekinDataResponse ret = new GetChiekinDataResponse();

                List<checkin> lst = objAdminDAL.Getcheckin(objGetVehicleDataRequest);
                ret.checkinid = lst;
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region UpdateData

        public void UpdateItemData(ItemData objItemData)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                //objAdminDAL.UpdateItemData(objItemData);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateLocationData(LocationData objLocationData)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                objAdminDAL.UpdateLocationData(objLocationData);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdatePassData(Pass objPassData)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                objAdminDAL.UpdatePassData(objPassData);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateSOPData(SOP objSOPData)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                objAdminDAL.UpdateSOPData(objSOPData);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Updatevehicle(Vehicle objvehicle)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                objAdminDAL.Updatevehicle(objvehicle);

            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateKeyData(AdminAddNewKey objKeyData)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                objAdminDAL.UpdateKeyData(objKeyData);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Updateuser(User_Info objuser)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                objAdminDAL.Updateuser(objuser);

            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateShiftData(Shift objShiftData)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                objAdminDAL.UpdateShiftData(objShiftData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Updatevent(eventAdmin objevent)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                objAdminDAL.Updateevent(objevent);

            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Updatincident(UserIncident objincident)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                objAdminDAL.Updatincident(objincident);


            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Updatvisotor(Visitor objvisitor)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();

                objAdminDAL.Updatevisitor(objvisitor);


            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Updatecontractor(Contractor objcontractor)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                objAdminDAL.Updatecontractor(objcontractor);

            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateAttendance(Contractor objcontractor)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                objAdminDAL.UpdateAttendance(objcontractor);

            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region DeleteData

        public void DeleteItem(DeleteItemRequest argObj)
        {
            try
            {
                AdminDAL ws = new AdminDAL();
                ws.DeleteItem(argObj);
            }
            catch (Exception ex)
            {

            }
        }

        public void Deletelocation(DeleteLocationRequest argObj)
        {
            try
            {
                AdminDAL ws = new AdminDAL();
                ws.DeleteLocationUser(argObj);
            }
            catch (Exception ex)
            {

            }
        }

        public void DeletePass(DeletePassRequest argObj)
        {
            try
            {
                AdminDAL ws = new AdminDAL();
                ws.DeletePassUser(argObj);
            }
            catch (Exception ex)
            {

            }
        }

        public void DeleteKey(DeleteKeyRequest argObj)
        {
            try
            {
                AdminDAL ws = new AdminDAL();
                ws.DeleteKeyUser(argObj);
            }
            catch (Exception ex)
            {

            }
        }

        public void DeleteSOP(DeleteSOPRequest argObj)
        {
            try
            {
                AdminDAL ws = new AdminDAL();
                ws.DeleteSOPUser(argObj);
            }
            catch (Exception ex)
            {

            }
        }

        public void DeleteShift(DeleteShiftRequest argObj)
        {
            try
            {
                AdminDAL ws = new AdminDAL();
                ws.DeleteShiftUser(argObj);
            }
            catch (Exception ex)
            {

            }
        }

        public void DeleteShiftStaff(GetStaffShift argObj)
        {
            try
            {
                AdminDAL ws = new AdminDAL();
                ws.DeleteShiftStaff(argObj);
            }
            catch (Exception ex)
            {

            }
        }

        public void DeleteEvent(DeleteEventPlannerRequest argObj)
        {
            try
            {
                AdminDAL ws = new AdminDAL();
                ws.DeleteEventUser(argObj);
            }
            catch (Exception ex)
            {

            }
        }

        public void DeleteContractor(DeleteContractorRequest argObj)
        {
            try
            {
                AdminDAL ws = new AdminDAL();
                ws.DeleteContractorUser(argObj);
            }
            catch (Exception ex)
            {

            }
        }

        public void DeleteUser(DeleteUserRequest argObj)
        {
            try
            {
                AdminDAL ws = new AdminDAL();



                ws.DeleteUser(argObj);
            }
            catch (Exception ex)
            {

            }
        }

        public void DeleteVehicle(DeleteVehicleRequest argObj)
        {
            try
            {
                AdminDAL ws = new AdminDAL();
                ws.DeleteVehicle(argObj);
            }
            catch (Exception ex)
            {

            }
        }

        public void DeleteIncident(DeleteIncidentRequest argObj)
        {
            try
            {
                AdminDAL ws = new AdminDAL();
                ws.DeleteIncident(argObj);
            }
            catch (Exception ex)
            {

            }
        }

        public void DeleteKeyData(AdminAddNewKey objKeyData)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                objAdminDAL.UpdateKeyData(objKeyData);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion


        #region isexist


        public bool isexistBLL(string c, string t, string w)
        {

            AdminDAL objAdminDAL = new AdminDAL();

            string bllstrsql = "select count (" + c + " ) As count from " + t + " with(nolock) " + w + " ";
            if (objAdminDAL.isexistDAL(bllstrsql))
            {
                return true;
            }
            return false;

        }
        public bool isAutogenBLL(string c, string t, string w)
        {

            AdminDAL objAdminDAL = new AdminDAL();

            string bllstrsql = "Update " + t + " Set " + c + " " + w + " ";
            if (objAdminDAL.isexistDAL(bllstrsql))
            {
                return true;
            }
            return false;

        }






        #endregion

        public void DeleteUserStaff(DeleteUserRequest argObj)
        {
            try
            {
                AdminDAL ws = new AdminDAL();
                ws.DeleteUserStaff(argObj);
            }
            catch (Exception ex)
            {

            }
        }

        public void DeleteInventory(DeleteInventoryRequest argObj)
        {
            try
            {
                AdminDAL ws = new AdminDAL();
                ws.DeleteInventoryUser(argObj);
            }
            catch (Exception ex)
            {

            }
        }


        public void UpdateInventoryData(AddNewInventory objinventoryData)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                objAdminDAL.UpdateInventoryData(objinventoryData);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }



        public GetInventoryResponce GetInventoryData(GetInventoryData objGetItemDataRequest)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                GetInventoryResponce ret = new GetInventoryResponce();
                List<AddNewInventory> lst = objAdminDAL.GetIenvenData(objGetItemDataRequest);
                ret.Itemid = lst;

                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void AddNewInventory(AddNewInventory objAddNewInventoryRequest)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                objAdminDAL.Add_NewInventory(objAddNewInventoryRequest);
            }
            catch (Exception cmsEx) { throw cmsEx; }

        }

        public void DeleteTraining(DeleteTrainingRequest argObj)
        {
            try
            {
                AdminDAL ws = new AdminDAL();
                ws.DeleteTrainingUser(argObj);
            }
            catch (Exception ex)
            {

            }
        }

        public void UpdateTrainingData(AddTraining objTrainingData)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                objAdminDAL.UpdateTrainingData(objTrainingData);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GetTrainingResponse GetTrainingData(GetTrainingData objGetTrainingRequest)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                GetTrainingResponse ret = new GetTrainingResponse();
                List<AddTraining> lst = objAdminDAL.GetTrainingData(objGetTrainingRequest);
                ret.Trainingid = lst;

                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddTraining(AddTraining objAddNewTrainingRequest)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                objAdminDAL.Add_NewTraining(objAddNewTrainingRequest);
            }
            catch (Exception cmsEx) { throw cmsEx; }

        }

        public void Updatalert(AlertHandlingUser objalert)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                objAdminDAL.Updatalert(objalert);

            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteAlert(DeleteAlertRequest argObj)
        {
            try
            {
                AdminDAL ws = new AdminDAL();
                ws.DeleteAlertUser(argObj);
            }
            catch (Exception ex)
            {

            }
        }


        public GetAlertDataResponse GetAlertData(GetAlertData objGetAlertDataRequest)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                GetAlertDataResponse ret = new GetAlertDataResponse();

                List<AlertHandlingUser> lst = objAdminDAL.GetAlertData(objGetAlertDataRequest);
                ret.Alert_ID = lst;
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddAlertHandling(AlertHandlingUser objAlertHandling)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                objAdminDAL.AddAlertHandling(objAlertHandling);
            }

            catch (Exception es)
            {
                throw es;
            }
        }

        public GetCheckInkeyResponse GetCheckInkey(GetCheckInKey objGetKeyRequest)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                GetCheckInkeyResponse ret = new GetCheckInkeyResponse();
                List<CheckInKeyData> lst = objAdminDAL.GetCheckInkeyData(objGetKeyRequest);
                ret.CheckIn_id = lst;
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GetCourseEvaluationResponse GetCourseEvaluationData(GetCourseEvaluationData objGetCourseEvaluationDataRequest)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                GetCourseEvaluationResponse ret = new GetCourseEvaluationResponse();
                List<CourseEvaluation> lst = objAdminDAL.GetCourseEvaluationData(objGetCourseEvaluationDataRequest);
                ret.Evaluation = lst;

                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GetClientVisitResponse GetClientVisitData(GetClientVisitMinutesData objGetClientVisitMinutesDataRequest)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                GetClientVisitResponse ret = new GetClientVisitResponse();
                List<ClientVisitMinutes> lst = objAdminDAL.GetClientVisitMinutesData(objGetClientVisitMinutesDataRequest);
                ret.Visit = lst;

                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GetPenaltyClauseResponse GetPenaltyClausetData(GetPenaltyClauseData objGetPenaltyClauseDataRequest)
        {
            try
            {
                AdminDAL objAdminDAL = new AdminDAL();
                GetPenaltyClauseResponse ret = new GetPenaltyClauseResponse();
                List<PenaltyClause> lst = objAdminDAL.GetPenaltyClauseData(objGetPenaltyClauseDataRequest);
                ret.Penalty = lst;

                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateClientVisitMinutes(ClientVisitMinutes objClientVisitMinutes)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.ClientVisitMinutes.SPNames.UPDATE_ClientVisitMinutes);


                db.AddInParameter(dbCommand, "@strAssignment", DbType.String, objClientVisitMinutes.strAssignment);
                db.AddInParameter(dbCommand, "@strMetWith", DbType.String, objClientVisitMinutes.strMetWith);
                db.AddInParameter(dbCommand, "@strCompletedBy", DbType.String, objClientVisitMinutes.strCompletedBy);

                db.AddInParameter(dbCommand, "@strComplaints", DbType.String, objClientVisitMinutes.strComplaints);
                db.AddInParameter(dbCommand, "@strPositiveComments", DbType.String, objClientVisitMinutes.strPositiveComments);
                db.AddInParameter(dbCommand, "@strDeployment", DbType.String, objClientVisitMinutes.strDeployment);
                db.AddInParameter(dbCommand, "@strEvents", DbType.String, objClientVisitMinutes.strEvents);
                db.AddInParameter(dbCommand, "@strRemarks", DbType.String, objClientVisitMinutes.strRemarks);

                db.AddInParameter(dbCommand, "@dtmDateMet", DbType.Date, objClientVisitMinutes.dtmDateMet);

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

        public void UpdateAssignmentVisit(AssignmentVisit objAssignmentVisit)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.AssignmentVisit.SPNames.UPDATE_AssignmentVisit);


                db.AddInParameter(dbCommand, "@strTo", DbType.String, objAssignmentVisit.strTo);
                db.AddInParameter(dbCommand, "@strSubmittedBy", DbType.String, objAssignmentVisit.strSubmittedBy);
                db.AddInParameter(dbCommand, "@strNameOfAssignment", DbType.String, objAssignmentVisit.strNameOfAssignment);

                db.AddInParameter(dbCommand, "@strInCharge", DbType.String, objAssignmentVisit.strInCharge);
                db.AddInParameter(dbCommand, "@strGuards", DbType.String, objAssignmentVisit.strDressing);
                db.AddInParameter(dbCommand, "@strDressing", DbType.String, objAssignmentVisit.strDeployment);
                db.AddInParameter(dbCommand, "@strAppearance", DbType.String, objAssignmentVisit.strAppearance);
                db.AddInParameter(dbCommand, "@strHaircut", DbType.String, objAssignmentVisit.strHaircut);
                db.AddInParameter(dbCommand, "@strAlertness", DbType.String, objAssignmentVisit.strAlertness);
                db.AddInParameter(dbCommand, "@strDeployment", DbType.String, objAssignmentVisit.strDeployment);
                db.AddInParameter(dbCommand, "@strGeneralPerformance", DbType.String, objAssignmentVisit.strGeneralPerformance);
                db.AddInParameter(dbCommand, "@strOtherMatters", DbType.String, objAssignmentVisit.strOtherMatters);
                db.AddInParameter(dbCommand, "@strConclussion", DbType.String, objAssignmentVisit.strConclussion);
                db.AddInParameter(dbCommand, "@strRecommendation", DbType.String, objAssignmentVisit.strRecommendation);
                db.AddInParameter(dbCommand, "@dtmDateVisit", DbType.Date, objAssignmentVisit.dtmDateVisit);

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

      
        public void FilldefaultValues()
        {
            DataAccessLayer objAdminDAL = new DataAccessLayer();
            DataSet dsfill = objAdminDAL.getdataset("Select * from Setting");
            if (dsfill.Tables[0].Rows.Count > 0)
            {


                //HttpContext.Current.Items.Add(ContextKeys.imagelogo, dsfill.Tables[0].Rows[0]["Image_Logo"].ToString());
                // HttpContext.Current.Items.Add(ContextKeys.title, dsfill.Tables[0].Rows[0]["Title"].ToString());
                HttpContext.Current.Items.Add("Welcome_heading", dsfill.Tables[0].Rows[0]["Welcome_heading"].ToString());
                //HttpContext.Current.Items.Add(ContextKeys.Welcome_title,dsfill.Tables[0].Rows[0]["Welcome_title"].ToString());
                //HttpContext.Current.Items.Add(ContextKeys.Welcome_title2,dsfill.Tables[0].Rows[0]["Welcome_title2"].ToString());
                //HttpContext.Current.Items.Add(ContextKeys.Title_header,dsfill.Tables[0].Rows[0]["Title_header"].ToString());
                //HttpContext.Current.Items.Add(ContextKeys.ClientFeedback_Online,dsfill.Tables[0].Rows[0]["ClientFeedback_Online"].ToString());
                //HttpContext.Current.Items.Add(ContextKeys.ClientFeedback_Help,dsfill.Tables[0].Rows[0]["ClientFeedback_Help"].ToString());
                //HttpContext.Current.Items.Add(ContextKeys.ClientFeedback_Analysis,dsfill.Tables[0].Rows[0]["ClientFeedback_Analysis"].ToString());
                //HttpContext.Current.Items.Add(ContextKeys.ClientFeedback_pvt,dsfill.Tables[0].Rows[0]["ClientFeedback_pvt"].ToString());
                //HttpContext.Current.Items.Add(ContextKeys.ClientFeedback_MDirtector,dsfill.Tables[0].Rows[0]["ClientFeedback_ManagingDirtector"].ToString());

            }
        }

        //public DataTable GetCheckInData(GetVisitorData objReq)
        //{
        //    throw new NotImplementedException();
        //}

        //public GetVisitorDataResponse GetStaffData1(GetVisitorData objReq)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
