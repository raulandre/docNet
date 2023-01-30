using System;

namespace docNet.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false)]
    public class PropDoc : Attribute
    {
        public string Text { get; private set; }
        
        public PropDoc(string text)
        {
            Text = text;
        }
    }
}