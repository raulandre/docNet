using System.Reflection;
using docNet.Attributes;
using docNet.Core;

namespace docNet.Test;

[ClassDoc(@"
    This is my sample test class!
")]
public class ScannerTest
{
    [PropDoc(@"
        This is my sample prop!
    ")]
    public string SampleProp { get; set; }
    
    [Fact]
    [MethodDoc(@"
        This is my sample test method!
    ")]
    public void Test()
    {
        var sc = Scanner.Scan(Assembly.GetExecutingAssembly());
    }
}