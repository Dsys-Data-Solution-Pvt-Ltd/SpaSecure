<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="ViewPreRegisterVisitorReport.aspx.cs" Inherits="SMS.SuperVisor.ViewPreRegisterVisitorReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">View Pre-Register Visitor Report</span></div>           
          
          <br/>
           <div id="divAdvSearch" runat="server" visible="true">
           <asp:panel runat="server" ID="printview" BackColor="White" 
                            style=" margin-left:1.5em" Font-Bold="True" width="750px">
            <table width="750px" class="table">
            </tr>
                <td align="center" colspan="4">
                    <asp:Image ID="image1" runat="server" style="Height:80px; width:100px" />
                    <hr style=" background-color:Black; color:Black; border-color:Black; width: 693px;">
                    </hr>
                </td>
                <tr>
                    <td align="center" colspan="4" height="70px" valign="top">
                         <asp:Label ID="lblIncidentReport" Text="Pre-Register Visitor Report" CssClass="Labels" 
                             runat="server" Font-Bold="True" Font-Size="20px" ForeColor="Black"></asp:Label>
                    
                    </td>
               </tr>
               <tr>                
                    <td>
                          <asp:Label ID="lbllocation" Text="Location" CssClass="Reportcolor" 
                              runat="server" Font-Bold="True"></asp:Label>
                   </td> 
                    <td colspan="3">
                         <asp:Label ID="txtlocation"  CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>  
                   
               </tr>
                  <tr>                
                    <td>
                          <asp:Label ID="lblInTime" Text="From Date" CssClass="Reportcolor" 
                              runat="server" Font-Bold="True"></asp:Label>
                   </td> 
                    <td colspan="3">
                         <asp:Label ID="txtInTime"  CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>  
                   
               </tr>
               <tr>    
                   
                    <td>
                         <asp:Label ID="lblOutTime" Text="To Date" CssClass="Reportcolor" 
                             runat="server" Font-Bold="True"></asp:Label>
                   </td> 
                    <td colspan="3">
                        <asp:Label ID="txtOutTime" CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>  
                                                  
               </tr>
                <tr>    
                   
                    <td>
                         <asp:Label ID="lblTime" Text="Time" CssClass="Reportcolor" 
                             runat="server" Font-Bold="True"></asp:Label>
                   </td> 
                    <td colspan="3">
                        <asp:Label ID="txtTime" CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>                          
               </tr>            
                <tr>                
                    <td>
                          <asp:Label ID="lblName" Text="Name" CssClass="Reportcolor" 
                              runat="server" Font-Bold="True"></asp:Label>
                   </td> 
                    <td colspan="3">
                         <asp:Label ID="txtname"  CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>  
                   
               </tr>
               <tr>    
                   
                    <td>
                         <asp:Label ID="lblCompany" Text="Company" CssClass="Reportcolor" 
                             runat="server" Font-Bold="True"></asp:Label>
                   </td> 
                    <td colspan="3">
                        <asp:Label ID="txtcompany" CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>   
                                                  
               </tr>
               <tr>                              
              
                    <td>
                         <asp:Label ID="lblposition" Text="Position" CssClass="Reportcolor" 
                             runat="server" Font-Bold="True"></asp:Label>
                   </td> 
                    <td colspan="3">
                        <asp:Label ID="txtposition"  CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>                                 
               </tr>
               
               <tr>                              
              
                    <td>
                         <asp:Label ID="lblVechicle" Text="Vehicle Registration" CssClass="Reportcolor" 
                             runat="server" Font-Bold="True"></asp:Label>
                   </td> 
                    <td colspan="3">
                        <asp:Label ID="txtvechicle"  CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>                                 
               </tr>
               <tr>                              
              
                    <td>
                         <asp:Label ID="Label3" Text="Purpose" CssClass="Reportcolor" 
                             runat="server" Font-Bold="True"></asp:Label>
                   </td> 
                    <td colspan="3">
                        <asp:Label ID="txtpurpose" CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>                                 
               </tr>
               
               
                <tr>                              
              
                    <td>
                         <asp:Label ID="lblinvited" Text="Invited By" CssClass="Reportcolor" 
                             runat="server" Font-Bold="True"></asp:Label>
                   </td> 
                    <td colspan="3">
                        <asp:Label ID="txtinviteby"  CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>                                 
               </tr>
                <tr>                              
              
                    <td>
                         <asp:Label ID="Label1" Text="Telephone" CssClass="Reportcolor" 
                             runat="server" Font-Bold="True"></asp:Label>
                   </td> 
                    <td colspan="3">
                        <asp:Label ID="txttelephone"  CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>                                 
               </tr>
               <tr>
                   <td height="25px">                   
                   </td>
               </tr>               
         </table>
      </asp:Panel>
      </div>
    
      
      <div class="table">
                 <table  width="750px" style="margin-left:0.1em; margin-bottom:-0.4em;border:1px;border-style:groove; border-color:Black;background: url(../Images/1397d40aa687.jpg)">
                   <tr>
                       <td colspan="4" align="center" style="width: 750px">
          <asp:Button ID="btnprint" runat="server" Text="Print" CssClass="Buttons" 
              Font-Bold="True" Height="35px" Width="110px" onclick="btnprint_Click"/> 
              <%--<asp:Label ID="lblid" runat="server" Visible="false"></asp:Label>     --%>
              </td></tr></table>
      </div>
     
  </div>
</asp:Content>
