﻿document.write("<script src='~/Content/js/mindmup-editabletable.js'><\/script>");
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
})
