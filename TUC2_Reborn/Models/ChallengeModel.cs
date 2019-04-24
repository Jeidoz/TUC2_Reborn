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
    public class ChallengeModel
    {
        private string _name;
        private string _description;
        private List<TestModel> _examples;
        private List<TestModel> _controlTests;

        public int Id { get; set; }
        public string Name
        {
            get => _name;
            set
            {
                if (value == _name) return;
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Description
        {
            get => _description;
            set
            {
                if (value == _description) return;
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
        public List<TestModel> Examples
        {
            get => _examples;
            set
            {
                if (value == _examples) return;
                _examples = value;
                OnPropertyChanged(nameof(Examples));
            }
        }
        public List<TestModel> ControlTests
        {
            get => _controlTests;
            set
            {
                if (value == _controlTests) return;
                _controlTests = value;
                OnPropertyChanged(nameof(ControlTests));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
