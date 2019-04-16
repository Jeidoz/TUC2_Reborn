using System.IO;
using DataBaseManager;
using DataBaseManager.Entities;

namespace InitDatabase
{
    class Program
    {
        private const string DatabaseFileName = "test.db";
        static readonly DatabaseContext Context = new DatabaseContext(DatabaseFileName);

        static void Main(string[] args)
        {
            ClearDatabase();
            InitializeRoles();
            InitializeUsers();
        }

        private static void ClearDatabase()
        {
            var currentDir = Directory.GetCurrentDirectory();
            var filePath = Path.Combine(currentDir, DatabaseFileName);
            if (File.Exists(filePath))
                File.Delete(filePath);
        }
        private static void InitializeRoles()
        {
            Context.Roles.Insert(new Role
            {
                Name = "Викладач"
            });
            Context.Roles.Insert(new Role
            {
                Name = "Студент"
            });
        }
        private static void InitializeUsers()
        {
            Context.Users.Insert(new User
            {
                Role = Context.GetRole("Викладач"),
                Login = "teacher",
                Password = "12345",
                FirstName = "Олег",
                LastName = "Желюк",
                FatherName = "Миколайович"
            });
            Context.Users.Insert(new User
            {
                Role = Context.GetRole("Студент"),
                Login = "student",
                Password = "1",
                FirstName = "Станіслав",
                LastName = "Хаврук",
                FatherName = "Володимирович"
            });
        }
    }
}
