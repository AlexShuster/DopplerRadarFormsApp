using Android.Hardware.Camera2;
using System;
using System.Collections.Generic;
using System.Text;

namespace DopplerRadarFormsApp.Models
{
    public enum PitchType
    {
        ChangeUp = 0,
        CurveBall = 1,
        Cutter = 2,
        FourSeamFastball = 3,
        Splitter = 4,
        Sinker = 5,
        Slider = 6
    }
    public class Pitch
    {
        public float speed;
        public float spin;
        public PitchIdentifier Identifier;
        public PitchType _pitchType;

        public Pitch(float speed, float spin)
        {
            this.speed = speed;
            this.spin = spin;
            Identifier = new PitchIdentifier();
        }
    }
}
