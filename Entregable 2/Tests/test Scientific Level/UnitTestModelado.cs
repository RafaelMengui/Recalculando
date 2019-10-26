using System;
using System.Collections.Generic;
using Proyecto.Factory.CSharp;
using Proyecto.Item.ScientistLevel;
using Proyecto.LeerHTML;
using Xunit;

namespace Proyecto.LibraryModelado.Engine.test
{
    /// <summary>
    /// Test creados para el Juego del Cientifico. 
    /// </summary>
    public class UnitTestModelado
    {
        private Level level = new Level("level", null);
        private FactoryMoney factoryMoney = new FactoryMoney();
        private World world = Singleton<World>.Instance;
        private EngineScientific engineScientific = Singleton<EngineScientific>.Instance;



        [Fact]
        public void TestVerifyAddition()
        {
            /// <summary>
            /// Este Test se encaarga de verificar que las sumas estén hechas de forma correcta.
            /// </summary>
            /// <returns></returns>
            MoneyContainer dragcontainerSource = new MoneyContainer("source", level, 1, 10, 10, 10, null, 0);
            MoneyContainer dragcontainerDestintantion = new MoneyContainer("dragC", level, 1, 10, 10, 10, null, 120);
            Money moneydrag = new Money("drag", level, 20, 20, 2, 2, null, true, dragcontainerSource, 120);
            Assert.Equal(true, EngineScientific.VerifyOperation(dragcontainerDestintantion, moneydrag));
        }

        [Fact]
        public void TestOnDrop()
        {
            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>

            MoneyContainer dragSource = new MoneyContainer("drag", level, 1, 10, 10, 10, null, 1);
            MoneyContainer dragcontainerDestintantion = new MoneyContainer("dragC", level, 1, 10, 10, 10, null, 120);
            Money moneydrag = new Money("drag", level, 20, 20, 2, 2, null, true, dragSource, 120);
            Assert.Equal(true, moneydrag.Drop(dragcontainerDestintantion));
        }

        [Fact]
        public void TestOnDropUndraggable()
        {
            MoneyContainer dragcontainerSource = new MoneyContainer("source", level, 1, 10, 10, 10, null, 0);
            MoneyContainer dragcontainerDestintantion = new MoneyContainer("dragC", level, 1, 10, 10, 10, null, 120);
            Money moneydrag = new Money("drag", level, 20, 20, 2, 2, null, false, dragcontainerSource, 120);
            Assert.Equal(false, moneydrag.Drop(dragcontainerDestintantion));
        }

        [Fact]
        public void NegativeMoneyValue()
        {
            /// <summary>
            /// Nuestro juego no permite que los billetes tengan valores negativos, por esto,
            /// este test en caso de que esto suceda, ejecuta la excepción y convierte al valor en positivo.
            /// </summary>
            /// <returns></returns>
            MoneyContainer container1 = new MoneyContainer("cont1", this.level, 50, 50, 60, 60, null, 10);
            Assert.Throws<ArithmeticException>(() => new Money("name", this.level, 50, 40, 30, 20, null, false, container1, -10));
        }

        [Fact]
        public void WinPage()
        {
            /// <summary>
            /// En este juego hay dos páginas, por esto, testeamos cuando se gana una página para luego
            /// pasar a la próxima y así ganar el nivel.
            /// </summary>
            /// <returns></returns>
            MoneyContainer containerDestination1 = new MoneyContainer("Dest1", this.level, 50, 50, 60, 60, null, 10); // 60 - 50
            MoneyContainer containerDestination2 = new MoneyContainer("Dest2", this.level, 50, 50, 60, 60, null, 175); // 100 + 175
            MoneyContainer containerSource1 = new MoneyContainer("Source1", this.level, 50, 50, 60, 60, null, 0);
            MoneyContainer containerSource2 = new MoneyContainer("Source2", this.level, 50, 50, 60, 60, null, 0);

            Money moneyDrag1 = new Money("Drag1", this.level, 20, 20, 2, 2, null, true, containerSource1, 10);
            Money moneyDrag2 = new Money("Drag2", this.level, 20, 20, 2, 2, null, true, containerSource2, 175);

            moneyDrag1.Drop(containerDestination1);
            moneyDrag2.Drop(containerDestination2);

            Assert.Equal(true, engineScientific.VerifyWinPage());
        }

        [Fact]
        public void WinLevel()
        {
            /// <summary>
            /// Verifica que haya ganado el nivel completo de juego.
            /// </summary>
            /// <returns></returns>
            MoneyContainer containerDestination1 = new MoneyContainer("Dest1", this.level, 50, 50, 60, 60, null, 10);
            MoneyContainer containerDestination2 = new MoneyContainer("Dest2", this.level, 50, 50, 60, 60, null, 175);
            MoneyContainer containerSource1 = new MoneyContainer("Source1", this.level, 50, 50, 60, 60, null, 0);
            MoneyContainer containerSource2 = new MoneyContainer("Source2", this.level, 50, 50, 60, 60, null, 0);

            Money moneyDrag1 = new Money("Drag1", this.level, 20, 20, 2, 2, null, true, containerSource1, 10);
            Money moneyDrag2 = new Money("Drag2", this.level, 20, 20, 2, 2, null, true, containerSource2, 175);

            moneyDrag1.Drop(containerDestination1);
            moneyDrag2.Drop(containerDestination2);

            if (engineScientific.VerifyWinPage())
            {
                // Pagina 2.
                engineScientific.StartPage();
                MoneyContainer containerDestination3 = new MoneyContainer("Dest3", this.level, 50, 50, 60, 60, null, 50);
                MoneyContainer containerDestination4 = new MoneyContainer("Dest4", this.level, 50, 50, 60, 60, null, 200);
                MoneyContainer containerSource3 = new MoneyContainer("Source3", this.level, 50, 50, 60, 60, null, 0);
                MoneyContainer containerSource4 = new MoneyContainer("Source4", this.level, 50, 50, 60, 60, null, 0);

                Money moneyDrag3 = new Money("Drag3", this.level, 20, 20, 2, 2, null, true, containerSource3, 50);
                Money moneyDrag4 = new Money("Drag4", this.level, 20, 20, 2, 2, null, true, containerSource4, 200);

                moneyDrag3.Drop(containerDestination3);
                moneyDrag4.Drop(containerDestination4);
                engineScientific.VerifyWinPage();

                Assert.Equal(true, engineScientific.VerifyWinLevel());
            }
        }
    }
}
