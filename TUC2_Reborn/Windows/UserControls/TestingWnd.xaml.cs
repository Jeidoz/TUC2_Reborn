using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
using System.Windows.Shapes;
using TUC2_Reborn.Models;
using TUC2_Reborn.TestingDataTypes;
using TUC2_Reborn.ViewModels;
using Path = System.IO.Path;

namespace TUC2_Reborn.Windows.UserControls
{
    /// <summary>
    /// Interaction logic for TestingWnd.xaml
    /// </summary>
    public partial class TestingWnd : Window
    {
        private readonly ChallengeModel _currentChallenge;
        private readonly List<TestModel> _controlTests;
        private readonly FileInfo _sourceFile;
        private readonly int _timeLimitPerTest; 
        private bool _isCompiled;
        private bool _isTestRunPassed;
        private int _currentTestNumber;
        private int _numberOfPassedTests;
        private int _numberOfFailedTests;

        public TestingActionViewModel Log { get; set; }

        public TestingWnd(ChallengeModel currentChallenge, string sourseFilePath)
        {
            Log = new TestingActionViewModel();

            AddNewAction("Ініціалізація змінних...");
            _sourceFile = new FileInfo(sourseFilePath);
            //TODO
            //Save timelimit into DB for Challenge
            _timeLimitPerTest = (int) TimeSpan.FromSeconds(3).TotalMilliseconds;
            _isCompiled = false;
            _isTestRunPassed = false;
            _currentTestNumber = 1;
            _numberOfPassedTests = 0;
            _numberOfFailedTests = 0;

            AddNewAction("Зчитування контрольних тестів...");
            _currentChallenge = currentChallenge;
            _controlTests = _currentChallenge.ControlTests;

            InitializeComponent();
            DataContext = Log;

            AddNewAction($"Підготовка до тестування завдання із назвою \"{_currentChallenge.Name}\" завершена.");
        }

        private void ChangeProgressBarStatus(double? newProgressValue = null, Brush newForeground = null)
        {
            App.Current.Dispatcher.Invoke(() => 
            {
                if (newProgressValue.HasValue)
                    TestingProgress.Value = newProgressValue.Value;
                if (newForeground != null)
                    TestingProgress.Foreground = newForeground;
            });
        }
        private TestingAction AddNewAction(string actionText)
        {
            TestingAction newAction = new TestingAction(actionText);
            App.Current.Dispatcher.Invoke(() =>
            {
                Log.Actions.Add(newAction);
            });
           
            return newAction;
        }
        private string GetCompilator(string extension)
        {
            switch (extension)
            {
                case ".c":
                case ".cpp":
                    return "g++";
                case ".pas":
                    return "fpc";
                default:
                    return null;
            }
        }
        private ProcessStartInfo PrepareCompilationProcessStartInfo(string extension)
        {
            string compilator = GetCompilator(extension);
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = compilator,
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };

            string sourcePath = _sourceFile.FullName;
            if (extension == ".cpp" || extension == ".c")
            {
                var exeName = sourcePath.Replace(extension, ".exe");
                startInfo.Arguments = $" \"{sourcePath}\" -o \"{exeName}\"";
            }
            else
                startInfo.Arguments = $"\"{sourcePath}\"";

