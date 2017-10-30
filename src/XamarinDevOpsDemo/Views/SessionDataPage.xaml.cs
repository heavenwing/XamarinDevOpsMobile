using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Pages;
using Xamarin.Forms.Xaml;

namespace XamarinDevOpsDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SessionDataPage : ListDataPage
    {
        public SessionDataPage()
        {
            InitializeComponent();
        }
    }
}