using Proyecto.LibraryModelado;
using Proyecto.LeerHTML;
using Proyecto.Factory.CSharp;
using System.Collections.Generic;
using Xunit;

namespace Proyecto.LibraryModelado.Engine.test
{
    public class UnitTextScientificExercise1
    {
        private EngineGame engineGame = Singleton<EngineGame>.Instance;

        /// <summary>
        /// Testea la asociación del Motor.
        /// </summary>
        [Fact]
        public void TestEngineAsociate()
        {
            const string XMLfile = @"..\..\..\..\..\..\Src\ArchivosHTML\html.xml";
            List<Tag> tags = Parser.ParserHTML(ReadHTML.ReturnHTML(XMLfile));
            List<IComponent> componentList = new List<IComponent>();

            foreach (Tag tag in tags)
            {
                IComponent component = FactoryComponent.InitializeFactories().MakeComponent(tag);
                componentList.Add(component);
            }
            this.engineGame.AsociateLevelsWithEngines(componentList);
            List<string> array = new List<string>();

            foreach (var s in this.engineGame.LevelEngines)
            {
                array.Add(s.Key.Name);
            }

            Assert.Equal("ScientificExercise1", array[0]);
        }
    }
}
