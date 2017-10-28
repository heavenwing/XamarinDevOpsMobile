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

            BuildNumber ="Build Number : " + AssemblyBuildNumberAttribute.GetBuildNumber();
            CodeVersion = "Code Version : " + AssemblyCodeVersionAttribute.GetCodeVersion().Substring(0, 8);
        }

        /// <summary>
        /// Command to open browser to xamarin.com
        /// </summary>
        public ICommand OpenWebCommand { get; }

        private string _buildNumber=string.Empty;

        public string BuildNumber
        {
            get { return _buildNumber; }
            set { SetProperty(ref _buildNumber, value); }
        }

        private string _codeVersion=string.Empty;
        public string CodeVersion
        {
            get { return _codeVersion; }
            set { SetProperty(ref _codeVersion, value); }
        }
    }
}
