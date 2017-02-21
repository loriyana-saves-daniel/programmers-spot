<%@ Page Title="Upload an image" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserUploadImage.aspx.cs" Inherits="ProgrammersSpot.WebClient.TakeABreak.UserUploadImage" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="../Content/Kendo/kendo.common.min.css" />
    <link rel="stylesheet" href="../Content/Kendo/kendo.silver.min.css" />
    <link rel="stylesheet" href="../Content/Kendo/kendo.silver.mobile.min.css" />
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/kendo.all.min.js"></script>
    <div class="upload-image">
        <p class="text-danger message" runat="server" ID="ErrorMessage">
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
    
        <script src="../Scripts/my-scripts/user-upload-image.js"></script>
    </div>
</asp:Content>
