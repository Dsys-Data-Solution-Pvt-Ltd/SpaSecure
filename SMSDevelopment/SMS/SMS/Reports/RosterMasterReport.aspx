<%@ Page Title="" Language="C#" MasterPageFile="~/master/SpaMaster.Master" AutoEventWireup="true"
    CodeBehind="RosterMasterReport.aspx.cs" Inherits="SMS.Reports.RosterMasterReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="panelgrid1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="panelgrid1" LoadingPanelID="RadAjaxLoadingPanel2">
                    </telerik:AjaxUpdatedControl>
                  
                    <telerik:AjaxUpdatedControl ControlID="Label398"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel2" Skin="Sunset" runat="server">
    </telerik:RadAjaxLoadingPanel>
    <div class="divHeader">
        <span class="pageTitle">Roster Detail Report</span>
    </div>
    <table width="100%">
        <tr>
            <td>
                <asp:Label ID="Label31" runat="server" Text="StaffID"></asp:Label>
            </td>
            <td>
                <telerik:RadComboBox ID="ddlStaffiD" runat="server" Width="150" EnableAutomaticLoadOnDemand="true"
                    EmptyMessage="Select StaffID" Style="z-index: 1000000;" DataSourceID="SqlDataSource1"
                    DataTextField="Staff_ID" DataValueField="Staff_ID" ItemsPerRequest="10" ShowMoreResultsBox="true"
                    EnableVirtualScrolling="true">
                </telerik:RadComboBox>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:spasecurelatestConnectionString %>"
                    SelectCommand="SELECT Staff_ID from UserInformation"></asp:SqlDataSource>
            </td>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Location"></asp:Label>
            </td>
            <td>
                <telerik:RadComboBox ID="ddlLocation" runat="server" Width="150" EnableAutomaticLoadOnDemand="true"
                    EmptyMessage="Select Location" Style="z-index: 1000000;" DataSourceID="SqlDataSource2"
                    DataTextField="Location_name" DataValueField="Location_id" ItemsPerRequest="10"
                    ShowMoreResultsBox="true" EnableVirtualScrolling="true">
                </telerik:RadComboBox>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:spasecurelatestConnectionString %>"
                    SelectCommand="SELECT Location_id,Location_name from location"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Month"></asp:Label>
            </td>
            <td>
                <telerik:RadComboBox ID="ddlMonth" runat="server" Width="150" EnableAutomaticLoadOnDemand="true"
                    EmptyMessage="Select Month" Style="z-index: 1000000;" ItemsPerRequest="10" ShowMoreResultsBox="true"
                    EnableVirtualScrolling="true">
                    <Items>
                        <telerik:RadComboBoxItem Value="1" Text="JAN"></telerik:RadComboBoxItem>
                        <telerik:RadComboBoxItem Value="2" Text="FEB"></telerik:RadComboBoxItem>
                        <telerik:RadComboBoxItem Value="3" Text="MAR"></telerik:RadComboBoxItem>
                        <telerik:RadComboBoxItem Value="4" Text="APR"></telerik:RadComboBoxItem>
                        <telerik:RadComboBoxItem Value="5" Text="MAY"></telerik:RadComboBoxItem>
                        <telerik:RadComboBoxItem Value="6" Text="JUN"></telerik:RadComboBoxItem>
                        <telerik:RadComboBoxItem Value="7" Text="JULY"></telerik:RadComboBoxItem>
                        <telerik:RadComboBoxItem Value="8" Text="AUG"></telerik:RadComboBoxItem>
                        <telerik:RadComboBoxItem Value="9" Text="SEP"></telerik:RadComboBoxItem>
                        <telerik:RadComboBoxItem Value="10" Text="OCT"></telerik:RadComboBoxItem>
                        <telerik:RadComboBoxItem Value="11" Text="NOV"></telerik:RadComboBoxItem>
                        <telerik:RadComboBoxItem Value="12" Text="DEC"></telerik:RadComboBoxItem>
                    </Items>
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Year"></asp:Label>
            </td>
            <td>
                <telerik:RadComboBox ID="ddlYear" runat="server" Width="150" EnableAutomaticLoadOnDemand="true"
                    EmptyMessage="Select Year" Style="z-index: 1000000;" ItemsPerRequest="10" ShowMoreResultsBox="true"
                    EnableVirtualScrolling="true">
                    <Items>
                        <telerik:RadComboBoxItem Text="2013" />
                        <telerik:RadComboBoxItem Text="2014" />
                        <telerik:RadComboBoxItem Text="2015" />
                        <telerik:RadComboBoxItem Text="2016" />
                        <telerik:RadComboBoxItem Text="2017" />
                        <telerik:RadComboBoxItem Text="2018" />
                        <telerik:RadComboBoxItem Text="2019" />
                        <telerik:RadComboBoxItem Text="2020" />
                        <telerik:RadComboBoxItem Text="2021" />
                        <telerik:RadComboBoxItem Text="2022" />
                        <telerik:RadComboBoxItem Text="2023" />
                        <telerik:RadComboBoxItem Text="2024" />
                        <telerik:RadComboBoxItem Text="2025" />
                    </Items>
                </telerik:RadComboBox>
            </td>
        </tr>

        <tr><td colspan="4">
        <center>
        <br />

        <asp:Button ID="btnSearch" CssClass="Button" runat="server" Text="Search" Width="60px" OnClick="btnSearch_Click" />
        </center>
        </td></tr>
    </table>
    <br />
    <asp:Panel ID="panelgrid1" runat="server">
        <telerik:RadGrid ID="gvRoster" runat="server" CssClass="RadGrid" GridLines="None"
            HeaderStyle-Font-Size="12px" AllowPaging="True" PageSize="50" AllowSorting="True"
            AutoGenerateColumns="False" ShowStatusBar="true" Skin="Simple" HeaderStyle-HorizontalAlign="left"
            HeaderStyle-BackColor="#ad1c1c" HeaderStyle-ForeColor="white" AllowMultiRowSelection="false"
            AllowFilteringByColumn="true">
            <GroupingSettings CaseSensitive="false" />
            <MasterTableView CommandItemDisplay="Bottom" DataKeyNames="WDRID">
                <CommandItemSettings ShowAddNewRecordButton="false" ShowRefreshButton="false" />
                <Columns>
                    <telerik:GridBoundColumn UniqueName="StaffName" HeaderText="Name" DataField="StaffName"
                        CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="Location" HeaderText="Location" DataField="Location"
                        CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="Shift" HeaderText="Shift" DataField="Shift"
                        CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="Date" HeaderText="Date" DataField="Date" CurrentFilterFunction="Contains"
                        AutoPostBackOnFilter="true" ShowFilterIcon="false">
                    </telerik:GridBoundColumn>
                </Columns>
                <NoRecordsTemplate>
                No Record Found
                </NoRecordsTemplate>
            </MasterTableView>
            <SelectedItemStyle BorderWidth="0px" Font-Bold="true" ForeColor="White" BackColor="Red" />
        </telerik:RadGrid>
    </asp:Panel>


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
                    
                        <asp:Button ID="btnGo" CssClass="Button" Height="30px" Width="100px" runat="server" Text="Go" OnClick="btnGo_Click" />
                    </td>
                    
                </tr>
            </table>
           </center>
        </div>
</asp:Content>
