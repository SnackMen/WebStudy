$(document).ready(function () {
    $("#select").click(function () {
        $("#queryTimetable").css({ "display": "none" });
        $("#grades").css({ "display": "none" });
        $("#dropcouse").css({ "display": "none" });
        $("#selecourse").css({ "display": "block" });
        $("#submit-select").css({ "display": "block" });
        $("#select-textbox").empty();
        $("#select-cno-result").empty();
    });
    $("#submit-select").click(function () {
        $("#select-cno-result").empty();
    });
    $("#drop").click(function () {
        $("#selecourse").css({ "display": "none" });
        $("#queryTimetable").css({ "display": "none" });
        $("#grades").css({ "display": "none" });
        $("#dropcouse").css({ "display": "block" });
        $("#dropcouse").empty();
    });
    $("#timetable").click(function () {
        $("#selecourse").css({ "display": "none" });
        $("#dropcouse").css({ "display": "none" });
        $("#grades").css({ "display": "none" });
        $("#queryTimetable").css({ "display": "block" });
    });
    $("#grade").click(function () {
        $("#selecourse").css({ "display": "none" });
        $("#queryTimetable").css({ "display": "none" });
        $("#dropcouse").css({ "display": "none" });
        $("#grades").css({ "display": "block" }); 
    });
})

