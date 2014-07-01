<%@ Page Language="C#" MasterPageFile="../SMSmaster.Master" AutoEventWireup="true" CodeBehind="EditORViewShift.aspx.cs" Inherits="SMS.SMSAdmin.EditORViewShift" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainer">
        <div class="divHeader"><span class="pageTitle">Edit/View Shift</span>
        </div>
        
      <div>
          <asp:panel runat="server">
             <table>
                <tr>
                       <td>
                       <table align="left">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblShiftID1" CssClass="Labels" runat="server" Text="Shift ID"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtShiftID1" CssClass="Input" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblShiftName1" CssClass="Labels" runat="server" Text="Shift Name"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtShiftName1" CssClass="Input"  runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                     </table>
                   </td>
                </tr>
                 <tr>
                         <td>
                              <table align="left">
                        <tr>
            
                            <td align="left">
                                <asp:GridView ID="GridView1"  CssClass="GridMain" runat="server" AutoGenerateColumns="false" Width="400px">
                                    <AlternatingRowStyle CssClass="AlternateRow" />
                                    <HeaderStyle CssClass="HeaderRow" />
                                    <RowStyle CssClass="NormalRow" />
                                    <Columns>
                                        <asp:CheckBoxField />
                                        <asp:BoundField HeaderText="Employee Name" />
                                    </Columns>
                                </asp:GridView>
                                <br />
                                <center>
                                <asp:Button ID="btnSave1" CssClass="Buttons" runat="server" Text="Save" />
                                </center>
                            </td>
                            <td>
                            </td>
                            <td align="left">
                                <asp:GridView ID="GridView2" CssClass="GridMain" runat="server" AutoGenerateColumns="false" Width="400px">
                                    <AlternatingRowStyle CssClass="AlternateRow" />
                                    <HeaderStyle CssClass="HeaderRow" />
                                    <RowStyle CssClass="NormalRow" />
                                    <Columns>
                                        <asp:CheckBoxField />
                                        <asp:BoundField HeaderText="Location" />
                                    </Columns>
                                </asp:GridView>
                                <br />
                                <center>
                                <asp:Button ID="btnSave2" CssClass="Buttons" runat="server" Text="Save" />
                                </center>
                            </td>
                        </tr>
                    </table>
                      </td>
                 </tr>
             
             </table>
         </asp:panel>
      </div>  
       
    </div>
    <br />
</asp:Content>
