using DopplerRadarFormsApp.Models;
using DopplerRadarFormsApp.ViewModels;
using DopplerRadarFormsApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DopplerRadarFormsApp.Commands
{
    internal class NewPitcherCommand : CommandBase
    {
        private PitcherViewModel _pitcherViewModel;
        private DataViewModel _dataViewModel;

        public NewPitcherCommand(PitcherViewModel pitcherViewModel, DataViewModel dataViewModel)
        {
            _pitcherViewModel = pitcherViewModel;
            _dataViewModel = dataViewModel;
        }

        public override void Execute(object parameter)
        {
            PitchDict map = new PitchDict();
            Handedness hand;
            Experience xp;
            Enum.TryParse(_pitcherViewModel.SelectedHand, out hand);
            map.ExperienceMap.TryGetValue(_pitcherViewModel.SelectedXP, out xp);
            if (_pitcherViewModel.Name != null) 
            {
                _pitcherViewModel.Pitchers.Add(new Pitcher(_pitcherViewModel.Name, hand, xp));
                _pitcherViewModel.PitcherList.Add(_pitcherViewModel.Name);
                // Navigate to Data Page
                var _dataPage = new DataPage();
                _dataPage.BindingContext = _dataViewModel;
                _dataViewModel.PitcherList.Add(_pitcherViewModel.Name);
                _dataViewModel.Pitchers.Add(new Pitcher(_pitcherViewModel.Name, hand, xp));
                Application.Current.MainPage.Navigation.PushAsync(_dataPage);
            }


        }
    }
}
