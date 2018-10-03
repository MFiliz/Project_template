$(function() {
    
    $(".validation-summary-errors").each(function () {

        $(this).css("display", "none");
        toastr.options = {
            "closeButton": false,
            "debug": false,
            "newestOnTop": false,
            "progressBar": false,
            "positionClass": "toast-top-center",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "200",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "100",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }
        toastr.error($(this).html(), "Hata");
        return false;
    });

    $(".field-validation-error").each(function () {

        var fieldName = $(this).attr("data-valmsg-for");
        $("*[name='" + fieldName + "']").addClass("error-border");

    });

    $(".error-border").on("click", function () {
        $(this).removeClass("error-border");
    });

   

});

