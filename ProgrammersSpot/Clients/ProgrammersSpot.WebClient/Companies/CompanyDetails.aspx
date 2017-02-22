<%@ Page Title='<%# this.Model.Firm.FirmName %>' Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master" CodeBehind="CompanyDetails.aspx.cs" Inherits="ProgrammersSpot.WebClient.Companies.CompanyDetails" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="regular-user-profile" >
        <h2>
        <%: this.Model.Firm.FirmName + "'s Profile" %>
        </h2>
        
        <ul id="profile" class="profile">
            <li>
                <div class="col col_4 profile-pic">
                    <asp:Image runat="server" CssClass="img-responsive avatar" ImageUrl="<%# this.Model.Firm.AvatarUrl %>" />
                    <div class="info">
                        <p><i class="fa fa-map-marker"></i> <%: this.Model.Firm.Country.Name %> (<%: this.Model.Firm.City.Name %>) </p>
                        <asp:LinkButton runat="server" ID="Star" firmId="<%# this.Model.Firm.Id %>" Text="<i class='fa fa-star'></i> Star" 
                                OnClick="Star_Click" CssClass="btn-o" />
                        <div class="social-profiles firm">
                            <a href="<%: this.Model.Firm.Website %>" class="fa fa-globe"></a>
                        </div>
                    </div>
                </div>       
            </li>
            <li class="default open">
                <div class="link"><i class="fa fa-globe"></i>About</div>
                <ul class="submenu">
                    <li>Adress : <%: this.Model.Firm.Address %></li>
                    <li>Employees : <%: this.Model.Firm.EmployeesCount %></li>
                </ul>
            </li>
        </ul>
        <div class="reviews-section">
            <h1><%# this.Model.Firm.FirmReviews.Count == 0 ? "No reviews" : "Reviews:" %></h1>
            <asp:Repeater runat="server" ItemType="ProgrammersSpot.Business.Models.Reviews.Review" DataSource="<%# this.Model.Firm.FirmReviews %>">
                <HeaderTemplate>
                    <h5 class="comment-content">  </h5>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="comment">
                        <h5 class="comment-content"> <%# Item.Content %> </h5>
                        <p class="comment-author"> Author: <a href="#"> <%# Item.Author != null ? Item.Author.FirstName + " " + Item.Author.LastName : "Anonymous" %> </a> </p>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <div class="add-comment">
                <asp:TextBox TextMode="MultiLine" runat="server" ID="TextBoxComment" ValidationGroup="review" CssClass="add-comment"></asp:TextBox>
                <asp:Button ValidationGroup="review" runat="server" ID="ButtonAddReview" OnClick="ButtonAddReview_Click" Text="Add review" CssClass="btn btn-primary" />
            </div>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxComment" ValidationGroup="review"
            CssClass="text-danger" Display="Dynamic" ErrorMessage="Your review must be at least 10 symbols." />
        </div>       
    </div>  
</asp:Content> 

