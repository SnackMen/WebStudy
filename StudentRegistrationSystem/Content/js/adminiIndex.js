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
    $("#dilatation").click(function () {
        //$.ajax({
        //    type: "get",
        //    contentType: "application/json",
        //    url: "/Admin/Dilatation",
        //    data: { 'classNumber': $("#cno-insert").val(), 'className': $("#cname-insert").val(), 'classCapacity': $("#cdept-insert").val() },
        //    success: function (result) {
        //        alert(result);
        //    },
        //    error:function(){
        //        alert("出错了");
        //    }
        var cno = $("#cno-insert").text();
        var cname = $("#cname-insert").text();
        var cnumber = $("#cdept-insert").text();
        $.get("/Admin/Dilatation",{classNumber:cno,className:cname,classCapacity:cnumber},function(result){
            alert(result);
        });
    });
})
