'use strict';

var maxFileSize = 5 * 1024 * 1024, // bytes
    invalidFileExtMsg = "The allowed file formats are .jpeg, .jpg and .png.",
    selectFileMsg = "Select image...";

$(document).ready(() => {
    var saveUrl = "";
    var redirectUrl = "";
    var buttonToHide;
    var url = window.location.toString().toLowerCase();
    if (url.indexOf("/account/manage") > 0) {
        saveUrl = "https://www.programmersspot.com/Account/UploadProfilePic";
        redirectUrl = "https://www.programmersspot.com/Account/Profile";
        buttonToHide = $("#MainContent_ButtonUpdateAvatarUrl");
    } else if (url.indexOf("/takeabreak/useruploadimage") > 0) {
        saveUrl = "https://www.programmersspot.com/TakeABreak/UploadImage";
        redirectUrl = "https://www.programmersspot.com/TakeABreak";
        buttonToHide = $("#MainContent_Submit");
    }

    buttonToHide.hide();

    $("#file-upload-image").kendoUpload({
        async: {
            saveUrl: saveUrl,
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
            buttonToHide.hide();
        } else {
            upload = $("#file-upload-image").data("kendoUpload");
            if (upload) {
                upload.disable();
            }

            $("#MainContent_ImageUrl").show();
            buttonToHide.show();
        }
    });

    function onUpload(e) {
        var inputImgTitle = $('#MainContent_ImageTitle');
        if (inputImgTitle) {
            var imgTitle = inputImgTitle.val();
            var xhr = e.XMLHttpRequest;
            if (xhr) {
                xhr.addEventListener("readystatechange", function (e) {
                    if (xhr.readyState === 1 /* OPENED */) {
                        xhr.setRequestHeader("Image-Title", encodeURIComponent(imgTitle));
                    }
                });
            }
        }
    }

    function onSuccess(e) {
        $('#MainContent_ErrorMessage').text("");
        window.location.replace(redirectUrl);
    }

    function onError(e) {
        var response = e.XMLHttpRequest.response;
        if (response.ErrorMsg) {
            $('#MainContent_ErrorMessage').text(e.XMLHttpRequest.response);
        }
    }
});