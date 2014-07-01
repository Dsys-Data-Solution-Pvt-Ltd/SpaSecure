<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="ViewItem.aspx.cs" Inherits="SMS.SMSUsers.Reports.ViewItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Item Report</span></div>           
          
          <br/>
           <div id="divAdvSearch" runat="server" visible="true">
           <asp:Panel ID="printview" runat="server" BackColor="White" Width=750 style=" margin-left:1.5em" Font-Bold="True"> 
             <table width="85%" cellspacing="10">
             <tr>
            <td align="center" colspan="4">
                   <asp:Image runat="server" ID="image1" style="Height:80px; width:100px"></asp:Image>
                   <hr  style=" background-color:Black; color:Black; border-color:Black"></hr>
             </td>
            </tr>
                                            <tr>
                                                <td align="center" colspan="4" height="70px" valign="top">
                                                     <asp:Label ID="lblIncidentReport" Text="Item Report" CssClass="Labels" 
                                                       runat="server" Font-Bold="True" Font-Size="20px" ForeColor="Black">
                                                     </asp:Label>
                                                </td>
                                           </tr>
                                            <tr>
                                            
                                                <td>
                                                    <asp:Label ID="lblItemName" Text="ItemName" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtItemName" runat="server" CssClass="Labels"></asp:Label>
                                                </td>
                                            
                                            
                                                <td>
                                                    <asp:Label ID="lblModelNo" Text="Model No." CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                               
                                                <td>
                                                    <asp:Label ID="txtModelNo" runat="server" CssClass="Labels"></asp:Label>
                                                </td>
                                                
                                          </tr>
                                          <tr>  
                                                <td>
                                                    <asp:Label ID="lblItemDescription" Text="ItemDescription" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td colspan="4">
                                                     <asp:Label ID="txtItemdescription" runat="server"  Width="570px" CssClass="Labels"></asp:Label>   
                                                </td>
                                         </tr>
                                         
                                         
                                         
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblItemquantity" Text="Item Quantity" CssClass="Labels" 
                                                        runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtItemQty" runat="server" CssClass="Labels"></asp:Label>   
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
                                                    <asp:Label ID="txtIssuedNRIC" runat="server" CssClass="Labels"></asp:Label>   
                                                </td>                                            
                                                <td>
                                                    <asp:Label ID="lblIssuedToName" Text="Name" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                   <asp:Label ID="txtIssuedToName" runat="server" CssClass="Labels"></asp:Label>   
                                                     
                                                </td>
                                                
                                            </tr>
                                            <tr>
                                                    <td>
                                                        <asp:Label ID="lblIssuedToPosition" Text="Position" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="txtIssuedToPosition" runat="server" CssClass="Labels"></asp:Label>   
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
                                                   <asp:Label ID="txtIssuedByNRIC" runat="server" CssClass="Labels"></asp:Label>   
                                                </td>                                            
                                                <td>
                                                    <asp:Label ID="lblIssuedByName" Text="Name" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                   <asp:Label ID="txtIssuedByName" runat="server" CssClass="Labels"></asp:Label>   
                                                </td>
                                                
                                            </tr>
                                            <tr>
                                                    <td>
                                                        <asp:Label ID="lblIssuedByPosition" Text="Position" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="txtIssuedByPosition" runat="server" CssClass="Labels"></asp:Label>   
                                                     </td>
                                                                                                    
                                            </tr>
                                            <tr>
                                                    <td valign="top">
                                                        <asp:Label ID="lblComment" Text="Comments" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="5" height="150" valign="top">
                                                       <asp:Label ID="txtComments" runat="server" CssClass="Labels"></asp:Label>   
                                                     </td>
                                                                                                    
                                            </tr>
                                            
                                             <tr>
                                                <td>
                                                     <asp:Label ID="lblStatus" Text="Status :" CssClass="Labels" runat="server" Font-Bold="True"></asp:Label>
                                                </td>
                                                 <td>
                                                        <asp:Label ID="txtStatus" runat="server" CssClass="Labels"></asp:Label>   
                                                </td>
                                                
                                            </tr> 
                                            
                                            
                                           
                                    </table>
      </asp:Panel>
      <br />
      
      <div align="center">
           <asp:panel ID="btnpanel" runat="server" Width="129%" style=" background:url(../../Images/1397d40aa687.jpg); margin-left:1.5em; margin-top:-1.4em">    

          <asp:Button ID="btnprint" runat="server" Text="Print" CssClass="Buttons" 
              Font-Bold="True" Height="35px" Width="110px" onclick="btnprint_Click"/>
      </asp:Panel>
      </div>
     </div>
  </div>
</asp:Content>
