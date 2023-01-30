using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using docNet.Attributes;
using docNet.Enums;

namespace docNet.Core {
    public abstract class Scanner {
        public static IEnumerable<Doc> Scan(Assembly assembly)
        {
            //Find all classes with 'ClassDoc' attribute
            var classes = assembly.GetTypes()
                .Where(t => t.GetCustomAttributes(typeof(ClassDoc), false).Length == 1);

            var docs = new List<Doc>();
            foreach(var c in classes)
            {
                //Get prop text from class
                var classDocText = c.GetCustomAttribute<ClassDoc>()
                    .Text.Trim();
                var classDoc = new Doc(DocType.Class, classDocText)
                {
                    Name = c.Name
                };

                //Register all docs found
                classDoc.AddProps((from prop in c.GetProperties()
                        .Where(p => p.GetCustomAttributes(typeof(PropDoc), false).Length == 1)
                    let attr = prop.GetCustomAttribute<PropDoc>()
                    let name = $"{prop.PropertyType.Name} {prop.Name}"
                    let text = attr.Text.Trim().Replace('\u0009', ' ')
                    select new Doc(DocType.Prop, text, name)).ToArray());
                
                classDoc.AddMethods((from method in c.GetMethods()
                        .Where(m => m.GetCustomAttributes(typeof(MethodDoc), false).Length == 1)
                    let attr = method.GetCustomAttribute<MethodDoc>()
                    let parameters = method.GetParameters()
                        .Select(p => $"{p.ParameterType.Name} {p.Name}")
                    let name = $"{method.ReturnType.Name} {method.Name}({string.Join(", ", parameters)})"
                    let text = attr.Text.Trim().Replace('\u0009', ' ')
                    select new Doc(DocType.Prop, text, name)).ToArray());
                
                //Add doc to return list
                docs.Add(classDoc);
            }

            return docs;
        }
    }
}