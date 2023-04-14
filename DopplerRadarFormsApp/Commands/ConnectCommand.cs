using DopplerRadarFormsApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DopplerRadarFormsApp.Commands
{
    internal class ConnectCommand : CommandBase
    {
        private BluetoothHandlerModel _handler;
        public override void Execute(object parameter)
        {
            
            _handler.RadarConnect();
        }
        public ConnectCommand(BluetoothHandlerModel Handler)
        {
            _handler = Handler;
        }
    }
}
