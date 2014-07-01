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

namespace SMS.BusinessEntities
{
    [Serializable]
    public class GetUserData
    {
        String _dateFrom = string.Empty;
        String _UserID = string.Empty;
        String _UserPassword = string.Empty;
        String _FirstName = string.Empty;
        String _MiddleName = string.Empty;
        String _LastName = string.Empty;
        String _KinName = string.Empty;
        String _HomeAddress = string.Empty;
        String _City = string.Empty;
        String _State = string.Empty;
        String _Country = string.Empty;
        String _Mobile = string.Empty;
        String _Phone = string.Empty;
        String _Fax = string.Empty;
        String _EmailId = string.Empty;
        String _PostalCode = string.Empty;
        String _KinContactNo = string.Empty;
        String _NRICno = string.Empty;
        String _DOB = string.Empty;
        String _Role = string.Empty;
        String _UserSecretQues = string.Empty;
        String _UserSecretAns = string.Empty;
        String _UserStatus = string.Empty;
        String _Staff_ID = string.Empty;
        String _ImagePathName = string.Empty;
        String _whereClause = string.Empty;

        String _LastLoginTime = string.Empty;
        String _LastActivityTime = string.Empty;



        //String _Staff_ID = string.Empty;

        String _Staff_Name = string.Empty;
        String _Staff_Address = string.Empty;
        String _Staff_Telphone = string.Empty;
        String _Staff_HPno = string.Empty;
        String _Staff_DOB = string.Empty;
        String _Staff_POB = string.Empty;

        String _Staff_Race = string.Empty;
        String _Staff_NRICno = string.Empty;
        String _Staff_Citizenship = string.Empty;
        String _Staff_Age = string.Empty;
        String _Staff_Religion = string.Empty;
        String _Staff_Sex = string.Empty;
        String _Staff_DriverLicense = string.Empty;
        String _Staff_IncomeTax = string.Empty;
        String _Staff_MaritalStatus = string.Empty;

        String _Staff_NoOfChile = string.Empty;
        String _Staff_MarriedSpousName = string.Empty;
        String _Staff_EmergencyName = string.Empty;
        String _Staff_EmergencyAdd = string.Empty;
        String _Staff_EmergencyTelphone = string.Empty;
        String _Staff_PrimarySchoolName = string.Empty;
        String _Staff_PrimaryAddress = string.Empty;
        String _Staff_PrimaryLevel = string.Empty;
        String _Staff_PrimaryFrom = string.Empty;
        String _Staff_PrimaryTo = string.Empty;
        String _Staff_PrimaryQualification = string.Empty;

        String _Staff_SecondarySchoolName = string.Empty;
        String _Staff_SecondaryAddress = string.Empty;
        String _Staff_SecondaryLevel = string.Empty;
        String _Staff_SecondaryFrom = string.Empty;
        String _Staff_SecondaryTo = string.Empty;
        String _Staff_SecondaryQualification = string.Empty;

        String _Staff_VocationSchoolName = string.Empty;
        String _Staff_VocationAddress = string.Empty;
        String _Staff_VocationLevel = string.Empty;
        String _Staff_VocationFrom = string.Empty;
        String _Staff_VocationTo = string.Empty;
        String _Staff_VocationQualification = string.Empty;

        String _Staff_OtherSchoolName = string.Empty;
        String _Staff_OtherAddress = string.Empty;
        String _Staff_OtherLevel = string.Empty;
        String _Staff_OtherFrom = string.Empty;
        String _Staff_OtherTo = string.Empty;
        String _Staff_OtherQualification = string.Empty;
        String _Staff_OtherTraining = string.Empty;

        String _Staff_Hobbies = string.Empty;
        String _Staff_NSFrom = string.Empty;
        String _Staff_NSTo = string.Empty;
        String _Staff_NSTypeOfDischarge = string.Empty;
        String _Staff_NSVocation = string.Empty;
        String _Staff_NSNextInCamp = string.Empty;
        String _Staff_NSLastRank = string.Empty;
        String _Staff_NSExempted = string.Empty;
        String _Staff_NSReason = string.Empty;

