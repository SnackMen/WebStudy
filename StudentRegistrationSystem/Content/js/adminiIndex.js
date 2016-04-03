$(function () {
    $("#addcourse").click(function () {
        $("#expan").css({ "display": "none" });
        $("#add").css({ "display": "block" });
    });
    $("#expancourse").click(function () {
        $("#add").css({ "display": "none" });
        $("#expan").css({ "display": "block" });
    });
})
