<%@ Page Title="" Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="View LostFound.aspx.cs" Inherits="SMS.SMSUsers.Reports.View_LostFound" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Item Report</span></div>           
          
          <br/>
           <div id="divAdvSearch" runat="server" visible="true">
          <asp:panel runat="server" ID="printview" BackColor="White" style=" margin-left:1.5em" Font-Bold="True" width="750">
            <table width="750px" class="table">            
            
            <tr>
            <td align="center" colspan="4">
                   <asp:Image runat="server" ID="image1" style="Height:80px; width:100px"></asp:Image>
                   <hr  style=" background-color:Black; color:Black; border-color:Black; width: 702px;"></hr>
             </td>
            </tr>
                                            <tr>
                                                <td align="center" colspan="4" height="70px" valign="top">
                                                     <asp:Label ID="lblIncidentReport" Text="Lost/Found Report" CssClass="Labels" 
                                                       runat="server" Font-Bold="True" Font-Size="20px" ForeColor="Black">
                                                     </asp:Label>
                                                </td>
                                           </tr>
                                            <tr>
                                            
                                                <td>
                                                    <asp:Label ID="lblName" runat="server" CssClass="Labels" Text="Name"></asp:Label>
                                                    
                                                </td>
                                                <td>
                                                <asp:Label ID="txtName1" runat="server" CssClass="Labels" runat="server" ></asp:Label>
                                                   
                                                </td>
                                            
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblLocation" Text="Location" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                               
                                                <td>
                                                    <asp:Label ID="txtLocation" runat="server" CssClass="Labels"></asp:Label>
                                                </td>
                                                </tr>
                                          </tr>
                                          <tr>  
                                                <td>
                                                    <asp:Label ID="lblDescription" Text="Description" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td colspan="4">
                                                     <asp:Label ID="txtIdescription" runat="server"  Width="570px" CssClass="Labels"></asp:Label>   
                                                </td>
                                         </tr>
                                         
                                         
                                         
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblConNo" Text="Contect No." CssClass="Labels" 
                                                        runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtConNo" runat="server" CssClass="Labels"></asp:Label>   
                                                </td>
                                            </tr>
                                                <tr>
                                                <td>
                                                    <asp:Label ID="lblNRIC" Text="NRIC/FIN No." CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                
                                                <td>
                                                    <asp:Label ID="txtNRIC" runat="server" CssClass="Labels"></asp:Label>   
                                                </td>  
                                                
                                            </tr>
                                            <tr>
                                                    <td>
                                                        <asp:Label ID="lblDate" Text="Date" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="txtDate" runat="server" CssClass="Labels"></asp:Label>   
                                                     </td>
                                                                                                    
                                            </tr>
                                            <tr>                                          
                                                <td>
                                                    <asp:Label ID="lblTime" Text="Time" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                   <asp:Label ID="txtTime" runat="server" CssClass="Labels"></asp:Label>   
                                                     
                                                </td>
                                                </tr>
                                            
                                             
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblNameOfReporting" runat="server" CssClass="Labels" 
                                                        Text="Name Of Reporting "></asp:Label>
                                                </td>                                                
                                                <td>
                                                    <asp:Label ID="txtNameOfReporting" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                            
                                                
                                            </tr>
                                            <tr>
                                                    <td>
                                                        <asp:Label ID="lblStatus" runat="server" CssClass="Labels" Text="Status"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="txtStatus" runat="server" CssClass="Labels"></asp:Label>
                                                     </td>
                                                                                                    
                                            </tr>
                                             
                                            
                                           
                                    </table>
      </asp:Panel>
      <br />
      
      <div align="center">
           <asp:panel ID="btnpanel" runat="server" style=" background:url(../../Images/1397d40aa687.jpg); margin-left:1.5em; margin-top:-1.4em; width:750px">    

          <asp:Button ID="btnprint" runat="server" Text="Print" CssClass="Buttons" 
              Font-Bold="True" Height="35px" Width="110px" onclick="btnprint_Click"/>
      </asp:Panel>
      </div>
     </div>
  </div>
</asp:Content>
