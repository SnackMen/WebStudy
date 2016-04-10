$(function () {
    $("#timetable").click(function () {
        $("#shownavigation").empty();
        $("#inputgrade").css({ "display": "none" });
        $("#queryTimetable").css({ "display": "block" });
    });
    $("#input").click(function () {
        $("#queryTimetable").css({ "display": "none" });
        $("#inputgrade").css({ "display": "block" });
    });
    $("#shownavigation").on("click", "#0", this, function (event) {
        //alert("aaa");
        $("#showCourse").empty();
        $.get("/Teacher/StudentList1", function (result) {
            $("#showCourse").html(result);
        });
        $("#showCourse").css({ "display": "block" });
    });
    $("#shownavigation").on("click", "#1", this, function (event) {
        //alert("aaa");
        $("#showCourse").empty();
        $.get("/Teacher/StudentList2", function (result) {
            $("#showCourse").html(result);
        });
        $("#showCourse").css({ "display": "block" });
    });
    $("#shownavigation").on("click", "#schedule", this, function (event) {
        $("#showCourse").empty();
        $.get("/Teacher/QueryTable", { tname: ViewBag.tname }, function (result) {
            $("#showCourse").html(result);
        })
        $("#showCourse").css({ "display": "block" });
    });
})
