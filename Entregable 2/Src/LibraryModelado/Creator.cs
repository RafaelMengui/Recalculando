using System;
using System.Collections.Generic;
using Proyecto.LeerHTML;
using Proyecto.Item;

namespace Proyecto.LibraryModelado
{
    public class Creator
    {
        static World world;
        static Space level;

        public static World AddWorld(Tag tag)
        {
            string name = "";
            int width = 0;
            int height = 0;
            List<Space> listSpace = new List<Space>();

            foreach (Atributos atributo in tag.atributos)
            {
                switch (atributo.clave)
                {
                    case "World":
                        name = atributo.valor;
                        break;
                    case "Width":
                        width = Convert.ToInt32(atributo.valor);
                        break;
                    case "Height":
                        height = Convert.ToInt32(atributo.valor);
                        break;
                }
            }
            world = new World(tag.Nombre, width, height, listSpace);
            return world;
        }

        public static Space AddLevel(Tag tag)
        {
            string name = "";
            int width = 0;
            int height = 0;
            List<Items> listItems = new List<Items>();

            foreach (Atributos atributo in tag.atributos)
            {
                switch (atributo.clave)
                {
                    case "Level":
                        name = atributo.valor;
                        break;
                    case "Width":
                        width = Convert.ToInt32(atributo.valor);
                        break;
                    case "Height":
                        height = Convert.ToInt32(atributo.valor);
                        break;
                }
            }

            level = new Level(tag.Nombre, width, height, listItems, world);
            world.spacelist.Add(level);
            return level;
        }

        public static Items AddButton(Tag tag)
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
                    case "Button":
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
            }
            Items button = new Button(tag.Nombre, level, positionX, positionY, width, height, false, color);
            level.itemList.Add(button);
            return button;
        }

        public static Items AddImage(Tag tag)
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
                    case "Image":
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
            }
            Items image = new Image(tag.Nombre, level, positionX, positionY, width, height, draggable);
            level.itemList.Add(image);
            return image;
        }

        public static Items AddDragAndDropSource(Tag tag)
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
                    case "DragAndDropSource":
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
            }
            Items container = new DragAndDropSource(tag.Nombre, level, positionX, positionY, width, height, false);
            level.itemList.Add(container);
            return container;
        }

        public static Items AddDragAndDropDestination(Tag tag)
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
                    case "DragAndDropDestination":
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
            }
            Items container = new DragAndDropDestination(tag.Nombre, level, positionX, positionY, width, height, false);
            level.itemList.Add(container);
            return container;
        }

        public static Items AddDragAndDropItem(Tag tag)
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
                    case "DragAndDropItem":
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
            }
            Items draggableItem = new DragAndDropItem(tag.Nombre, level, positionX, positionY, width, height, true);
            level.itemList.Add(draggableItem);
            return draggableItem;
        }
    }
}