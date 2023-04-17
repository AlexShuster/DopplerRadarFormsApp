using DopplerRadarFormsApp.Models;
using DopplerRadarFormsApp.ViewModels;
using DopplerRadarFormsApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DopplerRadarFormsApp.Commands
{
    internal class ConnectCommand : CommandBase
    {
        private BluetoothHandlerModel _handler;
        public override void Execute(object parameter)
        {
            // Connect to HC-05
            try
            {
                _handler.RadarConnect();
                // Navigate to Data Page
                var _dataPage = new DataPage();
                _dataPage.BindingContext = new DataViewModel(_handler);
                Application.Current.MainPage.Navigation.PushAsync(_dataPage);
            }
            catch
            {

            }
            

            
        }
        public ConnectCommand(BluetoothHandlerModel Handler)
        {
            _handler = Handler;
        }
    }
}
