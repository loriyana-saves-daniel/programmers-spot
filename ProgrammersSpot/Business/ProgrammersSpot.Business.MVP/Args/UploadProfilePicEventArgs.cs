namespace ProgrammersSpot.Business.MVP.Args
{
    public class UploadProfilePicEventArgs : UploadImageEventArgs
    {
        public string UserRole { get; set; }
    }
}
