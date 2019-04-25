using System.Linq;
using System.Windows;
using TUC2_Reborn.Models;
using TUC2_Reborn.ViewModels;

namespace TUC2_Reborn.Views
{
    /// <summary>
    /// Interaction logic for TestView.xaml
    /// </summary>
    public partial class TestView
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
        private void UpdateTests()
        {
            foreach (var test in _testViewModel.Tests)
            {
                var dbTest = GlobalHelper.Database.GetTest(test.Id);
                var mapperTest = DataMapper.Map(test);
                if (dbTest == null)
                    test.Id = GlobalHelper.Database.AddTest(mapperTest);
                else
                    GlobalHelper.Database.UpdateTest(mapperTest);
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
                if (_testViewModel.Tests[i].IsSelected)
                    _testViewModel.Tests.RemoveAt(i);
        }
        private void Save_OnClick(object sender, RoutedEventArgs e)
        {
            var dbChallenge = GlobalHelper.Database.GetChallenge(_currentChallenge.Id);
            UpdateTests();
            dbChallenge.ControlTests = DataMapper.Map(_testViewModel.Tests).ToList();
            GlobalHelper.Database.UpdateChallenge(dbChallenge);

            MessageBox.Show("Тести були успішно збережені у базу даних", "Успішне збереження", MessageBoxButton.OK, MessageBoxImage.Information);
            DialogResult = true;
            Close();
        }
    }
}
