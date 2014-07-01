<%@ Page Language="C#" MasterPageFile="~/master/SpaMaster.Master" AutoEventWireup="true"
    CodeBehind="PastStaff.aspx.cs" Inherits="SMS.ADMIN.PastStaff" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
'          Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endRequestHandler)
'Sys.WebForms.PageRequestManager.getInstance().remove_endRequest(endRequestHandler)
        function DPFPEnrollmentControl_OnEnroll(FingerMask, Template, Status)
            Dim b
'           alert("dsfds")
'           alert(OctetToHexStr(Template.Serialize))
            'document.getElementById("ctl00_ContentPlaceHolder1_hdnFP").value = OctetToHexStr(Template.Serialize)
    document.getElementById("ctl00_ContentPlaceHolder1_TabContainer1_tabpanel5_hdnFP").value = OctetToHexStr(Template.Serialize)
'   alert(document.getElementById("ctl00_ContentPlaceHolder1_TabContainer1_tabpanel5_hdnFP").value)
     
        End function 

        function DPFPEnrollmentControlUpda_OnEnroll(FingerMask, Template, Status)
              Dim b
'           alert("dsfds")
'           alert(document.getElementById("ctl00_ContentPlaceHolder1_TabContainer2_TabPanel5Upda_hdnFPUpda"))
            'document.getElementById("ctl00_ContentPlaceHolder1_hdnFP").value = OctetToHexStr(Template.Serialize)
    document.getElementById("ctl00_ContentPlaceHolder1_TabContainer2_TabPanel5Upda_hdnFPUpda").value = OctetToHexStr(Template.Serialize)
