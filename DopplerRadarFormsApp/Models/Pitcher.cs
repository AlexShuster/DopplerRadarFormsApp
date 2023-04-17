using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DopplerRadarFormsApp.Models
{
    public enum Handedness
    {
        Left = 0,
        Right = 1
    }

    public enum Experience
    {
        Age10 = 10,
        Age11 = 11,
        Age12 = 12,
        Age13 = 13,
        Age14 = 14,
        Age15 = 15,
        Age16 = 16,
        Age17 = 17,
        Age18 = 18,
        College = 19,
        Pro = 20
    }

    public class PitchDict
    {
        public Dictionary<string, Experience> ExperienceMap => new Dictionary<string, Experience>()
        {
            {"Age 10", Experience.Age10},
            { "Age 11", Experience.Age11 },
            { "Age 12", Experience.Age12 },
            { "Age 13", Experience.Age13 },
            { "Age 14", Experience.Age14 },
            { "Age 15", Experience.Age15 },
            { "Age 16", Experience.Age16 },
            { "Age 17", Experience.Age17 },
            { "Age 18", Experience.Age18 },
            { "College", Experience.College },
            { "Pro", Experience.Pro },
        };

        public Dictionary<string, PitchType> PitchMap => new Dictionary<string, PitchType>()
        {
            {"Change Up", PitchType.ChangeUp },
            {"Curve Ball", PitchType.CurveBall },
            {"Cutter", PitchType.Cutter },
            {"Four-Seam Fastball", PitchType.FourSeamFastball },
            {"Splitter", PitchType.Splitter },
            {"Sinker", PitchType.Sinker },
            {"Slider", PitchType.Slider }
        };
    }
        

    public class Pitcher
    {
        public string _name;
        public Handedness _handedness;
        public Experience _experience;
        public ObservableCollection<Pitch> Pitches;

        public Pitcher(string name, Handedness handedness, Experience experience)
        {
            _name = name;
            _handedness = handedness;
            _experience = experience;

            Pitches = new ObservableCollection<Pitch>();
        }
    }
}
