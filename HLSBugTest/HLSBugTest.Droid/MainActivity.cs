using System;
using System.Net;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Xamarin.Android.Net;

namespace HLSBugTest.Droid
{
    [Activity(Label = "HLSBugTest", Theme = "@style/MainTheme", MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private readonly CookieContainer CookieContainer = new CookieContainer();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            var networkEngineConfiguration = new NetworkEngineConfiguration
            {
                ApiUri = new Uri("https://api.draftkings.com"),
                WwwUri = new Uri("https://www.draftkings.com"),
            };


            BasicApiClient.HandlerFactory = () => new AndroidClientHandler
            {
                UseCookies = true, 
                CookieContainer = CookieContainer
            };
            AppNetworkEngine.InstanceFactory = () => new BasicNetworkingEngine(networkEngineConfiguration);

            // new MyNetworkEngine(networkEngineConfiguration);
            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
    }
}