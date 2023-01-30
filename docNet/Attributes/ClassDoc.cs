using System;

namespace docNet.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class ClassDoc : Attribute
    {
        public string Text { get; private set; }
        
        public ClassDoc(string text)
        {
            Text = text;
        }
    }
}