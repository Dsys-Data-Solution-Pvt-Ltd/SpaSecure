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
using System.Text.RegularExpressions;
using SMS.BusinessEntities.Main;

using Microsoft.Practices.EnterpriseLibrary;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System.Collections.Generic;


namespace SMS.BusinessEntities.Main
{
    [Serializable]
    [HasSelfValidation]
    public class User_Info
    {
        [RegexValidator(RegexConsts.UserIDRegex, MessageTemplate = RegexConsts.UserNameConstant)]
        public String UserID { get; set; }

        [StringLengthValidator(4, 16, MessageTemplate = RegexConsts.UserPassword)]
        public String UserPassword { get; set; }


        [RegexValidator(RegexConsts.CommonNameRegex, MessageTemplate = RegexConsts.FNameConstant)]
        public String FirstName { get; set; }
        public String MiddleName { get; set; }

        [RegexValidator(RegexConsts.CommonNameRegex, MessageTemplate = RegexConsts.LNameConstant)]
        public String LastName { get; set; }
        public String KinName { get; set; }
        public String HomeAddress { get; set; }

        [ContainsCharactersValidator("0123456789!@#$%^*", ContainsCharacters.Any, Negated = true, MessageTemplate = "Only alphabets allowed for City.")]
        public String City { get; set; }

        [ContainsCharactersValidator("0123456789!@#$%^*", ContainsCharacters.Any, Negated = true, MessageTemplate = "Only alphabets allowed for State.")]
        public String State { get; set; }
        public String Country { get; set; }
        public String Mobile { get; set; }

        [RegexValidator(RegexConsts.PhoneNoRegex, MessageTemplate = RegexConsts.PhNoConstant)]
        public String Phone { get; set; }
        public String Fax { get; set; }

        [RegexValidator(RegexConsts.EmailRegex, MessageTemplate = RegexConsts.EmailConstant)]
        public String EmailId { get; set; }
        public String PostalCode { get; set; }
        public String KinContactNo { get; set; }
        public String NRICno { get; set; }
        public String DOB { get; set; }
        public String Role { get; set; }
        public String Staff_ID { get; set; }

        public String UserSecretQues { get; set; }
        public String UserSecretAns { get; set; }
        public String UserStatus { get; set; }
        public String UserGrpDesc { get; set; }
        public String SecQuesDesc { get; set; }
        public String UserStatusDesc { get; set; }
        public String ImagePathName { get; set; }
        public String ManagementRole { get; set; }

        public DateTime? LastLoginTime { get; set; }
        public DateTime? LastActivityTime { get; set; }

        public String Staff_PreName { get; set; }
        public String Staff_Name { get; set; }
        public String Staff_Address { get; set; }
        public String Staff_Telphone { get; set; }
        public String Staff_HPno { get; set; }
        public String Staff_DOB { get; set; }
        public String Staff_POB { get; set; }

        public String Staff_Race { get; set; }
        public String Staff_NRICno { get; set; }
        public String Staff_Citizenship { get; set; }
        public String Staff_Age { get; set; }
        public String Staff_Religion { get; set; }
        public String Staff_Sex { get; set; }
        public String Staff_DriverLicense { get; set; }
        public String Staff_IncomeTax { get; set; }
        public String Staff_MaritalStatus { get; set; }

        public String Staff_NoOfChile { get; set; }
        public String Staff_MarriedSpousName { get; set; }
        public String Staff_EmergencyName { get; set; }
        public String Staff_EmergencyAdd { get; set; }
        public String Staff_EmergencyTelphone { get; set; }
        public String Staff_PrimarySchoolName { get; set; }
        public String Staff_PrimaryAddress { get; set; }
        public String Staff_PrimaryLevel { get; set; }
        public String Staff_PrimaryFrom { get; set; }
        public String Staff_PrimaryTo { get; set; }
        public String Staff_PrimaryQualification { get; set; }

        public String Staff_SecondarySchoolName { get; set; }
        public String Staff_SecondaryAddress { get; set; }
        public String Staff_SecondaryLevel { get; set; }
        public String Staff_SecondaryFrom { get; set; }
        public String Staff_SecondaryTo { get; set; }
        public String Staff_SecondaryQualification { get; set; }

        public String Staff_VocationSchoolName { get; set; }
        public String Staff_VocationAddress { get; set; }
        public String Staff_VocationLevel { get; set; }
        public String Staff_VocationFrom { get; set; }
        public String Staff_VocationTo { get; set; }
        public String Staff_VocationQualification { get; set; }

