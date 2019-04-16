using DataBaseManager;

namespace TUC2_Reborn
{
    public static class GlobalHelper
    {
        public static DatabaseContext Database = new DatabaseContext("test.db");
    }
}
