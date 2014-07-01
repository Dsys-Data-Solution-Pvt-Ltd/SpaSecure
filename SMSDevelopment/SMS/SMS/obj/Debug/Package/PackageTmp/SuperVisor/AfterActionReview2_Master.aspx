<%@ Page Language="C#" MasterPageFile="~/master/spamaster.Master" AutoEventWireup="true" CodeBehind="AfterActionReview2_Master.aspx.cs" Inherits="SMS.SuperVisor.AfterActionReview2"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX"%>
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
            <span class="pageTitle">After Action Review : Section 2</span></div>
                <br/>


 <div class="btnbar" style="margin-top: 20px">
        <div class="btnbarBox">
            <ul>
                <li>
                    <asp:LinkButton ID="imdAdd" runat="server" CausesValidation="false"  Enabled="false" Visible="false" >
                        <span id="spanAdd1" runat="server" class="iconAdd" style="line-height: 120px;">
                            <asp:Label ID="spanAdd" runat='server' Text="Add"></asp:Label></span>
                    </asp:LinkButton>
                </li>
                <li>
                    <asp:LinkButton ID="imgUpdate" runat="server" CausesValidation="false"  Enabled="false"  Visible="false">
                        <span id="spanUpdate1" runat="server" class="iconUpdate" style="line-height: 120px;">
                            <asp:Label ID="spanUpdate" runat='server' Text="Update"></asp:Label></span>
                    </asp:LinkButton>
                </li>
                <li>
                    <asp:LinkButton ID="imgDelete" runat="server" CausesValidation="false"  Enabled="false" Visible="false">
                        <span id="spanDelete" runat="server" class="iconDelete" style="line-height: 120px;">
                            Delete </span>
                    </asp:LinkButton>
                </li>
                <li>
                    <asp:LinkButton ID="imgCopy" runat="server" CausesValidation="false" OnClick="ImageView">
                        <span id="spanCopy" runat="server" class="iconCopy" style="line-height: 120px;">View
                        </span>
                    </asp:LinkButton>
                </li>
            </ul>
        </div>
    </div>
    <div class="clear">
    </div>
    <div id="content" runat="server">
        <br />
     <%--   <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel4" runat="server">
                </telerik:RadAjaxLoadingPanel>--%>
                  <asp:Panel ID="panelgrid" runat="server">
                <telerik:RadGrid ID="gvLoctionTable" runat="server" CssClass="RadGrid" GridLines="None"
                    HeaderStyle-Font-Size="12px" AllowPaging="True" PageSize="50" AllowSorting="True"
                    AutoGenerateColumns="False" ShowStatusBar="true" Skin="Simple" HeaderStyle-HorizontalAlign="left"
                    HeaderStyle-BackColor="#ad1c1c" HeaderStyle-ForeColor="white" AllowMultiRowSelection="false"
                    AllowFilteringByColumn="true">
                    <GroupingSettings CaseSensitive="false" />
                    <MasterTableView CommandItemDisplay="Bottom" DataKeyNames="intID">
                        <CommandItemSettings ShowAddNewRecordButton="false" ShowRefreshButton="false" />
                        <Columns>
                            <telerik:GridTemplateColumn UniqueName="CheckBoxTemplateColumn" ShowFilterIcon="false"
                                AllowFiltering="false">
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="ToggleRowSelection"
                                        AutoPostBack="True" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn UniqueName="IssueRaised" DataField="IssueRaised" HeaderText="Issue Raised"
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="strDescription" DataField="strDescription" HeaderText="Complaint/Problem"
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                           <%-- <telerik:GridBoundColumn UniqueName="strDescription" DataField="strDescription" HeaderText="Complaint""
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>--%>
                            <telerik:GridBoundColumn UniqueName="strRaisedBy" DataField="strRaisedBy" HeaderText="Raised By"
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="Status" DataField="Status" HeaderText="Status" CurrentFilterFunction="Contains"
                                AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                           
                        </Columns>
                    </MasterTableView>
                    <SelectedItemStyle BorderWidth="0px" Font-Bold="true" ForeColor="White" BackColor="Red" />
                </telerik:RadGrid>
     <%--       </ContentTemplate>
        </asp:UpdatePanel>--%>
        </asp:Panel>
      
       
        <asp:HiddenField ID="hdnView" runat="server" />
        <asp:ModalPopupExtender ID="ModalPopupView" runat="server" TargetControlID="hdnView"
            CancelControlID="btnCancelView" BackgroundCssClass="modalBackground" PopupControlID="pnlView">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlView" runat="server" BackColor="White" Height="600px" Width="750px" ScrollBars="Vertical"
            Style="display: none">
            <asp:UpdateProgress ID="UpdateProgress2" DisplayAfter="10" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
                <ProgressTemplate>
                    <div class="divWaiting">
                        <asp:Image ID="imgWait82" runat="server" ImageAlign="Middle" ImageUrl="~/img/progress.gif" /><br />
                        <asp:Label ID="lblWait82" runat="server" Text=" Please wait... " Font-Bold="true"
                            Font-Size="Large" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <br />
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <center>
                       
           
          
                <asp:Label ID="lblheading" runat="server" CssClass="Labels" Text="This form is for all staff to report,correct and verify faults found in the day to day operations."></asp:Label><br />
                <br />
               
                    <table Width="670px">
                        <tr>
                            <td>
                                <asp:Label runat="server" CssClass="Labels" ID="lblIssu" Text="Issue Raised"></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="txtIssueRaised" CssClass="Input" Width="620px" Height="19px"
                                    Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" CssClass="Labels" ID="Label2" Text="Description Of Problem"></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="txtdescProb" CssClass="Input" Width="620px" TextMode="MultiLine"
                                    Height="131px" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" CssClass="Labels" ID="Label3" Text="Raised By"></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="txtBy" CssClass="Input" Width="622px" TextMode="SingleLine"
                                    Height="22px" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDate" Text="Date :" CssClass="Labels" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="calDate" CssClass="Input" Font-Bold="True" />
                            </td>
                        </tr>
                    </table>
               
            
                    <table>
                        <tr>
                            <td >
                                <asp:Label runat="server" CssClass="Labels" ID="Label1" Text="Root Cause of the Problem"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtRootCause" CssClass="Input" Width="610px" TextMode="MultiLine"
                                    Height="131px" Font-Bold="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td >
                                <asp:Label runat="server" CssClass="Labels" ID="Label4" Text="Analysis Of Critical Task Performance"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtAOC" CssClass="Input" Width="610px" TextMode="MultiLine"
                                    Height="131px" Font-Bold="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" CssClass="Labels" ID="Label5" Text="Analysis Of OutCome"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtAO" CssClass="Input" Width="610px" TextMode="MultiLine"
                                    Height="131px" Font-Bold="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" CssClass="Labels" ID="Label6" Text="Goals & Objectives"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtGO" CssClass="Input" Width="610px" TextMode="MultiLine"
                                    Height="131px" Font-Bold="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" CssClass="Labels" ID="Label7" Text="Actions Required To Fix The Problem"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtAR" CssClass="Input" Width="610px" TextMode="MultiLine"
                                    Height="131px" Font-Bold="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" CssClass="Labels" ID="Label8" Text="Actions Required To Prevent Recurrence"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtART" CssClass="Input" Width="610px" TextMode="MultiLine"
                                    Height="131px" Font-Bold="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" CssClass="Labels" ID="Label9" Text="Expected Completion Date"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox runat="server" CssClass="newInput"  ID="txtexpected" Text="" width="160px"></asp:TextBox>
                               
                              <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy" TargetControlID="txtexpected"
                                PopupButtonID="imgBtnFromDate" Enabled="True" ></asp:CalendarExtender>

                                <asp:ImageButton ID="imgBtnFromDate" runat="server" class="calender" ImageUrl="~/Images/calendar.bmp" style="margin-top: -17px; margin-left: 167px; " />
                            </td>
                        </tr>
                      
                       
                            <tr>
                                <td  colspan="2">
                                <center>
                                    <asp:Button ID="btnAdd" runat="server" CssClass="Button" Height="30px" 
                                        OnClick="btnAdd_Click" Text="Save" Width="90px" />
                                         <asp:Button ID="btnCancelView" runat="server" CssClass="Button" Height="30px" 
                                        OnClick="btnCancelView_Click" Text="Cancel" Width="90px" />
                                </center>
                                </td>
                            </tr>
                     
                        
                    </table>
               
                    </center>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
    </div>

