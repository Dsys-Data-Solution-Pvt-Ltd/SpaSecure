<%@ Page Language="C#" MasterPageFile="../SMSmaster.Master" AutoEventWireup="true" CodeBehind="Elearn.aspx.cs" Inherits="SMS.SMSUsers.Elearn" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainer">
        <div class="divHeader"><span class="pageTitle">E-Learning</span></div>
          <br />
         
        
          <center>
            <asp:GridView ID="GridView1" CssClass="GridMain" runat="server" AutoGenerateColumns="false">
                <AlternatingRowStyle CssClass="AlternateRow" />
                <HeaderStyle CssClass="HeaderRow" />  
                <RowStyle CssClass="NormalRow" />
                
                <Columns>
                    <asp:BoundField HeaderText="Tutorial" ReadOnly="true" />
                    <asp:BoundField HeaderText="Download" />
                    <asp:BoundField HeaderText="Date" ReadOnly="true"/>
                    <asp:BoundField HeaderText="Time" ReadOnly="true" />
                    <asp:BoundField HeaderText="Ask Question" />
                </Columns>
            </asp:GridView>
          </center>
          <br />
        </div>
     <br />
          
</asp:Content>
