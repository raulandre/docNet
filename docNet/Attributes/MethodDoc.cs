using System;

namespace docNet.Attributes
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class MethodDoc : Attribute
    {
        public string Text { get; private set; }
        
        public MethodDoc(string text)
        {
            Text = text;
        }
    }
}