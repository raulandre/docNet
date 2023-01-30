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
                var classDoc = new Doc(DocType.Class, classDocText);

                //Find all method docs from class
                var methods = c.GetMethods()
                    .Where(m => m.GetCustomAttributes(typeof(MethodDoc), false).Length == 1)
                    .Select(m => m.GetCustomAttribute<MethodDoc>().Text.Trim())
                    .Select(m => new Doc(DocType.Method, m))
                    .ToArray();

                //Find all prop docs from class
                var props = c.GetProperties()
                    .Where(p => p.GetCustomAttributes(typeof(MethodDoc), false).Length == 1)
                    .Select(p => p.GetCustomAttribute<PropDoc>().Text.Trim())
                    .Select(p => new Doc(DocType.Prop, p))
                    .ToArray();

                //Register all docs found
                classDoc.AddMethods(methods);
                classDoc.AddProps(props);
                
                //Add doc to return list
                docs.Add(classDoc);
            }

            return docs;
        }
    }
}