using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using docNet.Attributes;
using docNet.Enums;
using docNet.Utils;

namespace docNet.Core {
    public abstract class Scanner {
        public static IEnumerable<ClassDocumentation> Scan(Assembly assembly)
        {
            //Find all classes with 'ClassDoc' attribute
            var classes = assembly.GetTypes()
                .Where(t => t.GetCustomAttributes(typeof(ClassDoc), false).Length == 1).ToArray();

            var docs = new List<ClassDocumentation>();
            foreach(var @class in classes)
            {
                //Get prop text from class
                var classDocText = @class.GetCustomAttribute<ClassDoc>()
                    .Text.Trim();
                var classDoc = new ClassDocumentation(classDocText, @class.Name, @class.Namespace);

                classDoc.AddProps((from prop in @class.GetProperties()
                        .Where(p => p.GetCustomAttributes(typeof(PropDoc), false).Length == 1)
                    let attr = prop.GetCustomAttribute<PropDoc>()
                    let text = attr.Text.Trim().Replace('\u0009', ' ')
                    let type = prop.PropertyType.GetFriendlyName()
                    select new PropertyDocumentation(text, prop.Name, type, VisibilityUtils.GetVisibility(prop))).ToArray());
                
                classDoc.AddMethods((from method in @class.GetMethods()
                        .Where(m => m.GetCustomAttributes(typeof(MethodDoc), false).Length == 1)
                    let attr = method.GetCustomAttribute<MethodDoc>()
                    let parameters = method.GetParameters()
                        .Select(p => $"{p.ParameterType.GetFriendlyName()} {p.Name}").ToList()
                    let text = attr.Text.Trim().Replace('\u0009', ' ')
                    select new MethodDocumentation(text, method.Name, method.ReturnType.GetFriendlyName(), parameters, VisibilityUtils.GetVisibility(method))).ToArray());
                
                //Add doc to return list
                docs.Add(classDoc);
            }

            return docs;
        }
    }
}