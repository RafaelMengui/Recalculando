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
        string name;
        string color;
        int width;
        int height;
        int positionX;
        int positionY;
        string image;
        string containerID;


        public Creator()
        {
            this.World = world;
            this.Level = level;
        }

        public World AddWorld(Tag tag)
        {
            name = tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "Name"; }).valor;
            width = Convert.ToInt32(tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "Width"; }).valor);
            height = Convert.ToInt32(tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "Height"; }).valor);

            this.World = new World(name, width, height);
            return this.World;
        }

        public Space AddLevel(Tag tag)
        {
            name = tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "Name"; }).valor;
            width = Convert.ToInt32(tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "Width"; }).valor);
            height = Convert.ToInt32(tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "Height"; }).valor);
            image = tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "Background"; }).valor;

            this.Level = new Level(name, width, height, image);
            this.World.SpaceList.Add(this.Level);
            return this.Level;
        }

        public Items AddButton(Tag tag)
        {
            name = tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "Name"; }).valor;
            width = Convert.ToInt32(tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "Width"; }).valor);
            height = Convert.ToInt32(tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "Height"; }).valor);
            positionX = Convert.ToInt32(tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "PositionX"; }).valor);
            positionY = Convert.ToInt32(tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "PositionY"; }).valor);
            color = tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "Color"; }).valor;
            image = tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "Photo"; }).valor;

            Items button = new Button(name, this.Level, positionX, positionY, width, height, image, color);
            this.Level.ItemList.Add(button);
            return button;
        }

        public Items AddImage(Tag tag)
        {
            name = tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "Name"; }).valor;
            width = Convert.ToInt32(tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "Width"; }).valor);
            height = Convert.ToInt32(tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "Height"; }).valor);
            positionX = Convert.ToInt32(tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "PositionX"; }).valor);
            positionY = Convert.ToInt32(tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "PositionY"; }).valor);
            image = tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "Photo"; }).valor;

            Items _image = new Image(name, this.Level, positionX, positionY, width, height, image);
            this.Level.ItemList.Add(_image);
            return _image;
        }

        public Items AddDragAndDropSource(Tag tag)
        {
            name = tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "Name"; }).valor;
            width = Convert.ToInt32(tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "Width"; }).valor);
            height = Convert.ToInt32(tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "Height"; }).valor);
            positionX = Convert.ToInt32(tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "PositionX"; }).valor);
            positionY = Convert.ToInt32(tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "PositionY"; }).valor);
            image = tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "Photo"; }).valor;

            Items container = new DragAndDropSource(name, this.Level, positionX, positionY, width, height, image);
            this.Level.ItemList.Add(container);
            return container;
        }

        public Items AddDragAndDropDestination(Tag tag)
        {
            name = tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "Name"; }).valor;
            width = Convert.ToInt32(tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "Width"; }).valor);
            height = Convert.ToInt32(tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "Height"; }).valor);
            positionX = Convert.ToInt32(tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "PositionX"; }).valor);
            positionY = Convert.ToInt32(tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "PositionY"; }).valor);
            image = tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "Photo"; }).valor;

            Items container = new DragAndDropDestination(name, this.Level, positionX, positionY, width, height, image);
            this.Level.ItemList.Add(container);
            return container;
        }

        public Items AddDragAndDropItem(Tag tag)
        {
            name = tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "Name"; }).valor;
            width = Convert.ToInt32(tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "Width"; }).valor);
            height = Convert.ToInt32(tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "Height"; }).valor);
            positionX = Convert.ToInt32(tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "PositionX"; }).valor);
            positionY = Convert.ToInt32(tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "PositionY"; }).valor);
            image = tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "Photo"; }).valor;
            
            string containerName = tag.atributos.Find(delegate (Atributos atr) { return atr.clave == "Container"; }).valor;
            Items container = this.Level.ItemList.Find(delegate (Items item) {return item.Name == containerName;});

            Items draggableItem = new DragAndDropItem(name, this.Level, positionX, positionY, width, height, image, container);
            this.Level.ItemList.Add(draggableItem);
            return draggableItem;
        }
    }
}