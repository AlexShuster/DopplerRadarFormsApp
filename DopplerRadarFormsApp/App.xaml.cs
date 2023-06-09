﻿using DopplerRadarFormsApp.Models;
using DopplerRadarFormsApp.Stores;
using DopplerRadarFormsApp.ViewModels;
using DopplerRadarFormsApp.Views;
using OxyPlot.Xamarin.Forms;
using OxyPlot;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DopplerRadarFormsApp
{
    public partial class App : Application
    {
        private readonly BluetoothHandlerModel _handler;
        public readonly NavigationStore _navigationStore;
        public App()
        {
            InitializeComponent();

            _handler = new BluetoothHandlerModel();

            MainPage = new NavigationPage(new MainPage())
            {
                BindingContext = new MainViewModel(_handler)
            };
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
