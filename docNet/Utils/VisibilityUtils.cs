using System;
using System.Linq;
using System.Reflection;

namespace docNet.Utils
{
    public static class VisibilityUtils
    {
        public static string GetVisibility(MethodInfo method)
        {
            if (method.IsPublic)
                return "public";
            else if (method.IsPrivate)
                return "private";
            else if (method.IsFamily)
                    return "protected";
            
            return string.Empty;
        }
        
        public static (string, string) GetVisibility(PropertyInfo prop)
        {
            var accessors = prop.GetAccessors(true).Select(GetVisibility).ToArray();
            return accessors.Count() == 2 ? (accessors.First(), accessors.Skip(1).First()) : (string.Empty, string.Empty);
        }
    }
}