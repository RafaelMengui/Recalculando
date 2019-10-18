using Proyecto.LeerHTML;
using System;
using Xunit;


namespace Proyecto.LeerHTML.test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            const string path = @"Ejemplo.xml";
            string s = Imprimir.Formato(path);
            Assert.Equal("", s);
        }
    }
}
