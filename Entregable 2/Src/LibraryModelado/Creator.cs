using System;
using System.Collections.Generic;
using Proyecto.LeerHTML;
using Proyecto.Item;

namespace Proyecto.LibraryModelado
{
    public class Creator
    {
        public World World { get; set; }
        public Space Level { get; set; }

        private World world;
        private Space level;

        public Creator()
        {
            this.World = world;
            this.Level = level;
        }

        public World AddWorld(Tag tag)
        {
            string name = (tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "Name"; }).valor);
            int width = Convert.ToInt32(tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "Width"; }).valor);
            int height = Convert.ToInt32(tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "Height"; }).valor);

            this.World = new World(name, width, height);
            return this.World;
        }

        public Space AddLevel(Tag tag)
        {
            string name = (tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "Name"; }).valor);
            int width = Convert.ToInt32(tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "Width"; }).valor);
            int height = Convert.ToInt32(tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "Height"; }).valor);

            this.Level = new Level(name, width, height);
            this.World.SpaceList.Add(this.Level);
            return this.Level;
        }

        public Items AddButton(Tag tag)
        {

            string name = (tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "Name"; }).valor);
            int width = Convert.ToInt32(tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "Width"; }).valor);
            int height = Convert.ToInt32(tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "Height"; }).valor);
            int positionX = Convert.ToInt32(tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "PositionX"; }).valor);
            int positionY = Convert.ToInt32(tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "PositionY"; }).valor);
            string color = (tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "Color"; }).valor);

            //Console.WriteLine(name + " " + width + " " + height + " " + PositionX + " " + PositionY + " " + Color + " " + this.Level.Name);
            Items button = new Button(name, this.Level, positionX, positionY, width, height, false, color);
            this.Level.ItemList.Add(button);
            return button;
        }

        public Items AddImage(Tag tag)
        {

            string name = (tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "Name"; }).valor);
            int width = Convert.ToInt32(tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "Width"; }).valor);
            int height = Convert.ToInt32(tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "Height"; }).valor);
            int positionX = Convert.ToInt32(tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "PositionX"; }).valor);
            int positionY = Convert.ToInt32(tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "PositionY"; }).valor);

            Items image = new Image(name, this.Level, positionX, positionY, width, height, false);
            this.Level.ItemList.Add(image);
            return image;
        }

        public Items AddDragAndDropSource(Tag tag)
        {
            string name = (tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "Name"; }).valor);
            int width = Convert.ToInt32(tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "Width"; }).valor);
            int height = Convert.ToInt32(tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "Height"; }).valor);
            int positionX = Convert.ToInt32(tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "PositionX"; }).valor);
            int positionY = Convert.ToInt32(tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "PositionY"; }).valor);

            Items container = new DragAndDropSource(name, this.Level, positionX, positionY, width, height, false);
            this.Level.ItemList.Add(container);
            return container;
        }


        public Items AddDragAndDropDestination(Tag tag)
        {
            string name = (tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "Name"; }).valor);
            int width = Convert.ToInt32(tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "Width"; }).valor);
            int height = Convert.ToInt32(tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "Height"; }).valor);
            int positionX = Convert.ToInt32(tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "PositionX"; }).valor);
            int positionY = Convert.ToInt32(tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "PositionY"; }).valor);

            Items container = new DragAndDropDestination(name, this.Level, positionX, positionY, width, height, false);
            this.Level.ItemList.Add(container);
            return container;
        }

        public Items AddDragAndDropItem(Tag tag)
        {
            string name = (tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "Name"; }).valor);
            int width = Convert.ToInt32(tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "Width"; }).valor);
            int height = Convert.ToInt32(tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "Height"; }).valor);
            int positionX = Convert.ToInt32(tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "PositionX"; }).valor);
            int positionY = Convert.ToInt32(tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "PositionY"; }).valor);

            Items draggableItem = new DragAndDropItem(name, this.Level, positionX, positionY, width, height, true);
            Console.WriteLine(draggableItem.Name);
            this.Level.ItemList.Add(draggableItem);
            return draggableItem;
        }
    }
}