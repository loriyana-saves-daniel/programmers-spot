
using ProgrammersSport.Business.Models.UploadedImages;
using ProgrammersSpot.Business.Models.Users;

namespace ProgrammersSport.Business.Models.UploadedImageComments
{
    public interface IUploadedImageComment
    {
        int Id { get; set; }

        string Content { get; set; }

        bool IsDeleted { get; set; }
        
        RegularUser Author { get; set; }

        UploadedImage UploadedImage { get; set; }
    }
}
