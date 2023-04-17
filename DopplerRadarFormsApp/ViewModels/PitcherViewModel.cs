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
        public List<Pitcher> Pitchers;
        private DataViewModel _dataViewModel;

        private ObservableCollection<string> _pitcherList;
        public ObservableCollection<string> PitcherList
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

        private string _selectedPitcher;
        public string SelectedPitcher
        {
            get
            {
                return _selectedPitcher;
            }
            set
            {
                _selectedPitcher = value;
                OnPropertyChanged(nameof(SelectedPitcher));
            }
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private ObservableCollection<string> _handedness;
        public ObservableCollection<string> Handedness
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

        private string _selectedHand = "Right";
        public string SelectedHand
        {
            get
            {
                return _selectedHand;
            }
            set
            {
                _selectedHand = value;
                OnPropertyChanged(nameof(SelectedHand));
            }
        }



        private ObservableCollection<string> _experienceLevel;
        public ObservableCollection<string> ExperienceLevel
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

        private string _selectedXP = "College";
        public string SelectedXP
        {
            get
            {
                return _selectedXP;
            }
            set
            {
                _selectedXP = value;
                OnPropertyChanged(nameof(SelectedXP));
            }
        }


        public ICommand AddCommand { get; }

        public PitcherViewModel(DataViewModel dataViewModel)
        {
            _dataViewModel = dataViewModel;

            PitcherList = new ObservableCollection<string>();
            Pitchers = new List<Pitcher>();

            Handedness = new ObservableCollection<string>();
            Handedness.Add("Left");
            Handedness.Add("Right");

            ExperienceLevel = new ObservableCollection<string>();
            ExperienceLevel.Add("Age 10");
            ExperienceLevel.Add("Age 11");
            ExperienceLevel.Add("Age 12");
            ExperienceLevel.Add("Age 13");
            ExperienceLevel.Add("Age 14");
            ExperienceLevel.Add("Age 15");
            ExperienceLevel.Add("Age 16");
            ExperienceLevel.Add("Age 17");
            ExperienceLevel.Add("Age 18");
            ExperienceLevel.Add("College");
            ExperienceLevel.Add("Pro");

            AddCommand = new NewPitcherCommand(this, _dataViewModel);

        }

    }
}
