using System;

namespace ProgrammersSpot.Business.MVP.Args
{
    public class UserUploadImageEventArgs : EventArgs
    {
        public string ImgTitle { get; set; }

        public string ImgUrl { get; set; }

        public string UploaderId { get; set; }
    }
}
