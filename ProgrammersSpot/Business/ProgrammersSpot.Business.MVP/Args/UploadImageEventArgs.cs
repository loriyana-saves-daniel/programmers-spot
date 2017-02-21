using System;
using System.Web;

namespace ProgrammersSpot.Business.MVP.Args
{
    public class UploadImageEventArgs : EventArgs
    {
        public string ImgTitle { get; set; }

        public HttpPostedFile Image;
        
        public string UploaderId { get; set; }
    }
}
