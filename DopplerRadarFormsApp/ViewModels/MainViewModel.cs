using Android.Bluetooth;
using DopplerRadarFormsApp.Models;
using DopplerRadarFormsApp.Stores;
using Java.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DopplerRadarFormsApp.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        BluetoothHandlerModel _handler;
        Pitcher _pitcher;
        private readonly NavigationStore _navigationStore;
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public MainViewModel(BluetoothHandlerModel handler, Pitcher pitcher)
        {
            _handler = handler;
            _pitcher = pitcher;
            _navigationStore= new NavigationStore();
            _navigationStore.CurrentViewModel = new DataViewModel(_handler, _pitcher);
        }
    }
}
