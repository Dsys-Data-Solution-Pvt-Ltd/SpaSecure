<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true"
    CodeBehind="VisitorViewCurrent.aspx.cs" Inherits="SMS.SMSUsers.Reports.VisitorViewCurrent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Visitor Report</span></div>
        <br />
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
                            <asp:Label ID="lblIncidentReport" Text="Visitor Report" CssClass="Labels" runat="server"
                                Font-Bold="True" Font-Size="20px" ForeColor="Black"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblInTime" Text="In Time" CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                        <td colspan="3">
                            : <asp:Label ID="txtInTime" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <%--<tr>    
                   
                    <td>
                         <asp:Label ID="lblOutTime" Text="Out Time" CssClass="Reportcolor" 
                             runat="server" Font-Bold="True"></asp:Label>
                   </td> 
                    <td colspan="3">
                        <asp:Label ID="txtOutTime" CssClass="Reportcolor" runat="server"></asp:Label>
                   </td>   
                                                  
               </tr>--%>
                    <tr>
                        <td>
                            <asp:Label ID="lblName" Text="Name" CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                        <td colspan="3">
                           : <asp:Label ID="txtname" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblNRIC" Text="NRIC No." CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                        <td colspan="3">
                           : <asp:Label ID="txtNRIC" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblAddress" Text="Address" CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                        <td colspan="3">
                           : <asp:Label ID="txtAddress" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblPhone" Text="Contact No." CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td colspan="3">
                           : <asp:Label ID="txtPhone" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblPass" Text="Pass No." CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                           : <asp:Label ID="txtPass" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblPassType" Text="Pass Type" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                           : <asp:Label ID="txtPassType" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblKeyNo" Text="Key No." CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                           : <asp:Label ID="txtKeyNo" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblVehicle" Text="Vehicle No." CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                           : <asp:Label ID="txtVehicle" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblCompanyFrom" Text="Company From" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td colspan="3">
                           : <asp:Label ID="txtCompanyFrom" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblToVisit" Text="To Visit" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td colspan="3">
                           : <asp:Label ID="txtToVisit" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <asp:Label ID="lblRemark" Text="Remarks" CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                        <td colspan="3" height="35" valign="top">
                           : <asp:Label ID="txtRemark" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25px">
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <br />
            <div align="center">
              <asp:panel ID="btnpanel" runat="server" style=" background:url(../../Images/1397d40aa687.jpg); margin-left:1.5em; margin-top:-1.5em">    

                <asp:Button ID="btnprint" runat="server" Text="Print" CssClass="Buttons" Font-Bold="True"
                    Height="30px" Width="110px" OnClick="btnprint_Click" />
                    </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>
