<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="ChangeActionReviewStageMD.aspx.cs" Inherits="SMS.SuperVisor.ChangeActionReviewStageMD" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 154px;
        }
        .style2
        {
            width: 425px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="divContainer">

    <asp:Panel ID="printview" runat="server" > 

    <div class="divHeader">
    
            <span class="pageTitle">After Action Review Form</span>
    </div> 
    <div>
           <asp:Label id="lblerror" runat="server" Text="lblerror " ForeColor="Red" CssClass="ValSummary" Visible="false"></asp:Label><br /><br />
    </div>
    <div id="divAdvSearch" runat="server" visible="true" class="table">
        <asp:label ID="lblheading" runat="server" CssClass="Labels" Text="This form is for all staff to report,correct and verify faults found in the day to day operations."></asp:label><br /><br />
        <div id="divClient" runat="server">
            <table border="1" width="100%" >
            <tr>
                <td>
                    <asp:Label runat="server" CssClass="Labels" ID="lblIssu" Text="Issue Raised"></asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="txtIssueRaised" CssClass="Input" 
                        Width="622px" Height="19px" Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" CssClass="Labels" ID="Label2" Text="Description Of Problem"></asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="txtdescProb" CssClass="Input" 
                        Width="622px" TextMode="MultiLine" Height="131px" Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" CssClass="Labels" ID="Label3" Text="Raised By"></asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="txtBy" CssClass="Input" 
                        Width="622px" TextMode="SingleLine" Height="22px" Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                 <td>
                        <asp:Label ID="lblDate" Text="Date :" CssClass="Labels" runat="server"></asp:Label>
                </td>
                <td>
                        <asp:Label runat="server" ID="calDate" CssClass="Input" Font-Bold="True"/>
                </td>
            </tr>
            </table>
        </div>  
        <div id="divoperations" runat="server">
            <table border="1" width="100%">
            <tr>
                <td class="style1">
                    <asp:Label runat="server" CssClass="Labels" ID="Label1" Text="Root Cause of the Problem"></asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="txtRootCause" CssClass="Input" 
                        Width="622px" TextMode="MultiLine" Height="131px" Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label runat="server" CssClass="Labels" ID="Label4" Text="Analysis Of Critical Task Performance"></asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="txtAOC" CssClass="Input" 
                        Width="622px" TextMode="MultiLine" Height="131px" Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label runat="server" CssClass="Labels" ID="Label5" Text="Analysis Of OutCome"></asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="txtAO" CssClass="Input" 
                        Width="622px" TextMode="MultiLine" Height="131px" Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label runat="server" CssClass="Labels" ID="Label6" Text="Goals & Objectives"></asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="txtGO" CssClass="Input" 
                        Width="622px" TextMode="MultiLine" Height="131px" Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label runat="server" CssClass="Labels" ID="Label7" Text="Actions Required To Fix The Problem"></asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="txtAR" CssClass="Input" 
                        Width="622px" TextMode="MultiLine" Height="131px" Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label runat="server" CssClass="Labels" ID="Label8" Text="Actions Required To Prevent Recurrence"></asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="txtART" CssClass="Input" 
                        Width="622px" TextMode="MultiLine" Height="131px" Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label runat="server" CssClass="Labels" ID="Label9" Text="Expected Completion Date"></asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="txtexpected" Text="" CssClass="Input"/>
                </td>
            </tr>
           </table>
        </div> 
        
        <div id="divMD" runat="server">
            <table border="1" width="100%">
                <tr>
                    <td class="style2">
                        <asp:Label runat="server" CssClass="Labels" ID="Label10" Text="Action and Complete Date Approved"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtAction" CssClass="Input" 
                             Font-Bold="True" Width="162px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <asp:Label runat="server" CssClass="Labels" ID="Label12" Text="Verification of Effectiveness of the Corrective and Preventative Actions:"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <asp:Label runat="server" CssClass="Labels" ID="Label13" Text="Corrective action effective. Comments:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtcomments1" CssClass="Input" 
                             Font-Bold="True" Width="362px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <asp:Label runat="server" CssClass="Labels" ID="Label14" Text="Preventative action effective. Comments:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtcomments2" CssClass="Input" 
                             Font-Bold="True" Width="361px" Height="16px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <asp:Label runat="server" CssClass="Labels" ID="Label15" Text="Procedure updated to reflect change. Comments:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtComments3" CssClass="Input" 
                             Font-Bold="True" Width="358px"></asp:TextBox>
                    </td>
                </tr>
                    <tr>
                    <td class="style2">
                        <asp:Label runat="server" CssClass="Labels" ID="Label16" Text="Verified By:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="Txtverifyby" CssClass="Input" 
                             Font-Bold="True" ></asp:TextBox>
                    </td>
                </tr>
                 </tr>
                    <tr>
                    <td class="style2">
                        <asp:Label runat="server" CssClass="Labels" ID="lblcreditNote" Text="Credit Note"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtcreditNote" CssClass="Input" 
                             Font-Bold="True" ></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    
     </asp:Panel>
    <br />
    <br />
    <div align="center">
         <asp:Button ID="btnAdd" runat="server" 
                            CssClass="Buttons" Text="Submit"  Width="100px" Height="30px"
                    onclick="btnAdd_Click"/>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                
                
                <asp:Button ID="btnprint" runat="server" CssClass="Buttons" Text="Print" 
                    Width="100px" Height="30px" onclick="btnprint_Click"/>
    
    
    </div>
    
    
    
</div>
</asp:Content>
