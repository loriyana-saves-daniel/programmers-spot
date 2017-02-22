using System;

namespace ProgrammersSpot.Business.MVP.Args
{
    public class StarProgrammerEventArgs : EventArgs
    {
        public string LoggedUserId { get; set; }

        public string StarredUserId { get; set; }
    }
}
