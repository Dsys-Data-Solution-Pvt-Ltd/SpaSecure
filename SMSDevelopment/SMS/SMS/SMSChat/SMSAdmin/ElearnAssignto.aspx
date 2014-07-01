<%@ Page Language="C#" MasterPageFile="../SMSmaster.Master" AutoEventWireup="true" CodeBehind="ElearnAssignto.aspx.cs" Inherits="SMS.SMSAdmin.ElearnAssignto" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainer">
        <div class="divHeader"><span class="pageTitle">Assign to</span>
        </div>
         <br />
         <asp:GridView ID="GridView1" CssClass="GridMain" runat="server" AutoGenerateColumns="false" >
            <HeaderStyle CssClass="HeaderRow" />
            <AlternatingRowStyle CssClass="Alternaterow" />
            <RowStyle CssClass="NormalRow" />
            
            <Columns>
                <asp:BoundField HeaderText="Employee ID" ReadOnly="true" />
                <asp:BoundField HeaderText="Name" ReadOnly="true" />
                <asp:BoundField HeaderText="Department" ReadOnly="true" />
            </Columns>
         </asp:GridView>
         <br />
    </div>
    <br />
</asp:Content>
