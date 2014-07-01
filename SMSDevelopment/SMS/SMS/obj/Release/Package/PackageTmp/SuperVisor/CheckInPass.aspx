<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="CheckInPass.aspx.cs" Inherits="SMS.SuperVisor.CheckInPass" Title="Check In Pass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="divContainer">
     <div class="divHeader"><span class="pageTitle">Check In Pass</span></div>
       
           <div><asp:Label id="lblerror" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"></asp:Label></div>                                     
            <br />  
           
                 <table width="100%">    
                                           
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblname" Text="Name" CssClass="Labels" runat="server"></asp:Label>                    
                                                </td>    
                                                <td>
                                                    <asp:TextBox ID="txtname" runat="server" CssClass="Input"/>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbldesignation" Text="Designation" CssClass="Labels" runat="server"></asp:Label>
                                                </td>   
                                                 <td>
                                                     <asp:TextBox ID="txtdesignation" runat="server" CssClass="Input"></asp:TextBox>
                                                </td> 
                                            </tr>
                                          
                                           
                                             <tr> 
                                                    <td>
                                                        <asp:Label ID="lblKeyNRIC" Text="NRIC No." CssClass="Labels" runat="server"></asp:Label></td>
                                                    <td>
                                                        <asp:TextBox ID="txtKeyNRIC" runat="server" CssClass="Input"/></td>
                                                   
                                                    <td>
                                                        <asp:Label ID="lblphone" Text="Contact No." CssClass="Labels" runat="server" ></asp:Label></td>                                                    
                                                    <td>
                                                        <asp:TextBox ID="txtphone" runat="server" CssClass="Input"/></td>
                                                
                                            </tr>
                                            
                                            <tr>
                                                   <td height="20px">
                                                   </td>
                                            </tr>
                                          <%--  
                                            <tr> 
                                                    <td>
                                                        <asp:Label ID="lblbunchno" Text="Bunch No." CssClass="Labels" runat="server"></asp:Label></td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlbunchno" runat="server" CssClass="Input" Width="130px">
                                                        </asp:DropDownList>
                                                     </td>
                                            </tr>--%>
                                            <tr>
                                                   <td height="20px">
                                                   </td>
                                            </tr>
                                            <tr>
                                                  <td align="center" colspan="5">
                                                    <asp:Button ID="btnSearchKeyAdd" Text="Check In Pass" runat="server" CssClass="Buttons" 
                                                          Width="100px"/>&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Button ID="btnClearKeyAdd" Text="Clear" runat="server" CssClass="Buttons" 
                                                          Width="100px"/>
                                                  </td>                        
                                               </tr>
                   </table>
                  
                  
            <br />
            
  <div>
    
    <asp:GridView ID="gvKeySearch" runat="server" 
            AllowPaging="True" AllowSorting="True" 
            AutoGenerateColumns="False" CellPadding="5" Width="100%"
            OnRowDataBound="gvNewKey_RowDataBound" 
           
            OnPageIndexChanging="gvNewKey_PageIndexChanging" CssClass="GridMain" 
            onselectedindexchanged="gvNewKey_SelectedIndexChanged">
            
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
            
            
                   <asp:BoundField DataField="Date_From" HeaderText="Check In Time"></asp:BoundField> 
                    <asp:BoundField DataField="Staff_ID" HeaderText="NRIC No."></asp:BoundField>
                    
                    <asp:BoundField DataField="Pass_No" HeaderText="Pass No."></asp:BoundField>
                  
              
               
                <%-- <asp:TemplateField HeaderText="Edit/View" ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center">
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
                </asp:TemplateField> --%>
                
            </Columns>
    </asp:GridView>
        </div>      
         <br />
         <br />
          
       </div>
</asp:Content>
