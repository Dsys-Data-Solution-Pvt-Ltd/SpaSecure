<%@ Page Language="C#" MasterPageFile="~/SMSmaster.Master" AutoEventWireup="true" CodeBehind="ViewContigencyExercise.aspx.cs" Inherits="SMS.SuperVisor.ViewContigencyExercise"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="divContainer" style="background-color: #FFFFFF">
        <div class="divHeader">
            <span class="pageTitle">Contigency Exercise</span></div>           
          
          <br/>
           <div id="divAdvSearch" runat="server" visible="true">
           <asp:Panel ID="printview" runat="server" > 
         
            <table width="100%" cellspacing="10px">
                <tr>
                    <td align="center" colspan="4" height="70px" valign="top">
                         <asp:Label ID="lblIncidentReport" Text="Contigency Exercise" CssClass="Labels" 
                             runat="server" Font-Bold="True" Font-Size="20px" ForeColor="Black"></asp:Label>
                    
                    </td>
               </tr>
            
                <tr>                
                    <td>
                          <asp:Label ID="lbllocation" Text="Location" CssClass="Reportcolor" 
                              runat="server" Font-Bold="True"></asp:Label>
                   </td> 
                    <td>
                         <asp:Label ID="txtlocation"  CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>  
                   <td>
                          <asp:Label ID="lblExecerType" Text="Exercise Type" CssClass="Reportcolor" 
                              runat="server" Font-Bold="True"></asp:Label>
                   </td> 
                    <td>
                         <asp:Label ID="Label2"  CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>  
                   
                   
               </tr>
               <tr>    
                    <td>
                         <asp:Label ID="lblDate" Text="Date" CssClass="Reportcolor" 
                             runat="server" Font-Bold="True"></asp:Label>
                   </td> 
                    <td>
                        <asp:Label ID="txtDate" CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>   
                                                  
               </tr>
               
                <%--<tr>                
                    <td>
                          <asp:Label ID="lblLocation" Text="Location" CssClass="Reportcolor" 
                              runat="server" Font-Bold="True"></asp:Label>
                   </td> 
                    <td>
                         <asp:Label ID="txtLocation"  CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>  
                   
               </tr>--%>
               <tr>    
                   
                    <td>
                         <asp:Label ID="lblAttendees" Text="Attendees" CssClass="Reportcolor" 
                             runat="server" Font-Bold="True"></asp:Label>
                   </td> 
                    <td colspan="3">
                        <asp:Label ID="txtAttendees" CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>
               </tr>
               <tr>         
                    <td valign="top">
                         <asp:Label ID="lblBriefingDetail" Text="Detail" CssClass="Reportcolor" 
                             runat="server" Font-Bold="True"></asp:Label>
                   </td> 
                    <td height="85px" valign="top" colspan="3">
                        <asp:Label ID="txtDetail" CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>   
                                                  
               </tr>
               
                <tr>    
                   
                    <td>
                         <asp:Label ID="lblConducted_By" Text="Conducted By" CssClass="Reportcolor" 
                             runat="server" Font-Bold="True"></asp:Label>
                   </td> 
                    <td colspan="3">
                        <asp:Label ID="txtConductedBy" CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>   
                   
                </tr>
                <tr>   
                    <td valign="top">
                         <asp:Label ID="lblActionDate" Text="Action Date" CssClass="Reportcolor" 
                             runat="server" Font-Bold="True"></asp:Label>
                   </td> 
                    <td colspan="3">
                        <asp:Label ID="txtActionDate" CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>   
                                                  
               </tr>
               
               <tr>   
                    <td valign="top">
                         <asp:Label ID="lblComment" Text="Comments" CssClass="Reportcolor" 
                             runat="server" Font-Bold="True"></asp:Label>
                   </td> 
                    <td colspan="3" height="75px" valign="top">
                        <asp:Label ID="txtComment" CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>   
                                                  
               </tr>
               
               
               
              <tr>     
                    <td class="style1">
                         <asp:Label ID="lblReportedTO" Text="Reported To" CssClass="Reportcolor" 
                             runat="server" Font-Bold="True"></asp:Label>
                   </td>                    
                    <td colspan="3">
                        <asp:Label ID="txtReportto"  CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>     
               </tr>
               <tr>    
                   <td class="style1">
                         <asp:Label ID="lblPosition" Text="Position" CssClass="Reportcolor" 
                             runat="server" Font-Bold="True"></asp:Label>
                   </td>                    
                    <td colspan="3">
                        <asp:Label ID="txtPosition"  CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>     
                   
                                               
               </tr>
              
              
                <tr>
                    <td height="55px" colspan="4">
                   
                   </td> 
                </tr>

         </table>
       
        </asp:Panel>
           
       <div align="center">
                    <asp:Button ID="btnprint" runat="server" CssClass="Buttons" Text="Print" 
                    Width="110px" Height="35px" Font-Bold="True"/> 
       </div>    
           
           
     </div>
  </div>

</asp:Content>
