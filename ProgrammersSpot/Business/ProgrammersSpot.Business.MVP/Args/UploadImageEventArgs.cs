using System;
using System.IO;
using System.Web;

namespace ProgrammersSpot.Business.MVP.Args
{
    public class UploadImageEventArgs : EventArgs
    {
        public string ImgTitle { get; set; }

        public int ContentLength { get; set; }

        public string FileName { get; set; }

        public Stream InputStream { get; set; }
        
        public string UploaderId { get; set; }
    }
}
