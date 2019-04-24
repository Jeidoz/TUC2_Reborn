using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUC2_Reborn.Models;

namespace TUC2_Reborn.ViewModels
{
    public class TestViewModel
    {
        public ObservableCollection<TestModel> Tests { get; set; }

        public TestViewModel(int challengeId)
        {
            InitializeTests(challengeId);
        }

        private void InitializeTests(int challengeId)
        {
            var dbTests = GlobalHelper.Database
                .GetChallenge(challengeId)
                .ControlTests;

            Tests = new ObservableCollection<TestModel>();
            foreach (var dbTest in dbTests)
            {
                Tests.Add(DataMapper.Map(dbTest));
            }
        }
    }
}
