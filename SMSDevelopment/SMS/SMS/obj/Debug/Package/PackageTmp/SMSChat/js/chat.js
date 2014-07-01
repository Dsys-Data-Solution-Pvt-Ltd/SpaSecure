var Titlemsg = "Visit the Computer Survival School!";
pos = 0;
var titletimer;
var polltimer;
//var AppDirectory = "http://192.168.45.82/Chatting/"
var AppDirectory = "";
/*
*
*REMOTE DATA HANDLING START
*
*/
function GetNewData(st1) {
    GetUsers();
    GetMessages(st1);
    if (st1 != "on") {
        polltimer = setTimeout(function() { GetNewData('on'); }, 7000);
    }
    else {
        polltimer = setTimeout(function() { GetNewData('on'); }, 7000);
    }
}

function InsertMessage(id, me) {
    var from = id.split('_')[1];
    var to = id.split('_')[2];
    AddFromMessage(from, to);
    var params = '"text":"' + $('#ChatTxt_' + from + '_' + to).val() + '","toUserid":"' + to + '"';
    params = '{' + params + '}';
    $.ajax({
        type: "POST",
        url: "GetChatData.asmx/InsertMessage",
        contentType: "application/json; charset=utf-8",
        data: params,
        dataType: "json",
        success: function() {
        },
        failure: function() {
        }
    });
    $('#ChatTxt_' + from + '_' + to).val("");
    SetScrollPosition(id);
}

function GetUsers() {
    $.ajax({
        type: "POST",
        url: "GetChatData.asmx/GetLoggedInUsers",
        contentType: "application/json; charset=utf-8",
        data: "{}",
        dataType: "json",
        success: function(msg) {
            $("#divUsers").html(msg.d);
        },
        failure: function() {
            alert("Failure");
        }
    });
}

function GetMessages(st1) {
    $.ajax({
        type: "POST",
        url: "GetChatData.asmx/GetMessages",
        contentType: "application/json; charset=utf-8",
        data: '{"stat":"' + st1 + '"}',
        dataType: "json",
        success: function(msg) {
            var data = eval('(' + msg.d + ')');
            DispatchData(data);
        },
        failure: function() {
            alert("Failure");
        }
    });
}

/*
*
*REMOTE DATA HANDLING END
*
*/



/*
*
*UI HANDLING START
*
*/

function AddNewWindow(from, to) {
    var ExistingEle = $('#ChatWd_' + from + '_' + to);
    if (ExistingEle.length == 0) {
        var newElem = $('#ChatWd_From_To').clone().attr('id', 'ChatWd_' + from + '_' + to);
        newElem.html(newElem.html().replace(/_From/g, "_" + from));
        newElem.html(newElem.html().replace(/_To/g, "_" + to));
        newElem.css("visibility", "visible");
        $("#ChatWinds").append(newElem);
        ResetHeader('#ChatWd_' + from + '_' + to);
    }
}

function AddFromMessage(from, to) {
    var msg = "<div style='padding: 10px;background-color: #FFFFFF;text-align:left;border-style:dotted;border-color:Black;border-width:thin'>";
    msg += "<img src='Images/manIcon.gif' style='vertical-align:middle' alt=''>&nbsp;&nbsp;<b>" + from + "</b>&nbsp; : &nbsp;" + $('#ChatTxt_' + from + '_' + to).val() + "</div>"
    $('#ChatMsg_' + from + '_' + to).html($('#ChatMsg_' + from + '_' + to).html() + msg);
}

function AddToMessage(from, to, text) {
    var msg = "<div style='padding: 10px;background-color: #EFEFEF;text-align:left;border-style:dotted;border-color:Black;border-width:thin'>";
    msg += "<img src='Images/manIcon.gif' style='vertical-align:middle' alt=''>&nbsp;&nbsp;<b>" + to + "</b>&nbsp; : &nbsp;" + text + "</div>"
    $('#ChatMsg_' + from + '_' + to).html($('#ChatMsg_' + from + '_' + to).html() + msg);
}

function SetScrollPosition(id) {
    var from = id.split('_')[1];
    var to = id.split('_')[2];
    var div = document.getElementById('ChatMsg_' + from + '_' + to);
    if (div != null) {
        div.scrollTop = div.scrollHeight;
    }
}

function SetToEnd(me) {
    if (me.createTextRange) {
        var fieldRange = me.createTextRange();
        fieldRange.moveStart('character', me.value.length);
        fieldRange.collapse();
        fieldRange.select();
    }
}

function ReplaceChars(evt, me) {
    var from = me.id.split('_')[1];
    var to = me.id.split('_')[2];
    if (evt.keyCode == '13') {
        $("#ChatBtn_" + from + "_" + to).click();
    }
    else {
        var txt = me.value;
        var out = "<"; // replace this
        var add = ""; // with this
        var temp = "" + txt; // temporary holder

        while (temp.indexOf(out) > -1) {
            pos = temp.indexOf(out);
            temp = "" + (temp.substring(0, pos) + add +
                        temp.substring((pos + out.length), temp.length));
        }
        me.value = temp;
    }
}

function ResetHeader(id) {
    var from = id.split('_')[1];
    var to = id.split('_')[2];
    $("#ChatHead_" + from + "_" + to).html("<b>&nbsp;&nbsp;" + to + "&nbsp;&nbsp;</b>")
    $("#ChatHead_" + from + "_" + to).css("background-image", "");
    $("#ChatHead_" + from + "_" + to).css("color", "black");
    clearTimeout(titletimer);
    document.title = '-- Welcome To Chat --';
    SetScrollPosition(id);
}

function DispatchData(data) {
    jQuery.each(data, function() {
        var from = this.ToUserID;
        var to = this.UserID;
        AddNewWindow(from, to);
        AddToMessage(from, to, this.Text);
        $("#ChatHead_" + from + "_" + to).html('<b> ' + to + ' Says....</b>')
        $("#ChatHead_" + from + "_" + to).css("background-image", "url('images/incoming.gif')");
        SetScrollPosition('ChatMsg_' + from + '_' + to);
        Titlemsg = to + ' Says';
        Titlemsg = "...   ..." + Titlemsg;
        scrollMsg();
    });
}
function scrollMsg() {
    document.title = Titlemsg.substring(pos, Titlemsg.length) + Titlemsg.substring(0, pos);
    pos++;
    if (pos > Titlemsg.length) pos = 0
    titletimer = setTimeout("scrollMsg()", 200);
}

function CloseThis(me) {
    me.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.removeChild(me.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode);
}
/*
*
*UI HANDLING END
*
*/