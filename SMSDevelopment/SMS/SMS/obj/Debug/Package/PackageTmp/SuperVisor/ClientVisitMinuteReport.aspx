<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true"
    CodeBehind="ClientVisitMinuteReport.aspx.cs" Inherits="SMS.SuperVisor.ClientVisitMinuteReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainerForCR">
        <div class="divHeader">
       
            <span class="pageTitle">Client Visit Minutes</span></div>
        <br />
        <div id="divAdvSearch" runat="server" visible="true">
            <asp:Panel ID="printview" runat="server" BackColor="White" Style="margin-left: 1.5em"
                Font-Bold="True" Width="750px" Height="70em">
                <table width="100%" cellspacing="10px">
                <tr>
                <td colspan="4" style=" height:90px;" align="center">
                <asp:Image runat="server" ID="image1" style="Height:80px; width:100px"></asp:Image>
                   <hr  style=" background-color:Black; color:Black; border-color:Black"></hr>
                </td>
                </tr>

                    <tr>
                        <td align="center" colspan="4" height="70px" valign="top">
                            <asp:Label ID="lblIncidentReport" Text="Client Visit Minutes Reports" CssClass="Labels" runat="server"
                                Font-Bold="True" Font-Size="20px" ForeColor="Black"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblAssignment" Text="Location" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:Label ID="ddlocation" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblcompletedby" Text="Completed By" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:Label ID="txtcompletedby" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbldatefrom" CssClass="Labels" runat="server" Text="Date"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtdatefrom" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblMetwith" Text="Client Name" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:Label ID="txtClientName" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="40" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            1) COMPLAINTS/ ABSENTEEISM
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" height="50px" valign="top">
                            <asp:Label ID="txtcomplaints" Text="" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            2) POSITIVE COMMENTS
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" height="50px" valign="top">
                            <asp:Label ID="txtpositivecomments" Text="" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            3) DEPLOYMENT/ OTHER CHANGES
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" height="50px" valign="top">
                            <asp:Label ID="txtdeployment" Text="" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            4) UP-COMING EVENTS
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" height="50px" valign="top">
                            <asp:Label ID="txtupcomingevent" Text="" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            5) REMARKS
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" height="55" valign="top">
                            <asp:Label ID="txtremarks" Text="" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25px">
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <div class="table">
                <table width="750px" style="margin-left:0.1em; margin-bottom:-0.4em; border: 1px;
                    border-style: groove; border-color: Black; background: url(../Images/1397d40aa687.jpg)">
                    <tr>
                        <td colspan="4" align="center" style="width: 897px">
                            <asp:Button ID="btnprint" runat="server" CssClass="Buttons" Text="Print" Width="110px"
                                Height="30px" Font-Bold="True" Font-Size="Medium" OnClick="btnprint_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