        String _Staff_NSDateOFRegistration = string.Empty;
        String _Staff_EmpExCompName1 = string.Empty;
        String _Staff_EmpExFrom1 = string.Empty;
        String _Staff_EmpExTo1 = string.Empty;
        String _Staff_EmpExReasonLeaving1 = string.Empty;
        String _Staff_EmpExLastDrawnSalary1 = string.Empty;
        String _Staff_EmpExCompName2 = string.Empty;
        String _Staff_EmpExFrom2 = string.Empty;
        String _Staff_EmpExTo2 = string.Empty;
        String _Staff_EmpExReasonLeaving2 = string.Empty;
        String _Staff_EmpExLastDrawnSalary2 = string.Empty;

        String _Staff_EmpExCompName3 = string.Empty;
        String _Staff_EmpExFrom3 = string.Empty;
        String _Staff_EmpExTo3 = string.Empty;
        String _Staff_EmpExReasonLeaving3 = string.Empty;
        String _Staff_EmpExLastDrawnSalary3 = string.Empty;

        String _Staff_EmpExCompName4 = string.Empty;
        String _Staff_EmpExFrom4 = string.Empty;
        String _Staff_EmpExTo4 = string.Empty;
        String _Staff_EmpExReasonLeaving4 = string.Empty;
        String _Staff_EmpExLastDrawnSalary4 = string.Empty;

        String _Staff_ExpectedSalary = string.Empty;
        String _Staff_CommenceWork = string.Empty;
        String _Staff_LAW = string.Empty;
        String _Staff_LAWResion = string.Empty;

        String _Staff_Injury = string.Empty;
        String _Staff_InjuryResion = string.Empty;

        String _Staff_ComfirmPassword = string.Empty;
        String _Staff_Status = string.Empty;
        String _ThumbImage = string.Empty;

        String _Staff_MalasianWorkPermitExpire = string.Empty;
        String _Staff_MalasianPassportExpire = string.Empty;
        String _Staff_MalasianIC = string.Empty;
        String _Staff_MalasianOLDIC = string.Empty;
        String _Staff_MalasianPassportNo = string.Empty;
        String _Staff_MalasianWorkPermit = string.Empty;
        String _Staff_MalasianEducationLevel = string.Empty;

        String _Staff_NRICWorkPermitCertificate = string.Empty;
        String _Staff_NSRSWSQModulesCertificate = string.Empty;
        String _Staff_OtherRecognisedCertificate = string.Empty;
        String _Staff_ExemptionCertificate = string.Empty;
        String _Staff_SecurityOfficerLicenseCertificate = string.Empty;
        String _Staff_SIRDScreenCertificate = string.Empty;


        #region UserString

