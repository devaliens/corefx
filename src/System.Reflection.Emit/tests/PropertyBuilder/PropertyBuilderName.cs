// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using Xunit;

namespace System.Reflection.Emit.Tests
{
    public class PropertyBuilderTest9
    {
        private static readonly RandomDataGenerator s_randomDataGenerator = new RandomDataGenerator();
        
        public static IEnumerable<object[]> Names_TestData()
        {
            yield return new object[] { new string((char)(s_randomDataGenerator.GetInt32() % ushort.MaxValue + 1), 1) + s_randomDataGenerator.GetString(false, 1, 260) };
            yield return new object[] { "class" };
            yield return new object[] { new string('a', short.MaxValue) };
        }

        [Theory]
        [MemberData(nameof(Names_TestData))]
        public void Name(string name)
        {
            TypeBuilder type = Helpers.DynamicType(TypeAttributes.Class | TypeAttributes.Public);
            PropertyBuilder property = type.DefineProperty(name, PropertyAttributes.None, typeof(int), null);
            Assert.Equal(name, property.Name);
        }

        [Fact]
        public void Name_InvalidString()
        {
            // TODO: move into Names_TestData when #7166 is fixed
            Name("1A\0\t\v\r\n\n\uDC81\uDC91");
        }
    }
}
