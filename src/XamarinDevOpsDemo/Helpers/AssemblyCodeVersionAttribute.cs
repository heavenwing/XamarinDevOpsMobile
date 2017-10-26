using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace XamarinDevOpsDemo.Helpers
{
    [AttributeUsage(AttributeTargets.Assembly)]
    public class AssemblyCodeVersionAttribute : Attribute
    {
        public AssemblyCodeVersionAttribute(string codeVersion)
        {
            CodeVersion = codeVersion;
        }

        public string CodeVersion { get; }

        public static string GetCodeVersion()
        {
            var assembly = typeof(AssemblyCodeVersionAttribute).GetTypeInfo().Assembly;
            var attribute = CustomAttributeExtensions.GetCustomAttribute<AssemblyCodeVersionAttribute>(assembly);
            return attribute.CodeVersion;
        }
    }
}
