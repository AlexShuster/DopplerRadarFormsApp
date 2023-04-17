using DopplerRadarFormsApp.ViewModels;
using DopplerRadarFormsApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DopplerRadarFormsApp.Commands
{
    internal class PitcherPageCommand : CommandBase
    {
        DataViewModel _dataViewModel;
        public override void Execute(object parameter)
        {
            var _pitcherPage = new PitcherView();
            _pitcherPage.BindingContext = new PitcherViewModel(_dataViewModel);
            Application.Current.MainPage.Navigation.PushAsync(_pitcherPage);
        }
        public PitcherPageCommand(DataViewModel dataViewModel)
        {
            _dataViewModel = dataViewModel;
        }
    }
}
