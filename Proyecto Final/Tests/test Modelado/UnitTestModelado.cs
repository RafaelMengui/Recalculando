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
        private EngineGame engineGame = Singleton<EngineGame>.Instance;
        private Money money;
        private MoneyContainer moneyContainer;
        private Space level;
        private ButtonStartLevel buttonStart;

        [Fact]
        public void TestFactoryComponents()
        {
            const string XMLfile = @"..\..\..\..\..\Src\ArchivosHTML\1920x1080 Test.xml";

            List<Tag> tags = Parser.ParserHTML(ReadHTML.ReturnHTML(XMLfile));
            List<IComponent> componentList = new List<IComponent>();

            foreach (Tag tag in tags)
            {
                IComponent component = FactoryComponent.InitializeFactories().MakeComponent(tag);
                componentList.Add(component);
            }

            this.engineGame.AsociateLevelsWithEngines(componentList);
        }
    }
}
