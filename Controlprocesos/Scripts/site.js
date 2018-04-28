$(function () {
    $('.changeStatus').change(function (e) {
        $(this)[0].form.submit();
    })
})