<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true"
    CodeBehind="LostAndFoundReport.aspx.cs" Inherits="SMS.SuperVisor.LostAndFoundReport"
    Title="Lost And Found Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Lost And Found Report</span></div>
        <br />
        <div id="divAdvSearch" runat="server" visible="true">
            <asp:Panel ID="printview" runat="server" BackColor="White" Style="margin-left: 1.5em"
                Font-Bold="True" Width="755px">
                <table width="100%" cellspacing="10px" cellpadding="6">
                    <tr>
                        <td align="center" valign="top" colspan="6">
                            <asp:Label ID="lblIncidentReport" Text="LOST AND FOUND REPORT" CssClass="Labels"
                                runat="server" Font-Bold="True" Font-Size="20px" ForeColor="Black"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" width="100%" colspan="6">
                            <asp:Label ID="lblheading" Text="PART -1     DETAILS OF PERSON REPORTED" CssClass="Reportcolor"
                                runat="server" Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbldate" Text="Date :" CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtdate" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblTime" Text="Time :" CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txttime" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lbllocation" Text="Location :" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtlocation" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblpersonName" Text="Name :" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtpersonName" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblpersonNric" Text="NRIC No :" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtpersonNric" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblpersonTel" Text="Tel :" CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtpersonTel" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="6" height="45" valign="bottom">
                            <asp:Label ID="lblpropertyDescription" Text="PART-II   PROPERTY DESCRIPTION" CssClass="Reportcolor"
                                runat="server" Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" height="270px" valign="top">
                            <asp:Label ID="txtpropertyDescription" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="6">
                            <asp:Label ID="lblAction" Text="ACTION" CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" height="110px" valign="top">
                            <asp:Label ID="txtAction" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblSecurityOfficerName" runat="server" CssClass="Reportcolor" Font-Bold="True"
                                Text="Security Officer Name :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtSecurityOfficerName" runat="server" CssClass="Reportcolor"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblSignature" runat="server" CssClass="Reportcolor" Font-Bold="True"
                                Text="Signature"></asp:Label>
                        </td>
                        <td align="right">
                            <asp:Label ID="lbldateofAction" runat="server" CssClass="Reportcolor" Font-Bold="True"
                                Text="Date"></asp:Label>
                        </td>
                        <td colspan="3">
                            <asp:Label ID="txtdateofAction" runat="server" CssClass="Reportcolor"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="6" height="45" valign="bottom">
                            <asp:Label ID="lblheadAcknowledgement" Text="PART-III  RECEIPT ACKNOWLEDGEMENT" CssClass="Reportcolor"
                                runat="server" Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblAckClaimant" Text="Claimant :" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                            <%-- </td> 
                    <td>--%>
                            &nbsp;&nbsp;
                            <asp:Label ID="txtAckClaimant" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:Label ID="lblAckNric" Text="NRIC No :" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                            <%-- </td> 
                    <td>--%>
                            &nbsp;&nbsp;
                            <asp:Label ID="txtAckNric" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                        <td colspan="3">
                            <asp:Label ID="lblAckTel" Text="Tel :" CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                            <%--</td> 
                    <td>--%>&nbsp;&nbsp;
                            <asp:Label ID="txtAckTel" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" colspan="6" height="60">
                            <asp:Label ID="lblAckAddress" Text="Address :" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                            <%-- </td> 
                    <td colspan="5" height="80px" valign="top">--%>&nbsp;&nbsp;
                            <asp:Label ID="txtAckAddress" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblI" Text="I " CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                            &nbsp;&nbsp;
                            <asp:Label ID="txtI" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                        <td colspan="5">
                            <asp:Label ID="lblNRIC" Text="NRIC :" CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                            &nbsp;&nbsp;
                            <asp:Label ID="txtNRIC" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" height="70" valign="top">
                            <asp:Label ID="lblAckdetail" Text="hereby acknowledge receipt of the property listed in 'Part II' which was verified correct upon claim."
                                CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblclaimantSignature" runat="server" CssClass="Reportcolor" Font-Bold="True"
                                Text="Claimant Signature"></asp:Label>
                        </td>
                        <td colspan="4">
                            <asp:Label ID="lblclaimantdate" runat="server" CssClass="Reportcolor" Font-Bold="True"
                                Text="Date & Time"></asp:Label>
                            &nbsp;&nbsp;
                            <asp:Label ID="lblclaimatdate" runat="server" CssClass="Reportcolor"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblnameofIssueOfficer" runat="server" CssClass="Reportcolor" Font-Bold="True"
                                Text="Name Of Issuing Officer"></asp:Label>
                            &nbsp;&nbsp;
                            <asp:Label ID="txtnameofIssueOfficer" runat="server" CssClass="Reportcolor"></asp:Label>
                        </td>
                        <td colspan="4">
                            <asp:Label ID="lblSignatureofIssuingOfficer" runat="server" CssClass="Reportcolor"
                                Font-Bold="True" Text="Signature Of Issuing Officer"></asp:Label>
                            &nbsp;&nbsp;
                            <asp:Label ID="txtSignatureofIssuingOfficer" runat="server" CssClass="Reportcolor"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="55px">
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <div class="table">
                <table width="754px" style="margin-left: 0.1em; margin-bottom: -0.4em; border: 1px;
                    border-style: groove; border-color: Black; background: url(../Images/1397d40aa687.jpg)">
                    <tr>
                        <td colspan="4" align="center" style="width: 897px">
                            <asp:Button ID="btnprint" runat="server" CssClass="Buttons" Text="Print" Width="110px"
                                Height="35px" Font-Bold="True" OnClick="btnprint_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
