<%@ Page Language="C#" MasterPageFile="~/master/SpaMaster.Master" AutoEventWireup="true"
    CodeBehind="AdminPass.aspx.cs" Inherits="SMS.SuperVisor.AdminPass" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
        </ContentTemplate>
    </asp:UpdatePanel>

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
        <span class="pageTitle">Pass Master</span></div>
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
    <div id="content" runat="server">
        <div id="divAdvSearch" runat="server" visible="true" style="display: none">
            <br />
            <asp:Panel runat="server" ID="Panel1" BackColor="White" Style="margin-left: 1.5em"
                Font-Bold="True" Width="700px ">
                <table width="700px" class="table">
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblPassNumber" Text="Pass No." CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="txtPassNUmber" runat="server" CssClass="Labels">
                            </asp:DropDownList>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblstatus" Text="Pass Status" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlstatus" runat="server" CssClass="Labels">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>Free</asp:ListItem>
                                <asp:ListItem>Reserve</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lbldatefrom" CssClass="Labels" runat="server" Text="Date: From"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtdatefrom" CssClass="Input" runat="server" Height="22px"></asp:TextBox>
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
                        <td align="left">
                            <asp:Label ID="lblPassType" Text="Pass Type" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlAddPassType" runat="server" CssClass="Labels">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td height="25px">
                        </td>
                    </tr>
                    <table width="700" style="margin-left: 0.1em; margin-bottom: -0.4em; border: 1px;
                        border-style: groove; border-color: Black; background: url(../Images/1397d40aa687.jpg)">
                        <tr>
                            <td colspan="4" align="center" width="700px">
                                <asp:Button ID="btnSearchPassAdd" Text="Search" runat="server" CssClass="Buttons"
                                    Width="85px" OnClick="btnSearchPassAdd_Click" />
                                &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnClearPassAdd" Text="Clear" runat="server"
                                    CssClass="Buttons" Width="85px" OnClick="btnClearPassAdd_Click" />
                            </td>
                        </tr>
                    </table>
                </table>
            </asp:Panel>
        </div>
        <div>
            <asp:Label ID="lblerror" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"></asp:Label></div>
      
            <%-- <asp:gridview id="gvPassTable" runat="server" allowpaging="True" allowsorting="True"
                autogeneratecolumns="False" cellpadding="5" width="700px" onrowdatabound="gvPass_RowDataBound"
                onrowcommand="gvPass_RowCommand" onpageindexchanging="gvPass_PageIndexChanging"
                cssclass="GridMain2" 
                   onselectedindexchanged="gvPassTable_SelectedIndexChanged" PageSize="100">            
            <HeaderStyle cssclass="HeaderRow" HorizontalAlign="Center"/>
            <RowStyle cssclass="NormalRow"/>
            <AlternatingRowStyle cssclass="AlternateRow"/>
            <PagerStyle cssclass="PagingRow" horizontalalign="Right" height="20px"/>
            <SelectedRowStyle cssclass="HighlightedRow"/>
            <EmptyDataRowStyle cssclass="NoRecords"/>
            <EmptyDataTemplate>
                <asp:Label ID="lblNoRecords" text="no records in the system." runat="server">
                </asp:Label>               
            </EmptyDataTemplate>
            <Columns>                                        
                    <asp:BoundField datafield="Pass_No" headertext="Pass No."></asp:BoundField>                      
                    <asp:BoundField datafield="Pass_Status" headertext="Status"></asp:BoundField>                    
                    <asp:BoundField datafield="Staff_ID" headertext="NRIC No."></asp:BoundField>
                    <asp:BoundField datafield="Location_id" headertext="Location"></asp:BoundField>
                 <asp:TemplateField HeaderText="Edit/View" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="../Images/Edit.gif" ID="btnEdit" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.Pass_id") %>' CommandName="EditRow" runat="server"/>
                    </ItemTemplate>
                     <HeaderStyle Width="50px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField> 
                 <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="~/Images/Delete.gif" ID="btnDelete" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.Pass_id") %>' CommandName="DeleteRow" runat="server"/>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>               
            </Columns>
       </asp:gridview>--%>
            <asp:Panel ID="Panelgrid" runat="server">
                    <telerik:RadGrid ID="gvPassTable" runat="server" CssClass="RadGrid" GridLines="None"
                        AllowPaging="True" PageSize="50" AllowSorting="True" AutoGenerateColumns="False"
                        HeaderStyle-Font-Size="12px" HeaderStyle-HorizontalAlign="Left" ShowStatusBar="true"
                        Skin="Simple" HeaderStyle-BackColor="#ad1c1c" HeaderStyle-ForeColor="white" EnableAJAX="true"
                        AllowMultiRowSelection="False" AllowFilteringByColumn="true">
                        <GroupingSettings CaseSensitive="false" />
                        <MasterTableView CommandItemDisplay="Bottom" DataKeyNames="Pass_id">
                            <CommandItemSettings ShowAddNewRecordButton="false" ShowRefreshButton="false" />
                            <Columns>
                                <telerik:GridTemplateColumn UniqueName="CheckBoxTemplateColumn" ShowFilterIcon="false"
                                    AllowFiltering="false">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="ToggleRowSelection"
                                            AutoPostBack="True" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn UniqueName="Pass_No" HeaderText="Pass No." DataField="Pass_No"
                                    CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="Pass_Status" HeaderText="Pass Status" DataField="Pass_Status"
                                    CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="Staff_ID" HeaderText="NRIC No." DataField="Staff_ID"
                                    CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="Location_ID" HeaderText="Location Name" DataField="Location_ID"
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
     
        <div class="table" style="display: none">
            <table width="700px" style="margin-left: 0.1em; margin-bottom: -0.4em; border: 1px;
                border-style: groove; border-color: Black; background: url(../Images/1397d40aa687.jpg)">
                <tr>
                    <td colspan="4" align="center" width="700px">
                        <asp:Button ID="btnNewPass" Text="Add New Pass" runat="server" CssClass="Buttons"
                            OnClick="btnNewPass_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <asp:HiddenField ID="HiddenFieldAdd" runat="server" />
    <asp:ModalPopupExtender ID="ModalPopupAdd" runat="server" TargetControlID="HiddenFieldAdd"
        CancelControlID="ButtonCancelAdd" BackgroundCssClass="modalBackground" PopupControlID="AdminADDpnl">
    </asp:ModalPopupExtender>
    <asp:Panel ID="AdminADDpnl" runat="server" BackColor="White" Height="565px" Width="435px"
        BorderWidth="1px" Style="display: none">
        <asp:UpdateProgress ID="UpdateProgress9" DisplayAfter="10" runat="server" AssociatedUpdatePanelID="UpdatePanel6">
            <ProgressTemplate>
                <div class="divWaiting" style="margin-top: 70px">
                    <asp:Image ID="imgWait1" runat="server" ImageAlign="Middle" ImageUrl="~/img/progress.gif" /><br />
                    <asp:Label ID="lblWait1" runat="server" Text=" Please wait... " Font-Bold="true"
                        Font-Size="Large" />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
            <ContentTemplate>
                <div>
                    <asp:Label ID="LblErrorAdd" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"></asp:Label>
                </div>
                <br />
                <center>
                    <table width="400px">
                        <tr>
                            <td>
                                <asp:Label ID="lblEnterPassNumber" Text="Pass No." CssClass="Labels" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtAddNoType" runat="server" CssClass="Input" />
                                <asp:Label ID="lblerr1" CssClass="ValSummary" runat="server" Text="*" Font-Size="Smaller"
                                    ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblLocation" Text="Location" CssClass="Labels" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddllocation" runat="server" CssClass="Labels">
                                </asp:DropDownList>
                                <asp:Label ID="SearchLocID" runat="server" Visible="False" CssClass="Input"></asp:Label>
                            </td>
                        </tr>
                        
                        <tr>
                            <td>
                                <asp:Label ID="lblAddPassType" runat="server" CssClass="Labels" Text="Add Pass Type" />
                            </td>
                            <td>
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtAddPassType" runat="server" CssClass="Input" Width="118px" />
                                            <asp:Label ID="lblerr3" CssClass="ValSummary" runat="server" Text="*" Font-Size="Smaller"
                                                ForeColor="Red"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnAdd1" Text="+" runat="server" CssClass="Button" OnClick="btnAdd1_Click"
                                                Width="40px" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <asp:Label ID="lblEnterPass" Text="Pass Type" CssClass="Labels" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlpasstypeAdd" runat="server" CssClass="Labels" Width="118px">
                                </asp:DropDownList>
                                <asp:Label ID="lblerr5" CssClass="ValSummary" runat="server" Text="*" Font-Size="Smaller"
                                    ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" Text="Pass Description" CssClass="Labels" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPassDecription" runat="server" CssClass="Input" TextMode="Multiline"
                                    Height="73px" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtstatus" runat="server" CssClass="Input" Visible="False" Width="45px">Free</asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="border: none">
                                <asp:UpdatePanel ID="updPerson" runat="server">
                                    <ContentTemplate>
                                        <table width="100%">
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Label ID="lblKeySign" runat="server" CssClass="Labels" Text="Pass Generated By:"
                                                        Font-Bold="True"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblKeyNRIC" Text="NRIC No." CssClass="Labels" runat="server"></asp:Label>
                                                    <asp:Label ID="lblerr2" CssClass="ValSummary" runat="server" Text="*" Font-Size="Smaller"
                                                        ForeColor="Red"></asp:Label>
                                                </td>
                                                <td>
                                                    <telerik:RadComboBox ID="txtKeyNRIC" runat="server" Width="150" EnableAutomaticLoadOnDemand="true"
                                                        EmptyMessage="Select NRIC No" AutoPostBack="true" Style="z-index: 1000000;" DataSourceID="SqlDataSource1"
                                                        DataTextField="NRICno" DataValueField="NRICno" ItemsPerRequest="10" ShowMoreResultsBox="true"
                                                        EnableVirtualScrolling="true" OnSelectedIndexChanged="txtKeyNRIC_TextChanged">
                                                    </telerik:RadComboBox>
                                                    <%-- <asp:DropDownList ID="DropDownList1" runat="server"  DataSourceID="SqlDataSource1" DataTextField="NRICno" DataValueField="NRICno">
                                                    </asp:DropDownList>--%>
                                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:spasecurelatestConnectionString %>"
                                                        SelectCommand="SELECT NRICno from UserInformation"></asp:SqlDataSource>
                                                </td>
                                                <td>
                                                    <%--<asp:TextBox ID="txtKeyNRIC" runat="server" AutoPostBack="True" CssClass="Input"
                                                        OnTextChangaed="txtKeyNRIC_TextChanged">
                                                    </asp:TextBox>--%>
                                                    
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblKeyName" Text="Name" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtKeyName" runat="server" CssClass="Input" ReadOnly="True" Width="285px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblposition" Text="Position" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtposition" runat="server" CssClass="Input" ReadOnly="True" />
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                           <td colspan="2">
                            <center>
                                <asp:Button ID="Button1" Text="Add" runat="server" CssClass="Button" Width="85px"
                                    OnClick="btnSearchPassAddpop_Click" />
                                <asp:Button ID="ButtonCancelAdd" Text="Cancel" runat="server" CssClass="Button" Width="85px"
                                    OnClick="btnClearPassAddpop_Click" />
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
        CancelControlID="btnUpdateCancel" BackgroundCssClass="modalBackground" PopupControlID="AdminUpdatepnl">
    </asp:ModalPopupExtender>
    <asp:Panel ID="AdminUpdatepnl" runat="server" BackColor="White" 
        Height="255px" Width="450px" BorderWidth="1px" Style="display: none">
        <asp:UpdateProgress ID="UpdateProgress1" DisplayAfter="10" runat="server" AssociatedUpdatePanelID="updCappOperationalPanel">
            <ProgressTemplate>
                <div class="divWaiting" style="margin-top: 30px">
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
                        <asp:Label ID="lblErrMsg" CssClass="ValSummary" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                        <asp:HiddenField ID="hdnBTID" runat="server" Value="" />
                        <asp:HiddenField ID="hdnBTName" runat="server" Value="" />
                        <asp:TextBox ID="txtpass_id" runat="server" Visible="False"></asp:TextBox>
                    </div>
                    <br />
                    <table width="400px">
                        <tr>
                            <td>
                                <asp:Label ID="lblPassNo" Text="Pass No." CssClass="Labels" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtUpdatePassNo" runat="server" CssClass="Input" ReadOnly="True"
                                    BackColor="#E2E2E2" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label6" Text="Pass Type" CssClass="Labels" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlpasstypeupdate" runat="server" CssClass="Input" Width="136px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblPassDescription" Text="Description" CssClass="Labels" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtUpdatePassDescription" runat="server" CssClass="Input" Height="65px"
                                    Width="76%" TextMode="MultiLine" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                            <center>
                                <asp:Button ID="btnSave" runat="server" Text="Update" CssClass="Button" OnClick="btnSave_Click" CausesValidation="false" />
                                <asp:Button ID="btnUpdateCancel" runat="server" Text="Cancel" CssClass="Button" OnClick="btnBackPassAdmin_Click" />
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
                            <td colspan="2">
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
