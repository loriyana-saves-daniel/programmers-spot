using ProgrammersSpot.Business.Models.UploadedImages;
using ProgrammersSpot.Business.Models.Users;
using System.Linq;

namespace ProgrammersSpot.Business.Services.Contracts
{
    public interface IUploadedImageService
    {
        IQueryable<UploadedImage> GetAllImages();

        IQueryable<UploadedImage> GetImagesWithTitle(string titleKeyword);

        UploadedImage GetImageById(int id);

        void UploadImage(string imgTitle, string thumbnailImgUrl, string originalImgUrl, RegularUser uploader);

        void LikeImage(int id);

        void DislikeImage(int id);

        void CommentImage(int imgId, string comment, string authorId);
    }
}
