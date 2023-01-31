using System.Collections.Generic;
using docNet.Enums;

namespace docNet.Core
{
    public class MethodDocumentation
    {
        public string Text { get; private set; }
        public string Name { get; private set; }
        public string ReturnType { get; private set; }
        public List<string> Params { get; private set; }
        public string Visiblity { get; private set; }
        

        public MethodDocumentation(string text, string name, string returnType, List<string> _params, string visiblity)
        {
            Text = text;
            Name = name;
            ReturnType = returnType;
            Params = _params;
            Visiblity = visiblity;
        }
    }
}