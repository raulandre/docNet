using System.Collections.Generic;
using docNet.Enums;

namespace docNet.Core
{
    public class PropertyDocumentation
    {
        public string Text { get; private set; }
        public string Name { get; private set; }
        public string Type { get; private set; }
        public (string, string) AccessorTypes { get; private set; }
        

        public PropertyDocumentation(string text, string name, string type, (string, string) accessorTypes)
        {
            Text = text;
            Name = name;
            Type = type;
            AccessorTypes = accessorTypes;
        }
    }
}