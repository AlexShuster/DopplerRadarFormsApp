using DopplerRadarFormsApp.Commands;
using DopplerRadarFormsApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace DopplerRadarFormsApp.ViewModels
{
    public class DataViewModel : ViewModelBase
    {
        public BluetoothHandlerModel _handler;
        public List<Pitcher> Pitchers;

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

        private string _pitcherName;
        public string PitcherName
        {
            get 
            { 
                return _pitcherName; 
            }
            set 
            { 
                _pitcherName = value;
                OnPropertyChanged(nameof(PitcherName));
            }   
        }

        private int _pitchSpeed;
        public int PitchSpeed
        {
            get
            {
                return _pitchSpeed;
            }
            set
            {
                _pitchSpeed = value;
                OnPropertyChanged(nameof(PitchSpeed));
            }
        }

        private int _spinRate;
        public int SpinRate
        {
            get
            {
                return _spinRate;
            }
            set
            {
                _spinRate = value;
                OnPropertyChanged(nameof(SpinRate));
            }
        }

        private string _pitchType;
        public string PitchType
        {
            get
            {
                return _pitchType;
            }
            set
            {
                _pitchType = value;
                OnPropertyChanged(nameof(PitchType));
            }
        }

        public ICommand StartCommand { get; }
        public ICommand AddCommand { get; }

        public DataViewModel(BluetoothHandlerModel handler)
        {
            _handler = handler;

            PitcherList = new ObservableCollection<string>();
            Pitchers = new List<Pitcher>();

            StartCommand = new CollectDataCommand(_handler, this);
            AddCommand = new PitcherPageCommand(this);
        }
    }
}