        public String Staff_ID
        {
            get
            {
                return _Staff_ID;
            }
            set
            {
                _Staff_ID = value;
            }
        }
        public String Date_From
        {
            get
            {
                return _dateFrom;
            }
            set
            {
                _dateFrom = value;
            }
        }
        public String WhereClause
        {
            get
            {
                return _whereClause;
            }
            set
            {
                _whereClause = value;
            }
        }
        public String UserID
        {
            get
            {
                return _UserID;
            }
            set
            {
                _UserID = value;
            }
        }
        public String UserPassword
        {
            get
            {
                return _UserPassword;
            }
            set
            {
                _UserPassword = value;
            }
        }
        public String FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                _FirstName = value;
            }
        }
        public String MiddleName
        {
            get
            {
                return _MiddleName;
            }
            set
            {
                _MiddleName = value;
            }
        }
        public String LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                _LastName = value;
            }
        }
        public String KinName
        {
            get
            {
                return _KinName;
            }
            set
            {
                _KinName = value;
            }
        }
        public String HomeAddress
        {
            get
            {
                return _HomeAddress;
            }
            set
            {
                _HomeAddress = value;
            }
        }
        public String City
        {
            get
            {
                return _City;
            }
            set
            {
                _City = value;
            }
        }
        public String State
        {
            get
            {
                return _State;
            }
            set
            {
                _State = value;
            }
        }
        public String Country
        {
            get
            {
                return _Country;
            }
            set
            {
                _Country = value;
            }
        }
        public String Mobile
        {
            get
            {
                return _Mobile;
            }
            set
            {
                _Mobile = value;
            }
        }
        public String Phone
        {
            get
            {
                return _Phone;
            }
            set
            {
                _Phone = value;
            }
        }
        public String Fax
        {
            get
            {
                return _Fax;
            }
            set
            {
                _Fax = value;
            }
        }
        public String EmailId
        {
            get
            {
                return _EmailId;
            }
            set
            {
                _EmailId = value;
            }
        }
        public String PostalCode
        {
            get
            {
                return _PostalCode;
            }
            set
            {
                _PostalCode = value;
            }
        }
        public String KinContactNo
        {
            get
            {
                return _KinContactNo;
            }
            set
            {
                _KinContactNo = value;
            }
        }
        public String NRICno
        {
            get
            {
                return _NRICno;
            }
            set
            {
                _NRICno = value;
            }
        }
        public String DOB
        {
            get
            {
                return _DOB;
            }
            set
            {
                _DOB = value;
            }
        }
        public String Role
        {
            get
            {
                return _Role;
            }
            set
            {
                _Role = value;
            }
        }
        public String UserSecretQues
        {
            get
            {
                return _UserSecretQues;
            }
            set
            {
                _UserSecretQues = value;
            }
        }
        public String UserSecretAns
        {
            get
            {
                return _UserSecretAns;
            }
            set
            {
                _UserSecretAns = value;
            }
        }
        public String UserStatus
        {
            get
            {
                return _UserStatus;
            }
            set
            {
                _UserStatus = value;
            }
        }
        public String ImagePathName
        {
            get
            {
                return _ImagePathName;
            }
            set
            {
                _ImagePathName = value;
            }
        }
        public String LastLoginTime
        {
            get
            {
                return _LastLoginTime;
            }
            set
            {
                _LastLoginTime = value;
            }
        }
        public String LastActivityTime
        {
            get
            {
                return _LastActivityTime;
            }
            set
            {
                _LastActivityTime = value;
            }
        }
        


        #endregion

        #region StaffString



        public String Staff_Name
        {
            get
            {
                return _Staff_Name;
            }
            set
            {
                _Staff_Name = value;
            }
        }
        public String Staff_Address
        {
            get
            {
                return _Staff_Address;
            }
            set
            {
                _Staff_Address = value;
            }
        }
        public String Staff_Telphone
        {
            get
            {
                return _Staff_Telphone;
            }
            set
            {
                _Staff_Telphone = value;
            }
        }
        public String Staff_HPno
        {
            get
            {
                return _Staff_HPno;
            }
            set
            {
                _Staff_HPno = value;
            }
        }
        public String Staff_DOB
        {
            get
            {
                return _Staff_DOB;
            }
            set
            {
                _Staff_DOB = value;
            }
        }
        public String Staff_POB
        {
            get
            {
                return _Staff_POB;
            }
            set
            {
                _Staff_POB = value;
            }
        }
        public String Staff_Race
        {
            get
            {
                return _Staff_Race;
            }
            set
            {
                _Staff_Race = value;
            }
        }
        public String Staff_NRICno
        {
            get
            {
                return _Staff_NRICno;
            }
            set
            {
                _Staff_NRICno = value;
            }
        }
        public String Staff_Citizenship
        {
            get
            {
                return _Staff_Citizenship;
            }
            set
            {
                _Staff_Citizenship = value;
            }
        }

        public String Staff_Age
        {
            get
            {
                return _Staff_Age;
            }
            set
            {
                _Staff_Age = value;
            }
        }
        public String Staff_Religion
        {
            get
            {
                return _Staff_Religion;
            }
            set
            {
                _Staff_Religion = value;
            }
        }
        public String Staff_Sex
        {
            get
            {
                return _Staff_Sex;
            }
            set
            {
                _Staff_Sex = value;
            }
        }
        public String Staff_DriverLicense
        {
            get
            {
                return _Staff_DriverLicense;
            }
            set
            {
                _Staff_DriverLicense = value;
            }
        }
        public String Staff_IncomeTax
        {
            get
            {
                return _Staff_IncomeTax;
            }
            set
            {
                _Staff_IncomeTax = value;
            }
        }
        public String Staff_MaritalStatus
        {
            get
            {
                return _Staff_MaritalStatus;
            }
            set
            {
                _Staff_MaritalStatus = value;
            }
        }
        public String Staff_NoOfChile
        {
            get
            {
                return _Staff_NoOfChile;
            }
            set
            {
                _Staff_NoOfChile = value;
            }
        }
        public String Staff_MarriedSpousName
        {
            get
            {
                return _Staff_MarriedSpousName;
            }
            set
            {
                _Staff_MarriedSpousName = value;
            }
        }
        public String Staff_EmergencyName
        {
            get
            {
                return _Staff_EmergencyName;
            }
            set
            {
                _Staff_EmergencyName = value;
            }
        }
        public String Staff_EmergencyAdd
        {
            get
            {
                return _Staff_EmergencyAdd;
            }
            set
            {
                _Staff_EmergencyAdd = value;
            }
        }
        public String Staff_EmergencyTelphone
        {
            get
            {
                return _Staff_EmergencyTelphone;
            }
            set
            {
                _Staff_EmergencyTelphone = value;
            }
        }

        public String Staff_PrimarySchoolName
        {
            get
            {
                return _Staff_PrimarySchoolName;
            }
            set
            {
                _Staff_PrimarySchoolName = value;
            }
        }
        public String Staff_PrimaryAddress
        {
            get
            {
                return _Staff_PrimaryAddress;
            }
            set
            {
                _Staff_PrimaryAddress = value;
            }
        }
        public String Staff_PrimaryLevel
        {
            get
            {
                return _Staff_PrimaryLevel;
            }
            set
            {
                _Staff_PrimaryLevel = value;
            }
        }
        public String Staff_PrimaryFrom
        {
            get
            {
                return _Staff_PrimaryFrom;
            }
            set
            {
                _Staff_PrimaryFrom = value;
            }
        }
        public String Staff_PrimaryTo
        {
            get
            {
                return _Staff_PrimaryTo;
            }
            set
            {
                _Staff_PrimaryTo = value;
            }
        }
        public String Staff_PrimaryQualification
        {
            get
            {
                return _Staff_PrimaryQualification;
            }
            set
            {
                _Staff_PrimaryQualification = value;
            }
        }

        public String Staff_SecondarySchoolName
        {
            get
            {
                return _Staff_SecondarySchoolName;
            }
            set
            {
                _Staff_SecondarySchoolName = value;
            }
        }
        public String Staff_SecondaryAddress
        {
            get
            {
                return _Staff_SecondaryAddress;
            }
            set
            {
                _Staff_SecondaryAddress = value;
            }
        }
        public String Staff_SecondaryLevel
        {
            get
            {
                return _Staff_SecondaryLevel;
            }
            set
            {
                _Staff_SecondaryLevel = value;
            }
        }
        public String Staff_SecondaryFrom
        {
            get
            {
                return _Staff_SecondaryFrom;
            }
            set
            {
                _Staff_SecondaryFrom = value;
            }
        }
        public String Staff_SecondaryTo
        {
            get
            {
                return _Staff_SecondaryTo;
            }
            set
            {
                _Staff_SecondaryTo = value;
            }
        }
        public String Staff_SecondaryQualification
        {
            get
            {
                return _Staff_SecondaryQualification;
            }
            set
            {
                _Staff_SecondaryQualification = value;
            }
        }

        public String Staff_VocationSchoolName
        {
            get
            {
                return _Staff_VocationSchoolName;
            }
            set
            {
                _Staff_VocationSchoolName = value;
            }
        }
        public String Staff_VocationAddress
        {
            get
            {
                return _Staff_VocationAddress;
            }
            set
            {
                _Staff_VocationAddress = value;
            }
        }
        public String Staff_VocationLevel
        {
            get
            {
                return _Staff_VocationLevel;
            }
            set
            {
                _Staff_VocationLevel = value;
            }
        }
        public String Staff_VocationFrom
        {
            get
            {
                return _Staff_VocationFrom;
            }
            set
            {
                _Staff_VocationFrom = value;
            }
        }
        public String Staff_VocationTo
        {
            get
            {
                return _Staff_VocationTo;
            }
            set
            {
                _Staff_VocationTo = value;
            }
        }
        public String Staff_VocationQualification
        {
            get
            {
                return _Staff_VocationQualification;
            }
            set
            {
                _Staff_VocationQualification = value;
            }
        }

        public String Staff_OtherSchoolName
        {
            get
            {
                return _Staff_OtherSchoolName;
            }
            set
            {
                _Staff_OtherSchoolName = value;
            }
        }
        public String Staff_OtherAddress
        {
            get
            {
                return _Staff_OtherAddress;
            }
            set
            {
                _Staff_OtherAddress = value;
            }
        }
        public String Staff_OtherLevel
        {
            get
            {
                return _Staff_OtherLevel;
            }
            set
            {
                _Staff_OtherLevel = value;
            }
        }
        public String Staff_OtherFrom
        {
            get
            {
                return _Staff_OtherFrom;
            }
            set
            {
                _Staff_OtherFrom = value;
            }
        }
        public String Staff_OtherTo
        {
            get
            {
                return _Staff_OtherTo;
            }
            set
            {
                _Staff_OtherTo = value;
            }
        }
        public String Staff_OtherQualification
        {
            get
            {
                return _Staff_OtherQualification;
            }
            set
            {
                _Staff_OtherQualification = value;
            }
        }

        public String Staff_OtherTraining
        {
            get
            {
                return _Staff_OtherTraining;
            }
            set
            {
                _Staff_OtherTraining = value;
            }
        }
        public String Staff_Hobbies
        {
            get
            {
                return _Staff_Hobbies;
            }
            set
            {
                _Staff_Hobbies = value;
            }
        }
        public String Staff_NSFrom
        {
            get
            {
                return _Staff_NSFrom;
            }
            set
            {
                _Staff_NSFrom = value;
            }
        }
        public String Staff_NSTo
        {
            get
            {
                return _Staff_NSTo;
            }
            set
            {
                _Staff_NSTo = value;
            }
        }
        public String Staff_NSTypeOfDischarge
        {
            get
            {
                return _Staff_NSTypeOfDischarge;
            }
            set
            {
                _Staff_NSTypeOfDischarge = value;
            }
        }
        public String Staff_NSVocation
        {
            get
            {
                return _Staff_NSVocation;
            }
            set
            {
                _Staff_NSVocation = value;
            }
        }
        public String Staff_NSNextInCamp
        {
            get
            {
                return _Staff_NSNextInCamp;
            }
            set
            {
                _Staff_NSNextInCamp = value;
            }
        }
        public String Staff_NSLastRank
        {
            get
            {
                return _Staff_NSLastRank;
            }
            set
            {
                _Staff_NSLastRank = value;
            }
        }

        public String Staff_NSExempted
        {
            get
            {
                return _Staff_NSExempted;
            }
            set
            {
                _Staff_NSExempted = value;
            }
        }
        public String Staff_NSReason
        {
            get
            {
                return _Staff_NSReason;
            }
            set
            {
                _Staff_NSReason = value;
            }
        }
        public String Staff_NSDateOFRegistration
        {
            get
            {
                return _Staff_NSDateOFRegistration;
            }
            set
            {
                _Staff_NSDateOFRegistration = value;
            }
        }

        public String Staff_EmpExCompName1
        {
            get
            {
                return _Staff_EmpExCompName1;
            }
            set
            {
                _Staff_EmpExCompName1 = value;
            }
        }
        public String Staff_EmpExFrom1
        {
            get
            {
                return _Staff_EmpExFrom1;
            }
            set
            {
                _Staff_EmpExFrom1 = value;
            }
        }
        public String Staff_EmpExTo1
        {
            get
            {
                return _Staff_EmpExTo1;
            }
            set
            {
                _Staff_EmpExTo1 = value;
            }
        }
        public String Staff_EmpExReasonLeaving1
        {
            get
            {
                return _Staff_EmpExReasonLeaving1;
            }
            set
            {
                _Staff_EmpExReasonLeaving1 = value;
            }
        }
        public String Staff_EmpExLastDrawnSalary1
        {
            get
            {
                return _Staff_EmpExLastDrawnSalary1;
            }
            set
            {
                _Staff_EmpExLastDrawnSalary1 = value;
            }
        }

        public String Staff_EmpExCompName2
        {
            get
            {
                return _Staff_EmpExCompName2;
            }
            set
            {
                _Staff_EmpExCompName2 = value;
            }
        }
        public String Staff_EmpExFrom2
        {
            get
            {
                return _Staff_EmpExFrom2;
            }
            set
            {
                _Staff_EmpExFrom2 = value;
            }
        }
        public String Staff_EmpExTo2
        {
            get
            {
                return _Staff_EmpExTo2;
            }
            set
            {
                _Staff_EmpExTo2 = value;
            }
        }
        public String Staff_EmpExReasonLeaving2
        {
            get
            {
                return _Staff_EmpExReasonLeaving2;
            }
            set
            {
                _Staff_EmpExReasonLeaving2 = value;
            }
        }
        public String Staff_EmpExLastDrawnSalary2
        {
            get
            {
                return _Staff_EmpExLastDrawnSalary2;
            }
            set
            {
                _Staff_EmpExLastDrawnSalary2 = value;
            }
        }


        public String Staff_EmpExCompName3
        {
            get
            {
                return _Staff_EmpExCompName3;
            }
            set
            {
                _Staff_EmpExCompName3 = value;
            }
        }
        public String Staff_EmpExFrom3
        {
            get
            {
                return _Staff_EmpExFrom3;
            }
            set
            {
                _Staff_EmpExFrom3 = value;
            }
        }
        public String Staff_EmpExTo3
        {
            get
            {
                return _Staff_EmpExTo3;
            }
            set
            {
                _Staff_EmpExTo3 = value;
            }
        }
        public String Staff_EmpExReasonLeaving3
        {
            get
            {
                return _Staff_EmpExReasonLeaving3;
            }
            set
            {
                _Staff_EmpExReasonLeaving3 = value;
            }
        }
        public String Staff_EmpExLastDrawnSalary3
        {
            get
            {
                return _Staff_EmpExLastDrawnSalary3;
            }
            set
            {
                _Staff_EmpExLastDrawnSalary3 = value;
            }
        }

        public String Staff_EmpExCompName4
        {
            get
            {
                return _Staff_EmpExCompName4;
            }
            set
            {
                _Staff_EmpExCompName4 = value;
            }
        }
        public String Staff_EmpExFrom4
        {
            get
            {
                return _Staff_EmpExFrom4;
            }
            set
            {
                _Staff_EmpExFrom4 = value;
            }
        }
        public String Staff_EmpExTo4
        {
            get
            {
                return _Staff_EmpExTo4;
            }
            set
            {
                _Staff_EmpExTo4 = value;
            }
        }
        public String Staff_EmpExReasonLeaving4
        {
            get
            {
                return _Staff_EmpExReasonLeaving4;
            }
            set
            {
                _Staff_EmpExReasonLeaving4 = value;
            }
        }
        public String Staff_EmpExLastDrawnSalary4
        {
            get
            {
                return _Staff_EmpExLastDrawnSalary4;
            }
            set
            {
                _Staff_EmpExLastDrawnSalary4 = value;
            }
        }


        public String Staff_ExpectedSalary
        {
            get
            {
                return _Staff_ExpectedSalary;
            }
            set
            {
                _Staff_ExpectedSalary = value;
            }
        }
        public String Staff_CommenceWork
        {
            get
            {
                return _Staff_CommenceWork;
            }
            set
            {
                _Staff_CommenceWork = value;
            }
        }
        public String Staff_LAW
        {
            get
            {
                return _Staff_LAW;
            }
            set
            {
                _Staff_LAW = value;
            }
        }
        public String Staff_LAWResion
        {
            get
            {
                return _Staff_LAWResion;
            }
            set
            {
                _Staff_LAWResion = value;
            }
        }

        public String Staff_Injury
        {
            get
            {
                return _Staff_Injury;
            }
            set
            {
                _Staff_Injury = value;
            }
        }
        public String Staff_InjuryResion
        {
            get
            {
                return _Staff_InjuryResion;
            }
            set
            {
                _Staff_InjuryResion = value;
            }
        }
        public String Staff_ComfirmPassword
        {
            get
            {
                return _Staff_ComfirmPassword;
            }
            set
            {
                _Staff_ComfirmPassword = value;
            }
        }
        public String Staff_Status
        {
            get
            {
                return _Staff_Status;
            }
            set
            {
                _Staff_Status = value;
            }
        }
        public String ThumbImage
        {
            get
            {
                return _ThumbImage;
            }
            set
            {
                _ThumbImage = value;
            }
        }

        public String Staff_MalasianWorkPermitExpire
        {
            get
            {
                return _Staff_MalasianWorkPermitExpire;
            }
            set
            {
                _Staff_MalasianWorkPermitExpire = value;
            }
        }
        public String Staff_MalasianPassportExpire
        {
            get
            {
                return _Staff_MalasianPassportExpire;
            }
            set
            {
                _Staff_MalasianPassportExpire = value;
            }
        }
        public String Staff_MalasianIC
        {
            get
            {
                return _Staff_MalasianIC;
            }
            set
            {
                _Staff_MalasianIC = value;
            }
        }
        public String Staff_MalasianOLDIC
        {
            get
            {
                return _Staff_MalasianOLDIC;
            }
            set
            {
                _Staff_MalasianOLDIC = value;
            }
        }
        public String Staff_MalasianPassportNo
        {
            get
            {
                return _Staff_MalasianPassportNo;
            }
            set
            {
                _Staff_MalasianPassportNo = value;
            }
        }
        public String Staff_MalasianWorkPermit
        {
            get
            {
                return _Staff_MalasianWorkPermit;
            }
            set
            {
                _Staff_MalasianWorkPermit = value;
            }
        }
        public String Staff_MalasianEducationLevel
        {
            get
            {
                return _Staff_MalasianEducationLevel;
            }
            set
            {
                _Staff_MalasianEducationLevel = value;
            }
        }

        public String Staff_NRICWorkPermitCertificate
        {
            get
            {
                return _Staff_NRICWorkPermitCertificate;
            }
            set
            {
                _Staff_NRICWorkPermitCertificate = value;
            }
        }
        public String Staff_NSRSWSQModulesCertificate
        {
            get
            {
                return _Staff_NSRSWSQModulesCertificate;
            }
            set
            {
                _Staff_NSRSWSQModulesCertificate = value;
            }
        }
        public String Staff_OtherRecognisedCertificate
        {
            get
            {
                return _Staff_OtherRecognisedCertificate;
            }
            set
            {
                _Staff_OtherRecognisedCertificate = value;
            }
        }
        public String Staff_ExemptionCertificate
        {
            get
            {
                return _Staff_ExemptionCertificate;
            }
            set
            {
                _Staff_ExemptionCertificate = value;
            }
        }
        public String Staff_SecurityOfficerLicenseCertificate
        {
            get
            {
                return _Staff_SecurityOfficerLicenseCertificate;
            }
            set
            {
                _Staff_SecurityOfficerLicenseCertificate = value;
            }
        }
        public String Staff_SIRDScreenCertificate
        {
            get
            {
                return _Staff_SIRDScreenCertificate;
            }
            set
            {
                _Staff_SIRDScreenCertificate = value;
            }
        }



        #endregion
    }
}
