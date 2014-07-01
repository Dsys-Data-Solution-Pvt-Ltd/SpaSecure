<%@ Page Language="C#" MasterPageFile="../SMSmaster.Master" AutoEventWireup="true" CodeBehind="AlertHandling.aspx.cs" Inherits="SMS.SMSUsers.AlertHandling" Title="TSP Secure" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div class="divContainer">
      <div class="divHeader">
         <span class="pageTitle">Alert Handling</span></div>
           <div>
                        
                          <asp:Label id="lblerror" runat="server" ForeColor="Red" Font-Bold="True" 
                             CssClass="ValSummary"></asp:Label>
                      </div>
            <br />          
           <div id="divAdvSearch" runat="server" visible="true">
                        <table width="700px">
                          
                                            <tr>
                                                    <td align="left">
                                                        <asp:Label ID="lblNRIC" Text="NRIC/FIN No." CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtAddNRIC" runat="server" CssClass="Input" />                                                     
                                                        <asp:Label ID="lblerr" CssClass="ValSummary" runat="server" Text="*" 
                                                        Font-Size="Smaller" ForeColor="Red"></asp:Label>
                                                    
                                                    
                                                    </td>
                                                      <td align="left">
                                                        <asp:Label ID="lblItemDesc" Text="Name" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtAddItemDesc" runat="server" CssClass="Input"/>                                                     
                                                    </td>
                                           </tr>
                                            <tr>      
                                                 
                                                    <td align="left">
                                                        <asp:Label ID="lblAlertType" Text="Alert Type" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlRole" runat="server" CssClass="Input" width="136px">
                                                      
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td align="left">
                                                  
                                                        <asp:Label ID="lblCompany" Text="Company" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtAddCompany" runat="server" CssClass="Input" />
                                                        
                                                    </td>
                                            </tr>
                                            
                                           
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lblVehicle" Text="Vehicle Registration No." CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtAddVehicle" runat="server" CssClass="Input"/>
                                                </td>
                                            </tr>                                               
                                            <tr>
                                                 <td valign="top" align="left">
                                                    <asp:Label ID="lblmessage" Text="Alert Message" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td colspan="3">
                                                    <asp:TextBox ID="txtmessage" runat="server" CssClass="Input" 
                                                        TextMode="Multiline" width="460px" Height="80px" />
                                                </td>
                                                
                                            </tr>
                      
                            <tr>
                                  <td height="45px" width="150px">
                                  </td>
                                  <td></td>
                            </tr>
                          
                                            <tr>
                                                    <td colspan="1">
                                                        <asp:Label ID="lblalertedby" runat="server" CssClass="Labels" Font-Bold="true" 
                                                            Text="Alerted By:"></asp:Label>
                                                    </td>
                                           </tr>
                                            <tr>
                                            
                                                     <td>
                                                        <asp:Label ID="lblbynric" runat="server" CssClass="Labels" Text="NRIC/FIN No."></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtbynric" runat="server" CssClass="Input" />
                                                        <asp:Label ID="lblerr1" CssClass="ValSummary" runat="server" Text="*" 
                                                        Font-Size="Smaller" ForeColor="Red"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblname" runat="server" CssClass="Labels" Text="Name"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtname" runat="server" CssClass="Input" />
                                                    </td>
                                                    
                                           </tr>
                                            <tr>        
                                                    
                                                    <td>
                                                        <asp:Label ID="lbldepartment" runat="server" CssClass="Labels" 
                                                            Text="Department"></asp:Label>
                                                    </td>
                                                    <td>
                                                        
                                                    <asp:DropDownList ID="ddlRole0" runat="server" CssClass="Input" width="132px">
                                                  
                                                    </asp:DropDownList>
                                                    </td>
                                                    
                                           
                                                     <td>
                                                        <asp:Label ID="lblphone" runat="server" CssClass="Labels" Text="Phone No."></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtphone" runat="server" CssClass="Input" />
                                                    </td>
                                              </tr>
                                              <tr>      
                                                    
                                                    <td>
                                                        <asp:Label ID="lbldesignation" runat="server" CssClass="Labels" 
                                                            Text="Designation"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtdesignation" runat="server" CssClass="Input" />
                                                    </td>
                                            </tr>
                      
                            <tr>
                                <td height="50px">
                                </td>
                            
                            </tr>
                            <tr>
                            
                                    <td align="Center" colspan="4" >
                                         <asp:Button ID="btnNewItemAdd" runat="server" CssClass="Buttons" 
                                          onclick="btnNewItemAdd_Click" Text="Enter" Width="85px" />
                                           &nbsp;&nbsp;&nbsp;              
                                          <asp:Button ID="btnClearNewItemAdd" runat="server" CssClass="Buttons" 
                                           onclick="btnClearNewItemAdd_Click" Text="Cancel" Width="85px"/>
                                     </td>
                           </tr>
                      </table>
                </div>
    <br/>     
 </div>
    
</asp:Content>
