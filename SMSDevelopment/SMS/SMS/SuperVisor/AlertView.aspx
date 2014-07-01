<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="AlertView.aspx.cs" Inherits="SMS.SuperVisor.AlertView"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="divContainer" >
        <div class="divHeader">
            <span class="pageTitle">Alert Report</span></div>           
          
          <br/>
           <div id="divAdvSearch" runat="server" visible="true">
           <asp:panel runat="server" ID="printview" BackColor="White" 
                            style=" margin-left:1.5em" Font-Bold="True" width="760">
            <table width="90%" class="table">
            <tr>
            <td align="center" colspan="4">
                   <asp:Image runat="server" ID="image1" style="Height:80px; width:100px"></asp:Image>
                   <hr  style=" background-color:Black; color:Black; border-color:Black"></hr>
             </td>
            </tr>
                <tr>
                    <td align="center" colspan="4" height="70px" valign="top">
                         <asp:Label ID="lblIncidentReport" Text="Alert Report" CssClass="Labels" 
                             runat="server" Font-Bold="True" Font-Size="20px" ForeColor="Black"></asp:Label>
                    
                    </td>
               </tr>
            
                <tr>                
                    <td>
                          <asp:Label ID="lbllocataion" Text="Location" CssClass="Reportcolor" 
                              runat="server" Font-Bold="True"></asp:Label>
                   </td> 
                    <td>
                         <asp:Label ID="txtlocation"  CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>  
                   
                    <td>
                         <asp:Label ID="lblNRICno" Text="NRIC No." CssClass="Reportcolor" 
                             runat="server" Font-Bold="True"></asp:Label>
                   </td> 
                    <td>
                        <asp:Label ID="txtNRICno" CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>   
                                                  
               </tr>
               
                <tr>                
                    <td>
                          <asp:Label ID="lblName" Text="Name" CssClass="Reportcolor" 
                              runat="server" Font-Bold="True"></asp:Label>
                   </td> 
                    <td colspan="3">
                         <asp:Label ID="txtName"  CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>  
                   
               </tr>
               <tr>    
                   
                    <td>
                         <asp:Label ID="lblPassport" Text="Passport No." CssClass="Reportcolor" 
                             runat="server" Font-Bold="True"></asp:Label>
                   </td> 
                    <td>
                        <asp:Label ID="txtPassport" CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>   
                    <td>
                         <asp:Label ID="lblNationality" Text="Nationality" CssClass="Reportcolor" 
                             runat="server" Font-Bold="True"></asp:Label>
                   </td> 
                    <td>
                        <asp:Label ID="txtNationality" CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>   
                                                  
               </tr>
               
                <tr>    
                   
                    <td>
                         <asp:Label ID="lblReason" Text="Reason for Alert" CssClass="Reportcolor" 
                             runat="server" Font-Bold="True"></asp:Label>
                   </td> 
                    <td colspan="3">
                        <asp:Label ID="txtReason" CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>   
                   
                </tr>
                <tr>   
                    <td valign="top">
                         <asp:Label ID="lblcomment" Text="Comments" CssClass="Reportcolor" 
                             runat="server" Font-Bold="True"></asp:Label>
                   </td> 
                    <td colspan="3" height="200px" valign="top">
                        <asp:Label ID="txtcomment" CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>   
                                                  
               </tr>
               
               
               
               
               <tr>                              
              
                    <td colspan="3">
                         <asp:Label ID="lbl" Text="Alert Raised By :" CssClass="Reportcolor" 
                             runat="server" Font-Bold="True"></asp:Label>
                   </td> 
                   
              </tr>
              <tr>     
                    <td>
                         <asp:Label ID="lblRaisedNric" Text="NRIC No." CssClass="Reportcolor" 
                             runat="server" Font-Bold="True"></asp:Label>
                   </td>                    
                    <td>
                        <asp:Label ID="txtRaisedNric"  CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>     
                   
                   <td>
                         <asp:Label ID="lblRaisedName" Text="Name" CssClass="Reportcolor" 
                             runat="server" Font-Bold="True"></asp:Label>
                   </td>                    
                    <td>
                        <asp:Label ID="txtRaisedName"  CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>     
                   
                                               
               </tr>
                <tr>     
                    <td>
                         <asp:Label ID="lblPhone" Text="Phone No." CssClass="Reportcolor" 
                             runat="server" Font-Bold="True"></asp:Label>
                   </td>                    
                    <td>
                        <asp:Label ID="txtPhone"  CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>     
                   
                   <td>
                         <asp:Label ID="lbldesignation" Text="Designation" CssClass="Reportcolor" 
                             runat="server" Font-Bold="True"></asp:Label>
                   </td>                    
                    <td>
                        <asp:Label ID="txtdesignation"  CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>     
                   
                                               
               </tr>
              
                <tr>
                    <td height="55px" colspan="4">
                   
                   </td> 
                </tr>

         </table>
      </asp:Panel>
           
       <div class="table">
                 <table  width="134%" style="margin-left:0.1em; margin-bottom:-0.4em;border:1px;border-style:groove; border-color:Black;background: url(../Images/1397d40aa687.jpg)">
                   <tr>
                       <td colspan="4" align="center" style="width: 897px">
                <asp:Button ID="btnprint" runat="server" CssClass="Buttons" Text="Print" Width="110px"
                    Height="30px" OnClick="btnprint_Click" Font-Bold="True" />
                </td></tr></table>
            </div>    
           
           
     </div>
  </div>

</asp:Content>
