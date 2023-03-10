using System.Collections.Generic;
using System.Linq;
using docNet.Core.Writers;

namespace docNet.Core.Generators
{
    public class DefaultGenerator : IGenerator
    {
        private List<ClassDocumentation> _docs;
        private IWriter _writer;

        public DefaultGenerator(IWriter writer, params ClassDocumentation[] docs)
        {
            _writer = writer;
            _docs = docs.ToList();
        }

        public void Generate()
        {
            foreach (var doc in _docs)
            {
                _writer.WriteDoc(doc);
            }
        }
    }
}