using Bytes2you.Validation;
using ProgrammersSpot.Business.Data.Contracts;
using ProgrammersSpot.Business.Models.UploadedImageComments;
using ProgrammersSpot.Business.Models.UploadedImages;
using ProgrammersSpot.Business.Models.Users;
using ProgrammersSpot.Business.Services.Contracts;
using System;
using System.Linq;

namespace ProgrammersSpot.Business.Services
{
    public class UploadedImageService : IUploadedImageService
    {
        private readonly IRepository<UploadedImage> repo;
        private readonly IUnitOfWork uow;

        public UploadedImageService(IRepository<UploadedImage> repo, IUnitOfWork uow)
        {
            Guard.WhenArgument(repo, "uploadedImageRepo").IsNull().Throw();
            Guard.WhenArgument(uow, "unitOfWork").IsNull().Throw();

            this.repo = repo;
            this.uow = uow;
        }

        public IQueryable<UploadedImage> GetAllImages()
        {
            return this.repo.All().Where(i => !i.IsDeleted).OrderBy(i => i.DateUploaded);
        }

        public IQueryable<UploadedImage> GetImagesWithTitle(string titleKeyword)
        {
            return this.repo.All().Where(i => !i.IsDeleted && i.Title.Contains(titleKeyword));
        }

        public UploadedImage GetImageById(int id)
        {
            return this.repo.GetById(id);
        }

        public void LikeImage(int id)
        {
            var image = this.repo.GetById(id);
            image.LikesCount++;
            using (var uow = this.uow)
            {
                this.repo.Update(image);
                uow.SaveChanges();
            }
        }

        public void DislikeImage(int id)
        {
            var image = this.repo.GetById(id);
            image.DislikesCount++;
            using (var uow = this.uow)
            {
                this.repo.Update(image);
                uow.SaveChanges();
            }
        }

        public void CommentImage(int imgId, string comment, string authorId)
        {
            var image = this.repo.GetById(imgId);
            image.Comments.Add(new UploadedImageComment() { AuthorId = authorId, Content = comment });
            using (var uow = this.uow)
            {
                this.repo.Update(image);
                uow.SaveChanges();
            }
        }

        public void UploadImage(string ImgTitle, string thumbnailImgUrl, string originalImgUrl, RegularUser uploader)
        {
            var image = new UploadedImage()
            {
                Title = ImgTitle,
                ThumbnailSrc = thumbnailImgUrl,
                OriginalSrc = originalImgUrl,
                DateUploaded = DateTime.Now,
                IsDeleted = false
            };

            using (var uow = this.uow)
            {
                uploader.UploadedImages.Add(image);
                uow.SaveChanges();
            }
        }
    }
}
