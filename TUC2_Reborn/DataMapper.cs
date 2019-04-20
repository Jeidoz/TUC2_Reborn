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
    }
}
