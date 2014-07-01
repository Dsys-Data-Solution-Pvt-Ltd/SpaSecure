<%@ Page Title="" Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true"
    CodeBehind="AddShift.aspx.cs" Inherits="SMS.ADMIN.AddShift" %>

<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Add New Shift</span></div>
        <div>
            <asp:Label ID="lblerror" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"></asp:Label>
        </div>
        <br />
        <div id="divAdvSearch" runat="server" visible="true">
       <asp:panel runat="server" ID="Pnl" BackColor="White" style=" margin-left:1.5em; margin-top: 0px;" Font-Bold="True" Width="750">
            
            <table width="700PX" class="table">
             <tr><td height="10" style="width: 96px"></td></tr>
                <tr>
                    <td>
                        <asp:Label ID="lblFromTime" Text="From Time" CssClass="Labels" runat="server"></asp:Label>
                    </td>
                    <td width="80%">
                        <MKB:TimeSelector ID="tsFromTime" runat="server" MinuteIncrement="1" SecondIncrement="1"
                            SelectedTimeFormat="Twelve" DisplaySeconds="False" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td width="80%">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td width="20%">
                        <asp:Label ID="lblToTime" Text="To Time" CssClass="Labels" runat="server"></asp:Label>
                    </td>
                    <td width="80%">
                        <MKB:TimeSelector ID="tsToTime" runat="server" MinuteIncrement="1" SecondIncrement="1"
                            SelectedTimeFormat="Twelve" DisplaySeconds="False" />
                    </td>
                </tr>
                <tr>
                    <td width="20%">
                        &nbsp;
                    </td>
                    <td width="80%">
                        &nbsp;
                    </td>
                </tr>
                </table>

                <table  width="750px" style="margin-left:0.1em; margin-bottom:-0.4em;border:1px;border-style:groove; border-color:Black;background: url(../Images/1397d40aa687.jpg)">
                <tr>
                    <td align="center" colspan="4">
                        <asp:Button ID="btnSearchLocationAdd" Text="Add" runat="server" CssClass="Buttons"
                            Width="85px" OnClick="btnSearchLocationAdd_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnClearLocationAdd" Text="Cancel" runat="server" CssClass="Buttons"
                            Width="85px" OnClick="btnClearLocationAdd_Click" />
                    </td>
                </tr>
            </table>
            </asp:panel>
        </div>
        <br />
    </div>
</asp:Content>
