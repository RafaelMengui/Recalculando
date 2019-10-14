//--------------------------------------------------------------------------------
// <copyright file="World.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System.Collections.Generic;

namespace Proyecto.LibraryModelado
{
    /// <summary>
    /// Clase Modelo del mundo.
    /// </summary>
    public class World
    {
        /// <summary>
        /// Nombre del Mundo.
        /// </summary>
        private string name;

        /// <summary>
        /// Ancho del mundo en pixeles.
        /// </summary>
        private int width;

        /// <summary>
        /// Altura del mundo en pixeles.
        /// </summary>
        private int height;

        /// <summary>
        /// Constructor. Inicializa una instancia de World.
        /// </summary>
        /// <param name="name">Nombre del mundo.</param>
        /// <param name="width">Ancho del mundo.</param>
        /// <param name="height">Altura del mundo.</param>
        public World(string name, int width, int height)
        {
            this.Name = name;
            this.Width = width;
            this.Height = height;
            this.SpaceList = new List<Space>();
        }

        /// <summary>
        /// Gets or sets del nombre del mundo.
        /// </summary>
        /// <value>String nombre del mundo.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets del Ancho del mundo.
        /// </summary>
        /// <value>Ancho del mundo.</value>
        public int Width { get; set; }

        /// <summary>
        /// Gets or sets de la altura del mundo.
        /// </summary>
        /// <value>Altura del mundo.</value>
        public int Height { get; set; }

        /// <summary>
        /// Gets or sets de la lista de espacios pertenecientes a un mundo.
        /// </summary>
        /// <value>Lista de Objetos <see cref="Space"/>.</value>
        public List<Space> SpaceList { get; set; }
    }
}