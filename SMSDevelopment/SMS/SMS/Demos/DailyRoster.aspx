<%@ Page Title="" Language="C#" MasterPageFile="~/SMSmaster.Master" AutoEventWireup="true"
    CodeBehind="DailyRoster.aspx.cs" Inherits="SMS.Demos.DailyRoster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Monthly Roster</span>
        </div>
        <br />
        <table width="100%">
            <tr>
                <td>
                    <img src="DailyCalender.png" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
