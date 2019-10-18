//--------------------------------------------------------------------------------
// <copyright file="ButtonGoToPage.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using Proyecto.Common;
using Proyecto.LibraryModelado;
using System;

namespace Proyecto.Item
{
    /// <summary>
    /// Clase de Botones que reedirigen a otra pagina. Hereda de <see cref="Items"/>, e implementa la interfaz <see cref="IButton"/>.
    /// </summary>
    public class ButtonGoToPage : Items, IButton
    {
        /// <summary>
        /// Accion de mostrar otra pagina.
        /// </summary>
        private Action<string> _event;

        /// <summary>
        /// Color del Boton.
        /// </summary>
        private string color;

        /// <summary>
        /// Pagina que muestra el boton.
        /// </summary>
        private string pageName;

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
        /// <param name="pageName">Pagina para mostrar.</param>
        public ButtonGoToPage(string name, Space level, int positionX, int positionY, int width, int height, string image, string color, string pageName)
        : base(name, level, positionX, positionY, width, height, image)
        {
            this.Color = color;
            this.PageName = pageName;
            this.Event = _event;
        }

        /// <summary>
        /// Gets or sets del Color del Boton.
        /// </summary>
        /// <value>string codigo en hexadecimal.</value>
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets de la pagina a mostrar.
        /// </summary>
        /// <value>string nombre del la pagina.</value>
        public string PageName { get; set; }

        /// <summary>
        /// Gets or sets del evento del boton.
        /// </summary>
        /// <value>Action.</value>
        public Action<string> Event { get; set; }
        
        /// <summary>
        /// Acciones realizadas por el boton.
        /// Busca el nivel que coincida con el nivel que mostrara al ser apretado, y obtiene su ID.
        /// </summary>
        public void Click(string text)
        {
            this.Event(this.Level.World.SpaceList.Find(delegate (Space level) { return level.Name == this.PageName; }).ID);
        }
    }
}