using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TUC2_Reborn.Annotations;

namespace TUC2_Reborn.Models
{
    public class TestingAction
    {
        private string _action;

        public string Action
        {
            get => _action;
            set
            {
                if (value == _action) return;
                _action = value;
                OnPropertyChanged(nameof(Action));
            }
        }

        public TestingAction(string action)
        {
            _action = action;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
