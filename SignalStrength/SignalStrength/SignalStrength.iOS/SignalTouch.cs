using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using SignalStrength.iOS;
[assembly: Dependency(typeof(SignalTouch))]
namespace SignalStrength.iOS
{
    public class SignalTouch : IWifiSignal
    {
        public int GetStrength()
        {
            throw new NotImplementedException();
        }
    }
}