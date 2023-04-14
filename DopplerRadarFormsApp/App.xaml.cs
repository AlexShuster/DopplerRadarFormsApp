using DopplerRadarFormsApp.Models;
using DopplerRadarFormsApp.Stores;
using DopplerRadarFormsApp.ViewModels;
using DopplerRadarFormsApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DopplerRadarFormsApp
{
    public partial class App : Application
    {
        private readonly BluetoothHandlerModel _handler;
        private readonly Pitcher _pitcher;
        public readonly NavigationStore _navigationStore;
        public App()
        {
            InitializeComponent();

            _handler = new BluetoothHandlerModel();
            _pitcher = new Pitcher();

            MainPage = new MainPage()
            {
                BindingContext = new MainViewModel(_handler, _pitcher)
            };

            _navigationStore = new NavigationStore();
            _navigationStore.CurrentViewModel = new ScanViewModel(_handler);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
