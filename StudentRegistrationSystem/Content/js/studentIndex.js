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
            data: {cno:$("cno").text().trim(),cname:$("cname").text().trim(),
                sno: $("#student-studentNo").text().trim(), sname: $("#student-studentName").text().trim()
            },
            success: function (result) {
                alert(result);
            },
            error: function (result) {
                alert("出错啦！");
            }
        });
    })
})

