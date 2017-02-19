<%@ Page Title="Profile" Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="ProgrammersSpot.WebClient.Account.Profile" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2>
        <%: this.Model.FoundRegularUser.FirstName + " " + 
                this.Model.FoundRegularUser.LastName + "'s Profile" %>
    </h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
</asp:Content>
