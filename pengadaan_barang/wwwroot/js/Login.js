$(document).ready(function () {
    $('#Login').click(function () {
        var data = {
            "email": $("#email").val(),
            "password": $("#password").val()
        };
        $.ajax({
            url: "https://localhost:44308/api/Account/Login",
            type: "POST",
            data: JSON.stringify(data),
            dataType: "json",
            contentType: "application/json",
            success: function (response) {
                if (response.SuccessStatusCode == 200) {
                    //$.get("@Url.Action("Kabag", "Index")", function (data) {
                    //    $('.container').html(data);
                    //});
                    console.log("Success Login")
                }
                else
                    //window.location.href = "@Url.Action("Home", "Index")";
                console.log("Error Login")
            },
            error: function () {
                console.log('Login Fail!!!');
            }
        });
    });
});