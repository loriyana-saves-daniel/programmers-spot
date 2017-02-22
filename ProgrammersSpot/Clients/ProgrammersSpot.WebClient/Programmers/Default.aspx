<%@ Page Title="Programmers" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProgrammersSpot.WebClient.Programmers.Programmers" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="list-profiles">
        <h2>Discover programmers</h2>
        <asp:Panel runat="server" DefaultButton="LinkButtonSearch" class="search-and-sort">
            <asp:TextBox runat="server" ID="TextBoxSearch" type="text" name="skill" CssClass="search-input" class="search-query" placeholder="Search by skill"></asp:TextBox>
            <asp:LinkButton runat="server" ID="LinkButtonSearch" OnClick="LinkButtonSearch_Click" CssClass="button btn-search special" Text="Search"></asp:LinkButton>
            <asp:Label runat="server" Text="Sort by: " />
            <asp:DropDownList CssClass="sort-by" runat="server" ID="SortBy" AutoPostBack="true">
                <asp:ListItem Text="Stars Count" Value="Stars" />
                <asp:ListItem Text="Age" Value="Age" />
                <asp:ListItem Selected="True" Text="First Name" Value="FirstName" />
                <asp:ListItem Text="Last Name" Value="LastName" />
            </asp:DropDownList>
            <asp:CheckBox runat="server" ID="CheckBoxIsDescending" AutoPostBack="true" Checked="true" Text=" Descending" />
        </asp:Panel>
        <div class="companies">
            <asp:ListView runat="server" ID="ListViewProgrammers" ItemType="ProgrammersSpot.Business.Models.Users.RegularUser"
                SelectMethod="ListViewProgrammers_GetData" GroupItemCount="4">
                <LayoutTemplate>
                    <asp:PlaceHolder ID="groupPlaceholder" runat="server" />
                    <div class="row paging-row">
                        <asp:DataPager runat="server" ID="DataPager" PagedControlID="ListViewProgrammers" PageSize="12">
                            <Fields>
                                <asp:NumericPagerField ButtonCount="10"
                                    CurrentPageLabelCssClass="paging-btn" NumericButtonCssClass="paging-btn"
                                    PreviousPageText="<--"
                                    NextPageText="-->" />
                            </Fields>
                        </asp:DataPager>
                    </div>
                </LayoutTemplate>

                <GroupTemplate>
                    <div class="companies-group">
					    <div class="container">
                            <div class="row">
                                <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
                            </div>
                        </div>
                    </div>
                </GroupTemplate>

                <ItemTemplate>
                    <div class="col-lg-3 doc-item">
				        <div class="company animated">
	                        <figure>
                                <a href="<%# string.Format("ProgrammerDetails.aspx?id={0}", Item.Id) %>">            
								    <img width="670" height="500" src="<%# Item.AvatarUrl %>" class="doc-img animate" alt="company"> 
                                </a>
							</figure>
						    <div class="text-content">
						        <h5><%# Item.FirstName + " " + Item.LastName %></h5>
						        <h5><small><i class="fa fa-star">Stars: </i> <%# Item.StarsCount %></small></h5>
						    </div>
						</div>
					</div>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>