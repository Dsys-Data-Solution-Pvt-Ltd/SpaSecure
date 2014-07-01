<%@ Page Language="C#" MasterPageFile="~/SMSmaster.Master" AutoEventWireup="true" CodeBehind="AdminSuperHead.aspx.cs" Inherits="SMS.SMSCommons.AdminSuperHead" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="divContainer">
        <div class="divHeader"><span class="pageTitle">AdminSuperHead</span></div> 
   
   <div>
      <asp:panel runat="server">
         <table>
               <tr>
                  <td>
                     <br />
                         <div>
                             <asp:Panel runat="server">
                                 <table>
                                     <tr>
                                         <td>
                                             <asp:Label ID="lblUserName" runat="server" CssClass="Labels" font-Bold="true" 
                                                 Text="Alert &amp; Messages" />
                                         </td>
                                     </tr>
                                     <tr>
                                         <td>
                                             <asp:GridView ID="Site_Table1" runat="server" allowpaging="true" allowsorting="true"
                                                        autogeneratecolumns="false" cellpadding="5" cellspacing="0" width="100%"
                                                        onrowdatabound="SiteTable1_RowDataBound"
                                                        onrowcommand="SiteTable1_RowCommand" 
                                                        onpageindexchanging="SiteTable1_PageIndexChanging"
                                                        cssclass="GridMain" >
                                                
                                                        
                                                        
                                                 <HeaderStyle CssClass="HeaderRow" />
                                                 <RowStyle CssClass="NormalRow" />
                                                 <AlternatingRowStyle CssClass="AlternateRow" />
                                                 <PagerStyle CssClass="PagingRow" Height="20px" HorizontalAlign="Right" />
                                                 <SelectedRowStyle CssClass="HighlightedRow" />
                                                 <EmptyDataRowStyle CssClass="NoRecords" />
                                                 
                                                 <Columns>
                                                     <asp:BoundField DataField="Name" HeaderText="Name" />
                                                     <asp:BoundField DataField="Message" HeaderText="Message" />
                                                 </Columns>
                                             </asp:GridView>
                                         </td>
                                     </tr>
                                 </table>
                             </asp:Panel>
                         </div>
                     </td>
                    
                        
                         <td>
                             <div>
                                 <asp:Panel runat="server">
                                     <table>
                                         <tr>
                                             <td align="center">
                                                 <asp:Label ID="ClientName" runat="server" CssClass="Labels" font-Bold="true" 
                                                     Text="Client Name" />
                                             </td>
                                         </tr>
                                         <tr>
                                             <td>
                                                 <asp:Label ID="lblUserName1" runat="server" CssClass="Labels" font-Bold="true" 
                                                     Text="Client View" />
                                             </td>
                                             <tr>
                                                 <td>
                                                     <asp:GridView ID="SiteTable" runat="server" allowpaging="true" allowsorting="true"
                                                        autogeneratecolumns="false" cellpadding="5" cellspacing="0" width="100%"
                                                        onrowdatabound="SiteTable_RowDataBound"
                                                        onrowcommand="SiteTable_RowCommand" 
                                                        onpageindexchanging="SiteTable_PageIndexChanging"
                                                        cssclass="GridMain">
                                                      
                                                     <AlternatingRowStyle CssClass="AlternateRow" />
                                                     <PagerStyle CssClass="PagingRow" Height="20px" HorizontalAlign="Right" />
                                                     <SelectedRowStyle CssClass="HighlightedRow" />
                                                     <EmptyDataRowStyle CssClass="NoRecords" />
                                                     
                                                     <Columns>
                                                         <asp:BoundField DataField="Site_Name" HeaderText="Site_Name" />
                                                         <asp:BoundField DataField="Site_Application" HeaderText="Application" />
                                                         <asp:BoundField DataField="Site_IpCamera1" HeaderText="View1" />
                                                         <asp:BoundField DataField="Site_IpCamera2" HeaderText="View2" />
                                                         <asp:BoundField DataField="Site_IpCamera3" HeaderText="View3" />
                                                         <asp:BoundField DataField="Site_IpCamera4" HeaderText="View4" />
                                                         <asp:BoundField DataField="Site_IpCamera5" HeaderText="View5" />
                                                         <asp:BoundField DataField="Site_IpCamera6" HeaderText="View6" />
                                                         <asp:BoundField DataField="Site_IpCamera7" HeaderText="View7" />
                                                        <asp:BoundField DataField="Site_IpCamera8" HeaderText="View8" />
                                                     </Columns>
                                                     </asp:GridView>
                                                 </td>
                                             </tr>
                                         </tr>
                                     </table>
                                 </asp:Panel>
                             </div>
                         </td>
                  
                 </tr>
           
           </table>
       </asp:panel>
    </div>
  
    
  </div>


</asp:Content>
