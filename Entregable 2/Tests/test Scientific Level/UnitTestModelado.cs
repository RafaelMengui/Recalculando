using System;
using System.Collections.Generic;
using Proyecto.Factory.CSharp;
using Proyecto.Item.ScientistLevel;
using Proyecto.LeerHTML;
using Xunit;

namespace Proyecto.LibraryModelado.Engine.test
{
    public class UnitTestModelado
    {
        private Level level = new Level("level", null);
        private FactoryMoney factoryMoney = new FactoryMoney();
        private World world = Singleton<World>.Instance;
        

        [Fact]
        public void TestVerifyAddition()
        {
            MoneyContainer container2 = new MoneyContainer("cont2", level, 50, 50, 60, 60, null, 0);
            MoneyContainer container1 = new MoneyContainer("cont1", level, 50, 50, 60, 60, null, 0);
            MoneyContainer dragcontainerSource = new MoneyContainer("source", level, 1, 10, 10, 10, null, 0);
            MoneyContainer dragcontainerDestintantion = new MoneyContainer("dragC", level, 1, 10, 10, 10, null, 120);

            Money money2 = new Money("name2", level, 60, 60, 50, 50, null, true, container2, 70);
            Money money1 = new Money("name1", level, 50, 50, 50, 50, null, true, container1, 50);
            Money moneydrag = new Money("drag", level, 20, 20, 2, 2, null, true, dragcontainerSource, 120);

            Assert.Equal(true, Engine.VerifyOperation(dragcontainerDestintantion, moneydrag));
        }

        [Fact]
        public void TestOnDrop()
        {
            MoneyContainer container2 = new MoneyContainer("cont2", level, 50, 50, 60, 60, null, 0);
            MoneyContainer container1 = new MoneyContainer("cont1", level, 50, 50, 60, 60, null, 0);
            MoneyContainer dragcontainerSource = new MoneyContainer("source", level, 1, 10, 10, 10, null, 0);
            MoneyContainer dragcontainerDestintantion = new MoneyContainer("dragC", level, 1, 10, 10, 10, null, 120);
            Money money2 = new Money("name2", level, 60, 60, 50, 50, null, false, container2, 70);
            Money money1 = new Money("name1", level, 50, 50, 50, 50, null, false, container1, 50);
            Money moneydrag = new Money("drag", level, 20, 20, 2, 2, null, true, dragcontainerSource, 120);

            Assert.Equal(true, moneydrag.Drop(dragcontainerDestintantion));
        }

        [Fact]
        public void TestOnDropUndraggable()
        {
            MoneyContainer container2 = new MoneyContainer("cont2", level, 50, 50, 60, 60, null, 0);
            MoneyContainer container1 = new MoneyContainer("cont1", level, 50, 50, 60, 60, null, 0);
            MoneyContainer dragcontainerSource = new MoneyContainer("source", level, 1, 10, 10, 10, null, 0);
            MoneyContainer dragcontainerDestintantion = new MoneyContainer("dragC", level, 1, 10, 10, 10, null, 120);
            Money money2 = new Money("name2", level, 60, 60, 50, 50, null, false, container2, 70);
            Money money1 = new Money("name1", level, 50, 50, 50, 50, null, false, container1, 50);
            Money moneydrag = new Money("drag", level, 20, 20, 2, 2, null, false, dragcontainerSource, 120);

            Assert.Equal(false, moneydrag.Drop(dragcontainerDestintantion));
        }

        [Fact]
        public void NegativeMoneyValue()
        {
            this.world.Name = "world";
            this.world.SpaceList.Add(this.level);
            MoneyContainer container1 = new MoneyContainer("cont1", this.level, 50, 50, 60, 60, null, 0);
            Atributos name = new Atributos("Name", "money");
            Atributos width = new Atributos("Width", "100");
            Atributos height = new Atributos("Height", "100");
            Atributos positionX = new Atributos("PositionX", "20");
            Atributos positionY = new Atributos("PositionY", "10");
            Atributos image = new Atributos("Photo", "photo.png");
            Atributos container = new Atributos("Container", "cont1");
            Atributos draggable = new Atributos("Draggable", "false");
            Atributos value = new Atributos("Value", "-10");
            this.level.ItemList.Add(container1);

            List<Atributos> list = new List<Atributos>(){name, width, height, positionX, positionY, image, container, draggable, value};
            Tag tag = new Tag("Money", list);

            Assert.Throws<ArithmeticException>(() => this.factoryMoney.MakeComponent(tag));
        }
    }
}
