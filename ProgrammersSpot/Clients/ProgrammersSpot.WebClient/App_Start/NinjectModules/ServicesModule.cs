﻿using Ninject.Modules;
using Ninject.Extensions.Conventions;

namespace ProgrammersSpot.WebClient.App_Start.NinjectModules
{
    public class ServicesModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind(x => x.From("ProgrammersSpot.Business.Services").SelectAllClasses().BindDefaultInterface());
        }
    }
}