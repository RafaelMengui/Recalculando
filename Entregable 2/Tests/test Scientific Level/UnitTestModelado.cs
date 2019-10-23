using System;
using Proyecto.Engine;
using Proyecto.LibraryModelado;
using Proyecto.Factory.CSharp;
using Proyecto.Item.ScientistLevel;
using Xunit;

namespace Proyecto.Engine.test
{
    public class UnitTestModelado
    {
        private Level level = new Level("level", null);

        [Fact]
        public void TestVerifyAddition()
        {
            Level level = new Level("level", null);
            MoneyContainer container2 = new MoneyContainer("cont2", level, 50, 50, 60, 60, null, 0);
            MoneyContainer container1 = new MoneyContainer("cont1", level, 50, 50, 60, 60, null, 0);
            MoneyContainer dragcontainerSource = new MoneyContainer("source", level, 1, 10, 10, 10, null, 0);
            MoneyContainer dragcontainerDestintantion = new MoneyContainer("dragC", level, 1, 10, 10, 10, null, 120);

            Money money2 = new Money("name2", level, 60, 60, 50, 50, null, true, container2, 70);
            Money money1 = new Money("name1", level, 50, 50, 50, 50, null, true, container1, 50);
            Money moneydrag = new Money("drag", level, 20, 20, 2, 2, null, true, dragcontainerSource, 120);

            Assert.Equal(true, Engine.VerifyOperation(dragcontainerDestintantion, moneydrag));
        }
    }
}
