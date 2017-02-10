using ProgrammersSpot.Business.Data;
using ProgrammersSpot.Business.Data.Migrations;
using System.Data.Entity;

namespace ProgramersSpot.Client.App_Start
{
    public class DbConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ProgrammersSpotDbContext, Configuration>());
            ProgrammersSpotDbContext.Create().Database.Initialize(true);
        }
    }
}