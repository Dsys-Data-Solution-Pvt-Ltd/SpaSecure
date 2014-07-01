<%@ Page Language="C#" MasterPageFile="../SMSmaster.Master" AutoEventWireup="true" CodeBehind="TestOnTraining.aspx.cs" Inherits="SMS.Reports.TestOnTraining" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>

<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">

                <table>
                    <tr>
                        <td class="style1">
                            Name of Trainee:</td>
                        <td colspan="3">
                            <asp:TextBox ID="TextBox1" runat="server" style="margin-left: 0px"></asp:TextBox></td>
                        <td class="style7">
                            Date:</td>
                        <td>
                            <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                            <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                              Format="MM/dd/yyyy" TargetControlID="txtDate" PopupButtonID="imgBtnFromDate2" />
                              <asp:ImageButton ID="imgBtnFromDate2" runat="server" 
                              ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp" 
                             onclick="imgBtnFromDate2_Click" style="width: 16px" Width="28px"/>
                         </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            Nric:</td>
                        <td class="style3" colspan="5">
                           <asp:TextBox ID="TextBox2" runat="server" style="margin-left: 0px"></asp:TextBox></td>
                    </tr>
                  
    </table>
    <br /><br />
    <table cellspacing="0">
    <tr>
                        <td class="style2" colspan="6">
                            Dear Trainee,<br />
                            <p style="width: 398%; height: 98px; font-family: 'Times New Roman', Times, serif;">
                            In our effort to improve upon the standards of our services, we have been awarded with ISO 9001 cerifitcation.<br />
                            Towards this objective, your feedback on regards to your NSRS Course which you have undergone is very<br />
                            important and helpful in assisting us to better understand the process of this Evaluation.<br /><br />
                            Please give us a few minutes of your time  to rate us on the following parameters. Any additional<br />
                            suggestions/observations that you may have are welcomed.
                            </p>
                        </td>
                        
                    </tr>
                    <tr>
                        <td class="style2" colspan="6" style="font-weight: bold">
                            Please tick the following boxes:</td>
                    </tr>
                    <tr>
                        <td class="style6" align="center">
                            PARAMETERS</td>
                        <td class="style5" align="center">
                            Poor</td>
                        <td class="style5" align="center"> 
                            Fair</td>
                        <td class="style5" align="center">
                            Average</td>
                        <td class="style5" align="center">
                            Good</td>
                        <td class="style5" align="center">
                            Excellent</td>
                    </tr>
                    <tr>
                        <td class="style7">
                            Handouts/Materials</td>
                        <td class="style7"></td>
                        <td class="style7"></td>
                        <td class="style7"></td>
                        <td class="style7"></td>
                        <td class="style7"></td>
                    </tr>
                    
                    <tr>
                    <td class="style7">
                            Duration of Assessment</td>
                    <td class="style7"></td>
                    <td class="style7"></td>
                    <td class="style7"></td>
                    <td class="style7"></td>
                    <td class="style7"></td>
                    </tr>
                    <tr>
                    <td class="style7">
                            Evaluator's Support Services</td>
                    <td class="style7"></td>
                    <td class="style7"></td>
                    <td class="style7"></td>
                    <td class="style7"></td>
                    <td class="style7"></td>
                    </tr>
                    <tr>
                    <td class="style7">
                            Evaluator's Question</td>
                    <td class="style7"></td>
                    <td class="style7"></td>
                    <td class="style7"></td>
                    <td class="style7"></td>
                    <td class="style7"></td>
                    </tr>
                                        <tr>
                    <td class="style7">
                            Evaluator's Capabilities</td>
                    <td class="style7"></td>
                    <td class="style7"></td>
                    <td class="style7"></td>
                    <td class="style7"></td>
                    <td class="style7"></td>
                    </tr>
                                        <tr>
                    <td class="style7">
                            Responsiveness/Reliability</td>
                    <td class="style7"></td>
                    <td class="style7"></td>
                    <td class="style7"></td>
                    <td class="style7"></td>
                    <td class="style7"></td>
                    </tr>
    </table>
    <br />
    <table>
    <tr>
    <td colspan="2">
    Key:
    </td>
    </tr>
    <tr>
    <td>
    </td>
    <td class="style9">
    Poor - A critical concern area, which needs immediate improvement.<br />
    Fair - A concern area, not critical but does need improvement.<br />
    Average - In line with industry standards and no room to complain.<br />
    Good - Commendable and far exceeds expected standards.<br />
    Excellent - Unparalled and can be used as a benchmark for Industry Standards.<br />
    </td>
    </tr>
    <tr>
    <td class="style8">
    Comments:
    </td>
    </tr>
    <tr>
    <td colspan="2">
        <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine" Width="851px"></asp:TextBox>
    </td>
    </tr>
    </table>

</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">

    <style type="text/css">
        .style1
        {
            width: 50%;
        }
        .style2
        {
            width: 100%;
        }
        .style3
        {
            width: 100%;
        }
        .style5
        {
            width: 93px;text-align:center;font-style:italic;font-weight:bold;border-style:solid; border-width:thin;
        }
        .style6
        {
            width: 400px;text-align:center;font-weight:bold; border-style:solid; border-width:thin;
        }
        .style7
        {
            width: 400px;text-align:left;border-style:solid; border-width:thin;
        }
        .style8
        {
            font-weight:bold;
        }
        .style9
        {
            width: 797px;
        }
    </style>

</asp:Content>
