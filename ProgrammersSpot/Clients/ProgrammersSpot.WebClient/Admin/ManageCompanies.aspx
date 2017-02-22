<%@ Page Title="Manage companies" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageCompanies.aspx.cs" Inherits="ProgrammersSpot.WebClient.Admin.ManageCompanies" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridViewFirms" runat="server" AllowPaging="true" AllowSorting="true" ItemType="ProgrammersSpot.Business.Models.Users.FirmUser"
        DataKeyNames="Id" SelectMethod="GridViewFirms_GetData" UpdateMethod="GridViewFirms_UpdateItem" AutoGenerateEditButton="true"
        CssClass ="grid-view" ShowHeader="true" GridLines="Both" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="FirmName" HeaderText="Firm name" InsertVisible="False" ReadOnly="False" SortExpression="FirmName" />
            <asp:ImageField DataImageUrlField="AvatarUrl" HeaderText="Avatar">
                <ControlStyle Height="200px" Width="200px" />
                <ItemStyle Width="200px" Wrap="False" />
            </asp:ImageField>
            <asp:BoundField DataField="Email" HeaderText="Email" InsertVisible="False" ReadOnly="False" SortExpression="Email" />
            <asp:BoundField DataField="Address" HeaderText="Address" InsertVisible="False" ReadOnly="False" SortExpression="Address" />
            <asp:BoundField DataField="EmployeesCount" HeaderText="Employees" InsertVisible="False" ReadOnly="False" SortExpression="EmployeesCount" />
            <asp:BoundField DataField="Rating" HeaderText="Rating" InsertVisible="False" ReadOnly="False" SortExpression="Rating" />
            <asp:BoundField DataField="Website" HeaderText="Website" InsertVisible="False" ReadOnly="False" SortExpression="Website" />
            <asp:BoundField DataField="IsApproved" HeaderText="IsApproved" InsertVisible="False" ReadOnly="False" SortExpression="Id" />
            <asp:BoundField DataField="IsDeleted" HeaderText="IsDeleted" ReadOnly="False" SortExpression="IsDeleted" />
        </Columns>
    </asp:GridView>
</asp:Content>
