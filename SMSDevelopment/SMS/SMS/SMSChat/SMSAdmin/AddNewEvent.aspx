<%@ Page Language="C#" MasterPageFile="../SMSmaster.Master" AutoEventWireup="true" CodeBehind="AddNewEvent.aspx.cs" Inherits="SMS.SMSAdmin.AddNewEvent" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 91px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div class="divContainer">
    <div class="divHeader"><span class="pageTitle">Add New Event</span></div> 
      <table align="left" >
          <tr>
            <td valign="top" class="style1">
                <asp:Label ID="lblDate1" CssClass="Labels" runat="server" Text="Date"></asp:Label>
            </td>
                  <td>
                                <asp:TextBox runat="server" ID="txtFromDate" Text="" CssClass="Input" />
                                <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                                    Format="MM/dd/yyyy" TargetControlID="txtFromDate" PopupButtonID="imgBtnFromDate" />
                                <asp:ImageButton ID="imgBtnFromDate" runat="server" ImageAlign="AbsMiddle" 		ImageUrl="~/Images/calendar.bmp" />
                  </td>
          </tr>
          <tr>
            <td valign="top" class="style1">
                <asp:Label ID="lblTime1" CssClass="Labels" runat="server" Text="Time"></asp:Label>
            </td>
                  <td>
                                <asp:TextBox runat="server" ID="txtFromDate1" Text="" CssClass="Input" />
                                <AJAX:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="AjaxCalendar"
                                    Format="MM/dd/yyyy" TargetControlID="txtFromDate1" PopupButtonID="imgBtnFromDate1" />
                                <asp:ImageButton ID="imgBtnFromDate1" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp" />
                </td>
           
          </tr>
          <tr>
            <td class="style1">
                <asp:Label ID="lblLocation1" CssClass="Labels" runat="server" Text="Location"></asp:Label>
            </td>
           
            <td>
                 <asp:TextBox ID="txtLocation1" CssClass="Input" runat="server"></asp:TextBox>
            </td>
          </tr>
          <tr>
            <td class="style1">
                <asp:Label ID="lblEventBreaf1" CssClass="Labels" runat="server" Text="Event Breaf"></asp:Label>
            </td>
            
            <td>
                 <asp:TextBox ID="txtEventBreaf1" CssClass="Input" runat="server"></asp:TextBox>
            </td>
          </tr>
          <tr>
          <td class="style1" align="right">
              <asp:Button ID="btnAdd1" CssClass="Buttons" runat="server" Text="Add" 
                  onclick="btnAdd1_Click" />
          </td>
         
          <td>
              <asp:Button ID="btnDelete1" CssClass="Buttons" runat="server" Text="Delete" 
                  onclick="btnDelete1_Click" />
          </td>
          </tr>
      </table>
    
  </div>
  <br />
</asp:Content>
