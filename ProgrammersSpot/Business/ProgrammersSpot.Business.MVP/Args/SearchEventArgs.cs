using System;

namespace ProgrammersSpot.Business.MVP.Args
{
    public class SearchEventArgs : EventArgs
    {
        public string QueryParams { get; private set; }

        public SearchEventArgs(string queryParams)
        {
            this.QueryParams = queryParams;
        }
    }
}
