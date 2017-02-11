using ProgrammersSpot.Business.Data;
using ProgrammersSpot.Business.Data.Migrations;
using System.Data.Entity;

namespace ProgrammersSpot.WebClient.App_Start
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