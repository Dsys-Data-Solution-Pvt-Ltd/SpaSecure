<%@ Page Language="C#" MasterPageFile="~/SMSmaster.Master" AutoEventWireup="true" CodeBehind="PassUpDateComplete.aspx.cs" Inherits="SMS.SMSAdmin.PassUpDateComplete" Title="Pass Update Complete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Pass Information</span></div>
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
                                <asp:label id="lblMsg1" cssclass="Labels" runat="server">You have successfully Updated Pass Data Information.</asp:label>
                            </td>
                        </tr>
                    </table>
                    <table id="tblUpdateMsg" visible="false" runat="server">
                        <tr>
                            <td>
                                <asp:label id="lblMsg2" cssclass="Labels" runat="server">You have successfully Updated a Pass Data Information record.</asp:label>
                            </td>
                        </tr>
                    </table>
                    <table id="tblDeleteMsg" visible="false" runat="server">
                        <tr>
                            <td>
                                <asp:label id="lblMsg3" cssclass="Labels" runat="server">You have successfully Deleted a Pass Data Information .</asp:label>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                <asp:label id="Label1" cssclass="Labels" runat="server">To review the record, Please check the Pass  Report</asp:label>
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