<%--<div class="divContainer">
      
                <asp:panel runat="server" ID="Panel1" BackColor="White" 
                            style=" margin-left:1.5em" Font-Bold="True" width="750px">
              <div style=" margin-left:0.001em; width:750px">
                    <asp:gridview id="gvLoctionTable" runat="server" allowpaging="True" allowsorting="True"
                        autogeneratecolumns="False" cellpadding="5" width="750px" onrowdatabound="gvLocation_RowDataBound"
                        onrowcommand="gvLocation_RowCommand" onpageindexchanging="gvLocation_PageIndexChanging"
                        cssclass="GridMain2">
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
                            <asp:BoundField DataField="IssueRaised" HeaderText="Issue Raised"><HeaderStyle Width="100px" /></asp:BoundField>
                            <asp:BoundField DataField="strDescription" HeaderText="Problem/Complaint"><HeaderStyle Width="200px" /></asp:BoundField>
                            <asp:BoundField DataField="strRaisedBy" HeaderText="Raised By"><HeaderStyle Width="200px" /></asp:BoundField>
                            <asp:BoundField DataField="Status" HeaderText="Status"><HeaderStyle Width="200px" /></asp:BoundField>
                            <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" >
                                <ItemTemplate>
                                    <asp:ImageButton ImageUrl="../Images/reports-stack.png" ID="btnEdit" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.intID") %>' CommandName="EditRow" runat="server"/>
                                </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField> 
                        </Columns>
             </asp:gridview>
    </div>
    </asp:panel>
  <br />
 </div>--%> 
</asp:Content>
