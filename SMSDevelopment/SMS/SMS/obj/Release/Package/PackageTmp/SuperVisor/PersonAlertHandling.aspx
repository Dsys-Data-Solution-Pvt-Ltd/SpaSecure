<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true"
    CodeBehind="PersonAlertHandling.aspx.cs" Inherits="SMS.SuperVisor.PersonAlertHandling" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Alert Handling</span></div>
        <div>
            <asp:Label ID="lblerror" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"></asp:Label>
        </div>
        <br />
        <div id="divAdvSearch" runat="server" visible="true">
            <asp:Panel runat="server" ID="Panel1" BackColor="White" Style="margin-left: 1.5em"
                Font-Bold="True" Width="750">
                <table width="800" class="table">
                    <tr>
                        <td height="10">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblheading" Text="Person Alert" CssClass="Labels" runat="server" Font-Bold="True"
                                Font-Size="10pt"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbllocation" CssClass="Labels" runat="server" Text="Location"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddllocation" runat="server" CssClass="Labels">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="lblNRIC" Text="NRIC/FIN No." CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td style="width: 340px">
                            <asp:TextBox ID="txtP_NricNo" runat="server" CssClass="Input" />
                            <asp:Label ID="lblerr" CssClass="ValSummary" runat="server" Text="*" Font-Size="Smaller"
                                ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblItemDesc" Text="Name" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="txtP_name" runat="server" CssClass="Input" Width="527px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblPassportNo" Text="Passport No." CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtP_Passport" runat="server" CssClass="Input" />
                        </td>
                        <td>
                            <asp:Label ID="lblCompany" Text="Nationality" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td style="width: 340px">
                            <asp:TextBox ID="txtnationality" runat="server" CssClass="Input" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblAlertReason" CssClass="Labels" runat="server" Text="Reason For Alert"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlAlertreason" runat="server" CssClass="Labels">
                                <asp:ListItem>Person Alert</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="lbladdNewtreason" CssClass="Labels" runat="server" Text="Add Alert Reason"
                                Visible="False"></asp:Label>
                        </td>
                        <td style="width: 340px">
                            <asp:TextBox runat="server" ID="txtaddReason" Text="" CssClass="Input" Visible="False" />
                            &nbsp;
                            <asp:Button ID="cmdAddReason" CssClass="Buttons" runat="server" Text="Add Reason"
                                OnClick="cmdAddReason_Click" Visible="False" Width="131px" />
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <asp:Label ID="lblmessage" Text="Comments" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="txtmessage" runat="server" CssClass="Input" TextMode="Multiline"
                                Width="523px" Height="116px" />
                        </td>
                    </tr>
                    <tr>
                        <td height="45px" width="150px">
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="1">
                            <asp:Label ID="lblalertedby" runat="server" CssClass="Labels" Font-Bold="True" Text="Alert Raised By:"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblbynric" runat="server" CssClass="Labels" Text="NRIC/FIN No."></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtbynric" runat="server" CssClass="Input" AutoPostBack="True" OnTextChanged="txtbynric_TextChanged" />
                            <asp:Label ID="lblerr1" CssClass="ValSummary" runat="server" Text="*" Font-Size="Smaller"
                                ForeColor="Red"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblname" runat="server" CssClass="Labels" Text="Name"></asp:Label>
                        </td>
                        <td style="width: 340px">
                            <asp:TextBox ID="txtname" runat="server" CssClass="Input" Width="250px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblphone" runat="server" CssClass="Labels" Text="Phone No."></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtphone" runat="server" CssClass="Input" />
                        </td>
                        <td>
                            <asp:Label ID="lbldesignation" runat="server" CssClass="Labels" Text="Designation"></asp:Label>
                        </td>
                        <td style="width: 340px">
                            <asp:TextBox ID="txtdesignation" runat="server" CssClass="Input" Width="250px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbldepartment" runat="server" CssClass="Labels" Text="Department"
                                Visible="False"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlRole0" runat="server" CssClass="Labels" Visible="False">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td height="30px">
                        </td>
                    </tr>
                    <table width="750" style="margin-left: 0.005em; margin-bottom: -0.4em; border: 1px;
                        border-style: groove; border-color: Black; background: url(../Images/1397d40aa687.jpg)">
                        <tr>
                            <td colspan="4" align="center" style="width: 897px">
                                <asp:Button ID="btnNewItemAdd" runat="server" CssClass="Buttons" OnClick="btnNewItemAdd_Click"
                                    Text="Enter" Width="85px" />
                                &nbsp;&nbsp; &nbsp;
                                <asp:Button ID="btnClearNewItemAdd" runat="server" CssClass="Buttons" OnClick="btnClearNewItemAdd_Click"
                                    Text="Cancel" Width="85px" />
                            </td>
                        </tr>
                    </table>
                </table>
            </asp:Panel>
        </div>
        <br />
    </div>
   

    
</asp:Content>
