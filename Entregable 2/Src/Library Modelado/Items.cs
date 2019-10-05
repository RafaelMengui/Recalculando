//--------------------------------------------------------------------------------
// <copyright file="Items.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

namespace Proyecto
{
    /// <summary>
    /// Clase abstracta de Items.
    /// </summary>
    public abstract class Items
    {
        /// <summary>
        /// Nombre del Item.
        /// </summary>
        private string name;

        /// <summary>
        /// Nivel al que pertenece el Item.
        /// </summary>
        private Level level;

        /// <summary>
        /// Posicion en eje Horizontal en pixeles.
        /// </summary>
        private string positionX;

        /// <summary>
        /// Posicion en eje Vertical en pixeles.
        /// </summary>
        private string positionY;

        /// <summary>
        /// Ancho en Pixeles.
        /// </summary>
        private string width;

        /// <summary>
        /// Altura en pixeles.
        /// </summary>
        private string height;

        /// <summary>
        /// Bool que define si un item es arrastable o no.
        /// </summary>
        private bool draggable;

        /// <summary>
        /// Inicializa una instancia de Item.
        /// </summary>
        /// <param name="Name">Nombre del Item.</param>
        /// <param name="Level">Nivel al que pertence.</param>
        /// <param name="PositionX">Posicion en eje horizontal en pixeles.</param>
        /// <param name="PositionY">Posicion en eje vertical en pixeles.</param>
        /// <param name="Width">Ancho en pixeles.</param>
        /// <param name="Height">Altura en pixeles.</param>
        /// <param name="Draggable">Item arrastrable.</param>
        public Items(string Name, Level Level, string PositionX, string PositionY, string Width, string Height, bool Draggable)
        {
            this.name = Name;
            this.level = Level;
            this.positionX = PositionX;
            this.positionY = PositionY;
            this.width = Width;
            this.height = Height;
            this.draggable = Draggable;
        }

        /// <summary>
        /// Gets or sets del nombre del item.
        /// </summary>
        /// <value>String nombre del item.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets del Nivel al que pertenece el Item.
        /// </summary>
        /// <value>String nivel al que pertence.</value>
        public Level Level { get; set; }

        /// <summary>
        /// Gets or sets de Posicion en eje Horizontal en pixeles.
        /// </summary>
        /// <value>String posicion en eje horizontal.</value>
        public string PositionX { get; set; }

        /// <summary>
        /// Gets or sets dePosicion en eje Vertical en pixeles.
        /// </summary>
        /// <value>String posicion en eje vertical.</value>
        public string PositionY { get; set; }

        /// <summary>
        /// Gets or sets de Ancho en Pixeles.
        /// </summary>
        /// <value>String ancho en pixeles.</value>
        public string Width { get; set; }

        /// <summary>
        /// Gets or sets de Altura en pixeles.
        /// </summary>
        /// <value>String altura en pixeles.</value>
        public string Height { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether un item es arrastable o no.
        /// Escribo algunas partes en ingles porque el docfx me obliga a que aparezca esa
        /// frase.
        /// </summary>
        /// <value>Bool de si es arrastrable.</value>
        public bool Draggable { get; set; }
    }
}