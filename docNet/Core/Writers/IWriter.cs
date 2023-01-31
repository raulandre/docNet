using System;

namespace docNet.Core.Writers
{
    public interface IWriter
    {
        void WriteDoc(ClassDocumentation doc);
    }
}