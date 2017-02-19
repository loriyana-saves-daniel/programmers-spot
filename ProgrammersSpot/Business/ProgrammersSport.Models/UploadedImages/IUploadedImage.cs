using ProgrammersSport.Business.Models.UploadedImageComments;
using ProgrammersSpot.Business.Models.Users;
using System;
using System.Collections.Generic;

namespace ProgrammersSport.Business.Models.UploadedImages
{
    public interface IUploadedImage
    {
        int Id { get; set; }

        string Title { get; set; }

        DateTime DateUploaded { get; set; }

        bool IsDeleted { get; set; }

        string Src { get; set; }

        RegularUser Uploader { get; set; }

        ICollection<UploadedImageComment> Comments { get; set; }

        int LikesCount { get; set; }

        int DislikesCount { get; set; }
    }
}
