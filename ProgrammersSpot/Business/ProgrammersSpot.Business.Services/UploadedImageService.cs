using ProgrammersSpot.Business.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using ProgrammersSport.Business.Models.UploadedImages;
using ProgrammersSpot.Business.Data.Contracts;
using Bytes2you.Validation;

namespace ProgrammersSpot.Business.Services
{
    public class UploadedImageService : IUploadedImageService
    {
        private readonly IRepository<UploadedImage> repo;

        public UploadedImageService(IRepository<UploadedImage> repo)
        {
            Guard.WhenArgument(repo, "uploadedImageRepo").IsNull().Throw();

            this.repo = repo;
        }

        public IQueryable<UploadedImage> GetAllImages()
        {
            return this.repo.All().OrderBy(i => i.DateUploaded);
        }

        public IQueryable<UploadedImage> GetImagesWithTitle(string titleKeyword)
        {
            return this.repo.All().Where(i => i.Title.Contains(titleKeyword));
        }

        public UploadedImage GetImageById(int id)
        {
            return this.repo.GetById(id);
        }
    }
}
