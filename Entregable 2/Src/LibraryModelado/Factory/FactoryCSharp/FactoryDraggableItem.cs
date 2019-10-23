//--------------------------------------------------------------------------------
// <copyright file="FactoryDraggableItem.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System;
using Proyecto.Item;
using Proyecto.LeerHTML;
using Proyecto.LibraryModelado;
using System.Linq;

namespace Proyecto.Factory.CSharp
{
    /// <summary>
    /// Esta clase es la responsable de crear items que van a ser arrastables.
    /// Utiliza la interfaz IFactoryComponent.
    /// </summary>
    public class FactoryDraggableItem : IFactoryComponent
    {
        /// <summary>
        /// Nombre del item.
        /// </summary>
        private string name;

        /// <summary>
        /// Imagen del item.
        /// </summary>
        private string image;

        /// <summary>
        /// Container del item.
        /// </summary>
        private string containerName;

        /// <summary>
        /// Ancho del item.
        /// </summary>
        private int width;

        /// <summary>
        /// Altura del item.
        /// </summary>
        private int height;

        /// <summary>
        /// Posicion en X del item.
        /// </summary>
        private int positionX;

        /// <summary>
        /// Posicion en Y del item.
        /// </summary>
        private int positionY;

        /// <summary>
        /// Define si el item es arrastrable.
        /// </summary>
        private bool draggable;

        /// <summary>
        /// Nivel al que pertenece el item.
        /// </summary>
        private Space level;

        /// <summary>
        /// Instancia del mundo.
        /// </summary>
        private World world = Singleton<World>.Instance;

        /// <summary>
        /// Sobrescribe el metodo abstracto de IFactoryComponent.
        /// Tiene la responsabilidad de crear el componente de tipo <see cref="DraggableItem"/>.
        /// </summary>
        /// <param name="tag">Tag <see cref="Tag"/>.</param>
        /// <returns>Componente <see cref="IComponent"/>.</returns>
        public override IComponent MakeComponent(Tag tag)
        {
            this.name = tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "Name"; }).Valor;
            this.level = this.world.SpaceList.Last();
            this.width = Convert.ToInt32(tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "Width"; }).Valor);
            this.height = Convert.ToInt32(tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "Height"; }).Valor);
            this.positionX = Convert.ToInt32(tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "PositionX"; }).Valor);
            this.positionY = Convert.ToInt32(tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "PositionY"; }).Valor);
            this.image = tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "Photo"; }).Valor;
            this.containerName = tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "Container"; }).Valor;
            this.draggable = Convert.ToBoolean(tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "Draggable"; }).Valor);
            Items container = this.level.ItemList.Find(delegate(Items item) { return item.Name == this.containerName; });
            Items draggableItem = new DraggableItem(this.name, this.level, this.positionX, this.positionY, this.width, this.height, this.image, this.draggable, container);
            this.level.ItemList.Add(draggableItem);
            return draggableItem;
        }
    }
}