$(function () {
    $("#CountryId").change(function () {
        var selectedItem = $(this).val() || 0;

        var ddlStates = $("#StateProvinceId");
        var estimateBox = $(this).closest(".estimate-shipping");

        var throbber = estimateBox.data("throbber");
        if (!throbber) {
            throbber = estimateBox.throbber({ white: true, small: true, show: false }).data("throbber");
        }
        throbber.show();

        $.ajax({
            cache: false,
            type: "GET",
            url: "/frontend/en/Country/GetStatesByCountryId",
            data: { "countryId": selectedItem, "addEmptyStateIfRequired": "false" },
            success: function (data) {
                ddlStates.html('');
                $.each(data, function (id, option) {
                    ddlStates.append($('<option></option>').val(option.id).html(option.name));
                });
                ddlStates.trigger("change");
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert('Failed to retrieve states.'); // TODO: Loc
            },
            complete: function () {
                _.delay(function () { estimateBox.data("throbber").hide() }, 400);
            }
        });
    });
});




$(function () {
    var checkoutButton = $(".confirm-order-next-step-button");
    checkoutButton.click(function () {

        $("#customercommenthidden").val($("#CustomerComment").val());

        //terms of services
        var termOfServiceOk = true;

        if (!$('#termsofservice').is(':checked')) {
            displayNotification('&quot;Please accept the terms of service before the next step.&quot;', "error");
            termOfServiceOk = false;
            $.scrollTo($('#termsofservice'), 800, { offset: -70 });
        }
        else {
            termOfServiceOk = true;
        }


        if (termOfServiceOk) {
            var submitOrderEvent = jQuery.Event('submitOrder');
            submitOrderEvent.isOrderValid = true;
            submitOrderEvent.isMobile = false;

            $(this).trigger(submitOrderEvent);

            if (true === submitOrderEvent.isOrderValid) {
                checkoutButton.attr("disabled", "disabled");
                checkoutButton.find(".fa-caret-right")
                    .removeClass("fa-caret-right")
                    .addClass("fa-spinner fa-spin");

                $('#confirm-order-form').submit();
            }
        }
    });
});


$(document).ready(function () {
    $('#confirm-order-form').submit(function () {
        $('input[type=submit]', this).attr('disabled', 'disabled');
    });
});


$(document).ready(function () {
    $("#terms-of-service-trigger").click(function () {
        $("#terms-of-service-modal .modal-body").html('<iframe id="iframe-terms-of-service" src="/frontend/en/t-popup/conditionsofUse" width="800" scrolling="yes" style="min-height:400px" frameBorder="0" />');
    });
    $("#disclaimer-trigger").click(function () {
        $("#terms-of-service-modal .modal-body").html('<iframe id="iframe-terms-of-service" src="/frontend/en/t-popup/Disclaimer" width="800" scrolling="yes" style="min-height:400px" frameBorder="0" />');
    });
});