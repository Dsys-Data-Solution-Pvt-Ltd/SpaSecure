<%@ Page Language="C#" MasterPageFile="~/SMSmaster.Master" AutoEventWireup="true" CodeBehind="UserUpdateComplete.aspx.cs" Inherits="SMS.SMSAdmin.UserUpdateComplete" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">User Information</span></div>
        <table id="tblMain" width="100%" align="center">
            <tr>
                <td>
                    <div id="divErr" runat="server">
                        <asp:label id="lblErrMsg" cssclass="ValSummary" runat="server"></asp:label>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <table id="tblInsertMsg" visible="false" runat="server">
                        <tr>
                            <td>
                                <asp:label id="lblMsg1" cssclass="Labels" runat="server">You have successfully Updated User Data  Information.</asp:label>
                            </td>
                        </tr>
                    </table>
                    <table id="tblUpdateMsg" visible="false" runat="server">
                        <tr>
                            <td>
                                <asp:label id="lblMsg2" cssclass="Labels" runat="server">You have successfully Updated a User Data Information record.</asp:label>
                            </td>
                        </tr>
                    </table>
                    <table id="tblDeleteMsg" visible="false" runat="server">
                        <tr>
                            <td>
                                <asp:label id="lblMsg3" cssclass="Labels" runat="server">You have successfully Deleted a User Data Information .</asp:label>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                <asp:label id="Label1" cssclass="Labels" runat="server">To review the record, Please check the User Report</asp:label>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                <asp:button id="btnComplete" text="Complete" cssclass="Buttons" runat="server" onclick="btnComplete_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
