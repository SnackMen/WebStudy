$(function () {
    $("#select").click(function () {
        $("#dropcouse").css({ "display": "none" });
        $("#queryTimetable").css({ "display": "none" });
        $("#grades").css({ "display": "none" });
        $("#selecourse").css({ "display": "block" });
    });
    $("#drop").click(function () {
        $("#selecourse").css({ "display": "none" });
        $("#queryTimetable").css({ "display": "none" });
        $("#grades").css({ "display": "none" });
        $("#dropcouse").css({ "display": "block" });
    });
    $("#timetable").click(function () {
        $("#dropcouse").css({ "display": "none" });
        $("#selecourse").css({ "display": "none" });
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


