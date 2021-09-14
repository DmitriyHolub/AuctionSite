$(document).ready(function () {
    $('input[name=fb]').change(function () {
        var me = $(this);
        var currentLang = me.val();

        var url = "/Home/ChangeLanguage?lang=" + currentLang;
        $.get(url);
        window.location.reload(false)
    });
});