using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace dotnet2ts
{
    public class ClassDefinition
    {
        private static readonly string EOL = "\n";

        private ClassDeclarationSyntax klass;

        public ClassDefinition(ClassDeclarationSyntax klass)
        {
            this.klass = klass;
        }

        private IEnumerable<string> EmitChunks()
        {
            yield return "export class "; yield return klass.Identifier.Text; yield return " extends NObject { "; yield return EOL;
            yield return "}";
        }

        public string Emit()
        {
            return string.Join("", EmitChunks());
        }

    }
}
