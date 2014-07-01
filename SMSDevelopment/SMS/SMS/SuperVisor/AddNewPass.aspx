<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="AddNewPass.aspx.cs" Inherits="SMS.SuperVisor.PassMgt" Title="Add New Pass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Add New Pass</span></div>
              
        <div>
            <asp:Label id="lblerror" runat="server" ForeColor="Red" Font-Bold="True" 
                CssClass="ValSummary"></asp:Label>
        </div>
        <br /> 
        <div id="divAdvSearch" runat="server" visible="true">  <br /> 
                       <asp:panel runat="server" ID="Panel1" BackColor="White" 
                            style=" margin-left:1.5em" Font-Bold="True" width="750px">
            <table width="750" class="table">
            <tr><td></td></tr><tr><td></td></tr>
                                             <tr>
                                                <td>
                                                    <asp:Label ID="lblEnterPassNumber" Text="Pass No." CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                
                                                 <td style="width: 275px">
                                                     <asp:TextBox ID="txtAddNoType" runat="server" CssClass="Input" />
                                                     <asp:Label ID="lblerr1" CssClass="ValSummary" runat="server" Text="*" 
                                                     Font-Size="Smaller" ForeColor="Red"></asp:Label>
                                                     
                                                 </td>
                                                 <td>
                                                        <asp:Label ID="lblLocation" Text="Location" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddllocation" runat="server" CssClass="Labels"></asp:DropDownList>   
                                                            <asp:Label ID="SearchLocID" runat="server" Visible="False" CssClass="Input"></asp:Label>                    
                                                    </td>
                                                                                
                                               
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblEnterPass" Text="Pass Type" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td style="width: 275px">
                                                    <asp:DropDownList ID="ddlAddPassType" runat="server" CssClass="Labels" 
                                                        Height="23px" Width="118px"> 
                                                    </asp:DropDownList>
                                                    <asp:Label ID="lblerr5" CssClass="ValSummary" runat="server" Text="*" 
                                                     Font-Size="Smaller" ForeColor="Red"></asp:Label>
                                                </td>
                                                </tr>
                                                <tr>
                                                <td>   
                                                    <asp:label ID="lblAddPassType" runat="server" CssClass="Labels" Text="Add Pass Type"/>
                                                                                
                                                </td>
                                                <td style="width: 275px">
                                                    <asp:TextBox ID="txtAddPassType" runat="server" CssClass="Input" Height="20px" 
                                                        Width="118px" />
                                                    <asp:Label ID="lblerr3" CssClass="ValSummary" runat="server" Text="*" 
                                                     Font-Size="Smaller" ForeColor="Red"></asp:Label>
                                                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <%--</td>
                                                <td>--%>
                                                    <asp:Button ID="btnAdd1" Text="Add Type" runat="server" 
                                                        CssClass="Buttons" onclick="btnAdd1_Click" Height="29px" Width="108px"/>
                                                </td>
                                            </tr> 
                                            
                                            <tr>
                                                <td valign="top">
                                                    <asp:Label ID="lblpassDescription" Text="Pass Description" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td colspan="4">
                                                    <asp:TextBox ID="txtPassDecription" runat="server" CssClass="Input" 
                                                        TextMode="Multiline" height="73px" Width="525px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                  <td height="45px">
                                                  <asp:TextBox ID="txtstatus" runat="server" CssClass="Input" Visible="False" 
                                                   Width="45px">Free</asp:TextBox>
                                                  </td>
                                            </tr>
                                          <tr>  
                                              <td colspan="6" style="border: none">
                                        <asp:UpdatePanel ID="updPerson" runat="server">
                                            <ContentTemplate>
                                                <table width="100%">
                                          
                                          <tr>
                                                   <td colspan="2">
                                                       <asp:Label ID="lblKeySign" runat="server" CssClass="Labels" 
                                                        Text="Pass Generated By:" font-Bold="True"></asp:Label>
                                                  </td>
                                         </tr>
                                          <tr>
                                                    <td><asp:Label ID="lblKeyNRIC" Text="NRIC No." CssClass="Labels" runat="server"></asp:Label> </td>
                                                    <td><asp:TextBox ID="txtKeyNRIC" runat="server" CssClass="Input" 
                                                            AutoPostBack="True" ontextchanged="txtKeyNRIC_TextChanged"/>
                                                       <asp:Label ID="lblerr2" CssClass="ValSummary" runat="server" Text="*" 
                                                     Font-Size="Smaller" ForeColor="Red"></asp:Label> </td> 
                                                                                               
                                                     <td><asp:Label ID="lblKeyName" Text="Name" CssClass="Labels" runat="server"></asp:Label>   </td>
                                                    <td><asp:TextBox ID="txtKeyName" runat="server" CssClass="Input" ReadOnly="True" 
                                                            Width="285px"/> </td>
                                            
                                          </tr>
                                          <tr>
                                                 <td><asp:Label ID="lblposition" Text="Position" CssClass="Labels" runat="server"></asp:Label>   </td>
                                                 <td><asp:TextBox ID="txtposition" runat="server" CssClass="Input" ReadOnly="True"/> </td>
                                            
                                            
                                          </tr>
                                                            
                                               </table>
                                             </ContentTemplate>
                                           </asp:UpdatePanel>
                                         </td>
                                       </tr>                     
                                                                                  
                                            <tr>  
                                                 <td height="130">
                                                </td>
                                            </tr>
                                            <table  width="700px" style="margin-left:0.1em; margin-bottom:-0.4em;border:1px;border-style:groove; border-color:Black;background: url(../Images/1397d40aa687.jpg)">
                                            <tr>
                                            <td colspan="4" align="center" width="700px">
                                                    <asp:Button ID="btnSearchPassAdd" Text="Add" runat="server" 
                                                        CssClass="Buttons" Width="85px" onclick="btnSearchPassAdd_Click" />
                                                     &nbsp;&nbsp; &nbsp;&nbsp;<asp:Button ID="btnClearPassAdd" Text="Cancel" runat="server" 
                                                        CssClass="Buttons" Width="85px" onclick="btnClearPassAdd_Click" />
                                                   </td>
                                            </tr>
                                            </table>
                               </table>
                   </asp:panel>
                   </div>
       <br />
    </div>
  <br />  


</asp:Content>
