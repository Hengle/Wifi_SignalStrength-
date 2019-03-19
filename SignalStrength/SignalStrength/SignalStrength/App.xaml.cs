﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SignalStrength
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            int signalCross = DependencyService.Get<IWifiSignal>().GetStrength();
            MainPage.DisplayAlert("Ok", signalCross.ToString(),"ok");
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
            int signalCross = DependencyService.Get<IWifiSignal>().GetStrength();
            MainPage.DisplayAlert("Ok", signalCross.ToString(), "ok");
        }
    }
}
