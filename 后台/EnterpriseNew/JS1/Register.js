/// <reference path="../RegisterWeb.asmx" />


$(function () {
    $("#register").click(function () {

        var account = $("#account").val();//账号
        var pwd = $("#pwd").val();//密码
        var name = $("#name").val();//姓名
        var address;//地址
        var tel = $("#tel").val();//电话
        var email = $("#email").val();//email
        var repwd = $("#repwd").val();//确认密码
        var gender = "";//性别
        var time;//注册时间
        var gender;

        var radio = document.getElementsByName("gender");
        for (var i = 0; i < radio.length; i++)
        {
            if (radio[i].checked == true) {
                gender = radio[i].value;
                //alert(gender);
            }
        }
        var d = new Date();

        time = d.getFullYear().toString() + "/" + d.getMonth().toString() + "/" + d.getDate().toString();

        var province = $("#province option:selected");
        var city = $("#city option:selected");
        var county = $("#county option:selected");
        address = province.val() + "_" + city.val() + "_" + county.val();
            if (account == "" || pwd == "" || name == "" || tel == "" || email == "" || repwd == "" || gender == "" || address == "") {
                alert("有必填项为空，请补充完整");
            }
            else {
                alert("in");
                if (pwd == repwd) {
                    $.ajax({
                        type: 'post',
                        url: "../RegisterWeb.asmx/register",
                        contentType: "application/json;charset-utf8",
                        data: '{"account":"' + account + '","pwd":"' + pwd + '","name":"' + name + '","address":"' + address + '","tel":"' + tel + '","time":"' + time + '","email":"' + email + '","gender":"'+gender+'"}',
                        //data: '{}',
                        dataType: 'json',
                        async: false,
                        success: function (result) {
                            if (result.d == "true") {
                                alert("注册成功");
                            }
                            else {
                                alert("注册失败");
                            }
                        },
                        error: function (err) {
                            alert("系统错误");
                        }
                    })
                }
                else {
                    alert("密码不一致，请确认密码");
                }

            }
        
        
    })
})