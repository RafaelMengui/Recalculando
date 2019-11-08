//--------------------------------------------------------------------------------
// <copyright file="Label.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using Proyecto.LibraryModelado;

namespace Proyecto.Item
{
    /// <summary>
    /// Clase responsable de crear etiquetas en el modelado.
    /// Hereda de la clase abstracta <see cref="Items"/>.
    /// </summary>
    public class Label : Items
    {
        /// <summary>
        /// Initializes a new instance of Label.
        /// </summary>
        /// <param name="name">Nombre del texto.</param>
        /// <param name="level">Nivel al que pertence.</param>
        /// <param name="positionX">Posicion en eje horizontal en pixeles.</param>
        /// <param name="positionY">Posicion en eje vertical en pixeles.</param>
        /// <param name="width">Ancho en pixeles.</param>
        /// <param name="height">Altura en pixeles.</param>
        /// <param name="image">Imagen del texto.</param>
        /// <param name="text">Texto de la etiqueta.</param>
        /// <param name="size">Tamaño del texto.</param>
        /// <param name="bold">Bool si el texto es en bold.</param>
        /// <param name="italic">Bool si el texto es en italic.</param>
        public Label(string name, Space level, float positionX, float positionY, float width, float height, string image, string text, int size, bool bold, bool italic)
        : base(name, level, positionX, positionY, width, height, image)
        {
            this.Text = text;
            this.Size = size;
            this.Bold = bold;
            this.Italic = italic;
        }

        /// <summary>
        /// Gets or sets del texto.
        /// </summary>
        /// <value></value>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets del Tamaño del texto.
        /// </summary>
        /// <value>Int.</value>
        public int Size { get; set; }

        /// <summary>
        /// Gets or sets indicating whether el texto va en bold.
        /// </summary>
        /// <value>Bool.</value>
        public bool Bold { get; set; }

        /// <summary>
        /// Gets or sets indicating whether el texto va en italics.
        /// </summary>
        /// <value>Bool.</value>
        public bool Italic { get; set; }
    }
}