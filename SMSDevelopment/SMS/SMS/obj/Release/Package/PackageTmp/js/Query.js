///<reference path="../SMSWebServices/StaffAssignment.asmx" Type="text/javascript" />
/// <reference path="jquery-1.4.2.js" />
//var $tablearea = $('#tablearea'), $tables = $('#tables');
$(function() {
    $("#tablearea").resizable();
});
SMS.SMSWebServices.StaffAssignment.GetAllStaff(onLoadSuccess);
function onColumnSuccess(result) {
    if (result != null) {
        $('#ustaff').append(result);
        $("#ustaff").resizable();

        $('input', $('#ustaff')).draggable({
            stop: function(event, ui) {
                $("#positionDiv").append("Top : " + ui.position.top + " , Left : " + ui.position.left + "<br />");
            }
        });

        EnableMovables();
    }
}

function EnableMovables() {
    $('div.movable', $('#tablearea')).draggable({
        stop: function(event, ui) {
            $("#positionDiv").append("Top : " + ($('#tablearea').position().top + ui.position.top) + " , Left : " + ($('#tablearea').position().left + ui.position.left) + "<br />");
        }
    });

    $('span.movable', $('#tablearea')).draggable({
        revert: "invalid",
        start: function(event, ui) {
            startpos = ui.offset;
        },
        stop: function(event, ui) {
            $("#positionDiv").append("Top : " + (ui.offset.top) + " , Left : " + (ui.offset.left) + "<br />");

            try {
                $("#tablearea").svg();
                var svg = $("#tablearea").svg('get');
                svg.line(startpos.left - $("#tablearea").offset().left + ui.helper.width(), startpos.top - $("#tablearea").offset().top + 5, ui.offset.left - $("#tablearea").offset().left, ui.offset.top - $("#tablearea").offset().top, { stroke: '#363F12', strokeWidth: 2 });
                var height, top = 0;
                if (startpos.top < ui.offset.top) {
                    height = ui.offset.top - startpos.top;
                }
                else {
                    height = startpos.top - ui.offset.top;

                }
                var width = 0;
                if (startpos.left < ui.offset.left) {
                    width = ui.offset.left - startpos.left;
                }
                else {
                    width = startpos.left - ui.offset.left;
                }
                $("#tablearea").find("svg").last().css("top", "0px");
                $("#tablearea").find("svg").last().css("left", "0px");
            }
            catch (err) {
                alert(err);
            }
            EnableMovables();
        }
    });
}

function onLoadSuccess(result) {
    if (result != null) {
        $("#ustaff ul").html(result);
        var $ustaff = $('#ustaff'), $astaff = $('#astaff');
        // let the gallery items be draggable

        $('ul li', $ustaff).draggable({
            cancel: 'a.ui-icon', // clicking an icon won't initiate dragging
            revert: 'invalid', // when not dropped, the item will revert back to its initial position
            helper: 'clone',
            cursor: 'move'
        });

        $('ul li', $astaff).draggable({
            cancel: 'a.ui-icon', // clicking an icon won't initiate dragging
            revert: 'invalid', // when not dropped, the item will revert back to its initial position
            helper: 'clone',
            cursor: 'move'
        });

        // let the gallery be droppable as well, accepting items from the trash
        $astaff.droppable({
            accept: '#ustaff li',
            activeClass: 'custom-state-active',
            drop: function(ev, ui) {
                Assign(ui.draggable);
            }
        });

        $ustaff.droppable({
            accept: '#astaff li',
            activeClass: 'custom-state-active',
            drop: function(ev, ui) {
                UnAssign(ui.draggable);
            }
        });

        function Assign($item) {
            $item.fadeOut(function() {
                var $list = $("#astaff ul");

                $item.find('a.ui-icon-trash').remove();
                $item.appendTo($list).fadeIn();
            });
        }

        function UnAssign($item) {
            $item.fadeOut(function() {
                var $list = $("#ustaff ul");

                $item.find('a.ui-icon-trash').remove();
                $item.appendTo($list).fadeIn();
            });
        }

        function GetColumns(tablename) {
            SqlMetaService.GetColumns(tablename, onColumnSuccess);
        }


    }
}