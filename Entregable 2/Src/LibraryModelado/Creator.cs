using System;
using System.Collections.Generic;
using Proyecto.LeerHTML;
using Proyecto.Item;

namespace Proyecto.LibraryModelado
{
    public class Creator
    {
        public World world;
        public Space level;
        public Items button;
        public Items image;
        public Items container;
        public Items draggableItem;


        public World AddWorld(Tag tag)
        {
            string name = "";
            int width = 0;
            int height = 0;
            List<Space> listSpace = new List<Space>();

            foreach (Atributos atributo in tag.atributos)
            {
                switch (atributo.clave)
                {
                    case "Name":
                        name = atributo.valor;
                        break;
                    case "Width":
                        width = Convert.ToInt32(atributo.valor);
                        break;
                    case "Height":
                        height = Convert.ToInt32(atributo.valor);
                        break;
                }
                world = new World(tag.Nombre, width, height, listSpace);

            }
            return world;
        }

        public Space AddLevel(Tag tag)
        {
            string name = "";
            int width = 0;
            int height = 0;
            List<Items> listItems = new List<Items>();

            foreach (Atributos atributo in tag.atributos)
            {
                switch (atributo.clave)
                {
                    case "Name":
                        name = atributo.valor;
                        break;
                    case "Width":
                        width = Convert.ToInt32(atributo.valor);
                        break;
                    case "Height":
                        height = Convert.ToInt32(atributo.valor);
                        break;
                }
                level = new Level(tag.Nombre, width, height, listItems, world);
                world.spacelist.Add(level);

            }
            return level;
        }

        public Items AddButton(Tag tag)
        {
            string name = "";
            string color = "";
            int width = 0;
            int height = 0;
            int positionX = 0;
            int positionY = 0;
            foreach (Atributos atributo in tag.atributos)
            {
                switch (atributo.clave)
                {
                    case "Name":
                        name = atributo.valor;
                        break;
                    case "Level":
                        level = world.spacelist.Find(delegate (Space L) { return L.Name == atributo.valor; });
                        break;
                    case "Width":
                        width = Convert.ToInt32(atributo.valor);
                        break;
                    case "Height":
                        height = Convert.ToInt32(atributo.valor);
                        break;
                    case "PositionX":
                        positionX = Convert.ToInt32(atributo.valor);
                        break;
                    case "PositionY":
                        positionY = Convert.ToInt32(atributo.valor);
                        break;
                    case "Color":
                        color = atributo.valor;
                        break;
                }
                Items button = new Button(tag.Nombre, level, positionX, positionY, width, height, false, color);
                level.ItemList.Add(button);

            }
            return button;
        }

        public Items AddImage(Tag tag)
        {
            string name = "";
            int width = 0;
            int height = 0;
            int positionX = 0;
            int positionY = 0;
            bool draggable = false;
            foreach (Atributos atributo in tag.atributos)
            {
                switch (atributo.clave)
                {
                    case "Name":
                        name = atributo.valor;
                        break;
                    case "Level":
                        level = world.spacelist.Find(delegate (Space L) { return L.Name == atributo.valor; });
                        break;
                    case "Width":
                        width = Convert.ToInt32(atributo.valor);
                        break;
                    case "Height":
                        height = Convert.ToInt32(atributo.valor);
                        break;
                    case "PositionX":
                        positionX = Convert.ToInt32(atributo.valor);
                        break;
                    case "PositionY":
                        positionY = Convert.ToInt32(atributo.valor);
                        break;
                    case "Draggable":
                        if (atributo.valor == "true")
                        {
                            draggable = true;
                        }
                        break;
                }
                Items image = new Image(tag.Nombre, level, positionX, positionY, width, height, draggable);
                level.ItemList.Add(image);

            }
            return image;
        }

        public Items AddDragAndDropSource(Tag tag)
        {
            string name = "";
            int width = 0;
            int height = 0;
            int positionX = 0;
            int positionY = 0;
            foreach (Atributos atributo in tag.atributos)
            {
                switch (atributo.clave)
                {
                    case "Name":
                        name = atributo.valor;
                        break;
                    case "Level":
                        level = world.spacelist.Find(delegate (Space L) { return L.Name == atributo.valor; });
                        break;
                    case "Width":
                        width = Convert.ToInt32(atributo.valor);
                        break;
                    case "Height":
                        height = Convert.ToInt32(atributo.valor);
                        break;
                    case "PositionX":
                        positionX = Convert.ToInt32(atributo.valor);
                        break;
                    case "PositionY":
                        positionY = Convert.ToInt32(atributo.valor);
                        break;
                }
                Items container = new DragAndDropSource(tag.Nombre, level, positionX, positionY, width, height, false);
                level.ItemList.Add(container);

            }
            return container;

        }

        public Items AddDragAndDropDestination(Tag tag)
        {
            string name = "";
            int width = 0;
            int height = 0;
            int positionX = 0;
            int positionY = 0;
            foreach (Atributos atributo in tag.atributos)
            {
                switch (atributo.clave)
                {
                    case "Name":
                        name = atributo.valor;
                        break;
                    case "Level":
                        level = world.spacelist.Find(delegate (Space L) { return L.Name == atributo.valor; });
                        break;
                    case "Width":
                        width = Convert.ToInt32(atributo.valor);
                        break;
                    case "Height":
                        height = Convert.ToInt32(atributo.valor);
                        break;
                    case "PositionX":
                        positionX = Convert.ToInt32(atributo.valor);
                        break;
                    case "PositionY":
                        positionY = Convert.ToInt32(atributo.valor);
                        break;
                }
                Items container = new DragAndDropDestination(tag.Nombre, level, positionX, positionY, width, height, false);
                level.ItemList.Add(container);

            }
            return container;
        }

        public Items AddDragAndDropItem(Tag tag)
        {
            string name = "";
            int width = 0;
            int height = 0;
            int positionX = 0;
            int positionY = 0;
            foreach (Atributos atributo in tag.atributos)
            {
                switch (atributo.clave)
                {
                    case "Name":
                        name = atributo.valor;
                        break;
                    case "Level":
                        level = world.spacelist.Find(delegate (Space L) { return L.Name == atributo.valor; });
                        break;
                    case "Width":
                        width = Convert.ToInt32(atributo.valor);
                        break;
                    case "Height":
                        height = Convert.ToInt32(atributo.valor);
                        break;
                    case "PositionX":
                        positionX = Convert.ToInt32(atributo.valor);
                        break;
                    case "PositionY":
                        positionY = Convert.ToInt32(atributo.valor);
                        break;
                }
                Items draggableItem = new DragAndDropItem(tag.Nombre, level, positionX, positionY, width, height, true);
                level.ItemList.Add(draggableItem);

            }
            return draggableItem;
        }
    }
}