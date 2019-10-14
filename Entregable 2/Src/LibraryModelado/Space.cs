//--------------------------------------------------------------------------------
// <copyright file="Space.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System.Collections.Generic;
using Proyecto.Common;

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
        /// </summary> 
        private string name { get; set; }

        /// <summary>
        /// Ancho del espacio.
        /// </summary>
        private int width;

        /// <summary>
        /// Altura del espacio.
        /// </summary>
        private int height;

        /// <summary>
        /// Unity ID del Espacio.
        /// </summary>
        private string id;

        /// <summary>
        /// Inicializa una instancia de Espacios.
        /// </summary>
        /// <param name="name">Nombre del Espacio.</param>
        /// <param name="width">Ancho del espacio.</param>
        /// <param name="height">Altura del espacio.</param>
        public Space(string name, int width, int height)
        {
            this.Name = name;
            this.ID = id;
            this.Width = width;
            this.Height = height;
            this.World = world;
            this.ItemList = new List<Items>();
        }

        /// <summary>
        /// Gets or sets del nombre del espacio.
        /// </summary>
        /// <value>String nombre del espacio.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets del Unity ID del espacio.
        /// </summary>
        /// <value>String Unity ID</value>
        public string ID { get; set; }

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

        /// <summary>
        /// Gets or sets de la lista de items pertenecientes a un espacio.
        /// </summary>
        /// <value>Lista de objetos tipo <see cref="Items"/>.</value>
        public List<Items> ItemList { get; set; }

        /// <summary>
        /// Metodo abstracto para crear Espacios en Unity.
        /// </summary>
        /// <param name="adapter">Adapter del tipo <see cref="IMainViewAdapter"/></param>
        public abstract void CreateUnityLevel(IMainViewAdapter adapter);

        /// <summary>
        /// Metodo abstracto para crear todos los items de un nivel en Unity.
        /// </summary>
        /// <param name="adapter">Adapter del tipo <see cref="IMainViewAdapter"/></param>
        public abstract void ShowLevelItems(IMainViewAdapter adapter);
    }
}