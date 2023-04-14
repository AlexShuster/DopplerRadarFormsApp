using DopplerRadarFormsApp.Commands;
using DopplerRadarFormsApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace DopplerRadarFormsApp.ViewModels
{
    internal class ScanViewModel : ViewModelBase
    {
        BluetoothHandlerModel _handler;
        public ICommand ScanCommand { get; }

        public ICommand StopCommand { get; }

        public ScanViewModel(BluetoothHandlerModel handler)
        {
            _handler = handler;
            ScanCommand = new ConnectCommand(_handler);
            StopCommand = new DisconnectCommand();
        }
    }
}
