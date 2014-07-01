<%@ Page Language="C#" MasterPageFile="~/SMSmaster.Master" AutoEventWireup="true" CodeBehind="OffLeaveReport.aspx.cs" Inherits="SMS.SuperVisor.OffLeaveReport"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="divContainer" style="background-color: #FFFFFF">
        <div class="divHeader">
            <span class="pageTitle">OFF/ Leave Application</span></div>           
          
          <br/>
           <div id="divAdvSearch" runat="server" visible="true">
           <asp:Panel ID="printview" runat="server" > 
            <table width="100%" cellspacing="10px">
                <tr>
                    <td align="center" colspan="4" height="70px" valign="top">
                         <asp:Label ID="lblIncidentReport" Text="OFF/ LEAVE APPLICATION FORM" CssClass="Labels" 
                             runat="server" Font-Bold="True" Font-Size="20px" ForeColor="Black"></asp:Label>
                    
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
                         <asp:Label ID="lblNRIC" Text="NRIC No." CssClass="Reportcolor" 
                             runat="server" Font-Bold="True"></asp:Label>
                   </td> 
                    <td colspan="3">
                        <asp:Label ID="txtNRIC" CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>   
                                                  
               </tr>
               <tr>                              
              
                    <td>
                         <asp:Label ID="lblAssignment" Text="Assignment" CssClass="Reportcolor" 
                             runat="server" Font-Bold="True"></asp:Label>
                   </td> 
                    <td colspan="3">
                        <asp:Label ID="txtAssignment"  CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>                                 
               </tr>
               
                <tr>                              
              
                    <td>
                         <asp:Label ID="lblDateofApplication" Text="Date of Application" CssClass="Reportcolor" 
                             runat="server" Font-Bold="True"></asp:Label>
                   </td> 
                    <td colspan="3">
                        <asp:Label ID="txtDateofApplication"  CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>                                 
               </tr>
               
                <tr>                              
              
                    <td>
                         <asp:Label ID="lblLeaveFrom" Text="Leave Application Period  :From" CssClass="Reportcolor" 
                             runat="server" Font-Bold="True"></asp:Label>
                   </td> 
                    <td>
                        <asp:Label ID="txtLeaveFrom"  CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>   
                   <td>
                         <asp:Label ID="lblLeaveTo" Text="To" CssClass="Reportcolor" 
                             runat="server" Font-Bold="True"></asp:Label>
                   </td> 
                    <td>
                        <asp:Label ID="txtLeaveTo"  CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>  
                                                 
               </tr>
              <tr>                              
                    <td>
                         <asp:Label ID="Label1" Text="Approved Superior Name" CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                   </td> 
                    <td>
                        <asp:Label ID="txtsuperiorname"  CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>  
              </tr>
              
                <tr>
                   <td height="25px" colspan="4">
                   
                   </td>
               </tr>
                <tr>                              
              
                    <td>
                         <asp:Label ID="lblApproved" Text="Approved Status" CssClass="Reportcolor" 
                             runat="server" Font-Bold="True"></asp:Label>
                   </td> 
                    <td>
                        <asp:Label ID="txtApproved"  CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>                                 
               </tr>
                          
                <tr>
                    <td height="55px" colspan="3">
                   
                   </td> 
                </tr>

         </table>
      </asp:Panel>
      <br />
      
      <div align="center">
      
          <asp:Button ID="btnprint" runat="server" Text="Print" CssClass="Buttons" 
              Font-Bold="True" Height="35px" onclick="btnprint_Click" Width="110px" />
      
      </div>
      
           
      
           
     </div>
  </div>


</asp:Content>
