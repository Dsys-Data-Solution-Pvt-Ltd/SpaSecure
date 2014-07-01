<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="EditPatroSystem.aspx.cs" Inherits="GaurdPatroSystem.EditPatroSystem"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width:116%">
  <table style="width: 90%">
  <tr><td><asp:Label ID="SearchLocID" runat="server" Visible="False" Width="20px"></asp:Label></td></tr>
      <tr>
         <td>
            <asp:Label ID="lbl" runat="server" Text="Personnel#"></asp:Label>
         </td>
         <td>
             <asp:TextBox ID="txtpersonnelNo" runat="server"></asp:TextBox>
         </td>
      <%--</tr>
      <tr>--%>
         <td>
            <asp:Label ID="Label1" runat="server" Text="Personnel"></asp:Label>
         </td>
         <td>
            <asp:TextBox ID="txtpersonnel" runat="server"></asp:TextBox>
         </td>
      <%--</tr>
      <tr>--%>    
           <td style=" width:100px">
             <asp:Label ID="lbllocation" runat="server" Text="Location"></asp:Label>      
           </td>
            <td>
             <asp:DropDownList ID="ddlocation2" runat="server"  Width="131px" Visible="false">
         </asp:DropDownList>          
          </td>        
        
     </tr>
      <tr>
          <td>
             <asp:Label ID="lblrout" runat="server" Text="Rout"></asp:Label>
         </td>
         <td>
            <asp:TextBox ID="txtrout" runat="server"></asp:TextBox>
         </td>
         <td>
            <asp:Label ID="Label2" runat="server" Text="Check Point#"></asp:Label>
         </td>
         <td>
           <asp:TextBox ID="txtCheckPoint" runat="server"></asp:TextBox> 
         </td>
   
         <td style=" width:140px">
             <asp:Label ID="lblchkpoint" runat="server" Text="Check Point"></asp:Label>
         </td>
         <td colspan="2">
            <asp:TextBox ID="txtchkpoint" runat="server"></asp:TextBox>
         </td>
    </tr>
     <tr>
         <td>
             <asp:Label ID="lblevent" runat="server" Text="Event"></asp:Label>
         </td>
         <td>
            <asp:TextBox ID="txtevent" runat="server"></asp:TextBox>
         </td>
    
         <td>
            <asp:Label ID="lblpatrotime" runat="server" Text="Patrol Time"></asp:Label>  
         </td>
         <td>
         <asp:TextBox ID="txtpatrotime" runat="server" Width="80%"></asp:TextBox>
             <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                  Format="MM/dd/yyyy" TargetControlID="txtpatrotime" 
                 PopupButtonID="imgBtnFromDate2" />
                  <asp:ImageButton ID="imgBtnFromDate2" runat="server" 
                  ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"/>
         </td>
         <td>
          <asp:Label ID="lblEventstarttype" CssClass="" runat="server" Text=" Start Time"></asp:Label>
         </td>
         <td>
         <MKB:TimeSelector ID="TimeSelector1" runat="server" SelectedTimeFormat="TwentyFour" AllowSecondEditing="True" 
                        DisplaySeconds="False" MinuteIncrement="1" />
         </td>

      </tr>
      <tr>
      <td>
       <asp:Label ID="lblreader" runat="server" Text="Reader"></asp:Label>
      </td>
     <td>
     <asp:TextBox ID="txtreader" runat="server"></asp:TextBox>
      </td>
      <td>
      <asp:Label ID="Remark" runat="server" Text="Remark"></asp:Label>
      </td>
       <td colspan="3">
            <asp:TextBox ID="txtremark" runat="server" TextMode="MultiLine" Height="30px" 
                 Width="320px"></asp:TextBox>
      </td>
      </tr>
     <tr>
       <td colspan="2">  
           <asp:Label ID="lblsearchtime" runat="server" Text="Patrol Time Sorted By:"></asp:Label>      
       </td>
       <td>    
           <asp:DropDownList ID="drpsearchtime" runat="server" AutoPostBack="True" 
               onselectedindexchanged="drpsearchtime_SelectedIndexChanged" Width="131px">
              <asp:ListItem></asp:ListItem>
              <asp:ListItem>Ascending</asp:ListItem>
              <asp:ListItem>Descending</asp:ListItem>
           </asp:DropDownList>   
       </td>
       <td>
        <asp:DropDownList ID="ddlocation1" runat="server"  Width="131px" Visible="false">
         </asp:DropDownList>   
       </td>
     </tr> 
      
      
    </table>
     <br />
    
   <div class="table" style="Width:1000px">
     <asp:Panel ID="Panel1" runat="server" Height="350px" ScrollBars="Vertical" 
            Width="1070px">
     <asp:gridview id="gvLoctionTable" runat="server" allowsorting="True"
     autogeneratecolumns="False" cellpadding="5" width="1050px" onrowdatabound="gvLocation_RowDataBound"
     onrowcommand="gvLocation_RowCommand" onpageindexchanging="gvLocation_PageIndexChanging"
     cssclass="GridMain" 
     onselectedindexchanged="gvLoctionTable_SelectedIndexChanged" PageSize="20">
                        
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
                            
                   <%--<asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" >
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
      </asp:Panel> 
    </div>
    
    <br />  
      
   <table width="70%">
      <tr>
         <td>
             <asp:Label ID="lblid" runat="server" Visible="False"></asp:Label>
         </td>
        <td height="45" align="left" colspan="5" valign="bottom">
            <asp:Button ID="btnupdate" runat="server" Text="Update" 
                onclick="btnupdate_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        
            <asp:Button ID="btnAdd" runat="server" Text="Add" onclick="btnAdd_Click" Width="56px" 
               />
        &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
        
            <asp:Button ID="btnviewall" runat="server" Text="View All" 
                onclick="btnviewall_Click" />
        </td>
      </tr>
  </table>
</div>
</asp:Content>
