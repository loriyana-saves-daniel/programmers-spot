<%@ Page Language="C#" Title='<%# Model.Image != null ? Model.Image.Title : "Image Details" %>' AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ImageDetails.aspx.cs" Inherits="ProgrammersSpot.WebClient.TakeABreak.ImageDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView runat="server" ID="FormViewImageDetails" ItemType="ProgrammersSport.Business.Models.UploadedImages.UploadedImage" SelectMethod="FormViewImageDetails_GetItem">
        <ItemTemplate>
            <header>
                <h1><%#: Item.Title %></h1>
            </header>
                <asp:Image runat="server" ImageUrl="<%#: Item.Src %>" />
                <p>Uploaded by: <a href="#"><%# Item.Uploader.FirstName + " " + Item.Uploader.LastName %></a></p>
            <footer>
                <asp:Repeater runat="server" ItemType="ProgrammersSport.Business.Models.UploadedImageComments.UploadedImageComment" DataSource="<%# Item.Comments %>">
                    <ItemTemplate>
                        <div class="comment">
                            <h4> <%# Item.Content %> </h4>
                            <p> <%# Item.Author.FirstName + " " + Item.Author.LastName %> </p>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:TextBox runat="server" ID="TextBoxComment" CssClass="form-control"></asp:TextBox>
                <asp:Button runat="server" ID="ButtonAddComment" Text="Add comment" CssClass="btn btn-primary" />
            </footer>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
