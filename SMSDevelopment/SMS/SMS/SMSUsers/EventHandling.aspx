<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true"
    CodeBehind="EventHandling.aspx.cs" Inherits="SMS.SMSUsers.EventHandaler" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">New Event</span></div>
        <div>
            <asp:Label ID="lblerror" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"></asp:Label>
        </div>
        <br />
        <asp:panel runat="server" ID="Panel1" BackColor="White" Width="750px" 
                            style=" margin-left:1.5em" Font-Bold="True">
            <table width="700px" class="table">
            <tr><td></td></tr>
        <table  style="margin-left:0.5em;" width="700px" class="table">
         
                    <tr>
                        <td>
                            <asp:Label ID="lblLocation" CssClass="Labels" runat="server" Text="Location"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="drlLocation" runat="server" CssClass="Labels" 
                                ForeColor="Black" >
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblgaurdreq" CssClass="Labels" runat="server" Text="Number of Guards Required "></asp:Label>
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="txtgaurdreq" CssClass="Input" runat="server"></asp:TextBox>
                            
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                ControlToValidate="txtgaurdreq" ErrorMessage="Please Enter Numeric Value!..." 
                                ValidationExpression="^\d+$" Font-Bold="True" Font-Size="17px" 
                                TabIndex="1"></asp:RegularExpressionValidator>
                            
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblspecialreq" CssClass="Labels" runat="server" Text="Special Requirement"></asp:Label>
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="txtspecialreq" CssClass="Input" runat="server" Width="450px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbldutyforgaurd" CssClass="Labels" runat="server" Text="Any Special Duty for Guards"></asp:Label>
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="txtdutygaurd" CssClass="Input" runat="server" Width="450px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Date" CssClass="Labels" runat="server" Text="Date :   From"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtFromDate" Text="" CssClass="Input" OnTextChanged="txtFromDate_TextChanged" />
                            <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                                Format="MM/dd/yyyy" TargetControlID="txtFromDate" PopupButtonID="imgBtnFromDate" />
                            <asp:ImageButton ID="imgBtnFromDate" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"
                                OnClick="imgBtnFromDate_Click" class="calender" />
                            &nbsp;&nbsp;&nbsp;
                        </td>
                        <td>
                            <asp:Label ID="Dateto" CssClass="Labels" runat="server" Text="To"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txttoDate" CssClass="Input" runat="server" OnTextChanged="txttoDate_TextChanged"></asp:TextBox>
                            <AJAX:CalendarExtender ID="Calendar" runat="server" CssClass="AjaxCalendar" Format="MM/dd/yyyy"
                                TargetControlID="txttoDate" PopupButtonID="imgBtnFromDate1" />
                            <asp:ImageButton ID="imgBtnFromDate1" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"
                                OnClick="imgBtnFromDate1_Click" class="calender"/>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblEventstarttype" CssClass="Labels" runat="server" Text=" Start Time"></asp:Label>
                        </td>
                        <td>
                            <MKB:TimeSelector ID="TimeSelector1" runat="server" MinuteIncrement="1" SecondIncrement="1"
                                SelectedTimeFormat="Twelve" AllowSecondEditing="true" DisplaySeconds="False" />
                        </td>
                        <td>
                            <asp:Label ID="lblEventend" CssClass="Labels" runat="server" Text="End Time"></asp:Label>
                        </td>
                        <td>
                            <MKB:TimeSelector ID="TimeSelector2" runat="server" MinuteIncrement="1" SecondIncrement="1"
                                SelectedTimeFormat="Twelve" AllowSecondEditing="true" DisplaySeconds="False" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbleventtype" CssClass="Labels" runat="server" Text="Event Type"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="drlEventType" runat="server" CssClass="Labels" 
                                ForeColor="Black" >
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="lbladdeventtype" CssClass="Labels" runat="server" Text="Add Event Type"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtaddeventtype" Text="" CssClass="Input" width="120"/>
                            
                            <asp:Button ID="cmdadd2" CssClass="Buttons" runat="server" Text="Add" Width="50px"
                                OnClick="cmdadd2_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <asp:Label ID="lblEventComment" runat="server" Text="Comments" CssClass="Labels"></asp:Label>
                        </td>
                        <td colspan="3" height="55">
                            <asp:TextBox ID="txtEventComment" runat="server" CssClass="Input" Height="77px" Width="450px"
                                TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
              
            
            <tr>
                <td height="20px" colspan="4">
                </td>
            </tr>
            <tr>
                <td height="50px" colspan="4" style="border: none">
                    <asp:UpdatePanel ID="updPerson" runat="server">
                        <ContentTemplate>
                            <table width="75%">
                                <%--<tr>
                                    <td width="25%">
                                        <asp:Label ID="lblEnternpir" CssClass="Labels" runat="server" Text="NRIC/FIN No."></asp:Label>
                                    </td>
                                    <td width="25%">
                                        <asp:TextBox ID="txtNricNo" CssClass="Input" runat="server" AutoPostBack="True" OnTextChanged="txtNricNo_TextChanged"></asp:TextBox>
                                        <asp:Label ID="lblerr1" CssClass="ValSummary" runat="server" Text="*" Font-Size="Smaller"
                                            ForeColor="Red"></asp:Label>
                                    </td>
                                    <td width="25%">
                                        <asp:Label ID="lblEnterName" CssClass="Labels" runat="server" Text="Name"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtname" CssClass="Input" runat="server" Width="192px"></asp:TextBox>
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td colspan="4" height="35">
                                        <asp:Label ID="lblperson" CssClass="Labels" runat="server" Text="Person In Charge: Contact Details"
                                            Font-Bold="True"></asp:Label>
                                    </td>
                                    <tr>
                                    <td width="25%">
                                        <asp:Label ID="lblEnternpir" CssClass="Labels" runat="server" Text="NRIC/FIN No."></asp:Label>
                                    </td>
                                    <td width="25%">
                                        <asp:TextBox ID="txtNricNo" CssClass="Input" runat="server" AutoPostBack="True" 
                                            OnTextChanged="txtNricNo_TextChanged" Width="192px"></asp:TextBox>
                                        <asp:Label ID="lblerr1" CssClass="ValSummary" runat="server" Text="*" Font-Size="Smaller"
                                            ForeColor="Red"></asp:Label>
                                    </td>
                                    <td width="25%" align="center">
                                        <asp:Label ID="lblEnterName" CssClass="Labels" runat="server" Text="Name"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtname" CssClass="Input" runat="server" Width="192px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="25%">
                                        <asp:Label ID="lblEnterContactno" CssClass="Labels" runat="server" Text="Contact No."></asp:Label>
                                    </td>
                                    <td width="25%">
                                        <asp:TextBox ID="txtContact" CssClass="Input" runat="server" Width="192px"></asp:TextBox>
                                    </td>
                                    <td width="25%" align="center">
                                        <asp:Label ID="lblEnterPosition" CssClass="Labels" runat="server" Text="Position"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPosition" CssClass="Input" runat="server" Width="192px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="25%">
                                        <asp:Label ID="lblsuperior" CssClass="Labels" runat="server" Text="Created By :"></asp:Label>
                                    </td>
                                    <td width="25%">
                                        <asp:TextBox ID="txtSupireorName" CssClass="Input" runat="server" Width="192px"></asp:TextBox>
                                    </td>
                                   <%-- <td width="25%">
                                        <asp:Label ID="lblEnterPosition" CssClass="Labels" runat="server" Text="Position"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPosition" CssClass="Input" runat="server" Width="192px"></asp:TextBox>
                                    </td>
                                    <td width="25%">
                                        <asp:Label ID="lblEnterContactno" CssClass="Labels" runat="server" Text="Contact No."></asp:Label>
                                    </td>
                                    <td width="25%">
                                        <asp:TextBox ID="txtContact" CssClass="Input" runat="server"></asp:TextBox>
                                    </td>--%>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td colspan="1" height="40px">
                </td>
            </tr>
            </table>
            <table  width="750px" style="margin-left:0.005em; margin-bottom:-0.4em;border:1px;border-style:groove; border-color:Black;background: url(../Images/1397d40aa687.jpg)">
                                            <tr>
                                                <td colspan="4" align="center" style="width: 897px">
                    <asp:Button ID="cmdbuttonadd" CssClass="Buttons" runat="server" Text="Add" Width="85px"
                        OnClick="cmdbuttonadd_Click" />
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="cmdbuttonclear" CssClass="Buttons" runat="server" Text="Cancel" Width="85px"
                        OnClick="cmdbuttonClear_Click" />
             </td></tr>
        </table>
        </asp:panel>
        <br />
    </div>
</asp:Content>
