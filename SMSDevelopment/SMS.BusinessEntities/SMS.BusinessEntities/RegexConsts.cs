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
    class RegexConsts
    {
        #region RegularExpressions
        public const string EmailRegex = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
        public const string regIntValidator = @"[0-9][0-9][0-9][0-9]";
        public const string charValidator = "!@#$%^*()_-+=|{}[]:;'<>,.?/";
        public const string AcctNoRegex = @"[0-9]{16}";
        public const string IntlPrmAcctNoRegex = "[0-9][0-9][0-9][0-9]";
        public const string PrmAcctNoRegex = "[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]";
        public const string alphanumericValidator = "!@#$%^*()_-+=|{}[]:;'<>,.?/";
        public const string CardNoRegex = "[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]";
        public const string UserIDRegex = "[a-zA-Z][a-zA-Z0-9]{3,16}$";
        public const string CommonNameRegex = "[a-zA-Z]{1,20}$";
        public const string PhoneNoRegex = "[0-9]{8,12}$";
        #endregion

        #region Message Templates

        #region MTCG
        public const string mtcDescrLength = "* MTC Description must not exceed 50 characters.<br/>";
        public const string mtcDescription = "* MTC Description accepts only alphanumeric values.<br/>";
        public const string mtcgNameLength = "* MTCG Name must not exceed 50 characters.<br/>";
        public const string mtcgName = "* MTCG Name accepts only alphanumeric values.<br/>";
        public const string mtcCodeLength = "* MTC Code must not exceed 50 characters.<br/>";
        public const string mtcCode = "* MTC Code accepts only alphanumeric values.<br/>";
        public const string mtcCodeDescLen = "* MTC Description must not exceed 50 characters.<br/>";
        public const string mtcCodeDesc = "* MTC Code Desc accepts only alphanumeric values.<br/>";
        public const string valueGroupName = "* Group Name can't be None.<br/>";
        public const string valueMTCCode = "* MTC Code can't be left blank.<br/>";
        public const string valueLogicModule = "* Logic Module can't be None.<br/>";
        public const string monTxnCtrlLen = "* MTC Code must not exceed 50 characters.<br/>";
        public const string monTxnControl = "* MTC Code accepts only alphanumeric values.<br/>";
        public const string valueMTCGName = "* MTCG Name can't be left blank.<br/>";
        public const string valueMTCDesc = "* MTCG Description can't be left blank.<br/>";
        #endregion

        #region Statement
        public const string messageCode = "* Message Code accepts only alphanumeric values.<br/>";
        public const string messCodeLength = "* Mesage Code accepts only 4 alphanumeric values.<br/>";
        public const string priorityField = "* Please cannot be Non-Numeric.<br/>";
        public const string priorityLength = "* Priority Field accepts only 1 value.<br/>";
        public const string stmntMsgLnth = "* Statement Message must not exceed 100 characters.";
        public const string stmntMessage = "* Statement Message accepts only alphanumeric values.<br/>";
        public const string stmntMsgGrpNameLen = "* Group Name must not exceed 50 characters.<br/>";
        public const string stmntMsgGrpName = "* Group Name accepts only alphanumeric values.<br/>";
        public const string grpDescLen = "* Group Description must not exceed 50 characters.<br/>";
        public const string grpDesc = "* Group Description accepts only alphanumeric values.<br/>";
        public const string valueMessaegCode = "* MessageCode can't be left blank.<br/>";
        public const string valueGrpName = "* Group Name can't be left blank.<br/>";
        public const string valueGrpDesc = "* Group Description can't be left blank.<br/>";
        public const string valueStmtMsgGroup = "* Statement Msg Group can't be None.<br/>";
        public const string valueMsgType = "* Message type can't be None.<br/>";
        public const string valueStmtMsg = "* Statement Message cannot be left blank.<br/>";
        public const string valuePriority = "* Priority cannot be Non-Numeric.<br/>";
        #endregion

        #region Transaction Constant
        public const string cardNoLenght = "* Card No. should be of 9 Digits.<br/>";
        public const string cardNo = "*Invalid / Blank Card No.<br/>";
        public const string acctNoLength = "* Account No. should be of 9 Digits.<br/>";
        public const string accountNo = "* Invalid  / Blank Account No.<br/>";
        public const string transCommentLen = "* Transaction Comments must not exceed 50 characters.<br/>";
        public const string transComments = "* Only alphabetic values are allowed for Trans Comments.<br/>";
        public const string tranAmnt = "* Transaction Amount can't be Non - Numeric.<br/>";
        public const string transComment = "* Transaction Comments cannot be null.<br/>";
        public const string valueInstituteID = "* InstituteID can't be None.<br/>";
        public const string valueStoreID = "* StoreID can't be None.<br/>";
        public const string valueMerchantID = "* MerchantID can't be None.<br/>";
        public const string valueTransType = "* Transaction Type can't be None.<br/>";
        #endregion

        #region Service Charge Constatnts
        public const string SC_ERRANNUTXNCODE = "* Annual Fee Txn Code can't be None.<br/>";
        public const string SC_ERRANNUREVTXNCODE = "* Annual Fee Reversal Txn Code can't be None.<br/>";
        public const string SC_ERRANNUPRIMARYACCNT = "* Annual Fee Fee Primary Account can't be blank.<br/>";
        //public const string SC_ERRANNUPRIMARYACCNTINVALID = "* Either Fee Primary Account blank or Value other than Money type.<br/>";
        public const string SC_ERRANNUPRIMARYACCNTINVALID1 = "* Fee Primary Account can't be left blank and contains only numeric values.<br/>";
        public const string SC_ERRANNUPRIMARYACCNTINVALID2 = "* Fee Primary Account should be Money type.<br/>";
        public const string SC_ERRANNUANNFEEMONTH = "* Annual Fee Fee month can't be None.<br/>";
        public const string SC_ERRNEWCARDFEENAME = "* New Card Fee Name can't be None.<br/>";
        public const string SC_ERRNEWCARDTXNCODE = "* New Card Txn Code can't be None.<br/>";
        public const string SC_ERRNEWCARDREVTXNCODE = "* New Card Reversal Txn Code can't be None.<br/>";
        public const string SC_ERRADDITIONALFEENAME = "* Additional Fee Name can't be None.<br/>";
        public const string SC_ERRADDITIONALTXNCODE = "* Additional Fee Txn Code can't be None.<br/>";
        public const string SC_ERRADDITIONALREVTXNCODE = "* Additional Fee Reversal Txn Code can't be None.<br/>";
        public const string SC_ERRREPLACEMENTFEENAME = "* Replacement Fee Name can't be None.<br/>";
        public const string SC_ERRREPLACEMENTTXNCODE = "* Replacement Fee Txn Code can't be None.<br/>";
        public const string SC_ERRREPLACEMENTREVTXNCODE = "* Replacement Fee Reversal Txn Code can't be None.<br/>";
        public const string SC_ERRREISSUEDFEENAME = "* Re-Issued Fee Name can't be None.<br/>";
        public const string SC_ERRREISSUEDTXNCODE = "* Re-Issued Fee Txn Code can't be None.<br/>";
        public const string SC_ERRREISSUEDREVTXNCODE = "* Re-Issued Fee Reversal Txn Code can't be None.<br/>";
        public const string SC_ERRTXNFEENAME = "* Transaction Fee Name can't be None.<br/>";
        public const string SC_ERRTRANSACTIONFEETXNCODE = "* Transaction Fee Txn Code can't be None.<br/>";
        public const string SC_ERRTXNFEEREVTXNCODE = "* Transaction Fee Reversal Txn Code can't be None.<br/>";
        public const string SC_ERRAUTHFEENAME = "* Auth Fee Name can't be None.<br/>";
        public const string SC_ERRAUTHFEETXNCODE = "* Auth Fee Txn Code can't be None.<br/>";
        public const string SC_ERRAUTHFEEREVTXNCODE = "* Auth Fee Reversal Txn Code can't be None.<br/>";
        public const string SC_ERRACTINACTIVEFEENAME = "* Active/InActive Fee Name can't be None.<br/>";
        public const string SC_ERRACTINACTIVEFETXNCODE = "* Active/InActive Fee Txn Code can't be None.<br/>";
        public const string SC_ERRACTINACTIVEFEEREVTXNCODE = "* Active/InActive Fee Reversal Txn Code can't be None.<br/>";
        public const string SC_ERRSERVICEFEENAME = "* Service Fee Name can't be None.<br/>";
        public const string SC_ERRSEVICEFEETXNCODE = "* Service Fee Txn Code can't be None.<br/>";
        public const string SC_ERRSERVICEFEEREVTXNCODE = "* Service Fee Reversal Txn Code can't be None.<br/>";
        public const string SC_ERRNWECARDFEETIMING = "* New Card Fee Timing can't be None.<br/>";
        //
        public const string SC_ERRNWECARDFEEINVALID1 = "* New Card Fee can't left blank.<br/>";
        public const string SC_ERRNWECARDFEEINVALID2 = "* New Card Fee allows only Money value.<br/>";
        public const string SC_ERRNADDCARDFEEINVALID = "* Either Additional Card Fee left blank or Value other than Money type.<br/>";
        public const string SC_ERRREPLCARDCARDFEEINVALID = "* Either Replacement Card Fee left blank or Value other than Money type.<br/>";
        public const string SC_ERRREISSUEDCARDFEEINVALID = "* Either Issued Card Fee left blank or Value other than Money type.<br/>";
        //
        public const string SC_ERRADDITIONALCARDFEETIMING = "* Additional Card Fee Timing can't be None.<br/>";
        public const string SC_ERRREPLACEMENTCARDFEETIMING = "* Replacement Card Fee Timing can't be None.<br/>";
        public const string SC_ERRREISSUEDCARDFEETIMING = "* Re-Issued Card Fee Timing can't be None.<br/>";
        public const string SC_ERRTRANFEESTATUS = "* Transaction Fee Status can't be None.<br/>";
        public const string SC_ERRAUTHFEESTATUS = "* Authorization Fee Status can't be None.<br/>";
        public const string SC_ERRACTVINACTIVEFEESTATUS = "* Active Inactive Fee Status can't be None.<br/>";
        public const string SC_ERRSERVICEFEESTATUS = "* Service Fee Status can't be None.<br/>";
        public const string MF_FEETXNCODE = "* Manual Fee Txn Code can't be None.<br/>";
        public const string MF_FEEREVTXNCODE = "* Manual Fee Reversal Txn Code can't be None.<br/>";

        //
        public const string SC_ERRTRANFEER1A = "* Either Rate 1 Amount left blank or Value other than Money type for Transaction Fee.<br/>";
        public const string SC_ERRTRANFEER1P = "* Either Rate 1 Percent left blank or Value other than Money type for Transaction Fee.<br/>";
        //
        #endregion

        #region Billing Group Constant
        public const string BGrpNameConstant = "* Billing Group Name must not exceed 100 characters.<br/>";
        public const string BGrpContainsConstant = "* Billing Group Name accepts only alphanumeric values.<br/>";
        public const string BGrpName = "* Billing Group Name can't be left blank.<br/>";
        public const string BGrpPrimaryCurrCode = "* Primary Currency Code can't be None.<br/>";
        public const string BGrpMTCGCode = "* MTC Group Code can't be None.<br/>";
        #endregion

        #region Billing Table Constant
        public const string BTabNameConstant = "* Billing Table Name accepts only alphanumeric values.<br/>";
        public const string BTabContainsConstant = "* Special Characters are not allowed for Billing Table Name.<br/>";
        public const string BTabName = "* Billing Table Name can't be left blank.<br/>";
        public const string BTabGroup = "* Billing Group can't be None.<br/>";
        public const string BTabPrimaryCurrCode = "* Primary Currency Code can't be None.<br/>";
        public const string BTabServiceCharge = "* Service Charge can't be None.<br/>";
        #endregion

        #endregion

        #region Image Management Constant
        public const string ImageNameConstant = "Image Name must not exceed 50 characters.";
        public const string ImageContainsConstant = "Special Characters are not allowed for Image Name.";
        #endregion

        #region CardToCardTransfer

        public const string SourceAcctNoConstant = "Inavalid Source Account No.";
        public const string SourcePrmAcctNoConstant = "Inavalid Source Card No.";
        public const string DestinationAcctNoConstant = "Inavalid Destination Account No.";
        public const string DestinationPrmAcctNoConstant = "Inavalid Destination Card No.";


        #endregion

        #region Account and Primary Account Constant
        public const string AcctNoConstant = "The Account No. should contain 16 Digits.";
        public const string IntlPrmAcctNoConstant = "The Card No. should contain 4 Digits.";
        #endregion

        #region User Info Constant
        //public const string UserNameConstant = "UserID must be 4-16 chars long and cannot be left blank or start with a number.";
        public const string UserNameConstant = "Please enter a valid UserID that is  4-16 chars long.";
        //public const string UserPassword = "Password must be 4-16 chars long and cannot be left blank.";
        public const string UserPassword = "Please enter a valid Password that is  4-16 chars long.";
        public const string UserNewPassword = "New Password must be 4-16 chars long and cannot be left blank.";
        public const string UserOldPassword = "Old Password must be 4-16 chars long and cannot be left blank.";
        public const string FNameConstant = "Please enter a valid First Name.";
        public const string LNameConstant = "Please enter a valid Last Name.";
        public const string PhNoConstant = "Please enter a valid Phone No.";
        public const string EmailConstant = "Please enter a valid Email ID.";

        #endregion

    }
}
