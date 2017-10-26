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
        public const string ApiUrl = "https://api-test.zyg.cloud";
#endif
#if UAT
        public const string ApiUrl = "https://api-uat.zyg.cloud";
#endif
#if PROD
        public const string ApiUrl = "https://api-prod.zyg.cloud";
#endif
    }
}
