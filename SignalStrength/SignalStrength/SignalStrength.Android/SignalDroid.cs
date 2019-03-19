using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using SignalStrength.Droid;
using Android.Net.Wifi;
using Android.Net;

[assembly : Dependency(typeof(SignalDroid))]
namespace SignalStrength.Droid
{
    public class SignalDroid : IWifiSignal
    {

        public int GetStrength()
        {
            Context _context = Android.App.Application.Context;
            //Xamarin.Forms.Forms.Context
            //WifiManager wifiManager = (WifiManager)Forms.Context.GetSystemService(Context.WifiService);
            WifiManager wifiManager = (WifiManager)_context.GetSystemService(Context.WifiService);
            int numberOfLevels = 5;
            WifiInfo wifiInfo = wifiManager.ConnectionInfo;

            int level = WifiManager.CalculateSignalLevel(wifiInfo.Rssi, numberOfLevels);
            return level;
        }
    }
}