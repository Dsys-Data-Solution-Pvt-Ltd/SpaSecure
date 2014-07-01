<%@ Page Language="C#" MasterPageFile="~/SMSmaster.Master" AutoEventWireup="true"
    CodeBehind="EmployeeIncentives.aspx.cs" Inherits="SMS.SMSUsers.EmployeeIncentives" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
            height: 1.5em;
            width: 62.6em;
            background-color: #D0E2F0;
            border: 0px solid #4596DD;
            vertical-align: top;
            color: #1F5588;
            font-family: Verdana;
            font-size: 12px;
            letter-spacing: 1.5px;
            font-weight: bold;
        }
        .style3
        {
            height: 9px;
            width: 307px;
        }
        .style4
        {
            width: 307px;
        }
        .style5
        {
            width: 307px;
            height: 83px;
        }
        .style6
        {
            height: 83px;
        }
        .style7
        {
            font-weight: bold;
            text-decoration: underline;
        }
        .style8
        {
            font-weight: normal;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">EMPLOYEE INCENTIVE SCHEME - REWARD PROGRAM</span></div>
        <br />
        <div class="Labels">
            <span class="style8">The purpose of the scheme is to reward positive behaviour, and
                innovative ideas which assist the organisation in achieving its objectives.
                <br />
                <br />
                The program involves nominating an individual who have achieved an outstanding result
                in security operations or contributing towards good leadership skills. In addition
                the scheme intends to recognise ideas which have resulted in a change or practice
                leading to efficiency gains or security benefit to the organisation.
                <br />
                <br />
                This program operates independently from the salary system presently in place.
                <br />
            </span>
            <br />
            <br />
            <span class="style7">Rules of the Program</span>
            <br />
            <br />
            <span class="style8">Security officers may be nominated by any two Security officers.
                <br />
                <br />
                Nominations should be left in writing on the prescribed form and should indicate
                details of the initiative. The final decision on the nomination is to be made by
                the Staff Consultative Committee. </span>
            <br />
            <br />
            <br />
            <span class="style7">Reward Examples</span>
            <br />
            <br />
            <b>Category 1</b> <span class="style8">Weekend away for two.</span>
            <br />
            <b>Category 2</b> <span class="style8">Gift Voucher to local business.</span>
            <br />
            <b>Category 3</b> <span class="style8">“Dinner for Two” at Diners Choice or equivalent.</span>
            <br />
            <br />
            <b>Category 1</b>&nbsp; <span class="style8">Reward Recognises an innovative change
                or idea which when implemented has resulted in significant efficiency or<br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                or service excellence to XXX Company.<br />
            </span>
            <br />
            <b>Category 2</b>&nbsp; <span class="style8">Reward Outstanding personal effort which
                has resulted in 100% attendence.<br />
            </span>
            <br />
            <b>Category 3&nbsp; </b><span class="style8">Reward Recognition of a great individual
                effort who has taken that extra step for the benefit of the organisation. </span>
        </div>
        <br />
        <div id="divAdvSearch" runat="server" visible="true">
            <table>
                <tr>
                    <td class="style4">
                        <asp:Label ID="lblItemNo" Text="Name of Individual or Team" CssClass="Labels" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtItemNo" runat="server" CssClass="Input" Height="85px" Width="392px"
                            TextMode="MultiLine" />
                        <asp:Label ID="lblerr2" CssClass="ValSummary" runat="server" Text="*" Font-Size="Smaller"
                            ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        <asp:Label ID="lblItemname" Text="Details of Achievement:" CssClass="Labels" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" CssClass="Input" Height="95px" OnTextChanged="txtName_TextChanged"
                            Width="392px" TextMode="MultiLine" />
                    </td>
                </tr>
                <tr>
                    <td class="style5">
                        <asp:Label ID="lblcname" Text="How has the achievement benefited the organisation:"
                            CssClass="Labels" runat="server"></asp:Label>
                    </td>
                    <td class="style6">
                        <asp:TextBox ID="txtcname" runat="server" CssClass="Input" Height="82px" Width="392px"
                            TextMode="MultiLine" />
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        <asp:Label ID="lblItemname0" runat="server" CssClass="Labels" Text="Nomination made by:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtName0" runat="server" CssClass="Input" Height="23px" Width="392px" />
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        <asp:Label ID="lblcname0" Text="Company Name" CssClass="Labels" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtcname0" runat="server" CssClass="Input" Height="25px" Width="392px" />
                    </td>
                    <td>
                </tr>
                <tr>
                    <td height="35px" class="style3">
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        &nbsp;
                    </td>
                    <td align="center">
                        <asp:Button ID="btnItemAdd" runat="server" CssClass="Buttons" Text="Add" Width="100px" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnItemAddq" runat="server" CssClass="Buttons" Text="Cancel" Width="100px" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="Center" colspan="4">
                        &nbsp;&nbsp; &nbsp;
                    </td>
                    <td align="Center">
                        &nbsp;&nbsp; &nbsp;
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <br />
</asp:Content>
