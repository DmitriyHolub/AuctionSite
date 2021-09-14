$(document).ready(function () {
    $('input[name=LotImages]').click(function () {

        var oneMoreImage = $('input[name=LotImages].input-image-lot').clone();
        oneMoreImage.removeClass('input-image-lot');
        $('.new-image-for-lot').append(oneMoreImage);
    });
});