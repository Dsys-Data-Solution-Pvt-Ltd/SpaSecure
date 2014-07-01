<%@ Page Title="" Language="C#" MasterPageFile="~/SMSmaster.Master" AutoEventWireup="true"
    CodeBehind="LocationStaffLink.aspx.cs" Inherits="SMS.Demos.LocationStaffLink" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            text-decoration: underline;
        }
        .style2
        {
            font-weight: bold;
        }
    </style>
    <script type="text/javascript">
        function Redirect() {
            window.location = "StaffProfile.aspx";
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">List Of Users On Assignment <span class="style1">Ren Ci 
            Hospital</span></span>
        </div>
        <br>
        <div>
            <div id="ctl00_ContentPlaceHolder1_panel1">
                <div>
                    <table rules="all" cellspacing="0" cellpadding="5" border="1" style="width: 100%;
                        border-collapse: collapse;" id="ctl00_ContentPlaceHolder1_gvItemTable" class="GridMain">
                        <tbody>
                            <tr align="center" class="HeaderRow">
                                <th scope="col">
                                    Login Time
                                </th>
                                <th scope="col">
                                    User ID
                                </th>
                                <th scope="col">
                                    NRIC/FIN No.
                                </th>
                                <th scope="col">
                                    Staff ID
                                </th>
                                <th scope="col">
                                    First Name
                                </th>
                                <th scope="col">
                                    Role
                                </th>
                                <th align="center" style="width: 50px;" scope="col">
                                    Edit/View
                                </th>
                                <th align="center" style="width: 50px;" scope="col">
                                    Delete
                                </th>
                            </tr>
                            <tr class="NormalRow">
                                <td>
                                    9/24/2009 7:10:36 AM
                                </td>
                                <td class="style2" style="cursor: pointer" onclick="Redirect();">
                                    AKHBAR
                                </td>
                                <td>
                                    S21561471
                                </td>
                                <td>
                                    S21561471
                                </td>
                                <td>
                                    AKHBAR
                                </td>
                                <td>
                                    Security Officer
                                </td>
                                <td align="center">
                                    <input type="image" style="border-width: 0px;" src="../../Images/Edit.gif" id="ctl00_ContentPlaceHolder1_gvItemTable_ctl02_btnEdit"
                                        name="ctl00$ContentPlaceHolder1$gvItemTable$ctl02$btnEdit">
                                </td>
                                <td align="center">
                                    <input type="image" style="border-width: 0px;" onclick="javascript:return confirm('Are you sure to delete this record?');"
                                        src="../../Images/Delete.gif" id="ctl00_ContentPlaceHolder1_gvItemTable_ctl02_btnDelete"
                                        name="ctl00$ContentPlaceHolder1$gvItemTable$ctl02$btnDelete">
                                </td>
                            </tr>
                            <tr class="AlternateRow">
                                <td>
                                    9/24/2009 7:05:21 AM
                                </td>
                                <td style="cursor: pointer">
                                    <b>BALLAN
                                </b>
                                </td>
                                <td>
                                    S1068091C
                                </td>
                                <td>
                                    S1068091C
                                </td>
                                <td>
                                    BALLAN
                                </td>
                                <td>
                                    Security Supervisor
                                </td>
                                <td align="center">
                                    <input type="image" style="border-width: 0px;" src="../../Images/Edit.gif" id="ctl00_ContentPlaceHolder1_gvItemTable_ctl03_btnEdit"
                                        name="ctl00$ContentPlaceHolder1$gvItemTable$ctl03$btnEdit">
                                </td>
                                <td align="center">
                                    <input type="image" style="border-width: 0px;" onclick="javascript:return confirm('Are you sure to delete this record?');"
                                        src="../../Images/Delete.gif" id="ctl00_ContentPlaceHolder1_gvItemTable_ctl03_btnDelete"
                                        name="ctl00$ContentPlaceHolder1$gvItemTable$ctl03$btnDelete">
                                </td>
                            </tr>
                            <tr class="NormalRow">
                                <td>
                                    9/24/2009 7:02:29 PM
                                </td>
                                <td class="style2" style="cursor: pointer">
                                    KRISHNAN
                                </td>
                                <td>
                                    S2148339G
                                </td>
                                <td>
                                    S2148339G
                                </td>
                                <td>
                                    KRISHNAN
                                </td>
                                <td>
                                    Security Officer
                                </td>
                                <td align="center">
                                    <input type="image" style="border-width: 0px;" src="../../Images/Edit.gif" id="ctl00_ContentPlaceHolder1_gvItemTable_ctl04_btnEdit"
                                        name="ctl00$ContentPlaceHolder1$gvItemTable$ctl04$btnEdit">
                                </td>
                                <td align="center">
                                    <input type="image" style="border-width: 0px;" onclick="javascript:return confirm('Are you sure to delete this record?');"
                                        src="../../Images/Delete.gif" id="ctl00_ContentPlaceHolder1_gvItemTable_ctl04_btnDelete"
                                        name="ctl00$ContentPlaceHolder1$gvItemTable$ctl04$btnDelete">
                                </td>
                            </tr>
                            <tr class="AlternateRow">
                                <td>
                                    9/24/2009 7:09:45 PM
                                </td>
                                <td style="cursor: pointer">
                                    <b>NG
                                </b>
                                </td>
                                <td>
                                    S1156752E
                                </td>
                                <td>
                                    S1156752E
                                </td>
                                <td>
                                    NG
                                </td>
                                <td>
                                    Security Officer
                                </td>
                                <td align="center">
                                    <input type="image" style="border-width: 0px;" src="../../Images/Edit.gif" id="ctl00_ContentPlaceHolder1_gvItemTable_ctl05_btnEdit"
                                        name="ctl00$ContentPlaceHolder1$gvItemTable$ctl05$btnEdit">
                                </td>
                                <td align="center">
                                    <input type="image" style="border-width: 0px;" onclick="javascript:return confirm('Are you sure to delete this record?');"
                                        src="../../Images/Delete.gif" id="ctl00_ContentPlaceHolder1_gvItemTable_ctl05_btnDelete"
                                        name="ctl00$ContentPlaceHolder1$gvItemTable$ctl05$btnDelete">
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
        <br>
        <div style="height: 50px; width: 880px;">
            <table align="left" width="550px">
                <tbody>
                    <tr>
                        <td>
                            <span style="color: rgb(0, 0, 153); font-weight: bold;" class="Labels" id="ctl00_ContentPlaceHolder1_employee1">
                                Total Users : </span>
                        </td>
                        <td>
                            &nbsp; <span style="color: rgb(0, 0, 153); font-weight: bold;" class="Labels" id="ctl00_ContentPlaceHolder1_userid">
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span style="color: rgb(0, 0, 153); font-weight: bold;" class="Labels" id="ctl00_ContentPlaceHolder1_exporto">
                                Export To :</span>
                        </td>
                        <td>
                            <select style="color: rgb(0, 0, 153); height: 16px; width: 80px;" class="Labels"
                                id="ctl00_ContentPlaceHolder1_DropDownList1" name="ctl00$ContentPlaceHolder1$DropDownList1">
                                <option value="None" selected="selected">None</option>
                                <option value="Excel">Excel</option>
                                <option value="Pdf">Pdf</option>
                                <option value="Html">Html</option>
                            </select>
                            &nbsp;&nbsp;
                        </td>
                        <td>
                            <input type="submit" style="width: 85px;" class="Buttons" id="ctl00_ContentPlaceHolder1_btnGo"
                                value="Go" name="ctl00$ContentPlaceHolder1$btnGo">
                        </td>
                        <td>
                            <input type="submit" style="width: 85px;" class="Buttons" id="ctl00_ContentPlaceHolder1_btnEmail1"
                                value="E-Mail" name="ctl00$ContentPlaceHolder1$btnEmail1">
                        </td>
                        <td>
                            <input type="submit" style="width: 85px;" class="Buttons" id="ctl00_ContentPlaceHolder1_btnprint1"
                                value="Print" name="ctl00$ContentPlaceHolder1$btnprint1">
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <br>
    </div>
</asp:Content>