        public String Staff_OtherSchoolName { get; set; }
        public String Staff_OtherAddress { get; set; }
        public String Staff_OtherLevel { get; set; }
        public String Staff_OtherFrom { get; set; }
        public String Staff_OtherTo { get; set; }
        public String Staff_OtherQualification { get; set; }
        public String Staff_OtherTraining { get; set; }

        public String Staff_Hobbies { get; set; }
        public String Staff_NSFrom { get; set; }
        public String Staff_NSTo { get; set; }
        public String Staff_NSTypeOfDischarge { get; set; }
        public String Staff_NSVocation { get; set; }
        public String Staff_NSNextInCamp { get; set; }
        public String Staff_NSLastRank { get; set; }
        public String Staff_NSExempted { get; set; }
        public String Staff_NSReason { get; set; }

        public String Staff_NSDateOFRegistration { get; set; }
        public String Staff_EmpExCompName1 { get; set; }
        public String Staff_EmpExFrom1 { get; set; }
        public String Staff_EmpExTo1 { get; set; }
        public String Staff_EmpExReasonLeaving1 { get; set; }
        public String Staff_EmpExLastDrawnSalary1 { get; set; }
        public String Staff_EmpExCompName2 { get; set; }
        public String Staff_EmpExFrom2 { get; set; }
        public String Staff_EmpExTo2 { get; set; }
        public String Staff_EmpExReasonLeaving2 { get; set; }
        public String Staff_EmpExLastDrawnSalary2 { get; set; }

        public String Staff_EmpExCompName3 { get; set; }
        public String Staff_EmpExFrom3 { get; set; }
        public String Staff_EmpExTo3 { get; set; }
        public String Staff_EmpExReasonLeaving3 { get; set; }
        public String Staff_EmpExLastDrawnSalary3 { get; set; }

        public String Staff_EmpExCompName4 { get; set; }
        public String Staff_EmpExFrom4 { get; set; }
        public String Staff_EmpExTo4 { get; set; }
        public String Staff_EmpExReasonLeaving4 { get; set; }
        public String Staff_EmpExLastDrawnSalary4 { get; set; }

        public String Staff_ExpectedSalary { get; set; }
        public String Staff_CommenceWork { get; set; }
        public String Staff_LAW { get; set; }
        public String Staff_LAWResion { get; set; }

        public String Staff_Injury { get; set; }
        public String Staff_InjuryResion { get; set; }

        public String Staff_ComfirmPassword { get; set; }
        public String Staff_Status { get; set; }
        public String ThumbImage { get; set; }

        public String Staff_MalasianWorkPermitExpire { get; set; }
        public String Staff_MalasianPassportExpire { get; set; }
        public String Staff_MalasianIC { get; set; }
        public String Staff_MalasianOLDIC { get; set; }
        public String Staff_MalasianPassportNo { get; set; }
        public String Staff_MalasianWorkPermit { get; set; }
        public String Staff_MalasianEducationLevel { get; set; }

        public String Staff_NRICWorkPermitCertificate { get; set; }
        public String Staff_NSRSWSQModulesCertificate { get; set; }
        public String Staff_OtherRecognisedCertificate { get; set; }
        public String Staff_ExemptionCertificate { get; set; }
        public String Staff_SecurityOfficerLicenseCertificate { get; set; }
        public String Staff_SIRDScreenCertificate { get; set; }




        [SelfValidation]
        public void Validate(ValidationResults results)
        {

            if (String.IsNullOrEmpty(City))
            {
                results.AddResult(new ValidationResult("Please enter a City", this, "City", null, null));
            }
            if (String.IsNullOrEmpty(State))
            {
                results.AddResult(new ValidationResult("Please enter a State", this, "State", null, null));
            }
            if (!String.IsNullOrEmpty(Fax))
            {
                Regex regnum = new Regex("^[0-9]+$");
                if (!regnum.IsMatch(Fax))
                {
                    results.AddResult(new ValidationResult("Only numeric values allowed for Fax.", this, "Fax", null, null));
                }
            }

            if (String.IsNullOrEmpty(UserSecretAns))
            {
                results.AddResult(new ValidationResult("Secret Answer can't be left blank.", this, "Secret Answer", null, null));
            }
            if (String.IsNullOrEmpty(UserStatus))
            {
                results.AddResult(new ValidationResult("Please select a User Status .", this, "User Status", null, null));
            }
        }


    }

}
