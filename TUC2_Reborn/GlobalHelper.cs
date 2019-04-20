using DataBaseManager;

namespace TUC2_Reborn
{
    public static class GlobalHelper
    {
        public static DatabaseContext Database = new DatabaseContext("test.db");
        public const string TeacherRoleName = "Викладач";
        public const string StudentRoleName = "Студент";

        public enum RoleIndex
        {
            Teacher = 0,
            Student = 1,
            NotSelected = -1
        }
    }
}
