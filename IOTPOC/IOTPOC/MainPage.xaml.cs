using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using IOTPOC.Model;
using IOTPOC.Helper;
using Newtonsoft.Json;

namespace IOTPOC
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            try
            {
                Temperature temperature = GetTemperature();
                CurrTemp.Text = temperature.Temp == null ? "0°C" : temperature.Temp + "°C";
                Device.StartTimer(TimeSpan.FromSeconds(10), () => {
                    Device.BeginInvokeOnMainThread(() => { CurrTemp.Text = temperature.Temp == null ? "0°C" : temperature.Temp + "°C"; });
                    return true;
                });
                Browser.Source = "http://google.com";
            }
            catch (Exception)
            {
                CurrTemp.Text = "0°C";
            }
            
        }
        private Temperature GetTemperature()
        {
            try
            {
                CallApi callApi = new CallApi();
                Task<HttpResponseMessage> varContext = callApi.client.GetAsync("Temperature");
                HttpResponseMessage resMsg = varContext.Result;
                if (!resMsg.IsSuccessStatusCode) return new Temperature();
                var jsonResult = resMsg.Content.ReadAsStringAsync().Result;
                var returnObj = JsonConvert.DeserializeObject<ReturnObj>(jsonResult);
                if (returnObj.IsSearchMsg) return new Temperature();
                return (Temperature)returnObj.ApiData.ToObject<Temperature>();
            }
            catch(Exception ex)
            {
                return new Temperature();
            }
        }
        private async void SayHelloButtonOnClicked(object sender, EventArgs e)
        {
            //var name = NameEntry.Text;
            //await DisplayAlert("Greeting", $"Hello {name}!", "Howdy");

        }
    }
}
