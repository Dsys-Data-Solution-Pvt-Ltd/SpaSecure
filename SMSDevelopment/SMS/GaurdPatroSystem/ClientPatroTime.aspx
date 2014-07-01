<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ClientPatroTime.aspx.cs" Inherits="GaurdPatroSystem.ClientPatroTime"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
    <div>
      <table cellspacing="5" style="width: 107%">
       <tr>
          
           <td>
              <asp:Label ID="lblchkpoint" runat="server" Text="Check Point"></asp:Label>
          </td>
          <td>
              <asp:TextBox ID="txtchkpoint" runat="server"></asp:TextBox>
          </td> 
          <td>
              <asp:Label ID="lblpersonnel" runat="server" Text="Personnel" ></asp:Label>
          </td>
          <td>
              <asp:TextBox ID="txtpersonnel" runat="server" ></asp:TextBox>
          </td> 
       </tr>
       <tr>      
           <td>
                  <asp:Label ID="lbldatefrom" runat="server" Text="Date:  From"></asp:Label>
          </td>
           <td>
                  <asp:TextBox ID="txtdatefrom" runat="server"></asp:TextBox>                                                       
                  <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                  Format="MM/dd/yyyy" TargetControlID="txtdatefrom" PopupButtonID="imgBtnFromDate2" />
                  <asp:ImageButton ID="imgBtnFromDate2" runat="server" 
                  ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"/>
          &nbsp;
          <mkb:timeselector ID="TimeSelector1" runat="server" SelectedTimeFormat="Twelve" AllowSecondEditing="True" 
                        DisplaySeconds="False" MinuteIncrement="1" />
          </td>                                                
           <td>
                 <asp:Label ID="lbldateto" runat="server" Text="To"></asp:Label>
           </td>
            <td>
                  <asp:TextBox ID="txtdateto" runat="server"></asp:TextBox>                                                               
                  <AJAX:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="AjaxCalendar"
                   Format="MM/dd/yyyy" TargetControlID="txtdateto" PopupButtonID="imgBtnFromDate3" />
                   <asp:ImageButton ID="imgBtnFromDate3" runat="server" 
                  ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"/>
                  <MKB:TimeSelector ID="TimeSelector2" runat="server" SelectedTimeFormat="Twelve" AllowSecondEditing="True" 
                        DisplaySeconds="False" MinuteIncrement="1" />
           </td>
       </tr>
       <tr>
          <td height="20px">   
             <asp:Label ID="lblsearch" runat="server" Visible="false"></asp:Label>          
          </td>
       </tr>
       <tr>
          <td align="center">
              <asp:Button ID="btnsearch" runat="server" Text="Search" 
                  onclick="btnsearch_Click" />
          </td>
          <td>
              <asp:Button ID="btncancel" runat="server" Text="Cancel" 
                  onclick="btncancel_Click" />
          </td>
       </tr>
   </table>
   </div>
   <br />
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
      <EmptyDataTemplate>
         <asp:Label ID="lblNoRecords" Text="No records in the system." runat="server">
         </asp:Label>
                  <p></p>                    
                  <li></li>
                  <li></li>
                  <li></li>
                  <li></li>                            
      </EmptyDataTemplate>
       <Columns>                
                   <asp:BoundField DataField="Personnel#" HeaderText="Personnel#"></asp:BoundField>            
                   <asp:BoundField DataField="Personnel" HeaderText="Personnel"></asp:BoundField>
                   <asp:BoundField DataField="PatrolTime" HeaderText="Patrol Time"></asp:BoundField> 
                    <asp:BoundField DataField="Check_Point#" HeaderText="Check_Point#"></asp:BoundField>  
                   <asp:BoundField DataField="Check_Point" HeaderText="Check Point"></asp:BoundField>  
                   <asp:BoundField DataField="Rout" HeaderText="Rout"></asp:BoundField>  
                   <asp:BoundField DataField="Reader" HeaderText="Reader"></asp:BoundField>  
                   <asp:BoundField DataField="GEvent" HeaderText="Event"></asp:BoundField>      
                            
                  <%--  <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" >
                       <ItemTemplate>
                           <asp:ImageButton ImageUrl="~/Images/edit.gif" ID="btnView" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.GTid")%>' CommandName="View" runat="server"/>
                       </ItemTemplate>
                       <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                       <ItemStyle HorizontalAlign="Center"></ItemStyle>
                  </asp:TemplateField>                        
                  <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                     <ItemTemplate>
                         <asp:ImageButton ImageUrl="~/Images/Del.gif" ID="btnDelete" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.GTid")%>' CommandName="DeleteRow" runat="server"/>
                     </ItemTemplate>
                         <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                         <ItemStyle HorizontalAlign="Center"></ItemStyle>
                   </asp:TemplateField> --%>                              
           </Columns>
        </asp:gridview>
    </div>
    <br />
       <div>          
             <asp:Label ID="exportto" runat="server" CssClass="" Font-Bold="true" ForeColor="#000099"
             Text="Export To:" Visible="false"></asp:Label>                   
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="" ForeColor="#000099"
                            Width="81px" Visible="false">
                            <asp:ListItem>None</asp:ListItem>
                            <asp:ListItem>Excel</asp:ListItem>
                            <asp:ListItem>Pdf</asp:ListItem>
                            <asp:ListItem>Html</asp:ListItem>
                        </asp:DropDownList>                   
             <asp:Button ID="btnGo" runat="server" CssClass="" Text="Go" Width="60px" 
                 onclick="btnGo_Click" Visible="false"/>                   
       </div>
 </div>  
</asp:Content>
