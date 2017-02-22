using Bytes2you.Validation;
using ProgrammersSpot.Business.MVP.Args;
using ProgrammersSpot.Business.MVP.Views;
using ProgrammersSpot.Business.Services.Contracts;
using WebFormsMvp;

namespace ProgrammersSpot.Business.MVP.Presenters
{
    public class FirmDetailsPresenter : Presenter<IFirmDetailsView>
    {
        private readonly IUserService userService;
        private readonly IFirmService firmService;

        public FirmDetailsPresenter(IFirmDetailsView view, IUserService userService,
            IFirmService firmService) : base(view)
        {
            Guard.WhenArgument(userService, "userService").IsNull().Throw();
            Guard.WhenArgument(firmService, "firmService").IsNull().Throw();

            this.userService = userService;
            this.firmService = firmService;

            view.EventGetFirm += this.OnGetFirm;
            view.EventGetLoggedInUser += this.OnGetLoggedInUser;
            view.FirmReviewed += this.OnFirmReviewed;
            view.FirmStarred += this.OnFirmStarred;
            view.FirmUnstarred += this.OnFirmUnstarred;
        }

        private void OnGetFirm(object sender, FindUserEventArgs e)
        {
            this.View.Model.Firm = this.firmService.GetFirmUserById(e.Id);
        }

        private void OnGetLoggedInUser(object sender, FindUserEventArgs e)
        {
            this.View.Model.LoggedInUser = this.userService.GetRegularUserById(e.Id);
        }

        private void OnFirmReviewed(object sender, FirmReviewEventArgs e)
        {
            this.firmService.MakeFirmReview(e.FirmId, e.Review, e.AuthorId);
        }

        private void OnFirmUnstarred(object sender, StarUserEventArgs e)
        {
            this.userService.UnstarFirm(e.LoggedUserId, e.StarredUserId);
        }

        private void OnFirmStarred(object sender, StarUserEventArgs e)
        {
            this.userService.StarFirm(e.LoggedUserId, e.StarredUserId);
        }
    }
}
