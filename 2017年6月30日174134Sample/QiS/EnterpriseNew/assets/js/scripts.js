

$(function() {

    $('#login').click(function () {
        //alert("Ö´ÐÐ");
        var username = $('.username').val();
        var password = $('.password').val();
        //alert(username);
            //alert(password);
        if(username == '') {
            $(this).find('.error').fadeOut('fast', function(){
                $(this).css('top', '27px');
            });
            $(this).find('.error').fadeIn('fast', function(){
                $(this).parent().find('.username').focus();
            });
            return false;
        }
        if (password == '') {
            $(this).find('.error').fadeOut('fast', function () {
                $(this).css('top', '96px');
            });
            $(this).find('.error').fadeIn('fast', function () {
                $(this).parent().find('.password').focus();
            });
            return false;
        }
        else {
            
            $.ajax({
                type: 'post',
                url: "../../LoginWeb.asmx/ModelLogin",
                contentType: "application/json;charset-utf8",
                data: '{"username":"'+username+'","pwd":"'+password+'"}',
                dataType: "json",
                async: false,
                success: function (result) {
                    //if (result.d == true) {
                    //    //window.location.href = '../../Set/personalset.html';
                    //}
                    //else {
                    //    alert("Error");
                    //}
                    var aa = result.d;
                    //alert(aa);
                    if (aa == "true") {
                        // alert("jump");
                        window.location.href = '../../Set/personalset.html';
                    }
                    else {
                        alert("Passwo Wrong£¡")
                    }
                    
                },
                error: function () {
                    alert("System Error£¡");
                }
            })
        }
    });

    $('.page-container form .username, .page-container form .password').keyup(function(){
        $(this).parent().find('.error').fadeOut('fast');
    });

});
$(function () {
    $("#managerlogin").click(function () {

        window.location.href = '../../resources/ManagerLogin.html';
    })
})
