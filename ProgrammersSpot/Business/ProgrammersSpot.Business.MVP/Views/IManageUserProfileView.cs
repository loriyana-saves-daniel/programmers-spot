using ProgrammersSpot.Business.MVP.Args;
using ProgrammersSpot.Business.MVP.ViewModels;
using System;
using WebFormsMvp;

namespace ProgrammersSpot.Business.MVP.Views
{
    public interface IManageUserProfileView : IView<ManageUserProfileViewModel>
    {
        event EventHandler<ManageUserProfileEventArgs> AddSkill;

        event EventHandler<ManageUserProfileEventArgs> AddProject;

        event EventHandler<EditUserInfoEventArgs> UpdateUserInfo;

        event EventHandler<EditFirmInfoEventArgs> UpdateFirmInfo;

        event EventHandler<UserUploadImageEventArgs> UpdateUserAvatarUrl;

        event EventHandler<UserUploadImageEventArgs> UpdateFirmAvatarUrl;
    }
}       
