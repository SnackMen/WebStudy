$(function () {
    $("#timetable").click(function () {
        $("#shownavigation").empty();
        $("#inputgrade").css({ "display": "none" });
        $("#queryTimetable").css({ "display": "block" });
    });
    $("#input").click(function () {
        $("#schedule-studentclass").empty();
        $("#queryTimetable").css({ "display": "none" });
        $("#inputgrade").css({ "display": "block" });
    });
    $("#shownavigation").on("click", "#0", this, function (event) {
        var name = $("#teacher-name-value").text();
        $("#showCourse").empty();
        $.get("/Teacher/StudentList1", { tname: name }, function (result) {
            $("#showCourse").html(result);
        });
        $("#showCourse").css({ "display": "block" });
    });
    $("#shownavigation").on("click", "#1", this, function (event) {
        var name = $("#teacher-name-value").text();
        $("#showCourse").empty();
        $.get("/Teacher/StudentList2", { tname: name }, function (result) {
            $("#showCourse").html(result);
        });
        $("#showCourse").css({ "display": "block" });
    });
    $("#shownavigation").on("click", "#schedule", this, function (event) {
        var name = $("#teacher-name-value").text();
        $("#showCourse").empty();
        $.get("/Teacher/QueryTable", { tname: name }, function (result) {
            $("#showCourse").html(result);
    });
        $("#showCourse").css({ "display": "block" });
    });



    $("#schedule-studentclass").on("click", "#0", this, function (event) {
        var name = $("#teacher-name-value").text();
        $("#grade-studentclass").empty();
        $.get("/Teacher/StudentGrade1", { tname: name }, function (result) {
            $("#grade-studentclass").html(result);
        });
        $("#savegrade").css({ "display": "block" });
    });

    $("#schedule-studentclass").on("click", "#1", this, function (event) {
        var name = $("#teacher-name-value").text();
        $("#grade-studentclass").empty();
        $.get("/Teacher/StudentGrade2", { tname: name }, function (result) {
            $("#grade-studentclass").html(result);
        });
        $("#savegrade").css({ "display": "block" });
    });
    $("#savegrade").click(function () {
        var models = [ ];
        $.each($("#grade-studentclass table tr"), function (i, item) {
            var sno = $(item).find($("[name=studentgradeid]")).text();
            var sname = $(item).find($("[name=studentgradename]")).text();
            var grade = $(item).find($("[name=student-input-grade]")).val();
            models.push({ SNO: sno, SNAME: sname, GRADE: grade });
        });
        debugger;
        $.ajax({
            url: "/Teacher/UpdateGrade",
            data: { "list": models },
            type: "get",
            contentType: "application/json,charset=utf-8",
            success:function(result){
                alert(result);
            },
            error: function (result) {
                alert("出错啦!");
            }
        });
    });
})
