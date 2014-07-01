<%@ Page Title="" Language="C#" MasterPageFile="~/SMSmaster.Master" AutoEventWireup="true"
    CodeBehind="LocationList.aspx.cs" Inherits="SMS.Demos.LocationList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            font-weight: bold;
        }
    </style>
    <script type="text/javascript">
        function Redirect() {
            window.location = "LocationStaffLink.aspx";
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content-inner">
        <div class="divContainer">
            <div class="divHeader">
                <span class="pageTitle">Location Master</span></div>
            <div id="ctl00_ContentPlaceHolder1_divAdvSearch">
                <br>
                <table width="900px">
                    <tbody>
                        <tr>
                            <td align="left">
                                <span class="Labels" id="ctl00_ContentPlaceHolder1_lblLocationID">Location Code</span>
                            </td>
                            <td>
                                <input type="text" class="Input" id="ctl00_ContentPlaceHolder1_txtLocationID" name="ctl00$ContentPlaceHolder1$txtLocationID">
                            </td>
                            <td align="left">
                                <span class="Labels" id="ctl00_ContentPlaceHolder1_lblLocation">Name</span>
                            </td>
                            <td>
                                <input type="text" style="width: 131px;" class="Input" id="ctl00_ContentPlaceHolder1_txtAddLocation"
                                    name="ctl00$ContentPlaceHolder1$txtAddLocation">
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <span class="Labels" id="ctl00_ContentPlaceHolder1_lbldatefrom">Date: From</span>
                            </td>
                            <td>
                                <input type="text" class="Input" id="ctl00_ContentPlaceHolder1_txtdatefrom" name="ctl00$ContentPlaceHolder1$txtdatefrom">
                                <input type="image" align="absmiddle" style="border-width: 0px; width: 16px;" src="../Images/calendar.bmp"
                                    id="ctl00_ContentPlaceHolder1_imgBtnFromDate2" name="ctl00$ContentPlaceHolder1$imgBtnFromDate2">
                            </td>
                            <td align="" right="">
                                <span class="Labels" id="ctl00_ContentPlaceHolder1_lbldateto">To</span>
                            </td>
                            <td>
                                <input type="text" class="Input" id="ctl00_ContentPlaceHolder1_txtdateto" name="ctl00$ContentPlaceHolder1$txtdateto">
                                <input type="image" align="absmiddle" style="border-width: 0px;" src="../Images/calendar.bmp"
                                    id="ctl00_ContentPlaceHolder1_imgBtnFromDate3" name="ctl00$ContentPlaceHolder1$imgBtnFromDate3">
                            </td>
                        </tr>
                        <tr>
                            <td height="15px">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="5">
                                <input type="submit" style="width: 85px;" class="Buttons" id="ctl00_ContentPlaceHolder1_btnSearchLocationAdd"
                                    value="Search" name="ctl00$ContentPlaceHolder1$btnSearchLocationAdd">
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <input type="submit" style="width: 85px;" class="Buttons" id="ctl00_ContentPlaceHolder1_btnClearLocationAdd"
                                    value="Clear" name="ctl00$ContentPlaceHolder1$btnClearLocationAdd">
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <br>
            <div style="overflow: auto;">
                <div>
                    <table rules="all" cellspacing="0" cellpadding="5" border="1" style="width: 100%;
                        border-collapse: collapse;" id="ctl00_ContentPlaceHolder1_gvLoctionTable" class="GridMain">
                        <tbody>
                            <tr align="center" class="HeaderRow">
                                <th style="width: 200px;" scope="col">
                                    Location Code
                                </th>
                                <th style="width: 200px;" scope="col">
                                    Name
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
                                    L10004
                                </td>
                                <td class="style1" style="cursor: pointer" onclick="Redirect();">
                                    Ren Ci Hospital&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                                <td align="center">
                                    <input type="image" style="border-width: 0px;" src="../Images/Edit.gif" id="ctl00_ContentPlaceHolder1_gvLoctionTable_ctl02_btnEdit"
                                        name="ctl00$ContentPlaceHolder1$gvLoctionTable$ctl02$btnEdit">
                                </td>
                                <td align="center">
                                    <input type="image" style="border-width: 0px;" onclick="javascript:return confirm('Are you sure to delete this record?');"
                                        src="../Images/Delete.gif" id="ctl00_ContentPlaceHolder1_gvLoctionTable_ctl02_btnDelete"
                                        name="ctl00$ContentPlaceHolder1$gvLoctionTable$ctl02$btnDelete">
                                </td>
                            </tr>
                            <tr class="AlternateRow">
                                <td>
                                    L10005
                                </td>
                                <td style="cursor: pointer">
                                    <b>UMS Semiconductor&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    </b>
                                </td>
                                <td align="center">
                                    <input type="image" style="border-width: 0px;" src="../Images/Edit.gif" id="ctl00_ContentPlaceHolder1_gvLoctionTable_ctl03_btnEdit"
                                        name="ctl00$ContentPlaceHolder1$gvLoctionTable$ctl03$btnEdit">
                                </td>
                                <td align="center">
                                    <input type="image" style="border-width: 0px;" onclick="javascript:return confirm('Are you sure to delete this record?');"
                                        src="../Images/Delete.gif" id="ctl00_ContentPlaceHolder1_gvLoctionTable_ctl03_btnDelete"
                                        name="ctl00$ContentPlaceHolder1$gvLoctionTable$ctl03$btnDelete">
                                </td>
                            </tr>
                            <tr class="NormalRow">
                                <td>
                                    L10006
                                </td>
                                <td class="style1" style="cursor: pointer">
                                    Maritime Port Authority&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                                <td align="center">
                                    <input type="image" style="border-width: 0px;" src="../Images/Edit.gif" id="ctl00_ContentPlaceHolder1_gvLoctionTable_ctl04_btnEdit"
                                        name="ctl00$ContentPlaceHolder1$gvLoctionTable$ctl04$btnEdit">
                                </td>
                                <td align="center">
                                    <input type="image" style="border-width: 0px;" onclick="javascript:return confirm('Are you sure to delete this record?');"
                                        src="../Images/Delete.gif" id="ctl00_ContentPlaceHolder1_gvLoctionTable_ctl04_btnDelete"
                                        name="ctl00$ContentPlaceHolder1$gvLoctionTable$ctl04$btnDelete">
                                </td>
                            </tr>
                            <tr class="AlternateRow">
                                <td>
                                    L10007
                                </td>
                                <td style="cursor: pointer">
                                    <b>Sim Lian Construction&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    </b>
                                </td>
                                <td align="center">
                                    <input type="image" style="border-width: 0px;" src="../Images/Edit.gif" id="ctl00_ContentPlaceHolder1_gvLoctionTable_ctl05_btnEdit"
                                        name="ctl00$ContentPlaceHolder1$gvLoctionTable$ctl05$btnEdit">
                                </td>
                                <td align="center">
                                    <input type="image" style="border-width: 0px;" onclick="javascript:return confirm('Are you sure to delete this record?');"
                                        src="../Images/Delete.gif" id="ctl00_ContentPlaceHolder1_gvLoctionTable_ctl05_btnDelete"
                                        name="ctl00$ContentPlaceHolder1$gvLoctionTable$ctl05$btnDelete">
                                </td>
                            </tr>
                            <tr class="NormalRow">
                                <td>
                                    L10008
                                </td>
                                <td class="style1" style="cursor: pointer">
                                    Clementi Loop&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                                <td align="center">
                                    <input type="image" style="border-width: 0px;" src="../Images/Edit.gif" id="ctl00_ContentPlaceHolder1_gvLoctionTable_ctl06_btnEdit"
                                        name="ctl00$ContentPlaceHolder1$gvLoctionTable$ctl06$btnEdit">
                                </td>
                                <td align="center">
                                    <input type="image" style="border-width: 0px;" onclick="javascript:return confirm('Are you sure to delete this record?');"
                                        src="../Images/Delete.gif" id="ctl00_ContentPlaceHolder1_gvLoctionTable_ctl06_btnDelete"
                                        name="ctl00$ContentPlaceHolder1$gvLoctionTable$ctl06$btnDelete">
                                </td>
                            </tr>
                            <tr class="AlternateRow">
                                <td>
                                    L10009
                                </td>
                                <td style="cursor: pointer">
                                    <b>MTW Yishun&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    </b>
                                </td>
                                <td align="center">
                                    <input type="image" style="border-width: 0px;" src="../Images/Edit.gif" id="ctl00_ContentPlaceHolder1_gvLoctionTable_ctl07_btnEdit"
                                        name="ctl00$ContentPlaceHolder1$gvLoctionTable$ctl07$btnEdit">
                                </td>
                                <td align="center">
                                    <input type="image" style="border-width: 0px;" onclick="javascript:return confirm('Are you sure to delete this record?');"
                                        src="../Images/Delete.gif" id="ctl00_ContentPlaceHolder1_gvLoctionTable_ctl07_btnDelete"
                                        name="ctl00$ContentPlaceHolder1$gvLoctionTable$ctl07$btnDelete">
                                </td>
                            </tr>
                            <tr class="NormalRow">
                                <td>
                                    L10010
                                </td>
                                <td class="style1" style="cursor: pointer">
                                    QIB Facilities&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                                <td align="center">
                                    <input type="image" style="border-width: 0px;" src="../Images/Edit.gif" id="ctl00_ContentPlaceHolder1_gvLoctionTable_ctl08_btnEdit"
                                        name="ctl00$ContentPlaceHolder1$gvLoctionTable$ctl08$btnEdit">
                                </td>
                                <td align="center">
                                    <input type="image" style="border-width: 0px;" onclick="javascript:return confirm('Are you sure to delete this record?');"
                                        src="../Images/Delete.gif" id="ctl00_ContentPlaceHolder1_gvLoctionTable_ctl08_btnDelete"
                                        name="ctl00$ContentPlaceHolder1$gvLoctionTable$ctl08$btnDelete">
                                </td>
                            </tr>
                            <tr class="AlternateRow">
                                <td>
                                    L10011
                                </td>
                                <td style="cursor: pointer">
                                    <b>Vobis Enterprise&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    </b>
                                </td>
                                <td align="center">
                                    <input type="image" style="border-width: 0px;" src="../Images/Edit.gif" id="ctl00_ContentPlaceHolder1_gvLoctionTable_ctl09_btnEdit"
                                        name="ctl00$ContentPlaceHolder1$gvLoctionTable$ctl09$btnEdit">
                                </td>
                                <td align="center">
                                    <input type="image" style="border-width: 0px;" onclick="javascript:return confirm('Are you sure to delete this record?');"
                                        src="../Images/Delete.gif" id="ctl00_ContentPlaceHolder1_gvLoctionTable_ctl09_btnDelete"
                                        name="ctl00$ContentPlaceHolder1$gvLoctionTable$ctl09$btnDelete">
                                </td>
                            </tr>
                            <tr class="NormalRow">
                                <td>
                                    L10012
                                </td>
                                <td class="style1" style="cursor: pointer">
                                    ICES Jurong Island&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                                <td align="center">
                                    <input type="image" style="border-width: 0px;" src="../Images/Edit.gif" id="ctl00_ContentPlaceHolder1_gvLoctionTable_ctl10_btnEdit"
                                        name="ctl00$ContentPlaceHolder1$gvLoctionTable$ctl10$btnEdit">
                                </td>
                                <td align="center">
                                    <input type="image" style="border-width: 0px;" onclick="javascript:return confirm('Are you sure to delete this record?');"
                                        src="../Images/Delete.gif" id="ctl00_ContentPlaceHolder1_gvLoctionTable_ctl10_btnDelete"
                                        name="ctl00$ContentPlaceHolder1$gvLoctionTable$ctl10$btnDelete">
                                </td>
                            </tr>
                            <tr class="AlternateRow">
                                <td>
                                    L10013
                                </td>
                                <td style="cursor: pointer">
                                    <b>Singapore Land Authority
                                </b>
                                </td>
                                <td align="center">
                                    <input type="image" style="border-width: 0px;" src="../Images/Edit.gif" id="ctl00_ContentPlaceHolder1_gvLoctionTable_ctl11_btnEdit"
                                        name="ctl00$ContentPlaceHolder1$gvLoctionTable$ctl11$btnEdit">
                                </td>
                                <td align="center">
                                    <input type="image" style="border-width: 0px;" onclick="javascript:return confirm('Are you sure to delete this record?');"
                                        src="../Images/Delete.gif" id="ctl00_ContentPlaceHolder1_gvLoctionTable_ctl11_btnDelete"
                                        name="ctl00$ContentPlaceHolder1$gvLoctionTable$ctl11$btnDelete">
                                </td>
                            </tr>
                            <tr class="NormalRow">
                                <td>
                                    L10014
                                </td>
                                <td class="style1" style="cursor: pointer">
                                    M+W Zander&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                                <td align="center">
                                    <input type="image" style="border-width: 0px;" src="../Images/Edit.gif" id="ctl00_ContentPlaceHolder1_gvLoctionTable_ctl12_btnEdit"
                                        name="ctl00$ContentPlaceHolder1$gvLoctionTable$ctl12$btnEdit">
                                </td>
                                <td align="center">
                                    <input type="image" style="border-width: 0px;" onclick="javascript:return confirm('Are you sure to delete this record?');"
                                        src="../Images/Delete.gif" id="ctl00_ContentPlaceHolder1_gvLoctionTable_ctl12_btnDelete"
                                        name="ctl00$ContentPlaceHolder1$gvLoctionTable$ctl12$btnDelete">
                                </td>
                            </tr>
                            <tr class="AlternateRow">
                                <td>
                                    L10015
                                </td>
                                <td style="cursor: pointer">
                                    <b>ASP Development&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    </b>
                                </td>
                                <td align="center">
                                    <input type="image" style="border-width: 0px;" src="../Images/Edit.gif" id="ctl00_ContentPlaceHolder1_gvLoctionTable_ctl13_btnEdit"
                                        name="ctl00$ContentPlaceHolder1$gvLoctionTable$ctl13$btnEdit">
                                </td>
                                <td align="center">
                                    <input type="image" style="border-width: 0px;" onclick="javascript:return confirm('Are you sure to delete this record?');"
                                        src="../Images/Delete.gif" id="ctl00_ContentPlaceHolder1_gvLoctionTable_ctl13_btnDelete"
                                        name="ctl00$ContentPlaceHolder1$gvLoctionTable$ctl13$btnDelete">
                                </td>
                            </tr>
                            <tr class="NormalRow">
                                <td>
                                    L10016
                                </td>
                                <td class="style1" style="cursor: pointer">
                                    Hyflux&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                                <td align="center">
                                    <input type="image" style="border-width: 0px;" src="../Images/Edit.gif" id="ctl00_ContentPlaceHolder1_gvLoctionTable_ctl14_btnEdit"
                                        name="ctl00$ContentPlaceHolder1$gvLoctionTable$ctl14$btnEdit">
                                </td>
                                <td align="center">
                                    <input type="image" style="border-width: 0px;" onclick="javascript:return confirm('Are you sure to delete this record?');"
                                        src="../Images/Delete.gif" id="ctl00_ContentPlaceHolder1_gvLoctionTable_ctl14_btnDelete"
                                        name="ctl00$ContentPlaceHolder1$gvLoctionTable$ctl14$btnDelete">
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            <div>
                <table>
                    <tbody>
                        <tr>
                            <td>
                                <br>
                                <input type="submit" class="Buttons" id="ctl00_ContentPlaceHolder1_btnNewLocation"
                                    value="Add New Location" name="ctl00$ContentPlaceHolder1$btnNewLocation">
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <br>
        </div>
    </div>
</asp:Content>
