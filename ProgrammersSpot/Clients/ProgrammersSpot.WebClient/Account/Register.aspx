<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ProgrammersSpot.WebClient.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <div>
            <h4>Create a new account</h4>
            <hr />
            <div class="form-group">
                <div class="col-md-10">
                    <asp:DropDownList 
                        ID="UserType" 
                        runat="server" 
                        AutoPostBack="True"
                        OnTextChanged="UserType_TextChanged"
                        DataTextField="Name" 
                        DataValueField="Name">
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <div runat="server" ID="RegularUserRegisterForm" visible="true">
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
                        CssClass="text-danger" Display="Dynamic" ErrorMessage="The email field is required." />
                    <asp:RegularExpressionValidator runat="server" ControlToValidate="Email" 
                        ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        CssClass="text-danger" Display="Dynamic" ErrorMessage="Invalid Email!" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                        CssClass="text-danger" Display="Dynamic" ErrorMessage="The password field is required." />
                    <asp:RegularExpressionValidator runat="server" ControlToValidate="Password"
                        ValidationExpression="^[\s\S]{6,}$" CssClass="text-danger" Display="Dynamic"
                        ErrorMessage="The password must be at least 6 symbols." />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Confirm password</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                        CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                    <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                        CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
                </div>
            </div>
        </div>
        
        <div runat="server" ID="FirmRegisterForm" visible="false">
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="CompanyName" CssClass="col-md-2 control-label">Company name</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="CompanyName" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="CompanyName"
                        CssClass="text-danger" Display="Dynamic" ErrorMessage="The company name field is required." />
                    <asp:RegularExpressionValidator runat="server" ControlToValidate="CompanyName"
                        ValidationExpression="^[\s\S]{2,20}$" CssClass="text-danger" Display="Dynamic"
                        ErrorMessage="The company name must be between 2 and 20 symbols." />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="Country" CssClass="col-md-2 control-label">Country</asp:Label>
                <div class="col-md-10">
                    <asp:DropDownList 
                        ID="Country" 
                        runat="server" 
                        AutoPostBack="True"
                        OnSelectedIndexChanged ="Country_SelectedIndexChanged"
                        DataTextField="Name" 
                        DataValueField="Name">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Country"
                        CssClass="text-danger" ErrorMessage="The country field is required." />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="City" CssClass="col-md-2 control-label">City</asp:Label>
                <div class="col-md-10">
                    <asp:DropDownList 
                        ID="City" 
                        runat="server"
                        DataTextField="Name" 
                        DataValueField="Name"></asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="City"
                        CssClass="text-danger" ErrorMessage="The country field is required." />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="Address" CssClass="col-md-2 control-label">Address</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="Address" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Address"
                        CssClass="text-danger" Display="Dynamic" ErrorMessage="The address field is required." />
                     <asp:RegularExpressionValidator runat="server" ControlToValidate="Address"
                        ValidationExpression="^[\s\S]{4,20}$" CssClass="text-danger" Display="Dynamic"
                        ErrorMessage="The address must be between 4 and 20 symbols." />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="FirmEmail" CssClass="form-control" TextMode="Email" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="FirmEmail" Display="Dynamic"
                        CssClass="text-danger" ErrorMessage="The email field is required." />             
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="FirmPassword" CssClass="col-md-2 control-label">Password</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="FirmPassword" TextMode="Password" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="FirmPassword"
                        CssClass="text-danger" Display="Dynamic" ErrorMessage="The password field is required." />
                    <asp:RegularExpressionValidator runat="server" ControlToValidate="FirmPassword"
                        ValidationExpression="^[\s\S]{6,}$" CssClass="text-danger" Display="Dynamic"
                        ErrorMessage="The password must be at least 6 symbols." />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="FirmConfirmPassword" CssClass="col-md-2 control-label">Confirm password</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="FirmConfirmPassword" TextMode="Password" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="FirmConfirmPassword"
                        CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                    <asp:CompareValidator runat="server" ControlToCompare="FirmPassword" ControlToValidate="FirmConfirmPassword"
                        CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
                </div>
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn btn-default special"  />
            </div>
        </div>
    </div>
</asp:Content>
