using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using WebFormsMvp;
using ProgrammersSpot.Business.MVP.Presenters;
using WebFormsMvp.Web;
using ProgrammersSpot.Business.MVP.ViewModels;
using ProgrammersSpot.Business.MVP.Views;
using ProgrammersSpot.Business.MVP.Args;

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