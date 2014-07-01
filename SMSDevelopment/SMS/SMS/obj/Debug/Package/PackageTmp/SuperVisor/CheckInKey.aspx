<%@ Page Language="C#" MasterPageFile="~/master/SpaMaster.Master" AutoEventWireup="true"
    CodeBehind="CheckInKey.aspx.cs" Inherits="SMS.SuperVisor.CheckInKey" Title="Check In Key" %>

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
            <span>CheckIn Key</span>
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
                    <asp:LinkButton ID="imgUpdate" Visible="false" runat="server" CausesValidation="false" OnClick="imgUpdate_Click">
                        <span id="SpanUpdate1" runat="server" class="iconUpdate" style="line-height: 120px;">
                            <asp:Label ID="SpanUpdate" runat="server"  Text="Edit"></asp:Label>
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
        <li id="CheckInKey1" runat="server">
            <asp:LinkButton ID="lnkCheckInKey" runat="server" CausesValidation="false" OnClick="lnkCheckInKey_Click">
                <span class="icon2" id="SpanOperation" runat="server">Check In Key </span>
            </asp:LinkButton></li>
    </ul>
    <div id="content" runat="server">
        <div>
            <%-- <asp:GridView ID="gvKeySearch" runat="server" 
            AllowPaging="True" AllowSorting="True" 
            AutoGenerateColumns="False" CellPadding="5" Width="750px"
            OnRowDataBound="gvNewKey_RowDataBound" onrowcommand="gvNewKey_RowCommand"
           
            OnPageIndexChanging="gvNewKey_PageIndexChanging" CssClass="GridMain2" 
            onselectedindexchanged="gvNewKey_SelectedIndexChanged" PageSize="20">
            
            <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center"/>
            <RowStyle CssClass="NormalRow"/>
            <AlternatingRowStyle CssClass="AlternateRow"/>
            <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="20px"/>
            <SelectedRowStyle CssClass="HighlightedRow"/>
            <EmptyDataRowStyle CssClass="NoRecords"/>
            <EmptyDataTemplate>
                <asp:Label ID="lblNoRecords" Text="Your search did not match any Key or, there may be no records in the system." runat="server">
                </asp:Label>
                <p>Suggestions:</p>                    
                <li>Try different keywords.</li>
                <li>Try fewer keywords.</li>
                <li>Make sure all words are spelled correctly.</li>
                <li>There may be no records in the system.</li>
                
            </EmptyDataTemplate>
            

            <Columns>
            
                   <asp:BoundField DataField="Fromdate" HeaderText="Check In Time"></asp:BoundField> 
                    <asp:BoundField DataField="Name" HeaderText="Name"></asp:BoundField>
                    <asp:BoundField DataField="BunchNo" HeaderText="Bunch No."></asp:BoundField>
                    <asp:BoundField DataField="NoOfKey" HeaderText="No.of Key"></asp:BoundField>
                  
                 <asp:TemplateField HeaderText="Check Out" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="~/Images/Delete.gif" ID="btnDelete" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.Chkinkey_id") %>' CommandName="DeleteRow" runat="server"/>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="100px"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField> 
                
            </Columns>
    </asp:GridView>
            --%>
            <%-- 
       <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
            <ContentTemplate>--%>
            <asp:Panel ID="Panelgrid" runat="server">
                <telerik:RadGrid ID="gvKeySearch" runat="server" CssClass="RadGrid" GridLines="None"
                    AllowPaging="True" PageSize="50" AllowSorting="True" AutoGenerateColumns="False"
                    HeaderStyle-Font-Size="12px" HeaderStyle-HorizontalAlign="Left" ShowStatusBar="true"
                    Skin="Simple" HeaderStyle-BackColor="#ad1c1c" HeaderStyle-ForeColor="white" EnableAJAX="true"
                    AllowMultiRowSelection="False" AllowFilteringByColumn="true">
                    <GroupingSettings CaseSensitive="false" />
                    <MasterTableView CommandItemDisplay="Bottom" DataKeyNames="Chkinkey_id">
                        <CommandItemSettings ShowAddNewRecordButton="false" ShowRefreshButton="false" />
                        <Columns>
                            <telerik:GridTemplateColumn UniqueName="CheckBoxTemplateColumn" ShowFilterIcon="false"
                                AllowFiltering="false">
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="ToggleRowSelection"
                                        AutoPostBack="True" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn UniqueName="Fromdate" HeaderText="Check In Time" DataField="Fromdate"
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="Name" HeaderText="Name" DataField="Name" CurrentFilterFunction="Contains"
                                AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="BunchNo" HeaderText="Bunch No." DataField="BunchNo"
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="NoOfKey" HeaderText="No.of Key" DataField="NoOfKey"
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
                <%--
  </ContentTemplate>
        </asp:UpdatePanel>--%>
            </asp:Panel>
        </div>
    </div>
    <asp:HiddenField ID="HiddenFieldAdd" runat="server" />
    <asp:ModalPopupExtender ID="ModalPopupAdd" runat="server" TargetControlID="HiddenFieldAdd"
        CancelControlID="btnClearKeyAdd" BackgroundCssClass="modalBackground" PopupControlID="AdminADDpnl">
    </asp:ModalPopupExtender>
    <asp:Panel ID="AdminADDpnl" runat="server" BackColor="White" Height="300px" Width="450px"
        BorderWidth="1px" Style="display: none">
        <asp:UpdateProgress ID="UpdateProgress9" DisplayAfter="10" runat="server" AssociatedUpdatePanelID="UpdatePanel6">
            <ProgressTemplate>
                <div class="divWaiting" style="margin-top: 400px">
                    <asp:Image ID="imgWait1" runat="server" ImageAlign="Middle" ImageUrl="~/img/progress.gif" /><br />
                    <asp:Label ID="lblWait1" runat="server" Text=" Please wait... " Font-Bold="true"
                        Font-Size="Large" />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div>
                    <asp:Label ID="lblerror" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"></asp:Label></div>
                <br />
                <center>
                    <table width="400px">
                        <tr>
                            <td>
                                <asp:Label ID="lblname" Text="Name" CssClass="Labels" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtname" runat="server" CssClass="Input" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lbldesignation" Text="Designation" CssClass="Labels" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtdesignation" runat="server" CssClass="Input1"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblKeyNRIC" Text="NRIC No." CssClass="Labels" runat="server"></asp:Label>
                            </td>
                            <td>
                                   <telerik:RadComboBox ID="txtKeyNRIC" runat="server" Width="150" EnableAutomaticLoadOnDemand="true"
                                                        EmptyMessage="Select NRIC No" AutoPostBack="true" Style="z-index: 1000000;" DataSourceID="SqlDataSource1"
                                                        DataTextField="NRICno" DataValueField="NRICno" ItemsPerRequest="10" ShowMoreResultsBox="true" OnSelectedIndexChanged="txtStaffiD_TextChanged"
                                                        EnableVirtualScrolling="true" >
                                                    </telerik:RadComboBox>
                                                    <%-- <asp:DropDownList ID="DropDownList1" runat="server"  DataSourceID="SqlDataSource1" DataTextField="NRICno" DataValueField="NRICno">
                                                    </asp:DropDownList>--%>
                                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:spasecurelatestConnectionString %>"
                                                        SelectCommand="SELECT NRICno from UserInformation"></asp:SqlDataSource>



                               <%-- <asp:TextBox ID="txtKeyNRIC" runat="server" CssClass="Input" />--%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblphone" Text="Contact No." CssClass="Labels" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtphone" runat="server" CssClass="Input1" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblbunchno" Text="Bunch No." CssClass="Labels" runat="server"></asp:Label>
                            </td>
                            <td colspan="3">
                                <asp:DropDownList ID="ddlbunchno" runat="server" CssClass="Labels">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                            <center>
                                <asp:Button ID="btnSearchKeyAdd" Text="Check In Key" runat="server" CssClass="Button"
                                    Width="146px" OnClick="btnSearchKeyAdd_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnClearKeyAdd" Text="Cancel" runat="server" CssClass="Button" Width="100px"
                                    OnClick="btnClearKeyAdd_Click" />
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
