using System.Collections.Generic;
using docNet.Enums;

namespace docNet.Core
{
    public class ClassDocumentation
    {
        public string Text { get; private set; }
        public string Name { get; private set; }
        public string Namespace { get; private set; }
        
        //TODO: maybe encapsulate these lists in a better way
        public List<MethodDocumentation> Methods { get; private set; } = new List<MethodDocumentation>();
        public List<PropertyDocumentation> Properties { get; private set; } = new List<PropertyDocumentation>();
        public List<string> Inherits { get; set; } = new List<string>();
        public List<string> Implements { get; set; } = new List<string>();

        public ClassDocumentation(string text, string name, string _namespace)
        {
            Text = text;
            Name = name;
            Namespace = _namespace;
        }

        public void AddMethods(params MethodDocumentation[] docs)
        {
            Methods.AddRange(docs);
        }
        
        public void AddProps(params PropertyDocumentation[] docs)
        {
            Properties.AddRange(docs);
        }
    }
}