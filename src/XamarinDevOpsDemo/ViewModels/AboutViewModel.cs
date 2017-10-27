using System;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinDevOpsDemo.Helpers;

namespace XamarinDevOpsDemo.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri(Constants.ApiUrl)));

            BuildNumber = AssemblyBuildNumberAttribute.GetBuildNumber();
            CodeVersion = AssemblyCodeVersionAttribute.GetCodeVersion().Substring(0, 8);
        }

        /// <summary>
        /// Command to open browser to xamarin.com
        /// </summary>
        public ICommand OpenWebCommand { get; }

        public string BuildNumber { get; set; }

        public string CodeVersion { get; set; }
    }
}
