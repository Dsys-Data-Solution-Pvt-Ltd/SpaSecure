<%@ Page Language="C#" MasterPageFile="~/master/SpaMaster.Master" AutoEventWireup="true"
    CodeBehind="AlertReport.aspx.cs" Inherits="SMS.SMSUsers.Reports.AlertReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="panelgrid">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="panelgrid" LoadingPanelID="RadAjaxLoadingPanel2">
                    </telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="Label398"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel2" Skin="Sunset" runat="server">
    </telerik:RadAjaxLoadingPanel>

   <div class="divHeader">
            <span class="pageTitle">Alert Report</span>
        </div>
        <div class="btnbar">
            <div class="btnbarBox">
                <ul>
                    
                    <li>
                        <asp:LinkButton ID="imgDelete" runat="server" CausesValidation="false" OnClick="imgDelete_Click">
                            <span id="spanDelete" runat="server" class="iconDelete" style="line-height: 120px;">
                                <asp:Label ID="spandelete1" runat='server' Text="Delete"></asp:Label>
                            </span>
                        </asp:LinkButton>
                    </li>
                     <li>
                    <asp:LinkButton ID="imgCopy" runat="server" CausesValidation="false" OnClick="imgUpdate_Click">
                        <span id="spanCopy" runat="server" class="iconCopy" style="line-height: 120px;">View
                        </span>
                    </asp:LinkButton>
                </li>
                </ul>
            </div>
        </div>
          <div class="clear">
    </div>
        <%--   <ul id="tabs" class="ui-tabs ui-widget ui-widget-content ui-corner-all">

            <li id="Present" runat="server">
                <asp:LinkButton ID="lnkPresent" runat="server" OnClick="lnkPresent_Click" CausesValidation="false">
                    <span id="spanPresent" runat="server" class="icon1">Present Staff</span>
                </asp:LinkButton></li>

            <li id="Past" runat="server">
                <asp:LinkButton ID="lnkPast" runat="server" OnClick="lnkPast_Click"
                    CausesValidation="false">
                    <span id="span_Past" runat="server" class="icon2">Past Staff</span>
                </asp:LinkButton></li>
        </ul>--%>
        <div id="content" runat="server">
           <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>--%>
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
                                    CurrentFilterFunction="Contains" FilterDelay="1000" ShowFilterIcon="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="AlertBy_Name" HeaderText="Alert By Name" DataField="AlertBy_Name"
                                    CurrentFilterFunction="Contains" FilterDelay="1000" ShowFilterIcon="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="P_Name" HeaderText="Person Name" DataField="P_Name"
                                    CurrentFilterFunction="Contains" FilterDelay="1000" ShowFilterIcon="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="V_ResgistNo" HeaderText="Vehicle Reg. No." DataField="V_ResgistNo"
                                    CurrentFilterFunction="Contains" FilterDelay="1000" ShowFilterIcon="false">
                                </telerik:GridBoundColumn>
                                <%--<telerik:GridBoundColumn UniqueName="SuperiorName" HeaderText="Superior Name" DataField="SuperiorName"
                                                CurrentFilterFunction="Contains" FilterDelay="1000" ShowFilterIcon="false">
                                            </telerik:GridBoundColumn>--%>
                            </Columns>
                        </MasterTableView>
                        <SelectedItemStyle BorderWidth="0px" Font-Bold="true" ForeColor="White" BackColor="Red" />
                    </telerik:RadGrid>
             <%--   </ContentTemplate>
            </asp:UpdatePanel>--%>
            </asp:Panel>
        </div>
        <br />
        <div style=" background-color: #E4E4E4; width:100%">
      <center>
        <table style=" background-color: #E4E4E4; width:50%;" >
                    <tr>
                        <td style="width: 121px">
                            <asp:Label ID="exportto" CssClass="Labels" runat="server" Text="Export To :" ForeColor="#000099"
                                Font-Bold="true"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownList1" CssClass="Labels" runat="server" ForeColor="#000099"
                                Width="79px" Height="28px">
                                <asp:ListItem>Pdf</asp:ListItem>
                                <asp:ListItem>Word</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;&nbsp;
                            <asp:Button ID="btnGo" CssClass="Button" runat="server" Text="Go" Width="60px" OnClick="btnGo_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnEmail" CssClass="Button" runat="server" Text="E-Mail" Width="85px"
                                Visible="False" />
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
          </center>
        </div>
        <asp:HiddenField ID="hdnAdd" runat="server" />
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <asp:HiddenField ID="lnkDelete" runat="server" />
        <asp:ModalPopupExtender ID="ModalPopupAdd" runat="server" TargetControlID="hdnAdd"
            BackgroundCssClass="modalBackground" PopupControlID="pnlAdd">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlAdd" runat="server" BackColor="White" Style="height: 530px; width: 760px;
            margin-top: 3px;">
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
                    <asp:Panel runat="server" ID="printview" BackColor="White"
                        Font-Bold="True" Width="700px">
                        <table width="700px">
                            <tr>
                                <td colspan="4">
                                <center>
                                    <asp:Image runat="server" ID="image1" Style="height: 80px; width: 100px"></asp:Image>
                                    <hr style="background-color: Black; color: Black; border-color: Black; width: 698px;">
                                    </hr>
                                    </center>
                                </td>
                            </tr>
                            <tr>
                                <td  colspan="4">
                                <center>
                                    <asp:Label ID="lblIncidentReport" Text="Vehicle Alert Report" CssClass="Labels" runat="server"
                                        Font-Bold="True" Font-Size="20px" ForeColor="Black"></asp:Label>
                                        </center>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbllocataion" Text="Location" CssClass="Reportcolor" runat="server"
                                        Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="txtlocation" CssClass="Reportcolor" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblVehicleType" Text="Vehicle Type" CssClass="Reportcolor" runat="server"
                                        Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="txtVehicleType" CssClass="Reportcolor" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblVehicleRegNo" Text="Vehicle Register No." CssClass="Reportcolor"
                                        runat="server" Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="txtVehicleRegNo" CssClass="Reportcolor" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblVehicleownerNric" Text="Vehicle Owner NRIC No." CssClass="Reportcolor"
                                        runat="server" Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="txtVehicleownerNric" CssClass="Reportcolor" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblVehicleownerName" Text="Vehicle Owner Name" CssClass="Reportcolor"
                                        runat="server" Font-Bold="True"></asp:Label>
                                </td>
                                  <td colspan="3">
                                    <asp:Label ID="txtVehicleownerName" CssClass="Reportcolor" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblVehicleReason" Text="Reason For Alert" CssClass="Reportcolor" runat="server"
                                        Font-Bold="True"></asp:Label>
                                </td>
                                <td colspan="3">
                                    <asp:Label ID="txtVehicleReason" CssClass="Reportcolor" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" style="height: 100px">
                                    <asp:Label ID="lblcomment" Text="Comments" CssClass="Reportcolor" runat="server"
                                        Font-Bold="True"></asp:Label>
                                </td>
                                <td colspan="3" valign="top" style="height: 100px">
                                    <asp:Label ID="txtcomment" CssClass="Reportcolor" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:Label ID="lbl" Text="Alert Raised By :" CssClass="Reportcolor" runat="server"
                                        Font-Bold="True"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblRaisedNric" Text="NRIC No." CssClass="Reportcolor" runat="server"
                                        Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="txtRaisedNric" CssClass="Reportcolor" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblRaisedName" Text="Name" CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="txtRaisedName" CssClass="Reportcolor" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblPhone" Text="Phone No." CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="txtPhone" CssClass="Reportcolor" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbldesignation" Text="Designation" CssClass="Reportcolor" runat="server"
                                        Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="txtdesignation" CssClass="Reportcolor" runat="server"></asp:Label>
                                </td>
                            </tr>
                          
                        </table>
                    </asp:Panel>
                    <br />
                       <div style="background-color: #E4E4E4; width:700px" >
                        <center>
                          <a id="print" href="printpage.aspx" class="Button"   runat="server" target="_blank" style="  Height:30px; Width:100px; color:White; padding:7px 30px 7px 30px">Print</a>

                                    <asp:Button ID="BtnCancel" Text="Cancel" runat="server" CausesValidation="false"
                                        CssClass="Button" Style="margin-left: 10px" Height="30px" Width="100px" OnClick="BtnCancel_Click" />
                                </center></div>
                                </center>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
        <asp:HiddenField ID="delete" runat="server" />
        <asp:ModalPopupExtender ID="ModalPopupDelete" runat="server" TargetControlID="delete"
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
                                            <asp:Button ID="BtnDeleteYes" CausesValidation="false" OnClick="Delete_Alert_Click"
                                                Text="Yes" runat="server" CssClass="Button" Height="30px" Width="100px" />
                                            <asp:Button ID="btnCancel21" Text="No" runat="server" CausesValidation="false" CssClass="Button"
                                                Style="margin-left: 10px" Height="30px" Width="100px" OnClick="BtnCancel_Click" />
                                        </center>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </center>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
 
</asp:Content>
