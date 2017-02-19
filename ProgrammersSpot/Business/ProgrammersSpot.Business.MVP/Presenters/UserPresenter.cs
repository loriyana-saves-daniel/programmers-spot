using Bytes2you.Validation;
using ProgrammersSpot.Business.MVP.Args;
using ProgrammersSpot.Business.MVP.Views;
using ProgrammersSpot.Business.Services.Contracts;
using System;
using WebFormsMvp;

namespace ProgrammersSpot.Business.MVP.Presenters
{
    public class UserPresenter : Presenter<IUserView>
    {
        private readonly IUserService userService;

        public UserPresenter(IUserView view, IUserService userService) : base(view)
        {
            Guard.WhenArgument(userService, "userService").IsNull().Throw();

            this.userService = userService;

            this.View.FindRegularUser += FindRegularUser;
        }

        private void FindRegularUser(object sender, FindRegularUserEventArgs e)
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

            //View.Model.ShowResults = true;
        }
    }
}
