using DataBaseManager.Entities;
using DataBaseManager.Exceptions;
using LiteDB;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DataBaseManager
{
    public class DatabaseContext : IDisposable
    {
        private readonly string _connectionString;
        private readonly LiteDatabase _databaseInstance;
        private LiteCollection<Role> _roles;
        private LiteCollection<User> _users;

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
        public bool IsUserExist(int id)
        {
            return Users.FindById(id) != null;
        }
        public bool IsPasswordsSame(string comparingPassword, string userPassword)
        {
            //TODO 
            // Compare hashes of passwords in future
            return comparingPassword == userPassword;
        }

        public Role GetRole(int index)
        {
            return Roles.FindById(index);
        }
        public Role GetRole(string roleName)
        {
            return Roles.FindOne(Query.EQ("Name", roleName));
        }
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

        public void Dispose()
        {
            _databaseInstance.Dispose();
        }
    }
}
