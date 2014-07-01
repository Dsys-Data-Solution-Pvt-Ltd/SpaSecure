<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="IncidentReportadmin.aspx.cs" Inherits="SMS.Reports.IncidentReportadmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Incident Report</span></div> 
          <br/>
           <div id="divAdvSearch" runat="server" visible="true">
           <asp:Panel ID="printview" runat="server" BackColor="White" style=" margin-left:1.5em" Font-Bold="True"> 
            <table width="100%" cellspacing="10px">
            <tr>
            <td align="center" colspan="4">
                   <asp:Image runat="server" ID="image1" style="Height:80px; width:100px"></asp:Image>
                   <hr  style=" background-color:Black; color:Black; border-color:Black"></hr>
             </td>
            </tr>
                <tr>
                    <td align="center" colspan="4" height="70px" valign="top">
                         <asp:Label ID="lblIncidentReport" Text="Incident Report" CssClass="Labels" 
                             runat="server" Font-Bold="True" Font-Size="20px" ForeColor="Black"></asp:Label>
                    
                    </td>
               </tr>
                <tr>
                    <td>
                          <asp:Label ID="lblReportno" Text="Report No. :" CssClass="Reportcolor" 
                              runat="server" Font-Bold="True"></asp:Label>
                   </td> 
                    <td>
                         <asp:Label ID="txtReportno"  CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>                                 
               </tr>
               <tr>
                    <td>
                         <asp:Label ID="lbldate" Text="Incident Date :" CssClass="Reportcolor" 
                             runat="server" Font-Bold="True"></asp:Label>
                   </td> 
                    <td>
                        <asp:Label ID="txtdate" CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>                                 
              
                    <td>
                         <asp:Label ID="lblTime" Text="Incident Time :" CssClass="Reportcolor" 
                             runat="server" Font-Bold="True"></asp:Label>
                   </td> 
                    <td>
                        <asp:Label ID="txttime"  CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>                                 
               </tr>
                <tr>
                   <%-- <td>
                         <asp:Label ID="lblnric" Text="NRIC/FIN No. :" CssClass="Reportcolor" 
                             runat="server" Font-Bold="True"></asp:Label>
                   </td> 
                    <td>
                        <asp:Label ID="txtnric" CssClass="Reportcolor" runat="server"></asp:Label>
                   </td> --%>                                
              
                    <td>
                         <asp:Label ID="lblreportedby" Text="Reported Filed By :" CssClass="Reportcolor" 
                             runat="server" Font-Bold="True"></asp:Label>
                   </td> 
                    <td>
                        <asp:Label ID="txtreportedby"  CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>                                 
             
                    <td>
                         <asp:Label ID="lblsite" Text="Incident Site :" CssClass="Reportcolor" 
                             runat="server" Font-Bold="True"></asp:Label>
                   </td> 
                    <td>
                        <asp:Label ID="txtsite" CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>                                 
               <%-- </tr>
               <tr>
                    <td>
                         <asp:Label ID="lbltype" Text="Incident Type :" CssClass="Reportcolor" 
                             runat="server" Font-Bold="True"></asp:Label>
                   </td> 
                    <td>
                        <asp:Label ID="txttype"  CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>    --%>                             
               </tr>
                <tr>
                    <td valign="top">
                         <asp:Label ID="lblstatement" Text="Statement :" CssClass="Reportcolor" 
                             runat="server" Font-Bold="True"></asp:Label>
                   </td> 
                    <td colspan="3" height="85px" valign="top">
                        <asp:Label ID="txtstatement" CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>    
               </tr>
               <tr>
                   <td height="55px" colspan="1" dir="ltr">
                         
                   </td>
                   <td height="55px" width="300px">
                         
                   </td>
                   <td height="55px" width="300px" colspan="2">
                         
                   </td>
               </tr>
               <tr>
                    <td colspan="2">
                         <asp:Label ID="lblfollowupstatus" Text="Incident Follow Up Status" 
                             CssClass="Labels" runat="server" Font-Bold="True" Font-Size="15px" 
                             ForeColor="Black"></asp:Label>
                    
                    </td>
               </tr>
                <tr>
                     <%--<td>
                         <asp:Label ID="lblfollowby" Text="Followed By :" CssClass="Reportcolor" 
                             runat="server" Font-Bold="True"></asp:Label>
                   </td> 
                    <td>
                        <asp:Label ID="txtfollowby"  CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>  --%>    
                    <td>
                         <asp:Label ID="lblfollowverify" Text="Verified By :" CssClass="Reportcolor" 
                             runat="server" Font-Bold="True"></asp:Label>
                   </td> 
                    <td>
                        <asp:Label ID="txtfollowverify" CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>
                
                    <td>
                         <asp:Label ID="lblfollownric" Text="NRIC/FIN No. :" CssClass="Reportcolor" 
                             runat="server" Font-Bold="True"></asp:Label>
                   </td> 
                    <td>
                        <asp:Label ID="txtfollownric" CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>                                 
              
                                              
               </tr>
                <tr>
                    <td>
                         <asp:Label ID="lblfollowinvestigate" Text="Investigated By :" 
                             CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                   </td> 
                    <td>
                        <asp:Label ID="txtfollowinvestigate"  CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>   
                
                    
               </tr>                                    
               <tr>
                    <td valign="top">
                         <asp:Label ID="lblfollowreport" Text="Follow Up Remarks :" CssClass="Reportcolor" 
                             runat="server" Font-Bold="True"></asp:Label>
                   </td> 
                    <td colspan="3" height="85px" valign="top">
                        <asp:Label ID="txtfollowreport" CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>  
                   
               </tr>    
                   
                     
               <tr>
                        <td>
                           <asp:Label ID="lblfollowstatus" Text="Status :" CssClass="Reportcolor" 
                                runat="server" Font-Bold="True" Visible="False"></asp:Label>
                        </td> 
                        <td>
                           <asp:Label ID="txtfollowstatus" CssClass="Reportcolor" runat="server" 
                                Visible="False"></asp:Label>
                       </td>                    
               </tr>
               
                <tr>
                    <td height="55px">
                   
                   </td> 
                </tr>

         </table>
      </asp:Panel>
           
       <div align="center">
        <asp:panel ID="btnpanel" runat="server" style=" background:url(../../Images/1397d40aa687.jpg); margin-left:1.5em">    
         <asp:Button ID="btnprint" runat="server" CssClass="Buttons" Text="Print" 
          Width="100px" Height="35px" onclick="btnprint_Click" Font-Bold="True"/> 
    </asp:Panel>
       </div>    
           
           
     </div>
  </div>








</asp:Content>
