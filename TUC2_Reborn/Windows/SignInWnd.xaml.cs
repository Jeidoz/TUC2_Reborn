using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TUC2_Reborn.Models;

namespace TUC2_Reborn.Windows
{
    /// <summary>
    /// Interaction logic for SignInWnd.xaml
    /// </summary>
    public partial class SignInWnd : UserControl
    {
        public SignInWnd()
        {
            InitializeComponent();
        }

        private void SignIn_OnClick(object sender, RoutedEventArgs e)
        {
            string login = Login.Text;
            string password = PasswordBox.Password;
            if (!GlobalHelper.Database.IsLoginExist(login))
            {
                string caption = "Невідомий логін";
                string message = $"Користувача із логіном: '{login}' не існує!";
                MessageBox.Show(caption, message, MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var dbUser = GlobalHelper.Database.GetUser(login);
            UserModel loginedUser = DataMapper.Map(dbUser);

            if (!GlobalHelper.Database.IsPasswordsSame(password, loginedUser.Password))
            {
                string caption = "Неправильний пароль";
                string message = "Введений пароль є неправильним";
                MessageBox.Show(caption, message, MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.LoginedUser = loginedUser;
            mainWindow.ShowLoginedUserControl();
        }

        private void Close_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
