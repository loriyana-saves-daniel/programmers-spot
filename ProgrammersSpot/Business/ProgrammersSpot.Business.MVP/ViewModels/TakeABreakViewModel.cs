using ProgrammersSpot.Business.Models.UploadedImages;
using System.Linq;

namespace ProgrammersSpot.Business.MVP.ViewModels
{
    public class TakeABreakViewModel
    {
        public IQueryable<UploadedImage> UploadedImages { get; set; }
    }
}
