<%@ Page Language="C#" MasterPageFile="~/SMSmaster.Master" AutoEventWireup="true" CodeBehind="VehicleReport.aspx.cs" Inherits="SMS.Reports.VehicleReport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainer">
        <div class="divHeader"><span class="pageTitle">Vehicle Report</span>
        </div>
        <br />
        <table align="left" width="900px">
            <tr>
                <td align="left">
                    <asp:Label ID="lblvehicleno" CssClass="Labels" runat="server" Text="Vehicle No."></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtvehicleno" CssClass="Input" runat="server"></asp:TextBox>
                </td>
                <td align="left">
                    <asp:Label ID="lblvehiclecolor" CssClass="Labels" runat="server" Text="Vehicle Color"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtvehiclecolor" CssClass="Input" runat="server"></asp:TextBox>
                </td>
                <td align="left">
                    <asp:Label ID="lblvehicletype" CssClass="Labels" runat="server" Text="Vehicle Type"></asp:Label>
                </td>
                <td>
                
                    <asp:DropDownList ID="DropDownList2" CssClass="Labels"  runat="server" 
                        ForeColor="#000099" width="126px">
                      
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                    
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
                        onclick="imgBtnFromDate2_Click" style="width: 16px"/>
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
                 
            
            </tr>
            <tr>
                    <td height="25px">
                    </td>
            </tr>
          
            <tr>
                <td align="Center" >
                    <asp:Button ID="btnSearch" CssClass="Buttons" runat="server" Text="Search" 
                        onclick="btnSearch_Click" Width="85px" />
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
            onrowcommand="gvItem_RowCommand" 
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
            
                    <asp:BoundField DataField="Date_From" HeaderText="Added ON"></asp:BoundField>
                   <%-- <asp:BoundField DataField="Date_To" HeaderText="To Date"></asp:BoundField>--%>
                    
                    <asp:BoundField DataField="Vehicle_No" HeaderText="Vehicle No."></asp:BoundField>
                    <asp:BoundField DataField="Vehicle_Type" HeaderText="Type"></asp:BoundField>
                 
                    <asp:BoundField DataField="Vehicle_Color" HeaderText=" Color"></asp:BoundField>
                    <asp:BoundField DataField="Vehicle_Model" HeaderText=" Model"></asp:BoundField>
                   <%-- <asp:BoundField DataField="Vehicle_Remark" HeaderText="Remark"></asp:BoundField>--%>
                    
                    
                     <asp:TemplateField HeaderText="View" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" >
                            <ItemTemplate>
                                <asp:ImageButton ImageUrl="~/Images/reports-stack.png" ID="btnView" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.Vehicle_No") %>' CommandName="View" runat="server"/>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField> 
                    
                   
                <%-- <asp:TemplateField HeaderText="Edit/View" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="../../Images/Edit.gif" ID="btnEdit" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.Vehicle_No") %>' CommandName="EditRow" runat="server"/>
                    </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>                
                </asp:TemplateField> --%>
                
                 <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="~/Images/Delete.gif" ID="btnDelete" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.Vehicle_No") %>' CommandName="DeleteRow" runat="server"/>
                    </ItemTemplate>
                   <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                   <ItemStyle HorizontalAlign="Center"></ItemStyle>
               </asp:TemplateField> 
                
            </Columns>
    </asp:gridview>
   </asp:panel>
 </div>
    <br />
 
   <div style="height: 50px; width: 880px">
        <table align="left" >
            <tr>
                <td>
                    <asp:Label ID="vechile1" CssClass="Labels"  runat="server" Text="Total Vehicles:" 
                        ForeColor="#000099" Font-Bold="True" Visible="False"></asp:Label>
                 </td>
                  <td> 
                        <asp:Label ID="vehicle2" CssClass="Labels"  runat="server" ForeColor="#000099" 
                            Font-Bold="True" Visible="False"></asp:Label></td>

                
            </tr>
            <tr>  
                <td >
                    <asp:Label ID="exportto" CssClass="Labels"  runat="server" Text="Export To:" ForeColor="#000099" Font-Bold="true"></asp:Label>
                </td>
                <td >
                
                    <asp:DropDownList ID="DropDownList1" CssClass="Labels"  runat="server" 
                        ForeColor="#000099" Height="16px" Width="85px">
                        <asp:ListItem>Pdf</asp:ListItem>
                        <asp:ListItem>word</asp:ListItem>
                    </asp:DropDownList>&nbsp;&nbsp;
                
                </td>
                <td >
                    <asp:button id="btnGo" cssclass="Buttons" runat="server" text="Go" 
                        Width="85px" onclick="btnGo_Click"/>          
                </td>
                <td>
                    <asp:button runat="server" cssclass="Buttons" text="E-mail" Width="85px" 
                        Visible="False"  />
                </td>
                <td>
                    <asp:button runat="server" cssclass="Buttons" text="Print" Width="85px" 
                        onclick="Unnamed2_Click" Visible="False" />
                </td>
            </tr>
          
        </table>
    </div>
    <br />
 </div>
</asp:Content>
