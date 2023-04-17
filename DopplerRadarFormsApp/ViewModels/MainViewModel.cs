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
        private readonly NavigationStore _navigationStore;
        public ViewModelBase CurrentViewModel { get; }

        public MainViewModel(BluetoothHandlerModel handler)
        {
            _handler = handler;
            CurrentViewModel = new ScanViewModel(_handler);
        }
    }
}
