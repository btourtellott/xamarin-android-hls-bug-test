using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HLSBugTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WebViewPage : ContentPage
    {
        public WebViewPage()
        {
            InitializeComponent();
            _ = Task.Run(PollDashes);
        }
        
        public async Task PollDashes()
        {
            try
            {
                for(int i = 0; i < 15; ++i)
                {
                    await Task.Delay(TimeSpan.FromSeconds(3));
                    try
                    {
                        var result = await AppNetworkEngine.Instance.Www.GetStringAsync("/");
                    }
                    catch (Exception ex)
                    {
                        Log.WriteLine(ex);
                    }

                    var i1 = i + 1;
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Label.Text = $"Completed {i1} background requests...";
                    });
                }
            }
            catch (Exception ex)
            {
                Log.WriteLine(ex);
            }
            
        }
    }
    
    class PollDashes
    {
      
    }
}

