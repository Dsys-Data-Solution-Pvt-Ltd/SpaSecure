<%@ Page Title="" Language="C#" MasterPageFile="~/SMSmaster.Master" AutoEventWireup="true" CodeBehind="ExcelReport.aspx.cs" Inherits="SMS.ADMIN.ExcelReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<iframe src="Reports/PDFReports/InventoryOut.pdf"></iframe>
</asp:Content>
