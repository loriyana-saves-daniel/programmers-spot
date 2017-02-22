<%@ Page Title='<%# this.Model.Programmer.FirstName + " " + this.Model.Programmer.LastName %>' Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master" CodeBehind="ProgrammerDetails.aspx.cs" Inherits="ProgrammersSpot.WebClient.Programmers.ProgrammerDetails" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="regular-user-profile" >
        <h2>
        <%: this.Model.Programmer.FirstName + " " + 
                this.Model.Programmer.LastName + "'s Profile" %>
        </h2>
        
        <ul id="profile" class="profile">
            <li>
                <div class="col col_4 profile-pic">
                    <asp:Image runat="server" CssClass="img-responsive avatar" ImageUrl="<%# this.Model.Programmer.AvatarUrl %>" />
                    <div class="info">
                        <p><i class="fa fa-briefcase"></i> <%: this.Model.Programmer.JobTitle %>  </p>
                        <asp:LinkButton runat="server" ID="Star" programmerId="<%# this.Model.Programmer.Id %>" Text="<i class='fa fa-star'></i> Star" 
                                OnClick="Star_Click" CssClass="btn-o" />
                        <div class="social-profiles">
                            <a href="<%: this.Model.Programmer.FacebookProfile %>" class="fa fa-facebook"></a>
                            <a href="<%: this.Model.Programmer.GitHubProfile %>" class="fa fa-github"></a>
                        </div>
                    </div>
                </div>       
            </li>
            <li class="default open">
                <div class="link"><i class="fa fa-globe"></i>About</div>
                <ul class="submenu">
                    <li>Age : <%: this.Model.Programmer.Age==0 ? "" : this.Model.Programmer.Age.ToString() %></li>
                    <li>Email : <%: this.Model.Programmer.Email %></li>
                </ul>
            </li>
            <li class="default open">
                <div class="link"><i class="fa fa-code"></i>Professional Skills</div>
                <ul class="submenu">
                    <li>
                        <asp:Repeater  runat="server" ID="Skills">
                            <ItemTemplate>
                                <span class="skill"><%# Eval("Name") %></span>
                            </ItemTemplate>
                        </asp:Repeater>
                    </li>
                </ul>
            </li>
            <li class="default open">
                <div class="link"><i class="fa fa-file-code-o"></i>Projects</div>
                <ul class="submenu">
                    <li>
                        <asp:Repeater  runat="server" ID="Projects">
                            <ItemTemplate>
                                <a class="skill" href="<%# Eval("LinkToProject") %>"><%# Eval("Name") %></a>
                            </ItemTemplate>
                        </asp:Repeater>
                    </li>
                </ul>
            </li>
        </ul>
    </div>
</asp:Content> 
