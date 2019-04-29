using System;
using System.Collections.Generic;
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
using TUC2_Reborn.Views;

namespace TUC2_Reborn.Windows.UserControls
{
    /// <summary>
    /// Interaction logic for StudentInterface.xaml
    /// </summary>
    public partial class StudentInterface : UserControl
    {
        public StudentInterface()
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
                case "Challenges":
                    activeControl = new ChallengeSolverView();
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
