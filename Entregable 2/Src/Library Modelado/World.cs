//--------------------------------------------------------------------------------
// <copyright file="Items.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using  System.Collections.Generic;

namespace Proyecto
{
    /// <summary>
    /// Modelo del mundo.
    /// </summary>
    public class World 
    {


        /// <summary>
        /// Nombre del World.
        /// 
        /// </summary>
        /// 
        private string name;

        /// <summary>
        /// Tamaño del World.
        /// </summary>
        private string size;

        /// <summary>
        /// Lista de Levels.
        /// </summary>
        internal List<Space> spacelist = new List<Space>(); //Tipo Space

        /// <summary>
        /// Inicializa una instancia de World.
        /// </summary>
        /// <param name="Name">Nombre del World.</param>
        /// <param name="Size">Tamaño del World.</param>
        /// <param name="SpaceList">Lista de Levels.</param>
        /// 
        public World(string Name, string Size, List<Space> SpaceList)
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