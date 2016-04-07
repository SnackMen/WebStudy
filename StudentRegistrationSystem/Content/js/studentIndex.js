$(document).ready(function () {
    $("#select").click(function () {
        $("#select-cno-message").empty();
    });
    $("#submit").click(function () {
        if ($("#makesure-div-submit").parent().children().count==1) {
            $("#makesure-div-submit").empty();
        }
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
