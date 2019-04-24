using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            InitializeTests();
            InitializeChallenges();
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
        private static void InitializeTests()
        {
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                int firstNumber = rand.Next(-100, 100);
                int secondNumber = rand.Next(-100, 100);
                int sum = firstNumber + secondNumber;

                Test newTest = new Test
                {
                    Input = $"{firstNumber} {secondNumber}",
                    Output = sum.ToString()
                };

                Context.AddTest(newTest);
            }
        }
        private static void InitializeChallenges()
        {
            Challenge firstChallenge = new Challenge()
            {
                Name = "Просте додавання",
                Description = "Вам потрібно написати програму додавання двох цілочисельних чисел.",
                Examples = Context.GetTests(1, 3).ToList(),
                ControlTests = Context.GetTests(1, 10).ToList()
            };
            Context.AddChallenge(firstChallenge);
        }
    }
}
