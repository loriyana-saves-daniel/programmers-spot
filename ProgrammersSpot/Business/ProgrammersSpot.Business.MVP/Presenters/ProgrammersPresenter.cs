using Bytes2you.Validation;
using ProgrammersSpot.Business.MVP.Args;
using ProgrammersSpot.Business.MVP.Views;
using ProgrammersSpot.Business.Services.Contracts;
using System;
using System.Linq;
using WebFormsMvp;

namespace ProgrammersSpot.Business.MVP.Presenters
{
    public class ProgrammersPresenter : Presenter<IProgrammersView>
    {
        protected readonly IUserService userService;
        protected readonly ISkillService skillService;

        public ProgrammersPresenter(IProgrammersView view, IUserService userService, 
            ISkillService skillService) : base(view)
        {
            Guard.WhenArgument(userService, "userService").IsNull().Throw();
            Guard.WhenArgument(skillService, "skillService").IsNull().Throw();

            this.userService = userService;
            this.skillService = skillService;

            view.EventGetProgrammers += this.OnGetProgrammers;
            view.EventSearchProgrammers += this.OnSearchProgrammers;
        }

        private void OnSearchProgrammers(object sender, SearchEventArgs e)
        {
            var skill = this.skillService.GetSkillByName(e.QueryParams.ToLower());
            this.View.Model.Programmers = skill.Users.AsQueryable();
        }

        private void OnGetProgrammers(object sender, EventArgs e)
        {
            this.View.Model.Programmers = this.userService.GetAllRegularUsers();
        }
    }
}
