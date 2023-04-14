using DopplerRadarFormsApp.Commands;
using DopplerRadarFormsApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace DopplerRadarFormsApp.ViewModels
{
    public class PitcherViewModel : ViewModelBase
    {
        private ObservableCollection<Pitcher> _pitcherList;
        public ObservableCollection<Pitcher> PitcherList
        {
            get
            {
                return _pitcherList;
            }
            set
            {
                _pitcherList = value;
                OnPropertyChanged(nameof(PitcherList));
            }
        }

        private string _handedness;
        public string Handedness
        {
            get
            {
                return _handedness;
            }
            set
            {
                _handedness = value;
                OnPropertyChanged(nameof(Handedness));
            }
        }

        private string _experienceLevel;
        public string ExperienceLevel
        {
            get
            {
                return _experienceLevel;
            }
            set
            {
                _experienceLevel = value;
                OnPropertyChanged(nameof(ExperienceLevel));
            }
        }

        public ICommand AddCommand { get; }

        public PitcherViewModel()
        {
            AddCommand = new NewPitcherCommand();
        }

    }
}
