using System;
using Xunit;
using Proyecto.LeerHTML;

namespace Proyecto.LeerHTML.test
{
    public class UnitTestLeerHTML
    {
        [Fact]
        public void ImprimirFormato()
        {
            string path = @"C:\Users\nicop\Desktop\Entregable 2\Code\Entregable 2\Src\Archivos HTML\Ejemplo.xml";
            string Actual = Imprimir.Formato(path);
            string Expected = "square-world\nsize=50\nname=world1\nlevel\nname=level1\nworld=world1\nbutton\nname=button1\nlevel=level1\nposition_x=10\nposition_y=20\nsize=20x30\n";
            
            Assert.Equal(Expected, Actual);
        }
    }
}