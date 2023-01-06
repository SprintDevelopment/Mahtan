showInPopup = (url, title, isLargeModal, isScrollableModal) => {
    $.ajax({
        async: true,
        type: "GET",
        url: url,
        success: function (res) {
            if (isLargeModal)
                $("#form-modal .modal-dialog").addClass('modal-lg');
            else
                $("#form-modal .modal-dialog").removeClass('modal-lg');

            if (isScrollableModal)
                $("#form-modal .modal-dialog").addClass('modal-dialog-scrollable');
            else
                $("#form-modal .modal-dialog").removeClass('modal-dialog-scrollable');

            $("#form-modal .modal-content").html(res);
            //$("#form-modal #modal-title").html(title);
            $("#form-modal").modal('show');
        }
    });
}

jQueryAjaxPost = form => {
    try {
        if ($(form).valid()) {
            $("#submit-button").prop("disabled", true);
            $("#submit-button").html(
                '<span class="spinner-border spinner-border-sm me-2" role="status" aria-hidden="true"></span> تایید'
            );
            $.ajax({
                async: true,
                type: "POST",
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData: false,
                success: function (res) {
                    if (res.isValid) {
                        $("#data-list").html(res.html);
                        $("#form-modal").modal('hide');
                        $("#form-modal .modal-body").html('');
                        $("#form-modal #modal-title").html('');
                    }
                    else
                        $("#form-modal .modal-content").html(res.html);
                }
            })
        }
    } catch (e) {
        console.log(e);
    }
    return false;
}

jQueryAjaxPostProfile = form => {
    try {
        if ($(form).valid()) {
            $("#submit-button").prop("disabled", true);
            $("#submit-button").html(
                '<span class="spinner-border spinner-border-sm me-2" role="status" aria-hidden="true"></span> ویرایش پروفایل'
            );
            $.ajax({
                async: true,
                type: "POST",
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData: false,
                success: function (res) {
                    $("#alert-div").html(res.html);
                    $("#submit-button").html('ویرایش پروفایل');
                    $("#submit-button").prop("disabled", false);
                    $("#user-avatar").attr("src", "/resources/img/avatars/" + res.userAvatar);
                    $("#user-full-name").html(res.userFullName);
                }
            })
        }
    } catch (e) {
        console.log(e);
    }
    return false;
}
