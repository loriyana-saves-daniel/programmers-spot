using Microsoft.AspNet.Identity;
using ProgrammersSpot.Business.MVP.Args;
using ProgrammersSpot.Business.MVP.Presenters;
using ProgrammersSpot.Business.MVP.ViewModels;
using ProgrammersSpot.Business.MVP.Views;
using System;
using System.Web.UI;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace ProgrammersSpot.WebClient.Account
{
    [PresenterBinding(typeof(UserPresenter))]
    public partial class Profile : MvpPage<UserViewModel>, IUserView
    {
        public event EventHandler<FindRegularUserEventArgs> FindRegularUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (this.User.IsInRole("User"))
                {
                    var eventArgs = new FindRegularUserEventArgs(this.User.Identity.GetUserId());
                    this.FindRegularUser(this, eventArgs);

                    if (string.IsNullOrEmpty(this.Model.FoundRegularUser.AvatarUrl))
                    {
                        this.Model.ProfileImage = "../Content/Images/profile.png";
                    }
                    else
                    {
                        this.Model.ProfileImage = this.Model.FoundRegularUser.AvatarUrl;
                    }
                }
            }
        }
    }
}