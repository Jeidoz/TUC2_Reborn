using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using TUC2_Reborn.Models;
using TUC2_Reborn.ViewModels;

namespace TUC2_Reborn.Views
{
    /// <summary>
    /// Interaction logic for ChallengeView.xaml
    /// </summary>
    public partial class ChallengeView
    {
        private int _selectedChallengeIndex;
        private ObservableCollection<ChallengeModel> _challenges;
        private ObservableCollection<ChallengeModel> _currentChallenge;
        
        public ChallengeView()
        {
            _selectedChallengeIndex = default;
            _challenges = (new ChallengeViewModel()).Challenges;
            _currentChallenge = new ObservableCollection<ChallengeModel>();
            if (_challenges.Count > 0)
                _currentChallenge.Add(_challenges[0]);

            InitializeComponent();

            ChallengeNamesList.ItemsSource = _challenges;
            ItemsControl.ItemsSource = _currentChallenge;
        }

        private void ChangeCurrentChallengeData()
        {
            if (_selectedChallengeIndex < 0)
                return;

            _currentChallenge[0] = _challenges[_selectedChallengeIndex];
        }
        private void ChangeCurrentChallengeData(int challengeIndex)
        {
            _selectedChallengeIndex = challengeIndex;
            ChangeCurrentChallengeData();
            ChallengeNamesList.SelectedIndex = _selectedChallengeIndex;
        }
        private bool IsAllFieldsFilled()
        {
            ChallengeModel focusedChallenge = _currentChallenge[0];
            bool isNameNotEmpty = !string.IsNullOrWhiteSpace(focusedChallenge.Name);
            bool isDescriptionNotEmpty = !string.IsNullOrWhiteSpace(focusedChallenge.Description);
            bool isExamplesExist = focusedChallenge.Examples.Count > 0;

            return isNameNotEmpty
                && isDescriptionNotEmpty
                && isExamplesExist;
        }
        private void UpdateExampleTests()
        {
            foreach (var test in _currentChallenge[0].Examples)
            {
                var dbTest = GlobalHelper.Database.GetTest(test.Id);
                var mapperTest = DataMapper.Map(test);
                if (dbTest == null)
                    test.Id = GlobalHelper.Database.AddTest(mapperTest);
                    
                else
                    GlobalHelper.Database.UpdateTest(mapperTest);
            }
        }

        private void ChallengeNamesList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ChallengeNamesList.SelectedIndex < 0)
                return;

            _selectedChallengeIndex = ChallengeNamesList.SelectedIndex;

            ChangeCurrentChallengeData();
        }
        private void AddNewChallenge_OnClick(object sender, RoutedEventArgs e)
        {
            ChallengeModel newChallenge = new ChallengeModel
            {
                Name = "НовеЗавдання1",
                Description = default,
                Examples = new List<TestModel>(),
                ControlTests = new List<TestModel>()
            };
            _challenges.Add(newChallenge);
            int lastIndex = _challenges.Count - 1;
            ChangeCurrentChallengeData(lastIndex);
        }
        private void EditTests_OnClick(object sender, RoutedEventArgs e)
        {
            string challengeName = _currentChallenge[0].Name;
            if (string.IsNullOrWhiteSpace(challengeName))
            {
                MessageBox.Show("Введіть спочатку назву завдання!", "Відсутня назва завдання", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                return;
            }
            if (!GlobalHelper.Database.IsChallengeExist(challengeName))
            {
                MessageBox.Show("Збережіть завдання із початковими даними (Назва, Опис, Приклади тестів)", "Не створене завдання", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            TestView testWnd = new TestView(_currentChallenge[0]);
            testWnd.ShowDialog();
        }
        private void Save_OnClick(object sender, RoutedEventArgs e)
        {
            if (!IsAllFieldsFilled())
            {
                MessageBox.Show("Заповніть усі поля й додайте принаймні 1 приклад.", "Пусті поля", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var challenge = _currentChallenge[0];
            var focusedChallenge = DataMapper.Map(challenge);
            string message;
            string caption;
            if (focusedChallenge.Id == 0)
            {
                if (GlobalHelper.Database.IsChallengeExist(challenge.Name))
                {
                    MessageBox.Show($"Завдання із назвою '{challenge.Name}' уже існує в базі даних!", "Зайнята назва", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                UpdateExampleTests();
                int challendeId = GlobalHelper.Database.AddChallenge(DataMapper.Map(challenge));
                
                challenge.Id = challendeId;

                message = $"Завдання із назвою '{challenge.Name}' було успішно створене і збережене у базу даних.";
                caption = "Успішне збереження нового завдання";
            }
            else
            {
                string oldName = GlobalHelper.Database.GetChallenge(challenge.Id).Name;
                if (GlobalHelper.Database.IsLoginExistExcept(challenge.Name, oldName))
                {
                    MessageBox.Show($"Назва '{challenge.Name}' зайнята іншим завданням!", "Зайнята назва", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                UpdateExampleTests();
                GlobalHelper.Database.UpdateChallenge(DataMapper.Map(challenge));

                message = $"Дані про завдання із назвою '{challenge.Name}' були успішно оновлені і збережені у базу даних.";
                caption = "Успішне оновлення даних завдання";
            }
            MessageBox.Show(message, caption, MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void Remove_OnClick(object sender, RoutedEventArgs e)
        {
            ChallengeModel challenge = _currentChallenge[0];

            string message = $"Ви точно бажаєте видалити це завдання:\n"
                             + $"Назва: '{challenge.Name}'?";
            string caption = "Підтвердження операції видалення";
            var result = MessageBox.Show(message, caption, MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                if (GlobalHelper.Database.IsChallengeExist(challenge.Id))
                    GlobalHelper.Database.RemoveChallenge(challenge.Id);
                _challenges.Remove(challenge);
                ChangeCurrentChallengeData(_selectedChallengeIndex - 1);
            }
        }
    }
}
