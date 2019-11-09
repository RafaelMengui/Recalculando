//--------------------------------------------------------------------------------
// <copyright file="Food.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System;
using Proyecto.LibraryModelado;

namespace Proyecto.Item.KitchenLevel
{
    /// <summary>
    /// Clase responsable de crear objetos de alimentos arrastrables en el modelado.
    /// Hereda de la clase abstracta <see cref="Items"/>.
    /// </summary>
    public class Food : Items
    {
        /// <summary>
        /// Accion que se ejecutara al soltar un alimento.
        /// </summary>
        private Action<string, float, float> onDropFood;

        /// <summary>
        /// Initializes a new instance of Food.
        /// </summary>
        /// <param name="name">Nombre del Food.</param>
        /// <param name="level">Nivel al que pertence.</param>
        /// <param name="positionX">Posicion en eje horizontal en pixeles.</param>
        /// <param name="positionY">Posicion en eje vertical en pixeles.</param>
        /// <param name="width">Ancho en pixeles.</param>
        /// <param name="height">Altura en pixeles.</param>
        /// <param name="image">Imagen del Food.</param>
        /// <param name="draggable">Bool que define si es arrastrable.</param>
        /// <param name="container">Container Source en donde es creado.</param>
        public Food(string name, Space level, float positionX, float positionY, float width, float height, string image, bool draggable, Items container)
        : base(name, level, positionX, positionY, width, height, image)
        {
            this.Draggable = draggable;
            this.Container = container;
            this.OnDropFood = this.onDropFood;
        }

        /// <summary>
        /// Gets or sets del container.
        /// </summary>
        /// <value><see cref="Items"/>.</value>
        public Items Container { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether el item es arrastrable.
        /// </summary>
        /// <value>Bool arrastrable.</value>
        public bool Draggable { get; set; }

        /// <summary>
        /// Gets or sets de la accion a realizar al soltar el alimento.
        /// </summary>
        /// <value>Action.</value>
        public Action<string, float, float> OnDropFood { get; set; }

        /// <summary>
        /// Accion realizada al soltar el alimento.
        /// </summary>
        public void Drop()
        {
        }
    }
}