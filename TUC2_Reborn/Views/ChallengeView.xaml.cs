using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using TUC2_Reborn.ViewModels;

namespace TUC2_Reborn.Views
{
    /// <summary>
    /// Interaction logic for ChallengeView.xaml
    /// </summary>
    public partial class ChallengeView : UserControl
    {
        private ChallengeViewModel _challengeViewModel;
        private ObservableCollection<ChallengeModel> _currentChallenge;
        public ChallengeView()
        {
            _challengeViewModel = new ChallengeViewModel();
            _currentChallenge = new ObservableCollection<ChallengeModel>();
            if (_challengeViewModel.Challenges.Count > 0)
                _currentChallenge.Add(_challengeViewModel.Challenges[0]);

            this.DataContext = _challengeViewModel;

            InitializeComponent();

            this.ItemsControl.ItemsSource = _currentChallenge;
        }

        private void ChallengeNamesList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
        private void AddNewChallenge_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
        private void EditTests_OnClick(object sender, RoutedEventArgs e)
        {
            TestView testWnd = new TestView(_currentChallenge[0]);
            testWnd.ShowDialog();
        }
        private void Save_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
        private void Remove_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
