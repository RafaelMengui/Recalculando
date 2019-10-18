//--------------------------------------------------------------------------------
// <copyright file="Creator.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Proyecto.LeerHTML;
using Proyecto.Item;

namespace Proyecto.LibraryModelado
{
    /// <summary>
    /// Clase CREATOR*2
    /// Esta es la clase Creator, debido a que, es la responsable de crear los objetos de tipo.
    /// Especificamente se le llama Creator, porque es abierta a la extensión pero cerrada a la modificación.
    /// Si en un futuro quisieramos crear más objetos podríamos hacerlo, pero no modificar lo ya creado que 
    /// funciona de forma adecuada.
    /// <see cref="World"/>, <see cref="Space"/>, <see cref="Items"/>.
    /// </summary>
    public class CreatorC
    {
        /// <summary>
        /// Objeto World asignado al Creator. <see cref="World"/>.
        /// </summary>
        private World world;

        /// <summary>
        /// Objeto Space asignado al Creator (Nivel). <see cref="Space"/>.
        /// </summary>
        private Space level;

        /// <summary>
        /// Atributos String utilizados para instanciar tipo World, Level, Items.
        /// </summary>
        string name, color, image, containerName, audio, pageName;

        /// <summary>
        /// Atributos Int utilizados para instanciar tipo World, Level, Items.
        /// </summary>
        int width, height, positionX, positionY;

        bool draggable;

        /// <summary>
        /// Constructor. Instancia un objeto Creator.
        /// </summary>
        public CreatorC()
        {
            this.World = world;
            this.Level = level;
        }

        /// <summary>
        /// Gets or sets el objeto World asignado al Creator.
        /// </summary>
        /// <value>Tipo World.</value>
        public World World { get; set; }

        /// <summary>
        /// Gets or sets el objeto Level asignado al Creator.
        /// </summary>
        /// <value>Tipo Level.</value>
        public Space Level { get; set; }

        /// <summary>
        /// Metodo responsable de extraer Valores de los Atributos de un Tag, para crear un Objeto Mundo.
        /// </summary>
        /// <param name="tag"><see cref="Tag"/>.</param>
        /// <returns><see cref="World"/>.</returns>
        public World AddWorld(Tag tag)
        {
            name = tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Name"; }).Valor;
            width = Convert.ToInt32(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Width"; }).Valor);
            height = Convert.ToInt32(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Height"; }).Valor);

            this.World = new World(name, width, height);
            return this.World;
        }

        /// <summary>
        /// Metodo responsable de extraer Valores de los Atributos de un Tag, para crear un Objeto Level.
        /// Agrega el nivel creado a la lista de niveles pertenecientes al mundo asignado en el Creator.
        /// </summary>
        /// <param name="tag"><see cref="Tag"/>.</param>
        /// <returns><see cref="Space"/>.</returns>
        public Space AddLevel(Tag tag)
        {
            name = tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Name"; }).Valor;
            width = Convert.ToInt32(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Width"; }).Valor);
            height = Convert.ToInt32(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Height"; }).Valor);
            image = tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Background"; }).Valor;

            this.Level = new Level(name, width, height, image);
            this.Level.World = this.World;
            this.World.SpaceList.Add(this.Level);
            return this.Level;
        }

        /// <summary>
        /// Metodo responsable de extraer Valores de los Atributos de un Tag, para crear un Objeto Button.
        /// Agrega el Boton creado a la lista de Items pertenecientes al Nivel asignado en el Creator.
        /// </summary>
        /// <param name="tag"><see cref="Tag"/>.</param>
        /// <returns><see cref="Items"/>.</returns>
        public Items AddButton(Tag tag)
        {
            name = tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Name"; }).Valor;
            width = Convert.ToInt32(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Width"; }).Valor);
            height = Convert.ToInt32(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Height"; }).Valor);
            positionX = Convert.ToInt32(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "PositionX"; }).Valor);
            positionY = Convert.ToInt32(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "PositionY"; }).Valor);
            color = tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Color"; }).Valor;
            image = tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Photo"; }).Valor;

            Items button = new Button(name, this.Level, positionX, positionY, width, height, image, color);
            this.Level.ItemList.Add(button);
            return button;
        }

        /// <summary>
        /// Metodo responsable de extraer Valores de los Atributos de un Tag, para crear un Objeto ButtonAudio.
        /// Agrega el Boton de audio creado a la lista de Items pertenecientes al Nivel asignado en el Creator.
        /// </summary>
        /// <param name="tag"><see cref="Tag"/>.</param>
        /// <returns><see cref="Items"/>.</returns>
        public Items AddButtonAudio(Tag tag)
        {
            name = tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Name"; }).Valor;
            width = Convert.ToInt32(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Width"; }).Valor);
            height = Convert.ToInt32(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Height"; }).Valor);
            positionX = Convert.ToInt32(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "PositionX"; }).Valor);
            positionY = Convert.ToInt32(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "PositionY"; }).Valor);
            color = tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Color"; }).Valor;
            image = tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Photo"; }).Valor;
            audio = tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Audio"; }).Valor;

            Items buttonAudio = new ButtonAudio(name, this.Level, positionX, positionY, width, height, image, color, audio);
            this.Level.ItemList.Add(buttonAudio);
            return buttonAudio;
        }

