//--------------------------------------------------------------------------------
// <copyright file="Items.cs" company="mio Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

using System.Collections.Generic;

namespace Proyecto
{
    /// <summary>
    /// Clase abstracta de Espacio.
    /// </summary>
    public abstract class Space
    {
        /// <summary>
        /// Nombre del Espacio.
        /// </summary>
        private string name;

        /// <summary>
        /// Tamaño del espacio.
        /// </summary>
        private string size;

        /// <summary>
        /// Lista de Subespacios.
        /// </summary>
        internal List<Space> spacelist = new List<Space>(); //Tipo Espacio

        /// <summary>
        /// Inicializa una instancia de Espacios.
        /// </summary>
        /// <param name="Name">Nombre del Espacio.</param>
        /// <param name="Size">Tamaño del espacio.</param>
        /// <param name="SpaceList">Lista de Subespacios.</param>
        public Space(string Name, string Size, List<Space> SpaceList)
        {
            this.name = Name;
            this.size = Size;
        }

        /// <summary>
        /// Gets or sets del nombre del espacio.
        /// </summary>
        /// <value>String nombre del espacio.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets del tamaño del espacio.
        /// </summary>
        /// <value>Tamaño del Espacio.</value>
        public string Size { get; set; }
    }
}