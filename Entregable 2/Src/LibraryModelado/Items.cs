//--------------------------------------------------------------------------------
// <copyright file="Items.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using Proyecto.Common;


namespace Proyecto.LibraryModelado
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
        private Space level;

        private string id;

        /// <summary>
        /// Posicion en eje Horizontal en pixeles.
        /// </summary>
        private int positionX;

        /// <summary>
        /// Posicion en eje Vertical en pixeles.
        /// </summary>
        private int positionY;

        /// <summary>
        /// Ancho en Pixeles.
        /// </summary>
        private int width;

        /// <summary>
        /// Altura en pixeles.
        /// </summary>
        private int height;

        private string image;

        /// <summary>
        /// Inicializa una instancia de Item.
        /// </summary>
        /// <param name="Name">Nombre del Item.</param>
        /// <param name="Level">Nivel al que pertence.</param>
        /// <param name="PositionX">Posicion en eje horizontal en pixeles.</param>
        /// <param name="PositionY">Posicion en eje vertical en pixeles.</param>
        /// <param name="Width">Ancho en pixeles.</param>
        /// <param name="Height">Altura en pixeles.</param>
        public Items(string name, Space level, int positionX, int positionY, int width, int height, string image)
        {
            this.Name = name;
            this.Level = level;
            this.ID = id;
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

        public string ID{get;set;}

        /// <summary>
        /// Gets or sets de Posicion en eje Horizontal en pixeles.
        /// </summary>
        /// <value>Int posicion en eje horizontal.</value>
        public int PositionX { get; set; }

        /// <summary>
        /// Gets or sets dePosicion en eje Vertical en pixeles.
        /// </summary>
        /// <value>Int posicion en eje vertical.</value>
        public int PositionY { get; set; }

        /// <summary>
        /// Gets or sets de Ancho en Pixeles.
        /// </summary>
        /// <value>Int ancho en pixeles.</value>
        public int Width { get; set; }

        /// <summary>
        /// Gets or sets de Altura en pixeles.
        /// </summary>
        /// <value>Int altura en pixeles.</value>
        public int Height { get; set; }

        public string Image { get; set; }

        public abstract string CreateUnityItem(IMainViewAdapter adapter);
        protected string unityItem { get; set; }
    }
}