            return startInfo;
        }
        private ProcessStartInfo PrepareExecutionProcessStartInfo()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                CreateNoWindow = true
            };

            if (_sourceFile.Extension == ".py")
            {
                startInfo.FileName = "python";
                startInfo.Arguments = $"\"{_sourceFile.FullName}\"";
            }
            else
            {
                var exeFileName = _sourceFile.FullName.Replace(_sourceFile.Extension, ".exe");
                startInfo.FileName = exeFileName;
            }

            return startInfo;
        }
        private Task<RuntimeResult> RunProcessAsync(ProcessStartInfo startInfo, string input)
        {
            return Task.Factory.StartNew(() =>
            {
                using (Process process = Process.Start(startInfo))
                {
                    process.StandardInput.WriteLine(input);
                    var processResult = true;
                    var firstEntry = true;
                    do
                    {
                        process.Refresh();
                        if (firstEntry)
                        {
                            firstEntry = false;
                            continue;
                        }
                        if (!process.HasExited)
                        {
                            processResult = false;
                            break;
                        }
                    } while (!process.WaitForExit(_timeLimitPerTest));

                    var errors = string.Empty;
                    if (processResult == false)
                    {
                        process.Kill();
                        errors = "Перевищений ліміт виконання (3 сек.).";
                    }
                    else
                        errors = process.StandardError.ReadToEnd();
                    var output = process.StandardOutput.ReadToEnd();


                    return new RuntimeResult(output, errors);
                }
            });
        }
        private void ChangeRowColor(TestingAction action, Brush color)
        {
            var dgIndex = Log.Actions.Count - 1;
            var lastRow = (DataGridRow)DataGridDetails.ItemContainerGenerator.ContainerFromIndex(dgIndex);
            if (lastRow == null)
            {
                DataGridDetails.UpdateLayout();
                DataGridDetails.ScrollIntoView(action);
                lastRow = (DataGridRow)DataGridDetails.ItemContainerGenerator.ContainerFromIndex(dgIndex);
            }
            lastRow.Foreground = color;
        }
        private CompilationResult Compile()
        {
            string extension = _sourceFile.Extension;
            if(extension == ".py")
                return new CompilationResult
                {
                    IsCompiled = true,
                    Errors = "Код написаний на Python не потребує компіляції!"
                };
            
            ProcessStartInfo startInfo = PrepareCompilationProcessStartInfo(extension);
            Process process = Process.Start(startInfo);
            string errors = process.StandardError.ReadToEnd();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            if (string.IsNullOrWhiteSpace(errors))
                errors = output;
            if (errors.Contains("compiled"))
                errors = string.Empty;

            return new CompilationResult(errors);
        }
        private void ProcessCompilation()
        {
            AddNewAction("Компіляція коду...");
            var compilationResult = Compile();
            if (compilationResult.IsCompiled)
            {
                ChangeProgressBarStatus(newProgressValue:10);
                AddNewAction("Компіляція завершена.");
                _isCompiled = true;
            }
            else
            {
                ChangeProgressBarStatus(newForeground:Brushes.MediumVioletRed);
                AddNewAction("Помилка компіляції!");
                AddNewAction($"Дані про помилку:\n{compilationResult.Errors}");
                _isCompiled = false;
            }
        }
        private async Task<RuntimeResult> Execute(string input)
        {
            if(!_isCompiled)
                return new RuntimeResult(string.Empty, "Неможливо знайти виконуючий файл.");

            var startInfo = PrepareExecutionProcessStartInfo();
            return await RunProcessAsync(startInfo, input);
        }
        private async Task ProcessTestRun()
        {
            AddNewAction("Пробний запуск виконуючого файлу..");
            var runtimeResult = await Execute(_controlTests[0].Input);

            if (runtimeResult.IsExecuted)
            {
                ChangeProgressBarStatus(newProgressValue:20);
                AddNewAction("Пробний запуск пройшов успішно.");
                _isTestRunPassed = true;
            }
            else
            {
                ChangeProgressBarStatus(newForeground:Brushes.MediumVioletRed);
                AddNewAction("Помилка виконання пробного запуску!");
                AddNewAction($"Дані про помилку:\n{runtimeResult.Errors}");
                _isTestRunPassed = false;
            }
        }
        private async Task<bool> IsTestPassed(TestModel test)
        {
            AddNewAction($"Запуск тесту №{_currentTestNumber} із {_controlTests.Count}");
            var runtimeResult = await Execute(test.Input);
            return runtimeResult.Output.StartsWith(test.Output);
        }
        private async Task ProcessTesting()
        {
            TestingAction action;
            double currentValue = 20;
            double multiplier = 80 / _controlTests.Count;
            foreach (var test in _controlTests)
            {
                if (await IsTestPassed(test))
                {
                    action = AddNewAction($"[Пройдений] Тест №{_currentTestNumber}");
                    ChangeRowColor(action, Brushes.Green);
                    _numberOfPassedTests++;
                }
                else
                {
                    action = AddNewAction($"[Провалений] Тест №{_currentTestNumber}");
                    ChangeRowColor(action, Brushes.Red);
                    _numberOfFailedTests++;
                }
                _currentTestNumber++;
                currentValue += multiplier;
                ChangeProgressBarStatus(newProgressValue: currentValue);
            }
            action = AddNewAction($"Провалено {_numberOfFailedTests} із {_controlTests.Count}");
            ChangeRowColor(action, (_numberOfFailedTests == 0 ? Brushes.DarkGreen : Brushes.Red));
            action = AddNewAction($"Пройдено {_numberOfPassedTests} із {_controlTests.Count}");
            ChangeRowColor(action, Brushes.DarkGreen);
            DataGridDetails.ScrollIntoView(action);
            ChangeProgressBarStatus(newProgressValue: 100);
        }

        private async void TestingWnd_OnContentRendered(object sender, EventArgs e)
        {
            TestingProgress.Value = 5;
            await Task.Factory.StartNew(() => ProcessCompilation());
            if (_isCompiled)
            {
                await ProcessTestRun();
                if (_isTestRunPassed)
                {
                    AddNewAction("Запуск тестування...");
                    await ProcessTesting();
                }
            }
        }
    }
}
