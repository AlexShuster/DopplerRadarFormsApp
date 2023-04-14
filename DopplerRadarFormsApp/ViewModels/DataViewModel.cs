using DopplerRadarFormsApp.Commands;
using DopplerRadarFormsApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace DopplerRadarFormsApp.ViewModels
{
    public class DataViewModel : ViewModelBase
    {
        private BluetoothHandlerModel _handler;
        private Pitcher _pitcher;

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
        public ICommand ConnectCommand { get; }

        public DataViewModel(BluetoothHandlerModel handler, Pitcher pitcher)
        {
            _handler = handler;
            _pitcher = pitcher;
            StartCommand = new CollectDataCommand(_handler, _pitcher, this);
            ConnectCommand = new ConnectCommand(_handler);
        }
    }
}
