using System;
using System.Collections.Generic;
using Proyecto.LeerHTML;
using Proyecto.LibraryModelado.Engine;
using Proyecto.Factory.CSharp;
using Proyecto.Item;
using Proyecto.Item.ScientistLevel;
using Xunit;

namespace Proyecto.LibraryModelado.Engine.test
{
    public class UnitTextScientificExercise1
    {
        private Level level = new Level("level", null);
        private EngineScientificExercise1 engineScientific1 = Singleton<EngineScientificExercise1>.Instance;
        private EngineGame engineGame = Singleton<EngineGame>.Instance;

        [Fact]
        public void TestVerifyAddition()
        {
            engineScientific1.StartLevel();
            MoneyContainer dragcontainerSource = new MoneyContainer("source", level, 1, 10, 10, 10, null, 0);
            MoneyContainer dragcontainerDestintantion = new MoneyContainer("dragC", level, 1, 10, 10, 10, null, 120);
            Money moneydrag = new Money("drag", level, 20, 20, 2, 2, null, true, dragcontainerSource, 120);
            Assert.Equal(true, EngineScientificExercise1.VerifyOperation(dragcontainerDestintantion, moneydrag));
        }

        [Fact]
        public void TestOnDrop()
        {
            engineScientific1.StartLevel();
            MoneyContainer dragSource = new MoneyContainer("drag", level, 1, 10, 10, 10, null, 1);
            MoneyContainer dragcontainerDestintantion = new MoneyContainer("dragC", level, 1, 10, 10, 10, null, 120);
            Money moneydrag = new Money("drag", level, 20, 20, 2, 2, null, true, dragSource, 120);
            Assert.Equal(true, moneydrag.Drop(dragcontainerDestintantion));
        }

        [Fact]
        public void TestOnDropUndraggable()
        {
            engineScientific1.StartLevel();
            MoneyContainer dragcontainerSource = new MoneyContainer("source", level, 1, 10, 10, 10, null, 0);
            MoneyContainer dragcontainerDestintantion = new MoneyContainer("dragC", level, 1, 10, 10, 10, null, 120);
            Money moneydrag = new Money("drag", level, 20, 20, 2, 2, null, false, dragcontainerSource, 120);
            Assert.Equal(false, moneydrag.Drop(dragcontainerDestintantion));
        }

        [Fact]
        public void NegativeMoneyValue()
        {
            engineScientific1.StartLevel();
            MoneyContainer container1 = new MoneyContainer("cont1", this.level, 50, 50, 60, 60, null, 10);
            Assert.Throws<ArithmeticException>(() => new Money("name", this.level, 50, 40, 30, 20, null, false, container1, -10));
        }

        [Fact]
        public void WinPage()
        {
            engineScientific1.StartLevel();
            MoneyContainer containerDestination1 = new MoneyContainer("Dest1", this.level, 50, 50, 60, 60, null, 10); // 60 - 50
            MoneyContainer containerDestination2 = new MoneyContainer("Dest2", this.level, 50, 50, 60, 60, null, 175); // 100 + 175
            MoneyContainer containerSource1 = new MoneyContainer("Source1", this.level, 50, 50, 60, 60, null, 0);
            MoneyContainer containerSource2 = new MoneyContainer("Source2", this.level, 50, 50, 60, 60, null, 0);

            Money moneyDrag1 = new Money("Drag1", this.level, 20, 20, 2, 2, null, true, containerSource1, 10);
            Money moneyDrag2 = new Money("Drag2", this.level, 20, 20, 2, 2, null, true, containerSource2, 175);

            moneyDrag1.Drop(containerDestination1);
            moneyDrag2.Drop(containerDestination2);

            Assert.Equal(true, engineScientific1.VerifyWinPage());
        }

