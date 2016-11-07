namespace SocialNetwork.ConsoleClient
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Searcher;
    using SocialNetwork.ConsoleClient.Generator;
    using SocialNetwork.Data;
    using SocialNetwork.Data.Migrations;

    public class Startup
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SocialNetworkDbContext, Configuration>());

            Importer.Create(Console.Out).Import();

            DataSearcher.Search(new SocialNetworkService());
        }
    }
}
