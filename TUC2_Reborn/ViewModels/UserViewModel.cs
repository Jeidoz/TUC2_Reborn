using System.Collections.ObjectModel;
using System.Linq;
using TUC2_Reborn.Models;

namespace TUC2_Reborn.ViewModels
{
    public class UserViewModel
    {
        public ObservableCollection<UserModel> Users { get; set; }
        public ObservableCollection<string> UserLogins { get; set; }
        public ObservableCollection<string> RoleNames { get; set; }

        public UserViewModel()
        {
            InitializeUsers();
            InitializeUsersLogins();
            InitializeRoleNames();
        }

        private void InitializeUsers()
        {
            var allDbUsers = GlobalHelper.Database.GetAllUsers().ToList();

            Users = new ObservableCollection<UserModel>();
            foreach (var dbUser in allDbUsers)
            {
                Users.Add(DataMapper.Map(dbUser));
            }
        }
        private void InitializeUsersLogins()
        {
            UserLogins = new ObservableCollection<string>();
            foreach (var user in Users)
            {
                UserLogins.Add(user.Login);
            }
        }
        private void InitializeRoleNames()
        {
            RoleNames = new ObservableCollection<string>
            {
                GlobalHelper.TeacherRoleName,
                GlobalHelper.StudentRoleName
            };
        }
    }
}
