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
            const string XMLfile = @"..\..\..\..\..\Src\ArchivosHTML\ElPosta.xml";

            List<Tag> tags = Parser.ParserHTML(ReadHTML.ReturnHTML(XMLfile));
            List<IComponent> componentList = new List<IComponent>();

            foreach (Tag tag in tags)
            {
                IComponent component = FactoryComponent.InitializeFactories().MakeComponent(tag);
                componentList.Add(component);
            }

            this.engineGame.AsociateLevelsWithEngines(componentList);
            foreach (IComponent comp in componentList)
            {
                if (comp is Money)
                {
                    if (((Money)comp).Name == "1coin5")
                    {
                        this.money = comp as Money;
                    }
                }
                if (comp is MoneyContainer)
                {
                    if (((MoneyContainer)comp).Name=="resultContainer1")
                    {
                        this.moneyContainer = comp as MoneyContainer;
                    }
                }
                if (comp is Space)
                {
                    if (((Level)comp).Name == "ScientificExercise1")
                    {
                        this.level = comp as Space;
                    }
                }
                if (comp is ButtonStartLevel)
                {
                    this.buttonStart = comp as ButtonStartLevel;
                }
            }
        }
    }
}
