<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="UpdateAdminAddItem.aspx.cs" Inherits="SMS.SuperVisor.UpdateAdminAddItem"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="divContainer">
  <div class="divHeader">
    <span class="pageTitle">Check In Item</span></div>
      <div id="divErr" runat="server">
          <asp:Label ID="lblErrMsg" CssClass="ValSummary" runat="server" Font-Bold="True" 
           ForeColor="Red"></asp:Label> </div>
          <asp:HiddenField ID="hdnBTID" runat="server" Value="" />
          <asp:HiddenField ID="hdnBTName" runat="server" Value="" />    
        
            <br />    
            <asp:panel runat="server" ID="Panel1" BackColor="White" 
                            style=" margin-left:1.5em" Font-Bold="True" 
        width="750px" Height="470px">      
           <div id="divAdvSearch" runat="server" visible="true">
                                                   
                       <table width="100%">
                                            <tr>
                                                <td colspan="1">
                                                    <asp:Label ID="lblItemID" Text="Item ID " CssClass="Labels" runat="server" 
                                                        Visible="False"></asp:Label>
                                                </td>
                                                 <td>
                                                    <asp:TextBox ID="txtItemID" runat="server" CssClass="Input" ReadOnly="True" 
                                                         Visible="False"/>
                                                </td>
                                            </tr>
                                            <tr>
                                            
                                                <td>
                                                    <asp:Label ID="lblItemName" Text="Item Name" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtItemName" runat="server" CssClass="Input"/>
                                                </td>
                                            
                                            
                                                <td>
                                                    <asp:Label ID="lblModelNo" Text="Model No." CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                               
                                                <td>
                                                    <asp:TextBox ID="txtModelNo" runat="server" CssClass="Input" Width="265px"/>
                                                </td>
                                                
                                          </tr>
                                          <tr>      
                                                
                                                <td>
                                                    <asp:Label ID="lblItemDescription" Text="Item Description" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td colspan="4">
                                                    <asp:TextBox ID="txtItemdescription" runat="server" CssClass="Input" 
                                                        Width="570px" />
                                                </td>
                                         </tr>
                                         
                                         
                                         
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblItemquantity" Text="Item Quantity" CssClass="Labels" 
                                                        runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtItemquantity" runat="server" CssClass="Input" />
                                                </td>
                                            </tr>
                                            
                                            <tr>
                                                 <td height="35px" colspan="5">
                                                 </td> 
                                            </tr>
                                            
                                            
                                             <tr>
                                                <td>
                                                     <asp:Label ID="lblIssuedTo" Text="Issued To :" CssClass="Labels" 
                                                         runat="server" Font-Bold="True"></asp:Label>
                                                </td>
                                            </tr> 
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblIssuedToNRIC" Text="NRIC/FIN No." CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                
                                                <td>
                                                    <asp:TextBox ID="txtIssuedToNRIC" runat="server" CssClass="Input" ReadOnly="True" 
                                                       />
                                                    <asp:Label ID="lblerr1" CssClass="ValSummary" runat="server" Text="*" 
                                                        Font-Size="Smaller" ForeColor="Red"></asp:Label>
                                                </td>                                            
                                                <td>
                                                    <asp:Label ID="lblIssuedToName" Text="Name" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtIssuedToName" runat="server" CssClass="Input" 
                                                        Width="266px" />
                                                     
                                                </td>
                                                
                                            </tr>
                                            <tr>
                                                    <td>
                                                        <asp:Label ID="lblIssuedToPosition" Text="Position" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtIssuedToPosition" runat="server" CssClass="Input"/>
                                                       
                                                     </td>
                                                                                                    
                                            </tr>
                                            <tr>
                                                    <td height="35px" colspan="5">
                                                    </td>
                                            </tr>
                                            
                                             <tr>
                                                <td>
                                                     <asp:Label ID="lblIssuedBy" Text="Issued By:" CssClass="Labels" 
                                                         runat="server" Font-Bold="True"></asp:Label>
                                                </td>
                                            </tr> 
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblIssuedByNRIC" Text="NRIC/FIN No." CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                
                                                <td>
                                                    <asp:TextBox ID="txtIssuedByNRIC" runat="server" CssClass="Input" ReadOnly="True" 
                                                       />
                                                    <asp:Label ID="errorIssuedByNRIC" CssClass="ValSummary" runat="server" Text="*" 
                                                        Font-Size="Smaller" ForeColor="Red"></asp:Label>
                                                </td>                                            
                                                <td>
                                                    <asp:Label ID="lblIssuedByName" Text="Name" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtIssuedByName" runat="server" CssClass="Input" 
                                                        Width="263px" />
                                                     
                                                </td>
                                                
                                            </tr>
                                            <tr>
                                                    <td>
                                                        <asp:Label ID="lblIssuedByPosition" Text="Position" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtIssuedByPosition" runat="server" CssClass="Input"/>
                                                       
                                                     </td>
                                                                                                    
                                            </tr>
                                            <tr>
                                                    <td valign="top">
                                                        <asp:Label ID="lblComment" Text="Comments" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="txtComment" runat="server" CssClass="Input" Height="55px" 
                                                            Width="627px" TextMode="MultiLine"/>
                                                       
                                                     </td>
                                                                                                    
                                            </tr>
                                             <tr>
                                                    <td>
                                                        <asp:Label ID="lblStatus" Text="Status" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="Input">
                                                          <asp:ListItem>Issued</asp:ListItem>
                                                          <asp:ListItem>Receive</asp:ListItem>
                                                        </asp:DropDownList>
                                                     </td>
                                                                                                    
                                            </tr>
                                            
                                            
                                           
                                    </table>
                                   
                   
          </div>
         <br/>  
         <br />
          
             <table width="100%" style="height:9px; background-color:Black; background: url(../Images/1397d40aa687.jpg)" >
                <tr>
        
                    <td align="Center" colspan="4" >
                                         <asp:Button ID="btnsave" runat="server" CssClass="Buttons" 
                                           Text="Save" Width="85px" onclick="btnsave_Click"/>
                                           &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;              
                                          <asp:Button ID="btnClear" runat="server" CssClass="Buttons" 
                                           Text="View All" Width="85px" onclick="btnClear_Click"/>
                        </td>                
                    </tr>       
               </table> 
              
               <br />
               <br />
                 </asp:panel>
                 
     </div>



</asp:Content>
