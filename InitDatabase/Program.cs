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
        private const string DatabaseFileName = "Tuc2.db";
        static readonly DatabaseContext Context = new DatabaseContext(DatabaseFileName, "0951431404Tuc2");

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
            byte[] adminUserSalt = Context.GetSalt();
            byte[] adminUserHashedPassword = Context.GetSaltedHash("123", adminUserSalt);
            Context.Users.Insert(new User
            {
                Role = Context.GetRole("Викладач"),
                Login = "sa",
                PasswordSalt = adminUserSalt,
                PasswordHash = adminUserHashedPassword,
                FirstName = "Олег",
                LastName = "Желюк",
                FatherName = "Миколайович"
            });

            byte[] studentUserSalt = Context.GetSalt();
            byte[] studentUserHashedPassword = Context.GetSaltedHash("1", studentUserSalt);
            Context.Users.Insert(new User
            {
                Role = Context.GetRole("Студент"),
                Login = "student",
                PasswordSalt = studentUserSalt,
                PasswordHash = studentUserHashedPassword,
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
                int firstNumber = rand.Next(short.MinValue, short.MaxValue);
                int secondNumber = rand.Next(short.MinValue, short.MaxValue);
                int sum = firstNumber + secondNumber;

                Test newTest = new Test
                {
                    Input = $"{firstNumber} {secondNumber}",
                    Output = sum.ToString()
                };

                Context.AddTest(newTest);
            }

            for (int i = 0; i < 10; i++)
            {
                int firstNumber = rand.Next(short.MinValue, short.MaxValue);
                int secondNumber = rand.Next(short.MinValue, short.MaxValue);
                int diff = firstNumber - secondNumber;

                Test newTest = new Test
                {
                    Input = $"{firstNumber} {secondNumber}",
                    Output = diff.ToString()
                };

                Context.AddTest(newTest);
            }
        }
        private static void InitializeChallenges()
        {
            Challenge firstChallenge = new Challenge()
            {
                Name = "Просте додавання",
                Description = "Вам потрібно написати програму для додавання двох цілочисельних чисел.",
                Examples = Context.GetTests(1, 3).ToList(),
                ControlTests = Context.GetTests(1, 10).ToList()
            };
            Context.AddChallenge(firstChallenge);

            Challenge secondChallenge = new Challenge
            {
                Name = "Просте віднімання",
                Description = "Вам потрібно написати програми для віднімання двох цілочисельних чисел.",
                Examples = Context.GetTests(11, 13).ToList(),
                ControlTests = Context.GetTests(11, 20).ToList()
            };
            Context.AddChallenge(secondChallenge);
        }
    }
}
