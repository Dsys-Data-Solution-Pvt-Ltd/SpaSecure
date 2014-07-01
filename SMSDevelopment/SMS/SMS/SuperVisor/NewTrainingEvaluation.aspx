<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="NewTrainingEvaluation.aspx.cs" Inherits="SMS.SuperVisor.NewTrainingEvaluation"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
         .style11
         {
             width: 130px;
         }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div class="divHeader">
                <span class="pageTitle">Training Evaluation Form</span></div>
                <div>
            <asp:Label ID="lblerror" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"></asp:Label></div>
        <br />
<table class="table" style=" width:50.6em">
                
                    <tr>
                        <td style="width:10em">
                            Name of Trainee:</td>
                        <td colspan="1" >
                            <asp:TextBox ID="txtName" runat="server" style="margin-left: 0px" 
                                Width="153px"></asp:TextBox></td>
                        <td>
                            Date:</td>
                        <td style=" width:14em">
                            <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                            <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                              Format="MM/dd/yyyy" TargetControlID="txtDate" PopupButtonID="imgBtnFromDate2" />
                              <asp:ImageButton ID="imgBtnFromDate2" runat="server" 
                              ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp" 
                             style="width: 16px" Width="28px"/>
                         </td>
                    </tr>
                    <tr>
                        <td>
                            NRIC No. :</td>
                        <td colspan="1">
                           <asp:TextBox ID="txtNRIC" runat="server" style="margin-left: 0px"></asp:TextBox>
                        </td>
                           
                         <td >
                            Course Title :</td>
                        <td colspan="5">
                           <asp:TextBox ID="txtCourseTitle" runat="server" style="margin-left: 0px"></asp:TextBox>
                       </td>   
                           
                    </tr>
                    <tr>
                      <td >
                            Venue :</td>
                        <td colspan="5">
                           <asp:TextBox ID="txtvenue" runat="server" style="margin-left: 0px"></asp:TextBox>
                       </td>                             
                    </tr>
                  
    </table>
    <br /><br />
    <table cellspacing="0" class="table">
    <tr>
                        <td class="style2" colspan="6">
                            Dear Trainee,<br />
                            <p style="width: 398%; height: 98px;text-align:'justify'; font-family: 'Times New Roman', Times, serif;">
                            In our effort to improve upon the standards of our services, we value your feedback.Towards this objective, your feedback  on <br />regards to your Course which you have undergone is very
                            important and helpful in assisting us to better understand <br />the process of this Evaluation.<br /><br />
                            Please give us a few minutes of your time  to rate us on the following parameters. Any additional
                            suggestions/observations that you may have are welcomed.
                            </p>
                        </td>
                        
                    </tr>
                    <tr>
                        <td class="style2" colspan="6" style="font-weight: bold">
                            Please choose the following:</td>
                    </tr>
                    <tr>
                        <td class="style7">
                            Handouts/Materials</td>
                        <td class="style7" align="center" valign="middle">
                           <asp:DropDownList ID="ddlHandout" runat="server" CssClass="Input" Width="100px">
                                 <asp:ListItem></asp:ListItem>
                                 <asp:ListItem>Poor</asp:ListItem>
                                 <asp:ListItem>Fair</asp:ListItem>
                                 <asp:ListItem>Average</asp:ListItem>                                                 
                                 <asp:ListItem>Good</asp:ListItem>
                                 <asp:ListItem>Excellent</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                    <td class="style7">
                            Duration of Assessment</td>
                    <td class="style7" align="center" valign="middle">
                        <asp:DropDownList ID="ddlDOA" runat="server" CssClass="Input" Width="100px">
                                 <asp:ListItem></asp:ListItem>
                                 <asp:ListItem>Poor</asp:ListItem>
                                 <asp:ListItem>Fair</asp:ListItem>
                                 <asp:ListItem>Average</asp:ListItem>                                                 
                                 <asp:ListItem>Good</asp:ListItem>
                                 <asp:ListItem>Excellent</asp:ListItem>
                        </asp:DropDownList>
                      </td>
                    </tr>
                    <tr>
                    <td class="style7">
                            Evaluator's Support Services</td>
                    <td class="style7">
                        <asp:DropDownList ID="ddlESS" runat="server" CssClass="Input" Width="100px">
                                 <asp:ListItem></asp:ListItem>
                                 <asp:ListItem>Poor</asp:ListItem>
                                 <asp:ListItem>Fair</asp:ListItem>
                                 <asp:ListItem>Average</asp:ListItem>                                                 
                                 <asp:ListItem>Good</asp:ListItem>
                                 <asp:ListItem>Excellent</asp:ListItem>
                        </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                    <td class="style7">
                            Evaluator's Question</td>
                    <td class="style7">
                        <asp:DropDownList ID="ddlEQ" runat="server" CssClass="Input" Width="100px">
                                 <asp:ListItem></asp:ListItem>
                                 <asp:ListItem>Poor</asp:ListItem>
                                 <asp:ListItem>Fair</asp:ListItem>
                                 <asp:ListItem>Average</asp:ListItem>                                                 
                                 <asp:ListItem>Good</asp:ListItem>
                                 <asp:ListItem>Excellent</asp:ListItem>
                        </asp:DropDownList>
                        </td>
                     </tr>
                   <tr>
                    <td class="style7">
                            Evaluator's Capabilities</td>
                    <td class="style7">
                        <asp:DropDownList ID="ddlEC" runat="server" CssClass="Input" Width="100px">
                                 <asp:ListItem></asp:ListItem>
                                 <asp:ListItem>Poor</asp:ListItem>
                                 <asp:ListItem>Fair</asp:ListItem>
                                 <asp:ListItem>Average</asp:ListItem>                                                 
                                 <asp:ListItem>Good</asp:ListItem>
                                 <asp:ListItem>Excellent</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    </tr>
                    <tr>
                    <td class="style7">
                            Responsiveness/Reliability</td>
                    <td class="style7">
                        <asp:DropDownList ID="ddlRR" runat="server" CssClass="Input" Width="100px">
                                 <asp:ListItem></asp:ListItem>
                                 <asp:ListItem>Poor</asp:ListItem>
                                 <asp:ListItem>Fair</asp:ListItem>
                                 <asp:ListItem>Average</asp:ListItem>                                                 
                                 <asp:ListItem>Good</asp:ListItem>
                                 <asp:ListItem>Excellent</asp:ListItem>
                        </asp:DropDownList></td>
                    </tr>
    </table>
    <br />
    <br />
    <br />
    <table class="table">
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
        <asp:TextBox ID="txtcomment" runat="server" TextMode="MultiLine" Width="851px" 
            Height="75px"></asp:TextBox>
    </td>
    </tr>
    <tr>
    <td colspan="2">
        Thank You for your invaluable time !
    </td>
    </tr>
    <tr>
    <td colspan="2" align="center" height="45">
        <asp:button id="btnNewPass" text="Save" runat="server" 
                            cssclass="Buttons" onclick="btnNewPass_Click" 
            Width="85px" Height="25px"/>
    </td>
    </tr>
    </table>
</asp:Content>