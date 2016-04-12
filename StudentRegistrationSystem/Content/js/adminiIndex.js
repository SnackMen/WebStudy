$(function () {
    $("#addcourse").click(function () {
        $("#expan").css({ "display": "none" });
        $("#settime").css({ "display": "none" });
        $("#add").css({ "display": "block" });
    });
    $("#expancourse").click(function () {
        $("#add").css({ "display": "none" });
        $("#settime").css({ "display": "none" });
        $("#expan").css({ "display": "block" });
    });
    $("#section").click(function () {
        $("#add").css({ "display": "none" });
        $("#expan").css({ "display": "none"});
        $("#settime").css({ "display": "block" });
    });
    $(".span2").datetimepicker();
})
