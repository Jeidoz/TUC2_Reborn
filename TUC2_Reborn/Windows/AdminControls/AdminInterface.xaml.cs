using System.Windows;
using System.Windows.Controls;
using TUC2_Reborn.Views;

namespace TUC2_Reborn.Windows.AdminControls
{
    /// <summary>
    /// Interaction logic for AdminTemplate.xaml
    /// </summary>
    public partial class AdminTemplate : UserControl
    {
        public AdminTemplate()
        {
            InitializeComponent();
        }

        private void OpenMenuButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.OpenMenuButton.Visibility = Visibility.Collapsed;
            this.CloseMenuButton.Visibility = Visibility.Visible;
        }
        private void CloseMenuButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.OpenMenuButton.Visibility = Visibility.Visible;
            this.CloseMenuButton.Visibility = Visibility.Collapsed;
        }
        private void MenuItems_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserControl activeControl = null;
            MainGrid.Children.Clear();
            ListViewItem selectedItem = ((ListView)sender).SelectedItem as ListViewItem;

            switch (selectedItem.Name)
            {
                case "Users":
                    activeControl = new UserView();
                    break;
                case "Challenges":
                    activeControl = new ChallengeView();
                    break;
                case "Logout":
                    var mainWnd = Window.GetWindow(this) as MainWindow;
                    mainWnd.ShowSignInWindow();
                    return;
            }

            MainGrid.Children.Add(activeControl);
        }
    }
}
