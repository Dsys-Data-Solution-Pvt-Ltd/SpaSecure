<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="TrainingEvaluation.aspx.cs" Inherits="SMS.SuperVisor.TrainingEvaluation" Title="" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
         .style1
        {
            width: 50%;
             font-weight: 700;
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
        
         .style10
         {
             width: 268435456px;
             height: 20px;
         }
                 
         .style12
         {
             width: 50%;
             height: 20px;
             font-weight: bold;
         }
         .style14
         {
             width: 492px;
         }
         .style15
         {
             width: 138px;
         }
        
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <asp:Panel ID="printview" runat="server" > 
  <div class="divHeader">
                <span class="pageTitle">Training Evaluation Form</span></div>
<table>
                    <tr>
                        <td class="style1">
                            Name of Trainee:</td>
                        <td colspan="1">
                            <asp:TextBox ID="txtNameofTrainee" runat="server" style="margin-left: 0px" 
                                Width="241px"></asp:TextBox>
                                
                                
                                
                        </td>
                        <td class="style1">
                            Date:</td>
                        <td>
                            <asp:TextBox ID="txtdat" runat="server"></asp:TextBox>
                            <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                              Format="MM/dd/yyyy" TargetControlID="txtDat" PopupButtonID="imgBtnFromDate2" />
                              <asp:ImageButton ID="imgBtnFromDate2" runat="server" 
                              ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp" 
                             style="width: 16px" Width="28px"/>
                         </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            NRIC No. :</td>
                        <td colspan="1">
                           <asp:TextBox ID="txtNRICno" runat="server" style="margin-left: 0px"></asp:TextBox>
                        </td>
                           
                         <td class="style1">
                            Cource Title :</td>
                        <td class="style3">
                           <asp:TextBox ID="txtCourceTitle" runat="server" style="margin-left: 0px"></asp:TextBox>
                       </td>   
                           
                    </tr>
                  
    </table>
    
    <br /><br />
    <table cellspacing="0">
    <tr>
                        <td class="style2" colspan="2">
                            Dear Trainee,<br />
                            <p style="width: 398%; height: 98px;text-align:'justify'; font-family: 'Times New Roman', Times, serif;">
                            In our effort to improve upon the standards of our services, we value your feedback.Towards this objective, your feedback  on <br />regards to your NSRS/WSQ Course which you have undergone is very
                            important and helpful in assisting us to better understand <br />the process of this Evaluation.<br /><br />
                            Please give us a few minutes of your time  to rate us on the following parameters. Any additional
                            suggestions/observations that you may have are welcomed.
                            </p>
                        </td>
                        
                    </tr>
                    <tr>
                        <td class="style2" colspan="2" style="font-weight: bold">
                            Please choose the following:</td>
                    </tr>
                    <tr>
                        <td class="style7">
                            Handouts/Materials</td>
                        <td class="style7" align="center" valign="middle">
                           <asp:Label ID="lblHand" runat="server" style="margin-left: 0px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                    <td class="style7">
                            Duration of Assessment</td>
                    <td class="style7" align="center" valign="middle">
                        <asp:Label ID="lblDOA" runat="server" style="margin-left: 0px"></asp:Label>
                      </td>
                    </tr>
                    <tr>
                    <td class="style7">
                            Evaluator's Support Services</td>
                    <td class="style7">
                        <asp:Label ID="lblESS" runat="server" style="margin-left: 0px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                    <td class="style7">
                            Evaluator's Question</td>
                    <td class="style7">
                        <asp:Label ID="lblEQ" runat="server" style="margin-left: 0px"></asp:Label>
                        </td>
                     </tr>
                   <tr>
                    <td class="style7">
                            Evaluator's Capabilities</td>
                    <td class="style7">
                        <asp:Label ID="lblEC" runat="server" style="margin-left: 0px"></asp:Label>
                    </td>
                    </tr>
                    <tr>
                    <td class="style7">
                            Responsiveness/Reliability</td>
                    <td class="style7">
                        <asp:Label ID="lblRR" runat="server" style="margin-left: 0px"></asp:Label></td>
                    </tr>
    </table>
    <br />
    <br />
    <br />
    <table>
    <tr>
    <td colspan="2">
        <b>Key: </b>
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
        Other Comments:
    </td>
    </tr>
    <tr>
    <td colspan="2">
        <asp:Label ID="txtcomment" runat="server" TextMode="MultiLine" Width="851px"></asp:Label>
    </td>
    </tr>
    <tr>
    <td colspan="2">
        Thank You for your invaluable time !
    </td>
    </tr>
    <tr>
    <td colspan="2">
        <b>Evaluated By </b>:
    </td>
    </tr>
    <tr>
    <td colspan="2" align="center" height="40">
        <asp:button id="btnNewPass" text="Print" runat="server" cssclass="Buttons" 
            onclick="btnNewPass_Click" Font-Bold="True" Height="30px" Width="100px" />
    </td>
    </tr>
    </table>
    </asp:Panel>
</asp:Content>