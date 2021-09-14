$(document).ready(function () {
    $('.login-hint-good').hide()
    $('.login-hint-bad').hide()

    $('input[name = Login]').keyup(function () {
        $('.login-hint-good').hide()
        $('.login-hint-bad').hide()
        var word = $(this);
        var currentLogin = word.val();

        var UrlValidateLogin = "/User/LoginValidate?login=" + currentLogin;
        var promise = $.get(UrlValidateLogin);
        promise.done(function (response) {
            if (response) {
                $('.login-hint-good').show();
                self.css('border-color', 'Red');
                self.css('border-', '');
            }
            else {
                $('.login-hint-bad').show()
            }
        })
    })
})