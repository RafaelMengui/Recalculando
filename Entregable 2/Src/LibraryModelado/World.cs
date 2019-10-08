//--------------------------------------------------------------------------------
// <copyright file="Items.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System.Collections.Generic;

namespace Proyecto.LibraryModelado
{
    /// <summary>
    /// Modelo del mundo.
    /// </summary>
    public class World
    {
        /// <summary>
        /// Nombre del World.
        /// </summary>
        private string name;

        /// <summary>
        /// Ancho del World en pixeles.
        /// </summary>
        private int width;

        /// <summary>
        /// Altura del World en pixeles.
        /// </summary>
        private int height;

        /// <summary>
        /// Inicializa una instancia de World.
        /// </summary>
        /// <param name="name">Nombre del World.</param>
        /// <param name="width">Ancho del World.</param>
        /// <param name="height">Altura del World.</param>
        /// <param name="spaceList">Lista de Levels.</param>
        public World(string name, int width, int height)
        {
            this.Name = name;
            this.Width = width;
            this.Height = height;
            this.SpaceList = new List<Space>();
        }

        /// <summary>
        /// Gets or sets del nombre del espacio.
        /// </summary>
        /// <value>String nombre del espacio.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets del Ancho del espacio.
        /// </summary>
        /// <value>Ancho del Espacio.</value>
        public int Width { get; set; }

        /// <summary>
        /// Gets or sets de la altura del espacio.
        /// </summary>
        /// <value>Altura del Espacio.</value>
        public int Height { get; set; }

        public List<Space> SpaceList {get; set;}
    }
}