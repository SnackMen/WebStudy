$(document).ready(function () {
    $("#select").click(function () {
        $("#submit-select").css({ "display": "block" });
        $("#select-textbox").empty();
        $("#select-cno-result").empty();
    });
    $("#submit-select").click(function () {
        $("#select-cno-result").empty();
    });
    $("#timetable").click(function () {
        $("#dropcouse").css({ "display": "none" });
        $("#grades").css({ "display": "none" });
        $("#queryTimetable").css({ "display": "block" });
    });
    $("#grade").click(function () {
        $("#queryTimetable").css({ "display": "none" });
        $("#dropcouse").css({ "display": "none" });
        $("#grades").css({ "display": "block" }); 
    });
})

