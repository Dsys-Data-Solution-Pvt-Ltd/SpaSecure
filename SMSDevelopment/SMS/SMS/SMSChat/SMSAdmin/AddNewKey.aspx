<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="AddNewKey.aspx.cs" Inherits="SMS.SMSAdmin.AddNewKey" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="AJAX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <div class="divContainer">
     <div class="divHeader"><span class="pageTitle">Key Manager</span></div>
       
           <div><asp:Label id="lblerror" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"></asp:Label></div>                                     
            <br />  
            <div id="divAdvSearch" runat="server" visible="true">
                            <br /> 
                             <asp:panel runat="server" ID="Panel1" BackColor="White" 
                            style=" margin-left:1.5em" Font-Bold="True" width="880">
            <table width="800" class="table">
            <tr><td></td></tr>                                 
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblKeyNo" Text="Key No." CssClass="Labels" runat="server"></asp:Label>                    
                                                </td>    
                                                <td>
                                                    <asp:TextBox ID="txtKeyNo" runat="server" CssClass="Input"/>
                                                </td>
                                               
                                              
                                                <td>
                                                    <asp:Label ID="lblKeyDesc" Text="Status" CssClass="Labels" runat="server"></asp:Label>
                                                </td>   
                                                 <td>
                                                    <asp:DropDownList ID="ddlstatus" runat="server" CssClass="Labels">
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
                                                    <asp:TextBox ID="txtdatefrom" CssClass="Input" runat="server" 
                                                     ontextchanged="txtdatefrom_TextChanged"></asp:TextBox>
                                                    
                                                     <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                                                     Format="MM/dd/yyyy" TargetControlID="txtdatefrom" PopupButtonID="imgBtnFromDate2" />
                                                     <asp:ImageButton ID="imgBtnFromDate2" runat="server" 
                                                    ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp" 
                                                    onclick="imgBtnFromDate2_Click" class="calender"/>
                                               </td>
                                                
                                                 <td align="left">
                                                       <asp:Label ID="lbldateto" CssClass="Labels"  runat="server" Text="To"></asp:Label>
                                                </td>
                                                 <td>
                                                        <asp:TextBox ID="txtdateto" CssClass="Input" runat="server" 
                                                            ontextchanged="txtdateto_TextChanged"></asp:TextBox>
                                                             
                                                        <AJAX:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="AjaxCalendar"
                                                         Format="MM/dd/yyyy" TargetControlID="txtdateto" PopupButtonID="imgBtnFromDate3" />
                                                         <asp:ImageButton ID="imgBtnFromDate3" runat="server" 
                                                          ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp" 
                                                          onclick="imgBtnFromDate3_Click" class="calender"/>
                                                </td>
                 
                                                
                                            </tr> 
                                            <tr>
                                                 <td height="15px"></td>
                                            </tr>
                                            
                                            <tr>
                                                <td colspan="5" align="left">
                                                    <asp:Label ID="lblKeyName" Text=" Key Added By:" CssClass="Labels" 
                                                        runat="server" Font-Bold="True"></asp:Label>
                                                </td>
                                            </tr>
                                             <tr> 
                                                    <td>
                                                        <asp:Label ID="lblKeyNRIC" Text="NRIC No." CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtKeyNRIC" runat="server" CssClass="Input"/>
                                                     </td>
                                                   
                                                      <td>
                                                        <asp:Label ID="lblName" Text="Name" CssClass="Labels" runat="server" ></asp:Label></td>
                                                    
                                                    <td>
                                                        <asp:TextBox ID="txtKeyName" runat="server" CssClass="Input" Width="173px"/>
                                                    </td>
                                            
                                                
                                            </tr>
                                            <tr>
                                                   <td height="20px">
                                                   </td>
                                            </tr>
                                           <table  width="100%" style="margin-left:0.1em; margin-bottom:-0.4em;border:1px;border-style:groove; border-color:Black;background: url(../Images/1397d40aa687.jpg)">
                <tr>
                    <td colspan="4" align="center" style="width: 897px">
                                                    <asp:Button ID="btnSearchKeyAdd" Text="Search" runat="server" CssClass="Buttons" 
                                                          onclick="btnSearchKeyAdd_Click" Width="85px" />&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Button ID="btnClearKeyAdd" Text="Clear" runat="server" CssClass="Buttons" 
                                                          onclick="btnClearKeyAdd_Click" Width="85px"/>
                                                  </td>                        
                                               </tr>
                                               </table>
                                            </table>
                                            </asp:panel>
                                               
                    </div>
                <br />
        
              <div>
    
    <asp:GridView ID="gvKeySearch" 
            runat="server" 
            AllowPaging="True" AllowSorting="True" 
            AutoGenerateColumns="False" CellPadding="5" Width="100%"
            OnRowDataBound="gvNewKey_RowDataBound" 
            OnRowCommand="gvNewKey_RowCommand" 
            OnPageIndexChanging="gvNewKey_PageIndexChanging" CssClass="GridMain2" 
            onselectedindexchanged="gvNewKey_SelectedIndexChanged" PageSize="100">
            
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
                
            </EmptyDataTemplate>
            

            <Columns>
            
            
                    <%--<asp:BoundField DataField="Key_ID" HeaderText="ID"></asp:BoundField>  --%>
                    <asp:BoundField DataField="BunchNo" HeaderText="Bunch No."></asp:BoundField>
                    <asp:BoundField DataField="NoOfKey" HeaderText="No. of Key"></asp:BoundField>
                    <asp:BoundField DataField="status" HeaderText="Status"></asp:BoundField>
                    <asp:BoundField DataField="Staff_ID" HeaderText="NRIC No."></asp:BoundField>
                   <%-- <asp:BoundField DataField="Location_name" HeaderText="Location"></asp:BoundField>--%>
                    <asp:BoundField DataField="position" HeaderText="Position"></asp:BoundField>
                    
                 
               
                 <asp:TemplateField HeaderText="Edit/View" ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="../Images/Edit.gif" ID="btnEdit" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.Key_ID") %>' CommandName="EditRow" runat="server"/>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="~/Images/Delete.gif" ID="btnDelete" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.Key_ID") %>' CommandName="DeleteRow" runat="server"/>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField> 
                
            </Columns>
    </asp:GridView>
        </div>
        
        <br/>
        
         <div class="table">
          <table  width="102%" style="margin-left:0.1em; margin-bottom:-0.4em;border:1px;border-style:groove; border-color:Black;background: url(../Images/1397d40aa687.jpg)">
        <tr><td  align="right" style="width: 448px">
                <asp:Button ID="btnNewBTable" Text="Add New Key" runat="server" 
                 CssClass="Buttons" onclick="btnNewBTable_Click" />
            </td>
             <td>           
                &nbsp;</td>     
            <td  align="left" style="width: 448px">            
                <asp:Button ID="btnChkinkey" Text="Check In Key" runat="server" 
                 CssClass="Buttons" onclick="btnChkinkey_Click"/>
            </td>
            
            
     </tr>
    </table>
</div>
    <br />
 </div>
</asp:Content>
