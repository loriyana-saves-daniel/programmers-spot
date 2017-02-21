'use strict';

var maxFileSize = 4 * 1024 * 1024, // bytes
    invalidFileExtMsg = "The allowed file formats are .jpeg, .jpg and .png.",
    selectFileMsg = "Select image...";


$(document).ready(() => {
    $("#MainContent_Submit").hide();

    $("#file-upload-image").kendoUpload({
        async: {
            saveUrl: "https://www.programmersspot.com/TakeABreak/UploadImage",
            autoUpload: false
        },
        validation: {
            allowedExtensions: [".jpg", ".jpeg", ".png"],
            maxFileSize: maxFileSize
        },
        multiple: false,
        localization: {
            invalidFileExtension: invalidFileExtMsg,
            select: selectFileMsg
        },
        upload: onUpload,
        success: onSuccess,
        error: onError
    });

    $("#upload-by").change((e) => {
        var upload;
        if (e.currentTarget.value === "file") {
            upload = $("#file-upload-image").data("kendoUpload");
            if (upload) {
                upload.enable();
            }

            $("#MainContent_ImageUrl").hide();
            $("#MainContent_Submit").hide();
        } else {
            upload = $("#file-upload-image").data("kendoUpload");
            if (upload) {
                upload.disable();
            }

            $("#MainContent_ImageUrl").show();
            $("#MainContent_Submit").show();
        }
    });

    function onUpload(e) {
        var imgTitle = $('#MainContent_ImageTitle').val();
        var xhr = e.XMLHttpRequest;
        if (xhr) {
            xhr.addEventListener("readystatechange", function (e) {
                if (xhr.readyState === 1 /* OPENED */) {
                    xhr.setRequestHeader("Image-Title", encodeURIComponent(imgTitle));
                }
            });
        }
    }

    function onSuccess(e) {
        $('#MainContent_ErrorMessage').text("");
        window.location.replace("https://www.programmersspot.com/TakeABreak");
    }

    function onError(e) {
        var response = e.XMLHttpRequest.response;
        if (response.ErrorMsg) {
            $('#MainContent_ErrorMessage').text(e.XMLHttpRequest.response)
        }
    }
});