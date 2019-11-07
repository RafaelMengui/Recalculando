//--------------------------------------------------------------------------------
// <copyright file="DraggableItem.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System;
using Proyecto.LibraryModelado;

namespace Proyecto.Item
{
    /// <summary>
    /// Clase responsable de crear items arrastrables en el modelado.
    /// Hereda de la clase abstracta <see cref="Items"/>.
    /// </summary>
    public class DraggableItem : Items, IDraggable
    {
        /// <summary>
        /// Accion que se ejecutara al soltar un item.
        /// </summary>
        private Action<DraggableItem, DragContainer> onDrop;

        /// <summary>
        /// Initializes a new instance of DraggableItem.
        /// </summary>
        /// <param name="name">Nombre del Item.</param>
        /// <param name="level">Nivel al que pertence.</param>
        /// <param name="positionX">Posicion en eje horizontal en pixeles.</param>
        /// <param name="positionY">Posicion en eje vertical en pixeles.</param>
        /// <param name="width">Ancho en pixeles.</param>
        /// <param name="height">Altura en pixeles.</param>
        /// <param name="image">Imagen del Item.</param>
        /// <param name="draggable">Bool que define si es arrastrable.</param>
        /// <param name="container">Container en donde es creado el item.</param>
        public DraggableItem(string name, Space level, float positionX, float positionY, float width, float height, string image, bool draggable, IContainer container)
        : base(name, level, positionX, positionY, width, height, image)
        {
            this.Draggable = draggable;
            this.Container = container;
            this.OnDrop = this.onDrop;
        }

        /// <summary>
        /// Gets or sets del container.
        /// </summary>
        /// <value><see cref="Items"/>.</value>
        public IContainer Container { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether el item es arrastrable.
        /// </summary>
        /// <value>Bool arrastrable.</value>
        public bool Draggable { get; set; }

        /// <summary>
        /// Gets or sets de la accion a realizar al soltar el item.
        /// </summary>
        /// <value>Action.</value>
        public Action<DraggableItem, DragContainer> OnDrop { get; set; }

        /// <summary>
        /// Accion realizada al soltar el Item.
        /// </summary>
        public bool Drop(IContainer container)
        {
            DragContainer dragContainer;
            try
            {
                dragContainer = container as DragContainer;
            }
            catch (System.InvalidCastException)
            {
                throw new System.InvalidCastException($"Invalid cast operation as DragContainer.");
            }

            return this.Draggable;
        }
    }
}