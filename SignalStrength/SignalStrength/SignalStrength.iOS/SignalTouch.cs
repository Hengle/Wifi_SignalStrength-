using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using SignalStrength.iOS;
using NetworkExtension;
using CoreTelephony;
using SystemConfiguration;
using CoreFoundation;
using System.Net;

[assembly: Dependency(typeof(SignalTouch))]
namespace SignalStrength.iOS
{
    public class SignalTouch : IWifiSignal
    {
        private static NetworkReachability _defaultRouteReachability;
        public static event EventHandler ReachabilityChanged;
        public static bool IsNetworkAvailable()
        {
            if (_defaultRouteReachability == null)
            {
                _defaultRouteReachability = new NetworkReachability(new IPAddress(0));
                _defaultRouteReachability.SetNotification(OnChange);
                _defaultRouteReachability.Schedule(CFRunLoop.Current, CFRunLoop.ModeDefault);
            }

            NetworkReachabilityFlags flags;

            return _defaultRouteReachability.TryGetFlags(out flags) &&
                IsReachableWithoutRequiringConnection(flags);
        }
        private static void OnChange(NetworkReachabilityFlags flags)
        {
            var h = ReachabilityChanged;
            if (h != null)
                h(null, EventArgs.Empty);
        }
        private static bool IsReachableWithoutRequiringConnection(NetworkReachabilityFlags flags)
        {
            // Is it reachable with the current network configuration?
            bool isReachable = (flags & NetworkReachabilityFlags.Reachable) != 0;

            // Do we need a connection to reach it?
            bool noConnectionRequired = (flags & NetworkReachabilityFlags.ConnectionRequired) == 0;

            // Since the network stack will automatically try to get the WAN up,
            // probe that
            if ((flags & NetworkReachabilityFlags.IsWWAN) != 0)
                noConnectionRequired = true;

            return isReachable && noConnectionRequired;
        }

        public int GetStrength()
        {
            if (IsNetworkAvailable())
            {
                return  4;
            }
            else
            {
                return 0;
            }
        }
    }
}