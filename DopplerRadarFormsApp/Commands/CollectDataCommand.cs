using Android.OS;
using DopplerRadarFormsApp.Models;
using DopplerRadarFormsApp.ViewModels;
using OxyPlot;
using OxyPlot.Series;
using Syncfusion.SfChart.XForms;
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
            var currentPitcher = _viewModel.Pitchers.FirstOrDefault(o => o._name == _viewModel.PitcherName);
            if (currentPitcher != null)
            {
                _pitcher = currentPitcher;
            }

            var pitch = _handler.Read();
            if (pitch != null)
            {
                _viewModel.PitchSpeed = Convert.ToInt32(pitch.speed);
                _viewModel.SpinRate = Convert.ToInt32(pitch.spin);
                if (_pitcher != null)
                {
                    _pitcher.Pitches.Add(pitch);
                    PitchDict pitchDict = new PitchDict();
                    int pitchInt = pitch.Identifier.predict_experience_seven_pitch(Convert.ToDouble(_pitcher._handedness), pitch.speed, pitch.spin, Convert.ToInt32(_pitcher._experience));

                    pitch._pitchType = (PitchType)Enum.ToObject(typeof(PitchType), pitchInt);

                    _viewModel.PitchType = pitch._pitchType.ToString();

                    // Display on Chart
                    _viewModel.SpeedData.Add(new ChartDataPoint(_viewModel.SpeedData.Count, pitch.speed));
                    _viewModel.SpinData.Add(new ChartDataPoint(_viewModel.SpinData.Count, pitch.spin));

                }
            }
        }

        public CollectDataCommand(BluetoothHandlerModel handler, DataViewModel viewModel)
        {
            _handler = handler;
            _viewModel = viewModel;
        }
    }
}
