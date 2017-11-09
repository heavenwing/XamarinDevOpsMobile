using Plugin.Geolocator;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            wv.ContentType = Xam.Plugin.WebView.Abstractions.Enumerations.WebViewContentType.StringData;
            wv.Source = @"
<html><body>
<button onclick=""mobilePlatform_TakePhoto()"">TakePhoto</button>
<button onclick=""mobilePlatform_TakeVideo()"">TakeVideo</button>
<button onclick=""mobilePlatform_GetPosition()"">GetPosition</button>
<body><html>
";
           
        }
    }
}