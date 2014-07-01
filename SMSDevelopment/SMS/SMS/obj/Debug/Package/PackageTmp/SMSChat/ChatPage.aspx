<%@ Page Language="C#" AutoEventWireup="true" Inherits="SMS.SMSChat.ChatPage" MasterPageFile="~/master/login.Master" Codebehind="ChatPage.aspx.cs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>-- Welcome To Chat --</title>
    <script type="text/javascript" language="javascript" src="js/dragResize.js"></script>
    <script src="js/chat.js" type="text/javascript"></script>
     <script src="js/jquery-1.3.2.js" type="text/javascript"></script>
    <% if (false)
       { %>
    <script src="js/jquery-1.3.2.js" type="text/javascript"></script>
    <script src="js/jquery-1.3.2-vsdoc.js" type="text/javascript"></script>
    <%} %>
    <style type="text/css">
        /* Required CSS classes: must be included in all pages using this script *//* Apply the element you want to drag/resize */.drsElement
        {
            position: absolute;
            border: 1px solid #333;
        }
        /*
 The main mouse handle that moves the whole element.
 You can apply to the same tag as drsElement if you want.
*/.drsMoveHandle
        {
            height: 20px;
            border-bottom: 1px solid #666;
            cursor: move;
        }
        /*
 The DragResize object name is automatically applied to all generated
 corner resize handles, as well as one of the individual classes below.
*/.dragresize
        {
            position: absolute;
            width: 5px;
            height: 5px;
            font-size: 1px;
            background: #EEE;
            border: 1px solid #333;
        }
        /*
 Individual corner classes - required for resize support.
 These are based on the object name plus the handle ID.
*/.dragresize-tl
        {
            top: -8px;
            left: -8px;
            cursor: nw-resize;
        }
        .dragresize-tm
        {
            top: -8px;
            left: 50%;
            margin-left: -4px;
            cursor: n-resize;
        }
        .dragresize-tr
        {
            top: -8px;
            right: -8px;
            cursor: ne-resize;
        }
        .dragresize-ml
        {
            top: 50%;
            margin-top: -4px;
            left: -8px;
            cursor: w-resize;
        }
        .dragresize-mr
        {
            top: 50%;
            margin-top: -4px;
            right: -8px;
            cursor: e-resize;
        }
        .dragresize-bl
        {
            bottom: -8px;
            left: -8px;
            cursor: sw-resize;
        }
        .dragresize-bm
        {
            bottom: -8px;
            left: 50%;
            margin-left: -4px;
            cursor: s-resize;
        }
        .dragresize-br
        {
            bottom: -8px;
            right: -8px;
            cursor: se-resize;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript" language="javascript">
        var dragresize = new DragResize('dragresize',
     { minWidth: 50, minHeight: 50, minLeft: 00, minTop: 0, maxLeft: 1000, maxTop: 1000 });

        dragresize.isElement = function(elm) {
            if (elm.className && elm.className.indexOf('drsElement') > -1) return true;
        };
        dragresize.isHandle = function(elm) {
            if (elm.className && elm.className.indexOf('drsMoveHandle') > -1) return true;
        };

        dragresize.ondragfocus = function() { };
        dragresize.ondragstart = function(isResize) { };
        dragresize.ondragmove = function(isResize) { };
        dragresize.ondragend = function(isResize) { };
        dragresize.ondragblur = function() { };

        dragresize.apply(document);
        
        $(document).ready(function() {
            GetNewData('off');
        });
</script>
    <div>
        <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 462px">
            <tr>
                <td id="ChatWinds" style="width: 85%;">
                    <div id="ChatWd_From_To" class="drsElement" style="left: 20px; top: 300px; width: 300px;
                        height: 300px; text-align: center;visibility:hidden; background-image: url('Images/back2.jpg');" onclick="ResetHeader(this.id);">
                        <div class="drsMoveHandle">
                            <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                <tbody>
                                    <tr>
                                        <td valign="top" style="width: 90%; text-align: center;">
                                            <div id="ChatHead_From_To">
                                            </div>
                                        </td>
                                        <td valign="top" style="margin: 0pt; padding: 0pt; width: 10%; vertical-align: top;">
                                            <img src="Images/close.jpg" onclick="CloseThis(this);" style="border-width: 0px;
                                                margin: 0pt; padding: 0pt; height: 15px; float: right;" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div id="ChatBody_From_To" style="width: 100%;">
                            <table cellspacing="0" cellpadding="0" border="0" style="width: 99%;">
                                <tbody>
                                    <tr>
                                        <td colspan="2">
                                            <div id="ChatMsg_From_To" onresize="SetScrollPosition(this.id)" style="border: 1px solid Black;
                                                padding: 4px; background-color: White; height: 215px; width: 96%; font-size: 11px;"> 
                                                
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 80%;">
                                            <input id="ChatTxt_From_To" type="text" style="width: 98%; height: 50px;"
                                                onfocus="SetToEnd(this)" onkeypress="ReplaceChars(event,this)" maxlength="1000" value="" />
                                        </td>
                                        <td>
                                            <input id="ChatBtn_From_To" type="button" style="height: 50px; width: 66px;"
                                                onclick="InsertMessage(this.id,this)" value="Send" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                </td>
                <td>
                    &nbsp;
                </td>
                <td style="vertical-align: top">
                    <div id="divUsers" style="border: 1px solid Black; background-color: White; height: 448px;
                        width: 150px;   font-size: 11px; padding: 4px 4px 4px 4px;overflow:scroll">
                        <asp:Literal runat="server" ID="litUsers">
                                
                        </asp:Literal>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
