using System.Data.Entity.Migrations;
using SistemaIndexador.Infra.CrossCutting.Logging.Data;

namespace SistemaIndexador.Infra.CrossCutting.Logging.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<LogginContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(LogginContext context)
        {

        }
    }
}
