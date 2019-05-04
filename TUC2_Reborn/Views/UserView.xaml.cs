﻿using System;
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
            bool isNewUser = focusedUser.Id == 0;
            bool isLoginNotEmpty = !string.IsNullOrWhiteSpace(focusedUser.Login);
            bool isPasswordNotEmpty = !string.IsNullOrWhiteSpace(focusedUser.Password);
            bool isFirstNameNotEmpty = !string.IsNullOrWhiteSpace(focusedUser.FirstName);
            bool isLastNameNotEmpty = !string.IsNullOrWhiteSpace(focusedUser.LastName);
            bool isFatherNameNotEmpty = !string.IsNullOrWhiteSpace(focusedUser.FatherName);
            bool isRoleSelected = focusedUser.RoleIndex != (int)GlobalHelper.RoleIndex.NotSelected;
            if (isNewUser)
            {
                return isLoginNotEmpty
                       && isPasswordNotEmpty
                       && isFirstNameNotEmpty
                       && isLastNameNotEmpty
                       && isFatherNameNotEmpty
                       && isRoleSelected;
            }

            return isLoginNotEmpty
                && isFirstNameNotEmpty
                && isLastNameNotEmpty
                && isFatherNameNotEmpty
                && isRoleSelected;
        }
        private bool IsLoginedUserHasBeenSelected()
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            return _currentUser[0].Id == mainWindow.LoginedUser.Id;
        }
        private void Users_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Users.SelectedIndex < 0)
                return;

            _selectedUserIndex = Users.SelectedIndex;
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
                Password = "1",
                RoleIndex = (int)GlobalHelper.RoleIndex.NotSelected
            };
            _users.Add(newUser);
            int lastUserIndex = _users.Count - 1;
            ChangeCurrentUserData(lastUserIndex);
        }
        private void SaveUser_OnClick(object sender, RoutedEventArgs e)
        {
            bool isNewUser = _currentUser[0].Id == 0;
            var oldDbUser = GlobalHelper.Database.GetUser(_currentUser[0].Id);
            UserModel oldUser = new UserModel();
            if(oldDbUser != null)
                oldUser = DataMapper.Map(oldDbUser);

            if (!IsAllFieldsFilled())
            {
                MessageBox.Show("Заповніть усі поля!", "Пусті поля", MessageBoxButton.OK, MessageBoxImage.Warning);
                if(!isNewUser)
                    _currentUser[0] = oldUser;
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

                focusedUser.PasswordSalt = GlobalHelper.Database.GetSalt();
                focusedUser.PasswordHash = GlobalHelper.Database.GetSaltedHash(usr.Password, focusedUser.PasswordSalt);
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
                    _currentUser[0] = oldUser;
                    return;
                }

                var dbUser = GlobalHelper.Database.GetUser(usr.Id);
                focusedUser.PasswordSalt = dbUser.PasswordSalt;
                focusedUser.PasswordHash = string.IsNullOrWhiteSpace(usr.Password) ? dbUser.PasswordHash : GlobalHelper.Database.GetSaltedHash(usr.Password, focusedUser.PasswordSalt);

                GlobalHelper.Database.UpdateUser(focusedUser);

                message = $"Дані про користувача із іменем '{usr.FullName}'\n"
                          + $"(логін: '{usr.Login}') були успішно оновлені і збережені у базу даних.";
                caption = "Успішне оновлення даних користувача";
            }
            MessageBox.Show(message, caption, MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void RemoveUser_OnClick(object sender, RoutedEventArgs e)
        {
            if (IsLoginedUserHasBeenSelected())
            {
                MessageBox.Show("Неможливо видалити самого себе!", "Видалення самого себе?", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
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
