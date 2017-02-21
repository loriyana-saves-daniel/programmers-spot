<%@ Page Title="Manage Account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="ProgrammersSpot.WebClient.Account.Manage" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="manage-profile">
        <asp:LoginView runat="server" ID="LoginView">
              <RoleGroups>
                <asp:RoleGroup Roles="User">
                    <ContentTemplate>
                        <div class="edit-user row">
                            <div class="form-horizontal col-md-6" >
                                <h2>Edit your profile information</h2>
                                <hr />
                                <div runat="server" ID="RegularUserEditProfileForm" visible="true">
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="Age" CssClass="col-md-2 control-label">Age</asp:Label>
                                        <div class="col-md-10">
                                            <asp:TextBox runat="server" ID="Age" CssClass="form-control" ValidationGroup="Update" />
                                            <asp:RegularExpressionValidator runat="server" ControlToValidate="JobTitle" ValidationGroup="Update"
                                                ValidationExpression="[0-9]{2,3}" CssClass="text-danger" Display="Dynamic"
                                                ErrorMessage="Invalid age!" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="JobTitle" CssClass="col-md-2 control-label">Job Title</asp:Label>
                                        <div class="col-md-10">
                                            <asp:TextBox runat="server" ID="JobTitle" CssClass="form-control" ValidationGroup="Update" />
                                            <asp:RegularExpressionValidator runat="server" ControlToValidate="JobTitle" ValidationGroup="Update"
                                                ValidationExpression="[a-zA-Z0-9]{2,20}" CssClass="text-danger" Display="Dynamic"
                                                ErrorMessage="The job title must be between 2 and 20 sybmols." />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="Facebook" CssClass="col-md-2 control-label">Facebook</asp:Label>
                                        <div class="col-md-10">
                                            <asp:TextBox runat="server" ID="Facebook" CssClass="form-control" ValidationGroup="Update" />
                                            <asp:RegularExpressionValidator runat="server" ControlToValidate="Facebook" ValidationGroup="Update"
                                                ValidationExpression="[\s\S]{2,40}"
                                                CssClass="text-danger" Display="Dynamic" ErrorMessage="Invalid facebook profile!" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="GitHub" CssClass="col-md-2 control-label">GitHub</asp:Label>
                                        <div class="col-md-10">
                                            <asp:TextBox runat="server" ID="GitHub" CssClass="form-control" ValidationGroup="Update" />
                                            <asp:RegularExpressionValidator runat="server" ControlToValidate="GitHub" ValidationGroup="Update"
                                                ValidationExpression="[\s\S]{2,40}"
                                                CssClass="text-danger" Display="Dynamic" ErrorMessage="Invalid facebook profile!" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-md-offset-2 col-md-10">
                                            <asp:Button runat="server" CausesValidation="true" OnClick="Update_Click" ValidationGroup="Update" Text="Update profile" CssClass="btn btn-default special" />
                                            <asp:HyperLink NavigateUrl="/Account/ManagePassword" Text="Change" Visible="false" ID="ChangePassword" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="form-horizontal col-md-6">
                                <section id="socialLoginForm">
                                    <h2>Add new skills and projects</h2>
                                    <hr />
                                    <%--Skills--%>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="Skill" CssClass="col-md-2 control-label">Skill</asp:Label>
                                        <div class="col-md-10">
                                            <asp:TextBox runat="server" ID="Skill" CssClass="form-control" ValidationGroup="SkillValidation"/>
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Skill" ValidationGroup="SkillValidation" 
                                                CssClass="text-danger" Display="Dynamic" ErrorMessage="Skill is required!"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator runat="server" ControlToValidate="Skill" 
                                                ValidationExpression="[/s/S]{2,20}" ValidationGroup="SkillValidation"
                                                CssClass="text-danger" Display="Dynamic" ErrorMessage="Skill must be between 2 and 20 symbols." />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-md-offset-2 col-md-10">
                                            <asp:Button runat="server" OnClick="AddSkill_Click"  CausesValidation="true" ValidationGroup="SkillValidation" Text="Add Skill" CssClass="btn btn-default special" />
                                        </div>
                                    </div>
                                   <%-- Projects--%>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="Project" CssClass="col-md-2 control-label">Project</asp:Label>
                                        <div class="col-md-10">
                                            <asp:TextBox runat="server" ID="Project" CssClass="form-control" />
                                            <asp:RegularExpressionValidator runat="server" ControlToValidate="Project" 
                                                ValidationExpression="[a-zA-Z]{2,20}"
                                                CssClass="text-danger" Display="Dynamic" ErrorMessage="Project name must be between 2 and 20 symbols." />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="LinkToProject" CssClass="col-md-2 control-label">Project link</asp:Label>
                                        <div class="col-md-10">
                                            <asp:TextBox runat="server" ID="LinkToProject" CssClass="form-control" />
                                            <asp:RegularExpressionValidator runat="server" ControlToValidate="LinkToProject" 
                                                ValidationExpression="[\s\S]{2,40}"
                                                CssClass="text-danger" Display="Dynamic" ErrorMessage="Link to project must be between 2 and 40 symbols." />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-md-offset-2 col-md-10">
                                            <asp:Button runat="server" OnClick="AddProject_Click" Text="Add Project" CssClass="btn btn-default special" />
                                        </div>
                                    </div>                     
                                </section>
                            </div>
                        </div>               
                    </ContentTemplate>
                </asp:RoleGroup>

                <asp:RoleGroup Roles="Firm">
                        <ContentTemplate>
                        <div>
                            <div class="form-horizontal">
                                <h2>Edit your company information</h2>
                                <hr />
                                <div runat="server" ID="FirmUserEditProfileForm" visible="true">
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="Address" CssClass="col-md-2 control-label">Address</asp:Label>
                                        <div class="col-md-10">
                                            <asp:TextBox runat="server" ID="Address" CssClass="form-control" />
                                            <asp:RegularExpressionValidator runat="server" ControlToValidate="Address" 
                                                ValidationExpression="[\s\S]{4,20}"
                                                CssClass="text-danger" Display="Dynamic" ErrorMessage="Address must be between 4 and 20 symbols." />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="EmployeesCount" CssClass="col-md-2 control-label">Employees count</asp:Label>
                                        <div class="col-md-10">
                                            <asp:TextBox runat="server" ID="EmployeesCount" CssClass="form-control" />
                                            <asp:RegularExpressionValidator runat="server" ControlToValidate="EmployeesCount" 
                                                ValidationExpression="[0-9]{1,5}" CssClass="text-danger" Display="Dynamic"
                                                ErrorMessage="Invalid count!" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="Website" CssClass="col-md-2 control-label">Website</asp:Label>
                                        <div class="col-md-10">
                                            <asp:TextBox runat="server" ID="Website" CssClass="form-control" />
                                            <asp:RegularExpressionValidator runat="server" ControlToValidate="Website" 
                                                ValidationExpression="[\s\S]{2,40}"
                                                CssClass="text-danger" Display="Dynamic" ErrorMessage="Invalid website!" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-md-offset-2 col-md-10">
                                            <asp:Button runat="server" OnClick="UpdateCompany_Click" Text="Update company info" CssClass="btn btn-default special" />
                                            <asp:HyperLink NavigateUrl="/Account/ManagePassword" Text="Change" Visible="false" ID="ChangePassword" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:RoleGroup>
            </RoleGroups>     
        </asp:LoginView>
    </div>
    
    <div class="row change-password">
        <div class="col-md-12">
            <div class="form-horizontal">
                <hr />
                <div>
                    <asp:PlaceHolder runat="server" ID="successMessage" Visible="false" ViewStateMode="Disabled">
                        <p class="text-success"><%: SuccessMessage %></p>
                    </asp:PlaceHolder>
                </div>
                <asp:HyperLink NavigateUrl="/Account/ManagePassword" Text="Change Password" Visible="false" ID="ChangePassword" runat="server" />         
                </>
            </div>
        </div>
    </div>

</asp:Content>
