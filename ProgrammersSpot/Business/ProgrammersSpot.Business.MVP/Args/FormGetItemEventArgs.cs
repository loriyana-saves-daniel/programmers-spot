using System;

namespace ProgrammersSpot.Business.MVP.Args
{
    public class FormGetItemEventArgs : EventArgs
    {
        public int Id { get; private set; }

        public FormGetItemEventArgs(int id)
        {
            this.Id = id;
        }
    }
}
