using Proyecto.LeerHTML;
using Proyecto.LibraryModelado;
using Proyecto.Item;
using System.Linq;
using System;

namespace Proyecto.FactoryCSharp2
{
    public class FactoryDraggableItem
    {
        private string name, image, containerName;
        private int width, height, positionX, positionY;
        private bool draggable;
        private Space level;
        World world = Singleton<World>.Instance;

        public IComponent MakeDraggableItem(Tag tag)
        {
            this.name = tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Name"; }).Valor;
            this.level = world.SpaceList.Last();
            this.width = Convert.ToInt32(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Width"; }).Valor);
            this.height = Convert.ToInt32(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Height"; }).Valor);
            this.positionX = Convert.ToInt32(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "PositionX"; }).Valor);
            this.positionY = Convert.ToInt32(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "PositionY"; }).Valor);
            this.image = tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Photo"; }).Valor;
            this.containerName = tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Container"; }).Valor;
            this.draggable = Convert.ToBoolean(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Draggable"; }).Valor);
            
            Items container = this.level.ItemList.Find(delegate (Items item) { return item.Name == containerName; });
            Items draggableItem = new DraggableItem(this.name, this.level, this.positionX, this.positionY, this.width, this.height, this.image, this.draggable, container);
            this.level.ItemList.Add(draggableItem);
            return draggableItem;
        }
    }
}