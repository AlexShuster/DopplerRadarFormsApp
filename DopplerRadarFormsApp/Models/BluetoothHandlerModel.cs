using Android.Bluetooth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DopplerRadarFormsApp.Models
{
    public class BluetoothHandlerModel
    {
        public static BluetoothAdapter Adapter => BluetoothAdapter.DefaultAdapter;

        public List<BluetoothDevice> deviceList = new List<BluetoothDevice>();

        public BluetoothSocket _socket;

        public BluetoothHandlerModel()
        {
            deviceList = Adapter.BondedDevices.ToList();
        }

        public void RadarConnect()
        {
            // Get Bonded Device (RadarGunBluetooth)
            var connectedDevice = (from bd in deviceList where bd.Name == "RadarGunBluetooth" select bd).FirstOrDefault();// Return bonded device

            connectedDevice.CreateBond();

            // Create and Connect Bluetooth Socket
            _socket = connectedDevice.CreateRfcommSocketToServiceRecord(Java.Util.UUID.FromString("00001101-0000-1000-8000-00805f9b34fb")); //the UUID of HC-05
            _socket.Connect();
        }

        public Pitch Read()
        {
            byte[] bytes = new byte[13];
            byte[] bytes2 = new byte[13];

            string bytesString;
            string bytesString2;

            string speed = "";
            string speed2 = "";
            string spinRate = "";
            string spinRate2 = "";

            float speedFinal = 9999;
            float spinRateFinal = 9999;

            bool isNewValue = true;

            // Read data from Bluetooth
            _socket.InputStream.Read(bytes, 0, 13);
            //_socket.InputStream.Read(bytes2, 0, 13);

            // 1. Convert to string
            bytesString = System.Text.Encoding.ASCII.GetString(bytes);
            //bytesString2 = System.Text.Encoding.ASCII.GetString(bytes2);

            // 2. Separate string into values using regex
            Regex speedSplitter, speedSplitter2, spinRateSplitter, spinRateSplitter2;
            Match speedMatch, speedMatch2, spinRateMatch, spinRateMatch2;


            if (bytesString.LastIndexOf(';') == 12) // aaaaa,bbbbbb;
            {
                // Regex Splitters
                speedSplitter = new Regex("(.*),");
                spinRateSplitter = new Regex(",(.*);");
                speedMatch = speedSplitter.Match(bytesString);
                spinRateMatch = spinRateSplitter.Match(bytesString);

                // Get first read variables
                speed = speedMatch.Groups[1].ToString();
                spinRate = spinRateMatch.Groups[1].ToString();

                // Get second read variables
                //speed2 = speedSplitter.Match(bytesString2).Groups[1].ToString();
                //spinRate2 = spinRateSplitter.Match(bytesString2).Groups[1].ToString();
            }
            else if (bytesString.LastIndexOf(';') > 7 && bytesString.LastIndexOf(';') < 12) // a,bbbbbb;aaaa
            {
                // Regex Splitters
                speedSplitter = new Regex(";(.*)");
                speedSplitter2 = new Regex("(.*),");
                spinRateSplitter = new Regex(",(.*);");
                speedMatch = speedSplitter.Match(bytesString);
                speedMatch2 = speedSplitter2.Match(bytesString);
                spinRateMatch = spinRateSplitter.Match(bytesString);

                // First Read variables
                speed = speedMatch.Groups[1].ToString() + speedMatch2.Groups[1].ToString();
                spinRate = spinRateMatch.Groups[1].ToString();

                // Second Read Variables
                //speed2 = speedSplitter.Match(bytesString2).Groups[1].ToString() + speedSplitter2.Match(bytesString2).Groups[1].ToString();
                //spinRate2 = spinRateSplitter.Match(bytesString2).Groups[1].ToString();
            }
            else if (bytesString.LastIndexOf(';') == 7) // ,bbbbbb;aaaaa
            {
                // Regex Splitters
                speedSplitter = new Regex(";(.*)");
                spinRateSplitter = new Regex(",(.*);");
                speedMatch = speedSplitter.Match(bytesString);
                spinRateMatch = spinRateSplitter.Match(bytesString);

                // First Read Variables
                speed = speedMatch.Groups[1].ToString();
                spinRate = spinRateMatch.Groups[1].ToString();

                // Second Read Variables
                //speed2 = speedSplitter.Match(bytesString2).Groups[1].ToString();
                //spinRate2 = spinRateSplitter.Match(bytesString2).Groups[1].ToString();
            }
            else if (bytesString.LastIndexOf(';') == 6) // bbbbbb;aaaaa,
            {
                // Regex Splitters
                speedSplitter = new Regex(";(.*)");
                spinRateSplitter = new Regex("(.*);");
                speedMatch = speedSplitter.Match(bytesString);
                spinRateMatch = spinRateSplitter.Match(bytesString);

                // First Read Variables
                speed = speedMatch.Groups[1].ToString();
                spinRate = spinRateMatch.Groups[1].ToString();

                // First Read Variables
                //speed2 = speedSplitter.Match(bytesString2).Groups[1].ToString();
                //spinRate2 = spinRateSplitter.Match(bytesString2).Groups[1].ToString();

            }
            else if (bytesString.LastIndexOf(';') > 2 && bytesString.LastIndexOf(';') < 6) // bbbbb;aaaaa,b
            {
                // Regex Splitters
                speedSplitter = new Regex(";(.*),");
                spinRateSplitter = new Regex(",(.*)");
                spinRateSplitter2 = new Regex("(.*);");
                speedMatch = speedSplitter.Match(bytesString);
                spinRateMatch = spinRateSplitter.Match(bytesString);
                spinRateMatch2 = spinRateSplitter2.Match(bytesString);

                // First Read Variables
                speed = speedMatch.Groups[1].ToString();
                spinRate = spinRateMatch.Groups[1].ToString() + spinRateMatch.Groups[1].ToString();

                // Second Read Variables
                //speed2 = speedSplitter.Match(bytesString2).Groups[1].ToString();
                //spinRate2 = spinRateSplitter.Match(bytesString2).Groups[1].ToString() + spinRateSplitter2.Match(bytesString2).Groups[1].ToString();

            }
            else if (bytesString.LastIndexOf(';') == 0) // ;aaaaa,bbbbbb
            {
                // Regex Splitters
                speedSplitter = new Regex(";(.*),");
                spinRateSplitter = new Regex(",(.*)");
                speedMatch = speedSplitter.Match(bytesString);
                spinRateMatch = spinRateSplitter.Match(bytesString);

                // First Read Variables
                speed = speedMatch.Groups[1].ToString();
                spinRate = spinRateMatch.Groups[1].ToString();

                // Second Read Variables
                //speed2 = speedSplitter.Match(bytesString2).Groups[1].ToString();
                //spinRate2 = spinRateSplitter.Match(bytesString2).Groups[1].ToString();
            }
            else
            {
                return null;
            }
            // MainActivity.GetInstance().UpdateAdapterStatus("Discovery Started...");
            // UpdateAdapter(new DataItem(speed, spinRate));


            // 3. Check if first few values of vel/spin are equal
            //string speedTest1 = speed.Substring(0, 3);
            //string speedTest2 = speed2.Substring(0, 3);
            //string spinTest1 = spinRate.Substring(0, 3);
            //string spinTest2 = spinRate2.Substring(0, 3);
            //if (speed.Substring(0, 3) == speed2.Substring(0, 3) && spinRate.Substring(0, 3) == spinRate2.Substring(0, 3))
            //{
            //    if (speed.Substring(0, 3) != speedFinal.ToString().Substring(0, 3) && spinRate.Substring(0, 2) != spinRateFinal.ToString().Substring(0, 2))
            //    {
            //        speedFinal = float.Parse(speed);
            //        spinRateFinal = float.Parse(spinRate);

            //        isNewValue = false;
            //    }
            //    else
            //    {
            //        isNewValue = true;
            //    }
            //}
            speedFinal = Convert.ToInt32(double.Parse(speed));
            spinRateFinal = Convert.ToInt32(double.Parse(spinRate));
            return new Pitch(speedFinal, spinRateFinal);
        }
    }
}
