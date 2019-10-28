//--------------------------------------------------------------------------------
// <copyright file="Space.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System.Collections.Generic;

namespace Proyecto.LibraryModelado
{
    /// <summary>
    /// Clase abstracta de espacios en el modelado.
    /// Implementa la interfaz <see cref="IComponent"/>.
    /// </summary>
    public abstract class Space : IComponent
    {
        /// <summary>
        /// Nombre del Mundo al que Pertencen.
        /// </summary>
        private World world;

        /// <summary>
        /// Unity ID del Espacio.
        /// </summary>
        private string id;

        /// <summary>
        /// Initializes a new instance of space.
        /// </summary>
        /// <param name="name">Nombre del Espacio.</param>
        /// <param name="image">Nombre de la imagen de fondo del espacio.</param>
        public Space(string name, string image)
        {
            this.Name = name;
            this.Image = image;
            this.ID = this.id;
            this.Width = 1270;
            this.Height = 570;
            this.World = this.world;
            this.ItemList = new List<Items>();
        }

        /// <summary>
        /// Gets or sets del nombre del espacio.
        /// </summary>
        /// <value>String nombre del espacio.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets del nombre de la imgen de fondo del espacio.
        /// </summary>
        /// <value>string nombre de imagen.</value>
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets del Unity ID del espacio.
        /// </summary>
        /// <value>String Unity ID.</value>
        public string ID { get; set; }

        /// <summary>
        /// Gets del ancho del nivel.
        /// </summary>
        /// <value>float ancho del nivel.</value>
        public float Width { get; }

        /// <summary>
        /// Gets de la altura del nivel.
        /// </summary>
        /// <value>float altura del nivel.</value>
        public float Height { get; }

        /// <summary>
        /// Gets or sets del nombre del mundo al que pertenece.
        /// </summary>
        /// <value>String nombre del mundo.</value>
        public World World { get; set; }

        /// <summary>
        /// Gets de la lista de items pertenecientes a un espacio.
        /// </summary>
        /// <value>Lista de objetos tipo <see cref="Items"/>.</value>
        public List<Items> ItemList { get; }
    }
}