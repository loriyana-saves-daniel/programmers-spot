<%@ Page Language="C#" Title='<%# Model.Image.Title != "" ? Model.Image.Title : "Image" %>' AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ImageDetails.aspx.cs" Inherits="ProgrammersSpot.WebClient.TakeABreak.ImageDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <section class="page-image-details">
    <div class="image-details">
    <asp:FormView runat="server" ID="FormViewImageDetails" CssClass="image-details"
         ItemType="ProgrammersSpot.Business.Models.UploadedImages.UploadedImage" SelectMethod="FormViewImageDetails_GetItem">
        <ItemTemplate>
            <header>
                <h2><%#: Item.Title %></h2>
            </header>
            <asp:Image CssClass="uploaded-image" runat="server" ImageUrl="<%# Item.OriginalSrc %>" />
            <p class="likes-dislikes">
                <span class="left">Uploaded by: <a href="#"><%#: Item.Uploader.FirstName + " " + Item.Uploader.LastName %></a> </span>
                <asp:LinkButton runat="server" ID="LinkButtonLike" imgId="<%# Item.Id %>" OnClick="LinkButtonLike_Click" class="likes"><%# Item.LikesCount %></asp:LinkButton>
                <asp:LinkButton runat="server" ID="LinkButtonDislike" imgId="<%# Item.Id %>" OnClick="LinkButtonDislike_Click" class="dislikes"><%# Item.DislikesCount %></asp:LinkButton>
                <asp:HyperLink CssClass="right" runat="server" NavigateUrl="~/TakeABreak">Browse more images</asp:HyperLink>
            </p>
            <h1><%# Item.Comments.Count == 0 ? "No comments" : "Comments:" %></h1>
            <footer>
                <asp:Repeater runat="server" ItemType="ProgrammersSpot.Business.Models.UploadedImageComments.UploadedImageComment" DataSource="<%# Item.Comments %>">
                    <HeaderTemplate>
                        <%--<h1>Comments:</h1>--%>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="comment">
                            <h5 class="comment-content"> <%# Item.Content %> </h5>
                            <p class="comment-author"> Commented by: <a href="#"> <%# Item.Author != null ? Item.Author.FirstName + " " + Item.Author.LastName : "Anonymous" %> </a> </p>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </footer>
        </ItemTemplate>
    </asp:FormView>
    <div class="add-comment">
        <asp:TextBox TextMode="MultiLine" runat="server" ID="TextBoxComment" ValidationGroup="comment" CssClass="add-comment"></asp:TextBox>
        <asp:Button ValidationGroup="comment" runat="server" ID="ButtonAddComment" OnClick="ButtonAddComment_Click" Text="Add comment" CssClass="btn btn-primary" />
    </div>
    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxComment" ValidationGroup="comment"
        CssClass="text-danger" Display="Dynamic" ErrorMessage="Your comment must be at least 5 symbols." />
    </div>
    </section>
</asp:Content>
