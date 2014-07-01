<%@ Page Language="C#" MasterPageFile="~/SMSmaster.Master" AutoEventWireup="true" CodeBehind="WeeklyRosterReport.aspx.cs" Inherits="SMS.SMSAdmin.WeeklyRosterReport"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="divContainer">
        <div class="divHeader"><span class="pageTitle">Weekly Roster Report</span>
        </div>        
           <div id="divAdvSearch" runat="server" visible="true">
            <br />
                    <table width="900px">                                       
                                        <tr>                                        
                                                  <td>
                                                        <asp:Label ID="lblLocation" Text="Location" CssClass="Labels" runat="server"></asp:Label>
                                                  </td>                                         
                                                  <td>
                                                        <asp:DropDownList ID="ddllocation" runat="server" CssClass="Input" Width="130px"> 
                                                         </asp:DropDownList>
                                                         <asp:Label ID="SearchLocID" Text="" CssClass="Labels" runat="server" Visible="False"></asp:Label>
                                                  </td>    
                                                  <td>
                                                        <asp:Label ID="lblWeek" Text="Week" CssClass="Labels" runat="server"></asp:Label>
                                                  </td>                                         
                                                  <td>
                                                        <asp:DropDownList ID="ddlWeekname" runat="server" CssClass="Input" Width="130px"> 
                                                         </asp:DropDownList>
                                                  </td>      
                                         </tr>        
                                          <tr>
                                              <td>                                              
                                                    <asp:Label ID="lbldatefrom" CssClass="Labels"  runat="server" Text="Date:  From"></asp:Label>
                                              </td>
                                              <td>
                                                        <asp:TextBox ID="txtdatefrom" CssClass="Input" runat="server"></asp:TextBox>                                                            
                                                       <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                                                        Format="MM/dd/yyyy" TargetControlID="txtdatefrom" PopupButtonID="imgBtnFromDate2" />
                                                       <asp:ImageButton ID="imgBtnFromDate2" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp" />
                                              </td>
                                    </tr>                                     
                                        <tr>
                                                <td height="20px">                                                
                                                </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <asp:Button ID="btnSearch1" CssClass="Buttons" runat="server" Text="Search" 
                                                     Width="85px" onclick="btnSearch1_Click"/>
                                            </td>
                                            <td>
                                                <asp:Button ID="btnclear" CssClass="Buttons" runat="server" Text="Clear" 
                                                     Width="85px" onclick="btnclear_Click"/>
                                            </td>
                                        </tr>
                                        <tr>
                                             <td height="25px">                                             
                                             </td>
                                        </tr>
                        </table>                     
             </div>
        <div>
          <asp:panel  ID="panel1" runat="server">
           <asp:gridview id="gvItemTable" runat="server"
            allowpaging="True" allowsorting="True"
            autogeneratecolumns="False" cellpadding="5" width="100%"
            onrowdatabound="gvItem_RowDataBound" PageSize="20"
            onrowcommand="gvItem_RowCommand" 
            cssclass="GridMain" onpageindexchanging="gvItemTable_PageIndexChanging" onselectedindexchanged="gvItemTable_SelectedIndexChanged2">            
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
                     <asp:BoundField DataField="MDate" HeaderText="Date"></asp:BoundField>
                     <asp:BoundField DataField="StaffName" HeaderText="Name"></asp:BoundField>
                     <asp:BoundField DataField="Shift" HeaderText="Shift"></asp:BoundField>                        
            </Columns>
    </asp:gridview>
    </asp:panel>
  </div>
  <br/> 
      <div style="height: 44px; width: 880px">
        <table align="left">           
            <tr> 
                 <td> 
                   <asp:Label ID="exportto" CssClass="Labels"  runat="server" Text="Export To :" ForeColor="#000099" Font-Bold="true"></asp:Label> &nbsp;&nbsp;&nbsp;                    
                  </td>   
                 <td> 
                     <asp:DropDownList ID="DropDownList1" CssClass="Labels" runat="server" ForeColor="#000099" Width="81px" Height="16px" >
                        <asp:ListItem>None</asp:ListItem>
                        <asp:ListItem>Excel</asp:ListItem>
                        <asp:ListItem>Pdf</asp:ListItem>
                        <asp:ListItem>Html</asp:ListItem>
                    </asp:DropDownList>
                </td>               
                <td>
                    <asp:button id="btnGo" cssclass="Buttons" runat="server" text="Go" Width="60px" onclick="btnGo_Click"/>          
                </td>              
          </tr>           
        </table>
     </div>
   <br/>
  </div>  
</asp:Content>
