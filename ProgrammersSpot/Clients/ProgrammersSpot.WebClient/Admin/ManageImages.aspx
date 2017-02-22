<%@ Page Title="Manage images" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageImages.aspx.cs" Inherits="ProgrammersSpot.WebClient.Admin.ManageImages" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="manage-images">
        <asp:GridView ID="GridViewImages" runat="server" CssClass="grid-view" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="PrgrammersSpotSqlDataSource" AllowPaging="True" AllowSorting="True" Width="1000px">
            <Columns>
                <asp:CommandField ShowEditButton="True">
                <ItemStyle VerticalAlign="Top" />
                </asp:CommandField>
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" >
                <ItemStyle VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="DateUploaded" HeaderText="Upload date" SortExpression="DateUploaded" ReadOnly="True" >
                <ItemStyle VerticalAlign="Top" />
                </asp:BoundField>
                <asp:ImageField DataImageUrlField="ThumbnailSrc" HeaderText="Thumbnail image">
                    <ControlStyle Height="300px" Width="300px" />
                    <ItemStyle Width="300px" Wrap="False" />
                </asp:ImageField>
                <asp:ImageField DataImageUrlField="OriginalSrc" HeaderText="Large image">
                    <ControlStyle Height="300px" Width="300px" />
                    <ItemStyle Width="300px" />
                </asp:ImageField>
                <asp:BoundField DataField="UploaderId" HeaderText="UploaderId" SortExpression="UploaderId" ReadOnly="True" >
                <ItemStyle VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="LikesCount" HeaderText="Likes" SortExpression="LikesCount" >
                <ItemStyle VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="DislikesCount" HeaderText="Dislikes" SortExpression="DislikesCount" >
                <ItemStyle VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="IsDeleted" HeaderText="IsDeleted" SortExpression="IsDeleted" />
            </Columns>
            <EditRowStyle Width="1000px" />
            <RowStyle Height="0px" VerticalAlign="Top" Width="1000px" />
        </asp:GridView>
    </div>
    <asp:SqlDataSource ID="PrgrammersSpotSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ProgrammersSpotDbConnectionString %>" SelectCommand="SELECT * FROM [UploadedImages] ORDER BY [DateUploaded] DESC" DeleteCommand="DELETE FROM [UploadedImages] WHERE [Id] = @original_Id" InsertCommand="INSERT INTO [UploadedImages] ([Title], [DateUploaded], [ThumbnailSrc], [OriginalSrc], [IsDeleted], [UploaderId], [LikesCount], [DislikesCount]) VALUES (@Title, @DateUploaded, @ThumbnailSrc, @OriginalSrc, @IsDeleted, @UploaderId, @LikesCount, @DislikesCount)" OldValuesParameterFormatString="original_{0}" UpdateCommand="UPDATE [UploadedImages] SET [Title] = @Title, [ThumbnailSrc] = @ThumbnailSrc, [OriginalSrc] = @OriginalSrc, [IsDeleted] = @IsDeleted, [LikesCount] = @LikesCount, [DislikesCount] = @DislikesCount WHERE [Id] = @original_Id">
        <DeleteParameters>
            <asp:Parameter Name="original_Id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="DateUploaded" Type="DateTime" />
            <asp:Parameter Name="ThumbnailSrc" Type="String" />
            <asp:Parameter Name="OriginalSrc" Type="String" />
            <asp:Parameter Name="IsDeleted" Type="Boolean" />
            <asp:Parameter Name="UploaderId" Type="String" />
            <asp:Parameter Name="LikesCount" Type="Int32" />
            <asp:Parameter Name="DislikesCount" Type="Int32" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="DateUploaded" Type="DateTime" />
            <asp:Parameter Name="ThumbnailSrc" Type="String" />
            <asp:Parameter Name="OriginalSrc" Type="String" />
            <asp:Parameter Name="IsDeleted" Type="Boolean" />
            <asp:Parameter Name="UploaderId" Type="String" />
            <asp:Parameter Name="LikesCount" Type="Int32" />
            <asp:Parameter Name="DislikesCount" Type="Int32" />
            <asp:Parameter Name="original_Id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
