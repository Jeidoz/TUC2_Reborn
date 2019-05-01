using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUC2_Reborn.Models;

namespace TUC2_Reborn.ViewModels
{
    public class TestingActionViewModel
    {
        public ObservableCollection<TestingAction> Actions { get; set; }

        public TestingActionViewModel()
        {
            Actions = new ObservableCollection<TestingAction>();
        }
    }
}
