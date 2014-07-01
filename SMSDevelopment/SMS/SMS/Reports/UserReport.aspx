<%@ Page Language="C#" MasterPageFile="~/SMSmaster.Master" AutoEventWireup="true" CodeBehind="UserReport.aspx.cs" Inherits="SMS.Reports.UserReport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div class="divContainer">
        <div class="divHeader"><span class="pageTitle">User Report</span>
        </div>
        <br />
          <table align="left" width="900px">
            <tr>
                <td align="left">
                    <asp:Label ID="lbluserID" CssClass="Labels"  runat="server" Text="User ID"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtuserid" CssClass="Input" runat="server"></asp:TextBox>
                </td>
                <td align="left">
                    <asp:Label ID="firstname" CssClass="Labels"  runat="server" Text="First Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtfirstname" CssClass="Input" runat="server"></asp:TextBox>
                </td>
                <td align="left">
                    
                    <asp:Label ID="lblrole" CssClass="Labels"  runat="server" Text="Role"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtrole" CssClass="Input" runat="server"></asp:TextBox>
                </td>
               
            </tr>
            <tr>
            
                 <td align="left">
                    <asp:Label ID="lblnricno" CssClass="Labels"  runat="server" Text="NRIC/FIN No."></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtnricno" CssClass="Input" runat="server"></asp:TextBox>
                </td>
            
                  <td align="left">
                        <asp:Label ID="lbldatefrom" CssClass="Labels"  runat="server" Text="Date:  From"></asp:Label>
                  </td>
                   <td>
                        <asp:TextBox ID="txtdatefrom" CssClass="Input" runat="server" 
                         ontextchanged="txtdatefrom_TextChanged"></asp:TextBox>
                            
                         <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                         Format="MM/dd/yyyy" TargetControlID="txtdatefrom" PopupButtonID="imgBtnFromDate2" />
                         <asp:ImageButton ID="imgBtnFromDate2" runat="server" 
                        ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp" 
                        onclick="imgBtnFromDate2_Click" style="height: 13px"/>
                   </td>
                    
                   <td align"right" align="left">
                            <asp:Label ID="lbldateto" CssClass="Labels"  runat="server" Text="To"></asp:Label>
                    </td>
                     <td>
                            <asp:TextBox ID="txtdateto" CssClass="Input" runat="server" 
                                ontextchanged="txtdateto_TextChanged"></asp:TextBox>
                                    
                            <AJAX:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="AjaxCalendar"
                             Format="MM/dd/yyyy" TargetControlID="txtdateto" PopupButtonID="imgBtnFromDate3" />
                             <asp:ImageButton ID="imgBtnFromDate3" runat="server" 
                              ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp" 
                              onclick="imgBtnFromDate3_Click" />
                    </td>
            <tr>
                    <td height="25px">
                    </td>
           </tr>    
            
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
                    <td height="25px">
                    </td>
           </tr> 
            
        </table>
    <div>
        <asp:panel  ID="panel1" runat="server">
        <asp:gridview id="gvItemTable" runat="server"
            allowpaging="True" allowsorting="True"
            autogeneratecolumns="False" cellpadding="5" width="100%"
            onrowdatabound="gvItem_RowDataBound"
            onrowcommand="gvItem_RowCommand" PageSize="50" 
            onpageindexchanging="gvItem_PageIndexChanging"
            cssclass="GridMain" 
            onselectedindexchanged="gvItemTable_SelectedIndexChanged">
            
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
                <li>To add Billing Table click the Add New Item Code.</li>
            </EmptyDataTemplate>
            <Columns>
            
                    <asp:BoundField DataField="LastLoginTime" HeaderText="Login Time"></asp:BoundField>
                   
                    
                    <asp:BoundField DataField="UserID" HeaderText="User ID"></asp:BoundField>
                    <asp:BoundField DataField="NRICno" HeaderText="NRIC/FIN No."></asp:BoundField>
                   <%-- <asp:BoundField DataField="Staff_ID" HeaderText="Staff ID"></asp:BoundField>--%>
                    <asp:BoundField DataField="FirstName" HeaderText="First Name"></asp:BoundField>
                    <asp:BoundField DataField="Role" HeaderText="Role"></asp:BoundField>
                 
                   
                 <asp:TemplateField HeaderText="View" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" >
                            <ItemTemplate>
                                <asp:ImageButton ImageUrl="~/Images/reports-stack.png" ID="btnView" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.UserID") %>' CommandName="View" runat="server"/>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField> 
                   
                <%-- <asp:TemplateField HeaderText="Edit/View" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="../../Images/Edit.gif" ID="btnEdit" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.UserID") %>' CommandName="EditRow" runat="server"/>
                    </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>--%>
                
                 <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="~/Images/Delete.gif" ID="btnDelete" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.UserID") %>' CommandName="DeleteRow" runat="server"/>
                    </ItemTemplate>

                <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>

                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                  </asp:TemplateField> 
            </Columns>
    </asp:gridview>
    </asp:panel>
    </div>
  <br/> 
    
    <div style="height: 50px; width: 880px">        
              <table align="left">
        <tr>
            <td>
                <asp:Label ID="employee1" runat="server" CssClass="Labels" Font-Bold="True" 
                    ForeColor="#000099" Text="Total Users : " Visible="False"></asp:Label>
            </td>
            <td>
                &nbsp;
                <asp:Label ID="userid" runat="server" CssClass="Labels" Font-Bold="True" 
                    ForeColor="#000099" Visible="False"></asp:Label>
            </td>
           
            </tr>
        <tr>
              <td>
                <asp:Label ID="exporto" runat="server" CssClass="Labels" Font-Bold="True" 
                    ForeColor="#000099" Text="Export To :"></asp:Label>
            </td>
              <td>
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="Labels" 
                    ForeColor="#000099" Height="16px" Width="80px" 
                    onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                    <asp:ListItem>None</asp:ListItem>
                        <asp:ListItem>Excel</asp:ListItem>
                        <asp:ListItem>Pdf</asp:ListItem>
                        <asp:ListItem>Html</asp:ListItem>
                </asp:DropDownList>
                &nbsp;&nbsp;
            </td>
              <td>
                
                <asp:Button ID="btnGo" runat="server" cssclass="Buttons" text="Go" 
                    Width="85px" onclick="btnGo_Click" />
            </td>
              <td>
                <asp:Button ID="btnEmail1" runat="server" CssClass="Buttons" Text="E-Mail" 
                    Width="85px" onclick="btnEmail1_Click" Visible="False" />
            </td>
              <td>
                <asp:Button ID="btnprint1" runat="server" CssClass="Buttons" Text="Print" 
                    Width="85px" onclick="btnprint1_Click" Visible="False" />
            </td>
         </tr>
           
        </table>
         </div>
    <br />
  </div>  
</asp:Content>
