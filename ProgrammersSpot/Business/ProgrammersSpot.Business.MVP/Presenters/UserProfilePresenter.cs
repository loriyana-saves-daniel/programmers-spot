using Bytes2you.Validation;
using ProgrammersSpot.Business.MVP.Args;
using ProgrammersSpot.Business.MVP.Views;
using ProgrammersSpot.Business.Services.Contracts;
using System;
using WebFormsMvp;

namespace ProgrammersSpot.Business.MVP.Presenters
{
    public class UserProfilePresenter : Presenter<IUserProfileView>
    {
        private readonly IUserService userService;

        public UserProfilePresenter(IUserProfileView view, IUserService userService) : base(view)
        {
            Guard.WhenArgument(userService, "userService").IsNull().Throw();

            this.userService = userService;

            this.View.FindRegularUser += FindRegularUser;
            this.View.FindFirmUser += FindFirmUser;
        }

        private void FindFirmUser(object sender, FindUserEventArgs e)
        {
            if (String.IsNullOrEmpty(e.Id))
            {
                return;
            }
            else
            {
                var firmUser = this.userService.GetFirmUserById(e.Id);
                View.Model.FoundFirmUser = firmUser;
            }
        }

        private void FindRegularUser(object sender, FindUserEventArgs e)
        {
            if (String.IsNullOrEmpty(e.Id))
            {
                return;
            }
            else
            {
                var regularUser = this.userService.GetRegularUserById(e.Id);
                View.Model.FoundRegularUser = regularUser;
            }
        }
    }
}
