<%@ Page Title="Take a break" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProgrammersSpot.WebClient.TakeABreak.TakeABreak" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="break">
        <asp:Panel runat="server" DefaultButton="LinkButtonSearch" class="search-and-sort">
            <asp:TextBox runat="server" ID="TextBoxSearch" type="text" name="imgTitle" CssClass="search-input" class="search-query" placeholder="Search by image title"></asp:TextBox>
            <asp:LinkButton runat="server" ID="LinkButtonSearch" OnClick="LinkButtonSearch_Click" CssClass="button btn-search special" Text="Search"></asp:LinkButton>
            <asp:Label runat="server" Text="Sort by: " />
            <asp:DropDownList CssClass="sort-by" runat="server" ID="SortBy" AutoPostBack="true">
                <asp:ListItem Selected="True" Text="Date" Value="DateUploaded" />
                <asp:ListItem Text="Likes" Value="LikesCount" />
            </asp:DropDownList>
            <asp:CheckBox runat="server" ID="CheckBoxIsDescending" AutoPostBack="true" Checked="true" Text=" Descending" />
            <asp:LinkButton runat="server" ID="LinkButtonUploadImage" OnClick="LinkButtonUploadImage_Click" CssClass="button btn-primary" Text="Upload an image!"></asp:LinkButton>
        </asp:Panel>
        <div class="funImages">
            <asp:ListView runat="server" ID="ListViewImages"
                ItemType="ProgrammersSport.Business.Models.UploadedImages.UploadedImage" SelectMethod="ListViewImages_GetData"
                GroupItemCount="4">
                <LayoutTemplate>
                    <asp:PlaceHolder ID="groupPlaceholder" runat="server" />
                    <asp:DataPager runat="server" ID="DataPager" PagedControlID="ListViewImages" PageSize="12">
                        <Fields>
                            <asp:NumericPagerField ButtonCount="10" CurrentPageLabelCssClass="" NumericButtonCssClass="paging-numeric-btn"
                                PreviousPageText="<--"
                                NextPageText="-->" />
                        </Fields>
                    </asp:DataPager>
                </LayoutTemplate>

                <GroupTemplate>
                    <div class="row">
                        <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
                    </div>
                </GroupTemplate>

                <ItemTemplate>
                    <div class="col-md-3 image" style="background-image: url('<%# Item.Src %>')">
                        <asp:Button runat="server" PostBackUrl='<%# string.Format("~/TakeABreak/ImageDetails.aspx?id={0}", Item.Id) %>' />
                        <asp:LinkButton runat="server" ID="LinkButtonLike" imgId="<%# Item.Id %>" OnClick="LinkButtonLike_Click" class="likes"><%# Item.LikesCount %></asp:LinkButton>
                        <asp:LinkButton runat="server" ID="LinkButtonDislike" imgId="<%# Item.Id %>" OnClick="LinkButtonDislike_Click" class="dislikes"><%# Item.DislikesCount %></asp:LinkButton>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