        [Fact]
        public void WinLevel()
        {
            engineScientific1.StartLevel();
            // Pagina 1.
            //Se crean containers y dinero.
            MoneyContainer containerDestination1 = new MoneyContainer("Dest1", this.level, 50, 50, 60, 60, null, 10);
            MoneyContainer containerDestination2 = new MoneyContainer("Dest2", this.level, 50, 50, 60, 60, null, 175);
            MoneyContainer containerSource1 = new MoneyContainer("Source1", this.level, 50, 50, 60, 60, null, 0);
            MoneyContainer containerSource2 = new MoneyContainer("Source2", this.level, 50, 50, 60, 60, null, 0);

            Money moneyDrag1 = new Money("Drag1", this.level, 20, 20, 2, 2, null, true, containerSource1, 10);
            Money moneyDrag2 = new Money("Drag2", this.level, 20, 20, 2, 2, null, true, containerSource2, 175);

            // Se suelta el dinero dentro del container destination correcto.
            moneyDrag1.Drop(containerDestination1);
            moneyDrag2.Drop(containerDestination2);

            // Si fueron correctamente soltados los dos dineros, se pasa a la segunda parte del nivel.
            if (engineScientific1.VerifyWinPage())
            {
                // Pagina 2.
                engineScientific1.StartPage();
                // Se reinicia la pagina y sus contadores, se crean los nuevos containers y dinero.
                MoneyContainer containerDestination3 = new MoneyContainer("Dest3", this.level, 50, 50, 60, 60, null, 50);
                MoneyContainer containerDestination4 = new MoneyContainer("Dest4", this.level, 50, 50, 60, 60, null, 200);
                MoneyContainer containerSource3 = new MoneyContainer("Source3", this.level, 50, 50, 60, 60, null, 0);
                MoneyContainer containerSource4 = new MoneyContainer("Source4", this.level, 50, 50, 60, 60, null, 0);

                Money moneyDrag3 = new Money("Drag3", this.level, 20, 20, 2, 2, null, true, containerSource3, 50);
                Money moneyDrag4 = new Money("Drag4", this.level, 20, 20, 2, 2, null, true, containerSource4, 200);

                // Se sueltan los nuevos dineros en los containers correctos.
                moneyDrag3.Drop(containerDestination3);
                moneyDrag4.Drop(containerDestination4);

                // Se verifica que se hayan completado correctamente las dos etapas del juego
                // (Se tienen que haber hecho correctamente las cuatro sumas.)
                engineScientific1.VerifyWinPage();

                Assert.Equal(true, engineScientific1.VerifyWinLevel());
            }
        }

        [Fact]
        public void TestGoodFeedback()
        {
            engineScientific1.StartLevel();

            MoneyContainer containerDestination = new MoneyContainer("Dest1", this.level, 50, 50, 60, 60, null, 10);
            MoneyContainer containerSource = new MoneyContainer("Source1", this.level, 50, 50, 60, 60, null, 0);
            Money moneyDrag = new Money("Drag1", this.level, 20, 20, 2, 2, null, true, containerSource, 10);

            engineScientific1.VerifyExercise(containerDestination, moneyDrag);
            Assert.Equal("Muy buen trabajo, ¡Continua asi!", engineScientific1.Feedback.Text);
        }

        [Fact]
        public void TestBadFeedback()
        {
            engineScientific1.StartLevel();

            MoneyContainer containerDestination = new MoneyContainer("Dest1", this.level, 50, 50, 60, 60, null, 200);
            MoneyContainer containerSource = new MoneyContainer("Source1", this.level, 50, 50, 60, 60, null, 0);
            Money moneyDrag = new Money("Drag1", this.level, 20, 20, 2, 2, null, true, containerSource, 10);

            engineScientific1.VerifyExercise(containerDestination, moneyDrag);
            Assert.Equal("Esa suma no es correcta, ¡Intentalo de nuevo!", engineScientific1.Feedback.Text);
        }

        [Fact]
        public void TestCreateGoToMainButton()
        {
            bool condicion = false;
            const string XMLfile = @"..\..\..\..\..\..\Src\ArchivosHTML\Niveles.xml";
            List<Tag> tags = Parser.ParserHTML(ReadHTML.ReturnHTML(XMLfile));
            List<IComponent> componentList = new List<IComponent>();

            foreach (Tag tag in tags)
            {
                IComponent component = FactoryComponent.InitializeFactories().MakeComponent(tag);
                componentList.Add(component);
            }
            this.engineGame.Asociate(componentList);
            this.engineGame.ButtonGoToMain();
            this.engineScientific1.StartLevel();
            foreach (Items item in this.engineScientific1.Level.ItemList)
            {
                if (item is ButtonGoToPage && item.Name == "GoToMain")
                {
                    condicion = true;
                }
            }
            Assert.True(condicion);
        }
    }
}