using Bytes2you.Validation;
using ProgrammersSpot.Business.MVP.Args;
using ProgrammersSpot.Business.MVP.Views;
using ProgrammersSpot.Business.Services.Contracts;
using WebFormsMvp;

namespace ProgrammersSpot.Business.MVP.Presenters
{
    public class ProgrammerDetailsPresenter : Presenter<IProgrammerDetailsView>
    {
        private readonly IUserService userService;

        public ProgrammerDetailsPresenter(IProgrammerDetailsView view, IUserService userService) 
            : base(view)
        {
            Guard.WhenArgument(userService, "userService").IsNull().Throw();

            this.userService = userService;

            view.EventGetProgrammer += this.OnGetProgrammer;
            view.EventGetLoggedInUser += this.OnGetLoggedInUser;
            view.ProgrammerStarred += this.OnProgrammerStarred;
            view.ProgrammerUnstarred += this.OnProgrammerUnstarred;
        }

        private void OnProgrammerUnstarred(object sender, StarUserEventArgs e)
        {
            this.userService.UnstarUser(e.LoggedUserId, e.StarredUserId);
        }

        private void OnProgrammerStarred(object sender, StarUserEventArgs e)
        {
            this.userService.StarUser(e.LoggedUserId, e.StarredUserId);
        }

        private void OnGetProgrammer(object sender, FindUserEventArgs e)
        {
            this.View.Model.Programmer = this.userService.GetRegularUserById(e.Id);
        }

        private void OnGetLoggedInUser(object sender, FindUserEventArgs e)
        {
            this.View.Model.LoggedInUser = this.userService.GetRegularUserById(e.Id);
        }
    }
}
