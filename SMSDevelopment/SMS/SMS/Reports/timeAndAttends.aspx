<%@ Page Language="C#" MasterPageFile="../SMSmaster.Master" AutoEventWireup="true" CodeBehind="timeAndAttends.aspx.cs" Inherits="SMS.Reports.timeAndAttends" Title="Untitled Page" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainer">
        <div class="divHeader"><span class="pageTitle">Time And Attends</span></div>
        <br />
        <table align="left">
            <tr>
                <td>
                    <asp:Label ID="lblStartDate1" CssClass="Labels" runat="server" Text="Start Date"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtStartDate1" CssClass="Input" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblEndDate1" CssClass="Labels" runat="server" Text="End Date"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEndDate1" CssClass="Input" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblMonth1" CssClass="Labels" runat="server" Text="Month"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtMonth1" CssClass="Input" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblID1" CssClass="Labels" runat="server" Text="ID"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtID1" CssClass="Input" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblDepartment1" CssClass="Labels" runat="server" Text="Department"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDepartment1" CssClass="Input" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblYear1" CssClass="Labels" runat="server" Text="Year"></asp:Label>
                </td>
                <td>
                 <asp:TextBox ID="txtYear1" CssClass="Input" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="8" align="left">
                    <asp:Button ID="btnSearch1" CssClass="Buttons" runat="server" Text="Search" Width="80px" />
                </td>
            </tr>
        </table>
            </div>

        <div>
        <asp:GridView ID="GridView1" CssClass="GridMain" runat="server" AllowPaging="true" AllowSorting="true" 
            AutoGenerateColumns="false" CellPadding="5" CellSpacing="0" Width="100%" > 
            <AlternatingRowStyle CssClass="AlternateRow" />
            <HeaderStyle CssClass="HeaderRow" />
            <RowStyle CssClass="NormalRow" />
           <HeaderStyle CssClass="HeaderRow"/>
            <RowStyle CssClass="NormalRow"/>
            <AlternatingRowStyle CssClass="AlternateRow"/>
            <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="20px"/>
            <SelectedRowStyle CssClass="HighlightedRow"/>
            <EmptyDataRowStyle CssClass="NoRecords"/>
            <EmptyDataTemplate>
            <asp:Label ID="lblNoRecords" Text="Your search did not match any Key or, there may be no records in the system." runat="server">
                </asp:Label>
                 <p>Suggestions:</p>                    
                <li>Try different keywords.</li>
                <li>Try fewer keywords.</li>
                <li>Make sure all words are spelled correctly.</li>
                <li>There may be no records in the system.</li>
                <li>To add Billing Table click the Add New Billing Table button.</li>
            </EmptyDataTemplate>
            
           
           
           
           
           
            <Columns>
                <asp:BoundField HeaderText="Date" />
                <asp:BoundField HeaderText="Name" />
                <asp:BoundField HeaderText="Employee ID" />
                <asp:BoundField  HeaderText="Department"/>
                <asp:BoundField HeaderText="Time In" />
                <asp:BoundField HeaderText="Time Out" />
                <asp:TemplateField HeaderText="Edit/View" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="../Images/Edit.gif" ID="btnEdit" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.locid") %>' CommandName="EditRow" runat="server"/>
                    </ItemTemplate>
                </asp:TemplateField> 
                
                
            </Columns>
        </asp:GridView>
        </div>
        <br />
        <br />
        <div >
        <table align="left">
            <tr>
                <td>
                    <asp:Label ID="employee1" CssClass="Labels" runat="server" Text="Total Employee" 
                        ForeColor="#000099"></asp:Label>

                    <asp:Label ID="employee2" CssClass="Labels" runat="server" ForeColor="#000099"></asp:Label>&nbsp;&nbsp;
                </td>
                <td>
                    <asp:Label ID="leaves1" CssClass="Labels" runat="server" Text="Leaves" ForeColor="#000099"></asp:Label>
<asp:Label ID="leaves2" CssClass="Labels" runat="server" ForeColor="#000099"></asp:Label>&nbsp;&nbsp;
                </td>
                <td>
                    <asp:Label ID="workingday1" CssClass="Labels" runat="server" Text="Total Working Day" 
                        ForeColor="#000099"></asp:Label>
&nbsp;<asp:Label ID="workingday2" CssClass="Labels" runat="server" ForeColor="#000099"></asp:Label>&nbsp;&nbsp;
                </td>
                <td>
                    <asp:Label ID="workinghour1"  CssClass="Labels" runat="server" Text="Working Hour" 
                        ForeColor="#000099"></asp:Label>
&nbsp;<asp:Label ID="workinghour2" CssClass="Labels" runat="server" ForeColor="#000099"></asp:Label>
            


                &nbsp;</td>
                
            </tr>
            <tr>
            <td> 
            
                <asp:Label ID="exportto" CssClass="Labels" runat="server" Text="ExportTo"></asp:Label>&nbsp;
               
            
                    <asp:DropDownList ID="DropDownList1" CssClass="Labels" runat="server" ForeColor="#000099">
                   
                   <asp:ListItem>Excel</asp:ListItem>
                        <asp:ListItem>Pdf</asp:ListItem>
                    
                    </asp:DropDownList>
                
            </td>
            <td>
            
                    <asp:Button ID="btnPrint" CssClass="Buttons" runat="server" Text="E-Mail" Width="100px" />
                
            </td>
            <td>
            
                    <asp:Button ID="btnEmail" CssClass="Buttons" runat="server" Text="Print" Width="100px" />
                
            </td>
            </tr>
           
        </table>
        <br />
    <br />
    </div>
</asp:Content>
