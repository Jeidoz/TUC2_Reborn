﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using TUC2_Reborn.Annotations;

namespace TUC2_Reborn.Models
{
    public class UserModel : INotifyPropertyChanged
    {
        private int _roleIndex;
        private string _login;
        private string _password;
        private string _firstName;
        private string _lastName;
        private string _fatherName;

        public int Id { get; set; }
        public int RoleIndex
        {
            get => _roleIndex;
            set
            {
                if (value == _roleIndex) return;
                _roleIndex = value;

                OnPropertyChanged(nameof(RoleIndex));
            }
        }
        public string Login
        {
            get => _login;
            set
            {
                if (value == _login) return;
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                if (value == _password) return;
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string FirstName
        {
            get => _firstName;
            set
            {
                if (value == _firstName) return;
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
                OnPropertyChanged(nameof(FullName));
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                if (value == _lastName) return;
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
                OnPropertyChanged(nameof(FullName));
            }
        }
        public string FatherName
        {
            get => _fatherName;
            set
            {
                if (value == _fatherName) return;
                _fatherName = value;
                OnPropertyChanged(nameof(FatherName));
                OnPropertyChanged(nameof(FullName));
            }
        }
        public string FullName => $"{LastName} {FirstName} {FatherName}";

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
