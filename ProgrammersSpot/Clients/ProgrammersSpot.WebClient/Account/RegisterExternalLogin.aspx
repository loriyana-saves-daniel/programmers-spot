<%@ Page Title="Register an external login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegisterExternalLogin.aspx.cs" Inherits="ProgrammersSpot.WebClient.Account.RegisterExternalLogin" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
<h3>Register with your <%: ProviderName %> account</h3>

    <asp:PlaceHolder runat="server">
        <div class="form-horizontal">
            <h4>Association Form</h4>
            <hr />
            <asp:ValidationSummary runat="server" ShowModelStateErrors="true" CssClass="text-danger" />
            <p class="text-info">
                You've authenticated with <strong><%: ProviderName %></strong>. Please enter the required information below for the current site
                and click the Log in button.
            </p>
            
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="FirstName" CssClass="col-md-2 control-label">First name</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="FirstName" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="FirstName"
                        CssClass="text-danger" Display="Dynamic" ErrorMessage="The first name field is required." />
                    <asp:RegularExpressionValidator runat="server" ControlToValidate="FirstName"
                        ValidationExpression="[a-zA-Z]{2,20}" CssClass="text-danger"  Display="Dynamic"
                        ErrorMessage="The first name must be between 2 and 20 sybmols."/>          
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="LastName" CssClass="col-md-2 control-label">Last name</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="LastName" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="LastName" 
                        CssClass="text-danger" Display="Dynamic" ErrorMessage="The last name field is required." />
                    <asp:RegularExpressionValidator runat="server" ControlToValidate="LastName" 
                        ValidationExpression="[a-zA-Z]{2,20}" CssClass="text-danger" Display="Dynamic"
                        ErrorMessage="The last name must be between 2 and 20 sybmols." />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                        Display="Dynamic" CssClass="text-danger" ErrorMessage="Email is required" />
                    <asp:ModelErrorMessage runat="server" ModelStateKey="Email" CssClass="text-error" />
                </div>
            </div>

            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <asp:Button runat="server" Text="Log in" CssClass="btn btn-default" OnClick="LogIn_Click" />
                </div>
            </div>
        </div>
    </asp:PlaceHolder>
</asp:Content>
