using System.Collections.Generic;
using Proyecto.Common;
using Proyecto.LibraryModelado;

namespace Proyecto.Item.NivelCocina
{
    /// <summary>
    /// Clase Bowl. Hereda de <see cref="Items"/>.
    /// </summary>
    public class Bowl : Items
    {
        /// <summary>
        /// Constructor. Instancia Objetos Bowl .
        /// </summary>
        /// <param name="name">Nombre del Item.</param>
        /// <param name="level">Nivel al que pertence.</param>
        /// <param name="positionX">Posicion en eje horizontal en pixeles.</param>
        /// <param name="positionY">Posicion en eje vertical en pixeles.</param>
        /// <param name="width">Ancho en pixeles.</param>
        /// <param name="height">Altura en pixeles.</param>
        /// <param name="image">Imagen del Item.</param>
        public Bowl(string name, Space level, int positionX, int positionY, int width, int height, string image)
        : base(name, level, positionX, positionY, width, height, image)
        {
            this.InTheBowl = new List<Food>();
            this.IncorrectItems = new List<DragAndDropItem>();
        }

        /// <summary>
        /// Lista de objetos Food, que seran soltados dentro del container.
        /// </summary>
        /// <value><see cref="Food"/>.</value>
        public List<Food> InTheBowl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public List<DragAndDropItem> IncorrectItems { get; set; }

    }
}