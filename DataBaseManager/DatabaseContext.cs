using DataBaseManager.Entities;
using DataBaseManager.Exceptions;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace DataBaseManager
{
    public class DatabaseContext : IDisposable
    {
        private readonly string _connectionString;
        private readonly LiteDatabase _databaseInstance;
        private LiteCollection<Role> _roles;
        private LiteCollection<User> _users;
        private LiteCollection<Test> _tests;
        private LiteCollection<Challenge> _challenges;

        public LiteCollection<User> Users
        {
            get => _users;
            set => _users = value ?? _databaseInstance.GetCollection<User>("users");
        }
        public LiteCollection<Role> Roles
        {
            get => _roles;
            set => _roles = value ?? _databaseInstance.GetCollection<Role>("roles");
        }
        public LiteCollection<Test> Tests
        {
            get => _tests;
            set => _tests = value ?? _databaseInstance.GetCollection<Test>("tests");
        }
        public LiteCollection<Challenge> Challenges
        {
            get => _challenges;
            set => _challenges = value ?? _databaseInstance.GetCollection<Challenge>("challenges");
        }

        public DatabaseContext(string dbFileName)
        {
            _connectionString = $"Filename={dbFileName}";
            _databaseInstance = new LiteDatabase(_connectionString);

            InitializeDatabaseCollections();
        }
        public DatabaseContext(string dbFileName, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new CannotCreateDbInstance("Database requires password.");
            }

            _connectionString = $"Filename={dbFileName};Password={password}";
            try
            {
                _databaseInstance = new LiteDatabase(_connectionString);
            }
            catch (Exception exception)
            {
                throw new CannotCreateDbInstance("Wrong database connection string (filename or password).", exception);
            }

            InitializeDatabaseCollections();
        }

        private void InitializeDatabaseCollections()
        {
            Roles = _databaseInstance.GetCollection<Role>("roles");
            Users = _databaseInstance.GetCollection<User>("users");
            Tests = _databaseInstance.GetCollection<Test>("tests");
            Challenges = _databaseInstance.GetCollection<Challenge>("challenges");
        }

        //Hashers
        public byte[] GetSalt(int maximumSaltLength = 32)
        {
            var salt = new byte[maximumSaltLength];
            using (var random = new RNGCryptoServiceProvider())
            {
                random.GetNonZeroBytes(salt);
            }

            return salt;
        }
        public byte[] GetSaltedHash(string originPassword, byte[] salt = null)
        {
            var algorithm = new SHA256Managed();
            if (salt == null)
                salt = GetSalt();
            byte[] plainText = Encoding.UTF8.GetBytes(originPassword);

            byte[] plainTextWithSaltBytes = new byte[plainText.Length + salt.Length];

            for (int i = 0; i < plainText.Length; i++)
                plainTextWithSaltBytes[i] = plainText[i];

            for (int i = 0; i < salt.Length; i++)
                plainTextWithSaltBytes[plainText.Length + i] = salt[i];

            return algorithm.ComputeHash(plainTextWithSaltBytes);
        }
        public bool CompareHash(string attemptedPassword, byte[] hash, byte[] salt)
        {
            string base64Hash = Convert.ToBase64String(hash);
            string base64AttemptedHash = Convert.ToBase64String(GetSaltedHash(attemptedPassword, salt));

            return base64Hash == base64AttemptedHash;
        }
        // CHECKERS
        public bool IsUserExist(int id)
        {
            return Users.FindById(id) != null;
        }
        public bool IsLoginExist(string loginForCheck)
        {
            return Users.Exists(Query.EQ("Login", loginForCheck));
        }
        public bool IsLoginExistExcept(string loginForCheck, string exceptionLogin)
        {
            var dbUser = GetUser(loginForCheck);
            if (dbUser == null)
                return false;
            return dbUser.Login != exceptionLogin;
        }
        public bool IsChallengeExist(int id)
        {
            return Challenges.FindById(id) != null;
        }
        public bool IsChallengeExist(string challengeNameForCheck)
        {
            return Challenges.Exists(Query.EQ("Name", challengeNameForCheck));
        }
        public bool IsChallengeExistExcept(string challengeNameForCheck, string exceptionChallengeName)
        {
            var dbChallenge = GetChallenge(challengeNameForCheck);
            if (dbChallenge == null)
                return false;
            return dbChallenge.Name != exceptionChallengeName;
        }
        // ROLES
        public Role GetRole(int index)
        {
            return Roles.FindById(index);
        }
        public Role GetRole(string roleName)
        {
            return Roles.FindOne(Query.EQ("Name", roleName));
        }
        // USERS
        public User GetUser(int id)
        {
            return Users.FindById(id);
        }
        public User GetUser(string login)
        {
            return Users.FindOne(Query.EQ("Login", login));
        }
        public IEnumerable<User> GetAllUsers()
        {
            return Users.IncludeAll().FindAll();
        }
        public int AddUser(User user)
        {
            return Users.Insert(user);
        }
        public int UpdateUser(User newUserData)
        {
            Users.Update(newUserData);
            return newUserData.Id;
        }
        public bool RemoveUser(int id)
        {
            return Users.Delete(id);
        }
        // TESTS
        public Test GetTest(int id)
        {
            return Tests.FindById(id);
        }
        public IEnumerable<Test> GetTests(int startId, int endId)
        {
            List<Test> tests = new List<Test>();
            for (int currentId = startId; currentId <= endId; currentId++)
            {
                Test dbTest = GetTest(currentId);
                tests.Add(dbTest);
            }

            return tests;
        }
        public int AddTest(Test test)
        {
            return Tests.Insert(test);
        }
        public bool UpdateTest(Test newTestData)
        {
            return Tests.Update(newTestData);
        }
        // CHALLENGES
        public Challenge GetChallenge(int id)
        {
            return Challenges.IncludeAll().FindById(id);
        }
        public Challenge GetChallenge(string challengeName)
        {
            return Challenges.IncludeAll().FindOne(Query.EQ("Name", challengeName));
        }
        public IEnumerable<Challenge> GetAllChallenges()
        {
            return Challenges.IncludeAll().FindAll();
        }
        public int AddChallenge(Challenge challenge)
        {
            return Challenges.Insert(challenge);
        }
        public int UpdateChallenge(Challenge newChallengeData)
        {
            
            Challenges.Update(newChallengeData);
            return newChallengeData.Id;
        }
        public bool RemoveChallenge(int id)
        {
            return Challenges.Delete(id);
        }
        public void Dispose()
        {
            _databaseInstance.Dispose();
        }
    }
}
