using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DopplerRadarFormsApp.Models
{
    public enum Handedness
    {
        Left,
        Right
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
    public class Pitcher
    {
        public string _name;
        public Handedness _handedness;
        public Experience _experience;
        public ObservableCollection<Pitch> Pitches;

        public Pitcher()
        {
            Pitches = new ObservableCollection<Pitch>();
        }
    }
}
