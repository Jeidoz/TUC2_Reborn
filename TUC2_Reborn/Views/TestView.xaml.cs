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
    /// Interaction logic for TestView.xaml
    /// </summary>
    public partial class TestView : Window
    {
        private ChallengeModel _currentChallenge;
        private TestViewModel _testViewModel;
        private bool _isAllTestsSelected;

        public bool IsAllTestsSelected
        {
            get => _isAllTestsSelected;
            set
            {
                if(value == _isAllTestsSelected) return;

                _isAllTestsSelected = value;
                SelectAll(_isAllTestsSelected);
            }
        }
        public TestView(ChallengeModel challenge)
        {
            _currentChallenge = challenge;
            _testViewModel = new TestViewModel(_currentChallenge.Id);
            _isAllTestsSelected = false;

            this.DataContext = _testViewModel;

            InitializeComponent();
        }

        private void SelectAll(bool select)
        {
            foreach (var test in _testViewModel.Tests)
            {
                test.IsSelected = select;
            }
        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
        private void RemoveSelected_OnClick(object sender, RoutedEventArgs e)
        {
            for (int i = _testViewModel.Tests.Count - 1; i >= 0; i--)
            {
                if (_testViewModel.Tests[i].IsSelected)
                {
                    _testViewModel.Tests.RemoveAt(i);
                }
            }
        }
        private void Save_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
