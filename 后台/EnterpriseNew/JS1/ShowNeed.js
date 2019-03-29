/// <reference path="../ShowNeedWeb.asmx" />

$(function () {
    $("#submits").click(function () {
        var rand = $("#rand option:selected");
        rands = rand.val();//种类
        var descirb = $("#describ").val();//描述
        var name;//姓名
        var firstname = $("#name").val();//姓
        var secondname;//名
        var radio = document.getElementsByName("gender");
        for (var i = 0; i < radio.length; i++) {
            if (radio[i].checked == true) {
                secondname = radio[i].value;
                //alert(gender);
            }
        }
        name = firstname + secondname;
        var pros = $("#province option:selected");
        var province = pro.val();//省份
        var citys = $("#city option:selected");
        var city = citys.val();//城市
        var countys = $("#county option:selected");
        var county = countys.val();//县
        var address;//地址
        address = province + "_" + city + "_" + county;
        var d = new Date();
        var time = d.getFullYear().toString() + "/" + d.getMonth().toString() + "/" + d.getDate().toString() + "/" + d.getHours().toString() + "/" + d.getMinutes().toString() + "/" + d.getSeconds().toString();//发布时间
        var email = $("#email").val();//email
        var tel = $("#tel").val();//电话
        if (rands == "" || descirb == "" || firstname == "" || secondname == "" || province == "" || city == "" || county == "" || address == "" || email == "" || tel == "") {
            alert("有必填项为空，请补充完整");
        }
        else {
            $.ajax({
                type: 'post',
                url: "../ShowNeedWeb.asmx/share",
                contentType: "application/json;charset-utf8",
                data: '{""region":"'+address+'","industry":"'+rands+'","time":"'+time+'","content":"'+descirb+'","name":"'+name+'","tel":"'+tel+'","email":"'+email+'""}',
                dataType: "json",
                async: false,
                success: function (result) {
                    if (result.d == "true") {
                        alert("发布成功");
                    }
                    else {
                        alert("发布失败");
                    }
                },
                errror: function (err) {
                    alert("系统错误");
                }
            })
        }

    })
})
