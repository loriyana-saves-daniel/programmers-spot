using ProgrammersSport.Business.Models.UploadedImages;
using System.Linq;

namespace ProgrammersSpot.Business.Services.Contracts
{
    public interface IUploadedImageService
    {
        IQueryable<UploadedImage> GetAllImages();

        IQueryable<UploadedImage> GetImagesWithTitle(string titleKeyword);

        UploadedImage GetImageById(int id);
    }
}
