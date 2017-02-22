using System;

namespace ProgrammersSpot.Business.MVP.Args
{
    public class StarUserEventArgs : EventArgs
    {
        public string LoggedUserId { get; set; }

        public string StarredUserId { get; set; }
    }
}
