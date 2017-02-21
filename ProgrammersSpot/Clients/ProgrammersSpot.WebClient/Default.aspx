<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProgrammersSpot.WebClient._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Banner -->
			<section id="banner">
				<i class="icon fa-group"></i>
				<h1>ProgrammerSSpot</h1>
				<p>Find your place or just let it find you</p>
				<ul class="actions">
                    <li>
                        <asp:Button runat="server" CssClass="button big special" PostBackUrl="~/About.aspx" Text="Learn More" />
                    </li>                 
				</ul>
			</section>

		<!-- One -->
			<section id="one" class="wrapper style1">
				<div class="inner">
					<article class="feature left">
						<span class="image"><img src="Content/Images/Home/developers.jpg" alt="" /></span>
						<div class="content">
							<h2>Discover software companies</h2>
							<p>Check out firms rating and programmers' opinions and find the most suitable company for you.</p>
							<ul class="actions">
								<li>
                                    <asp:Button runat="server" CssClass="button alt" PostBackUrl="~/Companies/" Text="Discover" />
								</li>
							</ul>
						</div>
					</article>
					<article class="feature right">
						<span class="image"><img src="Content/Images/Home/developer.jpg" alt="" /></span>
						<div class="content">
							<h2>The best programmers are here</h2>
							<p>Go through their profiles, dicover their projects and skills and make connections or just get inspired.</p>
							<ul class="actions">
								<li>
									<asp:Button runat="server" CssClass="button alt" PostBackUrl="~/Programmers/" Text="Discover" />
								</li>
							</ul>
						</div>
					</article>
				</div>
			</section>

		<!-- Three -->
			<section id="three" class="wrapper style3 special">
				<div class="inner">
					<header class="major narrow	">
						<h2>Take a break</h2>
						<p>Check out our fun section and post pictures yourself</p>
					</header>
					<ul class="actions">
						<li><asp:Button runat="server" CssClass="button big alt" PostBackUrl="~/TakeABreak/Default.aspx" Text="Discover" /></li>
					</ul>
				</div>
			</section>

		<!-- Four -->
			<section id="four" class="wrapper style2 special">
				<div class="inner">
					<header class="major narrow">
						<h2>Get in touch</h2>
						<p>We are always open for new ideas</p>
					</header>
						<div class="container 75%">
							<div class="row uniform 50%">
								<div class="6u 12u$(xsmall)">
									<input name="name" placeholder="Name" type="text" />
								</div>
								<div class="6u$ 12u$(xsmall)">
									<input name="email" placeholder="Email" type="email" />
								</div>
								<div class="12u$">
									<textarea name="message" placeholder="Message" rows="4"></textarea>
								</div>
							</div>
						</div>
						<ul class="actions">
							<li><input type="submit" class="special" value="Submit" /></li>
							<li><input type="reset" class="alt" value="Reset" /></li>
						</ul>
				</div>
			</section>
</asp:Content>
