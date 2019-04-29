using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUC2_Reborn.Models;

namespace TUC2_Reborn.ViewModels
{
    public class ChallengeViewModel
    {
        public ObservableCollection<ChallengeModel> Challenges { get; set; }

        public ChallengeViewModel()
        {
            InitializeChallenges();
        }

        private void InitializeChallenges()
        {
            var allDbChallenges = GlobalHelper.Database
                .GetAllChallenges()
                .ToList();

            Challenges = new ObservableCollection<ChallengeModel>();
            foreach (var dbChallenge in allDbChallenges)
            {
                Challenges.Add(DataMapper.Map(dbChallenge));
            }
        }
    }
}
