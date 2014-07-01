<%@ Page Language="C#" MasterPageFile="~/master/SpaMaster.Master" AutoEventWireup="true"
    CodeBehind="ItemReport.aspx.cs" Inherits="SMS.Reports.ItemReport" %>

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

        <div class="divHeader">
            <span class="pageTitle">Inventory Report</span>
        </div>
        <div class="btnbar" style="margin-top: 20px">
            <div class="btnbarBox">
                <ul>
                   <%-- <li>
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
        <div id="divAdvSearch" runat="server" visible="false">
            <br />
            <asp:Panel runat="server" ID="Pnl" BackColor="White" Style="margin-left: 1.5em; margin-top: 0px;"
                Font-Bold="True" Width="750px">
                <table width="750px" class="table">
                    <tr>
                        <td>
                            <asp:Label ID="lblLocation" Text="Location" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td style="width: 123px">
                            <asp:DropDownList ID="ddllocation" runat="server" CssClass="Labels" Width="130px"
                                Style="margin-left: -0.2em" ForeColor="Black" AutoPostBack="True" OnSelectedIndexChanged="ddllocation_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:Label ID="SearchLocID" runat="server" Visible="False" CssClass="Input"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblitenno" CssClass="Labels" runat="server" Text="ModelNo."></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtitemno" CssClass="Input" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblsignin" CssClass="Labels" runat="server" Text="IssuedTo"></asp:Label>
                        </td>
                        <td style="width: 123px">
                            <asp:TextBox ID="txtsigninby" CssClass="Input" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="lblsignout" CssClass="Labels" runat="server" Text="Issued By"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtsignoutby" CssClass="Input" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbldatefrom" CssClass="Labels" runat="server" Text="DateFrom"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtdatefrom" CssClass="Input" runat="server"></asp:TextBox>
                            <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                                Format="MM/dd/yyyy" TargetControlID="txtdatefrom" PopupButtonID="imgBtnFromDate2" />
                            <asp:ImageButton ID="imgBtnFromDate2" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"
                                class="calender" />
                        </td>
                        <td>
                            <asp:Label ID="lbldateto" CssClass="Labels" runat="server" Text="To"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtdateto" CssClass="Input" runat="server"></asp:TextBox>
                            <AJAX:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="AjaxCalendar"
                                Format="MM/dd/yyyy" TargetControlID="txtdateto" PopupButtonID="imgBtnFromDate3" />
                            <asp:ImageButton ID="imgBtnFromDate3" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"
                                class="calender" />
                        </td>
                    </tr>
                    <tr>
                        <td height="30px" style="width: 84px">
                            <asp:Label ID="lblStatus" Text="Status" CssClass="Labels" runat="server" Visible="false"></asp:Label>
                        </td>
                        <td style="width: 123px">
                            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="Labels" ForeColor="Black"
                                Height="20px" Width="90px" Visible="false">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>Lost</asp:ListItem>
                                <asp:ListItem>Found</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td height="50px" style="width: 84px">
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <table width="750px" style="margin-left: 1.4em; margin-bottom: -0.4em; border: 1px;
                border-style: groove; border-color: Black; background-color: Gray">
                <tr>
                    <td colspan="4" align="center" style="width: 750px">
                        <asp:Button ID="btnSearch1" CssClass="Buttons" runat="server" Text="Search" OnClick="btnSearch1_Click"
                            Width="85px" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnclear" CssClass="Buttons" runat="server" Text="Clear" Width="85px"
                            OnClick="btnclear_Click" />
                    </td>
                </tr>
            </table>
        </div>
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
                    <MasterTableView CommandItemDisplay="Bottom" DataKeyNames="AddItem_ID">
                        <CommandItemSettings ShowAddNewRecordButton="false" ShowRefreshButton="false" />
                        <Columns>
                            <telerik:GridTemplateColumn UniqueName="CheckBoxTemplateColumn" ShowFilterIcon="false"
                                AllowFiltering="false">
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="ToggleRowSelection"
                                        AutoPostBack="True" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn UniqueName="IssuedBy_Time" HeaderText="Issued Time" DataField="IssuedBy_Time"
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="Model_No" DataField="Model_No" HeaderText="Model No."
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="Item_Name" DataField="Item_Name" HeaderText="Item Name"
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="IssuedBy_Name" DataField="IssuedBy_Name" HeaderText="Issued To Name"
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="IssuedTo_Name" DataField="IssuedTo_Name" HeaderText="Issued By Name"
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="Status" DataField="Status" HeaderText="Status"
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                    <SelectedItemStyle BorderWidth="0px" Font-Bold="true" ForeColor="White" BackColor="Red" />
                </telerik:RadGrid>
          <%--  </ContentTemplate>
        </asp:UpdatePanel>--%>
        </asp:Panel>


        <asp:HiddenField ID="hdnUpdate" runat="server" />
        <asp:ModalPopupExtender ID="ModalPopupUpdate" runat="server" TargetControlID="hdnUpdate"
            CancelControlID="BtnCancelUpdate" BackgroundCssClass="modalBackground" PopupControlID="pnlUpdate">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlUpdate" runat="server" BackColor="White"
            Height="520px" Width="750px" Style="display: none">
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
                        <asp:Panel ID="printview" runat="server" BackColor="White" Width="690"
                            Font-Bold="True">
                            <table width="690px">
                                <tr>
                                    <td  colspan="4">
                                    <center>
                                        <asp:Image runat="server" ID="image1" Style="height: 80px; width: 100px"></asp:Image>
                                        <hr style="background-color: Black; color: Black; border-color: Black"></hr>
                                        </center>
                                    </td>
                                </tr>
                                <tr>
                                    <td  colspan="4">
                                    <center>
                                        <asp:Label ID="lblIncidentReport" Text="Item Report" CssClass="Labels" runat="server"
                                            Font-Bold="True" Font-Size="20px" ForeColor="Black">
                                        </asp:Label>
                                        </center>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblItemName" Text="ItemName" CssClass="Labels" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="txtItemName" runat="server" CssClass="Labels"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblModelNo" Text="Model No." CssClass="Labels" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="txtModelNo" runat="server" CssClass="Labels"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblItemDescription" Text="ItemDescription" CssClass="Labels" runat="server"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:Label ID="txtItemdescription" runat="server" Width="570px" CssClass="Labels"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblItemquantity" Text="Item Quantity" CssClass="Labels" runat="server"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:Label ID="txtItemQty" runat="server" CssClass="Labels"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:Label ID="lblIssuedTo" Text="Issued To :" CssClass="Labels" runat="server" Font-Bold="True"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblIssuedToNRIC" Text="NRIC/FIN No." CssClass="Labels" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="txtIssuedNRIC" runat="server" CssClass="Labels"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblIssuedToName" Text="Name" CssClass="Labels" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="txtIssuedToName" runat="server" CssClass="Labels"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblIssuedToPosition" Text="Position" CssClass="Labels" runat="server"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:Label ID="txtIssuedToPosition" runat="server" CssClass="Labels"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:Label ID="lblIssuedBy" Text="Issued By:" CssClass="Labels" runat="server" Font-Bold="True"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblIssuedByNRIC" Text="NRIC/FIN No." CssClass="Labels" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="txtIssuedByNRIC" runat="server" CssClass="Labels"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblIssuedByName" Text="Name" CssClass="Labels" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="txtIssuedByName" runat="server" CssClass="Labels"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblIssuedByPosition" Text="Position" CssClass="Labels" runat="server"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:Label ID="txtIssuedByPosition" runat="server" CssClass="Labels"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblComment" Text="Comments" CssClass="Labels" runat="server"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:Label ID="txtComments" runat="server" CssClass="Labels"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label1" Text="Status :" CssClass="Labels" runat="server" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:Label ID="txtStatus" runat="server" CssClass="Labels"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <br />
                        <div style="background-color: #E4E4E4; width:690px">
                            <center>
                                <a id="print" href="printpage.aspx" class="Button" runat="server" target="_blank"
                                    style="height: 30px; width: 100px; color: White; padding: 7px 30px 7px 30px">Print</a>
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
        <br />
        <div>
            <asp:Panel ID="panel1" runat="server" Visible="false" Width="750px" Style="margin-left: 1.2em">
                <asp:GridView ID="gvItemTable" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" CellPadding="5" Width="750px" OnRowDataBound="gvItem_RowDataBound"
                    OnRowCommand="gvItem_RowCommand" OnPageIndexChanging="gvItem_PageIndexChanging"
                    OnSelectedIndexChanged="gvItemTable_SelectedIndexChanged" PageSize="20">
                    <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center" />
                    <RowStyle CssClass="NormalRow" />
                    <AlternatingRowStyle CssClass="AlternateRow" />
                    <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="20px" />
                    <SelectedRowStyle CssClass="HighlightedRow" />
                    <EmptyDataRowStyle CssClass="NoRecords" />
                    <EmptyDataTemplate>
                        <asp:Label ID="lblNoRecords" Text="no record(s) in the system." runat="server">
                        </asp:Label>
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:BoundField DataField="IssuedBy_Time" HeaderText="Issued Time"></asp:BoundField>
                        <asp:BoundField DataField="Model_No" HeaderText="Model No."></asp:BoundField>
                        <asp:BoundField DataField="Item_Name" HeaderText="Item Name"></asp:BoundField>
                        <asp:BoundField DataField="IssuedBy_Name" HeaderText="Issued To Name" />
                        <asp:BoundField DataField="IssuedTo_Name" HeaderText="Issued By Name"></asp:BoundField>
                        <asp:BoundField DataField="Status" HeaderText="Status"></asp:BoundField>
                        <asp:TemplateField HeaderText="View" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:ImageButton ImageUrl="~/Images/reports-stack.png" ID="btnView" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.AddItem_ID") %>'
                                    CommandName="View" runat="server" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:ImageButton ImageUrl="~/Images/Delete.gif" ID="btnDelete" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.AddItem_ID") %>'
                                    CommandName="DeleteRow" runat="server" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </asp:Panel>
        </div>
        <br />
        <div style="background-color: #E4E4E4; width: 100%">
            <center>
                <table style="background-color: #E4E4E4; width: 50%;">
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
  

</asp:Content>
