using System.Reflection;
using docNet.Attributes;
using docNet.Core;
using docNet.Core.Generators;
using docNet.Core.Writers;

namespace docNet.Test;

public class ScannerTest
{
    
    [Fact]
    public void Test()
    {
        var docs = Scanner.Scan(Assembly.GetExecutingAssembly());
        new DefaultGenerator(new DefaultWriter(), docs.ToArray()).Generate();
    }
}