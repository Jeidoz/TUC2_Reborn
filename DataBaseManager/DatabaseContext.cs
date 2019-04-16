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
            return Users.FindOne(Query.EQ("login", login));
        }
        public IEnumerable<User> GetAllUsers()
        {
            return Users.IncludeAll().FindAll();
        }
        public int CreateOrUpdateUser(int id, string login = null, string password = null,
            string firstName = null, string lastName = null, string fatherName = null)
        { 
            User oldUser = GetUser(id);

            oldUser.Login = login ?? oldUser.Login;
            oldUser.Password = password ?? oldUser.Password;
            oldUser.FirstName = firstName ?? oldUser.FirstName;
            oldUser.LastName = lastName ?? oldUser.LastName;
            oldUser.FatherName = fatherName ?? oldUser.FatherName;

            int userId = oldUser.Id;
            bool isUserExist = Users.Update(oldUser);
            if (!isUserExist)
            {
                userId = Users.Insert(oldUser);
            }

            return userId;
        }
       

        public void Dispose()
        {
            _databaseInstance.Dispose();
        }
    }
}
