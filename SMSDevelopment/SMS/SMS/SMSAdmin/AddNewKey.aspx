<%@ Page Language="C#" MasterPageFile="~/master/SpaMaster.Master" AutoEventWireup="true"
    CodeBehind="AddNewKey.aspx.cs" Inherits="SMS.SMSAdmin.AddNewKey" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
            <span>Add New Key</span>
            <br />
            </div>
    <div class="btnbar">
        <div class="btnbarBox">
            <ul>
                <li>
                    <asp:LinkButton ID="imdAdd" runat="server" CausesValidation="false" OnClick="imdAdd_Click">
                        <span id="SpanAdd1" runat="server" class="iconAdd" style="line-height: 120px;">
                            <asp:Label ID="SpanAdd" runat="server" Text="Add"></asp:Label>
                        </span>
                    </asp:LinkButton>
                </li>
                <li>
                    <asp:LinkButton ID="imgUpdate" runat="server" CausesValidation="false" OnClick="imgUpdate_Click">
                        <span id="SpanUpdate1" runat="server" class="iconUpdate" style="line-height: 120px;">
                            <asp:Label ID="SpanUpdate" runat="server" Text="Edit"></asp:Label>
                        </span>
                    </asp:LinkButton>
                </li>
                <li>
                    <asp:LinkButton ID="imgDelete" runat="server" CausesValidation="false" OnClick="imgDelete_Click">
                        <span id="SpanDelete" runat="server" class="iconDelete" style="line-height: 120px;">
                            Delete </span>
                    </asp:LinkButton>
                </li>
            </ul>
        </div>
    </div>
    <div class="clear">
    </div>
    <ul id="tabs" class="ui-tabs ui-widget ui-widget-content ui-corner-all">
        <li id="ViewKey" runat="server">
            <asp:LinkButton ID="lnkViewKey" runat="server" CausesValidation="false" OnClick="lnkViewKey_Click">
                <span class="icon1" id="SpanPart" runat="server">View Key</span>
            </asp:LinkButton></li>
        <li id="CheckInKey" runat="server">
            <asp:LinkButton ID="lnkCheckInKey" runat="server" CausesValidation="false" OnClick="lnkCheckInKey_Click">
                <span class="icon2" id="SpanOperation" runat="server">Check In Key </span>
            </asp:LinkButton></li>
    </ul>
    <div id="content" runat="server">
        <%--<div class="divHeader">
            <span class="pageTitle">Key Manager</span></div>--%>
        <div>
            <asp:Label ID="lblerror" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"></asp:Label></div>
        <div id="divAdvSearch" runat="server" visible="False">
            <asp:Panel runat="server" ID="Panel1" BackColor="White" Style="margin-left: 1.5em"
                Font-Bold="True" Width="100%">
                <table width="100%" class="table" style="display: none">
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblKeyNo" Text="Key No." CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtKeyNo12" runat="server" CssClass="Input" />
                        </td>
                        <td>
                            <asp:Label ID="lblKeyDesc" Text="Status" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlstatus" runat="server" CssClass="Labels" OnSelectedIndexChanged="ddlstatus_SelectedIndexChanged">
                                <asp:ListItem> </asp:ListItem>
                                <asp:ListItem>Free </asp:ListItem>
                                <asp:ListItem>Reserve </asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lbldatefrom" CssClass="Labels" runat="server" Text="Date:  From"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtdatefrom" CssClass="Input" runat="server" OnTextChanged="txtdatefrom_TextChanged"></asp:TextBox>
                            <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                                Format="MM/dd/yyyy" TargetControlID="txtdatefrom" PopupButtonID="imgBtnFromDate2" />
                            <asp:ImageButton ID="imgBtnFromDate2" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"
                                OnClick="imgBtnFromDate2_Click" class="calender" />
                        </td>
                        <td align="left">
                            <asp:Label ID="lbldateto" CssClass="Labels" runat="server" Text="To"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtdateto" CssClass="Input" runat="server" OnTextChanged="txtdateto_TextChanged"></asp:TextBox>
                            <AJAX:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="AjaxCalendar"
                                Format="MM/dd/yyyy" TargetControlID="txtdateto" PopupButtonID="imgBtnFromDate3" />
                            <asp:ImageButton ID="imgBtnFromDate3" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"
                                OnClick="imgBtnFromDate3_Click" class="calender" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblLocation" Text="Location" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddllocation" runat="server" CssClass="Labels" Width="150px"
                                Style="margin-left: -0.1em" class="Label2">
                            </asp:DropDownList>
                            <asp:Label ID="SearchLocID" runat="server" Text="" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5" align="left">
                            <asp:Label ID="lblKeyName" Text=" Key Added By:" CssClass="Labels" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblKeyNRIC" Text="NRIC No." CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtKeyNRIC" runat="server" CssClass="Input" />
                        </td>
                        <td>
                            <asp:Label ID="lblName" Text="Name" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td>



                            <asp:TextBox ID="txtKeyNames" runat="server" CssClass="Input" Width="173px" />
                        </td>
                    </tr>
                    <tr>
                        <td height="20px">
                        </td>
                    </tr>
                    <%-- <table width="100%" style="margin-left: 0.1em; margin-bottom: -0.4em; border: 1px;
                        border-style: groove; border-color: Black; background: url(../Images/1397d40aa687.jpg)">--%>
                    <tr>
                        <td colspan="4" align="center" width="700px">
                            <asp:Button ID="btnSearchKeyAdd" Text="Search" runat="server" CssClass="Button" OnClick="btnSearchKeyAdd_Click"
                                Width="85px" />&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnClearKeyAdd" Text="Clear" runat="server" CssClass="Button" OnClick="btnClearKeyAdd_Click"
                                Width="85px" />
                        </td>
                    </tr>
                    <%--</table>--%>
                </table>
            </asp:Panel>
        </div>
        <div>
            <%-- <asp:GridView ID="gvKeySearch" runat="server" AllowPaging="True" AllowSorting="True"
                AutoGenerateColumns="False" CellPadding="5" Width="100%" OnRowDataBound="gvNewKey_RowDataBound"
                OnRowCommand="gvNewKey_RowCommand" OnPageIndexChanging="gvNewKey_PageIndexChanging"
                CssClass="GridMain2" OnSelectedIndexChanged="gvNewKey_SelectedIndexChanged" PageSize="100">
                <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center" />
                <RowStyle CssClass="NormalRow" />
                <AlternatingRowStyle CssClass="AlternateRow" />
                <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="20px" />
                <SelectedRowStyle CssClass="HighlightedRow" />
                <EmptyDataRowStyle CssClass="NoRecords" />
                <EmptyDataTemplate>
                    <asp:Label ID="lblNoRecords" Text="Your search did not match any Key or, there may be no records in the system."
                        runat="server">
                    </asp:Label>
                    <p>
                        Suggestions:</p>
                    <li>Try different keywords.</li>
                    <li>Try fewer keywords.</li>
                    <li>Make sure all words are spelled correctly.</li>
                    <li>There may be no records in the system.</li>
                </EmptyDataTemplate>
                <Columns>
                  
                    <asp:BoundField DataField="BunchNo" HeaderText="Bunch No."></asp:BoundField>
                    <asp:BoundField DataField="NoOfKey" HeaderText="No. of Key"></asp:BoundField>
                    <asp:BoundField DataField="status" HeaderText="Status"></asp:BoundField>
                    <asp:BoundField DataField="Staff_ID" HeaderText="NRIC No."></asp:BoundField>
                    <asp:BoundField DataField="Location_ID" HeaderText="Location Name" />
                    <asp:BoundField DataField="position" HeaderText="Position"></asp:BoundField>
                    <asp:TemplateField HeaderText="Edit/View" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="../Images/Edit.gif" ID="btnEdit" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.Key_ID") %>'
                                CommandName="EditRow" runat="server" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="~/Images/Delete.gif" ID="btnDelete" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.Key_ID") %>'
                                CommandName="DeleteRow" runat="server" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            --%>
            <asp:Panel ID="Panelgrid" runat="server">
                    <telerik:RadGrid ID="gvKeySearch" runat="server" CssClass="RadGrid" GridLines="None"
                        AllowPaging="True" PageSize="50" AllowSorting="True" AutoGenerateColumns="False"
                        HeaderStyle-Font-Size="12px" HeaderStyle-HorizontalAlign="Left" ShowStatusBar="true"
                        Skin="Simple" HeaderStyle-BackColor="#ad1c1c" HeaderStyle-ForeColor="white" EnableAJAX="true"
                        AllowMultiRowSelection="False" AllowFilteringByColumn="true">
                        <GroupingSettings CaseSensitive="false" />
                        <MasterTableView CommandItemDisplay="Bottom" DataKeyNames="Key_ID">
                            <CommandItemSettings ShowAddNewRecordButton="false" ShowRefreshButton="false" />
                            <Columns>
                                <telerik:GridTemplateColumn UniqueName="CheckBoxTemplateColumn" ShowFilterIcon="false"
                                    AllowFiltering="false">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="ToggleRowSelection"
                                            AutoPostBack="True" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn UniqueName="BunchNo" HeaderText="Bunch No." DataField="BunchNo"
                                    CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="NoOfKey" HeaderText="No. Of Key" DataField="NoOfKey"
                                    CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="status" HeaderText="status" DataField="status"
                                    CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="Staff_ID" HeaderText="NRIC No." DataField="Staff_ID"
                                    CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="Location_ID" HeaderText="Location Name" DataField="Location_ID"
                                    CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="position" HeaderText="position" DataField="position"
                                    CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                        <%-- <ClientSettings Selecting-AllowRowSelect="true" ReorderColumnsOnClient="True" AllowDragToGroup="True"
                                        AllowColumnsReorder="True">
                                        <Selecting AllowRowSelect="True" />
                                    </ClientSettings>--%>
                        <SelectedItemStyle BorderWidth="0px" Font-Bold="true" ForeColor="White" BackColor="Red" />
                    </telerik:RadGrid>
                </asp:Panel>
        </div>
        <br />
        <div style="display: none">
            <table width="100%" style="margin-left: 1.3em; margin-bottom: -0.4em;">
                <tr>
                    <td align="right" style="width: 448px">
                        <asp:Button ID="btnNewBTable" Text="Add New Key" runat="server" CssClass="Button"
                            OnClick="btnNewBTable_Click" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td align="left" style="width: 448px">
                        <asp:Button ID="btnChkinkey" Text="Check In Key" runat="server" CssClass="Button"
                            OnClick="btnChkinkey_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
    </div>
    <asp:HiddenField ID="HiddenFieldAdd" runat="server" />
    <asp:ModalPopupExtender ID="ModalPopupAdd" runat="server" TargetControlID="HiddenFieldAdd"
        CancelControlID="ButtonCancel" BackgroundCssClass="modalBackground" PopupControlID="AdminADDpnl">
    </asp:ModalPopupExtender>
    <asp:Panel ID="AdminADDpnl" runat="server" BackColor="White" Height="500px" Width="450px"
        BorderWidth="1px" Style="display: none">
        <asp:UpdateProgress ID="UpdateProgress9" DisplayAfter="10" runat="server" AssociatedUpdatePanelID="UpdatePanel6">
            <ProgressTemplate>
                <div class="divWaiting" style="margin-top: 200">
                    <asp:Image ID="imgWait1" runat="server" ImageAlign="Middle" ImageUrl="~/img/progress.gif" /><br />
                    <asp:Label ID="lblWait1" runat="server" Text=" Please wait... " Font-Bold="true"
                        Font-Size="Large" />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
            <ContentTemplate>
                <div>
                    <asp:Label ID="LabePopupAddError" runat="server" ForeColor="Red" Font-Bold="True"
                        CssClass="ValSummary"></asp:Label>
                </div>
                <br />
                <center>
                    <table width="400">
                        <tr>
                            <td>
                                <asp:Label ID="Label1" Text="Location" CssClass="Labels" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownList1" runat="server" Width="100px" CssClass="Labels">
                                </asp:DropDownList>
                                <asp:Label ID="Label2" Text="" CssClass="Labels" runat="server" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblbunchNo" Text="Bunch No." CssClass="Labels" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbunchNo" runat="server" CssClass="textbox1" />
                                <asp:Label ID="lblerr1" CssClass="ValSummary" runat="server" Text="*" Font-Size="Smaller"
                                    ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label3" Text="No. of Key" CssClass="Labels" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtKeyNo" runat="server" CssClass="textbox1" />
                            </td>
                        </tr>
                        <tr>
                            <td class="style1" valign="top">
                                <asp:Label ID="Label4" Text="Description" CssClass="Labels" runat="server"></asp:Label>
                            </td>
                            <td colspan="4" class="style1">
                                <asp:TextBox ID="txtKeyDesc" runat="server" CssClass="textbox1" Height="50px" TextMode="MultiLine" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblKeyStatus" Text="Status" CssClass="Labels" runat="server" Visible="False"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtKeyStatus" runat="server" CssClass="textbox1" Visible="False">Free</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:Label ID="lblKeySign" runat="server" CssClass="Labels" Text="Key Added By:"
                                    Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblStaffid" Text="NRIC No." CssClass="Labels" runat="server"></asp:Label>
                                 <asp:Label ID="lblerr2" CssClass="ValSummary" runat="server" Text="*" Font-Size="Smaller"
                                    ForeColor="Red"></asp:Label>
                            </td>
                            <td>

                            <telerik:RadComboBox ID="txtStaffiD" runat="server" Width="150" EnableAutomaticLoadOnDemand="true"
                                                        EmptyMessage="Select NRIC No" AutoPostBack="true" Style="z-index: 1000000;" DataSourceID="SqlDataSource1"
                                                        DataTextField="NRICno" DataValueField="NRICno" ItemsPerRequest="10" ShowMoreResultsBox="true" OnSelectedIndexChanged="txtStaffiD_TextChanged"
                                                        EnableVirtualScrolling="true" >
                                                    </telerik:RadComboBox>
                                                    <%-- <asp:DropDownList ID="DropDownList1" runat="server"  DataSourceID="SqlDataSource1" DataTextField="NRICno" DataValueField="NRICno">
                                                    </asp:DropDownList>--%>
                                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:spasecurelatestConnectionString %>"
                                                        SelectCommand="SELECT NRICno from UserInformation"></asp:SqlDataSource>

                               <%-- <asp:TextBox ID="txtStaffiD" runat="server" CssClass="textbox1" AutoPostBack="True"
                                    OnTextChanged="" />--%>
                               
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label5" Text="Name" CssClass="Labels" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtKeyName" runat="server" CssClass="textbox1" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblKeyPosition" Text="Position" CssClass="Labels" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtKeyPosition" runat="server" CssClass="textbox1"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" >
                            <center>
                                <asp:Button ID="ButtonAdd" Text="Add" runat="server" CssClass="Button" OnClick="btnpopupADD_Click"
                                    Width="85px" />
                                <asp:Button ID="ButtonCancel" Text="Cancel" CausesValidation="false" runat="server"
                                    CssClass="Button" OnClick="btnpopupADDClear_Click" Width="85px" />
                            </center>
                            </td>
                        </tr>
                    </table>
                </center>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:HiddenField ID="HiddenFieldUpdate" runat="server" />
    <asp:ModalPopupExtender ID="ModalPopupUpdate" runat="server" TargetControlID="HiddenFieldUpdate"
        CancelControlID="ButtonupdateCancel" BackgroundCssClass="modalBackground" PopupControlID="AdminUpdatepnl">
    </asp:ModalPopupExtender>
    <asp:Panel ID="AdminUpdatepnl" runat="server" BackColor="White" Height="350px" Width="450px"
        BorderWidth="1px" Style="display: none">
        <asp:UpdateProgress ID="UpdateProgress1" DisplayAfter="10" runat="server" AssociatedUpdatePanelID="updCappOperationalPanel">
            <ProgressTemplate>
                <div class="divWaiting" style="margin-top:20px">
                    <asp:Image ID="imgWait3" runat="server" ImageAlign="Middle" ImageUrl="~/img/progress.gif" /><br />
                    <asp:Label ID="lblWait3" runat="server" Text=" Please wait... " Font-Bold="true"
                        Font-Size="Large" />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="updCappOperationalPanel" runat="server">
            <ContentTemplate>
                <center>
                    <div id="divErr" runat="server">
                        <asp:Label ID="lblErrMsgUpdate" CssClass="ValSummary" runat="server" Font-Bold="True"
                            ForeColor="Red"></asp:Label>
                        <asp:HiddenField ID="hdnBTID" runat="server" Value="" />
                        <asp:HiddenField ID="hdnBTName" runat="server" Value="" />
                    </div>
                    <br />
                    <table width="400px">
                        <tr>
                            <td>
                                <asp:Label ID="lblKeyNoUpdate" Text="Key No." CssClass="Labels" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtKeyNoUpdate" runat="server" CssClass="Input" BackColor="#E1E1E1"
                                    ReadOnly="True" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblKeyDescUpdate" Text="Description" CssClass="Labels" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtKeyDescUpdate" runat="server" CssClass="Input" />
                            </td>
                        </tr>
                        <tr>
                            <%--<td><asp:Label ID="lblKeyStatusUpdate" Text="Status" CssClass="Labels" runat="server" 
                                                    Visible="False"></asp:Label></td>
                                            <td><asp:TextBox ID="txtKeyStatusUpdate" runat="server" CssClass="Input" Visible="False" 
                                                    BackColor="#E1E1E1" ReadOnly="True"/></td>--%>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblKeySignUpdate" runat="server" CssClass="Labels" Text="Key Signed In By:"
                                    Font-Bold="True"></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblKeyNRICUpdate" Text="NRIC/FIN No." CssClass="Labels" runat="server"></asp:Label>
                            </td>
                            <td>

                              <telerik:RadComboBox ID="txtKeyNRICUpdate" runat="server" Width="150" EnableAutomaticLoadOnDemand="true"
                                                        EmptyMessage="Select NRIC No" AutoPostBack="true" Style="z-index: 1000000;" DataSourceID="SqlDataSource1"
                                                        DataTextField="NRICno" DataValueField="NRICno" ItemsPerRequest="10" ShowMoreResultsBox="true" OnSelectedIndexChanged="txtStaffiD_TextChangedUpd"
                                                        EnableVirtualScrolling="true" >
                                                    </telerik:RadComboBox>
                                                    <%-- <asp:DropDownList ID="DropDownList1" runat="server"  DataSourceID="SqlDataSource1" DataTextField="NRICno" DataValueField="NRICno">
                                                    </asp:DropDownList>--%>
                                                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:spasecurelatestConnectionString %>"
                                                        SelectCommand="SELECT NRICno from UserInformation"></asp:SqlDataSource>
                                <%--<asp:TextBox ID="" runat="server" CssClass="Input" />--%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblKeyNameUpdate" Text="Name" CssClass="Labels" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtKeyNameUpdate" runat="server" CssClass="Input" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblKeyPositionUpdate" Text="Position" CssClass="Labels" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtKeyPositionUpdate" runat="server" CssClass="Input" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblKeyCountUpdate" Text="Count" CssClass="Labels" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtKeyConntUpdate" runat="server" CssClass="Input" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5">
                                <center>
                                    <asp:Button ID="btnSave" runat="server" Text="Update" CssClass="Button" CausesValidation="false"
                                        OnClick="btnSave_Click" />
                                    &nbsp;&nbsp; &nbsp;
                                    <%--   <asp:Button ID="btnBack" runat="server" Text="View All" CssClass="Button" 
                                    OnClick="btnBackPassAdmin_Click"  />--%>
                                    <asp:Button ID="ButtonupdateCancel" CausesValidation="false" runat="server" Text="Cancel" OnClick="btnpopupADDClear_Click"
                                        CssClass="Button" />
                                </center>
                            </td>
                        </tr>
                    </table>
                </center>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:HiddenField ID="HiddenFieldDelete" runat="server" />
    <asp:ModalPopupExtender ID="ModalPopupDeleteimage" runat="server" TargetControlID="HiddenFieldDelete"
        CancelControlID="btnCancel21" BackgroundCssClass="modalBackground" PopupControlID="paneldeleteimage">
    </asp:ModalPopupExtender>
    <asp:Panel ID="paneldeleteimage" runat="server" BackColor="White" Height="160px"
        Width="350px" BorderWidth="2px" Style="display: none">
        <asp:UpdatePanel ID="UpdatePanel13" runat="server">
            <ContentTemplate>
                <br />
                <center>
             <table width="320px">
                    <tr>
                        <td>
                            <p style="margin-left: 45px; margin-top: 8px; font-size: larger">
                                <asp:Label runat="server" Text="Do you want to delete this record..?" ID="lbldeletemessage"></asp:Label>
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <center>
                                <asp:Button ID="BtnDeleteYes" OnClick="Deletepopup_Yes_Click" CausesValidation="false"
                                    Text="Yes" runat="server" CssClass="Button" Height="30px" Width="100px" />
                                <asp:Button ID="btnCancel21" Text="No" runat="server" CausesValidation="false" OnClick="btnCancelDelete_Click"
                                    CssClass="Button" Style="margin-left: 10px" Height="30px" Width="100px" />
                            </center>
                        </td>
                    </tr>
                </table>
                </center>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
</asp:Content>
