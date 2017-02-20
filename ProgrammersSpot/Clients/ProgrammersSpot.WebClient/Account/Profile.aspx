<%@ Page Title="Profile" Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="ProgrammersSpot.WebClient.Account.Profile" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:LoginView runat="server">
          <RoleGroups>
            <asp:RoleGroup Roles="User">
                <ContentTemplate>
                    <div class="regular-user-profile" >
                    <h2>
                    <%: this.Model.FoundRegularUser.FirstName + " " + 
                            this.Model.FoundRegularUser.LastName + "'s Profile" %>
                    </h2>
        
                    <ul id="profile" class="profile">
                        <li>
                            <div class="col col_4 profile-pic">
                                <asp:Image runat="server" CssClass="img-responsive avatar" ImageUrl="<%# this.Model.ProfileImage %>" />
                                <div class="info">
                                    <%--<small><i class="fa fa-map-marker"></i> Bulgaria (Sofia)</small>--%>
                                    <p><i class="fa fa-briefcase"></i> <%: this.Model.FoundRegularUser.JobTitle %>  </p>  
                                    <a href="#" class="btn-o"> <i class="fa fa-user-plus"></i> Add Friend </a>
                                    <a href="#"  class="btn-o"> <i class="fa fa-message"></i> Follow </a>
                                    <div class="social-profiles">
                                        <a href="<%: this.Model.FoundRegularUser.FacebookProfile %>" class="fa fa-facebook"></a>
                                        <a href="<%: this.Model.FoundRegularUser.GitHubProfile %>" class="fa fa-github"></a>
                                    </div>
                                </div>
                            </div>       
                        </li>
		                <li class="default open">
			                <div class="link"><i class="fa fa-globe"></i>About</div>
			                <ul class="submenu">
				                <li>Age : <%: this.Model.FoundRegularUser.Age==0 ? "" : this.Model.FoundRegularUser.Age.ToString() %></li>
				                <li>Email : <%: this.Model.FoundRegularUser.Email %></li>
			                </ul>
		                </li>
		                <li class="default open">
			                <div class="link"><i class="fa fa-code"></i>Professional Skills</div>
			                <ul class="submenu">
				                <li>
                                    <%--<a href="#"/>--%>
                                        <span class="skill">Adobe Photoshop</span> 
                                        <span class="skill">Corel Draw</span> 
                                        <span class="skill">CSS</span>
                                        <span class="skill">Css 3</span> 
                                        <span class="skill">Graphic Design</span>
                                        <span class="skill">HTML</span> 
                                        <span class="skill">HTML5</span> 
                                        <span class="skill">JavaScript</span> 
                                        <span class="skill">Twitter bootstrap</span> 
                                        <span class="skill">bootstrap</span> 
                                        <span class="skill">User Interface Design</span> 
                                        <span class="skill">Wordpress</span>
                                </li>
		                    </ul>
                        </li>
                    </ul>
                </div>  
                </ContentTemplate>
            </asp:RoleGroup>

            <asp:RoleGroup Roles="Firm">
                <ContentTemplate>
                    FIRM
                </ContentTemplate>
            </asp:RoleGroup>
        </RoleGroups>
        
    </asp:LoginView>
</asp:Content>
