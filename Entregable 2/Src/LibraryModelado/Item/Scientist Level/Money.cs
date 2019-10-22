//--------------------------------------------------------------------------------
// <copyright file="Money.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System;
using Proyecto.LibraryModelado;

namespace Proyecto.Item.ScientistLevel
{
    /// <summary>
    /// Clase responsable de crear dinero arrastrable en el modelado.
    /// Hereda de la clase abstracta <see cref="Items"/>.
    /// </summary>
    public class Money : Items
    {
        /// <summary>
        /// Accion que se ejecutara al soltar el dinero.
        /// </summary>
        private Action<string, float, float> onDropMoney;

        /// <summary>
        /// Initializes a new instance of Money.
        /// </summary>
        /// <param name="name">Nombre de la moneda.</param>
        /// <param name="level">Nivel al que pertence.</param>
        /// <param name="positionX">Posicion en eje horizontal en pixeles.</param>
        /// <param name="positionY">Posicion en eje vertical en pixeles.</param>
        /// <param name="width">Ancho en pixeles.</param>
        /// <param name="height">Altura en pixeles.</param>
        /// <param name="image">Imagen de la moneda.</param>
        /// <param name="draggable">Bool que define si es arrastrable.</param>
        /// <param name="container">Container Source en donde es creado.</param>
        /// <param name="value">Valor de la moneda.</param>
        public Money(string name, Space level, int positionX, int positionY, int width, int height, string image, bool draggable, Items container, int value)
        : base(name, level, positionX, positionY, width, height, image)
        {
            this.Value = value;
            this.Draggable = draggable;
            this.Container = container;
            this.OnDropMoney = this.onDropMoney;
        }

        /// <summary>
        /// Gets or sets del valor de la moneda.
        /// </summary>
        /// <value>int valor de la moneda.</value>
        public int Value { get; set; }

        /// <summary>
        /// Gets or sets del container en el que es creado inicialmente el Item.
        /// </summary>
        /// <value><see cref="DragContainer"/>.</value>
        public Items Container { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether el item es arrastrable.
        /// </summary>
        /// <value>Bool arrastrable.</value>
        public bool Draggable { get; set; }

        /// <summary>
        /// Gets or sets de la accion a realizar al soltar el dinero.
        /// </summary>
        /// <value>Action.</value>
        public Action<string, float, float> OnDropMoney { get; set; }

        /// <summary>
        /// Accion realizada al soltar el dinero.
        /// </summary>
        public void Drop()
        {
            this.OnDropMoney(this.ID, this.PositionX, this.PositionY);
        }
    }
}