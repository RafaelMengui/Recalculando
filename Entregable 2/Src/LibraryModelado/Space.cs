//--------------------------------------------------------------------------------
// <copyright file="Items.cs" company="mio Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

using System.Collections.Generic;

namespace Proyecto.LibraryModelado
{
    /// <summary>
    /// Clase abstracta de Espacio.
    /// </summary>
    public abstract class Space
    {
        /// <summary>
        /// Nombre del Mundo al que Pertencen.
        /// </summary>
        private World world;


        /// <summary>
        /// Nombre del Espacio.
        /// 
        /// </summary>
        /// 
        private string name;

        /// <summary>
        /// Ancho del espacio.
        /// </summary>
        private int width;

        /// <summary>
        /// Altura del espacio.
        /// </summary>
        private int height;

        /// <summary>
        /// Lista de Subespacios.
        /// </summary>
        internal List<Items> itemList = new List<Items>(); //Tipo Espacio

        /// <summary>
        /// Inicializa una instancia de Espacios.
        /// </summary>
        /// <param name="Name">Nombre del Espacio.</param>
        /// <param name="Width">Ancho del espacio.</param>
        /// /// <param name="Height">Altura del espacio.</param>
        /// <param name="World">Mundo al que pertenece.</param>
        /// <param name="SpaceList">Lista de Subespacios.</param>
        public Space(string Name, int Width, int Height, List<Items> ItemList, World world)
        {
            this.name = Name;
            this.width = Width;
            this.height = Height;
            this.world = World;
            this.itemList = ItemList;
        }

        /// <summary>
        /// Gets or sets del nombre del espacio.
        /// </summary>
        /// <value>String nombre del espacio.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets del nombre del espacio.
        /// </summary>
        /// <value>String nombre del espacio.</value>
        public World World { get; set; }

        /// <summary>
        /// Gets or sets del Ancho del espacio.
        /// </summary>
        /// <value>Ancho del Espacio.</value>
        public int Width { get; set; }

        /// <summary>
        /// Gets or sets de la Altura del espacio.
        /// </summary>
        /// <value>Altura del Espacio.</value>
        public int Height { get; set; }

        public List<Items> ItemList {get; set;}
    }
}