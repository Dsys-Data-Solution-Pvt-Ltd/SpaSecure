<%@ Page Language="C#" MasterPageFile="../SMSmaster.Master" AutoEventWireup="true" CodeBehind="appointmentScheduling.aspx.cs" Inherits="SMS.SMSUsers.appointmentScheduling" Title="Appointment Scheduling" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainer">
        <div class="divHeader"><span class="pageTitle">Appointment Scheduling</span></div>
        <br />
        <table align="left">
            <tr>
                <td valign="top">
                    <asp:Label ID="lblDate" CssClass="Labels" runat="server" Text="Date"></asp:Label>
                </td>
                <td>
                      <asp:TextBox runat="server" ID="txtFromDate" Text="" CssClass="Input" />
                      <AJAX:CalendarExtender ID="DateCalendarExtender1" runat="server" CssClass="AjaxCalendar"
                      Format="MM/dd/yyyy" TargetControlID="txtFromDate" PopupButtonID="imgBtnFromDate" />
                      <asp:ImageButton ID="imgBtnFromDate" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp" />
                </td>
                
                
            </tr>
            <tr>
                <td valign="top">
                    <asp:Label ID="lblTimein" CssClass="Labels" runat="server" Text="Time In"></asp:Label>
                </td>
               <td>
                                <asp:TextBox runat="server" ID="txtFromDate1" Text="" CssClass="Input" />
                                <AJAX:CalendarExtender ID="TimeCalendarExtender1" runat="server" CssClass="AjaxCalendar"
                                    Format="MM/dd/yyyy" TargetControlID="txtFromDate1" PopupButtonID="imgBtnFromDate1" />
                                <asp:ImageButton ID="imgBtnFromDate1" runat="server" ImageAlign="AbsMiddle"	ImageUrl="~/Images/calendar.bmp" />
              </td>
            </tr>
            <tr>
                <td valign="top">
                    <asp:Label ID="lblTimeout" CssClass="Labels" runat="server" Text="Time Out"></asp:Label>
                </td>
                <td>
                                <asp:TextBox runat="server" ID="txtFromDate2" Text="" CssClass="Input" />
                                <AJAX:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="AjaxCalendar"
                                    Format="MM/dd/yyyy" TargetControlID="txtFromDate2" PopupButtonID="imgBtnFromDate2" />
                                <asp:ImageButton ID="imgBtnFromDate2" runat="server" ImageAlign="AbsMiddle"	ImageUrl="~/Images/calendar.bmp" />
              </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" CssClass="Labels" runat="server" Text="Department"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDepartment" CssClass="Input"  runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" CssClass="Labels" runat="server" Text="TO MEET:-" Font-Bold="true"></asp:Label>
                </td>
                <td>
                
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label6" CssClass="Labels" runat="server" Text="Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtName" CssClass="Input"  runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label7" CssClass="Labels" runat="server" Text="ID"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtID" CssClass="Input"  runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button1" CssClass="Buttons" runat="server" Text="Check Avaibility" />
                </td>
                <td>
                    <asp:Button ID="Button2" CssClass="Buttons" runat="server" Text="Block Appoinment" onclick="Add_Appointment" />
                </td>
            </tr>
            <tr>
                  <td>
                    <br />
                    <left>
                        <asp:Label ID="Label8" CssClass="Labels" runat="server" Text=""></asp:Label>
                        <asp:Label ID="Label9" CssClass="Labels"  runat="server" Text=""></asp:Label>
                        <asp:Label ID="Label10" CssClass="Labels"  runat="server" Text=""></asp:Label>
                        <asp:Label ID="Label11" CssClass="Labels"  runat="server" Text=""></asp:Label>
                    </left>
                 </td>   
             </tr> 
      </table>
        <left>
            <asp:GridView ID="GridView1" CssClass="GridMain" runat="server" AutoGenerateColumns="false" Width="600px">
                <AlternatingRowStyle CssClass="AlternateRow" />
                <HeaderStyle CssClass="HeaderRow" />
                <RowStyle CssClass="NormalRow" />
                <Columns>
                    <asp:BoundField HeaderText="Time" />
                    <asp:BoundField HeaderText="Status" />
                    <asp:ButtonField HeaderText="Edit" ControlStyle-CssClass="Buttons" ButtonType="Button" Text="Edit" />
                </Columns>
            </asp:GridView>
        </left>
        <br />
    </div>
    <br />
</asp:Content>
