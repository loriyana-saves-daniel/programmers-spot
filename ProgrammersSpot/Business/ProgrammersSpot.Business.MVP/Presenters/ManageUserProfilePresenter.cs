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
        private readonly IFirmService firmService;
        private readonly ISkillService skillService;
        private readonly IProjectService projectService;

        public ManageUserProfilePresenter(IManageUserProfileView view, IFirmService firmService,
            ISkillService skillService, IProjectService projectService, IUserService userService) : base(view)
        {
            Guard.WhenArgument(userService, "userService").IsNull().Throw();
            Guard.WhenArgument(firmService, "firmService").IsNull().Throw();
            Guard.WhenArgument(skillService, "skillService").IsNull().Throw();
            Guard.WhenArgument(projectService, "projectService").IsNull().Throw();

            this.userService = userService;
            this.firmService = firmService;
            this.skillService = skillService;
            this.projectService = projectService;

            this.View.AddSkill += AddSkill;
            this.View.AddProject += AddProject;
            this.View.UpdateUserInfo += UpdateUserInfo;
            this.View.UpdateFirmInfo += UpdateFirmInfo;
            this.View.UpdateUserAvatarUrl += OnUpdateUserAvatarUrl;
            this.View.UpdateFirmAvatarUrl += OnUpdateFirmAvatarUrl;
        }

        private void UpdateFirmInfo(object sender, EditFirmInfoEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(e.Address))
            {
                this.firmService.UpdateFirmUserAddress(e.FirmId, e.Address);
            }

            if (!string.IsNullOrWhiteSpace(e.EmployeesCount))
            {
                this.firmService.UpdateFirmUserEmployeesCount(e.FirmId, int.Parse(e.EmployeesCount));
            }

            if (!string.IsNullOrWhiteSpace(e.Website))
            {
                this.firmService.UpdateFirmUserWebsite(e.FirmId, e.Website);
            }
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

            if (this.skillService.GetSkillByName(e.SkillName) != null)
            {
                skill = this.skillService.GetSkillByName(e.SkillName);
            }

            this.userService.AddSkillToRegularUser(e.UserId, skill);
        }

        private void AddProject(object sender, ManageUserProfileEventArgs e)
        {
            var project = this.projectService.CreateProject(e.ProjectName, e.LinkToProject);

            this.userService.AddProjectToRegularUser(e.UserId, project);
        }

        private void OnUpdateUserAvatarUrl(object sender, UserUploadImageEventArgs e)
        {
            this.userService.UpdateRegularUserAvatarUrl(e.UploaderId, e.ImgUrl);
        }

        private void OnUpdateFirmAvatarUrl(object sender, UserUploadImageEventArgs e)
        {
            this.firmService.UpdateFirmUserAvatarUrl(e.UploaderId, e.ImgUrl);
        }
    }
}
