using Microsoft.AspNet.Identity;

namespace ProgrammersSpot.Business.MVP.Args
{
    public class SocialLoginEventArgs : OwinCtxEventArgs
    {
        public string UserId { get; set; }

        public UserLoginInfo UserLoginInfo { get; set; }
    }
}
