<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="AfterActionReview_ClientMaster.aspx.cs" Inherits="SMS.SuperVisor.AfterActionReview_ClientMaster"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">After Action Review : Section 3</span></div>
                <br/>
                 <div>
                    <asp:gridview id="gvLoctionTable" runat="server" allowpaging="True" allowsorting="True"
                        autogeneratecolumns="False" cellpadding="5" width="100%" onrowdatabound="gvLocation_RowDataBound"
                        onrowcommand="gvLocation_RowCommand" 
                         onpageindexchanging="gvLocation_PageIndexChanging" cssclass="GridMain2" 
                         PageSize="20">                        
                        <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center"/>
                        <RowStyle CssClass="NormalRow"/>
                        <AlternatingRowStyle CssClass="AlternateRow"/>
                        <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="20px"/>
                        <SelectedRowStyle CssClass="HighlightedRow"/>
                        <EmptyDataRowStyle CssClass="NoRecords"/>
                        <EmptyDataTemplate>
                            <asp:Label ID="lblNoRecords" Text="There are no records in the system." runat="server">
                            </asp:Label>
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:BoundField DataField="IssueRaised" HeaderText="Issue Raised"><HeaderStyle Width="100px" /></asp:BoundField>
                            <asp:BoundField DataField="strDescription" HeaderText="Problem/Complaint"><HeaderStyle Width="200px" /></asp:BoundField>
                            <asp:BoundField DataField="strRaisedBy" HeaderText="Raised By"><HeaderStyle Width="200px"/></asp:BoundField>
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
  <br />
 </div> 
</asp:Content>

