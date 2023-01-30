using docNet.Attributes;

namespace docNet.Test;

[ClassDoc(@"
    This is a sample class, documented using docNet!
")]
public class SampleClass
{
    [PropDoc(@"
        This is a sample documentation for the name prop!
    ")]
    public string Name { get; set; }
    
    [PropDoc(@"
        This is a sample documentation for the age prop!
    ")]
    public int Age { get; set; }

    [MethodDoc(@"
        This method does stuff...
    ")]
    public void DoStuff()
    {
        
    }

    [MethodDoc(@"
        This method does some other stuff...
    ")]
    public string DoOtherStuff(string s1, string s2, string s3)
    {
        return string.Empty;
    }
}