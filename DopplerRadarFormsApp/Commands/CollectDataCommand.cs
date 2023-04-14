using DopplerRadarFormsApp.Models;
using DopplerRadarFormsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DopplerRadarFormsApp.Commands
{
    public class CollectDataCommand : CommandBase
    {
        private BluetoothHandlerModel _handler;
        public Pitcher _pitcher;
        private DataViewModel _viewModel;

        public override void Execute(object parameter)
        {
            _pitcher.Pitches.Add(_handler.Read());
            _viewModel.PitchSpeed = Convert.ToInt32(_pitcher.Pitches.Last().speed);
            _viewModel.SpinRate = Convert.ToInt32(_pitcher.Pitches.Last().spin);
        }

        public CollectDataCommand(BluetoothHandlerModel handler, Pitcher pitcher, DataViewModel viewModel)
        {
            _handler = handler;
            _pitcher = pitcher;
            _viewModel = viewModel;
        }
    }
}
