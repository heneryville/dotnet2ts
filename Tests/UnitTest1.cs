using dotnet2ts;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class UnitTest1
    {
        public void ItTranspilesClasses()
        {
            var actual = DotNet2TS.TranspileFile("../../../../TestDll/ClassWithAutoProperties.cs");
        }

        [Test]
        public void ItTranspilesClassDefinitions()
        {
            var actual = DotNet2TS.TranspileFile("../../../../TestDll/ClassWithAutoProperties.cs");
            AssertHasString(actual, "export class ClassWithAutoProperties extends NObject {");
        }

        public static void AssertHasString(string actual, string expected)
        {
            if(!actual.Contains(expected))
            {
                throw new AssertionException($"Expected {actual} to have {expected}");
            }
        }
    }
}
