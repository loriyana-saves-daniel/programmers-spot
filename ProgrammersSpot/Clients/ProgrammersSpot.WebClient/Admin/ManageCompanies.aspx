<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageCompanies.aspx.cs" Inherits="ProgrammersSpot.WebClient.Admin.ManageCompanies" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridViewFirms" runat="server" AllowPaging="true" AllowSorting="true" ItemType="ProgrammersSpot.Business.Models.Users.FirmUser"
        DataKeyNames="Id" SelectMethod="GridViewFirms_GetData" UpdateMethod="GridViewFirms_UpdateItem" AutoGenerateEditButton="true"
        CssClass ="grid-view" ShowHeader="true" GridLines="Both" AutoGenerateColumns="true">
    </asp:GridView>
</asp:Content>
