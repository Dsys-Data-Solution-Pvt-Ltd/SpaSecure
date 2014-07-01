<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="ViewEvent.aspx.cs" Inherits="SMS.SMSUsers.Reports.ViewEvent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Event Report</span></div>           
          
          <br/>
           <div id="divAdvSearch" runat="server" visible="true">
           <asp:Panel ID="printview" runat="server" BackColor="White" style=" margin-left:1.5em" Font-Bold="True">            
            <table width="100%" cellspacing="8">
            <tr>
            <td align="center" colspan="4">
                   <asp:Image runat="server" ID="image1" style="Height:80px; width:100px"></asp:Image>
                   <hr  style=" background-color:Black; color:Black; border-color:Black"></hr>
             </td>
            </tr>
            <tr>            
                <td align="center" colspan="4" height="70px" valign="top">
                   <asp:Label ID="lblIncidentReport" Text="Event Report" CssClass="Labels" 
                   runat="server" Font-Bold="True" Font-Size="20px" ForeColor="Black"></asp:Label>
                </td>             
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblLocation" CssClass="Labels" runat="server" Text="Location"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="txtlocation" runat="server" CssClass="Labels"></asp:Label>
                </td>            
            </tr>
            <tr>    
                <td>
                    <asp:Label ID="lblgaurdreq" CssClass="Labels" runat="server" Text="Number of Guards Required "></asp:Label>
                </td>
                <td colspan="3">
                    <asp:Label ID="txtNoOfGuard" runat="server" CssClass="Labels"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblspecialreq" CssClass="Labels" runat="server" Text="Special Requirement"></asp:Label>
                </td>
                <td colspan="4">
                   <asp:Label ID="txtSpecialReg" runat="server" CssClass="Labels"></asp:Label>
                </td>            
            </tr>
            <tr>
                
                <td>
                    <asp:Label ID="lbldutyforgaurd" CssClass="Labels" runat="server" Text="Any Special Duty for Guards"></asp:Label>
                </td>
                <td colspan="3">
                    <asp:Label ID="txtSpecialDuty" runat="server" CssClass="Labels"></asp:Label>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <asp:Label ID="Date" CssClass="Labels" runat="server" Text="Date :   From"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="txtFromDate" runat="server" CssClass="Labels"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Dateto" CssClass="Labels" runat="server" Text="To"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="txtTodate" runat="server" CssClass="Labels"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblEventstarttype" CssClass="Labels" runat="server" Text=" Start Time"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="txtStartTime" runat="server" CssClass="Labels"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblEventend" CssClass="Labels" runat="server" Text="End Time"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="txtEndTime" runat="server" CssClass="Labels"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbleventtype" CssClass="Labels" runat="server" Text="Event Type"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="txtEventType" runat="server" CssClass="Labels"></asp:Label>
                </td>               
            </tr>
           
            <tr>
                 <td valign="top">
                     <asp:Label ID="lblEventComment" runat="server" Text="Comments" CssClass="Labels"></asp:Label>
                 </td>
                <td colspan="4" height="55" valign="top">
                    <asp:Label ID="txtComment" runat="server" CssClass="Labels"></asp:Label>
                </td>            
            </tr>
            <tr>
                <td height="50px" colspan="4">
                </td>
            </tr>
            
                
                         
            <tr>
                         <td colspan="4">
                             <asp:Label ID="lblperson" CssClass="Labels" runat="server" Text="Person In Charge: Contact Details"
                              Font-Bold="True"></asp:Label>
                         </td>
            </tr>
            <tr>
                        <td>
                              <asp:Label ID="lblEnternpir" CssClass="Labels" runat="server" Text="NRIC/FIN No."></asp:Label>
                       </td>
                       <td>
                            <asp:Label ID="txtPersonNRIC" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblEnterName" CssClass="Labels" runat="server" Text="Name"></asp:Label>
                       </td>
                       <td>
                            <asp:Label ID="txtPersonName" runat="server" CssClass="Labels"></asp:Label>
                       </td>
             </tr>
             <tr>
                     <td>
                         <asp:Label ID="lblEnterContactno" CssClass="Labels" runat="server" Text="Contact No."></asp:Label>
                    </td>
                   <td>
                         <asp:Label ID="txtPersonContNo" runat="server" CssClass="Labels"></asp:Label>
                   </td>
                   <td>
                        <asp:Label ID="lblEnterPosition" CssClass="Labels" runat="server" Text="Position"></asp:Label>
                  </td>
                   <td>
                        <asp:Label ID="txtPersonPosition" runat="server" CssClass="Labels"></asp:Label>
                   </td>
             </tr>
              <tr>
                   <td>
                        <asp:Label ID="lblsuperior" CssClass="Labels" runat="server" Text="Created By :"></asp:Label>
                   </td>
                    <td>
                        <asp:Label ID="txtSuperior" runat="server" CssClass="Labels"></asp:Label>
                   </td>
             </tr>
        </table>
           
      </asp:Panel>
      <br />
      
      <div align="center">
           <asp:panel ID="btnpanel" runat="server" style=" background:url(../../Images/1397d40aa687.jpg); margin-left:1.5em; margin-top:-1.4em">    

          <asp:Button ID="btnprint" runat="server" Text="Print" CssClass="Buttons" 
              Font-Bold="True" Height="35px" Width="110px" onclick="btnprint_Click"/>
      </asp:Panel>
      </div>
     </div>
  </div>

</asp:Content>
