<%@ Page Language="C#" MasterPageFile="~/SMSmaster.Master" AutoEventWireup="true" CodeBehind="KeyRepot.aspx.cs" Inherits="SMS.Reports.KeyRepot" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div class="divContainer">
        <div class="divHeader"><span class="pageTitle">Key Report</span>
        </div>
        <br />
             <table align="left" width="900px">          
              <tr>
                  <td align="left">
                    <asp:Label ID="lblKeyno1" CssClass="Labels"  runat="server" Text="Key No."></asp:Label>
                 </td>
                <td>
                    <asp:TextBox ID="txtkeyno1" CssClass="Input" runat="server"></asp:TextBox>
                </td>
                 <td align="left">
                       <asp:Label ID="lblName" Text=" Name" CssClass="Labels" runat="server" ></asp:Label></td>                
                 <td>
                       <asp:TextBox ID="txtKeyName" runat="server" CssClass="Input"/>
                  </td>
                  <td>
                       <asp:Label ID="lblKeyDesc" Text="Status" CssClass="Labels" runat="server"></asp:Label>
                  </td>   
                  <td>
                          <asp:DropDownList ID="ddlstatus" runat="server" CssClass="Input" width="131px">
                              <asp:ListItem> </asp:ListItem>
                              <asp:ListItem>Free </asp:ListItem>
                              <asp:ListItem>Reserve </asp:ListItem>                                                        
                          </asp:DropDownList>
                  </td> 
            </tr>
            <tr>
                     <td align="left">
                            <asp:Label ID="lbldatefrom" CssClass="Labels"  runat="server" Text="Date:  From"></asp:Label>
                     </td>
                     <td>
                           <asp:TextBox ID="txtdatefrom" CssClass="Input" runat="server"></asp:TextBox>                                                            
                           <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                            Format="MM/dd/yyyy" TargetControlID="txtdatefrom" PopupButtonID="imgBtnFromDate2" />
                             <asp:ImageButton ID="imgBtnFromDate2" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp" />
                      </td>
                       <td align="left">
                            <asp:Label ID="lbldateto" CssClass="Labels"  runat="server" Text="To"></asp:Label>
                        </td>
                       <td>
                             <asp:TextBox ID="txtdateto" CssClass="Input" runat="server"></asp:TextBox>                                                            
                             <AJAX:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="AjaxCalendar"
                             Format="MM/dd/yyyy" TargetControlID="txtdateto" PopupButtonID="imgBtnFromDate3" />
                             <asp:ImageButton ID="imgBtnFromDate3" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp" />
                       </td>
                    <td height="20px">                    
                   </td>
             </tr>
             <tr>                  
                 <td height="25px"></td>
             </tr>
            <tr>
                <td align="Center">
                    <asp:Button ID="btnSearch1" CssClass="Buttons" runat="server" Text="Search" 
                        onclick="btnSearch1_Click" Width="85px" />
                </td>
                <td>
                    <asp:Button ID="btnclear" CssClass="Buttons" runat="server" Text="Clear" 
                         Width="85px" onclick="btnclear_Click" />
                </td>
            </tr>
               <tr>                  
                 <td height="25px"></td>
             </tr>
        </table>
 <div>    
    <asp:GridView ID="gvKeySearch" 
            runat="server" 
            AllowPaging="True" AllowSorting="True" 
            AutoGenerateColumns="False" CellPadding="5" Width="100%"
            OnRowDataBound="gvNewKey_RowDataBound" 
            OnRowCommand="gvNewKey_RowCommand" 
            OnPageIndexChanging="gvNewKey_PageIndexChanging" CssClass="GridMain" 
            onselectedindexchanged="gvNewKey_SelectedIndexChanged">            
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
                    <asp:BoundField DataField="Date_From" HeaderText="Time"></asp:BoundField>
                    <asp:BoundField DataField="key_no" HeaderText="Key No."><HeaderStyle Width="80px" /></asp:BoundField>
                     <asp:BoundField DataField="status" HeaderText="Status"></asp:BoundField>
                    <asp:BoundField DataField="nricno" HeaderText="NRIC/FIN No."></asp:BoundField>
                    <asp:BoundField DataField="name" HeaderText="Name"></asp:BoundField>                    
                    <asp:BoundField DataField="position" HeaderText="Position"></asp:BoundField>
                    <asp:BoundField DataField="count" HeaderText="Count"></asp:BoundField>                   
                    <asp:BoundField DataField="Description" HeaderText="Description"></asp:BoundField>
                   <asp:TemplateField HeaderText="View" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" >
                            <ItemTemplate>
                                <asp:ImageButton ImageUrl="~/Images/reports-stack.png" ID="btnView" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.key_no") %>' CommandName="View" runat="server"/>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>               
                    <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="~/Images/Delete.gif" ID="btnDelete" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.key_no") %>' CommandName="DeleteRow" runat="server"/>
                        </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                  </asp:TemplateField> 
            </Columns>
    </asp:GridView>   
   </div>
   <br />  
        <div style="height: 50px; width: 880px">
            <table align="left">
            <tr>
                <td>
                    <asp:Label ID="key1" CssClass="Labels" runat="server" Text="Total Key:" 
                        ForeColor="#000099" Font-Bold="True" Visible="False"></asp:Label>
                  </td>   
                <td>
                    <asp:Label ID="key2" CssClass="Labels" runat="server" ForeColor="#000099" 
                        Font-Bold="True" Visible="False"></asp:Label>&nbsp;&nbsp;
                 </td>
             </tr> 
            <tr> 
                <td>                
                    <asp:Label ID="exportto1"  CssClass="Labels" runat="server" Text="Export To:" ForeColor="#000099" Font-Bold="true"></asp:Label>&nbsp;&nbsp;&nbsp;
               </td>
              <td> 
                      <asp:DropDownList ID="DropDownList1" CssClass="Labels" runat="server" ForeColor="#000099" Width="82px">
                        <asp:ListItem>None</asp:ListItem>
                        <asp:ListItem>Excel</asp:ListItem>
                        <asp:ListItem>Pdf</asp:ListItem>
                        <asp:ListItem>Html</asp:ListItem>
                    </asp:DropDownList>
                </td>               
                <td>
                    <asp:button id="btnGo" cssclass="Buttons" runat="server" text="Go" 
                        Width="85px" onclick="btnGo_Click"  />          
                </td>
                <td>
                    <asp:Button ID="btnEmail1" CssClass="Buttons"  runat="server" Text="E-Mail" 
                        Width="85px" Visible="False" />
                </td>
                <td>
                    <asp:Button ID="btnprint1" CssClass="Buttons"  runat="server" Text="Print" 
                        Width="85px" Visible="False"  />
                </td>
            </tr>
        </table>
        </div>
    <br/>
   </div>
</asp:Content>
