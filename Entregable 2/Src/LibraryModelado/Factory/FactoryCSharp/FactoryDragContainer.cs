using Proyecto.LeerHTML;
using Proyecto.LibraryModelado;
using Proyecto.Item;
using System.Linq;
using System;

namespace Proyecto.Factory.CSharp
{
    public class FactoryDragContainer: IFactoryComponent
    {
        private string name, image;
        private int width, height, positionX, positionY;
        private Space level;
        World world = Singleton<World>.Instance;

        public override IComponent MakeComponent(Tag tag)
        {
            this.name = tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Name"; }).Valor;
            this.level = world.SpaceList.Last();
            this.width = Convert.ToInt32(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Width"; }).Valor);
            this.height = Convert.ToInt32(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Height"; }).Valor);
            this.positionX = Convert.ToInt32(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "PositionX"; }).Valor);
            this.positionY = Convert.ToInt32(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "PositionY"; }).Valor);
            this.image = tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Photo"; }).Valor;
                       
            Items dragContainer = new DragContainer(this.name, this.level, this.positionX, this.positionY, this.width, this.height, this.image);
            this.level.ItemList.Add(dragContainer);
            return dragContainer;
        }
    }
}