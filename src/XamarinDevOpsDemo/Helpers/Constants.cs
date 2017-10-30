#define TEST
//#define UAT
//#define PROD

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinDevOpsDemo.Helpers
{
    public static class Constants
    {
#if TEST
        public const string ApiUrl = "https://www.bing.com";
        public const string MobileCenterAppKey_Android = "6a933322-6662-4428-aafd-1198644edef0";
        public const string MobileCenterAppKey_iOS = "bf45ef37-d3bf-4770-ba1c-8f48e2fa9967";
#endif
#if UAT
        public const string ApiUrl = "https://www.xamarin.com/";
        public const string MobileCenterAppKey_Android = "6a933322-6662-4428-aafd-1198644edef0";
        public const string MobileCenterAppKey_iOS = "bf45ef37-d3bf-4770-ba1c-8f48e2fa9967";
#endif
#if PROD
        public const string ApiUrl = "https://www.microsoft.com/china/techsummit/2017/";
        public const string MobileCenterAppKey_Android = "6a933322-6662-4428-aafd-1198644edef0";
        public const string MobileCenterAppKey_iOS = "bf45ef37-d3bf-4770-ba1c-8f48e2fa9967";
#endif
    }
}
