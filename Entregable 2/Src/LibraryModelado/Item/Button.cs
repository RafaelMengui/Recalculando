//--------------------------------------------------------------------------------
// <copyright file="Button.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System;
using Proyecto.Common;
using Proyecto.LibraryModelado;

namespace Proyecto.Item
{
    /// <summary>
    /// Clase de Botones. Hereda de <see cref="Items"/>, e implementa la interfaz <see cref="IButton"/>.
    /// </summary>
    public class Button : Items, IButton
    {
        /// <summary>
        /// Accion del boton.
        /// </summary>
        private Action<string> _event;

        /// <summary>
        /// Color del Boton.
        /// </summary>
        private string color;

        /// <summary>
        /// Constructor. Instancia Objetos Button.
        /// </summary>
        /// <param name="name">Nombre del boton.</param>
        /// <param name="level">Nivel al que pertence.</param>
        /// <param name="positionX">Posicion en eje horizontal en pixeles.</param>
        /// <param name="positionY">Posicion en eje vertical en pixeles.</param>
        /// <param name="width">Ancho en pixeles.</param>
        /// <param name="height">Altura en pixeles.</param>
        /// <param name="image">Imagen del boton.</param>
        /// <param name="color">Color del boton en Hexadecimal.</param>
        public Button(string name, Space level, int positionX, int positionY, int width, int height, string image, string color)
        : base(name, level, positionX, positionY, width, height, image)
        {
            this.Color = color;
            this.Event = _event;
        }

        /// <summary>
        /// Gets or sets del Color del Boton.
        /// </summary>
        /// <value>string codigo en hexadecimal.</value>
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets del evento del boton.
        /// </summary>
        /// <value>Action.</value>
        public Action<string> Event { get; set; }

        /// <summary>
        /// Accion realizada por el boton.
        /// </summary>
        public void Click(string text)
        {
            this.Event("");
        }
    }
}