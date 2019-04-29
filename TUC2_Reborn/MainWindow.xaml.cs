using System.Windows;
using TUC2_Reborn.Models;
using TUC2_Reborn.Views;
using TUC2_Reborn.Windows;
using TUC2_Reborn.Windows.AdminControls;
using TUC2_Reborn.Windows.UserControls;

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
            LoginedUser = null;
            MainGrid.Children.Clear();
            MainGrid.Children.Add(new SignInWnd());
        }

        public void ShowLoginedUserControl()
        {
            MainGrid.Children.Clear();
            if (LoginedUser.RoleIndex == (int) GlobalHelper.RoleIndex.Teacher)
                MainGrid.Children.Add(new AdminTemplate());
            else
                MainGrid.Children.Add(new StudentInterface());
        }
    }
}
