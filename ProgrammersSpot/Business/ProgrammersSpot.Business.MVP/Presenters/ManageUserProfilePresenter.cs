using Bytes2you.Validation;
using ProgrammersSpot.Business.MVP.Args;
using ProgrammersSpot.Business.MVP.Views;
using ProgrammersSpot.Business.Services.Contracts;
using WebFormsMvp;

namespace ProgrammersSpot.Business.MVP.Presenters
{
    public class ManageUserProfilePresenter : Presenter<IManageUserProfileView>
    {
        private readonly IUserService userService;
        private readonly ISkillService skillService;
        private readonly IProjectService projectService;

        public ManageUserProfilePresenter(IManageUserProfileView view, ISkillService skillService,
            IProjectService projectService, IUserService userService) : base(view)
        {
            Guard.WhenArgument(userService, "userService").IsNull().Throw();
            Guard.WhenArgument(skillService, "skillService").IsNull().Throw();
            Guard.WhenArgument(projectService, "projectService").IsNull().Throw();

            this.userService = userService;
            this.skillService = skillService;
            this.projectService = projectService;

            this.View.AddSkill += AddSkill;
            this.View.AddProject += AddProject;
            this.View.UpdateUserInfo += UpdateUserInfo;
        }

        private void UpdateUserInfo(object sender, EditUserInfoEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(e.Age))
            {
                this.userService.UpdateRegularUserAge(e.UserId, int.Parse(e.Age));
            }

            if (!string.IsNullOrWhiteSpace(e.JobTitle))
            {
                this.userService.UpdateRegularUserJobTitle(e.UserId, e.JobTitle);
            }

            if (!string.IsNullOrWhiteSpace(e.FacebookProfile))
            {
                this.userService.UpdateRegularUserFacebookProfile(e.UserId, e.FacebookProfile);
            }

            if (!string.IsNullOrWhiteSpace(e.GitHubProfile))
            {
                this.userService.UpdateRegularUserGitHubProfile(e.UserId, e.GitHubProfile);
            }
        }

        private void AddSkill(object sender, ManageUserProfileEventArgs e)
        {
            var skill = this.skillService.CreateSkill(e.SkillName);

            this.userService.AddSkillToRegularUser(e.UserId, skill);
        }

        private void AddProject(object sender, ManageUserProfileEventArgs e)
        {
            var project = this.projectService.CreateProject(e.ProjectName, e.LinkToProject);

            this.userService.AddProjectToRegularUser(e.UserId, project);
        }
    }
}
