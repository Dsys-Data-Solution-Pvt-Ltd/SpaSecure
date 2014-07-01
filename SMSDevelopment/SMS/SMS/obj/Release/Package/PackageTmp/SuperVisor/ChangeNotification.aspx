<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="ChangeNotification.aspx.cs" Inherits="SMS.SuperVisor.ChangeNotification"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Change Notification</span></div>
        <div>
            <asp:Label ID="lblerror" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"></asp:Label>
        </div>
        <br />
        <div id="divAdvSearch" runat="server" visible="true">
        <asp:Panel ID="printview" runat="server" > 
        
           <table width="80%" class="table" cellspacing="5" style=" background-color:White;">
                <tr>
                    <td>
                          <asp:Label ID="lblAssignment" Text="Location" CssClass="Labels" runat="server"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:DropDownList ID="ddllocation" runat="server" CssClass="Input" Width="130px" 
                              AutoPostBack="True" onselectedindexchanged="ddllocation_SelectedIndexChanged"></asp:DropDownList>
                        <asp:Label ID="searchid" CssClass="Labels" runat="server" Visible="false"></asp:Label>
                      </td>                       
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblEnterPassNumber" Text="Our Ref" CssClass="Labels" runat="server"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtRefNo" runat="server" CssClass="Input" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" Text="Date" CssClass="Labels" runat="server"></asp:Label>
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtdate" CssClass="Input" runat="server"></asp:TextBox>
                        <AJAX:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="AjaxCalendar"
                         Format="MM/dd/yyyy" TargetControlID="txtdate" PopupButtonID="imgBtnFromDate2" />
                         <asp:ImageButton ID="imgBtnFromDate2" runat="server" 
                         ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" Text="Attn" CssClass="Labels" runat="server"></asp:Label>
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtAttn" CssClass="Input" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                <td>
                 Dear Sir,
                </td>
                </tr>
                <tr>
                <td>
                RE: CHANGE OF SECURITY GUARD FOR YOUR PREMISE
                
                </td>
                </tr>
                <tr>
                <td >
                <p >
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; We would like to inform you that we are placing our relief security guard for the above assignment as our
           permanent guard will be attending urgent matters for a few days.<br />
           Please be informed that the under mentioned personnel deployed at your Site/Premises will be replaced on <asp:TextBox runat="server" ID="txtreplaced" CssClass="Input" ></asp:TextBox> &nbsp;as follows:<br />
           </p>
                </td>
                </tr>
           </table>
           
           <table width="80%" class="table" cellspacing="5" style=" background-color:White;">
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Label ID="Label3" Text="Name" CssClass="Labels" runat="server" Font-Bold="true"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label4" Text="NRIC NO." CssClass="Labels" runat="server" Font-Bold="true"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Security Guard :
                    </td>
                    <td>
                        <asp:TextBox ID="txtguardfrom" Text="" CssClass="input" runat="server" Font-Bold="true"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtguardfromNric" Text="" CssClass="input" runat="server" Font-Bold="true"></asp:TextBox>
                    </td>
                </tr>
                <tr><td>
                Is being replaced by the following personnel:
                </td></tr>
                <tr>
                    <td>Security Guard :
                    </td>
                    <td>
                        <asp:TextBox ID="txtToguard" Text="" CssClass="Input" runat="server" Font-Bold="true"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtToguardnric" Text="" CssClass="Input" runat="server" Font-Bold="true"></asp:TextBox>
                    </td>
                </tr>                
           </table>
           <p class="table" style=" background-color:White;">We would appreciate if you monitor his performance and give us your feedback. We provide our guard with adequate training and we will continuously monitor them.
           </p>
           <p class="table" style=" background-color:White;">Please be assured of our best service and attention at all times.</p>
           <p class="table" style=" background-color:White;">
              Thank You.
           </p>
           </asp:Panel>
           <table width="100%" class="table" style=" margin-top:-2=em; background: url(../Images/1397d40aa687.jpg); height:2.2em">     
                <tr>
                    <td align="Center" colspan="3">
                        <asp:Button ID="btnSearchPassAdd" Text="Add" runat="server" CssClass="Buttons" Width="85px"
                            OnClick="btnSearchPassAdd_Click" />
                        &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<asp:Button ID="btnClearPassAdd" Text="Print" runat="server" CssClass="Buttons"
                            Width="85px" onclick="btnClearPassAdd_Click" Visible="False" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
    </div>
</asp:Content>
