//--------------------------------------------------------------------------------
// <copyright file="Space.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using Proyecto.Common;
using System.Collections.Generic;

namespace Proyecto.LibraryModelado
{
    /// <summary>
    /// Clase abstracta de Espacio.
    /// </summary>
    public abstract class Space : IComponent
    {
        /// <summary>
        /// Nombre del Mundo al que Pertencen.
        /// </summary>
        private World world;

        /// <summary>
        /// Nombre del Espacio.
        /// </summary> 
        private string name;

        /// <summary>
        /// Unity ID del Espacio.
        /// </summary>
        private string id;

        /// <summary>
        /// Inicializa una instancia de Espacios.
        /// </summary>
        /// <param name="name">Nombre del Espacio.</param>
        public Space(string name)
        {
            this.Name = name;
            this.ID = id;
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
        /// Gets or sets del nombre del mundo al que pertenece.
        /// </summary>
        /// <value>String nombre del mundo.</value>
        public World World { get; set; }

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
    }
}