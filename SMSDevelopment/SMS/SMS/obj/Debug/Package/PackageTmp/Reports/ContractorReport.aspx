<%@ Page Language="C#" MasterPageFile="~/master/SpaMaster.Master" AutoEventWireup="true"
    CodeBehind="ContractorReport.aspx.cs" Inherits="SMS.Reports.ContractorReport" %>

<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
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

    <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Contractor Report</span>
        </div>
        <div class="btnbar" style="margin-top: 20px">
            <div class="btnbarBox">
                <ul>
                    <%--<li>
                        <asp:LinkButton ID="imgUpdate" runat="server" CausesValidation="false" OnClick="ImgView_Click">
                            <span id="spanUpdate1" runat="server" class="iconUpdate" style="line-height: 120px;">
                                <asp:Label ID="spanUpdate" runat='server' Text="View"></asp:Label></span>
                        </asp:LinkButton>
                    </li>--%>
                    <li>
                        <asp:LinkButton ID="imgDelete" runat="server" CausesValidation="false" OnClick="ImgDelete_Click">
                            <span id="spanDelete" runat="server" class="iconDelete" style="line-height: 120px;">
                                Delete </span>
                        </asp:LinkButton>
                    </li>
                    <li>
                    <asp:LinkButton ID="imgCopy" runat="server" CausesValidation="false" OnClick="ImgView_Click">
                        <span id="spanCopy" runat="server" class="iconCopy" style="line-height: 120px;">View
                        </span>
                    </asp:LinkButton>
                </li>
                </ul>
            </div>
        </div>
        <br />
        <asp:Panel runat="server" ID="Pnl" BackColor="White" Visible="false" Style="margin-left: 1.5em;
            margin-top: 0px;" Font-Bold="True" Width="750px">
            <table width="750px" class="table">
                <tr>
                    <td>
                        <asp:Label ID="lblLocation" Text="Location" CssClass="Labels" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddllocation" runat="server" CssClass="Labels" Width="130px"
                            Style="margin-left: -0.3em" OnSelectedIndexChanged="ddllocation_SelectedIndexChanged"
                            ForeColor="Black">
                        </asp:DropDownList>
                        <asp:Label ID="SearchLocID" runat="server" Visible="False" CssClass="Input"></asp:Label>
                    </td>
                    <td align="center">
                        <asp:Label ID="lblnricno" CssClass="Labels" runat="server" Text="NRIC/FIN No."></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtnricno" CssClass="Input" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblpasstype" CssClass="Labels" runat="server" Text="Pass No."></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtpasstype" CssClass="Input" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblkeyno" CssClass="Labels" runat="server" Text="Key No."></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtkeyno" CssClass="Input" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbldatefrom" CssClass="Labels" runat="server" Text="DateFrom"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtdatefrom" CssClass="Input" runat="server" OnTextChanged="txtdatefrom_TextChanged"></asp:TextBox>
                        <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                            Format="MM/dd/yyyy" TargetControlID="txtdatefrom" PopupButtonID="imgBtnFromDate2" />
                        <asp:ImageButton ID="imgBtnFromDate2" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"
                            OnClick="imgBtnFromDate2_Click" class="calender" />
                    </td>
                    <td align="left" style="width: 110px">
                        <asp:Label ID="lbldateto" CssClass="Labels" runat="server" Text="To"></asp:Label>
                    </td>
                    <td style="width: 170px">
                        <asp:TextBox ID="txtdateto" CssClass="Input" runat="server"></asp:TextBox>
                        <AJAX:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="AjaxCalendar"
                            Format="MM/dd/yyyy" TargetControlID="txtdateto" PopupButtonID="imgBtnFromDate3" />
                        <asp:ImageButton ID="imgBtnFromDate3" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"
                            OnClick="imgBtnFromDate3_Click" class="calender" />
                    </td>
                    <td style="width: 92px">
                        <asp:Label ID="lblvehicleno" CssClass="Labels" runat="server" Text="Vehicle No."
                            Visible="False"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtvehicleno" CssClass="Input" runat="server" Visible="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblname" CssClass="Labels" runat="server" Text="Name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtname" CssClass="Input" runat="server"></asp:TextBox>
                    </td>
                    <asp:TextBox ID="txtrole" runat="server" Visible="False" Width="15px">Contractor</asp:TextBox>
                </tr>
                <tr>
                    <td style="height: 50px">
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <table id="tblbtn" runat="server" visible="false" width="750px" style="margin-left: 1.4em;
            margin-bottom: -0.4em; border: 1px; border-style: groove; border-color: Black;
            background-color: Gray">
            <tr>
                <td colspan="4"  style="width: 750px">
                <center>
                    <asp:Button ID="btnSearch1" CssClass="Buttons" runat="server" Text="Search" OnClick="btnSearch1_Click"
                        Width="85px" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnclear" CssClass="Buttons" runat="server" Text="Clear" Width="85px"
                        OnClick="btnclear_Click" />
                        </center>
                </td>
            </tr>
        </table>
        <div class="clear">
        </div>
        <div id="content" runat="server">
        </div>
        <br />
       <%-- <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel4" runat="server">
                </telerik:RadAjaxLoadingPanel>--%>

                 <asp:Panel ID="panelgrid" runat="server">
                <telerik:RadGrid ID="gvItemTable1" runat="server" CssClass="RadGrid" GridLines="None"
                    HeaderStyle-Font-Size="12px" AllowPaging="True" PageSize="50" AllowSorting="True"
                    AutoGenerateColumns="False" ShowStatusBar="true" Skin="Simple" HeaderStyle-HorizontalAlign="left"
                    HeaderStyle-BackColor="#ad1c1c" HeaderStyle-ForeColor="white" AllowMultiRowSelection="false"
                    AllowFilteringByColumn="true">
                    <GroupingSettings CaseSensitive="false" />
                    <MasterTableView CommandItemDisplay="Bottom" DataKeyNames="checkout_id">
                        <CommandItemSettings ShowAddNewRecordButton="false" ShowRefreshButton="false" />
                        <Columns>
                            <telerik:GridTemplateColumn UniqueName="CheckBoxTemplateColumn" ShowFilterIcon="false"
                                AllowFiltering="false">
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="ToggleRowSelection"
                                        AutoPostBack="True" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn UniqueName="checkin_time" HeaderText="In Time" DataField="checkin_time"
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="checkout_time" DataField="checkout_time" HeaderText="Out Time"
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="NRICno" DataField="NRICno" HeaderText="NRIC/FIN No."
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="user_name" DataField="user_name" HeaderText="Name"
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="telephone" DataField="telephone" HeaderText="Phone No."
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="pass_no" DataField="pass_no" HeaderText="Pass No."
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="company_from" DataField="company_from" HeaderText="Company From"
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="to_visit" DataField="to_visit" HeaderText="To Visit"
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                    <SelectedItemStyle BorderWidth="0px" Font-Bold="true" ForeColor="White" BackColor="Red" />
                </telerik:RadGrid>
        <%--    </ContentTemplate>
        </asp:UpdatePanel>--%>
       </asp:Panel>

        <asp:HiddenField ID="hdnUpdate" runat="server" />
        <asp:ModalPopupExtender ID="ModalPopupUpdate" runat="server" TargetControlID="hdnUpdate"
            CancelControlID="BtnCancelUpdate" BackgroundCssClass="modalBackground" PopupControlID="pnlUpdate">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlUpdate" ScrollBars="Vertical" runat="server" BackColor="White"
            Height="600px" Width="750px" Style="display: none">
            <asp:UpdateProgress ID="UpdateProgress1" DisplayAfter="10" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                <ProgressTemplate>
                    <div class="divWaiting">
                        <asp:Image ID="imgWait83" runat="server" ImageAlign="Middle" ImageUrl="~/img/progress.gif" /><br />
                        <asp:Label ID="lblWait83" runat="server" Text=" Please wait... " Font-Bold="true"
                            Font-Size="Large" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <br />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <center>
                        <asp:Panel ID="printview" runat="server" BackColor="White" 
                            Font-Bold="True">
                            <table width="700px" cellspacing="10px">
                                <tr>
                                    <td  colspan="4">
                                    <center>
                                        <asp:Image runat="server" ID="image1" Style="height: 80px; width: 100px"></asp:Image>
                                        <hr style="background-color: Black; color: Black; border-color: Black"></hr>
                                        </center>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" >
                                    <center>
                                        <asp:Label ID="lblIncidentReport" Text="Contractor Report" CssClass="Labels" runat="server"
                                            Font-Bold="True" Font-Size="20px" ForeColor="Black"></asp:Label>
                                            </center>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblInTime" Text="In Time" CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:Label ID="txtInTime" CssClass="Reportcolor" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblOutTime" Text="Out Time" CssClass="Reportcolor" runat="server"
                                            Font-Bold="True"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:Label ID="txtOutTime" CssClass="Reportcolor" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label1" Text="Name" CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:Label ID="txtnameView" CssClass="Reportcolor" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblNRIC" Text="NRIC No." CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:Label ID="txtNRIC" CssClass="Reportcolor" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblAddress" Text="Address" CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:Label ID="txtAddress" CssClass="Reportcolor" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblPhone" Text="Contact No." CssClass="Reportcolor" runat="server"
                                            Font-Bold="True"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:Label ID="txtPhone" CssClass="Reportcolor" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblPassView" Text="Pass No." CssClass="Reportcolor" runat="server"
                                            Font-Bold="True"></asp:Label>
                                    </td>
                                     <td colspan="3">
                                        <asp:Label ID="txtPass" CssClass="Reportcolor" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblPassTypeView" Text="Pass Type" CssClass="Reportcolor" runat="server"
                                            Font-Bold="True"></asp:Label>
                                    </td>
                                     <td colspan="3">
                                        <asp:Label ID="txtPassTypeView" CssClass="Reportcolor" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblKeyNoView" Text="Key No." CssClass="Reportcolor" runat="server"
                                            Font-Bold="True"></asp:Label>
                                    </td>
                                      <td colspan="3">
                                        <asp:Label ID="txtKeyNoView" CssClass="Reportcolor" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblVehicle" Text="Vehicle No." CssClass="Reportcolor" runat="server"
                                            Font-Bold="True"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:Label ID="txtVehicle" CssClass="Reportcolor" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblCompanyFrom" Text="Company From" CssClass="Reportcolor" runat="server"
                                            Font-Bold="True"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:Label ID="txtCompanyFrom" CssClass="Reportcolor" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblToVisit" Text="To Visit" CssClass="Reportcolor" runat="server"
                                            Font-Bold="True"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:Label ID="txtToVisit" CssClass="Reportcolor" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <asp:Label ID="lblRemark" Text="Remarks" CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:Label ID="txtRemark" CssClass="Reportcolor" runat="server"></asp:Label>
                                    </td>
                                </tr>
                              
                            </table>
                        </asp:Panel>
                        <br />
                        <div style="background-color: #E4E4E4; width:690px">
                            <center>
                                 <a id="print" href="printpage.aspx" class="Button"   runat="server" target="_blank" style="  Height:30px; Width:100px; color:White; padding:7px 30px 7px 30px">Print</a>

                                <asp:Button ID="BtnCancelUpdate" CssClass="Button" Height="30px" Width="100px" runat="server"
                                    Text="Cancel" OnClick="BtnCancelPrint_Click" />
                            </center>
                        </div>
                    </center>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
        <asp:HiddenField ID="hdnDelete" runat="server" />
        <asp:ModalPopupExtender ID="ModalPopupDelete" runat="server" TargetControlID="hdnDelete"
            CancelControlID="btnCancelDelete" BackgroundCssClass="modalBackground" PopupControlID="pnlDelete">
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
                                        Are you sure you want to delete the record!
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                        <br />
                                        <center>
                                            <asp:Button ID="BtnDeleteYes" OnClick="Deletepopup_Yes_Click" CausesValidation="false"
                                                Text="Yes" runat="server" CssClass="Button" Height="30px" Width="100px" />
                                            <asp:Button ID="btnCancelDelete" Text="No" runat="server" CausesValidation="false"
                                                OnClick="btnCancelDelete_Click" CssClass="Button" Style="margin-left: 10px" Height="30px"
                                                Width="100px" />
                                        </center>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </center>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
        <div>
            <asp:Panel ID="panel11" runat="server" Visible="false" Width="750px" Style="margin-left: 1.2em">
                <asp:GridView ID="gvItemTable" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" CellPadding="5" Width="750px" OnRowDataBound="gvItem_RowDataBound"
                    OnRowCommand="gvItem_RowCommand" OnPageIndexChanging="gvItem_PageIndexChanging"
                    OnSelectedIndexChanged="GridView1_SelectedIndexChanged" HeaderStyle-HorizontalAlign="Center"
                    PageSize="20">
                    <AlternatingRowStyle CssClass="AlternateRow" />
                    <HeaderStyle CssClass="HeaderRow" />
                    <RowStyle CssClass="NormalRow" />
                    <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="20px" />
                    <SelectedRowStyle CssClass="HighlightedRow" />
                    <EmptyDataRowStyle CssClass="NoRecords" />
                    <EmptyDataTemplate>
                        <asp:Label ID="lblNoRecords" Text="no record(s) in the system." runat="server">
                        </asp:Label>
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:BoundField DataField="checkin_time" HeaderText="In Time"></asp:BoundField>
                        <asp:BoundField DataField="checkout_time" HeaderText="Out Time"></asp:BoundField>
                        <asp:BoundField DataField="NRICno" HeaderText="NRIC/FIN No."></asp:BoundField>
                        <asp:BoundField DataField="user_name" HeaderText=" Name"></asp:BoundField>
                        <asp:BoundField DataField="telephone" HeaderText="Phone No."></asp:BoundField>
                        <asp:BoundField DataField="pass_no" HeaderText="Pass No."></asp:BoundField>
                        <asp:BoundField DataField="company_from" HeaderText="Company From"></asp:BoundField>
                        <asp:BoundField DataField="to_visit" HeaderText="To Visit"></asp:BoundField>
                        <asp:TemplateField HeaderText="View" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:ImageButton ImageUrl="../../Images/reports-stack.png" ID="btnEdit" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.checkout_id") %>'
                                    CommandName="View" runat="server" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="50px" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:ImageButton ImageUrl="~/Images/Delete.gif" ID="btnDelete" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.checkout_id") %>'
                                    CommandName="DeleteRow" runat="server" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="50px" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </asp:Panel>
        </div>
        <br />
        <div style=" background-color: #E4E4E4; width:100%">
      <center>
        <table style=" background-color: #E4E4E4; width:50%;" >
                    <tr>
                        <td style="width: 111px">
                            <asp:Label ID="exportto" CssClass="Labels" runat="server" Text="Export To" ForeColor="#000099"
                                Font-Bold="true"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownList1" CssClass="Labels" runat="server" ForeColor="#000099"
                                Height="30px" Width="75px">
                                <asp:ListItem>Pdf</asp:ListItem>
                                <asp:ListItem>Word</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;&nbsp;
                            <asp:Button ID="btnGo" CssClass="Button" Height="30px" Width="100px" runat="server"
                                Text="Go" OnClick="btnGo_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnEmail" CssClass="Buttons" runat="server" Text="E-Mail" Width="85px"
                                Visible="False" />
                        </td>
                        <td>
                            <asp:Button ID="btnPrint" CssClass="Buttons" runat="server" Text="Print" Width="85px"
                                Visible="False" />
                        </td>
                    </tr>
                </table>
            </center>
        </div>
        <br />
    </div>
</asp:Content>
