<%@ Page Language="C#" MasterPageFile="~/master/SpaMaster.Master" AutoEventWireup="true"
    CodeBehind="VehicleAlertHandling.aspx.cs" Inherits="SMS.SuperVisor.VehicleAlertHandling" %>

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
    <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Alert Handling</span></div>
        <div>
            <asp:Label ID="lblerror" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"></asp:Label>
        </div>
        <br />
        <asp:Panel runat="server" ID="btnImg">
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
                            <asp:LinkButton ID="imgDelete" runat="server" CausesValidation="false" OnClick="ImgDelete_Click">
                                <span id="spanDelete" runat="server" class="iconDelete" style="line-height: 120px;">
                                    <asp:Label ID="spandelete1" runat='server' Text="Delete"></asp:Label>
                                </span>
                            </asp:LinkButton>
                        </li>
                    </ul>
                </div>
            </div>
        </asp:Panel>
        <ul id="tabs" class="ui-tabs ui-widget ui-widget-content ui-corner-all">
            <li id="Person_Alert" runat="server">
                <asp:LinkButton ID="lnkPerson_Alert" runat="server" OnClick="lnkPerson_Alert_Click"
                    CausesValidation="false">
                    <span id="spanPerson_Alert" runat="server" class="icon1">Person Alert</span>
                </asp:LinkButton></li>
            <li id="Vehicle_Alert" runat="server">
                <asp:LinkButton ID="lnkVehicle_Alert" runat="server" OnClick="lnkVehicle_Alert_Click"
                    CausesValidation="false">
                    <span id="spanVehicle_Alert" runat="server" class="icon2">Vehicle Alert</span>
                </asp:LinkButton></li>
        </ul>
        <div id="content" runat="server">
            <asp:Panel ID="panelgrid" runat="server">
                <telerik:RadGrid ID="gvLoctionTable" runat="server" CssClass="RadGrid" GridLines="None"
                    HeaderStyle-Font-Size="12px" AllowPaging="True" PageSize="50" AllowSorting="True"
                    AutoGenerateColumns="False" ShowStatusBar="true" Skin="Simple" HeaderStyle-HorizontalAlign="left"
                    HeaderStyle-BackColor="#ad1c1c" HeaderStyle-ForeColor="white" AllowMultiRowSelection="false"
                    AllowFilteringByColumn="true">
                    <GroupingSettings CaseSensitive="false" />
                    <MasterTableView CommandItemDisplay="Bottom" DataKeyNames="Alert_ID">
                        <CommandItemSettings ShowAddNewRecordButton="false" ShowRefreshButton="false" />
                        <Columns>
                            <telerik:GridTemplateColumn UniqueName="CheckBoxTemplateColumn" ShowFilterIcon="false"
                                AllowFiltering="false">
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="ToggleRowSelection"
                                        AutoPostBack="True" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn UniqueName="Alert_Type" HeaderText="Alert Type" DataField="Alert_Type"
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="AlertBy_Name" HeaderText="Alert By" DataField="AlertBy_Name"
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="P_Name" HeaderText="Person Name" DataField="P_Name"
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="V_ResgistNo" HeaderText="Vehicle Reg. No." DataField="V_ResgistNo"
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="Status" HeaderText="Status" DataField="Status"
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                    <SelectedItemStyle BorderWidth="0px" Font-Bold="true" ForeColor="White" BackColor="Red" />
                </telerik:RadGrid>
            </asp:Panel>
        </div>
        <asp:HiddenField ID="hdnAdd" runat="server" />
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <asp:HiddenField ID="lnkDelete" runat="server" />
        <asp:ModalPopupExtender ID="ModalPopupAdd" runat="server" CancelControlID="btnCancel"
            TargetControlID="hdnAdd" BackgroundCssClass="modalBackground" PopupControlID="pnlAdd">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlAdd" runat="server" BackColor="White" Style="height: 540px; width: 750px;
            margin-top: -20px">
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
                    <center>
                        <div>
                            <asp:Label ID="Label1" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"></asp:Label>
                        </div>
                        <br />
                        <asp:Panel ID="printview" runat="server" BackColor="White" Width="700px">
                            <table width="700px">
                                <tr>
                                    <td>
                                        <asp:Label ID="lbllocation" CssClass="Labels" runat="server" Text="Location"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddllocation" runat="server" CssClass="Labels">
                                        </asp:DropDownList>
                                        <asp:Label ID="searchid" CssClass="Labels" runat="server" Visible="false"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblV_Type" CssClass="Labels" runat="server" Text="Vehicle Type"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="ddlV_Type" runat="server" CssClass="Input"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblVehicleReg" Text="Vehicle Registration No." CssClass="Labels" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtVehicleReg" runat="server" CssClass="Input"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblVOwerName" Text="Vehicle Owner Name" CssClass="Labels" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtVOwerName" runat="server" CssClass="Input" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblAlertReason" CssClass="Labels" runat="server" Text="Reason For Alert"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="ddlAlertreason" runat="server" CssClass="Input" TextMode="Multiline"
                                            Height="70px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblmessage" Text="Comments" CssClass="Labels" runat="server"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtmessage" runat="server" CssClass="Input" TextMode="Multiline"
                                            Height="70px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:Label ID="Label2" runat="server" ForeColor="#C5061B" CssClass="Labels" Font-Bold="True" Text="Alert Send For:"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblV_ONricNo" Text="NRIC No." CssClass="Labels" runat="server"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <telerik:RadComboBox ID="txtV_ONricNo" runat="server" EnableAutomaticLoadOnDemand="true"
                                            EmptyMessage="Select NRIC No" Style="z-index: 1000000;" DataSourceID="SqlDataSource1"
                                            DataTextField="NRICno" DataValueField="NRICno" ItemsPerRequest="10" ShowMoreResultsBox="true"
                                            EnableVirtualScrolling="true">
                                        </telerik:RadComboBox>
                                        <asp:Label ID="lblerr" CssClass="ValSummary" runat="server" Text="*" Font-Size="Smaller"
                                            ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:Label ID="lblalertedby" runat="server" ForeColor="#C5061B" CssClass="Labels" Font-Bold="True" Text="Alert Raised By:"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblbynric" runat="server" CssClass="Labels" Text="NRIC/FIN No."></asp:Label>
                                    </td>
                                    <td>
                                        <telerik:RadComboBox ID="txtbynric" runat="server" EnableAutomaticLoadOnDemand="true"
                                            EmptyMessage="Select NRIC No" Style="z-index: 1000000;" DataSourceID="SqlDataSource1"
                                            AutoPostBack="true" DataTextField="NRICno" DataValueField="NRICno" ItemsPerRequest="10"
                                            ShowMoreResultsBox="true" OnSelectedIndexChanged="txtbynric_TextChanged" EnableVirtualScrolling="true">
                                        </telerik:RadComboBox>
                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:spasecurelatestConnectionString %>"
                                            SelectCommand="SELECT NRICno from UserInformation"></asp:SqlDataSource>
                                        <asp:Label ID="lblerr1" CssClass="ValSummary" runat="server" Text="*" Font-Size="Smaller"
                                            ForeColor="Red"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblname" runat="server" CssClass="Labels" Text="Name"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtname" runat="server" CssClass="Input" Width="200px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbldesignation" runat="server" CssClass="Labels" Text="Designation"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtdesignation" runat="server" CssClass="Input" Width="200px" />
                                    </td>
                                    <td>
                                        <asp:Label ID="lblphone" runat="server" CssClass="Labels" Text="Phone No."></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtphone" runat="server" CssClass="Input" Width="200px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbldepartment" runat="server" CssClass="Labels" Text="Department"
                                            Visible="False"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlRole0" runat="server" CssClass="Labels" Visible="False">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <center>
                                            <asp:Button ID="btnNewItemAdd" runat="server" CssClass="Button" OnClick="btnNewItemAdd_Click"
                                                Text="Save" Width="85px" />
                                            <asp:Button ID="btnClearNewItemAdd" runat="server" CssClass="Button" OnClick="btnClearNewItemAdd_Click"
                                                Text="Cancel" Width="85px" />
                                        </center>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
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
