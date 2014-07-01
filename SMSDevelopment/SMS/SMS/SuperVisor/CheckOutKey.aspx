<%@ Page Language="C#" MasterPageFile="~/SMSmaster.Master" AutoEventWireup="true" CodeBehind="CheckOutKey.aspx.cs" Inherits="SMS.SuperVisor.CheckOutKey"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <div class="divContainer">
     <div class="divHeader"><span class="pageTitle">Check Out Key</span></div>
       
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
                                            <tr> 
                                                    <td>
                                                        <asp:Label ID="lblbunchno" Text="Bunch No." CssClass="Labels" runat="server"></asp:Label></td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlbunchno" runat="server" CssClass="Input" Width="130px">
                                                        </asp:DropDownList>
                                                     </td>
                                            </tr>
                                            <tr>
                                                   <td height="20px">
                                                   </td>
                                            </tr>
                                            <tr>
                                                  <td align="center" colspan="5">
                                                    <asp:Button ID="btnSearchKeyAdd" Text="Check Out Key" runat="server" 
                                                          CssClass="Buttons" onclick="btnSearchKeyAdd_Click" 
                                                           />&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Button ID="btnClearKeyAdd" Text="Clear" runat="server" CssClass="Buttons" 
                                                          Width="100px" onclick="btnClearKeyAdd_Click"/>
                                                  </td>                        
                                           </tr>
                   </table>
          <br />
       </div>


</asp:Content>
