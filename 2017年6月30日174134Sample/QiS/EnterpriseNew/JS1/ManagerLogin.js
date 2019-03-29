/// <reference path="../ManagerLoginWeb.asmx" />

$(function () {
    $("#login").click(function () {
        alert("1234444");
        var username = $("#username").val();
        var pwd = $("#pwd").val();
        if (username == "") {
            alert("请输入账号");
        }
        else if (pwd == "") {
            alert("请输入密码");
        }
        else {
            $.ajax({
                type: 'post',
                url: "../ManagerLoginWeb.asmx/Login",
                contentType: "application/json;charset-utf8",
                data: '{"username":"'+username+'","pwd":"'+pwd+'"}',
                dataType: "json",
                async: false,
                success: function (result) {
                    aa = result.d;
                    if (aa == "true") {
                        alert("登录成功");
                    }
                    else {
                        alert("账号或密码错误");
                    }
                },
                error: function (err) {
                    alert("系统错误");
                }
            })
        }
    })
})