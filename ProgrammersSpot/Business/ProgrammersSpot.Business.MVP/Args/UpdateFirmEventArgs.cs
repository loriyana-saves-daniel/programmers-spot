using ProgrammersSpot.Business.Models.Users;
using System;

namespace ProgrammersSpot.Business.MVP.Args
{
    public class UpdateFirmEventArgs : EventArgs
    {
        public FirmUser FirmToUpdate { get; set; }
    }
}
