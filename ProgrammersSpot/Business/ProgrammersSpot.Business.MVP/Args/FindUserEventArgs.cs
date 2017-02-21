using System;

namespace ProgrammersSpot.Business.MVP.Args
{
    public class FindUserEventArgs : EventArgs
    {
        public FindUserEventArgs(string id)
        {
            this.Id = id;
        }

        public string Id { get; private set; }
    }
}
