﻿using ProgrammersSpot.Business.Models.Users;
using System.Collections.Generic;
using System.Linq;

namespace ProgrammersSpot.Business.Services.Contracts
{
    public interface IFirmService
    {
        IQueryable<FirmUser> GetAllFirmUsers();

        FirmUser GetFirmUserById(string id);

        IQueryable<FirmUser> GetFirmsWithName(string nameKeyword);

        void UpdateFirmUserAddress(string id, string address);

        void UpdateFirmUserEmployeesCount(string id, int employeesCount);

        void UpdateFirmUserWebsite(string id, string website);
    }
}