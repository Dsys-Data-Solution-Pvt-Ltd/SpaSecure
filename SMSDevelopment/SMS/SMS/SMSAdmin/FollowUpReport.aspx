<%@ Page Language="C#" MasterPageFile="~/SMSmaster.Master" AutoEventWireup="true" CodeBehind="FollowUpReport.aspx.cs" Inherits="SMS.SMSAdmin.FollowUpReport" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="divContainer" style="background-color: #FFFFFF">
        <div class="divHeader">
            <span class="pageTitle">Incident Follow-Up Report</span></div>           
          
          <br/>
           <div id="divAdvSearch" runat="server" visible="true">
           <asp:Panel ID="printview" runat="server" > 
            <table width="100%" cellspacing="10px">
                <tr>
                    <td align="center" colspan="4" height="70px" valign="top">
                         <asp:Label ID="lblIncidentReport" Text="Follow-Up/ Investigation Report" CssClass="Labels" 
                             runat="server" Font-Bold="True" Font-Size="20px" ForeColor="Black"></asp:Label>
                    
                    </td>
               </tr>
            
                <tr>                
                    <td>
                          <asp:Label ID="lblReportno" Text="Ref. Report No. :" CssClass="Reportcolor" 
                              runat="server" Font-Bold="True"></asp:Label>
                   </td> 
                    <td>
                         <asp:Label ID="txtReportno"  CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>  
                   
                    <td>
                         <asp:Label ID="lbldate" Text="Incident Date :" CssClass="Reportcolor" 
                             runat="server" Font-Bold="True"></asp:Label>
                   </td> 
                    <td>
                        <asp:Label ID="txtdate" CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>   
                                                  
               </tr>
               <tr>                              
              
                    <td>
                         <asp:Label ID="lblTime" Text="Incident Time :" CssClass="Reportcolor" 
                             runat="server" Font-Bold="True"></asp:Label>
                   </td> 
                    <td>
                        <asp:Label ID="txttime"  CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>                                 
               </tr>
              
               <tr>
                    <td valign="top">
                         <asp:Label ID="lblstatement" Text="Report/ Statement :" CssClass="Reportcolor" 
                             runat="server" Font-Bold="True"></asp:Label>
                   </td> 
                    <td colspan="3" height="500px" valign="top">
                        <asp:Label ID="txtstatement" CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>    
               </tr>
               
               
               
               
               
                <tr>
                    <td>
                         <asp:Label ID="lblInvestigationBy" Text="Investigation By :" CssClass="Reportcolor" 
                             runat="server" Font-Bold="True"></asp:Label>
                   </td> 
                    <td>
                        <asp:Label ID="txtInvestigationby"  CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>  
                   <td>
                         <asp:Label ID="lblVerifiedby" Text="Verified By :" CssClass="Reportcolor" 
                             runat="server" Font-Bold="True"></asp:Label>
                   </td> 
                    <td>
                        <asp:Label ID="txtVerifiedby"  CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>  
                   
                                                  
               </tr>
              
                <tr>
                    <td height="55px">
                   
                   </td> 
                </tr>

         </table>
      </asp:Panel>
           
       <div align="center">
                    
                        <asp:Button ID="btnprint" runat="server" CssClass="Buttons" Text="Print" 
                          Width="110px" Height="35px" onclick="btnprint_Click" Font-Bold="True"/> 
       </div>    
           
           
     </div>
  </div>

</asp:Content>
