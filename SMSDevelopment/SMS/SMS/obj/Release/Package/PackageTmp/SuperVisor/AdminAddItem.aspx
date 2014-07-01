<%@ Page Language="C#" MasterPageFile="~/master/SpaMaster.Master" AutoEventWireup="true"
    CodeBehind="AdminAddItem.aspx.cs" Inherits="SMS.SuperVisor.AdminAddItem" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <ajaxsettings>
            <telerik:AjaxSetting AjaxControlID="Panelgrid">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Panelgrid" LoadingPanelID="RadAjaxLoadingPanel2">
                    </telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="Label398"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </ajaxsettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel2" Skin="Sunset" runat="server">
    </telerik:RadAjaxLoadingPanel>
    <div class="divHeader">
        <span class="pageTitle">Item Manager</span></div>
    <div class="btnbar">
        <div class="btnbarBox">
            <ul>
                <li>
                    <asp:LinkButton ID="imdAdd" runat="server" CausesValidation="false" OnClick="imdAdd_Click">
                        <span id="SpanAdd1" runat="server" class="iconAdd" style="line-height: 120px;">
                            <asp:Label ID="SpanAdd" runat="server" Text="Check Out"></asp:Label>
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
    <ul id="tabs" class="ui-tabs ui-widget ui-widget-content ui-corner-all" style="display: none">
        <li id="ViewItem" runat="server">
            <asp:LinkButton ID="lnkViewItem" runat="server" CausesValidation="false" OnClick="lnkViewItem_Click">
                <span class="icon1" id="SpanPart" runat="server">View Item</span>
            </asp:LinkButton></li>
        <li id="CheckOutItem" runat="server">
            <asp:LinkButton ID="lnkCheckOutItem" runat="server" CausesValidation="false" OnClick="lnkCheckOutItem_Click">
                <span class="icon2" id="SpanOperation" runat="server">Check Out Item </span>
            </asp:LinkButton></li>
    </ul>
    <div id="content" runat="server">
        <div id="divAdvSearch" runat="server" visible="true" style="display: none">
            <br />
            <asp:Panel runat="server" ID="Panel1" BackColor="White" Style="margin-left: 1.5em"
                Font-Bold="True" Width="700px">
                <table width="700px" class="table">
                    <tr>
                        <td style="height: 3">
                            <asp:Label ID="lblItemName" Text="Item Name" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td style="height: 3">
                            <asp:TextBox ID="txtItemName" runat="server" CssClass="Input" />
                        </td>
                        <td style="height: 3">
                            <asp:Label ID="lblModel" Text="Model No." CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td style="height: 3">
                            <asp:TextBox ID="txtModel" runat="server" CssClass="Input" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 3">
                            <asp:Label ID="lblIssedTo" Text="Issued To" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td style="height: 3">
                            <asp:TextBox ID="txtIssuedTo" runat="server" CssClass="Input" />
                        </td>
                        <td style="height: 3">
                            <asp:Label ID="lblIssedBy" Text="Issued By" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td style="height: 3">
                            <asp:TextBox ID="txtIssuedBy" runat="server" CssClass="Input" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 3">
                            <asp:Label ID="lbldatefrom" CssClass="Labels" runat="server" Text="Date:  From"></asp:Label>
                        </td>
                        <td style="height: 3">
                            <asp:TextBox ID="txtdatefrom" CssClass="Input" runat="server"></asp:TextBox>
                            <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                                Format="MM/dd/yyyy" TargetControlID="txtdatefrom" PopupButtonID="imgBtnFromDate2" />
                            <asp:ImageButton ID="imgBtnFromDate2" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"
                                class="calender" />
                        </td>
                        <td style="height: 3">
                            <asp:Label ID="lbldateto" CssClass="Labels" runat="server" Text="To"></asp:Label>
                        </td>
                        <td style="height: 3">
                            <asp:TextBox ID="txtdateto" CssClass="Input" runat="server"></asp:TextBox>
                            <AJAX:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="AjaxCalendar"
                                Format="MM/dd/yyyy" TargetControlID="txtdateto" PopupButtonID="imgBtnFromDate3" />
                            <asp:ImageButton ID="imgBtnFromDate3" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"
                                class="calender" />
                        </td>
                    </tr>
                    <tr>
                        <td height="20">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:Button ID="btnSearchKeyAdd" Text="Search" runat="server" CssClass="Buttons"
                                Width="85px" OnClick="btnSearchKeyAdd_Click1" />&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnClearKeyAdd" Text="Clear" runat="server" CssClass="Buttons" Width="85px"
                                OnClick="btnClearKeyAdd_Click1" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
        <div>
            <asp:Label ID="lblerror" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"></asp:Label></div>
        <div>
            <%-- <asp:GridView ID="gvKeySearch" runat="server" 
            AllowPaging="True" AllowSorting="True" 
            AutoGenerateColumns="False" CellPadding="5" Width="700px"
            OnRowDataBound="gvNewKey_RowDataBound" 
            OnRowCommand="gvNewKey_RowCommand" 
            OnPageIndexChanging="gvNewKey_PageIndexChanging" CssClass="GridMain2" 
            onselectedindexchanged="gvNewKey_SelectedIndexChanged" PageSize="100">            
            <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center"/>
            <RowStyle CssClass="NormalRow"/>
            <AlternatingRowStyle CssClass="AlternateRow"/>
            <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="20px"/>
            <SelectedRowStyle CssClass="HighlightedRow"/>
            <EmptyDataRowStyle CssClass="NoRecords"/>
            <EmptyDataTemplate>
                <asp:Label ID="lblNoRecords" Text="no record(s) in the system." runat="server">
                </asp:Label>               
            </EmptyDataTemplate>
            <Columns>
                    <asp:BoundField DataField="Item_Name" HeaderText="Item Name"></asp:BoundField>
                    <asp:BoundField DataField="Model_No" HeaderText="Model No"></asp:BoundField>
                    <asp:BoundField DataField="Item_quantity" HeaderText="Item Qty."></asp:BoundField>
                    <asp:BoundField DataField="IssuedTo_Name" HeaderText="Issued To"></asp:BoundField>
                    <asp:BoundField DataField="IssuedBy_Name" HeaderText="Issued By"></asp:BoundField>
                    <asp:BoundField DataField="IssuedBy_Time" HeaderText="Time"></asp:BoundField>
                 <asp:TemplateField HeaderText="Check In Item" ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="../Images/Edit.gif" ID="btnEdit" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.AddItem_ID") %>' CommandName="EditRow" runat="server"/>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="70px"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="~/Images/Delete.gif" ID="btnDelete" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.AddItem_ID") %>' CommandName="DeleteRow" runat="server"/>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>                 
            </Columns>
    </asp:GridView>--%>
            <asp:Panel ID="Panelgrid" runat="server">
                <telerik:RadGrid ID="gvKeySearch" runat="server" CssClass="RadGrid" GridLines="None"
                    AllowPaging="True" PageSize="50" AllowSorting="True" AutoGenerateColumns="False"
                    HeaderStyle-Font-Size="12px" HeaderStyle-HorizontalAlign="Left" ShowStatusBar="true"
                    Skin="Simple" HeaderStyle-BackColor="#ad1c1c" HeaderStyle-ForeColor="white" EnableAJAX="true"
                    AllowMultiRowSelection="False" AllowFilteringByColumn="true">
                    <groupingsettings casesensitive="false" />
                    <mastertableview commanditemdisplay="Bottom" datakeynames="AddItem_ID">
                        <CommandItemSettings ShowAddNewRecordButton="false" ShowRefreshButton="false" />
                        <Columns>
                            <telerik:GridTemplateColumn UniqueName="CheckBoxTemplateColumn" ShowFilterIcon="false"
                                AllowFiltering="false">
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="ToggleRowSelection"
                                        AutoPostBack="True" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn UniqueName="Item_Name" HeaderText="Item Name" DataField="Item_Name"
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="Model_No" HeaderText="Model No" DataField="Model_No"
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="Item_quantity" HeaderText="Item quantity" DataField="Item_quantity"
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="IssuedTo_Name" HeaderText="Issued To" DataField="IssuedTo_Name"
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="IssuedBy_Name" HeaderText="Issued By" DataField="IssuedBy_Name"
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="IssuedBy_Time" HeaderText="Time" DataField="IssuedBy_Time"
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                        </Columns>
                    </mastertableview>
                    <%-- <ClientSettings Selecting-AllowRowSelect="true" ReorderColumnsOnClient="True" AllowDragToGroup="True"
                                        AllowColumnsReorder="True">
                                        <Selecting AllowRowSelect="True" />
                                    </ClientSettings>--%>
                    <selecteditemstyle borderwidth="0px" font-bold="true" forecolor="White" backcolor="Red" />
                </telerik:RadGrid>
            </asp:Panel>
        </div>
        <div class="table" style="display: none">
            <table>
                <tr>
                    <td colspan="4">
                        <center>
                            <asp:Button ID="btnNewBTable" Text="New Check Out Item" runat="server" CssClass="Buttons"
                                OnClick="btnNewBTable_Click" />
                        </center>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <asp:HiddenField ID="HiddenFieldAdd" runat="server" />
    <asp:ModalPopupExtender ID="ModalPopupAdd" runat="server" TargetControlID="HiddenFieldAdd"
        CancelControlID="btnClearItemAdd" BackgroundCssClass="modalBackground" PopupControlID="AdminADDpnl">
    </asp:ModalPopupExtender>
    <asp:Panel ID="AdminADDpnl" runat="server" BackColor="White" Height="590px" Width="450px" ScrollBars="Vertical"
        BorderWidth="1px" Style="display: none">
        <asp:UpdateProgress ID="UpdateProgress1" DisplayAfter="10" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
            <ProgressTemplate>
                <div class="divWaiting" style="margin-top:50px">
                    <asp:Image ID="imgWait1g" runat="server" ImageAlign="Middle" ImageUrl="~/img/progress.gif" /><br />
                    <asp:Label ID="lblWait1g" runat="server" Text=" Please wait... " Font-Bold="true"
                        Font-Size="Large" />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div>
                    <asp:Label ID="lblerroradd" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"></asp:Label>
                </div>
                <br />
                <center>
                    <table width="400px">
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="lblItem" Text=" " CssClass="Labels" runat="server" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" Text="Item Name" CssClass="Labels" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtitemnameadd" runat="server" CssClass="Input" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label3" Text="Model No." CssClass="Labels" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtmodelnoadd" runat="server" CssClass="Input" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label4" Text="Item Description" CssClass="Labels" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtitemdescadd" runat="server" CssClass="Input" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label5" Text="Item Quantity" CssClass="Labels" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtitemqtyadd" runat="server" CssClass="Input" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="Label6" Text="Issued To :" CssClass="Labels" runat="server" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label7" Text="NRIC/FIN No." CssClass="Labels" runat="server"></asp:Label>
                                <asp:Label ID="lblerr1add" CssClass="ValSummary" runat="server" Text="*" Font-Size="Smaller"
                                    ForeColor="Red"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadComboBox ID="txtnricaddto" runat="server" Width="150" EnableAutomaticLoadOnDemand="true"
                                    EmptyMessage="Select NRIC No" AutoPostBack="true" Style="z-index: 1000000;" DataSourceID="SqlDataSource1"
                                    DataTextField="NRICno" DataValueField="NRICno" ItemsPerRequest="10" ShowMoreResultsBox="true"
                                    OnSelectedIndexChanged="txtIssuedToNRIC_TextChanged" EnableVirtualScrolling="true">
                                </telerik:RadComboBox>
                                <%-- <asp:DropDownList ID="DropDownList1" runat="server"  DataSourceID="SqlDataSource1" DataTextField="NRICno" DataValueField="NRICno">
                                                    </asp:DropDownList>--%>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:spasecurelatestConnectionString %>"
                                    SelectCommand="SELECT NRICno from UserInformation"></asp:SqlDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label8" Text="Name" CssClass="Labels" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtnameaddto" runat="server" CssClass="Input" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label9" Text="Position" CssClass="Labels" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtpositionaddto" runat="server" CssClass="Input" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="Label10" Text="Issued By:" CssClass="Labels" runat="server" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label11" Text="NRIC/FIN No." CssClass="Labels" runat="server"></asp:Label>
                                 
                                <asp:Label ID="Label12" CssClass="ValSummary" runat="server" Text="*" Font-Size="Smaller"
                                    ForeColor="Red"></asp:Label>
                            </td>
                            <td>
                             <telerik:RadComboBox ID="txtnricaddby" runat="server" Width="150" EnableAutomaticLoadOnDemand="true"
                                    EmptyMessage="Select NRIC No" AutoPostBack="true" Style="z-index: 1000000;" DataSourceID="SqlDataSource1"
                                    DataTextField="NRICno" DataValueField="NRICno" ItemsPerRequest="10" ShowMoreResultsBox="true"
                                    OnSelectedIndexChanged="txtIssuedByNRIC_TextChanged" EnableVirtualScrolling="true">
                                </telerik:RadComboBox>
                                <%-- <asp:DropDownList ID="DropDownList1" runat="server"  DataSourceID="SqlDataSource1" DataTextField="NRICno" DataValueField="NRICno">
                                                    </asp:DropDownList>--%>
                               
                              
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label13" Text="Name" CssClass="Labels" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtnameaddby" runat="server" CssClass="Input" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label14" Text="Position" CssClass="Labels" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtpositionaddby" runat="server" CssClass="Input" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label15" Text="Comments" CssClass="Labels" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtcommentaddby" runat="server" CssClass="Input" Height="45px" TextMode="MultiLine" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <center>
                                    <asp:Button ID="btnItemAdd" runat="server" CssClass="Button" Text="Save" Width="85px"
                                        OnClick="btnItemAdd_Click" />
                                    <asp:Button ID="btnClearItemAdd" runat="server" CssClass="Button" Text="Cancel" Width="85px"
                                        OnClick="btnItemCancel_Click" />
                                </center>
                            </td>
                        </tr>
                    </table>
                </center>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:HiddenField ID="HiddenFieldupdate" runat="server" />
    <asp:ModalPopupExtender ID="ModalPopupupdate" runat="server" TargetControlID="HiddenFieldupdate"
        CancelControlID="btnCancel" BackgroundCssClass="modalBackground" PopupControlID="AdminUpdatepnl">
    </asp:ModalPopupExtender>
    <asp:Panel ID="AdminUpdatepnl" runat="server" BackColor="White" ScrollBars="Vertical"
        Height="550px" Width="550px" BorderWidth="1px" Style="display: none">
        <asp:UpdateProgress ID="UpdateProgress9" DisplayAfter="10" runat="server" AssociatedUpdatePanelID="UpdatePanel6">
            <ProgressTemplate>
                <div class="divWaiting" style="margin-top:50px">
                    <asp:Image ID="imgWait1" runat="server" ImageAlign="Middle" ImageUrl="~/img/progress.gif" /><br />
                    <asp:Label ID="lblWait1" runat="server" Text=" Please wait... " Font-Bold="true"
                        Font-Size="Large" />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div id="divErr" runat="server">
                    <asp:Label ID="lblErrMsg" CssClass="ValSummary" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                    <asp:HiddenField ID="hdnBTID" runat="server" Value="" />
                    <asp:HiddenField ID="hdnBTName" runat="server" Value="" />
                </div>
                <br />
                <center>
                    <table width="500px">
                        <tr>
                            <td>
                                <asp:Label ID="lblItemID" Text="Item ID " CssClass="Labels" runat="server" Visible="False"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtItemID" runat="server" CssClass="Input" ReadOnly="True" Visible="False" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" Text="Item Name" CssClass="Labels" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtItemNameUpdate" runat="server" CssClass="Input" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblModelNo" Text="Model No." CssClass="Labels" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtModelNo" runat="server" CssClass="Input" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblItemDescription" Text="Item Description" CssClass="Labels" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtItemdescription" runat="server" CssClass="Input" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblItemquantity" Text="Item Quantity" CssClass="Labels" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtItemquantity" runat="server" CssClass="Input" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="lblIssuedTo" Text="Issued To :" CssClass="Labels" runat="server" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblIssuedToNRIC" Text="NRIC/FIN No." CssClass="Labels" runat="server"></asp:Label>
                                 <asp:Label ID="lblerr1" CssClass="ValSummary" runat="server" Text="*" Font-Size="Smaller"
                                    ForeColor="Red"></asp:Label>
                            </td>
                            <td>

                             <telerik:RadComboBox ID="txtIssuedToNRIC" runat="server" Width="150" EnableAutomaticLoadOnDemand="true"
                                    EmptyMessage="Select NRIC No" AutoPostBack="true" Style="z-index: 1000000;" DataSourceID="SqlDataSource1"
                                    DataTextField="NRICno" DataValueField="NRICno" ItemsPerRequest="10" ShowMoreResultsBox="true"
                                    OnSelectedIndexChanged="txtIssuedToNRICUp_TextChanged" EnableVirtualScrolling="true">
                                </telerik:RadComboBox>
                                
                               
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblIssuedToName" Text="Name" CssClass="Labels" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtIssuedToName" runat="server" CssClass="Input" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblIssuedToPosition" Text="Position" CssClass="Labels" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtIssuedToPosition" runat="server" CssClass="Input" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="lblIssuedBy" Text="Issued By:" CssClass="Labels" runat="server" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblIssuedByNRIC" Text="NRIC/FIN No." CssClass="Labels" runat="server"></asp:Label>
                                 <asp:Label ID="errorIssuedByNRIC" CssClass="ValSummary" runat="server" Text="*" Font-Size="Smaller"
                                    ForeColor="Red"></asp:Label>
                            </td>
                            <td>
                             <telerik:RadComboBox ID="txtIssuedByNRIC" runat="server" Width="150" EnableAutomaticLoadOnDemand="true"
                                    EmptyMessage="Select NRIC No" AutoPostBack="true" Style="z-index: 1000000;" DataSourceID="SqlDataSource1"
                                    DataTextField="NRICno" DataValueField="NRICno" ItemsPerRequest="10" ShowMoreResultsBox="true"
                                    OnSelectedIndexChanged="txtIssuedByNRICUp_TextChanged" EnableVirtualScrolling="true">
                                </telerik:RadComboBox>
                               
                               
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblIssuedByName" Text="Name" CssClass="Labels" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtIssuedByName" runat="server" CssClass="Input" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblIssuedByPosition" Text="Position" CssClass="Labels" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtIssuedByPosition" runat="server" CssClass="Input" />
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Label ID="lblComment" Text="Comments" CssClass="Labels" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtComment" runat="server" CssClass="Input" Height="55px" TextMode="MultiLine" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblStatus" Text="Status" CssClass="Labels" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="Input">
                                    <asp:ListItem>Issued</asp:ListItem>
                                    <asp:ListItem>Receive</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <center>
                                    <asp:Button ID="btnsave" runat="server" CssClass="Button" Text="Update" Width="85px"
                                        OnClick="btnsave_Click" />
                                    <asp:Button ID="btnCancel" runat="server" CssClass="Button" CausesValidation="false"
                                        Text="Cancel" Width="85px" OnClick="btnClear_Click" />
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
