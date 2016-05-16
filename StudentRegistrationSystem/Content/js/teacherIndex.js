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

    $("#grade-studentclass").on("click", "#savegrade", this, function (event) {
        var models = [];
        var sno = null;
        var sname = null;
        var grade = null;
        var cname = null;
        var cname = $("#grade-studentclass .getValue").text().trim();
        $.each($("#grade-studentclass table tr"), function (i, item) {
            sno = $(item).find("#studentgradeid").text().trim();
            sname = $(item).find("#studentgradename").text().trim();
            grade = $(item).find("#student-input-grade").val();
            //cname = $(item).find("#grade-studentclass #getValue").text().trim();
            if (0 <= parseInt(grade) && 100 >= parseInt(grade)) {
                models.push({ SNO: sno, SNAME: sname, GRADE: grade, CNAME: cname });
            } else if (parseInt(grade) > 100 || parseInt(grade) < 0) {
                alert("分数存在错误，请重新输入!");
            }
        });
        $.ajax({
            url: "/Teacher/UpdateGrade",
            data: JSON.stringify(models),
            type: "POST",
            contentType: "application/json,charset=utf-8",
            success: function (result) {
                alert(result);
            }
        });
    });
})
