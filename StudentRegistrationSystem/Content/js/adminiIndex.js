$(function () {
    $("#addcourse").click(function () {
        $("#expan").css({ "display": "none" });
        $("#settime").css({ "display": "none" });
        $("#add").css({ "display": "block" });
    });
    $("#expancourse").click(function () {
        $("#expan").empty();
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
    $("#submit-time").click(function () {
        if ($("#begin-time").val() == '' || $("#over-time").val() ==''){
            alert("输入不能为空，重新刷新输入！");
        }
        else {
            $("#begin-time").attr("readonly", "readonly");
            $("#over-time").attr("readonly", "readonly");

            alert("设置成功！");
        }
    });
    $("#reset-time").click(function () {
        $("#begin-time").attr("readonly", false);
        $("#over-time").attr("readonly", false);
    });
    $("#expan").on("click", "#dilatation", this, function (event) {
        var cno = $("#cno-insert").val();
        var cname = $("#cname-insert").val();
        var cnumber = $("#cdept-insert").val();
        $.ajax({
            type: "get",
            contentType: "application/json",
            url: "/Admin/Dilatation",
            async: false,
            data: { classNumber: cno, className: cname, classCapacity: cnumber },
            success: function (result) {
                alert(result);
                

            },
            error: function () {
                alert("出错了");
            }
        });
    });
    $("#expan").on("click", "#resetdilatation", this, function (event) {
        $("#cno-insert").val("");
        $("#cname-insert").val("");
        $("#cdept-insert").val("");
    });

})
