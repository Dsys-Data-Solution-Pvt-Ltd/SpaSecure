<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="ViewAttendance2.aspx.cs" Inherits="SMS.SMSUsers.Reports.ViewAttendance2" Title="SPA Secure"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Attendance Report</span></div>           
          
          <br/>
           <asp:panel runat="server" ID="printview" BackColor="White" style=" margin-left:1.5em" Font-Bold="True" width="760">
            <table width="750px" class="table">            
            
            <tr>
            <td align="center" colspan="4">
                   <asp:Image runat="server" ID="image1" style="Height:80px; width:100px"></asp:Image>
                   <hr  style=" background-color:Black; color:Black; border-color:Black"></hr>
             </td>
            </tr>
            <tr>            
                <td align="center" colspan="4" height="70px" valign="top">
                   <asp:Label ID="lblIncidentReport" Text="Attendance Report" CssClass="Labels" 
                   runat="server" Font-Bold="True" Font-Size="20px" ForeColor="Black"></asp:Label>
                </td>             
            </tr>
            <tr>                
                <td>
                    <asp:Label ID="lblName" CssClass="Labels" runat="server" Text="Name"></asp:Label>
                </td>
                <td colspan="3">
                    <asp:Label ID="txtName" runat="server" CssClass="Labels"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblLocation" CssClass="Labels" runat="server" Text="Location" visible="false"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="txtlocation" runat="server" CssClass="Labels" visible="false"></asp:Label>
                </td>            
            </tr>
            <tr>    
                <td>
                    <asp:Label ID="lblchkIn" CssClass="Labels" runat="server" Text="Check In Time"></asp:Label>
                </td>
                <td colspan="3">
                    <asp:Label ID="txtChkIn" runat="server" CssClass="Labels"></asp:Label>
                </td>
            </tr>           
            
            <tr>
                <td>
                    <asp:Label ID="lblNRIC" CssClass="Labels" runat="server" Text="NRIC No."></asp:Label>
                </td>
                <td>
                    <asp:Label ID="txtNRIC" runat="server" CssClass="Labels"></asp:Label>
                </td>
            </tr>
            <tr>    
                <td>
                    <asp:Label ID="lblPassNo" CssClass="Labels" runat="server" Text="Pass No." visible="false"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="txtPassNo" runat="server" CssClass="Labels" visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblKeyNo" CssClass="Labels" runat="server" Text="Key No." visible="false"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="txtKeyNo" runat="server" CssClass="Labels" visible="false"></asp:Label>
                </td>
            </tr>            
            <tr>
                <td height="50px" colspan="4">
                </td>
            </tr>        
        </table>           
      </asp:Panel>
      <br />      
      <div  class="table">
      <table  width="750px" style="margin-left:0em; margin-bottom:-0.4em;margin-top:-1.3em;border:1px;border-style:groove; border-color:Black;background: url(../../Images/1397d40aa687.jpg)">
                   <tr>
                       <td colspan="4" align="center" style="width: 750px">
                <asp:Button ID="btnprint" runat="server" Text="Print" CssClass="Buttons" 
              Font-Bold="True" Height="30px" Width="100px" onclick="btnprint_Click"/>
                </td></tr></table>
      </div>
     </div>
 

</asp:Content>
