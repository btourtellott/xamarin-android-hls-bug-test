using System;
using Xamarin.Forms;

namespace HLSBugTest
{
    class Log
    {
        public static void WriteLine(object o)
        {
            System.Diagnostics.Debug.WriteLine(o);
        }
    }
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            // Username.Text = Preferences.Get("Username", "");
            // Password.Text = Preferences.Get("Password", "");
        }

        // const string loginURL = "/users/v3/providers/draftkings/logins?Format=json";
        // const string V4loginURL = "/users/v4/providers/draftkings/logins?Format=json";
        private async void Button_OnClicked(object sender, EventArgs e)
        {
            try
            {
                var result = await AppNetworkEngine.Instance.Www.GetStringAsync("/");
                // try
                // {
                //     var username = Username.Text;
                //     var password = Password.Text;
                //     var response = await AppNetworkEngine.Instance.Api.PostAsync<LoginResponse>(
                //         loginURL, new LoginRequest {Login = username, Password = password});
                //     Preferences.Set("Username", username);
                //     Preferences.Set("Password", password);
                // }
                // catch (Exception ex)
                // {
                //     Log.WriteLine(ex);
                // }
                await Navigation.PushModalAsync(new WebViewPage());
            }
            catch (Exception ex)
            {
                Log.WriteLine(ex);
            }
        }
    }

    
}