using Android.Hardware.Camera2;
using System;
using System.Collections.Generic;
using System.Text;

namespace DopplerRadarFormsApp.Models
{
    public class Pitch
    {
        public float speed;
        public float spin;

        public Pitch(float speed, float spin)
        {
            this.speed = speed;
            this.spin = spin;
        }
    }
}
