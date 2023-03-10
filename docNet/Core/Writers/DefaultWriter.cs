using System;
using System.IO;
using System.Linq;
using System.Text;
using docNet.Enums;

namespace docNet.Core.Writers
{
    public class DefaultWriter : IWriter
    {
        public string OutputDir { get; set; }

        public DefaultWriter()
        {
            var workingDirectory = Environment.CurrentDirectory;
            var directoryInfo = Directory.GetParent(workingDirectory)?.Parent;
            if (directoryInfo?.Parent == null) return;
            var projectDirectory = directoryInfo?.Parent.FullName;

            var docsDir = $"{projectDirectory}/Docs";
            if(!Directory.Exists(docsDir))
                Directory.CreateDirectory(docsDir);

            OutputDir = docsDir;
        }
        
        public void WriteDoc(ClassDocumentation doc)
        {
            var namespacePath = Path.Combine(OutputDir, doc.Namespace);
            if (!Directory.Exists(namespacePath))
                Directory.CreateDirectory(namespacePath);
            using (var docFile = File.Create(Path.Combine(OutputDir, $"{doc.Namespace}/{doc.Name}.md")))
            {
                var sb = new StringBuilder();
                sb.AppendLine($"## {doc.Name}");
                sb.AppendLine($"`using {doc.Namespace};` \n");
                sb.AppendLine($"{doc.Text}");


                if (doc.Properties.Any())
                {
                    sb.AppendLine("\n___\n");
                    sb.AppendLine($"#### Properties");
                }
                foreach (var prop in doc.Properties)
                {
                    sb.AppendLine($"+ {prop.Type} {prop.Name} {{ {prop.AccessorTypes.Item1} get; {prop.AccessorTypes.Item2} set; }}");
                    sb.AppendLine($"> {prop.Text.Replace("\n", "\n>")}");
                }

                if (doc.Methods.Any())
                {
                    sb.AppendLine("\n___\n");
                    sb.AppendLine($"#### Methods");
                }
                foreach (var method in doc.Methods)
                {
                    sb.AppendLine($"+ {method.Visiblity} {method.ReturnType} {method.Name}({string.Join(", ", method.Params)})");
                    sb.AppendLine($"> {method.Text.Replace("\n", "\n>")}");
                }

                var result = sb.ToString().Trim().Replace("<", "\\<");
                
                var bytes = Encoding.UTF8.GetBytes(result);
                docFile.Write(bytes, 0, bytes.Length);
            }
        }
    }
}