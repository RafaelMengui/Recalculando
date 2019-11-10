//--------------------------------------------------------------------------------
// <copyright file="World.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System.Collections.Generic;

namespace Proyecto.LibraryModelado
{
    /// <summary>
    /// Clase responsable de crear objetos mundo.
    /// Implementa la interfaz <see cref="IComponent"/>.
    /// </summary>
    public class World : IComponent
    {
        /// <summary>
        /// Nombre del Mundo.
        /// </summary>
        private string name;

        private string id;

        /// <summary>
        /// Initializes a new instance of world.
        /// </summary>
        public World()
        {
            this.Name = this.name;
            this.ID = id;
            this.SpaceList = new List<Space>();
            this.IsActive = true;
        }

        /// <summary>
        /// Gets or sets que indican si el item esta actualmente activo en pantalla.
        /// Por predeterminado sera true.
        /// </summary>
        /// <value></value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets del nombre del mundo.
        /// </summary>
        /// <value>String nombre del mundo.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets del ID.
        /// </summary>
        /// <value></value>
        public string ID { get; set; }

        /// <summary>
        /// Gets de la lista de espacios pertenecientes a un mundo.
        /// </summary>
        /// <value>Lista de Objetos <see cref="Space"/>.</value>
        public List<Space> SpaceList { get; }
    }
}