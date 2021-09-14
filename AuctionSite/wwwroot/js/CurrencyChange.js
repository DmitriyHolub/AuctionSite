$(document).ready(function () {
    $('select[name=Currencies]').change(function () {
        var w = $(this);
        var current = w.val();

        var url = "/Home/Index?currency=" + current;
        $.get(url);
    })
})