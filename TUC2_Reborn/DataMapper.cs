using System.Collections.Generic;
using System.Linq;
using DataBaseManager.Entities;
using TUC2_Reborn.Models;

namespace TUC2_Reborn
{
    public static class DataMapper
    {
        public static UserModel Map(User dbUser)
        {
            return new UserModel
            {
                Id = dbUser.Id,
                Login = dbUser.Login,
                Password = dbUser.Password,
                FirstName = dbUser.FirstName,
                LastName = dbUser.LastName,
                FatherName = dbUser.FatherName,
                RoleIndex = dbUser.Role.Id - 1
            };
        }
        public static User Map(UserModel uiUser)
        {
            return new User
            {
                Id = uiUser.Id,
                Role = GlobalHelper.Database.GetRole(uiUser.RoleIndex),
                Login = uiUser.Login,
                Password = uiUser.Password,
                FirstName = uiUser.FirstName,
                LastName = uiUser.LastName,
                FatherName = uiUser.FatherName
            };
        }

        public static TestModel Map(Test dbTest)
        {
            return new TestModel
            {
                Id = dbTest.Id,
                Output = dbTest.Output,
                Input = dbTest.Input,
                IsSelected = false
            };
        }
        public static Test Map(TestModel uiTest)
        {
            return new Test
            {
                Id =  uiTest.Id,
                Output = uiTest.Output,
                Input = uiTest.Input
            };
        }
        public static IEnumerable<TestModel> Map(IEnumerable<Test> dbTests)
        {
            return dbTests.Select(Map);
        }
        public static IEnumerable<Test> Map(IEnumerable<TestModel> uiTests)
        {
            return uiTests.Select(Map);
        }

        public static ChallengeModel Map(Challenge dbChallenge)
        {
            return new ChallengeModel
            {
                Id =  dbChallenge.Id,
                Name = dbChallenge.Name,
                Description = dbChallenge.Description,
                ControlTests = Map(dbChallenge.ControlTests).ToList(),
                Examples = Map(dbChallenge.Examples).ToList()
            };
        }
        public static Challenge Map(ChallengeModel uiChallenge)
        {
            return new Challenge
            {
                Id = uiChallenge.Id,
                Name =  uiChallenge.Name,
                Description = uiChallenge.Description,
                ControlTests = Map(uiChallenge.ControlTests).ToList(),
                Examples = Map(uiChallenge.Examples).ToList()
            };
        }
    }
}
