<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="AddNewOffLeave.aspx.cs" Inherits="SMS.SuperVisor.AddNewOffLeave"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="divContainer">
      <div class="divHeader">
         <span class="pageTitle">Add New Off/ Leave Setting</span></div>
             <div>                        
               <asp:Label id="lblerror" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"></asp:Label>
             </div>
            <br />          
           <div id="divAdvSearch" runat="server" visible="true">
                       <asp:panel runat="server" ID="Panel1" BackColor="White" 
                            style=" margin-left:1.5em" Font-Bold="True" width="750">
            <table width="700" class="table">
            <tr><td height="10"></td></tr>
            <tr>
            <td>
                                                        <asp:Label ID="Label1" CssClass="Labels" runat="server" 
                                                             Text="Add New Type of Leave"></asp:Label>
                                                    </td>
                                                    
                                                    <td>
                                                         <asp:TextBox ID="txtaddTypeOfLeave" runat="server" CssClass="Input" /> 
                                                         &nbsp;&nbsp;&nbsp;&nbsp;
                                                         
                                                        <asp:Button ID="btnAddNewType" runat="server" Text="Add " 
                                                             CssClass="Buttons" onclick="btnAddNewType_Click" />
                                                         
                                                    </td>
                                            </tr><tr><td height="10"></td></tr>                                           
                                            
                                            <tr>
                                                  <td>
                                                        <asp:Label ID="lblStaffname" CssClass="Labels" runat="server" Text="Staff Name"></asp:Label>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:DropDownList ID="ddlStaffname" runat="server" CssClass="Input" 
                                                            Width="250px">
                                                        </asp:DropDownList> 
                                                    </td>
                                            </tr><tr><td height="10"></td></tr>
                                            <tr>
                                                   <td>
                                                        <asp:Label ID="lblTypeOfLeave" CssClass="Labels" runat="server" Text="Type of Leave"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlTypeOfLeave" runat="server" CssClass="Input" 
                                                            Width="130px">
                                                        </asp:DropDownList> 
                                                    </td>
                                                    
                                                     
                                            </tr><tr><td height="10"></td></tr>
                                            <tr>
                                                   <td>
                                                        <asp:Label ID="lblNoOfday" CssClass="Labels" runat="server" Text="No. of days"></asp:Label>
                                                    </td>
                                                    <td>
                                                      <asp:TextBox ID="txtNoOfday" runat="server" CssClass="Input" /> 
                                                    </td>
                                            </tr><tr><td height="10"></td></tr>
                                            <tr>
                                                   <td>
                                                        <asp:Label ID="Label2" CssClass="Labels" runat="server" Text="Superior Officer"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtsuperiorOfficer" runat="server" CssClass="Input" /> 
                                                    </td>
                                            </tr>
                                                        
                            <tr>
                                 <td height="80px" colspan="3">
                                </td>
                            </tr>
                            </table>
                            <table  width="100%" style="margin-left:0.01em; margin-bottom:-0.4em;border:1px;border-style:groove; border-color:Black;background: url(../Images/1397d40aa687.jpg)">
                            <tr>
                            
                                    <td colspan="4" align="center" >
                                         <asp:Button ID="btnNewItemAdd" runat="server" CssClass="Buttons" 
                                             Text="Add" Width="85px" onclick="btnNewItemAdd_Click"/>
                                           &nbsp;&nbsp; &nbsp;&nbsp;              
                                          <asp:Button ID="btnClearNewItemAdd" runat="server" CssClass="Buttons" 
                                            Text="Cancel" Width="85px" onclick="btnClearNewItemAdd_Click"/>
                                     </td>
                           </tr>
                   </table>
                   </asp:panel>
           </div>
    <br/>     
 </div>

</asp:Content>
