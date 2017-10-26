using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace XamarinDevOpsDemo.Helpers
{
    [AttributeUsage(AttributeTargets.Assembly)]
    public class AssemblyBuildNumberAttribute : Attribute
    {
        public AssemblyBuildNumberAttribute(string buildNumber)
        {
            BuildNumber = buildNumber;
        }

        public string BuildNumber { get; }

        public static string GetBuildNumber()
        {
            var assembly = typeof(AssemblyBuildNumberAttribute).GetTypeInfo().Assembly;
            var attribute = CustomAttributeExtensions.GetCustomAttribute<AssemblyBuildNumberAttribute>(assembly);
            return attribute.BuildNumber;
        }
    }
}
