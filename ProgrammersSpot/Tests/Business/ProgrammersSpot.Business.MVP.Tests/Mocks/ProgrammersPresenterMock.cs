using ProgrammersSpot.Business.MVP.Presenters;
using ProgrammersSpot.Business.MVP.Views;
using ProgrammersSpot.Business.Services.Contracts;

namespace ProgrammersSpot.Business.MVP.Tests.Mocks
{
    public class ProgrammersPresenterMock : ProgrammersPresenter
    {
        public ProgrammersPresenterMock(IProgrammersView view, IUserService userService,
            ISkillService skillService) : base(view, userService, skillService)
        {
        }

        public IUserService UserService
        {
            get
            {
                return this.userService;
            }
        }

        public ISkillService SkillService
        {
            get
            {
                return this.skillService;
            }
        }
    }
}
