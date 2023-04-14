using DopplerRadarFormsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DopplerRadarFormsApp.Stores
{
    public class NavigationStore
    {
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
            }
        }
    }
}
