<%@ Page Language="C#" MasterPageFile="~/master/spamaster.Master" AutoEventWireup="true"
    CodeBehind="AddNewStaff.aspx.cs" Inherits="SMS.ADMIN.AddNewStaff" Title="Add New Staff" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="vbscript" type="text/vbscript">
    ' Format a byte array to a hex string to be sent to the server.
        Function OctetToHexStr(ByVal arrbytOctet)
            Dim k
            For k = 1 To Lenb(arrbytOctet)
                OctetToHexStr = OctetToHexStr _
                  & Right("0" & Hex(Ascb(Midb(arrbytOctet, k, 1))), 2)
            Next
        End Function
           
        'This event fires when new finger was enrolled.
      
        function DPFPEnrollmentControl_OnEnroll(FingerMask, Template, Status)
            Dim b
            alert("new")
            'document.getElementById("ctl00_ContentPlaceHolder1_hdnFP").value = OctetToHexStr(Template.Serialize)
    document.getElementById("ctl00_ContentPlaceHolder1_TabContainer1_TabPanel5_hdnFP").value = OctetToHexStr(Template.Serialize)

        End function 
        
    </script>
    <script src="../swfobject.js" language="javascript"></script>
    <script type="text/javascript">
        function EnableDisableEnroll(chk) {
            if (chk.checked) {
                document.getElementById("thumbPrint").style.display = "";
            }
            else {
                document.getElementById("thumbPrint").style.display = "none";
            }
        }
    </script>
    <script type="text/javascript">
        var gaJsHost = (("https:" == document.location.protocol) ? "https://ssl." : "http://www.");
        document.write(unescape("%3Cscript src='" + gaJsHost + "google-analytics.com/ga.js' type='text/javascript'%3E%3C/script%3E"));
    </script>
    <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Add New Staff</span></div>
        <div>
            <asp:Label ID="lblerror1" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"></asp:Label>
        </div>
        <br />
        <div>
            <asp:TextBox ID="TextBox1" runat="server" Visible="false"></asp:TextBox>
            <asp:Panel ID="Panel" runat="server" Style="margin-left: 0.2em; width: 59.6em; height: 30em">
                <AJAX:TabContainer ID="TabContainer1" runat="server" Font-Bold="True" OnActiveTabChanged="TabContainer1_ActiveTabChanged">
                    <AJAX:TabPanel ID="TabPanel1" TabIndex="1" HeaderText="PERSONAL PARTICULARS" runat="server"
                        Font-Bold="True" Font-Size="20px" Font-Names="Arial">
                        <ContentTemplate>
                            <table style="margin-left: 4px" width="700" class="table">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblname" CssClass="Labels" runat="server" Text="Name"></asp:Label>
                                    </td>
                                    <td colspan="6" valign="bottom">
                                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="Input">
                                            <asp:ListItem>Mr</asp:ListItem>
                                            <asp:ListItem>Miss</asp:ListItem>
                                            <asp:ListItem>Mrs</asp:ListItem>
                                            <asp:ListItem>Mdm</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblname0" CssClass="Labels" runat="server" Text="First Name"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFname" CssClass="Input" runat="server"></asp:TextBox>
                                        <asp:Label ID="errFname" CssClass="ValSummary" runat="server" Text="*" Font-Bold="True"
                                            Font-Size="Small" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblname1" CssClass="Labels" runat="server" Text="Middle Name"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMname" CssClass="Input" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblname2" CssClass="Labels" runat="server" Text="Last Name"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtLname" CssClass="Input" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblHomeAddress" CssClass="Labels" runat="server" Text="Home Address"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtHomeAdress" CssClass="Input" runat="server" Width="55%" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblmarital" CssClass="Labels" runat="server" Text="Marital Status"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DropDownList4" runat="server" CssClass="Input" AutoPostBack="True"
                                            OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged">
                                            <asp:ListItem>Single</asp:ListItem>
                                            <asp:ListItem>Married</asp:ListItem>
                                            <asp:ListItem>Divorced</asp:ListItem>
                                            <asp:ListItem>Widowed</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6">
                                        <asp:Panel ID="Panel4" runat="server" Visible="False">
                                            <table width="100%">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblheadifmarried" CssClass="Labels" runat="server" Text="If Married :"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblSpousename" CssClass="Labels" runat="server" Text="State spouse's name :"></asp:Label>
                                                        <asp:TextBox ID="txtSpousename" CssClass="Input" runat="server"></asp:TextBox>
                                                        <asp:Label ID="lblnoOfChildern" CssClass="Labels" runat="server" Text="No. of Children"></asp:Label>
                                                        <asp:TextBox ID="txtnoOfChildern" CssClass="Input" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblEnterPhoneName" CssClass="Labels" runat="server" Text="Phone No."></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPhone" CssClass="Input" runat="server"></asp:TextBox>
                                        <asp:Label ID="lblnri5" CssClass="ValSummary" runat="server" Text="*" Font-Bold="True"
                                            Font-Size="Small" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblEnterMobNo" CssClass="Labels" runat="server" Text="Mobile No."></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMobNo" CssClass="Input" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblHP" CssClass="Labels" runat="server" Text="H/P No." Visible="False"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtHP" CssClass="Input" runat="server" Visible="False"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblDOB" CssClass="Labels" runat="server" Text="Date of Birth"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDOB" CssClass="Input" runat="server" AutoPostBack="True" OnTextChanged="txtDOB_TextChanged"
                                            Width="130px"></asp:TextBox>
                                        <AJAX:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="AjaxCalendar"
                                            Format="MM/dd/yyyy" TargetControlID="txtDOB" PopupButtonID="imgBtnFromDate2"
                                            Enabled="True" />
                                        <asp:ImageButton ID="imgBtnFromDate2" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"
                                            class="calender" />
                                    </td>
                                    <td>
                                        <asp:Label ID="lblPOB" CssClass="Labels" runat="server" Text="Place Of Birth"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPOB" CssClass="Input" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblrace" CssClass="Labels" runat="server" Text="Race"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtrace" CssClass="Input" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblNRIC" CssClass="Labels" runat="server" Text="NRIC/FIN No."></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtnric" CssClass="Input" runat="server"></asp:TextBox>
                                        <asp:Label ID="errnri" CssClass="ValSummary" runat="server" Text="*" Font-Bold="True"
                                            Font-Size="Small" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblcitizen" CssClass="Labels" runat="server" Text="Citizenship"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DropDownList2" runat="server" CssClass="Input" AutoPostBack="True"
                                            OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                                            <asp:ListItem>Singapore</asp:ListItem>
                                            <asp:ListItem>Malaysian</asp:ListItem>
                                            <asp:ListItem>Other</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:TextBox ID="txtothercitizen" CssClass="Input" runat="server" Visible="False"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblage" CssClass="Labels" runat="server" Text="Age"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtage" CssClass="Input" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6">
                                        <asp:Panel ID="Panel3" runat="server" Visible="False">
                                            <table width="100%">
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:Label ID="lblifMalasian" CssClass="Labels" runat="server" Text="If Malasian :"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblMalaysianICno" CssClass="Labels" runat="server" Text="New IC No.:"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtMalaysianICno" CssClass="Input" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblMalaysianOldIC" CssClass="Labels" runat="server" Text="Old IC No.:"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtMalaysianOldIC" CssClass="Input" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblMalaysianPassport" CssClass="Labels" runat="server" Text="Passport No.:"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtMalasianPassport" CssClass="Input" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblMalasianPassportExpdate" CssClass="Labels" runat="server" Text="Passport Expiry Date :"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtMalasianPassportExpdate" CssClass="Input" runat="server"></asp:TextBox>
                                                        <AJAX:CalendarExtender ID="CalendarExtender6" runat="server" CssClass="AjaxCalendar"
                                                            Format="MM/dd/yyyy" TargetControlID="txtMalasianPassportExpdate" PopupButtonID="ImageButton6"
                                                            Enabled="True" />
                                                        <asp:ImageButton ID="ImageButton6" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"
                                                            Style="width: 16px" Width="28px" />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblMalasianWorkPermitNo" CssClass="Labels" runat="server" Text="Work Permit No.:"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtMalasianWorkPermitNo" CssClass="Input" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblMalasianWorkPermitExp" CssClass="Labels" runat="server" Text="Work Permit Expiry Date :"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtMalasianWorkPermitExp" CssClass="Input" runat="server"></asp:TextBox>
                                                        <AJAX:CalendarExtender ID="CalendarExtender7" runat="server" CssClass="AjaxCalendar"
                                                            Format="MM/dd/yyyy" TargetControlID="txtMalasianWorkPermitExp" PopupButtonID="ImageButton7"
                                                            Enabled="True" />
                                                        <asp:ImageButton ID="ImageButton7" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"
                                                            Style="width: 16px" Width="28px" />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblMalasianEducationaLevel" CssClass="Labels" runat="server" Text="Educational Level"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="DropDownList7" runat="server" CssClass="Labels">
                                                            <asp:ListItem></asp:ListItem>
                                                            <asp:ListItem>Primary</asp:ListItem>
                                                            <asp:ListItem>SRP</asp:ListItem>
                                                            <asp:ListItem>SPM</asp:ListItem>
                                                            <asp:ListItem>STPM</asp:ListItem>
                                                            <asp:ListItem>Diploma</asp:ListItem>
                                                            <asp:ListItem>Degree</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblreligion" CssClass="Labels" runat="server" Text="Religion"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtreligion" CssClass="Input" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblsex" CssClass="Labels" runat="server" Text="Sex"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DropDownList3" runat="server" CssClass="Input">
                                            <asp:ListItem>Male</asp:ListItem>
                                            <asp:ListItem>Female</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblDlicense" CssClass="Labels" runat="server" Text="Driving License"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDlicense" CssClass="Input" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="lblheadEmergency" runat="server" CssClass="Labels" Text="In Case of Emergency, to notify:"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblemergencyName" runat="server" CssClass="Labels" Text="Name"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtEmergencyName" runat="server" CssClass="Input" Width="92%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblEmergenAddress" runat="server" CssClass="Labels" Text="Address"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtEmergenAddress" runat="server" CssClass="Input" Width="92%" Height="41px"
                                            TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblEmergenContNo" runat="server" CssClass="Labels" Text="Telephone No."></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtEmergencContNo" runat="server" CssClass="Input"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="20px">
                                    </td>
                                </tr>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblRole" CssClass="Labels" runat="server" Text="Sub Role"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlRole" runat="server" CssClass="Labels" Width="130px">
                                        </asp:DropDownList>
                                        <asp:Label ID="errddlRole" CssClass="ValSummary" runat="server" Text="*" Font-Bold="True"
                                            Font-Size="Small" ForeColor="Red" Visible="False"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:Label ID="AddNewLabel" CssClass="Labels" runat="server" Text="Add New Sub Role"
                                            Visible="False"></asp:Label>
                                        <asp:TextBox ID="txtNewRoleDefine" CssClass="Input" runat="server" Visible="False"></asp:TextBox>
                                        <asp:Button ID="cmdbuttonadd" CssClass="Buttons" runat="server" Text="ADD" Width="46px"
                                            OnClick="cmdbuttonadd_Click" Visible="False" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblStaffuserid" CssClass="Labels" runat="server" Text="User ID"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtStaffUserid" CssClass="Input" runat="server"></asp:TextBox>
                                        <asp:Label ID="errUserid" CssClass="ValSummary" runat="server" Text="*" Font-Bold="True"
                                            Font-Size="Small" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblStaffuserPassword" CssClass="Labels" runat="server" Text="User Password"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtStaffUserPassword" CssClass="Input" runat="server" TextMode="Password"></asp:TextBox>
                                        <asp:Label ID="errUserPassword" CssClass="ValSummary" runat="server" Text="*" Font-Bold="True"
                                            Font-Size="Small" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblStaffuserConfigPassword" CssClass="Labels" runat="server" Text="Confirm Password"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtStaffuserConfigPassword" CssClass="Input" runat="server" TextMode="Password"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" valign="top">
                                        <asp:Label ID="lblStaffSeurityqty" CssClass="Labels" runat="server" Text="Select Security Question"></asp:Label>
                                        <asp:DropDownList ID="ddlStaffSecQues" runat="server" CssClass="Input" Width="180px">
                                        </asp:DropDownList>
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtStaffSeurityqty" CssClass="Input" runat="server" Height="18px"
                                            Width="370px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="height: 4em;">
                                    <td>
                                    </td>
                                </tr>
                            </table>
                            <table width="102.2%" style="margin-left: -0.4em; margin-bottom: -0.4em; border: 1px;
                                border-style: groove; border-color: Black; background: url(../Images/1397d40aa687.jpg)">
                                <tr>
                                    <td colspan="6">
                                        <asp:Button ID="cmdbuttonSave" CssClass="Buttons" runat="server" Text="Save" Width="85px"
                                            Style="margin-left: 245px" OnClick="cmdbuttonSave_Click1" />
                                        &nbsp; &nbsp; &nbsp;
                                        <asp:Button ID="cmdbuttonNext" CssClass="Buttons" runat="server" Text="Next" Width="85px"
                                            OnClick="cmdbuttonNext_Click" />
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="cmdbuttonFinish" runat="server" CssClass="Buttons" OnClick="cmdbuttonFinish_Click"
                                            Text="Finish" Width="85px" />
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </AJAX:TabPanel>
                    <AJAX:TabPanel ID="TabPanel7" HeaderText="PERSONAL PARTICULARS:2" runat="server"
                        Font-Bold="True" Font-Size="20px" Font-Names="Arial" Visible="false">
                        <ContentTemplate>
                            <table width="100%" class="table" visible="false">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblIncomeTax" CssClass="Labels" runat="server" Text="Income Tax" Visible="false"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtincometax" CssClass="Input" runat="server" Visible="false"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblOccupation" CssClass="Labels" runat="server" Text="Occupation"
                                            Visible="false"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtOccupation" CssClass="Input" runat="server" Visible="false"></asp:TextBox>
                                    </td>
                                </tr>
                                <br />
                            </table>
                        </ContentTemplate>
                    </AJAX:TabPanel>
                    <AJAX:TabPanel ID="TabPanel2" TabIndex="2" HeaderText="EDUCATIONAL DETAILS" runat="server"
                        Font-Bold="True" Font-Size="20px" Font-Names="Arial">
                        <ContentTemplate>
                            <table style="margin-left: 4px" width="700" class="table">
                                <tr>
                                    <td colspan="7">
                                        <div>
                                            <table width="700">
                                                <tr>
                                                    <td align="center">
                                                        <asp:Label ID="lblnameofSchool" CssClass="Labels" runat="server" Text="Name of School"></asp:Label>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="lbladdres" CssClass="Labels" runat="server" Text="Address"></asp:Label>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="lblLevel" CssClass="Labels" runat="server" Text="Level"></asp:Label>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="lblFrom" CssClass="Labels" runat="server" Text="From"></asp:Label>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="lblTo" CssClass="Labels" runat="server" Text="To"></asp:Label>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="lblqualification" CssClass="Labels" runat="server" Text="Qualification"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtEDnameofSchool1" CssClass="Input" runat="server" Width="115px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtEDaddres1" CssClass="Input" runat="server" Width="115px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtEDLeve1" CssClass="Input" runat="server" ReadOnly="True" Width="115px">Primary</asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtEDFrom1" CssClass="Input" runat="server" Width="115px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtEDTo1" CssClass="Input" runat="server" Width="115px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtEDqualification1" CssClass="Input" runat="server" Width="115px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtEDnameofSchool2" CssClass="Input" runat="server" Width="115px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtEDaddres2" CssClass="Input" runat="server" Width="115px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtEDLeve2" CssClass="Input" runat="server" ReadOnly="True" Width="115px">Secondary</asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtEDFrom2" CssClass="Input" runat="server" Width="115px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtEDTo2" CssClass="Input" runat="server" Width="115px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtEDqualification2" CssClass="Input" runat="server" Width="115px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtEDnameofSchool3" CssClass="Input" runat="server" Width="115px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtEDaddres3" CssClass="Input" runat="server" Width="115px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtEDLeve3" CssClass="Input" runat="server" ReadOnly="True" Width="115px">Vocational</asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtEDFrom3" CssClass="Input" runat="server" Width="115px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtEDTo3" CssClass="Input" runat="server" Width="115px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtEDqualification3" CssClass="Input" runat="server" Width="115px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtEDnameofSchool4" CssClass="Input" runat="server" Width="115px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtEDaddres4" CssClass="Input" runat="server" Width="115px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtEDLeve4" CssClass="Input" runat="server" ReadOnly="True" Width="115px">Other</asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtEDFrom4" CssClass="Input" runat="server" Width="115px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtEDTo4" CssClass="Input" runat="server" Width="115px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtEDqualification4" CssClass="Input" runat="server" Width="115px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblOtherSkills" CssClass="Labels" runat="server" Text="Other training or Skills"></asp:Label>
                                        <%--</td>
                    <td colspan="6">--%>
                                        <asp:TextBox ID="txtotherSkills" CssClass="Input" runat="server" Width="83%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblhobbies" CssClass="Labels" runat="server" Text="Hobbies" Visible="False"></asp:Label>
                                    </td>
                                    <td colspan="6">
                                        <asp:TextBox ID="txthobbies" CssClass="Input" runat="server" Width="92%" Visible="False"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="20px">
                                    </td>
                                </tr>
                                <tr style="height: 4em;">
                                    <td>
                                    </td>
                                </tr>
                            </table>
                            <table width="102.2%" style="margin-left: -0.4em; margin-bottom: -0.4em; border: 1px;
                                border-style: groove; border-color: Black; background: url(../Images/1397d40aa687.jpg)">
                                <tr>
                                    <td colspan="6">
                                        <asp:Button ID="cmdbuttonSave3" CssClass="Buttons" runat="server" Text="Save" Width="85px"
                                            OnClick="cmdbuttonSave3_Click" Style="margin-left: 245px" />
                                        &nbsp; &nbsp; &nbsp;
                                        <asp:Button ID="cmdbuttonNext3" CssClass="Buttons" runat="server" Text="Next" Width="85px"
                                            OnClick="cmdbuttonNext3_Click" />
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="cmdbuttonFinish3" runat="server" CssClass="Buttons" OnClick="cmdbuttonFinish3_Click"
                                            Text="Finish" Width="85px" />
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </AJAX:TabPanel>
                    <AJAX:TabPanel ID="TabPanel3" TabIndex="3" HeaderText="NATIONAL SERVICE" runat="server"
                        Font-Bold="True" Font-Size="20px" Font-Names="Arial">
                        <ContentTemplate>
                            <table style="margin-left: 4px" width="700" class="table">
                                <tr>
                                    <td colspan="6">
                                        <div>
                                            <table width="700">
                                                <tr>
                                                    <td colspan="2" style="font-weight: 700">
                                                        <asp:Label ID="lblheadNationalServices" CssClass="Labels" runat="server" Text="NATIONAL SERVICE"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="lblNSTime" CssClass="Labels" runat="server" Text="Time:  From"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtNSTime" CssClass="Input" runat="server" Width="120px"></asp:TextBox>
                                                        <AJAX:CalendarExtender ID="CalendarExtender3" runat="server" CssClass="AjaxCalendar"
                                                            Format="MM/dd/yyyy" TargetControlID="txtNSTime" PopupButtonID="ImageButton3" />
                                                        <asp:ImageButton ID="ImageButton3" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"
                                                            class="calender" />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblNSTo" CssClass="Labels" runat="server" Text="To"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtNSTo" CssClass="Input" runat="server" Width="120px"></asp:TextBox>
                                                        <AJAX:CalendarExtender ID="CalendarExtender4" runat="server" CssClass="AjaxCalendar"
                                                            Format="MM/dd/yyyy" TargetControlID="txtNSTo" PopupButtonID="imgBtnFromDate4" />
                                                        <asp:ImageButton ID="imgBtnFromDate4" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"
                                                            class="calender" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="5px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblNSTypeofDischarge" CssClass="Labels" runat="server" Text="Type of Discharge"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtNSTypeofDischarge" CssClass="Input" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblNSVocation" CssClass="Labels" runat="server" Text="Vocation"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtNSVocation" CssClass="Input" runat="server"></asp:TextBox>
                                                    </td>
                                                    <%--  <tr>
                   <td>
                        <asp:Label ID="lblGroupRole" CssClass="Labels" runat="server" Text="Select Management Role"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlGroupRole" runat="server" CssClass="Input" Width="150px">
                        </asp:DropDownList>
                    </td>
                    <td colspan="2">
                        <asp:Label ID="lblmRole" CssClass="Labels" runat="server" Text="Add New Management Role"></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:TextBox ID="txtNewmanagementRoleDefine" CssClass="Input" runat="server"></asp:TextBox>
                    </td>
                    <td width="120px" colspan="1">
                        <asp:Button ID="cmdbuttonadd4" CssClass="Buttons" runat="server" Text="ADD" OnClick="cmdbuttonaddm_Click"
                            Width="46px" />
                    </td>
                </tr>--%>
                                                </tr>
                                                <tr>
                                                    <td height="5px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblNSLastRank" CssClass="Labels" runat="server" Text="Last Rank"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtNSLastRank" CssClass="Input" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblNSNextInCamp" CssClass="Labels" runat="server" Text="Next In-Camp"
                                                            Width="130px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtNSNextInCamp" CssClass="Input" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblNSExempted" CssClass="Labels" runat="server" Text="Exempted/ Deferred/ Awaiting"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtNSExempted" CssClass="Input" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblNSReason" CssClass="Labels" runat="server" Text="Reason"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtNSReason" CssClass="Input" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblNSPeriod" CssClass="Labels" runat="server" Text="Period/ Date of Registration"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtNSPeriod" CssClass="Input" runat="server" Width="120px"></asp:TextBox>
                                                        <AJAX:CalendarExtender ID="CalendarExtender5" runat="server" CssClass="AjaxCalendar"
                                                            Format="MM/dd/yyyy" TargetControlID="txtNSPeriod" PopupButtonID="ImageButton5" />
                                                        <asp:ImageButton ID="ImageButton5" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"
                                                            class="calender" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="20px">
                                    </td>
                                </tr>
                                <tr style="height: 4em;">
                                    <td>
                                    </td>
                                </tr>
                            </table>
                            <table width="102.2%" style="margin-left: -0.4em; margin-bottom: -0.4em; border: 1px;
                                border-style: groove; border-color: Black; background: url(../Images/1397d40aa687.jpg)">
                                <tr>
                                    <td colspan="6">
                                        <asp:Button ID="cmdbuttonSave4" CssClass="Buttons" runat="server" Text="Save" Width="85px"
                                            OnClick="cmdbuttonSave4_Click" Style="margin-left: 245px" />
                                        &nbsp; &nbsp; &nbsp;
                                        <asp:Button ID="cmdbuttonNext4" CssClass="Buttons" runat="server" Text="Next" Width="85px"
                                            OnClick="cmdbuttonNext4_Click" />
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="cmdbuttonFinish4" runat="server" CssClass="Buttons" OnClick="cmdbuttonFinish4_Click"
                                            Text="Finish" Width="85px" />
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </AJAX:TabPanel>
                    <AJAX:TabPanel ID="TabPanel4" TabIndex="4" HeaderText="EMPLOYMENT EXPERIENCE" runat="server"
                        Font-Bold="True" Font-Size="20px" Font-Names="Arial">
                        <ContentTemplate>
                            <table style="margin-left: 18px" width="700" class="table">
                                <tr>
                                    <td>
                                        <div>
                                            <table width="700">
                                                <tr>
                                                    <td align="center">
                                                        <asp:Label ID="lblEnameofCompany" CssClass="Labels" runat="server" Text="Name of Company"></asp:Label>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="lblEFrom" CssClass="Labels" runat="server" Text="From"></asp:Label>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="lblETo" CssClass="Labels" runat="server" Text="To"></asp:Label>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="lblEReasonleave" CssClass="Labels" runat="server" Text="Reason for Leaving"></asp:Label>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="lblELastDraw" CssClass="Labels" runat="server" Text="Last Drawn Salary"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtEnameofCompany1" CssClass="Input" runat="server" Width="132px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtEFrom1" CssClass="Input" runat="server" Width="132px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtETo1" CssClass="Input" runat="server" Width="132px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtEReasonleave1" CssClass="Input" runat="server" Width="132px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtELastDraw1" CssClass="Input" runat="server" Width="132px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtEnameofCompany2" CssClass="Input" runat="server" Width="132px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtEFrom2" CssClass="Input" runat="server" Width="132px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtETo2" CssClass="Input" runat="server" Width="132px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtEReasonleave2" CssClass="Input" runat="server" Width="132px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtELastDraw2" CssClass="Input" runat="server" Width="132px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtEnameofCompany3" CssClass="Input" runat="server" Width="132px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtEFrom3" CssClass="Input" runat="server" Width="132px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtETo3" CssClass="Input" runat="server" Width="132px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtEReasonleave3" CssClass="Input" runat="server" Width="132px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtELastDraw3" CssClass="Input" runat="server" Width="132px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtEnameofCompany4" CssClass="Input" runat="server" Width="132px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtEFrom4" CssClass="Input" runat="server" Width="132px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtETo4" CssClass="Input" runat="server" Width="132px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtEReasonleave4" CssClass="Input" runat="server" Width="132px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtELastDraw4" CssClass="Input" runat="server" Width="132px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="20px">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="lblexpectedSalary" CssClass="Labels" runat="server" Text="If you are selected, your salary is :$ "></asp:Label>
                                        <%--</td>
                    <td>--%>
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:TextBox ID="txtexpectedSalary" CssClass="Input" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <asp:Label ID="lblcommencework" CssClass="Labels" runat="server" Text="If you are selected, when can you commence work :"
                                            Visible="false"></asp:Label>
                                        <%--</td>
                    <td>--%>
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:TextBox ID="txtcommencework" CssClass="Input" runat="server" Visible="false"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:Label ID="lblLaw" CssClass="Labels" runat="server" Text="Have you ever been convicted in a court of LAW in Singapore or any Country ?"></asp:Label>
                                        <%--</td>
                    <td>--%>
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:DropDownList ID="DropDownList5" runat="server" CssClass="Input" AutoPostBack="True"
                                            OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged">
                                            <asp:ListItem>No</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6">
                                        <asp:Panel ID="Panel1" runat="server" Visible="False">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblLAWyes" CssClass="Labels" runat="server" Text="If Yes, State Reason"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtLAWyes" CssClass="Input" runat="server" Width="730px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:Label ID="lblInjury" CssClass="Labels" runat="server" Text="Do you have any serious illness, injury or major operation ?"></asp:Label>
                                        <%--</td>
                    <td>--%>
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:DropDownList ID="DropDownList6" runat="server" CssClass="Input" AutoPostBack="True"
                                            OnSelectedIndexChanged="DropDownList6_SelectedIndexChanged">
                                            <asp:ListItem>No</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6">
                                        <asp:Panel ID="Panel2" runat="server" Visible="False">
                                            <asp:Label ID="lblInjuryyes" CssClass="Labels" runat="server" Text="If Yes, State Reason"></asp:Label>
                                            &nbsp;<asp:TextBox ID="txtInjuryyes" CssClass="Input" runat="server" Width="730px"></asp:TextBox>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                </tr>
                                <%-- </td>
                    <td>--%>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblNRICWorkpermit" Text="NRIC / Work Permit" CssClass="Labels" runat="server"
                                            Width="300px"></asp:Label>
                                        <%--</td>
                      <td> --%>
                                        <asp:FileUpload ID="txtNricworkpermit" runat="server" CssClass="Labels"></asp:FileUpload>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblNSRSWSQ" Text="NSRS / WSQ Modules" CssClass="Labels" runat="server"
                                            Width="300px"></asp:Label>
                                        <%-- %></td>
                          <td colspan="1">--%>
                                        <asp:FileUpload ID="txtNSRSWQ" runat="server" CssClass="Labels"></asp:FileUpload>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblotherRecognised" Text="Other Recognised Qualification" CssClass="Labels"
                                            runat="server" Width="300px"></asp:Label>
                                        <%--</td>
                          <td colspan="2">--%>
                                        <asp:FileUpload ID="txtotherRecognised" runat="server" CssClass="Labels"></asp:FileUpload>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblExemptionCertificate" Text="Exemption Certificate of Service" CssClass="Labels"
                                            runat="server" Width="300px"></asp:Label>
                                        <%--</td>
                          <td colspan="2">--%>
                                        <asp:FileUpload ID="txtExemptionCertificate" runat="server" CssClass="Labels"></asp:FileUpload>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblSecurityOfficerLicense" Text="Security Officer License" CssClass="Labels"
                                            runat="server" Width="300px"></asp:Label>
                                        <%--</td>
                          <td colspan="2">--%>
                                        <asp:FileUpload ID="txtSecurityOfficerLicense" runat="server" CssClass="Labels">
                                        </asp:FileUpload>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblSIRDscreen" Text="SIRD Screening" CssClass="Labels" runat="server"
                                            Width="300px"></asp:Label>
                                        <%--</td>
                          <td colspan="2">--%>
                                        <asp:FileUpload ID="txtSIRDscreen" runat="server" CssClass="Labels"></asp:FileUpload>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="25">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" valign="bottom">
                                        <asp:Button ID="cmdIssueItem" CssClass="Buttons" runat="server" Text="Issue New Items"
                                            OnClick="cmdIssueItem_Click" Visible="False" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="cmdViewIssueItem" CssClass="Buttons" runat="server" Text="View Issued Items"
                                            OnClick="cmdViewIssueItem_Click" Visible="False" />
                                    </td>
                                </tr>
                                <tr style="height: 4em;">
                                    <td>
                                    </td>
                                </tr>
                            </table>
                            <table width="102.2%" style="margin-left: -0.4em; margin-bottom: -0.4em; border: 1px;
                                border-style: groove; border-color: Black; background: url(../Images/1397d40aa687.jpg)">
                                <tr>
                                    <td colspan="6">
                                        <asp:Button ID="cmdbuttonSave5" CssClass="Buttons" runat="server" Text="Save" Width="85px"
                                            OnClick="cmdbuttonSave5_Click" Style="margin-left: 245px" />
                                        &nbsp; &nbsp; &nbsp;
                                        <asp:Button ID="cmdbuttonNext5" CssClass="Buttons" runat="server" Text="Next" Width="85px"
                                            OnClick="cmdbuttonNext5_Click" />
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="cmdbuttonFinish5" runat="server" CssClass="Buttons" OnClick="cmdbuttonFinish5_Click"
                                            Text="Finish" Width="85px" />
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </AJAX:TabPanel>
                    <AJAX:TabPanel ID="TabPanel5" TabIndex="5" HeaderText="THUMB PRINT" runat="server"
                        Font-Bold="True" Font-Size="20px" Font-Names="Arial">
                        <ContentTemplate>
                            <table style="margin-left: 4px" width="700" class="table">
                                <tr>
                                    <td colspan="6" style="font-weight: 700">
                                        <asp:CheckBox ID="chkAgree" runat="server" CssClass="Labels" Text="Click here if you agree with the terms and conditions"
                                            onclick="EnableDisableEnroll(this);" OnCheckedChanged="chkAgree_CheckedChanged"
                                            Visible="false" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6" style="font-weight: 700">
                                        <div id="thumbPrint" style="display: block">
                                            <table style="width: 100%">
                                                <tr>
                                                    <td align="center">
                                                        <object id="DPFPEnrollmentControl" classid="CLSID:0B4409EF-FD2B-4680-9519-D18C528B265E">
                                                            <param name="MaxEnrollFingerCount" value="4" />
                                                        </object>
                                                        <asp:HiddenField ID="hdnFP" runat="server" />
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center">
                                                        <div id="flashArea" class="flashArea" style="height: 100%;">
                                                            <p align="center" class="Labels">
                                                                This content requires the Adobe Flash Player.<br />
                                                                <a href="http://www.adobe.com/go/getflashplayer">
                                                                    <img src="http://www.adobe.com/images/shared/download_buttons/get_flash_player.gif"
                                                                        alt="Get Adobe Flash player" style="border: none" /><br />
                                                                    <a href="http://www.macromedia.com/go/getflash" />Get Flash</a></p>
                                                        </div>
                                                        <script type="text/javascript">
                                                            var mainswf = new SWFObject("../take_picture.swf", "main", "600", "350", "9", "#ffffff");
                                                            mainswf.addParam("scale", "noscale");
                                                            mainswf.addParam("wmode", "window");
                                                            mainswf.addParam("allowFullScreen", "false");
                                                            //mainswf.addVariable("requireLogin", "false");
                                                            mainswf.write("flashArea");
                                                        </script>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="30px">
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                </tr>
                                <tr>
                                    <td class="Labels">
                                        &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; If your flash player is not working
                                        then please choose a file manually!!
                                    </td>
                                </tr>
                                <tr>
                                </tr>
                                <tr>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;Select File &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:FileUpload ID="FileUpload1" runat="server" />
                                    </td>
                                </tr>
                                <tr style="height: 4em;">
                                    <td>
                                    </td>
                                </tr>
                            </table>
                            <table width="102.2%" style="margin-left: -0.4em; margin-bottom: -0.4em; border: 1px;
                                border-style: groove; border-color: Black; background: url(../Images/1397d40aa687.jpg)">
                                <tr>
                                    <td colspan="6">
                                        <asp:Button ID="cmdbuttonSave6" CssClass="Buttons" runat="server" Text="Save" Width="85px"
                                            OnClick="cmdbuttonSave6_Click" Style="margin-left: 275px" />
                                        &nbsp; &nbsp; &nbsp;
                                        <asp:Button ID="cmdbuttonFinish6" runat="server" CssClass="Buttons" OnClick="cmdbuttonFinish6_Click"
                                            Text="Finish" Width="85px" />
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </AJAX:TabPanel>
                </AJAX:TabContainer>
            </asp:Panel>
        </div>
        <br />
        <br />
    </div>
</asp:Content>
