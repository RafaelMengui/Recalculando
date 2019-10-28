using System;
using System.Collections.Generic;
using Proyecto.LeerHTML;
using Proyecto.LibraryModelado.Engine;
using Proyecto.Factory.CSharp;
using Proyecto.Item;
using Proyecto.Item.ScientistLevel;
using Xunit;

namespace Proyecto.LibraryModelado.test
{
    public class UnitTestModelado
    {

        [Fact]
        public void TestFactoryC()
        {
            const string XMLfile = @"..\..\..\..\..\Src\ArchivosHTML\TesteoModelado.xml";

            List<Tag> tags = Parser.ParserHTML(ReadHTML.ReturnHTML(XMLfile));
            List<IComponent> componentList = new List<IComponent>();

            foreach (Tag tag in tags)
            {
               Assert.Throws<System.ArgumentNullException>(() => FactoryComponent.InitializeFactories().MakeComponent(tag));
            }

        }
    }
}
