using Plugin.Geolocator;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xam.Plugin.WebView.Abstractions.Enumerations;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinDevOpsDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WebViewPage : ContentPage
    {
        public WebViewPage()
        {
            InitializeComponent();

            wv.AddLocalCallback("mobilePlatform_TakePhoto",async (args) => {
                Debug.WriteLine(args);
                if (CrossMedia.Current.IsCameraAvailable && CrossMedia.Current.IsTakePhotoSupported)
                {
                    var result = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions());
                    Debug.WriteLine(result?.Path);
                }
            });
            wv.AddLocalCallback("mobilePlatform_TakeVideo", async (args) => {
                Debug.WriteLine(args);
                if (CrossMedia.Current.IsCameraAvailable && CrossMedia.Current.IsTakeVideoSupported)
                {
                    var result = await CrossMedia.Current.TakeVideoAsync(new StoreVideoOptions());
                    Debug.WriteLine(result?.Path);
                }
            });
            wv.AddLocalCallback("mobilePlatform_GetPosition", async (args) => {
                Debug.WriteLine(args);
                if (CrossGeolocator.Current.IsGeolocationAvailable && CrossGeolocator.Current.IsGeolocationEnabled)
                {
                    var result = await CrossGeolocator.Current.GetPositionAsync();
                    if (result!=null)
                    {
                        var json = "{\"value\":{\"Latitude\":\"" + result.Latitude + "\",\"Longitude\":" + result.Longitude + "\"}}";
                        Debug.WriteLine(json);
                    }
                }
            });

            wv.ContentType = WebViewContentType.Internet;
            wv.Source = "https://xamarincd.chinacloudsites.cn/webview.html";
           
        }
    }
}