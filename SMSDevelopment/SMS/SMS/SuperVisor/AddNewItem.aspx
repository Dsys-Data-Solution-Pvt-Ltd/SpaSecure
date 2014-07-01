<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="AddNewItem.aspx.cs" Inherits="SMS.SuperVisor.AddNewItem"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Check Out Item</span></div>
            <div>            
                  <asp:Label id="lblerror" runat="server" ForeColor="Red" Font-Bold="True" 
                      CssClass="ValSummary"></asp:Label>
            </div>  
            <br />
            <div id="divAdvSearch" runat="server" visible="true">   
            
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                   <ContentTemplate>
                                                    
                       <asp:panel runat="server" ID="Panel1" BackColor="White" 
                            style=" margin-left:1.5em" Font-Bold="True" width="700px">
            <table width="700px" class="table">
            
                                            <tr>
                                                <td colspan="5">
                                                    <asp:Label ID="lblItem" Text=" " CssClass="Labels" runat="server" 
                                                        Font-Bold="True" ></asp:Label>
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
                                                    <asp:TextBox ID="txtModelNo" runat="server" CssClass="Input" Width="230px"/>
                                                </td>
                                                
                                          </tr>
                                          <tr>      
                                                
                                                <td>
                                                    <asp:Label ID="lblItemDescription" Text="Item Description" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td colspan="4">
                                                    <asp:TextBox ID="txtItemdescription" runat="server" CssClass="Input" 
                                                        Width="500px" />
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
                                                    <asp:TextBox ID="txtIssuedToNRIC" runat="server" CssClass="Input" 
                                                        AutoPostBack="True" ontextchanged="txtIssuedToNRIC_TextChanged"/>
                                                    <asp:Label ID="lblerr1" CssClass="ValSummary" runat="server" Text="*" 
                                                        Font-Size="Smaller" ForeColor="Red"></asp:Label>
                                                </td>                                            
                                                <td>
                                                    <asp:Label ID="lblIssuedToName" Text="Name" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtIssuedToName" runat="server" CssClass="Input" 
                                                        Width="230px" />
                                                     
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
                                                    <asp:TextBox ID="txtIssuedByNRIC" runat="server" CssClass="Input" 
                                                        AutoPostBack="True" ontextchanged="txtIssuedByNRIC_TextChanged"/>
                                                    <asp:Label ID="errorIssuedByNRIC" CssClass="ValSummary" runat="server" Text="*" 
                                                        Font-Size="Smaller" ForeColor="Red"></asp:Label>
                                                </td>                                            
                                                <td>
                                                    <asp:Label ID="lblIssuedByName" Text="Name" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtIssuedByName" runat="server" CssClass="Input" 
                                                        Width="230px" />
                                                     
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
                                                        <asp:TextBox ID="txtComment" runat="server" CssClass="Input" Height="45px" 
                                                            Width="500px" TextMode="MultiLine"/>
                                                     </td>                              
                                         </tr>
                                         <tr><td height="65" colspan="5"></td></tr>                        
                                    </table>
                                    </asp:panel>
                    </ContentTemplate>    
                  </asp:UpdatePanel>      
                                    <br /><br />
                              <div class="table">     
                               <table  width="700px" style="margin-left:0.1em; margin-bottom:-0.4em;border:1px;border-style:groove; border-color:Black;background: url(../Images/1397d40aa687.jpg)">
                                                  <tr>
                                                  <td colspan="4" align="center" width="700px">
                                                    <asp:Button ID="btnItemAdd" runat="server" CssClass="Buttons" 
                                                        Text="Save" Width="85px" onclick="btnItemAdd_Click" />
                                                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="btnClearItemAdd" runat="server" CssClass="Buttons" 
                                                        Text="Cancel" Width="85px" />
                                                </td>
                                            </tr>
                                </table></div> 
             <br />
          </div>
    </div>
</asp:Content>
