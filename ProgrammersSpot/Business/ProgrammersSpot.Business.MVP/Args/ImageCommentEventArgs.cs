using System;

namespace ProgrammersSpot.Business.MVP.Args
{
    public class ImageCommentEventArgs : EventArgs
    {
        public int ImageId { get; set; }

        public string Comment { get; set; }

        public string AuthorId { get; set; }
    }
}
