using System;
using Xunit;
using System.Collections.Generic;

namespace Version1.test
{
    public class UnitTest1
    {
        string ArchivoHTML1 = @"..\..\..\..\..\HTML-Prueba\test4.html";

        [Fact]
        public void FormatoImpresion()
        {
            Assert.Equal("html\nbody\nfont\ncolor=blue\nsize=3\n", Formato.Imprimir(ArchivoHTML1));
        }

        [Fact]
        public void AtributoVacio()
        {
            List<Atributos> Atr = new List<Atributos>();
            Tag T = new Tag("Prueba", Atr);

            Assert.Equal("", T.RetornarAtributos());
        }

        [Fact]
        public void TagSinNombre()
        {
            List<Atributos> Atr = new List<Atributos>();
            Tag T = new Tag(null, Atr);

            Assert.Equal(null, T.Nombre);
        }
    }
}