'   alert(document.getElementById("ctl00_ContentPlaceHolder1_TabContainer2_TabPanel5Upda_hdnFPUpda").value)
     
        End function
       
    </script>
    <script src="../swfobject.js" language="javascript" type="text/javascript"></script>
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
    <style type="text/css">
        .modalBackground
        {
            background-color: Gray;
            filter: alpha(opacity=80);
            opacity: 0.8;
            z-index: 10000;
        }
        .RadSearchBox
        {
            float: left; /*color: #888888;
            background: url("../img/searchBox.png") no-repeat;
            float: left;
            font-family: Arial,Helvetica,sans-serif;
            font-size: 14px;
            height: 36px;
            line-height: 36px;
            margin-right: 12px;
            outline: medium none;
            padding: 0 0 0 35px;
            text-shadow: 1px 1px 0 white;
            width: 380px;
            margin: 0px;
            outline: none;
            border: none;*/
        }
        .RadSearchBox:focus
        {
            float: left; /* color: #888888;
            background: url("../img/searchBox.png") no-repeat;
            float: left;
            font-family: Arial,Helvetica,sans-serif;
            font-size: 14px;
            height: 36px;
            line-height: 36px;
            margin-right: 12px;
            outline: medium none;
            padding: 0 0 0 35px;
            text-shadow: 1px 1px 0 white;
            width: 380px;
            margin: 0px;
            outline: none;
            border: none;*/
        }
        span.rsbInner
        {
            height: 30px;
            margin-left: -35px;
        }
        
        input.rsbInput.radPreventDecorate.rsbEmptyMessage
        {
            height: 28px;
        }
        button.rsbButton.rsbButtonSearch
        {
            float: None;
            height: 34px;
            margin-left: -1px;
        }
        button.rsbButton.rsbButtonSearch:hover
        {
            height: 34px;
            margin-left: -1px;
        }
        
        input.rsbInput:focus
        {
            margin-top: 6px;
        }
        
        input.rsbInput.radPreventDecorate
        {
            margin-top: 6px;
        }
        .RadGrid_Simple .rgRow td
        {
            /*border-color: #fff #c3c3c3;*/
            text-align: left;
        }
        .RadGrid_Simple .rgAltRow td
        {
            /*border-color: #ca4b0c #ffa517;*/
            text-align: left;
        }
    </style>
    <style type="text/css">
        div#ctl00_ContentPlaceHolder1_TabContainer2
        {
            width: 1000px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Panelgrid">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Panelgrid" LoadingPanelID="RadAjaxLoadingPanel2">
                    </telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="Label398"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <div class="divContainer">
        <div class="divHeader">
            <span>Past Staff</span>
            <br />
        </div>
        <div class="btnbar">
            <div class="btnbarBox">
                <ul>
                    <li>
                        <asp:LinkButton ID="imdAdd" runat="server" CausesValidation="false" OnClick="imgAdd_Click">
                            <span id="spanAdd1" runat="server" class="iconAdd" style="line-height: 120px;">
                                <asp:Label ID="spanAdd" runat='server' Text="Add"></asp:Label></span>
                        </asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="imgEdit" runat="server" CausesValidation="false" OnClick="imgUpdate_Click">
                            <span id="spanUpdate1" runat="server" class="iconUpdate" style="line-height: 120px;">
                                <asp:Label ID="spanUpdate" runat='server' Text="Edit"></asp:Label></span>
                        </asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="imgDelete" runat="server" CausesValidation="false" OnClick="imgDelete_Click">
                            <span id="spanDelete" runat="server" class="iconDelete" style="line-height: 120px;">
                                <asp:Label ID="spandelete1" runat='server' Text="Delete"></asp:Label>
                            </span>
                        </asp:LinkButton>
                    </li>
                </ul>
            </div>
        </div>
        <ul id="tabs" class="ui-tabs ui-widget ui-widget-content ui-corner-all">
            <li id="Present" runat="server">
                <asp:LinkButton ID="lnkPresent" runat="server" OnClick="lnkPresent_Click" CausesValidation="false">
                    <span id="spanPresent" runat="server" class="icon1">Present Staff</span>
                </asp:LinkButton></li>
            <li id="Past" runat="server">
                <asp:LinkButton ID="lnkPast" runat="server" OnClick="lnkPast_Click" CausesValidation="false">
                    <span id="span_Past" runat="server" class="icon2">Past Staff</span>
                </asp:LinkButton></li>
        </ul>
        <div id="content" runat="server" style="border: ridge; width: 102%">
            <asp:Panel ID="pnlAdd" runat="server" Visible="false" Style="width: 100%;">
                <center>
                    <table width="100%" style="border: none;">
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox1" runat="server" Visible="false"></asp:TextBox>
                                <asp:Panel ID="Panel" runat="server">
                                    <asp:TabContainer ID="TabContainer1" runat="server" Font-Bold="True" Style="border: none;">
                                        <asp:TabPanel ID="tabpanel1" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="20px"
                                            HeaderText="PERSONAL PARTICULARS" TabIndex="1">
                                            <ContentTemplate>
                                                <table width="100%" style="border: none;">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblname" runat="server" CssClass="Labels" Text="Name"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="Input">
                                                                <asp:ListItem>Mr</asp:ListItem>
                                                                <asp:ListItem>Miss</asp:ListItem>
                                                                <asp:ListItem>Mrs</asp:ListItem>
                                                                <asp:ListItem>Mdm</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblname0" runat="server" CssClass="Labels" Text="First Name"></asp:Label>
                                                            <asp:Label ID="errFname" runat="server" CssClass="ValSummary" Font-Bold="True" Font-Size="Small"
                                                                ForeColor="Red" Text="*"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtFname" runat="server"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblname1" runat="server" CssClass="Labels" Text="Middle Name"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtMname" runat="server"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblname2" runat="server" CssClass="Labels" Text="Last Name"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtLname" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblHomeAddress" runat="server" CssClass="Labels" Text="Home Address"></asp:Label>
                                                        </td>
                                                        <td colspan="5">
                                                            <asp:TextBox ID="txtHomeAdress" runat="server" CssClass="Input" TextMode="MultiLine"
                                                                Width="500px" Height="40px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblmarital" runat="server" CssClass="Labels" Text="Marital Status"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="DropDownList4" runat="server" AutoPostBack="True" CssClass="Input"
                                                                OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged">
                                                                <asp:ListItem>Single</asp:ListItem>
                                                                <asp:ListItem>Married</asp:ListItem>
                                                                <asp:ListItem>Divorced</asp:ListItem>
                                                                <asp:ListItem>Widowed</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="8">
                                                            <asp:Panel ID="Panel4" runat="server" Visible="False">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td colspan="4">
                                                                            <asp:Label ID="lblheadifmarried" runat="server" CssClass="Labels" Text="If Married :"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="lblSpousename" runat="server" CssClass="Labels" Text="State spouse's name :"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtSpousename" runat="server" CssClass="Input"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblnoOfChildern" runat="server" CssClass="Labels" Text="No. of Children"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtnoOfChildern" runat="server" CssClass="Input"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblEnterPhoneName" runat="server" CssClass="Labels" Text="Phone No."></asp:Label>
                                                            <asp:Label ID="lblnri5" runat="server" CssClass="ValSummary" Font-Bold="True" Font-Size="Small"
                                                                ForeColor="Red" Text="*" Visible="false"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPhone" runat="server" CssClass="Input"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblEnterMobNo" runat="server" CssClass="Labels" Text="Mobile No."></asp:Label>
                                                            <asp:Label ID="Label1" runat="server" CssClass="ValSummary" Font-Bold="True" Font-Size="Small"
                                                                ForeColor="Red" Text="*"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtMobNo" runat="server" CssClass="Input"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDOB" runat="server" CssClass="Labels" Text="Date of Birth"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtDOB" runat="server" AutoPostBack="True" CssClass="Input" OnTextChanged="txtDOB_TextChanged"
                                                                Width="130px"></asp:TextBox>
                                                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                                TargetControlID="txtDOB" PopupButtonID="ImageButton1">
                                                            </asp:CalendarExtender>
                                                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/calendar.bmp"
                                                                class="calender" Style="margin: -20px 0px 0px 110px;" />
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblHP" runat="server" CssClass="Labels" Text="H/P No." Visible="False"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtHP" runat="server" CssClass="Input" Visible="False"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblPOB" runat="server" CssClass="Labels" Text="Place Of Birth"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPOB" runat="server" CssClass="Input"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblrace" runat="server" CssClass="Labels" Text="Race"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtrace" runat="server" CssClass="Input"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblNRIC" runat="server" CssClass="Labels" Text="NRIC/FIN No."></asp:Label>
                                                            <asp:Label ID="errnri" runat="server" CssClass="ValSummary" Font-Bold="True" Font-Size="Small"
                                                                ForeColor="Red" Text="*"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtnric" runat="server" CssClass="Input"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblcitizen" runat="server" CssClass="Labels" Text="Citizenship"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" CssClass="Input"
                                                                OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                                                                <asp:ListItem>Singapore</asp:ListItem>
                                                                <asp:ListItem>Malaysian</asp:ListItem>
                                                                <asp:ListItem>Other</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:TextBox ID="txtothercitizen" runat="server" CssClass="Input" Visible="False"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="8">
                                                            <asp:Panel ID="Panel3" runat="server" Visible="False">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td colspan="6">
                                                                            <asp:Label ID="lblifMalasian" runat="server" CssClass="Labels" Text="If Malasian :"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="lblMalaysianICno" runat="server" CssClass="Labels" Text="New IC No.:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtMalaysianICno" runat="server" CssClass="Input"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblMalaysianOldIC" runat="server" CssClass="Labels" Text="Old IC No.:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtMalaysianOldIC" runat="server" CssClass="Input"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblMalaysianPassport" runat="server" CssClass="Labels" Text="Passport No.:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtMalasianPassport" runat="server" CssClass="Input"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="lblMalasianPassportExpdate" runat="server" CssClass="Labels" Text="Passport Expiry Date :"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtMalasianPassportExpdate" runat="server" CssClass="Input"></asp:TextBox>
                                                                            <asp:CalendarExtender ID="CalendarassportExpdate" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                                                TargetControlID="txtMalasianPassportExpdate">
                                                                            </asp:CalendarExtender>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblMalasianWorkPermitNo" runat="server" CssClass="Labels" Text="Work Permit No.:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtMalasianWorkPermitNo" runat="server" CssClass="Input"></asp:TextBox>
                                                                        </td>
                                                                        <tr>
                                                                            <td colspan="2">
                                                                            </td>
                                                                        </tr>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="lblMalasianWorkPermitExp" runat="server" CssClass="Labels" Text="Work Permit Expiry Date :"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtMalasianWorkPermitExp" runat="server" CssClass="Input"></asp:TextBox>
                                                                            <asp:CalendarExtender ID="CalendarMalasianWorkPermitExp" runat="server" Enabled="True"
                                                                                PopupButtonID="ImageButton2" Format="dd/MM/yyyy" TargetControlID="txtMalasianWorkPermitExp">
                                                                            </asp:CalendarExtender>
                                                                        </td>
                                                                        <td>
                                                                            <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/calendar.bmp"
                                                                                class="calender" Style="float: right; margin-top: -1px; margin-right: 90px; height: 17px;" />
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblMalasianEducationaLevel" runat="server" CssClass="Labels" Text="Educational Level"></asp:Label>
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
                                                                        <tr>
                                                                            <td colspan="2">
                                                                            </td>
                                                                        </tr>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblage" runat="server" CssClass="Labels" Text="Age"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtage" runat="server" CssClass="Input"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblreligion" runat="server" CssClass="Labels" Text="Religion"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtreligion" runat="server" CssClass="Input"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblsex" runat="server" CssClass="Labels" Text="Sex"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="DropDownList3" runat="server" CssClass="Input">
                                                                <asp:ListItem>Male</asp:ListItem>
                                                                <asp:ListItem>Female</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDlicense" runat="server" CssClass="Labels" Text="Driving License"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtDlicense" runat="server" CssClass="Input"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="8">
                                                            <asp:Label ID="lblheadEmergency" runat="server" CssClass="Labels" Text="In Case of Emergency, to notify:"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblemergencyName" runat="server" CssClass="Labels" Text="Name"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtEmergencyName" runat="server" CssClass="Input"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblEmergenContNo" runat="server" CssClass="Labels" Text="Telephone No."></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtEmergencContNo" runat="server" CssClass="Input"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblEmergenAddress" runat="server" CssClass="Labels" Text="Address"></asp:Label>
                                                        </td>
                                                        <td colspan="3">
                                                            <asp:TextBox ID="txtEmergenAddress" runat="server" CssClass="Input" Height="45px"
                                                                TextMode="MultiLine" Width="300px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblRole" runat="server" CssClass="Labels" Text="Sub Role"></asp:Label>
                                                            <asp:Label ID="errddlRole" runat="server" CssClass="ValSummary" Font-Bold="True"
                                                                Font-Size="Small" ForeColor="Red" Text="*"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlRole" runat="server" CssClass="Labels" Width="130px">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td colspan="6">
                                                            <asp:Label ID="AddNewLabel" runat="server" CssClass="Labels" Text="Add New Sub Role"
                                                                Visible="False"></asp:Label>
                                                            <asp:TextBox ID="txtNewRoleDefine" runat="server" CssClass="Input" Visible="False"></asp:TextBox>
                                                            <asp:Button ID="cmdbuttonadd" runat="server" CssClass="Button" Text="ADD" Visible="False"
                                                                Width="46px" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblStaffuserid" runat="server" CssClass="Labels" Text="User ID"></asp:Label>
                                                            <asp:Label ID="errUserid" runat="server" CssClass="ValSummary" Font-Bold="True" Font-Size="Small"
                                                                ForeColor="Red" Text="*"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtStaffUserid" runat="server" CssClass="Input"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblStaffuserPassword" runat="server" CssClass="Labels" Text="User Password"></asp:Label>
                                                            <asp:Label ID="errUserPassword" runat="server" CssClass="ValSummary" Font-Bold="True"
                                                                Font-Size="Small" ForeColor="Red" Text="*"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtStaffUserPassword" runat="server" CssClass="Input" TextMode="Password"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblStaffuserConfigPassword" runat="server" CssClass="Labels" Text="Confirm Password"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtStaffuserConfigPassword" runat="server" CssClass="Input" TextMode="Password"></asp:TextBox>
                                                        </td>
                                                        <td colspan="2">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4" valign="top">
                                                            <asp:Label ID="lblStaffSeurityqty" runat="server" CssClass="Labels" Text="Select Security Question"></asp:Label>
                                                            <asp:DropDownList ID="ddlStaffSecQues" runat="server" CssClass="Input" Width="180px">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td colspan="4">
                                                            <asp:TextBox ID="txtStaffSeurityqty" runat="server" CssClass="Input" Height="18px"
                                                                Width="370px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="8">
                                                            <center>
                                                                <asp:Button ID="cmdbuttonSave" runat="server" CssClass="Button" OnClick="cmdbuttonSave_Click1"
                                                                    Text="Save/Next" />
                                                                <asp:Button ID="cmdbuttonNext" runat="server" CssClass="Button" OnClick="cmdbuttonNext_Click"
                                                                    Text="Next" Visible="false" />
                                                                <asp:Button ID="cmdbuttonFinish" runat="server" CssClass="Button" OnClick="cmdbuttonFinish_Click"
                                                                    Text="Finish" Visible="false" />
                                                                <asp:Button ID="BtnCancel1" runat="server" CssClass="Button" OnClick="cmdbuttonCancel_Click"
                                                                    Text="Cancel" />
                                                            </center>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                        </asp:TabPanel>
                                        <asp:TabPanel ID="tabpanel7" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="20px"
                                            HeaderText="PERSONAL PARTICULARS:2" Visible="false">
                                            <ContentTemplate>
                                                <table visible="false" width="100%">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblIncomeTax" runat="server" CssClass="Labels" Text="Income Tax" Visible="false"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtincometax" runat="server" CssClass="Input" Visible="false"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblOccupation" runat="server" CssClass="Labels" Text="Occupation"
                                                                Visible="false"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtOccupation" runat="server" CssClass="Input" Visible="false"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <br />
                                                </table>
                                            </ContentTemplate>
                                        </asp:TabPanel>
                                        <asp:TabPanel ID="tabpanel2" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="20px"
                                            HeaderText="EDUCATIONAL DETAILS" TabIndex="2">
                                            <ContentTemplate>
                                                <table style="border: none;" width="100%">
                                                    <tr>
                                                        <td colspan="2">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="center">
                                                                        <asp:Label ID="lblnameofSchool" runat="server" CssClass="Labels" Text="Name of School"></asp:Label>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label ID="lbladdres" runat="server" CssClass="Labels" Text="Address"></asp:Label>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label ID="lblLevel" runat="server" CssClass="Labels" Text="Level"></asp:Label>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label ID="lblFrom" runat="server" CssClass="Labels" Text="From"></asp:Label>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label ID="lblTo" runat="server" CssClass="Labels" Text="To"></asp:Label>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label ID="lblqualification" runat="server" CssClass="Labels" Text="Qualification"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:TextBox ID="txtEDnameofSchool1" runat="server" CssClass="Input" Width="115px"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtEDaddres1" runat="server" CssClass="Input" Width="115px"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtEDLeve1" runat="server" CssClass="Input" ReadOnly="True" Width="115px">Primary</asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtEDFrom1" runat="server" CssClass="Input" Width="115px"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtEDTo1" runat="server" CssClass="Input" Width="115px"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtEDqualification1" runat="server" CssClass="Input" Width="115px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:TextBox ID="txtEDnameofSchool2" runat="server" CssClass="Input" Width="115px"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtEDaddres2" runat="server" CssClass="Input" Width="115px"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtEDLeve2" runat="server" CssClass="Input" ReadOnly="True" Width="115px">Secondary</asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtEDFrom2" runat="server" CssClass="Input" Width="115px"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtEDTo2" runat="server" CssClass="Input" Width="115px"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtEDqualification2" runat="server" CssClass="Input" Width="115px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:TextBox ID="txtEDnameofSchool3" runat="server" CssClass="Input" Width="115px"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtEDaddres3" runat="server" CssClass="Input" Width="115px"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtEDLeve3" runat="server" CssClass="Input" ReadOnly="True" Width="115px">Vocational</asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtEDFrom3" runat="server" CssClass="Input" Width="115px"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtEDTo3" runat="server" CssClass="Input" Width="115px"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtEDqualification3" runat="server" CssClass="Input" Width="115px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:TextBox ID="txtEDnameofSchool4" runat="server" CssClass="Input" Width="115px"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtEDaddres4" runat="server" CssClass="Input" Width="115px"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtEDLeve4" runat="server" CssClass="Input" ReadOnly="True" Width="115px">Other</asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtEDFrom4" runat="server" CssClass="Input" Width="115px"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtEDTo4" runat="server" CssClass="Input" Width="115px"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtEDqualification4" runat="server" CssClass="Input" Width="115px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOtherSkills" runat="server" CssClass="Labels" Text="Other training or Skills"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtotherSkills" runat="server" CssClass="Input" Width="83%"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblhobbies" runat="server" CssClass="Labels" Text="Hobbies" Visible="False"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txthobbies" runat="server" CssClass="Input" Visible="False" Width="92%"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <center>
                                                                <asp:Button ID="cmdbuttonSave3" runat="server" CssClass="Button" OnClick="cmdbuttonSave3_Click"
                                                                    Text="Save/Next" />
                                                                <asp:Button ID="cmdbuttonNext3" runat="server" CssClass="Button" OnClick="cmdbuttonNext3_Click"
                                                                    Text="Next" Visible="false" />
                                                                <asp:Button ID="cmdbuttonFinish3" runat="server" CssClass="Button" OnClick="cmdbuttonFinish3_Click"
                                                                    Text="Finish" Visible="false" />
                                                                <asp:Button ID="Button2" runat="server" CssClass="Button" OnClick="cmdbuttonCancel_Click"
                                                                    Text="Cancel" />
                                                            </center>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                        </asp:TabPanel>
                                        <asp:TabPanel ID="tabpanel3" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="20px"
                                            HeaderText="NATIONAL SERVICE" TabIndex="3">
                                            <ContentTemplate>
                                                <table width="100%">
                                                    <tr>
                                                        <td colspan="4">
                                                            <asp:Label ID="lblheadNationalServices" runat="server" CssClass="Labels" Text="NATIONAL SERVICE"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblNSTime" runat="server" CssClass="Labels" Text="Time:  From"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtNSTime" runat="server" CssClass="Input"></asp:TextBox>
                                                            <asp:CalendarExtender ID="CalendartxtNSTime" runat="server" Format="dd/MM/yyyy" TargetControlID="txtNSTime">
                                                            </asp:CalendarExtender>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblNSTo" runat="server" CssClass="Labels" Text="To"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtNSTo" runat="server" CssClass="Input"></asp:TextBox>
                                                            <asp:CalendarExtender ID="CalendartxtNSTo" runat="server" Format="dd/MM/yyyy" TargetControlID="txtNSTo">
                                                            </asp:CalendarExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblNSTypeofDischarge" runat="server" CssClass="Labels" Text="Type of Discharge"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtNSTypeofDischarge" runat="server" CssClass="Input"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblNSVocation" runat="server" CssClass="Labels" Text="Vocation"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtNSVocation" runat="server" CssClass="Input"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblNSLastRank" runat="server" CssClass="Labels" Text="Last Rank"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtNSLastRank" runat="server" CssClass="Input"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblNSNextInCamp" runat="server" CssClass="Labels" Text="Next In-Camp"
                                                                Width="130px"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtNSNextInCamp" runat="server" CssClass="Input"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblNSExempted" runat="server" CssClass="Labels" Text="Exempted/ Deferred/ Awaiting"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtNSExempted" runat="server" CssClass="Input"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblNSReason" runat="server" CssClass="Labels" Text="Reason"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtNSReason" runat="server" CssClass="Input"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblNSPeriod" runat="server" CssClass="Labels" Text="Period/ Date of Registration"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtNSPeriod" runat="server" CssClass="Input"></asp:TextBox>
                                                            <asp:CalendarExtender ID="CalendatxtNSPeriod" runat="server" Format="dd/MM/yyyy"
                                                                TargetControlID="txtNSPeriod">
                                                            </asp:CalendarExtender>
                                                        </td>
                                                        <td colspan="2">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4">
                                                            <center>
                                                                <asp:Button ID="cmdbuttonSave4" runat="server" CssClass="Button" OnClick="cmdbuttonSave4_Click"
                                                                    Text="Save/Next" />
                                                                <asp:Button ID="cmdbuttonNext4" runat="server" CssClass="Button" OnClick="cmdbuttonNext4_Click"
                                                                    Text="Next" Visible="false" />
                                                                <asp:Button ID="cmdbuttonFinish4" runat="server" CssClass="Button" OnClick="cmdbuttonFinish4_Click"
                                                                    Text="Finish" Visible="false" />
                                                                <asp:Button ID="Button3" runat="server" CssClass="Button" OnClick="cmdbuttonCancel_Click"
                                                                    Text="Cancel" />
                                                            </center>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                        </asp:TabPanel>
                                        <asp:TabPanel ID="tabpanel4" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="20px"
                                            HeaderText="EMPLOYMENT EXPERIENCE" TabIndex="4">
                                            <ContentTemplate>
                                                <table style="border: none;" width="100%">
                                                    <tr>
                                                        <td colspan="2">
                                                            <div>
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td align="center">
                                                                            <asp:Label ID="lblEnameofCompany" runat="server" CssClass="Labels" Text="Name of Company"></asp:Label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <asp:Label ID="lblEFrom" runat="server" CssClass="Labels" Text="From"></asp:Label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <asp:Label ID="lblETo" runat="server" CssClass="Labels" Text="To"></asp:Label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <asp:Label ID="lblEReasonleave" runat="server" CssClass="Labels" Text="Reason for Leaving"></asp:Label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <asp:Label ID="lblELastDraw" runat="server" CssClass="Labels" Text="Last Drawn Salary"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox ID="txtEnameofCompany1" runat="server" CssClass="Input" Width="132px"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtEFrom1" runat="server" CssClass="Input" Width="132px"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtETo1" runat="server" CssClass="Input" Width="132px"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtEReasonleave1" runat="server" CssClass="Input" Width="132px"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtELastDraw1" runat="server" CssClass="Input" Width="132px"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox ID="txtEnameofCompany2" runat="server" CssClass="Input" Width="132px"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtEFrom2" runat="server" CssClass="Input" Width="132px"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtETo2" runat="server" CssClass="Input" Width="132px"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtEReasonleave2" runat="server" CssClass="Input" Width="132px"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtELastDraw2" runat="server" CssClass="Input" Width="132px"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox ID="txtEnameofCompany3" runat="server" CssClass="Input" Width="132px"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtEFrom3" runat="server" CssClass="Input" Width="132px"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtETo3" runat="server" CssClass="Input" Width="132px"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtEReasonleave3" runat="server" CssClass="Input" Width="132px"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtELastDraw3" runat="server" CssClass="Input" Width="132px"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox ID="txtEnameofCompany4" runat="server" CssClass="Input" Width="132px"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtEFrom4" runat="server" CssClass="Input" Width="132px"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtETo4" runat="server" CssClass="Input" Width="132px"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtEReasonleave4" runat="server" CssClass="Input" Width="132px"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtELastDraw4" runat="server" CssClass="Input" Width="132px"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblexpectedSalary" runat="server" CssClass="Labels" Text="If you are selected, your salary is :$ "></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtexpectedSalary" runat="server" CssClass="Input"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblcommencework" runat="server" CssClass="Labels" Text="If you are selected, when can you commence work :"
                                                                Visible="false"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtcommencework" runat="server" CssClass="Input" Visible="false"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblLaw" runat="server" CssClass="Labels" Text="Have you ever been convicted in a court of LAW in Singapore or any Country ?"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="DropDownList5" runat="server" AutoPostBack="True" CssClass="Input"
                                                                OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged">
                                                                <asp:ListItem>No</asp:ListItem>
                                                                <asp:ListItem>Yes</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:Panel ID="Panel11" runat="server" Visible="False">
                                                                <table>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="lblLAWyes" runat="server" CssClass="Labels" Text="If Yes, State Reason"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtLAWyes" runat="server" CssClass="Input" Width="730px"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblInjury" runat="server" CssClass="Labels" Text="Do you have any serious illness, injury or major operation ?"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="DropDownList6" runat="server" AutoPostBack="True" CssClass="Input"
                                                                OnSelectedIndexChanged="DropDownList6_SelectedIndexChanged">
                                                                <asp:ListItem>No</asp:ListItem>
                                                                <asp:ListItem>Yes</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:Panel ID="Panel1" runat="server" Visible="False">
                                                                <asp:Label ID="lblInjuryyes" runat="server" CssClass="Labels" Text="If Yes, State Reason"></asp:Label>
                                                                &nbsp;<asp:TextBox ID="txtInjuryyes" runat="server" CssClass="Input" Width="730px"></asp:TextBox>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblNRICWorkpermit" runat="server" CssClass="Labels" Text="NRIC / Work Permit"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <telerik:RadAsyncUpload ID="txtNricworkpermit" runat="server" Width="50px" Height="20px"
                                                                CssClass="input" MultipleFileSelection="Disabled" MaxFileInputsCount="1" EnableAjaxSkinRendering="True"
                                                                EnableFileInputSkinning="True">
                                                            </telerik:RadAsyncUpload>
                                                            <%--  <asp:FileUpload ID="txtNricworkpermit" runat="server" CssClass="Labels" />--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblNSRSWSQ" runat="server" CssClass="Labels" Text="NSRS / WSQ Modules"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <telerik:RadAsyncUpload ID="txtNSRSWQ" runat="server" Width="50px" Height="20px"
                                                                CssClass="input" MultipleFileSelection="Disabled" MaxFileInputsCount="1" EnableAjaxSkinRendering="True"
                                                                EnableFileInputSkinning="True">
                                                            </telerik:RadAsyncUpload>
                                                            <%--<asp:FileUpload ID="txtNSRSWQ" runat="server" CssClass="Labels" />--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblotherRecognised" runat="server" CssClass="Labels" Text="Other Recognised Qualification"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <telerik:RadAsyncUpload ID="txtotherRecognised" runat="server" Width="50px" Height="20px"
                                                                CssClass="input" MultipleFileSelection="Disabled" MaxFileInputsCount="1" EnableAjaxSkinRendering="True"
                                                                EnableFileInputSkinning="True">
                                                            </telerik:RadAsyncUpload>
                                                            <%-- <asp:FileUpload ID="txtotherRecognised" runat="server" CssClass="Labels" />--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblExemptionCertificate" runat="server" CssClass="Labels" Text="Exemption Certificate of Service"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <telerik:RadAsyncUpload ID="txtExemptionCertificate" runat="server" Width="50px"
                                                                Height="20px" CssClass="input" MultipleFileSelection="Disabled" MaxFileInputsCount="1"
                                                                EnableAjaxSkinRendering="True" EnableFileInputSkinning="True">
                                                            </telerik:RadAsyncUpload>
                                                            <%--<asp:FileUpload ID="txtExemptionCertificate" runat="server" CssClass="Labels" />--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblSecurityOfficerLicense" runat="server" CssClass="Labels" Text="Security Officer License"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <telerik:RadAsyncUpload ID="txtSecurityOfficerLicense" runat="server" Width="50px"
                                                                Height="20px" CssClass="input" MultipleFileSelection="Disabled" MaxFileInputsCount="1"
                                                                EnableAjaxSkinRendering="True" EnableFileInputSkinning="True">
                                                            </telerik:RadAsyncUpload>
                                                            <%--<asp:FileUpload ID="txtSecurityOfficerLicense" runat="server" CssClass="Labels" />--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblSIRDscreen" runat="server" CssClass="Labels" Text="SIRD Screening"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <telerik:RadAsyncUpload ID="txtSIRDscreen" runat="server" Width="50px" Height="20px"
                                                                CssClass="input" MultipleFileSelection="Disabled" MaxFileInputsCount="1" EnableAjaxSkinRendering="True"
                                                                EnableFileInputSkinning="True">
                                                            </telerik:RadAsyncUpload>
                                                            <%--<asp:FileUpload ID="" runat="server" CssClass="Labels" />--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:Button ID="cmdIssueItem" runat="server" CssClass="Button" OnClick="cmdIssueItem_Click"
                                                                Text="Issue New Items" Visible="False" />
                                                            <asp:Button ID="cmdViewIssueItem" runat="server" CssClass="Button" OnClick="cmdViewIssueItem_Click"
                                                                Text="View Issued Items" Visible="False" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <center>
                                                                <asp:Button ID="cmdbuttonSave5" runat="server" CssClass="Button" OnClick="cmdbuttonSave5_Click"
                                                                    Text="Save/Next" />
                                                                <asp:Button ID="cmdbuttonNext5" runat="server" CssClass="Button" OnClick="cmdbuttonNext5_Click"
                                                                    Text="Next" Visible="false" />
                                                                <asp:Button ID="cmdbuttonFinish5" runat="server" CssClass="Button" OnClick="cmdbuttonFinish5_Click"
                                                                    Text="Finish" Visible="false" />
                                                                <asp:Button ID="Button4" runat="server" CssClass="Button" OnClick="cmdbuttonCancel_Click"
                                                                    Text="Cancel" />
                                                            </center>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                        </asp:TabPanel>
                                        <asp:TabPanel ID="tabpanel5" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="20px"
                                            HeaderText="THUMB PRINT" TabIndex="5">
                                            <ContentTemplate>
                                                <table style="border: none; width: 700px">
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:CheckBox ID="chkAgree" runat="server" CssClass="Labels" onclick="EnableDisableEnroll(this);"
                                                                Text="Click here if you agree with the terms and conditions" Visible="false" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <%--   <div id="thumbPrint1" style="display: block">--%>
                                                            <table style="border: none; width: 700px">
                                                                <tr>
                                                                    <td>
                                                                        <center>
                                                                            <div id="thumbPrint" style="display: block; width: 700px">
                                                                                <%--<object id="DPFPVerificationControl" classid="CLSID:F4AD5526-3497-4B8C-873A-A108EA777493">
                                                                                </object>--%>
                                                                                <object id="DPFPEnrollmentControl" width="100%" classid="CLSID:0B4409EF-FD2B-4680-9519-D18C528B265E">
                                                                                    <param name="MaxEnrollFingerCount" value="4" />
                                                                                </object>
                                                                                <asp:HiddenField ID="hdnFP" runat="server" />
                                                                                <asp:HiddenField ID="hdnFP2" runat="server" />
                                                                                <br />
                                                                            </div>
                                                                        </center>
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
                                                                                        alt="Get Adobe Flash player" style="border: none" />
                                                                                    <br />
                                                                                    <a href="http://www.macromedia.com/go/getflash" />Get Flash</a></p>
                                                                        </div>
                                                                        <script type="text/javascript">


                                                                            var mainswf = new SWFObject("../take_picture.swf", "main", "700px", "350px", "9", "#ffffff");
                                                                            mainswf.addParam("scale", "noscale");
                                                                            mainswf.addParam("wmode", "window");
                                                                            mainswf.addParam("allowFullScreen", "false");
                                                                            //mainswf.addVariable("requireLogin", "false");
                                                                            mainswf.write("flashArea");
                                                                            alert("sdfdsffsd");
                                                                        </script>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <%-- </div>--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            If your flash player is not working then please choose a file manually!!
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="100px">
                                                            Select File
                                                        </td>
                                                        <td>
                                                            <%-- <asp:FileUpload ID="FileUpload1" runat="server" />--%>
                                                            <telerik:RadAsyncUpload ID="FileUpload1" runat="server" Width="50px" Height="20px"
                                                                CssClass="input" MultipleFileSelection="Disabled" MaxFileInputsCount="1" EnableAjaxSkinRendering="True"
                                                                EnableFileInputSkinning="True">
                                                            </telerik:RadAsyncUpload>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <center>
                                                                <br />
                                                                <asp:Button ID="cmdbuttonSave6" runat="server" CssClass="Button" OnClick="cmdbuttonSave6_Click"
                                                                    Text="Save" />
                                                                <asp:Button ID="cmdbuttonFinish6" runat="server" CssClass="Button" OnClick="cmdbuttonFinish6_Click"
                                                                    Text="Finish" Visible="false" />
                                                                <asp:Button ID="Button5" runat="server" CssClass="Button" OnClick="cmdbuttonCancel_Click"
                                                                    Text="Cancel" />
                                                            </center>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                        </asp:TabPanel>
                                    </asp:TabContainer>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </center>
            </asp:Panel>
            <asp:Panel ID="pnlpopupEdit" runat="server" Visible="false" Width="100%">
                <table style="border: none; width: 100px !important; overflow: visible;">
                    <tr>
                        <td>
                            <asp:TabContainer ID="TabContainer2" runat="server" Font-Bold="True">
                                <asp:TabPanel ID="TabPanelUpda" HeaderText="PERSONAL PARTICULARS" runat="server"
                                    ForeColor="Red" Font-Bold="True" Font-Size="20px" Font-Names="Arial" Width="100%">
                                    <ContentTemplate>
                                        <table style="border: none;">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblStaffID" CssClass="Labels" runat="server" Text="Staff ID" Visible="False"></asp:Label>
                                                    <asp:Label ID="Label2" CssClass="Labels" runat="server" Text="Name"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="DropDownList8" runat="server" CssClass="Input">
                                                        <asp:ListItem>Mr</asp:ListItem>
                                                        <asp:ListItem>Miss</asp:ListItem>
                                                        <asp:ListItem>Mrs</asp:ListItem>
                                                        <asp:ListItem>Mdm</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:TextBox ID="txtStaff_ID" CssClass="Input" runat="server" ReadOnly="True" Visible="False"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label3" CssClass="Labels" runat="server" Text="First Name"></asp:Label>
                                                    <asp:Label ID="Label4" CssClass="ValSummary" runat="server" Text="*" Font-Bold="True"
                                                        Font-Size="Small" ForeColor="Red"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtFnameUpda" CssClass="Input" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label5" CssClass="Labels" runat="server" Text="Middle Name"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtMnameUpda" CssClass="Input" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label6" CssClass="Labels" runat="server" Text="Last Name"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtLnameUpda" CssClass="Input" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label7" CssClass="Labels" runat="server" Text="Home Address"></asp:Label>
                                                </td>
                                                <td colspan="5">
                                                    <asp:TextBox ID="txtHomeAdressUpda" CssClass="Input" runat="server" Height="50px"
                                                        Width="400px" TextMode="MultiLine"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label8" CssClass="Labels" runat="server" Text="Marital Status"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="DropDownList9" runat="server" CssClass="Input" AutoPostBack="True"
                                                        OnSelectedIndexChanged="DropDownList4_SelectedIndexChangedUpda">
                                                        <asp:ListItem>Single</asp:ListItem>
                                                        <asp:ListItem>Married</asp:ListItem>
                                                        <asp:ListItem>Divorced</asp:ListItem>
                                                        <asp:ListItem>Widowed</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="8">
                                                    <asp:Panel ID="Panel6" runat="server" Visible="False">
                                                        <table width="100%">
                                                            <tr>
                                                                <td colspan="4">
                                                                    <asp:Label ID="Label9" CssClass="Labels" runat="server" Text="If Married :" Font-Bold="True"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label10" CssClass="Labels" runat="server" Text="State spouse's name :"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtSpousenameUpda" CssClass="Input" runat="server"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label11" CssClass="Labels" runat="server" Text="No. of Children"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtnoOfChildernUpda" CssClass="Input" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label12" CssClass="Labels" runat="server" Text="Phone No."></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPhoneUpda" CssClass="Input" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label14" CssClass="Labels" runat="server" Text="Mobile No."></asp:Label>
                                                    <asp:Label ID="Label28" runat="server" CssClass="ValSummary" Font-Bold="True" Font-Size="Small"
                                                        ForeColor="Red" Text="*"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtMobNoUpda" CssClass="Input" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label16" CssClass="Labels" runat="server" Text="Date of Birth"></asp:Label>
                                                </td>
                                                <td colspan="2">
                                                    <asp:TextBox ID="txtDOBUpda" CssClass="Input" runat="server" AutoPostBack="True"
                                                        OnTextChanged="txtDOB_TextChanged" Width="130px"></asp:TextBox>
                                                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="AjaxCalendar"
                                                        Format="MM/dd/yyyy" Enabled="True" PopupButtonID="ImageButton3" TargetControlID="txtDOBUpda" />
                                                    <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Images/calendar.bmp"
                                                        class="calender" Style="margin: -20px 0px 0px 110px;" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label15" CssClass="Labels" runat="server" Text="H/P No." Visible="False"></asp:Label>
                                                    <asp:TextBox ID="txtHPUpda" CssClass="Input" runat="server" Visible="False"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label17" CssClass="Labels" runat="server" Text="Place Of Birth"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPOBUpda" CssClass="Input" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label18" CssClass="Labels" runat="server" Text="Race"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtraceUpda" CssClass="Input" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label19" CssClass="Labels" runat="server" Text="NRIC/FIN No."></asp:Label>
                                                    <asp:Label ID="Label20" CssClass="ValSummary" runat="server" Text="*" Font-Bold="True"
                                                        Font-Size="Small" ForeColor="Red"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtnricUpda" CssClass="Input" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label21" CssClass="Labels" runat="server" Text="Citizenship"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="DropDownList10" runat="server" CssClass="Input" AutoPostBack="True"
                                                        OnSelectedIndexChanged="DropDownList2_SelectedIndexChangedUpda">
                                                        <asp:ListItem>Singapore</asp:ListItem>
                                                        <asp:ListItem>Malaysian</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="8">
                                                    <asp:Panel ID="Panel7" runat="server" Visible="False">
                                                        <table width="100%">
                                                            <tr>
                                                                <td colspan="6">
                                                                    <asp:Label ID="Label23" CssClass="Labels" runat="server" Text="If Malasian :" Font-Bold="True"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label24" CssClass="Labels" runat="server" Text="New IC No.:"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtMalaysianICnoUpda" CssClass="Input" runat="server"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label25" CssClass="Labels" runat="server" Text="Old IC No.:"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtMalaysianOldICUpda" CssClass="Input" runat="server"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label26" CssClass="Labels" runat="server" Text="Passport No.:"></asp:Label>
                                                                </td>
                                                                <td align="right">
                                                                    <asp:TextBox ID="txtMalasianPassportUpda" CssClass="Input" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label27" CssClass="Labels" runat="server" Text="Passport Expiry Date :"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtMalasianPassportExpdateUpda" CssClass="Input" runat="server"></asp:TextBox>
                                                                    <asp:CalendarExtender ID="CalendarExtender6" runat="server" CssClass="AjaxCalendar"
                                                                        Format="MM/dd/yyyy" TargetControlID="txtMalasianPassportExpdate" PopupButtonID="ImageButton6"
                                                                        Enabled="True" />
                                                                    <asp:ImageButton ID="ImageButton6" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"
                                                                        Width="16px" />
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblMalasianWorkPermitNoUpda" CssClass="Labels" runat="server" Text="Work Permit No.:"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtMalasianWorkPermitNoUpda" CssClass="Input" runat="server"></asp:TextBox>
                                                                </td>
                                                                <td colspan="2">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="lblMalasianWorkPermitExpUpda" CssClass="Labels" runat="server" Text="Work Permit Expiry Date :"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtMalasianWorkPermitExpUpda" CssClass="Input" runat="server" Width="120px"></asp:TextBox>
                                                                    <asp:CalendarExtender ID="CalendarExtender7" runat="server" CssClass="AjaxCalendar"
                                                                        Format="MM/dd/yyyy" TargetControlID="txtMalasianWorkPermitExp" PopupButtonID="imgBtnFromDate2"
                                                                        Enabled="True" />
                                                                    <asp:ImageButton ID="imgBtnFromDate2" runat="server" ImageUrl="~/Images/calendar.bmp"
                                                                        class="calender" Style="float: right; margin-top: -21px; margin-right: 75px;
                                                                        height: 17px" />
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblMalasianEducationaLevelUpda" CssClass="Labels" runat="server" Text="Educational Level"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="DropDownList7Upda" runat="server" CssClass="Input">
                                                                        <asp:ListItem></asp:ListItem>
                                                                        <asp:ListItem>Primary</asp:ListItem>
                                                                        <asp:ListItem>SRP</asp:ListItem>
                                                                        <asp:ListItem>SPM</asp:ListItem>
                                                                        <asp:ListItem>STPM</asp:ListItem>
                                                                        <asp:ListItem>Diploma</asp:ListItem>
                                                                        <asp:ListItem>Degree</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td colspan="2">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label22" CssClass="Labels" runat="server" Text="Age"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtageUpda" CssClass="Input" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblreligionUpda" CssClass="Labels" runat="server" Text="Religion"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtreligionUpda" CssClass="Input" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblsexUpda" CssClass="Labels" runat="server" Text="Sex"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="DropDownList3Upda" runat="server" CssClass="Input">
                                                        <asp:ListItem>Male</asp:ListItem>
                                                        <asp:ListItem>Female</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblDlicenseUpda" CssClass="Labels" runat="server" Text="Driving License"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtDlicenseUpda" CssClass="Input" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="8">
                                                    <asp:Label ID="lblheadEmergencyUpda" CssClass="Labels" runat="server" Text="In case of Emergency, to notify:"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblemergencyNameUpda" CssClass="Labels" runat="server" Text="Name"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtEmergencyNameUpda" CssClass="Input" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblEmergenContNoUpda" CssClass="Labels" runat="server" Text="Telephone No."></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtEmergencContNoUpda" CssClass="Input" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblEmergenAddressUpda" CssClass="Labels" runat="server" Text="Address"></asp:Label>
                                                </td>
                                                <td colspan="3">
                                                    <asp:TextBox ID="txtEmergenAddressUpda" CssClass="Input" runat="server" Width="300px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblRoleUpdaUpda" CssClass="Labels" runat="server" Text="Sub Role"></asp:Label>
                                                    <asp:Label ID="Label13" runat="server" CssClass="ValSummary" Font-Bold="True" Font-Size="Small"
                                                        ForeColor="Red" Text="*"></asp:Label>
                                                </td>
                                                <td colspan="3">
                                                    <asp:DropDownList ID="ddlRoleUpda" runat="server" CssClass="Input" Width="160px">
                                                    </asp:DropDownList>
                                                    <asp:Label ID="AddNewLabelUpda" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td colspan="5">
                                                    <asp:TextBox ID="txtNewRoleDefineUpda" CssClass="Input" runat="server" Visible="False"></asp:TextBox>
                                                    <asp:Button ID="cmdbuttonaddUpda" CssClass="Button" runat="server" Text="ADD" Width="46px"
                                                        OnClick="cmdbuttonadd_Click" Visible="False" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblStaffuseridUpda" CssClass="Labels" runat="server" Text="User ID"></asp:Label>
                                                    <asp:Label ID="errUseridUpda" CssClass="ValSummary" runat="server" Text="*" Font-Bold="True"
                                                        Font-Size="Small" ForeColor="Red"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtStaffUseridUpda" CssClass="Input" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblStaffuserPasswordUpda" CssClass="Labels" runat="server" Text="User Password"
                                                        Visible="False"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtStaffUserPasswordUpda" CssClass="Input" runat="server" ReadOnly="True"
                                                        Visible="False"></asp:TextBox>
                                                    <asp:Label ID="errUserPasswordUpda" CssClass="ValSummary" runat="server" Text="*"
                                                        Font-Bold="True" Font-Size="Small" ForeColor="Red" Visible="false"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblStaffuserConfigPasswordUpda" CssClass="Labels" runat="server" Text="Confirm Password"
                                                        Visible="False"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtStaffuserConfigPasswordUpda" CssClass="Input" runat="server"
                                                        ReadOnly="True" Visible="False"></asp:TextBox>
                                                </td>
                                                <td colspan="2">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <asp:Label ID="lblStaffSeurityqtyUpda" CssClass="Labels" runat="server" Text="Select Security Question"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlStaffSecQuesUpda" runat="server" CssClass="Input" Width="170px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:Label ID="securityanswer" runat="server" Text="Label" CssClass="Labels" Width="150px"
                                                        Visible="false"></asp:Label>
                                                </td>
                                                <td colspan="3">
                                                    <asp:TextBox ID="txtStaffSeurityqtyUpda" CssClass="Input" runat="server" Width="150px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="8">
                                                    <center>
                                                        <asp:Button ID="cmdbuttonSaveUpda" CssClass="Button" runat="server" Text="Update"
                                                            Width="85px" OnClick="cmdbuttonSave_Click" />
                                                        <asp:Button ID="Button6" runat="server" CssClass="Button" OnClick="cmdbuttonCancel_Click"
                                                            Text="Cancel" />
                                                    </center>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:TabPanel>
                                <asp:TabPanel ID="TabPanel7Upda" HeaderText="PERSONAL PARTICULARS:2" runat="server"
                                    Visible="false" Font-Bold="True" Font-Size="20px" Font-Names="Arial">
                                    <ContentTemplate>
                                        <table style="width: 900px">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblIncomeTaxUpda" CssClass="Labels" runat="server" Text="Income Tax"
                                                        Visible="false"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtincometaxUpda" CssClass="Input" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblOccupationUpda" CssClass="Labels" runat="server" Text="Occupation"
                                                        Visible="false"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtOccupationUpda" CssClass="Input" runat="server" Visible="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="20px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="6">
                                                    <asp:Button ID="cmdbuttonSave1" CssClass="Button" runat="server" Text="Save" Width="85px"
                                                        OnClick="cmdbuttonSave1_Click" Visible="false" />
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:TabPanel>
                                <asp:TabPanel ID="TabPanel2Upda" HeaderText="EDUCATIONAL DETAILS" runat="server"
                                    Font-Bold="True" Font-Size="20px" Font-Names="Arial">
                                    <ContentTemplate>
                                        <table style="border: none; width: 900px">
                                            <tr>
                                                <td colspan="2">
                                                    <table width="100%">
                                                        <tr>
                                                            <td align="center">
                                                                <asp:Label ID="lblnameofSchoolUpda" CssClass="Labels" runat="server" Text="Name of School"></asp:Label>
                                                            </td>
                                                            <td align="center">
                                                                <asp:Label ID="lbladdresUpda" CssClass="Labels" runat="server" Text="Address"></asp:Label>
                                                            </td>
                                                            <td align="center">
                                                                <asp:Label ID="lblLevelUpda" CssClass="Labels" runat="server" Text="Level"></asp:Label>
                                                            </td>
                                                            <td align="center">
                                                                <asp:Label ID="lblFromUpda" CssClass="Labels" runat="server" Text="From"></asp:Label>
                                                            </td>
                                                            <td align="center">
                                                                <asp:Label ID="lblToUpda" CssClass="Labels" runat="server" Text="To"></asp:Label>
                                                            </td>
                                                            <td align="center">
                                                                <asp:Label ID="lblqualificationUpda" CssClass="Labels" runat="server" Text="Qualification"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txtEDnameofSchool1Upda" CssClass="Input" runat="server" Width="115px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtEDaddres1Upda" CssClass="Input" runat="server" Width="115px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtEDLeve1Upda" CssClass="Input" runat="server" ReadOnly="True"
                                                                    Width="115px">Primary</asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtEDFrom1Upda" CssClass="Input" runat="server" Width="115px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtEDTo1Upda" CssClass="Input" runat="server" Width="115px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtEDqualification1Upda" CssClass="Input" runat="server" Width="115px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txtEDnameofSchool2Upda" CssClass="Input" runat="server" Width="115px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtEDaddres2Upda" CssClass="Input" runat="server" Width="115px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtEDLeve2Upda" CssClass="Input" runat="server" ReadOnly="True"
                                                                    Width="115px">Secondary</asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtEDFrom2Upda" CssClass="Input" runat="server" Width="115px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtEDTo2Upda" CssClass="Input" runat="server" Width="115px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtEDqualification2Upda" CssClass="Input" runat="server" Width="115px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txtEDnameofSchool3Upda" CssClass="Input" runat="server" Width="115px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtEDaddres3Upda" CssClass="Input" runat="server" Width="115px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtEDLeve3Upda" CssClass="Input" runat="server" ReadOnly="True"
                                                                    Width="115px">Vocational</asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtEDFrom3Upda" CssClass="Input" runat="server" Width="115px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtEDTo3Upda" CssClass="Input" runat="server" Width="115px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtEDqualification3Upda" CssClass="Input" runat="server" Width="115px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txtEDnameofSchool4Upda" CssClass="Input" runat="server" Width="115px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtEDaddres4Upda" CssClass="Input" runat="server" Width="115px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtEDLeve4Upda" CssClass="Input" runat="server" ReadOnly="True"
                                                                    Width="115px">Other</asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtEDFrom4Upda" CssClass="Input" runat="server" Width="115px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtEDTo4Upda" CssClass="Input" runat="server" Width="115px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtEDqualification4Upda" CssClass="Input" runat="server" Width="115px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblOtherSkillsUpda" CssClass="Labels" runat="server" Text="Other training or Skills"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtotherSkillsUpda" CssClass="Input" runat="server" Width="83%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblhobbiesUpda" CssClass="Labels" runat="server" Text="Hobbies" Visible="False"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txthobbiesUpda" CssClass="Input" runat="server" Width="92%" Visible="False"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <center>
                                                        <asp:Button ID="cmdbuttonSave2" CssClass="Button" runat="server" Text="Update" Width="85px"
                                                            OnClick="cmdbuttonSave2_Click" />
                                                        <asp:Button ID="Button7" runat="server" CssClass="Button" OnClick="cmdbuttonCancel_Click"
                                                            Text="Cancel" />
                                                    </center>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:TabPanel>
                                <asp:TabPanel ID="TabPanel3Upda" HeaderText="NATIONAL SERVICE" runat="server" Font-Bold="True"
                                    Font-Size="20px" Font-Names="Arial">
                                    <ContentTemplate>
                                        <table style="border: none; width: 900px">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblNSTimeUpda" CssClass="Labels" runat="server" Text="Time:  From"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtNSTimeUpda" CssClass="Input" runat="server"></asp:TextBox>
                                                    <asp:CalendarExtender ID="CalendarExtender3" runat="server" CssClass="AjaxCalendar"
                                                        Format="MM/dd/yyyy" TargetControlID="txtNSTimeUpda" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblNSToUpda" CssClass="Labels" runat="server" Text="To"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtNSToUpda" CssClass="Input" runat="server"></asp:TextBox>
                                                    <asp:CalendarExtender ID="CalendarExtender4" runat="server" CssClass="AjaxCalendar"
                                                        Format="MM/dd/yyyy" TargetControlID="txtNSToUpda" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblNSTypeofDischargeUpda" CssClass="Labels" runat="server" Text="Type of Discharge"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtNSTypeofDischargeUpda" CssClass="Input" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblNSVocationUpda" CssClass="Labels" runat="server" Text="Vocation"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtNSVocationUpda" CssClass="Input" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblNSLastRankUpda" CssClass="Labels" runat="server" Text="Last Rank"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtNSLastRankUpda" CssClass="Input" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblNSNextInCampUpda" CssClass="Labels" runat="server" Text="Next In-Camp"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtNSNextInCampUpda" CssClass="Input" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblNSExemptedUpda" CssClass="Labels" runat="server" Text="Exempted/ Deferred/ Awaiting"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtNSExemptedUpda" CssClass="Input" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblNSReasonUpda" CssClass="Labels" runat="server" Text="Reason"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtNSReasonUpda" CssClass="Input" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblNSPeriodUpda" CssClass="Labels" runat="server" Text="Period/ Date of Registration"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtNSPeriodUpda" CssClass="Input" runat="server"></asp:TextBox>
                                                    <asp:CalendarExtender ID="CalendarExtender5" runat="server" CssClass="AjaxCalendar"
                                                        Format="MM/dd/yyyy" TargetControlID="txtNSPeriodUpda" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <center>
                                                        <asp:Button ID="cmdbuttonSave3Upda" CssClass="Button" runat="server" Text="Update"
                                                            OnClick="cmdbuttonSave3_ClickUpda" />
                                                        <asp:Button ID="Button8" runat="server" CssClass="Button" OnClick="cmdbuttonCancel_Click"
                                                            Text="Cancel" />
                                                    </center>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:TabPanel>
                                <asp:TabPanel ID="TabPanel4Upda" HeaderText="EMPLOYMENT EXPERIENCE" runat="server"
                                    Font-Bold="True" Font-Size="20px" Font-Names="Arial">
                                    <ContentTemplate>
                                        <table style="border: none; width: 900px">
                                            <tr>
                                                <td colspan="2">
                                                    <table width="900px">
                                                        <tr>
                                                            <td align="center">
                                                                <asp:Label ID="lblEnameofCompanyUpda" CssClass="Labels" runat="server" Text="Name of Company"></asp:Label>
                                                            </td>
                                                            <td align="center">
                                                                <asp:Label ID="lblEFromUpda" CssClass="Labels" runat="server" Text="From"></asp:Label>
                                                            </td>
                                                            <td align="center">
                                                                <asp:Label ID="lblEToUpda" CssClass="Labels" runat="server" Text="To"></asp:Label>
                                                            </td>
                                                            <td align="center">
                                                                <asp:Label ID="lblEReasonleaveUpda" CssClass="Labels" runat="server" Text="Reason for Leaving"></asp:Label>
                                                            </td>
                                                            <td align="center">
                                                                <asp:Label ID="lblELastDrawUpda" CssClass="Labels" runat="server" Text="Last Drawn Salary"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txtEnameofCompany1Upda" CssClass="Input" runat="server" Width="132px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtEFrom1Upda" CssClass="Input" runat="server" Width="132px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtETo1Upda" CssClass="Input" runat="server" Width="132px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtEReasonleave1Upda" CssClass="Input" runat="server" Width="132px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtELastDraw1Upda" CssClass="Input" runat="server" Width="132px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txtEnameofCompany2Upda" CssClass="Input" runat="server" Width="132px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtEFrom2Upda" CssClass="Input" runat="server" Width="132px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtETo2Upda" CssClass="Input" runat="server" Width="132px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtEReasonleave2Upda" CssClass="Input" runat="server" Width="132px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtELastDraw2Upda" CssClass="Input" runat="server" Width="132px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txtEnameofCompany3Upda" CssClass="Input" runat="server" Width="132px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtEFrom3Upda" CssClass="Input" runat="server" Width="132px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtETo3Upda" CssClass="Input" runat="server" Width="132px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtEReasonleave3Upda" CssClass="Input" runat="server" Width="132px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtELastDraw3Upda" CssClass="Input" runat="server" Width="132px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txtEnameofCompany4Upda" CssClass="Input" runat="server" Width="132px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtEFrom4Upda" CssClass="Input" runat="server" Width="132px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtETo4Upda" CssClass="Input" runat="server" Width="132px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtEReasonleave4Upda" CssClass="Input" runat="server" Width="132px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtELastDraw4Upda" CssClass="Input" runat="server" Width="132px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblexpectedSalaryUpda" CssClass="Labels" runat="server" Text="If you are selected,your salary is :$ "></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtexpectedSalaryUpda" CssClass="Input" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblcommenceworkUpda" CssClass="Labels" runat="server" Text="If you are selected, when can you commence work :"
                                                        Visible="false"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtcommenceworkUpda" CssClass="Input" runat="server" Visible="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblLawUpda" CssClass="Labels" runat="server" Text="Have you ever been convicted in a court of LAW in Singapore or any Country ?"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="DropDownList5Upda" runat="server" CssClass="Input" AutoPostBack="True"
                                                        OnSelectedIndexChanged=" DropDownList5_SelectedIndexChangedUpda">
                                                        <asp:ListItem>No</asp:ListItem>
                                                        <asp:ListItem>Yes</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Panel ID="Panel1Upda" runat="server" Visible="False">
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblLAWyesUpda" CssClass="Labels" runat="server" Text="If Yes, State Reason"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtLAWyesUpda" CssClass="Input" runat="server" Width="730px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblInjuryUpda" CssClass="Labels" runat="server" Text="Do you have any serious illness, injury or major operation ?"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="DropDownList6Upda" runat="server" CssClass="Input" AutoPostBack="True"
                                                        OnSelectedIndexChanged=" DropDownList6_SelectedIndexChangedUpda">
                                                        <asp:ListItem>No</asp:ListItem>
                                                        <asp:ListItem>Yes</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Panel ID="Panel2Upda" runat="server" Visible="False">
                                                        <asp:Label ID="lblInjuryyesUpda" CssClass="Labels" runat="server" Text="If Yes, State Reason"></asp:Label>
                                                        &nbsp;<asp:TextBox ID="txtInjuryyesUpda" CssClass="Input" runat="server" Width="730px"></asp:TextBox><br />
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblNRICWorkpermitUpda" Text="NRIC / Work Permit" CssClass="Labels"
                                                        runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <telerik:RadAsyncUpload ID="txtNricworkpermitUpda" runat="server" Width="50px" Height="20px"
                                                        CssClass="input" MultipleFileSelection="Disabled" MaxFileInputsCount="1" EnableAjaxSkinRendering="True"
                                                        EnableFileInputSkinning="True">
                                                    </telerik:RadAsyncUpload>
                                                    <%-- <asp:FileUpload ID="txtNricworkpermitUpda" runat="server" CssClass="Labels"></asp:FileUpload>--%>
                                                    &nbsp;
                                                  <%--  <asp:HyperLink ID="hypNRICWorkPermit" runat="server" Target="_blank" CssClass="Labels"
                                                        Font-Bold="True">Click Here To View</asp:HyperLink>--%>
                                                        <asp:LinkButton ID="hypNRICWorkPermit" runat="server" CssClass="Labels"
                                                        Font-Bold="True" OnClick="hypNRICWorkPermit_Click"></asp:LinkButton>
                                                    &nbsp;&nbsp;
                                                    <asp:Button ID="btnNRICWorkpermit" CssClass="Button" runat="server" Text="DELETE"
                                                        Width="56px" Visible="False" OnClick="btnNRICWorkpermit_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblNSRSWSQUpda" Text="NSRS / WSQ Modules" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <telerik:RadAsyncUpload ID="txtNSRSWQUpda" runat="server" Width="50px" Height="20px"
                                                        CssClass="input" MultipleFileSelection="Disabled" MaxFileInputsCount="1" EnableAjaxSkinRendering="True"
                                                        EnableFileInputSkinning="True">
                                                    </telerik:RadAsyncUpload>
                                                    <%-- <asp:FileUpload ID="txtNSRSWQUpda" runat="server" CssClass="Labels"></asp:FileUpload>--%>&nbsp;&nbsp;
                                                    <%--<asp:HyperLink ID="hypNSRSWSQModule" Target="_blank" runat="server" CssClass="Labels"
                                                        Font-Bold="True">Click Here To View</asp:HyperLink>--%>
                                                         <asp:LinkButton ID="hypNSRSWSQModule" runat="server" CssClass="Labels"
                                                        Font-Bold="True" OnClick="hypNSRSWSQModule_Click"></asp:LinkButton>
                                                    &nbsp;&nbsp;
                                                    <asp:Button ID="BtnNSRSWSQModules" CssClass="Button" runat="server" Text="DELETE"
                                                        Width="56px" Visible="False" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblotherRecognisedUpda" Text="Other Recognised Qualification" CssClass="Labels"
                                                        runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <telerik:RadAsyncUpload ID="txtotherRecognisedUpda" runat="server" Width="50px" Height="20px"
                                                        CssClass="input" MultipleFileSelection="Disabled" MaxFileInputsCount="1" EnableAjaxSkinRendering="True"
                                                        EnableFileInputSkinning="True">
                                                    </telerik:RadAsyncUpload>
                                                    <%-- <asp:FileUpload ID="txtotherRecognisedUpda" runat="server" CssClass="Labels"></asp:FileUpload>--%>
                                                    &nbsp;&nbsp;
                                                     <asp:LinkButton ID="hypOtherRecoQualify" runat="server" CssClass="Labels"
                                                        Font-Bold="True" OnClick="hypOtherRecoQualify_Click"></asp:LinkButton>
                                                   <%-- <asp:HyperLink ID="hypOtherRecoQualify" Target="_blank" runat="server" CssClass="Labels"
                                                        Font-Bold="True">Click Here To View</asp:HyperLink>--%>
                                                    &nbsp;&nbsp;
                                                    <asp:Button ID="BtnOtherRecognised" CssClass="Button" runat="server" Text="DELETE"
                                                        Width="56px" Visible="False" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblExemptionCertificateUpda" Text="Exemption Certificate of Service"
                                                        CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <telerik:RadAsyncUpload ID="txtExemptionCertificateUpda" runat="server" Width="50px"
                                                        Height="20px" CssClass="input" MultipleFileSelection="Disabled" MaxFileInputsCount="1"
                                                        EnableAjaxSkinRendering="True" EnableFileInputSkinning="True">
                                                    </telerik:RadAsyncUpload>
                                                    <%-- <asp:FileUpload ID="txtExemptionCertificateUpda" runat="server" CssClass="Labels">
                                                                </asp:FileUpload>--%>
                                                    &nbsp;&nbsp;
                                                     <asp:LinkButton ID="hypExemptionCertificate" runat="server" CssClass="Labels"
                                                        Font-Bold="True" OnClick="hypExemptionCertificate_Click"></asp:LinkButton>
                                                  <%--  <asp:HyperLink ID="hypExemptionCertificate" Target="_blank" runat="server" CssClass="Labels"
                                                        Font-Bold="True">Click Here To View</asp:HyperLink>--%>
                                                    &nbsp;&nbsp;
                                                    <asp:Button ID="BtnExemptionCertificate" CssClass="Button" runat="server" Text="DELETE"
                                                        Width="56px" Visible="False" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblSecurityOfficerLicenseUpda" Text="Security Officer License" CssClass="Labels"
                                                        runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <telerik:RadAsyncUpload ID="txtSecurityOfficerLicenseUpda" runat="server" Width="50px"
                                                        Height="20px" CssClass="input" MultipleFileSelection="Disabled" MaxFileInputsCount="1"
                                                        EnableAjaxSkinRendering="True" EnableFileInputSkinning="True">
                                                    </telerik:RadAsyncUpload>
                                                    <%-- <asp:FileUpload ID="txtSecurityOfficerLicenseUpda" runat="server" CssClass="Labels">
                                                                </asp:FileUpload>--%>
                                                    &nbsp;&nbsp;
                                                     <asp:LinkButton ID="hypSecurityOfficerLicense" runat="server" CssClass="Labels"
                                                        Font-Bold="True" OnClick="hypSecurityOfficerLicenset_Click"></asp:LinkButton>
                                                  <%--  <asp:HyperLink ID="hypSecurityOfficerLicense" Target="_blank" runat="server" CssClass="Labels"
                                                        Font-Bold="True">Click Here To View</asp:HyperLink>--%>
                                                    &nbsp;&nbsp;
                                                    <asp:Button ID="BtnSecurityOfficer" CssClass="Button" runat="server" Text="DELETE"
                                                        Width="56px" Visible="False" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblSIRDscreenUpda" Text="SIRD Screening" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <telerik:RadAsyncUpload ID="txtSIRDscreenUpda" runat="server" Width="50px" Height="20px"
                                                        CssClass="input" MultipleFileSelection="Disabled" MaxFileInputsCount="1" EnableAjaxSkinRendering="True"
                                                        EnableFileInputSkinning="True">
                                                    </telerik:RadAsyncUpload>
                                                    <%--<asp:FileUpload ID="txtSIRDscreenUpda" runat="server" CssClass="Labels"></asp:FileUpload>--%>
                                                    &nbsp;&nbsp;
                                                  <%--  <asp:HyperLink ID="hypSIRDScreen" Target="_blank" runat="server" CssClass="Labels"
                                                        Font-Bold="True">Click Here To View</asp:HyperLink>--%>
                                                         <asp:LinkButton ID="hypSIRDScreen" runat="server" CssClass="Labels"
                                                        Font-Bold="True" OnClick="hypSIRDScreen_Click"></asp:LinkButton>
                                                    &nbsp;&nbsp;
                                                    <asp:Button ID="BtnSIRDScreening" CssClass="Button" runat="server" Text="DELETE"
                                                        Width="56px" Visible="False" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <center>
                                                        <asp:Button ID="cmdbuttonSave4Upda" CssClass="Button" runat="server" Text="Update"
                                                            OnClick="cmdbuttonSave4Upda_Click" />
                                                        <asp:Button ID="Button9" runat="server" CssClass="Button" OnClick="cmdbuttonCancel_Click"
                                                            Text="Cancel" />
                                                    </center>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:TabPanel>
                                <asp:TabPanel ID="TabPanel5Upda" HeaderText="THUMB PRINT" runat="server" Font-Bold="True"
                                    Font-Size="20px" Font-Names="Arial">
                                    <ContentTemplate>
                                        <table style="border: none; width: 900px">
                                            <tr>
                                                <td>
                                                    <asp:CheckBox ID="chkAgreeUpda" runat="server" CssClass="Labels" Text="Enroll Finger Print & Capture Photo"
                                                        onclick="EnableDisableEnroll(this);" Visible="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div id="thumbPrintUpda" style="display: block; border: none;">
                                                        <table width="100%" style="border: none;">
                                                            <tr>
                                                                <td align="center" colspan="2">
                                                                    <object id="DPFPEnrollmentControlUpda" classid="CLSID:0B4409EF-FD2B-4680-9519-D18C528B265E">
                                                                        <param name="MaxEnrollFingerCount" value="4" />
                                                                    </object>
                                                                    <asp:HiddenField ID="hdnFPUpda" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center">
                                                                    <div id="flashAreaUpda" class="flashArea" style="height: 100%;">
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
                                                                        mainswf.write("flashAreaUpda");
                                                                    </script>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Image ID="ImgageStaff" runat="server" Width="90px" Height="80px" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    If your flash player is not working then please choose a file manually!!
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    Select File
                                                                    <%--  <asp:FileUpload ID="FileUpload1Upda" runat="server" Style="margin: -20px 0px 0px 70px" />--%>
                                                                    <telerik:RadAsyncUpload ID="FileUpload1Upda" runat="server" Width="50px" Height="20px"
                                                                        Style="margin: -20px 0px 0px 70px" CssClass="input" MultipleFileSelection="Disabled"
                                                                        MaxFileInputsCount="1" EnableAjaxSkinRendering="True" EnableFileInputSkinning="True">
                                                                    </telerik:RadAsyncUpload>
                                                                </td>
                                                                <td align="center">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <center>
                                                                        <br />
                                                                        <asp:Button ID="cmdbuttonSave5Upda" CssClass="Button" runat="server" Text="Update"
                                                                            OnClick="cmdbuttonSave5_ClickUpda" />
                                                                        <asp:Button ID="Button10" runat="server" CssClass="Button" OnClick="cmdbuttonCancel_Click"
                                                                            Text="Cancel" />
                                                                    </center>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:TabPanel>
                            </asp:TabContainer>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblerror1Upda" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"></asp:Label>
                            <asp:TextBox ID="userrole" runat="server" Visible="false"></asp:TextBox>
                            <asp:HiddenField ID="hdnBTID" runat="server" Value="" />
                            <asp:HiddenField ID="hdnBTName" runat="server" Value="" />
                            <asp:Label ID="lnkLabel1Upda" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="lnkLabel2Upda" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="lnkLabel3Upda" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="lnkLabel4Upda" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="lnkLabel5Upda" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="lnkLabel6Upda" runat="server" Visible="false"></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <br />
            <table width="100%" style="border: 0; margin-top: -7.2px">
                <tr style="vertical-align: top;">
                    <td style="width: 80%">
                        <asp:Panel ID="Panelgrid" runat="server">
                            <telerik:RadGrid ID="gvLoctionTable" runat="server" CssClass="RadGrid" GridLines="None"
                                HeaderStyle-Font-Size="12px" AllowPaging="True" PageSize="10" AllowSorting="True"
                                AutoGenerateColumns="False" ShowStatusBar="true" Skin="Simple" HeaderStyle-HorizontalAlign="left"
                                HeaderStyle-BackColor="#ad1c1c" HeaderStyle-ForeColor="white" AllowMultiRowSelection="false"
                                AllowFilteringByColumn="true">
                                <GroupingSettings CaseSensitive="false" />
                                <MasterTableView CommandItemDisplay="Bottom" DataKeyNames="Staff_ID">
                                    <CommandItemSettings ShowAddNewRecordButton="false" ShowRefreshButton="false" />
                                    <Columns>
                                        <telerik:GridTemplateColumn UniqueName="CheckBoxTemplateColumn" ShowFilterIcon="false"
                                            AllowFiltering="false">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="ToggleRowSelection"
                                                    AutoPostBack="True" />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn UniqueName="FirstName" HeaderText="First Name" DataField="FirstName"
                                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn UniqueName="NRICno" HeaderText="NRIC no" DataField="NRICno"
                                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn UniqueName="Staff_Telphone" HeaderText="Staff_Telphone"
                                            DataField="Staff_Telphone" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true"
                                            ShowFilterIcon="false">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn UniqueName="Role" HeaderText="Role" DataField="Role" CurrentFilterFunction="Contains"
                                            AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn ShowFilterIcon="false">
                                            <ItemTemplate>
                                                <asp:Image ID="img" runat="server" ImageUrl='<%# Eval("ImagePathName") %>' Width="80px"
                                                    Height="80px" />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                </MasterTableView>
                                <SelectedItemStyle BorderWidth="0px" Font-Bold="true" ForeColor="White" BackColor="Red" />
                            </telerik:RadGrid>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </div>
        <asp:HiddenField ID="hdnAdd" runat="server" />
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <asp:HiddenField ID="lnkDelete" runat="server" />
        <asp:ModalPopupExtender ID="ModalPopupOK" runat="server" TargetControlID="HiddenField1"
            BackgroundCssClass="modalBackground" PopupControlID="PnlOk">
        </asp:ModalPopupExtender>
        <asp:Panel ID="PnlOk" runat="server" BackColor="White" Height="270px" Width="320px"
            BorderWidth="2px" Style="display: none">
            <asp:UpdateProgress ID="UpdateProgress59" DisplayAfter="10" runat="server" AssociatedUpdatePanelID="UpdatePanel139">
                <ProgressTemplate>
                    <div class="divWaiting">
                        <asp:Image ID="Image1" runat="server" ImageAlign="Middle" ImageUrl="~/img/progress.gif" /><br />
                        <asp:Label ID="Label29" runat="server" Text=" Please wait... " Font-Bold="true" Font-Size="Large" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:UpdatePanel ID="UpdatePanel139" runat="server">
                <ContentTemplate>
                    <center>
                        <br />
                        <div>
                            <table width="290px" style="height: 170px">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblok" runat="server" Font-Size="Large" Style="line-height: 2"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                        <br />
                                        <center>
                                            <asp:Button ID="btnok" OnClick="btnok_Click" CausesValidation="false" Text="OK" runat="server"
                                                CssClass="Button" Height="30px" Width="100px" />
                                        </center>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </center>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
        <asp:ModalPopupExtender ID="ModalPopupDelete" runat="server" TargetControlID="lnkDelete"
            CancelControlID="btnCancel21" BackgroundCssClass="modalBackground" PopupControlID="pnlDelete">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlDelete" runat="server" BackColor="White" Height="200px" Width="320px"
            BorderWidth="2px" Style="display: none">
            <asp:UpdateProgress ID="UpdateProgress5" DisplayAfter="10" runat="server" AssociatedUpdatePanelID="UpdatePanel13">
                <ProgressTemplate>
                    <div class="divWaiting">
                        <asp:Image ID="imgWait5" runat="server" ImageAlign="Middle" ImageUrl="~/img/progress.gif" /><br />
                        <asp:Label ID="lblWait5" runat="server" Text=" Please wait... " Font-Bold="true"
                            Font-Size="Large" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                <ContentTemplate>
                    <center>
                        <br />
                        <div>
                            <table width="290px" style="height: 170px">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblDeleteMsg" runat="server" Text="Are You Sure To Delete Record ?"></asp:Label>
                                        <%--Deleting a Asset record and all associated: Base Fixtures<br />
                                        <br />
                                        Do you wish to continue?--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                        <br />
                                        <center>
                                            <asp:Button ID="BtnDeleteYes" OnClick="Deletepopup_Yes_Click" CausesValidation="false"
                                                Text="Yes" runat="server" CssClass="Button" Height="30px" Width="100px" />
                                            <asp:Button ID="btnCancel21" Text="No" runat="server" CausesValidation="false" OnClick="btnCancelDelete_Click"
                                                CssClass="Button" Style="margin-left: 10px" Height="30px" Width="100px" />
                                        </center>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </center>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>

          <asp:HiddenField ID="HiddenFieldViewer" runat="server" />
        <asp:ModalPopupExtender ID="ModalPopupViewer" runat="server" TargetControlID="HiddenFieldViewer"
            CancelControlID="ButtonCancelViewer" BackgroundCssClass="modalBackground" PopupControlID="PanelViewer">
        </asp:ModalPopupExtender>
        <asp:Panel ID="PanelViewer" runat="server" BackColor="White" Height="620px" Width="730px"
            BorderWidth="1px" Style="display: none; z-index:199999999 !important">
            <asp:UpdatePanel ID="UpdatePanelviewer" runat="server">
                <ContentTemplate>
                <br />
                <center>
                    <asp:Panel runat="server" ID="PanelV" BackColor="White"
                        Font-Bold="True" Width="700px">
                        <table width="100%" style=" border:none;">
                            <tr>
                                <td>
                                    <iframe id="ViewerDoc" runat="server" width="100%" height="530px"></iframe>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <center>
                                        <%-- <asp:Button ID="Button3" runat="server" CssClass="Button" Text="Print" Width="110px"
                                Height="35px" OnClientClick="Print()" Font-Bold="True" />--%>
                                        <asp:Button ID="ButtonCancelViewer" runat="server" CssClass="Button" OnClick="ButtonCancelViewer_Click"
                                            Text="Cancel" Width="110px" Height="35px" Font-Bold="True" />
                                    </center>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    </center>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
        <asp:Label ID="lblerror" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"></asp:Label>
    </div>
</asp:Content>
