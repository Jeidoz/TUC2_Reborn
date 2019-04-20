using System.Windows;
using TUC2_Reborn.Models;
using TUC2_Reborn.Views;
using TUC2_Reborn.Windows;

namespace TUC2_Reborn
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public UserModel LoginedUser { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            ShowSignInWindow();
        }

        public void ShowSignInWindow()
        {
            MainGrid.Children.Clear();
            MainGrid.Children.Add(new SignInWnd());
        }

        public void ShowLoginedUserControl()
        {
            MainGrid.Children.Clear();
            if (LoginedUser.RoleIndex == (int)GlobalHelper.RoleIndex.Teacher)
            {
                MainGrid.Children.Add(new UserView());
            }
        }
    }
}
