using JBMDatabase.Enum;
using JBMDatabase.UnitOfWork;

namespace DB_Test
{
    public static class GlobalTools
    {
        public static string ConnectionString = "Server=.;Database=JBMTestDBProj;User Id=james;Password=sa123456;Encrypt=True;TrustServerCertificate=True;";

        public static TestContext Context;
        public static IUoW UoW;

        public static void CreateUoW()
        {
            Context = DB_Settings.GetAndCreateDbContext<TestContext>(DatabaseOptions.SqlServer, ConnectionString);
            UoW = new UoW(Context);
        }

        public static IUoW GetUoW()
        {
            return UoW;
        }
    }
}
