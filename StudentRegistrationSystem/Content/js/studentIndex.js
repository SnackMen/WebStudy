$(document).ready(function () {
    $("#select").click(function () {
        var time = $("#time-Message").val();
        if (time == "true") {
            $("#queryTimetable").css({ "display": "none" });
            $("#grades").css({ "display": "none" });
            $("#dropcouse").css({ "display": "none" });
            $("#reset-select").css({ "display": "block" });
            $("#selecourse").css({ "display": "block" });
            $("#submit-select").css({ "display": "block" });
            $("#select-textbox").empty();
            $("#select-cno-result").empty();
        }
        else {
            alert("选课时间未到，禁止选课!");
        }
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
        $("#queryTimetable").empty();
    });
    $("#grade").click(function () {
        $("#selecourse").css({ "display": "none" });
        $("#queryTimetable").css({ "display": "none" });
        $("#dropcouse").css({ "display": "none" });
        $("#grades").css({ "display": "block" });
        $("#grades").empty();
    });
    $("#select-cno-result").on("click", "#makesure-button-submit", this, function (event) {
        $.ajax({
            type: "get",
            contentType: "application/json",
            url: "/Student/StudentSelectCourse",
            async: false,
            data: {
                cno: $("#student-cno").text().trim(), cname: $("#student-cname").text().trim(), credit: $("#student-credit").text().trim(),
                cdept: $("#student-cdept").text().trim(), tname: $("#student-tname").text().trim(), time: $("#student-time").text(),
                sno: $("#student-studentNo").text().trim()
            },
            success: function (result) {
                alert(result);
            },
            error: function (result) {
                alert("出错啦！");
            }
        });
    });
    $("#dropcouse").on("click", "#drop-makesure", this, function (event) {
        $.ajax({
            type: "get",
            contextType: "application/json",
            url: "/Student/DropCourse",
            async: false,
            data: { sno: $("#student-studentNo").text().trim(), cno: $(this).parent().siblings("#drop-cno").text().trim() },
            success: function (result) {
                alert(result);
            },
            error: function (result) {
                alert("出错啦!");
            }
        });
    })
})

