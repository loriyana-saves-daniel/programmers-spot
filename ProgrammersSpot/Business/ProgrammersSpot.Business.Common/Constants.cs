namespace ProgrammersSpot.Business.Common
{
    public class Constants
    {
        public const int NameMinLength = 2;
        public const int NameMaxLength = 20;

        public const int MinAge = 18;
        public const int MaxAge = 100;

        public const int MinSkillLength = 2;
        public const int MaxSkillLength = 20;

        public const int MinReviewLength = 10;
        public const int MaxReviewLength = 1000;

        public const int MinAddressLength = 4;
        public const int MaxAddressLength = 20;

        public const int MinProjectDescriptionLength = 10;
        public const int MaxProjectDescriptionLength = 1000;

        public const int MaxUploadedImageTitleLength = 50;

        public const int MinCommentLength = 5;
        public const int MaxCommentLength = 500;
        
        public const int ThumbnailImageSize = 500;
        public const int LargeImageSize = 700;

        public const int ThumbnailImageQualityPercentage = 80;
        public const int OriginalImageQualityPercentage = 100;

        public const string FailedUploadMessage = "Unfortunately, your uploading  has failed.\r\nPlease, try again later.";

        public const string ProgrammersSpotUrl = "https://www.programmersspot.com/";
        public const string ContentUploadedTakeABreakThumbnailsRelPath = "Content/Uploaded/TakeABreak/Thumbnails/";
        public const string ContentUploadedTakeABreakOriginalsRelPath = "Content/Uploaded/TakeABreak/Originals/";
        public const string ContentUploadedProfilesRelPath = "Content/Uploaded/Profiles/";
    }
}
