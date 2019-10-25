//--------------------------------------------------------------------------------
// <copyright file="Items.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
namespace Proyecto.LibraryModelado
{
    /// <summary>
    /// Clase abstracta de Items en el modelado.
    /// Implementa la interfaz <see cref="IComponent"/>.
    /// </summary>
    public abstract class Items : IComponent
    {
        /// <summary>
        /// Unity ID del item.
        /// </summary>
        private string id;

        /// <summary>
        /// Initializes a new instance of Items.
        /// </summary>
        /// <param name="name">Nombre del Item.</param>
        /// <param name="level">Nivel al que pertence.</param>
        /// <param name="positionX">Posicion en eje horizontal en pixeles.</param>
        /// <param name="positionY">Posicion en eje vertical en pixeles.</param>
        /// <param name="width">Ancho en pixeles.</param>
        /// <param name="height">Altura en pixeles.</param>
        /// <param name="image">Imagen del Item.</param>
        public Items(string name, Space level, float positionX, float positionY, float width, float height, string image)
        {
            this.Name = name;
            this.Level = level;
            this.ID = this.id;
            this.PositionX = positionX;
            this.PositionY = positionY;
            this.Width = width;
            this.Height = height;
            this.Image = image;
        }

        /// <summary>
        /// Gets or sets del nombre del item.
        /// </summary>
        /// <value>String nombre del item.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets del Nivel al que pertenece el Item.
        /// </summary>
        /// <value>Level al que pertence.</value>
        public Space Level { get; set; }

        /// <summary>
        /// Gets or sets del UnityID del Objeto.
        /// </summary>
        /// <value>Unity ID.</value>
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets de Posicion en eje Horizontal en pixeles.
        /// </summary>
        /// <value>float posicion en eje horizontal.</value>
        public float PositionX { get; set; }

        /// <summary>
        /// Gets or sets dePosicion en eje Vertical en pixeles.
        /// </summary>
        /// <value>float posicion en eje vertical.</value>
        public float PositionY { get; set; }

        /// <summary>
        /// Gets or sets de Ancho en Pixeles.
        /// </summary>
        /// <value>float ancho en pixeles.</value>
        public float Width { get; set; }

        /// <summary>
        /// Gets or sets de Altura en pixeles.
        /// </summary>
        /// <value>float altura en pixeles.</value>
        public float Height { get; set; }

        /// <summary>
        /// Gets or sets la imagen del item.
        /// </summary>
        /// <value>String path to image.</value>
        public string Image { get; set; }
    }
}