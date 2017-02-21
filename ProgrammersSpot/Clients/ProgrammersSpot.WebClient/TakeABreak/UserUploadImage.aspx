<%@ Page Title="Upload an image" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserUploadImage.aspx.cs" Inherits="ProgrammersSpot.WebClient.TakeABreak.UserUploadImage" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="../Content/Kendo/kendo.common.min.css" />
    <link rel="stylesheet" href="../Content/Kendo/kendo.default.min.css" />
    <link rel="stylesheet" href="../Content/Kendo/kendo.default.mobile.min.css" />
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/kendo.all.min.js"></script>
    <div class="upload-image">
        <p class="text-danger">
            <asp:Literal runat="server" ID="ErrorMessage" />
        </p>
    
        <div class="file-upload k-content">
            <p class="upload-by">
                Upload by: 
                <select name="upload-by" id="upload-by" class="upload-by">
                    <option selected="selected" value="file">File</option>
                    <option value="url">Url</option>
                </select> 
            </p>
            <input name="title" runat="server" id="ImageTitle" type="text" class="img-title" placeholder="Image title..."/>
            <input name="imgUrl" hidden="hidden" runat="server" id="ImageUrl" type="text" class="img-title" placeholder="Image url..."/>
            <input name="files" id="file-upload-image" type="file"/>
            <asp:Button runat="server" ID="Submit" OnClick="Submit_Click" Text="Upload"/>
        </div>
    
        <script type="text/javascript">
            $(document).ready(() => {
                $("#MainContent_Submit").hide();

                $("#file-upload-image").kendoUpload({
                    async: {
                        saveUrl: "https://www.programmersspot.com/TakeABreak/UploadImage",
                        autoUpload: false
                    },
                    validation: {
                        allowedExtensions: [".jpg", ".jpeg", ".png"],
                        maxFileSize: 4 * 1024 * 1024
                    },
                    multiple: false,
                    localization: {
                        invalidFileExtension: "The allowed file formats are .jpeg, .jpg and .png.",
                        select: "Select file..."
                    },
                    upload: onUpload
                });

                $("#upload-by").change((e) => {
                    if (e.currentTarget.value == "file") {
                        var upload = $("#file-upload-image").data("kendoUpload");
                        if (upload) {
                            upload.enable();
                        }

                        $("#MainContent_ImageUrl").hide();
                        $("#MainContent_Submit").hide();
                    } else {
                        var upload = $("#file-upload-image").data("kendoUpload");
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
                            if (xhr.readyState == 1 /* OPENED */) {
                                xhr.setRequestHeader("Image-Title", encodeURIComponent(imgTitle));
                            }
                        });
                    }
                }
            });
        </script>
    </div>
</asp:Content>
