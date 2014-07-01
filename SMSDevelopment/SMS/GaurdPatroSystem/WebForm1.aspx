<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="GaurdPatroSystem.WebForm1" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


 <div class="table">
     <asp:gridview id="gvLoctionTable" runat="server" allowpaging="True" allowsorting="True"
     autogeneratecolumns="False" cellpadding="5" width="100%" onrowdatabound="gvLocation_RowDataBound"
     onrowcommand="gvLocation_RowCommand" onpageindexchanging="gvLocation_PageIndexChanging"
     cssclass="GridMain" 
     onselectedindexchanged="gvLoctionTable_SelectedIndexChanged">
                        
      <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center"/>
      <RowStyle CssClass="NormalRow"/>
      <AlternatingRowStyle CssClass="AlternateRow"/>
      <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="20px"/>
      <SelectedRowStyle CssClass="HighlightedRow"/>
      <EmptyDataRowStyle CssClass="NoRecords"/>
   
       <Columns>     
                 <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" >
                       <ItemTemplate>                           
                             <asp:CheckBox ID="btnView" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.GTid")%>' CommandName="View" runat="server"/>
                       </ItemTemplate>
                       <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                       <ItemStyle HorizontalAlign="Center"></ItemStyle>
                  </asp:TemplateField> 
                      
                   <asp:BoundField DataField="Personnel" HeaderText="Personnel"></asp:BoundField>
                   <asp:BoundField DataField="PatrolTime" HeaderText="Patrol Time"></asp:BoundField>  
                   <asp:BoundField DataField="Check_Point" HeaderText="Check Point"></asp:BoundField>  
                   <asp:BoundField DataField="Rout" HeaderText="Rout"></asp:BoundField>  
                   <asp:BoundField DataField="Reader" HeaderText="Reader"></asp:BoundField>  
                   <asp:BoundField DataField="GEvent" HeaderText="Event"></asp:BoundField>                   
                            
                                         
                                      
           </Columns>
        </asp:gridview>
     <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" />
    </div>
    

</asp:Content>
