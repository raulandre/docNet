using System.Collections.Generic;
using docNet.Enums;

namespace docNet.Core
{
    public class Doc
    {
        private DocType Type { get; set; }
        private string Text { get; set; }
        private List<Doc> Methods { get; set; } = new List<Doc>();
        private List<Doc> Properties { get; set; } = new List<Doc>();

        public Doc(DocType type, string text)
        {
            Type = type;
            Text = text;
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