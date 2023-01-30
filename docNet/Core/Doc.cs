using System.Collections.Generic;
using docNet.Enums;

namespace docNet.Core
{
    public class Doc
    {
        public DocType Type { get; private set; }
        public string Text { get; private set; }
        public string Name { get; set; }
        
        //TODO: maybe encapsulate these lists in a better way
        public List<Doc> Methods { get; private set; } = new List<Doc>();
        public List<Doc> Properties { get; private set; } = new List<Doc>();

        public Doc(DocType type, string text, string name = null)
        {
            Type = type;
            Text = text;
            Name = name;
        }

        public void AddMethods(params Doc[] docs)
        {
            Methods.AddRange(docs);
        }
        
        public void AddProps(params Doc[] docs)
        {
            Properties.AddRange(docs);
        }
    }
}