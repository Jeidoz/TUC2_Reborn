using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using Microsoft.Win32;
using TUC2_Reborn.Models;
using TUC2_Reborn.ViewModels;
using TUC2_Reborn.Windows.UserControls;

namespace TUC2_Reborn.Views
{
    /// <summary>
    /// Interaction logic for ChallengeSolverView.xaml
    /// </summary>
    public partial class ChallengeSolverView : UserControl
    {
        private readonly string _currentDirectory;
        private int _selectedChallengeIndex;
        private string _selectedSourseFileDist;
        private ObservableCollection<ChallengeModel> _challenges;
        private ObservableCollection<ChallengeModel> _currentChallenge;

        public ChallengeSolverView()
        {
            _currentDirectory = Directory.GetCurrentDirectory();
            _selectedChallengeIndex = 0;
            _challenges = (new ChallengeViewModel()).Challenges;
            _currentChallenge = new ObservableCollection<ChallengeModel>();
            if (_challenges.Count > 0)
                _currentChallenge.Add(_challenges[0]);

            InitializeComponent();

            PreviusChallenge.IsEnabled = false;
            ChallengeNumber.Text = $"{_selectedChallengeIndex + 1} / {_challenges.Count}";
            ChallengeList.ItemsSource = _challenges;
            ItemsControl.ItemsSource = _currentChallenge;
            ChangeCurrentChallengeData();
        }

        private void ChangeCurrentChallengeData()
        {
            if (_selectedChallengeIndex < 0)
                return;

            _currentChallenge[0] = _challenges[_selectedChallengeIndex];
            ChallengeList.SelectedIndex = _selectedChallengeIndex;
        }
        private void ChangeCurrentChallengeData(int challengeIndex)
        {
            _selectedChallengeIndex = challengeIndex;
            ChangeCurrentChallengeData();
            ChallengeList.SelectedIndex = _selectedChallengeIndex;
        }
        private void ClearCodeFilesFolder()
        {
            var dir = Path.Combine(_currentDirectory, "Codes");

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            var dirInfo = new DirectoryInfo(dir);
            foreach (FileInfo file in dirInfo.EnumerateFiles())
            {
                file.Delete();
            }
        }

        private void ChallengeList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ChallengeList.SelectedIndex < 0)
                return;

            _selectedChallengeIndex = ChallengeList.SelectedIndex;

            ChangeCurrentChallengeData();
            ChallengeNumber.Text = $"{_selectedChallengeIndex + 1} / {_challenges.Count}";
            NextChallenge.IsEnabled = _selectedChallengeIndex + 1 != _challenges.Count;
            PreviusChallenge.IsEnabled = _selectedChallengeIndex != 0;
        }
        private void SelectCodeFile_Click(object sender, RoutedEventArgs e)
        {
            var openFileDlg = new OpenFileDialog
            {
                Filter = "Усі мови|*.pas; *.py; *.cpp|Pascal (*.pas)|*.pas|Python (*.py)|*.py|C++ (*.cpp)|*.cpp",
                Title = "Оберіть файл із кодом програми для тестування",
                Multiselect = false
            };
            var result = openFileDlg.ShowDialog();
            if (result.HasValue && result.Value)
            {
                var fileName = new FileInfo(openFileDlg.FileName);
                var codesDir = Path.Combine(_currentDirectory, "Codes");
                _selectedSourseFileDist = Path.Combine(codesDir, fileName.Name);
                ClearCodeFilesFolder();
                File.Copy(fileName.FullName, _selectedSourseFileDist);
                this.CodeFileName.Text = fileName.Name;
                this.CheckSolution.IsEnabled = true;
            }
        }
        private void CheckSolution_Click(object sender, RoutedEventArgs e)
        {
            var testingWnd = new TestingWnd(_currentChallenge[0], _selectedSourseFileDist);
            testingWnd.ShowDialog();
        }
        private void PreviusChallenge_Click(object sender, RoutedEventArgs e)
        {
            _selectedChallengeIndex--;
            this.ChallengeList.SelectedIndex = _selectedChallengeIndex;
        }
        private void NextChallenge_Click(object sender, RoutedEventArgs e)
        {
            _selectedChallengeIndex++;
            this.ChallengeList.SelectedIndex = _selectedChallengeIndex;
        }
    }
}
