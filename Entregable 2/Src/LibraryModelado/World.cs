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
    public class World : IComponent
    {
        /// <summary>
        /// Nombre del Mundo.
        /// </summary>
        private string name;

        /// <summary>
        /// Constructor. Inicializa una instancia de World.
        /// </summary>
        public World()
        {
            this.Name = name;
            this.SpaceList = new List<Space>();
        }

        /// <summary>
        /// Gets or sets del nombre del mundo.
        /// </summary>
        /// <value>String nombre del mundo.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets de la lista de espacios pertenecientes a un mundo.
        /// </summary>
        /// <value>Lista de Objetos <see cref="Space"/>.</value>
        public List<Space> SpaceList { get; set; }
    }
}