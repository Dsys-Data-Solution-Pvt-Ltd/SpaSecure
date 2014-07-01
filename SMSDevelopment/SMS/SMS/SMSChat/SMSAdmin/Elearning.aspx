<%@ Page Language="C#" MasterPageFile="../SMSmaster.Master" AutoEventWireup="true" CodeBehind="Elearning.aspx.cs" Inherits="SMS.SMSAdmin.Elearning" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="divContainer">
      <div class="divHeader"><span class="pageTitle">E-Learning</span> </div>
      <br />
     
         <table >
            <tr>
                <td>
                    <asp:Label ID="Label1" CssClass="Labels" runat="server" Text="Add New Tutorial/PPT"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" CssClass="Input" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="Button1" CssClass="Buttons" runat="server" Text="Browse" />
                </td>
            </tr>
            <tr>
                <td colspan="3" align="center">
                    <asp:Button ID="btnUpload" CssClass="Buttons" runat="server" Text="Upload" 
                        onclick="btnUpload_Click" />
                </td>
            </tr>
         </table>
         <br />
           
         <table >
            <tr>
                <td colspan="3">
                    <asp:Label ID="Label2" CssClass="Labels" runat="server" Text="Assign Tutorial to-" font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="CheckBox1" CssClass="Labels" runat="server" Text="Staff" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="CheckBox2" CssClass="Labels" runat="server" Text="Guards" />
                </td>
            </tr>
            <tr>
                <td colspan="3" align="left">
                    <asp:Button ID="btnSelelctCategory" CssClass="Buttons" runat="server" 
                        Text="Select Category" onclick="SelelctCategory_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" CssClass="Labels" runat="server" Text="Time"></asp:Label>
                </td>
                  <td>
                                <asp:TextBox runat="server" ID="TextBox2" Text="" CssClass="Input" />
                                <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                                    Format="MM/dd/yyyy" TargetControlID="TextBox2" PopupButtonID="imgBtnFromDate" />
                                <asp:ImageButton ID="imgBtnFromDate" runat="server" ImageAlign="AbsMiddle" 		ImageUrl="~/Images/calendar.bmp" />
                  </td>
                </tr>
                <tr>  
               
             
                <td>
                    <asp:Label ID="Label4" CssClass="Labels" runat="server" Text="Date"></asp:Label>
                </td>
                
                 <td>
                                <asp:TextBox runat="server" ID="TextBox3" Text="" CssClass="Input" />
                                <AJAX:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="AjaxCalendar"
                                    Format="MM/dd/yyyy" TargetControlID="TextBox3" PopupButtonID="imgBtnFromDate1" />
                                <asp:ImageButton ID="imgBtnFromDate1" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp" />
                   </td>
                
                
            </tr>
            
         </table>
        
        <br />
        <center>
            <%--  <div style="overflow: auto">
            <asp:gridview id="gvelearnTable" runat="server" allowpaging="true" allowsorting="true"
                autogeneratecolumns="false" cellpadding="5" cellspacing="0" width="70%" 
                onrowdatabound="gvelearn_RowDataBound"
                onrowcommand="gvelearn_RowCommand" 
                onpageindexchanging="gvelearn_PageIndexChanging"
                cssclass="GridMain">
            
            <HeaderStyle cssclass="HeaderRow"/>
            <RowStyle cssclass="NormalRow"/>
            <AlternatingRowStyle cssclass="AlternateRow"/>
            <PagerStyle cssclass="PagingRow" horizontalalign="Right" height="20px"/>
            <SelectedRowStyle cssclass="HighlightedRow"/>
            <EmptyDataRowStyle cssclass="NoRecords"/>
            <EmptyDataTemplate>
                <asp:Label ID="lblNoRecords" text="Your search did not match any Key or, there may be no records in the system." runat="server">
                </asp:Label>
                <p>Suggestions:</p>                    
                <li>Try different keywords.</li>
                <li>Try fewer keywords.</li>
                <li>Make sure all words are spelled correctly.</li>
                <li>There may be no records in the system.</li>
                <li>To add Billing Table click the Add New Billing Table button.</li>
            </EmptyDataTemplate>
            

            <Columns>
            <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" >
               <ItemTemplate >
                  <asp:CheckBox  runat="server"  ></asp:CheckBox>
               </ItemTemplate>
            </asp:TemplateField>     
                <asp:BoundField datafield="UserID" headertext="Employee Code"></asp:BoundField>
                <asp:BoundField datafield="user_name" headertext="Name"></asp:BoundField>
  
            </Columns>
    </asp:gridview>
     </div>--%>
        </center>
        <br />
        <left>
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnAssign" CssClass="Buttons" runat="server" Text="Assign" onclick="Assign_click" />
                    </td>
                    <td>
                        <asp:Button ID="btnUnassign" CssClass="Buttons" runat="server" Text="Unassign" onclick="Unassign_click" />
                    </td>
                </tr>
            </table>
        </left>
        <br />
    </div>
    <br />
 </asp:Content>
