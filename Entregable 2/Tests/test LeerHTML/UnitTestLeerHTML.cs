using System.Collections.Generic;
using Xunit;
using System;
using Proyecto.LeerHTML;

namespace Proyecto.LeerHTML.test
{
    public class UnitTestLeerHTML
    {
        [Fact]
        public void FormatPrinter()
        {
            string path = @"..\..\..\..\..\Src\ArchivosHTML\Ejemplo.xml";
            string Actual = Printer.Format(path);
            string Expected = "World\nHeight=50\nWidth=520\nName=world1\nLevel\nName=level1\nWorld=world1\nButton\nName=button1\nLevel=level1\nPositionX=100\nPositionY=200\nHeight=100\nWidth=100\n";

            Assert.Equal(Expected, Actual);
        }

        [Fact]
        public void EmptyAttributes()
        {
            //arrange
            string path = @"..\..\..\..\..\Src\ArchivosHTML\Test.xml";

            //assert
            Assert.Throws<ArgumentNullException>(() => Parser.ParserHTML(ReadHTML.ReturnHTML(path)));
        }
    }
}