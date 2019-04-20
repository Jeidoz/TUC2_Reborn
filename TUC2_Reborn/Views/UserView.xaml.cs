using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using TUC2_Reborn.Models;
using TUC2_Reborn.ViewModels;

namespace TUC2_Reborn.Views
{
    /// <summary>
    /// Interaction logic for UserView.xaml
    /// </summary>
    public partial class UserView : UserControl
    {
        private int _selectedUserIndex;
        private readonly ObservableCollection<UserModel> _users;
        private readonly ObservableCollection<UserModel> _currentUser;

        public UserView()
        {
            _selectedUserIndex = 0;
            _users = (new UserViewModel()).Users;
            _currentUser = new ObservableCollection<UserModel> { _users[_selectedUserIndex] };

            InitializeComponent();

            Users.ItemsSource = _users;
            Users.SelectedIndex = _selectedUserIndex;


            ChangeCurrentUserData();
            ItemControl.ItemsSource = _currentUser;
        }

        private void ChangeCurrentUserData()
        {
            if (_selectedUserIndex == -1)
                return;

            _currentUser[0] = _users[_selectedUserIndex];
            Users.SelectedIndex = _selectedUserIndex;
        }
        private void ChangeCurrentUserData(int index)
        {
            _selectedUserIndex = index;
            ChangeCurrentUserData();
        }
        private bool IsAllFieldsFilled()
        {
            UserModel focusedUser = _currentUser[0];
            bool isLoginNotEmpty = !string.IsNullOrWhiteSpace(focusedUser.Login);
            bool isPasswordNotEmpty = !string.IsNullOrWhiteSpace(focusedUser.Password);
            bool isFirstNameNotEmpty = !string.IsNullOrWhiteSpace(focusedUser.FirstName);
            bool isLastNameNotEmpty = !string.IsNullOrWhiteSpace(focusedUser.LastName);
            bool isFatherNameNotEmpty = !string.IsNullOrWhiteSpace(focusedUser.FatherName);
            bool isRoleSelected = focusedUser.RoleIndex != (int)GlobalHelper.RoleIndex.NotSelected;

            return isLoginNotEmpty
                && isPasswordNotEmpty
                && isFirstNameNotEmpty
                && isLastNameNotEmpty
                && isFatherNameNotEmpty
                && isRoleSelected;
        }
        private void Users_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedUserIndex = Users.SelectedIndex;

            if (_selectedUserIndex == -1)
            {
                return;
                ////TO DO
                ////0 index in Collection
                //_selectedUserIndex = Math.Max(_users.Count - 1, 0);
            }

            ChangeCurrentUserData();
        }
        private void NewUser_OnClick(object sender, RoutedEventArgs e)
        {
            UserModel newUser = new UserModel()
            {
                Login = "НовийКористувач1",
                FirstName = default,
                LastName = default,
                FatherName = default,
                Password = default,
                RoleIndex = (int)GlobalHelper.RoleIndex.NotSelected
            };
            _users.Add(newUser);
            int lastUserIndex = _users.Count - 1;
            ChangeCurrentUserData(lastUserIndex);
        }
        private void SaveUser_OnClick(object sender, RoutedEventArgs e)
        {
            if (!IsAllFieldsFilled())
            {
                MessageBox.Show("Заповніть усі поля!", "Пусті поля", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var usr = _currentUser[0];
            var focusedUser = DataMapper.Map(usr);
            string message;
            string caption;
            if (focusedUser.Id == 0)
            {
                if (GlobalHelper.Database.IsLoginExist(usr.Login))
                {
                    MessageBox.Show($"Користувач із логіном '{usr.Login}' уже існує в базі даних!", "Існуючий логін", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                int userId = GlobalHelper.Database.AddUser(focusedUser);
                usr.Id = userId;

                message = $"Користувач із іменем '{usr.FullName}'\n"
                          + $"(логін: '{usr.Login}') був успішно створений і збережений у базу даних.";
                caption = "Успішне збереження нового користувача";
            }
            else
            {
                string oldLogin = GlobalHelper.Database.GetUser(usr.Id).Login;
                if (GlobalHelper.Database.IsLoginExistExcept(usr.Login, oldLogin))
                {
                    MessageBox.Show($"Логін '{usr.Login}' зайнятий іншим користувачем!", "Зайнятий логін", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                GlobalHelper.Database.UpdateUser(focusedUser);

                message = $"Дані про користувача із іменем '{usr.FullName}'\n"
                          + $"(логін: '{usr.Login}') були успішно оновлена і збережена у базу даних.";
                caption = "Успішне оновлення даних користувача";
            }
            MessageBox.Show(message, caption, MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void RemoveUser_OnClick(object sender, RoutedEventArgs e)
        {
            UserModel usr = _currentUser[0];

            string message = $"Ви точно бажаєте видалити цього користувача:\n"
                             + $"Повне ім'я: '{usr.FullName}'\nЛогін: '{usr.Login}'?";
            string caption = "Підтвердження операції видалення";
            var result = MessageBox.Show(message, caption, MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                if(GlobalHelper.Database.IsUserExist(usr.Id))
                    GlobalHelper.Database.RemoveUser(usr.Id);
                _users.Remove(usr);
                ChangeCurrentUserData(_selectedUserIndex - 1);
            }
        }
    }
}
