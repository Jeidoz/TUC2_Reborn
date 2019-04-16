using System.Collections.ObjectModel;
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
        private int _selectedUsedIndex;
        private readonly ObservableCollection<UserModel> _users;
        private readonly ObservableCollection<UserModel> _currentUser;

        public UserView()
        {
            _selectedUsedIndex = 0;
            _users = (new UserViewModel()).Users;
            _currentUser = new ObservableCollection<UserModel> { _users[_selectedUsedIndex] };

            InitializeComponent();

            ChangeActiveUserData();
            this.ItemControl.ItemsSource = _currentUser;
        }

        private void ChangeActiveUserData()
        {
            _currentUser[0] = _users[_selectedUsedIndex];
        }
        private void Users_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedUsedIndex = this.Users.SelectedIndex;

            if (_selectedUsedIndex == -1)
            {
                _selectedUsedIndex = 0;
            }

            ChangeActiveUserData();
        }
    }
}
