using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace dotnet2ts
{
    public class DotNet2TS
    {

        public static string Transpile(string code)
        {
            var root = CSharpSyntaxTree.ParseText(code).GetRoot(); ;
            var classes = root.DescendantNodes()
                .OfType<ClassDeclarationSyntax>()
                .Select(x => new ClassDefinition(x).Emit());
            return String.Join("\n\n", classes);
        }

        public static string TranspileFile(string path)
        {
            using(StreamReader sr = new StreamReader(path))
            {
                string text = sr.ReadToEnd();
                return Transpile(text);
            }
        }
    }
}
