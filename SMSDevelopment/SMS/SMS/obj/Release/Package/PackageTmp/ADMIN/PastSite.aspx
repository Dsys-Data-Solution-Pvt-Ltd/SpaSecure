<%@ Page Language="C#" MasterPageFile="~/master/SpaMaster.Master" AutoEventWireup="true"
    CodeBehind="PastSite.aspx.cs" Inherits="SMS.ADMIN.PastSite" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel2" Skin="Sunset" runat="server">
    </telerik:RadAjaxLoadingPanel>
    <div class="divHeader">
            <span>Past Site</span>
            <br />
            </div>
    
    
    <div class="divContainer">
        <div class="btnbar">
            <div class="btnbarBox">
                <ul>
                    <li>
                        <asp:LinkButton ID="imdAdd" runat="server" CausesValidation="false" OnClick="ImgAdd_Click">
                            <span id="spanAdd1" runat="server" class="iconAdd" style="line-height: 120px;">
                                <asp:Label ID="spanAdd" runat='server' Text="Add"></asp:Label></span>
                        </asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="imgEdit" runat="server" CausesValidation="false" OnClick="ImgEdit_Click">
                            <span id="spanUpdate1" runat="server" class="iconUpdate" style="line-height: 120px;">
                                <asp:Label ID="spanUpdate" runat='server' Text="Edit"></asp:Label></span>
                        </asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="imgDelete" runat="server" CausesValidation="false" OnClick="ImgDelete_Click">
                            <span id="spanDelete" runat="server" class="iconDelete" style="line-height: 120px;">
                                <asp:Label ID="spandelete1" runat='server' Text="Delete"></asp:Label>
                            </span>
                        </asp:LinkButton>
                    </li>
                </ul>
            </div>
        </div>
        <ul id="tabs" class="ui-tabs ui-widget ui-widget-content ui-corner-all">

          <li id="Past" runat="server">
                <asp:LinkButton ID="lnkPresent" runat="server"  OnClick="lnkPresent_Click"
                    CausesValidation="false">
                    <span id="span_Past" runat="server" class="icon2">Present Site</span>
                </asp:LinkButton></li>

            <li id="Present" runat="server">
                <asp:LinkButton ID="lnkPast" runat="server" OnClick="lnkPast_Click"  CausesValidation="false">
                    <span id="spanPresent" runat="server" class="icon1">Past Site</span>
                </asp:LinkButton></li>

          
        </ul>
       
       <asp:Panel ID="Panelgrid" runat="server" >
        <div id="content" runat="server">
            <table width="100%" style="border: 0; margin-top: -7.2px">
                <tr style="vertical-align: top;">
                    <td style="width: 80%">
                        <%--<asp:UpdatePanel ID="locupdate" runat="server">
                            <ContentTemplate>--%>
                                <telerik:RadGrid ID="gvLoctionTable" runat="server" CssClass="RadGrid" GridLines="None"
                                    HeaderStyle-Font-Size="12px" AllowPaging="True" PageSize="10" AllowSorting="True"
                                    AutoGenerateColumns="False" ShowStatusBar="true" Skin="Simple" HeaderStyle-HorizontalAlign="left"
                                    HeaderStyle-BackColor="#ad1c1c" HeaderStyle-ForeColor="white" AllowMultiRowSelection="false"
                                    AllowFilteringByColumn="true">
                                    <GroupingSettings CaseSensitive="false" />
                                    <MasterTableView CommandItemDisplay="Bottom" DataKeyNames="Location_id">
                                        <CommandItemSettings ShowAddNewRecordButton="false" ShowRefreshButton="false" />
                                        <Columns>
                                            <telerik:GridTemplateColumn UniqueName="CheckBoxTemplateColumn" ShowFilterIcon="false"
                                                AllowFiltering="false">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="ToggleRowSelection"
                                                        AutoPostBack="True" />
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridBoundColumn UniqueName="Location_name" HeaderText="Location Name" DataField="Location_name"
                                                CurrentFilterFunction="Contains" FilterDelay="1000" ShowFilterIcon="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="Loc_Address" HeaderText="Address" DataField="Loc_Address"
                                                CurrentFilterFunction="Contains" FilterDelay="1000" ShowFilterIcon="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="ClientUserID" HeaderText="Client Id" DataField="ClientUserID"
                                                CurrentFilterFunction="Contains" FilterDelay="1000" ShowFilterIcon="false">
                                            </telerik:GridBoundColumn>
                                        </Columns>
                                    </MasterTableView>
                                    <%-- <ClientSettings Selecting-AllowRowSelect="true" ReorderColumnsOnClient="True" AllowDragToGroup="True"
                                            AllowColumnsReorder="True">
                                            <Selecting AllowRowSelect="True" />
                                        </ClientSettings>--%>
                                    <SelectedItemStyle BorderWidth="0px" Font-Bold="true" ForeColor="White" BackColor="Red" />
                                </telerik:RadGrid>
                            <%--</ContentTemplate>
                        </asp:UpdatePanel>--%>
                    </td>
                </tr>
            </table>
        </div>
        </asp:Panel>
         <asp:HiddenField ID="hdnAdd" runat="server" />
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <asp:HiddenField ID="lnkDelete" runat="server" />
        <asp:ModalPopupExtender ID="ModalPopupAdd" runat="server" CancelControlID="btnClearLocationAdd"
            TargetControlID="hdnAdd" BackgroundCssClass="modalBackground" PopupControlID="pnlAdd">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlAdd" runat="server" BackColor="White" Style="height: 450px; width: 750px;
            margin-top: -15px">
            <br />
            <asp:UpdateProgress ID="UpdateProgress1" DisplayAfter="10" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
                <ProgressTemplate>
                    <div class="divWaiting">
                        <asp:Image ID="imgWait1" runat="server" ImageAlign="Middle" ImageUrl="~/img/progress.gif" /><br />
                        <asp:Label ID="lblWait1" runat="server" Text=" Please wait... " Font-Bold="true"
                            Font-Size="Large" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div class="divContainer">
                      
                        <div>
                            <asp:Label ID="lblerror" runat="server" ForeColor="Red" Font-Bold="True" CssClass="lblerror"></asp:Label>
                        </div>
                        <br />
                        <div id="divAdvSearch" runat="server" visible="true">
                            <asp:Panel ID="Panel" runat="server" Style="margin-left: 1.5em; width: 58em; height: 200em;
                                margin-top: -5px;">
                                <asp:TabContainer ID="TabContainer1" runat="server" Font-Bold="True">
                                    <asp:TabPanel ID="TabPanel1" HeaderText="Location" runat="server" Font-Bold="True"
                                        Font-Size="20px" Font-Names="Arial">
                                        <ContentTemplate>
                                            <table width="100%" class="table">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblEnterLocation" Text="Location Name" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtAddLocation" runat="server" Width="425px" />
                                                        <asp:Label ID="lblerr" CssClass="ValSummary" runat="server" Text="*" Font-Size="Smaller"
                                                            ForeColor="Red"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                        <asp:Label ID="lblsiteAddress" Text="Address" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtsiteaddres" runat="server" Height="72px" Width="425px" TextMode="MultiLine" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblClientUserID" runat="server" CssClass="Labels" Text="Client UserID"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtClientUserID" runat="server" CssClass="newInput" Width="425px" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblClientPassword" runat="server" CssClass="Labels" Text="Client Password"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtClientPassword" runat="server" CssClass="newInput" Width="425px"
                                                            TextMode="Password" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblContractStartDate" CssClass="Labels" runat="server" Text="Start Date:"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtdatefrom" CssClass="newInput" runat="server" OnTextChanged="txtdatefrom_TextChanged"
                                                            Width="425px"></asp:TextBox>
                                                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy" TargetControlID="txtdatefrom"
                                                            PopupButtonID="imgBtnFromDate2" Enabled="True" />
                                                        <asp:ImageButton ID="imgBtnFromDate2" runat="server" ImageUrl="~/Images/calendar.bmp"
                                                            OnClick="imgBtnFromDate2_Click" class="calender" Style="float: right; margin-top: -21px;
                                                            margin-right: 75px; height: 17px" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label2" CssClass="Labels" runat="server" Text="Expiry Date:"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtdateto" CssClass="newInput" runat="server" OnTextChanged="txtdateto_TextChanged"
                                                            Width="425px"></asp:TextBox>
                                                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/dd/yyyy" TargetControlID="txtdateto"
                                                            PopupButtonID="imgBtnFromDate3" Enabled="True" />
                                                        <asp:ImageButton ID="imgBtnFromDate3" runat="server" ImageUrl="~/Images/calendar.bmp"
                                                            class="calender" OnClick="imgBtnFromDate3_Click" Style="float: right; margin-top: -21px;
                                                            margin-right: 75px; height: 17px" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label3" CssClass="Labels" runat="server" Text="Contract Value"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtContractValue" runat="server" CssClass="newInput" Width="400px" />
                                                    </td>
                                                </tr>
                                               
                                                <tr>
                                                    <td colspan="2">
                                                        <center>
                                                            <asp:Button ID="btnSearchLocationSave" Text="Save/Next" runat="server" CssClass="Button"
                                                                Width="100px" Height="30px" OnClick="btnSearchLocationSave_Click" />
                                                            <asp:Button ID="btnNextLocationAdd" Text="Next" runat="server" CssClass="Button"
                                                                Width="100px" Height="30px" OnClick="btnNextLocationAdd_Click" Visible="false" />
                                                            <asp:Button ID="btnClearLocationAdd" Text="Cancel" runat="server" CssClass="Button"
                                                                Width="100px" Height="30px" OnClick="btnClearLocationAdd_Click" />
                                                        </center>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:TabPanel>
                                    <asp:TabPanel ID="TabPanel2" HeaderText="Finance Contact" runat="server" Font-Bold="True"
                                        Font-Size="20px" Font-Names="Arial"  Height="360px">
                                        <ContentTemplate>
                                            <table width="100%" class="table">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblFinanceName" runat="server" CssClass="Labels" Text="Name"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtFinaceName" runat="server" CssClass="newInput" Width="425px" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblfinanceContactTel" runat="server" CssClass="Labels" Text="Telephone"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtFinanceContactTel" runat="server" CssClass="newInput" Width="425px" />
                                                        <asp:RegularExpressionValidator ID="Regularexpressionvalidator1" runat="server" ErrorMessage="Please Enter Numeric Value!..."
                                                            ControlToValidate="txtFinanceContactTel" Font-Bold="True" Font-Size="17px" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblFinanceContactMob" runat="server" CssClass="Labels" Text="Mobile"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtFinanceContactMob" runat="server" CssClass="newInput" Width="425px" />
                                                        <asp:RegularExpressionValidator ID="Regularexpressionvalidator2" runat="server" ErrorMessage="Please Enter Numeric Value!..."
                                                            ControlToValidate="txtFinanceContactMob" Font-Bold="True" Font-Size="17px" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblFinanceContactEmail" runat="server" CssClass="Labels" Text="E-mail"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtFinanceContactEmail" runat="server" CssClass="newInput" Width="425px" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblFinanceContactFax" runat="server" CssClass="Labels" Text="Fax"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtFinanceContactFax" runat="server" CssClass="newInput" Width="425px" />
                                                    </td>
                                                </tr>
                                              
                                                <tr>
                                                    <td colspan="2">
                                                        <center>
                                                            <asp:Button ID="btnSearch1LocationAdd" Text="Save/Next" runat="server" CssClass="Button"
                                                                Width="100px" Height="30px" OnClick="btnSearch1LocationAdd_Click" />
                                                            <asp:Button ID="btnNext1LocationAdd" Text="Next" runat="server" CssClass="Button"
                                                                Width="100px" Height="30px" OnClick="btnNext1LocationAdd_Click" Visible="false" />
                                                            <asp:Button ID="btnClear1LocationAdd" Text="Cancel" runat="server" CssClass="Button"
                                                                Width="100px" Height="30px" OnClick="btnClear1LocationAdd_Click" />
                                                        </center>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:TabPanel>
                                    <asp:TabPanel ID="TabPanel3" HeaderText="Operations Contact" runat="server" Font-Bold="True"
                                        Font-Size="20px" Font-Names="Arial"  Height="360px">
                                        <ContentTemplate>
                                            <table width="100%" class="table">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblOperationName" runat="server" CssClass="Labels" Text="Name"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtOperationName" runat="server" CssClass="newInput" Width="425px" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblOperationsContactTele" runat="server" CssClass="Labels" Text="Telephone"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtOperationsContactTelephone" runat="server" CssClass="newInput"
                                                            Width="425px" />
                                                        <asp:RegularExpressionValidator ID="Regularexpressionvalidator3" runat="server" ErrorMessage="Please Enter Numeric Value!..."
                                                            ControlToValidate="txtOperationsContactTelephone" Font-Bold="True" Font-Size="17px"
                                                            ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblOperationsContactMobile" runat="server" CssClass="Labels" Text="Mobile"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtOperationsContactMobile" runat="server" CssClass="newInput" Width="425px" />
                                                        <asp:RegularExpressionValidator ID="Regularexpressionvalidator4" runat="server" ErrorMessage="Please Enter Numeric Value!..."
                                                            ControlToValidate="txtOperationsContactMobile" Font-Bold="True" Font-Size="17px"
                                                            ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblOperationsContactEmail" runat="server" CssClass="Labels" Text="E-mail"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtOperationsContactEmail" runat="server" CssClass="newInput" Width="425px" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblOperationsContactFax" runat="server" CssClass="Labels" Text="Fax"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtOperationsContactFax" runat="server" CssClass="newInput" Width="425px" />
                                                    </td>
                                                </tr>
                                              
                                                <tr>
                                                    <td colspan="2">
                                                        <center>
                                                            <asp:Button ID="btnSearch2LocationAdd" Text="Save/Next" runat="server" CssClass="Button"
                                                                Width="100px" Height="30px" OnClick="btnSearch2LocationAdd_Click" />
                                                            <asp:Button ID="btnNext2LocationAdd" Text="Next" runat="server" CssClass="Button"
                                                                Width="100px" Height="30px" OnClick="btnNext2LocationAdd_Click" Visible="false" />
                                                            <asp:Button ID="btnClear2LocationAdd" Text="Cancel" runat="server" CssClass="Button"
                                                                Width="100px" Height="30px" OnClick="btnClear2LocationAdd_Click" />
                                                        </center>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:TabPanel>
                                    <asp:TabPanel ID="TabPanel4" HeaderText="Management Contact " runat="server" Font-Bold="True"
                                        Font-Size="20px" Font-Names="Arial"  Height="360px">
                                        <ContentTemplate>
                                            <table width="100%" class="table">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblManagementName" runat="server" CssClass="Labels" Text="Name"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtManagementName" runat="server" CssClass="newInput" Width="425px" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblManagementContactTelephone" runat="server" CssClass="Labels" Text="Telephone"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtlblManagementContactTelephone" runat="server" CssClass="newInput"
                                                            Width="425px" />
                                                        <asp:RegularExpressionValidator ID="Regularexpressionvalidator5" runat="server" ErrorMessage="Please Enter Numeric Value!..."
                                                            ControlToValidate="txtlblManagementContactTelephone" Font-Bold="True" Font-Size="13px"
                                                            ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblManagementContactMobile" runat="server" CssClass="Labels" Text="Mobile"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtManagementContactMobile" runat="server" CssClass="newInput" Width="425px" />
                                                        <asp:RegularExpressionValidator ID="Regularexpressionvalidator6" runat="server" ErrorMessage="Please Enter Numeric Value!..."
                                                            ControlToValidate="txtManagementContactMobile" Font-Bold="True" Font-Size="13px"
                                                            ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblManagementContactEmail" runat="server" CssClass="Labels" Text="E-mail"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtManagementContactEmail" runat="server" CssClass="newInput" Width="425px" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblManagementContactFax" runat="server" CssClass="Labels" Text="Fax"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtManagementContactFax" runat="server" CssClass="newInput" Width="425px" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblEmergencyContactEmail" runat="server" CssClass="Labels" Text="Emergency Contact Email"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtEmergencyContactEmail" runat="server" CssClass="newInput" Width="425px" />
                                                    </td>
                                                </tr>
                                              
                                                <tr>
                                                    <td colspan="2">
                                                        <center>
                                                            <asp:Button ID="btnSearch3LocationAdd" Text="Save" runat="server" CssClass="Button"
                                                                Width="100px" Height="30px" OnClick="btnSearch3LocationAdd_Click" />
                                                            <asp:Button ID="btnClear3LocationAdd" Text="Cancel" runat="server" CssClass="Button"
                                                                Width="100px" Height="30px" OnClick="btnClear3LocationAdd_Click" />
                                                        </center>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:TabPanel>
                                </asp:TabContainer>
                            </asp:Panel>
                            <table width="100%" class="table" visible="false">
                                <tr>
                                    <td colspan="4">
                                        <asp:Panel ID="Panel2" runat="server">
                                            <table width="70%">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblChiefSecurityOfficer" runat="server" CssClass="Labels" Text="Chief Security Officer Required"
                                                            Visible="false" />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblChiefSecurityRequiredDay" runat="server" CssClass="Labels" Text="Day Shift"
                                                            Visible="false"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtChiefSecurityRequiredDay1" runat="server" CssClass="newInput"
                                                            Width="75px" Visible="false" />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblChiefSecurityRequiredEvening" runat="server" CssClass="Labels"
                                                            Text="Night Shift" Visible="false"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtChiefSecurityRequiredEvening" runat="server" CssClass="newInput"
                                                            Width="67px" Visible="false" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblSuperVisorRequired" runat="server" CssClass="Labels" Text="Supervisor Required"
                                                            Visible="false" />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblSuperVisorRequiredDay" runat="server" CssClass="Labels" Text="Day Shift"
                                                            Visible="false"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtsupervisorrequiredDay" runat="server" CssClass="newInput" Width="75px"
                                                            Visible="false" />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblSupervisorRequireNight" runat="server" CssClass="Labels" Text="Night Shift"
                                                            Visible="false"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSupervisorRequireNight" runat="server" CssClass="newInput" Width="66px"
                                                            Visible="false" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblSeniorSecurity" runat="server" CssClass="Labels" Text="Senior Security Officer Required"
                                                            Visible="false" />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblSSO" runat="server" CssClass="Labels" Text="Day Shift" Visible="false"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="TxtSSODay" runat="server" CssClass="newInput" Width="75px" Visible="false" />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblSSONight" runat="server" CssClass="Labels" Text="Night Shift" Visible="false"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSSONight" runat="server" CssClass="newInput" Width="66px" Visible="false" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label1" runat="server" CssClass="Labels" Text="Security Officer Required"
                                                            Visible="false" />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblSODay" runat="server" CssClass="Labels" Text="Day Shift" Visible="false"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSODay" runat="server" CssClass="newInput" Width="75px" Visible="false" />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblSONight" runat="server" CssClass="Labels" Text="Night Shift" Visible="false"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSONight" runat="server" CssClass="newInput" Width="66px" Visible="false" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="chkoter" runat="server" Text="Others" AutoPostBack="true" CssClass="Labels"
                                            OnCheckedChanged="chkoter_CheckedChanged" Visible="false" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6">
                                        <asp:Panel ID="PnlOther" runat="server">
                                            <table width="60%">
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtOther1" runat="server" CssClass="newInput" Visible="false"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label5" runat="server" CssClass="Labels" Text="Day Shift" Visible="false"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtOther1_day" runat="server" CssClass="newInput" Width="75px" Visible="false" />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label6" runat="server" CssClass="Labels" Text="Night Shift" Visible="false"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtOther1_nig" runat="server" CssClass="newInput" Width="66px" Visible="false" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtOther2" runat="server" CssClass="newInput" Visible="false"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label8" runat="server" CssClass="Labels" Text="Day Shift" Visible="false"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtOther2_day" runat="server" CssClass="newInput" Width="75px" Visible="false" />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label9" runat="server" CssClass="Labels" Text="Night Shift" Visible="false"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtOther2_nig" runat="server" CssClass="newInput" Width="66px" Visible="false" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtOther3" runat="server" CssClass="newInput" Visible="false"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label11" runat="server" CssClass="Labels" Text="Day Shift"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtOther3_day" runat="server" CssClass="newInput" Width="75px" Visible="false" />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label12" runat="server" CssClass="Labels" Text="Night Shift" Visible="false"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtOther3_nig" runat="server" CssClass="newInput" Width="66px" Visible="false" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <br />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
        <asp:ModalPopupExtender ID="ModalPopupEdit" runat="server" TargetControlID="HiddenField1"
            BackgroundCssClass="modalBackground" PopupControlID="pnlpopupEdit">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlpopupEdit" runat="server" BackColor="White" Height="450px" Width="750px"
            Style="margin-top: -5px">
            <br />
            <asp:UpdateProgress ID="UpdateProgress2" DisplayAfter="10" runat="server" AssociatedUpdatePanelID="up">
                <ProgressTemplate>
                    <div class="divWaiting">
                        <asp:Image ID="imgWait2" runat="server" ImageAlign="Middle" ImageUrl="~/img/progress.gif" /><br />
                        <asp:Label ID="lblWait2" runat="server" Text=" Please wait... " Font-Bold="true"
                            Font-Size="Large" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:UpdatePanel ID="up" runat="server">
                <ContentTemplate>
                    <div class="divContainer">
                       
                        <div id="divErr" runat="server">
                            <asp:Label ID="lblErrMsg" CssClass="ValSummary" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                        </div>
                        <asp:HiddenField ID="hdnBTID" runat="server" Value="" />
                        <asp:HiddenField ID="hdnBTName" runat="server" Value="" />
                        <br />
                        <asp:Panel ID="Panel1" runat="server" Style="margin-left: 1.5em; width: 58em; height: 80em;
                            margin-top: -2px">
                            <AJAX:TabContainer ID="TabContainerEdit" runat="server" Font-Bold="True">
                                <AJAX:TabPanel ID="TabPanel1Edit" HeaderText="New Location" runat="server" Font-Bold="True"
                                    Font-Size="20px" Font-Names="Arial"  Height="360px">
                                    <ContentTemplate>
                                        <table width="100%" style="height: 200px" class="table">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblEnterLocationCode" Text="Location Code" CssClass="Labels" runat="server"
                                                        Visible="False"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtUpdateLocationNameEdit" runat="server" CssClass="Input" ReadOnly="True"
                                                        Visible="False" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblEnterLocationEdit" Text="Location Name" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtAddLocationEdit" runat="server" CssClass="Input" Width="380px" />
                                                    <asp:Label ID="Label7" CssClass="ValSummary" runat="server" Text="*" Font-Size="Smaller"
                                                        ForeColor="Red"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top">
                                                    <asp:Label ID="lblsiteAddressEdit" Text="Address" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtsiteaddresEdit" runat="server" CssClass="Input" Height="72px"
                                                        Width="380px" TextMode="MultiLine" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblClientUserIDEdit" runat="server" CssClass="Labels" Text="Client UserID"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtClientUserIDEdit" runat="server" CssClass="Input" Width="385px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblContractStartDateEdit" CssClass="Labels" runat="server" Text="Start Date"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtdatefromEdit" CssClass="Input" runat="server" OnTextChanged="txtdatefrom_TextChanged"
                                                        Width="385px"></asp:TextBox>
                                                    <asp:CalendarExtender ID="CalendarExtender1Edit" runat="server" Format="MM/dd/yyyy"
                                                        TargetControlID="txtdatefromEdit" PopupButtonID="imgBtnFromDate2Edit" Enabled="True" />
                                                    <asp:ImageButton ID="imgBtnFromDate2Edit" runat="server" ImageUrl="~/Images/calendar.bmp"
                                                        OnClick="imgBtnFromDate2Edit_Click" Style="float: right; margin-top: -21px; margin-right: 108px;
                                                        height: 17px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label15" CssClass="Labels" runat="server" Text="Expiry Date"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtdatetoEdit" CssClass="Input" runat="server" OnTextChanged="txtdateto_TextChanged"
                                                        Width="385px"></asp:TextBox>
                                                    <asp:CalendarExtender ID="CalendarExtender2Edit" runat="server" Format="MM/dd/yyyy"
                                                        TargetControlID="txtdatetoEdit" PopupButtonID="imgBtnFromDate3Edit" Enabled="True" />
                                                    <asp:ImageButton ID="imgBtnFromDate3Edit" runat="server" ImageUrl="~/Images/calendar.bmp"
                                                        Style="float: right; margin-top: -21px; margin-right: 108px; height: 17px" OnClick="imgBtnFromDate3Edit_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label16" CssClass="Labels" runat="server" Text="Contract Value"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtContractValueEdit" runat="server" CssClass="Input" Width="385px" />
                                                </td>
                                            </tr>
                                         
                                            <tr>
                                                <td colspan="2">
                                                    <center>
                                                        <asp:Button ID="btnSave" runat="server" Text="Update" CssClass="Button" OnClick="btnSave_Click"
                                                            Width="100px" Height="30px" />
                                                        <asp:Button ID="btnBack" runat="server" Text="Cancel" CssClass="Button" OnClick="btnBack_Click"
                                                            Width="100px" Height="30px" />
                                                    </center>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </AJAX:TabPanel>
                                <AJAX:TabPanel ID="TabPanel5" HeaderText="Finance Contact" runat="server" Font-Bold="True"
                                    Font-Size="20px" Font-Names="Arial"  Height="360px">
                                    <ContentTemplate>
                                        <table width="100%" class="table">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblFinanceNameEdit" runat="server" CssClass="Labels" Text="Name"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtFinaceNameEdit" runat="server" CssClass="Input" Width="380px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblfinanceContactTelEdit" runat="server" CssClass="Labels" Text="Telephone"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtFinanceContactTelEdit" runat="server" CssClass="Input" Width="380px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblFinanceContactMobEdit" runat="server" CssClass="Labels" Text="Mobile"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtFinanceContactMobEdit" runat="server" CssClass="Input" Width="380px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblFinanceContactEmailEdit" runat="server" CssClass="Labels" Text="E-mail"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtFinanceContactEmailEdit" runat="server" CssClass="Input" Width="380px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblFinanceContactFaxEdit" runat="server" CssClass="Labels" Text="Fax"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtFinanceContactFaxEdit" runat="server" CssClass="Input" Width="380px" />
                                                </td>
                                            </tr>
                                          
                                            <tr>
                                                <td colspan="2">
                                                    <center>
                                                        <asp:Button ID="btnSave1" runat="server" Text="Update" CssClass="Button" OnClick="btnSave1_Click"
                                                            Width="100px" Height="30px" />
                                                               <asp:Button ID="Button1" runat="server" Text="Cancel" CssClass="Button" OnClick="btnBack_Click"
                                                            Width="100px" Height="30px" />
                                                    </center>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </AJAX:TabPanel>
                                <AJAX:TabPanel ID="TabPanel6" HeaderText="Operation Contact" runat="server" Font-Bold="True"
                                    Font-Size="20px" Font-Names="Arial"  Height="360px">
                                    <ContentTemplate>
                                        <table width="100%" class="table">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblOperationNameEdit" runat="server" CssClass="Labels" Text="Name"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtOperationNameEdit" runat="server" CssClass="Input" Width="380px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblOperationsContactTeleEdit" runat="server" CssClass="Labels" Text="Telephone"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtOperationsContactTelephoneEdit" runat="server" CssClass="Input"
                                                        Width="380px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblOperationsContactMobileEdit" runat="server" CssClass="Labels" Text="Mobile"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtOperationsContactMobileEdit" runat="server" CssClass="Input"
                                                        Width="380px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblOperationsContactEmailEdit" runat="server" CssClass="Labels" Text="E-mail"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtOperationsContactEmailEdit" runat="server" CssClass="Input" Width="380px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblOperationsContactFaxEdit" runat="server" CssClass="Labels" Text="Fax"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtOperationsContactFaxEdit" runat="server" CssClass="Input" Width="380px" />
                                                </td>
                                            </tr>
                                         
                                            <tr>
                                                <td colspan="2">
                                                    <center>
                                                        <asp:Button ID="btnSave2" runat="server" Text="Update" CssClass="Button" OnClick="btnSave2_Click"
                                                            Width="100px" Height="30px" />
                                                             <asp:Button ID="Button2" runat="server" Text="Cancel" CssClass="Button" OnClick="btnBack_Click"
                                                            Width="100px" Height="30px" />
                                                    </center>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </AJAX:TabPanel>
                                <AJAX:TabPanel ID="TabPanel7" HeaderText="Management Contact " runat="server" Font-Bold="True"
                                    Font-Size="20px" Font-Names="Arial" Height="360px">
                                    <ContentTemplate>
                                        <table width="100%" class="table">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label27" runat="server" CssClass="Labels" Text="Name"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtManagementNameEdit" runat="server" CssClass="Input" Width="380px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblManagementContactTelephoneEdit" runat="server" CssClass="Labels"
                                                        Text="Telephone"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtlblManagementContactTelephoneEdit" runat="server" CssClass="Input"
                                                        Width="380px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblManagementContactMobileEdit" runat="server" CssClass="Labels" Text="Mobile"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtManagementContactMobileEdit" runat="server" CssClass="Input"
                                                        Width="380px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblManagementContactEmailEdit" runat="server" CssClass="Labels" Text="E-mail"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtManagementContactEmailEdit" runat="server" CssClass="Input" Width="380px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblManagementContactFaxEdit" runat="server" CssClass="Labels" Text="Fax"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtManagementContactFaxEdit" runat="server" CssClass="Input" Width="380px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblEmergencyContactEmailEdit" runat="server" CssClass="Labels" Text="Emergency Contact Email"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtEmergencyContactEmailEdit" runat="server" CssClass="Input" Width="380px" />
                                                </td>
                                            </tr>
                                         
                                            <tr>
                                                <td colspan="2">
                                                    <center>
                                                        <asp:Button ID="btnSave3" runat="server" Text="Update" CssClass="Button" OnClick="btnSave3_Click"
                                                            Width="100px" Height="30px" />
                                                             <asp:Button ID="Button3" runat="server" Text="Cancel" CssClass="Button" OnClick="btnBack_Click"
                                                            Width="100px" Height="30px" />
                                                    </center>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </AJAX:TabPanel>
                            </AJAX:TabContainer>
                        </asp:Panel>
                        <table width="100%" class="table" visible="false">
                            <tr>
                                <td>
                                    <asp:Label ID="lblChiefSecurityOfficerEdit" runat="server" CssClass="Labels" Text="Chief Security Officer Required"
                                        Visible="false" />
                                </td>
                                <td>
                                    <asp:Label ID="lblChiefSecurityRequiredDayEdit" runat="server" CssClass="Labels"
                                        Text="Day Shift" Visible="false"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtChiefSecurityRequiredDayEdit" runat="server" CssClass="Input"
                                        Width="77px" Visible="false" />
                                </td>
                                <td>
                                    <asp:Label ID="lblChiefSecurityRequiredEveningEdit" runat="server" CssClass="Labels"
                                        Text="Night Shift" Visible="false"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtChiefSecurityRequiredEveningEdit" runat="server" CssClass="Input"
                                        Width="67px" Visible="false" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblSuperVisorRequiredEdit" runat="server" CssClass="Labels" Text="Supervisor Required"
                                        Visible="false" />
                                </td>
                                <td>
                                    <asp:Label ID="lblSuperVisorRequiredDayEdit" runat="server" CssClass="Labels" Text="Day Shift"
                                        Visible="false"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtsupervisorrequiredDayEdit" runat="server" CssClass="Input" Width="75px"
                                        Visible="false" />
                                </td>
                                <td>
                                    <asp:Label ID="lblSupervisorRequireNightEdit" runat="server" CssClass="Labels" Text="Night Shift"
                                        Visible="false"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSupervisorRequireNightEdit" runat="server" CssClass="Input" Width="66px"
                                        Visible="false" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblSeniorSecurityEdit" runat="server" CssClass="Labels" Text="Senior Security Officer Required"
                                        Visible="false" />
                                </td>
                                <td>
                                    <asp:Label ID="lblSSOEdit" runat="server" CssClass="Labels" Text="Day Shift" Visible="false"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtSSODayEdit" runat="server" CssClass="Input" Width="75px" Visible="false" />
                                </td>
                                <td>
                                    <asp:Label ID="lblSSONightEdit" runat="server" CssClass="Labels" Text="Night Shift"
                                        Visible="false"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSSONightEdit" runat="server" CssClass="Input" Width="66px" Visible="false" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label1Edit" runat="server" CssClass="Labels" Text="Security Officer Required"
                                        Visible="false" />
                                </td>
                                <td>
                                    <asp:Label ID="lblSODayEdit" runat="server" CssClass="Labels" Text="Day Shift" Visible="false"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSODayEdit" runat="server" CssClass="Input" Width="75px" Visible="false" />
                                </td>
                                <td>
                                    <asp:Label ID="lblSONightEdit" runat="server" CssClass="Labels" Text="Night Shift"
                                        Visible="false"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSONightEdit" runat="server" CssClass="Input" Width="66px" Visible="false" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox ID="chkoterEdit" runat="server" Text="Others" CssClass="Labels" Visible="false" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    <asp:Panel ID="PnlOtherEdit" runat="server">
                                        <table width="90%">
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtOther1Edit" runat="server" CssClass="Input" Visible="false"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblOther1_dayEdit" runat="server" CssClass="Labels" Text="Day Shift"
                                                        Visible="false"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtOther1_dayEdit" runat="server" CssClass="Input" Width="75px"
                                                        Visible="false" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblOther1_nigEdit" runat="server" CssClass="Labels" Text="Night Shift"
                                                        Visible="false"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtOther1_nigEdit" runat="server" CssClass="Input" Width="66px"
                                                        Visible="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtOther2Edit" runat="server" CssClass="Input" Visible="false"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label8Edit" runat="server" CssClass="Labels" Text="Day Shift" Visible="false"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtOther2_dayEdit" runat="server" CssClass="Input" Width="75px"
                                                        Visible="false" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label9Edit" runat="server" CssClass="Labels" Text="Night Shift" Visible="false"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtOther2_nigEdit" runat="server" CssClass="Input" Width="66px"
                                                        Visible="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtOther3Edit" runat="server" CssClass="Input" Visible="false"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label11Edit" runat="server" CssClass="Labels" Text="Day Shift" Visible="false"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtOther3_dayEdit" runat="server" CssClass="Input" Width="75px"
                                                        Visible="false" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label12Edit" runat="server" CssClass="Labels" Text="Night Shift" Visible="false"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtOther3_nigEdit" runat="server" CssClass="Input" Width="66px"
                                                        Visible="false" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </div>
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
    </div>
</asp:Content>
