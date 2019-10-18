using Proyecto.Common;
using Proyecto.LibraryModelado;

namespace Proyecto.Item.Nivel_Cientifico
{
    /// <summary>
    /// Clase Money. Hereda de <see cref="Items"/>.
    /// </summary>
    public class Money : Items
    {
        /// <summary>
        /// Valor monetario del objeto.
        /// </summary>
        private int value;

        /// <summary>
        /// Container en el que es creado inicialmente el Item.
        /// </summary>
        private Items container;

        /// <summary>
        /// Constructor. Instancia un objeto Money.
        /// </summary>
        /// <param name="name">Nombre de la moneda.</param>
        /// <param name="level">Nivel al que pertence.</param>
        /// <param name="positionX">Posicion en eje horizontal en pixeles.</param>
        /// <param name="positionY">Posicion en eje vertical en pixeles.</param>
        /// <param name="width">Ancho en pixeles.</param>
        /// <param name="height">Altura en pixeles.</param>
        /// <param name="image">Imagen de la moneda.</param>
        /// <param name="value">Valor de la moneda.</param>
        /// <param name="container">Container Source en donde es creado.</param>
        public Money(string name, Space level, int positionX, int positionY, int width, int height, string image, int value, Items container)
        : base(name, level, positionX, positionY, width, height, image)
        {
            this.Value = value;
            this.Container = container;
        }

        /// <summary>
        /// Gets or sets del valor de la moneda.
        /// </summary>
        /// <value>int valor de la moneda.</value>
        public int Value { get; set; }

        /// <summary>
        /// Gets or sets del container en el que es creado inicialmente el Item.
        /// </summary>
        /// <value><see cref="DragAndDropSource"/>.</value>
        public Items Container { get; set; }
    }
}