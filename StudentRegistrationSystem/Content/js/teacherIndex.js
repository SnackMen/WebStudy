$(function () {
    $("#timetable").click(function () {
        $("#inputgrade").css({ "display": "none" });
        $("#queryTimetable").css({ "display": "block" });
    });
    $("#input").click(function () {
        $("#queryTimetable").css({ "display": "none" });
        $("#inputgrade").css({ "display": "block" });
    });
})