        /// <summary>
        /// Metodo responsable de extraer Valores de los Atributos de un Tag, para crear un Objeto ButtonGoToPage.
        /// Agrega el Boton creado a la lista de Items pertenecientes al Nivel asignado en el Creator.
        /// </summary>
        /// <param name="tag"><see cref="Tag"/>.</param>
        /// <returns><see cref="Items"/>.</returns>
        public Items AddButtonGoToPage(Tag tag)
        {
            name = tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Name"; }).Valor;
            width = Convert.ToInt32(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Width"; }).Valor);
            height = Convert.ToInt32(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Height"; }).Valor);
            positionX = Convert.ToInt32(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "PositionX"; }).Valor);
            positionY = Convert.ToInt32(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "PositionY"; }).Valor);
            color = tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Color"; }).Valor;
            image = tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Photo"; }).Valor;
            pageName = tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "GoToPage"; }).Valor;

            Items buttonGoToPage = new ButtonGoToPage(name, this.Level, positionX, positionY, width, height, image, color, pageName);
            this.Level.ItemList.Add(buttonGoToPage);
            return buttonGoToPage;
        }

        /// <summary>
        /// Metodo responsable de extraer Valores de los Atributos de un Tag, para crear un Objeto Image.
        /// Agrega la imagen creada a la lista de Items pertenecientes al Nivel asignado en el Creator.
        /// </summary>
        /// <param name="tag"><see cref="Tag"/>.</param>
        /// <returns><see cref="Items"/>.</returns>
        public Items AddImage(Tag tag)
        {
            name = tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Name"; }).Valor;
            width = Convert.ToInt32(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Width"; }).Valor);
            height = Convert.ToInt32(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Height"; }).Valor);
            positionX = Convert.ToInt32(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "PositionX"; }).Valor);
            positionY = Convert.ToInt32(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "PositionY"; }).Valor);
            image = tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Photo"; }).Valor;

            Items _image = new Image(name, this.Level, positionX, positionY, width, height, image);
            this.Level.ItemList.Add(_image);
            return _image;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public Items AddDraggableItem(Tag tag)
        {
            name = tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Name"; }).Valor;
            width = Convert.ToInt32(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Width"; }).Valor);
            height = Convert.ToInt32(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Height"; }).Valor);
            positionX = Convert.ToInt32(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "PositionX"; }).Valor);
            positionY = Convert.ToInt32(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "PositionY"; }).Valor);
            image = tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Photo"; }).Valor;
            draggable = Convert.ToBoolean(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Draggable"; }).Valor);

            Items draggableItem = new DraggableItem(name, this.Level, positionX, positionY, width, height, image, draggable);
            this.Level.ItemList.Add(draggableItem);
            return draggableItem;
        }

        /// <summary>
        /// Metodo responsable de extraer Valores de los Atributos de un Tag, para crear un Objeto DragAndDropSource.
        /// Agrega el container creado a la lista de Items pertenecientes al Nivel asignado en el Creator.
        /// </summary>
        /// <param name="tag"><see cref="Tag"/>.</param>
        /// <returns><see cref="Items"/>.</returns>
        public Items AddDragAndDropSource(Tag tag)
        {
            name = tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Name"; }).Valor;
            width = Convert.ToInt32(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Width"; }).Valor);
            height = Convert.ToInt32(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Height"; }).Valor);
            positionX = Convert.ToInt32(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "PositionX"; }).Valor);
            positionY = Convert.ToInt32(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "PositionY"; }).Valor);
            image = tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Photo"; }).Valor;

            Items container = new DragAndDropSource(name, this.Level, positionX, positionY, width, height, image);
            this.Level.ItemList.Add(container);
            return container;
        }

        /// <summary>
        /// Metodo responsable de extraer Valores de los Atributos de un Tag, para crear un Objeto DragAndDropDestination.
        /// Agrega el container creado a la lista de Items pertenecientes al Nivel asignado en el Creator.
        /// </summary>
        /// <param name="tag"><see cref="Tag"/>.</param>
        /// <returns><see cref="Items"/>.</returns>
        public Items AddDragAndDropDestination(Tag tag)
        {
            name = tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Name"; }).Valor;
            width = Convert.ToInt32(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Width"; }).Valor);
            height = Convert.ToInt32(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Height"; }).Valor);
            positionX = Convert.ToInt32(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "PositionX"; }).Valor);
            positionY = Convert.ToInt32(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "PositionY"; }).Valor);
            image = tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Photo"; }).Valor;

            Items container = new DragAndDropDestination(name, this.Level, positionX, positionY, width, height, image);
            this.Level.ItemList.Add(container);
            return container;
        }

        /// <summary>
        /// Metodo responsable de extraer Valores de los Atributos de un Tag, para crear un Objeto DragAndDropItem.
        /// Agrega el item creado a la lista de Items pertenecientes al Nivel asignado en el Creator.
        /// Agrega el item creado a un container DragAndDropSource, especificado en el Xml.
        /// </summary>
        /// <param name="tag"><see cref="Tag"/>.</param>
        /// <returns><see cref="Items"/>.</returns>
        public Items AddDragAndDropItem(Tag tag)
        {
            name = tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Name"; }).Valor;
            width = Convert.ToInt32(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Width"; }).Valor);
            height = Convert.ToInt32(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Height"; }).Valor);
            positionX = Convert.ToInt32(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "PositionX"; }).Valor);
            positionY = Convert.ToInt32(tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "PositionY"; }).Valor);
            image = tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Photo"; }).Valor;
            containerName = tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Container"; }).Valor;

            Items container = this.Level.ItemList.Find(delegate (Items item) { return item.Name == containerName; });
            Items draggableItem = new DragAndDropItem(name, this.Level, positionX, positionY, width, height, image, container);
            this.Level.ItemList.Add(draggableItem);
            return draggableItem;
        }
    }
}